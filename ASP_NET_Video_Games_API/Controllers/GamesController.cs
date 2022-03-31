using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{   
    //api/games
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GamesController(ApplicationDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var videoGames = _context.VideoGames.Distinct();

            return Ok(videoGames);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetGamesById(int id)
        {
            int? maxYear = _context.VideoGames.Select(vg => vg.Year).Max();
            int? minYear = _context.VideoGames.Select(vg => vg.Year).Min();
            var videoGames = _context.VideoGames.Where(vg => vg.Id == id);

            return Ok(videoGames);
        }
        

    }
}
