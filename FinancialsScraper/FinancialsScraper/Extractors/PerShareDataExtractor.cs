using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;

namespace FinancialsScraper.Extractors
{
    public static class PerShareDataExtractor
    {
        public static IEnumerable<string> GetDataTableCells(IDocument document, string selector)
        {
            return GetDataTable(document, selector).Children.SelectMany(x => x.Children.Select(y => y.TextContent));
        }

        private static IElement GetDataTable(IDocument document, string selector) 
        {
            return document.QuerySelector(selector).Children.Single(x => x.LocalName == "tbody");
        }
    }
}