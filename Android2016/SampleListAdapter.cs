using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Android2016
{
	//public class SampleListAdapter : BaseAdapter<MemberVM>
	//{
	//	List<MemberVM> items;
	//	Activity context;

	//	public override int Count
	//	{
	//		get
	//		{
	//			throw new NotImplementedException();
	//		}
	//	}

	//	public override MemberVM this[int position]
	//	{
	//		get
	//		{
	//			throw new NotImplementedException();
	//		}
	//	}

	//	public SampleListAdapter(Activity context, List<MemberVM> items)
	//		: base()
 //       {
	//		this.context = context;
	//		this.items = items;
	//	}

	//	public override View GetView(int position, View convertView, ViewGroup parent)
	//	{
	//		var item = items[position];

	//		View view = convertView;
	//		if (view == null) // no view to re-use, create new
	//			view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
	//		view.FindViewById<TextView>(Resource.Id.Text1).Text = item.FirstName;
	//		view.FindViewById<TextView>(Resource.Id.Text2).Text = item.LastName;

	//		return view;
	//	}

	//	public override long GetItemId(int position)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
}
