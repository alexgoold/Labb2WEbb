using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using ProductDataAccess.Repositories;
using System.Net.Http.Json;
using MongoDB.Bson;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Lab2Webb.Client.Pages
{
	public partial class CreateProduct :ComponentBase
	{
		public ProductDTO Product { get; set; } = new();

		public ProductDTO ProductToUpdate { get; set; } = new();
		public ProductDTO ProductToDelete { get; set; } = new();

		public List<ProductDTO> ProductList { get; set; } = new();

		async Task CreateNewProduct()
		{
			await HttpClient.PostAsJsonAsync(HttpClient.BaseAddress + "createProduct", Product);

			Product = new ProductDTO();

		}

		async Task UpdateProduct()
		{
			await HttpClient.PutAsJsonAsync(HttpClient.BaseAddress + $"updateProduct?id={ProductToUpdate.ProductId}", ProductToUpdate);
			
			ProductToUpdate = new ProductDTO();
			await InvokeAsync(() =>
			{

				StateHasChanged();
			});
		}
		
		async Task GetProducts()
		{
			ProductList = new List<ProductDTO>();

			var prods = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress + "allProducts");

			ProductList.AddRange(prods);


		}
		protected override async Task OnInitializedAsync()
		{
			await GetProducts();

			await base.OnInitializedAsync();

		}

		async Task DeleteProduct()
		{
			await HttpClient.DeleteFromJsonAsync<ProductDTO>(HttpClient.BaseAddress + $"deleteProduct?id={ProductToDelete.ProductId}");
			ProductToDelete = new();
			await  InvokeAsync(() =>
			{

				StateHasChanged();
			});

		}

		async Task GetProdToDelete(ChangeEventArgs obj)
		{
			var chosenProduct = obj.Value;

			var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress + $"productByName?name={chosenProduct}");

			if (prod.Length > 0)
			{
				ProductToDelete = prod[0];

			}
			

		}

		async Task GetProdByName(ChangeEventArgs obj)
		{
			var chosenProduct = obj.Value;

			var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress + $"productByName?name={chosenProduct}");

			if (prod.Length > 0)
			{
				ProductToUpdate = prod[0];

			}
			
		}
	}
}
