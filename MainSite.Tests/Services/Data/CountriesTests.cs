using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class CountriesTests : GenericServiceTests<GamersCommunityDbContext, CountriesService, Country>, IClassFixture<TestsFixture>
    {
        public CountriesTests(TestsFixture fixture) : base(fixture._countriesService)
        {
            fixture._testDbContext.AddRange(GetFakeData());
            fixture._testDbContext.SaveChanges();
        }

        protected override List<Country> GetFakeData()
        {
            return
            [
                new() {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Name = "Country 1",
                },
                new() {
                    Id = 2,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Name = "Country 2",
                },
            ];
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
