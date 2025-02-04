using System.Net.Http.Json;
using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "api/Products";

        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>> list()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDTO>>(ApiUrl) ?? new List<ProductDTO>();
        }

        public async Task<ProductDTO> Search(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDTO>($"{ApiUrl}/{id}");
        }

        public async Task<ProductDTO> create(ProductDTO productDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, productDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductDTO>();
            }
            throw new Exception("Error al crear el producto.");
        }

        public async Task<ProductDTO> update(Guid id, ProductDTO productDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", productDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductDTO>();
            }
            throw new Exception("Error al actualizar el producto.");
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
