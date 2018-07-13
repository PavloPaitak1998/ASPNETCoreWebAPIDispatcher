using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class DeparturesController : Controller
    {
        IDepartureService departureService;


        public DeparturesController(IDepartureService serv)
        {
            departureService = serv;
        }

        // GET: api/departures
        public IActionResult Get()
        {
            return Ok(departureService.GetDepartures());
        }

        // GET api/departures/5
        [HttpGet("{id}", Name = "GetDeparture")]
        public IActionResult Get(int id)
        {
            try
            {
                var departure = departureService.GetDeparture(id);
                return Ok(departure);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/departures
        [HttpPost]
        public IActionResult Post([FromBody]DepartureDTO departureDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                departureService.CreateDeparture(departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetDeparture", new { id = departureDTO.Id }, departureDTO);
        }

        // PUT api/departures/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DepartureDTO departureDTO)
        {
            departureDTO.Id = id;

            try
            {
                departureService.UpdateDeparture(departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(departureService.GetDeparture(id));
        }

        // DELETE api/departures/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                departureService.DeleteDeparture(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/departures
        [HttpDelete]
        public IActionResult Delete()
        {
            departureService.DeleteAllDepartures();
            return NoContent();
        }
    }
}