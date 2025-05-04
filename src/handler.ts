import { DynamoDBRecord, DynamoDBStreamEvent } from "aws-lambda";

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
  const type = record.dynamodb?.NewImage?.TYPE.S;

  if (type !== "ODD") {
    return;
  }

  // New odd has been inserted
}

async function handleModifyRecord(record: DynamoDBRecord) {
  let type: string | undefined;

  const newImageType = record.dynamodb?.NewImage?.TYPE.S;
  const oldImageType = record.dynamodb?.OldImage?.TYPE.S;

  if (newImageType !== oldImageType) {
    throw new Error("Mismatched types");
  }

  if (newImageType !== "ODD") {
    return;
  }

  // An existing odd has been changed
}

async function handleRemoveRecord(record: DynamoDBRecord) {
  const type = record.dynamodb?.OldImage?.TYPE.S;

  if (type !== "ODD") {
    return;
  }

  // An existing odd has been removed
}
