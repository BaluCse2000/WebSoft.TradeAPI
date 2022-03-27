using WebSoft.TradeAPI.Entities;
using WebSoft.TradeAPI.Helpers;

namespace WebSoft.TradeAPI.Data
{
    public class InMemoryDb
    {
        private readonly IConfiguration _configuration;

        public List<Account> Accounts { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Investment> Investments { get; set; }

        public InMemoryDb(IConfiguration configuration)
        {
            _configuration = configuration;

            PopulateInstitutions();
            PopulateAccounts();
           PopulateInvestments();
        }

        private void PopulateInvestments()
        {
            Investments = JsonFileReader.Read<IEnumerable<Investment>>(_configuration.GetSection("JsonFilePath:Investments").Value).ToList();
        }

        private void PopulateAccounts()
        {
            Accounts = JsonFileReader.Read<IEnumerable<Account>>(_configuration.GetSection("JsonFilePath:Accounts").Value).ToList();
        }

        private void PopulateInstitutions()
        {
            Institutions = JsonFileReader.Read<IEnumerable<Institution>>(_configuration.GetSection("JsonFilePath:Institutions").Value).ToList();
        }
    }
}
