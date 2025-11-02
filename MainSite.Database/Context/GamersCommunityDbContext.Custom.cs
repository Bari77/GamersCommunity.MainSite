using Microsoft.EntityFrameworkCore;

namespace MainSite.Database.Context
{
    public partial class GamersCommunityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Database");
            }
        }
    }
}
