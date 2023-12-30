using System;
using System.Linq;
using DisposingLama;

namespace Testables.Aspected
{
    //[DisposerDescendent]
    public partial class DisposableDescendentByAspect2 : DisposableDescendentByAspect
    {
        public DisposableDescendentByAspect2(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic) : base(disposable, disposableHashSet, disposableRoDic)
        {
        }
    }
}