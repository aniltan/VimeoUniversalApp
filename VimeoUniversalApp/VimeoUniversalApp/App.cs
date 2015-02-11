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
            var btn = new Button
            {
                Text = "Welcome to Xamarin Forms!"
            };

            btn.Clicked += btn_Clicked;
           // The root page of your application
            MainPage = new NavigationPage(GetMainPage());
        }

        void btn_Clicked(object sender, EventArgs e)
        {
            VimeoSearchDataProvider dataProvider = new VimeoSearchDataProvider();

            dataProvider.GetSearchResult("test",
                (success, list) =>
                {
                    if (success)
                    { }
                    else
                    { }
                });
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
            return new WelcomePageView();
        }

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
    }
}
