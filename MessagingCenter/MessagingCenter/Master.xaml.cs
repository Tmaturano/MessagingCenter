using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        ObservableCollection<string> _items = new ObservableCollection<string>();
        public Master()
        {
            InitializeComponent();

            list.ItemsSource = _items;
            _items.Add("Item 1");
            _items.Add("Item 2");

            //listening the message
            //first parameter means who is subscribing to listen the message
            //second parameter is the name of the Message that was published
            //third parameter is a callback. We define what will happen when we listen to this message
            Xamarin.Forms.MessagingCenter.Subscribe<Message>(this, "SendItem", message =>
            {
                _items.Add(message.Value);
            });            
        }

        //Important to when we subscribe a Message, we have to Unsubscribe to avoid Stackoverflow.
        //In this case, this Page will never disappear, so the OnDisappearing will never me called.
        protected override void OnDisappearing()
        {
            Xamarin.Forms.MessagingCenter.Unsubscribe<Message>(this, "SendItem");
            base.OnDisappearing();
        }
    }
}