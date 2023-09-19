using SportsBetter.Library;

namespace SportsBetter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bet bet = new Bet(-150);

            var wager = bet.Wager;
            var payout = bet.Payout;

            bet.ChangeWager(15.00M);
        }
    }
}