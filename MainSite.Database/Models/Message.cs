using GamersCommunity.Core.Database;

namespace MainSite.Database.Models;

public partial class Message : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Message1 { get; set; } = null!;

    public int IdSender { get; set; }

    public int IdReceiver { get; set; }

    public virtual User IdReceiverNavigation { get; set; } = null!;

    public virtual User IdSenderNavigation { get; set; } = null!;
}
