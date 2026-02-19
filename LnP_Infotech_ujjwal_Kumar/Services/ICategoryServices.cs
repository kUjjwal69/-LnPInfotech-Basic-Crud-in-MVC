using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    public interface ICategoryServices
    {
        Task<Category> AddCategory(Category category);

        Task<bool> DeleteCategory(int id);

        Task<Category?> GetCategoryById(int id);
        Task<List<Category>> GetAllCategories();
    }
}
