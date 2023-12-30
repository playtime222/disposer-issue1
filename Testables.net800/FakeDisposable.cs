using System;

namespace Disposer.Testables
{
    public class FakeDisposable : IDisposable
    {
        public bool Disposed { get; private set; } = false;

        public void Dispose()
        {
            Disposed = true;
        }
    }
}