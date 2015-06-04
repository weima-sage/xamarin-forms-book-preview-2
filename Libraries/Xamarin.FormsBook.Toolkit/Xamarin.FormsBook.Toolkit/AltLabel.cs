using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    using static Xamarin.FormsBook.Toolkit.BindableObjectHelpers<AltLabel>;

    public class AltLabel : Label
    {
        public static readonly BindableProperty PointSizeProperty =
            CreateProperty<double>(l => l.PointSize, 8, l => l.OnPointSizeChanged);

        public AltLabel()
        {
            SetLabelFontSize((double)PointSizeProperty.DefaultValue);
        }

        public double PointSize
        {
            set { SetValue(PointSizeProperty, value); }
            get { return (double)GetValue(PointSizeProperty); }
        }

        void OnPointSizeChanged(double oldValue, double newValue) => SetLabelFontSize(newValue);

        void SetLabelFontSize(double pointSize)
        {
            FontSize = Device.OnPlatform(160, 160, 240) * pointSize / 72;
        }
    }
}
