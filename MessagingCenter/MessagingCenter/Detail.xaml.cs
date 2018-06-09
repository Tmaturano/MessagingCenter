
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();

            this.button.Clicked += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(this.entry.Text))
                {
                    //Publishing the message
                    Xamarin.Forms.MessagingCenter.Send(new Message
                    {
                        Title = "new item",
                        Value = entry.Text
                    }, "SendItem");

                    entry.Text = string.Empty;
                }
            };

        }
    }
}