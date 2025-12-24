using System.ComponentModel;

namespace Domain;
public interface ICategoryService
{
    public void AddCategory(Category category);
    public void GetCategories();
    public string? UpdateCategory(int categoryId,string categoryName);
    public string? DeleteCategory(int categoryId);
}