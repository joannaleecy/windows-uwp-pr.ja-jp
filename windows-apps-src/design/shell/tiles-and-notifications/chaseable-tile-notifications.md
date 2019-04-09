---
Description: 追跡可能なタイル通知を使用すると、ユーザーがライブ タイルをクリックしたときに、アプリによってそのタイルに何が表示されるかを調べることができます。
title: 追跡可能なタイル通知
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Chaseable tile notifications
template: detail.hbs
ms.date: 06/13/2017
ms.topic: article
keywords: Windows 10, UWP, 追跡可能なタイル, ライブ タイル, 追跡可能なタイル通知
ms.localizationpriority: medium
ms.openlocfilehash: 6e27dec0e7256cfc035ecc3150bd976f69743fe3
ms.sourcegitcommit: f15cf141c299bde9cb19965d8be5198d7f85adf8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2019
ms.locfileid: "58358617"
---
# <a name="chaseable-tile-notifications"></a><span data-ttu-id="41212-104">追跡可能なタイル通知</span><span class="sxs-lookup"><span data-stu-id="41212-104">Chaseable tile notifications</span></span>

<span data-ttu-id="41212-105">追跡可能なタイル通知を使用すると、ユーザーがライブ タイルをクリックしたときに、アプリのライブ タイルに表示されるタイル通知を特定することができます。</span><span class="sxs-lookup"><span data-stu-id="41212-105">Chaseable tile notifications let you determine which tile notifications your app's Live Tile was displaying when the user clicked the tile.</span></span>  
<span data-ttu-id="41212-106">たとえば、新しいアプリでこの機能を使用して、ユーザーがライブ タイルを起動したときにそのタイルに表示される新しいストーリーを特定することができます。これにより、ユーザーが見つけることができるように、ストーリーを目立たせて表示することができます。</span><span class="sxs-lookup"><span data-stu-id="41212-106">For example, a news app could use this feature to determine which news story the its Live Tile was displaying when the user launched it; it could that ensure that the story is prominently displayed so that the user can find it.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="41212-107">**Anniversary Update が必要です**:使用した chaseable タイル通知を使用するC#、C++、または VB ベースの UWP アプリ、14393 SDK をターゲットする必要があり、実行しているビルド 14393 またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="41212-107">**Requires Anniversary Update**: To use chaseable tile notifications with C#, C++, or VB-based UWP apps, you must target SDK 14393 and be running build 14393 or higher.</span></span> <span data-ttu-id="41212-108">JavaScript ベースの UWP アプリの場合は、SDK 17134 以降をターゲットとし、ビルド 17134 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="41212-108">For JavaScript-based UWP apps, you must target SDK 17134 and be running build 17134 or higher.</span></span> 


> <span data-ttu-id="41212-109">**重要な API**:[LaunchActivatedEventArgs.TileActivatedInfo プロパティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo)、 [TileActivatedInfo クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)</span><span class="sxs-lookup"><span data-stu-id="41212-109">**Important APIs**: [LaunchActivatedEventArgs.TileActivatedInfo property](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo), [TileActivatedInfo class](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)</span></span>


## <a name="how-it-works"></a><span data-ttu-id="41212-110">方法</span><span class="sxs-lookup"><span data-stu-id="41212-110">How it works</span></span>

<span data-ttu-id="41212-111">追跡可能なタイル通知を有効にするには、タイル通知ペイロードで **Arguments** プロパティ (トースト通知ペイロードの起動プロパティに類似) を使用して、タイル通知のコンテンツに関する情報を埋め込みます。</span><span class="sxs-lookup"><span data-stu-id="41212-111">To enable chaseable tile notifications, you use the **Arguments** property on the tile notification payload, similar to the launch property on the toast notification payload, to embed info about the content in the tile notification.</span></span>

<span data-ttu-id="41212-112">アプリがライブ タイル経由で起動されると、システムは、現在または最後に表示されたタイル通知を基に引数の一覧を返します。</span><span class="sxs-lookup"><span data-stu-id="41212-112">When your app is launched via the Live Tile, the system returns a list of arguments from the current/recently displayed tile notifications.</span></span>


## <a name="when-to-use-chaseable-tile-notifications"></a><span data-ttu-id="41212-113">追跡可能なタイル通知を使用する状況</span><span class="sxs-lookup"><span data-stu-id="41212-113">When to use chaseable tile notifications</span></span>

<span data-ttu-id="41212-114">通常、追跡可能なタイル通知は、ライブ タイルで通知キューを使っているとき (つまり、最大 5 件の異なる通知を循環しているとき) に使用されます。</span><span class="sxs-lookup"><span data-stu-id="41212-114">Chaseable tile notifications are typically used when you're using the notification queue on your Live Tile (which means you are cycling through up to 5 different notifications).</span></span> <span data-ttu-id="41212-115">追跡可能なタイル通知は、ライブ タイルのコンテンツがアプリの最新のコンテンツと同期されていないと考えられる場合にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="41212-115">They're also beneficial when the content on your Live Tile is potentially out of sync with the latest content in the app.</span></span> <span data-ttu-id="41212-116">たとえば、ニュース アプリでは 30 分ごとにライブ タイルが更新されますが、アプリが起動すると、最新のニュースが読み込まれます (前回のポーリング間隔でタイルに表示されていた情報が含まれなくなる可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="41212-116">For example, the News app refreshes its Live Tile every 30 minutes, but when the app is launched, it loads the latest news (which may not include something that was on the tile from the last polling interval).</span></span> <span data-ttu-id="41212-117">この場合、ライブ タイルに表示されていたストーリーを見つけることができなくなり、ユーザーが不満を感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="41212-117">When this happens, the user might get frustrated about not being able to find the story they saw on their Live Tile.</span></span> <span data-ttu-id="41212-118">こうした問題に対応する際に追跡可能なタイル通知が役立ちます。このタイル通知によって、タイルでユーザーに表示されていた情報を簡単に見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="41212-118">That's where chaseable tile notifications can help, by allowing you to make sure that what the user saw on their Tile is easily discoverable.</span></span>

## <a name="what-to-do-with-a-chaseable-tile-notifications"></a><span data-ttu-id="41212-119">追跡可能なタイル通知で実行できること</span><span class="sxs-lookup"><span data-stu-id="41212-119">What to do with a chaseable tile notifications</span></span>

<span data-ttu-id="41212-120">注意が必要な最も重要なことは、ほとんどのシナリオでは、ユーザーがクリックしたときにタイルに表示されていた**特定の通知に直接移動しない**ということです。</span><span class="sxs-lookup"><span data-stu-id="41212-120">The most important thing to note is that in most scenarios, **you should NOT directly navigate to the specific notification** that was on the Tile when the user clicked it.</span></span> <span data-ttu-id="41212-121">ライブ タイルは、アプリケーションへのエントリ ポイントとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="41212-121">Your Live Tile is used as an entry point to your application.</span></span> <span data-ttu-id="41212-122">ユーザーは、ライブ タイルをクリックした 2 つのシナリオがあります。(通常、アプリを起動したいと 1)、またはライブ タイルには、特定の通知の詳細についてを参照してください (2) するつもりでした。</span><span class="sxs-lookup"><span data-stu-id="41212-122">There can be two scenarios when a user clicks your Live Tile: (1) they wanted to launch your app normally, or (2) they wanted to see more information about a specific notification that was on the Live Tile.</span></span> <span data-ttu-id="41212-123">必要な動作をユーザーが明示的に指定する方法がないため、理想的なエクスペリエンスは、**ユーザーに表示されていた通知を簡単に検出できるようにしながら、アプリを通常どおりに起動する**というものになります。</span><span class="sxs-lookup"><span data-stu-id="41212-123">Since there's no way for the user to explicitly say which behavior they want, the ideal experience is to **launch your app normally, while making sure that the notification the user saw is easily discoverable**.</span></span>

<span data-ttu-id="41212-124">たとえば、MSN ニュース アプリのライブ タイルをクリックしてアプリを通常どおりに起動したときに、ホーム ページを表示するか、またはユーザーが前に読んでいたいずれかの記事を表示するようにします。</span><span class="sxs-lookup"><span data-stu-id="41212-124">For example, clicking the MSN News app's Live Tile launches the app normally: it displays the home page, or whichever article the user was previously reading.</span></span> <span data-ttu-id="41212-125">ただしホーム ページを表示した場合は、アプリでライブ タイルのストーリーを簡単に検出できるようにします。</span><span class="sxs-lookup"><span data-stu-id="41212-125">However, on the home page, the app ensures that the story from the Live Tile is easily discoverable.</span></span> <span data-ttu-id="41212-126">これにより、両方のシナリオ (単純にアプリを起動/再開するシナリオと特定のストーリーを表示するシナリオ) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="41212-126">That way, both scenarios are supported: the scenario where you simply want to launch/resume the app, and the scenario where you want to view the specific story.</span></span>


## <a name="how-to-include-the-arguments-property-in-your-tile-notification-payload"></a><span data-ttu-id="41212-127">タイル通知ペイロードに Arguments プロパティを含める方法</span><span class="sxs-lookup"><span data-stu-id="41212-127">How to include the Arguments property in your tile notification payload</span></span>

<span data-ttu-id="41212-128">通知ペイロードで引数プロパティを使用することで、アプリは、後で通知を識別する際に使用できるデータを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="41212-128">In a notification payload, the arguments property enables your app to provide data you can use to later identify the notification.</span></span> <span data-ttu-id="41212-129">たとえば、引数にストーリーの ID を含めて、起動時にストーリーを取得し表示することができます。</span><span class="sxs-lookup"><span data-stu-id="41212-129">For example, your arguments might include the story's id, so that when launched, you can retrieve and display the story.</span></span> <span data-ttu-id="41212-130">プロパティは、シリアル化することができる文字列であればどのような文字列でも受け入れます (クエリ文字列、JSON など)。ただし、通常はクエリ文字列の形式を使用することをお勧めします。これは、クエリ文字列は軽量であり、適切に XML エンコードされるためです。</span><span class="sxs-lookup"><span data-stu-id="41212-130">The property accepts a string, which can be serialized however you like (query string, JSON, etc), but we typically recommend query string format, since it's lightweight and XML-encodes nicely.</span></span>

<span data-ttu-id="41212-131">プロパティは **TileVisual** 要素と **TileBinding** 要素の両方に対して設定でき、カスケードが起こります。</span><span class="sxs-lookup"><span data-stu-id="41212-131">The property can be set on both the **TileVisual** and the **TileBinding** elements, and will cascade down.</span></span> <span data-ttu-id="41212-132">すべてのタイル サイズで同じ引数が必要な場合は、引数を **TileVisual** 要素に対して設定するだけです。</span><span class="sxs-lookup"><span data-stu-id="41212-132">If you want the same arguments on every tile size, simply set the arguments on the **TileVisual**.</span></span> <span data-ttu-id="41212-133">特定のタイル サイズで特定の引数が必要な場合は、引数を個別の **TileBinding** 要素に対して設定することができます。</span><span class="sxs-lookup"><span data-stu-id="41212-133">If you need specific arguments for specific tile sizes, you can set the arguments on individual **TileBinding** elements.</span></span>

<span data-ttu-id="41212-134">この例では、通知を後で識別するための引数プロパティを使用する通知ペイロードを作成します。</span><span class="sxs-lookup"><span data-stu-id="41212-134">This example creates a notification payload that uses the arguments property so that notification can be identified later.</span></span> 

```csharp
// Uses the following NuGet packages
// - Microsoft.Toolkit.Uwp.Notifications
// - QueryString.NET
 
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        // These arguments cascade down to Medium and Wide
        Arguments = new QueryString()
        {
            { "action", "storyClicked" },
            { "story", "201c9b1" }
        }.ToString(),
 
 
        // Medium tile
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                // Omitted
            }
        },
 
 
        // Wide tile is same as Medium
        TileWide = new TileBinding() { /* Omitted */ },
 
 
        // Large tile is an aggregate of multiple stories
        // and therefore needs different arguments
        TileLarge = new TileBinding()
        {
            Arguments = new QueryString()
            {
                { "action", "storiesClicked" },
                { "story", "43f939ag" },
                { "story", "201c9b1" },
                { "story", "d9481ca" }
            }.ToString(),
 
            Content = new TileBindingContentAdaptive() { /* Omitted */ }
        }
    }
};
```


## <a name="how-to-check-for-the-arguments-property-when-your-app-launches"></a><span data-ttu-id="41212-135">アプリの起動時に引数プロパティを確認する方法</span><span class="sxs-lookup"><span data-stu-id="41212-135">How to check for the arguments property when your app launches</span></span>

<span data-ttu-id="41212-136">ほとんどのアプリは App.xaml.cs を保持しており、このファイルには [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) メソッドのオーバーライドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="41212-136">Most apps have an App.xaml.cs file that contains an override for the [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) method.</span></span> <span data-ttu-id="41212-137">その名前が示すように、アプリは起動時にこのメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="41212-137">As its name suggests, your app calls this method when it's launched.</span></span> <span data-ttu-id="41212-138">使用される引数は 1 つだけで、それは [LaunchActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="41212-138">It takes a single argument, a [LaunchActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs) object.</span></span>

<span data-ttu-id="41212-139">LaunchActivatedEventArgs オブジェクトには、追跡可能な通知を有効にするプロパティがあります。そのプロパティは、[TileActivatedInfo プロパティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo)で、[TileActivatedInfo オブジェクト](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)へのアクセスを可能にします。</span><span class="sxs-lookup"><span data-stu-id="41212-139">The LaunchActivatedEventArgs object has a property that enables chaseable notifications: the [TileActivatedInfo property](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo), which provides access to a [TileActivatedInfo object](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo).</span></span> <span data-ttu-id="41212-140">ユーザーがタイルからアプリを起動すると (アプリ一覧、検索、または他のエントリ ポイントから起動するのではありません)、アプリはこのプロパティを初期化します。</span><span class="sxs-lookup"><span data-stu-id="41212-140">When the user launches your app from its tile (rather than the app list, search, or any other entry point), your app initializes this property.</span></span>

<span data-ttu-id="41212-141">[TileActivatedInfo オブジェクト](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)には [RecentlyShownNotifications](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo.RecentlyShownNotifications) と呼ばれるプロパティが含まれています。このプロパティは、過去 15 分以内にタイルに表示されていた通知の一覧を保持しています。</span><span class="sxs-lookup"><span data-stu-id="41212-141">The [TileActivatedInfo object](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo) contains a property called [RecentlyShownNotifications](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo.RecentlyShownNotifications), which contains a list of notifications that have been shown on the tile within the last 15 minutes.</span></span> <span data-ttu-id="41212-142">一覧の最初の項目はタイルの現在の通知を表しており、それ以降の項目は現在の通知よりも前に表示されていた通知を表しています。</span><span class="sxs-lookup"><span data-stu-id="41212-142">The first item in the list represents the notification currently on the tile, and the subsequent items represent the notifications that the user saw before the current one.</span></span> <span data-ttu-id="41212-143">タイルがクリアされた場合、この一覧は空になります。</span><span class="sxs-lookup"><span data-stu-id="41212-143">If your tile has been cleared, this list is empty.</span></span>

<span data-ttu-id="41212-144">各 ShownTileNotification では、引数プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="41212-144">Each ShownTileNotification has an Arguments property.</span></span> <span data-ttu-id="41212-145">Arguments プロパティは、ペイロードには、引数文字列が含まれていなかった場合、タイル通知のペイロードまたは null の引数文字列で初期化されます。</span><span class="sxs-lookup"><span data-stu-id="41212-145">The Arguments property will be initialized with the arguments string from your tile notification payload, or null if your payload didn't include the arguments string.</span></span>

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs args)
{
    // If the API is present (doesn't exist on 10240 and 10586)
    if (ApiInformation.IsPropertyPresent(typeof(LaunchActivatedEventArgs).FullName, nameof(LaunchActivatedEventArgs.TileActivatedInfo)))
    {
        // If clicked on from tile
        if (args.TileActivatedInfo != null)
        {
            // If tile notification(s) were present
            if (args.TileActivatedInfo.RecentlyShownNotifications.Count > 0)
            {
                // Get arguments from the notifications that were recently displayed
                string[] allArgs = args.TileActivatedInfo.RecentlyShownNotifications
                .Select(i => i.Arguments)
                .ToArray();
 
                // TODO: Highlight each story in the app
            }
        }
    }
 
    // TODO: Initialize app
}
```


### <a name="accessing-onlaunched-from-desktop-applications"></a><span data-ttu-id="41212-146">デスクトップ アプリケーションから OnLaunched へのアクセス</span><span class="sxs-lookup"><span data-stu-id="41212-146">Accessing OnLaunched from desktop applications</span></span>

<span data-ttu-id="41212-147">デスクトップ アプリ (Win32 と WPF では、同様になど) を使用して、[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)、chaseable タイルにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="41212-147">Desktop apps (like Win32, WPF, etc) using the [Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop), can use chaseable tiles too!</span></span> <span data-ttu-id="41212-148">唯一の違いは、OnLaunched 引数にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="41212-148">The only difference is accessing the OnLaunched arguments.</span></span> <span data-ttu-id="41212-149">まず必要なメモ[デスクトップ ブリッジを使用してアプリをパッケージ化](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root)します。</span><span class="sxs-lookup"><span data-stu-id="41212-149">Note that you first must [package your app with the Desktop Bridge](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="41212-150">**2018 の年 10 月の更新プログラムが必要**:使用する、 `AppInstance.GetActivatedEventArgs()` API、SDK 17763 をターゲットする必要があり、17763 またはそれ以降、ビルドを実行します。</span><span class="sxs-lookup"><span data-stu-id="41212-150">**Requires October 2018 Update**: To use the `AppInstance.GetActivatedEventArgs()` API, you must target SDK 17763 and be running build 17763 or higher.</span></span>

<span data-ttu-id="41212-151">デスクトップ アプリケーションは、起動引数にアクセスするには次の操作.</span><span class="sxs-lookup"><span data-stu-id="41212-151">For desktop applications, to access the launch arguments, do the following...</span></span>

```csharp

static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    // API only available on build 17763 or higher
    var args = AppInstance.GetActivatedEventArgs();
    switch (args.Kind)
    {
        case ActivationKind.Launch:

            var launchArgs = args as LaunchActivatedEventArgs;

            // If clicked on from tile
            if (launchArgs.TileActivatedInfo != null)
            {
                // If tile notification(s) were present
                if (launchArgs.TileActivatedInfo.RecentlyShownNotifications.Count > 0)
                {
                    // Get arguments from the notifications that were recently displayed
                    string[] allTileArgs = launchArgs.TileActivatedInfo.RecentlyShownNotifications
                    .Select(i => i.Arguments)
                    .ToArray();
     
                    // TODO: Highlight each story in the app
                }
            }
    
            break;
```


## <a name="raw-xml-example"></a><span data-ttu-id="41212-152">生の XML の例</span><span class="sxs-lookup"><span data-stu-id="41212-152">Raw XML example</span></span>

<span data-ttu-id="41212-153">Notifications ライブラリではなく生の XML を使用する場合、XML は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="41212-153">If you're using raw XML instead of the Notifications library, here's the XML.</span></span>

```xml
<tile>
  <visual arguments="action=storyClicked&amp;story=201c9b1">
 
    <binding template="TileMedium">
       
      <text>Kitten learns how to drive a car...</text>
      ... (omitted)
     
    </binding>
 
    <binding template="TileWide">
      ... (same as Medium)
    </binding>
     
    <!--Large tile is an aggregate of multiple stories-->
    <binding
      template="TileLarge"
      arguments="action=storiesClicked&amp;story=43f939ag&amp;story=201c9b1&amp;story=d9481ca">
   
      <text>Can your dog understand what you're saying?</text>
      ... (another story)
      ... (one more story)
   
    </binding>
 
  </visual>
</tile>
```



## <a name="related-articles"></a><span data-ttu-id="41212-154">関連記事</span><span class="sxs-lookup"><span data-stu-id="41212-154">Related articles</span></span>

- [<span data-ttu-id="41212-155">LaunchActivatedEventArgs.TileActivatedInfo プロパティ</span><span class="sxs-lookup"><span data-stu-id="41212-155">LaunchActivatedEventArgs.TileActivatedInfo property</span></span>](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs#Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_TileActivatedInfo_)
- [<span data-ttu-id="41212-156">TileActivatedInfo クラス</span><span class="sxs-lookup"><span data-stu-id="41212-156">TileActivatedInfo class</span></span>](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)
