using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductDataAccess.Models;

public class CustomerModel
{
	
	[BsonId]
	public ObjectId Id { get; set; }

	[BsonElement]
	public string FirstName { get; set; }
	[BsonElement] 
	public string LastName { get; set; }

	[BsonElement]
	public string EmailAddress { get; set; }

	[BsonElement]
	public string PhoneNumber { get; set; }
	[BsonElement]
	public string Address { get; set; }

}