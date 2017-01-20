---
author: mcleanbyron
ms.assetid: adb2fa45-e18f-4254-bd8b-a749a386e3b4
description: "Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "HTML 5 および JavaScript の AdControl"
translationtype: Human Translation
ms.sourcegitcommit: f88a71491e185aec84a86248c44e1200a65ff179
ms.openlocfilehash: 509cfe00050c5b5b3997af0e2906676f946d9278

---

# <a name="adcontrol-in-html-5-and-javascript"></a>HTML 5 および JavaScript の AdControl

このチュートリアルでは、Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。 このチュートリアルでは **AdMediatorControl** (広告仲介) は使いません。

JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

## <a name="prerequisites"></a>前提条件


* UWP アプリ: Visual Studio 2015 と共に [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。
* Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。

> **注**&nbsp;&nbsp;Windows 10 Anniversary SDK Preview ビルド 14295 以降を Visual Studio 2015 と共にインストールしている場合は、WinJS ライブラリもインストールする必要があります。 このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 Anniversary SDK Preview ビルド 14295 以降ではこのライブラリを別個にインストールする必要があります。 WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。

## <a name="code-development"></a>コード開発

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

4.  **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

    ![javascriptaddreference](images/13-f7f6d6a6-161e-4f17-995d-1236d0b5d9f2.png)

    > **注**&nbsp;&nbsp;この画像は、Windows 10 用 UWP プロジェクトを構築している Visual Studio 2015 の画像です。 Windows 8.1 または Windows Phone 8.1 のアプリを構築している場合や、Visual Studio 2013 を使っている場合は、画面が異なります。

5.  **[参照マネージャー]** で、[OK] をクリックします。

6.  index.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。

7.  **&lt;head&gt;** セクションで、プロジェクトの default.css と main.js の JavaScript 参照の後に ad.js への参照を追加します。

  UWP プロジェクトでは、次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <!-- Microsoft advertising required references -->
  <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
  ```

  Windows 8.1 または Windows Phone 8.1 のプロジェクトでは、次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <!-- Microsoft advertising required references -->
  <script src="/MSAdvertisingJS/ads/ad.js"></script>
  ```

  <span/>
  >**注**&nbsp;&nbsp;この行は、**&lt;head&gt;** セクションの main.js のインクルードの後に配置する必要があります。そうでない場合、プロジェクトのビルド時にエラーが発生します。 プロジェクトのターゲットが Windows 8.1 または Windows Phone 8.1 である場合、プロジェクトの既定の HTML ファイルの名前は index.html ではなく default.html になります。また、プロジェクトの既定の JavaScript ファイルの名前は main.js ではなく default.js になります。

8.  default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の **&lt;body&gt;** セクションを変更して、**AdControl** の div を追加します。 **AdControl** の **applicationId** プロパティと **adUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てて、コントロールの高さと幅を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

  >               **注**&nbsp;&nbsp;**applicationId** と **adUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
        data-win-control="MicrosoftNSJS.Advertising.AdControl"
        data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: '10865270'}">
  </div>
  ```

9.  アプリをコンパイルして実行し、広告が表示されることを確認します。

## <a name="release-your-app-with-live-ads-using-windows-dev-center"></a>Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする


1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

## <a name="complete-indexhtml-for-a-sample-uwp-project"></a>サンプル UWP プロジェクトの完全な index.html

> [!div class="tabbedCodeSnippets"]
``` html
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
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: '10865270'}">
    </div>
    <p>Content goes here</p>
</body>
</html>
```

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
 

 



<!--HONumber=Dec16_HO2-->


