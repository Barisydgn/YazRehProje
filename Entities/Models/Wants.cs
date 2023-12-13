using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Wants
    {
        public int WantsId { get; set; }
        public string? Explanation { get; set; }
        public string? Description { get; set; }
        public Conclusion  Conclusion { get; set; }
    }
}
