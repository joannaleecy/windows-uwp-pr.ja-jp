---
author: TylerMSFT
title: "バックグラウンド タスクのライブ タイルの更新"
description: "アプリのライブ タイルを新しいコンテンツで更新するためにバックグラウンド タスクを使います。"
Search.SourceType: Video
ms.assetid: 9237A5BD-F9DE-4B8C-B689-601201BA8B9A
ms.sourcegitcommit: 39a012976ee877d8834b63def04e39d847036132
ms.openlocfilehash: 5b11c3d4757d7da0c4c99d8f74a8988babfc26fd

---


# バックグラウンド タスクのライブ タイルの更新


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)

アプリのライブ タイルを新しいコンテンツで更新するためにバックグラウンド タスクを使います。

アプリにライブ タイルを追加する方法について説明するビデオをご覧ください。

<iframe src="https://hubs-video.ssl.catalog.video.msn.com/embed/afb47cc5-edd3-4262-ae45-8f0e3ae664ac/IA?csid=ux-en-us&MsnPlayerLeadsWith=html&PlaybackMode=Inline&MsnPlayerDisplayShareBar=false&MsnPlayerDisplayInfoButton=false&iframe=true&QualityOverride=HD" width="720" height="405" allowFullScreen="true" frameBorder="0" scrolling="no">One Dev Minute - バックグラウンド タスクからのライブ タイルの更新</iframe>

## バックグラウンド タスク プロジェクトを作る


アプリのライブ タイルを有効にするには、新しい Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。 このプロジェクトは個別のアセンブリです。ユーザーがアプリをインストールするとき、OS ではこのプロジェクトがバックグラウンドで読み込まれ、実行されます。

1.  ソリューション エクスプローラーでソリューションを右クリックし、**[追加]** をポイントして、**[新しいプロジェクト]** をクリックまたはタップします。
2.  **[新しいプロジェクトの追加]** ダイアログ ボックスで、**[Visual C#] の [Windows ストア]** セクションにある **[Windows ランタイム コンポーネント]** テンプレートを選びます。
3.  プロジェクトに "BackgroundTasks" という名前を付け、**[OK]** をクリックまたはタップします。 Microsoft Visual Studio によって、新しいプロジェクトがソリューションに追加されます。
4.  メイン プロジェクトで、BackgroundTasks プロジェクトへの参照を追加します。

## バックグラウンド タスクの実装


[
            **IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装して、アプリのライブ タイルを更新するクラスを作ります。 バックグラウンドの作業は、Run メソッドで実行されます。 この場合、タスクによって MSDN ブログの配信フィードが取得されます。 非同期コードの実行中にタスクが途中で終了するのを防ぐには、保留を取得します。

1.  ソリューション エクスプローラーで、自動的に生成されたファイルである Class1.cs の名前を BlogFeedBackgroundTask.cs に変更します。
2.  BlogFeedBackgroundTask.cs を開き、自動的に生成されたコードを、**BlogFeedBackgroundTask** クラスのスタブ コードに置き換えます。
3.  Run メソッドの実装で、**GetMSDNBlogFeed** メソッドと **UpdateTile** のメソッドのコードを追加します。

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

## パッケージ マニフェストの設定


パッケージ マニフェストを設定するには、そのマニフェストを開き、新しいバックグラウンド タスクの宣言を追加します。 タスクのエントリ ポイントを設定します。このエントリ ポイントには、名前空間を含めてクラスの名前を指定します。

1.  ソリューション エクスプローラーで、Package.appxmanifest を開きます。
2.  **[宣言]** タブをタップまたはクリックします。
3.  **[使用可能な宣言]** で、**[BackgroundTasks]** を選び、**[追加]** をクリックします。 Visual Studio で、**[サポートされる宣言]** の下に **[BackgroundTasks]** が追加されます。
4.  **[サポートされるタスクの種類]** で、**[タイマー]** がオンになっていることを確認します。
5.  **[アプリの設定]** で、エントリ ポイントを **[BackgroundTasks.BlogFeedBackgroundTask]** に設定します。
6.  **[アプリケーション UI]** タブをクリックまたはタップします。
7.  **[ロック画面通知]** を **[バッジとタイル テキスト]** に設定します。
8.  **[バッジ ロゴ]** フィールドに、24x24 ピクセルのアイコンへのパスを設定します。
    **重要**  このアイコンには、モノクロで透明のピクセルだけを使ってください。
9.  **[小さいロゴ]** フィールドに、30x30 ピクセルのアイコンへのパスを設定します。
10. **[ワイド ロゴ]** フィールドに、310x150 ピクセルのアイコンへのパスを設定します。

## バックグラウンド タスクの登録


[
            **BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を作って、タスクを登録します。

> **注**  Windows 8.1 以降では、バックグラウンド タスクの登録パラメーターが登録時に検証されます。 いずれかの登録パラメーターが有効でない場合は、エラーが返されます。 アプリは、バックグラウンド タスクの登録が失敗するシナリオを処理できる必要があります。たとえば、条件ステートメントを使って登録エラーを確認し、失敗した登録は別のパラメーター値を使ってやり直してみます。
 

アプリのメイン ページで、**RegisterBackgroundTask** メソッドを追加し、このメソッドを **OnNavigatedTo** イベント ハンドラーで呼び出します。

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

## バックグラウンド タスクのデバッグ


バックグラウンド タスクをデバッグするには、タスクの Run メソッドにブレークポイントを設定します。 **[デバッグの場所]** ツール バーで、バックグラウンド タスクを選びます。 この操作によって、システムで Run メソッドがすぐに呼び出されます。

1.  タスクの Run メソッドにブレークポイントを設定します。
2.  アプリを展開し実行するには、F5 キーを押すか、**[デバッグ]、[デバッグの開始]** の順にタップします。
3.  アプリを起動した後で、Visual Studio に戻ります。
4.  **[デバッグの場所]** ツール バーが表示されていることを確認します。 **[表示] の [ツール バー]** メニューで確認できます。
5.  **[デバッグの場所]** ツール バーで、**[中断]** ドロップダウンをクリックし、**[BlogFeedBackgroundTask]**を選びます。
6.  Visual Studio では、ブレークポイントで実行が中断します。
7.  アプリの実行を続けるには、F5 キーを押すか、**[デバッグ]、[続行]** の順にタップします。
8.  デバッグを停止するには、Shift キーを押しながら F5 キーを押すか、**[デバッグ]、[デバッグの停止]** の順にタップします。
9.  スタート画面にあるアプリのタイルに戻ります。 数秒後、アプリのタイルにタイル通知が表示されます。

## 関連トピック


* [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
* [**TileUpdateManager**](https://msdn.microsoft.com/library/windows/apps/br208622)
* [**TileNotification**](https://msdn.microsoft.com/library/windows/apps/br208616)
* [バックグラウンド タスクによるアプリのサポート](support-your-app-with-background-tasks.md)
* [タイルとバッジのガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh465403)

 

 



<!--HONumber=Jun16_HO4-->


