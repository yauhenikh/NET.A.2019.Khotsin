using BankAccounts.Library;
using System;

namespace BankAccounts.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount accountJohn = new BankAccount(1, "John", "Doe", 100.0m, 0, new BaseAccountType(), new DefaultBonusPointsCalculator());
            BankAccount accountJimmy = new BankAccount(2, "Jimmy", "McNulty", 0.0m, 10, new GoldAccountType(), new DefaultBonusPointsCalculator());
            BankAccount accountJane = new BankAccount(3, "Jane", "Doe", 200.0m, 15, new BaseAccountType(), new DefaultBonusPointsCalculator());
            BankAccount accountKima = new BankAccount(4, "Kima", "Greggs", 10.0m, 15, new PlatinumAccountType(), new DefaultBonusPointsCalculator());
            BankAccount accountOmar = new BankAccount(5, "Omar", "Little", 1000.0m, 20, new PlatinumAccountType(), new DefaultBonusPointsCalculator());

            Console.WriteLine("Create new bank account service\n");
            BankAccountService bankAccountService = new BankAccountService(new BinaryFileStorage("accounts.dat"));

            Console.WriteLine("Open \"Jimmy McNulty\" account\n");
            bankAccountService.OpenAccount(accountJimmy);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();

            Console.WriteLine("Open \"Jane Doe\" account\n");
            bankAccountService.OpenAccount(accountJane);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();

            Console.WriteLine("Deposit 500$ into \"Jimmy McNulty\" account:\n");
            bankAccountService.Deposit(accountJimmy, 500.0m);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();

            Console.WriteLine("Withdraw 18$ from \"Jane Doe\" account:\n");
            bankAccountService.Withdraw(accountJane, 18.0m);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();


            Console.WriteLine("Close \"Jimmy McNulty\" account:\n");
            bankAccountService.CloseAccount(accountJimmy);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();

            Console.WriteLine("Close \"Jane Doe\" account:\n");
            bankAccountService.CloseAccount(accountJane);
            Console.WriteLine("List of accounts:\n");
            bankAccountService.ShowAccounts();

            Console.ReadLine();
        }
    }
}
