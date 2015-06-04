using System;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;

namespace Xamarin.FormsBook.Toolkit
{
    public static class BindablePropertyCreator<T,PT> where T:BindableObject
    {
        public static BindableProperty Create(
            Expression<Func<T, PT>> propertyGetter,
            PT defaultValue,
            Func<T, Action<PT,PT>> propertyUpdator)
        {
            return BindableProperty.Create<T,PT>(propertyGetter, defaultValue,
                propertyChanged: GetPropertyChanged(propertyUpdator));
        }

        private static BindableProperty.BindingPropertyChangedDelegate<PT>
           GetPropertyChanged(Func<T, Action<PT,PT>> changed)
        {
            return changed == null ? DefaultPropertyChanged()
                                   : (bo, oldVal, newVal) => changed((T)bo)
                                                               (oldVal, newVal);
        }

        private static BindableProperty.BindingPropertyChangedDelegate<PT>
        DefaultPropertyChanged() =>
              default(BindableProperty.BindingPropertyChangedDelegate<PT>);
    }
}
