---
author: mcleanbyron
ms.assetid: fcebd659-438b-4d03-bc73-6b662ed6f1f3
description: "広告を含むアプリを開発して公開するプロセスについて詳しく説明します。"
title: "広告を含むアプリを作成するためのワークフロー"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, AdControl, InterstitialAd"
ms.openlocfilehash: 93b56259314c54a56cd8ebbef89694319a95e41c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="workflows-for-creating-apps-with-ads"></a>広告を含むアプリを作成するためのワークフロー




アプリに広告を表示するには、アプリが広告ネットワークから広告を受信できるようにする必要があります。 マイクロソフトでは、Windows アプリの開発者が広告を受信できるようにする Web サービスを提供します。 ユーザーがアプリの広告をクリックすると、(広告の*発行元*となる) 発行者が、広告の作成者 (*広告主*) から収益を得られます。 広告主から得られる収益は、使用するアカウントを使って発行者に支払われます。

次の大まかな手順では、広告を含むアプリを開発および公開する一般的なプロセスについて説明します。

1.  開発段階:

    * Windows デベロッパー センター アカウントを設定します。
    * テスト モードの値を使ってアプリを開発します。

2.  リリースの準備:

    * ライブ広告を受信するアプリを設定します。
    * Windows デベロッパー センターにアプリを提出し、パフォーマンス データを確認します。

各手順について詳しくは、対応する以下のセクションをご覧ください。

## <a name="set-up-your-windows-dev-center-account"></a>Windows デベロッパー センター アカウントの設定

アプリを公開して広告を受信するには、Windows デベロッパー センターのアカウントが必要です。 広告に関連するアプリの管理も Windows デベロッパー センターで行います。 Microsoft pubCenter を使ってアプリの広告を管理したことがある場合、この機能は Windows デベロッパー センターの機能に置き換えられています。

Windows デベロッパー センターでアカウントをセットアップするには、[こちらのページ](http://go.microsoft.com/fwlink/p/?LinkId=615100)にアクセスしてください。

## <a name="develop-your-app-using-test-mode-values"></a>テスト モードの値を使ったアプリの開発

次の各チュートリアルの指示に従って、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を追加し、アプリに広告を表示します。

-   [スポット広告](interstitial-ads.md)
-   [XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)
-   [HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)
-   [Windows Phone Silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)

**AdControl** または **InterstitialAd** を使ってアプリに広告を表示する場合、コードにアプリケーション ID と広告ユニット ID を指定して、Windows デベロッパー センター アカウントにアプリをリンクして広告を組み込む必要があります。 アプリを開発しているときには、テスト用のアプリケーション ID と広告ユニット ID の値を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。 これにより、テスト中に、アプリが広告を受信およびレンダリングする方法を表示することができます。 詳しくは、「[テスト モード値](test-mode-values.md)」をご覧ください。

C# と C++ を使って JavaScript/HTML アプリと XAML アプリにバナー広告やスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

## <a name="configure-your-app-to-receive-live-ads"></a>ライブ広告を受信するアプリの設定

アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、[Windows デベロッパー センター ダッシュボード](https://msdn.microsoft.com/library/windows/apps/mt170658.aspx)から取得したアプリケーション ID と広告ユニット ID の値を使うためにアプリのコードを更新する必要があります。 ライブ アプリでテスト用の値を使うと、アプリでライブ広告は表示されません。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

## <a name="submit-your-app"></a>アプリの提出

アプリの開発を完了した後は、Windows デベロッパー センター ダッシュ ボードを使って Windows ストアでアプリを公開できます。 Windows ストアのすべてのアプリに対する適合要件に加えて、広告を表示するアプリは、その他のいくつかの要件を満たす必要があります。 詳しくは、「[広告を含むアプリを Windows ストアに提出する](submit-an-app-with-ads-to-the-windows-store.md)」をご覧ください。

アプリを公開して Windows ストアで利用可能になると、デベロッパー センター ダッシュ ボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認できます。

 

 
