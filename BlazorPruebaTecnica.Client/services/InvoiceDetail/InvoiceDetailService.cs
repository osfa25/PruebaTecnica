using System.Net.Http.Json;
using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.InvoiceDetail
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "api/InvoiceDetail"; // Ruta base del controlador

        public InvoiceDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<InvoiceDetailDTO>> list()
        {
            return await _httpClient.GetFromJsonAsync<List<InvoiceDetailDTO>>(ApiUrl) ?? new List<InvoiceDetailDTO>();
        }

        public async Task<InvoiceDetailDTO> Search(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<InvoiceDetailDTO>($"{ApiUrl}/{id}");
        }

        public async Task<InvoiceDetailDTO> create(InvoiceDetailDTO invoiceDetailDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, invoiceDetailDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InvoiceDetailDTO>();
            }
            throw new Exception("Error al crear el detalle de factura.");
        }

        public async Task<InvoiceDetailDTO> update(Guid id, InvoiceDetailDTO invoiceDetailDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", invoiceDetailDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InvoiceDetailDTO>();
            }
            throw new Exception("Error al actualizar el detalle de factura.");
        }

        public async Task<bool> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
