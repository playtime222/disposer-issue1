using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer;

namespace Disposer.Testables.Aspected;

[Disposable]
public class Right : IDisposable
{
#pragma warning disable CS0414 // Field is assigned but its value is never used
    Left _Disposable = null!;
#pragma warning restore CS0414 // Field is assigned but its value is never used
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}