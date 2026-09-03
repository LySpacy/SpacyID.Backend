using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Auth;

/// <summary>
/// Попытка входа
/// </summary>
public sealed class LoginTry : BaseModel
{
    /// <summary>
    /// Логин пользователя, пытающийся войти
    /// </summary>
    public string Login { get; } = string.Empty;

    /// <summary>
    /// Хэш кода, который получил пользователь
    /// </summary>
    public string CodeHash { get; } = string.Empty;

    /// <summary>
    /// Время истечения кода
    /// </summary>
    public DateTime CodeExpiration { get; } 

}
