﻿using AngleSharp.Dom;
using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;
using FinancialsScraper.PageElements;
using System.Text.RegularExpressions;
using FinancialsScraper.Helpers;

namespace FinancialsScraper.Mappers
{
    public class PerShareDataMapper : IDataMapper<PerShareData>
    {
        private readonly PerShareDataTable _perShareDataTable = new PerShareDataTable();
        
        public PerShareData Map(IDocument document)
        {
            var perShareData = new PerShareData();

            var tableCells = _perShareDataTable.GetDataTableCells(document, perShareData.GetSelector()); 
            
            foreach (var cellTexts in tableCells)
            {
                foreach (var text in cellTexts)
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
            }

            return perShareData; 
        }
    }
}