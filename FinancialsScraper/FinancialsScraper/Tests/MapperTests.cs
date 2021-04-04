using FinancialsScraper.Mappers;
using NSubstitute;
using NUnit.Framework;

namespace FinancialsScraper.Tests
{
    [TestFixture]
    public class MapperTests
    {
        private PerShareDataMapper _perShareDataMapper; 
        
        [SetUp]
        public void Setup()
        { 
            _perShareDataMapper = Substitute.For<PerShareDataMapper>();
        }

        [Test]
        public void GivenIMapSomeRandomData_ThenItsMapped()
        {
            //_perShareDataMapper.Map()
        }
    }
}