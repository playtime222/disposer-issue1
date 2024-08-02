using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

//using PostSharp.Reflection;

namespace Mefitihe.LamaHerd.Disposer.Imp;

[CompileTime]
public class MemberInfoCompileTime
{
    public MemberInfoCompileTime(string name, int order, TemplateInvocation template)
    {
        Name = name;
        Order = order;
        Template = template;
    }


    public string Name { get; }
    //public bool ExcludedNonPrivate => false; // FieldOrProperty.Accessibility != Accessibility.Private;
    //public bool ExcludedByAttribute { get; set; }
    //public bool Excluded => /*ExcludedNonPrivate ||*/ ExcludedByAttribute;
    public int Order { get; set; }
    public TemplateInvocation Template { get; }
    //public bool Included => !Excluded && Template != null;
}