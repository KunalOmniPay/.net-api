using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
   public class DataNotFound : Exception
    {
        public DataNotFound(string message)
            :base(message)
        {

        }
        public DataNotFound(string message,Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
