using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class DeleteRoleDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }
        public  List<string> Roles { get; set; }
        public string RoleId { get; set; }
    }
}
