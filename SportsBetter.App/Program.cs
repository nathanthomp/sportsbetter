using SportsBetter.Library;
using System;
using System.Collections.Generic;

namespace SportsBetter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal totalWager = 100.00M;
            const int numberOfGames = 2; // Move to global scope
            int numberOfParlays = NumberOfParlays(numberOfGames); // Move to global scope
            decimal parlayWagerAmount = totalWager / numberOfParlays;

            // Get data for each Game, make a tree of games

            Bet PHIMoneyLine = new Bet(-230);
            Bet TBMoneyLine = new Bet(190);
            Bet LARMoneyLine = new Bet(130);
            Bet CINMoneyLine = new Bet(-155);

            Dictionary<string, Parlay> parlays = new Dictionary<string, Parlay>();

            // PHI LAR
            Parlay parlay1 = new Parlay(PHIMoneyLine); // .3
            parlay1.AddBet(LARMoneyLine);
            parlays.Add("PHI-LAR", parlay1);
            parlay1.ChangeWager(totalWager * (decimal)parlay1.Probability);
            //parlay1.ChangeWager(parlayWagerAmount);

            // PHI CIN
            Parlay parlay2 = new Parlay(PHIMoneyLine); // .42
            parlay2.AddBet(CINMoneyLine);
            parlays.Add("PHI-CIN", parlay2);
            parlay2.ChangeWager(totalWager * (decimal)parlay2.Probability);
            //parlay2.ChangeWager(parlayWagerAmount);

            // TB LAR
            Parlay parlay3 = new Parlay(TBMoneyLine); // .15
            parlay3.AddBet(LARMoneyLine);
            parlays.Add("TB-LAR", parlay3);
            parlay3.ChangeWager(totalWager * (decimal)parlay3.Probability);
            //parlay3.ChangeWager(parlayWagerAmount);

            // TB CIN
            Parlay parlay4 = new Parlay(TBMoneyLine); // .21
            parlay4.AddBet(CINMoneyLine);
            parlays.Add("TB-CIN", parlay4);
            parlay4.ChangeWager(totalWager * (decimal)parlay4.Probability);
            //parlay4.ChangeWager(parlayWagerAmount);

            List<decimal> payouts = new List<decimal>();
            decimal minPayout = decimal.MaxValue, maxPayout = decimal.MinValue, totalWagers = 0.00M;
            foreach (KeyValuePair<string, Parlay> parlay in parlays)
            {
                payouts.Add(parlay.Value.Payout);

                if (parlay.Value.Payout > maxPayout)
                {
                    maxPayout = parlay.Value.Payout;
                }

                if (parlay.Value.Payout < minPayout)
                {
                    minPayout = parlay.Value.Payout;
                }

                totalWagers += parlay.Value.Wager;
            }
        }

        // Should be a global variable
        // n = number of games
        private static int NumberOfParlays(int numberOfGames)
        {
            return (int)Math.Pow(2, numberOfGames);
        }
    }
}