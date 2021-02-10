using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static IBrowsingContext _context => SetupBrowsingContext();
        private const string _address = "https://www.wsj.com/market-data/quotes/TSM/financials";
        
        public static async Task Main(string[] args)
        {
            var document = await GetDocument();
            
            var perShareData = new PerShareData();
            
            var perShareData1 = new PerShareData();
            
            var dataCells = perShareData.GetDataTableCells(document); 
            
            foreach (var cellTexts in dataCells)
            {
                var lol = new MapperFactory().GetMapper<PerShareData>();
                
                foreach (var text in cellTexts)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        var numberAndSymbolPattern = @"([^a-zA-Z])\d*\.?\d+";
                        var matchedValue = Regex.Match(text, numberAndSymbolPattern).Value.Trim();
                        
                        if (text.Contains("Earnings Per Share"))
                            perShareData.EarningsPerShare = matchedValue;
                        
                        if (text.Contains("Sales"))
                            perShareData.Sales = matchedValue;

                        if (text.Contains("Tangible Book Value"))
                            perShareData.TangibleBookValue = matchedValue;

                        if (text.Contains("Operating Profit"))
                            perShareData.OperatingProfit = matchedValue;

                        if (text.Contains("Working Capital"))
                            perShareData.WorkingCapital = matchedValue;
                        
                        if (text.Contains("Capital Expenditure"))
                            perShareData.CapitalExpenditure = matchedValue;
                        
                        if (text.Contains("Capital Expenditure TTM"))
                            perShareData.CapitalExpenditureTtm = matchedValue; 
                    }
                }
            }
        }

        private static IBrowsingContext SetupBrowsingContext()
        {
            var config = Configuration.Default.WithDefaultLoader();
            return BrowsingContext.New(config);
        }
        
        private static async Task<IDocument> GetDocument()
        {
            return await _context.OpenAsync(_address);
        }
    }
}