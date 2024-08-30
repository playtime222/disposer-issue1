using System;
using System.Collections.Generic;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp.Actions;

[CompileTime]
public class DisposeActionDictionary : IDisposeAction
{
    public int EvaluationOrder { get; } = 10;
    public TemplateInvocation GetTemplateInvocation(IFieldOrProperty field) => new(nameof(KillIt), this, arguments: new { field });

    public bool CanKill(IFieldOrProperty field)
    {
        if (field.Type is not IGeneric g)
            return false;
        
        if (g.TypeArguments.Count != 2)
            return false;

        if (!g.TypeArguments[1].Is(typeof(IDisposable)))
            return false;

        return
            field.Type.Is(typeof(IDictionary<,>), ConversionKind.TypeDefinition) ||
            field.Type.Is(typeof(IReadOnlyDictionary<,>), ConversionKind.TypeDefinition);
    }

    [Template]
    private void KillIt(IFieldOrProperty field)
    {
        if ((field.Value) != null)
        {
            foreach (var i in field.Value.Values)
                i?.Dispose();
        }
    }
}