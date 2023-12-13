using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.WantRepo
{
    public interface IWantRepositories:IRepositoryBase<Entities.Models.Wants>
    {
        void CreateOneWants(Entities.Models.Wants wants);
        void DeleteOneWants(Entities.Models.Wants wants);
        void UpdateOneWants(Entities.Models.Wants wants);
        IEnumerable<Entities.Models.Wants> GetAllWants(bool trackChanges);
        Entities.Models.Wants GetOneWants(int id, bool trackChanges);
    }
}
