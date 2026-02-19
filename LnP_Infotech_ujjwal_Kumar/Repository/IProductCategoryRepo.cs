using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public interface IProductCategoryRepo
    {
        Task Add(ProductCategory pc);

        Task RemoveByProductId(int productId);

        Task<List<ProductCategory>> GetByProductId(int productId);
    }
}
