﻿using System;
using System.Collections.Generic;
using Mefitihe.LamaHerd.Disposer;

namespace Disposer.Testables.Aspected
{
    [Disposable]
    public class DisposableByAspect : ITestableDisposable
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

        public int Method42()
        {
            return 42;
        }

        public int MethodWithNullCheck86(object ion)
        {
            ArgumentNullException.ThrowIfNull(ion);
            //if (ion == null)
            //    throw new ArgumentNullException(nameof(ion));

            return 86;
        }

        public void MethodAspectOrder(object obj)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}