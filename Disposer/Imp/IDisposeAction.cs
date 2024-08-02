using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer.Imp;

[CompileTime]
public interface IDisposeAction : ITemplateProvider
{
    int EvaluationOrder { get; }
    bool CanKill(IFieldOrProperty field);
    TemplateInvocation GetTemplateInvocation(IFieldOrProperty field);
}