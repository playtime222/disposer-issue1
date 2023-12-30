using System;
using Disposer.Testables;
using Xunit;


namespace Disposer.Tests
{
    public abstract class AllTheTestsBase
    {
        protected abstract ITestableDisposable Create();

        protected abstract ITestableDisposableDescendent CreateDescendent();

        [Fact]
        public void NoThrow42()
        {
            var target = Create();
            Assert.Equal(42, target.Method42());
        }

        [Fact]
        public void Throw42()
        {
            var target = Create();
            target.Dispose();
            Assert.Throws<ObjectDisposedException>(
                () => target.Method42()
            );
        }

        [Fact]
        public void NoThrow22()
        {
            var target = CreateDescendent();
            Assert.Equal(22, target.DescendentMethod22());
        }

        [Fact]
        public void ThrowDescendent22()
        {
            var target = CreateDescendent();
            target.DescendentMethod22();
            target.Dispose();
            Assert.Throws<ObjectDisposedException>(
                () => target.DescendentMethod22()
            );
        }

        [Fact]
        public void FieldsAreDisposed()
        {
            var target = Create();
            target.Dispose();
            Assert.True(target.Disposable.Disposed);
        }
    }
}