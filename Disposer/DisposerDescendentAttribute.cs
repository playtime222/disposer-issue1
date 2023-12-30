using System;
using DisposingLama.Old;
using System.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;
using Playtime222.PostsharpAspects.Disposer.Implementation;
using System.Net.NetworkInformation;

namespace DisposingLama
{
    //public abstract class NotAnAspect : TypeAspect
    //{
    //    protected virtual void Dispose(bool disposing) { }
    //}

    public class DisposerDescendentAttribute : TypeAspect //NotAnAspect
    {
        public override void BuildAspect(IAspectBuilder<INamedType> builder)
        {
            base.BuildAspect(builder);
            builder.Target.Methods.Where(y => !y.IsStatic && y.Accessibility != Accessibility.Private).ForEach(y => builder.Advice.Override(y, nameof(this.ThrowIfDisposed)));
        }

        [Template]
        private dynamic? ThrowIfDisposed()
        {
            if (meta.This._Disposed)
                throw new ObjectDisposedException(meta.This.ToString());

            return meta.Proceed();
        }

        [Introduce]
        private bool _Disposed;

        public override void BuildEligibility(IEligibilityBuilder<INamedType> builder)
        {
            base.BuildEligibility(builder);

            builder.DeclaringType().MustSatisfy(t => !t.IsStatic, t => $"{t.Description} is static.");
            builder.DeclaringType().MustSatisfy(t => !t.ImplementedInterfaces.Contains(typeof(IDisposable)), t => $"{t.Description} implements IDisposable.");
            builder.DeclaringType().MustSatisfy(t => t.BaseType != null && t.BaseType.AllImplementedInterfaces.Contains(typeof(IDisposable)), t => $"{t.Description} base type does not implement IDisposable.");
        }

        [Introduce(Accessibility = Accessibility.Protected, 
            IsVirtual = true, 
            //WhenInherited = OverrideStrategy.Override,
            WhenExists = OverrideStrategy.Override,
            Name ="Dispose")]
        protected void Dispose(bool disposing)
        {
            meta.Base.Dispose(disposing);

            if (meta.This._Disposed)
                return;

            if (!disposing)
                return;

            //Disposable Instance fields
            var disposableFields = GetDisposableFields();

            foreach (var f in disposableFields)
            {
                meta.InvokeTemplate(f.Template);
            }

            meta.This._Disposed = true;
        }

        private static FieldInfoCompileTime[] GetDisposableFields()
        {
            return meta.Target.Type.Fields
                .Select(DoField)
                .Where(x => x.Included)
                .OrderBy(x => x.Order)
                .ThenBy(x => x.Field.Name)
                .ToArray();
        }


        private static FieldInfoCompileTime DoField(IField field)
        {
            var result = new FieldInfoCompileTime(field);

            if (result.Excluded)
                return result;

            var attribute = field.Attributes
                .OfType<DisposerFieldAttribute>()
                .SingleOrDefault() ?? DisposerFieldAttribute.Default;

            result.ExcludedByAttribute = attribute.Excluded;
            result.Order = attribute.Order;

            if (result.Excluded)
                return result;

            result.Template = DisposeTemplateSelector.Instance.GetTemplate(result.Field);

            return result;
        }
    }
}
