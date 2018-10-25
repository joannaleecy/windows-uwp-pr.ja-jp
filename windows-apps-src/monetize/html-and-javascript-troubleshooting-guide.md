---
author: Xansky
ms.assetid: 7a61c328-77be-4614-b117-a32a592c9efe
description: JavaScript/HTML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。
title: HTML と JavaScript のトラブルシューティング ガイド
ms.author: mhopkins
ms.date: 08/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, AdControl, トラブルシューティング, HTML, JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: 5474ac51d57decfe2c4f4d5f1969da5b4436fd14
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5481944"
---
# <a name="html-and-javascript-troubleshooting-guide"></a>HTML と JavaScript のトラブルシューティング ガイド

このトピックでは、JavaScript/HTML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。

* [HTML](#html)
  * [AdControl が表示されない](#html-notappearing)
  * [ブラック ボックスが点滅し、表示されなくなる](#html-blackboxblinksdisappears)
  * [広告が更新されない](#html-adsnotrefreshing)

* [JavaScript](#js)
  * [AdControl が表示されない](#js-adcontrolnotappearing)
  * [ブラック ボックスが点滅し、表示されなくなる](#js-blackboxblinksdisappears)
  * [広告が更新されない](#js-adsnotrefreshing)

## <a name="html"></a>HTML

<span id="html-notappearing"/>

### <a name="adcontrol-not-appearing"></a>AdControl が表示されない

1.  Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。

2.  JavaScript の参照が存在することを確認します。 &lt;head&gt; セクション (default.js リファレンスの後ろ) に ad.js の参照がない場合、**AdControl** は表示できず、ビルド中にエラーが発生します。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <head>
        ...
        <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
        ...
    </head>
    ```

3.  アプリケーション ID と広告ユニット ID を確認します。 これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 50px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

4.  **height** プロパティと **width** プロパティを確認します。 これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 50px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

5.  要素の配置を確認します。 [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) は表示可能領域の内部にある必要があります。

6.  **visibility** プロパティを確認します。 このプロパティは、collapsed または hidden に設定しないでください。 (次のように) インラインで設定できるほか、外部スタイル シートで設定できます。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

7.  **position** プロパティを確認します。 position は、要素の他のプロパティ (親要素の margin、z-index など) に応じた適切な値に設定する必要があります。 (次のように) インラインで設定できるほか、外部スタイル シートで設定できます。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

8.  **z-index** プロパティを確認します。 **z-index** プロパティは、**AdControl** が常に他の要素の上に表示されるように、十分な高さに設定する必要があります。 (次のように) インラインで設定できるほか、外部スタイル シートで設定できます。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

9.  外部スタイル シートを確認します。 外部スタイル シートを使って **AdControl** 要素でプロパティを設定している場合、上記のプロパティがすべて正しく設定されていることを確認してください。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="visibility: visible; position: absolute; top: 1025px;
                          left: 500px; width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl"
         data-win-options="{applicationId: 'ApplicationID',
                            adUnitId: 'AdUnitID'}">
    </div>
    ```

10. **AdControl** の親を確認します。 **AdControl** が親要素の中にある場合、この親はアクティブで表示されている必要があります。

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

11. **AdControl** がビューポートから隠れていないことを確認します。 **AdControl** は、広告が正常に表示されるように、見える必要があります。

12. [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) と [AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) の実際の値は、エミュレーターでのテストに使わないようにしてください。 **AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。

<span id="html-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a>ブラック ボックスが点滅し、表示されなくなる

1.  前の「[AdControl が表示されない](#html-notappearing)」セクションの手順をすべてもう一度確認します。

2.  **onErrorOccurred** イベントを処理します。イベント ハンドラーに渡されるメッセージを使って、エラーが発生したかどうかと、スローされたエラーの種類を特定します。 詳しくは、「[Error handling in JavaScript walkthrough (JavaScript チュートリアルでのエラー処理)](error-handling-in-javascript-walkthrough.md)」をご覧ください。

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

    ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。 このエラーは、要求から復帰する利用可能な広告がないことを意味します。

3.  **AdControl** は正常に動作しています。 既定では、**AdControl** は広告を表示できない場合に折りたたまれます。 他の要素が同じ親の子である場合、これらの他の要素は折りたたんだ **AdControl** の隙間を埋めるように移動し、次の要求がなされたときに展開することがあります。

<span id="html-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a>広告が更新されない

1.  **isAutoRefreshEnabled** プロパティを確認します。 既定では、この省略可能なプロパティは true に設定されています。 false に設定すると、他の広告を取得するために **refresh** メソッドを使う必要があります。

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

2.  **refresh** メソッドの呼び出しを確認します。 自動更新を使う場合、他の広告を取得するために **refresh** を使うことはできません。 手動更新を使う場合、デバイスの現在のデータ接続に応じて、少なくとも 30 ～ 60 秒経ってから **refresh** を呼び出す必要があります。

    この例は、**refresh** メソッドの使い方を示しています。 次の HTML コードは、**isAutoRefreshEnabled** を false に設定した状態で **AdControl** をインスタンス化する方法を示した例です。

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

    次の例は **refresh** 関数の使い方を示しています。

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

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

<span id="js"/>

## <a name="javascript"></a>JavaScript

<span id="js-adcontrolnotappearing"/>

### <a name="adcontrol-not-appearing"></a>AdControl が表示されない

1.  Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。

2.  **AdControl** がインスタンス化されていることを確認します。 インスタンス化されていない **AdControl** は 使うことができません。

    次のスニペットは、**AdControl** のインスタンス化の例を示しています。 この HTML コードは、**AdControl** 用の UI の設定を示した例です。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl">
    </div>
    ```

    次の JavaScript コードは、**AdControl** のインスタンス化の例を示しています。

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

3.  親要素を確認します。 親の **&lt;div&gt;** は、正しく割り当てられ、アクティブな状態で表示されている必要があります。

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var adDiv = document.getElementById("myAd");
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv, {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });  
    ```

4.  アプリケーション ID と広告ユニット ID を確認します。 これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv, {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });  
    ```

5.  **AdControl** の親要素を確認します。 親はアクティブな状態で表示されている必要があります。

6.  **ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。 **AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても[テスト値](set-up-ad-units-in-your-app.md#test-ad-units)を使ってください。

<span id="js-blackboxblinksdisappears"/>

### <a name="black-box-blinks-and-disappears"></a>ブラック ボックスが点滅し、表示されなくなる

1.  「[AdControl が表示されない](#js-adcontrolnotappearing)」セクションの手順をすべてもう一度確認します。

2.  **onErrorOccurred** イベントを処理します。イベント ハンドラーに渡されるメッセージを使って、エラーが発生したかどうかと、スローされたエラーの種類を特定します。 詳しくは、「[Error handling in JavaScript walkthrough (JavaScript チュートリアルでのエラー処理)](error-handling-in-javascript-walkthrough.md)」をご覧ください。

    次の例では、エラー メッセージを報告するエラー ハンドラーを実装する方法を示します。 HTML コードのこのスニペットは、エラー メッセージを表示するように UI を設定する方法を示した例です。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div style="position:absolute; width:100%; height:130px; top:300px">
        <b>Ad Events</b><br />
        <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
    </div>
    ```

    次の例では、**AdControl** をインスタンス化する方法を示します。 この関数は app.onactivated ファイルに挿入されます。

    > [!div class="tabbedCodeSnippets"]
    ``` javascript
    var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv,
    {
        applicationId: "{ApplicationID}",
        adUnitId: "{AdUnitID}"
    });                
    myAdControl.onErrorOccurred = myAdError;
    ```

    次の例では、エラーを報告する方法を示します。 この関数は、default.js ファイルの自己実行関数の下に挿入されます。

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

    ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。 このエラーは、要求から復帰する利用可能な広告がないことを意味します。

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

<span id="js-adsnotrefreshing"/>

### <a name="ads-not-refreshing"></a>広告が更新されない

1.  **AdControl** の [IsAutoRefreshEnabled](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティが false に設定されているかどうかを確認します。 既定では、この省略可能なプロパティは **true** に設定されています。 **false** に設定すると、他の広告を取得するために **Refresh** メソッドを使う必要があります。

2.  [Refresh](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドの呼び出しを確認します。 自動更新 (**IsAutoRefreshEnabled** が **true**) の場合、他の広告を取得するために **Refresh** を使うことはできません。 手動更新 (**IsAutoRefreshEnabled** が **false**) の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。

    次の例は、**AdControl** の **div** を作成する方法を示しています。

    > [!div class="tabbedCodeSnippets"]
    ``` html
    <div id="myAd" style="position: absolute; top: 0px; left: 0px;
                          width: 250px; height: 250px; z-index: 1"
         data-win-control="MicrosoftNSJS.Advertising.AdControl">
    </div>
    ```

    次の例は、**Refresh** 関数の使い方を示しています。

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

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

 

 
