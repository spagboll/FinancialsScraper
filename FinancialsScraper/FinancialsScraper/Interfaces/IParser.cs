﻿using System.Threading.Tasks;
using AngleSharp.Dom;

namespace FinancialsScraper.Interfaces
{
    public interface IParser
    {
        Task<IDocument> GetDocument(string urlToParse);
    }
}