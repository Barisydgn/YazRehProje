using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class TokenDto
    {
        public String AccesToken { get; init; }
        public String RefreshToken { get; init; }
    }
}
