using MiniApp.Exceptions;
using MiniApp.Models;
using MiniApp.Services;
using System.Linq.Expressions;

namespace MiniApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserService userService = new UserService();
            CategoryService categoryService = new CategoryService();
            MedicineService medicineService = new MedicineService();

            
            Console.WriteLine("Programa xos geldiniz!");
            menu1:
            Console.WriteLine("1. register ");
            Console.WriteLine("2. Login ");
            Console.WriteLine("3. show menu ");
            Console.WriteLine("4. exit ");

            while (true)
            {
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        User user = new User();
                        Console.Write("Istifadeci adini daxil edin:");
                        user.Fullname = Console.ReadLine();
                        Console.Write("Istifadeci emailini daxil edin:");
                        user.Email = Console.ReadLine();
                        Console.Write("Istifadeci parolunu daxil edin:");
                        user.Password = Console.ReadLine();
                        userService.AddUser(user); break;
                    case 2:
                        User loggedInUser = null;

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        try
                        {
                            loggedInUser = userService.Login(email, password);
                            Console.WriteLine("Login successful!\n");
                            goto menu2;
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        goto menu1;
                        break;
                    case 4:
                        return;
                        break;
                    default:
                        Console.WriteLine("Duzgun secim daxil edin!");
                        break;
                }
                
                
            }
            menu2:
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create Category");
            Console.WriteLine("2. Create Medicine");
            Console.WriteLine("3. List All Medicines");
            Console.WriteLine("4. Get Medicine By Id");
            Console.WriteLine("5. Get Medicine By Name");
            Console.WriteLine("6. Get Medicine By Category");
            Console.WriteLine("7. Remove Medicine");
            Console.WriteLine("8. Update Medicine");
            Console.WriteLine("9. Show Menu");
            Console.WriteLine("10. Exit");





            Medicine medicine2 = new Medicine();
            
             



            bool exit = false;

            while (!exit)
            {
               
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Category category = new Category();
                        Console.Write("Kateqoriya adini daxil edin:");
                        category.Name = Console.ReadLine();
                        categoryService.CreateCategory(category);
                        for(int i = 0; i < DB.categories.Length; i++)   
                        {
                            Console.WriteLine(DB.categories[i].Name);
                            Console.WriteLine(DB.categories[i].Id);

                        }

                        break;
                    case "2":
                        Medicine medicine = new Medicine();
                        Console.Write("Derman adini daxil edin:");
                        medicine.Name = Console.ReadLine();
                        Console.Write("Derman qiymetini daxil edin:");
                        medicine.Price = int.Parse(Console.ReadLine());
                        Console.Write("Derman kateqoriyasini daxil edin:");
                        medicine.CategoryId = int.Parse(Console.ReadLine());
                        medicine.CreatedDate= DateTime.Now;
                        
                        medicineService.CreateMedicine(medicine);
                        break;
                    case "3":
                        foreach(var item in medicineService.GetAllmedicines())
                        {
                            Console.WriteLine(item.Name);
                        }
                        
                        break;
                    case "4":
                        Console.Write("Gormek istediyiniz dermanin id-sini daxil edin:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine(medicineService.GetMedicineById(id));
                        break;
                    case "5":
                        medicineService.GetMedicineByName(medicine2.Name);
                        break;
                    case "6":
                        medicineService.GetMedicineByCategory(medicine2.CategoryId);
                        break;
                    case "7":
                        medicineService.RemoveMedicine(medicine2.Id);
                        break; 
                    case "8":
                        medicineService.UpdateMedicine(medicine2.Id, medicine2);
                        break;
                    case "9":
                        goto menu2;
                        break;
                    case "10":
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