using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class Locale : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Code { get; set; } = null!;

    public string Lcid { get; set; } = null!;

    public string Entitled { get; set; } = null!;
}
