using System.ComponentModel.DataAnnotations;

namespace Lab2Webb.Shared.DTOs
{
	public class ProductDTO
	{
		[MaxLength (24), MinLength(24)]
		public string ProductId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string Type { get; set; }
		[Required]
		public bool Status { get; set; }
		public string ImgURL { get; set; }
	}
}
