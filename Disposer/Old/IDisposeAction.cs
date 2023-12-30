using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System.ComponentModel.Design;

namespace DisposingLama.Old;

[CompileTime]
public interface IDisposeAction : ITemplateProvider
{
    int EvaluationOrder { get; }
    bool CanKill(IField field);
    TemplateInvocation GetTemplateInvocation(IField field);
}