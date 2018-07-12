using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Exceptions;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using WebAppAirlineDispatcher.Modules;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PilotsController : Controller
    {
        IPilotService pilotService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PilotItem, PilotDTO>()).CreateMapper();


        public PilotsController(IPilotService serv)
        {
            pilotService = serv;
        }

        // GET: api/pilots
        public IActionResult Get()
        {
            return Ok(pilotService.GetPilots());
        }

        // GET api/pilots/5
        [HttpGet("{id}", Name = "GetPilot")]
        public IActionResult Get(int id)
        {
            try
            {
                var pilot = pilotService.GetPilot(id);
                return Ok(pilot);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/pilots
        [HttpPost]
        public IActionResult Post([FromBody]PilotItem pilotItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pilotDTO = mapper.Map<PilotDTO>(pilotItem);

            try
            {
                pilotService.CreatePilot(pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetFlight", new { id = pilotItem.Id }, pilotItem);
        }

        // PUT api/pilots/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PilotItem pilotItem)
        {
            var pilotDTO = mapper.Map<PilotDTO>(pilotItem);
            pilotDTO.Id = id;

            try
            {
                pilotService.UpdatePilot(pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(pilotService.GetPilot(id));
        }

        // DELETE api/pilots/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                pilotService.DeletePilot(id);
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
            pilotService.DeleteAllPilots();
            return NoContent();
        }

    }
}