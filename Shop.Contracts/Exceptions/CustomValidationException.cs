using Shop.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Exceptions
{
    public class CustomValidationException: Exception
    {
        public CustomValidationException(List<ValidationError> errors) 
        {
            Errors = errors;
        }

        public List<ValidationError> Errors { get; }
    }
}
