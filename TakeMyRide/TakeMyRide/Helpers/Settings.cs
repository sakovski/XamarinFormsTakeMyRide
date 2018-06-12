using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }


        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string Function
        {
            get
            {
                return AppSettings.GetValueOrDefault("Function", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Function", value);
            }
        }

        public static DateTime SessionTimer
        {
            get
            {
                return AppSettings.GetValueOrDefault("Session", DateTime.Now);
            }
            set
            {
                AppSettings.AddOrUpdateValue("Session", value);
            }
        }


        public static void Clear()
        {
            Username = Password = Function = string.Empty;
            SessionTimer = DateTime.Now;
        }

    }
}
