using LnP_Infotech_ujjwal_Kumar.DATA;
using LnP_Infotech_ujjwal_Kumar.Models;
using Microsoft.EntityFrameworkCore;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public class ProductRepo : IProductRepos
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<Product> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);

            if (data == null)
                return false;

            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }

        

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

     

        public async Task<Product?> Get(int id)
        {
            return await _context.Products
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.ProductId == id);
        }

        // ============ GET ALL ============

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .ToListAsync();
        }

       

        public IQueryable<Product> GetQueryable()
        {
            return _context.Products.AsQueryable();
        }


        public async Task AddProductCategory(ProductCategory pc)
        {
            await _context.ProductCategories.AddAsync(pc);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductCategories(int productId)
        {
            var data = _context.ProductCategories
                .Where(x => x.ProductId == productId);

            _context.ProductCategories.RemoveRange(data);
            await _context.SaveChangesAsync();
        }
}
}
