---
author: mcleanbyron
ms.assetid: ca92bed1-ad9e-4947-ad91-87d12de727c0
description: "Microsoft Store Engagement and Monetization SDK に含まれる Microsoft Advertising ライブラリのリリース ノートを確認します。"
title: "Microsoft Advertising ライブラリのリリース ノート"
translationtype: Human Translation
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 8e2114e969b27d579f62195f026cfcfd9672a94a

---

# Microsoft Advertising ライブラリのリリース ノート


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

このセクションでは、Microsoft Store Engagement and Monetization SDK に含まれる Microsoft Advertising ライブラリの最新リリースのリリース ノートを提供します。 これらのライブラリは、Windows 10、Windows 8.1、Windows Phone 8.1、Windows Phone 8 用の XAML アプリと JavaScript/HTML アプリをサポートします。

## インストール


Microsoft Advertising ライブラリは、[Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) の一部として入手できます。 Windows Phone 8.x Silverlight 以外のすべてのプロジェクト タイプについて、以前に Microsoft Universal Ad Client SDK および Microsoft Advertising SDK のスタンドアロン リリースで配布されていた Microsoft Advertising アセンブリは、Microsoft Store Engagement and Monetization SDK と共にインストールされるようになりました。 この SDK と SDK に含まれているライブラリのインストールについて詳しくは、「[Microsoft Advertising ライブラリのインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。

Windows Phone 8.x Silverlight プロジェクト用の Microsoft Advertising アセンブリを入手するには、[Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) をインストールします。次に、プロジェクトを Visual Studio で開き、**[プロジェクト]** > **[接続済みサービスを追加します]** > **[Ad Mediator]** の順に移動して、アセンブリを自動的にダウンロードします。 その後、広告仲介を使用しない場合は、広告メディエーターの参照をプロジェクトから削除できます。 詳しくは、「[AdControl in Windows Phone Silverlight (Windows Phone Silverlight での AdControl)](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。

## Microsoft Advertising ライブラリと広告仲介の違いについて

Microsoft Advertising ライブラリと広告仲介ライブラリはどちらも Microsoft Store Engagement and Monetization SDK によって提供されますが、これらのライブラリの用途は異なります。 XAML または JavaScript アプリでマイクロソフトのバナーやビデオのスポット広告を表示する場合には、Microsoft Advertising ライブラリの [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスおよび [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) クラスを使います。 XAML アプリで複数の広告ネットワークからのバナー広告を表示する場合には、広告仲介ライブラリの **AdMediatorControl** クラスを使います (広告仲介は JavaScript/HTML アプリではサポートされていません)。 詳しくは、「[AdMediatorControl と AdControl の違い](what-is-the-difference-admediatorcontrol-or-adcontrol.md)」をご覧ください。

## 以前のバージョンのアンインストール

Microsoft Store Engagement and Monetization SDK をインストールする前に、Microsoft Universal Ad Client SDK や Microsoft Advertising SDK の以前のインスタンスをすべてアンインストールすることをお勧めします。

## ターゲット アーキテクチャ固有のビルドの出力

Microsoft Advertising ライブラリを使う場合、プロジェクトで **Any CPU** をターゲットにすることはできません。 プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。 この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。

## C++ のサポート

Microsoft Advertising ライブラリ (**AdControl** クラスと **InterstitialAd** クラスが含まれる) は、Windows ランタイムの相互運用性 (*相互運用機能*) を使用して C++ および DirectX で記述されたアプリをサポートします。 XAML と C++ を使ったプログラミングの詳細情報と例については、「[型システム](https://msdn.microsoft.com/library/windows/apps/xaml/hh755822.aspx)」をご覧ください。

## ツールボックス コントロールはない

Microsoft Store Engagement and Monetization SDK に含まれる Microsoft Advertising ライブラリの現在のリリースには、**AdControl** や **InterstitialAd** をアプリのデザイン サーフェイスにドラッグするためのツールボックス コントロールはありません。 マークアップとコードでこれらのコントロールを追加する方法については、[開発者向けのチュートリアル](developer-walkthroughs.md)をご覧ください。

## 使用できなくなった緯度と経度のプロパティ

**AdControl**クラスに、UWP アプリ用の **Latitude** プロパティと **Longitude** プロパティは含まれなくなりました。 代わりに、広告コントロールに組み込まれているコードが、アプリに代わってこれらの値を検出し、広告サーバーに送信します。

## 重要な注意事項

必ずソフトウェア ライセンス条項 (EULA) 全体に目を通してください。 詳しくは、「[重要な注意事項 - EULA](important-notice-eula.md)」をご覧ください。

 

 



<!--HONumber=Jun16_HO4-->


