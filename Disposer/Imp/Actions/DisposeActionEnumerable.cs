using System;
using System.Collections.Generic;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp.Actions;

[CompileTime]
public class DisposeActionEnumerable : IDisposeAction
{

    public string Name => GetType().FullName;

    public int EvaluationOrder { get; } = 10;

    //Get an IEnumerable with a T that implements IDisposable
    public bool CanKill(IFieldOrProperty field) => field.Type.Is(typeof(IEnumerable<IDisposable>));
    public TemplateInvocation GetTemplateInvocation(IFieldOrProperty field) => new(nameof(KillIt), this, arguments: new { field = field });

    [Template]
    public void KillIt(IFieldOrProperty field)
    {
        if ((field.Value) != null)
            foreach (IDisposable i in field.Value)
                i?.Dispose();
    }
}