using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace BlazorWebViewTutorial.AndroidApp
{
    // add usings here
    using BlazorWebView.Android;
    using BlazorWebView;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private BlazorWebView blazorWebView;

        private IDisposable disposable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.SupportActionBar.Hide();
            this.blazorWebView = (BlazorWebView)this.SupportFragmentManager.FindFragmentById(Resource.Id.blazorWebView);

            // run blazor.
            this.disposable = BlazorWebViewHost.Run<Startup>(this.blazorWebView, "wwwroot/index.html", new AndroidAssetResolver(this.Assets, "wwwroot/index.html").Resolve);
        }

        protected override void OnDestroy()
        {
            if (this.disposable != null)
            {
                this.disposable.Dispose();
                this.disposable = null;
            }
            base.OnDestroy();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}