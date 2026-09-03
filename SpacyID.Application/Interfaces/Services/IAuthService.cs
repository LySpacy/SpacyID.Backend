namespace SpacyID.Application.Interfaces.Services;

public interface IAuthService
{
    Task<string> SendAuthCode(string email);
    //Task<bool> VerifyAuthCode(string login, string code);
    bool VerifyAuthCode(string login, string code);
}
