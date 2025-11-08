using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class EventsServiceTests : GenericDataServiceTests<GamersCommunityDbContext, EventsService, Event>, IClassFixture<FakeDataset>
    {
        protected override List<Event> GetFakeData() => [];

        protected override Event GetNewEntity() => new()
        {
            Title = "New event",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
            Active = false,
            BeginDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(7),
            Description = string.Empty,
            Address = null,
            NumAddress = null,
            Image = null,
            Link = null,
            PlaceName = null,
            Places = null,
        };

        protected override EventsService CreateService() => new(CreateContext());
    }
}
