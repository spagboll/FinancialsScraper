using System.Threading.Tasks;
using Amazon.Lambda.Core;
using FinancialsScraper.Builders;
using FinancialsScraper.Enum;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Mappers;
using FinancialsScraper.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FinancialsScraper
{
    public class Function
    {
        private IParser _parser;
        
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            input = "https://www.wsj.com/market-data/quotes/TSM/financials";

            var document = await _parser.GetDocument(input);
            
            var perShareData = new PerShareDataMapper().Map(document);

            var financials = new FinancialsBuilder().WithPerShareData(perShareData);
            

            return null;
        }
    }
}
