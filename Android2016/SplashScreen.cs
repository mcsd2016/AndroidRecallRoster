using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Android2016
{
	[Activity(Label = "Android2016", NoHistory = true, MainLauncher = true, Theme="@style/Theme.Splash",
	ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			StartActivity(new Intent(Application.Context, typeof(MainActivity)));

		}
	}
}