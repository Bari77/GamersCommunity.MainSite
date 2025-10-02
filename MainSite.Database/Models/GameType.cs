using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class GameType : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Entitled { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
