using System;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Fabrics;

namespace Mefitihe.LamaHerd.Disposer;


//TODO Exclude if attribute already present
//TODO Exclude namespaces
//TODO 
public class DisposePolicy : ProjectFabric
{
    public DisposePolicySettings Settings { get; set; }

    public override void AmendProject(IProjectAmender amender)
    {
        var receivers = amender.Outbound.SelectMany(x => x.GlobalNamespace.DescendantsAndSelf().SelectMany(n => n.Types));
        receivers.AddAspectIfEligible<DisposerAttribute>();

    }
}

//Something, something namespaces 
[CompileTime]
public class DisposePolicySettings
{

}