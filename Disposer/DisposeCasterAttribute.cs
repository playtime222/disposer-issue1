using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;

namespace Mefitihe.LamaHerd.Disposer;

public class DisposeCasterAttribute : TypeAspect
{
    public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
    {
        base.BuildEligibility(builder);
        builder.MustNotHaveAspectOfType(typeof(DisposeCasterAttribute));
        builder.MustNotHaveAspectOfType(typeof(DisposableAttribute));
        builder.MustNotHaveAspectOfType(typeof(DisposerDescendentAttribute));
        builder.MustNotBeStatic();
        builder.MustNotBeInterface();
        builder.MustSatisfy(t => !t.Attributes.Any(x => x.Type.Is(typeof(DisposerExcludeAttribute))), t => $"{t.Description} was excluded.");
    }

    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        base.BuildAspect(builder);

        var implementsDisposeDirectly = builder.Target.ImplementedInterfaces.Contains(typeof(IDisposable));
        if (implementsDisposeDirectly)
            builder.Outbound.AddAspectIfEligible<DisposableAttribute>();

        var implementsDispose = builder.Target.AllImplementedInterfaces.Contains(typeof(IDisposable));
        if (implementsDispose)
            builder.Outbound.AddAspectIfEligible<DisposerDescendentAttribute>();
    }
}