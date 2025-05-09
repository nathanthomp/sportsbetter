import { Odd } from "../sports/odd";
import { Bet } from "../sports/bet";
import { toImpliedProbability } from "./util";

export function findArbitrageBets(
    currentOdd: Odd,
    arbitrageOdds: Odd[]
): Bet[] {
    const bets: Bet[] = [];
    arbitrageOdds.forEach((arbitrageOdd) => {
        console.log("Comparing NewOdd to ArbitrageOdd");

        if (hasArbitrageBet(currentOdd, arbitrageOdd)) {
            const bet = getArbitrageBet(currentOdd, arbitrageOdd);
            if (bet) {
                bets.push(bet);
            }
        }
    });
    return bets;
}

function hasArbitrageBet(currentOdd: Odd, arbitrageOdd: Odd): boolean {
    const currentImpliedProbability: number = toImpliedProbability(
        currentOdd.PRICE
    );

    const arbitrageImpliedProbability: number = toImpliedProbability(
        arbitrageOdd.PRICE
    );

    return currentImpliedProbability + arbitrageImpliedProbability < 1;
}

function getArbitrageBet(currentOdd: Odd, arbitrageOdd: Odd): Bet | undefined {
    // Get the greater of the two odd prices => this is the underdog
    // Take the underdog and calculate the return for a high bet
    // Take the other odd price (as the favorite)

    let underdogOdd: Odd;
    let favoriteOdd: Odd;
    if (currentOdd.PRICE > arbitrageOdd.PRICE) {
        underdogOdd = currentOdd;
        favoriteOdd = arbitrageOdd;
    } else {
        underdogOdd = arbitrageOdd;
        favoriteOdd = currentOdd;
    }

    let underdogBet: Bet = new Bet(underdogOdd);
    let favoriteBet: Bet = new Bet(favoriteOdd);
    // Put more money on the underdog
    favoriteBet.setWager(1.0);
    underdogBet.setWager(Number.MAX_SAFE_INTEGER);
}
