using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Ben", 1000);
            System.Console.WriteLine($"Account number {account.Number} was opened by {account.Owner} with an initial balance of {account.Balance}.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent");
            System.Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Roommate paid for half of utilities.");
            System.Console.WriteLine(account.Balance);

            try
            {
                var invalidAccount = new BankAccount("Invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.ToString());
            }

            System.Console.WriteLine(account.GetAccountHistory());

        }
    }
}
