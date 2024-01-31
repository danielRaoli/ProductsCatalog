using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categorydto>> GetAll();
        Task<Categorydto> Get(int? id);
        Task<Categorydto> Create(CreateCategoryModel createModel);
        Task<Categorydto> Update(int id, Categorydto category);
        Task Delete(int id);
    }
}
