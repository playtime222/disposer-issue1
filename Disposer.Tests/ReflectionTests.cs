//using System.Linq;
//using Disposer.Testables.Aspected;

//using Playtime222.PostsharpAspects.Disposer.Implementation;
//using Xunit;

//namespace Disposer.Tests
//{

//    public class ReflectionTests
//    {
//        [Fact]
//        public void FindThrowersExcludeGetters()
//        {
//            var methods = typeof(ReflectionTestTarget).SelectThrowingMethods(ObjectDisposedExceptionThrowers.Default);
//            Assert.Equal(5, methods.Count());
//        }

//        [Fact]
//        public void FindThrowersIncludeGetters()
//        {
//            var methods = typeof(ReflectionTestTarget).SelectThrowingMethods(ObjectDisposedExceptionThrowers.Default | ObjectDisposedExceptionThrowers.PropertyGetters);
//            Assert.Equal(6, methods.Count());
//        }

//        [Fact]
//        public void FindGetter()
//        {
//            Assert.True(
//             typeof(ReflectionTestTarget).GetProperty(nameof(ReflectionTestTarget.Getter))
//                 .GetMethod.IsGetter());
//        }

//        [Fact]
//        public void FindSetter()
//        {
//            Assert.False(
//                typeof(ReflectionTestTarget).GetProperty(nameof(ReflectionTestTarget.Setter))
//                    .SetMethod.IsGetter());
//        }

//        [Fact]
//        public void ClassDeclaresIDisposableImplementation()
//        {
//            Assert.True(typeof(DisposableByAspect).IsClassAndImplementsIDisposable());
//            Assert.True(!typeof(DisposableDescendentByAspect).IsClassAndImplementsIDisposable());
//            Assert.True(!typeof(DisposableDescendentByAspect2).IsClassAndImplementsIDisposable());
//            Assert.True(!typeof(Nothing).IsClassAndImplementsIDisposable());
//        }


//        [Fact]
//        public void AncestorDeclaresIDisposableImplementation()
//        {
//            Assert.True(!typeof(Nothing).AncestorDeclaresIDisposableImplementation());
//            Assert.True(!typeof(DisposableByAspect).AncestorDeclaresIDisposableImplementation());
//            Assert.True(typeof(DisposableDescendentByAspect).AncestorDeclaresIDisposableImplementation());
//            Assert.True(typeof(DisposableDescendentByAspect2).AncestorDeclaresIDisposableImplementation());
//        }
//    }
//}