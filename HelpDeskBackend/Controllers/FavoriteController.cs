using HelpDeskBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        HelpdeskDbContext DbContext = new HelpdeskDbContext();

        [HttpPost()]
        // api/Favorite
        public IActionResult AddFavorite([FromBody] Favorite t)
        {
            DbContext.Favorites.Add(t);
            DbContext.SaveChanges();
            return Created($"/api/Favorite/{t.Id}", t);
        }


        [HttpGet]
        // api/Favorite
        public IActionResult GetFavorites()
        {
            List<Favorite> result = DbContext.Favorites.Include(t=> t.Ticket).ToList();
            //if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        // api/Favorite/{id}
        public IActionResult DeleteFavorite(int id)
        {
            Favorite result = DbContext.Favorites.FirstOrDefault(f => f.TicketId == id);
            if (result == null) { return NotFound(); }
            DbContext.Favorites.Remove(result);
            DbContext.SaveChanges();
            return NoContent();
        }

    }
}
