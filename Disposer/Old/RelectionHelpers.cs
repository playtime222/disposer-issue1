using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DisposingLama.Old.Actions;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Playtime222.PostsharpAspects.Disposer.Actions;
using Playtime222.PostsharpAspects.Disposer.Implementation;

//using System.CodeDom;

//using DisposingLama.Old;
//using DisposingLama.Old.Actions;

namespace DisposingLama.Old
{

    [RunTimeOrCompileTime]
    public static class Utility
    {
        public static void ForEach<T>(this IEnumerable<T> arse, Action<T> action)
        {
            foreach (var i in arse)
            {
                action(i);
            }
        }
    }
}