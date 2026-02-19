using LnP_Infotech_ujjwal_Kumar.Models;
using LnP_Infotech_ujjwal_Kumar.Repository;
using Microsoft.EntityFrameworkCore;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepos _repo;

        public ProductService(IProductRepos repo)
        {
            _repo = repo;
        }

       
      
        public async Task<Product> Add(Product product, int[] categoryIds)
        {
            var savedProduct = await _repo.Add(product);

            if (categoryIds != null && categoryIds.Length > 0)
            {
                foreach (var catId in categoryIds)
                {
                    var pc = new ProductCategory
                    {
                        ProductId = savedProduct.ProductId,
                        CategoryId = catId
                    };

                    await _repo.AddProductCategory(pc);
                }
            }

            return savedProduct;
        }


        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<Product?> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<bool> Update(Product product)
        {
            await _repo.Update(product);
            return true;
        }

       

        public async Task<(List<Product> Data, int TotalCount)>
        GetFilteredProducts(
            string? search,
            int? categoryId,
            int? minQty,
            decimal? maxPrice,
            int page,
            int pageSize)
        {
            var query = _repo.GetQueryable()
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category).AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x=>x.ProductName.Contains(search));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x =>
                    x.ProductCategories.Any(pc =>
                        pc.CategoryId == categoryId.Value));
            }

            if (minQty.HasValue)
            {
                query = query.Where(x =>
                    x.Quantity >= minQty.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(x =>
                    x.Price <= maxPrice.Value);
            }

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return (data, totalCount);
        }
    }
}
