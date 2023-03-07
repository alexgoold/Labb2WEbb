namespace Lab2Webb.Server.Extensions;

public static class WebApplicationEndpointExtensions

{
	public static WebApplication MapProductEndpoints(this WebApplication app)
	{
		//  / createProduct			MapPost
		//	/ updateProduct			MapPut
		//	/ deleteProduct			MapDelete
		//	/ discontinuedProduct   MapPatch
		//	/ getAllProducts		Get
		//	/ getProductByName		Get
		//	/ getProductById		Get

		return app;
	}
	
}