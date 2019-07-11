using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WebInView.ViewModel
{
   public class BrowserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand refreshCommand;
        public ICommand RefreshCommand
        {
            get { return refreshCommand; }
            set
            {
                if (value == refreshCommand)
                    return;

                refreshCommand = value;
                OnPropertyChanged(nameof(RefreshCommand));
            }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                //note that it's raising the property change event even when the value set is the same
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private string _url;
        public string URL
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(URL));
            }
        }

        public void StopRotate()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsRefreshing = true;
                await Task.Delay(50);
                IsRefreshing = false;
            });
        }

    }
}
