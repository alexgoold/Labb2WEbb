using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace Lab2Webb.Client.Pages
{
	partial class Orders :ComponentBase
	{
		private List<OrderDTO> OrderList { get; set; } = new();

		public List<ProductDTO> Products { get; set; } = new();

		public CustomerDTO Customer { get; set; } = new();

		public OrderDTO CurrentOrder { get; set; } = new();

		public bool IsVisible { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GetOrders();

			await base.OnInitializedAsync();

		}

		private async Task GetOrders()
		{
			OrderList = new List<OrderDTO>();

			var orders = await HttpClient.GetFromJsonAsync<OrderDTO[]>("allOrders");
			OrderList.AddRange(orders);
		}

		private void GetOrderByCustomer(ChangeEventArgs args)
		{
			var customerEmail = args.Value;

			Products = new();
			CurrentOrder = new();

			var selectedOrder = OrderList.Where(c => c.Customer.Email == customerEmail.ToString()).ToArray();

			if (selectedOrder.Length > 0)
			{
				Products.AddRange(selectedOrder[0].Products);
				CurrentOrder = selectedOrder[0];
				StateHasChanged();
			}
		}
	}
}
