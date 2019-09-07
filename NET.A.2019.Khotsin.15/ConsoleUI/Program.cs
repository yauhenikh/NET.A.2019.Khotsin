using System;
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

            service.OpenAccount("owner", "Account owner 1", AccountType.Gold, creator);
            service.OpenAccount("owner", "Account owner 2", AccountType.Base, creator);
            service.OpenAccount("owner", "Account owner 3", AccountType.Silver, creator);
            service.OpenAccount("owner", "Account owner 4", AccountType.Base, creator);

            var accounts = service.GetAllAccounts();

            foreach (var t in accounts)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in accounts)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
