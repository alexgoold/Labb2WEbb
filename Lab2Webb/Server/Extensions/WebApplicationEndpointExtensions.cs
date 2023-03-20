using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Server.Extensions;

public static class WebApplicationEndpointExtensions

{
	public static WebApplication MapProductEndpoints(this WebApplication app)
	{
		app.MapPost("/createProduct", CreateProductHandler);

		app.MapPut("/updateProduct", UpdateProductHandler);

		app.MapDelete("/deleteProduct", DeleteProductHandler);

		app.MapPatch("/discontinuedProduct", DiscontinuedProduct);

		app.MapGet("/allProducts", AllProductsHandler);

		app.MapGet("/productByName",ProductByName);

		app.MapGet("/productById", ProductById);
		

		return app;
	}

	

	private static async Task<IResult> ProductById(IProductRepository repo, ObjectId id)
	{
		return Results.Ok(await repo.GetProductById(id));
	}

	private static async Task<IResult> ProductByName(IProductRepository repo, string name)
	{
		return Results.Ok(await repo.GetProductByName(name));
	}
		

	private static async Task<IResult> AllProductsHandler(IProductRepository repo)
	{
		return Results.Ok(await repo.GetAllProducts());
	}

	private static async Task<IResult> DeleteProductHandler(IProductRepository repo, ObjectId id)
	{
		if (await repo.CheckExists(id) == false) return Results.NotFound();

		await repo.DeleteProduct(id);
		return Results.Ok();
	}

	public static async Task<IResult> CreateProductHandler(IProductRepository repo, ProductDTO product)
	{
		await repo.CreateProduct(product);
		return Results.Ok();
	}

	public static async Task<IResult> UpdateProductHandler(IProductRepository repo, ObjectId id, ProductDTO product)
	{
		if (await repo.CheckExists(id)== false) return Results.NotFound();

		await repo.UpdateProduct(id, product);
		return Results.Ok();
	}

	public static async Task<IResult> DiscontinuedProduct(IProductRepository repo, ObjectId id, bool isDiscontinued)
	{
		await repo.DiscontinuedProduct(id, isDiscontinued);
		return Results.Ok();
	}




}