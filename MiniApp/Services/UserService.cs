using MiniApp.Exceptions;
using MiniApp.Models;

namespace MiniApp.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            foreach (var user in DB.users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            throw new NotFoundException("sifre ve ya email duzgun daxil edilmeyib!");
        }

        public void AddUser(User user)
        {
            int newLength = DB.users.Length + 1;
            Array.Resize(ref DB.users, newLength);
            DB.users[newLength - 1] = user;
        }

        public void CreateCategory(Category category)
        {
            int newLength = DB.categories.Length + 1;
            Array.Resize(ref DB.categories, newLength);
            DB.categories[newLength - 1] = category;
        }

    }
}
