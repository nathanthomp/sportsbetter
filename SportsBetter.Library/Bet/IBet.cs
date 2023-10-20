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
        public decimal Wager;

        /// <summary>
        /// The american odds.
        /// </summary>
        public int Odds;

        /// <summary>
        /// The probability that this parlay will win.
        /// </summary>
        public double Probability;

        /// <summary>
        /// The dollar amount profit made if the parlay wins.
        /// </summary>
        public decimal Profit;

        /// <summary>
        /// The dollar amount returned if won.
        /// </summary>
        public decimal Payout;

        //public void ChangeWager(decimal wager);
        //private static double CalculateProbability(int odds);
        //private static decimal CalculateProfit(int odds, decimal wager);
        //public void Place();
    }
}
