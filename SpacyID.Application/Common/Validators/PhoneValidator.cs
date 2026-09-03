using System.Text.RegularExpressions;

namespace SpacyID.Application.Common.Validators;

public static partial class Validator
{
    private static readonly Regex PhoneRegex = new Regex(@"^\+?[0-9\s\-()]{7,15}$", RegexOptions.Compiled);

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
