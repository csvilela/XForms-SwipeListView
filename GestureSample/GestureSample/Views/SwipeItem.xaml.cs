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
    public partial class SwipeItem : ContentView, IGestureAwareControl
    {
        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create("MainContent", typeof(MR.Gestures.IGestureAwareControl), typeof(SwipeItem), new MR.Gestures.Grid(), propertyChanged: OnMainContentChanged);

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
            get
            {
                return (ICommand)this.GetValue(DismissedCommandProperty);
            }

            set
            {
                this.SetValue(DismissedCommandProperty, value);
            }
        }

        public IGestureAwareControl MainContent
        {
            get
            {
                return (IGestureAwareControl)this.GetValue(MainContentProperty);
            }

            set
            {
                this.SetValue(MainContentProperty, value);
            }
        }

        public double ClosingPoint => this.MainContentGrid.Width * ActionItemSize * -1;

        public double PartialSwipePoint => this.ActionItemsLayout.Children.Sum(item => item.WidthRequest) * -1;

        private static void OnMainContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SwipeItem)bindable).MainContentGrid.Children.Add((View)newValue);
        }

        private void ActionItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;

            foreach (var item in e.NewItems)
            {
                var newItem = (SwipeActionItem)item;
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

        public GestureHandler GestureHandler
        {
            get { return OuterGrid.GestureHandler; }
        }

        public ICommand DownCommand
        {
            get { return OuterGrid.DownCommand; }
            set { OuterGrid.DownCommand = value; }
        }

        public object DownCommandParameter
        {
            get { return OuterGrid.DownCommandParameter; }
            set { OuterGrid.DownCommandParameter = value; }
        }

        public ICommand UpCommand
        {
            get { return OuterGrid.UpCommand; }
            set { OuterGrid.UpCommand = value; }
        }

        public object UpCommandParameter
        {
            get { return OuterGrid.UpCommandParameter; }
            set { OuterGrid.UpCommandParameter = value; }
        }

        public ICommand TappingCommand
        {
            get { return OuterGrid.TappingCommand; }
            set { OuterGrid.TappingCommand = value; }
        }

        public object TappingCommandParameter
        {
            get { return OuterGrid.TappingCommandParameter; }
            set { OuterGrid.TappingCommandParameter = value; }
        }

        public ICommand TappedCommand
        {
            get { return OuterGrid.TappedCommand; }
            set { OuterGrid.TappedCommand = value; }
        }

        public object TappedCommandParameter
        {
            get { return OuterGrid.TappedCommandParameter; }
            set { OuterGrid.TappedCommandParameter = value; }
        }

        public ICommand DoubleTappedCommand
        {
            get { return OuterGrid.DoubleTappedCommand; }
            set { OuterGrid.DoubleTappedCommand = value; }
        }

        public object DoubleTappedCommandParameter
        {
            get { return OuterGrid.DoubleTappedCommandParameter; }
            set { OuterGrid.DoubleTappedCommandParameter = value; }
        }

        public ICommand LongPressingCommand
        {
            get { return OuterGrid.LongPressingCommand; }
            set { OuterGrid.LongPressingCommand = value; }
        }

        public object LongPressingCommandParameter
        {
            get { return OuterGrid.LongPressingCommandParameter; }
            set { OuterGrid.LongPressingCommandParameter = value; }
        }

        public ICommand LongPressedCommand
        {
            get { return OuterGrid.LongPressedCommand; }
            set { OuterGrid.LongPressedCommand = value; }
        }

        public object LongPressedCommandParameter
        {
            get { return OuterGrid.LongPressedCommandParameter; }
            set { OuterGrid.LongPressedCommandParameter = value; }
        }

        public ICommand PinchingCommand
        {
            get { return OuterGrid.PinchingCommand; }
            set { OuterGrid.PinchingCommand = value; }
        }

        public object PinchingCommandParameter
        {
            get { return OuterGrid.PinchingCommandParameter; }
            set { OuterGrid.PinchingCommandParameter = value; }
        }

        public ICommand PinchedCommand
        {
            get { return OuterGrid.PinchedCommand; }
            set { OuterGrid.PinchedCommand = value; }
        }

        public object PinchedCommandParameter
        {
            get { return OuterGrid.PinchedCommandParameter; }
            set { OuterGrid.PinchedCommandParameter = value; }
        }

        public ICommand PanningCommand
        {
            get { return OuterGrid.PanningCommand; }
            set { OuterGrid.PanningCommand = value; }
        }

        public object PanningCommandParameter
        {
            get { return OuterGrid.PanningCommandParameter; }
            set { OuterGrid.PanningCommandParameter = value; }
        }

        public ICommand PannedCommand
        {
            get { return OuterGrid.PannedCommand; }
            set { OuterGrid.PannedCommand = value; }
        }

        public object PannedCommandParameter
        {
            get { return OuterGrid.PannedCommandParameter; }
            set { OuterGrid.PannedCommandParameter = value; }
        }

        public ICommand SwipedCommand
        {
            get { return OuterGrid.SwipedCommand; }
            set { OuterGrid.SwipedCommand = value; }
        }

        public object SwipedCommandParameter
        {
            get { return OuterGrid.SwipedCommandParameter; }
            set { OuterGrid.SwipedCommandParameter = value; }
        }

        public ICommand RotatingCommand
        {
            get { return OuterGrid.RotatingCommand; }
            set { OuterGrid.RotatingCommand = value; }
        }

        public object RotatingCommandParameter
        {
            get { return OuterGrid.RotatingCommandParameter; }
            set { OuterGrid.RotatingCommandParameter = value; }
        }

        public ICommand RotatedCommand
        {
            get { return OuterGrid.RotatedCommand; }
            set { OuterGrid.RotatedCommand = value; }
        }

        public object RotatedCommandParameter
        {
            get { return OuterGrid.RotatedCommandParameter; }
            set { OuterGrid.RotatedCommandParameter = value; }
        }

        public event EventHandler<DownUpEventArgs> Down
        {
            add { OuterGrid.Down += value; }
            remove { OuterGrid.Down -= value; }
        }

        public event EventHandler<DownUpEventArgs> Up
        {
            add { OuterGrid.Up += value; }
            remove { OuterGrid.Up -= value; }
        }

        public event EventHandler<TapEventArgs> Tapping
        {
            add { OuterGrid.Tapping += value; }
            remove { OuterGrid.Tapping -= value; }
        }

        public event EventHandler<TapEventArgs> Tapped
        {
            add { OuterGrid.Tapped += value; }
            remove { OuterGrid.Tapped -= value; }
        }

        public event EventHandler<TapEventArgs> DoubleTapped
        {
            add { OuterGrid.DoubleTapped += value; }
            remove { OuterGrid.DoubleTapped -= value; }
        }

        public event EventHandler<LongPressEventArgs> LongPressing
        {
            add { OuterGrid.LongPressing += value; }
            remove { OuterGrid.LongPressing -= value; }
        }

        public event EventHandler<LongPressEventArgs> LongPressed
        {
            add { OuterGrid.LongPressed += value; }
            remove { OuterGrid.LongPressed -= value; }
        }

        public event EventHandler<PinchEventArgs> Pinching
        {
            add { OuterGrid.Pinching += value; }
            remove { OuterGrid.Pinching -= value; }
        }

        public event EventHandler<PinchEventArgs> Pinched
        {
            add { OuterGrid.Pinched += value; }
            remove { OuterGrid.Pinched -= value; }
        }

        public event EventHandler<PanEventArgs> Panning
        {
            add { OuterGrid.Panning += value; }
            remove { OuterGrid.Panning -= value; }
        }

        public event EventHandler<PanEventArgs> Panned
        {
            add { OuterGrid.Panned += value; }
            remove { OuterGrid.Panned -= value; }
        }

        public event EventHandler<SwipeEventArgs> Swiped
        {
            add { OuterGrid.Swiped += value; }
            remove { OuterGrid.Swiped -= value; }
        }

        public event EventHandler<RotateEventArgs> Rotating
        {
            add { OuterGrid.Rotating += value; }
            remove { OuterGrid.Rotating -= value; }
        }

        public event EventHandler<RotateEventArgs> Rotated
        {
            add { OuterGrid.Rotated += value; }
            remove { OuterGrid.Rotated -= value; }
        }
    }
}