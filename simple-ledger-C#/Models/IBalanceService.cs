using System.Collections.Concurrent;

namespace simple_ledger_C_.Models
{
    public interface IBalanceService
    {
        decimal GetBalance(string userId);
        void UpdateBalance(string userId, decimal amount);
    }

    public class BalanceService : IBalanceService
    {
        private readonly ConcurrentDictionary<string, decimal> _balances = new();

        public decimal GetBalance(string userId)
        {
            return _balances.GetValueOrDefault(userId, 0m);
        }

        public void UpdateBalance(string userId, decimal amount)
        {
            _balances.AddOrUpdate(userId, amount, (_, prev) => prev + amount);
        }
    }
}
