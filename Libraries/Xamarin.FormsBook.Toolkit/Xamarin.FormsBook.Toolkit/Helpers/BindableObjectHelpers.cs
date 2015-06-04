using System;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;

namespace Xamarin.FormsBook.Toolkit
{
    public static class BindableObjectHelpers<T> where T:BindableObject
    {
        public static BindableProperty CreateProperty<PT>
           (Expression<Func<T, PT>> propertyGetter, PT defaultValue,
            Action<T, PT, PT> propertyChanged = null)
        {
            return BindableProperty.Create<T,PT>(propertyGetter, defaultValue,
                         propertyChanged: GetPropertyChanged(propertyChanged));
        }

        public static BindablePropertyKey CreateReadOnlyProperty<PT>
           (Expression<Func<T, PT>> propertyGetter, PT defaultValue) =>
             BindableProperty.CreateReadOnly<T,PT>(propertyGetter, defaultValue);

        private static BindableProperty.BindingPropertyChangedDelegate<PT>
           GetPropertyChanged<PT>(Action<T, PT, PT> changed)
        {
            return changed == null ? DefaultPropertyChanged<PT>()
                                   : (bo, oldVal, newVal) => changed((T)bo, oldVal, newVal);
        }

        private static BindableProperty.BindingPropertyChangedDelegate<PT>
        DefaultPropertyChanged<PT>() =>
              default(BindableProperty.BindingPropertyChangedDelegate<PT>);
    }
}
