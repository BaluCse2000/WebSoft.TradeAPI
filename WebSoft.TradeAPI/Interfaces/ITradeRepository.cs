using WebSoft.TradeAPI.Entities;

namespace WebSoft.TradeAPI.Interfaces
{
    public interface ITradeRepository
    {
        IEnumerable<Account> GetAccounts();
        decimal GetAccountBalance(int accountId);
        bool CreateAccount(Account account);
        bool InvestAmount(Investment investment);
        IEnumerable<Investment> GetInvestments(int accountId);
    }
}
