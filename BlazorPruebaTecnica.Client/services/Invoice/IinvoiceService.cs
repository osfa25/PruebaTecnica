using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Invoice
{
    public interface IinvoiceService
    {
        Task<List<InvoiceDTO>> list();

        Task<InvoiceDTO> Search(Guid id);

        Task<InvoiceDTO> update(Guid id, InvoiceDTO invoiceDTO);

        Task<InvoiceDTO> create(InvoiceDTO invoiceDTO);

        Task<bool> Delete(Guid id);
    }
}
