using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.GetById;
using Application.Products.Update;
using Carter;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/products", CreateProduct);
            app.MapGet("api/products", GetProducts);
            app.MapGet("api/products/{id}", GetProduct).WithName(nameof(GetProduct));
            app.MapPut("api/products/{id}", UpdateProduct).WithName(nameof(UpdateProduct));
            app.MapDelete("api/products/{id}", DeleteProduct).WithName(nameof(DeleteProduct));
        }

        private async Task<IResult> CreateProduct(CreateProductRequest request, ISender sender)
        {
            var command = new CreateProductCommand(request.Name, request.Sku, request.Currency, request.Amount);

            await sender.Send(command);

            return Results.Ok();
        }

        private static async Task<IResult> GetProducts(
            string? searchTerm,
            string? sortColumn,
            string? sortOrder,
            int page,
            int pageSize,
            ISender sender)
        {
            var query = new GetProductsQuery(searchTerm, sortColumn, sortOrder, page, pageSize);

            var products = await sender.Send(query);

            return Results.Ok(products);
        }

        private async Task<IResult> GetProduct(Guid id, ISender sender)
        {
            try
            {
                var product = await sender.Send(new GetProductQuery(new ProductId(id)));

                return Results.Ok(product);
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        private async Task<IResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, ISender sender)
        {
            try
            {
                var command = new UpdateProductCommand(
                    new ProductId(id),
                    request.Name,
                    request.Sku,
                    request.Currency,
                    request.Amount);

                await sender.Send(command);

                return Results.NoContent();
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        private async Task<IResult> DeleteProduct(Guid id, ISender sender)
        {
            try
            {
                await sender.Send(new DeleteProductCommand(new ProductId(id)));

                return Results.NoContent();
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        }
    }
}
