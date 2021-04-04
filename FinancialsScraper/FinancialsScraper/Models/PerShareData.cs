using FinancialsScraper.Interfaces;

namespace FinancialsScraper.Models
{
    public class PerShareData : IDataModel
    {
        public string EarningsPerShare { get; set; }

        public string Sales { get; set; } 
    
        public string CapitalExpenditure { get; set; }
        
        public string OperatingProfit { get; set; }
        
        public string CapitalExpenditureTtm { get; set; }
        
        public string TangibleBookValue { get; set; }

        public string WorkingCapital { get; set; }

        public string LongTermLiabilities { get; set; }
        
        public string GetSelector() => "table[class='cr_dataTable cr_mod_pershare']";
    }
}