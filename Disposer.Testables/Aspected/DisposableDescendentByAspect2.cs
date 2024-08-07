﻿using System;
using System.Collections.Generic;
using Mefitihe.LamaHerd.Disposer;

namespace Disposer.Testables.Aspected
{
    [DisposerDescendent]
    public class DisposableDescendentByAspect2 : DisposableDescendentByAspect
    {
        public DisposableDescendentByAspect2(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic) : base(disposable, disposableHashSet, disposableRoDic)
        {
        }
    }
}