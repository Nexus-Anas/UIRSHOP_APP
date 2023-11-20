using UIRSHOP.BL.Models.Dtos.ProductDtos;

namespace UIRSHOP.WEB.BO.Services;

public class ProductService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Products";

    public ProductService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }




    public async Task<ProductDto> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<ProductDto>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<ProductDto>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<ProductDto>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<ProductDto> Create(ProductDto entity)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProductDto>();
    }

    public async Task<ProductDto> Update(int id, ProductDto entity)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", entity);
        response.EnsureSuccessStatusCode();
        return entity;
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
