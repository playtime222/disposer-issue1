using Disposer.Testables;
using Disposer.Testables.Aspected;


namespace Disposer.Tests
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