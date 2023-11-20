using UIRSHOP.BL.Models.Dtos.SubCategory;

namespace UIRSHOP.WEB.BO.Services;

public class SubCategoryService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Categories";

    public SubCategoryService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }




    public async Task<SubCategoryDto> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<SubCategoryDto>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<SubCategoryDto>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<SubCategoryDto>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<SubCategoryDto> Create(SubCategoryDto entity)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SubCategoryDto>();
    }

    public async Task<SubCategoryDto> Update(int id, SubCategoryDto entity)
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
