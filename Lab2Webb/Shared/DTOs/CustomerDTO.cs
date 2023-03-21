using System.ComponentModel.DataAnnotations;

namespace Lab2Webb.Shared.DTOs;

public class CustomerDTO
{

	public string Id { get; set; }
	[Required]
	public string FirstName { get; set; }
	[Required]
	public string LastName { get; set; }
	[Required]
	public string Email { get; set; }
	[Required]
	public string Phone { get; set; }
	[Required]
	public string Address { get; set; }

}
