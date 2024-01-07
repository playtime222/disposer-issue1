using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

[assembly:AspectOrder(typeof(ThrowIfDisposed), typeof(DisposerAttribute))]
[assembly: AspectOrder(typeof(DisposerDescendentAttribute), typeof(DisposerAttribute))]