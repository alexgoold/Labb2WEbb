using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lab2Webb.Client.Pages
{
	partial class Customers:ComponentBase
	{

		public CustomerDTO CurrentCustomer { get; set; } = new();

		public List<CustomerDTO> CustomerList { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			await GetCustomers();

			await base.OnInitializedAsync();

		}

		 async Task GetCustomers()
		{
			CustomerList = new List<CustomerDTO>();

			var customers = await HttpClient.GetFromJsonAsync<CustomerDTO[]>("allCustomers");

			CustomerList.AddRange(customers);
		}

		 async Task GetCustomerByEmail()
		{
			CustomerList = new List<CustomerDTO>();

			var prod = await HttpClient.GetFromJsonAsync<CustomerDTO[]>($"getByEmail?email={CurrentCustomer.Email}");

			if (prod.Length > 0)
			{
				CustomerList.AddRange(prod);
			}
		}

		async Task ResetList()
		{
			await GetCustomers();
			StateHasChanged();

		}
	}
}
