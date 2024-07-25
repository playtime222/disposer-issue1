using System;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer;

[RunTimeOrCompileTime]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class DisposerOrderAttribute : Attribute
{
    public const int Default = 1000;

    public DisposerOrderAttribute(int order = Default)
    {
        Order = order;
    }

    public int Order { get; set; }
}