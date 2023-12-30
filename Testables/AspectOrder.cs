using DisposingLama;
using DisposingLama.Old;
using Metalama.Framework.Aspects;

[assembly:AspectOrder(nameof(DisposerAttribute), nameof(DisposerDescendentAttribute))]
