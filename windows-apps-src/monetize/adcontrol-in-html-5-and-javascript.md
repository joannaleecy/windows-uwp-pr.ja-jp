---
author: Xansky
ms.assetid: adb2fa45-e18f-4254-bd8b-a749a386e3b4
description: Windows 10 (UWP) 用の JavaScript/HTML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。
title: HTML 5 および JavaScript の AdControl
ms.author: mhopkins
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, AdControl, 広告コントロール, JavaScript, HTML
ms.localizationpriority: medium
ms.openlocfilehash: 37f7754e8f88e61df571fe561ae94dc4b71468ed
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4618370"
---
# <a name="adcontrol-in-html-5-and-javascript"></a>HTML 5 および JavaScript の AdControl

このチュートリアルでは、Windows 10 (HTML) 用のユニバーサル Windows プラットフォーム (UWP) JavaScript/HTML アプリで [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) クラスを使ってバナー広告を表示する方法について説明します。

JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

## <a name="prerequisites"></a>前提条件

* Visual Studio 2015 以降の Visual Studio のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。 インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。

> [!NOTE]
> Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) またはそれ以降のバージョンの Windows SDK をインストールした場合は、 [WinJS](https://github.com/winjs/winjs)ライブラリもインストールする必要があります。 このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 SDK バージョン 10.0.14393 (Anniversary Update) 以降ではこのライブラリを別個にインストールする必要があります。 

## <a name="integrate-a-banner-ad-into-your-app"></a>バナー広告をアプリに統合する

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

    > [!NOTE]
    > 既存のプロジェクトを使用している場合、プロジェクトの Package.appxmanifest ファイルを開き、**インターネット (クライアント)** 機能が選択されていることを確認します。 アプリでは、テスト広告やライブ広告を受信するためにこの機能が必要になります。

2. プロジェクトのターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3. プロジェクトで Microsoft Advertising SDK への参照を追加します。

    1. **[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
    2.  **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for JavaScript]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
    3.  **[参照マネージャー]** で、[OK] をクリックします。

6.  index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。

7.  **&lt;head&gt;** セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に ad.js への参照を追加します。

    ``` HTML
    <!-- Advertising required references -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

    > [!NOTE]
    > この行は、**&lt;head&gt;** セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。

8.  default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の **&lt;body&gt;** セクションを変更して、**AdControl** の **div** を追加します。 **AdControl** の **applicationId** プロパティと **adUnitId** プロパティに、[広告ユニットのテスト値](set-up-ad-units-in-your-app.md#test-ad-units)を割り当てます。 また、コントロールの**高さ**と**幅**を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

    > [!NOTE]
    > 各 **AdControl** に、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。 ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。 これらのテスト値は、テスト バージョンのアプリでのみ使用できます。 ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。

    ``` HTML
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
        data-win-control="MicrosoftNSJS.Advertising.AdControl"
        data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    ```

9.  アプリをコンパイルして実行し、広告が表示されることを確認します。

次の例は、シンプルなアプリの index.html 全体を示しています。

``` HTML
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>AdControlExampleApp</title>
    <!-- WinJS references -->
    <link href="lib/winjs-4.0.1/css/ui-light.css" rel="stylesheet" />
    <script src="lib/winjs-4.0.1/js/base.js"></script>
    <script src="lib/winjs-4.0.1/js/ui.js"></script>
    <!-- AdControlExampleApp references -->
    <link href="css/default.css" rel="stylesheet" />
    <script src="js/main.js"></script>
    <!-- Required reference for AdControl -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
</head>
<body>
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    <p>Content goes here</p>
</body>
</html>
```

### <a name="create-an-adcontrol-programmatically-in-javascript"></a>JavaScript でのプログラムによる AdControl の作成

前の手順では、HTML マークアップで **AdControl** を宣言する方法を示しています。 代わりに、JavaScript を使ってプログラムで **AdControl** を作成できます。 次の例では、HTML に **div** が存在し、その ID が **myAd** に設定されていると想定しています。

> [!div class="tabbedCodeSnippets"]
[!code-javascript[AdControl](./code/AdvertisingSamples/AdControlSamples/js/main.js#DeclareAdControl)]

この例では、**myAdError**、**myAdRefreshed**、**myAdEngagedChanged** という名前のイベント ハンドラー メソッドが既に宣言されていることを前提としています。

このコードで広告が表示されない場合は、**AdControl** を含む **div** に **position:relative** の属性を挿入してみてください。 これにより、**IFrame** の既定の設定が上書きされます。 この属性の値が原因でなければ、広告が正しく表示されるようになります。 新しい広告ユニットが利用可能になるまでに最大で 30 分かかる場合があることに注意してください。

> [!NOTE]
> この例の *applicationId* の値と *adUnitId* の値は、[テスト モードの値](set-up-ad-units-in-your-app.md#test-ad-units)です。 申請のためにアプリを提出する前に、Windows デベロッパー センターから[実際の値にこれらの値を置き換える](set-up-ad-units-in-your-app.md#live-ad-units)必要があります。

<span id="release" />

## <a name="release-your-app-with-live-ads"></a>ライブ広告を表示するアプリをリリースする

1. アプリでのバナー広告の使用方法が[バナー広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)に従っていることを確認します。

1.  デベロッパー センター ダッシュボードで、[[アプリ内広告]](../publish/in-app-ads.md) ページに移動し、[広告ユニットを作成](set-up-ad-units-in-your-app.md#live-ad-units)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方を書き留めておきます。
    > [!NOTE]
    > テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。 テスト アプリケーション ID の値は GUID です。 ダッシュボードでライブ UWP 広告ユニットを作成する場合、広告ユニットのアプリケーション ID の値は常にアプリの Store ID に一致します (Store ID 値は、たとえば 9NBLGGH4R315 のようになります)。

2. 必要に応じて、[[アプリ内広告]](../publish/in-app-ads.md) ページの [[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、**AdControl** の広告仲介を有効にできます。 広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。

3.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

4.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

5.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。             

<span id="manage" />

## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a>アプリで複数の広告コントロールの広告ユニットを管理する

1 つのアプリで複数の **AdControl** オブジェクトを使うことができます (たとえば、アプリの各ページに異なる **AdControl** オブジェクトをホストできます)。 このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。 各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。 また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。

> [!IMPORTANT]
> 各広告ユニットは 1 つのアプリのみで使用できます。 複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。

## <a name="related-topics"></a>関連トピック

* [バナー広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-banner-ads)
* [GitHub の広告サンプル](http://aka.ms/githubads)
* [アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)
* [JavaScript ウォークスルーでのエラー処理](error-handling-in-javascript-walkthrough.md)
