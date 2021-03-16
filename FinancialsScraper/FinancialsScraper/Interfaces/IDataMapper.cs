using AngleSharp.Dom;
using FinancialsScraper.Models;

namespace FinancialsScraper.Interfaces
{
    public interface IDataMapper<out T>
    {
        T Map(IDocument document);
    }
}