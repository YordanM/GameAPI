using GameAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    public class Globals
    {
        public static List<Game> _gameManager = new List<Game>();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost]
        public Game AddGame([FromBody] Game game)
        {
            if (Globals._gameManager.Any(x => x.Id == game.Id))
            {
                throw new Exception("There is already an id like this!");
            }
            Globals._gameManager.Add(game);
            return game;
        }

        [HttpGet("{id}")]
        public Game GetGameById([FromRoute] string id)
        {
            var game = Globals._gameManager.FirstOrDefault(x => x.Id == id);

            if (game == null)
            {
                throw new Exception("No such game with the specific id");
            }
            return game;
        }

        [HttpPost("price")]
        public Game ChangePrice([FromQuery] string id, [FromQuery] decimal price)
        {
            var game = GetGameById(id);
            if (game == null)
            {
                throw new Exception("No such game with the specific id");
            }
            game.Price = price;

            return game;
        }

        [HttpPost("region")]
        public Game ChangeRegion([FromQuery] string id, [FromQuery] string region)
        {
            var game = GetGameById(id);
            if (game == null)
            {
                throw new Exception("No such game with the specific id");
            }
            game.Region = region;

            return game;
        }

    }
}
