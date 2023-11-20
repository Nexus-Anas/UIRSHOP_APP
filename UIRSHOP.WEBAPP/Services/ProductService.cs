



using UIRSHOP.BL.Models.Dtos.ProductDtos;

namespace UIRSHOP.WEBAPP.Services
{
	
		public class ProductService
		{
			private readonly HttpClient _http;
			private readonly string _baseUrl;
			private readonly string _controller = "Products";
			private readonly ILogger<ProductService> _logger;

			public ProductService(HttpClient http, IConfiguration configuration, ILogger<ProductService> logger)
			{
				_http = http ?? throw new ArgumentNullException(nameof(http));
				_baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? throw new ArgumentNullException(nameof(configuration));
				_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			}
			public async Task<IEnumerable<ProductDto>> FindAll()
			{
				try
				{
					var response = await _http.GetFromJsonAsync<IEnumerable<ProductDto>>($"{_baseUrl}api/{_controller}");
					return response;
				}
				catch (HttpRequestException ex)
				{
					_logger.LogError($"Error fetching products: {ex.Message}");
					throw; // Rethrow the exception to signal a failure to the calling code
				}
			}
        public async Task<ProductDto> Find(int id)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ProductDto>($"{_baseUrl}api/{_controller}/{id}");
             
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de la ressource : {ex.Message}");
                throw; // Vous pouvez gérer l'exception ici selon vos besoins.
            }
        }




        //public async Task<Product> Create(Product product)
        //{
        //	var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", product);
        //	response.EnsureSuccessStatusCode();
        //	return await response.Content.ReadFromJsonAsync<Product>();
        //}

        //public async Task<Product> Update(int id, Product product)
        //{
        //	var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", product);
        //	response.EnsureSuccessStatusCode();
        //	return await response.Content.ReadFromJsonAsync<Product>();
        //}

        //public async Task Delete(int id)
        //{
        //	var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        //	response.EnsureSuccessStatusCode();
        //}
    }

}
