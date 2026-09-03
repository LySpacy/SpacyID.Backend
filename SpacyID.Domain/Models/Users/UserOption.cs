using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Users;

/// <summary>
/// Связь пользователя и его согласие на опцию
/// </summary>
public sealed class UserOption : BaseModel
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор Опции
    /// </summary>
    public Guid OptionId { get; set; }

    /// <summary>
    /// Согласие
    /// </summary>
    public bool IsAgree { get; set; } = false;
}