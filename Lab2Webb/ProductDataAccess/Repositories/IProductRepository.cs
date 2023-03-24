using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories
{
	public interface IProductRepository
	{
		Task CreateProduct(ProductDTO product);


		Task UpdateProduct(ObjectId id, ProductDTO product);

		Task DeleteProduct(ObjectId id);

		Task DiscontinuedProduct(ObjectId id, ProductDTO isDiscontinued);

		Task<ProductDTO[]> GetAllProducts();


		Task<ProductDTO[]> GetProductByName(string name);
		Task<ProductDTO[]> GetProductById(ObjectId id);

		Task<bool> CheckExists(ObjectId id);

		Task<bool> CheckExistsName(string name);

		ProductModel ConvertToModel(ProductDTO dto);

		ProductDTO ConvertToDto(ProductModel model);
	}
}
