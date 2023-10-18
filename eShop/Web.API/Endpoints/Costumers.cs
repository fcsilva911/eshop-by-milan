using Application.Customers.Create;
using Carter;
using MediatR;

namespace Web.API.Endpoints
{
    public sealed class Costumers : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("customer", async (
                CreateCostumerRequest request,
                ISender sender) =>
            {
                var command = new CreateCustomerCommand(request.Email, request.Name);

                await sender.Send(command);

                return Results.Ok();
            });
        }
    }
}
