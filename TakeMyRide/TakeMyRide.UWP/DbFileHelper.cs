using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Data;
using TakeMyRide.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbFileHelper))]
namespace TakeMyRide.UWP
{
    public class DbFileHelper : IDbFileHelper
    {
        public string getLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
