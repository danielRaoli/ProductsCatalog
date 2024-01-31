using AutoMapper;
using CatalogoDeProdutos.Models;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;

namespace ProductsCatalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProduct(CreateProductModel createModel)
        {
            Product product = new Product {Name = createModel.Name, Price = createModel.Price, CategoryId = createModel.CategoryId };

            var productCreate = await _repository.CreateProduct(product);

            return _mapper.Map<ProductDto>(productCreate);           
            
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _repository.GetProduct(id);
            if(product != null)
            {
                await _repository.DeleteProduct(product);
            }
            
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return _mapper.Map<List<ProductDto>>(await _repository.GetAllProducts());
        }

        public async Task<ProductDto> GetProduct(int? id)
        {
            return _mapper.Map<ProductDto>(await _repository.GetProduct(id));
        }

        public async Task<ProductDto> UpdateProduct(int id, ProductDto product)
        {
            var productDb = await _repository.GetProduct(id);
            if(productDb != null)
            {
                _mapper.Map(product, productDb);
                return  _mapper.Map<ProductDto>(await _repository.UpdateProduct(productDb));
            }

            return null;
        }
    }
}
