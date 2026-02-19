using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public interface IProductRepos
    {
        Task<Product> Add(Product product);

        Task<bool> Delete(int id);

        Task Update(Product product);

        Task<Product?> Get(int id);

        Task<List<Product>> GetAll();

        IQueryable<Product> GetQueryable();

        Task AddProductCategory(ProductCategory pc);

        Task RemoveProductCategories(int productId);
      
    }
}
