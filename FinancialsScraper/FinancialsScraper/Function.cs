using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using AngleSharp;
using AngleSharp.Dom;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FinancialsScraper
{
    public class Function
    {
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            var config = Configuration.Default.WithDefaultLoader();
            
            var address = "https://www.wsj.com/market-data/quotes/TSM/financials";

            var browsingContext = BrowsingContext.New(config);
            
            var document = await browsingContext.OpenAsync(address);
            
            var perShareDataTable = document.QuerySelector("table[class='cr_dataTable cr_mod_pershare']");

            var perShareDataRows = perShareDataTable.Children.SelectMany(x => x.Children);
            
            
            return null;
        }
    }
}
