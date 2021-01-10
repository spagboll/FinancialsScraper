using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

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
            
            var perShareDataTable = document.QuerySelector("table[class='cr_dataTable cr_mod_pershare']");
        }
    }
}