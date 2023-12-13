using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.StudentRepo
{
    public class StudentRepositories : RepositoryBase<Entities.Models.Student>, IStudentRepositories
    {
        public StudentRepositories(YazContext context) : base(context)
        {
        }

        public void CreateOneStudent(Student student) => Create(student);

        public void DeleteOneStudent(Student student)=> Delete(student);
        public IEnumerable<Student> GetAllStudent(bool trackChanges) => GetAll(trackChanges).Include(x => x.Employee);

        public Student GetOneStudent(int id, bool trackChanges) => GetById(x => x.StudentId==id, trackChanges).SingleOrDefault();

        public void UpdateOneStudent(Student student)=> Update(student);
    }
}
