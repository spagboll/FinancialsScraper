using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using FinancialsScraper.Interfaces;

namespace FinancialsScraper.PageElements
{
    public class RatiosAndMarginsTable : IPageElement
    {
        public IEnumerable<string> GetValuationDataCells(IDocument document)
        {
            var table =  GetRatiosAndMargins(document).GetElementsByClassName(ValuationTableSelector)
                                                      .SelectMany(x => x.Children)
                                                      .SelectMany(x => x.Children);
            
            return table.SelectMany(x => x.Children).Select(x => x.TextContent);
        }

        private IElement GetRatiosAndMargins(IDocument document)
        {
            return document.QuerySelector(RatiosAndMarginsSelector);
        }
        private string RatiosAndMarginsSelector => "div[class='cr_financials_ratios module']";

        private string ValuationTableSelector => "cr_dataTable cr_sub_valuation";
    }
}