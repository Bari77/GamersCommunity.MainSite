using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class EventsUsersStatusesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, EventsUsersStatusesService, EventsUsersStatus>, IClassFixture<FakeDataset>
    {
        protected override List<EventsUsersStatus> GetFakeData() => [];

        protected override EventsUsersStatus GetNewEntity() => new()
        {
            Entitled = "New status",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override EventsUsersStatusesService CreateService() => new(CreateContext());
    }
}
