using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Requests
{
    public record UpdateCategoryRequest(int Id, string Name);
    
}
