using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TakeMyRide.Data;
using Xamarin.Forms;
using TakeMyRide.Droid;

[assembly: Dependency(typeof(DbFileHelper))]
namespace TakeMyRide.Droid
{
    public class DbFileHelper : IDbFileHelper
    {
        public string getLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}