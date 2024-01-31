using CatalogoDeProdutos.Models;

namespace ProductsCatalog.Application.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Get(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task Delete(Category category);
    }
}
