using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;

namespace ProductDataAccess.Repositories
{
	public interface IProductRepository
	{
		Task CreateProduct(ProductDTO product);


		Task UpdateProduct(ObjectId id, ProductDTO product);

		Task DeleteProduct(ObjectId id);

		Task DiscontinuedProduct(ObjectId id, bool isDiscontinued);

		Task<ProductDTO[]> GetAllProducts();


		Task<ProductDTO[]> GetProductByName(string name);
		Task<ProductDTO[]> GetProductById(ObjectId id);

		Task<bool> CheckExists(ObjectId id);

		ProductModel ConvertToModel(ProductDTO dto);

		ProductDTO ConvertToDto(ProductModel model);
	}
}
