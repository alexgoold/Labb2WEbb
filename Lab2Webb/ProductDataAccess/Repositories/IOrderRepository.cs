using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories;

public interface IOrderRepository
{
	Task CreateOrder(ObjectId customerId, ProductDTO[] products);
	Task DeleteOrder(ObjectId orderId);
	
}