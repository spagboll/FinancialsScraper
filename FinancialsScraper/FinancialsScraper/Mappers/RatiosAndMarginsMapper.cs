using System.Linq;
using AngleSharp.Dom;
using FinancialsScraper.Extractors;
using FinancialsScraper.Helpers;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;

namespace FinancialsScraper.Mappers
{
    public class RatiosAndMarginsMapper : IDataMapper<IElementModel>
    {
        public readonly RatiosAndMargins _ratiosAndMargins = new RatiosAndMargins();
        private readonly RatiosAndMarginsExtractor _dataExtractor = new RatiosAndMarginsExtractor();
        
        public IElementModel Map(IDocument document)
        {
            var valuation = MapValuation(document);

            
            throw new System.NotImplementedException();
        }
        
        private Valuation MapValuation(IDocument document)
        {
            var dataCells = _dataExtractor.GetValuationDataCells(document);
            var valuation = new Valuation();
            
            foreach (var cell in dataCells)
            {
                var matchedValue = MatchHelper.MatchNumberAndSymbol(cell);

                if (cell.Contains("P/E Ratio (TTM)"))
                    valuation.PriceEarningsRatioTTM = matchedValue;
                
                if (cell.Contains("P/E Ratio"))
                    valuation.PriceEarningsRatio = matchedValue;

                if (cell.Contains("Price to Sales Ratio"))
                    valuation.PriceToSalesRatio = matchedValue;
                
                if (cell.Contains("Price to Book Ratio"))
                    valuation.PriceToBookRatio = matchedValue;
                
                if (cell.Contains("Price to Cash Flow Ratio"))
                    valuation.PriceToCashFlowRatio = matchedValue;
                
                //if (cell.Contains("Enterprise Value to EBITDA"))
                    
                //if (cell.Contains("Enterprise Value to Sales"))

                if (cell.Contains("EPS (recurring)"))
                    valuation.EPSRecurring = matchedValue; 
     
                if (cell.Contains("EPS (basic)"))
                    valuation.EPSBasic = matchedValue;     
                    
                if (cell.Contains("EPS (diluted)"))
                    valuation.EPSDiluted = matchedValue;
            }
            

            return valuation;
        }

    }
}