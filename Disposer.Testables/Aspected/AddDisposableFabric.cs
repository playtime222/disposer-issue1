using System;
using System.Linq;
using Metalama.Framework.Fabrics;
using Mefitihe.LamaHerd.Disposer;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Project;

namespace Disposer.Testables.Aspected;

[CompileTime]
internal class AddDisposableFabric : ProjectFabric
{
    public override void AmendProject(IProjectAmender amender)
    {
        amender.SelectMany(x => x.GlobalNamespace.Namespaces.Where(ns => ns.Name.EndsWith(".HandCoded"))
            .SelectMany(y => y.Types))
            .AddAspectIfEligible<DisposableAttribute>();
    }
}