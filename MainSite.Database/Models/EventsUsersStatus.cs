using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class EventsUsersStatus : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Entitled { get; set; } = null!;

    public virtual ICollection<EventsUsersInterest> EventsUsersInterests { get; set; } = new List<EventsUsersInterest>();
}
