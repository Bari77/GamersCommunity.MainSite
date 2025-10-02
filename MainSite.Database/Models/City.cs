using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class City : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Name { get; set; } = null!;

    public decimal PostalCode { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
