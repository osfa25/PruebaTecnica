using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Client
{
    public interface IClientService
    {
        Task<List<ClientDTO>> list();

        Task<ClientDTO> Search(Guid id);

        Task<ClientDTO> update(Guid id, ClientDTO clientDTO);

        Task<ClientDTO> create(ClientDTO invoiceDTO);

        Task<bool> Delete(Guid id);
    }
}
