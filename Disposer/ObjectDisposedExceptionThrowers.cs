using System;
using System.Linq;
using Metalama.Framework.Aspects;

namespace Mefitihe.LamaHerd.Disposer;

[CompileTime]
[Flags]
public enum ObjectDisposedExceptionThrowers
{
    None = 0,
    Methods = 1,
    PropertyGetters = 1 << 1,
    PropertySetters = 1 << 2,
    Default = Methods | PropertySetters,
    All = Methods | PropertyGetters | PropertySetters
}