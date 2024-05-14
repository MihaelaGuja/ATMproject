using System;
using System.Collections.Generic;

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
    class BankATM 
    {
        private double _balance;
        public double Balance
        {
            get { return _balance; }
            private set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
            }
        }
        public void ExtractMoney()
        {
            Console.WriteLine("Enter amount of money that you want to extract: ");

            if(!double.TryParse(Console.ReadLine(), out double extractionAmount))
            {
                Console.WriteLine("Invalid input");
            }

            Balance -= extractionAmount;
            Console.WriteLine($"You balance is: {Balance}");
        }

        public void AddMoney()
        {
            Console.WriteLine("Enter amount of money that you want to add: ");

            if(!double.TryParse (Console.ReadLine(), out double addToBalance))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Balance += addToBalance;
            Console.WriteLine($"Your balance is: {Balance}");
        }

        public void ViewBalance()
        {
            Console.WriteLine($"Balance on this acount is: {Balance}");
        }

        public void PrintOptions()
        {
            Console.WriteLine("ATM Options: ");
            Console.WriteLine();
            Console.WriteLine("1. View account balance " +
                "\n2. Add money to account balance." +
                "\n3. Extract money from account.." +
                "\n4. Change account password." +
                "\n0. Exit Menu");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Authenticate authenticate = new Authenticate();
            BankATM bankATM = new BankATM();

            bool isOpen = true;
            while (isOpen)
            {
                Console.WriteLine("Account authentication:" +
                    " \nType 1. to Register your account or " +
                      "\nType 2. to Login to your bank account " +
                      "\nType 0. to exit the program");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        authenticate.Register();
                        awaitMessage("Press key to be able to Login in to your new account");
                        break;
                    case 2:
                        Console.Clear();
                        if (authenticate.LoginToAccount())
                        {
                            Console.Clear();
                            Console.WriteLine("Login successful!");

                            bool isOpenAcount = true;
                            while (isOpenAcount)
                            {
                                bankATM.PrintOptions();
                                switch (Convert.ToInt32(Console.ReadLine()))
                                {
                                    case 1:
                                        Console.Clear();
                                        bankATM.ViewBalance();
                                        awaitMessage();  
                                        break;
                                    case 2:
                                        Console.Clear();
                                        bankATM.AddMoney();
                                        awaitMessage();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        bankATM.ExtractMoney();
                                        awaitMessage();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        authenticate.changePassword();
                                        awaitMessage("Press any key to autentificate again");
                                        isOpenAcount = false;
                                        break;
                                    case 0:
                                        Console.Clear();
                                        isOpenAcount = false; 
                                        isOpen = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid option");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorect login information");
                        }
                        break;
                    case 0:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }
        public static void awaitMessage(string message = "Press any they to continue")
        {
            Console.WriteLine($"\t{message}");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
