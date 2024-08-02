using System;
using System.Collections.Generic;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Project;


namespace Mefitihe.LamaHerd.Disposer;

[CompileTime]
public static class Extensions
{
    // public static IEnumerable<INamedType> Disposable(this ICompilation c)
    // {
    //     return NamedTypes(c.AllTypes);
    // }

    // private static IEnumerable<INamedType> NamedTypes(INamedTypeCollection namedTypeCollection)
    // {
    //     return namedTypeCollection.Where(y => !y.IsStatic
    //                                           && y.TypeKind is TypeKind.Class or TypeKind.Struct or TypeKind.RecordClass or TypeKind.RecordStruct
    //                                           && y.AllImplementedInterfaces.Contains(typeof(IDisposable))
    //                                           && !(y.HasAttribute<DisposerExcludeAttribute>() || y.HasAttribute<DisposableAttribute>() || y.HasAttribute<DisposerDescendentAttribute>()));
    // }

    // public static IEnumerable<INamespace> NamespacesStartingWith(this IProject c, string prefix)
    // {
    //     if (string.IsNullOrWhiteSpace(prefix))
    //         throw new ArgumentNullException(nameof(prefix));
    //
    //     return c.Namespaces.Where(x => x.Name.StartsWith(prefix));
    // }

    // public static IEnumerable<INamedType> Disposable(this ICompilation c)
    // {
    //     return c.AllTypes.Where(y => !y.IsStatic
    //             && y.TypeKind is TypeKind.Class or TypeKind.Struct or TypeKind.RecordClass or TypeKind.RecordStruct
    //             && y.AllImplementedInterfaces.Contains(typeof(IDisposable))
    //             && !(y.HasAttribute<DisposerExcludeAttribute>() || y.HasAttribute<DisposableAttribute>() || y.HasAttribute<DisposerDescendentAttribute>()));
    // }

    // public static IEnumerable<INamedType> AllDisposable(this ICompilation c)
    // {
    //     return c.AllTypes.Where(y => !y.IsStatic
    //             && y.AllImplementedInterfaces.Contains(typeof(IDisposable))
    //             && !y.HasAttribute<DisposerExcludeAttribute>());
    // }

    public static bool HasAttribute<T>(this INamedType t) => Enumerable.Any(t.Attributes, z => z.Type.Is(typeof(T)));
}


//[Disposable]