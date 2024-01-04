using System;
using System.Collections.Generic;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp.Actions;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp;

[CompileTime]
public class DisposeTemplateSelector
{
    public static readonly DisposeTemplateSelector Instance = new(new IDisposeAction[] { new DisposeActionDefault(), new DisposeActionEnumerable(), new DisposeActionDictionary() });

    private readonly IEnumerable<IDisposeAction> _Actions;

    public DisposeTemplateSelector(IEnumerable<IDisposeAction> actions)
    {
        _Actions = actions.OrderBy(x => x.EvaluationOrder).ToArray();
    }

    public TemplateInvocation GetTemplate(IField f)
    {
        return _Actions.FirstOrDefault(x => x.CanKill(f))?.GetTemplateInvocation(f);
    }


}