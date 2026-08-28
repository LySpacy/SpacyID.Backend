namespace SpacyID.Application.Interfaces.Services;

public interface IAuthService
{
    Task SendAuthCodeToEmail(string email);

}
