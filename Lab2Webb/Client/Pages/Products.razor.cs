using System.Net.Http.Json;
using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Lab2Webb.Client.Pages;

partial class Products : ComponentBase
{
	public ProductDTO CurrentProduct { get; set; } = new();

	public List<ProductDTO> ProductList { get; set; } = new();



	async Task GetProducts()
	{
		ProductList = new List<ProductDTO>();

		var prods = await HttpClient.GetFromJsonAsync<ProductDTO[]>("allProducts");

		ProductList.AddRange(prods);

	}

	async Task UpdateStockStatus(string id, ProductDTO product, bool status)
	{
		product.Status = !status;
		await HttpClient.PutAsJsonAsync($"discontinuedProduct?id={id}", product);
		Console.WriteLine("Test");

	}

	async Task ResetList()
	{
		await GetProducts();
		StateHasChanged();

	}

	async Task GetProdFromId()
	{
		ProductList = new List<ProductDTO>();

		if (CurrentProduct.ProductId == null || CurrentProduct.ProductId.Length != 24)
		{
			return;
		}
		var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>($"productById?id={CurrentProduct.ProductId}");

		if (prod.Length > 0)
		{
			ProductList.AddRange(prod);
		}
	}

	async Task GetProdFromName()
	{
		ProductList = new List<ProductDTO>();

		var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>($"productByName?name={CurrentProduct.Name}");

		if (prod.Length > 0)
		{
			ProductList.AddRange(prod);
		}
	}

	protected override async Task OnInitializedAsync()
	{
		await GetProducts();

		await base.OnInitializedAsync();

	}
}