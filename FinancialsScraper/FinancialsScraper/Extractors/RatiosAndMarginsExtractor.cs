using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;

namespace FinancialsScraper.Extractors
{
    public class RatiosAndMarginsExtractor
    {
        private const string ProfitabilitySelector = "cr_dataTable cr_sub_profitability";
        private const string RatiosAndMarginsSelector = "div[class='cr_financials_ratios module']";
        private const string ValuationTableSelector = "cr_dataTable cr_sub_valuation";
        private const string CapitalStructureSelector = "cr_dataTable cr_sub_capital";
        private const string LiquiditySelector = "cr_dataTable cr_sub_liquidity"; 
        
        public IEnumerable<string> GetProfitability(IDocument document)
        {
            var table = GetRatiosAndMargins(document).GetElementsByClassName(ProfitabilitySelector)
                                                     .SelectMany(x => x.Children)
                                                     .SelectMany(x => x.Children); 
            
            return table.SelectMany(x => x.Children).Select(x => x.TextContent);
        }
        
        public IEnumerable<string> GetValuation(IDocument document)
        {
            var table =  GetRatiosAndMargins(document).GetElementsByClassName(ValuationTableSelector)
                                                      .SelectMany(x => x.Children)
                                                      .SelectMany(x => x.Children);
            
            return table.SelectMany(x => x.Children).Select(x => x.TextContent);
        }

        public IEnumerable<string> GetCapitalStructure(IDocument document)
        {
            var table =  GetRatiosAndMargins(document).GetElementsByClassName(CapitalStructureSelector)
                                                      .SelectMany(x => x.Children)
                                                      .SelectMany(x => x.Children);
            
            return table.SelectMany(x => x.Children).Select(x => x.TextContent);
        }
        
        public IEnumerable<string> GetLiquidity(IDocument document)
        {
            var table =  GetRatiosAndMargins(document).GetElementsByClassName(LiquiditySelector)
                .SelectMany(x => x.Children)
                .SelectMany(x => x.Children);
            
            return table.SelectMany(x => x.Children).Select(x => x.TextContent);
        }
        
        
        private IElement GetRatiosAndMargins(IDocument document)
        {
            return document.QuerySelector(RatiosAndMarginsSelector);
        }
    }
}