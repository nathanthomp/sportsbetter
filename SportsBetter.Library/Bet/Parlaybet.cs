using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SportsBetter.Library.Bet
{
    // public void AddBet(StraightBet bet)
    // private static int CalculateOdds(List<StraightBet> bets, decimal wager)
    public class Parlaybet : IBet
    {

        //private static decimal CaculateReturn(List<Bet> bets, decimal wager)
        //{
        //    Debug.Assert(bets.Count > 0);
        //    Debug.Assert(wager != 0.00M);

        //    decimal odds, oddsIndex = 1;
        //    foreach (Bet bet in bets)
        //    {
        //        odds = bet.Odds > 0
        //            ? Math.Round(((decimal)bet.Odds / 100) + 1, 2)
        //            : Math.Round((100 / (decimal)Math.Abs(bet.Odds)) + 1, 2);

        //        oddsIndex *= odds;
        //    }
        //    // ********************************************************
        //    // oddsIndex is the number that we are looking for the most.
        //    // *********************************************************

        //    return Math.Round((oddsIndex * wager), 2);
        //}

        /// <summary>
        /// Calculates the parlay's odds. This is calculated by dividing the profit by the wager. 
        /// Then converting the decimal odds back to american odds. If decimal odds >= 2, american 
        /// odds = (decimal odds - 1) * 100, else american odds = -100 / (decimal odds -1).
        /// </summary>
        /// <param name="profit">Profit of this parlay.</param>
        /// <param name="wager">The parlay's wager.</param>
        /// <returns>The parlay's odds.</returns>
        //private static int CalculateOdds(decimal profit, decimal wager)
        //{
        //    Debug.Assert(profit > 0.00M);
        //    Debug.Assert(wager > 0.00M);

        //    decimal oddsToOne = Math.Round(profit / wager, 2);
        //    return oddsToOne >= 2 ? (int)((oddsToOne - 1) * 100) : (int)(-100 / (oddsToOne - 1));
        //}

        /// <summary>
        /// Calculates the parlay odds. This is calculated by first converting each american odds
        /// to decimal odds. If american odds > 0, decimal odds = (odds/100) + 1, else decimal odds
        /// = (100 / absolute value of american odds) + 1. Multiply all the decimal odds together.
        /// Multiply the result by the wager. Subtract the wager. Divide by the wager. Then convert
        /// back to american odds. If the decimal odds is greater than or equal to 2, american odds
        /// = (decimal odds - 1) * 100. Else, american odds = -100 / (decimal odds - 1).
        /// </summary>
        /// <param name="bets">Each bet in this parlay.</param>
        /// <param name="wager">The wager amount.</param>
        /// <returns>The odds of the parlay</returns>
        private static int CalculateOdds(List<StraightBet> bets, decimal wager)
        {
            if (bets.Count == 1)
            {
                return bets[0].Odds;
            }

            decimal odds, oddsIndex = 1;
            foreach (StraightBet bet in bets)
            {
                odds = bet.Odds > 0
                    ? ((decimal)bet.Odds / 100) + 1
                    : (100 / (decimal)Math.Abs(bet.Odds)) + 1;

                oddsIndex *= odds;
            }

            return oddsIndex < 2 
                ? (int)Math.Round(-100 / (oddsIndex - 1))
                : (int)Math.Round((oddsIndex - 1) * 100);
            //var payout = Math.Round((oddsIndex * wager), 2);
            //var profit = payout - wager;
        }

        /// <summary>
        /// The probability that this parlay wins. If the american odds are greater than 0,
        /// probability = 100 / (american odds + 100). Else, probability = absolute value of 
        /// american odds / (absolute value of american odds + 100).
        /// </summary>
        /// <param name="odds">The american odds of this parlay.</param>
        /// <returns>The probability of this parlay.</returns>
        private static double CalculateProbability(int odds)
        {
            //return odds > 0
            //    ? Math.Round((double)100 / (double)(odds + 100), 2)
            //    : Math.Round((double)Math.Abs(odds) / (double)(Math.Abs(odds) + 100), 2);

            return odds > 0
                ? (double)100 / (double)(odds + 100)
                : (double)Math.Abs(odds) / (double)(Math.Abs(odds) + 100);
        }

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
        /// The bets included in this parlay.
        /// </summary>
        private List<StraightBet> Bets { get; }



        /// <summary>
        /// Parlay constructor. Ensures that bets is not null, has a size of 1, and the initial 
        /// wager is $10.00. Initializes the odds, probability, profit, and payout of the parlay.
        /// </summary>
        /// <param name="bet">The intial bet in this parlay</param>
        public Parlaybet(StraightBet bet)
        {
            this.Bets = new List<StraightBet>
            {
                bet
            };
            this.Wager = 10.00M;
            this.Odds = CalculateOdds(this.Bets, this.Wager);
            this.Probability = CalculateProbability(this.Odds);
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

        /// <summary>
        /// Adds a bet to this parlay. Ensures that this bet is unique in the list of bets.
        /// </summary>
        /// <param name="bet">The bet to add to this parlay.</param>
        public void AddBet(StraightBet bet)
        {
            Debug.Assert(bet != null);
            Debug.Assert(this.Bets.Contains(bet) == false);

            // Need a custom comparator here to check if this bet has already been added to the parlay

            this.Bets.Add(bet);
            this.Odds = CalculateOdds(this.Bets, this.Wager);
            this.Probability = CalculateProbability(this.Odds);
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }

        // public void RemoveBet(Bet bet)

        public void ChangeWager(decimal wager)
        {
            this.Wager = wager;
            this.Profit = CalculateProfit(this.Odds, this.Wager);
            this.Payout = this.Profit + this.Wager;
        }
    }
}
