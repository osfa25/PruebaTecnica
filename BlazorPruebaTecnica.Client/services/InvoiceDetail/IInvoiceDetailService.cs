using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.InvoiceDetail
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetailDTO>> list();

        Task<InvoiceDetailDTO> Search(Guid id);

        Task<InvoiceDetailDTO> update(Guid id, InvoiceDetailDTO invoiceDetailDTO);

        Task<InvoiceDetailDTO> create(InvoiceDetailDTO invoiceDetailDTO);

        Task<bool> Delete(Guid id);
    }
}
