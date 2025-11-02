using GamersCommunity.Core.Exceptions;
using GamersCommunity.Core.Rabbit;
using GamersCommunity.Core.Serialization;
using GamersCommunity.Core.Services;
using LinqToDB;
using MainSite.Consumer.Configuration;
using MainSite.Consumer.Models;
using MainSite.Consumer.Validators;
using MainSite.Database.Context;
using MainSite.Database.Models;
using Microsoft.Extensions.Options;

namespace MainSite.Consumer.Services
{
    /// <summary>
    /// Specialized table service for handling <see cref="User"/> entities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service inherits from <see cref="GenericTableService{TContext, TEntity}"/>,
    /// binding it to the <see cref="GamersCommunityDbContext"/> database context and the <see cref="User"/> entity type.
    /// </para>
    /// <para>
    /// It exposes all generic CRUD operations (List, Get, Update, Delete, etc.) implemented
    /// in <see cref="GenericTableService{TContext, TEntity}"/>, while associating them with the logical table name <c>"Users"</c>.
    /// </para>
    /// </remarks>
    /// <param name="context">
    /// The database context used to access the <c>Users</c> table.
    /// Typically injected by dependency injection.
    /// </param>
    public class UsersService(GamersCommunityDbContext context, IOptions<AppSettings> otps) : GenericTableService<GamersCommunityDbContext, User>(context, "Users")
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        /// App settings options value
        /// </summary>
        private AppSettings AppSettings = otps.Value;

        /// <summary>
        /// Handles custom user-related actions that extend the default behavior of <see cref="GenericTableService{TContext, TEntity}"/>.
        /// This override processes the "Load" action, which is responsible for either logging in
        /// an existing user or signing up a new one based on their Keycloak identifier.
        /// </summary>
        /// <param name="action">The action name to execute. Supports "Load" in this implementation.</param>
        /// <param name="data">A JSON payload representing a <see cref="LoadRequest"/> object, required for the "Load" action.</param>
        /// <param name="id">Optional entity ID (not used in this override).</param>
        /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A JSON string representing the user object returned from either <see cref="LoginAsync(User, CancellationToken)"/>
        /// or <see cref="SignupAsync(User, CancellationToken)"/>.
        /// </returns>
        /// <exception cref="BadRequestException">Thrown if the "Load" action is invoked without the required data payload.</exception>
        public override async Task<string> HandleAsync(string action, string? data = null, int? id = null, CancellationToken ct = default)
        {
            switch (action)
            {
                case "Load":
                    if (string.IsNullOrEmpty(data))
                    {
                        throw new BadRequestException("Data mandatory");
                    }

                    var info = ConsumerParamParser.ToObject<LoadRequest>(data);
                    var user = await Context.Users.FirstOrDefaultAsync(f => f.IdKeycloak == info.IdKeycloak, ct);

                    if (user != null)
                    {
                        return JsonSafe.Serialize(await LoginAsync(user, ct));
                    }

                    if (string.IsNullOrEmpty(info.Username))
                    {
                        throw new BadRequestException("Username mandatory");
                    }

                    user = new()
                    {
                        IdKeycloak = info.IdKeycloak,
                        Username = info.Username,
                    };
                    return JsonSafe.Serialize(await SignupAsync(user, ct));
            }

            return await base.HandleAsync(action, data, id, ct);
        }

        /// <summary>
        /// Creates a new user account in the database if no existing account matches the provided username and discriminator.
        /// This method generates a unique discriminator (4-digit numeric code) and a random avatar before saving the user.
        /// Once created, the user is automatically logged in via <see cref="LoginAsync(User, CancellationToken)"/>.
        /// </summary>
        /// <param name="entity">The user entity to create.</param>
        /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>The newly created and logged-in <see cref="User"/> entity.</returns>
        private async Task<User> SignupAsync(User entity, CancellationToken ct = default)
        {
            UserValidator.ValidateUsername(entity.Username);

            do
            {
                entity.Discriminator = GetRandomDiscriminator();
            }
            while (await Context.Users.AnyAsync(u => u.Username == entity.Username && u.Discriminator == entity.Discriminator, ct));

            entity.AvatarUrl = GetRandomAvatar();
            entity.CreationDate = DateTime.UtcNow;
            entity.ModificationDate = DateTime.UtcNow;

            await CreateAsync(entity, ct);
            return await LoginAsync(entity, ct);
        }

        /// <summary>
        /// Updates an existing user's connection-related data when they log in.
        /// This method refreshes the <see cref="User.LastConnection"/> and <see cref="User.ModificationDate"/> fields,
        /// persists the changes, and retrieves the updated user from the database.
        /// </summary>
        /// <param name="entity">The existing user entity to update.</param>
        /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>The updated <see cref="User"/> entity after successful login.</returns>
        private async Task<User> LoginAsync(User entity, CancellationToken ct = default)
        {
            entity.LastConnection = DateTime.UtcNow;
            entity.ModificationDate = DateTime.UtcNow;
            await UpdateAsync(entity.Id, entity, ct);

            return await GetAsync(entity.Id, ct);
        }


        /// <summary>
        /// Get a random avatar url
        /// </summary>
        /// <returns>Random avatar url</returns>
        private string GetRandomAvatar()
        {
            lock (Random)
                return AppSettings.AvatarBaseUrl + "/" + Random.Next(AppSettings.MinRangeAvatarId, AppSettings.MaxRangeAvatarId + 1) + ".png";
        }

        /// <summary>
        /// Get a random descriminator value
        /// </summary>
        /// <returns>Random descriminator value</returns>
        private string GetRandomDiscriminator()
        {
            lock (Random)
                return Random.Next(1, 10000).ToString("D4");
        }
    }
}
