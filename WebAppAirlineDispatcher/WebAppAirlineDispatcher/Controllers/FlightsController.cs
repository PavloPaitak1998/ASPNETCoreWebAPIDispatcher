using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        IFlightService flightService;

        public FlightsController(IFlightService serv)
        {
            flightService = serv;
        }


        // GET: api/flights
        public IEnumerable<FlightDTO> Get()
        {
            return flightService.GetFlights();
        }

        // GET api/flights/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = flightService.GetFlight(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }        
        }

        // POST api/flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDTO flight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                flightService.CreateFlight(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(flight);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FlightDTO flight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                flightService.UpdateFlight(id,flight);            
            }
            catch (ValidationException e)
            {
                return BadRequest(new { ValidationException = e.Message });
            }

            flight.Number = id;
            return Ok(flight);
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                flightService.DeleteFlight(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { ValidationException = e.Message });
            }
            return NoContent();
        }

        // DELETE api/flights
        [HttpDelete]
        public IActionResult Delete()
        {
            flightService.DeleteAllFlights();
            return NoContent();
        }

    }
}