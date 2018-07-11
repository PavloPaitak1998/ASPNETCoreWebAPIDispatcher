using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

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
        public FlightDTO Details(int id)
        {
            return flightService.GetFlight(id);
        }

        // POST api/flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDTO flight)
        {
            if (flight == null)
            {
                return BadRequest();
            }

            flightService.CreateFlight(flight);

            return Ok(flight);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FlightDTO flight)
        {
            if (flight == null)
            {
                return BadRequest();
            }

            var flightEntity = flightService.GetFlight(id);

            flightEntity = flight;

            return Ok(flight);

        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            flightService.DeleteFlight(id);

            return Ok(new {Id=id,Deleted=true });
        }

        // DELETE api/flights
        [HttpDelete]
        public IActionResult Delete()
        {
            flightService.DeleteAllFlights();

            return Ok();
        }

    }
}