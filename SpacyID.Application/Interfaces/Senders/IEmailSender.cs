namespace SpacyID.Application.Interfaces.Senders;

public interface IEmailSender : IAuthSender
{
    Task SendMessage (string recipient, string message);
}