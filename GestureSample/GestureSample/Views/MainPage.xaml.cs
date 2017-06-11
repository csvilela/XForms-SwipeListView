using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Gestures;
using Xamarin.Forms;

namespace GestureSample.Views
{
	public partial class MainPage
	{
	    public ObservableCollection<Model> Items { get; set; }
		public MainPage()
		{
			InitializeComponent();

            this.Items = new ObservableCollection<Model>();
		    this.MainListView.ItemsSource = Items;
            this.CreateData();
		}

	    private void CreateData()
	    {
	        this.Items.Add(new Model("Item 1"));
	        this.Items.Add(new Model("Item 2"));
	        this.Items.Add(new Model("Item 3"));
	        this.Items.Add(new Model("Item 4"));
	        this.Items.Add(new Model("Item 5"));
	        this.Items.Add(new Model("Item 6"));
        }

	    private void ListItem_OnDown(object sender, DownUpEventArgs e)
	    {
	        this.MainSwipeList.OnItemDown(e);
	    }
	}

    public class Model
    {
        public string Text { get; set; }

        public Model(string text)
        {
            Text = text;
        }
    }
}
