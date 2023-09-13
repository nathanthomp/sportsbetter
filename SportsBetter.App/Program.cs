using SportsBetter.Library;

namespace SportsBetter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bet bet1 = new Bet
            {
                Wager = 1.00,
                Odds = -150
            };
            Bet bet2 = new Bet
            {
                Wager = 1.00,
                Odds = 140
            };
            Bet bet3 = new Bet
            {
                Wager = 1.00,
                Odds = -170
            };
            Bet bet4 = new Bet
            {
                Wager = 1.00,
                Odds = -105
            };

            Parlay parlay = new Parlay();
            parlay.Wager = 10.00M;

            parlay.AddBet(bet1);
            var v = parlay.Odds;
            parlay.AddBet(bet2);
            v = parlay.Odds;
            parlay.AddBet(bet3);
            v = parlay.Odds;
            parlay.AddBet(bet4);
            v = parlay.Odds;


        }
    }
}