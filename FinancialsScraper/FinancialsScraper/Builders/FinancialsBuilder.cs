using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;

namespace FinancialsScraper.Builders
{
    public class FinancialsBuilder : IFinancialsBuilder
    {
        
        //NOTE: more methods will be added to this, im just testing it out with 1 for now\
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