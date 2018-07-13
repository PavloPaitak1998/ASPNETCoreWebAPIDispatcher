using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        ITicketService ticketService;

        public TicketsController(ITicketService serv)
        {
            ticketService = serv;
        }

        // GET: api/tickets
        public IActionResult Get()
        {
            return Ok(ticketService.GetTickets());
        }

        // GET api/tickets/5
        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = ticketService.GetTicket(id);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ticketService.CreateTicket(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetTicket", new { id = ticketDTO.Id }, ticketDTO);
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketDTO ticketDTO)
        {
            ticketDTO.Id = id;

            try
            {
                ticketService.UpdateTicket(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(ticketService.GetTicket(id));
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ticketService.DeleteTicket(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/tickets
        [HttpDelete]
        public IActionResult Delete()
        {
            ticketService.DeleteAllTickets();
            return NoContent();
        }
    }
}