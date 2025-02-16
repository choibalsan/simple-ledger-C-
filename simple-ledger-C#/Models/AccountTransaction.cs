namespace simple_ledger_C_.Models
{
    public class AccountTransaction
    {
        public Guid Id { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public AccountTransaction(decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Date = DateTime.UtcNow;
        }

        /// <summary>
        /// Returns the effect of this transaction on the user's balance.
        /// e.g. +100 for deposit, -50 for withdrawal
        /// </summary>
        public decimal Apply() => Amount;
    }
}
