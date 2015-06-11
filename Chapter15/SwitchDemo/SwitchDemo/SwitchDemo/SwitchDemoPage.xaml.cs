using System;
using Xamarin.Forms;
using System.Linq;

namespace SwitchDemo
{
    public partial class SwitchDemoPage : ContentPage
    {
        public SwitchDemoPage()
        {
            InitializeComponent();
        }

        private void ToggleAttribute(bool isOn, FontAttributes input) =>
           (isOn ? AddAttributes : RemoveAttributes).Invoke(input);

        private Action<FontAttributes> RemoveAttributes => input => label.FontAttributes &= ~input;
        private Action<FontAttributes> AddAttributes => input => label.FontAttributes |= input;

        void OnItalicSwitchToggled(object sender, ToggledEventArgs args) =>
                                ToggleAttribute(args.Value, FontAttributes.Italic);
        void OnBoldSwitchToggled(object sender, ToggledEventArgs args) =>
                                ToggleAttribute(args.Value, FontAttributes.Bold);
    }
}
