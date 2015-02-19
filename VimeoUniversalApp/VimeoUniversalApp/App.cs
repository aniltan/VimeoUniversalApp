using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VimeoUniversalApp.Service.Providers;
using VimeoUniversalApp.ViewModels;
using VimeoUniversalApp.Views;
using Xamarin.Forms;

namespace VimeoUniversalApp
{
    public class App : Application
    {
        public App()
        {
           // The root page of your application
            //MainPage = new NavigationPage(GetMainPage()) { BarBackgroundColor = Color.FromHex("3498db")};
            MainPage = GetMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static Page GetMainPage()
        {
            var rootPage = new HomeMasterPage();

            Navigation = rootPage.Navigation;

            return rootPage;
        }

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public static INavigation Navigation { get; private set; }
    }
}
