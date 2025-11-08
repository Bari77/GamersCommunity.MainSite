using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class FriendStatusesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, FriendStatusesService, FriendStatus>, IClassFixture<FakeDataset>
    {
        protected override List<FriendStatus> GetFakeData() => [];

        protected override FriendStatus GetNewEntity() => new()
        {
            Entitled = "New friend status",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override FriendStatusesService CreateService() => new(CreateContext());
    }
}
