using System;
using WebInView.Helper;
using WebInView.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebInView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            try
            {
                string urlVal = DependencyService.Get<IFileHelper>().GetURL();
                if (!string.IsNullOrEmpty(urlVal))
                {
                    MainPage = new BrowserView(urlVal);
                }
                else
                {
                    MainPage = new InputURLAddress();
                }
            }
            catch (Exception ex)
            {
                MainPage = new InputURLAddress();

            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
