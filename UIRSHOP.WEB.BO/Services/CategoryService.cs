using UIRSHOP.BL.Models.Dtos.CategoryDtos;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.WEB.BO.Services;

public class CategoryService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Categories";

    public CategoryService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }




    public async Task<CategoryDto> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<CategoryDto>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<CategoryDto>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<CategoryDto>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<CategoryDto> Create(CategoryDto entity)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CategoryDto>();
    }

    public async Task<CategoryDto> Update(int id, CategoryDto entity)
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
