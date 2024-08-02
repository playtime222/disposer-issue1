using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

/// <summary>
/// Cast with a fabric
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DisposableAttribute : TypeAspect
{
    public ObjectDisposedExceptionThrowers Throwers { get; set; } = ObjectDisposedExceptionThrowers.Default;

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);
        builder.Outbound.AddThrowIfDisposed(Throwers);
    }

    [Introduce(Name = nameof(IDisposable.Dispose), WhenExists = OverrideStrategy.Override)]
    public void Dispose()
    {
        meta.This.Dispose(true);
        GC.SuppressFinalize(meta.This);
    }

    [Introduce]
    protected bool IsDisposed { get; private set; }

    public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
    {
        base.BuildEligibility(builder);
        builder.MustSatisfy(t => t.TypeKind == TypeKind.Class, t => $"{t.Description} must be a class.");
        builder.MustSatisfy(t => !t.IsStatic, t => $"{t.Description} cannot be static.");
        builder.MustSatisfy(t => t.ImplementedInterfaces.Any(u => u.Is(typeof(IDisposable))), t => $"{t.Description} WIBBLE must directly implement IDisposable.");
        //builder.DeclaringType().MustSatisfy(t => t.BaseType != null && t.BaseType.AllImplementedInterfaces.Contains(typeof(IDisposable)), t => $"{t.Description} base type does not implement IDisposable.");
    }

    [Introduce(Name = "Dispose", IsVirtual = true, Accessibility = Accessibility.Protected, WhenExists = OverrideStrategy.Override)]
    protected void DisposeInner(bool disposing)
    {
        if (disposing)
        {
            //Disposable Instance fields
            var disposableFields = meta.Target.Type.GetDisposableFields();
            meta.InsertComment($"Disposing {disposableFields.Length} fields...");
            foreach (var f in disposableFields)
            {
                meta.InsertComment($"Disposing {f.Field.Name}.");
                meta.InvokeTemplate(f.Template);
            }
            IsDisposed = true;
        }

        meta.InsertComment($"Disposer aspect does not support Finalizers.");
    }
}
