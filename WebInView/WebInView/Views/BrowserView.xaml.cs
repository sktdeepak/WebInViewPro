using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebInView.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebInView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowserView : ContentPage
    {
        void RefreshPage()
        {

            webView.Reload();
            Device.BeginInvokeOnMainThread(() =>
            {
                browserViewModel.StopRotate();
            });
        }

        private void OnContentLoaded(object sender, EventArgs e)
        {
            browserViewModel.IsRefreshing = false;
        }

        BrowserViewModel browserViewModel = null;

        public BrowserView(string URL)
        {
            browserViewModel = new BrowserViewModel();
            browserViewModel.RefreshCommand = new Command(RefreshPage);
            browserViewModel.URL = URL;
            InitializeComponent();
            this.BindingContext = browserViewModel;
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsVisible = true;
        }

        protected void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsVisible = false;
        }
    }
}