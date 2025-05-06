import {
    DynamoDBClient,
    QueryCommand,
    QueryCommandOutput,
} from "@aws-sdk/client-dynamodb";

let client: DynamoDBClient | null = null;

function getClient(): DynamoDBClient {
    if (client) return client;
    client = new DynamoDBClient({ region: "us-east-2" });
    return client;
}

export async function query(pk: string): Promise<QueryCommandOutput> {
    const queryCommand = new QueryCommand({
        TableName: "OddsTable",
        KeyConditionExpression: "PK = :pk",
        ExpressionAttributeValues: {
            ":pk": { S: pk },
        },
    });

    return await getClient().send(queryCommand);
}
