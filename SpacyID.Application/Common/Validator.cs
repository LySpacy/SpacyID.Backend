using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SpacyID.Application.Common;

public static class Validator
{
    private static readonly Regex PhoneRegex = new Regex(@"^\+?[0-9\s\-()]{7,15}$", RegexOptions.Compiled);

    /// <summary>
    /// Проверяет, является ли строка корректным Email
    /// </summary>
    public static bool IsEmail(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        try
        {
            var mailAddress = new MailAddress(input);

            return mailAddress.Address == input;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Проверяет, является ли строка номером телефона
    /// </summary>
    public static bool IsPhoneNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {  
            return false; 
        }

        return PhoneRegex.IsMatch(input);
    }
}
