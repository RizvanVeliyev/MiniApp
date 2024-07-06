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

            Console.WriteLine("============================================================");
            Console.WriteLine("Programa xos geldiniz!");
            menu1:
            Console.WriteLine("1. Qeydiyyatdan kec ");
            Console.WriteLine("2. Hesaba giris ");
            Console.WriteLine("3. Menyunu goster ");
            Console.WriteLine("4. Programi sonlandirmag ");
            Console.WriteLine("============================================================");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Secim edin: ");

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
                        userService.AddUser(user);
                        Console.WriteLine();
                        break;
                    case 2:
                        User loggedInUser = null;

                        Console.Write("Emaili daxil edin: ");
                        string email = Console.ReadLine();

                        Console.Write("Sifreni daxil edin: ");
                        string password = Console.ReadLine();
                        Console.WriteLine();
                        try
                        {
                            loggedInUser = userService.Login(email, password);
                            Console.WriteLine("Hesaba ugurla giris edildi!\n");
                            Console.WriteLine();

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
            Console.WriteLine("============================================================");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Kateqoriya yarat");
            Console.WriteLine("2. Derman yarat");
            Console.WriteLine("3. Butun dermanlari goster");
            Console.WriteLine("4. Id ile derman tap");
            Console.WriteLine("5. Ad ile derman tap");
            Console.WriteLine("6. Kateqoriya ile derman tap");
            Console.WriteLine("7. Dermani sil");
            Console.WriteLine("8. Dermani yenile");
            Console.WriteLine("9. Menyunu goster");
            Console.WriteLine("10. Hesabdan cixis");
            Console.WriteLine("============================================================");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.Write("Secim edin: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Category category = new Category();
                        Console.Write("Kateqoriya adini daxil edin:");
                        category.Name = Console.ReadLine();
                        categoryService.CreateCategory(category);
                        

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
                            Console.WriteLine($"Ad:{item.Name} Qiymet:{item.Price} Kateqoriya:{item.CategoryId} Yaranma tarixi:{item.CreatedDate}");
                        }                       
                        break;
                    case "4":
                        Console.Write("Gormek istediyiniz dermanin id-sini daxil edin:");
                        int id = int.Parse(Console.ReadLine());
                        try
                        {
                            var med = medicineService.GetMedicineById(id);
                            Console.WriteLine($"Ad:{med.Name} Qiymet:{med.Price} Kateqoriya:{med.CategoryId} Yaranma tarixi:{med.CreatedDate}");

                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }                      
                        break;
                    case "5":
                        Console.Write("Gormek istediyiniz dermanin adini-sini daxil edin:");
                        string name = Console.ReadLine();
                        try
                        {
                            var medName = medicineService.GetMedicineByName(name);
                            Console.WriteLine($"Ad:{medName.Name} Qiymet:{medName.Price} Kateqoriya:{medName.CategoryId} Yaranma tarixi:{medName.CreatedDate}");

                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }                        
                        break;
                    case "6":
                        Console.WriteLine("Kateqoriya adlari:");
                        for (int i = 0; i < DB.categories.Length; i++)
                        {
                            Console.WriteLine($"{DB.categories[i].ID}-{DB.categories[i].Name}");
                        }
                        Console.Write("Hansi kateqoriyada olan dermanlari gormek isteyirsiniz?");
                        int catId = int.Parse(Console.ReadLine());
                        try
                        {
                            foreach (var item in medicineService.GetMedicineByCategory(catId))
                            {
                                Console.WriteLine($"Ad:{item.Name} Qiymet:{item.Price} Kateqoriya:{item.CategoryId} Yaranma tarixi:{item.CreatedDate}");
                            }
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }                       
                        break;
                    case "7":
                        Console.Write("Silmek istediyiniz dermanin id-sini daxil edin:");
                        int removeId=int.Parse(Console.ReadLine());
                        try
                        {
                            medicineService.RemoveMedicine(removeId);
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break; 
                    case "8":
                        Console.Write("deyismek istediyiniz dermanin id-sini daxil edin:");
                        int medId=int.Parse(Console.ReadLine());
                        Medicine medicine2= new Medicine();
                        Console.Write("Yeni derman adini daxil edin:");
                        medicine2.Name=Console.ReadLine();
                        Console.Write("Yeni derman qiymetini daxil edin:");
                        medicine2.Price = int.Parse(Console.ReadLine());
                        Console.Write("Yeni derman kateqoriyasini daxil edin:");
                        medicine2.CategoryId = int.Parse(Console.ReadLine());
                        medicine2.CreatedDate = DateTime.Now;
                        try
                        {
                            medicineService.UpdateMedicine(medId, medicine2);
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "9":
                        goto menu2;
                    case "10":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun secim edin!");
                        break;
                }
            }
        }
    }
}