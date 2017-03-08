---
author: mcleanbyron
ms.assetid: 3aeddb83-5314-447b-b294-9fc28273cd39
description: "Microsoft Advertising ライブラリをインストールする方法について説明します。"
title: "Microsoft Advertising ライブラリのインストール"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, インストール, SDK, ライブラリ"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 034b597c945f9f12700ac442e4b3014b0bc84c78
ms.lasthandoff: 02/07/2017

---

# <a name="install-the-microsoft-advertising-libraries"></a>Microsoft Advertising ライブラリのインストール




Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリ向けに、[Microsoft Store Services SDK](http://aka.ms/store-em-sdk) には Microsoft Advertising ライブラリが含まれています。 この SDK は、Visual Studio 2015 およびそれ以降のバージョンの拡張機能です。 この SDK のインストールについて詳しくは、[この記事](microsoft-store-services-sdk.md)をご覧ください。

> **注**&nbsp;&nbsp;Windows 10 SDK (14393) 以降をインストールしている場合、JavaScript/HTML UWP アプリに広告を追加するには WinJS ライブラリもインストールする必要があります。 このライブラリは以前のバージョンの Windows 10 SDK に含まれていましたが、Windows 10 SDK (14393) 以降ではこのライブラリを別個にインストールする必要があります。 WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。

Windows 8.1 および Windows Phone 8.x 用の XAML アプリと JavaScript/HTML アプリ向けには、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) にMicrosoft Advertising ライブラリが含まれています。 この SDK は、Visual Studio 2015 と Visual Studio 2013 の拡張機能です。

Windows Phone Silverlight 8.x アプリ向けには、Microsoft Advertising ライブラリは NuGet パッケージとして提供されています。このパッケージは、ダウンロードしてプロジェクトにインストールできます。 詳しくは、「[Windows Phone Silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」をご覧ください。

## <a name="library-names-for-advertising"></a>広告用のライブラリの名前


Windows および Windows Phone 8.x 用の Microsoft Store Services SDK と Microsoft Advertising SDK には、いくつか次のような広告ライブラリが用意されています。

* Microsoft Store Services SDK には、Microsoft Advertising ライブラリが含まれています (XAML アプリと JavaScript/HTML アプリ用の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスと [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) クラスを提供します)。

* Windows および Windows Phone 8.x 用の Microsoft Advertising SDK には、2 つのセットの広告ライブラリが含まれています。1 つは、Microsoft Advertising 用ライブラリです (XAML および JavaScript/HTML アプリ用の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスと [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) クラスを提供します)。もう 1 つは、広告仲介ライブラリ用のライブラリです (**AdMediatorControl** クラスを提供します)。

このドキュメントでは、Microsoft Advertising ライブラリの **AdControl** クラスと **InterstitialAd** クラスを使ってバナーまたはビデオ スポット広告を表示する方法について説明します。 Windows 8.1 アプリと Windows Phone 8.x アプリ向けの広告の仲介の使用について詳しくは、「[広告の仲介を追加して収益を最大限に高める](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359.aspx)」をご覧ください。

>**注**&nbsp;&nbsp;**AdMediatorControl** クラスを使用した広告の仲介は、Windows 10 用の UWP アプリでは現在サポートされていません。 サーバー側の広告仲介は、UWP アプリ で間もなく利用可能になる予定です。この場合、バナー広告 (**AdControl**) とビデオ スポット広告 (**InterstitialAd**) には同じ API が使用されます。

いずれかの広告コントロールをアプリ コードで使う場合、事前に適切なライブラリをプロジェクトで参照する必要があります。 次の表に、Visual Studio の **[参照マネージャー]** ダイアログ ボックスに表示される各ライブラリの名前を示します。


<table>
    <thead>
        <tr><th>コントロール名</th><th>プロジェクトの種類</th><th>参照マネージャーでのライブラリの名前</th><th>バージョン番号</th></tr>
    </thead>
    <tbody>
    <tr>
            <td rowspan="3">**AdControl**、**InterstitialAd** (XAML)</td>
            <td>UWP</td>
            <td>Microsoft Advertising SDK for XAML</td>
            <td>10.0</td>
        </tr>
        <tr>
            <td>Windows 8.1</td>
            <td>Ad Mediator SDK for Windows 8.1 XAML</td>
            <td>1.0</td>
        </tr>
        <tr>
            <td>Windows Phone 8.1</td>
            <td>Ad Mediator SDK for Windows Phone 8.1 XAML</td>
            <td>1.0</td>
        </tr>
    <tr>
            <td rowspan="3">**AdControl**、**InterstitialAd** (JavaScript/HTML)</td>
            <td>UWP</td>
            <td>Microsoft Advertising SDK for JavaScript</td>
            <td>10.0</td>
        </tr>
        <tr>
            <td>Windows 8.1</td>
            <td>Microsoft Advertising SDK for Windows 8.1 Native (JS)</td>
            <td>8.5</td>
        </tr>
        <tr>
            <td>Windows Phone 8.1</td>
            <td>Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)</td>
            <td>8.5</td>
        </tr>
    <tr>
            <td rowspan="3">**AdMediatorControl** (XAML のみ)</td>
            <td>UWP</td>
            <td>Microsoft Advertising Universal SDK</td>
            <td>1.0</td>
        </tr>
        <tr>
            <td>Windows 8.1</td>
            <td>Ad Mediator SDK for Windows 8.1 XAML</td>
            <td>1.0</td>
        </tr>
        <tr>
            <td>Windows Phone 8.1</td>
            <td>Ad Mediator SDK for Windows Phone 8.1 XAML</td>
            <td>1.0</td>
        </tr>
    </tbody>
</table>

 

 

 

