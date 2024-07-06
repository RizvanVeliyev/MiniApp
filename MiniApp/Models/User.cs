namespace MiniApp.Models
{
    public class User : BaseEntity
    {
        private string _fullName;
        private string _email;
        private string _password;
        public string Fullname 
        {
            get => _fullName;
            set
            {
                while (value.Length < 3 || value.Length > 15)
                {
                    Console.WriteLine("ad uzunlugu 3-15 araliginda olmalidir!");
                    Console.Write("Istifadeci adini yeniden daxil edin:");
                    value = Console.ReadLine();
                }
                if(value.Length>=3 && value.Length<=15) _fullName= value;
            }
                 
        }
        public string Email
        {
            get => _email;
            set
            {

                while (true)
                {
                    string emailLast = "";
                    bool isCorrect = false;
                    for (int i = 0; i < value.Length; i++)
                    {

                        if (value[i] == '@')
                        {
                            isCorrect = true;
                            for (int j = i; j < value.Length; j++)
                            {
                                emailLast += value[j];
                            }
                            if (emailLast == "@gmail.com")
                            {
                                _email = value;
                                return;

                            }
                            else
                            {
                                Console.WriteLine("email sonu @gmail.com ile bitmelidir!");
                                Console.Write("Emaili yeniden daxil edin:");
                                value = Console.ReadLine();
                            }
                        }
                        

                    }
                    if (!isCorrect)
                    {
                        Console.WriteLine("email icerisinde @ simvolundan istofade olunmalidir!");
                        Console.Write("Emaili yeniden daxil edin:");
                        value = Console.ReadLine();
                    }

                }
            }

        }
        public string Password
        {
            get => _password;
            set
            {
                while (true)
                {
                    bool isDigit = false;
                    bool isUpper = false;
                    bool isLower = false;
                    if (value.Length >= 8)
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (char.IsDigit(value[i])) isDigit = true;
                            else if (char.IsUpper(value[i])) isUpper = true;
                            else if (char.IsLower(value[i])) isLower = true;
                            if (isDigit && isLower && isUpper)
                            {
                                _password = value;
                                return;
                            }
                        }
                        Console.WriteLine("sifre en az 1 reqemden 1 kicik ve 1 boyuk herfden ibaret olmalidir! Yeniden daxil edin:");
                        value = Console.ReadLine();
                    }
                    else 
                    {
                        Console.WriteLine("sifre en az 8 simvoldan ibaret olmalidir! Yeniden daxil edin:");
                        value=Console.ReadLine();
                    }

                }
                
            }

        }
    }
}
