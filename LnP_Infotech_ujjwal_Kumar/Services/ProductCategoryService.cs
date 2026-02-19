using LnP_Infotech_ujjwal_Kumar.Models;
using LnP_Infotech_ujjwal_Kumar.Repository;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    using LnP_Infotech_ujjwal_Kumar.Models;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepo _repo;

        public ProductCategoryService(IProductCategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task AddMapping(int productId, int categoryId)
        {
            var pc = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            await _repo.Add(pc);
        }

        public async Task UpdateMapping(int productId, int[] categoryIds)
        {
            // Delete old
            await _repo.RemoveByProductId(productId);

            // Insert new
            foreach (var id in categoryIds)
            {
                await _repo.Add(new ProductCategory
                {
                    ProductId = productId,
                    CategoryId = id
                });
            }
        }

        public async Task<List<ProductCategory>> GetByProductId(int productId)
        {
            return await _repo.GetByProductId(productId);
        }
    }

}
