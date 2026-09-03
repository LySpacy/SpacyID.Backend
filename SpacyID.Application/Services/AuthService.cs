using SpacyID.Application.Common;
using SpacyID.Application.Common.Exceptions;
using SpacyID.Application.Interfaces.Senders;
using SpacyID.Application.Interfaces.Services;

namespace SpacyID.Application.Services;

public class AuthService : IAuthService
{
    private readonly IEmailSender _emailSender;
    private readonly Random randomizer = new Random();

    private Dictionary<string, string> _recipientsCodes = new Dictionary<string, string>();

    public AuthService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task<string> SendAuthCode(string recipient)
    {

        if (string.IsNullOrEmpty(recipient))
        {
            throw new AuthException("Получатель не может быть пустым");
        }

        var recipientType = GetRecipientType(recipient);

        if (recipientType == RecipientType.Default)
        {
            throw new AuthException("Неизвестный тип получателя.");
        }

        var randomNumber = randomizer.Next(1000000);
        var code = $"{randomNumber:000000}";

        switch (recipientType)
        {    
            case RecipientType.Phone:
                {
                    throw new AuthException($"Отправка кода по номеру телефона недоступна");

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

    //public Task<bool> VerifyAuthCode(string login, string code)
    //{
    //    throw new AuthException($"Пользователь {login} не запрашивал код.");
    //}
    public bool VerifyAuthCode(string login, string code)
    {  
        if (!_recipientsCodes.ContainsKey(login))
        {
            throw new AuthException($"Пользователь {login} не запрашивал код.");
        }

        var codeHash = Hasher.GetHash(code);

        return _recipientsCodes[login] == codeHash;
    }


    private async Task<string> SendEmail(string email, string code)
    {
        await _emailSender.SendCode(email, code);

        FixedCode(email, code);

        return $"Код отправлен на почтовый адресс {email}.";
    }

    private async Task<string> SendPhone(string phoneNumber, string code)
    {
        //await _phoneSender.SendCode(phoneNumber, code);

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

    private void FixedCode(string recipient, string code)
    {
        var codeHash = Hasher.GetHash(code);

       _recipientsCodes.Add(recipient, codeHash);
    }
}
