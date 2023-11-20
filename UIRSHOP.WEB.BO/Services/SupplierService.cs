using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.WEB.BO.Services;

public class SupplierService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Suppliers";

    public SupplierService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }




    public async Task<SupplierDto> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<SupplierDto>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<SupplierDto>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<SupplierDto>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<SupplierDto> Create(SupplierDto entity)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", entity);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SupplierDto>();
    }

    public async Task<SupplierDto> Update(int id, SupplierDto entity)
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
