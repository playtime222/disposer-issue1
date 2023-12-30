using System;
using System.Collections.Generic;

namespace Disposer.Testables.HandCoded
{
    public class HandCodedDisposableDescendent : HandCodedDisposable, ITestableDisposableDescendent
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }

        public int DescendentMethod22()
        {
            if (Disposed)
                throw new ObjectDisposedException(ToString());

            return 22;
        }

        public HandCodedDisposableDescendent(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic) 
            : base(disposable, disposableHashSet, disposableRoDic)
        {
        }
    }
}