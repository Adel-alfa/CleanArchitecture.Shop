using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository productRepository;
        public CreateProductCommandHandler(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId,
            };
            var result = await productRepository.CreateAsync(product,cancellationToken);
            return result.Id;
        }
    }
}
