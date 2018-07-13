using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PilotsController : Controller
    {
        IEntityService<PilotDTO> pilotService;

        public PilotsController(IEntityService<PilotDTO> serv)
        {
            pilotService = serv;
        }

        // GET: api/pilots
        public IActionResult Get()
        {
            return Ok(pilotService.GetEntities());
        }

        // GET api/pilots/5
        [HttpGet("{id}", Name = "GetPilot")]
        public IActionResult Get(int id)
        {
            try
            {
                var pilot = pilotService.GetEntity(id);
                return Ok(pilot);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/pilots
        [HttpPost]
        public IActionResult Post([FromBody]PilotDTO pilotDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                pilotService.CreateEntity(pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetFlight", new { id = pilotDTO.Id }, pilotDTO);
        }

        // PUT api/pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PilotDTO pilotDTO)
        {
            pilotDTO.Id = id;

            try
            {
                pilotService.UpdateEntity(pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(pilotService.GetEntity(id));
        }

        // DELETE api/pilots/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                pilotService.DeleteEntity(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/pilots
        [HttpDelete]
        public IActionResult Delete()
        {
            pilotService.DeleteAllEntities();
            return NoContent();
        }

    }
}