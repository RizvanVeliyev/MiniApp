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
            
            bool userExist = false;
            if(DB.users.Length > 0) 
            {
                foreach (var item in DB.users)
                {
                    if (item.Email == user.Email) userExist = true;
                }
            }
            
            if (!userExist)
            {
                int newLength = DB.users.Length + 1;
                Array.Resize(ref DB.users, newLength);
                DB.users[newLength - 1] = user;
                Console.WriteLine("Qeydiyyatdan kecdiniz!");

            }
            else Console.WriteLine("Bu emailde istifadeci var!");
           
        }

       

    }
}
