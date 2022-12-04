namespace GSCMaster.Infrastructure.Services.Authenticaion;
public class JWTOptions
{
    public const string SectionName = "JWTOptions";

    public string Issuer { get; init; } = "";

    public string Audience { get; init; } = "";

    public string SecretKey { get; init; } = "";
}