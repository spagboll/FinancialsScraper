using System.Collections.Generic;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;
using FinancialsScraper.Helpers;

namespace FinancialsScraper.Mappers
{
    public class PerShareDataMapper : IDataMapper<string>
    {
        public IDataModel Map(IEnumerable<string> cells)
        {
            var perShareData = new PerShareData();

            //var tableCells = PerShareDataExtractor.GetDataTableCells(document, perShareData.GetSelector()); 
            
                foreach (var text in cells)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        var matchedValue = MatchHelper.MatchNumberAndSymbol(text); 
                        
                        if (text.Contains("Earnings Per Share"))
                            perShareData.EarningsPerShare = matchedValue;
                        
                        if (text.Contains("Sales"))
                            perShareData.Sales = matchedValue;

                        if (text.Contains("Tangible Book Value"))
                            perShareData.TangibleBookValue = matchedValue;

                        if (text.Contains("Operating Profit"))
                            perShareData.OperatingProfit = matchedValue;

                        if (text.Contains("Working Capital"))
                            perShareData.WorkingCapital = matchedValue;
                        
                        if (text.Contains("Capital Expenditure"))
                            perShareData.CapitalExpenditure = matchedValue;
                        
                        if (text.Contains("Capital Expenditure TTM"))
                            perShareData.CapitalExpenditureTtm = matchedValue; 
                    }
                }

            return perShareData; 
        }

        public T Map<T>(IEnumerable<T> cells)
        {
            throw new System.NotImplementedException();
        }
    }
}