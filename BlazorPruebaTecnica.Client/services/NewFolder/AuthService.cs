using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPruebaTecnica.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _jsRuntime;

        public AuthService(HttpClient httpClient, NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
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

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", new { Username = username, Password = password });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { Username = username, Password = password });

            if (response.IsSuccessStatusCode)
            {
                // Deserializar la respuesta en un objeto LoginResponse
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                // Verifica si la respuesta fue exitosa
                return result?.IsSuccess ?? false;
            }

            return false;
        }
        public class LoginResponse
        {
            public string Message { get; set; }
            public bool IsSuccess { get; set; }
        }


        public async Task LogoutAsync()
        {
            var response = await _httpClient.PostAsync("api/auth/logout", null);
            if (response.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/login");
            }
        }
    }
}
