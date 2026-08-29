using System;
using System.Collections.Generic;
using System.Text;

namespace SpacyID.Domain.Common;

public class BaseModel
{
    public Guid Id { get; }
    public Guid DateCreate { get; }
}
