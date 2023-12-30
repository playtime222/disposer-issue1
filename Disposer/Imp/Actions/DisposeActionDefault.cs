using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp.Actions;

[CompileTime]
public class DisposeActionDefault : IDisposeAction
{
    public int EvaluationOrder => 10;
    
    public TemplateInvocation GetTemplateInvocation(IField field) => new (nameof(KillIt), this, arguments: new {field = field});

    public bool CanKill(IField f) => f.Type.Is(typeof(IDisposable));

    [Template]
    private void KillIt(IField field)
    {
        (field.Value)?.Dispose();
    }
}