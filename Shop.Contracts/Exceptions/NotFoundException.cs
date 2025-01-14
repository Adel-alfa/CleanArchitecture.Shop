using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Exceptions
{
    //public class NotFoundException(string message) : Exception(message);
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, string Key) : base($"{name} ({Key})was not found")
        {

        }
    }
}
//  throw new NotFoundException(nameof(user), request.id.ToString());