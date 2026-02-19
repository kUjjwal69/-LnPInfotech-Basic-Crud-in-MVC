using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    public interface IProductServices
    {
        Task<List<Product>> GetAll();
        Task<Product?> Get(int id);
        Task<Product> Add(Product product, int[] categoryIds);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);


        Task<(List<Product> Data, int TotalCount)>
        GetFilteredProducts(
            string? search,
            int? categoryId,
            int? minQty,
            decimal? maxPrice,
            int page,
            int pageSize
        );
      

    }
}
