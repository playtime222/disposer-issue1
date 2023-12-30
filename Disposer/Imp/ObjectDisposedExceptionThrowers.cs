using System;
using System.Linq;

namespace Mefitihe.LamaHerd.Disposer.Imp
{
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
}