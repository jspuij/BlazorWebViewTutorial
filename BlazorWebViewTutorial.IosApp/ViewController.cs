using Foundation;
using System;
using UIKit;

namespace BlazorWebViewTutorial.IosApp
{
    // add usings here
    using BlazorWebView.iOS;
    using BlazorWebView;

    public partial class ViewController : UIViewController
    {
        private IDisposable disposable;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // run blazor.
            this.disposable = BlazorWebViewHost.Run<Startup>(this.BlazorWebView, "wwwroot/index.html");
        }

        public override void DidReceiveMemoryWarning()
        {
            if (this.disposable != null)
            {
                this.disposable.Dispose();
                this.disposable = null;
            }

            base.DidReceiveMemoryWarning();
        }
    }
}