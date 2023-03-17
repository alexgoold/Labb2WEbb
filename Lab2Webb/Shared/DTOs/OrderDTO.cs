namespace Lab2Webb.Shared.DTOs;

public class OrderDTO
{
	public CustomerDTO Customer { get; set; }

	public ProductDTO[] Products { get; set; }

	public DateTime DateOrdered { get; set; }

}