using Entities.DTO.StudentDto;
using Entities.DTO.WantsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.WantsServices
{

    public interface IWantServices
    {
        Entities.Models.Wants CreateOneWants(WantsCreateDto wantsCreateDto);
        void UpdateOneWants(WantsUpdateDto wantsUpdateDto, int id, bool trackChanges);
        void DeleteOneWants(int id, bool trackChanges);
        Entities.Models.Wants GetOneWants(int id, bool trackChanges);
        IEnumerable<Entities.Models.Wants> GetAllWants(bool trackChanges);
    }
}
