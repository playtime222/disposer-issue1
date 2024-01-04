using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

//using PostSharp.Reflection;

namespace Mefitihe.LamaHerd.Disposer.Imp;

[CompileTime]
public class FieldInfoCompileTime
{
    public FieldInfoCompileTime(IField field)
    {
        Field = field ?? throw new ArgumentNullException();
    }

    public IField Field { get; }
    public bool ExcludedNonPrivate => !Field.Accessibility.HasFlag(Accessibility.Private);
    public bool ExcludedByAttribute { get; set; }
    public bool Excluded => ExcludedNonPrivate || ExcludedByAttribute;
    public int Order { get; set; }
    public TemplateInvocation? Template { get; set; }
    public bool Included => !Excluded && Template != null;
}