using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestureSample.Views
{
    public partial class SwipeActionItem : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(SwipeActionItem), null, propertyChanged: OnTextChanged);

        public static readonly BindableProperty IconSourceProperty =
            BindableProperty.Create("IconSource", typeof(string), typeof(SwipeActionItem), null, propertyChanged: OnIconSourceChanged);

        public static readonly BindableProperty ItemColorProperty =
            BindableProperty.Create("ItemColor", typeof(Color), typeof(SwipeActionItem), Color.White, propertyChanged: OnItemColorChanged);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(SwipeActionItem), Color.Black, propertyChanged: OnTextColorChanged);

        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create("TappedCommand", typeof(ICommand), typeof(SwipeActionItem));

        public SwipeActionItem()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public ICommand TappedCommand

        {
            get { return (ICommand)this.GetValue(TappedCommandProperty); }
            set { this.SetValue(TappedCommandProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)this.GetValue(TextColorProperty); }
            set { this.SetValue(TextColorProperty, value); }
        }

        public string IconSource
        {
            get { return (string)this.GetValue(IconSourceProperty); }
            set { this.SetValue(IconSourceProperty, value); }
        }

        public Color ItemColor
        {
            get { return (Color)this.GetValue(ItemColorProperty); }
            set { this.SetValue(ItemColorProperty, value); }
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeActionItem)bindable).TextLabel.Text = (string)newValue;
        }

        private static void OnIconSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeActionItem)bindable).Icon.Source = (string)newValue;
        }

        private static void OnItemColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeActionItem)bindable).MainGrid.BackgroundColor = (Color)newValue;
        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeActionItem)bindable).TextLabel.TextColor = (Color)newValue;
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            this.TappedCommand?.Execute(null);
        }
    }
}
