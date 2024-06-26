using HelpDeskBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        HelpdeskDbContext DbContext = new HelpdeskDbContext();

        [HttpGet]
        public IActionResult GetFavorites(int id)
        {
            Ticket result = DbContext.Tickets.FirstOrDefault(t => t.Id == id);  
            if(result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
