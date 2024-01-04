using System;
using System.Linq;

//namespace Playtime222.PostsharpAspects.Disposer
//{
//    //FABRIC
//    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
//    //TODO [MulticastAttributeUsage(MulticastTargets.Class)]
//    public class DisposerPolicyAttribute : MulticastAttribute, IAspectProvider
//    {
//        public ObjectDisposedExceptionThrowers Throwers { get; set; } = ObjectDisposedExceptionThrowers.Default;

//        public int AspectPriority { get; set; }

//        //ncrunch: no coverage start
//        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
//        {
//            Message.Write(LogMessageBuilder.CreateProcessingElement(targetElement));
//            return targetElement.AspectInstances(Throwers, AspectPriority);
//        }
//        //ncrunch: no coverage end
//    }
//}
