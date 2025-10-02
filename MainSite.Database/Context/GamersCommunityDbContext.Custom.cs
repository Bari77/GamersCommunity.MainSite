using Microsoft.EntityFrameworkCore;

namespace MainSite.Database.Context
{
    public partial class GamersCommunityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Vérifier si les options sont déjà configurées
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Database");
            }
        }
    }
}
