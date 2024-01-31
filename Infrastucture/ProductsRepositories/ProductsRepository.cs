using AutoMapper;
using CatalogoDeProdutos.Infrastucture;
using CatalogoDeProdutos.Models;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Application.Contracts;
using ProductsCatalog.Application.Dtos;
using ProductsCatalog.Application.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace ProductsCatalog.Infrastucture.ProductsRepositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ProductsRepository(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
   
            await  _context.AddAsync(product);
            await _context.SaveChangesAsync();

            _mapper.Map<Product>(product);

            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int? id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id); 
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
           await _context.SaveChangesAsync();
            return product;
        }
    }
}
