using BLL.Interface;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.ViewModels
{
    public class BankAccountViewModel
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        public string LastName { get; set; }

        [Required]
        public AccountType AccountType { get; set; }
    }
}