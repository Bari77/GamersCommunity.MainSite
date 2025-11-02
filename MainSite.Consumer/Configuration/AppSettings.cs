namespace MainSite.Consumer.Configuration
{
    /// <summary>
    /// App settings representation class
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Avatar base url
        /// </summary>
        public required string AvatarBaseUrl { get; set; }
        /// <summary>
        /// Min avatar id stored in AvatarBaseUrl
        /// </summary>
        public int MinRangeAvatarId { get; set; }
        /// <summary>
        /// Max avatar id stored in AvatarBaseUrl
        /// </summary>
        public int MaxRangeAvatarId { get; set; }
    }
}