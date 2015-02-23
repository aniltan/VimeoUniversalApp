using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace VimeoUniversalApp.Views
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
            this.Add(new MenuItem()
            {
                Title = "Home",
                IconSource = "Lead.png",
                TargetType = typeof(HomePageView)
            });

            this.Add(new MenuItem()
            {
                Title = "Recommended",
                IconSource = "Lead.png",
                TargetType = typeof(RecommendedView)
            });

			this.Add (new MenuItem () { 
				Title = "Search", 
				IconSource = "contracts.png", 
				TargetType = typeof(SearchPageView)
			});

            //this.Add (new MenuItem () { 
            //    Title = "Categories", 
            //    IconSource = "Accounts.png",
            //    TargetType = typeof(SearchPageView)
            //});
		}
	}
}