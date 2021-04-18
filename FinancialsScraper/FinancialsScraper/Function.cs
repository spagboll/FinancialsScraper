using System.Threading.Tasks;
using Amazon.Lambda.Core;
using FinancialsScraper.Builders;
using FinancialsScraper.Extractors;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Mappers;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FinancialsScraper
{
    public class Function
    {
        private IParser _parser = new Parser();
        
        public async Task<string> FunctionHandler(JObject input, ILambdaContext context)
        {
            string urlToScrape = "https://www.wsj.com/market-data/quotes/TSM/financials";
            
            var document = await _parser.ParsePage(urlToScrape);

            IncomeStatementExtractor incomeStatementExtractor = new IncomeStatementExtractor();

            var doc = incomeStatementExtractor.GetDataTableCells(document);
            
            

            return null;
        }
    }
}
