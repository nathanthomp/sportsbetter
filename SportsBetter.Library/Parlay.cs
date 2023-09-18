using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SportsBetter.Library
{
    public class Parlay
    {
        /// <summary>
        /// Calculates the parlay's return. This is calculated by first converting each American odds
        /// to decimal odds. If american odds > 0, decimal odds = (odds/100) + 1, else decimal odds
        /// = (100 / AbsoluteValue of american odds) + 1 Multiplying all the decimal odds together. 
        /// Then multiply the result by the wager.
        /// </summary>
        /// <param name="bets">Each bet in this parlay.</param>
        /// <param name="wager">The wager amount.</param>
        /// <returns>The return of this parlay.</returns>
        private static decimal CaculateReturn(List<Bet> bets, decimal wager)
        {
            Debug.Assert(bets.Count > 0);
            Debug.Assert(wager != 0.00M);

            decimal odds, oddsIndex = 1;
            foreach (Bet bet in bets)
            {
                odds = bet.Odds > 0
                    ? Math.Round(((decimal)bet.Odds / 100) + 1, 2)
                    : Math.Round((100 / (decimal)Math.Abs(bet.Odds)) + 1, 2);

                oddsIndex *= odds;
            }
            // ********************************************************
            // oddsIndex is the number that we are looking for the most.
            // *********************************************************

            return Math.Round((oddsIndex * wager), 2);
        }

        /// <summary>
        /// Calculates the parlay's odds. This is calculated by dividing the profit by the wager. 
        /// Then converting the decimal odds back to american odds. If decimal odds >= 2, american 
        /// odds = (decimal odds - 1) * 100, else american odds = -100 / (decimal odds -1).
        /// </summary>
        /// <param name="profit">Profit of this parlay.</param>
        /// <param name="wager">The parlay's wager.</param>
        /// <returns>The parlay's odds.</returns>
        private static int CalculateOdds(decimal profit, decimal wager)
        {
            Debug.Assert(profit > 0.00M);
            Debug.Assert(wager > 0.00M);

            decimal oddsToOne = Math.Round(profit / wager, 2);
            return oddsToOne >= 2 ? (int)((oddsToOne - 1) * 100) : (int)(-100 / (oddsToOne - 1));
        }

        private static int CalculateOdds(List<Bet> bets, decimal wager)
        {
            decimal odds, oddsIndex = 1;
            foreach (Bet bet in bets)
            {
                odds = bet.Odds > 0
                    ? Math.Round(((decimal)bet.Odds / 100) + 1, 2)
                    : Math.Round((100 / (decimal)Math.Abs(bet.Odds)) + 1, 2);

                oddsIndex *= odds;
            }

            var payout = Math.Round((oddsIndex * wager), 2);
            var profit = payout - wager;
            var oddsPerDollar = Math.Round(profit / wager, 2);
            var americanOdds = oddsPerDollar >= 2 ? (int)((oddsPerDollar - 1) * 100) : (int)(-100 / (oddsPerDollar - 1));
            return americanOdds;
        }

        /// <summary>
        /// Calculates the probability of this parlay winning. Calculated by (100 / american odds 
        /// + 100) * 100.
        /// </summary>
        /// <param name="odds">The odds of this parlay.</param>
        /// <returns>The probability of this parlay winning</returns>
        private static double CalculateProbability(int odds)
        {
            Debug.Assert(odds > 0);
            return (double)Math.Round((100 / (decimal)(odds + 100)) * 100, 2);
        }

        /// <summary>
        /// The bets included in this parlay.
        /// </summary>
        private List<Bet> Bets { get; }

        /// <summary>
        /// The dollar amount wager.
        /// </summary>
        public decimal Wager
        {
            get
            {
                return this.Wager;
            }
            set
            {
                Debug.Assert(value > 0);
                this.Wager = value;
            }
        }

        /// <summary>
        /// The american odds.
        /// </summary>
        public int Odds
        {
            get
            {
                return this.Bets.Count == 1 
                    ? this.Bets[0].Odds
                    : CalculateOdds(this.Bets, this.Wager);
            }
        }

        /// <summary>
        /// The dollar amount returned if won.
        /// </summary>
        //public decimal Payout
        //{ 
        //    get 
        //    {
        //        return CaculateReturn(this.Bets, this.Wager); 
        //    } 
        //}

        /// <summary>
        /// The dollar amount profit made if won. This is calculated by the dollar amount of return
        /// subtracted by the initial wager.
        /// </summary>
        //public decimal Profit 
        //{ 
        //    get 
        //    {
        //        return this.Payout - this.Wager; 
        //    } 
        //}

        /// <summary>
        /// The probability that this parlay will win.
        /// </summary>
        //public double Probability 
        //{ 
        //    get 
        //    {
        //        return CalculateProbability(this.Odds); 
        //    } 
        //}

        /// <summary>
        /// Parlay constructor. Ensures that this.Bets is not null and the initial wager is $10.00.
        /// </summary>
        public Parlay()
        {
            this.Bets = new List<Bet>();
            this.Wager = 10.00M;
        }

        /// <summary>
        /// Adds a bet to this parlay. Ensures that this bet is unique in the list of bets.
        /// </summary>
        /// <param name="bet">The bet to add to the parlay.</param>
        public void AddBet(Bet bet)
        {
            Debug.Assert(bet != null);
            Debug.Assert(this.Bets.Contains(bet) == false);

            // Need a custom comparator here

            this.Bets.Add(bet);
            // fire BetAddedEvent
        }
    }
}
