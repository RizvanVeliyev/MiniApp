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
                if(category.ID== medicine.CategoryId) 
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
            Console.WriteLine("derman elave olundu!");

        }


        public Medicine[] GetAllmedicines()
        {
            return DB.medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (var medicine in DB.medicines)
            {
                if (medicine.ID == id)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("verilen id ile derman tapilmadi!");
        }

        public Medicine GetMedicineByName(string name)
        {
            foreach (var medicine in DB.medicines)
            {
                if (medicine.Name == name)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("verilen ad ile derman tapilmadi!");
        }



        public Medicine[] GetMedicineByCategory(int categoryId)
        {
            int count = 0;
            foreach (var medicine in DB.medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                throw new NotFoundException("verilen kateqoriya id-si ile derman yoxdur!");
            }

            Medicine[] medicines = new Medicine[count];
            int index = 0;
            foreach (var medicine in DB.medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    medicines[index++] = medicine;
                }
            }

            return medicines;
        }


        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].ID == id)
                {
                    DB.medicines[i] = updatedMedicine;
                    return;
                }
            }
            throw new NotFoundException("verilen id ile derman tapilmadi!");
        }



        public void RemoveMedicine(int id)
        {
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (id == DB.medicines[i].ID)
                {
                    for (int j = id; j < DB.medicines.Length-1; j++)
                    {
                        DB.medicines[j] = DB.medicines[j+1];

                    }
                    Array.Resize(ref DB.medicines,DB.medicines.Length-1);
                    Console.WriteLine($"{id} id-li derman silindi!");
                    return;
                }
                
            }
            throw new NotFoundException("bu id ile derman tapilmadi");

        }







    }


}
