using System;
using Xamarin.Forms;

namespace SliderDemo
{
    public partial class SliderDemoPage : ContentPage
    {
        public SliderDemoPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args) =>
            label ?. SetValue(Label.TextProperty, $"Slider = {args.NewValue:F2}");
    }
}
