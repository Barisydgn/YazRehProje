using AutoMapper;
using Entities.DTO.EmployeeDto;
using Entities.ErrorModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.FileProviders;
using Repositories.Repositories.Repositories.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepositoryManager _repo;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public EmployeeServices(IRepositoryManager repo, IMapper mapper, IFileProvider fileProvider)
        {
            _repo = repo;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }

        public Employee CreateOneEmployee(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null)
                throw new ExceptionN("Lütfen bütün verileri doldurunuz");
            //var root = _fileProvider.GetDirectoryContents("wwwroot");
            //var images = root.First(x => x.Name == "images");
            //var randomİmages = Guid.NewGuid() + Path.GetExtension(employeeCreateDto.Image.FileName);
            //var path = Path.Combine(images.PhysicalPath, randomİmages);
            //using var stream = new FileStream(path, FileMode.Create);
            //employeeCreateDto.Image.CopyTo(stream);
            //employeeCreateDto.ImagePath = randomİmages;
            var employee=_mapper.Map<Employee>(employeeCreateDto);
          _repo.EmployeeRepositories.CreateOneEmployee(employee);
            _repo.SaveChanges();
            return employee;
        }

        public void DeleteOneEmployee(int id, bool trackChanges)
        {
            var employee = _repo.EmployeeRepositories.GetOneEmployee(id, trackChanges);
            if (employee is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            _repo.EmployeeRepositories.DeleteOneEmployee(employee);
            _repo.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployee(bool trackChanges)=> _repo.EmployeeRepositories.GetAllEmployee(trackChanges);

        public Employee GetOneEmployee(int id, bool trackChanges)
        {
            var employee=_repo.EmployeeRepositories.GetOneEmployee(id,trackChanges);
            if (employee is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            return employee;
        }

        public void UpdateOneEmployee(EmployeeUpdateDto employeeUpdateDto, int id, bool trackChanges)
        {
            var employee = _repo.EmployeeRepositories.GetOneEmployee(id, trackChanges);
            if (employee is null)
                throw new Exception($"Verdiğiniz id {id} ye ait veri bulunamamıştır");
            var empMapper = _mapper.Map<Employee>(employeeUpdateDto);
            _repo.EmployeeRepositories.UpdateOneEmployee(empMapper);
            _repo.SaveChanges();
        }
    }
}
