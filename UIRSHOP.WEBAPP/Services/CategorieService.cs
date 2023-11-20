using UIRSHOP.BL.Models.Dtos.CategoryDtos;


namespace UIRSHOP.WEBAPP.Services
{
	public class CategorieService
	{
		private readonly HttpClient _http;
		private readonly string _baseUrl;
		private readonly string _controller = "Categories";
		private readonly ILogger<ProductService> _logger;

		public CategorieService(HttpClient http, IConfiguration configuration, ILogger<ProductService> logger)
		{
			_http = http ?? throw new ArgumentNullException(nameof(http));
			_baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? throw new ArgumentNullException(nameof(configuration));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		public async Task<IEnumerable<CategoryDto>> FindAll()
		{
			try
			{
				var response = await _http.GetFromJsonAsync<IEnumerable<CategoryDto>>($"{_baseUrl}api/{_controller}");
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
