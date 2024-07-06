using MiniApp.Models;

namespace MiniApp.Services
{
    public class CategoryService
    {
        public void CreateCategory(Category category)
        {
            int newLength = DB.categories.Length + 1;
            Array.Resize(ref DB.categories, newLength);
            DB.categories[newLength - 1] = category;
            Console.WriteLine("kateqoriya elave olundu!");
        }
    }
}
