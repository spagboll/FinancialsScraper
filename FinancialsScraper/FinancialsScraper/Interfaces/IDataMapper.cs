using AngleSharp.Dom;
using FinancialsScraper.Models;

namespace FinancialsScraper.Interfaces
{
    public interface IDataMapper<T>
    {
        T Map(IDocument document);
    }
}