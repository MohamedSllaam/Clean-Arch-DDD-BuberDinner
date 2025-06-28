namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtSettings
    { 
        public const string SectionName = "JwtSettings";
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }  // Default to 60 minutes
        public string Audience { get; set; } = string.Empty;
        
    }
}