using System.Security.Cryptography;
using System.Text;

namespace SpacyID.Application.Common;

internal static class Hasher
{
    public static string GetHash(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = SHA256.HashData(bytes);

        return Convert.ToHexString(hashBytes);
    }
}
