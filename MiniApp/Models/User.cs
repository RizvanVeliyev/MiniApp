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
                if (value.Length < 3 || value.Length > 15) Console.WriteLine("ad uzunlugu 3-15 araliginda olmalidir!");
                else _fullName = value;
            }
                 
        }
        public string Email
        {
            get => _email;
            set
            {
                string emailLast = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '@' && value.Length >= 4)
                    {
                        for (int j = i; j < value.Length; j++)
                        {
                            emailLast += value[i];
                        }
                        if(emailLast=="@gmail.com") _email= value;
                        else Console.WriteLine("email sonu @gmail.com ile bitmelidir!");
                    }
                }
                Console.WriteLine("Email duzgun daxil edilmeyib!");
            }

        }
        public string Password
        {
            get => _password;
            set
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
                            break;
                        }
                    }
                    Console.WriteLine("sifre en az 1 reqemden 1 kicik ve 1 boyuk herfden ibaret olmalidir!");
                }
                else Console.WriteLine("sifre en az 8 simvoldan ibaret olmalidir!");
            }

        }
    }
}
