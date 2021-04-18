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

            var cells = GetIncomeSatement(document).SelectMany(x => x.GetElementsByClassName("cr_financials_row"));

            return null;
        }

        public IHtmlCollection<IElement> GetIncomeSatement(IDocument document)
        {
            return document.GetElementsByClassName("cr_financials_income");
        }
    }
}