using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models;

/// <summary>
/// Опция
/// </summary>
public sealed class Option : BaseModel
{
    public string Name { get; set; } = string.Empty;
}