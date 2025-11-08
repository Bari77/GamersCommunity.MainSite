using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class CountriesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, CountriesService, Country>, IClassFixture<FakeDataset>
    {
        protected override List<Country> GetFakeData() => [];

        protected override Country GetNewEntity() => new()
        {
            Name = "New country",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override CountriesService CreateService() => new(CreateContext());
    }
}
