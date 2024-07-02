using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Models
{
    public static class DB
    {
        public static User[] users;
        public static Category[] categories;
        public static Medicine[] medicines;

        static DB()
        {
            users = new User[0];
            categories = new Category[0];
            medicines = new Medicine[0];
        }
    }
}
