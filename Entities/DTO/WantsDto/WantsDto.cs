using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.WantsDto
{
    public class WantsDto
    {
        public int WantsId { get; set; }
        public string? Explanation { get; set; }
        public string? Description { get; set; }
        public Conclusion Conclusion { get; set; }
    }
}
