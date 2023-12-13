using Entities.Models;
using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.StudentRepo
{
    public interface IStudentRepositories:IRepositoryBase<Entities.Models.Student>
    {
        void CreateOneStudent(Student student);
        void DeleteOneStudent(Student student);
        void UpdateOneStudent(Student student);
        IEnumerable<Entities.Models.Student> GetAllStudent(bool trackChanges);
        Entities.Models.Student GetOneStudent(int id, bool trackChanges);
    }
}
