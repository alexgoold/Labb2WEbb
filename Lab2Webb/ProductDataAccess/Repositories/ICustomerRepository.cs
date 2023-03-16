using Lab2Webb.Shared.DTOs;
using MongoDB.Bson;
using ProductDataAccess.Models;

namespace ProductDataAccess.Repositories;

public interface ICustomerRepository
{
	Task CreateCustomer(CustomerDTO customer);
	Task UpdateCustomer(ObjectId id, CustomerDTO customer);

	Task<CustomerDTO[]> GetAllCustomers();

	Task<CustomerDTO[]> GetCustomerByEmail(string email);

	CustomerModel ConvertToModel(CustomerDTO dto);

	CustomerDTO ConvertToDto (CustomerModel model);
}