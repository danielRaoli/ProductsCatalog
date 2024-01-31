using CatalogoDeProdutos.Infrastucture;
using CatalogoDeProdutos.Models;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.Application.Contracts;

namespace ProductsCatalog.Infrastucture.ProductsRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiContext _context;

        public CategoryRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            var result = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> Get(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);


        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            var result = _context.Update(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
