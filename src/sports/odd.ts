export interface Keys {
    PK: string;
    SK: string;
}

export interface Odd extends Keys {
    sportsbook: string;
    PRICE: number;
    event: string;
    league: number;
    MARKET: number;
    RESULT: string;
    POINTS: number;
}
