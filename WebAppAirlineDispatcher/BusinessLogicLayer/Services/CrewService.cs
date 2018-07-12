using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class CrewService : ICrewService
    {
        IUnitOfWork unitOfWork;
        private object flightDTO;

        public CrewService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public CrewDTO GetCrew(int id)
        {
            var crew = unitOfWork.Crew.Get(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            return new CrewDTO
            {
                Id = crew.Id,
                PilotId = crew.PilotId,
                StewardessesId = crew.StewardessesId
            };
        }

        public IEnumerable<CrewDTO> GetCrew()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Crew, CrewDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Crew>, List<CrewDTO>>(unitOfWork.Crew.GetAll());
        }

        public void CreateCrew(CrewDTO crewDTO)
        {
            if (unitOfWork.Crew.Get(crewDTO.Id) != null)
                throw new ValidationException($"Crew with this id {crewDTO.Id} already exist");

            List<Stewardess> stewardesses = new List<Stewardess>();

            int count = 0;
            foreach (var sid in crewDTO.StewardessesId)
            {
                stewardesses.Add(unitOfWork.Stewardesses.Get(sid));
                if (stewardesses[count] == null)
                    throw new ValidationException($"Stewardesses with this id {sid} not found");
                count++;
            }

            var pilot = unitOfWork.Pilots.Get(crewDTO.PilotId);
            if (pilot == null)
                throw new ValidationException($"Pilot with this id {crewDTO.PilotId} not found");

            Crew crew = new Crew
            {
                Id=crewDTO.Id,
                PilotId= crewDTO.PilotId,
                StewardessesId= crewDTO.StewardessesId
            };

            unitOfWork.Crew.Create(crew);
        }

        public void UpdateCrew(CrewDTO crewDTO)
        {
            var crew = unitOfWork.Crew.Get(crewDTO.Id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {crewDTO.Id} not found");

            if(crewDTO.StewardessesId.Length>0)
            {
                List<Stewardess> stewardesses = new List<Stewardess>();

                int count = 0;
                foreach (var sid in crewDTO.StewardessesId)
                {
                    stewardesses.Add(unitOfWork.Stewardesses.Get(sid));
                    if (stewardesses[count] == null)
                        throw new ValidationException($"Stewardesses with this id {sid} not found");
                    count++;
                }
            }

            if (crewDTO.PilotId!=0)
            {
                var pilot = unitOfWork.Pilots.Get(crewDTO.PilotId);
                if (pilot == null)
                    throw new ValidationException($"Pilot with this id {crewDTO.PilotId} not found");
            }

            unitOfWork.Crew.Update(new Crew
            {
                Id = crewDTO.Id,
                PilotId = crewDTO.PilotId,
                StewardessesId = crewDTO.StewardessesId
            });
        }

        public void DeleteAllCrew()
        {
            unitOfWork.Crew.DeleteAll();
        }

        public void DeleteCrew(int id)
        {
            var crew = unitOfWork.Crew.Get(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            unitOfWork.Crew.Delete(id);
        }
    }
}
