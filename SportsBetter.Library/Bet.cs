using System;

namespace SportsBetter.Library
{
    public class Bet
    {
        /// <summary>
        /// The dollar amount profit made if the bet wins. If the american odds are greater than 0,
        /// profit = wager * (american odds / 100). Else, profit = wager / (absolute value of 
        /// american odds / 100).
        /// </summary>
        private static decimal CalculateProfit(int odds, decimal wager)
        {
            return odds > 0 
                ? Math.Round((wager * odds) / 100, 2)
                : Math.Round((wager / Math.Abs(odds)) * 100, 2);
        }

        /// <summary>
        /// The dollar amount wager.
        /// </summary>
        public decimal Wager { get; private set; }

        /// <summary>
        /// The american odds.
        /// </summary>
        public int Odds { get; }

        /// <summary>
        /// The dollar amount profit made if the bet wins.
        /// </summary>
        public decimal Profit { get; private set; }

        /// <summary>
        /// Total payout if bet wins.
        /// </summary>
        public decimal Payout { get; private set; }

        public Bet(int odds)
        {
            // American odds cannot be -99 - 99
            this.Odds = odds; 
            this.Wager = 10.00M;
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

        public void ChangeWager(decimal wager)
        {
            // wager must be greater that 0
            this.Wager = wager;
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

    }
}
