﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductDataAccess.Models
{
	public class ProductModel
	{
		[BsonId] 
		public ObjectId ProductId { get; set; }

		[BsonElement]
		public string ProductName { get; set; }

		[BsonElement] 
		public decimal Price { get; set; }

		[BsonElement] 
		public string ProductDescription { get; set; }

		[BsonElement] 
		public string ProductType { get; set; }

		[BsonElement] 
		public bool Status { get; set; }
	}
}
