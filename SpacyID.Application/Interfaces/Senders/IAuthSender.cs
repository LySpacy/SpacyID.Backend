namespace SpacyID.Application.Interfaces.Senders;

public interface IAuthSender
{
    Task SendCode(string recipient, string code);
}
