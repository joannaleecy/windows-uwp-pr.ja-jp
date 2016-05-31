---
author: mcleanbyron
ms.assetid: adb2fa45-e18f-4254-bd8b-a749a386e3b4
description: Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。
title: HTML 5 および Javascript の AdControl
---

# HTML 5 および Javascript の AdControl


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

このチュートリアルでは、Windows 10 (UWP) 用、Windows 8.1 用、Windows Phone 8.1 用の JavaScript/HTML アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使ってバナー広告を表示する方法について説明します。 このチュートリアルでは **AdMediatorControl** (広告仲介) は使いません。

JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

## 前提条件


* [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) を Visual Studio 2015 または Visual Studio 2013 と共にインストールします。

> **注** Windows 10 Anniversary SDK Preview ビルド 14295 以降を Visual Studio 2015 と共にインストールしている場合は、WinJS ライブラリもインストールする必要があります。 このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 Anniversary SDK Preview ビルド 14295 以降ではこのライブラリを別個にインストールする必要があります。 WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。

## コード開発

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising ライブラリへの参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

4.  **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

    ![javascriptaddreference](images/13-f7f6d6a6-161e-4f17-995d-1236d0b5d9f2.png)

    > **注**  この画像は、Windows 10 用 UWP プロジェクトを構築している Visual Studio 2015 の画像です。 Windows 8.1 または Windows Phone 8.1 のアプリを構築している場合や、Visual Studio 2013 を使っている場合は、画面が異なります。

5.  **[参照マネージャー]** で、[OK] をクリックします。

6.  default.html ファイル (またはプロジェクトに対応するその他の html ファイル) を開きます。

7.  **
            &lt;head&gt;** セクションで、プロジェクトの default.css と default.js の JavaScript 参照の後に ad.js への参照を追加します。

    UWP プロジェクトでは、次のコードを追加します。

    ``` syntax
    <!-- Microsoft advertising required references -->
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

    Windows 8.1 または Windows Phone 8.1 のプロジェクトでは、次のコードを追加します。

    ``` syntax
    <!-- Microsoft advertising required references -->
    <script src="/MSAdvertisingJS/ads/ad.js"></script>
    ```

    > **注**   この行は、**&lt;head&gt;** セクションの default.js のインクルードの後に配置する必要があります。そうしないと、プロジェクトのビルド時にエラーが発生します。

8.  default.html ファイル (またはプロジェクトに対応するその他の html ファイル) の **&lt;body&gt;** セクションを変更して、**AdControl** の div を追加します。 **AdControl** の **applicationId** プロパティと **adUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てて、コントロールの高さと幅を、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

    > **注**  
    **applicationId** と **adUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

    ``` syntax
    <div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
          data-win-control="MicrosoftNSJS.Advertising.AdControl"
          data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: '10865270'}">
    </div>
    ```

9.  アプリをコンパイルして実行し、広告が表示されることを確認します。

## Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする


1.  デベロッパー センターのダッシュボードで、アプリの **[貨幣化]**&gt;**[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

## サンプル UWP プロジェクトの完全な default.html


``` syntax
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>My_Windows_10_Ad_Funded_JavaScript_App</title>

    <!-- WinJS references -->
    <link href="//Microsoft.WinJS.2.0.Preview/css/ui-dark.css" rel="stylesheet" />
    <script src="//Microsoft.WinJS.2.0.Preview/js/base.js"></script>
    <script src="//Microsoft.WinJS.2.0.Preview/js/ui.js"></script>

    <!-- My_Windows_10_Ad_Funded_JavaScript_App references -->
    <link href="/css/default.css" rel="stylesheet" />
    <script src="/js/default.js"></script>

    <!-- Microsoft advertising required references -->
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

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
 

 


<!--HONumber=May16_HO2-->


