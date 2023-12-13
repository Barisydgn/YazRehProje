using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModels
{
    public class ExceptionN:Exception
    {
        public ExceptionN(string message):base($"Geçersiz İstek")
        {

        }
    }
}
