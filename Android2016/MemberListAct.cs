
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
	[Activity(Label = "MemberListAct")]
	public class MemberListAct : Activity
	{
		ListView ListView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


//http://stackoverflow.com/questions/21953965/listview-with-dynamic-strings-coded-in-c-sharp-xamarin-mono

			this.Title = "LIST List OF MEMBERS";
			this.ActionBar.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Black));
			this.TitleColor = Color.ParseColor("#ff424242");

			string text = Intent.GetStringExtra("MyData") ?? "Data not available";
			IEnumerable<MemberVM> parsedMemberObjectFromResponse = JsonConvert.DeserializeObject<IList<MemberVM>>(text);
			SetContentView(Resource.Layout.MemberLayoutList);

			this.ListView = FindViewById<ListView>(Resource.Id.listView1);

			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);

			foreach (MemberVM m in parsedMemberObjectFromResponse)
			{
				adapter.Add(string.Format("{0} {1} {2}", m.FirstName, m.LastName, m.TelephoneNumber));
				// uncomment if you want live update //
				// adapter.NotifyDataSetChanged();
			}
			this.ListView.Adapter = adapter;

		}
	}
}
