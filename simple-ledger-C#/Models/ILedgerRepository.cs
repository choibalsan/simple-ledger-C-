namespace simple_ledger_C_.Models
{
    public interface ILedgerRepository
    {
        void AddTransaction(string userId, AccountTransaction transaction);
        IEnumerable<AccountTransaction> GetTransactions(string userId);
        decimal GetBalance(string userId);
        void UpdateBalance(string userId, decimal amount);
    }
}
