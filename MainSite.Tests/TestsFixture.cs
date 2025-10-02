using MainSite.Consumer.Services;
using MainSite.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Tests
{
    public class TestsFixture : IDisposable
    {
        #region Global

        /// <summary>
        /// Testing database context
        /// </summary>
        public readonly GamersCommunityDbContext _testDbContext;

        #region Implementations

        #region Countries

        /// <summary>
        /// Implementation for countries
        /// </summary>
        public readonly CountriesService _countriesService;

        #endregion

        #endregion

        #endregion

        /// <summary>
        /// Called when tests start
        /// /!\ CARE: This context is shared between tests /!\
        /// </summary>
        public TestsFixture()
        {
            var options = new DbContextOptionsBuilder<GamersCommunityDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _testDbContext = new GamersCommunityDbContext(options);

            // Init all implementations
            _countriesService = new CountriesService(_testDbContext);
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
