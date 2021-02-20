using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;

namespace FinancialsScraper.PageElements
{
    public class PerShareDataTable
    {
        public IEnumerable<IEnumerable<string>> GetDataTableCells(IDocument document, string selector)
        {
            return GetDataTable(document, selector).Children.Select(x => x.Children.Select(y => y.TextContent));
        }
        
        public IElement GetDataTable(IDocument document, string selector) 
        {
            return document.QuerySelector(selector).Children.Single(x => x.LocalName == "tbody");
        }
    }
}