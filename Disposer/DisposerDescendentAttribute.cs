using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DisposerDescendentAttribute : TypeAspect
{
    public ObjectDisposedExceptionThrowers Throwers { get; set; } = ObjectDisposedExceptionThrowers.Default;

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);
        builder.Outbound.AddThrowIfDisposed(Throwers);
    }

    public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
    {
        base.BuildEligibility(builder);

        builder.DeclaringType().MustSatisfy(t => !t.IsStatic, t => $"{t.Description} cannot be static.");
        builder.DeclaringType().MustSatisfy(t => !t.ImplementedInterfaces.Contains(typeof(IDisposable)), t => $"{t.Description} cannot directly implement IDisposable.");
        builder.DeclaringType().MustSatisfy(t => t.BaseType != null && t.BaseType.AllImplementedInterfaces.Contains(typeof(IDisposable)), t => $"{t.Description} base type does not implement IDisposable.");
    }

    [Introduce(Accessibility = Accessibility.Protected, 
        //IsVirtual = true, 
        //WhenInherited = OverrideStrategy.Override,
        WhenExists = OverrideStrategy.Override,
        Name ="Dispose")]
    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            //Disposable Instance fields
            var disposableFields = meta.Target.Type.GetDisposableFields();
            meta.InsertComment($"Disposing {disposableFields.Length} fields...");
            foreach (var f in disposableFields)
            {
                meta.InvokeTemplate(f.Template);
            }
        }

        meta.Base.Dispose(disposing);
    }
}