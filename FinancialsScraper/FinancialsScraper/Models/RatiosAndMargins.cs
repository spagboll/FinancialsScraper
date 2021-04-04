namespace FinancialsScraper.Models
{
    public class RatiosAndMargins : IDataModel
    {
        public Valuation Valuation { get; set; }
        
        public Profitability Profitability { get; set; }

        public CapitalStructure CapitalStructure { get; set; }
        
        public Liquidity Liquidity { get; set; }
    }

    public class Liquidity
    {
        public string CurrentRatio { get; set; }
        
        public string QuickRatio { get; set; }
        
        public string CashRatio { get; set; }
    }

    public class CapitalStructure
    {
        public string TotalDebtToTotalEquity { get; set; }
        
        public string TotalDebtToTotalCapital { get; set; }
        
        public string TotalDebtToTotalAssets { get; set; }

        public string InterestCoverage { get; set; }

        public string LongTermDebtToEquity { get; set; }

        public string LongTermDebtToTotalCapital { get; set; }

        public string LongTermDebtToAssets { get; set; }

    }

    public class Profitability
    {
        public string GrossMargin { get; set; }

        public string OperatingMargin { get; set; }

        public string PretaxMargin { get; set; }

        public string NetMargin { get; set; }

        public string ReturnOnAssets { get; set; }
        
        public string ReturnOnEquity { get; set; }

        public string ReturnOnTotalCapital { get; set; }

        public string ReturnOnInvestedCapital { get; set; }

    }

    public class Valuation
    {
        public string PriceEarningsRatioTTM { get; set; }

        public string PriceEarningsRatio { get; set; }

        public string PriceToSalesRatio { get; set; }
        
        public string PriceToBookRatio { get; set; }

        public string PriceToCashFlowRatio { get; set; }
        
        public string TotalDebtToEnterpriseValue { get; set; }

        public string TotalDebtToEBITDA { get; set; }

        public string EPSRecurring { get; set; }
        
        public string EPSBasic { get; set; }
        
        public string EPSDiluted { get; set; }
    }
    
    
}