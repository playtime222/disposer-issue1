// Copyright © 1984-2024 Playtime222
// Disposer, a component of Sfb4Lafs2022

using System;
using System.Linq;
using Metalama.Framework.Aspects;

namespace Mefitihe.LamaHerd.Disposer;

public class ThrowIfDisposed : OverrideMethodAspect
{
    public override dynamic? OverrideMethod()
    {
        if (meta.This.IsDisposed)
            throw new ObjectDisposedException(meta.This.ToString());

        return meta.Proceed();
    }
}