using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TakeMyRide.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TakeMyRide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPageMaster : ContentPage
    {
        public ListView ListView;

        public MainMenuPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainMenuPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Settings.Clear();
            Navigation.PopAsync();
        }

        class MainMenuPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuPageMenuItem> MenuItems { get; set; }
            
            public string Username{ get; set; }
            

            public MainMenuPageMasterViewModel()
            {
                switch(Settings.Function)
                {
                    case "Driver":
                        MenuItems = new ObservableCollection<MainMenuPageMenuItem>(new[]
                        {
                            new MainMenuPageMenuItem { Id = 0, Title = "Home", TargetType = typeof(HomePage) },
                            new MainMenuPageMenuItem { Id = 1, Title = "Offer your ride", TargetType = typeof(OfferRidePage) },
                            new MainMenuPageMenuItem { Id = 2, Title = "Your profile", TargetType = typeof(DriverProfilePage) },
                        });
                        break;
                    case "Passenger":
                        MenuItems = new ObservableCollection<MainMenuPageMenuItem>(new[]
                        {
                            new MainMenuPageMenuItem { Id = 0, Title = "Home", TargetType = typeof(HomePage) },
                            new MainMenuPageMenuItem { Id = 1, Title = "Your profile", TargetType = typeof(PassengerProfilePage) },
                        });
                        break;
                    default:
                        break;
                }
                

                Username = "Hello, " + Settings.Username + "!";
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}