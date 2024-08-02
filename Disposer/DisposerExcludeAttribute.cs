﻿using System;
using System.Linq;
using Metalama.Framework.Aspects;

namespace Mefitihe.LamaHerd.Disposer;

[CompileTime]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class DisposerExcludeAttribute : Attribute
{
}