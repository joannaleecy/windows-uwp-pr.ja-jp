---
author: joannaleecy
title: "Windows 10 ゲーム開発ガイド"
description: "ユニバーサル Windows プラットフォーム (UWP) ゲーム開発のためのリソースや情報を網羅したガイドです。"
ms.assetid: 6061F498-96A8-44EF-9711-68AE5A1218C9
ms.author: joanlee
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム、ゲーム開発"
ms.openlocfilehash: f84f33f4e30391624ae8d2615cb9c27442e168fb
ms.sourcegitcommit: 63c815f8c6665872987b5410cabf324f2b7e3c7c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/10/2017
---
# <a name="windows-10-game-development-guide"></a><span data-ttu-id="c8315-104">Windows 10 ゲーム開発ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-104">Windows 10 game development guide</span></span>


<span data-ttu-id="c8315-105">Windows 10 ゲーム開発ガイドへようこそ。</span><span class="sxs-lookup"><span data-stu-id="c8315-105">Welcome to the Windows 10 game development guide!</span></span>

<span data-ttu-id="c8315-106">このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に必要なリソースと情報を網羅したコレクションを提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-106">This guide provides an end-to-end collection of the resources and information you'll need to develop a Universal Windows Platform (UWP) game.</span></span> <span data-ttu-id="c8315-107">このガイドの英語 (米国) 版は [PDF](http://download.microsoft.com/download/3/E/8/3E8F6376-D239-41A3-989C-DA1494C0024D/Windev_Game_Dev_Guide_May_2017.pdf) 形式で利用できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-107">An English (US) version of this guide is available in [PDF](http://download.microsoft.com/download/3/E/8/3E8F6376-D239-41A3-989C-DA1494C0024D/Windev_Game_Dev_Guide_May_2017.pdf) format.</span></span>

## <a name="introduction-to-game-development-for-the-universal-windows-platform-uwp"></a><span data-ttu-id="c8315-108">ユニバーサル Windows プラットフォーム (UWP) 用ゲーム開発の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-108">Introduction to game development for the Universal Windows Platform (UWP)</span></span>


<span data-ttu-id="c8315-109">Windows 10 ゲームを作成すると、スマートフォンから PC、Xbox One にいたる数百万人のプレイヤーにゲームを提供するチャンスを得られます。</span><span class="sxs-lookup"><span data-stu-id="c8315-109">When you create a Windows 10 game, you have the opportunity to reach millions of players worldwide across phone, PC, and Xbox One.</span></span> <span data-ttu-id="c8315-110">Windows の Xbox、Xbox Live、クロス デバイス マルチプレイヤー、すばらしいゲーム コミュニティ、ユニバーサル Windows プラットフォーム (UWP) や DirectX 12 などの強力な新機能により、Windows 10 ゲームは、あらゆる世代やジャンルのプレイヤーを楽しませるでしょう。</span><span class="sxs-lookup"><span data-stu-id="c8315-110">With Xbox on Windows, Xbox Live, cross-device multiplayer, an amazing gaming community, and powerful new features like the Universal Windows Platform (UWP) and DirectX 12, Windows 10 games thrill players of all ages and genres.</span></span> <span data-ttu-id="c8315-111">新しいユニバーサル Windows プラットフォーム (UWP) は、スマートフォン、PC、Xbox One 用の共通 API と、各デバイスのエクスペリエンスに合わせてゲームをカスタマイズするツールやオプションによって、Windows 10 デバイスでのゲームの互換性を実現します。</span><span class="sxs-lookup"><span data-stu-id="c8315-111">The new Universal Windows Platform (UWP) delivers compatibility for your game across Windows 10 devices with a common API for phone, PC, and Xbox One, along with tools and options to tailor your game to each device experience.</span></span>

<span data-ttu-id="c8315-112">このガイドでは、ゲームの開発に役立つさまざまなリソースや情報を網羅して提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-112">This guide provides an end-to-end collection of information and resources that will help you as you develop your game.</span></span> <span data-ttu-id="c8315-113">必要なときに情報を検索する場所がわかるように、各セクションはゲームの開発の各段階に従って編成されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-113">The sections are organized according to the stages of game development, so you'll know where to look for information when you need it.</span></span>

<span data-ttu-id="c8315-114">最初に、「[ゲーム開発に関するリソース](#game-development-resources)」セクションでは、ゲームの作成時に役立つドキュメント、プログラム、その他のリソースの大まかな概要を示します。</span><span class="sxs-lookup"><span data-stu-id="c8315-114">To get started, the [Game development resources](#game-development-resources) section provides a high-level survey of documentation, programs, and other resources that are helpful when creating a game.</span></span>

<span data-ttu-id="c8315-115">このガイドは、Windows 10 ゲーム開発に関する新しいリソースや資料が利用可能になると更新されます。</span><span class="sxs-lookup"><span data-stu-id="c8315-115">This guide will be updated as additional Windows 10 game development resources and material become available.</span></span>  

## <a name="game-development-resources"></a><span data-ttu-id="c8315-116">ゲーム開発に関するリソース</span><span class="sxs-lookup"><span data-stu-id="c8315-116">Game development resources</span></span>

<span data-ttu-id="c8315-117">ドキュメントから、開発者向けのプログラム、フォーラム、ブログ、サンプルまで、ゲーム開発に役立つ多くのリソースが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-117">From documentation to developer programs, forums, blogs, and samples, there are many resources available to help you on your game development journey.</span></span> <span data-ttu-id="c8315-118">ここでは、Windows 10 ゲームの開発を始めるにあたって役立つリソースをまとめています。</span><span class="sxs-lookup"><span data-stu-id="c8315-118">Here's a roundup of resources to know about as you begin developing your Windows 10 game.</span></span>

> [!Note]
> <span data-ttu-id="c8315-119">一部の機能は、さまざまなプログラムで管理されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-119">Some features are managed through various programs.</span></span> <span data-ttu-id="c8315-120">このガイドでは幅広いリソースを取り上げているため、参加しているプログラムや特定の開発の役割によっては、一部のリソースにアクセスできない場合があります。</span><span class="sxs-lookup"><span data-stu-id="c8315-120">This guide covers a broad range of resources, so you may find that some resources are inaccessible depending on the program you are in or your specific development role.</span></span> <span data-ttu-id="c8315-121">developer.xboxlive.com、forums.xboxlive.com、xdi.xboxlive.com、Game Developer Network (GDN) に解決されるリンクなどです。</span><span class="sxs-lookup"><span data-stu-id="c8315-121">Examples are links that resolve to developer.xboxlive.com, forums.xboxlive.com, xdi.xboxlive.com, or the Game Developer Network (GDN).</span></span> <span data-ttu-id="c8315-122">Microsoft との提携について詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8315-122">For information about partnering with Microsoft, see [Developer Programs](#developer-programs).</span></span>


### <a name="game-development-documentation"></a><span data-ttu-id="c8315-123">ゲーム開発に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-123">Game development documentation</span></span>

<span data-ttu-id="c8315-124">このガイド全体を通して、タスク、テクノロジ、ゲームの開発の段階ごとに整理された、関連ドキュメントへのディープ リンクを示しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-124">Throughout this guide, you'll find deep links to relevant documentation—organized by task, technology, and stage of game development.</span></span> <span data-ttu-id="c8315-125">利用可能なドキュメントのさまざまなビューを提供するために、Windows 10 ゲーム開発用の主要なドキュメント ポータルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="c8315-125">To give you a broad view of what's available, here are the main documentation portals for Windows 10 game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-126">Windows デベロッパー センターのメイン ポータル</span><span class="sxs-lookup"><span data-stu-id="c8315-126">Windows Dev Center main portal</span></span></td>
        <td>[<span data-ttu-id="c8315-127">Windows デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="c8315-127">Windows Dev Center</span></span>](https://dev.windows.com)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-128">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-128">Developing Windows apps</span></span></td>
        <td>[<span data-ttu-id="c8315-129">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-129">Develop Windows apps</span></span>](https://dev.windows.com/develop)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-130">ユニバーサル Windows プラットフォーム アプリの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-130">Universal Windows Platform app development</span></span></td>
        <td>[<span data-ttu-id="c8315-131">Windows 10 アプリに関するハウツー ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-131">How-to guides for Windows 10 apps</span></span>](https://msdn.microsoft.com/library/windows/apps/mt244352)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-132">UWP ゲームに関する使い方ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-132">How-to guides for UWP games</span></span></td>
        <td>[<span data-ttu-id="c8315-133">ゲームと DirectX</span><span class="sxs-lookup"><span data-stu-id="c8315-133">Games and DirectX</span></span>](index.md) </td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-134">DirectX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="c8315-134">DirectX reference and overviews</span></span></td>
        <td>[<span data-ttu-id="c8315-135">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="c8315-135">DirectX Graphics and Gaming</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-136">ゲームのための Azure</span><span class="sxs-lookup"><span data-stu-id="c8315-136">Azure for gaming</span></span></td>
        <td>[<span data-ttu-id="c8315-137">Azure を使ったゲームの構築とスケーリング</span><span class="sxs-lookup"><span data-stu-id="c8315-137">Build and scale your games using Azure</span></span>](https://azure.microsoft.com/solutions/gaming/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-138">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="c8315-138">UWP on Xbox One</span></span></td>
        <td>[<span data-ttu-id="c8315-139">Xbox One の UWP アプリの構築</span><span class="sxs-lookup"><span data-stu-id="c8315-139">Building UWP apps on Xbox One</span></span>](https://msdn.microsoft.com/windows/uwp/xbox-apps/index)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-140">HoloLens の UWP</span><span class="sxs-lookup"><span data-stu-id="c8315-140">UWP on HoloLens</span></span></td>
        <td>[<span data-ttu-id="c8315-141">HoloLens の UWP アプリの構築</span><span class="sxs-lookup"><span data-stu-id="c8315-141">Building UWP apps on HoloLens</span></span>](https://developer.microsoft.com/windows/mixed-reality/development_overview)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-142">Xbox Live に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-142">Xbox Live documentation</span></span></td>
        <td>[<span data-ttu-id="c8315-143">Xbox Live 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-143">Xbox Live developer guide</span></span>](../xbox-live/index.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-144">Xbox One 開発者向けドキュメント (GDN)</span><span class="sxs-lookup"><span data-stu-id="c8315-144">Xbox One developer documentation (GDN)</span></span></td>
        <td>[<span data-ttu-id="c8315-145">Xbox One XDK ドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-145">Xbox One XDK documentation</span></span>](https://developer.xboxlive.com/en-us/platform/development/documentation/Pages/home.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-146">Xbox One 開発者向けホワイト ペーパー (GDN)</span><span class="sxs-lookup"><span data-stu-id="c8315-146">Xbox One developer whitepapers (GDN)</span></span></td>
        <td>[<span data-ttu-id="c8315-147">ホワイト ペーパー</span><span class="sxs-lookup"><span data-stu-id="c8315-147">White Papers</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Pages/WhitePapers.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-148">Mixer の対話機能のドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-148">Mixer Interactive documentation</span></span></td>
        <td>[<span data-ttu-id="c8315-149">ゲームへの対話機能の追加</span><span class="sxs-lookup"><span data-stu-id="c8315-149">Add interactivity to your game</span></span>](https://dev.mixer.com/reference/interactive/index.html)</td>
    </tr>        
</table>

### <a name="windows-dev-center"></a><span data-ttu-id="c8315-150">Windows デベロッパー センター</span><span class="sxs-lookup"><span data-stu-id="c8315-150">Windows Dev Center</span></span>

<span data-ttu-id="c8315-151">Windows ゲームの公開に向けての最初の一歩は、Windows デベロッパー センターで開発者アカウントを登録することです。</span><span class="sxs-lookup"><span data-stu-id="c8315-151">Registering a developer account on the Windows Dev Center is the first step towards publishing your Windows game.</span></span> <span data-ttu-id="c8315-152">開発者アカウントでは、ゲームの名前を予約することや、すべての Windows デバイスに対応する無料ゲームと有料ゲームを Windows ストアに提出することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-152">A developer account lets you reserve your game's name and submit free or paid games to the Windows Store for all Windows devices.</span></span> <span data-ttu-id="c8315-153">開発者アカウントを使って、ゲームとゲーム内製品を管理したり、詳細な分析を取得したり、世界中のプレイヤーに優れたエクスペリエンスを提供するサービスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-153">Use your developer account to manage your game and in-game products, get detailed analytics, and enable services that create great experiences for your players around the world.</span></span> 

<span data-ttu-id="c8315-154">さらにマイクロソフトでは、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-154">Microsoft also offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="c8315-155">デベロッパー センター アカウントに登録する前に、他に適切なプログラムがあるかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8315-155">We recommend seeing if any are right for you before registering for a Dev Center account.</span></span> <span data-ttu-id="c8315-156">詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8315-156">For more info, go to [Developer programs](#developer-programs)</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-157">開発者アカウントの登録</span><span class="sxs-lookup"><span data-stu-id="c8315-157">Register a developer account</span></span></td>
        <td>[<span data-ttu-id="c8315-158">サインアップの準備はできましたか</span><span class="sxs-lookup"><span data-stu-id="c8315-158">Ready to sign up?</span></span>](https://msdn.microsoft.com/library/windows/apps/bg124287)</td>
    </tr> 
</table>

### <a name="developer-programs"></a><span data-ttu-id="c8315-159">開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-159">Developer programs</span></span>

<span data-ttu-id="c8315-160">Microsoft では、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-160">Microsoft offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="c8315-161">Xbox One のゲームを開発し、Xbox Live の機能をゲームに統合する場合には、開発者プログラムへの参加を検討してください。</span><span class="sxs-lookup"><span data-stu-id="c8315-161">Consider joining a developer program if you want to develop games for Xbox One and integrate Xbox Live features in your game.</span></span> <span data-ttu-id="c8315-162">Windows ストアでゲームを公開するには、さらに Windows デベロッパー センターで開発者アカウントを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8315-162">To publish a game in the Windows Store, you'll also need to create a developer account on Windows Dev Center.</span></span> 

#### <a name="idxbox"></a>ID@Xbox

<span data-ttu-id="c8315-163">ID@Xbox プログラムを利用すると、認定されたゲーム開発者は Windows や Xbox One 向けに自分でゲームを公開することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-163">The ID@Xbox program helps qualified game developers self-publish on Windows and Xbox One.</span></span> <span data-ttu-id="c8315-164">Xbox One 向けの開発を行ったり、ゲーマースコア、達成度、ランキングなどの Xbox Live 機能を自分の Windows 10 ゲームでも実現したいと検討されているなら、ID@Xbox にサインアップしてください。</span><span class="sxs-lookup"><span data-stu-id="c8315-164">If you want to develop for Xbox One, or add Xbox Live features like Gamerscore, achievements, and leaderboards to your Windows 10 game, sign up with ID@Xbox.</span></span> <span data-ttu-id="c8315-165">ID@Xbox 開発者になると、創造性を発揮し、成功の可能性を最大限に引き出すためのツールやサポートを利用できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-165">Become an ID@Xbox developer to get the tools and support you need to unleash your creativity and maximize your success.</span></span> <span data-ttu-id="c8315-166">Windows デベロッパー センターで開発者アカウントを登録する前に、まず ID@Xbox に申し込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8315-166">We recommend that you apply to ID@Xbox first before registering for a developer account on Windows Dev Center.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-167">ID@Xbox開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-167">ID@Xbox developer program</span></span></td>
        <td>[<span data-ttu-id="c8315-168">Xbox One 向けの独立した開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-168">Independent Developer Program for Xbox One</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=526271)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-169">ID@Xbox コンシューマー向けサイト</span><span class="sxs-lookup"><span data-stu-id="c8315-169">ID@Xbox consumer site</span></span></td>
        <td>[ID@Xbox](http://www.idatxbox.com/)</td>
    </tr>
</table>

#### <a name="xbox-live-creators-program"></a><span data-ttu-id="c8315-170">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-170">Xbox Live Creators Program</span></span>

<span data-ttu-id="c8315-171">Xbox Live クリエーターズ プログラムでは、だれでも Xbox Live を自分のタイトルに統合して、Xbox One や Windows 10 に公開することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-171">The Xbox Live Creators Program allows anyone to integrate Xbox Live into their title and publish to Xbox One and Windows 10.</span></span> <span data-ttu-id="c8315-172">今すぐサインアップして、Xbox Live クリエーターズ プログラムで開発を始めましょう。</span><span class="sxs-lookup"><span data-stu-id="c8315-172">To start developing with the Xbox Live Creators Program, sign up today.</span></span>

<span data-ttu-id="c8315-173">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/Developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="c8315-173">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](http://www.xbox.com/Developers/id) program.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-174">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-174">Xbox Live Creators Program</span></span></td>
        <td>[<span data-ttu-id="c8315-175">Xbox Live をタイトルに統合する</span><span class="sxs-lookup"><span data-stu-id="c8315-175">Integrate Xbox Live into your title</span></span>](https://developer.microsoft.com/games/xbox/xboxlive/creator)</td>
    </tr>
</table>

#### <a name="xbox-tools-and-middleware"></a><span data-ttu-id="c8315-176">Xbox のツールとミドルウェア</span><span class="sxs-lookup"><span data-stu-id="c8315-176">Xbox tools and middleware</span></span>

<span data-ttu-id="c8315-177">Xbox のツールおよびミドルウェア プログラムは、ゲームのツールやミドルウェア専門の開発者に Xbox 開発キットのライセンスを付与します。</span><span class="sxs-lookup"><span data-stu-id="c8315-177">The Xbox Tools and Middleware Program licenses Xbox development kits to professional developers of game tools and middleware.</span></span> <span data-ttu-id="c8315-178">プログラムに受け入れられた開発者は、Xbox XDK テクノロジを共有し、ライセンスを持つ他の Xbox 開発者に配布することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-178">Developers accepted into the program can share and distribute their Xbox XDK technologies to other licensed Xbox developers.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-179">ツールおよびミドルウェア プログラムについて問い合わせる</span><span class="sxs-lookup"><span data-stu-id="c8315-179">Contact the tools and middleware program</span></span></td>
        <td><xboxtlsm@microsoft.com></td>
    </tr>
</table>


### <a name="game-samples"></a><span data-ttu-id="c8315-180">ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-180">Game samples</span></span>

<span data-ttu-id="c8315-181">Windows 10 のゲーム機能を理解してゲーム開発をすぐに始めることができるように、Windows 10 のゲームとアプリのサンプルが数多く用意されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-181">There are many Windows 10 game and app samples available to help you understand Windows 10 gaming features and get a quick start on game development.</span></span> <span data-ttu-id="c8315-182">サンプルは次々と開発され、定期的に公開されるため、ときどきサンプル ポータルをチェックして、新機能を確認することを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="c8315-182">More samples are developed and published regularly, so don't forget to occasionally check back at sample portals to see what's new.</span></span> <span data-ttu-id="c8315-183">GitHub のリポジトリを[監視](https://help.github.com/articles/watching-repositories/)して、変更や追加についての通知を受け取ることもできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-183">You can also [watch](https://help.github.com/articles/watching-repositories/) GitHub repos to be notified of changes and additions.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-184">ユニバーサル Windows プラットフォーム アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-184">Universal Windows Platform app samples</span></span></td>
        <td>[<span data-ttu-id="c8315-185">Windows-universal-samples</span><span class="sxs-lookup"><span data-stu-id="c8315-185">Windows-universal-samples</span></span>](https://github.com/Microsoft/Windows-universal-samples)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-186">Xbox Advanced Technology Group のパブリック サンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-186">Xbox Advanced Technology Group public samples</span></span></td>
        <td>[<span data-ttu-id="c8315-187">Xbox-ATG-Samples</span><span class="sxs-lookup"><span data-stu-id="c8315-187">Xbox-ATG-Samples</span></span>](https://github.com/Microsoft/Xbox-ATG-Samples)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-188">Direct3D 12 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-188">Direct3D 12 graphics samples</span></span></td>
        <td>[<span data-ttu-id="c8315-189">DirectX-Graphics-Samples</span><span class="sxs-lookup"><span data-stu-id="c8315-189">DirectX-Graphics-Samples</span></span>](https://github.com/Microsoft/DirectX-Graphics-Samples)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-190">Direct3D 11 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-190">Direct3D 11 graphics samples</span></span></td>
        <td>[<span data-ttu-id="c8315-191">directx-sdk-samples</span><span class="sxs-lookup"><span data-stu-id="c8315-191">directx-sdk-samples</span></span>](https://github.com/walbourn/directx-sdk-samples)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-192">Direct3D 11 主観視点のゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-192">Direct3D 11 first-person game sample</span></span></td>
        <td>[<span data-ttu-id="c8315-193">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-193">Create a simple UWP game with DirectX</span></span>](tutorial--create-your-first-metro-style-directx-game.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-194">Direct2D カスタム画像効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-194">Direct2D custom image effects sample</span></span></td>
        <td>[<span data-ttu-id="c8315-195">D2DCustomEffects</span><span class="sxs-lookup"><span data-stu-id="c8315-195">D2DCustomEffects</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620531)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-196">Direct2D グラデーション メッシュのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-196">Direct2D gradient mesh sample</span></span></td>
        <td>[<span data-ttu-id="c8315-197">D2DGradientMesh</span><span class="sxs-lookup"><span data-stu-id="c8315-197">D2DGradientMesh</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620532)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-198">Direct2D 写真調整のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-198">Direct2D photo adjustment sample</span></span></td>
        <td>[<span data-ttu-id="c8315-199">D2DPhotoAdjustment</span><span class="sxs-lookup"><span data-stu-id="c8315-199">D2DPhotoAdjustment</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620533)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-200">Xbox One ゲームのサンプル (GDN)</span><span class="sxs-lookup"><span data-stu-id="c8315-200">Xbox One game samples (GDN)</span></span></td>
        <td>[<span data-ttu-id="c8315-201">サンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-201">Samples</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-202">Windows 8 ゲームのサンプル (MSDN コード ギャラリー)</span><span class="sxs-lookup"><span data-stu-id="c8315-202">Windows 8 game samples (MSDN Code Gallery)</span></span></td>
        <td>[<span data-ttu-id="c8315-203">Windows ストア ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-203">Windows Store game samples</span></span>](https://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=SearchText&f%5B0%5D.Value=game&f%5B1%5D.Type=Contributors&f%5B1%5D.Value=Microsoft&f%5B1%5D.Text=Microsoft)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-204">JavaScript と HTML5 のゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-204">JavaScript and HTML5 game sample</span></span></td>
        <td>[<span data-ttu-id="c8315-205">JavaScript と HTML5 のタッチ ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-205">JavaScript and HTML5 touch game sample</span></span>](https://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)</td>
    </tr>      
</table>


### <a name="developer-forums"></a><span data-ttu-id="c8315-206">開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-206">Developer forums</span></span>

<span data-ttu-id="c8315-207">開発者フォーラムは、ゲームの開発に関する質疑応答を行ったり、ゲーム開発コミュニティで交流を深めたりするのに適した場所です。</span><span class="sxs-lookup"><span data-stu-id="c8315-207">Developer forums are a great place to ask and answer game development questions and connect with the game development community.</span></span> <span data-ttu-id="c8315-208">フォーラムは、他の開発者が過去に直面し、解決した困難な問題に対する既存の回答を見つけることができる、優れたリソースでもあります。</span><span class="sxs-lookup"><span data-stu-id="c8315-208">Forums can also be fantastic resources for finding existing answers to difficult issues that developers have faced and solved in the past.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-209">Windows アプリ開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-209">Windows apps developer forums</span></span></td>
        <td>[<span data-ttu-id="c8315-210">Windows ストアとアプリ フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-210">Windows store and apps forums</span></span>](https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsapps)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-211">UWP アプリ開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-211">UWP apps developer forum</span></span></td>
        <td>[<span data-ttu-id="c8315-212">ユニバーサル Windows プラットフォーム アプリの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-212">Developing Universal Windows Platform apps</span></span>](https://social.msdn.microsoft.com/Forums/en-us/home?forum=wpdevelop)</td>
    </tr>

    <tr>
        <td><span data-ttu-id="c8315-213">デスクトップ アプリケーション開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-213">Desktop applications developer forums</span></span></td>
        <td>[<span data-ttu-id="c8315-214">Windows デスクトップ アプリケーション フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-214">Windows desktop applications forums</span></span>](https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsdesktopdev)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-215">DirectX Windows ストア ゲーム (アーカイブ済みのフォーラムの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-215">DirectX Windows Store games (archived forum posts)</span></span></td>
        <td>[<span data-ttu-id="c8315-216">DirectX を使った Windows ストア ゲームの構築 (アーカイブ済み)</span><span class="sxs-lookup"><span data-stu-id="c8315-216">Building Windows Store games with DirectX (archived)</span></span>](https://social.msdn.microsoft.com/Forums/vstudio/home?forum=wingameswithdirectx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-217">Windows 10 対象パートナー開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-217">Windows 10 managed partner developer forums</span></span></td>
        <td>[<span data-ttu-id="c8315-218">XBOX 開発者フォーラム: Windows 10</span><span class="sxs-lookup"><span data-stu-id="c8315-218">XBOX Developer Forums: Windows 10</span></span>](http://aka.ms/win10devforums)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-219">DirectX フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-219">DirectX forums</span></span></td>
        <td>[<span data-ttu-id="c8315-220">DirectX 12 フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-220">DirectX 12 forum</span></span>](http://forums.directxtech.com/index.php)</td>
    </tr>
</table>


### <a name="developer-blogs"></a><span data-ttu-id="c8315-221">開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-221">Developer blogs</span></span>

<span data-ttu-id="c8315-222">開発者ブログは、ゲーム開発に関する最新情報を手に入れることができる、もう 1 つの有用なリソースです。</span><span class="sxs-lookup"><span data-stu-id="c8315-222">Developer blogs are another great resource for the latest information about game development.</span></span> <span data-ttu-id="c8315-223">新機能、実装の詳細、ベスト プラクティス、アーキテクチャの背景などに関する投稿を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-223">You'll find posts about new features, implementation details, best practices, architecture background, and more.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-224">Windows 用アプリ開発ブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-224">Building apps for Windows blog</span></span></td>
        <td>[<span data-ttu-id="c8315-225">Windows 用アプリ開発</span><span class="sxs-lookup"><span data-stu-id="c8315-225">Building Apps for Windows</span></span>](http://blogs.windows.com/buildingapps/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-226">Windows 10 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-226">Windows 10 (blog posts)</span></span></td>
        <td>[<span data-ttu-id="c8315-227">Windows 10 に関する投稿</span><span class="sxs-lookup"><span data-stu-id="c8315-227">Posts in Windows 10</span></span>](http://blogs.windows.com/blog/tag/windows-10/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-228">Visual Studio エンジニアリング チームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-228">Visual Studio engineering team blog</span></span></td>
        <td>[<span data-ttu-id="c8315-229">The Visual Studio Blog</span><span class="sxs-lookup"><span data-stu-id="c8315-229">The Visual Studio Blog</span></span>](http://blogs.msdn.com/b/visualstudio/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-230">Visual Studio 開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-230">Visual Studio developer tools blogs</span></span></td>
        <td>[<span data-ttu-id="c8315-231">Developer Tools Blogs</span><span class="sxs-lookup"><span data-stu-id="c8315-231">Developer Tools Blogs</span></span>](http://blogs.msdn.com/b/developer-tools/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-232">Somasegar の開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-232">Somasegar's developer tools blog</span></span></td>
        <td>[<span data-ttu-id="c8315-233">Somasegar’s blog</span><span class="sxs-lookup"><span data-stu-id="c8315-233">Somasegar’s blog</span></span>](http://blogs.msdn.com/b/somasegar/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-234">DirectX 開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-234">DirectX developer blog</span></span></td>
        <td>[<span data-ttu-id="c8315-235">DirectX Developer blog</span><span class="sxs-lookup"><span data-stu-id="c8315-235">DirectX Developer blog</span></span>](http://blogs.msdn.com/b/directx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-236">DirectX 12 の概要 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-236">DirectX 12 introduction (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-237">DirectX 12</span><span class="sxs-lookup"><span data-stu-id="c8315-237">DirectX 12</span></span>](http://blogs.msdn.com/b/directx/archive/2014/03/20/directx-12.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-238">Visual C++ ツール チームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-238">Visual C++ tools team blog</span></span></td>
        <td>[<span data-ttu-id="c8315-239">Visual C++ チームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-239">Visual C++ team blog</span></span>](http://blogs.msdn.com/b/vcblog/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-240">PIX チームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-240">PIX team blog</span></span></td>
        <td>[<span data-ttu-id="c8315-241">Windows および Xbox での DirectX 12 ゲームのパフォーマンスのチューニングとデバッグ</span><span class="sxs-lookup"><span data-stu-id="c8315-241">Performance tuning and debugging for DirectX 12 games on Windows and Xbox</span></span>](https://blogs.msdn.microsoft.com/pix/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-242">ユニバーサル Windows アプリの展開チームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-242">Universal Windows App Deployment team blog</span></span></td>
        <td>[<span data-ttu-id="c8315-243">UWP アプリのビルドと展開のチームのブログ</span><span class="sxs-lookup"><span data-stu-id="c8315-243">Build and deploy UWP apps team blog</span></span>](https://blogs.msdn.microsoft.com/appinstaller/)</td>
    </tr>
</table>
 

## <a name="concept-and-planning"></a><span data-ttu-id="c8315-244">概念と計画</span><span class="sxs-lookup"><span data-stu-id="c8315-244">Concept and planning</span></span>


<span data-ttu-id="c8315-245">概念と計画の段階では、ゲームの全体像とそれを実現するために使用するテクノロジやツールを決定します。</span><span class="sxs-lookup"><span data-stu-id="c8315-245">In the concept and planning stage, you're deciding what your game is going to be like and the technologies and tools you'll use to bring it to life.</span></span>

### <a name="overview-of-game-development-technologies"></a><span data-ttu-id="c8315-246">ゲーム開発テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-246">Overview of game development technologies</span></span>

<span data-ttu-id="c8315-247">UWP のゲームの開発を開始するとき、グラフィックス、入力、オーディオ、ネットワーク、ユーティリティ、ライブラリについて、利用可能なオプションは複数あります。</span><span class="sxs-lookup"><span data-stu-id="c8315-247">When you start developing a game for the UWP you have multiple options available for graphics, input, audio, networking, utilities, and libraries.</span></span>

<span data-ttu-id="c8315-248">ゲームで使うすべてのテクノロジが既に決定している場合は問題ありません。</span><span class="sxs-lookup"><span data-stu-id="c8315-248">If you've already decided on all the technologies you'll be using in your game, great!</span></span> <span data-ttu-id="c8315-249">まだ決まっていない場合、[UWP アプリのゲーム テクノロジ](game-development-platform-guide.md) ガイドに利用可能な多くのテクノロジの概要がまとめられています。このガイドに目を通して、さまざまなオプションとそれらを組み合わせる方法を理解しておくことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8315-249">If not, the [Game technologies for UWP apps](game-development-platform-guide.md) guide is an excellent overview of many of the technologies available, and is highly recommended reading to help you understand the options and how they fit together.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-250">UWP のゲーム テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-250">Survey of UWP game technologies</span></span></td>
        <td>[<span data-ttu-id="c8315-251">UWP アプリのゲーム テクノロジ</span><span class="sxs-lookup"><span data-stu-id="c8315-251">Game technologies for UWP apps</span></span>](game-development-platform-guide.md)</td>
    </tr>
</table>
 

<span data-ttu-id="c8315-252">次の 3 つの GDC 2015 のビデオは、Windows 10 のゲーム開発と Windows 10 のゲーム エクスペリエンスの概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-252">These three GDC 2015 videos give a good overview of Windows 10 game development and the Windows 10 gaming experience.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-253">Windows 10 のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-253">Overview of Windows 10 game development (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-254">Windows 10 のゲームの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-254">Developing Games for Windows 10</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-Games-for-Windows-10)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-255">Windows 10 のゲーム エクスペリエンス (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-255">Windows 10 gaming experience (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-256">Windows 10 でのゲームのユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="c8315-256">Gaming Consumer Experience on Windows 10</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Gaming-Consumer-Experience-on-Windows-10)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-257">Microsoft エコシステム全体でのゲーム (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-257">Gaming across the Microsoft ecosystem (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-258">Microsoft エコシステム全体でのゲームの未来</span><span class="sxs-lookup"><span data-stu-id="c8315-258">The Future of Gaming Across the Microsoft Ecosystem</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/The-Future-of-Gaming-Across-the-Microsoft-Ecosystem)</td>
    </tr>
</table>

### <a name="game-planning"></a><span data-ttu-id="c8315-259">ゲームの計画</span><span class="sxs-lookup"><span data-stu-id="c8315-259">Game planning</span></span>

<span data-ttu-id="c8315-260">これらは、いくつかの高レベルの概念と、ゲームを計画するときに考慮する計画のトピックです。</span><span class="sxs-lookup"><span data-stu-id="c8315-260">These are some high level concept and planning topics to consider when planning for your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-261">ゲームをアクセシビリティ対応にする</span><span class="sxs-lookup"><span data-stu-id="c8315-261">Make your game accessible</span></span></td>
        <td>[<span data-ttu-id="c8315-262">ゲームのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="c8315-262">Accessibility for games</span></span>](https://msdn.microsoft.com/windows/uwp/gaming/accessibility-for-games)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-263">クラウドを使用したゲームの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-263">Build games using cloud</span></span></td>
        <td>[<span data-ttu-id="c8315-264">ゲーム用のクラウド</span><span class="sxs-lookup"><span data-stu-id="c8315-264">Cloud for games</span></span>](https://msdn.microsoft.com/windows/uwp/gaming/cloud-for-games)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-265">ゲームの収益化</span><span class="sxs-lookup"><span data-stu-id="c8315-265">Monetize your game</span></span></td>
        <td>[<span data-ttu-id="c8315-266">ゲームの収益化</span><span class="sxs-lookup"><span data-stu-id="c8315-266">Monetization for games</span></span>](https://msdn.microsoft.com/windows/uwp/gaming/monetization-for-games)</td>
    </tr>
</table>



### <a name="choosing-your-graphics-technology-and-programming-language"></a><span data-ttu-id="c8315-267">グラフィックス テクノロジとプログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="c8315-267">Choosing your graphics technology and programming language</span></span>

<span data-ttu-id="c8315-268">Windows 10 ゲームでは、複数のプログラミング言語やグラフィックス テクノロジを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-268">There are several programming languages and graphics technologies available for use in Windows 10 games.</span></span> <span data-ttu-id="c8315-269">どれを選ぶかは、開発しているゲームの種類、開発スタジオの経験や好み、ゲームの具体的な機能要件によって決まります。</span><span class="sxs-lookup"><span data-stu-id="c8315-269">The path you take depends on the type of game you’re developing, the experience and preferences of your development studio, and specific feature requirements of your game.</span></span> <span data-ttu-id="c8315-270">C#、C++、JavaScript のどれを使うか、</span><span class="sxs-lookup"><span data-stu-id="c8315-270">Will you use C#, C++, or JavaScript?</span></span> <span data-ttu-id="c8315-271">DirectX、XAML、HTML5 のどれを使うかなどです。</span><span class="sxs-lookup"><span data-stu-id="c8315-271">DirectX, XAML, or HTML5?</span></span>

#### <a name="directx"></a><span data-ttu-id="c8315-272">DirectX</span><span class="sxs-lookup"><span data-stu-id="c8315-272">DirectX</span></span>

<span data-ttu-id="c8315-273">Microsoft DirectX を使うと、最高のパフォーマンスの 2D および 3D グラフィックスとマルチメディアを生み出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-273">Microsoft DirectX is the choice to make for the highest-performance 2D and 3D graphics and multimedia.</span></span> 

<span data-ttu-id="c8315-274">Windows 10 で新たに導入された Direct3D 12 は、コンソールに似た API の性能を備え、これまで以上に高速で効率的になりました。</span><span class="sxs-lookup"><span data-stu-id="c8315-274">Direct3D 12, new in Windows 10, brings the power of a console-like API and is faster and more efficient than ever before.</span></span> <span data-ttu-id="c8315-275">開発するゲームで、最新のグラフィックス ハードウェアを十分に活用して、より多くのオブジェクト、より豊かなシーン、より印象的な効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-275">Your game can fully utilize modern graphics hardware and feature more objects, richer scenes, and enhanced effects.</span></span> <span data-ttu-id="c8315-276">Direct3D 12 は、Windows 10 PC と Xbox One 向けに最適化されたグラフィックスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-276">Direct3D 12 delivers optimized graphics on Windows 10 PCs and Xbox One.</span></span> <span data-ttu-id="c8315-277">Direct3D 11 の使い慣れたグラフィックス パイプラインを使う場合でも、Direct3D 11.3 に追加された新しいレンダリングおよび最適化機能を活かすことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-277">If you want to use the familiar graphics pipeline of Direct3D 11, you’ll still benefit from the new rendering and optimization features added to Direct3D 11.3.</span></span> <span data-ttu-id="c8315-278">さらに、Win32 をルーツとする実証済みのデスクトップ Windows API の開発者は、Windows 10 でもそのオプションを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-278">And, if you’re a tried-and-true desktop Windows API developer with roots in Win32, you’ll still have that option in Windows 10.</span></span>

<span data-ttu-id="c8315-279">DirectX のさまざまな機能と緊密なプラットフォーム統合により、要求の多いほとんどのゲームに必要とされる性能とパフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-279">The extensive features and deep platform integration of DirectX provide the power and performance needed by the most demanding games.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-280">DirectX ゲームに関する使い方ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-280">How-to guides for DirectX games</span></span></td>
        <td>[<span data-ttu-id="c8315-281">ゲームと DirectX</span><span class="sxs-lookup"><span data-stu-id="c8315-281">Games and DirectX</span></span>](index.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-282">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-282">DirectX overviews and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-283">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="c8315-283">DirectX Graphics and Gaming</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-284">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-284">Direct3D 12 programming guide and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-285">Direct3D 12 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="c8315-285">Direct3D 12 Graphics</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-286">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="c8315-286">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td>[<span data-ttu-id="c8315-287">Microsoft DirectX 12 とグラフィックスに関する教育</span><span class="sxs-lookup"><span data-stu-id="c8315-287">Microsoft DirectX 12 and Graphics Education</span></span>](https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA)</td>
    </tr>
</table>
 

#### <a name="xaml"></a><span data-ttu-id="c8315-288">XAML</span><span class="sxs-lookup"><span data-stu-id="c8315-288">XAML</span></span>

<span data-ttu-id="c8315-289">XAML は、アニメーション、ストーリーボード、データ バインディング、拡張性の高いベクター ベース グラフィックス、動的なサイズ変更、シーン グラフなどの便利な機能を備える、使いやすい宣言型 UI 言語です。</span><span class="sxs-lookup"><span data-stu-id="c8315-289">XAML is an easy-to-use declarative UI language with convenient features like animations, storyboards, data binding, scalable vector-based graphics, dynamic resizing, and scene graphs.</span></span> <span data-ttu-id="c8315-290">また、XAML はゲーム UI、メニュー、スプライト、2D グラフィックスに最適です。</span><span class="sxs-lookup"><span data-stu-id="c8315-290">XAML works great for game UI, menus, sprites, and 2D graphics.</span></span> <span data-ttu-id="c8315-291">UI レイアウトを簡単にするため、XAML には、Expression Blend や Microsoft Visual Studio などの設計および開発ツールとの互換性があります。</span><span class="sxs-lookup"><span data-stu-id="c8315-291">To make UI layout easy, XAML is compatible with design and development tools like Expression Blend and Microsoft Visual Studio.</span></span> <span data-ttu-id="c8315-292">XAML はよく C# と同時に使用されますが、希望する言語が C++ の場合や、ゲームが多くの CPU を必要とする場合は、C++ も適しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-292">XAML is commonly used with C#, but C++ is also a good choice if that’s your preferred language or if your game has high CPU demands.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-293">XAML プラットフォームの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-293">XAML platform overview</span></span></td>
        <td>[<span data-ttu-id="c8315-294">XAML プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="c8315-294">XAML platform</span></span>](https://msdn.microsoft.com/library/windows/apps/mt228259)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-295">XAML UI とコントロール</span><span class="sxs-lookup"><span data-stu-id="c8315-295">XAML UI and controls</span></span></td>
        <td>[<span data-ttu-id="c8315-296">コントロール、レイアウト、テキスト</span><span class="sxs-lookup"><span data-stu-id="c8315-296">Controls, layouts, and text</span></span>](https://msdn.microsoft.com/library/windows/apps/mt228348)</td>
    </tr>
</table>
 

#### <a name="html-5"></a><span data-ttu-id="c8315-297">HTML 5</span><span class="sxs-lookup"><span data-stu-id="c8315-297">HTML 5</span></span>

<span data-ttu-id="c8315-298">ハイパーテキスト マークアップ言語 (HTML) は、Web ページ、アプリ、リッチ クライアントに使用される一般的な UI マークアップ言語です。</span><span class="sxs-lookup"><span data-stu-id="c8315-298">HyperText Markup Language (HTML) is a common UI markup language used for web pages, apps, and rich clients.</span></span> <span data-ttu-id="c8315-299">Windows ゲームでは、HTML の使い慣れた機能、ユニバーサル Windows プラットフォーム、AppCache、Web ワーカー、キャンバス、ドラッグ アンド ドロップ、非同期プログラミング、SVG などの最新の Web 機能のサポートを備えた、全機能装備のプレゼンテーション層として HTML5 を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-299">Windows games can use HTML5 as a full-featured presentation layer with the familiar features of HTML, access to the Universal Windows Platform, and support for modern web features like AppCache, Web Workers, canvas, drag-and-drop, asynchronous programming, and SVG.</span></span> <span data-ttu-id="c8315-300">HTML レンダリングの内部では、DirectX ハードウェア アクセラレータの機能が活用されるため、追加のコードを記述しなくても DirectX のパフォーマンスの恩恵を受けることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-300">Behind the scenes, HTML rendering takes advantage of the power of DirectX hardware acceleration, so you can still get the performance benefits of DirectX without writing any extra code.</span></span> <span data-ttu-id="c8315-301">Web 開発に熟練している場合、Web ゲームを移植する場合、または他の選択肢よりアプローチしやすい言語およびグラフィックス層を使う場合は、HTML5 が最適です。</span><span class="sxs-lookup"><span data-stu-id="c8315-301">HTML5 is a good choice if you are proficient with web development, porting a web game, or want to use language and graphics layers that can be easier to approach than the other choices.</span></span> <span data-ttu-id="c8315-302">HTML5 は JavaScript と同時に使用されますが、C# や C++/CX で作成されたコンポーネントを呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-302">HTML5 is used with JavaScript, but can also call into components created with C# or C++/CX.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-303">HTML5 とドキュメント オブジェクト モデルに関する情報</span><span class="sxs-lookup"><span data-stu-id="c8315-303">HTML5 and Document Object Model information</span></span></td>
        <td>[<span data-ttu-id="c8315-304">HTML と DOM のリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-304">HTML and DOM reference</span></span>](https://msdn.microsoft.com/library/windows/apps/br212882.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-305">HTML5 W3C 勧告</span><span class="sxs-lookup"><span data-stu-id="c8315-305">The HTML5 W3C Recommendation</span></span></td>
        <td>[<span data-ttu-id="c8315-306">HTML5</span><span class="sxs-lookup"><span data-stu-id="c8315-306">HTML5</span></span>](http://go.microsoft.com/fwlink/p/?linkid=221374)</td>
    </tr>
</table>
 

#### <a name="combining-presentation-technologies"></a><span data-ttu-id="c8315-307">プレゼンテーション テクノロジの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="c8315-307">Combining presentation technologies</span></span>

<span data-ttu-id="c8315-308">Microsoft DirectX Graphic Infrastructure (DXGI) には、複数のグラフィックス テクノロジにおける相互運用性と互換性が備わっています。</span><span class="sxs-lookup"><span data-stu-id="c8315-308">The Microsoft DirectX Graphics Infrastructure (DXGI) provides interop and compatibility across multiple graphics technologies.</span></span> <span data-ttu-id="c8315-309">高パフォーマンスのグラフィックスを実現するため、メニューや他のシンプルな UI には XAML を使い、複雑な 2D および 3D シーンのレンダリングには DirectX を使うことで、XAML と DirectX を組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-309">For high-performance graphics, you can combine XAML and DirectX, using XAML for menus and other simple UI, and DirectX for rendering complex 2D and 3D scenes.</span></span> <span data-ttu-id="c8315-310">DXGI には、Direct2D、Direct3D、DirectWrite、DirectCompute、Microsoft メディア ファンデーション間の互換性も備わっています。</span><span class="sxs-lookup"><span data-stu-id="c8315-310">DXGI also provides compatibility between Direct2D, Direct3D, DirectWrite, DirectCompute, and the Microsoft Media Foundation.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-311">DirectX Graphics Infrastructure のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-311">DirectX Graphics Infrastructure programming guide and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-312">DXGI</span><span class="sxs-lookup"><span data-stu-id="c8315-312">DXGI</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh404534)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-313">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="c8315-313">Combining DirectX and XAML</span></span></td>
        <td>[<span data-ttu-id="c8315-314">DirectX と XAML の相互運用機能</span><span class="sxs-lookup"><span data-stu-id="c8315-314">DirectX and XAML interop</span></span>](directx-and-xaml-interop.md)</td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="c8315-315">C++</span><span class="sxs-lookup"><span data-stu-id="c8315-315">C++</span></span>

<span data-ttu-id="c8315-316">C++/CX はオーバーヘッドの低い高パフォーマンスな言語であり、速度、互換性、プラットフォーム アクセスがうまく組み合わせられています。</span><span class="sxs-lookup"><span data-stu-id="c8315-316">C++/CX is a high-performance, low overhead language that provides the powerful combination of speed, compatibility, and platform access.</span></span> <span data-ttu-id="c8315-317">C++/CX により、DirectX や Xbox Live など、Windows 10 のすばらしいゲーム機能すべてが使いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="c8315-317">C++/CX makes it easy to use all of the great gaming features in Windows 10, including DirectX and Xbox Live.</span></span> <span data-ttu-id="c8315-318">既にある C++ コードとライブラリを再利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-318">You can also reuse existing C++ code and libraries.</span></span> <span data-ttu-id="c8315-319">C++/CX を使うと、ガベージ コレクションのオーバーヘッドを生じさせない高速なネイティブ コードが作成されるため、ゲームのパフォーマンスが向上し、電力消費が低くなり、結果としてバッテリ寿命が延びます。</span><span class="sxs-lookup"><span data-stu-id="c8315-319">C++/CX creates fast, native code that doesn’t incur the overhead of garbage collection, so your game can have great performance and low power consumption, which leads to longer battery life.</span></span> <span data-ttu-id="c8315-320">C++/CX を DirectX または XAML と同時に使うか、両方の組み合わせを使って、ゲームを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-320">Use C++/CX with DirectX or XAML, or create a game that uses a combination of both.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-321">C++/CX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="c8315-321">C++/CX reference and overviews</span></span></td>
        <td>[<span data-ttu-id="c8315-322">Visual C++ 言語のリファレンス (C++/CX)</span><span class="sxs-lookup"><span data-stu-id="c8315-322">Visual C++ Language Reference (C++/CX)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-323">Visual C++ のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-323">Visual C++ programming guide and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-324">Visual Studio 2015 の Visual C++</span><span class="sxs-lookup"><span data-stu-id="c8315-324">Visual C++ in Visual Studio 2015</span></span>](https://msdn.microsoft.com/library/60k1461a.aspx)</td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="c8315-325">C#</span><span class="sxs-lookup"><span data-stu-id="c8315-325">C#</span></span>

<span data-ttu-id="c8315-326">C# ("シー シャープ" と発音) は、タイプ セーフかつオブジェクト指向のシンプルで強力な最新の革新的言語です。</span><span class="sxs-lookup"><span data-stu-id="c8315-326">C# (pronounced "C sharp") is a modern, innovative language that is simple, powerful, type-safe, and object-oriented.</span></span> <span data-ttu-id="c8315-327">C# を使うと、C スタイル言語の親しみやすさと表現力を維持しながら短期間で開発できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-327">C# enables rapid development while retaining the familiarity and expressiveness of C-style languages.</span></span> <span data-ttu-id="c8315-328">C# は使いやすい言語ですが、ポリモーフィズム、デリゲート、ラムダ、クロージャ、反復子メソッド、共変性、統合言語クエリ (LINQ) 式など、多くの高度な言語機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="c8315-328">Though easy to use, C# has numerous advanced language features like polymorphism, delegates, lambdas, closures, iterator methods, covariance, and Language-Integrated Query (LINQ) expressions.</span></span> <span data-ttu-id="c8315-329">XAML をターゲットとする場合、ゲームの開発をすぐに始めたい場合、C# を既に使ったことがある場合、C# が最適です。</span><span class="sxs-lookup"><span data-stu-id="c8315-329">C# is an excellent choice if you are targeting XAML, want to get a quick start developing your game, or have previous C# experience.</span></span> <span data-ttu-id="c8315-330">C# は主に XAML と同時に使われるめ、DirectX を使う場合は、代わりに C++ を選ぶか、ゲームの一部を DirectX とやり取りする C++ コンポーネントとして記述します。</span><span class="sxs-lookup"><span data-stu-id="c8315-330">C# is used primarily with XAML, so if you want to use DirectX, choose C++ instead, or write part of your game as a C++ component that interacts with DirectX.</span></span> <span data-ttu-id="c8315-331">または、C# と C++ 用の即時モード Direct2D グラフィックス ライブラリである [Win2D](https://github.com/Microsoft/Win2D) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="c8315-331">Or, consider [Win2D](https://github.com/Microsoft/Win2D), an immediate mode Direct2D graphics libary for C# and C++.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-332">C# のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-332">C# programming guide and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-333">C# 言語のリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-333">C# language reference</span></span>](https://msdn.microsoft.com/library/kx37x362.aspx)</td>
    </tr>
</table>
 

#### <a name="javascript"></a><span data-ttu-id="c8315-334">JavaScript</span><span class="sxs-lookup"><span data-stu-id="c8315-334">JavaScript</span></span>

<span data-ttu-id="c8315-335">JavaScript は、最新の Web アプリケーションやリッチ クライアント アプリケーションに広く使用されている動的なスクリプト言語です。</span><span class="sxs-lookup"><span data-stu-id="c8315-335">JavaScript is a dynamic scripting language widely used for modern web and rich client applications.</span></span>

<span data-ttu-id="c8315-336">Windows JavaScript アプリは、ユニバーサル Windows プラットフォームの強力な機能に簡単かつ直感的な方法でアクセスできます (オブジェクト指向 JavaScript クラスのメソッドとプロパティとして)。</span><span class="sxs-lookup"><span data-stu-id="c8315-336">Windows JavaScript apps can access the powerful features of the Universal Windows Platform in an easy, intuitive way—as methods and properties of object-oriented JavaScript classes.</span></span> <span data-ttu-id="c8315-337">JavaScript は、Web 開発環境を使っていた場合、JavaScript に既に慣れている場合、HTML5、CSS、WinJS、または JavaScript ライブラリを使用する場合のゲーム開発に最適です。</span><span class="sxs-lookup"><span data-stu-id="c8315-337">JavaScript is a good choice for your game if you’re coming from a web development environment, are already familiar with JavaScript, or want to use HTML5, CSS, WinJS, or JavaScript libraries.</span></span> <span data-ttu-id="c8315-338">DirectX や XAML をターゲットとする場合は、代わりに C# または C++/CX を選択してください。</span><span class="sxs-lookup"><span data-stu-id="c8315-338">If you’re targeting DirectX or XAML, choose C# or C++/CX instead.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-339">JavaScript と Windows ランタイムのリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-339">JavaScript and Windows Runtime reference</span></span></td>
        <td>[<span data-ttu-id="c8315-340">JavaScript のリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-340">JavaScript reference</span></span>](https://msdn.microsoft.com/library/windows/apps/jj613794)</td>
    </tr>
</table>


#### <a name="use-windows-runtime-components-to-combine-languages"></a><span data-ttu-id="c8315-341">Windows ランタイム コンポーネントを使って言語を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="c8315-341">Use Windows Runtime Components to combine languages</span></span>

<span data-ttu-id="c8315-342">ユニバーサル Windows プラットフォームでは、異なる言語で記述されたコンポーネントを簡単に組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-342">With the Universal Windows Platform, it’s easy to combine components written in different languages.</span></span> <span data-ttu-id="c8315-343">C++、C#、Visual Basic で Windows ランタイム コンポーネントを作成した後、JavaScript、C#、C++、Visual Basic から呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-343">Create Windows Runtime Components in C++, C#, or Visual Basic, and then call into them from JavaScript, C#, C++, or Visual Basic.</span></span> <span data-ttu-id="c8315-344">これは、好みの言語でゲームの一部をプログラミングする場合に最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="c8315-344">This is a great way to program portions of your game in the language of your choice.</span></span> <span data-ttu-id="c8315-345">コンポーネントにより、特定の言語でのみ使用可能な外部ライブラリや、既に記述しているレガシ コードを使うこともできるようになります。</span><span class="sxs-lookup"><span data-stu-id="c8315-345">Components also let you consume external libraries that are only available in a particular language, as well as use legacy code you’ve already written.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-346">Windows ランタイム コンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-346">How to create Windows Runtime Components</span></span></td>
        <td>[<span data-ttu-id="c8315-347">Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-347">Creating Windows Runtime Components</span></span>](https://docs.microsoft.com/windows/uwp/winrt-components/creating-windows-runtime-components-in-cpp)</td>
    </tr>
</table>


### <a name="which-version-of-directx-should-your-game-use"></a><span data-ttu-id="c8315-348">ゲームで使う Microsoft DirectX のバージョン</span><span class="sxs-lookup"><span data-stu-id="c8315-348">Which version of DirectX should your game use?</span></span>

<span data-ttu-id="c8315-349">ゲームで DirectX を使うことを選んだ場合、使うバージョン (Microsoft Direct3D 12 または Microsoft Direct3D 11) を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8315-349">If you are choosing DirectX for your game, you'll need to decide which version to use: Microsoft Direct3D 12 or Microsoft Direct3D 11.</span></span>

<span data-ttu-id="c8315-350">Windows 10 で新たに導入された Direct3D 12 は、コンソールに似た API の性能を備え、これまで以上に高速で効率的になりました。</span><span class="sxs-lookup"><span data-stu-id="c8315-350">Direct3D 12, new in Windows 10, brings the power of a console-like API and is faster and more efficient than ever before.</span></span> <span data-ttu-id="c8315-351">開発するゲームで、最新のグラフィックス ハードウェアを十分に活用して、より多くのオブジェクト、より豊かなシーン、より印象的な効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-351">Your game can fully utilize modern graphics hardware and feature more objects, richer scenes, and enhanced effects.</span></span> <span data-ttu-id="c8315-352">Direct3D 12 は、Windows 10 PC と Xbox One 向けに最適化されたグラフィックスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-352">Direct3D 12 delivers optimized graphics on Windows 10 PCs and Xbox One.</span></span> <span data-ttu-id="c8315-353">Direct3D 12 は非常に低いレベルで動作するため、専門的なグラフィックス開発チームや経験豊富な DirectX 11 開発チームは、グラフィックスの最適化を十分に活かすために必要となるすべてのコントロールを利用することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-353">Since Direct3D 12 works at a very low level, it is able to give an expert graphics development team or an experienced DirectX 11 development team all the control they need to maximize graphics optimization.</span></span>

<span data-ttu-id="c8315-354">Direct3D 11.3 は低レベル グラフィック API です。よく利用される Direct3D プログラミング モデルが使われており、GPU レンダリングに関連する多くの複雑な処理を扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-354">Direct3D 11.3 is a low level graphics API that uses the familiar Direct3D programming model and handles for you more of the complexity involved in GPU rendering.</span></span> <span data-ttu-id="c8315-355">また、Windows 10 と Xbox One でもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c8315-355">It is also supported in Windows 10 and Xbox One.</span></span> <span data-ttu-id="c8315-356">Direct3D 11 で作成されたエンジンを既にお持ちで、Direct3D 12 への切り替えの準備がまだ整っていない場合は、Direct3D 11 on 12 を使うことによって、ある程度のパフォーマンスの向上を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-356">If you have an existing engine written in Direct3D 11, and you're not quite ready to make the jump to Direct3D 12, you can use Direct3D 11 on 12 to achieve some performance improvements.</span></span> <span data-ttu-id="c8315-357">バージョン 11.3 以降には、Direct3D 12 でも利用可能な新しいレンダリングと最適化の機能が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8315-357">Versions 11.3+ contain the new rendering and optimization features enabled also in Direct3D 12.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-358">Direct3D 12 または Direct3D 11 の選択</span><span class="sxs-lookup"><span data-stu-id="c8315-358">Choosing Direct3D 12 or Direct3D 11</span></span></td>
        <td>[<span data-ttu-id="c8315-359">Direct3D 12 の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-359">What is Direct3D 12?</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn899228)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-360">Direct3D 11 の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-360">Overview of Direct3D 11</span></span></td>
        <td>[<span data-ttu-id="c8315-361">Direct3D 11 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="c8315-361">Direct3D 11 Graphics</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476080)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-362">Direct3D 11 on 12 の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-362">Overview of Direct3D 11 on 12</span></span></td>
        <td>[<span data-ttu-id="c8315-363">Direct3D 11 on 12</span><span class="sxs-lookup"><span data-stu-id="c8315-363">Direct3D 11 on 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn913195)</td>
    </tr>
</table>


### <a name="bridges-game-engines-and-middleware"></a><span data-ttu-id="c8315-364">ブリッジ、ゲーム エンジン、ミドルウェア</span><span class="sxs-lookup"><span data-stu-id="c8315-364">Bridges, game engines, and middleware</span></span>

<span data-ttu-id="c8315-365">ゲームのニーズに応じて、ブリッジ、ゲーム エンジン、ミドルウェアを使うことにより、開発やテストに費やす時間やリソースを節約できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-365">Depending on the needs of your game, using bridges, game engines, or middleware can save development and testing time and resources.</span></span> <span data-ttu-id="c8315-366">ここでは、ゲームの開発に適しているかどうかを判断できるように、ブリッジ、ゲーム エンジン、ミドルウェアの概要とリソースを示します。</span><span class="sxs-lookup"><span data-stu-id="c8315-366">Here are some overview and resources for bridges, game engines, and middleware to help you decide if any are right for you.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-367">ミドルウェアを使ったゲーム開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-367">Game Development with Middleware (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-368">ミドルウェアによる Windows ストア ゲーム開発のスピードアップ</span><span class="sxs-lookup"><span data-stu-id="c8315-368">Accelerating Windows Store Game Development with Middleware</span></span>](https://channel9.msdn.com/Events/Build/2013/3-187)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-369">ゲームのミドルウェアの概要 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-369">Introduction to game middleware (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-370">ゲーム開発ミドルウェア: 概要と</span><span class="sxs-lookup"><span data-stu-id="c8315-370">Game Development Middleware - What is it?</span></span> <span data-ttu-id="c8315-371">必要性</span><span class="sxs-lookup"><span data-stu-id="c8315-371">Do I need it?</span></span>](http://blogs.msdn.com/b/wsdevsol/archive/2014/05/02/game-development-middleware-what-is-it-do-i-need-it.aspx)</td>
    </tr>
</table>
 

#### <a name="universal-windows-platform-bridges"></a><span data-ttu-id="c8315-372">ユニバーサル Windows プラットフォーム ブリッジ</span><span class="sxs-lookup"><span data-stu-id="c8315-372">Universal Windows Platform Bridges</span></span>

<span data-ttu-id="c8315-373">ユニバーサル Windows プラットフォーム ブリッジは、既にあるアプリやゲームを UWP に移植するためのテクノロジです。</span><span class="sxs-lookup"><span data-stu-id="c8315-373">Universal Windows Platform Bridges are technologies that bring your existing app or game over to the UWP.</span></span> <span data-ttu-id="c8315-374">ブリッジは、すぐに UWP のゲーム開発の始めるときに最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="c8315-374">Bridges are a great way to get a quick start on UWP game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-375">UWP ブリッジ</span><span class="sxs-lookup"><span data-stu-id="c8315-375">UWP bridges</span></span></td>
        <td>[<span data-ttu-id="c8315-376">Windows にコードを移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-376">Bring your code to Windows</span></span>](https://dev.windows.com/bridges/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-377">iOS 用 Windows ブリッジ</span><span class="sxs-lookup"><span data-stu-id="c8315-377">Windows Bridge for iOS</span></span></td>
        <td>[<span data-ttu-id="c8315-378">iOS アプリを Windows に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-378">Bring your iOS apps to Windows</span></span>](https://dev.windows.com/bridges/ios)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-379">デスクトップ アプリケーション用 Windows ブリッジ (.NET および Win32)</span><span class="sxs-lookup"><span data-stu-id="c8315-379">Windows Bridge for desktop applications (.NET and Win32)</span></span></td>
        <td>[<span data-ttu-id="c8315-380">デスクトップ アプリケーションを UWP アプリに変換する</span><span class="sxs-lookup"><span data-stu-id="c8315-380">Convert your desktop application to a UWP app</span></span>](https://developer.microsoft.com/windows/bridges/desktop)</td>
    </tr>
</table>
 

#### <a name="unity"></a><span data-ttu-id="c8315-381">Unity</span><span class="sxs-lookup"><span data-stu-id="c8315-381">Unity</span></span>

<span data-ttu-id="c8315-382">Unity 5 は、2D および 3D ゲームと対話型エクスペリエンスを作成するための、受賞歴のある次世代開発プラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="c8315-382">Unity 5 is the next generation of the award-winning development platform for creating 2D and 3D games and interactive experiences.</span></span> <span data-ttu-id="c8315-383">Unity 5 により、新しい芸術性、高度なグラフィックス機能、高い効率性を手に入れることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-383">Unity 5 brings new artistic power, enhanced graphics capabilities, and improved efficiency.</span></span>

<span data-ttu-id="c8315-384">Unity 5.4 以降では、Unity は Direct3D 12 の開発をサポートします。</span><span class="sxs-lookup"><span data-stu-id="c8315-384">Beginning with Unity 5.4, Unity supports Direct3D 12 development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-385">Unity ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="c8315-385">The Unity game engine</span></span></td>
        <td>[<span data-ttu-id="c8315-386">Unity - ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="c8315-386">Unity - Game Engine</span></span>](http://unity3d.com/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-387">Unity 5 を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-387">Get Unity 5</span></span></td>
        <td>[<span data-ttu-id="c8315-388">Unity を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-388">Get Unity</span></span>](http://unity3d.com/get-unity)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-389">Unity 5.2 でのユニバーサル Windows プラットフォーム アプリのサポート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-389">Universal Windows Platform app support in Unity 5.2 (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-390">Unity 5.2 での Windows 10 ユニバーサル プラットフォーム アプリ</span><span class="sxs-lookup"><span data-stu-id="c8315-390">Windows 10 Universal Platform apps in Unity 5.2</span></span>](http://blogs.unity3d.com/2015/09/09/windows-10-universal-apps-in-unity-5-2/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-391">Windows 向けの Unity に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-391">Unity documentation for Windows</span></span></td>
        <td>[<span data-ttu-id="c8315-392">Unity マニュアル / Windows</span><span class="sxs-lookup"><span data-stu-id="c8315-392">Unity Manual / Windows</span></span>](http://docs.unity3d.com/Manual/Windows.html)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-393">Mixer の対話機能を使用して、ゲームに対話機能を追加する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-393">How to add interactivity to your game using Mixer Interactive</span></span></td>
        <td>[<span data-ttu-id="c8315-394">ファースト ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-394">Getting started guide</span></span>](https://github.com/mixer/interactive-unity-plugin/wiki/Getting-started)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-395">Unity 向け Mixer SDK</span><span class="sxs-lookup"><span data-stu-id="c8315-395">Mixer SDK for Unity</span></span></td>
        <td>[<span data-ttu-id="c8315-396">Mixer Unity プラグイン</span><span class="sxs-lookup"><span data-stu-id="c8315-396">Mixer Unity plugin</span></span>](https://www.assetstore.unity3d.com/en/#!/content/88585)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-397">Unity 向け Mixer SDK のリファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-397">Mixer SDK for Unity reference documentation</span></span></td>
        <td>[<span data-ttu-id="c8315-398">Mixer Unity プラグインの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-398">API reference for Mixer Unity plugin</span></span>](https://dev.mixer.com/reference/interactive/csharp/index.html)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-399">Unity ゲームを Windows ストアに公開する</span><span class="sxs-lookup"><span data-stu-id="c8315-399">Publish your Unity game to Windows Store</span></span></td>
        <td>[<span data-ttu-id="c8315-400">移植ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-400">Porting guide</span></span>](https://unity3d.com/partners/microsoft/porting-guides)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-401">ユニバーサル Windows プラットフォーム アプリとして Unity ゲームを公開する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-401">Publish your Unity game as a Universal Windows Platform app (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-402">UWP アプリとして Unity ゲームを公開する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-402">How to publish your Unity game as a UWP app</span></span>](https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-publish-your-Unity-game-as-a-UWP-app)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-403">Unity を使って Windows 向けゲームとアプリを作成する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-403">Use Unity to make Windows games and apps (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-404">Unity を使った Windows 向けゲームとアプリの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-404">Making Windows games and apps with Unity</span></span>](https://channel9.msdn.com/Blogs/One-Dev-Minute/Making-games-and-apps-with-Unity)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-405">Visual Studio を使った Unity ゲームの開発 (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="c8315-405">Unity game development using Visual Studio (video series)</span></span></td>
        <td>[<span data-ttu-id="c8315-406">Visual Studio 2015 での Unity の使用</span><span class="sxs-lookup"><span data-stu-id="c8315-406">Using Unity with Visual Studio 2015</span></span>](http://go.microsoft.com/fwlink/?LinkId=722359)</td>
    </tr>
</table>
 

#### <a name="havok"></a><span data-ttu-id="c8315-407">Havok</span><span class="sxs-lookup"><span data-stu-id="c8315-407">Havok</span></span>

<span data-ttu-id="c8315-408">Havok のモジュール化された一連のツールとテクノロジによって、ゲーム クリエーターは新しいレベルの対話式操作と没入感を提供できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-408">Havok’s modular suite of tools and technologies help game creators reach new levels of interactivity and immersion.</span></span> <span data-ttu-id="c8315-409">Havok により、非常にリアルな物理的効果、対話型のシミュレーション、魅力的な映像を実現できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-409">Havok enables highly realistic physics, interactive simulations, and stunning cinematics.</span></span> <span data-ttu-id="c8315-410">Version 2015.1 以上では、x86、64 ビット、ARM 上の Visual Studio 2015 で UWP を正式にサポートします。</span><span class="sxs-lookup"><span data-stu-id="c8315-410">Version 2015.1 and higher officially supports UWP in Visual Studio 2015 on x86, 64-bit, and ARM.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-411">Havok の Web サイト</span><span class="sxs-lookup"><span data-stu-id="c8315-411">Havok website</span></span></td>
        <td>[<span data-ttu-id="c8315-412">Havok</span><span class="sxs-lookup"><span data-stu-id="c8315-412">Havok</span></span>](http://www.havok.com/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-413">Havok ツール スイート</span><span class="sxs-lookup"><span data-stu-id="c8315-413">Havok tool suite</span></span></td>
        <td>[<span data-ttu-id="c8315-414">Havok 製品の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-414">Havok Product Overview</span></span>](http://www.havok.com/products/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-415">Havok サポート フォーラム</span><span class="sxs-lookup"><span data-stu-id="c8315-415">Havok support forums</span></span></td>
        <td>[<span data-ttu-id="c8315-416">Havok</span><span class="sxs-lookup"><span data-stu-id="c8315-416">Havok</span></span>](http://support.havok.com)</td>
    </tr>
</table>
 

#### <a name="monogame"></a><span data-ttu-id="c8315-417">MonoGame</span><span class="sxs-lookup"><span data-stu-id="c8315-417">MonoGame</span></span>

<span data-ttu-id="c8315-418">MonoGame は、オープン ソース、クロスプラット フォームのゲーム開発フレームワークで、当初は Microsoft の XNA Framework 4.0 に基づいていました。</span><span class="sxs-lookup"><span data-stu-id="c8315-418">MonoGame is an open source, cross-platform game development framework originally based on Microsoft's XNA Framework 4.0.</span></span> <span data-ttu-id="c8315-419">現在、Monogame は、Windows、Windows Phone、Xbox と共に、Linux、macOS、iOS、Android、その他のいくつかのプラットフォームをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c8315-419">Monogame currently supports Windows, Windows Phone, and Xbox, as well as Linux, macOS, iOS, Android, and several other platforms.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-420">MonoGame</span><span class="sxs-lookup"><span data-stu-id="c8315-420">MonoGame</span></span></td>
        <td>[<span data-ttu-id="c8315-421">MonoGame Web サイト</span><span class="sxs-lookup"><span data-stu-id="c8315-421">MonoGame website</span></span>](http://www.monogame.net)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-422">MonoGame のドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-422">MonoGame Documentation</span></span></td>
        <td>[<span data-ttu-id="c8315-423">MonoGame のドキュメント (最新)</span><span class="sxs-lookup"><span data-stu-id="c8315-423">MonoGame Documentation (latest)</span></span>](http://www.monogame.net/documentation/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-424">Monogame のダウンロード</span><span class="sxs-lookup"><span data-stu-id="c8315-424">Monogame Downloads</span></span></td>
        <td><span data-ttu-id="c8315-425">MonoGame の Web サイトから[リリース、開発ビルド、ソース コードをダウンロード](http://www.monogame.net/downloads/)するか、[NuGet から最新のリリースを入手](https://www.nuget.org/profiles/MonoGame)します。</span><span class="sxs-lookup"><span data-stu-id="c8315-425">[Download releases, development builds, and source code](http://www.monogame.net/downloads/) from the MonoGame website, or [get the latest release via NuGet](https://www.nuget.org/profiles/MonoGame).</span></span>
    </tr>
</table>


#### <a name="cocos2d"></a><span data-ttu-id="c8315-426">Cocos2d</span><span class="sxs-lookup"><span data-stu-id="c8315-426">Cocos2d</span></span>

<span data-ttu-id="c8315-427">Cocos2d-X は、オープン ソース、クロス プラットフォームのゲーム開発エンジンおよびツール スイートで、UWP ゲームの構築をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c8315-427">Cocos2d-X is a cross-platform open source game development engine and tools suite that supports building UWP games.</span></span> <span data-ttu-id="c8315-428">バージョン 3 以降、3 D 機能も追加されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-428">Beginning with version 3, 3D features are being added as well.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-429">Cocos2d-x</span><span class="sxs-lookup"><span data-stu-id="c8315-429">Cocos2d-x</span></span></td>
        <td>[<span data-ttu-id="c8315-430">Cocos2d-X とは</span><span class="sxs-lookup"><span data-stu-id="c8315-430">What is Cocos2d-X?</span></span>](http://www.cocos2d-x.org/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-431">Cocos2d-x プログラマ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-431">Cocos2d-x programmer's guide</span></span></td>
        <td>[<span data-ttu-id="c8315-432">Cocos2d-x プログラマ ガイド v3.8</span><span class="sxs-lookup"><span data-stu-id="c8315-432">Cocos2d-x Programmers Guide v3.8</span></span>](http://www.cocos2d-x.org/programmersguide/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-433">Windows 10 での Cocos2d-x (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-433">Cocos2d-x on Windows 10 (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-434">Windows 10 での Cocos2d-x の実行</span><span class="sxs-lookup"><span data-stu-id="c8315-434">Running Cocos2d-x on Windows 10</span></span>](https://blogs.windows.com/buildingapps/2015/06/15/running-cocos2d-x-on-windows-10/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-435">Cocos2d-x Windows ストア ゲーム (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-435">Cocos2d-x Windows Store games (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-436">Cocos2d-x を使った Windows デバイス用ゲームの構築</span><span class="sxs-lookup"><span data-stu-id="c8315-436">Build a Game with Cocos2d-x for Windows Devices</span></span>](http://www.microsoftvirtualacademy.com/training-courses/build-a-game-with-cocos2d-x-for-windows-devices)</td>
    </tr>
</table>


#### <a name="unreal-engine"></a><span data-ttu-id="c8315-437">Unreal Engine</span><span class="sxs-lookup"><span data-stu-id="c8315-437">Unreal Engine</span></span>

<span data-ttu-id="c8315-438">Unreal Engine 4 は、あらゆる種類のゲームや開発者に適したゲーム開発ツールがすべて揃ったスイートです。</span><span class="sxs-lookup"><span data-stu-id="c8315-438">Unreal Engine 4 is a complete suite of game development tools for all types of games and developers.</span></span> <span data-ttu-id="c8315-439">最も要求の厳しいコンソールおよび PC ゲームにおいて、Unreal Engine は世界中のゲーム開発者により使用されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-439">For the most demanding console and PC games, Unreal Engine is used by game developers worldwide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-440">Unreal Engine の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-440">Unreal Engine overview</span></span></td>
        <td>[<span data-ttu-id="c8315-441">Unreal Engine 4</span><span class="sxs-lookup"><span data-stu-id="c8315-441">Unreal Engine 4</span></span>](https://www.unrealengine.com/what-is-unreal-engine-4)</td>
    </tr>
</table>

#### <a name="babylonjs"></a><span data-ttu-id="c8315-442">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="c8315-442">BabylonJS</span></span>

<span data-ttu-id="c8315-443">BabylonJS は、HTML5、WebGL、Web オーディオで 3D ゲームを構築するための完全な JavaScript フレームワークです。</span><span class="sxs-lookup"><span data-stu-id="c8315-443">BabylonJS is a complete JavaScript framework for building 3D games with HTML5, WebGL, and Web Audio.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-444">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="c8315-444">BabylonJS</span></span></td>
        <td>[<span data-ttu-id="c8315-445">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="c8315-445">BabylonJS</span></span>](http://www.babylonjs.com/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-446">HTML5 と BabylonJS を使用した WebGL 3D (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="c8315-446">WebGL 3D with HTML5 and BabylonJS (video series)</span></span></td>
        <td>[<span data-ttu-id="c8315-447">WebGL 3D と BabylonJS について</span><span class="sxs-lookup"><span data-stu-id="c8315-447">Learning WebGL 3D and BabylonJS</span></span>](https://channel9.msdn.com/Series/Introduction-to-WebGL-3D-with-HTML5-and-Babylonjs/01)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-448">BabylonJS を使用してクロスプラットフォーム WebGL ゲームを構築する</span><span class="sxs-lookup"><span data-stu-id="c8315-448">Building a cross-platform WebGL game with BabylonJS</span></span></td>
        <td>[<span data-ttu-id="c8315-449">BabylonJS を使用してクロスプラットフォーム ゲームを開発する</span><span class="sxs-lookup"><span data-stu-id="c8315-449">Use BabylonJS to develop a cross-platform game</span></span>](https://www.smashingmagazine.com/2016/07/babylon-js-building-sponza-a-cross-platform-webgl-game/)</td>
    </tr>    
</table>

### <a name="middleware-and-partners"></a><span data-ttu-id="c8315-450">ミドルウェアとパートナー</span><span class="sxs-lookup"><span data-stu-id="c8315-450">Middleware and partners</span></span>

<span data-ttu-id="c8315-451">ほかにも数多くのミドルウェアとエンジンのパートナーが、ゲーム開発のニーズに応じてソリューションを提供しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-451">There are many other middleware and engine partners that can provide solutions depending on your game development needs.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-452">Windows デベロッパー センターのパートナー</span><span class="sxs-lookup"><span data-stu-id="c8315-452">Windows Dev Center partners</span></span></td>
        <td>[<span data-ttu-id="c8315-453">デベロッパー センターのパートナー</span><span class="sxs-lookup"><span data-stu-id="c8315-453">Dev Center Partners</span></span>](https://developer.microsoft.com/windows/app-middleware-partners)</td>
    </tr>
</table>


### <a name="porting-your-game"></a><span data-ttu-id="c8315-454">ゲームの移植</span><span class="sxs-lookup"><span data-stu-id="c8315-454">Porting your game</span></span>

<span data-ttu-id="c8315-455">既にゲームがある場合は、ゲームを短期間で UWP に移植するのに役立つ多くのリソースやガイドがあります。</span><span class="sxs-lookup"><span data-stu-id="c8315-455">If you have an existing game, there are many resources and guides available to help you quickly bring your game to the UWP.</span></span> <span data-ttu-id="c8315-456">移植作業をすぐに開始する場合は、[ユニバーサル Windows プラットフォーム ブリッジ](#universal-windows-platform-bridges)を使うことも検討してください。</span><span class="sxs-lookup"><span data-stu-id="c8315-456">To jumpstart your porting efforts, you might also consider using a [Universal Windows Platform Bridge](#universal-windows-platform-bridges).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-457">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-457">Porting a Windows 8 app to a Universal Windows Platform app</span></span></td>
        <td>[<span data-ttu-id="c8315-458">Windows ランタイム 8.x から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="c8315-458">Move from Windows Runtime 8.x to UWP</span></span>](https://msdn.microsoft.com/library/windows/apps/mt238322)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-459">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-459">Porting a Windows 8 app to a Universal Windows Platform app (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-460">8.1 アプリの Windows 10 への移植</span><span class="sxs-lookup"><span data-stu-id="c8315-460">Porting 8.1 Apps to Windows 10</span></span>](https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/21)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-461">iOS アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-461">Porting an iOS app to a Universal Windows Platform app</span></span></td>
        <td>[<span data-ttu-id="c8315-462">iOS から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="c8315-462">Move from iOS to UWP</span></span>](https://msdn.microsoft.com/library/windows/apps/mt238320)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-463">Silverlight アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-463">Porting a Silverlight app to a Universal Windows Platform app</span></span></td>
        <td>[<span data-ttu-id="c8315-464">Windows Phone Silverlight から UWP への移行</span><span class="sxs-lookup"><span data-stu-id="c8315-464">Move from Windows Phone Silverlight to UWP</span></span>](https://msdn.microsoft.com/library/windows/apps/mt238323)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-465">XAML または Silverlight からユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-465">Porting from XAML or Silverlight to a Universal Windows Platform app (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-466">XAML または Silverlight から Windows 10 へのアプリの移植</span><span class="sxs-lookup"><span data-stu-id="c8315-466">Porting an App from XAML or Silverlight to Windows 10</span></span>](https://channel9.msdn.com/Events/Build/2015/3-741)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-467">Xbox ゲームをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-467">Porting an Xbox game to a Universal Windows Platform app</span></span></td>
        <td>[<span data-ttu-id="c8315-468">Xbox One から Windows 10 UWP への移植</span><span class="sxs-lookup"><span data-stu-id="c8315-468">Porting from Xbox One to Windows 10 UWP</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-469">DirectX 9 から DirectX 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-469">Porting from DirectX 9 to DirectX 11</span></span></td>
        <td>[<span data-ttu-id="c8315-470">DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植</span><span class="sxs-lookup"><span data-stu-id="c8315-470">Port from DirectX 9 to Universal Windows Platform (UWP)</span></span>](porting-your-directx-9-game-to-windows-store.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-471">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-471">Porting from Direct3D 11 to Direct3D 12</span></span></td>
        <td>[<span data-ttu-id="c8315-472">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-472">Porting from Direct3D 11 to Direct3D 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt431709)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-473">OpenGL ES から Direct3D 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-473">Porting from OpenGL ES to Direct3D 11</span></span></td>
        <td>[<span data-ttu-id="c8315-474">OpenGL ES 2.0 から Direct3D 11 への移植</span><span class="sxs-lookup"><span data-stu-id="c8315-474">Port from OpenGL ES 2.0 to Direct3D 11</span></span>](port-from-opengl-es-2-0-to-directx-11-1.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-475">ANGLE を使って OpenGL ES から Direct3D 11 に移行する</span><span class="sxs-lookup"><span data-stu-id="c8315-475">OpenGL ES to Direct3D 11 using ANGLE</span></span></td>
        <td>[<span data-ttu-id="c8315-476">ANGLE</span><span class="sxs-lookup"><span data-stu-id="c8315-476">ANGLE</span></span>](http://go.microsoft.com/fwlink/p/?linkid=618387)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-477">UWP で従来の Windows API に相当する要素</span><span class="sxs-lookup"><span data-stu-id="c8315-477">Classic Windows API equivalents in the UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-478">ユニバーサル Windows プラットフォーム (UWP) アプリでの Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="c8315-478">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</span></span>](https://msdn.microsoft.com/library/windows/apps/hh464945)</td>
    </tr>
</table>


## <a name="prototype-and-design"></a><span data-ttu-id="c8315-479">プロトタイプとデザイン</span><span class="sxs-lookup"><span data-stu-id="c8315-479">Prototype and design</span></span>


<span data-ttu-id="c8315-480">作成するゲームの種類と、ゲームの構築に使うツールとグラフィックス テクノロジが決まったら、すぐにデザインとプロトタイプを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-480">Now that you've decided the type of game you want to create and the tools and graphics technology you'll use to build it, you're ready to get started with the design and prototype.</span></span> <span data-ttu-id="c8315-481">ゲームのコアはユニバーサル Windows プラットフォーム アプリであるため、そこから作業を開始します。</span><span class="sxs-lookup"><span data-stu-id="c8315-481">At its core, your game is a Universal Windows Platform app, so that's where you'll begin.</span></span>

### <a name="introduction-to-the-universal-windows-platform-uwp"></a><span data-ttu-id="c8315-482">ユニバーサル Windows プラットフォーム (UWP) の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-482">Introduction to the Universal Windows Platform (UWP)</span></span>

<span data-ttu-id="c8315-483">Windows 10 ではユニバーサル Windows プラットフォーム (UWP) が導入され、Windows 10 デバイス間で共通の API プラットフォームが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c8315-483">Windows 10 introduces the Universal Windows Platform (UWP), which provides a common API platform across Windows 10 devices.</span></span> <span data-ttu-id="c8315-484">UWP は、Windows ランタイム モデルを発展させて拡張したもので、まとまりのある統一されたコアとなっています。</span><span class="sxs-lookup"><span data-stu-id="c8315-484">UWP evolves and expands the Windows Runtime model and hones it into a cohesive, unified core.</span></span> <span data-ttu-id="c8315-485">UWP を対象とするゲームでは、すべてのデバイスに共通する WinRT API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-485">Games that target the UWP can call WinRT APIs that are common to all devices.</span></span> <span data-ttu-id="c8315-486">UWP により保証されたコア API 層が提供されるため、あらゆる Windows 10 デバイスにインストールできる 1 つのアプリ パッケージを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-486">Because the UWP provides a guaranteed core API layer, you can choose to create a single app package that will install across Windows 10 devices.</span></span> <span data-ttu-id="c8315-487">また、必要に応じて、ゲームが実行されるデバイスに固有の API (Win32 や .NET の従来の Windows API など) を、ゲームで呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-487">And if you want to, your game can still call APIs (including some classic Windows APIs from Win32 and .NET) that are specific to the devices your game runs on.</span></span>

<span data-ttu-id="c8315-488">UWP の目的は、次のようなことを実現することです。</span><span class="sxs-lookup"><span data-stu-id="c8315-488">The goal of the UWP is to have:</span></span>

-   <span data-ttu-id="c8315-489">1 つのコア オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="c8315-489">One core operating system</span></span>
-   <span data-ttu-id="c8315-490">1 つのアプリケーション プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="c8315-490">One application platform</span></span>
-   <span data-ttu-id="c8315-491">1 つのゲーム ソーシャル ネットワーク</span><span class="sxs-lookup"><span data-stu-id="c8315-491">One gaming social network</span></span>
-   <span data-ttu-id="c8315-492">1 つのストア</span><span class="sxs-lookup"><span data-stu-id="c8315-492">One store</span></span>
-   <span data-ttu-id="c8315-493">1 つのインジェスト パス</span><span class="sxs-lookup"><span data-stu-id="c8315-493">One ingestion path</span></span>

<span data-ttu-id="c8315-494">次に示すガイドは、ユニバーサル Windows プラットフォーム アプリについて詳しく説明している優れたガイドであり、このプラットフォームを理解するために一読することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8315-494">The following are excellent guides that discuss the Universal Windows Platform apps in detail, and are recommended reading to help you understand the platform.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-495">ユニバーサル Windows プラットフォーム アプリの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-495">Introduction to Universal Windows Platform apps</span></span></td>
        <td>[<span data-ttu-id="c8315-496">ユニバーサル Windows プラットフォーム アプリとは</span><span class="sxs-lookup"><span data-stu-id="c8315-496">What's a Universal Windows Platform app?</span></span>](https://msdn.microsoft.com/library/windows/apps/dn726767)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-497">UWP の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-497">Overview of the UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-498">UWP アプリ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-498">Guide to UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn894631)</td>
    </tr>
</table>
 

### <a name="getting-started-with-uwp-development"></a><span data-ttu-id="c8315-499">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-499">Getting started with UWP development</span></span>

<span data-ttu-id="c8315-500">ユニバーサル Windows プラットフォーム アプリを開発するための準備は非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="c8315-500">Getting set up and ready to develop a Universal Windows Platform app is quick and easy.</span></span> <span data-ttu-id="c8315-501">以下のガイドでは、プロセスの詳しい手順を説明しています。</span><span class="sxs-lookup"><span data-stu-id="c8315-501">The following guides take you through the process step-by-step.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-502">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-502">Getting started with UWP development</span></span></td>
        <td>[<span data-ttu-id="c8315-503">Windows アプリの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-503">Get started with Windows apps</span></span>](https://dev.windows.com/getstarted)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-504">UWP 開発の準備</span><span class="sxs-lookup"><span data-stu-id="c8315-504">Getting set up for UWP development</span></span></td>
        <td>[<span data-ttu-id="c8315-505">準備</span><span class="sxs-lookup"><span data-stu-id="c8315-505">Get set up</span></span>](https://msdn.microsoft.com/library/windows/apps/dn726766)</td>
    </tr>
</table>

<span data-ttu-id="c8315-506">UWP プログラミングについて "文字どおりの初心者" である場合や、ゲームで XAML の使用を検討している場合 (「[グラフィックス テクノロジとプログラミング言語の選択](#choosing-your-graphics-technology-and-programming-language)」を参照) は、最初に[文字どおりの初心者のための Windows 10 の開発](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)に関するビデオ シリーズをご覧になることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c8315-506">If you're an "absolute beginner" to UWP programming, and are considering using XAML in your game (see [Choosing your graphics technology and programming language](#choosing-your-graphics-technology-and-programming-language)), the [Windows 10 development for absolute beginners](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners) video series is a good place to start.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-507">XAML を使った Windows 10 の開発の初心者向けガイド (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="c8315-507">Beginners guide to Windows 10 development with XAML (Video series)</span></span></td>
        <td>[<span data-ttu-id="c8315-508">文字どおりの初心者のための Windows 10 の開発</span><span class="sxs-lookup"><span data-stu-id="c8315-508">Windows 10 development for absolute beginners</span></span>](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-509">XAML を使う Windows 10 の初心者向けシリーズの発表 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-509">Announcing the Windows 10 absolute beginners series using XAML (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-510">文字どおりの初心者のための Windows 10 の開発</span><span class="sxs-lookup"><span data-stu-id="c8315-510">Windows 10 development for absolute beginners</span></span>](http://blogs.windows.com/buildingapps/2015/09/30/windows-10-development-for-absolute-beginners/)</td>
    </tr>
</table>

### <a name="uwp-development-concepts"></a><span data-ttu-id="c8315-511">UWP 開発の概念</span><span class="sxs-lookup"><span data-stu-id="c8315-511">UWP development concepts</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-512">ユニバーサル Windows プラットフォーム アプリの開発の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-512">Overview of Universal Windows Platform app development</span></span></td>
        <td>[<span data-ttu-id="c8315-513">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-513">Develop Windows apps</span></span>](https://dev.windows.com/develop)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-514">UWP のネットワーク プログラミングの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-514">Overview of network programming in the UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-515">ネットワークと Web サービス</span><span class="sxs-lookup"><span data-stu-id="c8315-515">Networking and web services</span></span>](https://msdn.microsoft.com/library/windows/apps/mt280378)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-516">ゲームでの Windows.Web.HTTP と Windows.Networking.Sockets の使用</span><span class="sxs-lookup"><span data-stu-id="c8315-516">Using Windows.Web.HTTP and Windows.Networking.Sockets in games</span></span></td>
        <td>[<span data-ttu-id="c8315-517">ゲームのネットワーク</span><span class="sxs-lookup"><span data-stu-id="c8315-517">Networking for games</span></span>](work-with-networking-in-your-directx-game.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-518">UWP での非同期プログラミングの概念</span><span class="sxs-lookup"><span data-stu-id="c8315-518">Asynchronous programming concepts in the UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-519">非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="c8315-519">Asynchronous programming</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187335)</td>
    </tr>
</table>

### <a name="windows-desktop-apis-to-uwp"></a><span data-ttu-id="c8315-520">Windows デスクトップ API から UWP へ</span><span class="sxs-lookup"><span data-stu-id="c8315-520">Windows Desktop APIs to UWP</span></span>

<span data-ttu-id="c8315-521">Windows デスクトップ ゲームを UWP に移行する際に役立つリンクの一部を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="c8315-521">These are some links to help you move your Windows desktop game to UWP.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-522">既存の C++ コードを使った UWP ゲーム開発</span><span class="sxs-lookup"><span data-stu-id="c8315-522">Use existing C++ code for UWP game development</span></span></td>
        <td>[<span data-ttu-id="c8315-523">UWP アプリで既存の C++ コードを使う方法</span><span class="sxs-lookup"><span data-stu-id="c8315-523">How to: Use existing C++ code in a UWP app</span></span>](https://docs.microsoft.com/cpp/porting/how-to-use-existing-cpp-code-in-a-universal-windows-platform-app)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-524">Win32 API と COM API 用の UWP API</span><span class="sxs-lookup"><span data-stu-id="c8315-524">UWP APIs for Win32 and COM APIs</span></span></td>
        <td>[<span data-ttu-id="c8315-525">UWP アプリ用の Win32 API と COM API</span><span class="sxs-lookup"><span data-stu-id="c8315-525">Win32 and COM APIs for UWP apps</span></span>](https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-526">UWP でサポートされない CRT 関数</span><span class="sxs-lookup"><span data-stu-id="c8315-526">Unsupported CRT functions in UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-527">ユニバーサル Windows プラットフォーム アプリでサポートされていない CRT 関数</span><span class="sxs-lookup"><span data-stu-id="c8315-527">CRT functions not supported in Universal Windows Platform apps</span></span>](https://msdn.microsoft.com/library/windows/apps/jj606124.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-528">Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="c8315-528">Alternatives for Windows APIs</span></span></td>
        <td>[<span data-ttu-id="c8315-529">ユニバーサル Windows プラットフォーム (UWP) アプリでの Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="c8315-529">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</span></span>](https://msdn.microsoft.com/library/windows/apps/mt592894.aspx)</td>
    </tr>
</table>
 

### <a name="process-lifetime-management"></a><span data-ttu-id="c8315-530">プロセス ライフタイム管理</span><span class="sxs-lookup"><span data-stu-id="c8315-530">Process lifetime management</span></span>

<span data-ttu-id="c8315-531">プロセス ライフタイム管理、つまりアプリのライフ サイクルは、ユニバーサル Windows プラットフォーム アプリが取り得るさまざまなアクティブ化状態を表します。</span><span class="sxs-lookup"><span data-stu-id="c8315-531">Process lifetime management, or app lifecyle, describes the various activation states that a Universal Windows Platform app can transition through.</span></span> <span data-ttu-id="c8315-532">ゲームは、アクティブ化、中断、再開、または終了することができ、さまざまな方法でこれらの状態を移行できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-532">Your game can be activated, suspended, resumed, or terminated, and can transition through those states in a variety of ways.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-533">アプリのライフ サイクルの移行の処理</span><span class="sxs-lookup"><span data-stu-id="c8315-533">Handling app lifecyle transitions</span></span></td>
        <td>[<span data-ttu-id="c8315-534">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="c8315-534">App lifecycle</span></span>](https://msdn.microsoft.com/library/windows/apps/mt243287)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-535">Microsoft Visual Studio を使ったアプリの移行のトリガー</span><span class="sxs-lookup"><span data-stu-id="c8315-535">Using Microsoft Visual Studio to trigger app transitions</span></span></td>
        <td>[<span data-ttu-id="c8315-536">Visual Studio で Windows ストア アプリの一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法</span><span class="sxs-lookup"><span data-stu-id="c8315-536">How to trigger suspend, resume, and background events for Windows Store apps in Visual Studio</span></span>](https://msdn.microsoft.com/library/hh974425.aspx)</td>
    </tr>
</table>
 

### <a name="designing-game-ux"></a><span data-ttu-id="c8315-537">ゲーム UX の設計</span><span class="sxs-lookup"><span data-stu-id="c8315-537">Designing game UX</span></span>

<span data-ttu-id="c8315-538">優れたゲームはすばらしいデザインから始まります。</span><span class="sxs-lookup"><span data-stu-id="c8315-538">The genesis of a great game is inspired design.</span></span>

<span data-ttu-id="c8315-539">ゲームは、共通のユーザー インターフェイス要素とデザイン原則をアプリと共有していますが、ユーザー エクスペリエンスの外観、機能、設計目標が独特であることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="c8315-539">Games share some common user interface elements and design principles with apps, but games often have a unique look, feel, and design goal for their user experience.</span></span> <span data-ttu-id="c8315-540">テストされた UX をゲームで使用すべきなのはいつか、斬新で革新的な UX を使用すべきなのはいつか、という両方の側面に、よく考えられたデザインを当てはめるときにゲームは成功します。</span><span class="sxs-lookup"><span data-stu-id="c8315-540">Games succeed when thoughtful design is applied to both aspects—when should your game use tested UX, and when should it diverge and innovate?</span></span> <span data-ttu-id="c8315-541">ゲームに選択したプレゼンテーション テクノロジ (DirectX、XAML、HTML5、または 3 つの組み合わせ) は、実装の細部に影響を与える可能性がありますが、適用するデザイン原則はその選択とはほとんど関係がありません。</span><span class="sxs-lookup"><span data-stu-id="c8315-541">The presentation technology that you choose for your game—DirectX, XAML, HTML5, or some combination of the three—will influence implementation details, but the design principles you apply are largely independent of that choice.</span></span>

<span data-ttu-id="c8315-542">UX デザインとは別に、レベルのデザイン、ペース配分、世界のデザインなどのゲームプレイのデザインには独自の様式があり、開発者や開発チームによって決定されるため、この開発ガイドに記載していません。</span><span class="sxs-lookup"><span data-stu-id="c8315-542">Separately from UX design, gameplay design such as level design, pacing, world design, and other aspects is an art form of its own—one that's up to you and your team, and not covered in this development guide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-543">UWP の設計の基本とガイドライン</span><span class="sxs-lookup"><span data-stu-id="c8315-543">UWP design basics and guidelines</span></span></td>
        <td>[<span data-ttu-id="c8315-544">UWP アプリの設計</span><span class="sxs-lookup"><span data-stu-id="c8315-544">Designing UWP apps</span></span>](https://dev.windows.com/design)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-545">アプリのライフサイクルの状態の設計</span><span class="sxs-lookup"><span data-stu-id="c8315-545">Designing for app lifecycle states</span></span></td>
        <td>[<span data-ttu-id="c8315-546">起動、中断、再開の UX ガイドライン</span><span class="sxs-lookup"><span data-stu-id="c8315-546">UX guidelines for launch, suspend, and resume</span></span>](https://msdn.microsoft.com/library/windows/apps/dn611862)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-547">Xbox One とテレビ画面向けの UWP アプリの設計</span><span class="sxs-lookup"><span data-stu-id="c8315-547">Design your UWP app for Xbox One and television screens</span></span></td>
        <td>[<span data-ttu-id="c8315-548">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="c8315-548">Designing for Xbox and TV</span></span>](https://docs.microsoft.com/windows/uwp/input-and-devices/designing-for-tv)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-549">複数のデバイスのフォーム ファクターをターゲットに設定する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-549">Targeting multiple device form factors (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-550">Windows コアの世界向けのゲームの設計</span><span class="sxs-lookup"><span data-stu-id="c8315-550">Designing Games for a Windows Core World</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Designing-Games-for-a-Windows-Core-World)</td>
    </tr>   
</table>
 

#### <a name="color-guideline-and-palette"></a><span data-ttu-id="c8315-551">色のガイドラインとパレット</span><span class="sxs-lookup"><span data-stu-id="c8315-551">Color guideline and palette</span></span>

<span data-ttu-id="c8315-552">ゲームで一貫した色のガイドラインに従うと、美しさやナビゲーションの操作性が向上し、メニューや HUD の機能がプレイヤーに伝わりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="c8315-552">Following a consistent color guideline in your game improves aesthetics, aids navigation, and is a powerful tool to inform the player of menu and HUD functionality.</span></span> <span data-ttu-id="c8315-553">警告、ダメージ、XP、成績などのゲーム要素の色が一貫していると、UI がわかりやすくなるため、ラベルによって説明する必要性が減ります。</span><span class="sxs-lookup"><span data-stu-id="c8315-553">Consistent coloring of game elements like warnings, damage, XP, and achievements can lead to cleaner UI and reduce the need for explicit labels.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-554">色のガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-554">Color guide</span></span></td>
        <td>[<span data-ttu-id="c8315-555">ベストプラクティス: 色</span><span class="sxs-lookup"><span data-stu-id="c8315-555">Best Practices: Color</span></span>](https://assets.windowsphone.com/499cd2be-64ed-4b05-a4f5-cd0c9ad3f6a3/101_BestPractices_Color_InvariantCulture_Default.zip)</td>
    </tr>
</table>
 

#### <a name="typography"></a><span data-ttu-id="c8315-556">文字体裁</span><span class="sxs-lookup"><span data-stu-id="c8315-556">Typography</span></span>

<span data-ttu-id="c8315-557">文字体裁を適切に使うと、UI のレイアウト、ナビゲーション、読みやすさ、雰囲気、ブランド、プレイヤーの熱中度など、多くの側面が向上します。</span><span class="sxs-lookup"><span data-stu-id="c8315-557">The appropriate use of typography enhances many aspects of your game, including UI layout, navigation, readability, atmosphere, brand, and player immersion.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-558">文字体裁のガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-558">Typography guide</span></span></td>
        <td>[<span data-ttu-id="c8315-559">ベスト プラクティス: 文字体裁</span><span class="sxs-lookup"><span data-stu-id="c8315-559">Best Practices: Typography</span></span>](http://go.microsoft.com/fwlink/?LinkId=535007)</td>
    </tr>
</table>
 

#### <a name="ui-map"></a><span data-ttu-id="c8315-560">UI マップ</span><span class="sxs-lookup"><span data-stu-id="c8315-560">UI map</span></span>

<span data-ttu-id="c8315-561">UI マップとは、ゲーム ナビゲーションのレイアウトとフローチャートで表されるメニューのことです。</span><span class="sxs-lookup"><span data-stu-id="c8315-561">A UI map is a layout of game navigation and menus expressed as a flowchart.</span></span> <span data-ttu-id="c8315-562">UI マップを使うと、すべての関係者が、ゲームのインターフェイスとナビゲーション パスを理解しやすくなり、開発サイクルの初期段階で潜在的な障害や行き詰まりが明らかになります。</span><span class="sxs-lookup"><span data-stu-id="c8315-562">The UI map helps all involved stakeholders understand the game’s interface and navigation paths, and can expose potential roadblocks and dead ends early in the development cycle.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-563">UI マップ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-563">UI map guide</span></span></td>
        <td>[<span data-ttu-id="c8315-564">ベスト プラクティス: UI マップ</span><span class="sxs-lookup"><span data-stu-id="c8315-564">Best Practices: UI Map</span></span>](http://go.microsoft.com/fwlink/?LinkId=535008)</td>
    </tr>
</table>

### <a name="game-audio"></a><span data-ttu-id="c8315-565">ゲーム オーディオ</span><span class="sxs-lookup"><span data-stu-id="c8315-565">Game audio</span></span>

<span data-ttu-id="c8315-566">XAudio2、XAPO、Windows Sonic を使ってオーディオをゲームで実装するためのガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-566">Guides and references for implementing audio in games using XAudio2, XAPO, and Windows Sonic.</span></span> <span data-ttu-id="c8315-567">XAudio2 は、パフォーマンスの高いオーディオ エンジンを開発するための、信号処理とミキシングの基盤を提供する低水準のオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="c8315-567">XAudio2 is a low-level audio API that provides signal processing and mixing foundation for developing high performance audio engines.</span></span> <span data-ttu-id="c8315-568">XAPO API を使用すると、XAudio2 を使用するクロスプラットフォーム オーディオ処理オブジェクト (XAPO) を、Windows と Xbox の両方で作成できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-568">XAPO API allows the creation of cross-platform audio processing objects (XAPO) for use in XAudio2 on both Windows and Xbox.</span></span> <span data-ttu-id="c8315-569">Windows Sonic オーディオのサポートにより、ゲームやストリーミング メディア アプリケーションに、Dolby Atmos for Home Theater、Dolby Atmos for Headphones、Windows HRTF のサポートを追加できます。</span><span class="sxs-lookup"><span data-stu-id="c8315-569">Windows Sonic audio support allows you to add Dolby Atmos for Home Theater, Dolby Atmos for Headphones, and Windows HRTF support to your game or streaming media application.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-570">XAudio2 API</span><span class="sxs-lookup"><span data-stu-id="c8315-570">XAudio2 APIs</span></span></td>
        <td>[<span data-ttu-id="c8315-571">XAudio2 のプログラミング ガイドと API リファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-571">Programming guide and API reference for XAudio2</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh405049.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-572">クロスプラット フォーム オーディオ処理オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="c8315-572">Create cross-platform audio processing objects</span></span></td>
        <td>[<span data-ttu-id="c8315-573">XAPO 概要</span><span class="sxs-lookup"><span data-stu-id="c8315-573">XAPO Overview</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee415735.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-574">オーディオの概念の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-574">Intro to audio concepts</span></span></td>
        <td>[<span data-ttu-id="c8315-575">ゲームのオーディオ</span><span class="sxs-lookup"><span data-stu-id="c8315-575">Audio for games</span></span>](working-with-audio-in-your-directx-game.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-576">Windows Sonic の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-576">Windows Sonic overview</span></span></td>
        <td>[<span data-ttu-id="c8315-577">立体音響</span><span class="sxs-lookup"><span data-stu-id="c8315-577">Spatial sound</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt807491.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-578">Windows Sonic の立体音響のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-578">Windows Sonic spatial sound samples</span></span></td>
        <td>[<span data-ttu-id="c8315-579">Xbox Advanced Technology Group のオーディオ サンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-579">Xbox Advanced Technology Group audio samples</span></span>](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/Audio)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-580">Windows Sonic をゲーム (ビデオ) に統合する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-580">Learn how to integrate Windows Sonic into your games (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-581">Windows および Xbox 用の空間オーディオ機能の導入</span><span class="sxs-lookup"><span data-stu-id="c8315-581">Introducing Spatial Audio Capabilities for Xbox and Windows</span></span>](https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-002)</td>
    </tr>
</table>

### <a name="directx-development"></a><span data-ttu-id="c8315-582">DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="c8315-582">DirectX development</span></span>

<span data-ttu-id="c8315-583">DirectX ゲーム開発用のガイドと参照情報を紹介します。</span><span class="sxs-lookup"><span data-stu-id="c8315-583">Guides and references for DirectX game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-584">UWP での DirectX ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-584">DirectX game development on the UWP</span></span></td>
        <td>[<span data-ttu-id="c8315-585">ゲームと DirectX</span><span class="sxs-lookup"><span data-stu-id="c8315-585">Games and DirectX</span></span>](index.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-586">UWP アプリ モデルによる DirectX の操作</span><span class="sxs-lookup"><span data-stu-id="c8315-586">DirectX interaction with the UWP app model</span></span></td>
        <td>[<span data-ttu-id="c8315-587">アプリ オブジェクトと DirectX</span><span class="sxs-lookup"><span data-stu-id="c8315-587">The app object and DirectX</span></span>](about-the-metro-style-user-interface-and-directx.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-588">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="c8315-588">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td>[<span data-ttu-id="c8315-589">Microsoft DirectX 12 とグラフィックスに関する教育</span><span class="sxs-lookup"><span data-stu-id="c8315-589">Microsoft DirectX 12 and Graphics Education</span></span>](https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-590">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-590">DirectX overviews and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-591">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="c8315-591">DirectX Graphics and Gaming</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee663274)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-592">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="c8315-592">Direct3D 12 programming guide and reference</span></span></td>
        <td>[<span data-ttu-id="c8315-593">Direct3D 12 グラフィックス</span><span class="sxs-lookup"><span data-stu-id="c8315-593">Direct3D 12 Graphics</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-594">DirectX 12 の基本事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-594">DirectX 12 fundamentals (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-595">強化されたパワーとパフォーマンスの向上: DirectX 12 でのゲーム</span><span class="sxs-lookup"><span data-stu-id="c8315-595">Better Power, Better Performance: Your Game on DirectX 12</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Better-Power-Better-Performance-Your-Game-on-DirectX12)</td>
    </tr>
</table>

#### <a name="learning-direct3d-12"></a><span data-ttu-id="c8315-596">Direct3D 12 について</span><span class="sxs-lookup"><span data-stu-id="c8315-596">Learning Direct3D 12</span></span>

<span data-ttu-id="c8315-597">Direct3D 12 での変更点、および Direct3D 12 を使ってプログラミングを開始する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c8315-597">Learn what changed in Direct3D 12 and how to start programming using Direct3D 12.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-598">プログラミング環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="c8315-598">Set up programming environment</span></span></td>
        <td>[<span data-ttu-id="c8315-599">Direct3D 12 プログラミング環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="c8315-599">Direct3D 12 programming environment setup</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn899120.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-600">基本的なコンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-600">How to create a basic component</span></span></td>
        <td>[<span data-ttu-id="c8315-601">Direct3D 12 の基本的なコンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-601">Creating a basic Direct3D 12 component</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn859356.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-602">Direct3D 12 での変更点</span><span class="sxs-lookup"><span data-stu-id="c8315-602">Changes in Direct3D 12</span></span></td>
        <td>[<span data-ttu-id="c8315-603">Direct3D 11 から Direct3D 12 に移行された重要な変更点</span><span class="sxs-lookup"><span data-stu-id="c8315-603">Important changes migrating from Direct3D 11 to Direct3D 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn899194.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-604">Direct3D 11 から Direct3D 12 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-604">How to port from Direct3D 11 to Direct3D 12</span></span></td>
        <td>[<span data-ttu-id="c8315-605">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="c8315-605">Porting from Direct3D 11 to Direct3D 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt431709.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-606">リソース バインディングの概念 (対象となる記述子、記述子テーブル、記述子ヒープ、およびルート署名)</span><span class="sxs-lookup"><span data-stu-id="c8315-606">Resource binding concepts (covering descriptor, descriptor table, descriptor heap, and root signature)</span></span> </td>
        <td>[<span data-ttu-id="c8315-607">Direct3D 12 でのリソース バインディング</span><span class="sxs-lookup"><span data-stu-id="c8315-607">Resource binding in Direct3D 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn899206.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-608">メモリ管理</span><span class="sxs-lookup"><span data-stu-id="c8315-608">Managing memory</span></span></td>
        <td>[<span data-ttu-id="c8315-609">Direct3D 12 でのメモリ管理</span><span class="sxs-lookup"><span data-stu-id="c8315-609">Memory management in Direct3D 12</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn899198.aspx)</td>
    </tr>
</table>
 
#### <a name="directx-tool-kit-and-libraries"></a><span data-ttu-id="c8315-610">DirectX ツール キットとライブラリ</span><span class="sxs-lookup"><span data-stu-id="c8315-610">DirectX Tool Kit and libraries</span></span>

<span data-ttu-id="c8315-611">DirectX ツール キット、DirectX テクスチャ処理ライブラリ、DirectXMesh ジオメトリ処理ライブラリ、UVAtlas ライブラリ、DirectXMath ライブラリは、DirectX 開発用のテクスチャ、メッシュ、スプライト、その他のユーティリティ機能とヘルパー クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-611">The DirectX Tool Kit, DirectX texture processing library, DirectXMesh geometry processing library, UVAtlas library, and DirectXMath library provide texture, mesh, sprite, and other utility functionality and helper classes for DirectX development.</span></span> <span data-ttu-id="c8315-612">これらのライブラリは、開発にかかる時間と労力を減らすのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c8315-612">These libraries can help you save development time and effort.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-613">DirectX 11 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-613">Get DirectX Tool Kit for DirectX 11</span></span></td>
        <td>[<span data-ttu-id="c8315-614">DirectXTK</span><span class="sxs-lookup"><span data-stu-id="c8315-614">DirectXTK</span></span>](http://go.microsoft.com/fwlink/?LinkId=248929)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-615">DirectX 12 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-615">Get DirectX Tool Kit for DirectX 12</span></span></td>
        <td>[<span data-ttu-id="c8315-616">DirectXTK 12</span><span class="sxs-lookup"><span data-stu-id="c8315-616">DirectXTK 12</span></span>](http://go.microsoft.com/fwlink/?LinkID=615561)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-617">DirectX テクスチャ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-617">Get DirectX texture processing library</span></span></td>
        <td>[<span data-ttu-id="c8315-618">DirectXTex</span><span class="sxs-lookup"><span data-stu-id="c8315-618">DirectXTex</span></span>](http://go.microsoft.com/fwlink/?LinkId=248926)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-619">DirectXMesh ジオメトリ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-619">Get DirectXMesh geometry processing library</span></span></td>
        <td>[<span data-ttu-id="c8315-620">DirectXMesh</span><span class="sxs-lookup"><span data-stu-id="c8315-620">DirectXMesh</span></span>](http://go.microsoft.com/fwlink/?LinkID=324981)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-621">isochart テクスチャ アトラスを作成してパッケージ化するための UVAtlas を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-621">Get UVAtlas for creating and packing isochart texture atlas</span></span></td>
        <td>[<span data-ttu-id="c8315-622">UVAtlas</span><span class="sxs-lookup"><span data-stu-id="c8315-622">UVAtlas</span></span>](http://go.microsoft.com/fwlink/?LinkID=512686)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-623">DirectXMath のライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-623">Get the DirectXMath library</span></span></td>
        <td>[<span data-ttu-id="c8315-624">DirectXMath</span><span class="sxs-lookup"><span data-stu-id="c8315-624">DirectXMath</span></span>](http://go.microsoft.com/fwlink/?LinkID=615560)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-625">DirectXTK での Direct3D 12 のサポート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-625">Direct3D 12 support in the DirectXTK (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-626">DirectX 12 のサポート</span><span class="sxs-lookup"><span data-stu-id="c8315-626">Support for DirectX 12</span></span>](https://github.com/Microsoft/DirectXTK/issues/2)</td>
    </tr>
</table>

#### <a name="directx-resources-from-partners"></a><span data-ttu-id="c8315-627">パートナーからの DirectX リソース</span><span class="sxs-lookup"><span data-stu-id="c8315-627">DirectX resources from partners</span></span>

<span data-ttu-id="c8315-628">これらは、外部のパートナーによって作成された補足の DirectX ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="c8315-628">These are some additional DirectX documentation created by external partners.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-629">Nvidia: DX12 での推奨と非推奨 (ブログ投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-629">Nvidia: DX12 Do's and Don'ts (blog post)</span></span> </td>
        <td>[<span data-ttu-id="c8315-630">Nvidia GPU での DirectX 12</span><span class="sxs-lookup"><span data-stu-id="c8315-630">DirectX 12 on Nvidia GPUs</span></span>](https://developer.nvidia.com/dx12-dos-and-donts-updated)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-631">Intel: DirectX 12 を使った効率的なレンダリング</span><span class="sxs-lookup"><span data-stu-id="c8315-631">Intel: Efficient rendering with DirectX 12</span></span></td>
        <td>[<span data-ttu-id="c8315-632">Intel グラフィックスでの DirectX 12 のレンダリング</span><span class="sxs-lookup"><span data-stu-id="c8315-632">DirectX 12 rendering on Intel Graphics</span></span>](https://software.intel.com/sites/default/files/managed/4a/38/Efficient-Rendering-with-DirectX-12-on-Intel-Graphics.pdf)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-633">Intel: DirectX 12 でのマルチ アダプターのサポート</span><span class="sxs-lookup"><span data-stu-id="c8315-633">Intel: Multi adapter support in DirectX 12</span></span></td>
        <td>[<span data-ttu-id="c8315-634">DirectX 12 を使った明示的なマルチ アダプターアプリケーションを実装する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-634">How to implement an explicit multi-adapter application using DirectX 12</span></span>](https://software.intel.com/articles/multi-adapter-support-in-directx-12)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-635">Intel: DirectX 12 のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="c8315-635">Intel: DirectX 12 tutorial</span></span></td>
        <td>[<span data-ttu-id="c8315-636">Intel、Suzhou Snail、Microsoft によって共同制作されたホワイト ペーパー</span><span class="sxs-lookup"><span data-stu-id="c8315-636">Collaborative white paper by Intel, Suzhou Snail and Microsoft</span></span>](https://software.intel.com/articles/tutorial-migrating-your-apps-to-directx-12-part-1)</td>
    </tr>
</table>


## <a name="production"></a><span data-ttu-id="c8315-637">制作</span><span class="sxs-lookup"><span data-stu-id="c8315-637">Production</span></span>


<span data-ttu-id="c8315-638">制作スタジオの準備が整ったら、チーム全体に作業を分散して制作サイクルに移行します。</span><span class="sxs-lookup"><span data-stu-id="c8315-638">Your studio is now fully engaged and moving into the production cycle, with work distributed throughout your team.</span></span> <span data-ttu-id="c8315-639">プロトタイプの調整、リファクタリング、拡張によって、ゲームの完成品に仕上げていきます。</span><span class="sxs-lookup"><span data-stu-id="c8315-639">You're polishing, refactoring, and extending the prototype to craft it into a full game.</span></span>

### <a name="notifications-and-live-tiles"></a><span data-ttu-id="c8315-640">通知とライブ タイル</span><span class="sxs-lookup"><span data-stu-id="c8315-640">Notifications and live tiles</span></span>

<span data-ttu-id="c8315-641">タイルとは、[スタート] メニュー上でゲームを表すものです。</span><span class="sxs-lookup"><span data-stu-id="c8315-641">A tile is your game's representation on the Start Menu.</span></span> <span data-ttu-id="c8315-642">タイルや通知によって、ゲームをプレイしていない場合でも、プレイヤーに興味を持たせることができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-642">Tiles and notifications can drive player interest even when they aren't currently playing your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-643">タイルとバッジの開発</span><span class="sxs-lookup"><span data-stu-id="c8315-643">Developing tiles and badges</span></span></td>
        <td>[<span data-ttu-id="c8315-644">タイル、バッジ、通知</span><span class="sxs-lookup"><span data-stu-id="c8315-644">Tiles, badges, and notifications</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185606)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-645">ライブ タイルと通知を示すサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-645">Sample illustrating live tiles and notifications</span></span></td>
        <td>[<span data-ttu-id="c8315-646">通知のサンプル</span><span class="sxs-lookup"><span data-stu-id="c8315-646">Notifications sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-647">アダプティブ タイル テンプレート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-647">Adaptive tile templates (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-648">アダプティブ タイル テンプレート - スキーマとドキュメント</span><span class="sxs-lookup"><span data-stu-id="c8315-648">Adaptive Tile Templates - Schema and Documentation</span></span>](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/06/30/adaptive-tile-templates-schema-and-documentation.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-649">タイルとバッジの設計</span><span class="sxs-lookup"><span data-stu-id="c8315-649">Designing tiles and badges</span></span></td>
        <td>[<span data-ttu-id="c8315-650">タイルとバッジのガイドライン</span><span class="sxs-lookup"><span data-stu-id="c8315-650">Guidelines for tiles and badges</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465403)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-651">ライブ タイル テンプレートを対話形式で開発するための Windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="c8315-651">Windows 10 app for interactively developing live tile templates</span></span></td>
        <td>[<span data-ttu-id="c8315-652">Notifications Visualizer</span><span class="sxs-lookup"><span data-stu-id="c8315-652">Notifications Visualizer</span></span>](https://www.microsoft.com/store/apps/9nblggh5xsl1)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-653">Visual Studio 用の UWP Tile Generator 拡張機能</span><span class="sxs-lookup"><span data-stu-id="c8315-653">UWP Tile Generator extension for Visual Studio</span></span></td>
        <td>[<span data-ttu-id="c8315-654">1 つの画像を使用して必要なすべてのタイルを作成するためのツール</span><span class="sxs-lookup"><span data-stu-id="c8315-654">Tool for creating all required tiles using single image</span></span>](https://visualstudiogallery.msdn.microsoft.com/09611e90-f3e8-44b7-9c83-18dba8275bb2)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-655">Visual Studio 用の UWP Tile Generator 拡張機能 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-655">UWP Tile Generator extension for Visual Studio (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-656">UWP Tile Generator ツールの使用に関するヒント</span><span class="sxs-lookup"><span data-stu-id="c8315-656">Tips on using the UWP Tile Generator tool</span></span>](https://blogs.windows.com/buildingapps/2016/02/15/uwp-tile-generator-extension-for-visual-studio/)</td>
    </tr>
</table>
 

### <a name="enable-in-app-product-iap-purchases"></a><span data-ttu-id="c8315-657">アプリ内製品 (IAP) 購入の有効化</span><span class="sxs-lookup"><span data-stu-id="c8315-657">Enable in-app product (IAP) purchases</span></span>

<span data-ttu-id="c8315-658">IAP (アプリ内製品) は、プレイヤーがゲーム内で購入できる補助アイテムです。</span><span class="sxs-lookup"><span data-stu-id="c8315-658">An IAP (in-app product) is a supplementary item that players can purchase in-game.</span></span> <span data-ttu-id="c8315-659">IAP には、新しいアドオン、ゲームのレベル、項目、その他のプレーヤーを楽しませるものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c8315-659">IAPs can be new add-ons, game levels, items, or anything else that your players might enjoy.</span></span> <span data-ttu-id="c8315-660">適切に使用すると、IAP はゲームのエクスペリエンスを向上させると共に、収益の増加につながります。</span><span class="sxs-lookup"><span data-stu-id="c8315-660">Used appropriately, IAPs can provide revenue while improving the game experience.</span></span> <span data-ttu-id="c8315-661">ゲームの IAP は Windows デベロッパー センター ダッシュボードで定義して公開します。また、ゲームのコードでアプリ内購入を有効にします。</span><span class="sxs-lookup"><span data-stu-id="c8315-661">You define and publish your game's IAPs through the Windows Dev Center dashboard, and enable in-app purchases in your game's code.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-662">永続的なアプリ内製品</span><span class="sxs-lookup"><span data-stu-id="c8315-662">Durable in-app products</span></span></td>
        <td>[<span data-ttu-id="c8315-663">アプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="c8315-663">Enable in-app product purchases</span></span>](https://msdn.microsoft.com/library/windows/apps/mt219684)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-664">コンシューマブルなアプリ内製品</span><span class="sxs-lookup"><span data-stu-id="c8315-664">Consumable in-app products</span></span></td>
        <td>[<span data-ttu-id="c8315-665">コンシューマブルなアプリ内製品購入の有効化</span><span class="sxs-lookup"><span data-stu-id="c8315-665">Enable consumable in-app product purchases</span></span>](https://msdn.microsoft.com/library/windows/apps/mt219683)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-666">アプリ内製品の詳細と申請</span><span class="sxs-lookup"><span data-stu-id="c8315-666">In-app product details and submission</span></span></td>
        <td>[<span data-ttu-id="c8315-667">IAP の申請</span><span class="sxs-lookup"><span data-stu-id="c8315-667">IAP submissions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148551)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-668">IAP 売り上げとゲームの人口統計の監視</span><span class="sxs-lookup"><span data-stu-id="c8315-668">Monitor IAP sales and demographics for your game</span></span></td>
        <td>[<span data-ttu-id="c8315-669">IAP 取得レポート</span><span class="sxs-lookup"><span data-stu-id="c8315-669">IAP acquisitions report</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148538)</td>
    </tr>
</table>
 
### <a name="debugging-performance-optimization-and-monitoring"></a><span data-ttu-id="c8315-670">デバッグとパフォーマンスの最適化と監視</span><span class="sxs-lookup"><span data-stu-id="c8315-670">Debugging, performance optimization, and monitoring</span></span>

<span data-ttu-id="c8315-671">パフォーマンスを最適化するには、Windows 10 のゲーム モードを活用し、ハードウェアの機能を最大限に活用して、ゲーマーに可能な限りのゲーム エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-671">To optimize performance, take advantage of Game Mode in Windows 10 to provide your gamers with the best possible gaming experience by fully utilizing the capacity of their current hardware.</span></span>

<span data-ttu-id="c8315-672">Windows Performance Toolkit (WPT) は、Windows オペレーティング システムやアプリケーションの詳しいパフォーマンス プロファイルを生成するための一連のパフォーマンス監視ツールです。</span><span class="sxs-lookup"><span data-stu-id="c8315-672">The Windows Performance Toolkit (WPT) consists of performance monitoring tools that produce in-depth performance profiles of Windows operating systems and applications.</span></span> <span data-ttu-id="c8315-673">これは、メモリ使用量を監視し、ゲームのパフォーマンスを向上させるために特に便利です。</span><span class="sxs-lookup"><span data-stu-id="c8315-673">This is especially useful for monitoring memory usage and improving game performance.</span></span> <span data-ttu-id="c8315-674">Windows Performance Toolkit は、Windows 10 SDK と Windows ADK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8315-674">The Windows Performance Toolkit is included in the Windows 10 SDK and Windows ADK.</span></span> <span data-ttu-id="c8315-675">このツールキットは、2 つの独立したツールで構成されています。Windows Performance Recorder (WPR) と Windows Performance Analyzer (WPA) です。</span><span class="sxs-lookup"><span data-stu-id="c8315-675">This toolkit consists of two independent tools: Windows Performance Recorder (WPR) and Windows Performance Analyzer (WPA).</span></span> <span data-ttu-id="c8315-676">[Windows Sysinternals](https://technet.microsoft.com/sysinternals/default) に含まれる ProcDump は、コマンドライン ユーティリティであり、CPU 使用量の急上昇を監視し、ゲームのクラッシュ時にダンプ ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="c8315-676">ProcDump, which is part of [Windows Sysinternals](https://technet.microsoft.com/sysinternals/default), is a command-line utility that monitors CPU spikes and generates dump files during game crashes.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-677">ゲーム モードの API の使用によるハードウェア リソースへの排他的または優先的なアクセスを使ったパフォーマンスの向上</span><span class="sxs-lookup"><span data-stu-id="c8315-677">Improve performance by getting exclusive or priority access to hardware resources using Game Mode APIs</span></span></td>
        <td>[<span data-ttu-id="c8315-678">ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="c8315-678">Game Mode</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt808808)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-679">Windows 10 SDK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-679">Get Windows Performance Toolkit (WPT) from Windows 10 SDK</span></span></td>
        <td>[<span data-ttu-id="c8315-680">Windows 10 SDK</span><span class="sxs-lookup"><span data-stu-id="c8315-680">Windows 10 SDK</span></span>](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-681">Windows ADK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-681">Get Windows Performance Toolkit (WPT) from Windows ADK</span></span></td>
        <td>[<span data-ttu-id="c8315-682">Windows ADK</span><span class="sxs-lookup"><span data-stu-id="c8315-682">Windows ADK</span></span>](https://msdn.microsoft.com/windows/hardware/dn913721.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-683">Windows Performance Analyzer を使って応答しない UI のトラブルシューティングを行う (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-683">Troubleshoot unresponsible UI using Windows Performance Analyzer (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-684">WPA を使ったクリティカル パスの分析</span><span class="sxs-lookup"><span data-stu-id="c8315-684">Critical path analysis with WPA</span></span>](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-156-Critical-Path-Analysis-with-Windows-Performance-Analyzer)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-685">Windows Performance Recorder を使ってメモリ使用量とメモリ リークを診断する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-685">Diagnose memory usage and leaks using Windows Performance Recorder (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-686">メモリ使用量とリーク</span><span class="sxs-lookup"><span data-stu-id="c8315-686">Memory footprint and leaks</span></span>](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-154-Memory-Footprint-and-Leaks)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-687">ProcDump を取得する</span><span class="sxs-lookup"><span data-stu-id="c8315-687">Get ProcDump</span></span></td>
        <td>[<span data-ttu-id="c8315-688">ProcDump</span><span class="sxs-lookup"><span data-stu-id="c8315-688">ProcDump</span></span>](https://technet.microsoft.com/sysinternals/dd996900)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-689">ProcDump の使い方 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-689">Learn to use ProcDump (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-690">ダンプ ファイルを作成するために ProcDump を構成する</span><span class="sxs-lookup"><span data-stu-id="c8315-690">Configure ProcDump to create dump files</span></span>](https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-131-Windows-10-SDK)</td>
    </tr>
</table>

### <a name="advanced-directx-techniques-and-concepts"></a><span data-ttu-id="c8315-691">高度な DirectX の手法と概念</span><span class="sxs-lookup"><span data-stu-id="c8315-691">Advanced DirectX techniques and concepts</span></span>

<span data-ttu-id="c8315-692">DirectX の開発には微妙で複雑な部分があります。</span><span class="sxs-lookup"><span data-stu-id="c8315-692">Some portions of DirectX development can be nuanced and complex.</span></span> <span data-ttu-id="c8315-693">運用環境で、DirectX エンジンの詳細を掘り下げる必要がある場合や、難しいパフォーマンスの問題をデバッグする場合は、このセクションで紹介するリソースや情報が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c8315-693">When you get to the point in production where you need to dig down into the details of your DirectX engine, or debug difficult performance problems, the resources and information in this section can help.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-694">Windows の PIX</span><span class="sxs-lookup"><span data-stu-id="c8315-694">PIX on Windows</span></span></td>
        <td>[<span data-ttu-id="c8315-695">Windows での DirectX 12 ゲームのパフォーマンスのチューニングとデバッグのツール</span><span class="sxs-lookup"><span data-stu-id="c8315-695">Performance tuning and debugging tool for DirectX 12 on Windows</span></span>](https://blogs.msdn.microsoft.com/pix/2017/01/17/introducing-pix-on-windows-beta/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-696">D3D12 開発のデバッグと検証のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-696">Debugging and validation tools for D3D12 development (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-697">D3D12 パフォーマンス チューニングと PIX と GPU の検証を使ったデバッグ</span><span class="sxs-lookup"><span data-stu-id="c8315-697">D3D12 Performance Tuning and Debugging with PIX and GPU Validation</span></span>](https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-003)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-698">グラフィックスとパフォーマンスの最適化 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-698">Optimizing graphics and performance (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-699">高度な DirectX 12 グラフィックスとパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="c8315-699">Advanced DirectX 12 Graphics and Performance</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Advanced-DirectX12-Graphics-and-Performance)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-700">DirectX グラフィックスのデバッグ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-700">DirectX graphics debugging (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-701">DirectX ツールを使用した、ゲームでのグラフィックスの困難な問題の解決</span><span class="sxs-lookup"><span data-stu-id="c8315-701">Solve the tough graphics problems with your game using DirectX Tools</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Solve-the-Tough-Graphics-Problems-with-your-Game-Using-DirectX-Tools)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-702">DirectX 12 をデバッグするための Visual Studio 2015 のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-702">Visual Studio 2015 tools for debugging DirectX 12 (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-703">Visual Studio 2015 の Windows 10 用 DirectX ツール</span><span class="sxs-lookup"><span data-stu-id="c8315-703">DirectX tools for Windows 10 in Visual Studio 2015</span></span>](https://channel9.msdn.com/Series/ConnectOn-Demand/212)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-704">Direct3D 12 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-704">Direct3D 12 programming guide</span></span></td>
        <td>[<span data-ttu-id="c8315-705">Direct3D 12 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-705">Direct3D 12 Programming Guide</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn903821)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-706">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="c8315-706">Combining DirectX and XAML</span></span></td>
        <td>[<span data-ttu-id="c8315-707">DirectX と XAML の相互運用機能</span><span class="sxs-lookup"><span data-stu-id="c8315-707">DirectX and XAML interop</span></span>](directx-and-xaml-interop.md)</td>
    </tr>
</table>

### <a name="globalization-and-localization"></a><span data-ttu-id="c8315-708">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="c8315-708">Globalization and localization</span></span>

<span data-ttu-id="c8315-709">Windows プラットフォーム用の多言語対応ゲームを開発し、Microsoft の有力製品に組み込まれている地域と言語の機能について説明します。</span><span class="sxs-lookup"><span data-stu-id="c8315-709">Develop world-ready games for the Windows platform and learn about the international features built into Microsoft’s top products.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-710">世界市場向けのゲームの準備</span><span class="sxs-lookup"><span data-stu-id="c8315-710">Preparing your game for the global market</span></span></td>
        <td>[<span data-ttu-id="c8315-711">世界中のユーザーに対応する開発のガイドライン</span><span class="sxs-lookup"><span data-stu-id="c8315-711">Guidelines when developing for a global audience</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/mt186453.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-712">言語、文化、およびテクノロジの橋渡し</span><span class="sxs-lookup"><span data-stu-id="c8315-712">Bridging languages, cultures, and technology</span></span></td>
        <td>[<span data-ttu-id="c8315-713">言語の規則および Microsoft の標準的な用語のオンライン リソース</span><span class="sxs-lookup"><span data-stu-id="c8315-713">Online resource for language conventions and standard Microsoft terminology</span></span>](http://www.microsoft.com/Language/Default.aspx)</td>
    </tr>
</table>

## <a name="submitting-and-publishing-your-game"></a><span data-ttu-id="c8315-714">ゲームの申請と公開</span><span class="sxs-lookup"><span data-stu-id="c8315-714">Submitting and publishing your game</span></span>

<span data-ttu-id="c8315-715">次のガイドと情報は、公開と申請のプロセスをできるだけスムーズに進めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c8315-715">The following guides and information help make the publishing and submission process as smooth as possible.</span></span>

### <a name="publishing"></a><span data-ttu-id="c8315-716">公開</span><span class="sxs-lookup"><span data-stu-id="c8315-716">Publishing</span></span>

<span data-ttu-id="c8315-717">新しい統合 Windows デベロッパー センター ダッシュボードを使って、すべてのゲーム パッケージを公開し管理することができます。</span><span class="sxs-lookup"><span data-stu-id="c8315-717">You'll use the new unified Windows Dev Center dashboard to publish and manage your game packages.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-718">Windows デベロッパー センターでのアプリの公開</span><span class="sxs-lookup"><span data-stu-id="c8315-718">Windows Dev Center app publishing</span></span></td>
        <td>[<span data-ttu-id="c8315-719">Windows アプリの公開</span><span class="sxs-lookup"><span data-stu-id="c8315-719">Publish Windows apps</span></span>](https://dev.windows.com/publish)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-720">Windows デベロッパー センターでの高度な公開 (GDN)</span><span class="sxs-lookup"><span data-stu-id="c8315-720">Windows Dev Center advanced publishing (GDN)</span></span></td>
        <td>[<span data-ttu-id="c8315-721">Windows デベロッパー センター ダッシュボードでの高度な公開ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-721">Windows Dev Center Dashboard advanced publishing guide</span></span>](https://developer.xboxlive.com/en-us/windows/documentation/Pages/home.aspx)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-722">Azure Active Directory (AAD) を使用して、ユーザーをデベロッパー センター アカウントに追加する</span><span class="sxs-lookup"><span data-stu-id="c8315-722">Use Azure Active Directory (AAD) to add users to your Dev Center account</span></span></td>
        <td>[<span data-ttu-id="c8315-723">アカウント ユーザーの管理</span><span class="sxs-lookup"><span data-stu-id="c8315-723">Manage account users</span></span>](https://docs.microsoft.com/windows/uwp/publish/manage-account-users)</td>
    </tr>   
    <tr>
        <td><span data-ttu-id="c8315-724">ゲームの評価 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-724">Rating your game (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-725">IARC システムを使って年齢区分を割り当てるための単一のワークフロー</span><span class="sxs-lookup"><span data-stu-id="c8315-725">Single workflow to assign age ratings using IARC system</span></span>](https://blogs.windows.com/buildingapps/2016/01/06/now-available-single-age-rating-system-to-simplify-app-submissions/)</td>
    </tr>
</table>

#### <a name="packaging-and-uploading"></a><span data-ttu-id="c8315-726">パッケージ化とアップロード</span><span class="sxs-lookup"><span data-stu-id="c8315-726">Packaging and uploading</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-727">ストリーミング インストールとオプション パッケージを使用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-727">Learn to use streaming install and optional packages (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-728">次世代の UWP アプリの配布: 拡張可能で、ストリーミング可能な、コンポーネント化されたアプリの構築</span><span class="sxs-lookup"><span data-stu-id="c8315-728">Nextgen UWP app distribution: Building extensible, stream-able, componentized apps</span></span>](https://channel9.msdn.com/Events/Build/2017/B8093)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-729">コンテンツの分割とグループ化によるストリーミング インストールの実現</span><span class="sxs-lookup"><span data-stu-id="c8315-729">Divide and group content to enable streaming install</span></span></td>
        <td>[<span data-ttu-id="c8315-730">UWP アプリ ストリーミング インストール</span><span class="sxs-lookup"><span data-stu-id="c8315-730">UWP App Streaming install</span></span>](../packaging/streaming-install.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-731">DLC ゲーム コンテンツのようなオプション パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="c8315-731">Create optional packages like DLC game content</span></span></td>
        <td>[<span data-ttu-id="c8315-732">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-732">Optional packages and related set authoring</span></span>](../packaging/optional-packages.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-733">UWP ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="c8315-733">Package your UWP game</span></span></td>
        <td>[<span data-ttu-id="c8315-734">アプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="c8315-734">Packaging apps</span></span>](../packaging/index.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-735">UWP DirectX ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="c8315-735">Package your UWP DirectX game</span></span></td>
        <td>[<span data-ttu-id="c8315-736">UWP DirectX ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="c8315-736">Package your UWP DirectX game</span></span>](package-your-windows-store-directx-game.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-737">サード パーティ開発者としてのゲームのパッケージ化 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="c8315-737">Packaging your game as a 3rd party developer (blog post)</span></span></td>
        <td>[<span data-ttu-id="c8315-738">発行元のストア アカウントにアクセスせずにアップロード可能なパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-738">Create uploadable packages without publisher's store account access</span></span>](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-739">MakeAppx を使用したアプリ パッケージとアプリ パッケージ バンドルの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-739">Creating app packages and app package bundles using MakeAppx</span></span></td>
        <td>[<span data-ttu-id="c8315-740">アプリ パッケージ ツール MakeAppx.exe を使用したパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="c8315-740">Create packages using app packager tool MakeAppx.exe</span></span>](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-741">SignTool を使用したファイルへのデジタル署名</span><span class="sxs-lookup"><span data-stu-id="c8315-741">Signing your files digitally using SignTool</span></span></td>
        <td>[<span data-ttu-id="c8315-742">SignTool を使用した、ファイルへの署名とファイルの署名の確認</span><span class="sxs-lookup"><span data-stu-id="c8315-742">Sign files and verify signatures in files using SignTool</span></span>](https://msdn.microsoft.com/library/windows/desktop/aa387764)</td>
    </tr>    
    <tr>
        <td><span data-ttu-id="c8315-743">ゲームのアップロードとバージョン管理</span><span class="sxs-lookup"><span data-stu-id="c8315-743">Uploading and versioning your game</span></span></td>
        <td>[<span data-ttu-id="c8315-744">アプリ パッケージのアップロード</span><span class="sxs-lookup"><span data-stu-id="c8315-744">Upload app packages</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148542)</td>
    </tr>
</table>


### <a name="policies-and-certification"></a><span data-ttu-id="c8315-745">ポリシーと認定</span><span class="sxs-lookup"><span data-stu-id="c8315-745">Policies and certification</span></span>

<span data-ttu-id="c8315-746">認定に関する問題によってゲームのリリースを延期しないでください。</span><span class="sxs-lookup"><span data-stu-id="c8315-746">Don't let certification issues delay your game's release.</span></span> <span data-ttu-id="c8315-747">ここでは、ポリシーと注意が必要な一般的な認定の問題を示します。</span><span class="sxs-lookup"><span data-stu-id="c8315-747">Here are policies and common certification issues to be aware of.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-748">Windows ストア アプリ開発者契約書</span><span class="sxs-lookup"><span data-stu-id="c8315-748">Windows Store App Developer Agreement</span></span></td>
        <td>[<span data-ttu-id="c8315-749">アプリ開発者契約書</span><span class="sxs-lookup"><span data-stu-id="c8315-749">App Developer Agreement</span></span>](https://msdn.microsoft.com/library/windows/apps/hh694058)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-750">Windows ストアでアプリを公開するためのポリシー</span><span class="sxs-lookup"><span data-stu-id="c8315-750">Policies for publishing apps in the Windows Store</span></span></td>
        <td>[<span data-ttu-id="c8315-751">Windows ストア ポリシー</span><span class="sxs-lookup"><span data-stu-id="c8315-751">Windows Store Policies</span></span>](https://msdn.microsoft.com/library/windows/apps/dn764944)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-752">一般的なアプリの認定の問題を回避する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-752">How to avoid some common app certification issues</span></span></td>
        <td>[<span data-ttu-id="c8315-753">一般的な認定エラーの回避</span><span class="sxs-lookup"><span data-stu-id="c8315-753">Avoid common certification failures</span></span>](https://msdn.microsoft.com/library/windows/apps/jj657968)</td>
    </tr>
</table>
 

### <a name="store-manifest-storemanifestxml"></a><span data-ttu-id="c8315-754">ストア マニフェスト (StoreManifest.xml)</span><span class="sxs-lookup"><span data-stu-id="c8315-754">Store manifest (StoreManifest.xml)</span></span>

<span data-ttu-id="c8315-755">ストア マニフェスト (StoreManifest.xml) は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。</span><span class="sxs-lookup"><span data-stu-id="c8315-755">The store manifest (StoreManifest.xml) is an optional configuration file that can be included in your app package.</span></span> <span data-ttu-id="c8315-756">ストア マニフェストには、AppxManifest.xml ファイルに含まれていないその他の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="c8315-756">The store manifest provides additional features that are not part of the AppxManifest.xml file.</span></span> <span data-ttu-id="c8315-757">たとえば、ターゲット デバイスが指定された DirectX の最小機能レベルまたは指定された最小システム メモリの条件を満たしていない場合に、ストア マニフェストを使ってゲームのインストールをブロックできます。</span><span class="sxs-lookup"><span data-stu-id="c8315-757">For example, you can use the store manifest to block installation of your game if a target device doesn't have the specified minimum DirectX feature level, or the specified minimum system memory.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-758">ストア マニフェストのスキーマ</span><span class="sxs-lookup"><span data-stu-id="c8315-758">Store manifest schema</span></span></td>
        <td>[<span data-ttu-id="c8315-759">StoreManifest のスキーマ (Windows 10)</span><span class="sxs-lookup"><span data-stu-id="c8315-759">StoreManifest schema (Windows 10)</span></span>](https://msdn.microsoft.com/library/windows/apps/mt617335)</td>
    </tr>
</table>
 

## <a name="game-lifecycle-management"></a><span data-ttu-id="c8315-760">ゲームのライフサイクル管理</span><span class="sxs-lookup"><span data-stu-id="c8315-760">Game lifecycle management</span></span>


<span data-ttu-id="c8315-761">開発が終了し、ゲームを出荷しても、"ゲーム オーバー" というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="c8315-761">After you've finished development and shipped your game, it's not "game over".</span></span> <span data-ttu-id="c8315-762">バージョン 1 の開発は終了ですが、市場でのゲームの旅は始まったばかりです。</span><span class="sxs-lookup"><span data-stu-id="c8315-762">You may be done with development on version one, but your game's journey in the marketplace has only just begun.</span></span> <span data-ttu-id="c8315-763">使用状況やエラー レポートの監視、ユーザーからのフィードバックへの対応、ゲームの更新プログラムの公開という作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="c8315-763">You'll want to monitor usage and error reporting, respond to user feedback, and publish updates to your game.</span></span>

### <a name="windows-dev-center-analytics-and-promotion"></a><span data-ttu-id="c8315-764">Windows デベロッパー センターの分析と販売促進</span><span class="sxs-lookup"><span data-stu-id="c8315-764">Windows Dev Center analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-765">デベロッパー センター アプリ</span><span class="sxs-lookup"><span data-stu-id="c8315-765">Dev Center App</span></span></td>
        <td>[<span data-ttu-id="c8315-766">公開済みアプリのパフォーマンスを表示するデベロッパー センター Windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="c8315-766">Dev Center Windows 10 app to view performance of your published apps</span></span>](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws)</td>
    </tr>  
    <tr>
        <td><span data-ttu-id="c8315-767">Windows デベロッパー センターの分析</span><span class="sxs-lookup"><span data-stu-id="c8315-767">Windows Dev Center analytics</span></span></td>
        <td>[<span data-ttu-id="c8315-768">分析</span><span class="sxs-lookup"><span data-stu-id="c8315-768">Analytics</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148522)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-769">顧客のレビューへの返信</span><span class="sxs-lookup"><span data-stu-id="c8315-769">Responding to customer reviews</span></span></td>
        <td>[<span data-ttu-id="c8315-770">顧客のレビューに返信する</span><span class="sxs-lookup"><span data-stu-id="c8315-770">Respond to customer reviews</span></span>](https://msdn.microsoft.com/library/windows/apps/mt148546)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-771">ゲームの販売を促進する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-771">Ways to promote your game</span></span></td>
        <td>[<span data-ttu-id="c8315-772">アプリの販売促進</span><span class="sxs-lookup"><span data-stu-id="c8315-772">Promote your apps</span></span>](https://dev.windows.com/store-promotion)</td>
    </tr>
</table>
 

### <a name="visual-studio-application-insights"></a><span data-ttu-id="c8315-773">Visual Studio Application Insights</span><span class="sxs-lookup"><span data-stu-id="c8315-773">Visual Studio Application Insights</span></span>

<span data-ttu-id="c8315-774">Visual Studio Application Insights は、公開されたゲームのパフォーマンス、利用統計情報、および使用状況の分析を提供します。</span><span class="sxs-lookup"><span data-stu-id="c8315-774">Visual Studio Application Insights provides performance, telemetry, and usage analytics for your published game.</span></span> <span data-ttu-id="c8315-775">Application Insights は、リリース後のゲームの問題の検出と解決、使用状況の継続的な監視と向上、プレイヤーがゲームを操作する方法の把握に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c8315-775">Application Insights helps you detect and solve issues after your game is released, continuously monitor and improve usage, and understand how players are continuing to interact with your game.</span></span> <span data-ttu-id="c8315-776">Application Insights は、アプリに SDK を追加することで機能し、[Azure ポータル](http://portal.azure.com/)に利用統計情報を送信します。</span><span class="sxs-lookup"><span data-stu-id="c8315-776">Application Insights works by adding an SDK into your app, which sends telemetry to the [Azure portal](http://portal.azure.com/).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-777">アプリケーションのパフォーマンスと使用状況の分析</span><span class="sxs-lookup"><span data-stu-id="c8315-777">Application performance and usage analytics</span></span></td>
        <td>[<span data-ttu-id="c8315-778">Visual Studio Application Insights</span><span class="sxs-lookup"><span data-stu-id="c8315-778">Visual Studio Application Insights</span></span>](https://azure.microsoft.com/documentation/articles/app-insights-get-started/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-779">Windows アプリでの Application Insights の有効化</span><span class="sxs-lookup"><span data-stu-id="c8315-779">Enable Application Insights in Windows apps</span></span></td>
        <td>[<span data-ttu-id="c8315-780">Windows Phone およびストア アプリ向けの Application Insights</span><span class="sxs-lookup"><span data-stu-id="c8315-780">Application Insights for Windows Phone and Store apps</span></span>](https://azure.microsoft.com/documentation/articles/app-insights-windows-get-started/)</td>
    </tr>
</table>


### <a name="third-party-solutions-for-analytics-and-promotion"></a><span data-ttu-id="c8315-781">分析とプロモーションのためのサード パーティ ソリューション</span><span class="sxs-lookup"><span data-stu-id="c8315-781">Third party solutions for analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-782">GameAnalytics を使用してプレイヤーの動作を理解する</span><span class="sxs-lookup"><span data-stu-id="c8315-782">Understand player behavior using GameAnalytics</span></span></td>
        <td>[<span data-ttu-id="c8315-783">GameAnalytics</span><span class="sxs-lookup"><span data-stu-id="c8315-783">GameAnalytics</span></span>](http://www.gameanalytics.com/)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-784">UWP ゲームを Google Analytics に接続する</span><span class="sxs-lookup"><span data-stu-id="c8315-784">Connect your UWP game to Google Analytics</span></span></td>
        <td>[<span data-ttu-id="c8315-785">Google Analytics 向けの Windows SDK を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-785">Get Windows SDK for Google Analytics</span></span>](https://github.com/dotnet/windows-sdk-for-google-analytics)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-786">Google Analytics で Windows SDK を利用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-786">Learn how to use Windows SDK for Google Analytics (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-787">Google Analytics 向けの Windows SDK の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-787">Getting started with Windows SDK for Google Analytics</span></span>](https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-the-Windows-SDK-for-Google-Analytics)</td>
    </tr>    
    <tr>
        <td><span data-ttu-id="c8315-788">Facebook のアプリ インストール広告を使って Facebook ユーザー向けにゲームのプロモーションを行う</span><span class="sxs-lookup"><span data-stu-id="c8315-788">Use Facebook App Installs Ads to promote your game to Facebook users</span></span></td>
        <td>[<span data-ttu-id="c8315-789">Windows SDK for Facebook を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-789">Get Windows SDK for Facebook</span></span>](https://github.com/Microsoft/winsdkfb)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-790">Facebook のアプリ インストール広告の使用方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-790">Learn how to use Facebook App Installs Ads (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-791">Windows SDK for Facebook の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-791">Getting started with Windows SDK for Facebook</span></span>](https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-Facebook-App-Install-Ads)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-792">Vungle を使用してゲームにビデオ広告を追加する</span><span class="sxs-lookup"><span data-stu-id="c8315-792">Use Vungle to add video ads into your games</span></span></td>
        <td>[<span data-ttu-id="c8315-793">Windows SDK for Vungle を入手する</span><span class="sxs-lookup"><span data-stu-id="c8315-793">Get Windows SDK for Vungle</span></span>](https://v.vungle.com/sdk)</td>
    </tr>
</table>
 

### <a name="creating-and-managing-content-updates"></a><span data-ttu-id="c8315-794">コンテンツの更新プログラムの作成と管理</span><span class="sxs-lookup"><span data-stu-id="c8315-794">Creating and managing content updates</span></span>

<span data-ttu-id="c8315-795">公開されたゲームを更新するには、大きいバージョン番号を持つ新しいアプリ パッケージを申請します。</span><span class="sxs-lookup"><span data-stu-id="c8315-795">To update your published game, submit a new app package with a higher version number.</span></span> <span data-ttu-id="c8315-796">このパッケージの申請と認定が終了すると、自動的にユーザーに更新プログラムとして公開されます。</span><span class="sxs-lookup"><span data-stu-id="c8315-796">After the package makes its way through submission and certification, it will automatically be available to customers as an update.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-797">ゲームの更新とバージョン管理</span><span class="sxs-lookup"><span data-stu-id="c8315-797">Updating and versioning your game</span></span></td>
        <td>[<span data-ttu-id="c8315-798">パッケージ バージョンの番号付け</span><span class="sxs-lookup"><span data-stu-id="c8315-798">Package version numbering</span></span>](https://msdn.microsoft.com/library/windows/apps/mt188602)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-799">ゲームのパッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="c8315-799">Game package management guidance</span></span></td>
        <td>[<span data-ttu-id="c8315-800">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="c8315-800">Guidance for app package management</span></span>](https://msdn.microsoft.com/library/windows/apps/mt188602)</td>
    </tr>
</table>


## <a name="adding-xbox-live-to-your-game"></a><span data-ttu-id="c8315-801">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="c8315-801">Adding Xbox Live to your game</span></span>

> <span data-ttu-id="c8315-802">**注意** Xbox Live 対応のタイトルを開発する場合、いくつかのオプションを利用可能です。</span><span class="sxs-lookup"><span data-stu-id="c8315-802">**Note**   If you would like to develop Xbox Live enabled titles, there are several options are available to you.</span></span> <span data-ttu-id="c8315-803">さまざまなプログラムについて詳しくは、「[開発者プログラムの概要](../xbox-live/developer-program-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c8315-803">For info about the various programs, see [Developer program overview](../xbox-live/developer-program-overview.md).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-804">Xbox Live の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-804">Xbox Live overview</span></span></td>
        <td>[<span data-ttu-id="c8315-805">Xbox Live 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-805">Xbox Live developer guide</span></span>](../xbox-live/index.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-806">プログラムによって利用できる機能を理解する</span><span class="sxs-lookup"><span data-stu-id="c8315-806">Understand which features are available depending on program</span></span></td>
        <td>[<span data-ttu-id="c8315-807">開発者プログラムの概要: 機能表</span><span class="sxs-lookup"><span data-stu-id="c8315-807">Developer program overview: Feature table</span></span>](../xbox-live/developer-program-overview.md#feature-table)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-808">Xbox Live サービスから情報を取得する方法</span><span class="sxs-lookup"><span data-stu-id="c8315-808">Learn how to get info from Xbox Live services</span></span></td>
        <td>[<span data-ttu-id="c8315-809">Xbox Live API の概要</span><span class="sxs-lookup"><span data-stu-id="c8315-809">Introduction to Xbox Live APIs</span></span>](../xbox-live/introduction-to-xbox-live-apis.md)</td>
    </tr>
</table>


### <a name="for-developers-in-the-xbox-live-creators-program"></a><span data-ttu-id="c8315-810">Xbox Live クリエーターズ プログラム開発者向け</span><span class="sxs-lookup"><span data-stu-id="c8315-810">For developers in the Xbox Live Creators Program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-811">概要</span><span class="sxs-lookup"><span data-stu-id="c8315-811">Overview</span></span></td>
        <td>[<span data-ttu-id="c8315-812">Xbox Live クリエーターズ プログラムの概要</span><span class="sxs-lookup"><span data-stu-id="c8315-812">Get started with the Xbox Live Creators Program</span></span>](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-813">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="c8315-813">Add Xbox Live to your game</span></span></td>
        <td>[<span data-ttu-id="c8315-814">Xbox Live クリエーターズ プログラムを統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-814">Step by step guide to integrate Xbox Live Creators program</span></span>](../xbox-live/get-started-with-creators/creators-step-by-step-guide.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-815">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="c8315-815">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td>[<span data-ttu-id="c8315-816">Unity ゲーム エンジンを使用して、Xbox Live クリエーターズ プログラムのタイトルの開発を開始する</span><span class="sxs-lookup"><span data-stu-id="c8315-816">Get started developing an Xbox Live Creators Program title with the Unity game engine</span></span>](../xbox-live/get-started-with-creators/develop-creators-title-with-unity.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-817">クロスプラット フォームの Xbox Live エクスペリエンスを UWP ゲームに統合する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-817">Learn how to integrate cross-platform Xbox Live experiences in UWP games (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-818">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="c8315-818">Xbox Live Creators Program</span></span>](https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-005)</td>
    </tr>
</table>

### <a name="for-managed-partners-and-developers-in-the-idxbox-program"></a><span data-ttu-id="c8315-819">対象パートナーおよび ID@Xbox プログラムの開発者向け</span><span class="sxs-lookup"><span data-stu-id="c8315-819">For managed partners and developers in the ID@Xbox program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-820">概要</span><span class="sxs-lookup"><span data-stu-id="c8315-820">Overview</span></span></td>
        <td>[<span data-ttu-id="c8315-821">対象パートナーまたは ID 開発者として Xbox Live の利用を開始する</span><span class="sxs-lookup"><span data-stu-id="c8315-821">Get started with Xbox Live as a managed partner or an ID developer</span></span>](../xbox-live/get-started-with-partner/get-started-with-xbox-live-partner.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-822">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="c8315-822">Add Xbox Live to your game</span></span></td>
        <td>[<span data-ttu-id="c8315-823">対象パートナーおよび ID メンバー向けに Xbox Live を統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="c8315-823">Step by step guide to integrate Xbox Live for managed partners and ID members</span></span>](../xbox-live/get-started-with-partner/partners-step-by-step-guide.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-824">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="c8315-824">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td>[<span data-ttu-id="c8315-825">ID および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="c8315-825">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID and managed partners</span></span>](../xbox-live/get-started-with-partner/partner-unity-uwp-il2cpp.md)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-826">Xbox Live を使うためのゲームの要件 (GDN)</span><span class="sxs-lookup"><span data-stu-id="c8315-826">Requirements for games that use Xbox Live (GDN)</span></span></td>
        <td>[<span data-ttu-id="c8315-827">Xbox Live on Windows 10 の Xbox の要件</span><span class="sxs-lookup"><span data-stu-id="c8315-827">Xbox Requirements for Xbox Live on Windows 10</span></span>](http://go.microsoft.com/fwlink/?LinkId=533217)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-828">Xbox Live のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-828">Overview of Xbox Live game development (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-829">Windows 10 用の Xbox Live を使った開発</span><span class="sxs-lookup"><span data-stu-id="c8315-829">Developing with Xbox Live for Windows 10</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Developing-with-Xbox-Live-for-Windows-10)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-830">クロス プラットフォーム マッチメイキング (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-830">Cross-platform matchmaking (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-831">Xbox Live マルチプレイヤー: クロス プラットフォーム マッチメイキングとゲームプレイのサービスの紹介</span><span class="sxs-lookup"><span data-stu-id="c8315-831">Xbox Live Multiplayer: Introducing services for cross-platform matchmaking and gameplay</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Xbox-Live-Multiplayer-Introducing-services-for-cross-platform-matchmaking-and-gameplay)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-832">Fable Legends でのクロス デバイスのゲームプレイ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-832">Cross-device gameplay in Fable Legends (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-833">Fable Legends: Xbox Live によるクロス デバイス ゲームプレイ</span><span class="sxs-lookup"><span data-stu-id="c8315-833">Fable Legends: Cross-device Gameplay with Xbox Live</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Fable-Legends-Cross-device-Gameplay-with-Xbox-Live)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-834">Xbox Live の統計情報や達成度 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-834">Xbox Live stats and achievements (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-835">クラウド ベースのユーザーの統計情報と Xbox Live での達成度の活用のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="c8315-835">Best Practices for Leveraging Cloud-Based User Stats and Achievements in Xbox Live</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Best-Practices-for-Leveraging-Cloud-Based-User-Stats-and-Achievements-in-Xbox-Live)</td>
    </tr>
</table>


## <a name="additional-resources"></a><span data-ttu-id="c8315-836">その他の情報</span><span class="sxs-lookup"><span data-stu-id="c8315-836">Additional resources</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="c8315-837">ゲーム開発ビデオ</span><span class="sxs-lookup"><span data-stu-id="c8315-837">Game development videos</span></span></td>
        <td>[<span data-ttu-id="c8315-838">GDC や //build などの主要なカンファレンスのビデオ</span><span class="sxs-lookup"><span data-stu-id="c8315-838">Videos from major conferences like GDC and //build</span></span>](https://docs.microsoft.com/windows/uwp/gaming/game-development-videos)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-839">インディーズ ゲーム開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-839">Indie game development (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-840">個人開発者のための新しい機会</span><span class="sxs-lookup"><span data-stu-id="c8315-840">New Opportunities for Independent Developers</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/New-Opportunities-for-Independent-Developers)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-841">マルチコア モバイル デバイスに関する考慮事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-841">Considerations for multi-core mobile devices (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-842">マルチコア モバイル デバイスでのゲームのパフォーマンスの維持</span><span class="sxs-lookup"><span data-stu-id="c8315-842">Sustained Gaming Performance in multi-core mobile devices</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/Sustained-gaming-performance-in-multi-core-mobile-devices)</td>
    </tr>
    <tr>
        <td><span data-ttu-id="c8315-843">Windows 10 デスクトップ ゲームの開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="c8315-843">Developing Windows 10 desktop games (video)</span></span></td>
        <td>[<span data-ttu-id="c8315-844">Windows 10 向け PC ゲーム</span><span class="sxs-lookup"><span data-stu-id="c8315-844">PC Games for Windows 10</span></span>](http://channel9.msdn.com/Events/GDC/GDC-2015/PC-Games-for-Windows-10)</td>
    </tr>
</table>



 

 

 
