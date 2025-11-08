using GamersCommunity.Core.Tests;
using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Tests.Services.Data
{
    public class MessagesServiceTests : GenericDataServiceTests<GamersCommunityDbContext, MessagesService, Message>, IClassFixture<FakeDataset>
    {
        protected override List<Message> GetFakeData() => [];

        protected override Message GetNewEntity() => new()
        {
            IdSender = 1,
            IdReceiver = 2,
            Content = "New message",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override MessagesService CreateService() => new(CreateContext());
    }
}
