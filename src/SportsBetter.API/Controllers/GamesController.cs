using Microsoft.AspNetCore.Mvc;

namespace SportsBetter.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public List<int> GetGames()
        {
            return new List<int> { 1, 2, 3, 4 };
        }
    }
}
