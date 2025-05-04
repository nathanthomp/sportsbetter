import { DynamoDBClient } from "@aws-sdk/client-dynamodb";

let client: DynamoDBClient | null = null;

export function getClient(): DynamoDBClient {
  if (client) {
    return client;
  }
  client = new DynamoDBClient({ region: "us-east-2" });
  return client;
}
