using MongoDB.Driver;
using ProductDataAccess.Models;
using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;

namespace ProductDataAccess.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly IMongoCollection<OrderModel> _orders;


		private readonly IProductRepository _productRepo = new ProductRepository();

		private readonly ICustomerRepository _customerRepo = new CustomerRepository();

		public OrderRepository()
		{
			var databaseName = "Labb2Webb";
			var settings =
				MongoClientSettings.FromConnectionString(
					"mongodb+srv://mongo:mongo123@cluster0.t4yoico.mongodb.net/test");
			var client = new MongoClient(settings);
			var database = client.GetDatabase(databaseName);
			_orders =
				database.GetCollection<OrderModel>("Orders",
					new MongoCollectionSettings() { AssignIdOnInsert = true });

		}

		public async Task CreateOrder(ObjectId customerId, ProductDTO[] products)
		{
			var orderAsModel = new OrderModel();


			orderAsModel.Products = products.Select(_productRepo.ConvertToModel).ToArray();

			var customers = _customerRepo.GetAllCustomers().Result;

			var customerDto = customers.Where(i => i.Id == customerId.ToString()).FirstOrDefault();

			orderAsModel.Customer = _customerRepo.ConvertToModel(customerDto);

			orderAsModel.DateOrdered = DateTime.Now;

			await _orders.InsertOneAsync(orderAsModel);
		}

		public async Task DeleteOrder(ObjectId orderId)
		{
			var filter = Builders<OrderModel>.Filter.Eq("Id", orderId);
			await _orders.DeleteOneAsync(filter);
		}

		public async Task<OrderDTO[]> GetAllOrders()
		{
			var filter = Builders<OrderModel>.Filter.Empty;
			var all = await _orders.FindAsync(filter);
			var test = all.ToList().Select(ConvertToDto).ToArray();
			return test;
		}


		public OrderModel ConvertToModel(OrderDTO dto)
		{

			if (dto.Id == null)
			{
				return new OrderModel()
				{
					Customer = _customerRepo.ConvertToModel(dto.Customer),
					DateOrdered = dto.DateOrdered,
					Products = dto.Products.Select(_productRepo.ConvertToModel).ToArray()
				};
			}

			return new OrderModel()
			{
				Customer = _customerRepo.ConvertToModel(dto.Customer),
				DateOrdered = dto.DateOrdered,
				Products = dto.Products.Select(_productRepo.ConvertToModel).ToArray(),
				Id = new ObjectId(dto.Id)
			};

		}

		public OrderDTO ConvertToDto(OrderModel model)
		{
			return new OrderDTO()
			{
				Customer = _customerRepo.ConvertToDto(model.Customer),
				DateOrdered = model.DateOrdered,
				Products = model.Products.Select(_productRepo.ConvertToDto).ToArray(),
				Id = model.Id.ToString(),
			};
		}
	}
}
