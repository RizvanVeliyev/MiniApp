using MiniApp.Exceptions;
using MiniApp.Models;

namespace MiniApp.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            bool categoryExist = false;
            foreach(var category in DB.categories)
            {
                if(category.Id== medicine.CategoryId) 
                {
                    categoryExist = true;
                    break;
                }
            }
            if(!categoryExist)
            {
                throw new NotFoundException("verilen id ile kateqoriya tapilmadi");
            }

            int newLength = DB.medicines.Length + 1;
            Array.Resize(ref DB.medicines, newLength);
            DB.medicines[newLength-1] = medicine;

        }


        public Medicine[] GetAllmedicines()
        {
            return DB.medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (var medicine in DB.medicines)
            {
                if (medicine.Id == id)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("verilen id ile derman tapilmadi!");
        }











    }


}
