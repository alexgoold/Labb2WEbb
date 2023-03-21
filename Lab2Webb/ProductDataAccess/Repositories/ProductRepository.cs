using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoCollection<ProductModel> _products;


		public ProductRepository()
		{
			var databaseName = "Labb2Webb";
			var port = 27017;
			var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongo:mongo123@cluster0.t4yoico.mongodb.net/test");
			var client = new MongoClient(settings);
			var database = client.GetDatabase(databaseName);
			_products =
				database.GetCollection<ProductModel>("Products",
					new MongoCollectionSettings() { AssignIdOnInsert = true });
		}

		///createProduct
		public async Task CreateProduct(ProductDTO product)
		{
			await _products.InsertOneAsync(ConvertToModel(product));
		}


		///updateProduct
		public async Task UpdateProduct(ObjectId id, ProductDTO product)
		{
			
			var filter = Builders<ProductModel>.Filter.Eq("ProductId", id);
			var update = Builders<ProductModel>.Update
				.Set("ProductName", product.Name)
				.Set("ProductDescription", product.Description)
				.Set("Price", product.Price)
				.Set("ProductType", product.Type)
				.Set("Status", product.Status)
				.Set("ImgURL", product.ImgURL);

			await _products.UpdateOneAsync(filter, update);

		}

		///deleteProduct

		public async Task DeleteProduct(ObjectId id)
		{
			var filter = Builders<ProductModel>.Filter.Eq("ProductId", id);
			await _products.DeleteOneAsync(filter);
		}

		///discontinuedProduct
		public async Task DiscontinuedProduct(ObjectId id, bool isDiscontinued)
		{
			var filter = Builders<ProductModel>.Filter.Eq("ProductId", id);
			var update = Builders<ProductModel>.Update
				.Set("Status", isDiscontinued );

			await _products.UpdateOneAsync(filter, update);
		}

		///getAllProducts

		public async Task<ProductDTO[]> GetAllProducts()
		{
			var filter = Builders<ProductModel>.Filter.Empty;
			var all = await _products.FindAsync(filter);
			return all.ToList().Select(ConvertToDto).ToArray();
		}

		///getProductByName

		public async Task<ProductDTO[]> GetProductByName(string name)
		{
			var filter = Builders<ProductModel>.Filter.Eq("ProductName", name);
			var all = await _products.FindAsync(filter);
			return all.ToList().Select(ConvertToDto).ToArray();

		}
		///getProductById
		public async Task<ProductDTO[]> GetProductById(ObjectId id)
		{
			var filter = Builders<ProductModel>.Filter.Eq("ProductId", id);
			var all = await _products.FindAsync(filter);
			return all.ToList().Select(ConvertToDto).ToArray();
		}


		public ProductModel ConvertToModel(ProductDTO dto)
		{
			if (dto.ProductId == null)
			{
				return new ProductModel()
				{
					ProductName = dto.Name,
					ProductDescription = dto.Description,
					Price = dto.Price,
					ProductType = dto.Type,
					Status = dto.Status,
					ImgURL = dto.ImgURL,
				};
			}
			return new ProductModel()
				{
					ProductName = dto.Name,
					ProductDescription = dto.Description,
					Price = dto.Price,
					ProductType = dto.Type,
					Status = dto.Status,
					ProductId = new ObjectId(dto.ProductId),
					ImgURL = dto.ImgURL,
				};


		}

		public ProductDTO ConvertToDto(ProductModel model)
		{
			return new ProductDTO()
			{
				Name = model.ProductName,
				Description = model.ProductDescription,
				Price = model.Price,
				Type = model.ProductType,
				Status = model.Status,
				ProductId = model.ProductId.ToString(),
				ImgURL = model.ImgURL,

			};
		}

		public async Task<bool> CheckExists(ObjectId id)
		{
			var filter = Builders<ProductModel>.Filter.Eq("ProductId", id);
			return await _products.Find(filter).CountDocumentsAsync() > 0;
		}

		public async Task<bool> CheckExistsName(string name)
		{
			var filter = Builders<ProductModel>.Filter.Eq("Name", name);
			return await _products.Find(filter).CountDocumentsAsync() > 0;
		}
	}
}
