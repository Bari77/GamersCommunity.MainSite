using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class EventsUsersInterestsServiceTests : GenericDataServiceTests<GamersCommunityDbContext, EventsUsersInterestsService, EventsUsersInterest>, IClassFixture<FakeDataset>
    {
        protected override List<EventsUsersInterest> GetFakeData() => [];

        protected override EventsUsersInterest GetNewEntity() => new()
        {
            IdEvent = 1,
            IdStatus = 1,
            IdUser = 1,
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override EventsUsersInterestsService CreateService() => new(CreateContext());
    }
}
