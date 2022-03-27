using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebSoft.TradeAPI.Entities;
using WebSoft.TradeAPI.Interfaces;

namespace WebSoft.TradeAPI.Controllers
{
    [Route("api/[controller]")]
    public class TradeController : BaseController
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        
       [HttpGet("Accounts")]
       public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return Ok(_tradeRepository.GetAccounts());
        }

        //Req : Ability to create a new trading account with an initial deposit
        [HttpPost("CreateAccount")]
        public ActionResult<bool> CreateAccount(Account account)
        {
            return Created(new Uri("/api/Trade/CreateAccount", UriKind.Relative),_tradeRepository.CreateAccount(account));
        }

        //Req: Can invest from a single account with different currencies and amounts in several different institutions.
        [HttpPost("InvestAmount")]
        public ActionResult<bool> InvestAmount(Investment investment)
        {
            return Created(new Uri("/api/Trade/InvestAmount", UriKind.Relative), _tradeRepository.InvestAmount(investment));
        }
        //Req: Ability to retrieve current balance from a specified account
        [HttpGet("Accounts/{accountId}/GetAvailableBalance")]
        public ActionResult<decimal> GetAvailableBalance([FromRoute]int accountId)
        {
            return Ok(_tradeRepository.GetAccountBalance(accountId));
        }
        //Req: Ability to retrieve all current investments by currency, institution name or amount
        [HttpGet("Accounts/{accountId}/Investments")]
        public ActionResult<IEnumerable<Investment>> GetInvestments([FromRoute] int accountId)
        {
            return Ok(_tradeRepository.GetInvestments(accountId));
        }
    }
}
