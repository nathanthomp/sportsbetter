import { getClient } from "./client";
import { ScanCommand } from "@aws-sdk/client-dynamodb";

import { handle } from "./handler";

import { createMockDynamoDBStreamEvent } from "./mockdynamodbstreamevent";

// async function scanTable(tableName: string) {
//     const client = getClient();
//     const params = {
//         TableName: tableName,
//     };

//     try {
//         const command = new ScanCommand(params);
//         const data = await client.send(command);
//         console.log("Scan succeeded:", data.Items);
//     } catch (error) {
//         console.error("Error scanning table:", error);
//     }
// }

// scanTable("OddsTable");

// const mockEvent = createMockDynamoDBStreamEvent("INSERT");
const mockEvent = createMockDynamoDBStreamEvent("MODIFY");
// const mockEvent = createMockDynamoDBStreamEvent("REMOVE");
handle(mockEvent);
