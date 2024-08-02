using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

//[assembly:AspectOrder(typeof(DisposerAttribute), typeof(DisposerDescendentAttribute))]
[assembly: AspectOrder(AspectOrderDirection.RunTime, typeof(DisposerDescendentAttribute), typeof(DisposableAttribute))]