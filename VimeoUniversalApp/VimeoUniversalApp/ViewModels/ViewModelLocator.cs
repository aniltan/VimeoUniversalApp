/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:VimeoUniversalApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using AdvancedTimer.Forms.Plugin.Abstractions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using VimeoUniversalApp.Service.Providers;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // add the viewmodels
            SimpleIoc.Default.Register<WelcomePageViewModel>();
            SimpleIoc.Default.Register<SearchPageViewModel>();

            // add the service
            SimpleIoc.Default.Register<VimeoSearchDataProvider>();
        }

        public T GetInstance<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }
    }
}