//using System;
//using System.Linq;
//using Metalama.Framework.Aspects;

//namespace DisposingLama.Old
//{
//    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)] //TODO consider false here

//    public class ThrowIfDisposed : OverrideMethodAspect
//    {
//        //public ObjectDisposedExceptionThrowers Throwers { get; set; } = ObjectDisposedExceptionThrowers.Default;

//        public override dynamic OverrideMethod()
//        {
//            if (meta.This._Disposed)
//                throw new ObjectDisposedException(meta.This.ToString());

//            return meta.Proceed();
//        }

//        //private IEnumerable<MethodInfo> SelectMethods(Type type)
//        //    => type.SelectThrowingMethods(Throwers);

//    }
//}
