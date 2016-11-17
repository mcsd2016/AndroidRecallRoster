
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
		TableLayout TableLayout;
		TableRow MemberRow;
		TextView FirstName;
		TextView LastName;
		Button TelephoneNumber;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			string text = Intent.GetStringExtra("MyData") ?? "Data not available";

			IEnumerable<MemberVM> parsedMemberObjectFromResponse = JsonConvert.DeserializeObject<IList<MemberVM>>(text);

			SetContentView(Resource.Layout.List);

			//this.MemberScrollView = new ScrollView(this);
			//this.MemberHorizontalScrollView = new HorizontalScrollView(this);
			this.TableLayout = FindViewById<TableLayout>(Resource.Id.TableList);
			//this.MemberTableLayout = new TableLayout(this);
			//this.MemberTableLayout.StretchAllColumns.Equals(true);
			//this.MemberTableLayout.LayoutParameters.Equals(new TableLayout.LayoutParams(TableLayout.LayoutParams.MatchParent, TableLayout.LayoutParams.WrapContent));
			//this.MemberTableLayout.WeightSum.Equals(3);

			foreach (MemberVM m in parsedMemberObjectFromResponse)
			{
				this.MemberRow = new TableRow(this);
				this.MemberRow.SetGravity(GravityFlags.Center);
				//this.MemberRow.LayoutParameters.Equals(new TableRow.LayoutParams(TableRow.LayoutParams.FillParent, TableRow.LayoutParams.FillParent, 1.0f));
				//this.MemberRow.SetGravity(GravityFlags.Center);
				//this.MemberRow.SetMinimumHeight(100);
				this.MemberRow.SetBackgroundColor(Android.Graphics.Color.White);

				this.FirstName = new TextView(this);
				this.FirstName.SetPadding(15,0,15,0);
				this.FirstName.SetMinWidth(0);
				this.FirstName.SetTextColor(Android.Graphics.Color.Red);

				this.LastName = new TextView(this);
				this.LastName.SetPadding(15, 0, 15, 0);
				this.LastName.SetMinWidth(0);
				this.LastName.SetTextColor(Android.Graphics.Color.Red);

				this.TelephoneNumber = new Button(this);
				this.TelephoneNumber.SetPadding(15, 0, 15, 0);
				this.TelephoneNumber.SetMinWidth(0);
				this.TelephoneNumber.SetBackgroundColor(Android.Graphics.Color.White);
				this.TelephoneNumber.SetTextColor(Android.Graphics.Color.RoyalBlue);

				this.FirstName.Text = m.FirstName.ToString();
				this.LastName.Text = m.LastName.ToString();
				this.TelephoneNumber.Text = m.TelephoneNumber.ToString();
				this.TelephoneNumber.Click += ((sender, e) => CallAsync(m.TelephoneNumber));

				this.MemberRow.AddView(this.FirstName);
				this.MemberRow.AddView(this.LastName);
				this.MemberRow.AddView(this.TelephoneNumber);

				this.TableLayout.AddView(this.MemberRow);
			}
			//this.MemberHorizontalScrollView.AddView(this.MemberTableLayout);
			//this.MemberScrollView.AddView(this.MemberHorizontalScrollView);
			SetContentView(this.TableLayout);
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
