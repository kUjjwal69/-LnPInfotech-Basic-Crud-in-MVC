using LnP_Infotech_ujjwal_Kumar.DATA;
using LnP_Infotech_ujjwal_Kumar.Models;
using Microsoft.EntityFrameworkCore;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public class ProductCategoryRepo : IProductCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ProductCategory pc)
        {
            await _context.ProductCategories.AddAsync(pc);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByProductId(int productId)
        {
            var data = _context.ProductCategories
                              .Where(x => x.ProductId == productId);

            _context.ProductCategories.RemoveRange(data);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductCategory>> GetByProductId(int productId)
        {
            return await _context.ProductCategories
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
    }
}
