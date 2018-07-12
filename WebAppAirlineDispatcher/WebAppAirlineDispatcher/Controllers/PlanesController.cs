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
    public class PlanesController : Controller
    {
        IPlaneService planeService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneItem, PlaneDTO>()).CreateMapper();


        public PlanesController(IPlaneService serv)
        {
            planeService = serv;
        }


        // GET: api/planes
        public IActionResult Get()
        {
            return Ok(planeService.GetPlanes());
        }

        // GET api/planes/5
        [HttpGet("{id}", Name = "GetPlane")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = planeService.GetPlane(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneItem planeItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var planeDTO = mapper.Map<PlaneDTO>(planeItem);

            try
            {
                planeService.CreatePlane(planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetPlane", new { id = planeItem.Id }, planeItem);
        }

        // PUT api/planes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneItem planeItem)
        {
            var planeDTO = mapper.Map<PlaneDTO>(planeItem);
            planeDTO.Id = id;

            try
            {
                planeService.UpdatePlane(planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeService.GetPlane(id));
        }

        // DELETE api/planes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                planeService.DeletePlane(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planes
        [HttpDelete]
        public IActionResult Delete()
        {
            planeService.DeleteAllPlanes();
            return NoContent();
        }
    }
}
