using System;
using Metalama.Patterns.Contracts;

namespace Disposer.Testables
{
    public interface ITestableDisposable : IDisposable
    {
        FakeDisposable Disposable { get; }
        int Property21 { get; set; }
        int Method42();
        int MethodWithNullCheck86(object ion);
        void MethodAspectOrder([Required]object obj);
    }
}