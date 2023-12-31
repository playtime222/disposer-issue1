﻿using System;
using System.Linq;
using DisposingLama;
using DisposingLama.Old;

namespace Testables.Aspected
{
    [Disposer]
    public partial class DisposableByAspect : ITestableDisposable
    {
        private int _Property21 = 21;
        private readonly FakeDisposable _Disposable;
        private readonly HashSet<IDisposable> _DisposableHashSet;
        private readonly IReadOnlyDictionary<int, IDisposable> _DisposableRoDic;

        public DisposableByAspect(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic)
        {
            _Disposable = disposable;
            _DisposableHashSet = disposableHashSet;
            _DisposableRoDic = disposableRoDic;
            _Disposable = disposable;
        }

        public int Property21
        {
            get => _Property21;
            set
            {
                _Property21 = value;
            }
        }

        public FakeDisposable Disposable => _Disposable;

        //[ThrowIfDisposed]
        public int Method42()
        {
            return 42;
        }

        public int MethodWithNullCheck86(object ion)
        {
            if (ion == null)
                throw new ArgumentNullException(nameof(ion));

            return 86;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}