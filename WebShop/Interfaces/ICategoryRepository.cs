using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(CategoryViewModel category);
        void UpdateCategory(CategoryViewModel category);
        void DeleteCategory(int id);
        int CountCategories();
        string UploadFile(CategoryViewModel model);
        CategoryViewModel DeleteFile(Category category);
        List<SelectListItem> CategoriesForDropDownList();
    }
}
