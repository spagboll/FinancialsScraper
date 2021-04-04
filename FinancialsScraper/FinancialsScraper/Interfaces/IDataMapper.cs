using System.Collections.Generic;
using FinancialsScraper.Models;

namespace FinancialsScraper.Interfaces
{
    public interface IDataMapper<in T>
    {
       IDataModel Map(IEnumerable<T> cells);
    }
}