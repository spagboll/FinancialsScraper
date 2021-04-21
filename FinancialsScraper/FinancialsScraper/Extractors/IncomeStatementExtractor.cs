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
            var incomeStatementTable = GetIncomeSatement(document).SelectMany(x => x.Children.Select(y => y.GetElementsByClassName("cr_financials_table"))).SingleOrDefault(z => z.Any());

            return null;
        }

        public IHtmlCollection<IElement> GetIncomeSatement(IDocument document)
        {
            return document.GetElementsByClassName("cr_financials_income");
        }
    }
}