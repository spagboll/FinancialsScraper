using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp.Dom;

namespace FinancialsScraper.Extractors
{
    public class IncomeStatementExtractor
    {
        public IEnumerable<string> GetDataTableCells(IDocument document, string selector = "")
        {
            // return GetDataTable(document, selector).Children.SelectMany(x => x.Children.Select(y => y.TextContent));

            var allChildren = GetIncomeSatement(document).SelectMany(x => x.Children.SelectMany(y => y.Children.SelectMany(z => z.Children)));


            var child = GetIncomeSatement(document)
                .SelectMany(x =>
                    x.Children
                        .Select(y =>
                            y.GetElementsByClassName("cr_financials_table").SelectMany(z => z.LocalName == "table");
            
            
            //var table = allChildren.SelectMany(x => x.Children.Select(y => y.QuerySelector("cr_financials_table")));

            return null;
        }

        public IHtmlCollection<IElement> GetIncomeSatement(IDocument document)
        {
            return document.GetElementsByClassName("cr_financials_income");
        }
    }
}