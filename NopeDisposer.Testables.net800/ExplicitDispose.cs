using System;
using System.Linq;
using Testables;
using Testables.HandCoded;

namespace TestProject1
{

    public class ExplicitDispose : AllTheTestsBase
    {
        protected override ITestableDisposable Create()
        {
            return new HandCodedDisposable(new FakeDisposable(), null, null);
        }

        protected override ITestableDisposableDescendent CreateDescendent()
        {
            return new HandCodedDisposableDescendent(new FakeDisposable(), null, null);
        }
    }
}