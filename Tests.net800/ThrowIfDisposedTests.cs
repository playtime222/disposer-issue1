//using System;
//using Disposer.Testables.Aspected;
//
//

//namespace Disposer.Tests
//{
//
//    public class ThrowIfDisposedTests
//    {
//        [Fact]
//        public void ArgCheckBeforeObjectState_ArgNull()
//        {
//            Assert.Throws<ArgumentNullException>(()=>
//            new ThrowIfDisposedTestable().DoSomething(null));
//        }

//        [Fact]
//        public void ArgCheckBeforeObjectState_ObjDisposed()
//        {
//            var argle = new ThrowIfDisposedTestable();
//            argle.DoSomething(new object());

//            argle.SetDisposed();

//            Assert.Throws<ObjectDisposedException>(() =>
//                argle.DoSomething(new object()));
//        }

//        [Fact]
//        public void ThrowObjectDisposed_Setter()
//        {
//            var argle = new ThrowIfDisposedTestable();
//            argle.SetDisposed();
//            Assert.Throws<ObjectDisposedException>(() =>
//                argle.DontThrowObjectDisposed = true);
//        }

//        [Fact]
//        public void DontThrowObjectDisposed_Getter()
//        {
//            var argle = new ThrowIfDisposedTestable();
//            argle.SetDisposed();
//            var argle2 = argle.DontThrowObjectDisposed;
//        }
//    }
//}
