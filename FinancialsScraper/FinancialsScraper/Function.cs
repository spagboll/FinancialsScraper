using System.Threading.Tasks;
using Amazon.Lambda.Core;
using FinancialsScraper.Builders;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Mappers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FinancialsScraper
{
    public class Function
    {
        private IParser _parser = new Parser();
        
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            input = "https://www.wsj.com/market-data/quotes/TSM/financials";

            var document = await _parser.ParsePage(input);
            
            var ratiosandmargins = new RatiosAndMarginsMapper().Map(document);
            
            
            var perShareData = new PerShareDataMapper().Map(document);
            var financials = FinancialsBuilder.Create().WithPerShareData(perShareData).Build(); 
            

            return null;
        }
    }
}
