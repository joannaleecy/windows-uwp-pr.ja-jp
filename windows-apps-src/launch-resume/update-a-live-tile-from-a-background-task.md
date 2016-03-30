---
xxxxx: Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx
xxxxxxxxxxx: Xxx x xxxxxxxxxx xxxx xx xxxxxx xxxx xxx'x xxxx xxxx xxxx xxxxx xxxxxxx.
Xxxxxx.XxxxxxXxxx: Xxxxx
xx.xxxxxxx: YYYYXYXX-XYXX-YXYX-XYYY-YYYYYYXXYXYX
---


# Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)

Xxx x xxxxxxxxxx xxxx xx xxxxxx xxxx xxx'x xxxx xxxx xxxx xxxxx xxxxxxx.

Xxxx'x x xxxxx xxxx xxxxx xxx xx xxx xxxx xxxxx xx xxxx xxxx.

<iframe src="https://hubs-video.ssl.catalog.video.msn.com/embed/afb47cc5-edd3-4262-ae45-8f0e3ae664ac/IA?csid=ux-en-us&MsnPlayerLeadsWith=html&PlaybackMode=Inline&MsnPlayerDisplayShareBar=false&MsnPlayerDisplayInfoButton=false&iframe=true&QualityOverride=HD" width="720" height="405" allowFullScreen="true" frameBorder="0" scrolling="no">Xxx Xxx Xxxxxx - Xxxxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx</iframe>

## Xxxxxx xxx xxxxxxxxxx xxxx xxxxxxx


Xx xxxxxx x xxxx xxxx xxx xxxx xxx, xxx x xxx Xxxxxxx Xxxxxxx Xxxxxxxxx xxxxxxx xx xxxx xxxxxxxx. Xxxx xx x xxxxxxxx xxxxxxxx xxxx xxx XX xxxxx xxx xxxx xx xxx xxxxxxxxxx xxxx x xxxx xxxxxxxx xxxx xxx.

1.  Xx Xxxxxxxx Xxxxxxxx, xxxxx-xxxxx xxx xxxxxxxx, xxxxx xx **Xxx**, xxx xxxxx xx xxx **Xxx Xxxxxxx**.
2.  Xx xxx **Xxx Xxx Xxxxxxx** xxxxxx, xxxxxx xxx **Xxxxxxx Xxxxxxx Xxxxxxxxx** xxxxxxxx xx xxx **Xxxxxx X\# &xx; Xxxxxxx Xxxxx** xxxxxxx.
3.  Xxxx xxx xxxxxxx XxxxxxxxxxXxxxx xxx xxxxx xx xxx **XX**. Xxxxxxxxx Xxxxxx Xxxxxx xxxx xxx xxx xxxxxxx xx xxx xxxxxxxx.
4.  Xx xxx xxxx xxxxxxx, xxx x xxxxxxxxx xx xxx XxxxxxxxxxXxxxx xxxxxxx.

## Xxxxxxxxx xxx xxxxxxxxxx xxxx


Xxxxxxxxx xxx [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794) xxxxxxxxx xx xxxxxx x xxxxx xxxx xxxxxxx xxxx xxx'x xxxx xxxx. Xxxx xxxxxxxxxx xxxx xxxx xx xxx Xxx xxxxxx. Xx xxxx xxxx, xxx xxxx xxxx x xxxxxxxxxxx xxxx xxx xxx XXXX xxxxx. Xx xxxxxxx xxx xxxx xxxx xxxxxxx xxxxxxxxxxx xxxxx xxxxxxxxxxxx xxxx xx xxxxx xxxxxxx, xxx x xxxxxxxx.

1.  Xx Xxxxxxxx Xxxxxxxx, xxxxxx xxx xxxxxxxxxxxxx xxxxxxxxx xxxx, XxxxxY.xx, xx XxxxXxxxXxxxxxxxxxXxxx.xx.
2.  Xx XxxxXxxxXxxxxxxxxxXxxx.xx, xxxxxxx xxx xxxxxxxxxxxxx xxxxxxxxx xxxx xxxx xxx xxxx xxxx xxx xxx **XxxxXxxxXxxxxxxxxxXxxx** xxxxx.
3.  Xx xxx Xxx xxxxxx xxxxxxxxxxxxxx, xxx xxxx xxx xxx **XxxXXXXXxxxXxxx** xxx **XxxxxxXxxx** xxxxxxx.

```cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Added during quickstart
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Web.Syndication;

namespace BackgroundTasks
{
    public sealed class BlogFeedBackgroundTask  : IBackgroundTask
    {
        public async void Run( IBackgroundTaskInstance taskInstance )
        {
            // Get a deferral, to prevent the task from closing prematurely 
            // while asynchronous code is still running.
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            // Download the feed.
            var feed = await GetMSDNBlogFeed();

            // Update the live tile with the feed items.
            UpdateTile( feed );

            // Inform the system that the task is finished.
            deferral.Complete();
        }

        private static async Task<SyndicationFeed> GetMSDNBlogFeed()
        {
            SyndicationFeed feed = null;

            try
            {
                // Create a syndication client that downloads the feed.  
                SyndicationClient client = new SyndicationClient();
                client.BypassCacheOnRetrieve = true;
                client.SetRequestHeader( customHeaderName, customHeaderValue );

                // Download the feed. 
                feed = await client.RetrieveFeedAsync( new Uri( feedUrl ) );
            }
            catch( Exception ex )
            {
                Debug.WriteLine( ex.ToString() );
            }

            return feed;
        }

        private static void UpdateTile( SyndicationFeed feed )
        {
            // Create a tile update manager for the specified syndication feed.
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue( true );
            updater.Clear();

            // Keep track of the number feed items that get tile notifications. 
            int itemCount = 0;

            // Create a tile notification for each feed item.
            foreach( var item in feed.Items )
            {
                XmlDocument tileXml = TileUpdateManager.GetTemplateContent( TileTemplateType.TileWideText03 );

                var title = item.Title;
                string titleText = title.Text == null ? String.Empty : title.Text;
                tileXml.GetElementsByTagName( textElementName )[0].InnerText = titleText;

                // Create a new tile notification. 
                updater.Update( new TileNotification( tileXml ) );

                // Don't create more than 5 notifications.
                if( itemCount++ > 5 ) break;
            }
        }

        // Although most HTTP servers do not require User-Agent header, others will reject the request or return 
        // a different response if this header is missing. Use SetRequestHeader() to add custom headers. 
        static string customHeaderName = "User-Agent";
        static string customHeaderValue = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";

        static string textElementName = "text";
        static string feedUrl = @"http://blogs.msdn.com/b/MainFeed.aspx?Type=BlogsOnly";
    }
}
```

## Xxx xx xxx xxxxxxx xxxxxxxx


Xx xxx xx xxx xxxxxxx xxxxxxxx, xxxx xx xxx xxx x xxx xxxxxxxxxx xxxx xxxxxxxxxxx. Xxx xxx xxxxx xxxxx xxx xxx xxxx xx xxx xxxxx xxxx, xxxxxxxxx xxx xxxxxxxxx.

1.  Xx Xxxxxxxx Xxxxxxxx, xxxx Xxxxxxx.xxxxxxxxxxxx.
2.  Xxxxx xx xxx xxx **Xxxxxxxxxxxx** xxx.
3.  Xxxxx **Xxxxxxxxx Xxxxxxxxxxxx**, xxxxxx **XxxxxxxxxxXxxxx** xxx xxxxx **Xxx**. Xxxxxx Xxxxxx xxxx **XxxxxxxxxxXxxxx** xxxxx **Xxxxxxxxx Xxxxxxxxxxxx**.
4.  Xxxxx **Xxxxxxxxx xxxx xxxxx**, xxxxxx xxxx **Xxxxx** xx xxxxxxx.
5.  Xxxxx **Xxx xxxxxxxx**, xxx xxx xxxxx xxxxx xx **XxxxxxxxxxXxxxx.XxxxXxxxXxxxxxxxxxXxxx**.
6.  Xxxxx xx xxx xxx **Xxxxxxxxxxx XX** xxx.
7.  Xxx **Xxxx xxxxxx xxxxxxxxxxxxx** xx **Xxxxx xxx Xxxx Xxxx**.
8.  Xxx x xxxx xx x YYxYY xxxxx xxxx xx xxx **Xxxxx xxxx** xxxxx.
    **Xxxxxxxxx**  Xxxx xxxx xxxx xxx xxxxxxxxxx xxx xxxxxxxxxxx xxxxxx xxxx.
9.  Xx xxx **Xxxxx xxxx** xxxxx, xxx x xxxx xx x YYxYY xxxxx xxxx.
10. Xx xxx **Xxxx xxxx** xxxxx, xxx x xxxx xx x YYYxYYY xxxxx xxxx.

## Xxxxxxxx xxx xxxxxxxxxx xxxx


Xxxxxx x [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768) xx xxxxxxxx xxxx xxxx.

> **Xxxx**  Xxxxxxxx xx Xxxxxxx Y.Y, xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxx xxxx xx xxxxxxxxxxxx. Xx xxxxx xx xxxxxxxx xx xxx xx xxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxx xxx xxxx xx xxxx xx xxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxx - xxx xxxxxxx, xxx x xxxxxxxxxxx xxxxxxxxx xx xxxxx xxx xxxxxxxxxxxx xxxxxx xxx xxxx xxxxx xxxxxx xxxxxxxxxxxx xxxxx xxxxxxxxx xxxxxxxxx xxxxxx.
 

Xx xxxx xxx'x xxxx xxxx, xxx xxx **XxxxxxxxXxxxxxxxxxXxxx** xxxxxx xxx xxxx xx xx xxx **XxXxxxxxxxxXx** xxxxx xxxxxxx.

```cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Syndication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?LinkID=234238

namespace ContosoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            this.RegisterBackgroundTask();
        }


        private async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if( backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity )
            {
                foreach( var task in BackgroundTaskRegistration.AllTasks )
                {
                    if( task.Value.Name == taskName )
                    {
                        task.Value.Unregister( true );
                    }
                }

                BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = taskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger( new TimeTrigger( 15, false ) );
                var registration = taskBuilder.Register();
            }
        }

        private const string taskName = "BlogFeedBackgroundTask";
        private const string taskEntryPoint = "BackgroundTasks.BlogFeedBackgroundTask";
    }
}
```

## Xxxxx xxx xxxxxxxxxx xxxx


Xx xxxxx xxx xxxxxxxxxx xxxx, xxx x xxxxxxxxxx xx xxx xxxx’x Xxx xxxxxx. Xx xxx **Xxxxx Xxxxxxxx** xxxxxxx, xxxxxx xxxx xxxxxxxxxx xxxx. Xxxx xxxxxx xxx xxxxxx xx xxxx xxx Xxx xxxxxx xxxxxxxxxxx.

1.  Xxx x xxxxxxxxxx xx xxx xxxx’x Xxx xxxxxx.
2.  Xxxxx XY xx xxx **Xxxxx &xx; Xxxxx Xxxxxxxxx** xx xxxxxx xxx xxx xxx xxx.
3.  Xxxxx xxx xxx xxxxxxxx, xxxxxx xxxx xx Xxxxxx Xxxxxx.
4.  Xxxxxx xxxx xxx **Xxxxx Xxxxxxxx** xxxxxxx xx xxxxxxx. Xx'x xx xxx **Xxxx &xx; Xxxxxxxx** xxxx.
5.  Xx xxx **Xxxxx Xxxxxxxx** xxxxxxx, xxxxx xxx **Xxxxxxx** xxxxxxxx xxx xxxxxx **XxxxXxxxXxxxxxxxxxXxxx**.
6.  Xxxxxx Xxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxxxxxxxx.
7.  Xxxxx XY xx xxx **Xxxxx &xx; Xxxxxxxx** xx xxxxxxxx xxxxxxx xxx xxx.
8.  Xxxxx Xxxxx+XY xx xxx **Xxxxx &xx; Xxxx Xxxxxxxxx** xx xxxx xxxxxxxxx.
9.  Xxxxxx xx xxx xxx'x xxxx xx xxx Xxxxx xxxxxx. Xxxxx x xxx xxxxxxx, xxxx xxxxxxxxxxxxx xxxxxx xx xxxx xxx'x xxxx.

## Xxxxxxx xxxxxx


* [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
* [**XxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208622)
* [**XxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208616)
* [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md)
* [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxxx xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465403)

 

 



<!--HONumber=Mar16_HO1-->
