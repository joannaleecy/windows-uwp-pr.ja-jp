---
author: mcleanbyron
ms.assetid: 3aeddb83-5314-447b-b294-9fc28273cd39
description: "Microsoft Advertising ライブラリをインストールする方法について説明します。"
title: "Microsoft Advertising ライブラリのインストール"
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 0951818ceaf3d96543f9f97ec6993d08fdaab2b8


---

# Microsoft Advertising ライブラリのインストール


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Windows アプリ向けの Microsoft Advertising ライブラリは、[Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) に含まれています。 この SDK は、Visual Studio 2015 と Visual Studio 2013 の拡張機能です。

インストールの手順については、「[Microsoft Store Engagement and Monetization SDK](https://msdn.microsoft.com/windows/uwp/monetize/monetize-your-app-with-the-microsoft-store-engagement-and-monetization-sdk)」をご覧ください。

> 
            **注**  Windows 10 Anniversary SDK Preview ビルド 14295 以降を Visual Studio 2015 と共にインストールしている場合、JavaScript/HTML アプリに広告を追加するには WinJS ライブラリもインストールする必要があります。 このライブラリは以前のバージョンの Windows SDK for Windows 10 に含まれていましたが、Windows 10 Anniversary SDK Preview ビルド 14295 以降ではこのライブラリを別個にインストールする必要があります。 WinJS をインストールする場合は、「[Get WinJS (WinJS を入手する)](http://try.buildwinjs.com/download/GetWinJS/)」をご覧ください。

## 広告および広告仲介用のライブラリの名前


Microsoft Store Engagement and Monetization SDK には、2 つのセットの広告ライブラリが含まれています。1 つは、Microsoft Advertising 用ライブラリです (XAML および JavaScript/HTML アプリ用の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスと [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) クラスを提供します)。もう 1 つは、広告仲介ライブラリ用のライブラリです (**AdMediatorControl** クラスを提供します)。

このドキュメントでは、Microsoft Advertising ライブラリの **AdControl** クラスと **InterstitialAd** クラスを使って Microsoft からのバナーまたはビデオ スポット広告を表示する方法について説明します。 広告の仲介の使用について詳しくは、「[広告の仲介を追加して収益を最大限に高める](https://msdn.microsoft.com/windows/uwp/monetize/use-ad-mediation-to-maximize-revenue)」をご覧ください。


いずれかの広告コントロールをアプリ コードで使う場合、事前に適切なライブラリをプロジェクトで参照する必要があります。 次の表に、Visual Studio の **[参照マネージャー]** ダイアログ ボックスに表示される、Microsoft Store Engagement and Monetization SDK に含まれる各ライブラリの名前を示します。


<table>
    <thead>
        <tr><th>コントロール名</th><th>プロジェクトの種類</th><th>参照マネージャーでのライブラリの名前</th><th>バージョン番号</th></tr>
    </thead>
    <tbody>
    <tr>
            <td rowspan="3">
            **AdControl**、**InterstitialAd** (XAML)</td>
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
            <td rowspan="3">
            **AdControl**、**InterstitialAd** (JavaScript/HTML)</td>
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
            <td rowspan="3">
            **AdMediatorControl** (XAML のみ)</td>
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

 

 

 



<!--HONumber=Jun16_HO4-->


