using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class StewardessService : IStewardessService
    {
        IUnitOfWork unitOfWork;

        public StewardessService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public StewardessDTO GetStewardess(int id)
        {
            var stewardess = unitOfWork.Stewardesses.Get(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            return new StewardessDTO
            {
                Id = stewardess.Id,
                FirstName = stewardess.FirstName,
                LastName = stewardess.LastName,
                BirthDate = stewardess.BirthDate
            };
        }

        public IEnumerable<StewardessDTO> GetStewardesses()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Stewardess, StewardessDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Stewardess>, List<StewardessDTO>>(unitOfWork.Stewardesses.GetAll());
        }

        public void CreateStewardess(StewardessDTO stewardessDTO)
        {

            if (unitOfWork.Stewardesses.Get(stewardessDTO.Id) != null)
            {
                throw new ValidationException($"Stewardess with this id {stewardessDTO.Id} already exist");
            }

            Stewardess stewardess = new Stewardess
            {
                Id= stewardessDTO.Id,
                FirstName= stewardessDTO.FirstName,
                LastName= stewardessDTO.LastName,
                BirthDate= stewardessDTO.BirthDate
            };

            unitOfWork.Stewardesses.Create(stewardess);
        }

        public void UpdateStewardess(StewardessDTO stewardessDTO)
        {
            var stewardess = unitOfWork.Stewardesses.Get(stewardessDTO.Id);

            if (stewardess == null)
                throw new ValidationException($"Flight with this number {stewardessDTO.Id} not found");

            unitOfWork.Stewardesses.Update(new Stewardess
            {
                Id = stewardessDTO.Id,
                FirstName = stewardessDTO.FirstName,
                LastName = stewardessDTO.LastName,
                BirthDate = stewardessDTO.BirthDate
            });
        }

        public void DeleteAllStewardesses()
        {
            unitOfWork.Stewardesses.DeleteAll();

            foreach (var crew in unitOfWork.Crew.GetAll())
            {
                crew.StewardessesId=new List<int>();
            }

        }

        public void DeleteStewardess(int id)
        {
            var stewardess = unitOfWork.Stewardesses.Get(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            unitOfWork.Stewardesses.Delete(id);

            foreach (var crew in unitOfWork.Crew.Find(c => c.StewardessesId.Exists(s => s == id)))
            {
                crew.StewardessesId.Remove(id);
            }
        }
    }
}
