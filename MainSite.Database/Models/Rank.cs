using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class Rank : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Entitled { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<RankRight> RankRights { get; set; } = new List<RankRight>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
