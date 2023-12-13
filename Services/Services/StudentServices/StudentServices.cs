using AutoMapper;
using Entities.DTO.EmployeeDto;
using Entities.DTO.StudentDto;
using Entities.ErrorModels;
using Entities.Models;
using Repositories.Repositories.Repositories.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.StudentServices
{
    public class StudentServices : IStudentServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public StudentServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Student CreateOneStudent(StudentCreateDto2 studentCreateDto2)
        {
            if (studentCreateDto2 == null)
                throw new ExceptionN("Lütfen bütün verileri doldurunuz");
            var student = _mapper.Map<Student>(studentCreateDto2);
            _repositoryManager.StudentRepositories.CreateOneStudent(student);
            _repositoryManager.SaveChanges();
            return student;
        }

        public void DeleteOneStudent(int id, bool trackChanges)
        {
            var student = _repositoryManager.StudentRepositories.GetOneStudent(id, trackChanges);
            if (student is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            _repositoryManager.StudentRepositories.DeleteOneStudent(student);
            _repositoryManager.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudent(bool trackChanges)=> _repositoryManager.StudentRepositories.GetAllStudent(trackChanges);

        public Student GetOneStudent(int id, bool trackChanges)
        {
            var student = _repositoryManager.StudentRepositories.GetOneStudent(id, trackChanges);
            if (student is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            return student;
        }

        public void UpdateOneStudent(StudentUpdateDto studentUpdateDto, int id, bool trackChanges)
        {
            var student = _repositoryManager.StudentRepositories.GetOneStudent(id, trackChanges);
            if (student is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            var empMapper = _mapper.Map<Student>(studentUpdateDto);
            _repositoryManager.StudentRepositories.UpdateOneStudent(empMapper);
            _repositoryManager.SaveChanges();
        }
    }
}
