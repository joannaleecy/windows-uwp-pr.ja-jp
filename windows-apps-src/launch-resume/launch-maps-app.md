---
author: TylerMSFT
title: "Windows マップ アプリの起動"
description: "アプリから Windows マップ アプリを起動する方法について説明します。"
ms.assetid: E363490A-C886-4D92-9A64-52E3C24F1D98
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 3d36708b5b11a089ffa126b760f0990f2da39e38
ms.sourcegitcommit: f6dd9568eafa10ee5cb2b849c0d82d84a1c5fb93
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/02/2017
---
# <a name="launch-the-windows-maps-app"></a><span data-ttu-id="5d20e-104">Windows マップ アプリの起動</span><span class="sxs-lookup"><span data-stu-id="5d20e-104">Launch the Windows Maps app</span></span>


<span data-ttu-id="5d20e-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="5d20e-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="5d20e-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="5d20e-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="5d20e-107">アプリから Windows マップ アプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-107">Learn how to launch the Windows Maps app from your app.</span></span> <span data-ttu-id="5d20e-108">このトピックでは、**bingmaps:、*ms-drive-to:、ms-walk-to:**、**ms-settings:** の各 URI (Uniform Resource Identifier) スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-108">This topic describes the **bingmaps:, *ms-drive-to:, ms-walk-to:** and **ms-settings:** Uniform Resource Identifier (URI) schemes.</span></span> <span data-ttu-id="5d20e-109">これらの URI スキームを使って、Windows マップ アプリを起動し、特定の地図、ルート案内、検索結果を表示したり、設定アプリから Windows マップ オフライン マップをダウンロードしたりします。</span><span class="sxs-lookup"><span data-stu-id="5d20e-109">Use these URI schemes to launch the Windows Maps app to specific maps, directions, and search results or to download Windows Maps offline maps from the Settings app.</span></span>

<span data-ttu-id="5d20e-110">**ヒント** アプリから Windows マップ アプリを起動する方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-110">**Tip** To learn more about launching the Windows Maps app from your app, download the [Universal Windows Platform (UWP) map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977) from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

## <a name="introducing-uris"></a><span data-ttu-id="5d20e-111">URI の概要</span><span class="sxs-lookup"><span data-stu-id="5d20e-111">Introducing URIs</span></span>

<span data-ttu-id="5d20e-112">URI スキームを使うと、ハイパーリンクのクリックによって (またはアプリでプログラム的に) アプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-112">URI schemes let you open apps by clicking hyperlinks (or programmatically, in your app).</span></span> <span data-ttu-id="5d20e-113">**mailto:** を使って新しいメールの作成を開始したり、**http:** を使って既定の Web ブラウザーを開いたりできるのと同様に、**bingmaps:**、**ms-drive-to:**、**ms-walk-to:** を使って Windows マップ アプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-113">Just as you can start a new email using **mailto:** or open a web browser using **http:**, you can open the Windows maps app using **bingmaps:**, **ms-drive-to:**, and **ms-walk-to:**.</span></span>

-   <span data-ttu-id="5d20e-114">**bingmaps:** URI は、位置情報、検索結果、ルート案内、交通情報用の地図を提供します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-114">The **bingmaps:** URI provides maps for locations, search results, directions, and traffic.</span></span>
-   <span data-ttu-id="5d20e-115">**ms-drive-to:** URI は、現在の場所からのターン バイ ターン方式の自動車ルート案内を提供します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-115">The **ms-drive-to:** URI provides turn-by-turn driving directions from your current location.</span></span>
-   <span data-ttu-id="5d20e-116">**ms-walk-to:** URI は、現在の場所からのターン バイ ターン方式の徒歩ルート案内を提供します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-116">The **ms-walk-to:** URI provides turn-by-turn walking directions from your current location.</span></span>

<span data-ttu-id="5d20e-117">たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-117">For example, the following URI opens the Windows Maps app and displays a map centered over New York City.</span></span>

```xml
<bingmaps:?cp=40.726966~-74.006076>
```

![ニューヨークを中心とした地図。](images/mapnyc.png)

<span data-ttu-id="5d20e-119">URI スキームについて次に説明します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-119">Here is a description of the URI scheme:</span></span>

**<span data-ttu-id="5d20e-120">bingmaps:?query</span><span class="sxs-lookup"><span data-stu-id="5d20e-120">bingmaps:?query</span></span>**

<span data-ttu-id="5d20e-121">この URI スキームでは、*query* は、次のようなパラメーター名と値の一連のペアを示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-121">In this URI scheme, *query* is a series of parameter name/value pairs:</span></span>

**<span data-ttu-id="5d20e-122">&param1=value1&param2=value2 …</span><span class="sxs-lookup"><span data-stu-id="5d20e-122">&param1=value1&param2=value2 …</span></span>**

<span data-ttu-id="5d20e-123">使用可能なパラメーターの一覧については、[bingmaps:](#bingmaps-param-reference)、[ms-drive-to:](#ms-drive-to-param-reference)、[ms-walk-to:](#ms-walk-to-param-reference) のパラメーター リファレンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-123">For a full list of the available parameters, see the [bingmaps:](#bingmaps-param-reference), [ms-drive-to:](#ms-drive-to-param-reference), and [ms-walk-to:](#ms-walk-to-param-reference) parameter reference.</span></span> <span data-ttu-id="5d20e-124">このトピックでも後で例を示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-124">There are also examples later in this topic.</span></span>

## <a name="launch-a-uri-from-your-app"></a><span data-ttu-id="5d20e-125">アプリからの URI の起動</span><span class="sxs-lookup"><span data-stu-id="5d20e-125">Launch a URI from your app</span></span>


<span data-ttu-id="5d20e-126">アプリから Windows マップ アプリを起動するには、**bingmaps:**、**ms-drive-to:**、または **ms-walk-to:** URI を指定して [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-126">To launch the Windows Maps app from your app, call the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method with a **bingmaps:**, **ms-drive-to:**, or **ms-walk-to:** URI.</span></span> <span data-ttu-id="5d20e-127">次の例では、前の例と同じ URI を起動します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-127">The following example launches the same URI from the previous example.</span></span> <span data-ttu-id="5d20e-128">URI によるアプリの起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-128">For more info about launching apps via URI, see [Launch the default app for a URI](launch-default-app.md).</span></span>

```cs
// Center on New York City
var uriNewYork = new Uri(@"bingmaps:?cp=40.726966~-74.006076");

// Launch the Windows Maps app
var launcherOptions = new Windows.System.LauncherOptions();
launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
var success = await Windows.System.Launcher.LaunchUriAsync(uriNewYork, launcherOptions);
```

<span data-ttu-id="5d20e-129">この例では、Windows マップ アプリを確実に起動するために [**LauncherOptions**](https://msdn.microsoft.com/library/windows/apps/hh701435) クラスを使っています。</span><span class="sxs-lookup"><span data-stu-id="5d20e-129">In this example, the [**LauncherOptions**](https://msdn.microsoft.com/library/windows/apps/hh701435) class is used to help ensure the Windows Maps app is launched.</span></span>

## <a name="display-known-locations"></a><span data-ttu-id="5d20e-130">既知の場所の表示</span><span class="sxs-lookup"><span data-stu-id="5d20e-130">Display known locations</span></span>

<span data-ttu-id="5d20e-131">地図の表示する部分を制御するための多くのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-131">There are many options to control which part of the map to show.</span></span> <span data-ttu-id="5d20e-132">*cp* (中心点) パラメーターと *rad* (半径) パラメーターまたは *lvl* (ズーム レベル) パラメーターを使って、場所を表示し、ズーム インの程度を選択できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-132">You can use the *cp* (center point) parameter with either the *rad* (radius) or the *lvl* (zoom level) parameters to show a location and choose how close to zoom in to it.</span></span> <span data-ttu-id="5d20e-133">*cp* パラメーターを使う場合、*hdg* (向き) と *pit* (ピッチ) を指定して、表示する方向を制御できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-133">When you use the *cp* parameter, you can also specify a *hdg* (heading) and *pit* (pitch) to control what direction to look.</span></span> <span data-ttu-id="5d20e-134">もう 1 つの方法は、*bb* (境界ボックス) パラメーターを使って、表示する領域の東西南北の最大の座標を指定することです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-134">Another method is to use the *bb* (bounding box) parameter to provide the maximum south, east, north, and west coordinates of the area you want to show.</span></span>

<span data-ttu-id="5d20e-135">ビューの種類を制御するには、*sty* (スタイル) パラメーターと *ss* (Streetside) パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-135">To control the type of view, use the *sty* (style) and *ss* (Streetside) parameters.</span></span> <span data-ttu-id="5d20e-136">*sty* パラメーターは、道路図と航空写真表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-136">The *sty* parameter lets you switch between road and aerial views.</span></span> <span data-ttu-id="5d20e-137">*ss* パラメーターは、Streetside ビューに地図を配置します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-137">The *ss* parameter puts the map into a Streetside view.</span></span> <span data-ttu-id="5d20e-138">これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-138">For more info about these and other parameters, see the [bingmaps: parameter reference](#bingmaps-param-reference).</span></span>


| <span data-ttu-id="5d20e-139">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-139">Sample URI</span></span>                                                                 | <span data-ttu-id="5d20e-140">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-140">Results</span></span>                                                                                                                                                                                        |
|----------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-141">bingmaps:?</span><span class="sxs-lookup"><span data-stu-id="5d20e-141">bingmaps:?</span></span>                                                                 | <span data-ttu-id="5d20e-142">マップ アプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-142">Opens the Maps app.</span></span>                                                                                                                                                                            |
| <span data-ttu-id="5d20e-143">bingmaps:?cp=40.726966~-74.006076</span><span class="sxs-lookup"><span data-stu-id="5d20e-143">bingmaps:?cp=40.726966~-74.006076</span></span>                                          | <span data-ttu-id="5d20e-144">ニューヨークを中心とした地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-144">Displays a map centered over New York City.</span></span>                                                                                                                                                    |
| <span data-ttu-id="5d20e-145">bingmaps:?cp=40.726966~-74.006076&lvl=10</span><span class="sxs-lookup"><span data-stu-id="5d20e-145">bingmaps:?cp=40.726966~-74.006076&lvl=10</span></span>                                   | <span data-ttu-id="5d20e-146">ズーム レベル 10 でニューヨークを中心とした地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-146">Displays a map centered over New York City with a zoom level of 10.</span></span>                                                                                                                            |
| <span data-ttu-id="5d20e-147">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5</span><span class="sxs-lookup"><span data-stu-id="5d20e-147">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5</span></span>                                   | <span data-ttu-id="5d20e-148">**bb** 引数で指定された領域に基づいてニューヨーク市の地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-148">Displays a map of New York City, which is the area specified in the **bb** argument.</span></span>                                                                                                           |
| <span data-ttu-id="5d20e-149">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&cp=47~-122</span><span class="sxs-lookup"><span data-stu-id="5d20e-149">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&cp=47~-122</span></span>                        | <span data-ttu-id="5d20e-150">境界ボックスの引数で指定された領域に基づいてニューヨークの地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-150">Displays a map of New York City, which is the area specified in the bounding box argument.</span></span> <span data-ttu-id="5d20e-151">*bb* が指定されているため、**cp** 引数で指定されたシアトルの中心点は無視されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-151">The center point for Seattle specified in the **cp** argument is ignored because *bb* is specified.</span></span> |
| <span data-ttu-id="5d20e-152">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16</span><span class="sxs-lookup"><span data-stu-id="5d20e-152">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16</span></span> | <span data-ttu-id="5d20e-153">シーザーズ パレス (ラスベガス) という名前のポイントを使って地図を表示します。ズーム レベルは 16 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-153">Displays a map with a point named Caesars Palace (in Las Vegas) and sets the zoom level to 16.</span></span>                                                                                                 |
| <span data-ttu-id="5d20e-154">bingmaps:?collection=point.40.726966\_-74.006076\_Some%255FBusiness</span><span class="sxs-lookup"><span data-stu-id="5d20e-154">bingmaps:?collection=point.40.726966\_-74.006076\_Some%255FBusiness</span></span>        | <span data-ttu-id="5d20e-155">Some\_Business (ラスベガス) という名前のポイントを使って地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-155">Displays a map with a point named Some\_Business (in Las Vegas).</span></span>                                                                                                                               |
| <span data-ttu-id="5d20e-156">bingmaps:?cp=40.726966~-74.006076&trfc=1&sty=a</span><span class="sxs-lookup"><span data-stu-id="5d20e-156">bingmaps:?cp=40.726966~-74.006076&trfc=1&sty=a</span></span>                             | <span data-ttu-id="5d20e-157">航空写真の地図形式を使い、交通情報を有効にして、ニューヨーク市の地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-157">Displays a map of New York City with traffic on and aerial map style.</span></span>                                                                                                                          |
| <span data-ttu-id="5d20e-158">bingmaps:?cp=47.6204~-122.3491&sty=3d</span><span class="sxs-lookup"><span data-stu-id="5d20e-158">bingmaps:?cp=47.6204~-122.3491&sty=3d</span></span>                                      | <span data-ttu-id="5d20e-159">スペース ニードルの 3D ビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-159">Displays a 3D view of the Space Needle.</span></span>                                                                                                                                                        |
| <span data-ttu-id="5d20e-160">bingmaps:?cp=47.6204~-122.3491&sty=3d&rad=200&pit=75&hdg=165</span><span class="sxs-lookup"><span data-stu-id="5d20e-160">bingmaps:?cp=47.6204~-122.3491&sty=3d&rad=200&pit=75&hdg=165</span></span>               | <span data-ttu-id="5d20e-161">半径 200 m、ピッチ 75 度、方位 165 度で、スペース ニードルの 3D ビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-161">Displays a 3D view of the Space Needle with a radius of 200m, a pitch of 75 degrees, and a heading of 165 degrees.</span></span>                                                                             |
| <span data-ttu-id="5d20e-162">bingmaps:?cp=47.6204~-122.3491&ss=1</span><span class="sxs-lookup"><span data-stu-id="5d20e-162">bingmaps:?cp=47.6204~-122.3491&ss=1</span></span>                                        | <span data-ttu-id="5d20e-163">スペース ニードルの Streetside ビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-163">Displays a Streetside view of the Space Needle.</span></span>                                                                                                                                                |


## <a name="display-search-results"></a><span data-ttu-id="5d20e-164">検索結果の表示</span><span class="sxs-lookup"><span data-stu-id="5d20e-164">Display search results</span></span>

<span data-ttu-id="5d20e-165">*q* パラメーターを使って場所を検索する場合には、検索語句をできるだけ具体的に示すこと、また *cp*、*bb*、または *where* の各パラメーターを使って、検索場所を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5d20e-165">When searching for places using the *q* parameter, we recommend making the terms as specific as possible and using the *cp*, *bb*, or *where* parameters to specify a search location.</span></span> <span data-ttu-id="5d20e-166">検索場所が指定されず、ユーザーの現在の場所が利用できない場合は、検索が意味のある結果を返さない場合があります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-166">If you do not specify a search location and the user's current location isn't available, the search may not return meaningful results.</span></span> <span data-ttu-id="5d20e-167">検索結果は、最も適切な地図のビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-167">Search results are displayed in the most appropriate map view.</span></span> <span data-ttu-id="5d20e-168">これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-168">For more info about these and other parameters, see the [bingmaps: parameter reference](#bingmaps-param-reference).</span></span>


| <span data-ttu-id="5d20e-169">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-169">Sample URI</span></span>                                                    | <span data-ttu-id="5d20e-170">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-170">Results</span></span>                                                                            |
|---------------------------------------------------------------|------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-171">bingmaps:?q=1600%20Pennsylvania%20Ave,%20Washington,%20DC</span><span class="sxs-lookup"><span data-stu-id="5d20e-171">bingmaps:?q=1600%20Pennsylvania%20Ave,%20Washington,%20DC</span></span>     | <span data-ttu-id="5d20e-172">地図を表示し、ワシントンD.C. のホワイト ハウスの住所を検索します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-172">Displays a map and searches for the address of the White House in Washington, D.C.</span></span> |
| <span data-ttu-id="5d20e-173">bingmaps:?q=coffee&where=Seattle</span><span class="sxs-lookup"><span data-stu-id="5d20e-173">bingmaps:?q=coffee&where=Seattle</span></span>                              | <span data-ttu-id="5d20e-174">シアトルでコーヒーを検索します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-174">Searches for coffee in Seattle.</span></span>                                                    |
| <span data-ttu-id="5d20e-175">bingmaps:?cp=40.726966~-74.006076&where=New%20York</span><span class="sxs-lookup"><span data-stu-id="5d20e-175">bingmaps:?cp=40.726966~-74.006076&where=New%20York</span></span>            | <span data-ttu-id="5d20e-176">指定した中心点の近くのニューヨークを検索します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-176">Searches for New York near the specified center point.</span></span>                             |
| <span data-ttu-id="5d20e-177">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&q=pizza</span><span class="sxs-lookup"><span data-stu-id="5d20e-177">bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&q=pizza</span></span>              | <span data-ttu-id="5d20e-178">指定した境界ボックス (ニューヨーク市) の中でピザを検索します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-178">Searches for pizza in the specified bounding box (that is, in New York City).</span></span>      |

 
## <a name="display-multiple-points"></a><span data-ttu-id="5d20e-179">複数のポイントの表示</span><span class="sxs-lookup"><span data-stu-id="5d20e-179">Display multiple points</span></span>


<span data-ttu-id="5d20e-180">地図上のポイントのカスタム セットを表示するには、*collection* パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-180">Use the *collection* parameter to show a custom set of points on the map.</span></span> <span data-ttu-id="5d20e-181">ポイントが複数ある場合は、ポイントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-181">If there is more than one point, a list of points is displayed.</span></span> <span data-ttu-id="5d20e-182">コレクションには 25 個までポイントを含めることができます。これらのポイントは指定された順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-182">There can be up to 25 points in a collection and they are listed in the order provided.</span></span> <span data-ttu-id="5d20e-183">コレクションは、検索要求やルート案内の要求よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-183">The collection takes precedence over search and directions requests.</span></span> <span data-ttu-id="5d20e-184">このパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-184">For more info about this parameter and others, see the [bingmaps: parameter reference](#bingmaps-param-reference).</span></span>

| <span data-ttu-id="5d20e-185">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-185">Sample URI</span></span> | <span data-ttu-id="5d20e-186">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-186">Results</span></span>                                                                                                                   |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-187">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace</span><span class="sxs-lookup"><span data-stu-id="5d20e-187">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace</span></span>                                                                                                | <span data-ttu-id="5d20e-188">ラスベガスのシーザーズ パレスを検索し、その結果を地図に表示します (最適な地図のビューで表示されます)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-188">Searches for Caesar's Palace in Las Vegas and displays the results on a map in the best map view.</span></span>                         |
| <span data-ttu-id="5d20e-189">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16</span><span class="sxs-lookup"><span data-stu-id="5d20e-189">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16</span></span>                                                                                         | <span data-ttu-id="5d20e-190">ラスベガスにあるシーザーズ パレスという名前のプッシュピンを表示し、ズーム レベルを 16 に設定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-190">Displays a pushpin named Caesars Palace in Las Vegas and zooms to level 16.</span></span>                                               |
| <span data-ttu-id="5d20e-191">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669</span><span class="sxs-lookup"><span data-stu-id="5d20e-191">bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669</span></span>                   | <span data-ttu-id="5d20e-192">ラスベガスにあるシーザーズ パレスおよびベラジオという名前のプッシュピンを表示し、ズーム レベルを 16 に設定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-192">Displays a pushpin named Caesars Palace and a pushpin named The Bellagio in Las Vegas and zooms to level 16.</span></span>              |
| <span data-ttu-id="5d20e-193">bingmaps:?collection=point.40.726966\_-74.006076\_Fake%255FBusiness%255Fwith%255FUnderscore</span><span class="sxs-lookup"><span data-stu-id="5d20e-193">bingmaps:?collection=point.40.726966\_-74.006076\_Fake%255FBusiness%255Fwith%255FUnderscore</span></span>                                                                        | <span data-ttu-id="5d20e-194">Fake\_Business\_with\_Underscore という名前のプッシュピンと共にニューヨークを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-194">Displays New York with a pushpin named Fake\_Business\_with\_Underscore.</span></span>                                                  |
| <span data-ttu-id="5d20e-195">bingmaps:?collection=name.Hotel%20List~point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669</span><span class="sxs-lookup"><span data-stu-id="5d20e-195">bingmaps:?collection=name.Hotel%20List~point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669</span></span> | <span data-ttu-id="5d20e-196">Hotel List という名前の一覧、およびラスベガスにあるシーザーズ パレスとベラジオの 2 つのプッシュピンを表示し、ズーム レベルを 16 に設定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-196">Displays a list named Hotel List and two pushpins for Caesars Palace and The Bellagio in Las Vegas and zooms to level 16.</span></span> |

 

## <a name="display-directions-and-traffic"></a><span data-ttu-id="5d20e-197">ルート案内と交通情報の表示</span><span class="sxs-lookup"><span data-stu-id="5d20e-197">Display directions and traffic</span></span>


<span data-ttu-id="5d20e-198">*rtp* パラメーターを使って、2 つのポイント間のルート案内を表示できます。これらのポイントは、住所または緯度と経度の座標で指定できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-198">You can display directions between two points using the *rtp* parameter; those points can be either addresses or latitude and longitude coordinates.</span></span> <span data-ttu-id="5d20e-199">交通情報を表示するには、*trfc* パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-199">Use the *trfc* parameter to show traffic information.</span></span> <span data-ttu-id="5d20e-200">ルート案内の種類 (自動車、徒歩、乗り換え案内) を指定するには、*mode* パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-200">To specify the type of directions: driving, walking, or transit, use the *mode* parameter.</span></span> <span data-ttu-id="5d20e-201">*mode* が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-201">If *mode* isn't specified, directions will be provided using the user's preferred mode of transportation.</span></span> <span data-ttu-id="5d20e-202">これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-202">For more info about these parameters and others, see the [bingmaps: parameter reference](#bingmaps-param-reference).</span></span>

![ルート案内の例](images/windowsmapgcdirections.png)

| <span data-ttu-id="5d20e-204">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-204">Sample URI</span></span>                                                                                                              | <span data-ttu-id="5d20e-205">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-205">Results</span></span>                                                                                                                                                         |
|-------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-206">bingmaps:?rtp=pos.44.9160\_-110.4158~pos.45.0475\_-109.4187</span><span class="sxs-lookup"><span data-stu-id="5d20e-206">bingmaps:?rtp=pos.44.9160\_-110.4158~pos.45.0475\_-109.4187</span></span>                                                             | <span data-ttu-id="5d20e-207">ポイント ツー ポイントのルート案内と共に地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-207">Displays a map with point-to-point directions.</span></span> <span data-ttu-id="5d20e-208">*mode* が指定されていないため、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-208">Because *mode* is not specified, directions will be provided using the user's mode of transportation preference.</span></span> |
| <span data-ttu-id="5d20e-209">bingmaps:?cp=43.0332~-87.9167&trfc=1</span><span class="sxs-lookup"><span data-stu-id="5d20e-209">bingmaps:?cp=43.0332~-87.9167&trfc=1</span></span>                                                                                    | <span data-ttu-id="5d20e-210">ウィスコンシン州のミルウォーキーを中心とした地図と交通情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-210">Displays a map centered over Milwaukee, WI with traffic.</span></span>                                                                                                        |
| <span data-ttu-id="5d20e-211">bingmaps:?rtp=adr.One Microsoft Way, Redmond, WA 98052~pos.39.0731\_-108.7238</span><span class="sxs-lookup"><span data-stu-id="5d20e-211">bingmaps:?rtp=adr.One Microsoft Way, Redmond, WA 98052~pos.39.0731\_-108.7238</span></span>                                           | <span data-ttu-id="5d20e-212">指定した住所から指定した場所までのルート案内と共に地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-212">Displays a map with directions from the specified address to the specified location.</span></span>                                                                            |
| <span data-ttu-id="5d20e-213">bingmaps:?rtp=adr.1%20Microsoft%20Way,%20Redmond,%20WA,%2098052~pos.36.1223\_-111.9495\_Grand%20Canyon%20northern%20rim</span><span class="sxs-lookup"><span data-stu-id="5d20e-213">bingmaps:?rtp=adr.1%20Microsoft%20Way,%20Redmond,%20WA,%2098052~pos.36.1223\_-111.9495\_Grand%20Canyon%20northern%20rim</span></span> | <span data-ttu-id="5d20e-214">1 Microsoft Way, Redmond, WA、98052 からグランドキャニオンの北端までのルート案内を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-214">Displays directions from 1 Microsoft Way, Redmond, WA, 98052 to the Grand Canyon's northern rim.</span></span>                                                                |
| <span data-ttu-id="5d20e-215">bingmaps:?rtp=adr.Davenport, CA~adr.Yosemite Village</span><span class="sxs-lookup"><span data-stu-id="5d20e-215">bingmaps:?rtp=adr.Davenport, CA~adr.Yosemite Village</span></span>                                                                    | <span data-ttu-id="5d20e-216">指定した場所から指定したランドマークまでの自動車ルート案内と共に地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-216">Displays a map with driving directions from the specified location to the specified landmark.</span></span>                                                                   |
| <span data-ttu-id="5d20e-217">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=d</span><span class="sxs-lookup"><span data-stu-id="5d20e-217">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=d</span></span>                      | <span data-ttu-id="5d20e-218">カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの自動車ルート案内を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-218">Displays driving directions from Mountain View, CA to San Francisco International Airport, CA.</span></span>                                                                  |
| <span data-ttu-id="5d20e-219">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=w</span><span class="sxs-lookup"><span data-stu-id="5d20e-219">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=w</span></span>                      | <span data-ttu-id="5d20e-220">カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの徒歩ルート案内を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-220">Displays walking directions from Mountain View, CA to San Francisco International Airport, CA.</span></span>                                                                  |
| <span data-ttu-id="5d20e-221">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=t</span><span class="sxs-lookup"><span data-stu-id="5d20e-221">bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=t</span></span>                      | <span data-ttu-id="5d20e-222">カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの乗り換え案内を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-222">Displays transit directions from Mountain View, CA to San Francisco International Airport, CA.</span></span>                                                                  |

 

## <a name="display-turn-by-turn-directions"></a><span data-ttu-id="5d20e-223">ターン バイ ターン方式のルート案内の表示</span><span class="sxs-lookup"><span data-stu-id="5d20e-223">Display turn-by-turn directions</span></span>


<span data-ttu-id="5d20e-224">**ms-drive-to:** と **ms-walk-to:** の各 URI スキームでは、直接ターン バイ ターン方式のルート案内を起動できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-224">The **ms-drive-to:** and **ms-walk-to:** URI schemes let you launch directly into a turn-by-turn view of a route.</span></span> <span data-ttu-id="5d20e-225">これらの URI スキームでは、ユーザーの現在の場所からのルート案内のみを提供できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-225">These URI schemes can only provide directions from the user's current location.</span></span> <span data-ttu-id="5d20e-226">ユーザーの現在の場所を含まないポイント間のルート案内を提供する必要がある場合は、前のセクションで説明した **bingmaps:** URI スキームを使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-226">If you must provide directions between points that do not include the user's current location, use the **bingmaps:** URI scheme as described in the previous section.</span></span> <span data-ttu-id="5d20e-227">これらの URI スキームについて詳しくは、[ms-drive-to:](#ms-drive-to-param-reference) と [ms-walk-to:](#ms-walk-to-param-reference) のパラメーター リファレンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-227">For more info about these URI schemes, see the [ms-drive-to:](#ms-drive-to-param-reference) and [ms-walk-to:](#ms-walk-to-param-reference) parameter reference.</span></span>

> <span data-ttu-id="5d20e-228">**重要**  **ms-drive-to:** または **ms-walk-to:** の URI スキームが呼び出されると、マップ アプリは、デバイスで GPS 位置情報の修正が行われたことがあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-228">**Important**  When the **ms-drive-to:** or **ms-walk-to:** URI schemes are launched, the Maps app will check to see if the device has ever had a GPS location fix.</span></span> <span data-ttu-id="5d20e-229">行われたことがある場合は、ターン バイ ターン方式のルート案内に進みます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-229">If it has, then the Maps app will proceed to turn-by-turn directions.</span></span> <span data-ttu-id="5d20e-230">行われたことがない場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」で説明したルートの概要を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-230">If it hasn't, the app will display the route overview, as described in [Display directions and traffic](#display-directions-and-traffic).</span></span>

 

![ターン バイ ターン方式のルート案内の例](images/windowsmapsappdirections.png)

| <span data-ttu-id="5d20e-232">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-232">Sample URI</span></span>                                                                                                | <span data-ttu-id="5d20e-233">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-233">Results</span></span>                                                                                       |
|-----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-234">ms-drive-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake</span><span class="sxs-lookup"><span data-stu-id="5d20e-234">ms-drive-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake</span></span> | <span data-ttu-id="5d20e-235">現在の場所からグリーン湖までのターン バイ ターン方式の自動車ルート案内と共に地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-235">Displays a map with turn-by-turn driving directions to Green Lake from your current location.</span></span> |
| <span data-ttu-id="5d20e-236">ms-walk-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake</span><span class="sxs-lookup"><span data-stu-id="5d20e-236">ms-walk-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake</span></span>  | <span data-ttu-id="5d20e-237">現在の場所からグリーン湖までのターン バイ ターン方式の徒歩ルート案内と共に地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-237">Displays a map with turn-by-turn walking directions to Green Lake from your current location.</span></span> |


## <a name="download-offline-maps"></a><span data-ttu-id="5d20e-238">オフライン マップのダウンロード</span><span class="sxs-lookup"><span data-stu-id="5d20e-238">Download offline maps</span></span>


<span data-ttu-id="5d20e-239">**ms-settings:** URI スキームでは、設定アプリで特定のページを直接起動することができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-239">The **ms-settings:** URI scheme lets you launch directly into a particular page in the Settings app.</span></span> <span data-ttu-id="5d20e-240">**ms-settings:** URI スキームでは、マップ アプリが起動されませんが、設定アプリでオフライン マップ ページを直接起動し、マップ アプリが使用するオフライン マップをダウンロードするための確認ダイアログ ボックスを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-240">While the **ms-settings:** URI scheme doesn't launch into the Maps app, it does allow you to launch directly to the Offline Maps page in the Settings app and displays a confirmation dialog to download the offline maps used by the Maps app.</span></span> <span data-ttu-id="5d20e-241">URI スキームは、緯度と経度で指定されたポイントを受け取り、そのポイントが含まれる地域のオフライン マップが利用できるかどうかを自動的に判定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-241">The URI scheme accepts a point specified by a latitude and longitude and automatically determines if there are offline maps available for a region containing that point.</span></span>  <span data-ttu-id="5d20e-242">渡された緯度と経度が複数のダウンロード地域内にある場合、ユーザーは、確認ダイアログ ボックスでダウンロードする地域を選択できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-242">If the latitude and longitude passed happen to fall within multiple download regions, the confirmation dialog will let the user pick which of those regions to download.</span></span> <span data-ttu-id="5d20e-243">そのポイントが含まれる地域のオフライン マップが利用できない場合、設定アプリのオフライン マップ ページがエラー ダイアログと共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-243">If offline maps are not available for a region containing that point, the offline Maps page in the Settings app is displayed with an error dialog.</span></span>

| <span data-ttu-id="5d20e-244">サンプル URI</span><span class="sxs-lookup"><span data-stu-id="5d20e-244">Sample URI</span></span>                                                                                                | <span data-ttu-id="5d20e-245">結果</span><span class="sxs-lookup"><span data-stu-id="5d20e-245">Results</span></span>                                                                                       |
|-----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| <span data-ttu-id="5d20e-246">ms-settings:maps-downloadmaps?latlong=47.6,-122.3</span><span class="sxs-lookup"><span data-stu-id="5d20e-246">ms-settings:maps-downloadmaps?latlong=47.6,-122.3</span></span> | <span data-ttu-id="5d20e-247">設定アプリで、確認ダイアログ ボックスが表示されたオフライン マップ ページを開き、緯度と経度で指定されたポイントが含まれた地域のマップをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="5d20e-247">Opens the Settings app to the Offline Maps page with a confirmation dialog displayed to download maps for the region containing the specified latitude-longitude point.</span></span> |
 

<span id="bingmaps-param-reference"/>
## <a name="bingmaps-parameter-reference"></a><span data-ttu-id="5d20e-248">bingmaps: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d20e-248">bingmaps: parameter reference</span></span>


<span data-ttu-id="5d20e-249">次に示す各パラメーターの構文は、拡張バッカスナウア記法 (ABNF) を使って表されています。</span><span class="sxs-lookup"><span data-stu-id="5d20e-249">The syntax for each parameter in this table is shown by using Augmented Backus–Naur Form (ABNF).</span></span>

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="5d20e-250">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5d20e-250">Parameter</span></span></th>
<th align="left"><span data-ttu-id="5d20e-251">定義</span><span class="sxs-lookup"><span data-stu-id="5d20e-251">Definition</span></span></th>
<th align="left"><span data-ttu-id="5d20e-252">ABNF での定義と例</span><span class="sxs-lookup"><span data-stu-id="5d20e-252">ABNF Definition and Example</span></span></th>
<th align="left"><span data-ttu-id="5d20e-253">詳細</span><span class="sxs-lookup"><span data-stu-id="5d20e-253">Details</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-254">cp</span><span class="sxs-lookup"><span data-stu-id="5d20e-254">cp</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-255">中心点</span><span class="sxs-lookup"><span data-stu-id="5d20e-255">Center point</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-256">cp = "cp=" cpval</span><span class="sxs-lookup"><span data-stu-id="5d20e-256">cp = "cp=" cpval</span></span></p>
<p><span data-ttu-id="5d20e-257">cpval = degreeslat "~" degreeslon</span><span class="sxs-lookup"><span data-stu-id="5d20e-257">cpval = degreeslat "~" degreeslon</span></span></p>
<p><span data-ttu-id="5d20e-258">degreeslat = ["-"] 1*3DIGIT ["." 1*7DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-258">degreeslat = ["-"] 1*3DIGIT ["." 1*7DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-259">degreeslon = ["-"] 1*2DIGIT ["." 1*7DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-259">degreeslon = ["-"] 1*2DIGIT ["." 1*7DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-260">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-260">Example:</span></span></p>
<p><span data-ttu-id="5d20e-261">cp=40.726966~-74.006076</span><span class="sxs-lookup"><span data-stu-id="5d20e-261">cp=40.726966~-74.006076</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-262">どちらの値も、10 進角で表し、チルダ (**~**) で区切る必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-262">Both values must be expressed in decimal degrees and separated by a tilde(**~**).</span></span></p>
<p><span data-ttu-id="5d20e-263">有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-263">Valid longitude values are between -180 and +180 inclusive.</span></span></p>
<p><span data-ttu-id="5d20e-264">有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-264">Valid latitude values are between -90 and +90 inclusive.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-265">bb</span><span class="sxs-lookup"><span data-stu-id="5d20e-265">bb</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-266">境界ボックス</span><span class="sxs-lookup"><span data-stu-id="5d20e-266">Bounding box</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-267">bb = "bb=" southlatitude "_" westlongitude "~" northlatitude "_" eastlongitude</span><span class="sxs-lookup"><span data-stu-id="5d20e-267">bb = "bb=" southlatitude "_" westlongitude "~" northlatitude "_" eastlongitude</span></span></p>
<p><span data-ttu-id="5d20e-268">southlatitude = degreeslat</span><span class="sxs-lookup"><span data-stu-id="5d20e-268">southlatitude = degreeslat</span></span></p>
<p><span data-ttu-id="5d20e-269">northlatitude = degreeslat</span><span class="sxs-lookup"><span data-stu-id="5d20e-269">northlatitude = degreeslat</span></span></p>
<p><span data-ttu-id="5d20e-270">westlongitude = degreeslon</span><span class="sxs-lookup"><span data-stu-id="5d20e-270">westlongitude = degreeslon</span></span></p>
<p><span data-ttu-id="5d20e-271">eastlongitude = degreeslon</span><span class="sxs-lookup"><span data-stu-id="5d20e-271">eastlongitude = degreeslon</span></span></p>
<p><span data-ttu-id="5d20e-272">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-272">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-273">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-273">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-274">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-274">Example:</span></span></p>
<p><span data-ttu-id="5d20e-275">bb=39.719_-74.52~41.71_-73.5</span><span class="sxs-lookup"><span data-stu-id="5d20e-275">bb=39.719_-74.52~41.71_-73.5</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-276">境界ボックスを指定する四角形の領域。10 進角で表し、左下隅と右上隅を区別するためにチルダ (**~**) を使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-276">A rectangular area that specifies the bounding box expressed in decimal degrees, using a tilde (**~**) to separate the lower left corner from the upper right corner.</span></span> <span data-ttu-id="5d20e-277">それぞれの緯度と経度は、アンダー スコア (**_**) で区切られます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-277">Latitude and longitude for each are separated with an underscore (**_**).</span></span></p>
<p><span data-ttu-id="5d20e-278">有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-278">Valid longitude values are between -180 and +180 inclusive.</span></span></p>
<p><span data-ttu-id="5d20e-279">有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-279">Valid latitude values are between -90 and +90 inclusive.</span></span></p><p><span data-ttu-id="5d20e-280">境界ボックスが提供されている場合、cp パラメーターと lvl パラメーターは無視されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-280">The cp and lvl parameters are ignored when a bounding box is provided.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-281">where</span><span class="sxs-lookup"><span data-stu-id="5d20e-281">where</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-282">位置情報</span><span class="sxs-lookup"><span data-stu-id="5d20e-282">Location</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-283">where = "where=" whereval</span><span class="sxs-lookup"><span data-stu-id="5d20e-283">where = "where=" whereval</span></span></p>
<p><span data-ttu-id="5d20e-284">whereval = 1*( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "*" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span><span class="sxs-lookup"><span data-stu-id="5d20e-284">whereval = 1*( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "*" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span></span></p>
<p><span data-ttu-id="5d20e-285">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-285">Example:</span></span></p>
<p><span data-ttu-id="5d20e-286">where=1600%20Pennsylvania%20Ave,%20Washington,%20DC</span><span class="sxs-lookup"><span data-stu-id="5d20e-286">where=1600%20Pennsylvania%20Ave,%20Washington,%20DC</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-287">特定の所在地、ランドマーク、または場所を検索するための語句。</span><span class="sxs-lookup"><span data-stu-id="5d20e-287">Search term for a specific location, landmark or place.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-288">q</span><span class="sxs-lookup"><span data-stu-id="5d20e-288">q</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-289">クエリ語句</span><span class="sxs-lookup"><span data-stu-id="5d20e-289">Query Term</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-290">q = "q="</span><span class="sxs-lookup"><span data-stu-id="5d20e-290">q = "q="</span></span></p>
<p><span data-ttu-id="5d20e-291">whereval</span><span class="sxs-lookup"><span data-stu-id="5d20e-291">whereval</span></span></p>
<p><span data-ttu-id="5d20e-292">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-292">Example:</span></span></p>
<p><span data-ttu-id="5d20e-293">q=mexican%20restaurants</span><span class="sxs-lookup"><span data-stu-id="5d20e-293">q=mexican%20restaurants</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-294">各地のビジネスや業種を検索するための語句。</span><span class="sxs-lookup"><span data-stu-id="5d20e-294">Search term for local business or category of businesses.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-295">lvl</span><span class="sxs-lookup"><span data-stu-id="5d20e-295">lvl</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-296">ズーム レベル</span><span class="sxs-lookup"><span data-stu-id="5d20e-296">Zoom Level</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-297">lvl = "lvl=" 1*2DIGIT ["." 1*2DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-297">lvl = "lvl=" 1*2DIGIT ["." 1*2DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-298">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-298">Example:</span></span></p>
<p><span data-ttu-id="5d20e-299">lvl=10.50</span><span class="sxs-lookup"><span data-stu-id="5d20e-299">lvl=10.50</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-300">地図ビューのズーム レベルを定義します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-300">Defines the zoom level of the map view.</span></span> <span data-ttu-id="5d20e-301">有効な値は 1 ～ 20 です。1 は、最も縮小された状態で表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-301">Valid values are 1-20 where 1 is zoomed all the way out.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-302">sty</span><span class="sxs-lookup"><span data-stu-id="5d20e-302">sty</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-303">形式</span><span class="sxs-lookup"><span data-stu-id="5d20e-303">Style</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-304">sty = "sty=" ("a" / "r"/"3d")</span><span class="sxs-lookup"><span data-stu-id="5d20e-304">sty = "sty=" ("a" / "r"/"3d")</span></span></p>
<p><span data-ttu-id="5d20e-305">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-305">Example:</span></span></p>
<p><span data-ttu-id="5d20e-306">sty=a</span><span class="sxs-lookup"><span data-stu-id="5d20e-306">sty=a</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-307">地図の形式を定義します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-307">Defines the map style.</span></span> <span data-ttu-id="5d20e-308">このパラメーターの有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-308">Valid values for this parameter include:</span></span></p>
<ul>
<li><span data-ttu-id="5d20e-309">**a**: 地図の航空写真を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-309">**a**: Display an aerial view of the map.</span></span></li>
<li><span data-ttu-id="5d20e-310">**r**: 地図の道路図を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-310">**r**: Display a road view of the map.</span></span></li>
<li><span data-ttu-id="5d20e-311">**3d**: 地図を 3D で表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-311">**3d**: Display a 3D view of the map.</span></span> <span data-ttu-id="5d20e-312">**cp** パラメーターと組み合わせて使います。必要に応じて、**rad** パラメーターと共に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-312">Use in conjunction with the **cp** parameter and optionally with the **rad** parameter.</span></span></li>
</ul>
<p><span data-ttu-id="5d20e-313">Windows 10 では、航空写真表示と 3D ビューのスタイルは同じです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-313">In Windows 10, the aerial view and 3D view styles are the same.</span></span></p>
<div class="alert"><span data-ttu-id="5d20e-314">
**注**  **sty** パラメーターを省略すると、sty=r と同じ結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-314">
**Note**  Omitting the **sty** parameter produces the same results as sty=r.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-315">rad</span><span class="sxs-lookup"><span data-stu-id="5d20e-315">rad</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-316">半径</span><span class="sxs-lookup"><span data-stu-id="5d20e-316">Radius</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-317">rad = "rad=" 1*8DIGIT</span><span class="sxs-lookup"><span data-stu-id="5d20e-317">rad = "rad=" 1*8DIGIT</span></span></p>
<p><span data-ttu-id="5d20e-318">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-318">Example:</span></span></p>
<p><span data-ttu-id="5d20e-319">rad=1000</span><span class="sxs-lookup"><span data-stu-id="5d20e-319">rad=1000</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-320">目的の地図ビューを表す円形領域です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-320">A circular area that specifies the desired map view.</span></span> <span data-ttu-id="5d20e-321">半径の値はメートル単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-321">The radius value is measured in meters.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-322">pit</span><span class="sxs-lookup"><span data-stu-id="5d20e-322">pit</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-323">ピッチ</span><span class="sxs-lookup"><span data-stu-id="5d20e-323">Pitch</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-324">pit = "pit=" pitch</span><span class="sxs-lookup"><span data-stu-id="5d20e-324">pit = "pit=" pitch</span></span></p>
<p><span data-ttu-id="5d20e-325">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-325">Example:</span></span></p>
<p><span data-ttu-id="5d20e-326">pit=60</span><span class="sxs-lookup"><span data-stu-id="5d20e-326">pit=60</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-327">地図を表示する角度を指定します。90 は水平方向を見ること (最大) を表し、0 は真下を見下ろすこと (最小) を表します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-327">Indicates the angle that the map is viewed at, where 90 is looking out at the horizon (maximum) and 0 is looking straight down (minimum).</span></span></p><p><span data-ttu-id="5d20e-328">有効なピッチの値の範囲は 0 ～ 90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-328">Valid pitch values are between 0 and 90 inclusive.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-329">hdg</span><span class="sxs-lookup"><span data-stu-id="5d20e-329">hdg</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-330">方位</span><span class="sxs-lookup"><span data-stu-id="5d20e-330">Heading</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-331">hdg = "hdg=" heading</span><span class="sxs-lookup"><span data-stu-id="5d20e-331">hdg = "hdg=" heading</span></span></p>
<p><span data-ttu-id="5d20e-332">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-332">Example:</span></span></p>
<p><span data-ttu-id="5d20e-333">hdg=180</span><span class="sxs-lookup"><span data-stu-id="5d20e-333">hdg=180</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-334">地図の向いている方位を角度で指定します。0 または 360 は北、90 は東、180 は南、270 は西を表します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-334">Indicates the direction the map is heading in degrees, where 0 or 360 = North, 90 = East, 180 = South, and 270 = West.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-335">ss</span><span class="sxs-lookup"><span data-stu-id="5d20e-335">ss</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-336">Streetside</span><span class="sxs-lookup"><span data-stu-id="5d20e-336">Streetside</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-337">ss = "ss=" BIT</span><span class="sxs-lookup"><span data-stu-id="5d20e-337">ss = "ss=" BIT</span></span></p>
<p><span data-ttu-id="5d20e-338">例: </span><span class="sxs-lookup"><span data-stu-id="5d20e-338">Example:</span></span></p>
<p><span data-ttu-id="5d20e-339">ss=1</span><span class="sxs-lookup"><span data-stu-id="5d20e-339">ss=1</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-340"><code>ss=1</code> の場合は、ストリート レベルの画像が表示されることを示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-340">Indicates that street-level imagery is shown when <code>ss=1</code>.</span></span> <span data-ttu-id="5d20e-341">**ss** パラメーターを省略すると、<code>ss=0</code> と同じ結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-341">Omitting the **ss** parameter produces the same result as <code>ss=0</code>.</span></span> <span data-ttu-id="5d20e-342">**cp** パラメーターと組み合わせて使うと、ストリート レベル ビューの場所を指定できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-342">Use in conjunction with the **cp** parameter to specify the location of the street-level view.</span></span></p>
<div class="alert"><span data-ttu-id="5d20e-343">
**注**  ストリート レベルの画像は、すべての地域で利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-343">
**Note**  Street-level imagery is not available in all regions.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-344">trfc</span><span class="sxs-lookup"><span data-stu-id="5d20e-344">trfc</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-345">交通情報</span><span class="sxs-lookup"><span data-stu-id="5d20e-345">Traffic</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-346">trfc = "trfc=" BIT</span><span class="sxs-lookup"><span data-stu-id="5d20e-346">trfc = "trfc=" BIT</span></span></p>
<p><span data-ttu-id="5d20e-347">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-347">Example:</span></span></p>
<p><span data-ttu-id="5d20e-348">trfc=1</span><span class="sxs-lookup"><span data-stu-id="5d20e-348">trfc=1</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-349">交通情報を地図に含めるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-349">Specifies whether traffic information is included on the map.</span></span> <span data-ttu-id="5d20e-350">trfc パラメーターを省略すると、<code>trfc=0</code> と同じ結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-350">Omitting the trfc parameter produces the same results as <code>trfc=0</code>.</span></span></p>
<div class="alert"><span data-ttu-id="5d20e-351">
**注**  交通情報のデータは、すべての地域で利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-351">
**Note**  Traffic data is not available in all regions.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-352">rtp</span><span class="sxs-lookup"><span data-stu-id="5d20e-352">rtp</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-353">ルート</span><span class="sxs-lookup"><span data-stu-id="5d20e-353">Route</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-354">rtp = "rtp=" (waypoint "~" [waypoint]) / ("~" waypoint)</span><span class="sxs-lookup"><span data-stu-id="5d20e-354">rtp = "rtp=" (waypoint "~" [waypoint]) / ("~" waypoint)</span></span></p>
<p><span data-ttu-id="5d20e-355">waypoint = ("pos."</span><span class="sxs-lookup"><span data-stu-id="5d20e-355">waypoint = ("pos."</span></span> <span data-ttu-id="5d20e-356">point ) / ("adr."</span><span class="sxs-lookup"><span data-stu-id="5d20e-356">point ) / ("adr."</span></span> <span data-ttu-id="5d20e-357">whereval)</span><span class="sxs-lookup"><span data-stu-id="5d20e-357">whereval)</span></span></p>
<p><span data-ttu-id="5d20e-358">point = "point."</span><span class="sxs-lookup"><span data-stu-id="5d20e-358">point = "point."</span></span> <span data-ttu-id="5d20e-359">pointval ["_" title]</span><span class="sxs-lookup"><span data-stu-id="5d20e-359">pointval ["_" title]</span></span></p>
<p><span data-ttu-id="5d20e-360">pointval = degreeslat "" degreeslon</span><span class="sxs-lookup"><span data-stu-id="5d20e-360">pointval = degreeslat "" degreeslon</span></span></p>
<p><span data-ttu-id="5d20e-361">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-361">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-362">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-362">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span></span></p>
<p><span data-ttu-id="5d20e-363">title = whereval</span><span class="sxs-lookup"><span data-stu-id="5d20e-363">title = whereval</span></span></p>
<p><span data-ttu-id="5d20e-364">whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span><span class="sxs-lookup"><span data-stu-id="5d20e-364">whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span></span></p>


<p><span data-ttu-id="5d20e-365">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-365">Examples:</span></span></p>
<p><span data-ttu-id="5d20e-366">rtp=adr.Mountain%20View,%20CA~adr.SFO</span><span class="sxs-lookup"><span data-stu-id="5d20e-366">rtp=adr.Mountain%20View,%20CA~adr.SFO</span></span></p>
<p><span data-ttu-id="5d20e-367">rtp=adr.One%20Microsoft%20Way,%20Redmond,%20WA~pos.45.23423_-122.1232 _My%20Picnic%20Spot</span><span class="sxs-lookup"><span data-stu-id="5d20e-367">rtp=adr.One%20Microsoft%20Way,%20Redmond,%20WA~pos.45.23423_-122.1232 _My%20Picnic%20Spot</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-368">地図上に表示するルートの開始地点と終了地点を、チルダ (**~**) で区切って定義します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-368">Defines the start and end of a route to draw on the map, separated by a tilde (**~**).</span></span> <span data-ttu-id="5d20e-369">各中間点は、緯度、経度、オプションのタイトルを使った位置、または住所の識別情報を使って定義します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-369">Each of the waypoints is defined by either a position using ltitude, longitude, and optional title or an address identifier.</span></span></p>
<p><span data-ttu-id="5d20e-370">完全なルートとは、中間点が 2 つだけ含まれるルートです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-370">A complete route contains exactly two waypoints.</span></span> <span data-ttu-id="5d20e-371">たとえば、2 つの中間点を持つルートは、<code>rtp="A"~"B"</code> のように定義されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-371">For example, a route with two waypoints is defined by <code>rtp="A"~"B"</code>.</span></span></p>
<p><span data-ttu-id="5d20e-372">不完全なルートを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-372">It's also acceptable to specify an incomplete route.</span></span> <span data-ttu-id="5d20e-373">たとえば、ルートの開始地点だけを定義する場合は、<code>rtp="A"~</code> のように指定できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-373">For example, you can define only the start of a route with <code>rtp="A"~</code>.</span></span> <span data-ttu-id="5d20e-374">この場合、ルート案内の入力が表示されると、**[出発地]** フィールドには指定された中間点が表示され、**[目的地]** フィールドにフォーカスが設定されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-374">In this case, the directions input is displayed with the provided waypoint in the **From** field and the **To** field has focus.</span></span></p>
<p><span data-ttu-id="5d20e-375"><code>rtp=~"B"</code> のようにルートの終了地点のみを指定した場合は、ルート案内のパネルが表示されると、**[目的地]** フィールドには指定された中間点が表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-375">If only the end of a route is specified, as with <code>rtp=~"B"</code>, the directions panel is displayed with the provided waypoint in the **To** field.</span></span> <span data-ttu-id="5d20e-376">現在の正確な位置情報にアクセスできる場合、**[出発地]** フィールドに現在の場所があらかじめ入力され、フォーカスが設定されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-376">If an accurate current location is available, the current location is pre-populated in the **From** field with focus.</span></span></p>
<p><span data-ttu-id="5d20e-377">不完全なルートが指定されている場合は、ルートの線は表示されません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-377">No route line is drawn when an incomplete route is given.</span></span></p>
<p><span data-ttu-id="5d20e-378">**mode** パラメーターと組み合わせて使うと、交通手段のモード (自動車、公共交通機関、徒歩) を指定できます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-378">Use in conjunction with the **mode** parameter to specify the mode of transportation (driving, transit, or walking).</span></span> <span data-ttu-id="5d20e-379">**mode** が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-379">If **mode** isn't specified, directions will be provided using the user's mode of transportation preference.</span></span></p>
<div class="alert"><span data-ttu-id="5d20e-380">
**注**  **pos** パラメーターの値によって場所が指定されている場合、その場所に対してタイトルを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-380">
**Note**  A title can be used for a location if the location is specified by the **pos** parameter value.</span></span> <span data-ttu-id="5d20e-381">緯度と経度が表示される代わりに、タイトルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-381">Rather than showing the latitude and longitude, the title will be displayed.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p>**<span data-ttu-id="5d20e-382">mode</span><span class="sxs-lookup"><span data-stu-id="5d20e-382">mode</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-383">交通手段モード</span><span class="sxs-lookup"><span data-stu-id="5d20e-383">Transportation mode</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-384">mode = "mode=" ("d" / "t" / "w")</span><span class="sxs-lookup"><span data-stu-id="5d20e-384">mode = "mode=" ("d" / "t" / "w")</span></span></p>
<p><span data-ttu-id="5d20e-385">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-385">Example:</span></span></p>
<p><span data-ttu-id="5d20e-386">mode=d</span><span class="sxs-lookup"><span data-stu-id="5d20e-386">mode=d</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-387">交通手段モードを定義します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-387">Defines the transportation mode.</span></span> <span data-ttu-id="5d20e-388">このパラメーターの有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-388">Valid values for this parameter include:</span></span></p>
<ul>
<li><span data-ttu-id="5d20e-389">**d**: 自動車ルート案内のルートの概要を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-389">**d**: Displays route overview for driving directions</span></span></li>
<li><span data-ttu-id="5d20e-390">**t**: 乗り換え案内のルートの概要を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-390">**t**: Displays route overview for transit directions</span></span></li>
<li><span data-ttu-id="5d20e-391">**w**: 徒歩ルート案内のルートの概要を表示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-391">**w**: Displays route overview for walking directions</span></span></li>
</ul>
<p><span data-ttu-id="5d20e-392">交通手段案内の **rtp** パラメーターと組み合わせて使います。</span><span class="sxs-lookup"><span data-stu-id="5d20e-392">Use in conjunction with the **rtp** parameter for transportation directions.</span></span> <span data-ttu-id="5d20e-393">**mode** が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-393">If **mode** isn't specified, directions will be provided using the user's mode of transportation preference.</span></span> <span data-ttu-id="5d20e-394">現在の位置情報からこのモード用のルート案内に入力するルート パラメーターなしに、**mode** を提供することができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-394">A **mode** can be provided with no route parameter to enter directions input for that mode from the current location.</span></span></p></td>
</tr>

<tr class="even">
<td align="left"><p>**<span data-ttu-id="5d20e-395">collection</span><span class="sxs-lookup"><span data-stu-id="5d20e-395">collection</span></span>**</p></td>
<td align="left"><p><span data-ttu-id="5d20e-396">コレクション</span><span class="sxs-lookup"><span data-stu-id="5d20e-396">Collection</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-397">collection = "collection="(name"~"/)point["~"point]</span><span class="sxs-lookup"><span data-stu-id="5d20e-397">collection = "collection="(name"~"/)point["~"point]</span></span></p>
<p><span data-ttu-id="5d20e-398">name = "name."</span><span class="sxs-lookup"><span data-stu-id="5d20e-398">name = "name."</span></span> <span data-ttu-id="5d20e-399">whereval</span><span class="sxs-lookup"><span data-stu-id="5d20e-399">whereval</span></span> </p>
<p><span data-ttu-id="5d20e-400">whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span><span class="sxs-lookup"><span data-stu-id="5d20e-400">whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?")</span></span> </p>
<p><span data-ttu-id="5d20e-401">point = "point."</span><span class="sxs-lookup"><span data-stu-id="5d20e-401">point = "point."</span></span> <span data-ttu-id="5d20e-402">pointval ["_" title]</span><span class="sxs-lookup"><span data-stu-id="5d20e-402">pointval ["_" title]</span></span> </p>
<p><span data-ttu-id="5d20e-403">pointval = degreeslat "" degreeslon</span><span class="sxs-lookup"><span data-stu-id="5d20e-403">pointval = degreeslat "" degreeslon</span></span> </p>
<p><span data-ttu-id="5d20e-404">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-404">degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</span></span> </p>
<p><span data-ttu-id="5d20e-405">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span><span class="sxs-lookup"><span data-stu-id="5d20e-405">degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</span></span> </p>
<p><span data-ttu-id="5d20e-406">title = whereval</span><span class="sxs-lookup"><span data-stu-id="5d20e-406">title = whereval</span></span></p>


<p><span data-ttu-id="5d20e-407">例:</span><span class="sxs-lookup"><span data-stu-id="5d20e-407">Example:</span></span></p>
<p><span data-ttu-id="5d20e-408">collection=name.My%20Trip%20Stops~point.36.116584_-115.176753_Las%20Vegas~point.37.8268_-122.4798_Golden%20Gate%20Bridge</span><span class="sxs-lookup"><span data-stu-id="5d20e-408">collection=name.My%20Trip%20Stops~point.36.116584_-115.176753_Las%20Vegas~point.37.8268_-122.4798_Golden%20Gate%20Bridge</span></span></p></td>
<td align="left"><p><span data-ttu-id="5d20e-409">地図と一覧に追加されるポイントのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="5d20e-409">Collection of points to be added to the map and list.</span></span> <span data-ttu-id="5d20e-410">name パラメーターを使用して、ポイントのコレクションに名前を付けることができます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-410">The collection of points can be named using the name parameter.</span></span> <span data-ttu-id="5d20e-411">ポイントは、緯度、経度、およびオプションのタイトルを使用して指定されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-411">A point is specified using a latitude, longitude, and optional title.</span></span></p>
<p><span data-ttu-id="5d20e-412">名前と複数のポイントをチルダ (**~**) で区切ります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-412">Separate name and multiple points with tildes (**~**).</span></span></p>
<p><span data-ttu-id="5d20e-413">指定した項目にチルダが含まれている場合は、そのチルダを <code>%7E</code> としてエンコードしてください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-413">If the item you specify contains a tilde, make sure the tilde is encoded as <code>%7E</code>.</span></span> <span data-ttu-id="5d20e-414">中心点のパラメーターやズーム レベルのパラメーターと共に使わない場合、コレクションによって、最適な地図ビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-414">If not accompanied by Center point and Zoom Level parameters, the collection will provide the best map view.</span></span></p>

<p><span data-ttu-id="5d20e-415">**重要** 指定した項目にアンダースコアが含まれている場合は、そのアンダースコアを %255F としてダブル エンコードしてください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-415">**Important** If the item you specify contains an underscore, make sure the underscore is double encoded as %255F.</span></span></p></td>
</tr>
</tbody>
</table>

  
<span id="ms-drive-to-param-reference"/>
## <span data-ttu-id="5d20e-416">ms-drive-to: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d20e-416">ms-drive-to: parameter reference</span></span>


<span data-ttu-id="5d20e-417">ターン バイ ターン方式の自動車ルート案内の要求を起動する URI は、エンコードする必要がありません。その形式は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-417">The URI to launch a request for turn-by-turn driving directions does not need to be encoded and has the following format.</span></span>

> <span data-ttu-id="5d20e-418">**注**  この URI スキームでは出発地を指定しません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-418">**Note**  You don’t specify the starting point in this URI scheme.</span></span> <span data-ttu-id="5d20e-419">常に、現在の場所が出発地であると見なされます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-419">The starting point is always assumed to be the current location.</span></span> <span data-ttu-id="5d20e-420">現在の場所以外の出発地を指定する必要がある場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-420">If you need to specify a starting point other than the current location, see [Display directions and traffic](#display-directions-and-traffic).</span></span>

 

| <span data-ttu-id="5d20e-421">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5d20e-421">Parameter</span></span> | <span data-ttu-id="5d20e-422">定義</span><span class="sxs-lookup"><span data-stu-id="5d20e-422">Definition</span></span> | <span data-ttu-id="5d20e-423">例</span><span class="sxs-lookup"><span data-stu-id="5d20e-423">Example</span></span> | <span data-ttu-id="5d20e-424">詳細</span><span class="sxs-lookup"><span data-stu-id="5d20e-424">Details</span></span> |
|------------|-----------|---------|---------|
| **<span data-ttu-id="5d20e-425">destination.latitude</span><span class="sxs-lookup"><span data-stu-id="5d20e-425">destination.latitude</span></span>** | <span data-ttu-id="5d20e-426">目的地の緯度</span><span class="sxs-lookup"><span data-stu-id="5d20e-426">Destination latitude</span></span> | <span data-ttu-id="5d20e-427">例: destination.latitude=47.6451413797194</span><span class="sxs-lookup"><span data-stu-id="5d20e-427">Example: destination.latitude=47.6451413797194</span></span> | <span data-ttu-id="5d20e-428">目的地の緯度です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-428">The latitude of the destination.</span></span> <span data-ttu-id="5d20e-429">有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-429">Valid latitude values are between -90 and +90 inclusive.</span></span> |
| **<span data-ttu-id="5d20e-430">destination.longitude</span><span class="sxs-lookup"><span data-stu-id="5d20e-430">destination.longitude</span></span>** | <span data-ttu-id="5d20e-431">目的地の経度</span><span class="sxs-lookup"><span data-stu-id="5d20e-431">Destination longitude</span></span> | <span data-ttu-id="5d20e-432">例: destination.longitude=-122.141964733601</span><span class="sxs-lookup"><span data-stu-id="5d20e-432">Example: destination.longitude=-122.141964733601</span></span> | <span data-ttu-id="5d20e-433">目的地の経度です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-433">The longitude of the destination.</span></span> <span data-ttu-id="5d20e-434">有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-434">Valid longitude values are between -180 and +180 inclusive.</span></span> |
| **<span data-ttu-id="5d20e-435">destination.name</span><span class="sxs-lookup"><span data-stu-id="5d20e-435">destination.name</span></span>** | <span data-ttu-id="5d20e-436">目的地の名前</span><span class="sxs-lookup"><span data-stu-id="5d20e-436">Name of the destination</span></span> | <span data-ttu-id="5d20e-437">例: destination.name=Redmond, WA</span><span class="sxs-lookup"><span data-stu-id="5d20e-437">Example: destination.name=Redmond, WA</span></span> | <span data-ttu-id="5d20e-438">目的地の名前です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-438">The name of the destination.</span></span> <span data-ttu-id="5d20e-439">**destination.name** 値をエンコードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-439">You do not have to encode the **destination.name** value.</span></span> |

 
<span id="ms-walk-to-param-reference"/>
## <a name="ms-walk-to-parameter-reference"></a><span data-ttu-id="5d20e-440">ms-walk-to: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d20e-440">ms-walk-to: parameter reference</span></span>


<span data-ttu-id="5d20e-441">ターン バイ ターン方式の徒歩ルート案内の要求を起動する URI は、エンコードする必要がありません。その形式は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5d20e-441">The URI to launch a request for turn-by-turn walking directions does not need to be encoded and has the following format.</span></span>

> <span data-ttu-id="5d20e-442">**注**  この URI スキームでは出発地を指定しません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-442">**Note**  You don’t specify the starting point in this URI scheme.</span></span> <span data-ttu-id="5d20e-443">常に、現在の場所が出発地であると見なされます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-443">The starting point is always assumed to be the current location.</span></span> <span data-ttu-id="5d20e-444">現在の場所以外の出発地を指定する必要がある場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d20e-444">If you need to specify a starting point other than the current location, see [Display directions and traffic](#display-directions-and-traffic).</span></span>
 

| <span data-ttu-id="5d20e-445">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5d20e-445">Parameter</span></span> | <span data-ttu-id="5d20e-446">定義</span><span class="sxs-lookup"><span data-stu-id="5d20e-446">Definition</span></span> | <span data-ttu-id="5d20e-447">例</span><span class="sxs-lookup"><span data-stu-id="5d20e-447">Example</span></span> | <span data-ttu-id="5d20e-448">詳細</span><span class="sxs-lookup"><span data-stu-id="5d20e-448">Details</span></span> |
|-----------|------------|---------|----------|
| **<span data-ttu-id="5d20e-449">destination.latitude</span><span class="sxs-lookup"><span data-stu-id="5d20e-449">destination.latitude</span></span>** | <span data-ttu-id="5d20e-450">目的地の緯度</span><span class="sxs-lookup"><span data-stu-id="5d20e-450">Destination latitude</span></span> | <span data-ttu-id="5d20e-451">例: destination.latitude=47.6451413797194</span><span class="sxs-lookup"><span data-stu-id="5d20e-451">Example: destination.latitude=47.6451413797194</span></span> | <span data-ttu-id="5d20e-452">目的地の緯度です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-452">The latitude of the destination.</span></span> <span data-ttu-id="5d20e-453">有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-453">Valid latitude values are between -90 and +90 inclusive.</span></span> |
| **<span data-ttu-id="5d20e-454">destination.longitude</span><span class="sxs-lookup"><span data-stu-id="5d20e-454">destination.longitude</span></span>** | <span data-ttu-id="5d20e-455">目的地の経度</span><span class="sxs-lookup"><span data-stu-id="5d20e-455">Destination longitude</span></span> | <span data-ttu-id="5d20e-456">例: destination.longitude=-122.141964733601</span><span class="sxs-lookup"><span data-stu-id="5d20e-456">Example: destination.longitude=-122.141964733601</span></span> | <span data-ttu-id="5d20e-457">目的地の経度です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-457">The longitude of the destination.</span></span> <span data-ttu-id="5d20e-458">有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-458">Valid longitude values are between -180 and +180 inclusive.</span></span> |
| **<span data-ttu-id="5d20e-459">destination.name</span><span class="sxs-lookup"><span data-stu-id="5d20e-459">destination.name</span></span>** | <span data-ttu-id="5d20e-460">目的地の名前</span><span class="sxs-lookup"><span data-stu-id="5d20e-460">Name of the destination</span></span> | <span data-ttu-id="5d20e-461">例: destination.name=Redmond, WA</span><span class="sxs-lookup"><span data-stu-id="5d20e-461">Example: destination.name=Redmond, WA</span></span> | <span data-ttu-id="5d20e-462">目的地の名前です。</span><span class="sxs-lookup"><span data-stu-id="5d20e-462">The name of the destination.</span></span> <span data-ttu-id="5d20e-463">**destination.name** 値をエンコードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5d20e-463">You do not have to encode the **destination.name** value.</span></span> |

 
## <a name="ms-settings-parameter-reference"></a><span data-ttu-id="5d20e-464">ms-settings: のパラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="5d20e-464">ms-settings: parameter reference</span></span>


<span data-ttu-id="5d20e-465">**ms-settings:** URI スキームのマップ アプリ固有のパラメーターの構文は、次のように定義されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-465">The syntax for maps app specific parameters for the **ms-settings:** URI scheme is defined below.</span></span> <span data-ttu-id="5d20e-466">**maps-downloadmaps** は、**ms-settings:** URI と共に **ms-settings:maps-downloadmaps?** の形式で指定され、オフライン マップの設定ページを示します。</span><span class="sxs-lookup"><span data-stu-id="5d20e-466">**maps-downloadmaps** is specified along with the **ms-settings:** URI in the form of **ms-settings:maps-downloadmaps?** to indicate the offline maps settings page.</span></span>

 

| <span data-ttu-id="5d20e-467">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5d20e-467">Parameter</span></span> | <span data-ttu-id="5d20e-468">定義</span><span class="sxs-lookup"><span data-stu-id="5d20e-468">Definition</span></span> | <span data-ttu-id="5d20e-469">例</span><span class="sxs-lookup"><span data-stu-id="5d20e-469">Example</span></span> | <span data-ttu-id="5d20e-470">詳細</span><span class="sxs-lookup"><span data-stu-id="5d20e-470">Details</span></span> |
|-----------|------------|---------|----------|
| **<span data-ttu-id="5d20e-471">latlong</span><span class="sxs-lookup"><span data-stu-id="5d20e-471">latlong</span></span>** | <span data-ttu-id="5d20e-472">オフライン マップの地域を定義するポイント。</span><span class="sxs-lookup"><span data-stu-id="5d20e-472">Point defining offline map region.</span></span> | <span data-ttu-id="5d20e-473">例: latlong=47.6,-122.3</span><span class="sxs-lookup"><span data-stu-id="5d20e-473">Example: latlong=47.6,-122.3</span></span> | <span data-ttu-id="5d20e-474">GeoPoint は、コンマ区切りの緯度と経度で指定されます。</span><span class="sxs-lookup"><span data-stu-id="5d20e-474">The geopoint is specified by a comma separated latitude and longitude.</span></span> <span data-ttu-id="5d20e-475">有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-475">Valid latitude values are between -90 and +90 inclusive.</span></span> <span data-ttu-id="5d20e-476">有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</span><span class="sxs-lookup"><span data-stu-id="5d20e-476">Valid longitude values are between -180 and +180 inclusive.</span></span> |
 

 
