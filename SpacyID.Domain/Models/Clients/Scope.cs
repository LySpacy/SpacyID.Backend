using SpacyID.Domain.Common;
using System.Runtime.CompilerServices;

namespace SpacyID.Domain.Models.Clients;

/// <summary>
/// Разрешение
/// </summary>
public sealed class Scope : BaseModel
{
    /// <summary>
    /// Наименование 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Переопределение сравнения
    /// </summary>
    /// <param name="obj">Объект сравнения</param>
    /// <returns>Результат сравнения</returns>
    public override bool Equals(object obj)
    {
        return Equals(obj as Scope);
    }

    /// <summary>
    /// Переопределение сравнения (внутренняя логика)
    /// </summary>
    /// <param name="other">Сущность другого разрешения</param>
    /// <returns>Результат сравнения</returns>
    private bool Equals(Scope other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return string.Equals(Code, other.Code, StringComparison.OrdinalIgnoreCase);
    }
}