namespace simple_ledger_C_.Models
{
    public interface ITransactionService
    {
        void RecordTransaction(AccountTransaction transaction, string userId);
        IEnumerable<AccountTransaction> GetTransactions(string userId);
    }
}
