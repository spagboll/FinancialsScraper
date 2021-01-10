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
            
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
            
            var browsingContext = BrowsingContext.New(config);
            
            var document = await browsingContext.OpenAsync(address);
            
            var cellSelector = "tr.vevent td:nth-child(3)";
            
            var cells = document.QuerySelectorAll(cellSelector);
            
            var titles = cells.Select(m => m.TextContent);

            return null;
        }
    }
}
