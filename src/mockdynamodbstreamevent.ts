import { DynamoDBStreamEvent } from "aws-lambda";

export function createMockDynamoDBStreamEvent(
  eventName: "INSERT" | "MODIFY" | "REMOVE"
): DynamoDBStreamEvent {
  switch (eventName) {
    case "INSERT":
      return mockInsertEvent;
    case "MODIFY":
      return mockMoifyEvent;
    case "REMOVE":
      return mockRemoveEvent;
  }
}

const mockInsertEvent: DynamoDBStreamEvent = {
  Records: [
    {
      eventID: "1234567890",
      eventName: "INSERT",
      eventVersion: "1.1",
      eventSource: "aws:dynamodb",
      awsRegion: "us-east-2",
      dynamodb: {
        ApproximateCreationDateTime: 123456,
        SequenceNumber: "1234567890",
        SizeBytes: 123,
        StreamViewType: "NEW_AND_OLD_IMAGES",
        Keys: {
          PK: {
            S: "OUTCOME#1#1232634576",
          },
          SK: {
            S: "ODD#SPORTSBOOK1",
          },
        },
        NewImage: {
          ATTRIBUTES: {
            M: {
              price: {
                N: "130",
              },
              sportsbook: {
                S: "sportsbook3",
              },
            },
          },
          TTL: {
            S: "1746313703",
          },
          TYPE: {
            S: "ODD",
          },
        },
      },
      eventSourceARN: "arn",
    },
  ],
} as DynamoDBStreamEvent;

const mockMoifyEvent: DynamoDBStreamEvent = {
  Records: [
    {
      eventID: "1234567890",
      eventName: "MODIFY",
      eventVersion: "1.1",
      eventSource: "aws:dynamodb",
      awsRegion: "us-east-2",
      dynamodb: {
        ApproximateCreationDateTime: 123456,
        SequenceNumber: "1234567890",
        SizeBytes: 123,
        StreamViewType: "NEW_AND_OLD_IMAGES",
        Keys: {
          PK: {
            S: "OUTCOME#1#1232634576",
          },
          SK: {
            S: "ODD#SPORTSBOOK1",
          },
        },
        OldImage: {
          ATTRIBUTES: {
            M: {
              price: {
                N: "120",
              },
              sportsbook: {
                S: "sportsbook3",
              },
            },
          },
          TTL: {
            S: "1746313703",
          },
          TYPE: {
            S: "ODD",
          },
        },
        NewImage: {
          ATTRIBUTES: {
            M: {
              price: {
                N: "130",
              },
              sportsbook: {
                S: "sportsbook3",
              },
            },
          },
          TTL: {
            S: "1746313703",
          },
          TYPE: {
            S: "ODD",
          },
        },
      },
      eventSourceARN: "arn",
    },
  ],
} as DynamoDBStreamEvent;

const mockRemoveEvent: DynamoDBStreamEvent = {
  Records: [
    {
      eventID: "1234567890",
      eventName: "REMOVE",
      eventVersion: "1.1",
      eventSource: "aws:dynamodb",
      awsRegion: "us-east-2",
      dynamodb: {
        ApproximateCreationDateTime: 123456,
        SequenceNumber: "1234567890",
        SizeBytes: 123,
        StreamViewType: "NEW_AND_OLD_IMAGES",
        Keys: {
          PK: {
            S: "OUTCOME#1#1232634576",
          },
          SK: {
            S: "ODD#SPORTSBOOK1",
          },
        },
        OldImage: {
          ATTRIBUTES: {
            M: {
              price: {
                N: "130",
              },
              sportsbook: {
                S: "sportsbook3",
              },
            },
          },
          TTL: {
            S: "1746313703",
          },
          TYPE: {
            S: "ODD",
          },
        },
      },
      eventSourceARN: "arn",
    },
  ],
} as DynamoDBStreamEvent;
