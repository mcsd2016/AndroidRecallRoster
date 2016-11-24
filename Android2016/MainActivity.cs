using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using Android.Views;
using Android.Content;
using Org.Json;
using Java.Lang;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Android2016
{

	[Activity(Label = "Android2016", Icon = "@mipmap/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Activity
	{
		Button ButtonLogin;
		TextView TextUserName;
		TextView TextPassWord;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			//Xamarin.Forms.Forms.Init(this, savedInstanceState);
			this.Title = "AFRC RECALL ROSTER";
			this.ActionBar.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Black));
			this.TitleColor = Color.ParseColor("#ff424242");
			SetContentView(Resource.Layout.Main);
			this.ButtonLogin = FindViewById<Button>(Resource.Id.ButtonLogin);
			ButtonLogin.Click += ((sender, e) => downloadAsync());
		}

		public async void downloadAsync()
		{
			ProgressDialog progress = new ProgressDialog(this);
			//progress.SetTitle("Loading");
			progress.SetMessage("Retrieving Users...");
			progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
			progress.Show();

			this.TextUserName = FindViewById<TextView>(Resource.Id.TextUserName);
			this.TextPassWord = FindViewById<TextView>(Resource.Id.TextPassWord);
			var un = this.TextUserName.Text.ToString();
			var pw = this.TextPassWord.Text.ToString();

			using (var Client = new HttpClient())
			{
				var values = new Dictionary<string, string>{{"UserName", un},{"PassWord", pw}};
				var content = new FormUrlEncodedContent(values);
				var url = "https://129.54.2.82/RRAPI/api/users/login/";
				Client.DefaultRequestHeaders.Accept.Clear();
				Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
				var response = await Client.PostAsync(url, content);

				if (response.IsSuccessStatusCode)
				{
					var responseString = await response.Content.ReadAsStringAsync();
					var MemberListActivity = new Intent(this, typeof(MemberListActivity));
					MemberListActivity.PutExtra("MyData", responseString);
					StartActivity(MemberListActivity);
					//To Make Main Page not able to be history if true but still if false
					Finish();
				}
				else
				{
					//Disabling Activity and making Pop up show error
					//var ErrorActivity = new Intent(this, typeof(ErrorActivity));
					//StartActivity(ErrorActivity);


			new AlertDialog.Builder(this)
			.SetTitle("Invalid Credentials")
			.SetMessage("Want to retry?")
			.SetCancelable(false)
			.SetPositiveButton("Yes", delegate { })
			.SetNegativeButton("No", delegate { Finish(); })
			.Show();
					
				}
				progress.Dismiss();
			}
		}
	}
}

