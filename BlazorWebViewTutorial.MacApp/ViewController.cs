using System;

using AppKit;
using Foundation;

namespace BlazorWebViewTutorial.MacApp
{
    // add usings here
    using BlazorWebView.Mac;
    using BlazorWebView;

    public partial class ViewController : NSViewController
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

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposable != null)
            {
                this.disposable.Dispose();
                this.disposable = null;
            }

            base.Dispose(disposing);
        }
    }
}
