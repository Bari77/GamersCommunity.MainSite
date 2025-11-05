using GamersCommunity.Core.Services;
using MainSite.Database.Context;
using MainSite.Database.Models;

namespace MainSite.Consumer.Services.Data
{
    /// <summary>
    /// Specialized table service for handling <see cref="City"/> entities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service inherits from <see cref="GenericTableService{TContext, TEntity}"/>,
    /// binding it to the <see cref="GamersCommunityDbContext"/> database context and the <see cref="City"/> entity type.
    /// </para>
    /// <para>
    /// It exposes all generic CRUD operations (List, Get, Update, Delete, etc.) implemented
    /// in <see cref="GenericTableService{TContext, TEntity}"/>, while associating them with the logical table name <c>"Cities"</c>.
    /// </para>
    /// </remarks>
    /// <param name="context">
    /// The database context used to access the <c>Cities</c> table.
    /// Typically injected by dependency injection.
    /// </param>
    public class CitiesService(GamersCommunityDbContext context) : GenericTableService<GamersCommunityDbContext, City>(context, "Cities")
    {
    }
}
