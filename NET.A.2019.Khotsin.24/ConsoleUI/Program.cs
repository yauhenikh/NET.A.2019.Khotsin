using System;
using System.Linq;
using BLL.Interface;
using DependencyResolver;
using Ninject;

namespace ConsoleUI
{
    internal class Program
    {
        private static readonly IKernel _Resolver;

        static Program()
        {
            _Resolver = new StandardKernel();
            _Resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService service = _Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = _Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Owner 1", "Account owner 1", AccountType.Gold, creator);
            service.OpenAccount("Owner 2", "Account owner 2", AccountType.Base, creator);
            service.OpenAccount("Owner 3", "Account owner 3", AccountType.Silver, creator);
            service.OpenAccount("Owner 4", "Account owner 4", AccountType.Base, creator);

            var accounts = service.GetAllAccounts().ToList();

            Console.WriteLine("Accounts before deposit/withdrawal");
            foreach (var item in accounts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var t in accounts)
            {
                service.DepositAccount(t, 100);
            }

            Console.WriteLine("Accounts after deposit");
            foreach (var item in accounts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var t in accounts)
            {
                service.WithdrawAccount(t, 10);
            }

            Console.WriteLine("Accounts after withdrawal");
            foreach (var item in accounts)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
