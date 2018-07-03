---
author: joannaleecy
title: Windows 10 ゲーム開発ガイド
description: ユニバーサル Windows プラットフォーム (UWP) ゲーム開発のためのリソースや情報を網羅したガイドです。
ms.assetid: 6061F498-96A8-44EF-9711-68AE5A1218C9
ms.author: joanlee
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム、ゲーム開発
ms.localizationpriority: medium
ms.openlocfilehash: b351b5072c6bba228d81a65b51656a81bd564daf
ms.sourcegitcommit: 3500825bc2e5698394a8b1d2efece7f071f296c1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/09/2018
ms.locfileid: "1862261"
---
# <a name="windows-10-game-development-guide"></a><span data-ttu-id="70357-104">Windows 10 ゲーム開発ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-104">Windows 10 game development guide</span></span>


<span data-ttu-id="70357-105">Windows 10 ゲーム開発ガイドへようこそ。</span><span class="sxs-lookup"><span data-stu-id="70357-105">Welcome to the Windows 10 game development guide!</span></span>

<span data-ttu-id="70357-106">このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に必要なリソースと情報を網羅したコレクションを提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-106">This guide provides an end-to-end collection of the resources and information you'll need to develop a Universal Windows Platform (UWP) game.</span></span> <span data-ttu-id="70357-107">このガイドの英語 (米国) 版は [PDF](http://download.microsoft.com/download/9/C/9/9C9D344F-611F-412E-BB01-259E5C76B17F/Windev_Game_Dev_Guide_Oct_2017.pdf) 形式で利用できます。</span><span class="sxs-lookup"><span data-stu-id="70357-107">An English (US) version of this guide is available in [PDF](http://download.microsoft.com/download/9/C/9/9C9D344F-611F-412E-BB01-259E5C76B17F/Windev_Game_Dev_Guide_Oct_2017.pdf) format.</span></span>

## <a name="introduction-to-game-development-for-the-universal-windows-platform-uwp"></a><span data-ttu-id="70357-108">ユニバーサル Windows プラットフォーム (UWP) 用ゲーム開発の概要</span><span class="sxs-lookup"><span data-stu-id="70357-108">Introduction to game development for the Universal Windows Platform (UWP)</span></span>


<span data-ttu-id="70357-109">Windows 10 ゲームを作成すると、スマートフォンから PC、Xbox One にいたる数百万人のプレイヤーにゲームを提供するチャンスを得られます。</span><span class="sxs-lookup"><span data-stu-id="70357-109">When you create a Windows 10 game, you have the opportunity to reach millions of players worldwide across phone, PC, and Xbox One.</span></span> <span data-ttu-id="70357-110">Windows の Xbox、Xbox Live、クロス デバイス マルチプレイヤー、すばらしいゲーム コミュニティ、ユニバーサル Windows プラットフォーム (UWP) や DirectX 12 などの強力な新機能により、Windows 10 ゲームは、あらゆる世代やジャンルのプレイヤーを楽しませるでしょう。</span><span class="sxs-lookup"><span data-stu-id="70357-110">With Xbox on Windows, Xbox Live, cross-device multiplayer, an amazing gaming community, and powerful new features like the Universal Windows Platform (UWP) and DirectX 12, Windows 10 games thrill players of all ages and genres.</span></span> <span data-ttu-id="70357-111">新しいユニバーサル Windows プラットフォーム (UWP) は、スマートフォン、PC、Xbox One 用の共通 API と、各デバイスのエクスペリエンスに合わせてゲームをカスタマイズするツールやオプションによって、Windows 10 デバイスでのゲームの互換性を実現します。</span><span class="sxs-lookup"><span data-stu-id="70357-111">The new Universal Windows Platform (UWP) delivers compatibility for your game across Windows 10 devices with a common API for phone, PC, and Xbox One, along with tools and options to tailor your game to each device experience.</span></span>

<span data-ttu-id="70357-112">このガイドでは、ゲームの開発に役立つさまざまなリソースや情報を網羅して提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-112">This guide provides an end-to-end collection of information and resources that will help you as you develop your game.</span></span> <span data-ttu-id="70357-113">必要なときに情報を検索する場所がわかるように、各セクションはゲームの開発の各段階に従って編成されています。</span><span class="sxs-lookup"><span data-stu-id="70357-113">The sections are organized according to the stages of game development, so you'll know where to look for information when you need it.</span></span>

<span data-ttu-id="70357-114">Windows または Xbox で初めてゲームを開発する場合は、最初に[ファースト ステップ](getting-started.md) ガイドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="70357-114">If you're new to developing games on Windows or Xbox, the [Getting Started](getting-started.md) guide may be where you want to start off.</span></span> <span data-ttu-id="70357-115">「[ゲーム開発に関するリソース](#game-development-resources)」セクションでも、ゲームの作成時に役立つドキュメント、プログラム、その他のリソースの大まかな概要を示します。</span><span class="sxs-lookup"><span data-stu-id="70357-115">The [Game development resources](#game-development-resources) section also provides a high-level survey of documentation, programs, and other resources that are helpful when creating a game.</span></span> <span data-ttu-id="70357-116">概要ではなく、実際の UWP コードを見て作業を始める場合は、「[ゲームのサンプル](#game-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="70357-116">If you want to start by looking at some UWP code instead, see [Game samples](#game-samples).</span></span>

<span data-ttu-id="70357-117">このガイドは、Windows 10 ゲーム開発に関する新しいリソースや資料が利用可能になると更新されます。</span><span class="sxs-lookup"><span data-stu-id="70357-117">This guide will be updated as additional Windows 10 game development resources and material become available.</span></span>

## <a name="game-development-resources"></a><span data-ttu-id="70357-118">ゲーム開発に関するリソース</span><span class="sxs-lookup"><span data-stu-id="70357-118">Game development resources</span></span>

<span data-ttu-id="70357-119">ドキュメントから、開発者向けのプログラム、フォーラム、ブログ、サンプルまで、ゲーム開発に役立つ多くのリソースが用意されています。</span><span class="sxs-lookup"><span data-stu-id="70357-119">From documentation to developer programs, forums, blogs, and samples, there are many resources available to help you on your game development journey.</span></span> <span data-ttu-id="70357-120">ここでは、Windows 10 ゲームの開発を始めるにあたって役立つリソースをまとめています。</span><span class="sxs-lookup"><span data-stu-id="70357-120">Here's a roundup of resources to know about as you begin developing your Windows 10 game.</span></span>

> [!Note]
> <span data-ttu-id="70357-121">一部の機能は、さまざまなプログラムで管理されています。</span><span class="sxs-lookup"><span data-stu-id="70357-121">Some features are managed through various programs.</span></span> <span data-ttu-id="70357-122">このガイドでは幅広いリソースを取り上げているため、参加しているプログラムや特定の開発の役割によっては、一部のリソースにアクセスできない場合があります。</span><span class="sxs-lookup"><span data-stu-id="70357-122">This guide covers a broad range of resources, so you may find that some resources are inaccessible depending on the program you are in or your specific development role.</span></span> <span data-ttu-id="70357-123">developer.xboxlive.com、forums.xboxlive.com、xdi.xboxlive.com、Game Developer Network (GDN) に解決されるリンクなどです。</span><span class="sxs-lookup"><span data-stu-id="70357-123">Examples are links that resolve to developer.xboxlive.com, forums.xboxlive.com, xdi.xboxlive.com, or the Game Developer Network (GDN).</span></span> <span data-ttu-id="70357-124">Microsoft との提携について詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="70357-124">For information about partnering with Microsoft, see [Developer Programs](#developer-programs).</span></span>


### <a name="game-development-documentation"></a><span data-ttu-id="70357-125">ゲーム開発に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-125">Game development documentation</span></span>

<span data-ttu-id="70357-126">このガイド全体を通して、タスク、テクノロジ、ゲームの開発の段階ごとに整理された、関連ドキュメントへのディープ リンクを示しています。</span><span class="sxs-lookup"><span data-stu-id="70357-126">Throughout this guide, you'll find deep links to relevant documentation—organized by task, technology, and stage of game development.</span></span> <span data-ttu-id="70357-127">利用可能なドキュメントのさまざまなビューを提供するために、Windows 10 ゲーム開発用の主要なドキュメント ポータルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="70357-127">To give you a broad view of what's available, here are the main documentation portals for Windows 10 game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-128">Windows デベロッパー センターのメイン ポータル</span><span class="sxs-lookup"><span data-stu-id="70357-128">Windows Dev Center main portal</span></span></td>
        <td><a href="https://dev.windows.com"><span data-ttu-id="70357-129">Windows デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="70357-129">Windows Dev Center</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-130">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="70357-130">Developing Windows apps</span></span></td>
        <td><a href="https://dev.windows.com/develop"><span data-ttu-id="70357-131">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="70357-131">Develop Windows apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-132">ユニバーサル Windows プラットフォーム アプリの開発</span><span class="sxs-lookup"><span data-stu-id="70357-132">Universal Windows Platform app development</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt244352"><span data-ttu-id="70357-133">Windows 10 アプリに関するハウツー ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-133">How-to guides for Windows 10 apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-134">UWP ゲームに関する使い方ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-134">How-to guides for UWP games</span></span></td>
        <td><a href="index.md"><span data-ttu-id="70357-135">ゲームと DirectX</span><span class="sxs-lookup"><span data-stu-id="70357-135">Games and DirectX</span></span></a> </td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-136">DirectX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="70357-136">DirectX reference and overviews</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274"><span data-ttu-id="70357-137">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="70357-137">DirectX Graphics and Gaming</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-138">ゲームのための Azure</span><span class="sxs-lookup"><span data-stu-id="70357-138">Azure for gaming</span></span></td>
        <td><a href="https://azure.microsoft.com/solutions/gaming/"><span data-ttu-id="70357-139">Azure を使ったゲームの構築とスケーリング</span><span class="sxs-lookup"><span data-stu-id="70357-139">Build and scale your games using Azure</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-140">PlayFab</span><span class="sxs-lookup"><span data-stu-id="70357-140">PlayFab</span></span></td>
        <td><a href="https://api.playfab.com/"><span data-ttu-id="70357-141">ライブ ゲームの完全なバックエンド ソリューション</span><span class="sxs-lookup"><span data-stu-id="70357-141">Complete backend solution for live games</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-142">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="70357-142">UWP on Xbox One</span></span></td>
        <td><a href="https://msdn.microsoft.com/windows/uwp/xbox-apps/index"><span data-ttu-id="70357-143">Xbox One の UWP アプリの構築</span><span class="sxs-lookup"><span data-stu-id="70357-143">Building UWP apps on Xbox One</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-144">HoloLens の UWP</span><span class="sxs-lookup"><span data-stu-id="70357-144">UWP on HoloLens</span></span></td>
        <td><a href="https://developer.microsoft.com/windows/mixed-reality/development_overview"><span data-ttu-id="70357-145">HoloLens の UWP アプリの構築</span><span class="sxs-lookup"><span data-stu-id="70357-145">Building UWP apps on HoloLens</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-146">Xbox Live に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-146">Xbox Live documentation</span></span></td>
        <td><a href="../xbox-live/index.md"><span data-ttu-id="70357-147">Xbox Live 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="70357-147">Xbox Live developer guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-148">Xbox One 開発に関するドキュメント (XGD)</span><span class="sxs-lookup"><span data-stu-id="70357-148">Xbox One development documentation (XGD)</span></span></td>
        <td><a href="https://developer.microsoft.com/games/xbox/partner/development-home"><span data-ttu-id="70357-149">Xbox One 開発</span><span class="sxs-lookup"><span data-stu-id="70357-149">Xbox One Development</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-150">Xbox One 開発に関するホワイト ペーパー (XGD)</span><span class="sxs-lookup"><span data-stu-id="70357-150">Xbox One development whitepapers (XGD)</span></span></td>
        <td><a href="https://developer.microsoft.com/games/xbox/partner/development-education-whitepapers"><span data-ttu-id="70357-151">ホワイト ペーパー</span><span class="sxs-lookup"><span data-stu-id="70357-151">White Papers</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-152">Mixer の対話機能のドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-152">Mixer Interactive documentation</span></span></td>
        <td><a href="https://dev.mixer.com/reference/interactive/index.html"><span data-ttu-id="70357-153">ゲームへの対話機能の追加</span><span class="sxs-lookup"><span data-stu-id="70357-153">Add interactivity to your game</span></span></a></td>
    </tr>        
</table>

### <a name="windows-dev-center"></a><span data-ttu-id="70357-154">Windows デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="70357-154">Windows Dev Center</span></span>

<span data-ttu-id="70357-155">Windows ゲームの公開に向けての最初の一歩は、Windows デベロッパー センターで開発者アカウントを登録することです。</span><span class="sxs-lookup"><span data-stu-id="70357-155">Registering a developer account on the Windows Dev Center is the first step towards publishing your Windows game.</span></span> <span data-ttu-id="70357-156">開発者アカウントでは、ゲームの名前を予約することや、すべての Windows デバイスに対応する無料ゲームと有料ゲームを Microsoft Store に提出することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-156">A developer account lets you reserve your game's name and submit free or paid games to the Microsoft Store for all Windows devices.</span></span> <span data-ttu-id="70357-157">開発者アカウントを使って、ゲームとゲーム内製品を管理したり、詳細な分析を取得したり、世界中のプレイヤーに優れたエクスペリエンスを提供するサービスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-157">Use your developer account to manage your game and in-game products, get detailed analytics, and enable services that create great experiences for your players around the world.</span></span> 

<span data-ttu-id="70357-158">さらにマイクロソフトでは、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="70357-158">Microsoft also offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="70357-159">デベロッパー センター アカウントに登録する前に、他に適切なプログラムがあるかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="70357-159">We recommend seeing if any are right for you before registering for a Dev Center account.</span></span> <span data-ttu-id="70357-160">詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="70357-160">For more info, go to [Developer programs](#developer-programs)</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-161">開発者アカウントの登録</span><span class="sxs-lookup"><span data-stu-id="70357-161">Register a developer account</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/bg124287"><span data-ttu-id="70357-162">サインアップの準備はできましたか</span><span class="sxs-lookup"><span data-stu-id="70357-162">Ready to sign up?</span></span></a></td>
    </tr> 
</table>

### <a name="developer-programs"></a><span data-ttu-id="70357-163">開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-163">Developer programs</span></span>

<span data-ttu-id="70357-164">Microsoft では、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="70357-164">Microsoft offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="70357-165">Xbox One のゲームを開発し、Xbox Live の機能をゲームに統合する場合には、開発者プログラムへの参加を検討してください。</span><span class="sxs-lookup"><span data-stu-id="70357-165">Consider joining a developer program if you want to develop games for Xbox One and integrate Xbox Live features in your game.</span></span> <span data-ttu-id="70357-166">Microsoft Store でゲームを公開するには、さらに Windows デベロッパー センターで開発者アカウントを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="70357-166">To publish a game in the Microsoft Store, you'll also need to create a developer account on Windows Dev Center.</span></span>

#### <a name="xbox-live-creators-program"></a><span data-ttu-id="70357-167">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-167">Xbox Live Creators Program</span></span>

<span data-ttu-id="70357-168">Xbox Live クリエーターズ プログラムでは、だれでも Xbox Live を自分のタイトルに統合して、Xbox One や Windows 10 に公開することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-168">The Xbox Live Creators Program allows anyone to integrate Xbox Live into their title and publish to Xbox One and Windows 10.</span></span> <span data-ttu-id="70357-169">認定プロセスが簡素化され、標準的な [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx)以外に概念の承認はありません。</span><span class="sxs-lookup"><span data-stu-id="70357-169">There is a simplified certification process and no concept approval is required outside of the standard [Microsoft Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx).</span></span>

<span data-ttu-id="70357-170">専用の開発キットがなくても、製品版ハードウェアのみを使用して、クリエーターズ プログラムでゲームを展開、設計、公開することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-170">You can deploy, design, and publish your game in the Creators Program without a dedicated dev kit, using only retail hardware.</span></span> <span data-ttu-id="70357-171">作業を始めるには、Xbox One で[開発者モードのアクティブ化用アプリ](https://docs.microsoft.com/windows/uwp/xbox-apps/devkit-activation)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="70357-171">To get started, download the [Dev Mode Activation app](https://docs.microsoft.com/windows/uwp/xbox-apps/devkit-activation) on your Xbox One.</span></span>

<span data-ttu-id="70357-172">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/Developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="70357-172">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](http://www.xbox.com/Developers/id) program.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-173">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-173">Xbox Live Creators Program</span></span></td>
        <td><a href="https://developer.microsoft.com/games/xbox/xboxlive/creator"><span data-ttu-id="70357-174">Xbox Live クリエーターズ プログラムの詳細を見る</span><span class="sxs-lookup"><span data-stu-id="70357-174">Learn more about the Xbox Live Creators Program</span></span></a></td>
    </tr>
</table>

#### <a name="idxbox"></a>ID@Xbox

<span data-ttu-id="70357-175">ID@Xbox プログラムを利用すると、認定されたゲーム開発者は Windows や Xbox One 向けに自分でゲームを公開することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-175">The ID@Xbox program helps qualified game developers self-publish on Windows and Xbox One.</span></span> <span data-ttu-id="70357-176">Xbox One 向けの開発を行ったり、ゲーマースコア、達成度、ランキングなどの Xbox Live 機能を自分の Windows 10 ゲームでも実現したいと検討されているなら、ID@Xbox にサインアップしてください。</span><span class="sxs-lookup"><span data-stu-id="70357-176">If you want to develop for Xbox One, or add Xbox Live features like Gamerscore, achievements, and leaderboards to your Windows 10 game, sign up with ID@Xbox.</span></span> <span data-ttu-id="70357-177">ID@Xbox 開発者になると、創造性を発揮し、成功の可能性を最大限に引き出すためのツールやサポートを利用できます。</span><span class="sxs-lookup"><span data-stu-id="70357-177">Become an ID@Xbox developer to get the tools and support you need to unleash your creativity and maximize your success.</span></span> <span data-ttu-id="70357-178">Windows デベロッパー センターで開発者アカウントを登録する前に、まず ID@Xbox に申し込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="70357-178">We recommend that you apply to ID@Xbox first before registering for a developer account on Windows Dev Center.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-179">ID@Xbox開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-179">ID@Xbox developer program</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?LinkID=526271"><span data-ttu-id="70357-180">Xbox One 向けの独立した開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-180">Independent Developer Program for Xbox One</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-181">ID@Xbox コンシューマー向けサイト</span><span class="sxs-lookup"><span data-stu-id="70357-181">ID@Xbox consumer site</span></span></td>
        <td><a href="http://www.idatxbox.com/">ID@Xbox</a></td>
    </tr>
</table>

#### <a name="xbox-tools-and-middleware"></a><span data-ttu-id="70357-182">Xbox のツールとミドルウェア</span><span class="sxs-lookup"><span data-stu-id="70357-182">Xbox tools and middleware</span></span>

<span data-ttu-id="70357-183">Xbox のツールおよびミドルウェア プログラムは、ゲームのツールやミドルウェア専門の開発者に Xbox 開発キットのライセンスを付与します。</span><span class="sxs-lookup"><span data-stu-id="70357-183">The Xbox Tools and Middleware Program licenses Xbox development kits to professional developers of game tools and middleware.</span></span> <span data-ttu-id="70357-184">プログラムに受け入れられた開発者は、Xbox XDK テクノロジを共有し、ライセンスを持つ他の Xbox 開発者に配布することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-184">Developers accepted into the program can share and distribute their Xbox XDK technologies to other licensed Xbox developers.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-185">ツールおよびミドルウェア プログラムについて問い合わせる</span><span class="sxs-lookup"><span data-stu-id="70357-185">Contact the tools and middleware program</span></span></td>
        <td><xboxtlsm@microsoft.com></td>
    </tr>
</table>


### <a name="game-samples"></a><span data-ttu-id="70357-186">ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-186">Game samples</span></span>

<span data-ttu-id="70357-187">Windows 10 のゲーム機能を理解してゲーム開発をすぐに始めることができるように、Windows 10 のゲームとアプリのサンプルが数多く用意されています。</span><span class="sxs-lookup"><span data-stu-id="70357-187">There are many Windows 10 game and app samples available to help you understand Windows 10 gaming features and get a quick start on game development.</span></span> <span data-ttu-id="70357-188">サンプルは次々と開発され、定期的に公開されるため、ときどきサンプル ポータルをチェックして、新機能を確認することを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="70357-188">More samples are developed and published regularly, so don't forget to occasionally check back at sample portals to see what's new.</span></span> <span data-ttu-id="70357-189">GitHub のリポジトリを[監視](https://help.github.com/articles/watching-repositories/)して、変更や追加についての通知を受け取ることもできます。</span><span class="sxs-lookup"><span data-stu-id="70357-189">You can also [watch](https://help.github.com/articles/watching-repositories/) GitHub repos to be notified of changes and additions.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-190">ユニバーサル Windows プラットフォーム アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-190">Universal Windows Platform app samples</span></span></td>
        <td><a href="https://github.com/Microsoft/Windows-universal-samples"><span data-ttu-id="70357-191">Windows-universal-samples</span><span class="sxs-lookup"><span data-stu-id="70357-191">Windows-universal-samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-192">Direct3D 12 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-192">Direct3D 12 graphics samples</span></span></td>
        <td><a href="https://github.com/Microsoft/DirectX-Graphics-Samples"><span data-ttu-id="70357-193">DirectX-Graphics-Samples</span><span class="sxs-lookup"><span data-stu-id="70357-193">DirectX-Graphics-Samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-194">Direct3D 11 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-194">Direct3D 11 graphics samples</span></span></td>
        <td><a href="https://github.com/walbourn/directx-sdk-samples"><span data-ttu-id="70357-195">directx-sdk-samples</span><span class="sxs-lookup"><span data-stu-id="70357-195">directx-sdk-samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-196">Direct3D 11 主観視点のゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-196">Direct3D 11 first-person game sample</span></span></td>
        <td><a href="tutorial--create-your-first-uwp-directx-game.md"><span data-ttu-id="70357-197">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="70357-197">Create a simple UWP game with DirectX</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-198">Direct2D カスタム画像効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-198">Direct2D custom image effects sample</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?LinkId=620531"><span data-ttu-id="70357-199">D2DCustomEffects</span><span class="sxs-lookup"><span data-stu-id="70357-199">D2DCustomEffects</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-200">Direct2D グラデーション メッシュのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-200">Direct2D gradient mesh sample</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?LinkId=620532"><span data-ttu-id="70357-201">D2DGradientMesh</span><span class="sxs-lookup"><span data-stu-id="70357-201">D2DGradientMesh</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-202">Direct2D 写真調整のサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-202">Direct2D photo adjustment sample</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?LinkId=620533"><span data-ttu-id="70357-203">D2DPhotoAdjustment</span><span class="sxs-lookup"><span data-stu-id="70357-203">D2DPhotoAdjustment</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-204">Xbox Advanced Technology Group のパブリック サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-204">Xbox Advanced Technology Group public samples</span></span></td>
        <td><a href="https://github.com/Microsoft/Xbox-ATG-Samples"><span data-ttu-id="70357-205">Xbox-ATG-Samples</span><span class="sxs-lookup"><span data-stu-id="70357-205">Xbox-ATG-Samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-206">Xbox Live のサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-206">Xbox Live samples</span></span></td>
        <td><a href="https://github.com/Microsoft/xbox-live-samples"><span data-ttu-id="70357-207">xbox-live-samples</span><span class="sxs-lookup"><span data-stu-id="70357-207">xbox-live-samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-208">Xbox One ゲームのサンプル (XGD)</span><span class="sxs-lookup"><span data-stu-id="70357-208">Xbox One game samples (XGD)</span></span></td>
        <td><a href="https://developer.microsoft.com/games/xbox/partner/development-education-samples"><span data-ttu-id="70357-209">サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-209">Samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-210">Windows ゲームのサンプル (MSDN コード ギャラリー)</span><span class="sxs-lookup"><span data-stu-id="70357-210">Windows game samples (MSDN Code Gallery)</span></span></td>
        <td><a href="https://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=SearchText&f%5B0%5D.Value=game&f%5B1%5D.Type=Contributors&f%5B1%5D.Value=Microsoft&f%5B1%5D.Text=Microsoft"><span data-ttu-id="70357-211">Microsoft Store ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-211">Microsoft Store game samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-212">JavaScript 2D ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-212">JavaScript 2D game sample</span></span></td>
        <td><a href="../get-started/get-started-tutorial-game-js2d.md"><span data-ttu-id="70357-213">JavaScript で UWP ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-213">Create a UWP game in JavaScript</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-214">JavaScript 3D ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-214">JavaScript 3D game sample</span></span></td>
        <td><a href="../get-started/get-started-tutorial-game-js3d.md"><span data-ttu-id="70357-215">three.js を使用して 3D JavaScript ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-215">Creating a 3D JavaScript game using three.js</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-216">MonoGame 2D UWP ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-216">MonoGame 2D UWP game sample</span></span></td>
        <td><a href="../get-started/get-started-tutorial-game-mg2d.md"><span data-ttu-id="70357-217">MonoGame 2D で UWP ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-217">Create a UWP game in MonoGame 2D</span></span></a></td>
    </tr>      
</table>


### <a name="developer-forums"></a><span data-ttu-id="70357-218">開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-218">Developer forums</span></span>

<span data-ttu-id="70357-219">開発者フォーラムは、ゲームの開発に関する質疑応答を行ったり、ゲーム開発コミュニティで交流を深めたりするのに適した場所です。</span><span class="sxs-lookup"><span data-stu-id="70357-219">Developer forums are a great place to ask and answer game development questions and connect with the game development community.</span></span> <span data-ttu-id="70357-220">フォーラムは、他の開発者が過去に直面し、解決した困難な問題に対する既存の回答を見つけることができる、優れたリソースでもあります。</span><span class="sxs-lookup"><span data-stu-id="70357-220">Forums can also be fantastic resources for finding existing answers to difficult issues that developers have faced and solved in the past.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-221">Windows アプリ開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-221">Windows apps developer forums</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsapps"><span data-ttu-id="70357-222">Windows ストアとアプリ フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-222">Windows store and apps forums</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-223">UWP アプリ開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-223">UWP apps developer forum</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/en-us/home?forum=wpdevelop"><span data-ttu-id="70357-224">ユニバーサル Windows プラットフォーム アプリの開発</span><span class="sxs-lookup"><span data-stu-id="70357-224">Developing Universal Windows Platform apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-225">デスクトップ アプリケーション開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-225">Desktop applications developer forums</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsdesktopdev"><span data-ttu-id="70357-226">Windows デスクトップ アプリケーション フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-226">Windows desktop applications forums</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-227">DirectX Microsoft Store ゲーム (アーカイブ済みのフォーラムの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-227">DirectX Microsoft Store games (archived forum posts)</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/vstudio/home?forum=wingameswithdirectx"><span data-ttu-id="70357-228">DirectX を使った Microsoft Store ゲームの構築 (アーカイブ済み)</span><span class="sxs-lookup"><span data-stu-id="70357-228">Building Microsoft Store games with DirectX (archived)</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-229">Windows 10 対象パートナー開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-229">Windows 10 managed partner developer forums</span></span></td>
        <td><a href="http://aka.ms/win10devforums"><span data-ttu-id="70357-230">XBOX 開発者フォーラム: Windows 10</span><span class="sxs-lookup"><span data-stu-id="70357-230">XBOX Developer Forums: Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-231">DirectX フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-231">DirectX forums</span></span></td>
        <td><a href="http://forums.directxtech.com/index.php"><span data-ttu-id="70357-232">DirectX 12 フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-232">DirectX 12 forum</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-233">Azure プラットフォーム フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-233">Azure platform forums</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsazureplatform"><span data-ttu-id="70357-234">Azure フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-234">Azure forum</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-235">Xbox Live フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-235">Xbox Live forum</span></span></td>
        <td><a href="https://social.msdn.microsoft.com/Forums/en-US/home?forum=xboxlivedev"><span data-ttu-id="70357-236">Xbox Live 開発フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-236">Xbox Live development forum</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-237">PlayFab フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-237">PlayFab forums</span></span></td>
        <td><a href="https://community.playfab.com/index.html"><span data-ttu-id="70357-238">PlayFab フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-238">PlayFab forums</span></span></a></td>
    </tr>
</table>


### <a name="developer-blogs"></a><span data-ttu-id="70357-239">開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="70357-239">Developer blogs</span></span>

<span data-ttu-id="70357-240">開発者ブログは、ゲーム開発に関する最新情報を手に入れることができる、もう 1 つの有用なリソースです。</span><span class="sxs-lookup"><span data-stu-id="70357-240">Developer blogs are another great resource for the latest information about game development.</span></span> <span data-ttu-id="70357-241">新機能、実装の詳細、ベスト プラクティス、アーキテクチャの背景などに関する投稿を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="70357-241">You'll find posts about new features, implementation details, best practices, architecture background, and more.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-242">Windows 用アプリ開発ブログ</span><span class="sxs-lookup"><span data-stu-id="70357-242">Building apps for Windows blog</span></span></td>
        <td><a href="http://blogs.windows.com/buildingapps/"><span data-ttu-id="70357-243">Windows 用アプリ開発</span><span class="sxs-lookup"><span data-stu-id="70357-243">Building Apps for Windows</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-244">Windows 10 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-244">Windows 10 (blog posts)</span></span></td>
        <td><a href="http://blogs.windows.com/blog/tag/windows-10/"><span data-ttu-id="70357-245">Windows 10 に関する投稿</span><span class="sxs-lookup"><span data-stu-id="70357-245">Posts in Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-246">Visual Studio エンジニアリング チームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-246">Visual Studio engineering team blog</span></span></td>
        <td><a href="http://blogs.msdn.com/b/visualstudio/"><span data-ttu-id="70357-247">The Visual Studio Blog</span><span class="sxs-lookup"><span data-stu-id="70357-247">The Visual Studio Blog</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-248">Visual Studio 開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="70357-248">Visual Studio developer tools blogs</span></span></td>
        <td><a href="http://blogs.msdn.com/b/developer-tools/"><span data-ttu-id="70357-249">Developer Tools Blogs</span><span class="sxs-lookup"><span data-stu-id="70357-249">Developer Tools Blogs</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-250">Somasegar の開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="70357-250">Somasegar's developer tools blog</span></span></td>
        <td><a href="http://blogs.msdn.com/b/somasegar/"><span data-ttu-id="70357-251">Somasegar’s blog</span><span class="sxs-lookup"><span data-stu-id="70357-251">Somasegar’s blog</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-252">DirectX 開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="70357-252">DirectX developer blog</span></span></td>
        <td><a href="http://blogs.msdn.com/b/directx"><span data-ttu-id="70357-253">DirectX Developer blog</span><span class="sxs-lookup"><span data-stu-id="70357-253">DirectX Developer blog</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-254">DirectX 12 の概要 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-254">DirectX 12 introduction (blog post)</span></span></td>
        <td><a href="http://blogs.msdn.com/b/directx/archive/2014/03/20/directx-12.aspx"><span data-ttu-id="70357-255">DirectX 12</span><span class="sxs-lookup"><span data-stu-id="70357-255">DirectX 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-256">Visual C++ ツール チームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-256">Visual C++ tools team blog</span></span></td>
        <td><a href="http://blogs.msdn.com/b/vcblog/"><span data-ttu-id="70357-257">Visual C++ チームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-257">Visual C++ team blog</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-258">PIX チームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-258">PIX team blog</span></span></td>
        <td><a href="https://blogs.msdn.microsoft.com/pix/"><span data-ttu-id="70357-259">Windows および Xbox での DirectX 12 ゲームのパフォーマンスのチューニングとデバッグ</span><span class="sxs-lookup"><span data-stu-id="70357-259">Performance tuning and debugging for DirectX 12 games on Windows and Xbox</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-260">ユニバーサル Windows アプリの展開チームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-260">Universal Windows App Deployment team blog</span></span></td>
        <td><a href="https://blogs.msdn.microsoft.com/appinstaller/"><span data-ttu-id="70357-261">UWP アプリのビルドと展開のチームのブログ</span><span class="sxs-lookup"><span data-stu-id="70357-261">Build and deploy UWP apps team blog</span></span></a></td>
    </tr>
</table>
 

## <a name="concept-and-planning"></a><span data-ttu-id="70357-262">概念と計画</span><span class="sxs-lookup"><span data-stu-id="70357-262">Concept and planning</span></span>


<span data-ttu-id="70357-263">概念と計画の段階では、ゲームの全体像とそれを実現するために使用するテクノロジやツールを決定します。</span><span class="sxs-lookup"><span data-stu-id="70357-263">In the concept and planning stage, you're deciding what your game is going to be like and the technologies and tools you'll use to bring it to life.</span></span>

### <a name="overview-of-game-development-technologies"></a><span data-ttu-id="70357-264">ゲーム開発テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="70357-264">Overview of game development technologies</span></span>

<span data-ttu-id="70357-265">UWP のゲームの開発を開始するとき、グラフィックス、入力、オーディオ、ネットワーク、ユーティリティ、ライブラリについて、利用可能なオプションは複数あります。</span><span class="sxs-lookup"><span data-stu-id="70357-265">When you start developing a game for the UWP you have multiple options available for graphics, input, audio, networking, utilities, and libraries.</span></span>

<span data-ttu-id="70357-266">ゲームで使うすべてのテクノロジが既に決定している場合は問題ありません。</span><span class="sxs-lookup"><span data-stu-id="70357-266">If you've already decided on all the technologies you'll be using in your game, great!</span></span> <span data-ttu-id="70357-267">まだ決まっていない場合、[UWP アプリのゲーム テクノロジ](game-development-platform-guide.md) ガイドに利用可能な多くのテクノロジの概要がまとめられています。このガイドに目を通して、さまざまなオプションとそれらを組み合わせる方法を理解しておくことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="70357-267">If not, the [Game technologies for UWP apps](game-development-platform-guide.md) guide is an excellent overview of many of the technologies available, and is highly recommended reading to help you understand the options and how they fit together.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-268">UWP のゲーム テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="70357-268">Survey of UWP game technologies</span></span></td>
        <td><a href="game-development-platform-guide.md"><span data-ttu-id="70357-269">UWP アプリのゲーム テクノロジ</span><span class="sxs-lookup"><span data-stu-id="70357-269">Game technologies for UWP apps</span></span></a></td>
    </tr>
</table>
 

<span data-ttu-id="70357-270">次の 3 つの GDC 2015 のビデオは、Windows 10 のゲーム開発と Windows 10 のゲーム エクスペリエンスの概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="70357-270">These three GDC 2015 videos give a good overview of Windows 10 game development and the Windows 10 gaming experience.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-271">Windows 10 のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-271">Overview of Windows 10 game development (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-Games-for-Windows-10"><span data-ttu-id="70357-272">Windows 10 のゲームの開発</span><span class="sxs-lookup"><span data-stu-id="70357-272">Developing Games for Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-273">Windows 10 のゲーム エクスペリエンス (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-273">Windows 10 gaming experience (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Gaming-Consumer-Experience-on-Windows-10"><span data-ttu-id="70357-274">Windows 10 でのゲームのユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="70357-274">Gaming Consumer Experience on Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-275">Microsoft エコシステム全体でのゲーム (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-275">Gaming across the Microsoft ecosystem (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/The-Future-of-Gaming-Across-the-Microsoft-Ecosystem"><span data-ttu-id="70357-276">Microsoft エコシステム全体でのゲームの未来</span><span class="sxs-lookup"><span data-stu-id="70357-276">The Future of Gaming Across the Microsoft Ecosystem</span></span></a></td>
    </tr>
</table>

### <a name="game-planning"></a><span data-ttu-id="70357-277">ゲームの計画</span><span class="sxs-lookup"><span data-stu-id="70357-277">Game planning</span></span>

<span data-ttu-id="70357-278">これらは、いくつかの高レベルの概念と、ゲームを計画するときに考慮する計画のトピックです。</span><span class="sxs-lookup"><span data-stu-id="70357-278">These are some high level concept and planning topics to consider when planning for your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-279">ゲームをアクセシビリティ対応にする</span><span class="sxs-lookup"><span data-stu-id="70357-279">Make your game accessible</span></span></td>
        <td><a href="https://msdn.microsoft.com/windows/uwp/gaming/accessibility-for-games"><span data-ttu-id="70357-280">ゲームのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="70357-280">Accessibility for games</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-281">クラウドを使用したゲームの作成</span><span class="sxs-lookup"><span data-stu-id="70357-281">Build games using cloud</span></span></td>
        <td><a href="https://msdn.microsoft.com/windows/uwp/gaming/cloud-for-games"><span data-ttu-id="70357-282">ゲーム用のクラウド</span><span class="sxs-lookup"><span data-stu-id="70357-282">Cloud for games</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-283">ゲームの収益化</span><span class="sxs-lookup"><span data-stu-id="70357-283">Monetize your game</span></span></td>
        <td><a href="https://msdn.microsoft.com/windows/uwp/gaming/monetization-for-games"><span data-ttu-id="70357-284">ゲームの収益化</span><span class="sxs-lookup"><span data-stu-id="70357-284">Monetization for games</span></span></a></td>
    </tr>
</table>



### <a name="choosing-your-graphics-technology-and-programming-language"></a><span data-ttu-id="70357-285">グラフィックス テクノロジとプログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="70357-285">Choosing your graphics technology and programming language</span></span>

<span data-ttu-id="70357-286">Windows 10 ゲームでは、複数のプログラミング言語やグラフィックス テクノロジを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-286">There are several programming languages and graphics technologies available for use in Windows 10 games.</span></span> <span data-ttu-id="70357-287">どれを選ぶかは、開発しているゲームの種類、開発スタジオの経験や好み、ゲームの具体的な機能要件によって決まります。</span><span class="sxs-lookup"><span data-stu-id="70357-287">The path you take depends on the type of game you’re developing, the experience and preferences of your development studio, and specific feature requirements of your game.</span></span> <span data-ttu-id="70357-288">C#、C++、JavaScript のどれを使うか、</span><span class="sxs-lookup"><span data-stu-id="70357-288">Will you use C#, C++, or JavaScript?</span></span> <span data-ttu-id="70357-289">DirectX、XAML、HTML5 のどれを使うかなどです。</span><span class="sxs-lookup"><span data-stu-id="70357-289">DirectX, XAML, or HTML5?</span></span>

#### <a name="directx"></a><span data-ttu-id="70357-290">DirectX</span><span class="sxs-lookup"><span data-stu-id="70357-290">DirectX</span></span>

<span data-ttu-id="70357-291">Microsoft DirectX を使うと、最高のパフォーマンスの 2D および 3D グラフィックスとマルチメディアを生み出すことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-291">Microsoft DirectX is the choice to make for the highest-performance 2D and 3D graphics and multimedia.</span></span>

<span data-ttu-id="70357-292">DirectX 12 は、以前のバージョンよりも高速かつ効率的になっています。</span><span class="sxs-lookup"><span data-stu-id="70357-292">DirectX 12 is faster and more efficient than any previous version.</span></span> <span data-ttu-id="70357-293">Direct3D 12 は、より豊かなシーン、より多くのオブジェクト、より複雑な効果を実現し、Windows 10 PC や Xbox One の最新の GPU ハードウェアを十分に活用できます。</span><span class="sxs-lookup"><span data-stu-id="70357-293">Direct3D 12 enables richer scenes, more objects, more complex effects, and full utilization of modern GPU hardware on Windows 10 PCs and Xbox One.</span></span>

<span data-ttu-id="70357-294">Direct3D 11 の使い慣れたグラフィックス パイプラインを使う場合でも、Direct3D 11.3 に追加された新しいレンダリングおよび最適化機能を活かすことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-294">If you want to use the familiar graphics pipeline of Direct3D 11, you’ll still benefit from the new rendering and optimization features added to Direct3D 11.3.</span></span> <span data-ttu-id="70357-295">さらに、Win32 をルーツとする実証済みのデスクトップ Windows API の開発者は、Windows 10 でもそのオプションを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-295">And, if you’re a tried-and-true desktop Windows API developer with roots in Win32, you’ll still have that option in Windows 10.</span></span>

<span data-ttu-id="70357-296">DirectX のさまざまな機能と緊密なプラットフォーム統合により、要求の多いほとんどのゲームに必要とされる性能とパフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="70357-296">The extensive features and deep platform integration of DirectX provide the power and performance needed by the most demanding games.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-297">UWP 用の DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="70357-297">DirectX for UWP development</span></span></td>
        <td><a href="directx-programming.md"><span data-ttu-id="70357-298">DirectX プログラミング</span><span class="sxs-lookup"><span data-stu-id="70357-298">DirectX programming</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-299">チュートリアル: UWP DirectX ゲームを作成する方法</span><span class="sxs-lookup"><span data-stu-id="70357-299">Tutorial: How to create a UWP DirectX game</span></span></td>
        <td><a href="tutorial--create-your-first-uwp-directx-game.md"><span data-ttu-id="70357-300">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="70357-300">Create a simple UWP game with DirectX</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-301">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-301">DirectX overviews and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274"><span data-ttu-id="70357-302">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="70357-302">DirectX Graphics and Gaming</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-303">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-303">Direct3D 12 programming guide and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821"><span data-ttu-id="70357-304">Direct3D 12 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="70357-304">Direct3D 12 Graphics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-305">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="70357-305">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA"><span data-ttu-id="70357-306">Microsoft DirectX 12 とグラフィックスに関する教育</span><span class="sxs-lookup"><span data-stu-id="70357-306">Microsoft DirectX 12 and Graphics Education</span></span></a></td>
    </tr>
</table>
 

#### <a name="xaml"></a><span data-ttu-id="70357-307">XAML</span><span class="sxs-lookup"><span data-stu-id="70357-307">XAML</span></span>

<span data-ttu-id="70357-308">XAML は、アニメーション、ストーリーボード、データ バインディング、拡張性の高いベクター ベース グラフィックス、動的なサイズ変更、シーン グラフなどの便利な機能を備える、使いやすい宣言型 UI 言語です。</span><span class="sxs-lookup"><span data-stu-id="70357-308">XAML is an easy-to-use declarative UI language with convenient features like animations, storyboards, data binding, scalable vector-based graphics, dynamic resizing, and scene graphs.</span></span> <span data-ttu-id="70357-309">また、XAML はゲーム UI、メニュー、スプライト、2D グラフィックスに最適です。</span><span class="sxs-lookup"><span data-stu-id="70357-309">XAML works great for game UI, menus, sprites, and 2D graphics.</span></span> <span data-ttu-id="70357-310">UI レイアウトを簡単にするため、XAML には、Expression Blend や Microsoft Visual Studio などの設計および開発ツールとの互換性があります。</span><span class="sxs-lookup"><span data-stu-id="70357-310">To make UI layout easy, XAML is compatible with design and development tools like Expression Blend and Microsoft Visual Studio.</span></span> <span data-ttu-id="70357-311">XAML はよく C# と同時に使用されますが、希望する言語が C++ の場合や、ゲームが多くの CPU を必要とする場合は、C++ も適しています。</span><span class="sxs-lookup"><span data-stu-id="70357-311">XAML is commonly used with C#, but C++ is also a good choice if that’s your preferred language or if your game has high CPU demands.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-312">XAML プラットフォームの概要</span><span class="sxs-lookup"><span data-stu-id="70357-312">XAML platform overview</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt228259"><span data-ttu-id="70357-313">XAML プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="70357-313">XAML platform</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-314">XAML UI とコントロール</span><span class="sxs-lookup"><span data-stu-id="70357-314">XAML UI and controls</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt228348"><span data-ttu-id="70357-315">コントロール、レイアウト、テキスト</span><span class="sxs-lookup"><span data-stu-id="70357-315">Controls, layouts, and text</span></span></a></td>
    </tr>
</table>
 

#### <a name="html-5"></a><span data-ttu-id="70357-316">HTML 5</span><span class="sxs-lookup"><span data-stu-id="70357-316">HTML 5</span></span>

<span data-ttu-id="70357-317">ハイパーテキスト マークアップ言語 (HTML) は、Web ページ、アプリ、リッチ クライアントに使用される一般的な UI マークアップ言語です。</span><span class="sxs-lookup"><span data-stu-id="70357-317">HyperText Markup Language (HTML) is a common UI markup language used for web pages, apps, and rich clients.</span></span> <span data-ttu-id="70357-318">Windows ゲームでは、HTML の使い慣れた機能、ユニバーサル Windows プラットフォーム、AppCache、Web ワーカー、キャンバス、ドラッグ アンド ドロップ、非同期プログラミング、SVG などの最新の Web 機能のサポートを備えた、全機能装備のプレゼンテーション層として HTML5 を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-318">Windows games can use HTML5 as a full-featured presentation layer with the familiar features of HTML, access to the Universal Windows Platform, and support for modern web features like AppCache, Web Workers, canvas, drag-and-drop, asynchronous programming, and SVG.</span></span> <span data-ttu-id="70357-319">HTML レンダリングの内部では、DirectX ハードウェア アクセラレータの機能が活用されるため、追加のコードを記述しなくても DirectX のパフォーマンスの恩恵を受けることができます。</span><span class="sxs-lookup"><span data-stu-id="70357-319">Behind the scenes, HTML rendering takes advantage of the power of DirectX hardware acceleration, so you can still get the performance benefits of DirectX without writing any extra code.</span></span> <span data-ttu-id="70357-320">Web 開発に熟練している場合、Web ゲームを移植する場合、または他の選択肢よりアプローチしやすい言語およびグラフィックス層を使う場合は、HTML5 が最適です。</span><span class="sxs-lookup"><span data-stu-id="70357-320">HTML5 is a good choice if you are proficient with web development, porting a web game, or want to use language and graphics layers that can be easier to approach than the other choices.</span></span> <span data-ttu-id="70357-321">HTML5 は JavaScript と同時に使用されますが、C# や C++/CX で作成されたコンポーネントを呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="70357-321">HTML5 is used with JavaScript, but can also call into components created with C# or C++/CX.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-322">HTML5 とドキュメント オブジェクト モデルに関する情報</span><span class="sxs-lookup"><span data-stu-id="70357-322">HTML5 and Document Object Model information</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/br212882.aspx"><span data-ttu-id="70357-323">HTML と DOM のリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-323">HTML and DOM reference</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-324">HTML5 W3C 勧告</span><span class="sxs-lookup"><span data-stu-id="70357-324">The HTML5 W3C Recommendation</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?linkid=221374"><span data-ttu-id="70357-325">HTML5</span><span class="sxs-lookup"><span data-stu-id="70357-325">HTML5</span></span></a></td>
    </tr>
</table>
 

#### <a name="combining-presentation-technologies"></a><span data-ttu-id="70357-326">プレゼンテーション テクノロジの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="70357-326">Combining presentation technologies</span></span>

<span data-ttu-id="70357-327">Microsoft DirectX Graphic Infrastructure (DXGI) には、複数のグラフィックス テクノロジにおける相互運用性と互換性が備わっています。</span><span class="sxs-lookup"><span data-stu-id="70357-327">The Microsoft DirectX Graphics Infrastructure (DXGI) provides interop and compatibility across multiple graphics technologies.</span></span> <span data-ttu-id="70357-328">高パフォーマンスのグラフィックスを実現するため、メニューや他のシンプルな UI には XAML を使い、複雑な 2D および 3D シーンのレンダリングには DirectX を使うことで、XAML と DirectX を組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="70357-328">For high-performance graphics, you can combine XAML and DirectX, using XAML for menus and other simple UI, and DirectX for rendering complex 2D and 3D scenes.</span></span> <span data-ttu-id="70357-329">DXGI には、Direct2D、Direct3D、DirectWrite、DirectCompute、Microsoft メディア ファンデーション間の互換性も備わっています。</span><span class="sxs-lookup"><span data-stu-id="70357-329">DXGI also provides compatibility between Direct2D, Direct3D, DirectWrite, DirectCompute, and the Microsoft Media Foundation.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-330">DirectX Graphics Infrastructure のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-330">DirectX Graphics Infrastructure programming guide and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/hh404534"><span data-ttu-id="70357-331">DXGI</span><span class="sxs-lookup"><span data-stu-id="70357-331">DXGI</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-332">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="70357-332">Combining DirectX and XAML</span></span></td>
        <td><a href="directx-and-xaml-interop.md"><span data-ttu-id="70357-333">DirectX と XAML の相互運用機能</span><span class="sxs-lookup"><span data-stu-id="70357-333">DirectX and XAML interop</span></span></a></td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="70357-334">C++</span><span class="sxs-lookup"><span data-stu-id="70357-334">C++</span></span>

<span data-ttu-id="70357-335">C++/CX はオーバーヘッドの低い高パフォーマンスな言語であり、速度、互換性、プラットフォーム アクセスがうまく組み合わせられています。</span><span class="sxs-lookup"><span data-stu-id="70357-335">C++/CX is a high-performance, low overhead language that provides the powerful combination of speed, compatibility, and platform access.</span></span> <span data-ttu-id="70357-336">C++/CX により、DirectX や Xbox Live など、Windows 10 のすばらしいゲーム機能すべてが使いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="70357-336">C++/CX makes it easy to use all of the great gaming features in Windows 10, including DirectX and Xbox Live.</span></span> <span data-ttu-id="70357-337">既にある C++ コードとライブラリを再利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="70357-337">You can also reuse existing C++ code and libraries.</span></span> <span data-ttu-id="70357-338">C++/CX を使うと、ガベージ コレクションのオーバーヘッドを生じさせない高速なネイティブ コードが作成されるため、ゲームのパフォーマンスが向上し、電力消費が低くなり、結果としてバッテリ寿命が延びます。</span><span class="sxs-lookup"><span data-stu-id="70357-338">C++/CX creates fast, native code that doesn’t incur the overhead of garbage collection, so your game can have great performance and low power consumption, which leads to longer battery life.</span></span> <span data-ttu-id="70357-339">C++/CX を DirectX または XAML と同時に使うか、両方の組み合わせを使って、ゲームを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-339">Use C++/CX with DirectX or XAML, or create a game that uses a combination of both.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-340">C++/CX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="70357-340">C++/CX reference and overviews</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/hh699871.aspx"><span data-ttu-id="70357-341">Visual C++ 言語のリファレンス (C++/CX)</span><span class="sxs-lookup"><span data-stu-id="70357-341">Visual C++ Language Reference (C++/CX)</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-342">Visual C++ のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-342">Visual C++ programming guide and reference</span></span></td>
        <td><a href="https://docs.microsoft.com/cpp/visual-cpp-in-visual-studio"><span data-ttu-id="70357-343">Visual Studio 2017 の Visual C++</span><span class="sxs-lookup"><span data-stu-id="70357-343">Visual C++ in Visual Studio 2017</span></span></a></td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="70357-344">C#</span><span class="sxs-lookup"><span data-stu-id="70357-344">C#</span></span>

<span data-ttu-id="70357-345">C# ("シー シャープ" と発音) は、タイプ セーフかつオブジェクト指向のシンプルで強力な最新の革新的言語です。</span><span class="sxs-lookup"><span data-stu-id="70357-345">C# (pronounced "C sharp") is a modern, innovative language that is simple, powerful, type-safe, and object-oriented.</span></span> <span data-ttu-id="70357-346">C# を使うと、C スタイル言語の親しみやすさと表現力を維持しながら短期間で開発できます。</span><span class="sxs-lookup"><span data-stu-id="70357-346">C# enables rapid development while retaining the familiarity and expressiveness of C-style languages.</span></span> <span data-ttu-id="70357-347">C# は使いやすい言語ですが、ポリモーフィズム、デリゲート、ラムダ、クロージャ、反復子メソッド、共変性、統合言語クエリ (LINQ) 式など、多くの高度な言語機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="70357-347">Though easy to use, C# has numerous advanced language features like polymorphism, delegates, lambdas, closures, iterator methods, covariance, and Language-Integrated Query (LINQ) expressions.</span></span> <span data-ttu-id="70357-348">XAML をターゲットとする場合、ゲームの開発をすぐに始めたい場合、C# を既に使ったことがある場合、C# が最適です。</span><span class="sxs-lookup"><span data-stu-id="70357-348">C# is an excellent choice if you are targeting XAML, want to get a quick start developing your game, or have previous C# experience.</span></span> <span data-ttu-id="70357-349">C# は主に XAML と同時に使われるめ、DirectX を使う場合は、代わりに C++ を選ぶか、ゲームの一部を DirectX とやり取りする C++ コンポーネントとして記述します。</span><span class="sxs-lookup"><span data-stu-id="70357-349">C# is used primarily with XAML, so if you want to use DirectX, choose C++ instead, or write part of your game as a C++ component that interacts with DirectX.</span></span> <span data-ttu-id="70357-350">または、C# と C++ 用の即時モード Direct2D グラフィックス ライブラリである [Win2D](https://github.com/Microsoft/Win2D) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="70357-350">Or, consider [Win2D](https://github.com/Microsoft/Win2D), an immediate mode Direct2D graphics libary for C# and C++.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-351">C# のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-351">C# programming guide and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/kx37x362.aspx"><span data-ttu-id="70357-352">C# 言語のリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-352">C# language reference</span></span></a></td>
    </tr>
</table>
 

#### <a name="javascript"></a><span data-ttu-id="70357-353">JavaScript</span><span class="sxs-lookup"><span data-stu-id="70357-353">JavaScript</span></span>

<span data-ttu-id="70357-354">JavaScript は、最新の Web アプリケーションやリッチ クライアント アプリケーションに広く使用されている動的なスクリプト言語です。</span><span class="sxs-lookup"><span data-stu-id="70357-354">JavaScript is a dynamic scripting language widely used for modern web and rich client applications.</span></span>

<span data-ttu-id="70357-355">Windows JavaScript アプリは、ユニバーサル Windows プラットフォームの強力な機能に簡単かつ直感的な方法でアクセスできます (オブジェクト指向 JavaScript クラスのメソッドとプロパティとして)。</span><span class="sxs-lookup"><span data-stu-id="70357-355">Windows JavaScript apps can access the powerful features of the Universal Windows Platform in an easy, intuitive way—as methods and properties of object-oriented JavaScript classes.</span></span> <span data-ttu-id="70357-356">JavaScript は、Web 開発環境を使っていた場合、JavaScript に既に慣れている場合、HTML5、CSS、WinJS、または JavaScript ライブラリを使用する場合のゲーム開発に最適です。</span><span class="sxs-lookup"><span data-stu-id="70357-356">JavaScript is a good choice for your game if you’re coming from a web development environment, are already familiar with JavaScript, or want to use HTML5, CSS, WinJS, or JavaScript libraries.</span></span> <span data-ttu-id="70357-357">DirectX や XAML をターゲットとする場合は、代わりに C# または C++/CX を選択してください。</span><span class="sxs-lookup"><span data-stu-id="70357-357">If you’re targeting DirectX or XAML, choose C# or C++/CX instead.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-358">JavaScript と Windows ランタイムのリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-358">JavaScript and Windows Runtime reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/jj613794"><span data-ttu-id="70357-359">JavaScript のリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-359">JavaScript reference</span></span></a></td>
    </tr>
</table>


#### <a name="use-windows-runtime-components-to-combine-languages"></a><span data-ttu-id="70357-360">Windows ランタイム コンポーネントを使って言語を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="70357-360">Use Windows Runtime Components to combine languages</span></span>

<span data-ttu-id="70357-361">ユニバーサル Windows プラットフォームでは、異なる言語で記述されたコンポーネントを簡単に組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="70357-361">With the Universal Windows Platform, it’s easy to combine components written in different languages.</span></span> <span data-ttu-id="70357-362">C++、C#、Visual Basic で Windows ランタイム コンポーネントを作成した後、JavaScript、C#、C++、Visual Basic から呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-362">Create Windows Runtime Components in C++, C#, or Visual Basic, and then call into them from JavaScript, C#, C++, or Visual Basic.</span></span> <span data-ttu-id="70357-363">これは、好みの言語でゲームの一部をプログラミングする場合に最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="70357-363">This is a great way to program portions of your game in the language of your choice.</span></span> <span data-ttu-id="70357-364">コンポーネントにより、特定の言語でのみ使用可能な外部ライブラリや、既に記述しているレガシ コードを使うこともできるようになります。</span><span class="sxs-lookup"><span data-stu-id="70357-364">Components also let you consume external libraries that are only available in a particular language, as well as use legacy code you’ve already written.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-365">Windows ランタイム コンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="70357-365">How to create Windows Runtime Components</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/winrt-components/creating-windows-runtime-components-in-cpp"><span data-ttu-id="70357-366">Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="70357-366">Creating Windows Runtime Components</span></span></a></td>
    </tr>
</table>


### <a name="which-version-of-directx-should-your-game-use"></a><span data-ttu-id="70357-367">ゲームで使う Microsoft DirectX のバージョン</span><span class="sxs-lookup"><span data-stu-id="70357-367">Which version of DirectX should your game use?</span></span>

<span data-ttu-id="70357-368">ゲームで DirectX を使うことを選んだ場合、使うバージョン (Microsoft Direct3D 12 または Microsoft Direct3D 11) を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="70357-368">If you are choosing DirectX for your game, you'll need to decide which version to use: Microsoft Direct3D 12 or Microsoft Direct3D 11.</span></span>

<span data-ttu-id="70357-369">DirectX 12 は、以前のバージョンよりも高速かつ効率的になっています。</span><span class="sxs-lookup"><span data-stu-id="70357-369">DirectX 12 is faster and more efficient than any previous version.</span></span> <span data-ttu-id="70357-370">Direct3D 12 は、より豊かなシーン、より多くのオブジェクト、より複雑な効果を実現し、Windows 10 PC や Xbox One の最新の GPU ハードウェアを十分に活用できます。</span><span class="sxs-lookup"><span data-stu-id="70357-370">Direct3D 12 enables richer scenes, more objects, more complex effects, and full utilization of modern GPU hardware on Windows 10 PCs and Xbox One.</span></span> <span data-ttu-id="70357-371">Direct3D 12 は非常に低いレベルで動作するため、専門的なグラフィックス開発チームや経験豊富な DirectX 11 開発チームは、グラフィックスの最適化を十分に活かすために必要となるすべてのコントロールを利用することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-371">Since Direct3D 12 works at a very low level, it is able to give an expert graphics development team or an experienced DirectX 11 development team all the control they need to maximize graphics optimization.</span></span>

<span data-ttu-id="70357-372">Direct3D 11.3 は低レベル グラフィック API です。よく利用される Direct3D プログラミング モデルが使われており、GPU レンダリングに関連する多くの複雑な処理を扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-372">Direct3D 11.3 is a low level graphics API that uses the familiar Direct3D programming model and handles for you more of the complexity involved in GPU rendering.</span></span> <span data-ttu-id="70357-373">また、Windows 10 と Xbox One でもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="70357-373">It is also supported in Windows 10 and Xbox One.</span></span> <span data-ttu-id="70357-374">Direct3D 11 で作成されたエンジンを既にお持ちで、Direct3D 12 への切り替えの準備がまだ整っていない場合は、Direct3D 11 on 12 を使うことによって、ある程度のパフォーマンスの向上を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-374">If you have an existing engine written in Direct3D 11, and you're not quite ready to make the jump to Direct3D 12, you can use Direct3D 11 on 12 to achieve some performance improvements.</span></span> <span data-ttu-id="70357-375">バージョン 11.3 以降には、Direct3D 12 でも利用可能な新しいレンダリングと最適化の機能が含まれています。</span><span class="sxs-lookup"><span data-stu-id="70357-375">Versions 11.3+ contain the new rendering and optimization features enabled also in Direct3D 12.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-376">Direct3D 12 または Direct3D 11 の選択</span><span class="sxs-lookup"><span data-stu-id="70357-376">Choosing Direct3D 12 or Direct3D 11</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn899228"><span data-ttu-id="70357-377">Direct3D 12 の概要</span><span class="sxs-lookup"><span data-stu-id="70357-377">What is Direct3D 12?</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-378">Direct3D 11 の概要</span><span class="sxs-lookup"><span data-stu-id="70357-378">Overview of Direct3D 11</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080"><span data-ttu-id="70357-379">Direct3D 11 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="70357-379">Direct3D 11 Graphics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-380">Direct3D 11 on 12 の概要</span><span class="sxs-lookup"><span data-stu-id="70357-380">Overview of Direct3D 11 on 12</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn913195"><span data-ttu-id="70357-381">Direct3D 11 on 12</span><span class="sxs-lookup"><span data-stu-id="70357-381">Direct3D 11 on 12</span></span></a></td>
    </tr>
</table>


### <a name="bridges-game-engines-and-middleware"></a><span data-ttu-id="70357-382">ブリッジ、ゲーム エンジン、ミドルウェア</span><span class="sxs-lookup"><span data-stu-id="70357-382">Bridges, game engines, and middleware</span></span>

<span data-ttu-id="70357-383">ゲームのニーズに応じて、ブリッジ、ゲーム エンジン、ミドルウェアを使うことにより、開発やテストに費やす時間やリソースを節約できます。</span><span class="sxs-lookup"><span data-stu-id="70357-383">Depending on the needs of your game, using bridges, game engines, or middleware can save development and testing time and resources.</span></span> <span data-ttu-id="70357-384">ここでは、ブリッジ、ゲーム エンジン、ミドルウェアの概要とリソースを示します。</span><span class="sxs-lookup"><span data-stu-id="70357-384">Here are some overview and resources for bridges, game engines, and middleware.</span></span>

#### <a name="universal-windows-platform-bridges"></a><span data-ttu-id="70357-385">ユニバーサル Windows プラットフォーム ブリッジ</span><span class="sxs-lookup"><span data-stu-id="70357-385">Universal Windows Platform Bridges</span></span>

<span data-ttu-id="70357-386">ユニバーサル Windows プラットフォーム ブリッジは、既にあるアプリやゲームを UWP に移植するためのテクノロジです。</span><span class="sxs-lookup"><span data-stu-id="70357-386">Universal Windows Platform Bridges are technologies that bring your existing app or game over to the UWP.</span></span> <span data-ttu-id="70357-387">ブリッジは、すぐに UWP のゲーム開発の始めるときに最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="70357-387">Bridges are a great way to get a quick start on UWP game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-388">UWP ブリッジ</span><span class="sxs-lookup"><span data-stu-id="70357-388">UWP bridges</span></span></td>
        <td><a href="https://dev.windows.com/bridges/"><span data-ttu-id="70357-389">Windows にコードを移植する</span><span class="sxs-lookup"><span data-stu-id="70357-389">Bring your code to Windows</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-390">iOS 用 Windows ブリッジ</span><span class="sxs-lookup"><span data-stu-id="70357-390">Windows Bridge for iOS</span></span></td>
        <td><a href="https://dev.windows.com/bridges/ios"><span data-ttu-id="70357-391">iOS アプリを Windows に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-391">Bring your iOS apps to Windows</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-392">デスクトップ アプリケーション用 Windows ブリッジ (.NET および Win32)</span><span class="sxs-lookup"><span data-stu-id="70357-392">Windows Bridge for desktop applications (.NET and Win32)</span></span></td>
        <td><a href="https://developer.microsoft.com/windows/bridges/desktop"><span data-ttu-id="70357-393">デスクトップ アプリケーションを UWP アプリに変換する</span><span class="sxs-lookup"><span data-stu-id="70357-393">Convert your desktop application to a UWP app</span></span></a></td>
    </tr>
</table>

#### <a name="playfab"></a><span data-ttu-id="70357-394">PlayFab</span><span class="sxs-lookup"><span data-stu-id="70357-394">PlayFab</span></span>

<span data-ttu-id="70357-395">Microsoft ファミリの一部となった PlayFab は、ライブ ゲームの完全なバックエンド プラットフォームであり、独立系のスタジオが開発を開始するための強力な手段です。</span><span class="sxs-lookup"><span data-stu-id="70357-395">Now part of the Microsoft family, PlayFab is a complete back-end platform for live games and a powerful way for independent studios to get started.</span></span> <span data-ttu-id="70357-396">ゲーム サービス、リアルタイム分析、LiveOps によって、コストを削減しながら、収益性、エンゲージメント、リテンションを向上させます。</span><span class="sxs-lookup"><span data-stu-id="70357-396">Boost revenue, engagement, and retention—while cutting costs—with game services, real-time analytics, and LiveOps.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-397">PlayFab</span><span class="sxs-lookup"><span data-stu-id="70357-397">PlayFab</span></span></td>
        <td><a href="https://playfab.com/"><span data-ttu-id="70357-398">ツールとサービスの概要</span><span class="sxs-lookup"><span data-stu-id="70357-398">Overview of tools and services</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-399">概要</span><span class="sxs-lookup"><span data-stu-id="70357-399">Getting started</span></span></td>
        <td><a href="https://api.playfab.com/docs/general-getting-started"><span data-ttu-id="70357-400">一般的なファースト ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-400">General getting started guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-401">ビデオ チュートリアル シリーズ</span><span class="sxs-lookup"><span data-stu-id="70357-401">Video tutorial series</span></span></td>
        <td><a href="https://www.youtube.com/watch?v=fGNpiqVi5xU&list=PLHCfyL7JpoPbLpA_oh_T5PKrfzPgCpPT5"><span data-ttu-id="70357-402">PlayFab のコア システムに関する一連のデモ ビデオ</span><span class="sxs-lookup"><span data-stu-id="70357-402">Series of demo videos about PlayFab's core systems</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-403">レシピ</span><span class="sxs-lookup"><span data-stu-id="70357-403">Recipes</span></span></td>
        <td><a href="https://api.playfab.com/docs/tutorials/recipes-index"><span data-ttu-id="70357-404">人気のあるゲームのしくみと設計パターンのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-404">Popular game mechanics and design pattern samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-405">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="70357-405">Platforms</span></span></td>
        <td><a href="https://api.playfab.com/platforms"><span data-ttu-id="70357-406">さまざまなプラットフォームやゲーム エンジンに固有のドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-406">Specific documentation for various platforms and game engines</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-407">GitHub リポジトリ</span><span class="sxs-lookup"><span data-stu-id="70357-407">GitHub repo</span></span></td>
        <td><a href="https://github.com/PlayFab"><span data-ttu-id="70357-408">Android、iOS、Windows、Unity、Unreal など、さまざまなプラットフォーム向けのスクリプトと SDK を入手できます。</span><span class="sxs-lookup"><span data-stu-id="70357-408">Get scripts and SDKs for various platforms including Android, iOS, Windows, Unity, and Unreal.</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-409">API ドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-409">API documentation</span></span></td>
        <td><a href="https://api.playfab.com/documentation/"><span data-ttu-id="70357-410">REST に似た Web API 経由で直接 PlayFab サービスにアクセス</span><span class="sxs-lookup"><span data-stu-id="70357-410">Access PlayFab service directly via REST-like Web APIs</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-411">フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-411">Forums</span></span></td>
        <td><a href="https://community.playfab.com/index.html"><span data-ttu-id="70357-412">PlayFab フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-412">PlayFab forums</span></span></a></td>
    </tr>
</table>
 

#### <a name="unity"></a><span data-ttu-id="70357-413">Unity</span><span class="sxs-lookup"><span data-stu-id="70357-413">Unity</span></span>

<span data-ttu-id="70357-414">Unity は、美しく魅力的な 2D、3D、VR、AR ゲームやアプリを作成するためのプラットフォームを提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-414">Unity offers a platform for creating beautiful and engaging 2D, 3D, VR, and AR games and apps.</span></span> <span data-ttu-id="70357-415">クリエイティブな構想をすばやく実現することができ、事実上、あらゆるメディアやデバイスにコンテンツを提供できます。</span><span class="sxs-lookup"><span data-stu-id="70357-415">It enables you to realize your creative vision fast and delivers your content to virtually any media or device.</span></span>

<span data-ttu-id="70357-416">Unity 5.4 以降では、Unity は Direct3D 12 の開発をサポートします。</span><span class="sxs-lookup"><span data-stu-id="70357-416">Beginning with Unity 5.4, Unity supports Direct3D 12 development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-417">Unity ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="70357-417">The Unity game engine</span></span></td>
        <td><a href="http://unity3d.com/"><span data-ttu-id="70357-418">Unity - ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="70357-418">Unity - Game Engine</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-419">Unity を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-419">Get Unity</span></span></td>
        <td><a href="http://unity3d.com/get-unity"><span data-ttu-id="70357-420">Unity を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-420">Get Unity</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-421">Windows 向けの Unity に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-421">Unity documentation for Windows</span></span></td>
        <td><a href="http://docs.unity3d.com/Manual/Windows.html"><span data-ttu-id="70357-422">Unity マニュアル / Windows</span><span class="sxs-lookup"><span data-stu-id="70357-422">Unity Manual / Windows</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-423">PlayFab を使用して LiveOps を追加する</span><span class="sxs-lookup"><span data-stu-id="70357-423">Add LiveOps using PlayFab</span></span></td>
        <td><a href="https://api.playfab.com/docs/getting-started/unity-getting-started"><span data-ttu-id="70357-424">概要 - Unity ゲームからの最初の PlayFab API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="70357-424">Getting started - Make your first PlayFab API call from your Unity game</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-425">Mixer の対話機能を使用して、ゲームに対話機能を追加する方法</span><span class="sxs-lookup"><span data-stu-id="70357-425">How to add interactivity to your game using Mixer Interactive</span></span></td>
        <td><a href="https://github.com/mixer/interactive-unity-plugin/wiki/Getting-started"><span data-ttu-id="70357-426">ファースト ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-426">Getting started guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-427">Unity 向け Mixer SDK</span><span class="sxs-lookup"><span data-stu-id="70357-427">Mixer SDK for Unity</span></span></td>
        <td><a href="https://www.assetstore.unity3d.com/en/#!/content/88585"><span data-ttu-id="70357-428">Mixer Unity プラグイン</span><span class="sxs-lookup"><span data-stu-id="70357-428">Mixer Unity plugin</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-429">Unity 向け Mixer SDK のリファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-429">Mixer SDK for Unity reference documentation</span></span></td>
        <td><a href="https://dev.mixer.com/reference/interactive/csharp/index.html"><span data-ttu-id="70357-430">Mixer Unity プラグインの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-430">API reference for Mixer Unity plugin</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-431">Unity ゲームを Microsoft Store に公開する</span><span class="sxs-lookup"><span data-stu-id="70357-431">Publish your Unity game to Microsoft Store</span></span></td>
        <td><a href="https://unity3d.com/partners/microsoft/porting-guides"><span data-ttu-id="70357-432">移植ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-432">Porting guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-433">.NET API に関連するアセンブリ参照が見つからない場合のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="70357-433">Troubleshooting missing assembly references related to .NET APIs</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/gaming/missing-dot-net-apis-in-unity-and-uwp"><span data-ttu-id="70357-434">Unity や UWP で不足している .NET API</span><span class="sxs-lookup"><span data-stu-id="70357-434">Missing .NET APIs in Unity and UWP</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-435">ユニバーサル Windows プラットフォーム アプリとして Unity ゲームを公開する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-435">Publish your Unity game as a Universal Windows Platform app (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-publish-your-Unity-game-as-a-UWP-app"><span data-ttu-id="70357-436">UWP アプリとして Unity ゲームを公開する方法</span><span class="sxs-lookup"><span data-stu-id="70357-436">How to publish your Unity game as a UWP app</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-437">Unity を使って Windows 向けゲームとアプリを作成する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-437">Use Unity to make Windows games and apps (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/Making-games-and-apps-with-Unity"><span data-ttu-id="70357-438">Unity を使った Windows 向けゲームとアプリの作成</span><span class="sxs-lookup"><span data-stu-id="70357-438">Making Windows games and apps with Unity</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-439">Visual Studio を使った Unity ゲームの開発 (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="70357-439">Unity game development using Visual Studio (video series)</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=722359"><span data-ttu-id="70357-440">Visual Studio 2015 での Unity の使用</span><span class="sxs-lookup"><span data-stu-id="70357-440">Using Unity with Visual Studio 2015</span></span></a></td>
    </tr>
</table>
 

#### <a name="havok"></a><span data-ttu-id="70357-441">Havok</span><span class="sxs-lookup"><span data-stu-id="70357-441">Havok</span></span>

<span data-ttu-id="70357-442">Havok のモジュール化された一連のツールとテクノロジによって、ゲーム クリエーターは新しいレベルの対話式操作と没入感を提供できます。</span><span class="sxs-lookup"><span data-stu-id="70357-442">Havok’s modular suite of tools and technologies help game creators reach new levels of interactivity and immersion.</span></span> <span data-ttu-id="70357-443">Havok により、非常にリアルな物理的効果、対話型のシミュレーション、魅力的な映像を実現できます。</span><span class="sxs-lookup"><span data-stu-id="70357-443">Havok enables highly realistic physics, interactive simulations, and stunning cinematics.</span></span> <span data-ttu-id="70357-444">Version 2015.1 以上では、x86、64 ビット、ARM 上の Visual Studio 2015 で UWP を正式にサポートします。</span><span class="sxs-lookup"><span data-stu-id="70357-444">Version 2015.1 and higher officially supports UWP in Visual Studio 2015 on x86, 64-bit, and ARM.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-445">Havok の Web サイト</span><span class="sxs-lookup"><span data-stu-id="70357-445">Havok website</span></span></td>
        <td><a href="http://www.havok.com/"><span data-ttu-id="70357-446">Havok</span><span class="sxs-lookup"><span data-stu-id="70357-446">Havok</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-447">Havok ツール スイート</span><span class="sxs-lookup"><span data-stu-id="70357-447">Havok tool suite</span></span></td>
        <td><a href="http://www.havok.com/products/"><span data-ttu-id="70357-448">Havok 製品の概要</span><span class="sxs-lookup"><span data-stu-id="70357-448">Havok Product Overview</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-449">Havok サポート フォーラム</span><span class="sxs-lookup"><span data-stu-id="70357-449">Havok support forums</span></span></td>
        <td><a href="http://support.havok.com"><span data-ttu-id="70357-450">Havok</span><span class="sxs-lookup"><span data-stu-id="70357-450">Havok</span></span></a></td>
    </tr>
</table>
 

#### <a name="monogame"></a><span data-ttu-id="70357-451">MonoGame</span><span class="sxs-lookup"><span data-stu-id="70357-451">MonoGame</span></span>

<span data-ttu-id="70357-452">MonoGame は、オープン ソース、クロスプラット フォームのゲーム開発フレームワークで、当初は Microsoft の XNA Framework 4.0 に基づいていました。</span><span class="sxs-lookup"><span data-stu-id="70357-452">MonoGame is an open source, cross-platform game development framework originally based on Microsoft's XNA Framework 4.0.</span></span> <span data-ttu-id="70357-453">現在、Monogame は、Windows、Windows Phone、Xbox と共に、Linux、macOS、iOS、Android、その他のいくつかのプラットフォームをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="70357-453">Monogame currently supports Windows, Windows Phone, and Xbox, as well as Linux, macOS, iOS, Android, and several other platforms.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-454">MonoGame</span><span class="sxs-lookup"><span data-stu-id="70357-454">MonoGame</span></span></td>
        <td><a href="http://www.monogame.net"><span data-ttu-id="70357-455">MonoGame Web サイト</span><span class="sxs-lookup"><span data-stu-id="70357-455">MonoGame website</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-456">MonoGame のドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-456">MonoGame Documentation</span></span></td>
        <td><a href="http://www.monogame.net/documentation/"><span data-ttu-id="70357-457">MonoGame のドキュメント (最新)</span><span class="sxs-lookup"><span data-stu-id="70357-457">MonoGame Documentation (latest)</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-458">Monogame のダウンロード</span><span class="sxs-lookup"><span data-stu-id="70357-458">Monogame Downloads</span></span></td>
        <td><span data-ttu-id="70357-459">MonoGame の Web サイトから<a href="http://www.monogame.net/downloads/">リリース、開発ビルド、ソース コードをダウンロード</a>するか、<a href="https://www.nuget.org/profiles/MonoGame">NuGet から最新のリリースを入手</a>します。</span><span class="sxs-lookup"><span data-stu-id="70357-459"><a href="http://www.monogame.net/downloads/">Download releases, development builds, and source code</a> from the MonoGame website, or <a href="https://www.nuget.org/profiles/MonoGame">get the latest release via NuGet</a>.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-460">MonoGame 2D UWP ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-460">MonoGame 2D UWP game sample</span></span></td>
        <td><a href="../get-started/get-started-tutorial-game-mg2d.md"><span data-ttu-id="70357-461">MonoGame 2D で UWP ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-461">Create a UWP game in MonoGame 2D</span></span></a></td>
    </tr>    
</table>


#### <a name="cocos2d"></a><span data-ttu-id="70357-462">Cocos2d</span><span class="sxs-lookup"><span data-stu-id="70357-462">Cocos2d</span></span>

<span data-ttu-id="70357-463">Cocos2d-x は、オープン ソース、クロス プラットフォームのゲーム開発エンジンおよびツール スイートで、UWP ゲームの構築をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="70357-463">Cocos2d-x is a cross-platform open source game development engine and tools suite that supports building UWP games.</span></span> <span data-ttu-id="70357-464">バージョン 3 以降、3D 機能も追加されています。</span><span class="sxs-lookup"><span data-stu-id="70357-464">Beginning with version 3, 3D features are being added as well.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-465">Cocos2d-x</span><span class="sxs-lookup"><span data-stu-id="70357-465">Cocos2d-x</span></span></td>
        <td><a href="http://www.cocos2d-x.org/"><span data-ttu-id="70357-466">Cocos2d-x とは</span><span class="sxs-lookup"><span data-stu-id="70357-466">What is Cocos2d-x?</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-467">Cocos2d-x プログラマ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-467">Cocos2d-x programmer's guide</span></span></td>
        <td><a href="http://www.cocos2d-x.org/programmersguide/"><span data-ttu-id="70357-468">Cocos2d-x プログラマ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-468">Cocos2d-x Programmers Guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-469">Windows 10 での Cocos2d-x (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-469">Cocos2d-x on Windows 10 (blog post)</span></span></td>
        <td><a href="https://blogs.windows.com/buildingapps/2015/06/15/running-cocos2d-x-on-windows-10/"><span data-ttu-id="70357-470">Windows 10 での Cocos2d-x の実行</span><span class="sxs-lookup"><span data-stu-id="70357-470">Running Cocos2d-x on Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-471">PlayFab を使用して LiveOps を追加する</span><span class="sxs-lookup"><span data-stu-id="70357-471">Add LiveOps using PlayFab</span></span></td>
        <td><a href="https://api.playfab.com/docs/getting-started/cocos2d-x-getting-started-guide"><span data-ttu-id="70357-472">概要 - Cocos2d ゲームからの最初の PlayFab API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="70357-472">Getting started - Make your first PlayFab API call from your Cocos2d game</span></span></a></td>
    </tr>
</table>


#### <a name="unreal-engine"></a><span data-ttu-id="70357-473">Unreal Engine</span><span class="sxs-lookup"><span data-stu-id="70357-473">Unreal Engine</span></span>

<span data-ttu-id="70357-474">Unreal Engine 4 は、あらゆる種類のゲームや開発者に適したゲーム開発ツールがすべて揃ったスイートです。</span><span class="sxs-lookup"><span data-stu-id="70357-474">Unreal Engine 4 is a complete suite of game development tools for all types of games and developers.</span></span> <span data-ttu-id="70357-475">最も要求の厳しいコンソールおよび PC ゲームにおいて、Unreal Engine は世界中のゲーム開発者により使用されています。</span><span class="sxs-lookup"><span data-stu-id="70357-475">For the most demanding console and PC games, Unreal Engine is used by game developers worldwide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-476">Unreal Engine の概要</span><span class="sxs-lookup"><span data-stu-id="70357-476">Unreal Engine overview</span></span></td>
        <td><a href="https://www.unrealengine.com/what-is-unreal-engine-4"><span data-ttu-id="70357-477">Unreal Engine 4</span><span class="sxs-lookup"><span data-stu-id="70357-477">Unreal Engine 4</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-478">PlayFab を使用して LiveOps を追加する - C++</span><span class="sxs-lookup"><span data-stu-id="70357-478">Add LiveOps using PlayFab - C++</span></span></td>
        <td><a href="https://api.playfab.com/docs/getting-started/unreal-cpp-getting-started"><span data-ttu-id="70357-479">概要 - Unreal ゲームからの最初の PlayFab API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="70357-479">Getting started - Make your first PlayFab API call from your Unreal game</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-480">PlayFab を使用して LiveOps を追加する - Blueprints</span><span class="sxs-lookup"><span data-stu-id="70357-480">Add LiveOps using PlayFab - Blueprints</span></span></td>
        <td><a href="https://api.playfab.com/docs/getting-started/unreal-blueprints-getting-started"><span data-ttu-id="70357-481">概要 - Unreal ゲームからの最初の PlayFab API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="70357-481">Getting started - Make your first PlayFab API call from your Unreal game</span></span></a></td>
    </tr>
</table>

#### <a name="babylonjs"></a><span data-ttu-id="70357-482">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="70357-482">BabylonJS</span></span>

<span data-ttu-id="70357-483">BabylonJS は、HTML5、WebGL、WebVR、Web オーディオで 3D ゲームを構築するための完全な JavaScript フレームワークです。</span><span class="sxs-lookup"><span data-stu-id="70357-483">BabylonJS is a complete JavaScript framework for building 3D games with HTML5, WebGL, WebVR, and Web Audio.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-484">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="70357-484">BabylonJS</span></span></td>
        <td><a href="http://www.babylonjs.com/"><span data-ttu-id="70357-485">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="70357-485">BabylonJS</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-486">HTML5 と BabylonJS を使用した WebGL 3D (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="70357-486">WebGL 3D with HTML5 and BabylonJS (video series)</span></span></td>
        <td><a href="https://channel9.msdn.com/Series/Introduction-to-WebGL-3D-with-HTML5-and-Babylonjs/01"><span data-ttu-id="70357-487">WebGL 3D と BabylonJS について</span><span class="sxs-lookup"><span data-stu-id="70357-487">Learning WebGL 3D and BabylonJS</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-488">BabylonJS を使用してクロスプラットフォーム WebGL ゲームを構築する</span><span class="sxs-lookup"><span data-stu-id="70357-488">Building a cross-platform WebGL game with BabylonJS</span></span></td>
        <td><a href="https://www.smashingmagazine.com/2016/07/babylon-js-building-sponza-a-cross-platform-webgl-game/"><span data-ttu-id="70357-489">BabylonJS を使用してクロスプラットフォーム ゲームを開発する</span><span class="sxs-lookup"><span data-stu-id="70357-489">Use BabylonJS to develop a cross-platform game</span></span></a></td>
    </tr>    
</table>

### <a name="porting-your-game"></a><span data-ttu-id="70357-490">ゲームの移植</span><span class="sxs-lookup"><span data-stu-id="70357-490">Porting your game</span></span>

<span data-ttu-id="70357-491">既にゲームがある場合は、ゲームを短期間で UWP に移植するのに役立つ多くのリソースやガイドがあります。</span><span class="sxs-lookup"><span data-stu-id="70357-491">If you have an existing game, there are many resources and guides available to help you quickly bring your game to the UWP.</span></span> <span data-ttu-id="70357-492">移植作業をすぐに開始する場合は、[ユニバーサル Windows プラットフォーム ブリッジ](#universal-windows-platform-bridges)を使うことも検討してください。</span><span class="sxs-lookup"><span data-stu-id="70357-492">To jumpstart your porting efforts, you might also consider using a [Universal Windows Platform Bridge](#universal-windows-platform-bridges).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-493">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-493">Porting a Windows 8 app to a Universal Windows Platform app</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt238322"><span data-ttu-id="70357-494">Windows ランタイム 8.x から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="70357-494">Move from Windows Runtime 8.x to UWP</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-495">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-495">Porting a Windows 8 app to a Universal Windows Platform app (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/21"><span data-ttu-id="70357-496">8.1 アプリの Windows 10 への移植</span><span class="sxs-lookup"><span data-stu-id="70357-496">Porting 8.1 Apps to Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-497">iOS アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="70357-497">Porting an iOS app to a Universal Windows Platform app</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt238320"><span data-ttu-id="70357-498">iOS から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="70357-498">Move from iOS to UWP</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-499">Silverlight アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="70357-499">Porting a Silverlight app to a Universal Windows Platform app</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt238323"><span data-ttu-id="70357-500">Windows Phone Silverlight から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="70357-500">Move from Windows Phone Silverlight to UWP</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-501">XAML または Silverlight からユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-501">Porting from XAML or Silverlight to a Universal Windows Platform app (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/Build/2015/3-741"><span data-ttu-id="70357-502">XAML または Silverlight から Windows 10 へのアプリの移植</span><span class="sxs-lookup"><span data-stu-id="70357-502">Porting an App from XAML or Silverlight to Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-503">Xbox ゲームをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="70357-503">Porting an Xbox game to a Universal Windows Platform app</span></span></td>
        <td><a href="https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx"><span data-ttu-id="70357-504">Xbox One から Windows 10 UWP への移植</span><span class="sxs-lookup"><span data-stu-id="70357-504">Porting from Xbox One to Windows 10 UWP</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-505">DirectX 9 から DirectX 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-505">Porting from DirectX 9 to DirectX 11</span></span></td>
        <td><a href="porting-your-directx-9-game-to-windows-store.md"><span data-ttu-id="70357-506">DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植</span><span class="sxs-lookup"><span data-stu-id="70357-506">Port from DirectX 9 to Universal Windows Platform (UWP)</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-507">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-507">Porting from Direct3D 11 to Direct3D 12</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709"><span data-ttu-id="70357-508">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-508">Porting from Direct3D 11 to Direct3D 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-509">OpenGL ES から Direct3D 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-509">Porting from OpenGL ES to Direct3D 11</span></span></td>
        <td><a href="port-from-opengl-es-2-0-to-directx-11-1.md"><span data-ttu-id="70357-510">OpenGL ES 2.0 から Direct3D 11 への移植</span><span class="sxs-lookup"><span data-stu-id="70357-510">Port from OpenGL ES 2.0 to Direct3D 11</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-511">ANGLE を使って OpenGL ES から Direct3D 11 に移行する</span><span class="sxs-lookup"><span data-stu-id="70357-511">OpenGL ES to Direct3D 11 using ANGLE</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/p/?linkid=618387"><span data-ttu-id="70357-512">ANGLE</span><span class="sxs-lookup"><span data-stu-id="70357-512">ANGLE</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-513">UWP で従来の Windows API に相当する要素</span><span class="sxs-lookup"><span data-stu-id="70357-513">Classic Windows API equivalents in the UWP</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/hh464945"><span data-ttu-id="70357-514">ユニバーサル Windows プラットフォーム (UWP) アプリでの Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="70357-514">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</span></span></a></td>
    </tr>
</table>


## <a name="prototype-and-design"></a><span data-ttu-id="70357-515">プロトタイプとデザイン</span><span class="sxs-lookup"><span data-stu-id="70357-515">Prototype and design</span></span>


<span data-ttu-id="70357-516">作成するゲームの種類と、ゲームの構築に使うツールとグラフィックス テクノロジが決まったら、すぐにデザインとプロトタイプを開始できます。</span><span class="sxs-lookup"><span data-stu-id="70357-516">Now that you've decided the type of game you want to create and the tools and graphics technology you'll use to build it, you're ready to get started with the design and prototype.</span></span> <span data-ttu-id="70357-517">ゲームのコアはユニバーサル Windows プラットフォーム アプリであるため、そこから作業を開始します。</span><span class="sxs-lookup"><span data-stu-id="70357-517">At its core, your game is a Universal Windows Platform app, so that's where you'll begin.</span></span>

### <a name="introduction-to-the-universal-windows-platform-uwp"></a><span data-ttu-id="70357-518">ユニバーサル Windows プラットフォーム (UWP) の概要</span><span class="sxs-lookup"><span data-stu-id="70357-518">Introduction to the Universal Windows Platform (UWP)</span></span>

<span data-ttu-id="70357-519">Windows 10 ではユニバーサル Windows プラットフォーム (UWP) が導入され、Windows 10 デバイス間で共通の API プラットフォームが提供されます。</span><span class="sxs-lookup"><span data-stu-id="70357-519">Windows 10 introduces the Universal Windows Platform (UWP), which provides a common API platform across Windows 10 devices.</span></span> <span data-ttu-id="70357-520">UWP は、Windows ランタイム モデルを発展させて拡張したもので、まとまりのある統一されたコアとなっています。</span><span class="sxs-lookup"><span data-stu-id="70357-520">UWP evolves and expands the Windows Runtime model and hones it into a cohesive, unified core.</span></span> <span data-ttu-id="70357-521">UWP を対象とするゲームでは、すべてのデバイスに共通する WinRT API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="70357-521">Games that target the UWP can call WinRT APIs that are common to all devices.</span></span> <span data-ttu-id="70357-522">UWP により保証された API 層が提供されるため、あらゆる Windows 10 デバイスにインストールできる 1 つのアプリ パッケージを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="70357-522">Because the UWP provides guaranteed API layers, you can choose to create a single app package that will install across Windows 10 devices.</span></span> <span data-ttu-id="70357-523">また、必要に応じて、ゲームが実行されるデバイスに固有の API (Win32 や .NET の従来の Windows API など) を、ゲームで呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="70357-523">And if you want to, your game can still call APIs (including some classic Windows APIs from Win32 and .NET) that are specific to the devices your game runs on.</span></span>

<span data-ttu-id="70357-524">次に示すガイドは、ユニバーサル Windows プラットフォーム アプリについて詳しく説明している優れたガイドであり、このプラットフォームを理解するために一読することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="70357-524">The following are excellent guides that discuss the Universal Windows Platform apps in detail, and are recommended reading to help you understand the platform.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-525">ユニバーサル Windows プラットフォーム アプリの概要</span><span class="sxs-lookup"><span data-stu-id="70357-525">Introduction to Universal Windows Platform apps</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/dn726767"><span data-ttu-id="70357-526">ユニバーサル Windows プラットフォーム アプリとは</span><span class="sxs-lookup"><span data-stu-id="70357-526">What's a Universal Windows Platform app?</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-527">UWP の概要</span><span class="sxs-lookup"><span data-stu-id="70357-527">Overview of the UWP</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/dn894631"><span data-ttu-id="70357-528">UWP アプリ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-528">Guide to UWP apps</span></span></a></td>
    </tr>
</table>
 

### <a name="getting-started-with-uwp-development"></a><span data-ttu-id="70357-529">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="70357-529">Getting started with UWP development</span></span>

<span data-ttu-id="70357-530">ユニバーサル Windows プラットフォーム アプリを開発するための準備は非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="70357-530">Getting set up and ready to develop a Universal Windows Platform app is quick and easy.</span></span> <span data-ttu-id="70357-531">以下のガイドでは、プロセスの詳しい手順を説明しています。</span><span class="sxs-lookup"><span data-stu-id="70357-531">The following guides take you through the process step-by-step.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-532">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="70357-532">Getting started with UWP development</span></span></td>
        <td><a href="https://dev.windows.com/getstarted"><span data-ttu-id="70357-533">Windows アプリの概要</span><span class="sxs-lookup"><span data-stu-id="70357-533">Get started with Windows apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-534">UWP 開発の準備</span><span class="sxs-lookup"><span data-stu-id="70357-534">Getting set up for UWP development</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/dn726766"><span data-ttu-id="70357-535">準備</span><span class="sxs-lookup"><span data-stu-id="70357-535">Get set up</span></span></a></td>
    </tr>
</table>

<span data-ttu-id="70357-536">UWP プログラミングについて "文字どおりの初心者" である場合や、ゲームで XAML の使用を検討している場合 (「[グラフィックス テクノロジとプログラミング言語の選択](#choosing-your-graphics-technology-and-programming-language)」を参照) は、最初に[文字どおりの初心者のための Windows 10 の開発](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)に関するビデオ シリーズをご覧になることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="70357-536">If you're an "absolute beginner" to UWP programming, and are considering using XAML in your game (see [Choosing your graphics technology and programming language](#choosing-your-graphics-technology-and-programming-language)), the [Windows 10 development for absolute beginners](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners) video series is a good place to start.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-537">XAML を使った Windows 10 の開発の初心者向けガイド (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="70357-537">Beginners guide to Windows 10 development with XAML (Video series)</span></span></td>
        <td><a href="https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners"><span data-ttu-id="70357-538">文字どおりの初心者のための Windows 10 の開発</span><span class="sxs-lookup"><span data-stu-id="70357-538">Windows 10 development for absolute beginners</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-539">XAML を使う Windows 10 の初心者向けシリーズの発表 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-539">Announcing the Windows 10 absolute beginners series using XAML (blog post)</span></span></td>
        <td><a href="http://blogs.windows.com/buildingapps/2015/09/30/windows-10-development-for-absolute-beginners/"><span data-ttu-id="70357-540">文字どおりの初心者のための Windows 10 の開発</span><span class="sxs-lookup"><span data-stu-id="70357-540">Windows 10 development for absolute beginners</span></span></a></td>
    </tr>
</table>

### <a name="uwp-development-concepts"></a><span data-ttu-id="70357-541">UWP 開発の概念</span><span class="sxs-lookup"><span data-stu-id="70357-541">UWP development concepts</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-542">ユニバーサル Windows プラットフォーム アプリの開発の概要</span><span class="sxs-lookup"><span data-stu-id="70357-542">Overview of Universal Windows Platform app development</span></span></td>
        <td><a href="https://dev.windows.com/develop"><span data-ttu-id="70357-543">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="70357-543">Develop Windows apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-544">UWP のネットワーク プログラミングの概要</span><span class="sxs-lookup"><span data-stu-id="70357-544">Overview of network programming in the UWP</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt280378"><span data-ttu-id="70357-545">ネットワークと Web サービス</span><span class="sxs-lookup"><span data-stu-id="70357-545">Networking and web services</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-546">ゲームでの Windows.Web.HTTP と Windows.Networking.Sockets の使用</span><span class="sxs-lookup"><span data-stu-id="70357-546">Using Windows.Web.HTTP and Windows.Networking.Sockets in games</span></span></td>
        <td><a href="work-with-networking-in-your-directx-game.md"><span data-ttu-id="70357-547">ゲームのネットワーク</span><span class="sxs-lookup"><span data-stu-id="70357-547">Networking for games</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-548">UWP での非同期プログラミングの概念</span><span class="sxs-lookup"><span data-stu-id="70357-548">Asynchronous programming concepts in the UWP</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt187335"><span data-ttu-id="70357-549">非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="70357-549">Asynchronous programming</span></span></a></td>
    </tr>
</table>

### <a name="windows-desktop-apis-to-uwp"></a><span data-ttu-id="70357-550">Windows デスクトップ API から UWP へ</span><span class="sxs-lookup"><span data-stu-id="70357-550">Windows Desktop APIs to UWP</span></span>

<span data-ttu-id="70357-551">Windows デスクトップ ゲームを UWP に移行する際に役立つリンクの一部を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="70357-551">These are some links to help you move your Windows desktop game to UWP.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-552">既存の C++ コードを使った UWP ゲーム開発</span><span class="sxs-lookup"><span data-stu-id="70357-552">Use existing C++ code for UWP game development</span></span></td>
        <td><a href="https://docs.microsoft.com/cpp/porting/how-to-use-existing-cpp-code-in-a-universal-windows-platform-app"><span data-ttu-id="70357-553">UWP アプリで既存の C++ コードを使う方法</span><span class="sxs-lookup"><span data-stu-id="70357-553">How to: Use existing C++ code in a UWP app</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-554">Win32 API と COM API 用の UWP API</span><span class="sxs-lookup"><span data-stu-id="70357-554">UWP APIs for Win32 and COM APIs</span></span></td>
        <td><a href="https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps"><span data-ttu-id="70357-555">UWP アプリ用の Win32 API と COM API</span><span class="sxs-lookup"><span data-stu-id="70357-555">Win32 and COM APIs for UWP apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-556">UWP でサポートされない CRT 関数</span><span class="sxs-lookup"><span data-stu-id="70357-556">Unsupported CRT functions in UWP</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/jj606124.aspx"><span data-ttu-id="70357-557">ユニバーサル Windows プラットフォーム アプリでサポートされていない CRT 関数</span><span class="sxs-lookup"><span data-stu-id="70357-557">CRT functions not supported in Universal Windows Platform apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-558">Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="70357-558">Alternatives for Windows APIs</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt592894.aspx"><span data-ttu-id="70357-559">ユニバーサル Windows プラットフォーム (UWP) アプリでの Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="70357-559">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</span></span></a></td>
    </tr>
</table>
 

### <a name="process-lifetime-management"></a><span data-ttu-id="70357-560">プロセス ライフタイム管理</span><span class="sxs-lookup"><span data-stu-id="70357-560">Process lifetime management</span></span>

<span data-ttu-id="70357-561">プロセス ライフタイム管理、つまりアプリのライフ サイクルは、ユニバーサル Windows プラットフォーム アプリが取り得るさまざまなアクティブ化状態を表します。</span><span class="sxs-lookup"><span data-stu-id="70357-561">Process lifetime management, or app lifecyle, describes the various activation states that a Universal Windows Platform app can transition through.</span></span> <span data-ttu-id="70357-562">ゲームは、アクティブ化、中断、再開、または終了することができ、さまざまな方法でこれらの状態を移行できます。</span><span class="sxs-lookup"><span data-stu-id="70357-562">Your game can be activated, suspended, resumed, or terminated, and can transition through those states in a variety of ways.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-563">アプリのライフ サイクルの移行の処理</span><span class="sxs-lookup"><span data-stu-id="70357-563">Handling app lifecyle transitions</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt243287"><span data-ttu-id="70357-564">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="70357-564">App lifecycle</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-565">Microsoft Visual Studio を使ったアプリの移行のトリガー</span><span class="sxs-lookup"><span data-stu-id="70357-565">Using Microsoft Visual Studio to trigger app transitions</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/hh974425.aspx"><span data-ttu-id="70357-566">Visual Studio で UWP アプリの一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法</span><span class="sxs-lookup"><span data-stu-id="70357-566">How to trigger suspend, resume, and background events for UWP apps in Visual Studio</span></span></a></td>
    </tr>
</table>
 

### <a name="designing-game-ux"></a><span data-ttu-id="70357-567">ゲーム UX の設計</span><span class="sxs-lookup"><span data-stu-id="70357-567">Designing game UX</span></span>

<span data-ttu-id="70357-568">優れたゲームはすばらしいデザインから始まります。</span><span class="sxs-lookup"><span data-stu-id="70357-568">The genesis of a great game is inspired design.</span></span>

<span data-ttu-id="70357-569">ゲームは、共通のユーザー インターフェイス要素とデザイン原則をアプリと共有していますが、ユーザー エクスペリエンスの外観、機能、設計目標が独特であることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="70357-569">Games share some common user interface elements and design principles with apps, but games often have a unique look, feel, and design goal for their user experience.</span></span> <span data-ttu-id="70357-570">テストされた UX をゲームで使用すべきなのはいつか、斬新で革新的な UX を使用すべきなのはいつか、という両方の側面に、よく考えられたデザインを当てはめるときにゲームは成功します。</span><span class="sxs-lookup"><span data-stu-id="70357-570">Games succeed when thoughtful design is applied to both aspects—when should your game use tested UX, and when should it diverge and innovate?</span></span> <span data-ttu-id="70357-571">ゲームに選択したプレゼンテーション テクノロジ (DirectX、XAML、HTML5、または 3 つの組み合わせ) は、実装の細部に影響を与える可能性がありますが、適用するデザイン原則はその選択とはほとんど関係がありません。</span><span class="sxs-lookup"><span data-stu-id="70357-571">The presentation technology that you choose for your game—DirectX, XAML, HTML5, or some combination of the three—will influence implementation details, but the design principles you apply are largely independent of that choice.</span></span>

<span data-ttu-id="70357-572">UX デザインとは別に、レベルのデザイン、ペース配分、世界のデザインなどのゲームプレイのデザインには独自の様式があり、開発者や開発チームによって決定されるため、この開発ガイドに記載していません。</span><span class="sxs-lookup"><span data-stu-id="70357-572">Separately from UX design, gameplay design such as level design, pacing, world design, and other aspects is an art form of its own—one that's up to you and your team, and not covered in this development guide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-573">UWP の設計の基本とガイドライン</span><span class="sxs-lookup"><span data-stu-id="70357-573">UWP design basics and guidelines</span></span></td>
        <td><a href="https://dev.windows.com/design"><span data-ttu-id="70357-574">UWP アプリの設計</span><span class="sxs-lookup"><span data-stu-id="70357-574">Designing UWP apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-575">アプリのライフサイクルの状態の設計</span><span class="sxs-lookup"><span data-stu-id="70357-575">Designing for app lifecycle states</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/dn611862"><span data-ttu-id="70357-576">起動、中断、再開の UX ガイドライン</span><span class="sxs-lookup"><span data-stu-id="70357-576">UX guidelines for launch, suspend, and resume</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-577">Xbox One とテレビ画面向けの UWP アプリの設計</span><span class="sxs-lookup"><span data-stu-id="70357-577">Design your UWP app for Xbox One and television screens</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv"><span data-ttu-id="70357-578">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="70357-578">Designing for Xbox and TV</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-579">複数のデバイスのフォーム ファクターをターゲットに設定する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-579">Targeting multiple device form factors (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Designing-Games-for-a-Windows-Core-World"><span data-ttu-id="70357-580">Windows コアの世界向けのゲームの設計</span><span class="sxs-lookup"><span data-stu-id="70357-580">Designing Games for a Windows Core World</span></span></a></td>
    </tr>   
</table>
 

#### <a name="color-guideline-and-palette"></a><span data-ttu-id="70357-581">色のガイドラインとパレット</span><span class="sxs-lookup"><span data-stu-id="70357-581">Color guideline and palette</span></span>

<span data-ttu-id="70357-582">ゲームで一貫した色のガイドラインに従うと、美しさやナビゲーションの操作性が向上し、メニューや HUD の機能がプレイヤーに伝わりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="70357-582">Following a consistent color guideline in your game improves aesthetics, aids navigation, and is a powerful tool to inform the player of menu and HUD functionality.</span></span> <span data-ttu-id="70357-583">警告、ダメージ、XP、成績などのゲーム要素の色が一貫していると、UI がわかりやすくなるため、ラベルによって説明する必要性が減ります。</span><span class="sxs-lookup"><span data-stu-id="70357-583">Consistent coloring of game elements like warnings, damage, XP, and achievements can lead to cleaner UI and reduce the need for explicit labels.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-584">色のガイド</span><span class="sxs-lookup"><span data-stu-id="70357-584">Color guide</span></span></td>
        <td><a href="https://assets.windowsphone.com/499cd2be-64ed-4b05-a4f5-cd0c9ad3f6a3/101_BestPractices_Color_InvariantCulture_Default.zip"><span data-ttu-id="70357-585">ベストプラクティス: 色</span><span class="sxs-lookup"><span data-stu-id="70357-585">Best Practices: Color</span></span></a></td>
    </tr>
</table>
 

#### <a name="typography"></a><span data-ttu-id="70357-586">文字体裁</span><span class="sxs-lookup"><span data-stu-id="70357-586">Typography</span></span>

<span data-ttu-id="70357-587">文字体裁を適切に使うと、UI のレイアウト、ナビゲーション、読みやすさ、雰囲気、ブランド、プレイヤーの熱中度など、多くの側面が向上します。</span><span class="sxs-lookup"><span data-stu-id="70357-587">The appropriate use of typography enhances many aspects of your game, including UI layout, navigation, readability, atmosphere, brand, and player immersion.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-588">文字体裁のガイド</span><span class="sxs-lookup"><span data-stu-id="70357-588">Typography guide</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=535007"><span data-ttu-id="70357-589">ベスト プラクティス: 文字体裁</span><span class="sxs-lookup"><span data-stu-id="70357-589">Best Practices: Typography</span></span></a></td>
    </tr>
</table>
 

#### <a name="ui-map"></a><span data-ttu-id="70357-590">UI マップ</span><span class="sxs-lookup"><span data-stu-id="70357-590">UI map</span></span>

<span data-ttu-id="70357-591">UI マップとは、ゲーム ナビゲーションのレイアウトとフローチャートで表されるメニューのことです。</span><span class="sxs-lookup"><span data-stu-id="70357-591">A UI map is a layout of game navigation and menus expressed as a flowchart.</span></span> <span data-ttu-id="70357-592">UI マップを使うと、すべての関係者が、ゲームのインターフェイスとナビゲーション パスを理解しやすくなり、開発サイクルの初期段階で潜在的な障害や行き詰まりが明らかになります。</span><span class="sxs-lookup"><span data-stu-id="70357-592">The UI map helps all involved stakeholders understand the game’s interface and navigation paths, and can expose potential roadblocks and dead ends early in the development cycle.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-593">UI マップ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-593">UI map guide</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=535008"><span data-ttu-id="70357-594">ベスト プラクティス: UI マップ</span><span class="sxs-lookup"><span data-stu-id="70357-594">Best Practices: UI Map</span></span></a></td>
    </tr>
</table>

### <a name="game-audio"></a><span data-ttu-id="70357-595">ゲーム オーディオ</span><span class="sxs-lookup"><span data-stu-id="70357-595">Game audio</span></span>

<span data-ttu-id="70357-596">XAudio2、XAPO、Windows Sonic を使ってオーディオをゲームで実装するためのガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-596">Guides and references for implementing audio in games using XAudio2, XAPO, and Windows Sonic.</span></span> <span data-ttu-id="70357-597">XAudio2 は、パフォーマンスの高いオーディオ エンジンを開発するための、信号処理とミキシングの基盤を提供する低水準のオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="70357-597">XAudio2 is a low-level audio API that provides signal processing and mixing foundation for developing high performance audio engines.</span></span> <span data-ttu-id="70357-598">XAPO API を使用すると、XAudio2 を使用するクロスプラットフォーム オーディオ処理オブジェクト (XAPO) を、Windows と Xbox の両方で作成できます。</span><span class="sxs-lookup"><span data-stu-id="70357-598">XAPO API allows the creation of cross-platform audio processing objects (XAPO) for use in XAudio2 on both Windows and Xbox.</span></span> <span data-ttu-id="70357-599">Windows Sonic オーディオのサポートにより、ゲームやストリーミング メディア アプリケーションに、Dolby Atmos for Home Theater、Dolby Atmos for Headphones、Windows HRTF のサポートを追加できます。</span><span class="sxs-lookup"><span data-stu-id="70357-599">Windows Sonic audio support allows you to add Dolby Atmos for Home Theater, Dolby Atmos for Headphones, and Windows HRTF support to your game or streaming media application.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-600">XAudio2 API</span><span class="sxs-lookup"><span data-stu-id="70357-600">XAudio2 APIs</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049.aspx"><span data-ttu-id="70357-601">XAudio2 のプログラミング ガイドと API リファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-601">Programming guide and API reference for XAudio2</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-602">クロスプラット フォーム オーディオ処理オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-602">Create cross-platform audio processing objects</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/ee415735.aspx"><span data-ttu-id="70357-603">XAPO 概要</span><span class="sxs-lookup"><span data-stu-id="70357-603">XAPO Overview</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-604">オーディオの概念の概要</span><span class="sxs-lookup"><span data-stu-id="70357-604">Intro to audio concepts</span></span></td>
        <td><a href="working-with-audio-in-your-directx-game.md"><span data-ttu-id="70357-605">ゲームのオーディオ</span><span class="sxs-lookup"><span data-stu-id="70357-605">Audio for games</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-606">Windows Sonic の概要</span><span class="sxs-lookup"><span data-stu-id="70357-606">Windows Sonic overview</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt807491.aspx"><span data-ttu-id="70357-607">立体音響</span><span class="sxs-lookup"><span data-stu-id="70357-607">Spatial sound</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-608">Windows Sonic の立体音響のサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-608">Windows Sonic spatial sound samples</span></span></td>
        <td><a href="https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/Audio"><span data-ttu-id="70357-609">Xbox Advanced Technology Group のオーディオ サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-609">Xbox Advanced Technology Group audio samples</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-610">Windows Sonic をゲーム (ビデオ) に統合する方法</span><span class="sxs-lookup"><span data-stu-id="70357-610">Learn how to integrate Windows Sonic into your games (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-002"><span data-ttu-id="70357-611">Windows および Xbox 用の空間オーディオ機能の導入</span><span class="sxs-lookup"><span data-stu-id="70357-611">Introducing Spatial Audio Capabilities for Xbox and Windows</span></span></a></td>
    </tr>
</table>

### <a name="directx-development"></a><span data-ttu-id="70357-612">DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="70357-612">DirectX development</span></span>

<span data-ttu-id="70357-613">DirectX ゲーム開発用のガイドと参照情報を紹介します。</span><span class="sxs-lookup"><span data-stu-id="70357-613">Guides and references for DirectX game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-614">UWP 用の DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="70357-614">DirectX for UWP development</span></span></td>
        <td><a href="directx-programming.md"><span data-ttu-id="70357-615">DirectX プログラミング</span><span class="sxs-lookup"><span data-stu-id="70357-615">DirectX programming</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-616">チュートリアル: UWP DirectX ゲームを作成する方法</span><span class="sxs-lookup"><span data-stu-id="70357-616">Tutorial: How to create a UWP DirectX game</span></span></td>
        <td><a href="tutorial--create-your-first-uwp-directx-game.md"><span data-ttu-id="70357-617">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="70357-617">Create a simple UWP game with DirectX</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-618">UWP アプリ モデルによる DirectX の操作</span><span class="sxs-lookup"><span data-stu-id="70357-618">DirectX interaction with the UWP app model</span></span></td>
        <td><a href="about-the-uwp-user-interface-and-directx.md"><span data-ttu-id="70357-619">アプリ オブジェクトと DirectX</span><span class="sxs-lookup"><span data-stu-id="70357-619">The app object and DirectX</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-620">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="70357-620">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA"><span data-ttu-id="70357-621">Microsoft DirectX 12 とグラフィックスに関する教育</span><span class="sxs-lookup"><span data-stu-id="70357-621">Microsoft DirectX 12 and Graphics Education</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-622">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-622">DirectX overviews and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274"><span data-ttu-id="70357-623">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="70357-623">DirectX Graphics and Gaming</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-624">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="70357-624">Direct3D 12 programming guide and reference</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821"><span data-ttu-id="70357-625">Direct3D 12 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="70357-625">Direct3D 12 Graphics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-626">DirectX 12 の基本事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-626">DirectX 12 fundamentals (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Better-Power-Better-Performance-Your-Game-on-DirectX12"><span data-ttu-id="70357-627">強化されたパワーとパフォーマンスの向上: DirectX 12 でのゲーム</span><span class="sxs-lookup"><span data-stu-id="70357-627">Better Power, Better Performance: Your Game on DirectX 12</span></span></a></td>
    </tr>
</table>

#### <a name="learning-direct3d-12"></a><span data-ttu-id="70357-628">Direct3D 12 について</span><span class="sxs-lookup"><span data-stu-id="70357-628">Learning Direct3D 12</span></span>

<span data-ttu-id="70357-629">Direct3D 12 での変更点、および Direct3D 12 を使ってプログラミングを開始する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="70357-629">Learn what changed in Direct3D 12 and how to start programming using Direct3D 12.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-630">プログラミング環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="70357-630">Set up programming environment</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn899120.aspx"><span data-ttu-id="70357-631">Direct3D 12 プログラミング環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="70357-631">Direct3D 12 programming environment setup</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-632">基本的なコンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="70357-632">How to create a basic component</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn859356.aspx"><span data-ttu-id="70357-633">Direct3D 12 の基本的なコンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="70357-633">Creating a basic Direct3D 12 component</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-634">Direct3D 12 での変更点</span><span class="sxs-lookup"><span data-stu-id="70357-634">Changes in Direct3D 12</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn899194.aspx"><span data-ttu-id="70357-635">Direct3D 11 から Direct3D 12 に移行された重要な変更点</span><span class="sxs-lookup"><span data-stu-id="70357-635">Important changes migrating from Direct3D 11 to Direct3D 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-636">Direct3D 11 から Direct3D 12 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="70357-636">How to port from Direct3D 11 to Direct3D 12</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709.aspx"><span data-ttu-id="70357-637">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="70357-637">Porting from Direct3D 11 to Direct3D 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-638">リソース バインディングの概念 (対象となる記述子、記述子テーブル、記述子ヒープ、およびルート署名)</span><span class="sxs-lookup"><span data-stu-id="70357-638">Resource binding concepts (covering descriptor, descriptor table, descriptor heap, and root signature)</span></span> </td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn899206.aspx"><span data-ttu-id="70357-639">Direct3D 12 でのリソース バインディング</span><span class="sxs-lookup"><span data-stu-id="70357-639">Resource binding in Direct3D 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-640">メモリ管理</span><span class="sxs-lookup"><span data-stu-id="70357-640">Managing memory</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn899198.aspx"><span data-ttu-id="70357-641">Direct3D 12 でのメモリ管理</span><span class="sxs-lookup"><span data-stu-id="70357-641">Memory management in Direct3D 12</span></span></a></td>
    </tr>
</table>
 

#### <a name="directx-tool-kit-and-libraries"></a><span data-ttu-id="70357-642">DirectX ツール キットとライブラリ</span><span class="sxs-lookup"><span data-stu-id="70357-642">DirectX Tool Kit and libraries</span></span>

<span data-ttu-id="70357-643">DirectX ツール キット、DirectX テクスチャ処理ライブラリ、DirectXMesh ジオメトリ処理ライブラリ、UVAtlas ライブラリ、DirectXMath ライブラリは、DirectX 開発用のテクスチャ、メッシュ、スプライト、その他のユーティリティ機能とヘルパー クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-643">The DirectX Tool Kit, DirectX texture processing library, DirectXMesh geometry processing library, UVAtlas library, and DirectXMath library provide texture, mesh, sprite, and other utility functionality and helper classes for DirectX development.</span></span> <span data-ttu-id="70357-644">これらのライブラリは、開発にかかる時間と労力を減らすのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="70357-644">These libraries can help you save development time and effort.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-645">DirectX 11 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="70357-645">Get DirectX Tool Kit for DirectX 11</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=248929"><span data-ttu-id="70357-646">DirectXTK</span><span class="sxs-lookup"><span data-stu-id="70357-646">DirectXTK</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-647">DirectX 12 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="70357-647">Get DirectX Tool Kit for DirectX 12</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkID=615561"><span data-ttu-id="70357-648">DirectXTK 12</span><span class="sxs-lookup"><span data-stu-id="70357-648">DirectXTK 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-649">DirectX テクスチャ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="70357-649">Get DirectX texture processing library</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=248926"><span data-ttu-id="70357-650">DirectXTex</span><span class="sxs-lookup"><span data-stu-id="70357-650">DirectXTex</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-651">DirectXMesh ジオメトリ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="70357-651">Get DirectXMesh geometry processing library</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkID=324981"><span data-ttu-id="70357-652">DirectXMesh</span><span class="sxs-lookup"><span data-stu-id="70357-652">DirectXMesh</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-653">isochart テクスチャ アトラスを作成してパッケージ化するための UVAtlas を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-653">Get UVAtlas for creating and packing isochart texture atlas</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkID=512686"><span data-ttu-id="70357-654">UVAtlas</span><span class="sxs-lookup"><span data-stu-id="70357-654">UVAtlas</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-655">DirectXMath のライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="70357-655">Get the DirectXMath library</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkID=615560"><span data-ttu-id="70357-656">DirectXMath</span><span class="sxs-lookup"><span data-stu-id="70357-656">DirectXMath</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-657">DirectXTK での Direct3D 12 のサポート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-657">Direct3D 12 support in the DirectXTK (blog post)</span></span></td>
        <td><a href="https://github.com/Microsoft/DirectXTK/issues/2"><span data-ttu-id="70357-658">DirectX 12 のサポート</span><span class="sxs-lookup"><span data-stu-id="70357-658">Support for DirectX 12</span></span></a></td>
    </tr>
</table>

#### <a name="directx-resources-from-partners"></a><span data-ttu-id="70357-659">パートナーからの DirectX リソース</span><span class="sxs-lookup"><span data-stu-id="70357-659">DirectX resources from partners</span></span>

<span data-ttu-id="70357-660">これらは、外部のパートナーによって作成された補足の DirectX ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="70357-660">These are some additional DirectX documentation created by external partners.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-661">Nvidia: DX12 での推奨と非推奨 (ブログ投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-661">Nvidia: DX12 Do's and Don'ts (blog post)</span></span> </td>
        <td><a href="https://developer.nvidia.com/dx12-dos-and-donts-updated"><span data-ttu-id="70357-662">Nvidia GPU での DirectX 12</span><span class="sxs-lookup"><span data-stu-id="70357-662">DirectX 12 on Nvidia GPUs</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-663">Intel: DirectX 12 を使った効率的なレンダリング</span><span class="sxs-lookup"><span data-stu-id="70357-663">Intel: Efficient rendering with DirectX 12</span></span></td>
        <td><a href="https://software.intel.com/sites/default/files/managed/4a/38/Efficient-Rendering-with-DirectX-12-on-Intel-Graphics.pdf"><span data-ttu-id="70357-664">Intel グラフィックスでの DirectX 12 のレンダリング</span><span class="sxs-lookup"><span data-stu-id="70357-664">DirectX 12 rendering on Intel Graphics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-665">Intel: DirectX 12 でのマルチ アダプターのサポート</span><span class="sxs-lookup"><span data-stu-id="70357-665">Intel: Multi adapter support in DirectX 12</span></span></td>
        <td><a href="https://software.intel.com/articles/multi-adapter-support-in-directx-12"><span data-ttu-id="70357-666">DirectX 12 を使った明示的なマルチ アダプターアプリケーションを実装する方法</span><span class="sxs-lookup"><span data-stu-id="70357-666">How to implement an explicit multi-adapter application using DirectX 12</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-667">Intel: DirectX 12 のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="70357-667">Intel: DirectX 12 tutorial</span></span></td>
        <td><a href="https://software.intel.com/articles/tutorial-migrating-your-apps-to-directx-12-part-1"><span data-ttu-id="70357-668">Intel、Suzhou Snail、Microsoft によって共同制作されたホワイト ペーパー</span><span class="sxs-lookup"><span data-stu-id="70357-668">Collaborative white paper by Intel, Suzhou Snail and Microsoft</span></span></a></td>
    </tr>
</table>


## <a name="production"></a><span data-ttu-id="70357-669">制作</span><span class="sxs-lookup"><span data-stu-id="70357-669">Production</span></span>


<span data-ttu-id="70357-670">制作スタジオの準備が整ったら、チーム全体に作業を分散して制作サイクルに移行します。</span><span class="sxs-lookup"><span data-stu-id="70357-670">Your studio is now fully engaged and moving into the production cycle, with work distributed throughout your team.</span></span> <span data-ttu-id="70357-671">プロトタイプの調整、リファクタリング、拡張によって、ゲームの完成品に仕上げていきます。</span><span class="sxs-lookup"><span data-stu-id="70357-671">You're polishing, refactoring, and extending the prototype to craft it into a full game.</span></span>

### <a name="notifications-and-live-tiles"></a><span data-ttu-id="70357-672">通知とライブ タイル</span><span class="sxs-lookup"><span data-stu-id="70357-672">Notifications and live tiles</span></span>

<span data-ttu-id="70357-673">タイルとは、[スタート] メニュー上でゲームを表すものです。</span><span class="sxs-lookup"><span data-stu-id="70357-673">A tile is your game's representation on the Start Menu.</span></span> <span data-ttu-id="70357-674">タイルや通知によって、ゲームをプレイしていない場合でも、プレイヤーに興味を持たせることができます。</span><span class="sxs-lookup"><span data-stu-id="70357-674">Tiles and notifications can drive player interest even when they aren't currently playing your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-675">タイルとバッジの開発</span><span class="sxs-lookup"><span data-stu-id="70357-675">Developing tiles and badges</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt185606"><span data-ttu-id="70357-676">タイル、バッジ、通知</span><span class="sxs-lookup"><span data-stu-id="70357-676">Tiles, badges, and notifications</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-677">ライブ タイルと通知を示すサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-677">Sample illustrating live tiles and notifications</span></span></td>
        <td><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications"><span data-ttu-id="70357-678">通知のサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-678">Notifications sample</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-679">アダプティブ タイル テンプレート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-679">Adaptive tile templates (blog post)</span></span></td>
        <td><a href="http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/06/30/adaptive-tile-templates-schema-and-documentation.aspx"><span data-ttu-id="70357-680">アダプティブ タイル テンプレート - スキーマとドキュメント</span><span class="sxs-lookup"><span data-stu-id="70357-680">Adaptive Tile Templates - Schema and Documentation</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-681">タイルとバッジの設計</span><span class="sxs-lookup"><span data-stu-id="70357-681">Designing tiles and badges</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/hh465403"><span data-ttu-id="70357-682">タイルとバッジのガイドライン</span><span class="sxs-lookup"><span data-stu-id="70357-682">Guidelines for tiles and badges</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-683">ライブ タイル テンプレートを対話形式で開発するための Windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="70357-683">Windows 10 app for interactively developing live tile templates</span></span></td>
        <td><a href="https://www.microsoft.com/store/apps/9nblggh5xsl1"><span data-ttu-id="70357-684">Notifications Visualizer</span><span class="sxs-lookup"><span data-stu-id="70357-684">Notifications Visualizer</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-685">Visual Studio 用の UWP Tile Generator 拡張機能</span><span class="sxs-lookup"><span data-stu-id="70357-685">UWP Tile Generator extension for Visual Studio</span></span></td>
        <td><a href="https://visualstudiogallery.msdn.microsoft.com/09611e90-f3e8-44b7-9c83-18dba8275bb2"><span data-ttu-id="70357-686">1 つの画像を使用して必要なすべてのタイルを作成するためのツール</span><span class="sxs-lookup"><span data-stu-id="70357-686">Tool for creating all required tiles using single image</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-687">Visual Studio 用の UWP Tile Generator 拡張機能 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-687">UWP Tile Generator extension for Visual Studio (blog post)</span></span></td>
        <td><a href="https://blogs.windows.com/buildingapps/2016/02/15/uwp-tile-generator-extension-for-visual-studio/"><span data-ttu-id="70357-688">UWP Tile Generator ツールの使用に関するヒント</span><span class="sxs-lookup"><span data-stu-id="70357-688">Tips on using the UWP Tile Generator tool</span></span></a></td>
    </tr>
</table>
 

### <a name="enable-in-app-product-iap-purchases"></a><span data-ttu-id="70357-689">アプリ内製品 (IAP) 購入の有効化</span><span class="sxs-lookup"><span data-stu-id="70357-689">Enable in-app product (IAP) purchases</span></span>

<span data-ttu-id="70357-690">IAP (アプリ内製品) は、プレイヤーがゲーム内で購入できる補助アイテムです。</span><span class="sxs-lookup"><span data-stu-id="70357-690">An IAP (in-app product) is a supplementary item that players can purchase in-game.</span></span> <span data-ttu-id="70357-691">IAP には、新しいアドオン、ゲームのレベル、項目、その他のプレーヤーを楽しませるものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="70357-691">IAPs can be new add-ons, game levels, items, or anything else that your players might enjoy.</span></span> <span data-ttu-id="70357-692">適切に使用すると、IAP はゲームのエクスペリエンスを向上させると共に、収益の増加につながります。</span><span class="sxs-lookup"><span data-stu-id="70357-692">Used appropriately, IAPs can provide revenue while improving the game experience.</span></span> <span data-ttu-id="70357-693">ゲームの IAP は Windows デベロッパー センター ダッシュボードで定義して公開します。また、ゲームのコードでアプリ内購入を有効にします。</span><span class="sxs-lookup"><span data-stu-id="70357-693">You define and publish your game's IAPs through the Windows Dev Center dashboard, and enable in-app purchases in your game's code.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-694">永続的なアプリ内製品</span><span class="sxs-lookup"><span data-stu-id="70357-694">Durable in-app products</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt219684"><span data-ttu-id="70357-695">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="70357-695">Enable in-app product purchases</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-696">コンシューマブルなアプリ内製品</span><span class="sxs-lookup"><span data-stu-id="70357-696">Consumable in-app products</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt219683"><span data-ttu-id="70357-697">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="70357-697">Enable consumable in-app product purchases</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-698">アプリ内製品の詳細と申請</span><span class="sxs-lookup"><span data-stu-id="70357-698">In-app product details and submission</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt148551"><span data-ttu-id="70357-699">IAP の申請</span><span class="sxs-lookup"><span data-stu-id="70357-699">IAP submissions</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-700">IAP 売り上げとゲームの人口統計の監視</span><span class="sxs-lookup"><span data-stu-id="70357-700">Monitor IAP sales and demographics for your game</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt148538"><span data-ttu-id="70357-701">IAP 取得レポート</span><span class="sxs-lookup"><span data-stu-id="70357-701">IAP acquisitions report</span></span></a></td>
    </tr>
</table>
 

### <a name="debugging-performance-optimization-and-monitoring"></a><span data-ttu-id="70357-702">デバッグとパフォーマンスの最適化と監視</span><span class="sxs-lookup"><span data-stu-id="70357-702">Debugging, performance optimization, and monitoring</span></span>

<span data-ttu-id="70357-703">パフォーマンスを最適化するには、Windows 10 のゲーム モードを活用し、ハードウェアの機能を最大限に活用して、ゲーマーに可能な限りのゲーム エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-703">To optimize performance, take advantage of Game Mode in Windows 10 to provide your gamers with the best possible gaming experience by fully utilizing the capacity of their current hardware.</span></span>

<span data-ttu-id="70357-704">Windows Performance Toolkit (WPT) は、Windows オペレーティング システムやアプリケーションの詳しいパフォーマンス プロファイルを生成するための一連のパフォーマンス監視ツールです。</span><span class="sxs-lookup"><span data-stu-id="70357-704">The Windows Performance Toolkit (WPT) consists of performance monitoring tools that produce in-depth performance profiles of Windows operating systems and applications.</span></span> <span data-ttu-id="70357-705">これは、メモリ使用量を監視し、ゲームのパフォーマンスを向上させるために特に便利です。</span><span class="sxs-lookup"><span data-stu-id="70357-705">This is especially useful for monitoring memory usage and improving game performance.</span></span> <span data-ttu-id="70357-706">Windows Performance Toolkit は、Windows 10 SDK と Windows ADK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="70357-706">The Windows Performance Toolkit is included in the Windows 10 SDK and Windows ADK.</span></span> <span data-ttu-id="70357-707">このツールキットは、2 つの独立したツールで構成されています。Windows Performance Recorder (WPR) と Windows Performance Analyzer (WPA) です。</span><span class="sxs-lookup"><span data-stu-id="70357-707">This toolkit consists of two independent tools: Windows Performance Recorder (WPR) and Windows Performance Analyzer (WPA).</span></span> <span data-ttu-id="70357-708">[Windows Sysinternals](https://technet.microsoft.com/sysinternals/default) に含まれる ProcDump は、コマンドライン ユーティリティであり、CPU 使用量の急上昇を監視し、ゲームのクラッシュ時にダンプ ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="70357-708">ProcDump, which is part of [Windows Sysinternals](https://technet.microsoft.com/sysinternals/default), is a command-line utility that monitors CPU spikes and generates dump files during game crashes.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-709">コードのパフォーマンス テストを行う</span><span class="sxs-lookup"><span data-stu-id="70357-709">Performance test your code</span></span></td>
        <td><a href="https://www.visualstudio.com/team-services/cloud-load-testing/"><span data-ttu-id="70357-710">クラウド ベースのロード テスト</span><span class="sxs-lookup"><span data-stu-id="70357-710">Cloud based load testing</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-711">ゲーム デバイス情報を使用して Xbox 本体のタイプを取得する</span><span class="sxs-lookup"><span data-stu-id="70357-711">Get Xbox console type using Gaming Device Information</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt825235"><span data-ttu-id="70357-712">ゲーム デバイス情報</span><span class="sxs-lookup"><span data-stu-id="70357-712">Gaming Device Information</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-713">ゲーム モードの API の使用によるハードウェア リソースへの排他的または優先的なアクセスを使ったパフォーマンスの向上</span><span class="sxs-lookup"><span data-stu-id="70357-713">Improve performance by getting exclusive or priority access to hardware resources using Game Mode APIs</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt808808"><span data-ttu-id="70357-714">ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="70357-714">Game Mode</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-715">Windows 10 SDK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-715">Get Windows Performance Toolkit (WPT) from Windows 10 SDK</span></span></td>
        <td><a href="https://developer.microsoft.com/windows/downloads/windows-10-sdk"><span data-ttu-id="70357-716">Windows 10 SDK</span><span class="sxs-lookup"><span data-stu-id="70357-716">Windows 10 SDK</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-717">Windows ADK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-717">Get Windows Performance Toolkit (WPT) from Windows ADK</span></span></td>
        <td><a href="https://msdn.microsoft.com/windows/hardware/dn913721.aspx"><span data-ttu-id="70357-718">Windows ADK</span><span class="sxs-lookup"><span data-stu-id="70357-718">Windows ADK</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-719">Windows Performance Analyzer を使って応答しない UI のトラブルシューティングを行う (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-719">Troubleshoot unresponsible UI using Windows Performance Analyzer (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-156-Critical-Path-Analysis-with-Windows-Performance-Analyzer"><span data-ttu-id="70357-720">WPA を使ったクリティカル パスの分析</span><span class="sxs-lookup"><span data-stu-id="70357-720">Critical path analysis with WPA</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-721">Windows Performance Recorder を使ってメモリ使用量とメモリ リークを診断する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-721">Diagnose memory usage and leaks using Windows Performance Recorder (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-154-Memory-Footprint-and-Leaks"><span data-ttu-id="70357-722">メモリ使用量とリーク</span><span class="sxs-lookup"><span data-stu-id="70357-722">Memory footprint and leaks</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-723">ProcDump を取得する</span><span class="sxs-lookup"><span data-stu-id="70357-723">Get ProcDump</span></span></td>
        <td><a href="https://technet.microsoft.com/sysinternals/dd996900"><span data-ttu-id="70357-724">ProcDump</span><span class="sxs-lookup"><span data-stu-id="70357-724">ProcDump</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-725">ProcDump の使い方 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-725">Learn to use ProcDump (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-131-Windows-10-SDK"><span data-ttu-id="70357-726">ダンプ ファイルを作成するために ProcDump を構成する</span><span class="sxs-lookup"><span data-stu-id="70357-726">Configure ProcDump to create dump files</span></span></a></td>
    </tr>
</table>

### <a name="advanced-directx-techniques-and-concepts"></a><span data-ttu-id="70357-727">高度な DirectX の手法と概念</span><span class="sxs-lookup"><span data-stu-id="70357-727">Advanced DirectX techniques and concepts</span></span>

<span data-ttu-id="70357-728">DirectX の開発には微妙で複雑な部分があります。</span><span class="sxs-lookup"><span data-stu-id="70357-728">Some portions of DirectX development can be nuanced and complex.</span></span> <span data-ttu-id="70357-729">運用環境で、DirectX エンジンの詳細を掘り下げる必要がある場合や、難しいパフォーマンスの問題をデバッグする場合は、このセクションで紹介するリソースや情報が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="70357-729">When you get to the point in production where you need to dig down into the details of your DirectX engine, or debug difficult performance problems, the resources and information in this section can help.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-730">Windows の PIX</span><span class="sxs-lookup"><span data-stu-id="70357-730">PIX on Windows</span></span></td>
        <td><a href="https://blogs.msdn.microsoft.com/pix/2017/01/17/introducing-pix-on-windows-beta/"><span data-ttu-id="70357-731">Windows での DirectX 12 ゲームのパフォーマンスのチューニングとデバッグのツール</span><span class="sxs-lookup"><span data-stu-id="70357-731">Performance tuning and debugging tool for DirectX 12 on Windows</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-732">D3D12 開発のデバッグと検証のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-732">Debugging and validation tools for D3D12 development (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-003"><span data-ttu-id="70357-733">D3D12 パフォーマンス チューニングと PIX と GPU の検証を使ったデバッグ</span><span class="sxs-lookup"><span data-stu-id="70357-733">D3D12 Performance Tuning and Debugging with PIX and GPU Validation</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-734">グラフィックスとパフォーマンスの最適化 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-734">Optimizing graphics and performance (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Advanced-DirectX12-Graphics-and-Performance"><span data-ttu-id="70357-735">高度な DirectX 12 グラフィックスとパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="70357-735">Advanced DirectX 12 Graphics and Performance</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-736">DirectX グラフィックスのデバッグ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-736">DirectX graphics debugging (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Solve-the-Tough-Graphics-Problems-with-your-Game-Using-DirectX-Tools"><span data-ttu-id="70357-737">DirectX ツールを使用した、ゲームでのグラフィックスの困難な問題の解決</span><span class="sxs-lookup"><span data-stu-id="70357-737">Solve the tough graphics problems with your game using DirectX Tools</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-738">DirectX 12 をデバッグするための Visual Studio 2015 のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-738">Visual Studio 2015 tools for debugging DirectX 12 (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Series/ConnectOn-Demand/212"><span data-ttu-id="70357-739">Visual Studio 2015 の Windows 10 用 DirectX ツール</span><span class="sxs-lookup"><span data-stu-id="70357-739">DirectX tools for Windows 10 in Visual Studio 2015</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-740">Direct3D 12 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-740">Direct3D 12 programming guide</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821"><span data-ttu-id="70357-741">Direct3D 12 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-741">Direct3D 12 Programming Guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-742">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="70357-742">Combining DirectX and XAML</span></span></td>
        <td><a href="directx-and-xaml-interop.md"><span data-ttu-id="70357-743">DirectX と XAML の相互運用機能</span><span class="sxs-lookup"><span data-stu-id="70357-743">DirectX and XAML interop</span></span></a></td>
    </tr>
</table>

### <a name="high-dynamic-range-hdr-content-development"></a><span data-ttu-id="70357-744">ハイ ダイナミック レンジ (HDR) コンテンツの開発</span><span class="sxs-lookup"><span data-stu-id="70357-744">High dynamic range (HDR) content development</span></span>

<span data-ttu-id="70357-745">HDR のフル カラー機能を使用するゲーム コンテンツを構築します。</span><span class="sxs-lookup"><span data-stu-id="70357-745">Build game content that uses the full color capabilities of HDR.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-746">HDR の概要と色の概念 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-746">Introduction to HDR and color concepts (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/Build/2017/P4061"><span data-ttu-id="70357-747">HDR の照明と DirectX での高度な色</span><span class="sxs-lookup"><span data-stu-id="70357-747">Lighting up HDR and advanced color in DirectX</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-748">HDR コンテンツをレンダリングする方法と、現在のディスプレイが HDR コンテンツをサポートするかどうかを検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="70357-748">Learn how to render HDR content and detect whether the current display supports it</span></span></td>
        <td><a href="https://github.com/Microsoft/DirectX-Graphics-Samples/tree/master/Samples/UWP/D3D12HDR"><span data-ttu-id="70357-749">HDR サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-749">HDR sample</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-750">DirectX を使用して高度な色を作成および構成する</span><span class="sxs-lookup"><span data-stu-id="70357-750">Create and configure an advanced color using DirectX</span></span></td>
        <td><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/D2DAdvancedColorImages"><span data-ttu-id="70357-751">Direct2D の高度な色の画像のレンダリング サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-751">Direct2D advanced color image rendering sample</span></span></a></td>
    </tr>   
</table>


### <a name="globalization-and-localization"></a><span data-ttu-id="70357-752">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="70357-752">Globalization and localization</span></span>

<span data-ttu-id="70357-753">Windows プラットフォーム用の多言語対応ゲームを開発し、Microsoft の有力製品に組み込まれている地域と言語の機能について説明します。</span><span class="sxs-lookup"><span data-stu-id="70357-753">Develop world-ready games for the Windows platform and learn about the international features built into Microsoft’s top products.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-754">世界市場向けのゲームの準備</span><span class="sxs-lookup"><span data-stu-id="70357-754">Preparing your game for the global market</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt186453.aspx"><span data-ttu-id="70357-755">世界中のユーザーに対応する開発のガイドライン</span><span class="sxs-lookup"><span data-stu-id="70357-755">Guidelines when developing for a global audience</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-756">言語、文化、およびテクノロジの橋渡し</span><span class="sxs-lookup"><span data-stu-id="70357-756">Bridging languages, cultures, and technology</span></span></td>
        <td><a href="http://www.microsoft.com/Language/Default.aspx"><span data-ttu-id="70357-757">言語の規則および Microsoft の標準的な用語のオンライン リソース</span><span class="sxs-lookup"><span data-stu-id="70357-757">Online resource for language conventions and standard Microsoft terminology</span></span></a></td>
    </tr>
</table>

### <a name="security"></a><span data-ttu-id="70357-758">セキュリティ</span><span class="sxs-lookup"><span data-stu-id="70357-758">Security</span></span>

<span data-ttu-id="70357-759">ゲーマーが公平にプレイして競うことができる環境を作成します。</span><span class="sxs-lookup"><span data-stu-id="70357-759">Create an environment where your gamers can play and compete fairly.</span></span> <span data-ttu-id="70357-760">TruePlay に登録されているゲームは、保護されたプロセスで実行されるため、一般的な種類の攻撃が軽減されます。</span><span class="sxs-lookup"><span data-stu-id="70357-760">A game enrolled in TruePlay runs in a protected process which mitigates a class of common attacks.</span></span> <span data-ttu-id="70357-761">ゲーム監視システムも、一般的な不正行為を識別するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="70357-761">The game monitoring system also helps to identify common cheating scenarios.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-762">PC ゲーム内で不正行為を防止するためのツール</span><span class="sxs-lookup"><span data-stu-id="70357-762">Tools to combat cheating within PC games</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/mt808781"><span data-ttu-id="70357-763">TruePlay</span><span class="sxs-lookup"><span data-stu-id="70357-763">TruePlay</span></span></a></td>
    </tr>
</table>

## <a name="submitting-and-publishing-your-game"></a><span data-ttu-id="70357-764">ゲームの申請と公開</span><span class="sxs-lookup"><span data-stu-id="70357-764">Submitting and publishing your game</span></span>

<span data-ttu-id="70357-765">次のガイドと情報は、公開と申請のプロセスをできるだけスムーズに進めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="70357-765">The following guides and information help make the publishing and submission process as smooth as possible.</span></span>

### <a name="publishing"></a><span data-ttu-id="70357-766">公開</span><span class="sxs-lookup"><span data-stu-id="70357-766">Publishing</span></span>

<span data-ttu-id="70357-767">新しい統合 Windows デベロッパー センター ダッシュボードを使って、すべてのゲーム パッケージを公開し管理することができます。</span><span class="sxs-lookup"><span data-stu-id="70357-767">You'll use the new unified Windows Dev Center dashboard to publish and manage your game packages.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-768">Windows デベロッパー センターでのアプリの公開</span><span class="sxs-lookup"><span data-stu-id="70357-768">Windows Dev Center app publishing</span></span></td>
        <td><a href="https://dev.windows.com/publish"><span data-ttu-id="70357-769">Windows アプリの公開</span><span class="sxs-lookup"><span data-stu-id="70357-769">Publish Windows apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-770">Windows デベロッパー センターでの高度な公開 (GDN)</span><span class="sxs-lookup"><span data-stu-id="70357-770">Windows Dev Center advanced publishing (GDN)</span></span></td>
        <td><a href="https://developer.xboxlive.com/en-us/windows/documentation/Pages/home.aspx"><span data-ttu-id="70357-771">Windows デベロッパー センター ダッシュボードでの高度な公開ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-771">Windows Dev Center Dashboard advanced publishing guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-772">Azure Active Directory (AAD) を使用して、ユーザーをデベロッパー センター アカウントに追加する</span><span class="sxs-lookup"><span data-stu-id="70357-772">Use Azure Active Directory (AAD) to add users to your Dev Center account</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/publish/manage-account-users"><span data-ttu-id="70357-773">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="70357-773">Manage account users</span></span></a></td>
    </tr>   
    <tr>
        <td><span data-ttu-id="70357-774">ゲームの評価 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-774">Rating your game (blog post)</span></span></td>
        <td><a href="https://blogs.windows.com/buildingapps/2016/01/06/now-available-single-age-rating-system-to-simplify-app-submissions/"><span data-ttu-id="70357-775">IARC システムを使って年齢区分を割り当てるための単一のワークフロー</span><span class="sxs-lookup"><span data-stu-id="70357-775">Single workflow to assign age ratings using IARC system</span></span></a></td>
    </tr>
</table>

#### <a name="packaging-and-uploading"></a><span data-ttu-id="70357-776">パッケージ化とアップロード</span><span class="sxs-lookup"><span data-stu-id="70357-776">Packaging and uploading</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-777">ストリーミング インストールとオプション パッケージを使用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-777">Learn to use streaming install and optional packages (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/Build/2017/B8093"><span data-ttu-id="70357-778">次世代の UWP アプリの配布: 拡張可能で、ストリーミング可能な、コンポーネント化されたアプリの構築</span><span class="sxs-lookup"><span data-stu-id="70357-778">Nextgen UWP app distribution: Building extensible, stream-able, componentized apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-779">コンテンツの分割とグループ化によるストリーミング インストールの実現</span><span class="sxs-lookup"><span data-stu-id="70357-779">Divide and group content to enable streaming install</span></span></td>
        <td><a href="../packaging/streaming-install.md"><span data-ttu-id="70357-780">UWP アプリ ストリーミング インストール</span><span class="sxs-lookup"><span data-stu-id="70357-780">UWP App Streaming install</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-781">DLC ゲーム コンテンツのようなオプション パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="70357-781">Create optional packages like DLC game content</span></span></td>
        <td><a href="../packaging/optional-packages.md"><span data-ttu-id="70357-782">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="70357-782">Optional packages and related set authoring</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-783">UWP ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="70357-783">Package your UWP game</span></span></td>
        <td><a href="../packaging/index.md"><span data-ttu-id="70357-784">アプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="70357-784">Packaging apps</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-785">UWP DirectX ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="70357-785">Package your UWP DirectX game</span></span></td>
        <td><a href="package-your-windows-store-directx-game.md"><span data-ttu-id="70357-786">UWP DirectX ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="70357-786">Package your UWP DirectX game</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-787">サード パーティ開発者としてのゲームのパッケージ化 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="70357-787">Packaging your game as a 3rd party developer (blog post)</span></span></td>
        <td><a href="https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/"><span data-ttu-id="70357-788">発行元のストア アカウントにアクセスせずにアップロード可能なパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="70357-788">Create uploadable packages without publisher's store account access</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-789">MakeAppx を使用したアプリ パッケージとアプリ パッケージ バンドルの作成</span><span class="sxs-lookup"><span data-stu-id="70357-789">Creating app packages and app package bundles using MakeAppx</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool"><span data-ttu-id="70357-790">アプリ パッケージ ツール MakeAppx.exe を使用したパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="70357-790">Create packages using app packager tool MakeAppx.exe</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-791">SignTool を使用したファイルへのデジタル署名</span><span class="sxs-lookup"><span data-stu-id="70357-791">Signing your files digitally using SignTool</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/desktop/aa387764"><span data-ttu-id="70357-792">SignTool を使用した、ファイルへの署名とファイルの署名の確認</span><span class="sxs-lookup"><span data-stu-id="70357-792">Sign files and verify signatures in files using SignTool</span></span></a></td>
    </tr>    
    <tr>
        <td><span data-ttu-id="70357-793">ゲームのアップロードとバージョン管理</span><span class="sxs-lookup"><span data-stu-id="70357-793">Uploading and versioning your game</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt148542"><span data-ttu-id="70357-794">アプリ パッケージのアップロード</span><span class="sxs-lookup"><span data-stu-id="70357-794">Upload app packages</span></span></a></td>
    </tr>
</table>


### <a name="policies-and-certification"></a><span data-ttu-id="70357-795">ポリシーと認定</span><span class="sxs-lookup"><span data-stu-id="70357-795">Policies and certification</span></span>

<span data-ttu-id="70357-796">認定に関する問題によってゲームのリリースを延期しないでください。</span><span class="sxs-lookup"><span data-stu-id="70357-796">Don't let certification issues delay your game's release.</span></span> <span data-ttu-id="70357-797">ここでは、ポリシーと注意が必要な一般的な認定の問題を示します。</span><span class="sxs-lookup"><span data-stu-id="70357-797">Here are policies and common certification issues to be aware of.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-798">Microsoft Store アプリ開発者契約</span><span class="sxs-lookup"><span data-stu-id="70357-798">Microsoft Store App Developer Agreement</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/hh694058"><span data-ttu-id="70357-799">アプリ開発者契約</span><span class="sxs-lookup"><span data-stu-id="70357-799">App Developer Agreement</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-800">Microsoft Store でアプリを公開するためのポリシー</span><span class="sxs-lookup"><span data-stu-id="70357-800">Policies for publishing apps in the Microsoft Store</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/dn764944"><span data-ttu-id="70357-801">Microsoft Store ポリシー</span><span class="sxs-lookup"><span data-stu-id="70357-801">Microsoft Store Policies</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-802">一般的なアプリの認定の問題を回避する方法</span><span class="sxs-lookup"><span data-stu-id="70357-802">How to avoid some common app certification issues</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/jj657968"><span data-ttu-id="70357-803">一般的な認定エラーの回避</span><span class="sxs-lookup"><span data-stu-id="70357-803">Avoid common certification failures</span></span></a></td>
    </tr>
</table>
 

### <a name="store-manifest-storemanifestxml"></a><span data-ttu-id="70357-804">ストア マニフェスト (StoreManifest.xml)</span><span class="sxs-lookup"><span data-stu-id="70357-804">Store manifest (StoreManifest.xml)</span></span>

<span data-ttu-id="70357-805">ストア マニフェスト (StoreManifest.xml) は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。</span><span class="sxs-lookup"><span data-stu-id="70357-805">The store manifest (StoreManifest.xml) is an optional configuration file that can be included in your app package.</span></span> <span data-ttu-id="70357-806">ストア マニフェストには、AppxManifest.xml ファイルに含まれていないその他の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="70357-806">The store manifest provides additional features that are not part of the AppxManifest.xml file.</span></span> <span data-ttu-id="70357-807">たとえば、ターゲット デバイスが指定された DirectX の最小機能レベルまたは指定された最小システム メモリの条件を満たしていない場合に、ストア マニフェストを使ってゲームのインストールをブロックできます。</span><span class="sxs-lookup"><span data-stu-id="70357-807">For example, you can use the store manifest to block installation of your game if a target device doesn't have the specified minimum DirectX feature level, or the specified minimum system memory.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-808">ストア マニフェストのスキーマ</span><span class="sxs-lookup"><span data-stu-id="70357-808">Store manifest schema</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt617335"><span data-ttu-id="70357-809">StoreManifest のスキーマ (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="70357-809">StoreManifest schema (Windows 10)</span></span></a></td>
    </tr>
</table>
 

## <a name="game-lifecycle-management"></a><span data-ttu-id="70357-810">ゲームのライフサイクル管理</span><span class="sxs-lookup"><span data-stu-id="70357-810">Game lifecycle management</span></span>


<span data-ttu-id="70357-811">開発が終了し、ゲームを出荷しても、"ゲーム オーバー" というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="70357-811">After you've finished development and shipped your game, it's not "game over".</span></span> <span data-ttu-id="70357-812">バージョン 1 の開発は終了ですが、市場でのゲームの旅は始まったばかりです。</span><span class="sxs-lookup"><span data-stu-id="70357-812">You may be done with development on version one, but your game's journey in the marketplace has only just begun.</span></span> <span data-ttu-id="70357-813">使用状況やエラー レポートの監視、ユーザーからのフィードバックへの対応、ゲームの更新プログラムの公開という作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="70357-813">You'll want to monitor usage and error reporting, respond to user feedback, and publish updates to your game.</span></span>

### <a name="windows-dev-center-analytics-and-promotion"></a><span data-ttu-id="70357-814">Windows デベロッパー センターの分析と販売促進</span><span class="sxs-lookup"><span data-stu-id="70357-814">Windows Dev Center analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-815">デベロッパー センター アプリ</span><span class="sxs-lookup"><span data-stu-id="70357-815">Dev Center App</span></span></td>
        <td><a href="https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws"><span data-ttu-id="70357-816">公開済みアプリのパフォーマンスを表示するデベロッパー センター Windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="70357-816">Dev Center Windows 10 app to view performance of your published apps</span></span></a></td>
    </tr>  
    <tr>
        <td><span data-ttu-id="70357-817">Windows デベロッパー センターの分析</span><span class="sxs-lookup"><span data-stu-id="70357-817">Windows Dev Center analytics</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt148522"><span data-ttu-id="70357-818">アプリのパフォーマンスの分析</span><span class="sxs-lookup"><span data-stu-id="70357-818">Analyze app performance</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-819">ゲーム内で Xbox の機能を使用してユーザーを引き付ける方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="70357-819">Learn how your customers are engaging with the Xbox features in your game</span></span></td>
        <td><a href="../publish/xbox-analytics-report.md"><span data-ttu-id="70357-820">Xbox 分析レポート</span><span class="sxs-lookup"><span data-stu-id="70357-820">Xbox analytics report</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-821">顧客のレビューへの返信</span><span class="sxs-lookup"><span data-stu-id="70357-821">Responding to customer reviews</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt148546"><span data-ttu-id="70357-822">顧客のレビューに返信する</span><span class="sxs-lookup"><span data-stu-id="70357-822">Respond to customer reviews</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-823">ゲームの販売を促進する方法</span><span class="sxs-lookup"><span data-stu-id="70357-823">Ways to promote your game</span></span></td>
        <td><a href="https://dev.windows.com/store-promotion"><span data-ttu-id="70357-824">アプリの販売促進</span><span class="sxs-lookup"><span data-stu-id="70357-824">Promote your apps</span></span></a></td>
    </tr>
</table>
 

### <a name="visual-studio-application-insights"></a><span data-ttu-id="70357-825">Visual Studio Application Insights</span><span class="sxs-lookup"><span data-stu-id="70357-825">Visual Studio Application Insights</span></span>

<span data-ttu-id="70357-826">Visual Studio Application Insights は、公開されたゲームのパフォーマンス、利用統計情報、および使用状況の分析を提供します。</span><span class="sxs-lookup"><span data-stu-id="70357-826">Visual Studio Application Insights provides performance, telemetry, and usage analytics for your published game.</span></span> <span data-ttu-id="70357-827">Application Insights は、リリース後のゲームの問題の検出と解決、使用状況の継続的な監視と向上、プレイヤーがゲームを操作する方法の把握に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="70357-827">Application Insights helps you detect and solve issues after your game is released, continuously monitor and improve usage, and understand how players are continuing to interact with your game.</span></span> <span data-ttu-id="70357-828">Application Insights は、アプリに SDK を追加することで機能し、[Azure ポータル](http://portal.azure.com/)に利用統計情報を送信します。</span><span class="sxs-lookup"><span data-stu-id="70357-828">Application Insights works by adding an SDK into your app, which sends telemetry to the [Azure portal](http://portal.azure.com/).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-829">アプリケーションのパフォーマンスと使用状況の分析</span><span class="sxs-lookup"><span data-stu-id="70357-829">Application performance and usage analytics</span></span></td>
        <td><a href="https://azure.microsoft.com/documentation/articles/app-insights-get-started/"><span data-ttu-id="70357-830">Visual Studio Application Insights</span><span class="sxs-lookup"><span data-stu-id="70357-830">Visual Studio Application Insights</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-831">Windows アプリでの Application Insights の有効化</span><span class="sxs-lookup"><span data-stu-id="70357-831">Enable Application Insights in Windows apps</span></span></td>
        <td><a href="https://azure.microsoft.com/documentation/articles/app-insights-windows-get-started/"><span data-ttu-id="70357-832">Windows Phone およびストア アプリ向けの Application Insights</span><span class="sxs-lookup"><span data-stu-id="70357-832">Application Insights for Windows Phone and Store apps</span></span></a></td>
    </tr>
</table>


### <a name="third-party-solutions-for-analytics-and-promotion"></a><span data-ttu-id="70357-833">分析とプロモーションのためのサード パーティ ソリューション</span><span class="sxs-lookup"><span data-stu-id="70357-833">Third party solutions for analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-834">GameAnalytics を使用してプレイヤーの動作を理解する</span><span class="sxs-lookup"><span data-stu-id="70357-834">Understand player behavior using GameAnalytics</span></span></td>
        <td><a href="http://www.gameanalytics.com/"><span data-ttu-id="70357-835">GameAnalytics</span><span class="sxs-lookup"><span data-stu-id="70357-835">GameAnalytics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-836">UWP ゲームを Google Analytics に接続する</span><span class="sxs-lookup"><span data-stu-id="70357-836">Connect your UWP game to Google Analytics</span></span></td>
        <td><a href="https://github.com/dotnet/windows-sdk-for-google-analytics"><span data-ttu-id="70357-837">Google Analytics 向けの Windows SDK を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-837">Get Windows SDK for Google Analytics</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-838">Google Analytics で Windows SDK を利用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-838">Learn how to use Windows SDK for Google Analytics (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-the-Windows-SDK-for-Google-Analytics"><span data-ttu-id="70357-839">Google Analytics 向けの Windows SDK の概要</span><span class="sxs-lookup"><span data-stu-id="70357-839">Getting started with Windows SDK for Google Analytics</span></span></a></td>
    </tr>    
    <tr>
        <td><span data-ttu-id="70357-840">Facebook のアプリ インストール広告を使って Facebook ユーザー向けにゲームのプロモーションを行う</span><span class="sxs-lookup"><span data-stu-id="70357-840">Use Facebook App Installs Ads to promote your game to Facebook users</span></span></td>
        <td><a href="https://github.com/Microsoft/winsdkfb"><span data-ttu-id="70357-841">Windows SDK for Facebook を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-841">Get Windows SDK for Facebook</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-842">Facebook のアプリ インストール広告の使用方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-842">Learn how to use Facebook App Installs Ads (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-Facebook-App-Install-Ads"><span data-ttu-id="70357-843">Windows SDK for Facebook の概要</span><span class="sxs-lookup"><span data-stu-id="70357-843">Getting started with Windows SDK for Facebook</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-844">Vungle を使用してゲームにビデオ広告を追加する</span><span class="sxs-lookup"><span data-stu-id="70357-844">Use Vungle to add video ads into your games</span></span></td>
        <td><a href="https://v.vungle.com/sdk"><span data-ttu-id="70357-845">Windows SDK for Vungle を入手する</span><span class="sxs-lookup"><span data-stu-id="70357-845">Get Windows SDK for Vungle</span></span></a></td>
    </tr>
</table>
 

### <a name="creating-and-managing-content-updates"></a><span data-ttu-id="70357-846">コンテンツの更新プログラムの作成と管理</span><span class="sxs-lookup"><span data-stu-id="70357-846">Creating and managing content updates</span></span>

<span data-ttu-id="70357-847">公開されたゲームを更新するには、大きいバージョン番号を持つ新しいアプリ パッケージを申請します。</span><span class="sxs-lookup"><span data-stu-id="70357-847">To update your published game, submit a new app package with a higher version number.</span></span> <span data-ttu-id="70357-848">このパッケージの申請と認定が終了すると、自動的にユーザーに更新プログラムとして公開されます。</span><span class="sxs-lookup"><span data-stu-id="70357-848">After the package makes its way through submission and certification, it will automatically be available to customers as an update.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-849">ゲームの更新とバージョン管理</span><span class="sxs-lookup"><span data-stu-id="70357-849">Updating and versioning your game</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt188602"><span data-ttu-id="70357-850">パッケージ バージョンの番号付け</span><span class="sxs-lookup"><span data-stu-id="70357-850">Package version numbering</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-851">ゲームのパッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="70357-851">Game package management guidance</span></span></td>
        <td><a href="https://msdn.microsoft.com/library/windows/apps/mt188602"><span data-ttu-id="70357-852">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="70357-852">Guidance for app package management</span></span></a></td>
    </tr>
</table>


## <a name="adding-xbox-live-to-your-game"></a><span data-ttu-id="70357-853">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="70357-853">Adding Xbox Live to your game</span></span>

<span data-ttu-id="70357-854">Xbox Live は、世界中の何百万ものゲーマーを結びつける最高のゲーミング ネットワークです。</span><span class="sxs-lookup"><span data-stu-id="70357-854">Xbox Live is a premier gaming network that connects millions of gamers across the world.</span></span> <span data-ttu-id="70357-855">開発者は、Xbox Live プレゼンス、ランキング、クラウド保存、ゲーム ハブ、クラブ、パーティー チャット、ゲーム DVR など、ゲームの対象ユーザーを組織的に拡大できる Xbox Live の機能にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="70357-855">Developers gain access to Xbox Live features that can organically grow their game’s audience, including Xbox Live presence, Leaderboards, Cloud Saves, Game Hubs, Clubs, Party Chat, Game DVR, and more.</span></span>

> [!Note]
> <span data-ttu-id="70357-856">Xbox Live 対応のタイトルを開発する場合、いくつかのオプションを利用できます。</span><span class="sxs-lookup"><span data-stu-id="70357-856">If you would like to develop Xbox Live enabled titles, there are several options are available to you.</span></span> <span data-ttu-id="70357-857">さまざまなプログラムについて詳しくは、「[開発者プログラムの概要](../xbox-live/developer-program-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="70357-857">For info about the various programs, see [Developer program overview](../xbox-live/developer-program-overview.md).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-858">Xbox Live の概要</span><span class="sxs-lookup"><span data-stu-id="70357-858">Xbox Live overview</span></span></td>
        <td><a href="../xbox-live/index.md"><span data-ttu-id="70357-859">Xbox Live 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="70357-859">Xbox Live developer guide</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-860">プログラムによって利用できる機能を理解する</span><span class="sxs-lookup"><span data-stu-id="70357-860">Understand which features are available depending on program</span></span></td>
        <td><a href="../xbox-live/developer-program-overview.md#feature-table"><span data-ttu-id="70357-861">開発者プログラムの概要: 機能表</span><span class="sxs-lookup"><span data-stu-id="70357-861">Developer program overview: Feature table</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-862">Xbox Live ゲーム開発に役立つリソースへのリンク</span><span class="sxs-lookup"><span data-stu-id="70357-862">Links to useful resources for developing Xbox Live games</span></span></td>
        <td><a href="../xbox-live/xbox-live-resources.md"><span data-ttu-id="70357-863">Xbox Live リソース</span><span class="sxs-lookup"><span data-stu-id="70357-863">Xbox Live resources</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-864">Xbox Live サービスから情報を取得する方法</span><span class="sxs-lookup"><span data-stu-id="70357-864">Learn how to get info from Xbox Live services</span></span></td>
        <td><a href="../xbox-live/introduction-to-xbox-live-apis.md"><span data-ttu-id="70357-865">Xbox Live API の概要</span><span class="sxs-lookup"><span data-stu-id="70357-865">Introduction to Xbox Live APIs</span></span></a></td>
    </tr>
</table>


### <a name="for-developers-in-the-xbox-live-creators-program"></a><span data-ttu-id="70357-866">Xbox Live クリエーターズ プログラム開発者向け</span><span class="sxs-lookup"><span data-stu-id="70357-866">For developers in the Xbox Live Creators Program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-867">概要</span><span class="sxs-lookup"><span data-stu-id="70357-867">Overview</span></span></td>
        <td><a href="../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md"><span data-ttu-id="70357-868">Xbox Live クリエーターズ プログラムの概要</span><span class="sxs-lookup"><span data-stu-id="70357-868">Get started with the Xbox Live Creators Program</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-869">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="70357-869">Add Xbox Live to your game</span></span></td>
        <td><a href="../xbox-live/get-started-with-creators/creators-step-by-step-guide.md"><span data-ttu-id="70357-870">Xbox Live クリエーターズ プログラムを統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-870">Step by step guide to integrate Xbox Live Creators Program</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-871">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="70357-871">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td><a href="../xbox-live/get-started-with-creators/develop-creators-title-with-unity.md"><span data-ttu-id="70357-872">Unity ゲーム エンジンを使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する</span><span class="sxs-lookup"><span data-stu-id="70357-872">Get started developing an Xbox Live Creators Program title with the Unity game engine</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-873">開発サンドボックスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="70357-873">Set up your development sandbox</span></span></td>
        <td><a href="../xbox-live/get-started-with-creators/xbox-live-sandboxes-creators.md"><span data-ttu-id="70357-874">Xbox Live のサンドボックスの概要</span><span class="sxs-lookup"><span data-stu-id="70357-874">Xbox Live sandboxes introduction</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-875">テスト用のアカウントを設定する</span><span class="sxs-lookup"><span data-stu-id="70357-875">Set up accounts for testing</span></span></td>
        <td><a href="../xbox-live/get-started-with-creators/authorize-xbox-live-accounts.md"><span data-ttu-id="70357-876">テスト環境で Xbox Live アカウントを承認する</span><span class="sxs-lookup"><span data-stu-id="70357-876">Authorize Xbox Live accounts in your test environment</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-877">Xbox Live クリエーターズ プログラム向けサンプル</span><span class="sxs-lookup"><span data-stu-id="70357-877">Samples for Xbox Live Creators Program</span></span></td>
        <td><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK"><span data-ttu-id="70357-878">クリエーターズ プログラム開発者向けのコード サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-878">Code samples for Creators Program developers</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-879">クロスプラット フォームの Xbox Live エクスペリエンスを UWP ゲームに統合する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-879">Learn how to integrate cross-platform Xbox Live experiences in UWP games (video)</span></span></td>
        <td><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-005"><span data-ttu-id="70357-880">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="70357-880">Xbox Live Creators Program</span></span></a></td>
    </tr>  
</table>

### <a name="for-managed-partners-and-developers-in-the-idxbox-program"></a><span data-ttu-id="70357-881">対象パートナーおよび ID@Xbox プログラムの開発者向け</span><span class="sxs-lookup"><span data-stu-id="70357-881">For managed partners and developers in the ID@Xbox program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-882">概要</span><span class="sxs-lookup"><span data-stu-id="70357-882">Overview</span></span></td>
        <td><a href="../xbox-live/get-started-with-partner/get-started-with-xbox-live-partner.md"><span data-ttu-id="70357-883">対象パートナーまたは ID 開発者として Xbox Live の利用を開始する</span><span class="sxs-lookup"><span data-stu-id="70357-883">Get started with Xbox Live as a managed partner or an ID developer</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-884">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="70357-884">Add Xbox Live to your game</span></span></td>
        <td><a href="../xbox-live/get-started-with-partner/partners-step-by-step-guide.md"><span data-ttu-id="70357-885">対象パートナーおよび ID メンバー向けに Xbox Live を統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="70357-885">Step by step guide to integrate Xbox Live for managed partners and ID members</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-886">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="70357-886">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td><a href="../xbox-live/get-started-with-partner/partner-unity-uwp-il2cpp.md"><span data-ttu-id="70357-887">ID および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="70357-887">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID and managed partners</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-888">開発サンドボックスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="70357-888">Set up your development sandbox</span></span></td>
        <td><a href="../xbox-live/get-started-with-partner/advanced-xbox-live-sandboxes.md"><span data-ttu-id="70357-889">高度な Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="70357-889">Advanced Xbox Live sandboxes</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-890">Xbox Live を使うためのゲームの要件 (GDN)</span><span class="sxs-lookup"><span data-stu-id="70357-890">Requirements for games that use Xbox Live (GDN)</span></span></td>
        <td><a href="http://go.microsoft.com/fwlink/?LinkId=533217"><span data-ttu-id="70357-891">Xbox Live on Windows 10 の Xbox の要件</span><span class="sxs-lookup"><span data-stu-id="70357-891">Xbox Requirements for Xbox Live on Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-892">サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-892">Samples</span></span></td>
        <td><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK"><span data-ttu-id="70357-893">ID@Xbox 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="70357-893">Code samples for ID@Xbox developers</span></span></a></td>
    </tr>  
    <tr>
        <td><span data-ttu-id="70357-894">Xbox Live のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-894">Overview of Xbox Live game development (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-with-Xbox-Live-for-Windows-10"><span data-ttu-id="70357-895">Windows 10 用の Xbox Live を使った開発</span><span class="sxs-lookup"><span data-stu-id="70357-895">Developing with Xbox Live for Windows 10</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-896">クロス プラットフォーム マッチメイキング (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-896">Cross-platform matchmaking (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Xbox-Live-Multiplayer-Introducing-services-for-cross-platform-matchmaking-and-gameplay"><span data-ttu-id="70357-897">Xbox Live マルチプレイヤー: クロス プラットフォーム マッチメイキングとゲームプレイのサービスの紹介</span><span class="sxs-lookup"><span data-stu-id="70357-897">Xbox Live Multiplayer: Introducing services for cross-platform matchmaking and gameplay</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-898">Fable Legends でのクロス デバイスのゲームプレイ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-898">Cross-device gameplay in Fable Legends (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Fable-Legends-Cross-device-Gameplay-with-Xbox-Live"><span data-ttu-id="70357-899">Fable Legends: Xbox Live によるクロス デバイス ゲームプレイ</span><span class="sxs-lookup"><span data-stu-id="70357-899">Fable Legends: Cross-device Gameplay with Xbox Live</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-900">Xbox Live の統計情報や達成度 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-900">Xbox Live stats and achievements (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Best-Practices-for-Leveraging-Cloud-Based-User-Stats-and-Achievements-in-Xbox-Live"><span data-ttu-id="70357-901">クラウド ベースのユーザーの統計情報と Xbox Live での達成度の活用のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="70357-901">Best Practices for Leveraging Cloud-Based User Stats and Achievements in Xbox Live</span></span></a></td>
    </tr>
</table>


## <a name="additional-resources"></a><span data-ttu-id="70357-902">その他の情報</span><span class="sxs-lookup"><span data-stu-id="70357-902">Additional resources</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="70357-903">ゲーム開発ビデオ</span><span class="sxs-lookup"><span data-stu-id="70357-903">Game development videos</span></span></td>
        <td><a href="https://docs.microsoft.com/windows/uwp/gaming/game-development-videos"><span data-ttu-id="70357-904">GDC や //build などの主要なカンファレンスのビデオ</span><span class="sxs-lookup"><span data-stu-id="70357-904">Videos from major conferences like GDC and //build</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-905">インディーズ ゲーム開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-905">Indie game development (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/New-Opportunities-for-Independent-Developers"><span data-ttu-id="70357-906">個人開発者のための新しい機会</span><span class="sxs-lookup"><span data-stu-id="70357-906">New Opportunities for Independent Developers</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-907">マルチコア モバイル デバイスに関する考慮事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-907">Considerations for multi-core mobile devices (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/Sustained-gaming-performance-in-multi-core-mobile-devices"><span data-ttu-id="70357-908">マルチコア モバイル デバイスでのゲームのパフォーマンスの維持</span><span class="sxs-lookup"><span data-stu-id="70357-908">Sustained Gaming Performance in multi-core mobile devices</span></span></a></td>
    </tr>
    <tr>
        <td><span data-ttu-id="70357-909">Windows 10 デスクトップ ゲームの開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="70357-909">Developing Windows 10 desktop games (video)</span></span></td>
        <td><a href="http://channel9.msdn.com/Events/GDC/GDC-2015/PC-Games-for-Windows-10"><span data-ttu-id="70357-910">Windows 10 向け PC ゲーム</span><span class="sxs-lookup"><span data-stu-id="70357-910">PC Games for Windows 10</span></span></a></td>
    </tr>
</table>



 

 

 
