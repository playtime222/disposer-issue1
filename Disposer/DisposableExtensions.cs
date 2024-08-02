using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer;

[CompileTime]
internal static class DisposableExtensions
{
    public static void AddThrowIfDisposed(this IAspectReceiver<INamedType> rx, ObjectDisposedExceptionThrowers throwers) =>
        rx.SelectMany(t => t.Methods
                .Where(y => !y.IsStatic && y.Accessibility != Accessibility.Private && y.Name != nameof(IDisposable.Dispose)))
            .AddAspectIfEligible<ThrowIfDisposed>();

    // TODO properties!!!!!!
    public static FieldInfoCompileTime[] GetDisposableFields(this INamedType t)
    {
        return t
            .FieldsAndProperties
            //Excludes backing fields cos metalama compiler error
            .Where(x => x.DeclarationKind == DeclarationKind.Property || (x.DeclarationKind == DeclarationKind.Field && !x.IsImplicitlyDeclared))
            .Where(x => x.Type.Is(typeof(IDisposable)))
            .Select(DoField)
            .Where(x => x.Included)
            .OrderBy(x => x.Order)
            .ThenBy(x => x.Field.Name)
            .ToArray();
    }

    private static FieldInfoCompileTime DoField(IFieldOrProperty field)
    {
        var result = new FieldInfoCompileTime(field);

        if (result.Excluded)
            return result;

        result.ExcludedByAttribute = field.Attributes.Any(x => x.Type.Is(typeof(DisposerExcludeAttribute)));

        var order = (int?)field.Attributes
            .OfAttributeType(typeof(DisposerOrderAttribute))
            .SingleOrDefault()?.NamedArguments[nameof(DisposerOrderAttribute.Order)].Value;

        result.Order = /*order ??*/ DisposerOrderAttribute.Default;

        if (result.Excluded)
            return result;

        result.Template = DisposeTemplateSelector.Instance.GetTemplate(result.Field);

        return result;
    }
}