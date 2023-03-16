using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Webb.Shared.DTOs
{
	public class ProductDTO
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public bool Status { get; set; }
	}
}
