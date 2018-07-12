using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using WebAppAirlineDispatcher.Modules;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class StewardessesController : Controller
    {
        IStewardessService stewardessService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StewardessItem, StewardessDTO>()).CreateMapper();


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
        public IActionResult Post([FromBody]StewardessItem stewardessItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stewardessDTO = mapper.Map<StewardessDTO>(stewardessItem);

            try
            {
                stewardessService.CreateStewardess(stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetStewardess", new { id = stewardessItem.Id }, stewardessItem);
        }

        // PUT api/stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StewardessItem stewardessItem)
        {
            var stewardessDTO = mapper.Map<StewardessDTO>(stewardessItem);
            stewardessDTO.Id = id;

            try
            {
                stewardessService.UpdateStewardess(stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(stewardessItem);
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