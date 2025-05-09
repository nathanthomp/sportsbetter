import { DynamoDBStreamEvent } from "aws-lambda";
import { Processor } from "./processor";

export const handler = async (event: DynamoDBStreamEvent) => {
    const processor: Processor = new Processor();
    try {
        const processPromises = event.Records.map(async (record) => {
            try {
                console.log("Processing...");
                await processor.handleRecord(record);
                console.log("...Processed");
            } catch (error) {
                console.error("Error processing record:", error);
            }
        });
        await Promise.all(processPromises);
    } catch (error) {
        console.error("Stream processing failed:", error);
        throw error;
    }
};
