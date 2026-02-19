using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    public interface IProductCategoryService
    {
        Task AddMapping(int productId, int categoryId);

        Task UpdateMapping(int productId, int[] categoryIds);

        Task<List<ProductCategory>> GetByProductId(int productId);
    }
}
