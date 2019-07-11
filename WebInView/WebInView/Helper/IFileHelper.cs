using System;
using System.Collections.Generic;
using System.Text;

namespace WebInView.Helper
{
    public interface IFileHelper
    {

        int SaveURL(string stringURL);
        string GetURL();
    }
}
