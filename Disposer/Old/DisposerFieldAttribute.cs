using System;
using System.Linq;
using Metalama.Framework.Aspects;

namespace DisposingLama.Old
{
    [RunTimeOrCompileTime]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    //TODO [MulticastAttributeUsage(MulticastTargets.Field)]
    public class DisposerFieldAttribute : Attribute
    {
        [NonSerialized]
        public static readonly DisposerFieldAttribute Default = new DisposerFieldAttribute();

        public bool Excluded { get; set; }
        public int Order { get; set; } = 1000;
    }
}