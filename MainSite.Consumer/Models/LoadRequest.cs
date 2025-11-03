namespace MainSite.Consumer.Models
{
    /// <summary>
    /// Load user request
    /// </summary>
    public class LoadRequest
    {
        /// <summary>
        /// Keycloak id
        /// </summary>
        public required Guid IdKeycloak { get; set; }
        /// <summary>
        /// Choosed username
        /// </summary>
        public string? Nickname { get; set; }
    }
}
