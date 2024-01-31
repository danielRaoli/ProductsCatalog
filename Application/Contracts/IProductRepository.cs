using CatalogoDeProdutos.Models;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Application.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int? id);
        Task<Product> CreateProduct(Product productDto);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);



    }
}
