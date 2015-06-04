using System;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;
using static Xamarin.Forms.BindableProperty;

namespace Xamarin.FormsBook.Toolkit
{
    public static class BindablePropertyCreator<T,PT> where T:BindableObject
    {
        public static BindableProperty Create(
            Expression<Func<T, PT>> propertyGetter,
            PT defaultValue,
            Updator<T,PT> propertyUpdator)
        {
            return Create<T,PT>(propertyGetter, defaultValue,
                propertyChanged: GetPropertyChanged(propertyUpdator));
        }

        private static PropertyChanged<T,PT> GetPropertyChanged =
            updator =>
                (bo, oldVal, newVal) =>
                    updator ?. Invoke(bo as T)(oldVal, newVal);
    }
}
