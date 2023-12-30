using System;
using System.Linq;
using Testables;
using Testables.Aspected;

namespace TestProject1
{

    public class AspectDispose : AllTheTestsBase
    {
        protected override ITestableDisposable Create()
        {
            return new DisposableByAspect(new FakeDisposable(), null, null);
        }

        protected override ITestableDisposableDescendent CreateDescendent()
        {
            return new DisposableDescendentByAspect(new FakeDisposable(), null, null);
        }
    }
}