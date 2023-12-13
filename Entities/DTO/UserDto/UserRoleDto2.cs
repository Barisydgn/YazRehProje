using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class UserRoleDto2
    {
        public string UserId { get; set; }
        
        public string UserName{ get; set; }
        public string Email{ get; set; }
        
        public List <IdentityRole> Roles{ get; set; }
        public string roleName { get; set; }
    }
}
