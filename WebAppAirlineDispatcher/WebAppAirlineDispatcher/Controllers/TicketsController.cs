using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        ITicketService ticketService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketItem, TicketDTO>()).CreateMapper();


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
        public IActionResult Post([FromBody]TicketItem ticketItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticketDTO = mapper.Map<TicketDTO>(ticketItem);

            try
            {
                ticketService.CreateTicket(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetTicket", new { id = ticketItem.Id }, ticketItem);
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketItem ticketItem)
        {
            var ticketDTO = mapper.Map<TicketDTO>(ticketItem);
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