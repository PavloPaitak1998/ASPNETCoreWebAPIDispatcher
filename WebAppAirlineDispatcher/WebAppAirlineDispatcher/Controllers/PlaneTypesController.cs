using AutoMapper;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using WebAppAirlineDispatcher.Modules;
using Shared.Exceptions;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlaneTypesController : Controller
    {
        IPlaneTypeService planeTypeService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneTypeItem, PlaneTypeDTO>()).CreateMapper();

        public PlaneTypesController(IPlaneTypeService serv)
        {
            planeTypeService = serv;
        }


        // GET: api/planetypes
        public IActionResult Get()
        {
            return Ok(planeTypeService.GetPlaneTypes());
        }

        // GET api/planetypes/5
        [HttpGet("{id}", Name = "GetPlaneType")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = planeTypeService.GetPlaneType(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planetypes
        [HttpPost]
        public IActionResult Post([FromBody]PlaneTypeItem planeTypeItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var planeTypeDTO = mapper.Map<PlaneTypeDTO>(planeTypeItem);

            try
            {
                planeTypeService.CreatePlaneType(planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetPlaneType", new { id = planeTypeItem.Id }, planeTypeItem);
        }

        // PUT api/planetypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PlaneTypeItem planeTypeItem)
        {
            var planeTypeDTO = mapper.Map<PlaneTypeDTO>(planeTypeItem);
            planeTypeDTO.Id = id;

            try
            {
                planeTypeService.UpdatePlaneType(planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeTypeItem);
        }

        // DELETE api/planetypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                planeTypeService.DeletePlaneType(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planetypes
        [HttpDelete]
        public IActionResult Delete()
        {
            planeTypeService.DeleteAllPlaneTypes();
            return NoContent();
        }
    }
}