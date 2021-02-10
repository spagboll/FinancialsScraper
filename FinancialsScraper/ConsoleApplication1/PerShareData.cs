using System.Collections.Generic;
using System.Linq;
using AngleSharp;
using AngleSharp.Dom;

namespace ConsoleApplication1
{
    public class PerShareData : DataElement
    {
        public string EarningsPerShare { get; set; }

        public string Sales { get; set; } 
    
        public string CapitalExpenditure { get; set; }
        
        public string OperatingProfit { get; set; }
        
        public string CapitalExpenditureTtm { get; set; }
        
        public string TangibleBookValue { get; set; }

        public string WorkingCapital { get; set; }

        public string LongTermLiabilities { get; set; }
        
        public IEnumerable<IEnumerable<string>> GetDataTableCells(IDocument document)
        {
            return GetDataTable(document).Children.Select(x => x.Children.Select(y => y.TextContent));
        }
        
        public IElement GetDataTable(IDocument document) 
        {
            return document.QuerySelector(GetSelector()).Children.Single(x => x.LocalName == "tbody");
        }

        public override string GetSelector() => "table[class='cr_dataTable cr_mod_pershare']"; 
    }
}