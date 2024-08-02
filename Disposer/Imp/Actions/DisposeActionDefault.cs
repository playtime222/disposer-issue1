using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp.Actions;

[CompileTime]
public class DisposeActionDefault : IDisposeAction
{
    public int EvaluationOrder => 10;
    
    public TemplateInvocation GetTemplateInvocation(IFieldOrProperty field) => new (nameof(KillIt), this, arguments: new {field = field});

    public bool CanKill(IFieldOrProperty f) => f.Type.Is(typeof(IDisposable));

    [Template]
    private void KillIt(IFieldOrProperty field)
    {
        (field.Value)?.Dispose();
    }
}