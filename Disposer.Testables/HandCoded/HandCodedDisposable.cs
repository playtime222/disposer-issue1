using Mefitihe.LamaHerd.Disposer;
using System;
using System.Collections.Generic;

namespace Disposer.Testables.HandCoded
{
    [DisposerExclude]
    public class HandCodedDisposable : ITestableDisposable
    {
        private int _Property21 = 21;
        protected bool IsDisposed { get; private set; }

        private readonly FakeDisposable _Disposable;
        private readonly HashSet<IDisposable> _DisposableHashSet;
        private readonly IReadOnlyDictionary<int, IDisposable> _DisposableRoDic;

        public HandCodedDisposable(FakeDisposable disposable, HashSet<IDisposable> disposableHashSet, IReadOnlyDictionary<int, IDisposable> disposableRoDic)
        {
            _Disposable = disposable;
            _DisposableHashSet = disposableHashSet;
            _DisposableRoDic = disposableRoDic;
        }

        public FakeDisposable Disposable => _Disposable;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposable?.Dispose();
                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Property21
        {
            get => _Property21;
            set
            {
                if (IsDisposed)
                    throw new ObjectDisposedException(ToString());

                _Property21 = value; 
            }
        }

        public int Method42()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(ToString());

            return 42;
        }

        public int MethodWithNullCheck86(object ion)
        {
            if (ion == null)
                throw new ArgumentNullException(nameof(ion));

            if (IsDisposed)
                throw new ObjectDisposedException(ToString());

            return 86;
        }

        public void MethodAspectOrder(object obj)
        {
        }
    }
}