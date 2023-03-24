using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

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
			await HttpClient.PostAsJsonAsync("createProduct", Product);

			Product = new ProductDTO();
			await GetProducts();

			StateHasChanged();

		}

		async Task UpdateProduct()
		{
			await HttpClient.PutAsJsonAsync($"updateProduct?id={ProductToUpdate.ProductId}", ProductToUpdate);
			
			ProductToUpdate = new ProductDTO();
			await GetProducts();

			StateHasChanged();
		}
		
		async Task GetProducts()
		{
			ProductList = new List<ProductDTO>();

			var prods = await HttpClient.GetFromJsonAsync<ProductDTO[]>("allProducts");

			ProductList.AddRange(prods);


		}
		protected override async Task OnInitializedAsync()
		{
			await GetProducts();

			await base.OnInitializedAsync();

		}

		async Task DeleteProduct()
		{ 
			var response= await HttpClient.DeleteAsync($"deleteProduct?id={ProductToDelete.ProductId}");
			if (response.IsSuccessStatusCode)
			{
				ProductToDelete = new ProductDTO();
				await GetProducts();
				StateHasChanged();
			}

		}

		async Task GetProdToDelete(ChangeEventArgs obj)
		{

			var chosenProduct = obj.Value;

			var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>($"productByName?name={chosenProduct}");

			if (prod.Length > 0)
			{
				ProductToDelete = prod[0];

			}
			await GetProducts();
			StateHasChanged();


		}

		async Task GetProdByName(ChangeEventArgs obj)
		{
			//if (obj.Value == ProductToDelete.Name)
			//{
			//	return;
			//}
			var chosenProduct = obj.Value;

			var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>($"productByName?name={chosenProduct}");

			if (prod.Length > 0)
			{
				ProductToUpdate = prod[0];

			}
			
		}
	}
}
