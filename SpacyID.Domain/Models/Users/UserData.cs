using SpacyID.Domain.Common;

namespace SpacyID.Domain.Models.Users;

public class UserData : BaseModel
{
    
}

public sealed class UserDataOption : BaseModel
{
    public required string Name { get; set; } = string.Empty;
    public bool isRequired { get; set; } = false;
}
