using SportsBetter.Library.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetter.Library.Game
{
    public class NFLGame : IGame
    {
        NFLTeam HomeTeam { get; set; }
        NFLTeam AwayTeam { get; set; }


    }
}
