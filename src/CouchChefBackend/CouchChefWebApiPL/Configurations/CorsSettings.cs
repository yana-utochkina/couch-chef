namespace CouchChefWebApiPL.Configurations;

public class CorsSettings
{
    public required string[] Origins { get; set; } = Array.Empty<string>();
}
