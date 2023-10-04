using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetter.Library.Bet
{
    public class IBet
    {
        /// <summary>
        /// The dollar amount wager.
        /// </summary>
        public decimal Wager { get; private set; }

        /// <summary>
        /// The american odds.
        /// </summary>
        public int Odds { get; private set; }

        /// <summary>
        /// The probability that this parlay will win.
        /// </summary>
        public double Probability { get; private set; }

        /// <summary>
        /// The dollar amount profit made if the parlay wins.
        /// </summary>
        public decimal Profit { get; private set; }

        /// <summary>
        /// The dollar amount returned if won.
        /// </summary>
        public decimal Payout { get; private set; }

        public void ChangeWager(decimal wager);
        private static double CalculateProbability(int odds);
        private static decimal CalculateProfit(int odds, decimal wager);
        public void Place();
    }
}
