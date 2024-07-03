using MiniApp.Exceptions;
using MiniApp.Models;
using MiniApp.Services;

namespace MiniApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserService userService = new UserService();
            CategoryService categoryService = new CategoryService();
            MedicineService medicineService = new MedicineService();

            User firstlUser = new User { Fullname = "Rizvan Veliyev", Email = "veliyev@gmail.com", Password = "salam123" };
            userService.AddUser(firstlUser);

            Category category = new Category();
            category.Name = "Cat1";

            Medicine medicine = new Medicine();
            medicine.Name= "Test";
            medicine.Price = 13;
            medicine.CategoryId = 1;
            medicine.UserId = 1;
            medicine.CreatedDate = DateTime.Now;


            Medicine medicine2 = new Medicine();
            medicine2.Name = "Test1";
            medicine2.Price = 15;
            medicine2.CategoryId = 2;
            medicine2.UserId = 2;
            medicine2.CreatedDate = DateTime.Now;

            User loggedInUser = null;

            while (loggedInUser == null)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                try
                {
                    loggedInUser = userService.Login(email, password);
                    Console.WriteLine("Login successful!\n");
                }
                catch (NotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
             



            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Category");
                Console.WriteLine("2. Create Medicine");
                Console.WriteLine("3. List All Medicines");
                Console.WriteLine("4. Get Medicine By Id");
                Console.WriteLine("5. Get Medicine By Name");
                Console.WriteLine("6. Get Medicine By Category");
                Console.WriteLine("7. Remove Medicine");
                Console.WriteLine("8. Update Medicine");
                Console.WriteLine("9. Exit");

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        categoryService.CreateCategory(category);
                        for(int i = 0; i < DB.categories.Length; i++)
                        {
                            Console.WriteLine(DB.categories[i].Name);
                        }
                        
                        break;
                    case "2":
                        medicineService.CreateMedicine(medicine);
                        break;
                    case "3":
                        medicineService.GetAllmedicines();
                        break;
                    case "4":
                        medicineService.GetMedicineById(medicine.Id);
                        break;
                    case "5":
                        medicineService.GetMedicineByName(medicine.Name);
                        break;
                    case "6":
                        medicineService.GetMedicineByCategory(medicine.CategoryId);
                        break;
                    case "7":
                        medicineService.RemoveMedicine(medicine.Id);
                        break;
                    case "8":
                        medicineService.UpdateMedicine(medicine.Id, medicine2);
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}