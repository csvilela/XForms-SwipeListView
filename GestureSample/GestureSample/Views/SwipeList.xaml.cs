using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MR.Gestures;
using Xamarin.Forms;
using ContentView = Xamarin.Forms.ContentView;
using ListView = MR.Gestures.ListView;

namespace GestureSample.Views
{
    public partial class SwipeList : ContentView
    {
        private SwipeItem selectedControl;

        public static readonly BindableProperty MainListProperty =
            BindableProperty.Create("MainList",
                typeof(ListView),
                typeof(SwipeList),
                new ListView(),
                propertyChanged: OnMainListChanged);

        public ListView MainList
        {
            get
            {
                return (ListView)this.GetValue(MainListProperty);
            }

            set
            {
                this.SetValue(MainListProperty, value);
            }
        }

        public SwipeList()
        {
            InitializeComponent();
            
        }

        public void OnPanning(object sender, PanEventArgs e)
        {
            if (this.selectedControl == null) return;
            this.selectedControl.TranslationX += e.DeltaDistance.X;
        }

        public void OnItemDown(SwipeItem sender, DownUpEventArgs e)
        {
            this.selectedControl = sender;
        }

        private void OnUp(object sender, DownUpEventArgs e)
        {
            if (this.selectedControl == null) return;
            if (this.selectedControl.TranslationX < this.selectedControl.ClosingPoint)
            {
                this.selectedControl.TranslationX = this.selectedControl.Width * -1;
            }
            else
            {
                this.selectedControl.TranslationX = this.selectedControl.PartialSwipePoint;
            }

            this.selectedControl = null;
        }

        private static void OnMainListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeList) bindable).MainContent.Children.Add((ListView)newValue);
        }

    }
}
