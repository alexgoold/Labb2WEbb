using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories;

public class CustomerRepository
{
	private readonly IMongoCollection<CustomerModel> _customers;

	public CustomerRepository()
	{
		var databaseName = "Labb2Webb";
		var port = 27017;
		var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongo:mongo123@cluster0.t4yoico.mongodb.net/test");
		var client = new MongoClient(settings);
		var database = client.GetDatabase(databaseName);
		_customers =
			database.GetCollection<CustomerModel>("Customers",
				new MongoCollectionSettings() { AssignIdOnInsert = true });
	}

	public async Task CreateCustomer(CustomerDTO customer)
	{
		await _customers.InsertOneAsync(ConvertToModel(customer));
	}


	public async Task UpdateCustomer(ObjectId id, CustomerDTO customer)
	{

		var filter = Builders<CustomerModel>.Filter.Eq("Id", id);
		var update = Builders<CustomerModel>.Update
			.Set("FirstName", customer.FirstName)
			.Set("LastName", customer.LastName)
			.Set("EmailAddress", customer.Email)
			.Set("PhoneNumber", customer.Phone)
			.Set("Address", customer.Address);

		await _customers.UpdateOneAsync(filter, update);

	}
	public async Task<CustomerDTO[]> GetAllCustomers()
	{
		var filter = Builders<CustomerModel>.Filter.Empty;
		var all = await _customers.FindAsync(filter);
		return all.ToList().Select(ConvertToDto).ToArray();
	}
	public async Task<CustomerDTO[]> GetCustomerByEmail(string email)
	{
		var filter = Builders<CustomerModel>.Filter.Eq("EmailAddress", email);
		var all = await _customers.FindAsync(filter);
		return all.ToList().Select(ConvertToDto).ToArray();

	}


	private CustomerModel ConvertToModel(CustomerDTO dto)
	{
		return new CustomerModel()
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			EmailAddress = dto.Email,
			PhoneNumber = dto.Phone,
			Address = dto.Address,
		};

	}

	private CustomerDTO ConvertToDto(CustomerModel model)
	{
		return new CustomerDTO()
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Email = model.EmailAddress,
			Phone = model.PhoneNumber,
			Address = model.Address,
		};
	}
}