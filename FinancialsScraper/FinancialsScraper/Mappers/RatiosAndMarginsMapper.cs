using System.Collections.Generic;
using System.Linq;
using FinancialsScraper.Helpers;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;

namespace FinancialsScraper.Mappers
{
    public class RatiosAndMarginsMapper : IDataMapper<string>
    {
        public IDataModel Map(IEnumerable<string> cells)
        {
            var dataCells = cells as string[] ?? cells.ToArray();
            return new RatiosAndMargins
            {
                Valuation = MapValuation(dataCells),
                Profitability = MapProfitability(dataCells),
                CapitalStructure = MapCapitalStructure(dataCells),
                Liquidity = MapLiquidity(dataCells)
            };
        }

        private Liquidity MapLiquidity(IEnumerable<string> dataCells)
        {
            //var dataCells = RatiosAndMarginsExtractor.GetLiquidity(document);
            var liquidity = new Liquidity();
            
            foreach (var cell in dataCells)
            {
                if (string.IsNullOrEmpty(cell)) continue;
                
                var matchedValue = MatchHelper.MatchNumberAndSymbol(cell);

                if (cell.Contains("Current Ratio")) liquidity.CurrentRatio = matchedValue;

                if (cell.Contains("Quick Ratio")) liquidity.QuickRatio = matchedValue;
                
                if (cell.Contains("Cash Ratio")) liquidity.CashRatio = matchedValue;
            }
            
            return liquidity;
        }

        private CapitalStructure MapCapitalStructure(IEnumerable<string> dataCells)
        {
            //var dataCells = RatiosAndMarginsExtractor.GetCapitalStructure(document);
            var capitalStructure = new CapitalStructure();

            foreach (var cell in dataCells)
            {
                if (string.IsNullOrEmpty(cell)) continue;

                var matchedValue = MatchHelper.MatchNumberAndSymbol(cell);

                if (cell.Contains("Total Debt to Total Equity")) capitalStructure.TotalDebtToTotalEquity = matchedValue;
                
                if (cell.Contains("Total Debt to Total Capital")) capitalStructure.TotalDebtToTotalCapital = matchedValue;
                
                if (cell.Contains("Total Debt to Total Assets")) capitalStructure.TotalDebtToTotalAssets = matchedValue;

                if (cell.Contains("Interest Coverage")) capitalStructure.InterestCoverage = matchedValue;

                if (cell.Contains("Long-Term Debt to Equity")) capitalStructure.LongTermDebtToEquity = matchedValue;
                
                if (cell.Contains("Long-Term Debt to Capital")) capitalStructure.LongTermDebtToTotalCapital = matchedValue;
                
                if (cell.Contains("Long-Term Debt to Assets")) capitalStructure.LongTermDebtToAssets = matchedValue;
            }
            
            return capitalStructure;
        }

        private Profitability MapProfitability(IEnumerable<string> dataCells)
        {
            //var dataCells = RatiosAndMarginsExtractor.GetProfitability(document);
            var profitability = new Profitability();

            foreach (var cell in dataCells)
            {
                if (string.IsNullOrEmpty(cell)) continue;

                var matchedValue = MatchHelper.MatchNumberAndSymbol(cell);

                if (cell.Contains("Gross Margin")) profitability.GrossMargin = matchedValue;

                if (cell.Contains("Operating Margin")) profitability.OperatingMargin = matchedValue;

                if (cell.Contains("Pretax Margin")) profitability.PretaxMargin = matchedValue;

                if (cell.Contains("Net Margin")) profitability.NetMargin = matchedValue;
                
                if (cell.Contains("Return on Assets")) profitability.ReturnOnAssets = matchedValue;
                
                if (cell.Contains("Return on Total Capital")) profitability.ReturnOnTotalCapital = matchedValue;

                if (cell.Contains("Return on Invested Capital")) profitability.ReturnOnInvestedCapital = matchedValue;
            }

            return profitability;
        }

        private Valuation MapValuation(IEnumerable<string> dataCells)
        {
            //var dataCells = RatiosAndMarginsExtractor.GetValuation(document);
            var valuation = new Valuation();

            foreach (var cell in dataCells)
            {
                if (string.IsNullOrEmpty(cell)) continue;
                
                var matchedValue = MatchHelper.MatchNumberAndSymbol(cell);

                if (cell.Contains("P/E Ratio (TTM)")) valuation.PriceEarningsRatioTTM = matchedValue;

                if (cell.Contains("P/E Ratio")) valuation.PriceEarningsRatio = matchedValue;

                if (cell.Contains("Price to Sales Ratio")) valuation.PriceToSalesRatio = matchedValue;

                if (cell.Contains("Price to Book Ratio")) valuation.PriceToBookRatio = matchedValue;

                if (cell.Contains("Price to Cash Flow Ratio")) valuation.PriceToCashFlowRatio = matchedValue;

                //if (cell.Contains("Enterprise Value to EBITDA"))

                //if (cell.Contains("Enterprise Value to Sales"))

                if (cell.Contains("EPS (recurring)")) valuation.EPSRecurring = matchedValue;

                if (cell.Contains("EPS (basic)")) valuation.EPSBasic = matchedValue;

                if (cell.Contains("EPS (diluted)")) valuation.EPSDiluted = matchedValue;
            }
            
            return valuation;
        }

        // public IElementModel Map(IEnumerable<IElementModel> cells)
        // {
        //     throw new System.NotImplementedException();
        // }
       
    }
}