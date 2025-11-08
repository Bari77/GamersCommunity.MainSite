using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class FriendsServiceTests : GenericDataServiceTests<GamersCommunityDbContext, FriendsService, Friend>, IClassFixture<FakeDataset>
    {
        protected override List<Friend> GetFakeData() => [];

        protected override Friend GetNewEntity() => new()
        {
            IdFriendAsking = 1,
            IdFriendReceive = 2,
            IdFriendStatus = 1,
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override FriendsService CreateService() => new(CreateContext());
    }
}
