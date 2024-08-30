using System;
using System.Linq;
using Mefitihe.LamaHerd.Disposer.Imp;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Mefitihe.LamaHerd.Disposer;

[CompileTime]
internal static class DisposableExtensions
{
    public static void AddThrowIfDisposed(this IAspectReceiver<INamedType> rx, ObjectDisposedExceptionThrowers throwers)
    {
        //TODO just does the default at the moment.
        rx.SelectMany(t => t.Methods
            // ReSharper disable once RedundantLogicalConditionalExpressionOperand
            .Where(y => true
                        && !y.IsStatic
                        && y.Accessibility != Accessibility.Private
                        && y.Name != nameof(IDisposable.Dispose)
                        && !y.Attributes.Any(x => x.Type.Is(typeof(DisposerExcludeAttribute)))
            ))
            .AddAspectIfEligible<ThrowIfDisposed>();
    }

    public static MemberInfoCompileTime[] GetDisposableFields(this INamedType t)
    {
        return t
            .FieldsAndProperties
            // Exclude compiler generated property backing fields
            .Where(x => x.DeclarationKind == DeclarationKind.Property || (x.DeclarationKind == DeclarationKind.Field && !x.IsImplicitlyDeclared))
            .Where(x => !x.Attributes.Any(y => y.Type.Is(typeof(DisposerExcludeAttribute))))
            .Select(x => new { fop = x, t = DisposeTemplateSelector.Instance.GetTemplate(x) })
            .Where(x => x.t != null)
            .Select(x => new MemberInfoCompileTime(x.fop.Name, GetOrder(x.fop), x.t!))
            .OrderBy(x => x.Order)
            .ThenBy(x => x.Name)
            .ToArray();

        int GetOrder(IFieldOrProperty fop)
        {
            var a = fop.Attributes
                .OfAttributeType(typeof(DisposerOrderAttribute))
                .SingleOrDefault();

            if (a == null)
                return DisposerOrderAttribute.Default;

            return (int)(a.ConstructorArguments[0].Value!);
        }
    }
}