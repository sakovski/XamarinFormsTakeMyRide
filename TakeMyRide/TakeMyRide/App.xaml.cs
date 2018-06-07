using System;
using TakeMyRide.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TakeMyRide
{
	public partial class App : Application
	{
        static DatabaseService database;

		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

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

        protected override void OnStart ()
		{
            createDB();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void createDB()
        {

        }
	}
}
