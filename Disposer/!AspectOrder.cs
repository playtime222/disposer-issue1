using System;
using System.Collections.Generic;
using System.Text;
using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

[assembly: AspectOrder(AspectOrderDirection.RunTime, typeof(DisposableAttribute), typeof(DisposeCasterAttribute))]
[assembly: AspectOrder(AspectOrderDirection.RunTime, typeof(DisposerDescendentAttribute), typeof(DisposableAttribute))]
[assembly: AspectOrder(AspectOrderDirection.RunTime, typeof(ThrowIfDisposed), typeof(DisposableAttribute))]
[assembly: AspectOrder(AspectOrderDirection.RunTime, typeof(ThrowIfDisposed), typeof(DisposerDescendentAttribute))]
