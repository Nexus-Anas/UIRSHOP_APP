using UIRSHOP.BL.Models.Dtos.SubCategory;
using UIRSHOP.BL.Models.Dtos.SupplierDtos;

namespace UIRSHOP.WEBAPP.Services
{
  
    public class SupplierService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;
        private readonly string _controller = "Suppliers";
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(HttpClient http, IConfiguration configuration, ILogger<SupplierService> logger)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<IEnumerable<SupplierDto>> FindAll()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<IEnumerable<SupplierDto>>($"{_baseUrl}api/{_controller}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error fetching products: {ex.Message}");
                throw; // Rethrow the exception to signal a failure to the calling code
            }
        }
    }
}
