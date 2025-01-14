using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string Name) : IRequest<Unit>;

}
