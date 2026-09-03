using SpacyID.Application.Common;
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

    public async Task<string> SendAuthCode(string recipient)
    {

        if (string.IsNullOrEmpty(recipient))
        {
            throw new ArgumentNullException("Получатель не может быть пустым");
        }

        var recipientType = GetRecipientType(recipient);

        if (recipientType == RecipientType.Default)
        {
            throw new ArgumentNullException("Неизвестный тип получателя.");
        }

        var randomNumber = randomizer.Next(1000000);
        var code = $"{randomNumber:000000}";

        switch (recipientType)
        {    
            case RecipientType.Phone:
                {
                    throw new ArgumentException($"Отправка кода по номеру телефона недоступна");

                    //return await SendPhone(recipient, code);
                }
            case RecipientType.Email:
                {
                    return await SendEmail(recipient, code);
                }
            default:
                return $"Код авторизации не отправлен. Проверьте правильность поля получателя.";
        }

        
    }

    public Task VerifyAuthCode(string login, string code)
    {
        throw new NotImplementedException();
    }


    private async Task<string> SendEmail(string email, string code)
    {
        await _emailSender.SendCode(email, code);

        return $"Код отправлен на почтовый адресс {email}.";
    }

    private async Task<string> SendPhone(string phoneNumber, string code)
    {
        return $"Код отправлен на номер +{phoneNumber}.";
    }
    private static RecipientType GetRecipientType(string recipient)
    {
        if (Validator.IsEmail(recipient))
        {
            return RecipientType.Email;
        }

        if (Validator.IsPhoneNumber(recipient))
        {
            return RecipientType.Phone;
        }

        return RecipientType.Default;
    }
}
