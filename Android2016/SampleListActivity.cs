
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
	//[Activity(Label = "SampleListActivity", MainLauncher = true, Icon = "@drawable/icon")]
	//public class HomeScreen : Activity
	//{

	//	List<MemberVM> tableItems = new List<MemberVM>();
	//	ListView listView;

	//	protected override void OnCreate(Bundle bundle)
	//	{
	//		base.OnCreate(bundle);

	//		SetContentView(Resource.Layout.HomeScreen);

	//		listView = FindViewById<ListView>(Resource.Id.List);

	//		tableItems.Add(new MemberVM() { FirstName = "Vegetables", LastName = "65 items" });
	//		tableItems.Add(new MemberVM() { FirstName = "Fruits", LastName = "17 items" });
	//		tableItems.Add(new MemberVM() { FirstName = "Flower Buds", LastName = "5 items" });
	//		tableItems.Add(new MemberVM() { FirstName = "Legumes", LastName = "33 items" });
	//		tableItems.Add(new MemberVM() { FirstName = "Bulbs", LastName = "18 items" });
	//		tableItems.Add(new MemberVM() { FirstName = "Tubers", LastName = "43 items" });

	//		listView.Adapter = new SampleListAdapter(this, tableItems);
	//	}


	//}
}