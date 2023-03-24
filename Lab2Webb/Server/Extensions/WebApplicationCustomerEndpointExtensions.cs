using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Server.Extensions;

public static class WebApplicationCustomerEndpointExtensions
{
	public static WebApplication MapCustomerEndpoints(this WebApplication app)
	{
		app.MapPost("/createCustomer", CreateCustomerHandler);

		app.MapPut("/updateCustomer", UpdateCustomerHandler);

		app.MapGet("/allCustomers", GetAllCustomersHandler);

		app.MapGet("/getByEmail", GetByEmailHandler);


		return app;
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