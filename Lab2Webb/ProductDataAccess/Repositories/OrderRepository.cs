using MongoDB.Driver;
using ProductDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;

namespace ProductDataAccess.Repositories
{
	public class OrderRepository
	{
		private readonly IMongoCollection<OrderModel> _orders;

		public OrderRepository()
		{
			var databaseName = "Labb2Webb";
			var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongo:mongo123@cluster0.t4yoico.mongodb.net/test");
			var client = new MongoClient(settings);
			var database = client.GetDatabase(databaseName);
			_orders =
				database.GetCollection<OrderModel>("Orders",
					new MongoCollectionSettings() { AssignIdOnInsert = true });
		}

		public async void CreateOrder(OrderModel order)
		{
			await _orders.InsertOneAsync(order);
		}

		}

	
}
