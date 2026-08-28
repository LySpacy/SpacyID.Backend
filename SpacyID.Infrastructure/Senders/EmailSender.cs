using Microsoft.Extensions.Options;
using SpacyID.Application.Interfaces.Senders;
using SpacyID.Infrastructure.Configuration;
using System.Net;
using System.Net.Mail;
using SpacyID.Infrastructure.EmailTemplates;

namespace SpacyID.Infrastructure.Senders;

internal class EmailSender : IEmailSender
{

    private readonly MailAddress _senderEmail;
    private readonly SmtpClient _smtp;

    public EmailSender(IOptions<EmailOptions> options)
    {
        var emailOptions = options.Value;

        _senderEmail = new MailAddress(emailOptions.Address, emailOptions.Name);

        _smtp = new SmtpClient(emailOptions.Smtp.Host, emailOptions.Smtp.Port)
        {
            Credentials = new NetworkCredential(emailOptions.Address, emailOptions.Password),
            EnableSsl = true,
        };
    }
    public async Task SendCode(string recipient, string code)
    {
        var recipientMail = new MailAddress(recipient);

        var htmlBody = EmailTemplate.GetTemplateEmailWithCode(code);

        var messageWithCode = new MailMessage(_senderEmail, recipientMail)
        {
            Subject = "Код авторизации",
            Body = htmlBody,
            IsBodyHtml = true,
        };

        await _smtp.SendMailAsync(messageWithCode);
    }

    public Task SendMessage(string recipient, string message)
    {
        throw new NotImplementedException();
    }
}
