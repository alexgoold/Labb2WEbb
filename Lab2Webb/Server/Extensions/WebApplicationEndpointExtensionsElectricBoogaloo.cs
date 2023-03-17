using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Models;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Server.Extensions;

public static class WebApplicationEndponitExtensionsElectricBoogaloo
{
	public static WebApplication MapCustomerEndpoints(this WebApplication app)
	{
		app.MapPost("/createCustomer", CreateCustomerHandler);

		app.MapPut("/updateCustomer", UpdateCustomerHandler);

		app.MapGet("/allCustomers", GetAllCustomersHandler);

		app.MapGet("/getByEmail", GetByEmailHandler);

		app.MapPost("/createOrder", CreateOrderHandler);

		app.MapDelete("/deleteOrder", DeleteOrderHandler);


		return app;
	}

	private static async Task<IResult> DeleteOrderHandler(IOrderRepository repo, ObjectId id)
	{
		await repo.DeleteOrder(id);
		return Results.Ok();
	}

	private static async Task<IResult> CreateOrderHandler(IOrderRepository repo, ObjectId id, ProductDTO[] products)
	{
		
		await repo.CreateOrder(id, products);
		var breakpoint = 4;
		return Results.Ok();
	}

	private static async Task<IResult> CreateCustomerHandler(ICustomerRepository repo, CustomerDTO dto)
	{
		await repo.CreateCustomer(dto);
		return Results.Ok();
	}

	private static async Task<IResult> UpdateCustomerHandler(ICustomerRepository repo, ObjectId id, CustomerDTO dto)
	{
		if(await repo.CheckExists(id)==false) return Results.NotFound();

		await repo.UpdateCustomer(id, dto);
		return Results.Ok();
	}

	private static async Task<IResult> GetAllCustomersHandler(ICustomerRepository repo)
	{
		return Results.Ok(await repo.GetAllCustomers());
	}

	private static async Task<IResult> GetByEmailHandler(ICustomerRepository repo, string email)
	{
		return Results.Ok(await repo.GetCustomerByEmail(email));
	}


}