namespace DiscoverAirline.CoreAPI.Settings
{
    public class SecuritySettings
    {
        public string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
        public int ExpirationRefreshInHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
