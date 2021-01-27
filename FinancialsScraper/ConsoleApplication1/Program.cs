using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var config = Configuration.Default.WithDefaultLoader();
            
            var address = "https://www.wsj.com/market-data/quotes/TSM/financials";

            var context = BrowsingContext.New(config);
            
            var document = await context.OpenAsync(address);
            
            var perShareDataTable = document.QuerySelector("table[class='cr_dataTable cr_mod_pershare']").Children.Single(x => x.LocalName == "tbody");

            var perShareDataTableCells = perShareDataTable.Children.Select(x => x.Children.Select(y => y.TextContent));
            
            PerShareDataTable dataTable = new PerShareDataTable();
            
            foreach (var cellTexts in perShareDataTableCells)
            {
                foreach (var text in cellTexts)
                {
                    var pattern = @"([^a-zA-Z])\d*\.?\d+";

                    var digitsAndSymbolsRegex = Regex.Match(text, pattern).Value;

                    var charIndex = text.Contains("+") ? "+" : "-";
                    
                    if (text.Contains("Earnings Per Share"))
                    {
                        var val = text.Substring(text.IndexOf(charIndex)).Trim();
                        dataTable.EarningsPerShare = val; 
                    }
                    else if (text.Contains("Sales"))
                    {
                        var val = text.Substring(text.IndexOf(charIndex)).Trim();
                    }
                }
            }

            // foreach (var text in perShareDataTable.Children.Select(x => x.TextContent.Trim()))
            // {
            //
            //     if (text.Contains("Earnings Per Share") || text.Contains("Sales"))
            //     {
            //         var perShareTxt = text.Substring(0, text.IndexOf('+')).Trim();
            //         var perShareVal = text.Substring(text.IndexOf('+'), text.IndexOf(' ')).Trim();
            //         
            //         //var salesTxt = text.Substring(text.IndexOf(''))
            //     }
            // }
        }
    }
}