using SpacyID.Application.Interfaces.Senders;
using SpacyID.Application.Interfaces.Services;

namespace SpacyID.Application.Services;

public class AuthService : IAuthService
{
    private readonly IEmailSender _emailSender;
    private readonly Random randomizer = new Random();

    public AuthService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendAuthCodeToEmail(string email)
    {
        var randomNumber = randomizer.Next(1000000);
        var code = $"{randomNumber:S-#######}";

        await _emailSender.SendCode(email, code);
    }
}
