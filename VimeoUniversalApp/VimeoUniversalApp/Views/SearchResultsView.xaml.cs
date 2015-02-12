using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.ViewModels;
using Xamarin.Forms;
using VimeoUniversalApp.Models;

namespace VimeoUniversalApp.Views
{
    public partial class SearchResultsView : ContentPage
    {
        public SearchResultsView(string Query)
        {
            InitializeComponent();

            this.ViewModel.Navigation = this.Navigation;
            this.BindingContext = this.ViewModel;
            this.ViewModel.LoadList(Query);
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        SearchResultsViewModel ViewModel { get { return App.Locator.GetInstance<SearchResultsViewModel>(); } }

//        // Handle item selection for editing and deleting.
// listView.ItemSelected += (sender, args) =>
// {
// if (args.SelectedItem != null)
// {
// // Deselect the item.
//listView.SelectedItem = null;
// // Navigate to NotePage.
// Note note = (Note)args.SelectedItem;
// this.Navigation.PushAsync(new NotePage(note, true));
// }
// };
    }
}
