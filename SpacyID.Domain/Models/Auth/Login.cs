using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Auth;

public sealed class LoginTry : BaseModel
{
    public string Login { get; }
    public string CodeHash { get; }
    public DateTime CodeExpiration { get; }

}
