
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
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

			this.Title = "ERROR PAGE";
			this.ActionBar.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Black));
			this.TitleColor = Color.ParseColor("#ff424242");

			SetContentView(Resource.Layout.ErrorWarning);
		}
	}
}
