using System;
using System.Linq;

namespace DisposingLama.Old
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