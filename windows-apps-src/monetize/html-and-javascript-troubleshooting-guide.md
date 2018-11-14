---
author: Xansky
ms.assetid: 7a61c328-77be-4614-b117-a32a592c9efe
description: JavaScript/HTML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。
title: HTML と JavaScript のトラブルシューティング ガイド
ms.author: mhopkins
ms.date: 08/23/2017
ms.topic: article
keywords: Windows 10, UWP, 広告, Advertising, AdControl, トラブルシューティング, HTML, JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: 38f0b36769d13d119965e7d15c5812b9ba1d6ecd
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6463668"
---
# <a name="html-and-javascript-troubleshooting-guide"></a><span data-ttu-id="4985d-104">HTML と JavaScript のトラブルシューティング ガイド</span><span class="sxs-lookup"><span data-stu-id="4985d-104">HTML and JavaScript troubleshooting guide</span></span>

<span data-ttu-id="4985d-105">このトピックでは、JavaScript/HTML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。</span><span class="sxs-lookup"><span data-stu-id="4985d-105">This topic contains solutions to common development issues with the Microsoft advertising libraries in JavaScript/HTML apps.</span></span>

* [<span data-ttu-id="4985d-106">HTML</span><span class="sxs-lookup"><span data-stu-id="4985d-106">HTML</span></span>](#html)
  * [<span data-ttu-id="4985d-107">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="4985d-107">AdControl not appearing</span></span>](#html-notappearing)
  * [<span data-ttu-id="4985d-108">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="4985d-108">Black box blinks and disappears</span></span>](#html-blackboxblinksdisappears)
  * [<span data-ttu-id="4985d-109">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="4985d-109">Ads not refreshing</span></span>](#html-adsnotrefreshing)

* [<span data-ttu-id="4985d-110">JavaScript</span><span class="sxs-lookup"><span data-stu-id="4985d-110">JavaScript</span></span>](#js)
  * [<span data-ttu-id="4985d-111">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="4985d-111">AdControl not appearing</span></span>](#js-adcontrolnotappearing)
  * [<span data-ttu-id="4985d-112">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="4985d-112">Black box blinks and disappears</span></span>](#js-blackboxblinksdisappears)
  * [<span data-ttu-id="4985d-113">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="4985d-113">Ads not refreshing</span></span>](#js-adsnotrefreshing)

## <a name="html"></a><span data-ttu-id="4985d-114">HTML</span><span class="sxs-lookup"><span data-stu-id="4985d-114">HTML</span></span>

<span id="html-notappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="4985d-115">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="4985d-115">AdControl not appearing</span></span>

1.  <span data-ttu-id="4985d-116">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-116">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="4985d-117">JavaScript の参照が存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-117">Ensure the JavaScript reference is present.</span></span> <span data-ttu-id="4985d-118">&lt;head&gt; セクション (default.js リファレンスの後ろ) に ad.js の参照がない場合、**AdControl** は表示できず、ビルド中にエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="4985d-118">Without the ad.js reference in the &lt;head&gt; section (after the default.js reference) the **AdControl** will be unable to display and an error will occur during build.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <head>
        ...
        <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
        ...
    </head>
    ```

3.  <span data-ttu-id="4985d-119">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-119">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="4985d-120">これらの Id は、アプリケーション ID とパートナー センターで取得した広告ユニット ID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-120">These IDs must match the application ID and ad unit ID that you obtained in Partner Center.</span></span> <span data-ttu-id="4985d-121">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985d-121">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 50px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

4.  <span data-ttu-id="4985d-122">**height** プロパティと **width** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-122">Check the **height** and **width** properties.</span></span> <span data-ttu-id="4985d-123">これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-123">These must be set to one of the [supported ad sizes for banner ads](supported-ad-sizes-for-banner-ads.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 50px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

5.  <span data-ttu-id="4985d-124">要素の配置を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-124">Check the element positioning.</span></span> <span data-ttu-id="4985d-125">[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) は表示可能領域の内部にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-125">The [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) must be inside the viewable area.</span></span>

6.  <span data-ttu-id="4985d-126">**visibility** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-126">Check the **visibility** property.</span></span> <span data-ttu-id="4985d-127">このプロパティは、collapsed または hidden に設定しないでください。</span><span class="sxs-lookup"><span data-stu-id="4985d-127">This property must not be set to collapsed or hidden.</span></span> <span data-ttu-id="4985d-128">(次のように) インラインで設定できるほか、外部スタイル シートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="4985d-128">This property can be set inline (as shown below) or in an external style sheet.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

7.  <span data-ttu-id="4985d-129">**position** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-129">Check the **position** property.</span></span> <span data-ttu-id="4985d-130">position は、要素の他のプロパティ (親要素の margin、z-index など) に応じた適切な値に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-130">The position property must be set to an appropriate value depending on the element’s other properties (for example, margins in parent element and z-index).</span></span> <span data-ttu-id="4985d-131">(次のように) インラインで設定できるほか、外部スタイル シートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="4985d-131">This property can be set inline (as shown below) or in an external style sheet.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

8.  <span data-ttu-id="4985d-132">**z-index** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-132">Check the **z-index** property.</span></span> <span data-ttu-id="4985d-133">**z-index** プロパティは、**AdControl** が常に他の要素の上に表示されるように、十分な高さに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-133">The **z-index** property must be set high enough so the **AdControl** always appears on top of other elements.</span></span> <span data-ttu-id="4985d-134">(次のように) インラインで設定できるほか、外部スタイル シートで設定できます。</span><span class="sxs-lookup"><span data-stu-id="4985d-134">This property can be set inline (as shown below) or in an external style sheet.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

9.  <span data-ttu-id="4985d-135">外部スタイル シートを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-135">Check external style sheets.</span></span> <span data-ttu-id="4985d-136">外部スタイル シートを使って **AdControl** 要素でプロパティを設定している場合、上記のプロパティがすべて正しく設定されていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4985d-136">If properties are set on the **AdControl** element through an external style sheet, ensure all of the above properties are correctly set.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

10. <span data-ttu-id="4985d-137">**AdControl** の親を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-137">Check the parent of the **AdControl**.</span></span> <span data-ttu-id="4985d-138">**AdControl** が親要素の中にある場合、この親はアクティブで表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-138">If the **AdControl** resides in a parent element, the parent must be active and visible.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div style="position: absolute; width: 500px; height: 500px;">
        <div id="myAd" style="position: relative; top: 0px; left: 100px;
                              width: 250px; height: 250px; z-index: 1"
             data-win-control="MicrosoftNSJS.Advertising.AdControl"
             data-win-options="{applicationId: 'ApplicationID',
                                adUnitId: 'AdUnitID'}">
        </div>
    </div>
    ```

11. <span data-ttu-id="4985d-139">**AdControl** がビューポートから隠れていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-139">Ensure the **AdControl** is not hidden from the viewport.</span></span> <span data-ttu-id="4985d-140">**AdControl** は、広告が正常に表示されるように、見える必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-140">The **AdControl** must be visible for ads to display properly.</span></span>

12. <span data-ttu-id="4985d-141">[ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) と [AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="4985d-141">Live values for [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) and [AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) should not be tested in the emulator.</span></span> <span data-ttu-id="4985d-142">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="4985d-142">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="html-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="4985d-143">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="4985d-143">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="4985d-144">前の「[AdControl が表示されない](#html-notappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-144">Double-check all steps in the previous [AdControl not appearing](#html-notappearing) section.</span></span>

2.  <span data-ttu-id="4985d-145">**onErrorOccurred** イベントを処理します。イベント ハンドラーに渡されるメッセージを使って、エラーが発生したかどうかと、スローされたエラーの種類を特定します。</span><span class="sxs-lookup"><span data-stu-id="4985d-145">Handle the **onErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="4985d-146">詳しくは、「[Error handling in JavaScript walkthrough (JavaScript チュートリアルでのエラー処理)](error-handling-in-javascript-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985d-146">More details can be found in [Error handling in JavaScript walkthrough](error-handling-in-javascript-walkthrough.md).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 728px; height: 90px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID',
                            onErrorOccurred: errorLogger}">
    </div>
    <div style="position:absolute; width:100%; height:130px; top:300px; left:0px">
        <b>Ad Events</b><br />
        <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
    </div>
    ```

    <span data-ttu-id="4985d-147">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="4985d-147">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="4985d-148">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="4985d-148">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="4985d-149">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-149">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="4985d-150">既定では、**AdControl** は広告を表示できない場合に折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="4985d-150">By default, the **AdControl** will collapse when it cannot display an ad.</span></span> <span data-ttu-id="4985d-151">他の要素が同じ親の子である場合、これらの他の要素は折りたたんだ **AdControl** の隙間を埋めるように移動し、次の要求がなされたときに展開することがあります。</span><span class="sxs-lookup"><span data-stu-id="4985d-151">If other elements are children of the same parent they may move to fill the gap of the collapsed **AdControl** and expand when the next request is made.</span></span>

<span id="html-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="4985d-152">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="4985d-152">Ads not refreshing</span></span>

1.  <span data-ttu-id="4985d-153">**isAutoRefreshEnabled** プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-153">Check the **isAutoRefreshEnabled** property.</span></span> <span data-ttu-id="4985d-154">既定では、この省略可能なプロパティは true に設定されています。</span><span class="sxs-lookup"><span data-stu-id="4985d-154">By default, this optional property is set to true.</span></span> <span data-ttu-id="4985d-155">false に設定すると、他の広告を取得するために **refresh** メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-155">When set to false, the **refresh** method must be used to retrieve another ad.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{ applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID',
                            onErrorOccurred: errorLogger,
                            isAutoRefreshEnabled: true}">
    </div>
    ```

2.  <span data-ttu-id="4985d-156">**refresh** メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-156">Check calls to the **refresh** method.</span></span> <span data-ttu-id="4985d-157">自動更新を使う場合、他の広告を取得するために **refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="4985d-157">When using automatic refresh, **refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="4985d-158">手動更新を使う場合、デバイスの現在のデータ接続に応じて、少なくとも 30 ～ 60 秒経ってから **refresh** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-158">When using manual refresh, **refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="4985d-159">この例は、**refresh** メソッドの使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-159">This example demonstrates how to use the **refresh** method.</span></span> <span data-ttu-id="4985d-160">次の HTML コードは、**isAutoRefreshEnabled** を false に設定した状態で **AdControl** をインスタンス化する方法を示した例です。</span><span class="sxs-lookup"><span data-stu-id="4985d-160">The following HTML code shows an example of how to instantiate the **AdControl** with **isAutoRefreshEnabled** set to false.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{ applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID',
                            onErrorOccurred: errorLogger,
                            isAutoRefreshEnabled: false}">
    </div>
    ```

    <span data-ttu-id="4985d-161">次の例は **refresh** 関数の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-161">Theis example demonstrates how to use the **refresh** function.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    args.setPromise(WinJS.UI.processAll()
        .then(function (args) {
            window.setInterval(function()
            {
                document.getElementById("myAd").winControl.refresh();
            }, 60000)
        })
    );
    ```

3.  <span data-ttu-id="4985d-162">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-162">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="4985d-163">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="4985d-163">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="js"/>

## <a name="javascript"></a><span data-ttu-id="4985d-164">JavaScript</span><span class="sxs-lookup"><span data-stu-id="4985d-164">JavaScript</span></span>

<span id="js-adcontrolnotappearing"/>

### <a name="adcontrol-not-appearing"></a><span data-ttu-id="4985d-165">AdControl が表示されない</span><span class="sxs-lookup"><span data-stu-id="4985d-165">AdControl not appearing</span></span>

1.  <span data-ttu-id="4985d-166">Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-166">Ensure that the **Internet (Client)** capability is selected in Package.appxmanifest.</span></span>

2.  <span data-ttu-id="4985d-167">**AdControl** がインスタンス化されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-167">Ensure the **AdControl** is instantiated.</span></span> <span data-ttu-id="4985d-168">インスタンス化されていない **AdControl** は</span><span class="sxs-lookup"><span data-stu-id="4985d-168">If the **AdControl** is not instantiated.</span></span> <span data-ttu-id="4985d-169">使うことができません。</span><span class="sxs-lookup"><span data-stu-id="4985d-169">it will not be available.</span></span>

    <span data-ttu-id="4985d-170">次のスニペットは、**AdControl** のインスタンス化の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-170">The following snippets show an example of instantiating the **AdControl**.</span></span> <span data-ttu-id="4985d-171">この HTML コードは、**AdControl** 用の UI の設定を示した例です。</span><span class="sxs-lookup"><span data-stu-id="4985d-171">This HTML code shows an example of setting up the UI for the **AdControl**</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl">
    </div>
    ```

    <span data-ttu-id="4985d-172">次の JavaScript コードは、**AdControl** のインスタンス化の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-172">The following JavaScript code shows an example of instantiating the **AdControl**</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !==
                    activation.ApplicationExecutionState.terminated)
            {
                var adDiv = document.getElementById("myAd");
                var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv,
                {
                    applicationId: "{ApplicationID}",
                    adUnitId: "{AdUnitID}"
                 });                
                 myAdControl.onErrorOccurred = myAdError;
            } else {
                ...
            }
        }
    }
    ```

3.  <span data-ttu-id="4985d-173">親要素を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-173">Check the parent element.</span></span> <span data-ttu-id="4985d-174">親の **&lt;div&gt;** は、正しく割り当てられ、アクティブな状態で表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-174">The parent **&lt;div&gt;** must be correctly assigned, active, and visible.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var adDiv = document.getElementById("myAd");
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv, {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });  
    ```

4.  <span data-ttu-id="4985d-175">アプリケーション ID と広告ユニット ID を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-175">Check the application ID and ad unit ID.</span></span> <span data-ttu-id="4985d-176">これらの Id は、アプリケーション ID とパートナー センターで取得した広告ユニット ID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-176">These IDs must match the application ID and ad unit ID that you obtained in Partner Center.</span></span> <span data-ttu-id="4985d-177">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985d-177">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv, {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });  
    ```

5.  <span data-ttu-id="4985d-178">**AdControl** の親要素を確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-178">Check the parent element of the **AdControl**.</span></span> <span data-ttu-id="4985d-179">親はアクティブな状態で表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-179">The parent must be active and visible.</span></span>

6.  <span data-ttu-id="4985d-180">**ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="4985d-180">Live values for **ApplicationId** and **AdUnitId** should not be tested in the emulator.</span></span> <span data-ttu-id="4985d-181">**AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。</span><span class="sxs-lookup"><span data-stu-id="4985d-181">To ensure the **AdControl** is functioning as expected, use the [test values](set-up-ad-units-in-your-app.md#test-ad-units) for both **ApplicationId** and **AdUnitId**.</span></span>

<span id="js-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a><span data-ttu-id="4985d-182">ブラック ボックスが点滅し、表示されなくなる</span><span class="sxs-lookup"><span data-stu-id="4985d-182">Black box blinks and disappears</span></span>

1.  <span data-ttu-id="4985d-183">「[AdControl が表示されない](#js-adcontrolnotappearing)」セクションの手順をすべてもう一度確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-183">Double-check all steps in the [AdControl not appearing](#js-adcontrolnotappearing) section.</span></span>

2.  <span data-ttu-id="4985d-184">**onErrorOccurred** イベントを処理します。イベント ハンドラーに渡されるメッセージを使って、エラーが発生したかどうかと、スローされたエラーの種類を特定します。</span><span class="sxs-lookup"><span data-stu-id="4985d-184">Handle the **onErrorOccurred** event, and use the message that is passed to the event handler to determine whether an error occurred and what type of error was thrown.</span></span> <span data-ttu-id="4985d-185">詳しくは、「[Error handling in JavaScript walkthrough (JavaScript チュートリアルでのエラー処理)](error-handling-in-javascript-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985d-185">More details can be found in [Error handling in JavaScript walkthrough](error-handling-in-javascript-walkthrough.md).</span></span>

    <span data-ttu-id="4985d-186">次の例では、エラー メッセージを報告するエラー ハンドラーを実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4985d-186">This example demonstrates how to implement an error handler that reports error messages.</span></span> <span data-ttu-id="4985d-187">HTML コードのこのスニペットは、エラー メッセージを表示するように UI を設定する方法を示した例です。</span><span class="sxs-lookup"><span data-stu-id="4985d-187">This snippet of HTML code provides an example of how to set up the UI to display error messages.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div style="position:absolute; width:100%; height:130px; top:300px">
        <b>Ad Events</b><br />
        <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
    </div>
    ```

    <span data-ttu-id="4985d-188">次の例では、**AdControl** をインスタンス化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4985d-188">This example demonstrates how to instantiate the **AdControl**.</span></span> <span data-ttu-id="4985d-189">この関数は app.onactivated ファイルに挿入されます。</span><span class="sxs-lookup"><span data-stu-id="4985d-189">This function would be inserted in the app.onactivated file.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv,
    {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });                
    myAdControl.onErrorOccurred = myAdError;
    ```

    <span data-ttu-id="4985d-190">次の例では、エラーを報告する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4985d-190">This example demonstrates how to report errors.</span></span> <span data-ttu-id="4985d-191">この関数は、default.js ファイルの自己実行関数の下に挿入されます。</span><span class="sxs-lookup"><span data-stu-id="4985d-191">This function would be inserted below the self-running function in the default.js file.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    WinJS.Utilities.markSupportedForProcessing
    (
        window.errorLogger = function (sender, evt)
        {
            adEvents.innerHTML = (new Date()).toLocaleTimeString() + ": " +
            sender.element.id + " error: " + evt.errorMessage + " error code: " +
            evt.errorCode + "<br>" + adEvents.innerHTML;
        }
    );
    ```

    <span data-ttu-id="4985d-192">ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。</span><span class="sxs-lookup"><span data-stu-id="4985d-192">The most common error that causes a black box is “No ad available.”</span></span> <span data-ttu-id="4985d-193">このエラーは、要求から復帰する利用可能な広告がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="4985d-193">This error means there is no ad available to return from the request.</span></span>

3.  <span data-ttu-id="4985d-194">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-194">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="4985d-195">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="4985d-195">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

<span id="js-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a><span data-ttu-id="4985d-196">広告が更新されない</span><span class="sxs-lookup"><span data-stu-id="4985d-196">Ads not refreshing</span></span>

1.  <span data-ttu-id="4985d-197">**AdControl** の [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティが false に設定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-197">Check whether the [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) property of your **AdControl** is set to false.</span></span> <span data-ttu-id="4985d-198">既定では、この省略可能なプロパティは **true** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="4985d-198">By default, this optional property is set to **true**.</span></span> <span data-ttu-id="4985d-199">**false** に設定すると、他の広告を取得するために **Refresh** メソッドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985d-199">When set to **false**, the **Refresh** method must be used to retrieve another ad.</span></span>

2.  <span data-ttu-id="4985d-200">[Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドの呼び出しを確認します。</span><span class="sxs-lookup"><span data-stu-id="4985d-200">Check calls to the [Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) method.</span></span> <span data-ttu-id="4985d-201">自動更新 (**IsAutoRefreshEnabled** が **true**) の場合、他の広告を取得するために **Refresh** を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="4985d-201">When using automatic refresh (**IsAutoRefreshEnabled** is **true**), **Refresh** cannot be used to retrieve another ad.</span></span> <span data-ttu-id="4985d-202">手動更新 (**IsAutoRefreshEnabled** が **false**) の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4985d-202">When using manual refresh (**IsAutoRefreshEnabled** is **false**), **Refresh** should be called only after a minimum of 30 to 60 seconds depending on the device’s current data connection.</span></span>

    <span data-ttu-id="4985d-203">次の例は、**AdControl** の **div** を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-203">This example demonstrates how to create the **div** for the **AdControl**.</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl">
    </div>
    ```

    <span data-ttu-id="4985d-204">次の例は、**Refresh** 関数の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-204">This example shows how to use the **Refresh** function</span></span>

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv,
    {
      applicationId: "{ApplicationID}",
      adUnitId: "{AdUnitID}",
      isAutoRefreshEnabled: false
    });
    ...
    args.setPromise(WinJS.UI.processAll()
        .then(function (args) {
            window.setInterval(function()
            {
                document.getElementById("myAd").winControl.refresh();
            }, 60000)
        })
    );
    ```

3.  <span data-ttu-id="4985d-205">**AdControl** は正常に動作しています。</span><span class="sxs-lookup"><span data-stu-id="4985d-205">The **AdControl** is behaving normally.</span></span> <span data-ttu-id="4985d-206">同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。</span><span class="sxs-lookup"><span data-stu-id="4985d-206">Sometimes the same ad will appear more than once in a row giving the appearance that ads are not refreshing.</span></span>

 

 
