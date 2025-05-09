import { Odd } from "./odd";

export class Bet {
    private odd: Odd;
    private wager: number;

    public constructor(odd: Odd) {
        this.odd = odd;
        this.wager = 0.0;
    }

    public setWager(wager: number) {
        this.wager = this.wager;
    }
}
