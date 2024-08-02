using Mefitihe.LamaHerd.Disposer;
using System;
using System.Collections.Generic;
using System.Text;
using Metalama.Framework.Code;
using System.Linq;
using Metalama.Framework.Aspects;
using Microsoft.VisualBasic;

namespace Disposer.Testables.Aspected
{
    [CompileTime]
    public static class Extensions
    {
        public static IEnumerable<INamedType> Disposable(this ICompilation c)
        {
            return c.AllTypes.Where(y => !y.IsStatic
                    && y.TypeKind is TypeKind.Class or TypeKind.Struct or TypeKind.RecordClass or TypeKind.RecordStruct
                    && y.AllImplementedInterfaces.Contains(typeof(IDisposable))
                    && !y.HasAttribute<DisposerExcludeAttribute>());
        }

        // public static IEnumerable<INamedType> AllDisposable(this ICompilation c)
        // {
        //     return c.AllTypes.Where(y => !y.IsStatic
        //             && y.AllImplementedInterfaces.Contains(typeof(IDisposable))
        //             && !y.HasAttribute<DisposerExcludeAttribute>());
        // }

        public static bool HasAttribute<T>(this INamedType t) => t.Attributes.Any(z => z.Type.Is(typeof(T)));
    }


    //[Disposable]
}
