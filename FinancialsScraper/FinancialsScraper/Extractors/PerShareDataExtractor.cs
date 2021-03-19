using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;

namespace FinancialsScraper.Extractors
{
    public class PerShareDataExtractor
    {
        public IEnumerable<IEnumerable<string>> GetDataTableCells(IDocument document, string selector)
        {
            return GetDataTable(document, selector).Children.Select(x => x.Children.Select(y => y.TextContent));
        }

        private IElement GetDataTable(IDocument document, string selector) 
        {
            return document.QuerySelector(selector).Children.Single(x => x.LocalName == "tbody");
        }
    }
}