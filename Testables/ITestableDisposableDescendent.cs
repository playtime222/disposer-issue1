using System;
using System.Linq;

namespace Testables
{
    public interface ITestableDisposableDescendent : ITestableDisposable
    {
        int DescendentMethod22();
    }
}