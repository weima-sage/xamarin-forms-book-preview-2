using System;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;

namespace Xamarin.FormsBook.Toolkit
{
    public static class BindableObjectHelpers<T> where T:BindableObject
    {
        public static BindableProperty Create<PT>
           (Expression<Func<T, PT>> propertyGetter, PT defaultValue,
            Action<T, PT, PT> propertyChanged = null)
        {
            return BindableProperty.Create<T,PT>(propertyGetter, defaultValue,
                         propertyChanged: GetPropertyChanged(propertyChanged));
        }

        private static BindableProperty.BindingPropertyChangedDelegate<PT>
           GetPropertyChanged<PT>(Action<T, PT, PT> changed) =>         
             (bo, oldVal, newVal) => changed((T)bo, oldVal, newVal);

    }
}
