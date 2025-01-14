using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Requests
{
    public record CreateProductRequest(string Name, string Description, decimal Price, int Quantity, int CategoryId);
   
}
