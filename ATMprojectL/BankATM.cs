namespace ATMbank
{
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
}
