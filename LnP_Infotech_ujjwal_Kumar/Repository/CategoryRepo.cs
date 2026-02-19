using LnP_Infotech_ujjwal_Kumar.DATA;
using LnP_Infotech_ujjwal_Kumar.Models;
using Microsoft.EntityFrameworkCore;

namespace LnP_Infotech_ujjwal_Kumar.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

    

        async Task<Category> ICategoryRepo.AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }


        public async Task<bool> DeleteCategory(int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if (data == null)
                return false;

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }



        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

      

    }
}
