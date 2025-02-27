﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.CreateCategory
{
    public record CreateCategoryCommand(string Name) : IRequest<int>;
   
}
