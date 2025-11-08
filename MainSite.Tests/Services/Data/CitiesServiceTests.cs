using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class CitiesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, CitiesService, City>, IClassFixture<FakeDataset>
    {
        protected override List<City> GetFakeData() => [];

        protected override City GetNewEntity() => new()
        {
            Name = "New city",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override CitiesService CreateService() => new(CreateContext());
    }
}
