namespace ATMbank
{
    class Authenticate
    {
        private static Dictionary<string, string> _authentication { get; set; }
        public Dictionary<string,string> Authentication
        {
            get {return _authentication;}
            set 
            {
                foreach(var keyValuePair in value)
                {
                    if(keyValuePair.Value.Length > 10)
                    {
                        Console.WriteLine("Enter below 10 characters");
                    }
                }
                _authentication = value;
            }
        }


        public Authenticate()
        {
            Authentication = new Dictionary<string, string> { {"qwerty", "qwerty" } };
        }
        public bool changePassword()
        {
            Console.WriteLine("What is you username");
            string username = Console.ReadLine();

            if (!Authentication.ContainsKey(username))
            {
                Console.WriteLine("Username is incorrect");
            }

            Console.WriteLine("Enter old password: ");
            string oldPassword = Console.ReadLine();

            if(!Authentication.ContainsValue(oldPassword))
            {
                Console.WriteLine("Password is incorrect");
            }

            if (Authentication[username] == oldPassword)  
            {
                Console.WriteLine("Enter you new password: ");
                string newPassword = Console.ReadLine();

                Authentication[username] = newPassword;
                Console.WriteLine($"pasword changed! {newPassword}");
                return true;
            }
            else
            {
                Console.ReadKey();
                Console.Clear();
                return changePassword();
            }
            
        }
        public void Register()
        {
            Console.Write("Insert new username: ");
            string username = Console.ReadLine();

            if (Authentication.ContainsKey(username) )
            {
                Console.WriteLine("Username alredy exists!");
                return;
            }

            Console.WriteLine("Insert new password: ");
            string password = Console.ReadLine();

            if (Authentication.ContainsValue(password))
            {
                Console.WriteLine("password alredy exists!");
                return;
            }
            else
            {
                Authentication.Add(username, password);
                Console.WriteLine("Successful registration");
            }
            

        }
        public bool LoginToAccount()
        {
            Console.WriteLine("=== Login ===");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            if (!_authentication.ContainsKey(username))
            {
                Console.WriteLine("username incorrect or doesn't exist!");
                return false;
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();
            
            if (!_authentication.ContainsValue(password))
            {
                Console.WriteLine("password incorrect or doesn't exist!");
                return false;
            }

           return _authentication[username] == password;
            
        }
    }
}
