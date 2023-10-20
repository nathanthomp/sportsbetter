using SportsBetter.Library.Bet;

namespace SportsBetter.Library.Game
{
    public class NFLGame
    {
        string HomeTeam { get; set; }
        string AwayTeam { get; set; }
        StraightBet HomeTeamMoneyLineBet { get; set; }
        StraightBet AwayTeamMoneyLineBet { get; set; }


        public NFLGame(string homeTeam, int homeTeamMoneyLineOdds, string awayTeam, int awayTeamMoneyLineOdds)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeTeamMoneyLineBet = new StraightBet(homeTeamMoneyLineOdds);
            this.AwayTeamMoneyLineBet = new StraightBet(awayTeamMoneyLineOdds);
        }

        public override string ToString()
        {
            return $"{this.HomeTeam} ({this.HomeTeamMoneyLineBet.Odds}) vs {this.AwayTeam} ({this.AwayTeamMoneyLineBet.Odds})";
        }
    }
}
