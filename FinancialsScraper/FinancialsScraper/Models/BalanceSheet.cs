namespace FinancialsScraper.Models
{
    public class BalanceSheet
    {
        public string CashAndShortTermInvestment  { get; set; }

        public string TotalDebt { get; set; }

        public string TotalLiabilities { get; set; }

        public string TotalShareholdersEquity { get; set; }

        public string BookValuePerShare { get; set; }
    }
}