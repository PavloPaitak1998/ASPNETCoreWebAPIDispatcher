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
    public class DeparturesController : Controller
    {
        IDepartureService departureService;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartureItem, DepartureDTO>()).CreateMapper();


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
        public IActionResult Post([FromBody]DepartureItem departureItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var departureDTO = mapper.Map<DepartureDTO>(departureItem);

            try
            {
                departureService.CreateDeparture(departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return CreatedAtRoute("GetDeparture", new { id = departureItem.Id }, departureItem);
        }

        // PUT api/departures/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DepartureItem departureItem)
        {
            var departureDTO = mapper.Map<DepartureDTO>(departureItem);
            departureDTO.Id = id;

            try
            {
                departureService.UpdateDeparture(departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(departureItem);
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