using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {
        // Constructor 
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance.");
        }

        // Public properties -- available to all members of BankAccount.
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        // Private property -- only available for use within the class definition (being used in constructor in this example.).
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();

        // Public methods -- available for use by all members of BankAccount.
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deposited must be positive.");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount withdrawn must be positive.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Note}");
            }
            
            return report.ToString();
        }
    }
}