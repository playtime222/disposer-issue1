using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

public class DisposableAttribute : TypeAspect
{
    public ObjectDisposedExceptionThrowers Throwers { get; set; } = ObjectDisposedExceptionThrowers.Default;

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);
        builder.Outbound.SelectMany(t => t.Methods
            .Where(y => !y.IsStatic && y.Accessibility != Accessibility.Private && y.Name != nameof(IDisposable.Dispose)))
            .AddAspectIfEligible<ThrowIfDisposed>();
    }

    [Introduce(Accessibility = Accessibility.Public, IsVirtual = false, WhenExists = OverrideStrategy.Override, Name = "Dispose")]
    public void DisposeImp()
    {
        Dispose(true);
        GC.SuppressFinalize(meta.This);
    }

    [Introduce]
    protected bool IsDisposed { get; private set; }

    public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
    {
        base.BuildEligibility(builder);
        builder.DeclaringType().MustSatisfy(t => !t.IsStatic, t => $"{t.Description} is static.");
        builder.DeclaringType().MustSatisfy(t => !t.ImplementedInterfaces.Contains(typeof(IDisposable)) || t.ImplementedInterfaces.Any(z => z.AllImplementedInterfaces.Contains(typeof(IDisposable))),
            t => $"{t.Description} must not implement IDisposable.");
    }

    [Introduce(WhenExists = OverrideStrategy.Fail, Name = "Dispose")]
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        { 
            //Disposable Instance fields
            var disposableFields = meta.Target.Type.Fields
                .Select(DoField)
                .Where(x => x.Included)
                .OrderBy(x => x.Order)
                .ThenBy(x => x.Field.Name)
                .ToArray();

            meta.InsertComment($"Disposing {disposableFields.Length} fields...");

            foreach (var f in disposableFields)
            {
                meta.InvokeTemplate(f.Template);
            }
            
            IsDisposed = true;
        }

        meta.InsertComment($"Disposer aspect does not support Finalizers.");
    }

    private static FieldInfoCompileTime DoField(IField field)
    {
        var result = new FieldInfoCompileTime(field);

        if (result.Excluded)
            return result;

        result.ExcludedByAttribute = field.Attributes.Any(x => x.Type.Is(typeof(DisposerExcludeAttribute)));

        var order = (int?)field.Attributes
            .OfAttributeType(typeof(DisposerOrderAttribute))
            .SingleOrDefault()?.NamedArguments[nameof(DisposerOrderAttribute.Order)].Value;

        result.Order =  order ?? DisposerOrderAttribute.Default;

        if (result.Excluded)
            return result;

        result.Template = DisposeTemplateSelector.Instance.GetTemplate(result.Field);

        return result;
    }
}
