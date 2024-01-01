using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

//[assembly:AspectOrder(typeof(DisposerAttribute), typeof(DisposerDescendentAttribute))]
[assembly: AspectOrder(typeof(DisposerDescendentAttribute), typeof(DisposerAttribute))]