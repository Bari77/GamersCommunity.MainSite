using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class Banned : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Entitled { get; set; } = null!;

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public int IdUserBan { get; set; }

    public int IdModo { get; set; }

    public virtual User IdModoNavigation { get; set; } = null!;

    public virtual User IdUserBanNavigation { get; set; } = null!;
}
