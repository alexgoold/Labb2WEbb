namespace Lab2Webb.Shared.DTOs;

public class OrderDTO
{

	public string Id { get; set; }
	public CustomerDTO Customer { get; set; }

	public ProductDTO[] Products { get; set; }

	public DateTime DateOrdered { get; set; }

}