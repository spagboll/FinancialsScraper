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
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {

            return null;
        }
    }
}
