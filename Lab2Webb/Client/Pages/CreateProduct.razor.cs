using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using ProductDataAccess.Repositories;
using System.Net.Http.Json;
using MongoDB.Bson;

namespace Lab2Webb.Client.Pages
{
	public partial class CreateProduct :ComponentBase
	{
		public ProductDTO Product { get; set; } = new();

		public ProductDTO ProductToUpdate { get; set; } = new();

		public IProductRepository _ProductRepository { get; set; }

		public List<ProductDTO> ProductList { get; set; }

		async Task CreateNewProduct()
		{
			await HttpClient.PostAsJsonAsync(HttpClient.BaseAddress + "createProduct", Product);

			Product = new ProductDTO();

		}

		async Task UpdateProduct()
		{

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

		private string SelectedProductId
		{
			get => ProductToUpdate.ProductId.ToString();

			set => ProductToUpdate = ProductList.SingleOrDefault(p => p.ProductId == value);
		}
	}
}
