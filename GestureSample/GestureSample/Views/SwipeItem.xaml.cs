using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MR.Gestures;
using Xamarin.Forms;
using ContentView = Xamarin.Forms.ContentView;

namespace GestureSample.Views
{
    public partial class SwipeItem : ContentView
    {
        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create("MainContent", typeof(MR.Gestures.IGestureAwareControl), typeof(SwipeItem),
                new MR.Gestures.Grid(), propertyChanged: OnMainContentChanged);

        public static readonly BindableProperty DismissedCommandProperty =
            BindableProperty.Create("DismissedCommand", typeof(ICommand), typeof(SwipeItem));

        private const double ActionItemSize = 0.2;

        private const uint AnimationSpeed = 300;

        private bool isPanning;

        private double totalPanned;

        public SwipeItem()
        {
            this.InitializeComponent();

            this.ActionItems = new ObservableCollection<SwipeActionItem>();
            this.ActionItems.CollectionChanged += this.ActionItemsCollectionChanged;

            //this.MainContentGrid.PanningCommand = new Command<PanEventArgs>(this.OnPanningCommand);
            //this.MainContentGrid.UpCommand = new Command<DownUpEventArgs>(this.OnUpCommand);
            //this.MainContentGrid.SwipedCommand = new Command<SwipeEventArgs>(this.OnSwipedCommand);
            this.MainContentGrid.DownCommand = new Command<DownUpEventArgs>(this.OnDownCommand);
        }

        private void OnDownCommand(DownUpEventArgs obj)
        {
            this.SetActionItemsSize();  
        }

        public ObservableCollection<SwipeActionItem> ActionItems { get; set; }

        public ICommand DismissedCommand
        {
            get { return (ICommand) this.GetValue(DismissedCommandProperty); }

            set { this.SetValue(DismissedCommandProperty, value); }
        }

        public IGestureAwareControl MainContent
        {
            get { return (IGestureAwareControl) this.GetValue(MainContentProperty); }

            set { this.SetValue(MainContentProperty, value); }
        }

        public double ClosingPoint => this.MainContentGrid.Width * ActionItemSize * -1;

        public double PartialSwipePoint => this.ActionItemsLayout.Children.Sum(item => item.WidthRequest) * -1;

        private static void OnMainContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeItem) bindable).MainContentGrid.Children.Add((View) newValue);
        }

        private void ActionItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;

            foreach (var item in e.NewItems)
            {
                var newItem = (SwipeActionItem) item;
                this.ActionItemsLayout.Children.Add(newItem);
            }
        }

        private void SetActionItemsSize()
        {
            foreach (var child in this.ActionItemsLayout.Children)
            {
                child.WidthRequest = this.MainContentGrid.Width * ActionItemSize;
                child.HeightRequest = this.MainContentGrid.Height;
            }
        }

    }
}