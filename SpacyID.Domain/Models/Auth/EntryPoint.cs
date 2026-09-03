using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Auth;

/// <summary>
/// Точка входа пользователя
/// </summary>
public sealed class EntryPoint
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Адресс входа
    /// </summary>
    public string Ip { get; init; } = string.Empty;

    /// <summary>
    /// Время входа
    /// </summary>
    public DateTime Date { get; } = DateTime.UtcNow;
}
