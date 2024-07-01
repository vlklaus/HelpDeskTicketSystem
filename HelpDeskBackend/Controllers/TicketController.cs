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
        // api/Ticket
        public IActionResult GetAllTickets()
        {
            List<Ticket> result = DbContext.Tickets.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
            Ticket result = DbContext.Tickets.Find(id);
            return Ok(result);
        }

        [HttpPost] //For adding
        // api/Ticket
        public IActionResult AddTicket([FromBody] Ticket newTicket)
        {
            DbContext.Tickets.Add(newTicket);
            DbContext.SaveChanges();
            return Created($"/Tickets/Api{newTicket.Id}", newTicket);
        }
        [HttpPut("{id}")]
        // api/Ticket/{id}
        public IActionResult UpdateTicket(int id, [FromBody] Ticket targetTicket)
        {
            if (id != targetTicket.Id) { return BadRequest(); }
            if (!DbContext.Tickets.Any(b => b.Id == id)) { return NotFound(); }

            DbContext.Tickets.Update(targetTicket);
            DbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // api/Ticket/{id}
        public IActionResult DeleteTicket(int id)
        {
            Ticket Result = DbContext.Tickets.Find(id);
            if(Result == null)
            {
                return NotFound();
            }
            DbContext.Tickets.Remove(Result);
            DbContext.SaveChanges();
            return NoContent();
        }
    }
}

