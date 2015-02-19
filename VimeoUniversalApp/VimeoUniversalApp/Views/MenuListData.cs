using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace VimeoUniversalApp.Views
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Contracts", 
				IconSource = "contracts.png", 
				TargetType = typeof(SearchPageView)
			});

			this.Add (new MenuItem () { 
				Title = "Leads", 
				IconSource = "Lead.png",
                TargetType = typeof(SearchPageView)
			});

			this.Add (new MenuItem () { 
				Title = "Accounts", 
				IconSource = "Accounts.png",
                TargetType = typeof(SearchPageView)
			});

			this.Add (new MenuItem () {
				Title = "Opportunities",
				IconSource = "Opportunity.png",
                TargetType = typeof(SearchPageView)
			});
		}
	}
}