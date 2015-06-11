using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    using static Xamarin.FormsBook.Toolkit.BindableObjectHelpers<CheckBox>;
    public partial class CheckBox : ContentView
    {
        public static readonly BindableProperty TextProperty =
            CreateProperty<string>(c => c.Text, default(string), c => c.OnTextChanged);

        public static readonly BindableProperty FontSizeProperty =
            CreateProperty<double>(
                c => c.FontSize,
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                c => c.OnFontSizeChanged );

        public static readonly BindableProperty IsCheckedProperty =
            CreateProperty<bool>(c => c.IsChecked, false, c => c.OnIsCheckedChanged);

        public event EventHandler<bool> CheckedChanged;

        void OnTextChanged(string oldValue, string newValue) => textLabel.Text = newValue;
        void OnFontSizeChanged(double oldValue, double newValue)
        {
            boxLabel.FontSize = newValue;
            textLabel.FontSize = newValue;
        }
        void OnIsCheckedChanged(bool oldValue, bool newValue)
        {
            boxLabel.Text = newValue ? "\u2611" : "\u2610";
            CheckedChanged ?. Invoke( this, newValue);
        }

        public CheckBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        public bool IsChecked
        {
            set { SetValue(IsCheckedProperty, value); }
            get { return (bool)GetValue(IsCheckedProperty); }
        }

        // TapGestureRecognizer handler.
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
    }
}
