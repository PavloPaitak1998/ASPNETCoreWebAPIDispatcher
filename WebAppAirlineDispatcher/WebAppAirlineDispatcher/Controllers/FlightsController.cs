using AutoMapper;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        IFlightService flightService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<FlightItem, FlightDTO>()).CreateMapper();


        public FlightsController(IFlightService serv)
        {
            flightService = serv;
        }


        // GET: api/flights
        public IActionResult Get()
        {
            return Ok(flightService.GetFlights());
        }

        // GET api/flights/5
        [HttpGet("{id}", Name = "GetFlight")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = flightService.GetFlight(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }        
        }

        // POST api/flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightItem flightItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flightDTO = mapper.Map<FlightItem, FlightDTO>(flightItem);

            try
            {
                flightService.CreateFlight(flightDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetFlight", new { id = flightItem.Number }, flightItem);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FlightItem flightItem)
        {
            var flightDTO = mapper.Map<FlightDTO>(flightItem);

            try
            {
                flightService.UpdateFlight(id, flightDTO);            
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            flightItem.Number = id;
            return Ok(flightItem);
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
                return BadRequest(new { Exception = e.Message });
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