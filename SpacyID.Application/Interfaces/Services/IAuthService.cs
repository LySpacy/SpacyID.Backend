namespace SpacyID.Application.Interfaces.Services;

public interface IAuthService
{
    Task<string> SendAuthCode(string email);
    Task VerifyAuthCode(string login, string code);
}
