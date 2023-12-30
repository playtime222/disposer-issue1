using Disposer.Testables;


namespace Disposer.Tests
{

    public class ExplicitDispose : AllTheTestsBase
    {
        protected override ITestableDisposable Create()
        {
            return new Testables.HandCoded.HandCodedDisposable(new FakeDisposable(), null, null);
        }

        protected override ITestableDisposableDescendent CreateDescendent()
        {
            return new Testables.HandCoded.HandCodedDisposableDescendent(new FakeDisposable(), null, null);
        }
    }
}