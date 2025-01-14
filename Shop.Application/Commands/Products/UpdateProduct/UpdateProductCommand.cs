using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.UpdateProduct
{
    public record UpdateProductCommand(int Id, string Name, string Description,
        decimal Price, int Quantity, int CategoryId): IRequest<Unit>;
    
}
