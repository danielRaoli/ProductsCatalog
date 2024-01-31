using CatalogoDeProdutos.Models;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Application.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProduct(int? id);
        Task<ProductDto> CreateProduct(CreateProductModel createModel);
        Task<ProductDto> UpdateProduct(int id, ProductDto product);
        Task DeleteProduct(int id);
    }
}
