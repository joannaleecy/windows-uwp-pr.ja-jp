---
author: mcleanbyron
ms.assetid: 9165f709-71d7-42cf-9b30-3190fe029fb4
description: Microsoft Advertising ライブラリの AdControl クラスと広告仲介ライブラリの AdMediatorControl クラスの違いについて説明します。
title: AdMediatorControl と AdControl の違い
---

# AdMediatorControl と AdControl の違い


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

Microsoft からのバナー広告またはスポット広告ビデオを表示する場合は、アプリで XAML および JavaScript の Microsoft Advertising ライブラリを使います。 これらのライブラリは、複数の広告ネットワークからの広告を表示するために使う広告仲介ライブラリとは異なります。 次の場合にこの Microsoft Advertising ライブラリ (XAML および JavaScript) 用のドキュメントを使います。

* XAML または JavaScript アプリで、**AdMediatorControl** ではなく [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使っている。
* 広告仲介によって使われる、基となる **AdControl** API のリファレンス情報を探している。

Microsoft Advertising ライブラリと広告仲介ライブラリは、両方とも Microsoft Store Engagement and Monetization SDK に含まれています。 この SDK のインストールと、この SDK に含まれているさまざまな Microsoft Advertising ライブラリについて詳しくは、「[Microsoft Advertising ライブラリのインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。

>**注:** スポット広告を表示するには、**InterstitialAd** コントロールを使います。 **AdControl** と **AdMediatorControl** は、スポット広告を表示できません。 詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。

 

## 広告仲介


(スポット広告ではなく) Microsoft からのバナー広告を表示するためにお勧めする方法は、アプリで **AdMediatorControl** を使うことです。 **AdMediatorControl** は、複数の広告ネットワークからのバナー広告を表示します。

プロジェクトで **AdMediatorControl** を使う場合は、Visual Studio の**接続済みサービス**機能を使ってどの広告ネットワークを使うかを指定する必要があります。 Visual Studio は、一部の広告ネットワークに必要なアセンブリをプログラムで取得しようとします。 自動的に取得できないアセンブリがある場合は、各広告ネットワーク用にインストールする必要があります。 広告の仲介について詳しくは、「[広告の仲介を追加して収益を最大限に高める](use-ad-mediation-to-maximize-revenue.md)」をご覧ください。

**AdMediatorControl** は、広告ユニット ID とアプリケーション ID の使用を抽象化します。 これらの ID は **AdMediatorControl** によって、Windows デベロッパー センター ダッシュボードの広告仲介設定と共に管理されます。 詳しくは、「[アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)」をご覧ください。

**AdMediatorControl** は、独自の属性と構文を使って仲介する各広告サービス用の API をサポートします。 詳しくは、「[広告メディエーター コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。

## AdControl


(その他の広告ネットワークは使わず) Microsoft からのバナー広告のみを表示する場合は、XAML および JavaScript アプリで **AdControl** を単独で使うことができます。 **AdControl** を使うアプリのテスト中に、アプリケーション ID と広告ユニット ID 用の[テスト モードの値](test-mode-values.md)を使います。 アプリのテストが完了し、Windows デベロッパー センターに提出する準備ができたら、Windows デベロッパー センター ダッシュボードを使ってライブ広告ユニット ID とアプリケーション ID を取得して、それらの値を使うようにコードを更新します。 詳しくは、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

 

 


<!--HONumber=May16_HO2-->


