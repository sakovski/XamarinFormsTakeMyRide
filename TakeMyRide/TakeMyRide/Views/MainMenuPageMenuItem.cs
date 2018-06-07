using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeMyRide.Views
{

    public class MainMenuPageMenuItem
    {
        public MainMenuPageMenuItem()
        {
            TargetType = typeof(HomePage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}