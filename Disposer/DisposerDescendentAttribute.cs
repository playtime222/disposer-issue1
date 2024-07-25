using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

public class DisposerDescendentAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);
        builder.Target.Methods.Where(y => !y.IsStatic && y.Accessibility != Accessibility.Private).ForEach(y => builder.Advice.Override(y, nameof(ThrowIfDisposed)));
    }

    [Template]
    private dynamic? ThrowIfDisposed()
    {
        if (meta.This.IsDisposed)
            throw new ObjectDisposedException(meta.This.ToString());

        return meta.Proceed();
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
            var disposableFields = GetDisposableFields();

            meta.InsertComment($"Disposing {disposableFields.Length} fields...");

            foreach (var f in disposableFields)
            {
                meta.InvokeTemplate(f.Template);
            }
        }

        meta.Base.Dispose(disposing);
    }

    private static FieldInfoCompileTime[] GetDisposableFields()
    {
        return meta.Target.Type.Fields
            .Select(DoField)
            .Where(x => x.Included)
            .OrderBy(x => x.Order)
            .ThenBy(x => x.Field.Name)
            .ToArray();
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

        result.Order = order ?? DisposerOrderAttribute.Default;

        if (result.Excluded)
            return result;

        result.Template = DisposeTemplateSelector.Instance.GetTemplate(result.Field);

        return result;
    }
}