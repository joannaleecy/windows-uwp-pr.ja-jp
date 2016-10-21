---
author: mcleanbyron
ms.assetid: ca92bed1-ad9e-4947-ad91-87d12de727c0
description: "Microsoft Store Services SDK に含まれる Microsoft Advertising ライブラリのリリース ノートを確認します。"
title: "Microsoft Advertising ライブラリのリリース ノート"
translationtype: Human Translation
ms.sourcegitcommit: 2f0835638f330de0ac2d17dae28347686cc7ed97
ms.openlocfilehash: b82c4385b0e7089bdddbe094f47f0766f90aa21b

---

# Microsoft Advertising ライブラリのリリース ノート




このセクションでは、Microsoft Store Services SDK (UWP アプリ用) と、Windows および Windows Phone 8.x 用の Microsoft Advertising SDK (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) の Microsoft Advertising ライブラリの現在のリリースに関するリリース ノートを示します。 これらのライブラリは、Windows 10、Windows 8.1、Windows Phone 8.1、Windows Phone 8 用の XAML アプリと JavaScript/HTML アプリをサポートします。

## インストール


Microsoft Advertising ライブラリは、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) (UWP アプリ用) と [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) の一部として入手できます。 この SDK と SDK に含まれているライブラリのインストールについて詳しくは、「[Microsoft Advertising ライブラリのインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。

Windows Phone 8.x Silverlight プロジェクト用の Microsoft Advertising アセンブリを入手するには、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。次に、プロジェクトを Visual Studio で開き、**[プロジェクト]** > **[接続済みサービスを追加します]** > **[Ad Mediator]** の順に移動して、アセンブリを自動的にダウンロードします。 その後、広告仲介を使用しない場合は、広告メディエーターの参照をプロジェクトから削除できます。 詳しくは、「[AdControl in Windows Phone Silverlight (Windows Phone Silverlight での AdControl)](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。


## 以前のバージョンのアンインストール

Microsoft Store Services SDK (UWP アプリ用) または Windows および Windows Phone 8.x 用の Microsoft Advertising SDK (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) をインストールする前に、Microsoft Universal Ad Client SDK または Microsoft Advertising SDK の以前のインスタンスをすべてアンインストールすることを強くお勧めします。

## ターゲット アーキテクチャ固有のビルドの出力

Microsoft Advertising ライブラリを使う場合、プロジェクトで **Any CPU** をターゲットにすることはできません。 プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。 この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。

## C++ のサポート

Microsoft Advertising ライブラリ (**AdControl** クラスと **InterstitialAd** クラスが含まれる) は、Windows ランタイムの相互運用性 (*相互運用機能*) を使用して C++ および DirectX で記述されたアプリをサポートします。 XAML と C++ を使ったプログラミングの詳細情報と例については、「[型システム](https://msdn.microsoft.com/library/windows/apps/xaml/hh755822.aspx)」をご覧ください。

## ツールボックス コントロールはない

Microsoft Store Services SDK または Windows および Windows Phone 8.x 用の Microsoft Advertising SDK に含まれる Microsoft Advertising ライブラリの現在のリリースには、**AdControl** や **InterstitialAd** をアプリのデザイン サーフェイスにドラッグするためのツールボックス コントロールがありません。 マークアップとコードでこれらのコントロールを追加する方法については、[開発者向けのチュートリアル](developer-walkthroughs.md)をご覧ください。

## 使用できなくなった緯度と経度のプロパティ

**AdControl**クラスに、UWP アプリ用の **Latitude** プロパティと **Longitude** プロパティは含まれなくなりました。 代わりに、広告コントロールに組み込まれているコードが、アプリに代わってこれらの値を検出し、広告サーバーに送信します。

## 重要な注意事項

必ずソフトウェア ライセンス条項 (EULA) 全体に目を通してください。 詳しくは、「[重要な注意事項 - EULA](important-notice-eula.md)」をご覧ください。

 

 



<!--HONumber=Sep16_HO2-->


