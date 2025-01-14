using MediatR;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Categories.GetCategories
{
    public record GetCategoryQuery() : IRequest<GetCategoryResponse>;
    
}
