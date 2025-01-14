using Shop.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Responses
{
    public record GetProductByIdResponse(ProductDto ProductDto);
    
}
