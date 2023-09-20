using SportsBetter.Library;

namespace SportsBetter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bet bet1 = new Bet(150);
            Bet bet2 = new Bet(-150);
            Bet bet3 = new Bet(200);
            
            Parlay parlay = new Parlay(bet1);
            parlay.AddBet(bet2);
            parlay.AddBet(bet3);

            parlay.ChangeWager(1.00M);
        }
    }
}