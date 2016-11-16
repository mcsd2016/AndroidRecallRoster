
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
using Newtonsoft.Json;

namespace Android2016
{
	[Activity(Label = "MemberListActivity")]
	public class MemberListActivity : Activity
	{
		ScrollView MemberScrollView;
		HorizontalScrollView MemberHorizontalScrollView;
		TableLayout MemberTableLayout;
		TableRow MemberRow;
		TextView FirstName;
		TextView LastName;
		Button TelephoneNumber;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			string text = Intent.GetStringExtra("MyData") ?? "Data not available";

			IEnumerable<MemberVM> parsedMemberObjectFromResponse = JsonConvert.DeserializeObject<IList<MemberVM>>(text);

			SetContentView(Resource.Layout.MembersTable);

			this.MemberScrollView = new ScrollView(this);
			this.MemberHorizontalScrollView = new HorizontalScrollView(this);
			this.MemberTableLayout = new TableLayout(this);

			foreach (MemberVM m in parsedMemberObjectFromResponse)
			{
				this.MemberRow = new TableRow(this);
				this.MemberRow.SetMinimumHeight(225);
				this.MemberRow.SetBackgroundColor(Android.Graphics.Color.White);
				this.FirstName = new TextView(this);

				this.FirstName.SetMinimumHeight(50);
				this.LastName = new TextView(this);
				this.LastName.SetMinimumHeight(50);
				this.TelephoneNumber = new Button(this);

				this.FirstName.Text = m.FirstName.ToString();
				this.LastName.Text = m.LastName.ToString();
				this.TelephoneNumber.Text = m.TelephoneNumber.ToString();
				this.TelephoneNumber.Click += ((sender, e) => CallAsync(m.TelephoneNumber));

				this.MemberRow.AddView(this.FirstName);
				this.MemberRow.AddView(this.LastName);
				this.MemberRow.AddView(this.TelephoneNumber);
				this.MemberTableLayout.AddView(this.MemberRow);
			}
			this.MemberHorizontalScrollView.AddView(this.MemberTableLayout);
			this.MemberScrollView.AddView(this.MemberHorizontalScrollView);
			SetContentView(this.MemberScrollView);
		}


		public void CallAsync(string m)
		{
			string me = m.ToString().Trim();
			string mem = "tel:" + me;
			Intent intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse(mem));
			StartActivity(intent);
	}
	}
}
