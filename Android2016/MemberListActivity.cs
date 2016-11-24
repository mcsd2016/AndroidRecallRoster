
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
using Newtonsoft.Json;

namespace Android2016
{
	[Activity(Label = "MemberListActivity")]
	public class MemberListActivity : Activity
	{
		//ScrollView MemberScrollView;
		//HorizontalScrollView MemberHorizontalScrollView;
		//TableLayout MemberTableLayout;
		TableLayout TableLayout;
		TableRow MemberRow;
		TextView FirstName;
		TextView LastName;
		Button TelephoneNumber;
		Switch isCalled;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			this.Title = "LIST OF MEMBERS";
			this.ActionBar.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Black));
			this.TitleColor = Color.ParseColor("#ff424242");
			string text = Intent.GetStringExtra("MyData") ?? "Data not available";
			IEnumerable<MemberVM> parsedMemberObjectFromResponse = JsonConvert.DeserializeObject<IList<MemberVM>>(text);
			SetContentView(Resource.Layout.List);
			//this.MemberScrollView = new ScrollView(this);
			//this.MemberHorizontalScrollView = new HorizontalScrollView(this);
			this.TableLayout = FindViewById<TableLayout>(Resource.Id.TableList);
			//this.MemberTableLayout = new TableLayout(this);

			foreach (MemberVM m in parsedMemberObjectFromResponse)
			{
				this.MemberRow = new TableRow(this);
				this.MemberRow.SetGravity(GravityFlags.Center);
				this.MemberRow.SetBackgroundColor(Android.Graphics.Color.White);

				this.FirstName = new TextView(this);
				this.FirstName.SetPadding(15, 0, 15, 0);
				this.FirstName.SetMinWidth(0);
				this.FirstName.SetTextColor(Android.Graphics.Color.Black);

				this.LastName = new TextView(this);
				this.LastName.SetPadding(15, 0, 15, 0);
				this.LastName.SetMinWidth(0);
				this.LastName.SetTextColor(Android.Graphics.Color.Black);

				this.TelephoneNumber = new Button(this);
				this.TelephoneNumber.SetPadding(15, 0, 15, 0);
				this.TelephoneNumber.SetMinWidth(0);
				this.TelephoneNumber.SetBackgroundColor(Android.Graphics.Color.White);
				this.TelephoneNumber.SetTextColor(Android.Graphics.Color.RoyalBlue);

				this.isCalled = new Switch(this);
				this.isCalled.SetPadding(15, 0, 15, 0);
				this.isCalled.SetMinWidth(0);

				this.FirstName.Text = m.FirstName.ToString();
				this.LastName.Text = m.LastName.ToString();
				this.TelephoneNumber.Text = m.TelephoneNumber.ToString();
				//Chaneg function to CallAsyn to bypass yes no alert
				this.TelephoneNumber.Click += ((sender, e) => PreCallAsync(m.TelephoneNumber));

				this.MemberRow.AddView(this.FirstName);
				this.MemberRow.AddView(this.LastName);
				this.MemberRow.AddView(this.TelephoneNumber);

				this.TableLayout.AddView(this.MemberRow);
			}
			//this.MemberHorizontalScrollView.AddView(this.MemberTableLayout);
			//this.MemberScrollView.AddView(this.MemberHorizontalScrollView);
			SetContentView(this.TableLayout);
		}

		public void PreCallAsync(string m)
		{
			new AlertDialog.Builder(this)
			.SetTitle("Call" + " - " + m)
			.SetMessage("Are You Sure?")
			.SetCancelable(false)
			               .SetPositiveButton("Yes", delegate { CallAsync(m); })
			.SetNegativeButton("No", delegate { })
			.Show();
		}

		public void CallAsync(string m)
		{
			string me = m.ToString().Trim();
			string mem = "tel:" + me;
			Intent intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse(mem));
			StartActivity(intent);
		}

		//http://stackoverflow.com/questions/16660632/how-to-display-messagebox-in-monodroid
		public override void OnBackPressed()
		{
			new AlertDialog.Builder(this)
			.SetTitle("Exit App")
			.SetMessage("Are You Sure?")
			.SetCancelable(false)
			.SetPositiveButton("Yes", delegate { Finish(); })
			.SetNegativeButton("No", delegate { })
			.Show();
		}
		
	}
}
