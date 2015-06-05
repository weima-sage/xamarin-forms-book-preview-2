using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace RgbSliders
{
    public partial class RgbSlidersPage : ContentPage
    {
        class BundledColorChoice
        {
            public Label Label;
            string Prefix;
            public Slider Slider;
            public BundledColorChoice(Label label, Slider slider, string prefix)
            {
                Label = label;
                Slider = slider;
                Prefix = prefix;
            }
            public void UpdateValue() => Label.Text = $"{Prefix} {Slider.Value :F2}";
        }

        private IList<BundledColorChoice> Choices{ get; }

        public RgbSlidersPage()
        {
            InitializeComponent();
            redSlider.Value = 128;
            greenSlider.Value = 128;
            blueSlider.Value = 128;

            Choices = new List<BundledColorChoice>
            {
                new BundledColorChoice(redLabel, redSlider, "Red = "),
                new BundledColorChoice(blueLabel, blueSlider, "Blue = "),
                new BundledColorChoice(greenLabel, greenSlider, "Green = ")
            };
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
                Choices ?. SingleOrDefault(b => (b?. Slider == sender))?. UpdateValue();
                boxView.Color = Color.FromRgb((int)redSlider.Value,
                    (int)greenSlider.Value,
                    (int)blueSlider.Value);
        }
    }
}
