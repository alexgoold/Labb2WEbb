using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

		public async Task<ProductDTO> CreateProduct(ProductDTO product)
		{
			var createdProduct = new ProductDTO();
			return createdProduct;
		}

		///createProduct
		///updateProduct
		///deleteProduct
		///discontinuedProduct
		///getAllProducts
		///getProductByName
		///getProductById


		private ProductModel ConvertToModel(ProductDTO dto)
		{
			return new ProductModel()
			{
			
			};
		}

		private ProductDTO ConvertToDto(ProductModel dataModel)
		{
			return new ProductDTO()
			{
			};
		}
	}
}
