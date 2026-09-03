using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Users;

/// <summary>
/// Данные пользователя
/// </summary>
public sealed class UserData : BaseModel
{
    /// <summary>
    /// Ключ связи с пользователем
    /// </summary>
    public Guid UserId { get; set; }    

    /// <summary>
    /// Короткое имя (Логин)
    /// </summary>
    public string ShortName { get; set; } = string.Empty;

    /// <summary>
    /// ФИО 
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Электронная почта 
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Номер телефон
    /// </summary>
    public string Phone {  get; set; } = string.Empty;

    /// <summary>
    ///  Дата рождения
    /// </summary>
    public DateTime BirthDay { get; set; } = DateTime.UtcNow;

}
