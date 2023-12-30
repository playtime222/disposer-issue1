using DisposingLama;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testables.AspectEligibility;


//[Disposer] //Uncomment to see eligibility warning
public partial class Class1
{
}


[Disposer]
public partial class Class2 : IDisposable
{
}


public interface IOneStep : IDisposable { }


[Disposer]
public partial class Class3 : IOneStep
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
