using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Gestures;
using Xamarin.Forms;
using ContentView = Xamarin.Forms.ContentView;
using ListView = MR.Gestures.ListView;

namespace GestureSample.Views
{
    public partial class SwipeList : ContentView
    {
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

        public void OnListViewPanning(PanEventArgs e)
        {
            
        }

        public void OnListItemDown(DownUpEventArgs e)
        {
            
        }

        private static void OnMainListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeList) bindable).MainContent.Children.Add((ListView)newValue);
        }

    }
}
