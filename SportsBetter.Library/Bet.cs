using System;
using System.Diagnostics;

namespace SportsBetter.Library
{
    public class Bet
    {
        /// <summary>
        /// The dollar amount profit made if the bet wins. If the american odds are greater than 0,
        /// profit = wager * (american odds / 100). Else, profit = wager / (absolute value of 
        /// american odds / 100).
        /// </summary>
        /// <param name="odds">The american odds of this bet.</param>
        /// <param name="wager">The wager amount.</param>
        /// <returns>The profit of this bet.</returns>
        private static decimal CalculateProfit(int odds, decimal wager)
        {
            return odds > 0 
                ? Math.Round((wager * odds) / 100, 2)
                : Math.Round((wager / Math.Abs(odds)) * 100, 2);
        }

        /// <summary>
        /// The probability that this bet wins. If the american odds are greater than 0, 
        /// probability = 100 / (american odds + 100). Else, probability = absolute value of 
        /// american odds / (absolute value of american odds + 100).
        /// </summary>
        /// <param name="odds">The american odds of this bet.</param>
        /// <returns>The probability of this bet.</returns>
        private static double CalculateProbability(int odds)
        {
            return odds > 0 
                ? (double)100 / (double)(odds + 100)
                : (double)Math.Abs(odds) / (double)(Math.Abs(odds) + 100);
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
        /// The probability that this parlay will win.
        /// </summary>
        public double Probability { get; private set; }

        /// <summary>
        /// The dollar amount profit made if the bet wins.
        /// </summary>
        public decimal Profit { get; private set; }

        /// <summary>
        /// Total payout if bet wins.
        /// </summary>
        public decimal Payout { get; private set; }

        /// <summary>
        /// Bet constructor. Ensures that the initial wager is $10.00. Initializes odds, 
        /// probability, profit, and payout.
        /// </summary>
        /// <param name="odds">The odds of this bet.</param>
        public Bet(int odds)
        {
            // TODO
            // American odds cannot be -99 - 99
            this.Wager = 10.00M;
            this.Odds = odds;
            this.Probability = CalculateProbability(this.Odds);
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

        /// <summary>
        /// Changes the wager of this bet. Updates profit and payout.
        /// </summary>
        /// <param name="wager">New wager of this bet.</param>
        public void ChangeWager(decimal wager)
        {
            // TODO
            // wager must be greater that 0
            this.Wager = wager;
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

    }
}
