using System.Collections.Concurrent;

namespace simple_ledger_C_.Models
{
    public interface ITransactionService
    {
        void RecordTransaction(AccountTransaction transaction, string userId);
        IEnumerable<AccountTransaction> GetTransactions(string userId);
    }

    public class TransactionService : ITransactionService
    {
        private readonly ConcurrentDictionary<string, List<AccountTransaction>> _userTransactions = new();

        public void RecordTransaction(AccountTransaction transaction, string userId)
        {
            var list = _userTransactions.GetOrAdd(userId, _ => new List<AccountTransaction>());

            // Lock on the user's transaction list only
            lock (list)
            {
                list.Add(transaction);
            }
        }

        public IEnumerable<AccountTransaction> GetTransactions(string userId)
        {
            if (_userTransactions.TryGetValue(userId, out var list))
            {
                lock (list)
                {
                    // Return a snapshot
                    return list.ToList();
                }
            }
            return Enumerable.Empty<AccountTransaction>();
        }
    }
}
