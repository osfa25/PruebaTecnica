using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Client
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;

        public ClientService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        private async Task<string> GetAuthToken()
        {
            // Usar JavaScript Interop para leer la cookie
            var cookie = await _jsRuntime.InvokeAsync<string>("cookieHelper.getCookie", "AuthToken");

            // Si no se encuentra el token en las cookies, devolver null
            if (string.IsNullOrEmpty(cookie))
            {
                return null;
            }

            return cookie;
        }

        private async Task SetAuthHeader()
        {
            var token = await GetAuthToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<ClientDTO> create(ClientDTO client)
        {
            await SetAuthHeader(); // Establecer el encabezado de autorización antes de hacer la solicitud

            var response = await _httpClient.PostAsJsonAsync("api/Client", client);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClientDTO>();
        }

        public async Task<bool> Delete(Guid id)
        {
            await SetAuthHeader(); // Establecer el encabezado de autorización antes de hacer la solicitud

            var response = await _httpClient.DeleteAsync($"api/Client/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ClientDTO>> list()
        {
            await SetAuthHeader(); // Establecer el encabezado de autorización antes de hacer la solicitud

            var result = await _httpClient.GetFromJsonAsync<List<ClientDTO>>("api/Client");
            return result ?? new List<ClientDTO>();
        }

        public async Task<ClientDTO> Search(Guid id)
        {
            await SetAuthHeader(); // Establecer el encabezado de autorización antes de hacer la solicitud

            var result = await _httpClient.GetFromJsonAsync<ClientDTO>($"api/Client/{id}");
            return result;
        }

        public async Task<ClientDTO> update(Guid id, ClientDTO clientDTO)
        {
            await SetAuthHeader(); // Establecer el encabezado de autorización antes de hacer la solicitud

            var response = await _httpClient.PutAsJsonAsync($"api/Client/{id}", clientDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClientDTO>();
        }
    }
}
