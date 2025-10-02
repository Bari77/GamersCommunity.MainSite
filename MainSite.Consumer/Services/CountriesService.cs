using GamersCommunity.Core.Services;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Consumer.Services
{
    /// <summary>
    /// Specialized table service for handling <see cref="Country"/> entities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service inherits from <see cref="GenericTableService{TContext, TEntity}"/>,
    /// binding it to the <see cref="GamersCommunityDbContext"/> database context and the <see cref="Country"/> entity type.
    /// </para>
    /// <para>
    /// It exposes all generic CRUD operations (List, Get, Update, Delete, etc.) implemented
    /// in <see cref="GenericTableService{TContext, TEntity}"/>, while associating them with the logical table name <c>"Countries"</c>.
    /// </para>
    /// </remarks>
    public class CountriesService : GenericTableService<GamersCommunityDbContext, Country>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesService"/> class.
        /// </summary>
        /// <param name="context">
        /// The database context used to access the <c>Countries</c> table.
        /// Typically injected by dependency injection.
        /// </param>
        public CountriesService(GamersCommunityDbContext context)
            : base(context, "Countries")
        {
        }
    }
}
