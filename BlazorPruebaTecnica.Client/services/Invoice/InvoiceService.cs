using System.Net.Http.Json;
using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Invoice
{
    public class InvoiceService : IinvoiceService
    {
        private readonly HttpClient _httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InvoiceDTO> create(InvoiceDTO invoiceDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Invoice", invoiceDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<InvoiceDTO>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Invoice/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<InvoiceDTO>> list()
        {
            var result = await _httpClient.GetFromJsonAsync<List<InvoiceDTO>>("api/Invoice");
            return result ?? new List<InvoiceDTO>();
        }

        public async Task<InvoiceDTO> Search(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<InvoiceDTO>($"api/Invoice/{id}");
            return result;
        }

        public async Task<InvoiceDTO> update(Guid id, InvoiceDTO invoiceDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Invoice/{id}", invoiceDTO);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<InvoiceDTO>();
        }
    }
}