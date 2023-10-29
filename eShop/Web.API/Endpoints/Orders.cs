﻿using Application.Orders.Create;
using Application.Orders.GetOrderSummary;
using Carter;
using MediatR;

namespace Web.API.Endpoints
{
    public class Orders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("orders", async (Guid customerId, ISender sender) =>
            {
                var command = new CreateOrderCommand(customerId);

                await sender.Send(command);

                return Results.Ok();
            });

            app.MapGet("order/{id}/summary", async (Guid id, ISender sender) =>
            {
                var query = new GetOrderSummaryQuery(id);

                return Results.Ok(await sender.Send(query));
            });
        }
    }
}
