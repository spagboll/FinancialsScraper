using System;

namespace FinancialsScraper.Models
{
    public abstract class IncomeStatement
    {
        public abstract string Year { get; set; }
        public abstract string NetIncomeGrowth { get; set; }
        public abstract string SalesOrRevenue { get; set; }
        public abstract string SalesOrRevenueGrowth { get; set; }
        
        public class QuarterlyIncomeStatement : IncomeStatement
        {
            public override string Year { get; set; } = DateTime.Today.Year.ToString();
            public override string NetIncomeGrowth { get; set; }
            public override string SalesOrRevenue { get; set; }
            public override string SalesOrRevenueGrowth { get; set; }
        }

        public class AnnualIncomeStatement : IncomeStatement
        {
            public override string Year { get; set; } = DateTime.Today.Year.ToString();
            public override string NetIncomeGrowth { get; set; }
            public override string SalesOrRevenue { get; set; }
            public override string SalesOrRevenueGrowth { get; set; }
        }
    }
}