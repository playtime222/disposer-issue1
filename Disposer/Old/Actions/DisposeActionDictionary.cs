using System;
using System.Collections.Generic;
using System.Reflection;
using DisposingLama.Old;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Playtime222.PostsharpAspects.Disposer.Implementation;

namespace Playtime222.PostsharpAspects.Disposer.Actions
{
    [CompileTime]
    public class DisposeActionDictionary : IDisposeAction
    {
        public int EvaluationOrder { get; } = 10;
        public TemplateInvocation GetTemplateInvocation(IField field) => new(nameof(KillIt), this, arguments: new { field = field });

        public bool CanKill(IField field)
        {
            var t = field.Type.ToType();

            return t.GenericTypeArguments.Length == 2
                   && (
                       //Anything with a Values property 
                       typeof(Dictionary<,>).IsAssignableFrom(t.GetGenericTypeDefinition())
                       || typeof(IDictionary<,>).IsAssignableFrom(t.GetGenericTypeDefinition())
                       || typeof(IReadOnlyDictionary<,>).IsAssignableFrom(t.GetGenericTypeDefinition())
                   )
                   && typeof(IDisposable).IsAssignableFrom(t.GenericTypeArguments[1]);
        }

        [Template]
        private void KillIt(IField field)
        {
            if ((field.Value) != null)
                foreach (IDisposable i in (field.Value).Values)
                    i?.Dispose();
        }
    }
}