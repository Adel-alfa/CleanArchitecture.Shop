

using Shop.Infrastructure.Configurations;
using Shop.Application.Configurations;
using Scalar.AspNetCore;
using Shop.API.Endpoints;
using Shop.API.Handlers;


namespace Shop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

       
            builder.Services.AddAuthorization();

            builder.Services.AddApplicationServices()
               .AddPersistanceServices(builder.Configuration);
            builder.Services.AddExceptionHandler<ExceptionHandler>();

            var allowedOriginStr = builder.Configuration["FrontendUrl"];
            var allowedOrigins = allowedOriginStr!.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            builder.Services.AddCors(option => option.AddPolicy("CorsPolicy",
             policy => policy.WithOrigins(allowedOrigins)
             .AllowAnyMethod()
             .AllowAnyHeader()             
             ));

            builder.Services.AddOpenApi();

            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(); // https://localhost:7115/Scalar/v1
            }

            app.UseExceptionHandler(_ => { });
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapProductEndpoints();
            app.MapCategoryEndpoints();

            app.Run();
        }
    }
}
