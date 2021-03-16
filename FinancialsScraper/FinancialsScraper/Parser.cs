using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using FinancialsScraper.Interfaces;

namespace FinancialsScraper
{
    public class Parser : IParser
    {
        private IBrowsingContext _context => SetupBrowsingContext();
        
        public async Task<IDocument> ParsePage(string urlToParse)
        {
            return await _context.OpenAsync(urlToParse);
        }
        
        private IBrowsingContext SetupBrowsingContext()
        {
            var config = Configuration.Default.WithDefaultLoader();
            return BrowsingContext.New(config);
        }
    }
}