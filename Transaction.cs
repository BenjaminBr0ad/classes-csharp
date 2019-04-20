using System;

namespace classes
{
    public class Transaction
    {
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Note = note;
        }

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note { get; }

    }
}