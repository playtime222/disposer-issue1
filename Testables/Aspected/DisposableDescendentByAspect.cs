using System;
using System.Linq;
using DisposingLama;

namespace Testables.Aspected
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