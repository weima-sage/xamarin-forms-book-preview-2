using System;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Xamarin.FormsBook.Toolkit
{
    public static class BindableObjectHelpers<T> where T:BindableObject
    {
        public static BindableProperty CreateProperty<PT>
           (Expression<Func<T, PT>> propertyGetter, PT defaultValue,
            Func<T,Action<PT,PT>> propertyChanged = null) =>
                BindablePropertyCreator<T,PT>.Create(propertyGetter, defaultValue, propertyChanged);

        public static BindablePropertyKey CreateReadOnlyProperty<PT>
           (Expression<Func<T, PT>> propertyGetter, PT defaultValue) =>
                BindableProperty.CreateReadOnly<T,PT>(propertyGetter, defaultValue);

        public static Type TypeOf(string propertyName) =>
            typeof(T).GetRuntimeProperty(propertyName).PropertyType;
    }
}
