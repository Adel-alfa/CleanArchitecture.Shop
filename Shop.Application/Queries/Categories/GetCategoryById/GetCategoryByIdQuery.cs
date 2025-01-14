using MediatR;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Categories.GetCategoryById
{
    public record GetCategoryByIdQuery(int id) : IRequest<GetCategoryByIdResponse>;
    
}
