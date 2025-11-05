using MainSite.Consumer.Services.Data;
using MainSite.Database.Context;
using MainSite.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Tests
{
    public class TestsDataFixture : IDisposable
    {
        /// <summary>
        /// Creates a new in-memory <see cref="GamersCommunityDbContext"/> with a unique database name.
        /// </summary>
        public GamersCommunityDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<GamersCommunityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GamersCommunityDbContext(options);
        }

        /// <summary>
        /// Creates a fully functional <see cref="CountriesService"/> with all required dependencies and seeded data.
        /// </summary>
        public CountriesService CreateCountriesService()
        {
            var ctx = CreateContext();
            SeedFullDataset(ctx);

            return new CountriesService(ctx);
        }

        /// <summary>
        /// Seeds the full test dataset required across all services (relations, dependencies, etc.).
        /// </summary>
        public void SeedFullDataset(GamersCommunityDbContext ctx)
        {
            if (!ctx.Countries.Any())
            {
                ctx.Countries.AddRange(
                    new Country { Id = 1, Name = "Country A", CreationDate = DateTime.Now, ModificationDate = DateTime.Now },
                    new Country { Id = 2, Name = "Country B", CreationDate = DateTime.Now, ModificationDate = DateTime.Now }
                );
            }

            ctx.SaveChanges();
        }

        /// <summary>
        /// Called when test is ended
        /// </summary>
        public void Dispose()
        {
            // Clean
        }
    }
}
