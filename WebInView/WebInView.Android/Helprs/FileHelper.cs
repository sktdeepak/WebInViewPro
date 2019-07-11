using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WebInView.Droid.Helprs;
using WebInView.Helper;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace WebInView.Droid.Helprs
{
   public class FileHelper : IFileHelper
    {

        Context mContext = Android.App.Application.Context;

        public string GetURL()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            string editor = prefs.GetString("url_value", string.Empty);
            return editor;
        }

        public int SaveURL(string stringURL)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("url_value", stringURL);
            // editor.Commit();    // applies changes synchronously on older APIs
            editor.Apply();
            return 1;
        }
    }
}