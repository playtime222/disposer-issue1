using System.ComponentModel.DataAnnotations;
using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;

[assembly: AspectOrder(typeof(ThrowIfDisposed), typeof(RequiredAttribute))]
