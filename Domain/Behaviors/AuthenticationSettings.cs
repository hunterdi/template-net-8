namespace Domain.Behaviors
{
    public sealed class AuthenticationSettings
    {
        public int BearerTokenExpiration { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireUppercase { get; set; }
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public int DefaultLockoutTimeSpan { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
        public bool AllowedForNewUsers { get; set; }
        public required string AllowedUserNameCharacters { get; set; }
        public bool RequireUniqueEmail { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
        public required string IssuerSigningKey { get; set; }
    }
}
