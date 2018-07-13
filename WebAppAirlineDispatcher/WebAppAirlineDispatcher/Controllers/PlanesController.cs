using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlanesController : Controller
    {
        IPlaneService planeService;

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
        public IActionResult Post([FromBody]PlaneDTO planeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                planeService.CreatePlane(planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetPlane", new { id = planeDTO.Id }, planeDTO);
        }

        // PUT api/planes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneDTO planeDTO)
        {
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
