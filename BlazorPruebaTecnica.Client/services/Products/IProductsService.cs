using PruebaTecnicaShared;

namespace BlazorPruebaTecnica.Client.services.Products
{
    public interface IProductsService
    {
        Task<List<ProductDTO>> list();

        Task<ProductDTO> Search(Guid id);

        Task<ProductDTO> update(Guid id, ProductDTO productDTO);

        Task<ProductDTO> create(ProductDTO productDTO);

        Task<bool> Delete(Guid id);
    }
}
