using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class User : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public decimal Hashcode { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Mail { get; set; } = null!;

    public string? MailHash { get; set; }

    public string Pseudo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public int? IdCity { get; set; }

    public string? Address { get; set; }

    public string? NumAddress { get; set; }

    public DateTime? LastConnection { get; set; }

    public int IdRank { get; set; }

    public int? IdLocale { get; set; }

    public virtual ICollection<Banned> BannedIdModoNavigations { get; set; } = new List<Banned>();

    public virtual ICollection<Banned> BannedIdUserBanNavigations { get; set; } = new List<Banned>();

    public virtual ICollection<EventsUsersInterest> EventsUsersInterests { get; set; } = new List<EventsUsersInterest>();

    public virtual ICollection<Friend> FriendIdFriendAskingNavigations { get; set; } = new List<Friend>();

    public virtual ICollection<Friend> FriendIdFriendReceiveNavigations { get; set; } = new List<Friend>();

    public virtual City? IdCityNavigation { get; set; }

    public virtual Locale? IdLocaleNavigation { get; set; }

    public virtual Rank IdRankNavigation { get; set; } = null!;

    public virtual ICollection<Message> MessageIdReceiverNavigations { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageIdSenderNavigations { get; set; } = new List<Message>();
}
