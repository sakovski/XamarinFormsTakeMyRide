using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Data
{
    public interface IDbFileHelper
    {
        string getLocalFilePath(string filename);
    }
}
