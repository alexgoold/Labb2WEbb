using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;

namespace ProductDataAccess.Repositories;

public interface IOrderRepository
{
	Task CreateOrder(ObjectId customerId, ProductDTO[] products);
	Task DeleteOrder(ObjectId orderId);
	
}