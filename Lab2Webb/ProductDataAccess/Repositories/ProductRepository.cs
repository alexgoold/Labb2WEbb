using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories
{
	public class ProductRepository
	{
		private readonly IMongoCollection<ProductModel> _products;

		public ProductRepository()
		{
			var databaseName = "Labb2Webb";
			var port = 27017;
			var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongo:mongo123@cluster0.t4yoico.mongodb.net/?retryWrites=true&w=majority");
			var client = new MongoClient(settings);
			var database = client.GetDatabase(databaseName);
			_products =
				database.GetCollection<ProductModel>("Prodcuts",
					new MongoCollectionSettings() { AssignIdOnInsert = true });
		}

		///createProduct
		///updateProduct
		///deleteProduct
		///discontinuedProduct
		///getAllProducts
		///getProductByName
		///getProductById

	}
}
