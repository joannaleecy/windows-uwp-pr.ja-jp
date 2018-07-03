---
author: mcleanbyron
ms.assetid: 527660fb-8e32-41b4-89cb-d422ed48c69b
description: このセクションのチュートリアルでは、Microsoft Advertising SDK を使ってアプリにバナー広告、スポット広告、ネイティブ広告を追加する方法について説明します。
title: アプリでの広告の実装
ms.author: mcleans
ms.date: 05/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, チュートリアル
ms.localizationpriority: medium
ms.openlocfilehash: c7562dd63206326f6cd278195effffdd2afa7b7f
ms.sourcegitcommit: 834992ec14a8a34320c96e2e9b887a2be5477a53
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/14/2018
ms.locfileid: "1880833"
---
# <a name="implement-ads-in-your-app"></a><span data-ttu-id="b46c1-104">アプリでの広告の実装</span><span class="sxs-lookup"><span data-stu-id="b46c1-104">Implement ads in your app</span></span>

<span data-ttu-id="b46c1-105">このセクションの記事では、Microsoft Advertising SDK を使ってアプリにバナー広告、スポット広告、ネイティブ広告を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b46c1-105">The articles in this section show you how to add banner ads, interstitial ads, and native ads to apps by using the Microsoft Advertising SDK.</span></span> <span data-ttu-id="b46c1-106">完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b46c1-106">For complete sample projects, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

## <a name="in-this-section"></a><span data-ttu-id="b46c1-107">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="b46c1-107">In this section</span></span>

|  <span data-ttu-id="b46c1-108">トピック</span><span class="sxs-lookup"><span data-stu-id="b46c1-108">Topic</span></span>    | <span data-ttu-id="b46c1-109">説明</span><span class="sxs-lookup"><span data-stu-id="b46c1-109">Description</span></span> |               
|----------|-------|
| [<span data-ttu-id="b46c1-110">バナー広告</span><span class="sxs-lookup"><span data-stu-id="b46c1-110">Banner ads</span></span>](banner-ads.md)     | <span data-ttu-id="b46c1-111">Microsoft Advertising SDK の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスを使用して、UWP アプリにバナー広告を追加する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="b46c1-111">Provides instructions for adding a banner ad to your UWP app by using the [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) class in the Microsoft Advertising SDK.</span></span>        |
| [<span data-ttu-id="b46c1-112">スポット広告</span><span class="sxs-lookup"><span data-stu-id="b46c1-112">Interstitial Ads</span></span>](interstitial-ads.md)    | <span data-ttu-id="b46c1-113">Microsoft Advertising SDK の [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) クラスを使用して、UWP アプリにスポット広告を追加する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="b46c1-113">Provides instructions for adding an interstitial ad to your UWP app by using the [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) class in the Microsoft Advertising SDK.</span></span>       |
| [<span data-ttu-id="b46c1-114">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="b46c1-114">Native ads</span></span>](native-ads.md)       | <span data-ttu-id="b46c1-115">Microsoft Advertising SDK の **NativeAdsManagerV2** クラスと **NativeAdV2** クラスを使用して、UWP アプリにネイティブ広告を追加する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="b46c1-115">Provides instructions for adding a native ad to your UWP app by using the **NativeAdsManagerV2** and **NativeAdV2** classes in the Microsoft Advertising SDK.</span></span>  |
| [<span data-ttu-id="b46c1-116">ビデオ コンテンツに広告を表示する</span><span class="sxs-lookup"><span data-stu-id="b46c1-116">Show ads in video content</span></span>](add-advertisements-to-video-content.md)     |  <span data-ttu-id="b46c1-117">UWP アプリでビデオ コンテンツに広告を表示するための手順について説明します (この機能は現在、JavaScript と HTML を使って記述されているアプリについてのみサポートされています)。</span><span class="sxs-lookup"><span data-stu-id="b46c1-117">Provides instructions for showing ads during video content in your UWP app (this feature is currently supported only for apps that are written using JavaScript with HTML).</span></span> |



 

 
