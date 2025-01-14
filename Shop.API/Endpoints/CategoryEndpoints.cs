using MediatR;
using Shop.Application.Commands.Categories.CreateCategory;
using Shop.Application.Commands.Categories.DeleteCategory;
using Shop.Application.Commands.Categories.UpdateCategory;
using Shop.Application.Queries.Categories.GetCategories;
using Shop.Application.Queries.Categories.GetCategoryById;
using Shop.Contracts.Requests;

namespace Shop.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/categories", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var categories = await mediator.Send(new GetCategoryQuery(), cancellationToken);
                return Results.Ok(categories);
            }).WithTags("categories");

            app.MapGet("/api/categories/{id}", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                var category = await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
                return Results.Ok(category);
            }).WithTags("categories");

            app.MapPost("/api/categories", async (CreateCategoryRequest CreateCategory, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new CreateCategoryCommand(CreateCategory.Name);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("categories");

            app.MapPut("/api/categories/{id}", async (int id,UpdateCategoryRequest UpdateCategory, IMediator mediator, CancellationToken cancellationToken) =>
            {
                if (id != UpdateCategory.Id)
                    return Results.BadRequest("The Query parameter Id does not match the body id");

                var command = new UpdateCategoryCommand(id,UpdateCategory.Name);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("categories");

            app.MapDelete("/api/categories/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new DeleteCategoryCommand(id);
                var result = await mediator.Send(command, cancellationToken);
                return Results.Ok(result);
            }).WithTags("categories");
        }
    }
}
