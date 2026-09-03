using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SpacyID.Application.Common.Validators;

public static partial class Validator
{
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
}
