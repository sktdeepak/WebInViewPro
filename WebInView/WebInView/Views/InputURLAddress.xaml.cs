using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInView.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebInView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputURLAddress : ContentPage
    {
        public InputURLAddress()
        {
            InitializeComponent();
            entryURL.Text = "https://";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string url = entryURL.Text;
            if (!string.IsNullOrEmpty(url))
            {
                int val = DependencyService.Get<IFileHelper>().SaveURL(url.Trim());
                if (val == 1)
                {
                    DisplayAlert("Your URL", url.Trim(), "OK");
                    App.Current.MainPage = new BrowserView(url.Trim());
                }
            }
            else
                DisplayAlert("", "Please enter URL", "OK");
        }
    }
}