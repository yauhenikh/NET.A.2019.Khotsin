using System;
using System.Globalization;
using System.Threading;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents bank account
    /// </summary>
    [Serializable]
    public class BankAccount
    {
        #region Fields

        private int _id;
        private string _firstName;
        private string _lastName;
        private decimal _balance;
        private int _bonusPoints;
        private IAccountType _accountType;
        private IBonusPointsCalculator _bonusPointsCalculator;

        #endregion

        #region Constructor

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="id">Given id</param>
        /// <param name="firstName">Given first name</param>
        /// <param name="lastName">Given last name</param>
        /// <param name="balance">Given balance</param>
        /// <param name="bonusPoints">Given bonus points</param>
        /// <param name="accountType">Given account type</param>
        /// <param name="bonusPointsCalculator">Given bonus points calculator</param>
        public BankAccount(int id, string firstName, string lastName, decimal balance, int bonusPoints, IAccountType accountType, IBonusPointsCalculator bonusPointsCalculator)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
            this.AccountType = accountType;
            this.BonusPointsCalculator = bonusPointsCalculator;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id of the bank account
        /// </summary>
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (!Validator.IsIdValid(value))
                {
                    throw new ArgumentException("Invalid id value");
                }
                this._id = value;
            }
        }

        /// <summary>
        /// First name of the owner of bank account
        /// </summary>
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if (!Validator.IsFirstNameValid(value))
                {
                    throw new ArgumentException("Invalid first name value");
                }
                this._firstName = value;
            }
        }

        /// <summary>
        /// Last name of the owner of bank account
        /// </summary>
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                if (!Validator.IsLastNameValid(value))
                {
                    throw new ArgumentException("Invalid last name value");
                }
                this._lastName = value;
            }
        }

        /// <summary>
        /// Balance of the bank account
        /// </summary>
        public decimal Balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                if (!Validator.IsBalanceValid(value))
                {
                    throw new ArgumentException("Invalid balance value");
                }
                this._balance = value;
            }
        }

        /// <summary>
        /// Bonus points of the bank account
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return this._bonusPoints;
            }
            set
            {
                if (!Validator.IsBonusPointsValid(value))
                {
                    throw new ArgumentException("Invalid bonus points value");
                }
                this._bonusPoints = value;
            }
        }

        /// <summary>
        /// Account type of the bank account
        /// </summary>
        public IAccountType AccountType
        {
            get
            {
                return this._accountType;
            }
            set
            {
                if (!Validator.IsAccountTypeValid(value))
                {
                    throw new ArgumentException("Invalid account type value");
                }
                this._accountType = value;
            }
        }

        /// <summary>
        /// Bonus points calculator of the bank account
        /// </summary>
        public IBonusPointsCalculator BonusPointsCalculator
        {
            get
            {
                return this._bonusPointsCalculator;
            }
            set
            {
                if (!Validator.IsBonusPointsCalculatorValid(value))
                {
                    throw new ArgumentException("Invalid bonus points calculator value");
                }
                this._bonusPointsCalculator = value;
            }
        }

        #endregion

        #region Override System.Object Methods

        /// <summary>
        /// Converts a bank account to its string representation
        /// </summary>
        /// <returns>String that represents bank account</returns>
        public override string ToString()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;

            return $"Id: {this.Id}\n" +
                   $"First name: {this.FirstName}\n" +
                   $"Last name: {this.LastName}\n" +
                   $"Balance: {this.Balance:C2}\n" +
                   $"Bonus points: {this.BonusPoints}\n" +
                   $"Account type: {this.AccountType}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current bank account
        /// </summary>
        /// <param name="obj">The object to compare with the current bank account</param>
        /// <returns>True, if the specified object is equal to the current bank account</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            BankAccount account = (BankAccount)obj;

            return this.Id == account.Id;
        }

        /// <summary>
        /// Gets a hash code for the current book
        /// </summary>
        /// <returns>A hash code for the current book</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() + FirstName.GetHashCode() + LastName.GetHashCode() +
                   Balance.GetHashCode() + BonusPoints.GetHashCode() + AccountType.GetHashCode() +
                   BonusPointsCalculator.GetHashCode();
        }

        #endregion

        #region Overload Equality Operators

        /// <summary>
        /// Checks if two bank accounts are equal
        /// </summary>
        /// <param name="obj1">First bank account</param>
        /// <param name="obj2">Second bank account</param>
        /// <returns>True if bank accounts are equal</returns>
        public static bool operator ==(BankAccount obj1, BankAccount obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Checks if two bank accounts are not equal
        /// </summary>
        /// <param name="obj1">First bank account</param>
        /// <param name="obj2">Second bank account</param>
        /// <returns>True if bank accounts are not equal</returns>
        public static bool operator !=(BankAccount obj1, BankAccount obj2)
        {
            return !obj1.Equals(obj2);
        }

        #endregion

        #region Public Methods

        public void Deposit(decimal deposit)
        {
            if (deposit < 0)
            {
                throw new ArgumentException("Impossible to deposite negative amount");
            }

            this.Balance += deposit;
            this.BonusPoints += this.BonusPointsCalculator.CalculateBonusPoints(this.AccountType, true);
        }

        public void Withdraw(decimal withdrawal)
        {
            if (withdrawal < 0)
            {
                throw new ArgumentException("Impossible to withdraw negative amount");
            }

            if (this.Balance < withdrawal)
            {
                throw new ArgumentException("Balance is less than withdrawal");
            }

            this.Balance -= withdrawal;

            int newBonusPoints = this.BonusPointsCalculator.CalculateBonusPoints(this.AccountType, true);
            if (this.BonusPoints < newBonusPoints)
            {
                this.BonusPoints = 0;
            }
            else
            {
                this.BonusPoints -= newBonusPoints;
            }
        }

        #endregion
    }
}
