---
description: iOS から UWP への移行
Search.SourceType: Video
title: iOS から UWP への移行
ms.assetid: 7a05751d-02df-4240-9ba5-d95f65a7a9c5
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3d4740c108491751afa038894de2e9c50579e74c
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7977579"
---
# <a name="move-from-ios-to-uwp"></a><span data-ttu-id="42ca6-104">iOS から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="42ca6-104">Move from iOS to UWP</span></span>

<span data-ttu-id="42ca6-105">ユーザー ベースを Windows 10 とユニバーサル Windows プラットフォーム (UWP) にまで拡大する方法に悩んでいる iOS 開発者向けに、便利なツールが提供されています。そしてその数は日々増え続けています。</span><span class="sxs-lookup"><span data-stu-id="42ca6-105">If you are an iOS developer wondering how to expand your user base to include Windows 10 and the Universal Windows Platform (UWP), there are a growing number of tools to help you.</span></span> <span data-ttu-id="42ca6-106">どの方法を使うかは、対象のアプリの種類 (ゲーム、ライフ スタイル、エンタープライズなど) と、開発プロセスにどれだけ関与できるかに応じて異なります。</span><span class="sxs-lookup"><span data-stu-id="42ca6-106">The approaches you can take depend on the type of app you are working on (game, lifestyle, enterprise, and so on) and how far along you are in the development process.</span></span> <span data-ttu-id="42ca6-107">たとえば、OpenGL または Cocos2D に大きく依存している完成済みのゲームまたはほぼ完成しているゲームの場合は、[iOS 用 Windows ブリッジ](https://dev.windows.com/bridges/ios)が有力な候補になります。また、スモール ビジネス用のクロスプラットフォーム アプリを計画している場合は、[Xamarin.Forms](https://www.xamarin.com/forms) の使用を検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="42ca6-107">For example, a completed or nearly completed game that is heavily dependent on OpenGL or Cocos2D is an ideal candidate for the [Windows Bridge for iOS](https://dev.windows.com/bridges/ios), whereas if you are planning a cross-platform app for a small business, you should be considering using [Xamarin.Forms](https://www.xamarin.com/forms).</span></span> <span data-ttu-id="42ca6-108">Unity などのクロスプラットフォーム ツールでアプリを記述している場合は、[Windows に公開](http://blogs.unity3d.com/2015/09/09/windows-10-universal-apps-in-unity-5-2/)するのが簡単です。</span><span class="sxs-lookup"><span data-stu-id="42ca6-108">And if you have written your app in a cross-platform tool such as Unity, [publishing to Windows](http://blogs.unity3d.com/2015/09/09/windows-10-universal-apps-in-unity-5-2/) is quite straightforward.</span></span>

## <a name="why-windows"></a><span data-ttu-id="42ca6-109">Windows を選ぶ理由</span><span class="sxs-lookup"><span data-stu-id="42ca6-109">Why Windows?</span></span>

<span data-ttu-id="42ca6-110">今日は、Windows は膨大な数のデバイスで実行されています。</span><span class="sxs-lookup"><span data-stu-id="42ca6-110">Today, Windows is running on a huge number of devices.</span></span> <span data-ttu-id="42ca6-111">UWP は、デスクトップ コンピューター、ゲーム コンソール、ホログラフィック ディスプレイなどのさまざまなデバイス間で美しく応答性に優れたユーザー インターフェイスを作るように設計された最新の API のセットを開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="42ca6-111">The UWP provides developers with a set of modern APIs, designed to create beautifully responsive user interfaces across devices as diverse as desktop computers, games consoles and holographic displays.</span></span> <span data-ttu-id="42ca6-112">1 つの Visual Studio ソリューションと、複数のプラットフォームに自動的に最適化されるスマートなユーザー インターフェイス コントロールにより、より少ないコードで記述したアプリをより多くのハードウェア上で実行できます。</span><span class="sxs-lookup"><span data-stu-id="42ca6-112">With one Visual Studio solution, and with user interface controls that are smart enough to automatically optimize themselves for multiple platforms , you'll often find that you are writing less code and running it on more hardware.</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-Convert-your-iOS-app-to-Windows/player]

| <span data-ttu-id="42ca6-113">トピック</span><span class="sxs-lookup"><span data-stu-id="42ca6-113">Topic</span></span> | <span data-ttu-id="42ca6-114">説明</span><span class="sxs-lookup"><span data-stu-id="42ca6-114">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="42ca6-115">iOS と UWP のアプリ開発方法の選択</span><span class="sxs-lookup"><span data-stu-id="42ca6-115">Selecting an approach to iOS and UWP app development</span></span>](selecting-an-approach-to-ios-and-uwp-app-development.md) | <span data-ttu-id="42ca6-116">クロスプラットフォーム アプリを開発するときの選択肢</span><span class="sxs-lookup"><span data-stu-id="42ca6-116">What are the choices when developing cross-platform apps?</span></span> |
| [<span data-ttu-id="42ca6-117">iOS 開発者のための UWP の概要</span><span class="sxs-lookup"><span data-stu-id="42ca6-117">Getting started with UWP for iOS developers</span></span>](getting-started-with-uwp-for-ios-developers.md) | <span data-ttu-id="42ca6-118">この記事は、Windows 10 用の開発を検討している iOS 開発者向けに用意されています。</span><span class="sxs-lookup"><span data-stu-id="42ca6-118">If you're an iOS developer considering developing for Windows 10, these docs are a great place to start.</span></span> |
| [<span data-ttu-id="42ca6-119">Windows 10 を使用するための Mac のセットアップ</span><span class="sxs-lookup"><span data-stu-id="42ca6-119">Setting up your Mac with Windows 10</span></span>](setting-up-your-mac-with-windows-10.md) | <span data-ttu-id="42ca6-120">現在の Mac コンピューターを使用して、Windows 用アプリを開発します。</span><span class="sxs-lookup"><span data-stu-id="42ca6-120">Use your current Mac computer to develop apps for Windows.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="42ca6-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="42ca6-121">Related topics</span></span>

**<span data-ttu-id="42ca6-122">設計者と開発者向け</span><span class="sxs-lookup"><span data-stu-id="42ca6-122">For designers and developers</span></span>**
* [<span data-ttu-id="42ca6-123">すべての Windows デバイスを対象としたユニバーサル Windows アプリの構築</span><span class="sxs-lookup"><span data-stu-id="42ca6-123">Building Universal Windows apps for all Windows devices</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=397871)
* [<span data-ttu-id="42ca6-124">UWP アプリの設計アセットのダウンロード</span><span class="sxs-lookup"><span data-stu-id="42ca6-124">Download design assets for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)
