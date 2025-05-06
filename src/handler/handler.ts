import { DynamoDBRecord, DynamoDBStreamEvent } from "aws-lambda";
import { AttributeValue, QueryCommand } from "@aws-sdk/client-dynamodb";
import { findArbitrageBets } from "../better/arbitrageBetter";
import { query } from "./client";

export const handle = async (event: DynamoDBStreamEvent) => {
    try {
        for (const record of event.Records) {
            try {
                await handleRecord(record);
            } catch (error) {
                console.error("Failed to process record:", error);
            }
        }
    } catch (error) {
        console.error("Stream processing failed:", error);
        throw error;
    }
};

async function handleRecord(record: DynamoDBRecord): Promise<void> {
    switch (record.eventName) {
        case "INSERT":
            await handleInsertRecord(record);
            break;
        case "MODIFY":
            await handleModifyRecord(record);
            break;
        case "REMOVE":
            await handleRemoveRecord(record);
            break;
    }
}

async function handleInsertRecord(record: DynamoDBRecord) {
    // New odd has been inserted
    const recordPk = record.dynamodb?.Keys?.PK.S;
    if (!recordPk) return;
    const recordResult = record.dynamodb?.NewImage?.RESULT.S;

    console.log("New Record:", record.dynamodb?.NewImage);

    let queryItems: Record<string, AttributeValue>[] | undefined;
    try {
        queryItems = (await query(recordPk)).Items;
        if (!queryItems) return;
    } catch (error) {
        console.error(error);
        throw error;
    }

    const arbitrageRecords: Record<string, AttributeValue>[] = [];
    queryItems.forEach((queryItem) => {
        const queryItemResult = queryItem.RESULT.S;
        if (queryItemResult !== recordResult) {
            arbitrageRecords.push(queryItem);
        }
    });

    console.log("Arbitrage Records", arbitrageRecords);

    findArbitrageBets(record, arbitrageRecords);
}

async function handleModifyRecord(record: DynamoDBRecord) {
    // An existing odd has been changed
}

async function handleRemoveRecord(record: DynamoDBRecord) {
    // An existing odd has been removed
}
