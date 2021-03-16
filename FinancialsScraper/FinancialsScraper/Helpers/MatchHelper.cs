using System.Text.RegularExpressions;

namespace FinancialsScraper.Helpers
{
    public static class MatchHelper
    {
        public static string MatchNumberAndSymbol(string input)
        {
            var numberAndSymbolPattern = @"([^a-zA-Z])\d*\.?\d+";
            return Regex.Match(input, numberAndSymbolPattern).Value.Trim();
        }
    }
}