using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskBackend.Models;

namespace HelpDeskBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        HelpdeskDbContext DbContext = new HelpdeskDbContext();

        [HttpGet]
        public IActionResult GetAllTickets()
        {
            List<Ticket> result = DbContext.Tickets.ToList();
            return Ok(result);

        }

        
    }
}
