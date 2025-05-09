import { AttributeValue } from "@aws-sdk/client-dynamodb";
import { unmarshall } from "@aws-sdk/util-dynamodb";
import { DynamoDBRecord } from "aws-lambda";
import { Keys, Odd } from "../sports/odd";
import { findArbitrageBets } from "../better/arbitrageBetter";
import { query } from "./client";
import { Bet } from "../sports/bet";

interface UnmarshalledRecord {
    keys: Keys | null;
    oldItem: Odd | null;
    newItem: Odd | null;
}

export class Processor {
    async handleRecord(record: DynamoDBRecord): Promise<void> {
        const { keys, oldItem, newItem } = this.processRecord(record);

        if (!keys) return;

        switch (record.eventName) {
            case "INSERT":
                if (!newItem) return;

                console.log("New Odd", {
                    keys,
                    newItem,
                });

                let arbitrageOdds: Odd[] = await findArbitrageOdds(
                    keys,
                    newItem
                );

                console.log("Arbitrage Odds", arbitrageOdds);

                const bets: Bet[] = findArbitrageBets(newItem, arbitrageOdds);
                console.log("Bets", bets);

                break;

            case "MODIFY":
                break;

            case "REMOVE":
                break;

            default:
                console.warn("Unhandled event type: ", record.eventName);
        }
    }

    public processRecord(record: DynamoDBRecord): UnmarshalledRecord {
        const { dynamodb } = record;

        if (!dynamodb) {
            return {
                keys: null,
                oldItem: null,
                newItem: null,
            };
        }

        const keys = dynamodb.Keys
            ? (unmarshall(
                  dynamodb.Keys as Record<string, AttributeValue>
              ) as Odd)
            : null;

        const oldItem = dynamodb.OldImage
            ? (unmarshall(
                  dynamodb.OldImage as Record<string, AttributeValue>
              ) as Odd)
            : null;

        const newItem = record.dynamodb?.NewImage
            ? (unmarshall(
                  dynamodb.NewImage as Record<string, AttributeValue>
              ) as Odd)
            : null;

        return { keys, oldItem, newItem };
    }
}

async function findArbitrageOdds(
    newItemKeys: Keys,
    newItem: Odd
): Promise<Odd[]> {
    let queryItems: Record<string, AttributeValue>[] | undefined = (
        await query(newItemKeys.PK)
    ).Items;

    if (!queryItems || queryItems.length == 0) {
        throw new Error("Odds query failed");
    }

    const arbitrageOdds: Odd[] = [];
    queryItems.forEach((queryItem) => {
        /*
         * Based on the market, see if we need to get points
         */
        const item = unmarshall(queryItem) as Odd;

        if (item.MARKET === 1) {
            if (item.RESULT !== newItem.RESULT) {
                arbitrageOdds.push(item);
            }
        } else if (item.MARKET === 3) {
            if (
                item.RESULT !== newItem.RESULT &&
                item.POINTS == newItem.POINTS
            ) {
                arbitrageOdds.push(item);
            }
        }
    });

    return arbitrageOdds;
}
