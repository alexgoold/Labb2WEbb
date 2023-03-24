using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Server.Extensions
{
	public static class WebApplicationOrderEndpointExtensions
	{
		public static WebApplication MapOrderEndpoints(this WebApplication app)
		{

			app.MapPost("/createOrder", CreateOrderHandler);

			app.MapDelete("/deleteOrder", DeleteOrderHandler);

			app.MapGet("/allOrders", GetAllOrdersHandler);

			return app;
		}


		private static async Task<IResult> CreateOrderHandler(IOrderRepository repo, ObjectId id, ProductDTO[] products)
		{
			await repo.CreateOrder(id, products);
			return Results.Ok();
		}

		private static async Task<IResult> DeleteOrderHandler(IOrderRepository repo, ObjectId id)
		{
			await repo.DeleteOrder(id);
			return Results.Ok();
		}

		private static async Task<IResult> GetAllOrdersHandler(IOrderRepository repo)
		{
			return Results.Ok(await repo.GetAllOrders());
		}
	}
}
