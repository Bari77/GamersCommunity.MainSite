using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class GameTypesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, GameTypesService, GameType>, IClassFixture<FakeDataset>
    {
        protected override List<GameType> GetFakeData() => [];

        protected override GameType GetNewEntity() => new()
        {
            Entitled = "New game type",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override GameTypesService CreateService() => new(CreateContext());
    }
}
