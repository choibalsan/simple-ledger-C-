using System.Collections.Concurrent;

namespace simple_ledger_C_.Models
{
    public interface ILedgerRepository
    {
        void RecordTransaction(decimal amount, string userId);
        decimal GetBalance(string userId);
        IEnumerable<AccountTransaction> GetTransactions(string userId);
    }

    public class LedgerRepository : ILedgerRepository
    {
        private readonly ITransactionService _transactionService;
        private readonly IBalanceService _balanceService;

        public LedgerRepository(ITransactionService transactionService, IBalanceService balanceService)
        {
            _transactionService = transactionService;
            _balanceService = balanceService;
        }

        public void RecordTransaction(decimal amount, string userId)
        {
            var transaction = new AccountTransaction(amount);
            _transactionService.RecordTransaction(transaction, userId);
            _balanceService.UpdateBalance(userId, transaction.Apply());
        }

        public decimal GetBalance(string userId) => _balanceService.GetBalance(userId);

        public IEnumerable<AccountTransaction> GetTransactions(string userId) =>
            _transactionService.GetTransactions(userId);
    }
}
