namespace ShopBridge.API.Configuration
{
    public class JwtConfig
    {
        public const string JwtConfigSection = "JwtConfig";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
