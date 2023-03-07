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
			var host = "localhost";
			var databaseName = "NetChat";
			var port = 27017;
			var connectionString = $"mongodb://{host}:{port}";
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(databaseName);
		}
	}
}
