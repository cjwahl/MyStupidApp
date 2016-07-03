using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestApp1
{
    [Activity(Label = "Welcome to Shimlar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            Button login = FindViewById<Button>(Resource.Id.login);

            login.Click += delegate { };

            Button newUser = FindViewById<Button>(Resource.Id.newUser);

            newUser.Click += delegate { SetContentView(Resource.Layout.Register);};
        }
    }
}

