using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;

namespace FinancialsScraper.Builders
{
    public class FinancialsBuilder : IFinancialsBuilder
    {
        private readonly Financials _page = new Financials();
        
        public IFinancialsBuilder WithPerShareData(PerShareData perShareData)
        {
            _page.PerShareData = perShareData;
            return this; 
        }

        public Financials Build() => _page; 
    }

    public interface IFinancialsBuilder : IBuilder<Financials>
    {
        IFinancialsBuilder WithPerShareData(PerShareData perShareData);
    }
}