using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Server.Extensions;

public static class WebApplicationEndpointExtensions

{
	public static WebApplication MapProductEndpoints(this WebApplication app)
	{
		//  / createProduct			MapPost
		app.MapPost("/createProduct", async (ProductRepository repo, ProductDTO product) =>
		{
			await repo.CreateProduct(product);

		});
		//	/ updateProduct			MapPut
		app.MapPut("/updateProduct", async (ProductRepository repo, ObjectId id, ProductDTO product) =>
		{
			await repo.UpdateProduct(id, product);
		});
		//	/ deleteProduct			MapDelete
		app.MapDelete("/deleteProduct", async (ProductRepository repo, ObjectId id) =>
		{
			await repo.DeleteProduct(id);
		});
		//	/ discontinuedProduct   MapPatch
		app.MapPatch("/discontinuedProduct", async (ProductRepository repo, ObjectId id, bool isDiscontinued) =>
		{
			await repo.DiscontinuedProduct(id, isDiscontinued);
		});
		//	/ getAllProducts		Get
		app.MapGet("/allProducts", async (ProductRepository repo) =>
		{
			await repo.GetAllProducts();
		});
		//	/ getProductByName		Get
		app.MapGet("/productByName", async (ProductRepository repo, string name) =>
		{
			await repo.GetProductByName(name);
		});
		//	/ getProductById		Get
		app.MapGet("/productById", async (ProductRepository repo, ObjectId id) =>
		{
			await repo.GetProductById(id);
		});

		return app;
	}

	
	
}