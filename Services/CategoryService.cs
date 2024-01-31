using AutoMapper;
using CatalogoDeProdutos.Models;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Categorydto> Create(CreateCategoryModel createModel)
        {
            var category = await _categoryRepository.Create(new Category { Name = createModel.Name });
            return _mapper.Map<Categorydto>(category);

        }

        public async Task Delete(int id)
        {
            var product = await _categoryRepository.Get(id);
            await _categoryRepository.Delete(product);
        }

        public async Task<IEnumerable<Categorydto>> GetAll()
        {
            return _mapper.Map<List<Categorydto>>( await _categoryRepository.GetAll());
        }

        public async Task<Categorydto> Get(int? id)
        {
            var categoryDto = _mapper.Map<Categorydto>(await _categoryRepository.Get(id));
            if(categoryDto != null) { return categoryDto; }

            return null;
        }

        public async Task<Categorydto> Update(int id, Categorydto category)
        {
            var categoryDb = await _categoryRepository.Get(id);
            if(categoryDb != null)
            {
                _mapper.Map(category, categoryDb);
                return _mapper.Map<Categorydto>(await _categoryRepository.Update(categoryDb));
            }

            return null;
        }
    }
}
