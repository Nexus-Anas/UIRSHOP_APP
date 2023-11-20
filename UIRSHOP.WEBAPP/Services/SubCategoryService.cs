
using UIRSHOP.BL.Models.Dtos.SubCategory;

namespace UIRSHOP.WEBAPP.Services
{
	public class SubCategoryService
	{
		private readonly HttpClient _http;
		private readonly string _baseUrl;
		private readonly string _controller = "SubCategories";
		private readonly ILogger<SubCategoryService> _logger;

		public SubCategoryService(HttpClient http, IConfiguration configuration, ILogger<SubCategoryService> logger)
		{
			_http = http ?? throw new ArgumentNullException(nameof(http));
			_baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? throw new ArgumentNullException(nameof(configuration));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		public async Task<IEnumerable<SubCategoryDto>> FindAll()
		{
			try
			{
				var response = await _http.GetFromJsonAsync<IEnumerable<SubCategoryDto>>($"{_baseUrl}api/{_controller}");
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
