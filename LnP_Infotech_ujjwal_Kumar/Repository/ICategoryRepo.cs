using LnP_Infotech_ujjwal_Kumar.Models;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public interface ICategoryRepo
    {
        Task<Category> AddCategory(Category category);
        
        Task<bool> DeleteCategory(int id);

        Task<Category?> GetCategoryById(int id);
        Task<List<Category>> GetAllCategories();
    }
}
