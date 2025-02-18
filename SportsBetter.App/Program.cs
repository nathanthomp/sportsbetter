using SportsBetter.Library.Bet;
using SportsBetter.Data;
using System;
using System.Collections.Generic;
using SportsBetter.Library.Game;

namespace SportsBetter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Load data from a data source
             */
            int currentNFLWeek = 10;
            List<NFLGame> games = OddsAPI.GetNFLGames(currentNFLWeek);

            /*
             * Create a binary tree of bets
             */
            // Take one game take one of the odds
            // Take the next game and 

            /*
             * Create all the parlays using depth first search.
             */
            List<Parlaybet> parlays = new List<Parlaybet>();

            /*
             * Debugging
             */
            foreach (NFLGame game in games)
            {
                Console.WriteLine(game);
            }




        //    const decimal totalWager = 100.00M;
        //    const int numberOfGames = 2; // Move to global scope
        //    int numberOfParlays = NumberOfParlays(numberOfGames); // Move to global scope
        //    decimal parlayWagerAmount = totalWager / numberOfParlays;

        //    // Get data for each Game, make a tree of games

        //    StraightBet PHIMoneyLine = new StraightBet(-230);
        //    StraightBet TBMoneyLine = new StraightBet(190);
        //    StraightBet LARMoneyLine = new StraightBet(130);
        //    StraightBet CINMoneyLine = new StraightBet(-155);

        //    Dictionary<string, Parlaybet> parlays = new Dictionary<string, Parlaybet>();

        //    // PHI LAR
        //    Parlaybet parlay1 = new Parlaybet(PHIMoneyLine); // .3
        //    parlay1.AddBet(LARMoneyLine);
        //    parlays.Add("PHI-LAR", parlay1);
        //    parlay1.ChangeWager(totalWager * (decimal)parlay1.Probability);
        //    //parlay1.ChangeWager(parlayWagerAmount);

        //    // PHI CIN
        //    Parlaybet parlay2 = new Parlaybet(PHIMoneyLine); // .42
        //    parlay2.AddBet(CINMoneyLine);
        //    parlays.Add("PHI-CIN", parlay2);
        //    parlay2.ChangeWager(totalWager * (decimal)parlay2.Probability);
        //    //parlay2.ChangeWager(parlayWagerAmount);

        //    // TB LAR
        //    Parlaybet parlay3 = new Parlaybet(TBMoneyLine); // .15
        //    parlay3.AddBet(LARMoneyLine);
        //    parlays.Add("TB-LAR", parlay3);
        //    parlay3.ChangeWager(totalWager * (decimal)parlay3.Probability);
        //    //parlay3.ChangeWager(parlayWagerAmount);

        //    // TB CIN
        //    Parlaybet parlay4 = new Parlaybet(TBMoneyLine); // .21
        //    parlay4.AddBet(CINMoneyLine);
        //    parlays.Add("TB-CIN", parlay4);
        //    parlay4.ChangeWager(totalWager * (decimal)parlay4.Probability);
        //    //parlay4.ChangeWager(parlayWagerAmount);

        //    List<decimal> payouts = new List<decimal>();
        //    decimal minPayout = decimal.MaxValue, maxPayout = decimal.MinValue, totalWagers = 0.00M;
        //    foreach (KeyValuePair<string, Parlaybet> parlay in parlays)
        //    {
        //        payouts.Add(parlay.Value.Payout);

        //        if (parlay.Value.Payout > maxPayout)
        //        {
        //            maxPayout = parlay.Value.Payout;
        //        }

        //        if (parlay.Value.Payout < minPayout)
        //        {
        //            minPayout = parlay.Value.Payout;
        //        }

        //        totalWagers += parlay.Value.Wager;
        //    }
        }

        //// Should be a global variable
        //// n = number of games
        //private static int NumberOfParlays(int numberOfGames)
        //{
        //    return (int)Math.Pow(2, numberOfGames);
        //}
    }
}