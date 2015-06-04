using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    using static BindableObjectHelpers<CountedLabel>;
    public class CountedLabel : Label
    {
        static readonly BindablePropertyKey WordCountKey =
            CreateReadOnlyProperty<int>(l=>l.WordCount, 0);

        public static readonly BindableProperty WordCountProperty = WordCountKey.BindableProperty;

        public CountedLabel()
        {
            // Set the WordCount property when the Text property changes.
            PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
                {
                    if (args.PropertyName == nameof(Label.Text))
                    {
                        WordCount = Text ?. Split(' ', '-', '\u2014').Length ?? 0;
                    }
                };
        }

        public int WordCount
        {
            private set { SetValue(WordCountKey, value); }
            get { return (int)GetValue(WordCountProperty); }
        }
    }
}
