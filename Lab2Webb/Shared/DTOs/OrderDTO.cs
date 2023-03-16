namespace Lab2Webb.Shared.DTOs;

public class OrderDTO
{
	public  CustomerDTO Customer { get; set; }

	public List<ProductDTO> Products { get; set; }

	public DateTime DateOrdered { get; set; }

}