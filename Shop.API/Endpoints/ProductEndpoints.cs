using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Commands.Products.CreateProduct;
using Shop.Application.Commands.Products.DeleteProduct;
using Shop.Application.Commands.Products.UpdateProduct;
using Shop.Application.Queries.GetProducts;
using Shop.Application.Queries.Products.GetProductById;
using Shop.Application.Queries.Products.GetProductByPage;
using Shop.Application.Queries.Products.GetProducts;
using Shop.Contracts.Requests;
using Shop.Contracts.Utils;

namespace Shop.API.Endpoints
{
    public static class ProductEndpoints
    {

        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", async (IMediator mediator, CancellationToken cancellationToken) =>
             {
                 var products = await mediator.Send(new GetProductQuery(), cancellationToken);
                 return Results.Ok(products);
             }).WithTags("Products");

            app.MapGet("/api/products/page", async (IMediator mediator, [FromQuery] int pageSize, [FromQuery] int pageNumber, CancellationToken cancellationToken) =>
            {
                var products = await mediator.Send(new GetProductPageQuery(new PaginationParameters { PageNumber = pageNumber, PageSize = pageSize }), cancellationToken);
                return Results.Extensions.OkPaginationResult(products.PageSize, products.CurrentPage,
                    products.TotalPages,products.TotalCount, products.Items);
            }).WithTags("Products");

            app.MapGet("/api/products/{id}", async (int id,IMediator mediator, CancellationToken cancellationToken) =>
            {
                var product = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
                return Results.Ok(product);
            }).WithTags("Products");

            app.MapPost("/api/products", async (CreateProductRequest CreateProduct, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new CreateProductCommand(CreateProduct.Name, CreateProduct.Description,CreateProduct.Price,
                                                CreateProduct.Quantity,CreateProduct.CategoryId);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("Products");

            app.MapPut("/api/products/{id}", async (int id,UpdateProductRequest UpdateProduct, IMediator mediator, CancellationToken cancellationToken) =>
            {
                if (id != UpdateProduct.Id)
                    return Results.BadRequest("The Query parameter Id does not match the body id");

                var command = new UpdateProductCommand(id,UpdateProduct.Name, UpdateProduct.Description, UpdateProduct.Price,
                                                UpdateProduct.Quantity, UpdateProduct.CategoryId);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("Products");

            app.MapDelete("/api/products/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new DeleteProductCommand(id);
                var result = mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("Products");
        }
    }
}
