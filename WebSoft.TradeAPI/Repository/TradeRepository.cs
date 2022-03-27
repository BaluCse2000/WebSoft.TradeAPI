using Microsoft.Extensions.Caching.Memory;
using WebSoft.TradeAPI.Entities;
using WebSoft.TradeAPI.Helpers;
using WebSoft.TradeAPI.Interfaces;

namespace WebSoft.TradeAPI.Repository
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IMemoryCache _cache;

        public TradeRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool CreateAccount(Account account)
        {
            var accounts = GetAccounts().ToList();
            accounts.Add(account);
            _cache.Set<IEnumerable<Account>>(Constants.AccountsCacheKey,accounts);
            return true;
        }

        public decimal GetAccountBalance(int accountId)
        {
            decimal availableBalance = 0;
            var accounts = _cache.Get<IEnumerable<Account>>(Constants.AccountsCacheKey);
            var account = accounts.Where(p => p.Id == accountId).FirstOrDefault();
            if(account != null)
            {
                availableBalance = account.AvailableBalance;
            }
            return availableBalance;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _cache.Get<IEnumerable<Account>>(Constants.AccountsCacheKey);
        }

        public IEnumerable<Investment> GetInvestments(int accountId)
        {
            IEnumerable<Investment> accountInvestment = null;
            var investments =  _cache.Get<IEnumerable<Investment>>(Constants.InvestmentsCacheKey);
            if(investments.Any())
            {
                accountInvestment = investments.ToList().Where(p => p.AccountId== accountId).ToList();
            }
            return accountInvestment;
        }

        public bool InvestAmount(Investment investment)
        {
            var investments = _cache.Get<IEnumerable<Investment>>(Constants.InvestmentsCacheKey).ToList();
            investments.Add(investment);
            _cache.Set<IEnumerable<Investment>>(Constants.InvestmentsCacheKey, investments);
            return true;
        }
    }
}
