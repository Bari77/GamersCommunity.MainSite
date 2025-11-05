using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class CountriesTests(TestsDataFixture fixture) : GenericDataServiceTests<GamersCommunityDbContext, CountriesService, Country>, IClassFixture<TestsDataFixture>
    {
        protected override CountriesService CreateService() => fixture.CreateCountriesService();

        protected override List<Country> GetFakeData()
        {
            return [];
        }

        protected override Country GetNewEntity()
        {
            return new Country
            {
                Name = "Country test"
            };
        }
    }
}
