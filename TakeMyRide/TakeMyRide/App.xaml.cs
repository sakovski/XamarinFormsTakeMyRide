using System;
using TakeMyRide.Data;
using TakeMyRide.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TakeMyRide
{
	public partial class App : Application
	{
        private static FakeDatabaseService database;

		public App ()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

        
        public static FakeDatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new FakeDatabaseService();
                }
                return database;
            }
        }

        /*
        private static DatabaseService database;
        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(DependencyService.Get<IDbFileHelper>().getLocalFilePath("TakeMyRideSQLite.db3"));
                }
                return database;
            }
        }
        */
        protected override void OnStart ()
		{
            
		}

		protected override void OnSleep ()
		{
            Settings.SessionTimer = DateTime.Now;
		}

		protected override void OnResume ()
		{
            if (DateTime.Now - Settings.SessionTimer > TimeSpan.FromMinutes(60))
            {
                Settings.Clear();
                MessagingCenter.Send(this, "Your session expired");
            }
        }
	}
}
