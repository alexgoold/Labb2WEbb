using System.Net.Http.Json;
using Lab2Webb.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using ProductDataAccess.Repositories;

namespace Lab2Webb.Client.Pages;

partial class Products : ComponentBase
{
	public ProductDTO CurrentProduct { get; set; }

	public List<ProductDTO> ProductList { get; set; }

	public IProductRepository _ProductRepository { get; set; }


	async Task GetProducts()
	{
		ProductList = new List<ProductDTO>();

		var prods = await HttpClient.GetFromJsonAsync<ProductDTO[]>(HttpClient.BaseAddress+"allProducts");

		ProductList.AddRange(prods);

		
	}

	protected override async Task OnInitializedAsync()
	{
		await GetProducts();

		await base.OnInitializedAsync();

	}
}