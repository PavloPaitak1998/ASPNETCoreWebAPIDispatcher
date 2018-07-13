using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class StewardessesController : Controller
    {
        IStewardessService stewardessService;

        public StewardessesController(IStewardessService serv)
        {
            stewardessService = serv;
        }


        // GET: api/stewardesses
        public IActionResult Get()
        {
            return Ok(stewardessService.GetStewardesses());
        }

        // GET api/stewardesses/5
        [HttpGet("{id}", Name = "GetStewardess")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = stewardessService.GetStewardess(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/stewardesses
        [HttpPost]
        public IActionResult Post([FromBody]StewardessDTO stewardessDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                stewardessService.CreateStewardess(stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetStewardess", new { id = stewardessDTO.Id }, stewardessDTO);
        }

        // PUT api/stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StewardessDTO stewardessDTO)
        {
            stewardessDTO.Id = id;

            try
            {
                stewardessService.UpdateStewardess(stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(stewardessService.GetStewardess(id));
        }

        // DELETE api/stewardesses/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                stewardessService.DeleteStewardess(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/stewardesses
        [HttpDelete]
        public IActionResult Delete()
        {
            stewardessService.DeleteAllStewardesses();
            return NoContent();
        }
    }
}