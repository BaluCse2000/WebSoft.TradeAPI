namespace WebSoft.TradeAPI.Entities
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PrimaryCurrency { get; set; }
        public Decimal AvailableBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
