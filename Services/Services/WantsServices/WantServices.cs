using AutoMapper;
using Entities.DTO.StudentDto;
using Entities.DTO.WantsDto;
using Entities.ErrorModels;
using Entities.Models;
using Repositories.Repositories.Repositories.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.WantsServices
{
    public class WantServices : IWantServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WantServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Wants CreateOneWants(WantsCreateDto wantsCreateDto)
        {
            if (wantsCreateDto == null)
                throw new ExceptionN("Lütfen bütün verileri doldurunuz");
            var wants = _mapper.Map<Wants>(wantsCreateDto);
            _repositoryManager.WantRepositories.CreateOneWants(wants);
            _repositoryManager.SaveChanges();
            return wants;
        }

        public void DeleteOneWants(int id, bool trackChanges)
        {
            var wants = _repositoryManager.WantRepositories.GetOneWants(id, trackChanges);
            if (wants is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            _repositoryManager.WantRepositories.DeleteOneWants(wants);
            _repositoryManager.SaveChanges();
        }

        public IEnumerable<Wants> GetAllWants(bool trackChanges)=>_repositoryManager.WantRepositories.GetAllWants(trackChanges);

        public Wants GetOneWants(int id, bool trackChanges)
        {
            var wants = _repositoryManager.WantRepositories.GetOneWants(id, trackChanges);
            if (wants is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            return wants;
        }

        public void UpdateOneWants(WantsUpdateDto wantsUpdateDto, int id, bool trackChanges)
        {
            var wants = _repositoryManager.WantRepositories.GetOneWants(id, trackChanges);
            if (wants is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            var empMapper = _mapper.Map<Wants>(wantsUpdateDto);
            _repositoryManager.WantRepositories.UpdateOneWants(empMapper);
            _repositoryManager.SaveChanges();
        }
    }
}
