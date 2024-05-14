using System;
using System.Collections.Generic;

namespace ATMbank
{
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
