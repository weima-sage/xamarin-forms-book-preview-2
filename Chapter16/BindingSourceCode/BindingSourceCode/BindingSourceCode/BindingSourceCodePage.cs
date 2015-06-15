using System;
using Xamarin.Forms;
using System.Linq.Expressions;

namespace BindingSourceCode
{
    public class BindingSourceCodePage : ContentPage
    {
        private Binding GetBinding<T> (T source, Expression< Func<T,object>> func) where T:BindableObject
        {
            Binding binding = Binding.Create<T>(func);
            binding.Source = source;
            return binding;
        }

        public BindingSourceCodePage()
        {

            Label label = new Label
            {
                Text = "Binding Source Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Define Binding object with source object and property.
            Binding binding = GetBinding(slider, src => src.Value);

            // Bind the Opacity property of the Label to the source.
            label.SetBinding(Label.OpacityProperty, binding);

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}
