using FinancialsScraper.Interfaces;
using FinancialsScraper.Models;

namespace FinancialsScraper.Builders
{
    public class FinancialsBuilder : IFinancialsBuilder
    {
        //NOTE: more methods will be added to this, im just testing it out with 1 for now\
        private readonly Financials _page = new Financials();

        public Financials Build() => _page; 

        public static FinancialsBuilder Create()
        {
            return new FinancialsBuilder();
        }
        
        public IFinancialsBuilder WithPerShareData(PerShareData perShareData)
        {
            _page.PerShareData = perShareData;
            return this; 
        }
        
        public IFinancialsBuilder WithEarningsAndEstimates(RatiosAndMargins ratiosAndMargins)
        {
            return this; 
        }
    }

    public interface IFinancialsBuilder : IBuilder<Financials>
    {
        IFinancialsBuilder WithPerShareData(PerShareData perShareData);
    }
}