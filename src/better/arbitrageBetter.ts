import { AttributeValue } from "@aws-sdk/client-dynamodb";
import { DynamoDBRecord } from "aws-lambda";

export function findArbitrageBets(
    record: DynamoDBRecord,
    arbitrageRecords: Record<string, AttributeValue>[]
) {}
