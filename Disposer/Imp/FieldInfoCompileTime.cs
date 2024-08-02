using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

//using PostSharp.Reflection;

namespace Mefitihe.LamaHerd.Disposer.Imp;

[CompileTime]
public class FieldInfoCompileTime
{
    public FieldInfoCompileTime(IFieldOrProperty field)
    {
        Field = field ?? throw new ArgumentNullException(nameof(field));
    }

    public IFieldOrProperty Field { get; }
    private bool ExcludedNonPrivate => Field.Accessibility != Accessibility.Private;
    public bool ExcludedByAttribute { get; set; }
    public bool Excluded => ExcludedNonPrivate || ExcludedByAttribute;
    public int Order { get; set; }
    public TemplateInvocation? Template { get; set; }
    public bool Included => !Excluded && Template != null;
}