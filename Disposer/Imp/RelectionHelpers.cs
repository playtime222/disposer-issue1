using System;
using System.Collections.Generic;
using System.Linq;
using Metalama.Framework.Aspects;

//using System.CodeDom;

//using DisposingLama.Old;
//using DisposingLama.Old.Actions;

namespace Mefitihe.LamaHerd.Disposer.Imp
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