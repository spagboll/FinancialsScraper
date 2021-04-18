namespace FinancialsScraper.Models
{
    public class Financials : IDataModel
    {
        public PerShareData PerShareData { get; set; }
        
        public RatiosAndMargins RatiosAndMargins { get; set; }
        
        public IncomeStatement IncomeStatement { get; set; }
    }
}