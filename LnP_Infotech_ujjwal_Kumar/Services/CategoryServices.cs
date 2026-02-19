using LnP_Infotech_ujjwal_Kumar.Models;
using LnP_Infotech_ujjwal_Kumar.Repository;

namespace LnP_Infotech_ujjwal_Kumar.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepo _repo;

        public CategoryServices(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _repo.AddCategory(category);
            return category;
        }

    

        public async Task<bool> DeleteCategory(int id)
        {
            return await _repo.DeleteCategory(id);
        }

        

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repo.GetAllCategories();
        }


        public async Task<Category?> GetCategoryById(int id)
        {
            return await _repo.GetCategoryById(id);
        }
    }
}
