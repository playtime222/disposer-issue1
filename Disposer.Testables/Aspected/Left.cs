using System;
using System.Linq;

namespace Disposer.Testables.Aspected;

public class Left : IDisposable
{
    public void DoSomething()
    { }

    // ReSharper disable once ArrangeTypeMemberModifiers
#pragma warning disable CS0414 // Field is assigned but its value is never used
    IDisposable _Disposable = null!;
#pragma warning restore CS0414 // Field is assigned but its value is never used
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}