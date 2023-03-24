using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Lab2Webb.Client.Pages
{
	partial class CreateCustomer :ComponentBase
	{
		public CustomerDTO CustomerToUpdate { get; set; } = new();
		public CustomerDTO Customer { get; set; } = new();

		public List<CustomerDTO> CustomerList { get; set; } = new();


		async Task CreateNewCustomer()
		{
			await HttpClient.PostAsJsonAsync("createCustomer", Customer);

			Customer = new CustomerDTO();
			await GetCustomers();

			StateHasChanged();
		}

		async Task GetCustomers()
		{
			CustomerList = new List<CustomerDTO>();

			var customers = await HttpClient.GetFromJsonAsync<CustomerDTO[]>("allCustomers");

			CustomerList.AddRange(customers);
		}

		async Task UpdateCustomer()
		{
			await HttpClient.PutAsJsonAsync($"updateCustomer?id={CustomerToUpdate.Id}", CustomerToUpdate);

			CustomerToUpdate = new CustomerDTO();
			await GetCustomers();

			StateHasChanged();
		}

		async Task GetByEmail(ChangeEventArgs obj)
		{
			var customerEmail = obj.Value;

			var prod = await HttpClient.GetFromJsonAsync<CustomerDTO[]>($"getByEmail?email={customerEmail}");

			if (prod.Length > 0)
			{
				CustomerToUpdate = prod[0];
			}

		}

		protected override async Task OnInitializedAsync()
		{
			await GetCustomers();

			await base.OnInitializedAsync();

		}
	}
}
