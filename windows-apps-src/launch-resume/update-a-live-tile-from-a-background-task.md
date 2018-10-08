---
author: TylerMSFT
title: バックグラウンド タスクによるライブ タイルの更新
description: アプリのライブ タイルを新しいコンテンツで更新するには、バックグラウンド タスクを使います。
Search.SourceType: Video
ms.assetid: 9237A5BD-F9DE-4B8C-B689-601201BA8B9A
ms.author: twhitney
ms.date: 01/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: 3042a6f52453fa4a4c50334b605f637f1dec92aa
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4418856"
---
# <a name="update-a-live-tile-from-a-background-task"></a><span data-ttu-id="2b264-104">バックグラウンド タスクによるライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="2b264-104">Update a live tile from a background task</span></span>

**<span data-ttu-id="2b264-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="2b264-105">Important APIs</span></span>**

-   [**<span data-ttu-id="2b264-106">IBackgroundTask</span><span class="sxs-lookup"><span data-stu-id="2b264-106">IBackgroundTask</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**<span data-ttu-id="2b264-107">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="2b264-107">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)

<span data-ttu-id="2b264-108">アプリのライブ タイルを新しいコンテンツで更新するには、バックグラウンド タスクを使います。</span><span class="sxs-lookup"><span data-stu-id="2b264-108">Use a background task to update your app's live tile with fresh content.</span></span>

<span data-ttu-id="2b264-109">アプリにライブ タイルを追加する方法について説明するビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2b264-109">Here's a video that shows how to add live tiles to your apps.</span></span>

<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Updating-a-live-tile-from-a-background-task/player" width="720" height="405" allowFullScreen="true" frameBorder="0"></iframe>

## <a name="create-the-background-task-project"></a><span data-ttu-id="2b264-110">バックグラウンド タスク プロジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="2b264-110">Create the background task project</span></span>  

<span data-ttu-id="2b264-111">アプリのライブ タイルを有効にするには、新しい Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="2b264-111">To enable a live tile for your app, add a new Windows Runtime Component project to your solution.</span></span> <span data-ttu-id="2b264-112">このプロジェクトは個別のアセンブリです。ユーザーがアプリをインストールするとき、OS ではこのプロジェクトがバックグラウンドで読み込まれ、実行されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-112">This is a separate assembly that the OS loads and runs in the background when a user installs your app.</span></span>

1.  <span data-ttu-id="2b264-113">ソリューション エクスプローラーでソリューションを右クリックし、**[追加]**、**[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="2b264-113">In Solution Explorer, right-click the solution, click **Add**, and then click **New Project**.</span></span>
2.  <span data-ttu-id="2b264-114">**[新しいプロジェクトの追加]** ダイアログ ボックスで、**[インストール済み] &gt; [他の言語] &gt; [Visual C#] &gt; [Windows ユニバーサル]** セクションで、**[Windows ランタイム コンポーネント]** テンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="2b264-114">In the **Add New Project** dialog, select the **Windows Runtime Component** template in the **Installed &gt; Other Languages &gt; Visual C# &gt; Windows Universal** section.</span></span>
3.  <span data-ttu-id="2b264-115">プロジェクトに BackgroundTasks という名前を付け、**[OK]** をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="2b264-115">Name the project BackgroundTasks and click or tap **OK**.</span></span> <span data-ttu-id="2b264-116">Microsoft Visual Studio によって、新しいプロジェクトがソリューションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-116">Microsoft Visual Studio adds the new project to the solution.</span></span>
4.  <span data-ttu-id="2b264-117">メイン プロジェクトで、BackgroundTasks プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2b264-117">In the main project, add a reference to the BackgroundTasks project.</span></span>

## <a name="implement-the-background-task"></a><span data-ttu-id="2b264-118">バックグラウンド タスクの実装</span><span class="sxs-lookup"><span data-stu-id="2b264-118">Implement the background task</span></span>


<span data-ttu-id="2b264-119">[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装して、アプリのライブ タイルを更新するクラスを作ります。</span><span class="sxs-lookup"><span data-stu-id="2b264-119">Implement the [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) interface to create a class that updates your app's live tile.</span></span> <span data-ttu-id="2b264-120">バックグラウンドの作業は、Run メソッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-120">Your background work goes in the Run method.</span></span> <span data-ttu-id="2b264-121">この場合、タスクによって MSDN ブログの配信フィードが取得されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-121">In this case, the task gets a syndication feed for the MSDN blogs.</span></span> <span data-ttu-id="2b264-122">非同期コードの実行中にタスクが途中で終了するのを防ぐには、保留を取得します。</span><span class="sxs-lookup"><span data-stu-id="2b264-122">To prevent the task from closing prematurely while asynchronous code is still running, get a deferral.</span></span>

1.  <span data-ttu-id="2b264-123">ソリューション エクスプローラーで、自動的に生成されたファイルである Class1.cs の名前を BlogFeedBackgroundTask.cs に変更します。</span><span class="sxs-lookup"><span data-stu-id="2b264-123">In Solution Explorer, rename the automatically generated file, Class1.cs, to BlogFeedBackgroundTask.cs.</span></span>
2.  <span data-ttu-id="2b264-124">BlogFeedBackgroundTask.cs を開き、自動的に生成されたコードを、**BlogFeedBackgroundTask** クラスのスタブ コードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="2b264-124">In BlogFeedBackgroundTask.cs, replace the automatically generated code with the stub code for the **BlogFeedBackgroundTask** class.</span></span>
3.  <span data-ttu-id="2b264-125">Run メソッドの実装で、**GetMSDNBlogFeed** メソッドと **UpdateTile** のメソッドのコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="2b264-125">In the Run method implementation, add code for the **GetMSDNBlogFeed** and **UpdateTile** methods.</span></span>

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

## <a name="set-up-the-package-manifest"></a><span data-ttu-id="2b264-126">パッケージ マニフェストの設定</span><span class="sxs-lookup"><span data-stu-id="2b264-126">Set up the package manifest</span></span>


<span data-ttu-id="2b264-127">パッケージ マニフェストを設定するには、そのマニフェストを開き、新しいバックグラウンド タスクの宣言を追加します。</span><span class="sxs-lookup"><span data-stu-id="2b264-127">To set up the package manifest, open it and add a new background task declaration.</span></span> <span data-ttu-id="2b264-128">タスクのエントリ ポイントを設定します。このエントリ ポイントには、名前空間を含めてクラスの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-128">Set the entry point for the task to the class name, including its namespace.</span></span>

1.  <span data-ttu-id="2b264-129">ソリューション エクスプローラーで、Package.appxmanifest を開きます。</span><span class="sxs-lookup"><span data-stu-id="2b264-129">In Solution Explorer, open Package.appxmanifest.</span></span>
2.  <span data-ttu-id="2b264-130">**[宣言]** タブをタップまたはクリックします。</span><span class="sxs-lookup"><span data-stu-id="2b264-130">Click or tap the **Declarations** tab.</span></span>
3.  <span data-ttu-id="2b264-131">**[使用可能な宣言]** で、**[BackgroundTasks]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2b264-131">Under **Available Declarations**, select **BackgroundTasks** and click **Add**.</span></span> <span data-ttu-id="2b264-132">Visual Studio で、**[サポートされる宣言]** の下に **[BackgroundTasks]** が追加されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-132">Visual Studio adds **BackgroundTasks** under **Supported Declarations**.</span></span>
4.  <span data-ttu-id="2b264-133">**[サポートされるタスクの種類]** で、**[タイマー]** がオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2b264-133">Under **Supported task types**, ensure that **Timer** is checked.</span></span>
5.  <span data-ttu-id="2b264-134">**[アプリの設定]** で、エントリ ポイントを **[BackgroundTasks.BlogFeedBackgroundTask]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-134">Under **App settings**, set the entry point to **BackgroundTasks.BlogFeedBackgroundTask**.</span></span>
6.  <span data-ttu-id="2b264-135">**[アプリケーション UI]** タブをクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="2b264-135">Click or tap the **Application UI** tab.</span></span>
7.  <span data-ttu-id="2b264-136">**[ロック画面通知]** を **[バッジとタイル テキスト]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-136">Set **Lock screen notifications** to **Badge and Tile Text**.</span></span>
8.  <span data-ttu-id="2b264-137">**[バッジ ロゴ]** フィールドに、24x24 ピクセルのアイコンへのパスを設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-137">Set a path to a 24x24 pixel icon in the **Badge logo** field.</span></span>
    <span data-ttu-id="2b264-138">**重要**  このアイコンには、モノクロで透明のピクセルだけを使ってください。</span><span class="sxs-lookup"><span data-stu-id="2b264-138">**Important**  This icon must use monochrome and transparent pixels only.</span></span>
9.  <span data-ttu-id="2b264-139">**[小さいロゴ]** フィールドに、30x30 ピクセルのアイコンへのパスを設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-139">In the **Small logo** field, set a path to a 30x30 pixel icon.</span></span>
10. <span data-ttu-id="2b264-140">**[ワイド ロゴ]** フィールドに、310x150 ピクセルのアイコンへのパスを設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-140">In the **Wide logo** field, set a path to a 310x150 pixel icon.</span></span>

## <a name="register-the-background-task"></a><span data-ttu-id="2b264-141">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="2b264-141">Register the background task</span></span>


<span data-ttu-id="2b264-142">[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を作って、タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="2b264-142">Create a [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) to register your task.</span></span>

> <span data-ttu-id="2b264-143">**注**  Windows 8.1 以降では、バックグラウンド タスクの登録パラメーターが登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-143">**Note**  Starting in Windows 8.1, background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="2b264-144">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-144">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="2b264-145">アプリは、バックグラウンド タスクの登録が失敗するシナリオを処理できる必要があります。たとえば、条件ステートメントを使って登録エラーを確認し、失敗した登録は別のパラメーター値を使ってやり直してみます。</span><span class="sxs-lookup"><span data-stu-id="2b264-145">Your app must be able to handle scenarios where background task registration fails - for example, use a conditional statement to check for registration errors and then retry failed registration using different parameter values.</span></span>
 

<span data-ttu-id="2b264-146">アプリのメイン ページで、**RegisterBackgroundTask** メソッドを追加し、このメソッドを **OnNavigatedTo** イベント ハンドラーで呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2b264-146">In your app's main page, add the **RegisterBackgroundTask** method and call it in the **OnNavigatedTo** event handler.</span></span>

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

## <a name="debug-the-background-task"></a><span data-ttu-id="2b264-147">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="2b264-147">Debug the background task</span></span>


<span data-ttu-id="2b264-148">バックグラウンド タスクをデバッグするには、タスクの Run メソッドにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-148">To debug the background task, set a breakpoint in the task’s Run method.</span></span> <span data-ttu-id="2b264-149">**[デバッグの場所]** ツール バーで、バックグラウンド タスクを選びます。</span><span class="sxs-lookup"><span data-stu-id="2b264-149">In the **Debug Location** toolbar, select your background task.</span></span> <span data-ttu-id="2b264-150">この操作によって、システムで Run メソッドがすぐに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-150">This causes the system to call the Run method immediately.</span></span>

1.  <span data-ttu-id="2b264-151">タスクの Run メソッドにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="2b264-151">Set a breakpoint in the task’s Run method.</span></span>
2.  <span data-ttu-id="2b264-152">アプリを展開し実行するには、F5 キーを押すか、**[デバッグ]、[デバッグの開始]** の順にタップします。</span><span class="sxs-lookup"><span data-stu-id="2b264-152">Press F5 or tap **Debug &gt; Start Debugging** to deploy and run the app.</span></span>
3.  <span data-ttu-id="2b264-153">アプリを起動した後で、Visual Studio に戻ります。</span><span class="sxs-lookup"><span data-stu-id="2b264-153">After the app launches, switch back to Visual Studio.</span></span>
4.  <span data-ttu-id="2b264-154">**[デバッグの場所]** ツール バーが表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2b264-154">Ensure that the **Debug Location** toolbar is visible.</span></span> <span data-ttu-id="2b264-155">**[表示] の [ツール バー]** メニューで確認できます。</span><span class="sxs-lookup"><span data-stu-id="2b264-155">It's on the **View &gt; Toolbars** menu.</span></span>
5.  <span data-ttu-id="2b264-156">**[デバッグの場所]** ツール バーで、**[中断]** ドロップダウンをクリックし、**[BlogFeedBackgroundTask]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="2b264-156">On the **Debug Location** toolbar, click the **Suspend** dropdown and select **BlogFeedBackgroundTask**.</span></span>
6.  <span data-ttu-id="2b264-157">Visual Studio では、ブレークポイントで実行が中断します。</span><span class="sxs-lookup"><span data-stu-id="2b264-157">Visual Studio suspends execution at the breakpoint.</span></span>
7.  <span data-ttu-id="2b264-158">アプリの実行を続けるには、F5 キーを押すか、**[デバッグ]、[続行]** の順にタップします。</span><span class="sxs-lookup"><span data-stu-id="2b264-158">Press F5 or tap **Debug &gt; Continue** to continue running the app.</span></span>
8.  <span data-ttu-id="2b264-159">デバッグを停止するには、Shift キーを押しながら F5 キーを押すか、**[デバッグ]、[デバッグの停止]** の順にタップします。</span><span class="sxs-lookup"><span data-stu-id="2b264-159">Press Shift+F5 or tap **Debug &gt; Stop Debugging** to stop debugging.</span></span>
9.  <span data-ttu-id="2b264-160">スタート画面にあるアプリのタイルに戻ります。</span><span class="sxs-lookup"><span data-stu-id="2b264-160">Return to the app's tile on the Start screen.</span></span> <span data-ttu-id="2b264-161">数秒後、アプリのタイルにタイル通知が表示されます。</span><span class="sxs-lookup"><span data-stu-id="2b264-161">After a few seconds, tile notifications appear on your app's tile.</span></span>

## <a name="related-topics"></a><span data-ttu-id="2b264-162">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2b264-162">Related topics</span></span>


* [**<span data-ttu-id="2b264-163">BackgroundTaskBuilder</span><span class="sxs-lookup"><span data-stu-id="2b264-163">BackgroundTaskBuilder</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
* [**<span data-ttu-id="2b264-164">TileUpdateManager</span><span class="sxs-lookup"><span data-stu-id="2b264-164">TileUpdateManager</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208622)
* [**<span data-ttu-id="2b264-165">TileNotification</span><span class="sxs-lookup"><span data-stu-id="2b264-165">TileNotification</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208616)
* [<span data-ttu-id="2b264-166">バックグラウンド タスクによるアプリのサポート</span><span class="sxs-lookup"><span data-stu-id="2b264-166">Support your app with background tasks</span></span>](support-your-app-with-background-tasks.md)
* [<span data-ttu-id="2b264-167">タイルとバッジのガイドラインとチェック リスト</span><span class="sxs-lookup"><span data-stu-id="2b264-167">Guidelines and checklist for tiles and badges</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465403)

 

 
