using Xamarin.Forms;

namespace MessagingCenter
{
    public partial class MainPage : MasterDetailPage
	{
        private int _items = 0;
		public MainPage()
		{
			InitializeComponent();

            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());

            Xamarin.Forms.MessagingCenter.Subscribe<Message>(this, "SendItem", message =>
            {
                _items++;
                item.Text = $"{_items} items";
            });            
        }
	}
}
