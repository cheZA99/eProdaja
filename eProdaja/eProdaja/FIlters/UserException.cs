using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.FIlters
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}
