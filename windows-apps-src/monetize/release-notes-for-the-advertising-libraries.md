---
author: mcleanbyron
ms.assetid: ca92bed1-ad9e-4947-ad91-87d12de727c0
description: "Microsoft Store Services SDK に含まれる Microsoft Advertising ライブラリのリリース ノートを確認します。"
title: "Advertising ライブラリのリリース ノート"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, リリース ノート"
ms.openlocfilehash: f3d07df6e64c96e9070cb82bd7ac6e96b9cad1ee
ms.sourcegitcommit: d053f28b127e39bf2aee616aa52bb5612194dc53
translationtype: HT
---
# <a name="release-notes-for-the-advertising-libraries"></a>Advertising ライブラリのリリース ノート




このセクションでは、Microsoft Store Services SDK (UWP アプリ用) と、Windows および Windows Phone 8.x 用の Microsoft Advertising SDK (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) に含まれている Microsoft Advertising ライブラリの現在のリリースに関するリリース ノートを示します。 これらのライブラリは、Windows 10、Windows 8.1、Windows Phone 8.1、Windows Phone 8 用の XAML アプリと JavaScript/HTML アプリをサポートします。

## <a name="installation"></a>インストール


Microsoft Advertising ライブラリは、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) (UWP アプリ用) と [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) の一部として入手できます。 この SDK と SDK に含まれているライブラリのインストールについて詳しくは、「[Microsoft Advertising ライブラリのインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。

Windows Phone 8.x Silverlight プロジェクト用の Microsoft Advertising アセンブリを入手するには、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。次に、プロジェクトを Visual Studio で開き、**[プロジェクト]** > **[接続済みサービスを追加します]** > **[Ad Mediator]** の順に移動して、アセンブリを自動的にダウンロードします。 その後、広告仲介を使用しない場合は、広告メディエーターの参照をプロジェクトから削除できます。 詳しくは、「[AdControl in Windows Phone Silverlight (Windows Phone Silverlight での AdControl)](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。


## <a name="uninstall-previous-versions"></a>以前のバージョンのアンインストール

Microsoft Store Services SDK (UWP アプリ用) または Windows および Windows Phone 8.x 用の Microsoft Advertising SDK (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) をインストールする前に、Microsoft Universal Ad Client SDK または Microsoft Advertising SDK の以前のインスタンスをすべてアンインストールすることを強くお勧めします。

## <a name="target-architecture-specific-build-outputs"></a>ターゲット アーキテクチャ固有のビルドの出力

Microsoft Advertising ライブラリを使う場合、プロジェクトで **Any CPU** をターゲットにすることはできません。 プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。 この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。

## <a name="c-support"></a>C++ のサポート

Microsoft Advertising ライブラリ (**AdControl** クラスと **InterstitialAd** クラスが含まれる) は、Windows ランタイムの相互運用性 (*相互運用機能*) を使用して C++ および DirectX で記述されたアプリをサポートします。 XAML と C++ を使ったプログラミングの詳細情報と例については、「[型システム](https://msdn.microsoft.com/library/windows/apps/xaml/hh755822.aspx)」をご覧ください。

## <a name="no-toolbox-control"></a>ツールボックス コントロールはない

Microsoft Store Services SDK または Windows および Windows Phone 8.x 用の Microsoft Advertising SDK に含まれる Microsoft Advertising ライブラリの現在のリリースには、**AdControl** や **InterstitialAd** をアプリのデザイン サーフェイスにドラッグするためのツールボックス コントロールがありません。 マークアップとコードでこれらのコントロールを追加する方法については、[開発者向けのチュートリアル](developer-walkthroughs.md)をご覧ください。

## <a name="latitude-and-longitude-properties-no-longer-available"></a>使用できなくなった緯度と経度のプロパティ

**AdControl**クラスに、UWP アプリ用の **Latitude** プロパティと **Longitude** プロパティは含まれなくなりました。 代わりに、広告コントロールに組み込まれているコードが、アプリに代わってこれらの値を検出し、広告サーバーに送信します。


 

 
