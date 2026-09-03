using SpacyID.Domain.Common;
using SpacyID.Domain.Models.Auth;

namespace SpacyID.Domain.Models.Users;

/// <summary>
/// Пользователь
/// </summary>
public sealed class User : BaseModel
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    public UserData Data { get; set; }

    /// <summary>
    /// Опции
    /// </summary>
    public List<UserOption> Options { get; set; } = [];

    /// <summary>
    /// Точки входа
    /// </summary>
    public List<EntryPoint> EntryPoints { get; set; } = [];
}
