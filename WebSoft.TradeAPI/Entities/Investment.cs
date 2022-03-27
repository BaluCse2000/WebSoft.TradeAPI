namespace WebSoft.TradeAPI.Entities
{
    public class Investment : BaseEntity
    {
        public int AccountId { get; set; }
        public int InstitutionId { get; set; }
        public string Currency { get;set; }
        public Decimal InvestmentAmount { get; set; }
    }
}
