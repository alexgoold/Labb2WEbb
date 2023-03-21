using System.Net.Http.Json;
using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Client.Pages;

partial class Products : ComponentBase
{
	public ProductDTO CurrentProduct { get; set; } = new();

	public List<ProductDTO> ProductList { get; set; } = new();

	public IProductRepository _ProductRepository { get; set; }
	public Virtualize<ProductDTO> ProductContainer { get; set; } = new();


	async Task GetProducts()
	{
		ProductList = new List<ProductDTO>();

		var prods = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress+"allProducts");

		ProductList.AddRange(prods);

	}

	async Task ResetList()
	{
		await GetProducts();
		await ProductContainer.RefreshDataAsync();
		StateHasChanged();

	}

	async Task GetProdFromId()
	{
		ProductList = new List<ProductDTO>();

		var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress + $"productById?id={CurrentProduct.ProductId}");


		ProductList.AddRange(prod);
	}

	async Task GetProdFromName()
	{
		ProductList = new List<ProductDTO>();

		var prod = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress + $"productByName?name={CurrentProduct.Name}");


		ProductList.AddRange(prod);
	}

	protected override async Task OnInitializedAsync()
	{
		await GetProducts();

		await base.OnInitializedAsync();

	}
}