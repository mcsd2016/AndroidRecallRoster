
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android2016
{
	[Activity(Label = "ErrorActivity")]
	public class ErrorActivity : Activity
	{
			//TableLayout TableLayout;
			//TableRow MemberRow;
			//TextView FirstName;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ErrorWarning);
		}
	}
}
