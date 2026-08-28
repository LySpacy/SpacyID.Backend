namespace SpacyID.Infrastructure.Configuration;

internal class EmailOptions
{
    public string Address { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public SmtpOptions Smtp { get; set; } = new();

}

internal class SmtpOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
}
