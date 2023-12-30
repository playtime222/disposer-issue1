using System;
using System.Collections.Generic;
using DisposingLama;
using Playtime222.PostsharpAspects.Disposer;

namespace Disposer.Testables.Aspected
{

    [DisposerDescendent]
    public class DisposableDescendentByAspect : DisposableByAspect, ITestableDisposableDescendent
    {
        public DisposableDescendentByAspect(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic) : base(disposable, disposableHashSet, disposableRoDic)
        {
        }

        public int DescendentMethod22()
        {
            return 22;
        }
    }
}