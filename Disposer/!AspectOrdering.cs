using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

[assembly:AspectOrder(typeof(ThrowIfDisposed), typeof(DisposableAttribute))]
[assembly: AspectOrder(typeof(DisposerDescendentAttribute), typeof(DisposableAttribute))]