namespace simple_ledger_C_.Models
{
    public abstract class AccountTransaction
    {
        public Guid Id { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        protected AccountTransaction(decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Date = DateTime.UtcNow;
        }

        public abstract decimal Apply();
    }
}
