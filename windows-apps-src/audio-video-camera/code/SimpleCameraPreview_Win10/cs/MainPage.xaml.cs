using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//<SnippetSimpleCameraPreviewUsing>
using Windows.Media.Capture;
using Windows.ApplicationModel;
using System.Threading.Tasks;
//</SnippetSimpleCameraPreviewUsing>

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleCameraPreview_Win10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //<SnippetDeclareMediaCapture>
        MediaCapture mediaCapture;
        //</SnippetDeclareMediaCapture>

        //<SnippetRegisterSuspending>
        public MainPage()
        {
            this.InitializeComponent();

            Application.Current.Suspending += Application_Suspending;
        }
        //</SnippetRegisterSuspending>


        //<SnippetStartPreviewAsync>
        private async Task StartPreviewAsync()
        {
            try
            {
                mediaCapture = new MediaCapture();
                await mediaCapture.InitializeAsync();
                PreviewControl.Source = mediaCapture;
                await mediaCapture.StartPreviewAsync();
            }
            catch (UnauthorizedAccessException)
            {
                // This will be thrown if the user denied access to the camera in privacy settings
                System.Diagnostics.Debug.WriteLine("The app was denied access to the camera");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("MediaCapture initialization failed.");
            }
        }
        //</SnippetStartPreviewAsync>

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await StartPreviewAsync();
        }
        //<SnippetCleanupCameraAsync>
        private async Task CleanupCameraAsync()
        {
            if (mediaCapture != null)
            {
                await mediaCapture.StopPreviewAsync();
                PreviewControl.Source = null;
                mediaCapture.Dispose();
                mediaCapture = null;
            }
        }
        //</SnippetCleanupCameraAsync>

        //<SnippetOnNavigatedFrom>
        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
            await CleanupCameraAsync();
        }
        //</SnippetOnNavigatedFrom>

        //<SnippetSuspendingHandler>
        private async void Application_Suspending(object sender, SuspendingEventArgs e)
        {
            // Handle global application events only if this page is active
            if (Frame.CurrentSourcePageType == typeof(MainPage))
            {
                var deferral = e.SuspendingOperation.GetDeferral();
                await CleanupCameraAsync();
                deferral.Complete();
            }
        }
        //</SnippetSuspendingHandler>
    }
}
