export function toImpliedProbability(american: number): number {
    if (american > 0) {
        return 100 / (american + 100);
    }

    const absoluteAmerican: number = Math.abs(american);
    return absoluteAmerican / (absoluteAmerican + 100);
}

export function toReturn(american: number, wager: number) {
    /*
     * Wager: Put $5 on bet
     * Return:
     */
}
