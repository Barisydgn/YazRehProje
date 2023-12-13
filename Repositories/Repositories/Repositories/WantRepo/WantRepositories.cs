using Entities.Models;
using Repositories.Context;
using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.WantRepo
{
    public class WantRepositories : RepositoryBase<Entities.Models.Wants>, IWantRepositories
    {
        public WantRepositories(YazContext context) : base(context)
        {
        }

        public void CreateOneWants(Wants wants) => Create(wants);
        public void DeleteOneWants(Wants wants)=> Delete(wants);
        public IEnumerable<Wants> GetAllWants(bool trackChanges)=> GetAll(trackChanges);

        public Wants GetOneWants(int id, bool trackChanges) => GetById(x => x.WantsId==id, trackChanges).SingleOrDefault();

        public void UpdateOneWants(Wants wants)=> Update(wants);
    }
}
