using BLL;
using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;
using DAL.Interface;
using System.Net;
using MVCApp.ViewModels;

namespace MVCApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;
        private readonly IAccountNumberCreateService _creator;

        public AccountsController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.ConfigurateResolver();
            _service = ninjectKernel.Get<IAccountService>();
            _creator = ninjectKernel.Get<IAccountNumberCreateService>();
        }
        
        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = _service.GetAllAccounts().ToList();

            return View(accounts);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            return View(BankAccountMapper.BankAccToDTO(bankAccount));
        }

        // GET: Accounts/Deposit/5
        public ActionResult Deposit(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            return View(bankAccount);
        }

        // POST: Accounts/Deposit/5
        [HttpPost]
        public ActionResult Deposit(int id, decimal amount)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            int oldBonusPoints = bankAccount.BonusPoints;

            _service.DepositAccount(bankAccount, amount);

            TempData["Message"] = $"{bankAccount.FirstName} {bankAccount.LastName}, {amount} was deposited on your account with number {id}," +
                $" you earned {bankAccount.BonusPoints - oldBonusPoints} bonus points";

            return Redirect($"/Accounts/Details/{id}");
        }

        // GET: Accounts/Withdraw/5
        public ActionResult Withdraw(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            return View(bankAccount);
        }

        // POST: Accounts/Withdraw/5
        [HttpPost]
        public ActionResult Withdraw(int id, decimal amount)
        {
            BankAccount bankAccount = _service.GetAccountById(id);
            int oldBonusPoints = bankAccount.BonusPoints;

            if (amount > bankAccount.Balance)
            {
                TempData["Message"] = $"Impossible to withdraw {amount}, balance is only {bankAccount.Balance}";
            }
            else
            {
                _service.WithdrawAccount(bankAccount, amount);

                TempData["Message"] = $"{bankAccount.FirstName} {bankAccount.LastName}, {amount} was withrawn from your account with number {id}," +
                    $" now you have {oldBonusPoints - bankAccount.BonusPoints} bonus points less";
            }

            return Redirect($"/Accounts/Details/{id}");
        }

        // GET: Accounts/Transfer/5
        public ActionResult Transfer(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            return View(bankAccount);
        }

        // POST: Accounts/Transfer/5
        [HttpPost]
        public ActionResult Transfer(int id, int receiverId, decimal amount)
        {
            BankAccount senderAccount = _service.GetAccountById(id);
            int oldBonusPointsSender = senderAccount.BonusPoints;

            BankAccount receiverAccount = _service.GetAccountById(receiverId);

            if (receiverAccount == null)
            {
                TempData["Message"] = $"Impossible to transfer, no account with number {receiverId}";
            }
            else if (amount > senderAccount.Balance)
            {
                TempData["Message"] = $"Impossible to transfer {amount} to account {receiverId} with owner {receiverAccount.FirstName} {receiverAccount.LastName}," +
                    $" your balance is only {senderAccount.Balance}";
            }
            else
            {
                _service.WithdrawAccount(senderAccount, amount);

                int oldBonusPointsReceiver = receiverAccount.BonusPoints;

                _service.DepositAccount(receiverAccount, amount);

                if (senderAccount.FirstName == receiverAccount.FirstName && senderAccount.LastName == receiverAccount.LastName)
                {
                    TempData["Message"] = $"{amount} transfered from your account {id} ({oldBonusPointsSender - senderAccount.BonusPoints} bonus points less)" +
                        $" to your account {receiverId} ({receiverAccount.BonusPoints - oldBonusPointsReceiver} bonus points more)";
                }
                else
                {
                    TempData["Message"] = $"{amount} transfered from your account {id}, now you have {oldBonusPointsSender - senderAccount.BonusPoints} bonus points less," +
                        $" {receiverAccount.FirstName} {receiverAccount.LastName} has {receiverAccount.BonusPoints - oldBonusPointsReceiver} bonus points more on" +
                        $" account {receiverId}";
                }
            }

            return Redirect($"/Accounts/Details/{id}");
        }

        // GET: Accounts/Open
        public ActionResult Open()
        {
            return View();
        }

        // POST: Accounts/Open
        [HttpPost]
        public ActionResult Open(BankAccountViewModel bankAccount)
        {
            if (ModelState.IsValid)
            {
                _service.OpenAccount(bankAccount.FirstName, bankAccount.LastName, bankAccount.AccountType, _creator);
                return Redirect($"/Accounts/Index");
            }

            return View();
        }

        // GET: Accounts/Close/5
        public ActionResult Close(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            return View(BankAccountMapper.BankAccToDTO(bankAccount));
        }

        // POST: Accounts/Close/5
        [HttpPost, ActionName("Close")]
        public ActionResult CloseConsfirmed(int id)
        {
            BankAccount bankAccount = _service.GetAccountById(id);

            if (bankAccount != null)
            {
                _service.CloseAcount(bankAccount);
            }

            return Redirect($"/Accounts/Index");
        }
    }
}