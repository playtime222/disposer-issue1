using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

public class DisposerAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);
        builder.Target.Methods
            .Where(y => !y.IsStatic && y.Accessibility != Accessibility.Private && y.Name != nameof(IDisposable.Dispose))
            .ForEach(y => builder.Advice.Override(y, nameof(this.ThrowIfDisposed)));
    }

    [Template]
    private dynamic? ThrowIfDisposed()
    {
        if (meta.This._Disposed)
            throw new ObjectDisposedException(meta.This.ToString());

        return meta.Proceed();
    }

    [Introduce]
    private bool _Disposed;

    [Introduce(Accessibility = Accessibility.Public, IsVirtual = false, WhenExists = OverrideStrategy.Override, Name = "Dispose")]
    public void Dispose2()
    {
        Dispose(true);
        GC.SuppressFinalize(meta.This);
    }

    public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
    {
        base.BuildEligibility(builder);
        builder.DeclaringType().MustSatisfy(t => !t.IsStatic, t => $"{t.Description} is static.");
        builder.DeclaringType().MustSatisfy(t => t.ImplementedInterfaces.Contains(typeof(IDisposable)) || t.ImplementedInterfaces.Any(z => z.AllImplementedInterfaces.Contains(typeof(IDisposable))),
            t => $"{t.Description} must implement IDisposable.");
    }

    [Introduce]
    private bool _DisposerCanary;


    [Introduce(WhenExists = OverrideStrategy.New, Name = "Dispose")]
    protected virtual void Dispose(bool disposing)
    {
        if (_Disposed)
            return;

        if (!disposing)
            return;

        //Disposable Instance fields
        var disposableFields = meta.Target.Type.Fields
            .Select(DoField)
            .Where(x => x.Included)
            .OrderBy(x => x.Order)
            .ThenBy(x => x.Field.Name)
            .ToArray();

        foreach(var f in disposableFields)
        {
            meta.InvokeTemplate(f.Template);
        }

        _Disposed = true;
    }
    private static FieldInfoCompileTime DoField(IField field)
    {
        var result = new FieldInfoCompileTime(field);

        if (result.Excluded)
            return result;

        var attribute = field.Attributes
            .OfType<DisposerFieldAttribute>()
            .SingleOrDefault() ?? DisposerFieldAttribute.Default;

        result.ExcludedByAttribute = attribute.Excluded;
        result.Order = attribute.Order;

        if (result.Excluded)
            return result;

        result.Template = DisposeTemplateSelector.Instance.GetTemplate(result.Field);

        return result;
    }
}
