using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VimeoUniversalApp.Views
{
    public partial class HomeMasterPage : MasterDetailPage
    {
        public HomeMasterPage()
        {
            InitializeComponent();

            this.master.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Detail = new NavigationPage(new SearchPageView());
        }

        void NavigateTo(MenuItem menu)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            IsPresented = false;
        }
    }
}
