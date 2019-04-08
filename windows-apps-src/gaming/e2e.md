---
title: Windows 10 ゲーム開発ガイド
description: ユニバーサル Windows プラットフォーム (UWP) ゲーム開発のためのリソースや情報を網羅したガイドです。
ms.assetid: 6061F498-96A8-44EF-9711-68AE5A1218C9
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム、ゲーム開発
ms.localizationpriority: medium
ms.openlocfilehash: 38fc73eb602c1307fdd345d02c621791feb89dc2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57652327"
---
# <a name="windows-10-game-development-guide"></a><span data-ttu-id="52ac8-104">Windows 10 ゲーム開発ガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-104">Windows 10 game development guide</span></span>


<span data-ttu-id="52ac8-105">Windows 10 ゲーム開発ガイドへようこそ。</span><span class="sxs-lookup"><span data-stu-id="52ac8-105">Welcome to the Windows 10 game development guide!</span></span>

<span data-ttu-id="52ac8-106">このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に必要なリソースと情報を網羅したコレクションを提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-106">This guide provides an end-to-end collection of the resources and information you'll need to develop a Universal Windows Platform (UWP) game.</span></span> <span data-ttu-id="52ac8-107">このガイドの英語 (米国) 版は [PDF](https://download.microsoft.com/download/9/C/9/9C9D344F-611F-412E-BB01-259E5C76B17F/Windev_Game_Dev_Guide_Oct_2017.pdf) 形式で利用できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-107">An English (US) version of this guide is available in [PDF](https://download.microsoft.com/download/9/C/9/9C9D344F-611F-412E-BB01-259E5C76B17F/Windev_Game_Dev_Guide_Oct_2017.pdf) format.</span></span>

## <a name="introduction-to-game-development-for-the-universal-windows-platform-uwp"></a><span data-ttu-id="52ac8-108">ユニバーサル Windows プラットフォーム (UWP) 用ゲーム開発の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-108">Introduction to game development for the Universal Windows Platform (UWP)</span></span>


<span data-ttu-id="52ac8-109">Windows 10 ゲームを作成すると、スマートフォンから PC、Xbox One にいたる数百万人のプレイヤーにゲームを提供するチャンスを得られます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-109">When you create a Windows 10 game, you have the opportunity to reach millions of players worldwide across phone, PC, and Xbox One.</span></span> <span data-ttu-id="52ac8-110">Windows の Xbox、Xbox Live、クロス デバイス マルチプレイヤー、すばらしいゲーム コミュニティ、ユニバーサル Windows プラットフォーム (UWP) や DirectX 12 などの強力な新機能により、Windows 10 ゲームは、あらゆる世代やジャンルのプレイヤーを楽しませるでしょう。</span><span class="sxs-lookup"><span data-stu-id="52ac8-110">With Xbox on Windows, Xbox Live, cross-device multiplayer, an amazing gaming community, and powerful new features like the Universal Windows Platform (UWP) and DirectX 12, Windows 10 games thrill players of all ages and genres.</span></span> <span data-ttu-id="52ac8-111">新しいユニバーサル Windows プラットフォーム (UWP) は、スマートフォン、PC、Xbox One 用の共通 API と、各デバイスのエクスペリエンスに合わせてゲームをカスタマイズするツールやオプションによって、Windows 10 デバイスでのゲームの互換性を実現します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-111">The new Universal Windows Platform (UWP) delivers compatibility for your game across Windows 10 devices with a common API for phone, PC, and Xbox One, along with tools and options to tailor your game to each device experience.</span></span>

<span data-ttu-id="52ac8-112">このガイドでは、ゲームの開発に役立つさまざまなリソースや情報を網羅して提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-112">This guide provides an end-to-end collection of information and resources that will help you as you develop your game.</span></span> <span data-ttu-id="52ac8-113">必要なときに情報を検索する場所がわかるように、各セクションはゲームの開発の各段階に従って編成されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-113">The sections are organized according to the stages of game development, so you'll know where to look for information when you need it.</span></span>

<span data-ttu-id="52ac8-114">Windows または Xbox で初めてゲームを開発する場合は、最初に[ファースト ステップ](getting-started.md) ガイドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-114">If you're new to developing games on Windows or Xbox, the [Getting Started](getting-started.md) guide may be where you want to start off.</span></span> <span data-ttu-id="52ac8-115">「[ゲーム開発に関するリソース](#game-development-resources)」セクションでも、ゲームの作成時に役立つドキュメント、プログラム、その他のリソースの大まかな概要を示します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-115">The [Game development resources](#game-development-resources) section also provides a high-level survey of documentation, programs, and other resources that are helpful when creating a game.</span></span> <span data-ttu-id="52ac8-116">概要ではなく、実際の UWP コードを見て作業を始める場合は、「[ゲームのサンプル](#game-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-116">If you want to start by looking at some UWP code instead, see [Game samples](#game-samples).</span></span>

<span data-ttu-id="52ac8-117">このガイドは、Windows 10 ゲーム開発に関する新しいリソースや資料が利用可能になると更新されます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-117">This guide will be updated as additional Windows 10 game development resources and material become available.</span></span>

## <a name="game-development-resources"></a><span data-ttu-id="52ac8-118">ゲーム開発に関するリソース</span><span class="sxs-lookup"><span data-stu-id="52ac8-118">Game development resources</span></span>

<span data-ttu-id="52ac8-119">ドキュメントから、開発者向けのプログラム、フォーラム、ブログ、サンプルまで、ゲーム開発に役立つ多くのリソースが用意されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-119">From documentation to developer programs, forums, blogs, and samples, there are many resources available to help you on your game development journey.</span></span> <span data-ttu-id="52ac8-120">ここでは、Windows 10 ゲームの開発を始めるにあたって役立つリソースをまとめています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-120">Here's a roundup of resources to know about as you begin developing your Windows 10 game.</span></span>

> [!Note]
> <span data-ttu-id="52ac8-121">一部の機能は、さまざまなプログラムで管理されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-121">Some features are managed through various programs.</span></span> <span data-ttu-id="52ac8-122">このガイドでは幅広いリソースを取り上げているため、参加しているプログラムや特定の開発の役割によっては、一部のリソースにアクセスできない場合があります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-122">This guide covers a broad range of resources, so you may find that some resources are inaccessible depending on the program you are in or your specific development role.</span></span> <span data-ttu-id="52ac8-123">developer.xboxlive.com、forums.xboxlive.com、xdi.xboxlive.com、Game Developer Network (GDN) に解決されるリンクなどです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-123">Examples are links that resolve to developer.xboxlive.com, forums.xboxlive.com, xdi.xboxlive.com, or the Game Developer Network (GDN).</span></span> <span data-ttu-id="52ac8-124">Microsoft との提携について詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-124">For information about partnering with Microsoft, see [Developer Programs](#developer-programs).</span></span>


### <a name="game-development-documentation"></a><span data-ttu-id="52ac8-125">ゲーム開発に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-125">Game development documentation</span></span>

<span data-ttu-id="52ac8-126">このガイド全体を通して、タスク、テクノロジ、ゲームの開発の段階ごとに整理された、関連ドキュメントへのディープ リンクを示しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-126">Throughout this guide, you'll find deep links to relevant documentation—organized by task, technology, and stage of game development.</span></span> <span data-ttu-id="52ac8-127">利用可能なドキュメントのさまざまなビューを提供するために、Windows 10 ゲーム開発用の主要なドキュメント ポータルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-127">To give you a broad view of what's available, here are the main documentation portals for Windows 10 game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-128">Windows デベロッパー センターのメイン ポータル</span><span class="sxs-lookup"><span data-stu-id="52ac8-128">Windows Dev Center main portal</span></span></td>
        <td><span data-ttu-id="52ac8-129"><a href="https://dev.windows.com">Windows デベロッパー センター</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-129"><a href="https://dev.windows.com">Windows Dev Center</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-130">Windows アプリの開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-130">Developing Windows apps</span></span></td>
        <td><span data-ttu-id="52ac8-131"><a href="https://dev.windows.com/develop">Windows アプリを開発します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-131"><a href="https://dev.windows.com/develop">Develop Windows apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-132">ユニバーサル Windows プラットフォーム アプリの開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-132">Universal Windows Platform app development</span></span></td>
        <td><span data-ttu-id="52ac8-133"><a href="https://msdn.microsoft.com/library/windows/apps/mt244352">Windows 10 アプリに関するハウツー ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-133"><a href="https://msdn.microsoft.com/library/windows/apps/mt244352">How-to guides for Windows 10 apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-134">UWP ゲームに関する使い方ガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-134">How-to guides for UWP games</span></span></td>
        <td><span data-ttu-id="52ac8-135"><a href="index.md">ゲームと DirectX</a> </span><span class="sxs-lookup"><span data-stu-id="52ac8-135"><a href="index.md">Games and DirectX</a> </span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-136">DirectX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-136">DirectX reference and overviews</span></span></td>
        <td><span data-ttu-id="52ac8-137"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX のグラフィックスとゲーミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-137"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX Graphics and Gaming</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-138">ゲームのための Azure</span><span class="sxs-lookup"><span data-stu-id="52ac8-138">Azure for gaming</span></span></td>
        <td><span data-ttu-id="52ac8-139"><a href="https://azure.microsoft.com/solutions/gaming/">ビルドし、Azure を使用してゲームをスケール</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-139"><a href="https://azure.microsoft.com/solutions/gaming/">Build and scale your games using Azure</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-140">PlayFab</span><span class="sxs-lookup"><span data-stu-id="52ac8-140">PlayFab</span></span></td>
        <td><span data-ttu-id="52ac8-141"><a href="https://api.playfab.com/">ライブ ゲーム向けの完全なバックエンド ソリューション</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-141"><a href="https://api.playfab.com/">Complete backend solution for live games</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-142">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="52ac8-142">UWP on Xbox One</span></span></td>
        <td><span data-ttu-id="52ac8-143"><a href="https://msdn.microsoft.com/windows/uwp/xbox-apps/index">Xbox One での UWP アプリのビルド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-143"><a href="https://msdn.microsoft.com/windows/uwp/xbox-apps/index">Building UWP apps on Xbox One</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-144">HoloLens の UWP</span><span class="sxs-lookup"><span data-stu-id="52ac8-144">UWP on HoloLens</span></span></td>
        <td><span data-ttu-id="52ac8-145"><a href="https://developer.microsoft.com/windows/mixed-reality/development_overview">HoloLens で UWP アプリのビルド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-145"><a href="https://developer.microsoft.com/windows/mixed-reality/development_overview">Building UWP apps on HoloLens</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-146">Xbox Live に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-146">Xbox Live documentation</span></span></td>
        <td><span data-ttu-id="52ac8-147"><a href="../xbox-live/index.md">開発者ガイドの Xbox Live</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-147"><a href="../xbox-live/index.md">Xbox Live developer guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-148">Xbox One 開発に関するドキュメント (XGD)</span><span class="sxs-lookup"><span data-stu-id="52ac8-148">Xbox One development documentation (XGD)</span></span></td>
        <td><span data-ttu-id="52ac8-149"><a href="https://developer.microsoft.com/games/xbox/partner/development-home">Xbox One の開発</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-149"><a href="https://developer.microsoft.com/games/xbox/partner/development-home">Xbox One Development</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-150">Xbox One 開発に関するホワイト ペーパー (XGD)</span><span class="sxs-lookup"><span data-stu-id="52ac8-150">Xbox One development whitepapers (XGD)</span></span></td>
        <td><span data-ttu-id="52ac8-151"><a href="https://developer.microsoft.com/games/xbox/partner/development-education-whitepapers">ホワイト ペーパー</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-151"><a href="https://developer.microsoft.com/games/xbox/partner/development-education-whitepapers">White Papers</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-152">Mixer の対話機能のドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-152">Mixer Interactive documentation</span></span></td>
        <td><span data-ttu-id="52ac8-153"><a href="https://dev.mixer.com/reference/interactive/index.html">ゲームにインタラクティビティを追加します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-153"><a href="https://dev.mixer.com/reference/interactive/index.html">Add interactivity to your game</a></span></span></td>
    </tr>        
</table>

### <a name="partner-center"></a><span data-ttu-id="52ac8-154">パートナー センター</span><span class="sxs-lookup"><span data-stu-id="52ac8-154">Partner Center</span></span>

<span data-ttu-id="52ac8-155">[パートナー センターでは、開発者アカウントを登録する](https://developer.microsoft.com/store/register)は Windows ゲームを公開における最初の手順です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-155">[Registering a developer account in Partner Center](https://developer.microsoft.com/store/register) is the first step towards publishing your Windows game.</span></span> <span data-ttu-id="52ac8-156">開発者アカウントでは、ゲームの名前を予約することや、すべての Windows デバイスに対応する無料ゲームと有料ゲームを Microsoft Store に提出することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-156">A developer account lets you reserve your game's name and submit free or paid games to the Microsoft Store for all Windows devices.</span></span> <span data-ttu-id="52ac8-157">開発者アカウントを使って、ゲームとゲーム内製品を管理したり、詳細な分析を取得したり、世界中のプレイヤーに優れたエクスペリエンスを提供するサービスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-157">Use your developer account to manage your game and in-game products, get detailed analytics, and enable services that create great experiences for your players around the world.</span></span> 

<span data-ttu-id="52ac8-158">さらにマイクロソフトでは、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-158">Microsoft also offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="52ac8-159">いずれかがパートナー センター アカウントに登録する前に適切な場合が表示されることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-159">We recommend seeing if any are right for you before registering for a Partner Center account.</span></span> <span data-ttu-id="52ac8-160">詳しくは、「[開発者プログラム](#developer-programs)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-160">For more info, go to [Developer programs](#developer-programs)</span></span>


### <a name="developer-programs"></a><span data-ttu-id="52ac8-161">開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-161">Developer programs</span></span>

<span data-ttu-id="52ac8-162">Microsoft では、Windows ゲームの開発と公開に役立ついくつかの開発者向けプログラムを提供しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-162">Microsoft offers several developer programs to help you develop and publish Windows games.</span></span> <span data-ttu-id="52ac8-163">Xbox One のゲームを開発し、Xbox Live の機能をゲームに統合する場合には、開発者プログラムへの参加を検討してください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-163">Consider joining a developer program if you want to develop games for Xbox One and integrate Xbox Live features in your game.</span></span> <span data-ttu-id="52ac8-164">Microsoft Store でのゲームを公開するにも必要で、開発者アカウントを作成する[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-164">To publish a game in the Microsoft Store, you'll also need to create a developer account in [Partner Center](https://partner.microsoft.com/dashboard) .</span></span>

#### <a name="xbox-live-creators-program"></a><span data-ttu-id="52ac8-165">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-165">Xbox Live Creators Program</span></span>

<span data-ttu-id="52ac8-166">Xbox Live クリエーターズ プログラムでは、だれでも Xbox Live を自分のタイトルに統合して、Xbox One や Windows 10 に公開することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-166">The Xbox Live Creators Program allows anyone to integrate Xbox Live into their title and publish to Xbox One and Windows 10.</span></span> <span data-ttu-id="52ac8-167">認定プロセスが簡素化され、標準的な [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx)以外に概念の承認はありません。</span><span class="sxs-lookup"><span data-stu-id="52ac8-167">There is a simplified certification process and no concept approval is required outside of the standard [Microsoft Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx).</span></span>

<span data-ttu-id="52ac8-168">専用の開発キットがなくても、製品版ハードウェアのみを使用して、クリエーターズ プログラムでゲームを展開、設計、公開することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-168">You can deploy, design, and publish your game in the Creators Program without a dedicated dev kit, using only retail hardware.</span></span> <span data-ttu-id="52ac8-169">作業を始めるには、Xbox One で[開発者モードのアクティブ化用アプリ](https://docs.microsoft.com/windows/uwp/xbox-apps/devkit-activation)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-169">To get started, download the [Dev Mode Activation app](https://docs.microsoft.com/windows/uwp/xbox-apps/devkit-activation) on your Xbox One.</span></span>

<span data-ttu-id="52ac8-170">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](https://www.xbox.com/Developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-170">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](https://www.xbox.com/Developers/id) program.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-171">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-171">Xbox Live Creators Program</span></span></td>
        <td><span data-ttu-id="52ac8-172"><a href="https://developer.microsoft.com/games/xbox/xboxlive/creator">Xbox Live Creators Program の詳細を見る</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-172"><a href="https://developer.microsoft.com/games/xbox/xboxlive/creator">Learn more about the Xbox Live Creators Program</a></span></span></td>
    </tr>
</table>

#### <a name="idxbox"></a>ID@Xbox

<span data-ttu-id="52ac8-173">ID@Xbox プログラムを利用すると、認定されたゲーム開発者は Windows や Xbox One 向けに自分でゲームを公開することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-173">The ID@Xbox program helps qualified game developers self-publish on Windows and Xbox One.</span></span> <span data-ttu-id="52ac8-174">Xbox One 向けの開発を行ったり、ゲーマースコア、達成度、ランキングなどの Xbox Live 機能を自分の Windows 10 ゲームでも実現したいと検討されているなら、ID@Xbox にサインアップしてください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-174">If you want to develop for Xbox One, or add Xbox Live features like Gamerscore, achievements, and leaderboards to your Windows 10 game, sign up with ID@Xbox.</span></span> <span data-ttu-id="52ac8-175">ID@Xbox 開発者になると、創造性を発揮し、成功の可能性を最大限に引き出すためのツールやサポートを利用できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-175">Become an ID@Xbox developer to get the tools and support you need to unleash your creativity and maximize your success.</span></span> <span data-ttu-id="52ac8-176">適用することをお勧めします。ID@Xboxパートナー センターでの開発者アカウントに登録する前にします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-176">We recommend that you apply to ID@Xbox first before registering for a developer account in Partner Center.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-177">ID@Xbox開発者プログラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-177">ID@Xbox developer program</span></span></td>
        <td><span data-ttu-id="52ac8-178"><a href="https://go.microsoft.com/fwlink/p/?LinkID=526271">Xbox One の独立した開発者プログラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-178"><a href="https://go.microsoft.com/fwlink/p/?LinkID=526271">Independent Developer Program for Xbox One</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-179">ID@Xbox コンシューマー向けサイト</span><span class="sxs-lookup"><span data-stu-id="52ac8-179">ID@Xbox consumer site</span></span></td>
        <td><a href="https://www.idatxbox.com/">ID@Xbox</a></td>
    </tr>
</table>

#### <a name="xbox-tools-and-middleware"></a><span data-ttu-id="52ac8-180">Xbox のツールとミドルウェア</span><span class="sxs-lookup"><span data-stu-id="52ac8-180">Xbox tools and middleware</span></span>

<span data-ttu-id="52ac8-181">Xbox のツールおよびミドルウェア プログラムは、ゲームのツールやミドルウェア専門の開発者に Xbox 開発キットのライセンスを付与します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-181">The Xbox Tools and Middleware Program licenses Xbox development kits to professional developers of game tools and middleware.</span></span> <span data-ttu-id="52ac8-182">プログラムに受け入れられた開発者は、Xbox XDK テクノロジを共有し、ライセンスを持つ他の Xbox 開発者に配布することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-182">Developers accepted into the program can share and distribute their Xbox XDK technologies to other licensed Xbox developers.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-183">ツールおよびミドルウェア プログラムについて問い合わせる</span><span class="sxs-lookup"><span data-stu-id="52ac8-183">Contact the tools and middleware program</span></span></td>
        <td><xboxtlsm@microsoft.com></td>
    </tr>
</table>


### <a name="game-samples"></a><span data-ttu-id="52ac8-184">ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-184">Game samples</span></span>

<span data-ttu-id="52ac8-185">Windows 10 ゲームとアプリのサンプルが数多く用意されており、Windows 10 のゲーム機能を理解して、ゲーム開発をすぐに始めることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-185">There are many Windows 10 game and app samples available to help you understand Windows 10 gaming features and get a quick start on game development.</span></span> <span data-ttu-id="52ac8-186">サンプルは次々と開発され、定期的に公開されるため、ときどきサンプル ポータルをチェックして、新機能を確認することを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-186">More samples are developed and published regularly, so don't forget to occasionally check back at sample portals to see what's new.</span></span> <span data-ttu-id="52ac8-187">GitHub のリポジトリを[監視](https://help.github.com/articles/watching-repositories/)して、変更や追加についての通知を受け取ることもできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-187">You can also [watch](https://help.github.com/articles/watching-repositories/) GitHub repos to be notified of changes and additions.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-188">ユニバーサル Windows プラットフォーム アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-188">Universal Windows Platform app samples</span></span></td>
        <td><span data-ttu-id="52ac8-189"><a href="https://github.com/Microsoft/Windows-universal-samples">Windows-universal-samples</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-189"><a href="https://github.com/Microsoft/Windows-universal-samples">Windows-universal-samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-190">Direct3D 12 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-190">Direct3D 12 graphics samples</span></span></td>
        <td><span data-ttu-id="52ac8-191"><a href="https://github.com/Microsoft/DirectX-Graphics-Samples">DirectX のサンプル グラフィック</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-191"><a href="https://github.com/Microsoft/DirectX-Graphics-Samples">DirectX-Graphics-Samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-192">Direct3D 11 グラフィックスのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-192">Direct3D 11 graphics samples</span></span></td>
        <td><span data-ttu-id="52ac8-193"><a href="https://github.com/walbourn/directx-sdk-samples">directx sdk のサンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-193"><a href="https://github.com/walbourn/directx-sdk-samples">directx-sdk-samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-194">Direct3D 11 主観視点のゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-194">Direct3D 11 first-person game sample</span></span></td>
        <td><span data-ttu-id="52ac8-195"><a href="tutorial--create-your-first-uwp-directx-game.md">DirectX によるシンプルな UWP ゲームの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-195"><a href="tutorial--create-your-first-uwp-directx-game.md">Create a simple UWP game with DirectX</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-196">Direct2D カスタム画像効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-196">Direct2D custom image effects sample</span></span></td>
        <td><span data-ttu-id="52ac8-197"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620531">D2DCustomEffects</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-197"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620531">D2DCustomEffects</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-198">Direct2D グラデーション メッシュのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-198">Direct2D gradient mesh sample</span></span></td>
        <td><span data-ttu-id="52ac8-199"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620532">D2DGradientMesh</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-199"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620532">D2DGradientMesh</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-200">Direct2D 写真調整のサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-200">Direct2D photo adjustment sample</span></span></td>
        <td><span data-ttu-id="52ac8-201"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620533">D2DPhotoAdjustment</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-201"><a href="https://go.microsoft.com/fwlink/p/?LinkId=620533">D2DPhotoAdjustment</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-202">Xbox Advanced Technology Group のパブリック サンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-202">Xbox Advanced Technology Group public samples</span></span></td>
        <td><span data-ttu-id="52ac8-203"><a href="https://github.com/Microsoft/Xbox-ATG-Samples">Xbox 用 ATG サンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-203"><a href="https://github.com/Microsoft/Xbox-ATG-Samples">Xbox-ATG-Samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-204">Xbox Live のサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-204">Xbox Live samples</span></span></td>
        <td><span data-ttu-id="52ac8-205"><a href="https://github.com/Microsoft/xbox-live-samples">xbox live サンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-205"><a href="https://github.com/Microsoft/xbox-live-samples">xbox-live-samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-206">Xbox One ゲームのサンプル (XGD)</span><span class="sxs-lookup"><span data-stu-id="52ac8-206">Xbox One game samples (XGD)</span></span></td>
        <td><span data-ttu-id="52ac8-207"><a href="https://developer.microsoft.com/games/xbox/partner/development-education-samples">サンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-207"><a href="https://developer.microsoft.com/games/xbox/partner/development-education-samples">Samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-208">Windows ゲームのサンプル (MSDN コード ギャラリー)</span><span class="sxs-lookup"><span data-stu-id="52ac8-208">Windows game samples (MSDN Code Gallery)</span></span></td>
        <td><span data-ttu-id="52ac8-209"><a href="https://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=SearchText&f%5B0%5D.Value=game&f%5B1%5D.Type=Contributors&f%5B1%5D.Value=Microsoft&f%5B1%5D.Text=Microsoft">Microsoft Store ゲームのサンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-209"><a href="https://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=SearchText&f%5B0%5D.Value=game&f%5B1%5D.Type=Contributors&f%5B1%5D.Value=Microsoft&f%5B1%5D.Text=Microsoft">Microsoft Store game samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-210">JavaScript 2D ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-210">JavaScript 2D game sample</span></span></td>
        <td><span data-ttu-id="52ac8-211"><a href="../get-started/get-started-tutorial-game-js2d.md">JavaScript での UWP ゲームを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-211"><a href="../get-started/get-started-tutorial-game-js2d.md">Create a UWP game in JavaScript</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-212">JavaScript 3D ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-212">JavaScript 3D game sample</span></span></td>
        <td><span data-ttu-id="52ac8-213"><a href="../get-started/get-started-tutorial-game-js3d.md">Three.js を使用して 3D JavaScript ゲームを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-213"><a href="../get-started/get-started-tutorial-game-js3d.md">Creating a 3D JavaScript game using three.js</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-214">MonoGame 2D UWP ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-214">MonoGame 2D UWP game sample</span></span></td>
        <td><span data-ttu-id="52ac8-215"><a href="../get-started/get-started-tutorial-game-mg2d.md">MonoGame 2D での UWP ゲームを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-215"><a href="../get-started/get-started-tutorial-game-mg2d.md">Create a UWP game in MonoGame 2D</a></span></span></td>
    </tr>      
</table>


### <a name="developer-forums"></a><span data-ttu-id="52ac8-216">開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-216">Developer forums</span></span>

<span data-ttu-id="52ac8-217">開発者フォーラムは、ゲームの開発に関する質疑応答を行ったり、ゲーム開発コミュニティで交流を深めたりするのに適した場所です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-217">Developer forums are a great place to ask and answer game development questions and connect with the game development community.</span></span> <span data-ttu-id="52ac8-218">フォーラムは、他の開発者が過去に直面し、解決した困難な問題に対する既存の回答を見つけることができる、優れたリソースでもあります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-218">Forums can also be fantastic resources for finding existing answers to difficult issues that developers have faced and solved in the past.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-219">発行のアプリやゲームの開発者向けフォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-219">Publishing apps and games developer forums</span></span></td>
        <td><span data-ttu-id="52ac8-220"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsapps">パブリッシングおよびアプリでの広告</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-220"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsapps">Publishing and ads-in-apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-221">UWP アプリ開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-221">UWP apps developer forum</span></span></td>
        <td><span data-ttu-id="52ac8-222"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?forum=wpdevelop">開発のユニバーサル Windows プラットフォーム アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-222"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?forum=wpdevelop">Developing Universal Windows Platform apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-223">デスクトップ アプリケーション開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-223">Desktop applications developer forums</span></span></td>
        <td><span data-ttu-id="52ac8-224"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsdesktopdev">Windows デスクトップ アプリケーションのフォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-224"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsdesktopdev">Windows desktop applications forums</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-225">DirectX Microsoft Store ゲーム (アーカイブ済みのフォーラムの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-225">DirectX Microsoft Store games (archived forum posts)</span></span></td>
        <td><span data-ttu-id="52ac8-226"><a href="https://social.msdn.microsoft.com/Forums/vstudio/home?forum=wingameswithdirectx">DirectX (アーカイブ済み) を使用した Microsoft Store ゲームの構築</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-226"><a href="https://social.msdn.microsoft.com/Forums/vstudio/home?forum=wingameswithdirectx">Building Microsoft Store games with DirectX (archived)</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-227">Windows 10 対象パートナー開発者フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-227">Windows 10 managed partner developer forums</span></span></td>
        <td><span data-ttu-id="52ac8-228"><a href="https://aka.ms/win10devforums">XBOX デベロッパー フォーラム:Windows 10</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-228"><a href="https://aka.ms/win10devforums">XBOX Developer Forums: Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-229">DirectX フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-229">DirectX forums</span></span></td>
        <td><span data-ttu-id="52ac8-230"><a href="https://forums.directxtech.com/index.php">DirectX 12 のフォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-230"><a href="https://forums.directxtech.com/index.php">DirectX 12 forum</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-231">Azure プラットフォーム フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-231">Azure platform forums</span></span></td>
        <td><span data-ttu-id="52ac8-232"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsazureplatform">Azure フォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-232"><a href="https://social.msdn.microsoft.com/Forums/en-us/home?category=windowsazureplatform">Azure forum</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-233">Xbox Live フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-233">Xbox Live forum</span></span></td>
        <td><span data-ttu-id="52ac8-234"><a href="https://social.msdn.microsoft.com/Forums/en-US/home?forum=xboxlivedev">Xbox Live 開発フォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-234"><a href="https://social.msdn.microsoft.com/Forums/en-US/home?forum=xboxlivedev">Xbox Live development forum</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-235">PlayFab フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-235">PlayFab forums</span></span></td>
        <td><span data-ttu-id="52ac8-236"><a href="https://community.playfab.com/index.html">PlayFab フォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-236"><a href="https://community.playfab.com/index.html">PlayFab forums</a></span></span></td>
    </tr>
</table>


### <a name="developer-blogs"></a><span data-ttu-id="52ac8-237">開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-237">Developer blogs</span></span>

<span data-ttu-id="52ac8-238">開発者ブログは、ゲーム開発に関する最新情報を手に入れることができる、もう 1 つの有用なリソースです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-238">Developer blogs are another great resource for the latest information about game development.</span></span> <span data-ttu-id="52ac8-239">新機能、実装の詳細、ベスト プラクティス、アーキテクチャの背景などに関する投稿を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-239">You'll find posts about new features, implementation details, best practices, architecture background, and more.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-240">Windows 用アプリ開発ブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-240">Building apps for Windows blog</span></span></td>
        <td><span data-ttu-id="52ac8-241"><a href="https://blogs.windows.com/buildingapps/">Windows のアプリの構築</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-241"><a href="https://blogs.windows.com/buildingapps/">Building Apps for Windows</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-242">Windows 10 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-242">Windows 10 (blog posts)</span></span></td>
        <td><span data-ttu-id="52ac8-243"><a href="https://blogs.windows.com/blog/tag/windows-10/">Windows 10 での投稿</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-243"><a href="https://blogs.windows.com/blog/tag/windows-10/">Posts in Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-244">Visual Studio エンジニアリング チームのブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-244">Visual Studio engineering team blog</span></span></td>
        <td><span data-ttu-id="52ac8-245"><a href="https://blogs.msdn.com/b/visualstudio/">Visual Studio ブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-245"><a href="https://blogs.msdn.com/b/visualstudio/">The Visual Studio Blog</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-246">Visual Studio 開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-246">Visual Studio developer tools blogs</span></span></td>
        <td><span data-ttu-id="52ac8-247"><a href="https://blogs.msdn.com/b/developer-tools/">開発者ツールのブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-247"><a href="https://blogs.msdn.com/b/developer-tools/">Developer Tools Blogs</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-248">Somasegar の開発者ツールに関するブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-248">Somasegar's developer tools blog</span></span></td>
        <td><span data-ttu-id="52ac8-249"><a href="https://blogs.msdn.com/b/somasegar/">Somasegar のブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-249"><a href="https://blogs.msdn.com/b/somasegar/">Somasegar’s blog</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-250">DirectX 開発者ブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-250">DirectX developer blog</span></span></td>
        <td><span data-ttu-id="52ac8-251"><a href="https://blogs.msdn.com/b/directx">DirectX の開発者向けブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-251"><a href="https://blogs.msdn.com/b/directx">DirectX Developer blog</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-252">DirectX 12 の概要 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-252">DirectX 12 introduction (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-253"><a href="https://blogs.msdn.com/b/directx/archive/2014/03/20/directx-12.aspx">DirectX 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-253"><a href="https://blogs.msdn.com/b/directx/archive/2014/03/20/directx-12.aspx">DirectX 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-254">Visual C++ ツール チームのブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-254">Visual C++ tools team blog</span></span></td>
        <td><span data-ttu-id="52ac8-255"><a href="https://blogs.msdn.com/b/vcblog/">Visual C チーム ブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-255"><a href="https://blogs.msdn.com/b/vcblog/">Visual C++ team blog</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-256">PIX チームのブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-256">PIX team blog</span></span></td>
        <td><span data-ttu-id="52ac8-257"><a href="https://blogs.msdn.microsoft.com/pix/">パフォーマンスのチューニングと、Windows と Xbox でゲームを DirectX 12 のデバッグ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-257"><a href="https://blogs.msdn.microsoft.com/pix/">Performance tuning and debugging for DirectX 12 games on Windows and Xbox</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-258">ユニバーサル Windows アプリの展開チームのブログ</span><span class="sxs-lookup"><span data-stu-id="52ac8-258">Universal Windows App Deployment team blog</span></span></td>
        <td><span data-ttu-id="52ac8-259"><a href="https://blogs.msdn.microsoft.com/appinstaller/">ビルドおよび配置の UWP アプリ チームのブログ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-259"><a href="https://blogs.msdn.microsoft.com/appinstaller/">Build and deploy UWP apps team blog</a></span></span></td>
    </tr>
</table>
 

## <a name="concept-and-planning"></a><span data-ttu-id="52ac8-260">概念と計画</span><span class="sxs-lookup"><span data-stu-id="52ac8-260">Concept and planning</span></span>


<span data-ttu-id="52ac8-261">概念と計画の段階では、ゲームの全体像とそれを実現するために使用するテクノロジやツールを決定します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-261">In the concept and planning stage, you're deciding what your game is going to be like and the technologies and tools you'll use to bring it to life.</span></span>

### <a name="overview-of-game-development-technologies"></a><span data-ttu-id="52ac8-262">ゲーム開発テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-262">Overview of game development technologies</span></span>

<span data-ttu-id="52ac8-263">UWP のゲームの開発を開始するとき、グラフィックス、入力、オーディオ、ネットワーク、ユーティリティ、ライブラリについて、利用可能なオプションは複数あります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-263">When you start developing a game for the UWP you have multiple options available for graphics, input, audio, networking, utilities, and libraries.</span></span>

<span data-ttu-id="52ac8-264">ゲームで使うすべてのテクノロジが既に決定している場合は問題ありません。</span><span class="sxs-lookup"><span data-stu-id="52ac8-264">If you've already decided on all the technologies you'll be using in your game, great!</span></span> <span data-ttu-id="52ac8-265">まだ決まっていない場合、[UWP アプリのゲーム テクノロジ](game-development-platform-guide.md) ガイドに利用可能な多くのテクノロジの概要がまとめられています。このガイドに目を通して、さまざまなオプションとそれらを組み合わせる方法を理解しておくことを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-265">If not, the [Game technologies for UWP apps](game-development-platform-guide.md) guide is an excellent overview of many of the technologies available, and is highly recommended reading to help you understand the options and how they fit together.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-266">UWP のゲーム テクノロジの概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-266">Survey of UWP game technologies</span></span></td>
        <td><span data-ttu-id="52ac8-267"><a href="game-development-platform-guide.md">UWP アプリ用のゲーム テクノロジ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-267"><a href="game-development-platform-guide.md">Game technologies for UWP apps</a></span></span></td>
    </tr>
</table>
 

<span data-ttu-id="52ac8-268">次の 3 つの GDC 2015 のビデオは、Windows 10 のゲーム開発と Windows 10 のゲーム エクスペリエンスの概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-268">These three GDC 2015 videos give a good overview of Windows 10 game development and the Windows 10 gaming experience.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-269">Windows 10 のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-269">Overview of Windows 10 game development (video)</span></span></td>
        <td><span data-ttu-id="52ac8-270"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Developing-Games-for-Windows-10">Windows 10 向けゲームの開発</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-270"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Developing-Games-for-Windows-10">Developing Games for Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-271">Windows 10 のゲーム エクスペリエンス (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-271">Windows 10 gaming experience (video)</span></span></td>
        <td><span data-ttu-id="52ac8-272"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Gaming-Consumer-Experience-on-Windows-10">Windows 10 でのコンシューマー エクスペリエンスをゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-272"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Gaming-Consumer-Experience-on-Windows-10">Gaming Consumer Experience on Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-273">Microsoft エコシステム全体でのゲーム (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-273">Gaming across the Microsoft ecosystem (video)</span></span></td>
        <td><span data-ttu-id="52ac8-274"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/The-Future-of-Gaming-Across-the-Microsoft-Ecosystem">Microsoft のエコシステム全体でのゲームの未来</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-274"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/The-Future-of-Gaming-Across-the-Microsoft-Ecosystem">The Future of Gaming Across the Microsoft Ecosystem</a></span></span></td>
    </tr>
</table>

### <a name="game-planning"></a><span data-ttu-id="52ac8-275">ゲームの計画</span><span class="sxs-lookup"><span data-stu-id="52ac8-275">Game planning</span></span>

<span data-ttu-id="52ac8-276">これらは、いくつかの高レベルの概念と、ゲームを計画するときに考慮する計画のトピックです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-276">These are some high level concept and planning topics to consider when planning for your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-277">ゲームをアクセシビリティ対応にする</span><span class="sxs-lookup"><span data-stu-id="52ac8-277">Make your game accessible</span></span></td>
        <td><span data-ttu-id="52ac8-278"><a href="https://msdn.microsoft.com/windows/uwp/gaming/accessibility-for-games">ゲームのユーザー補助機能</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-278"><a href="https://msdn.microsoft.com/windows/uwp/gaming/accessibility-for-games">Accessibility for games</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-279">クラウドを使用したゲームの作成</span><span class="sxs-lookup"><span data-stu-id="52ac8-279">Build games using cloud</span></span></td>
        <td><span data-ttu-id="52ac8-280"><a href="https://msdn.microsoft.com/windows/uwp/gaming/cloud-for-games">クラウド ゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-280"><a href="https://msdn.microsoft.com/windows/uwp/gaming/cloud-for-games">Cloud for games</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-281">ゲームの収益化</span><span class="sxs-lookup"><span data-stu-id="52ac8-281">Monetize your game</span></span></td>
        <td><span data-ttu-id="52ac8-282"><a href="https://msdn.microsoft.com/windows/uwp/gaming/monetization-for-games">ゲームの収益化</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-282"><a href="https://msdn.microsoft.com/windows/uwp/gaming/monetization-for-games">Monetization for games</a></span></span></td>
    </tr>
</table>



### <a name="choosing-your-graphics-technology-and-programming-language"></a><span data-ttu-id="52ac8-283">グラフィックス テクノロジとプログラミング言語の選択</span><span class="sxs-lookup"><span data-stu-id="52ac8-283">Choosing your graphics technology and programming language</span></span>

<span data-ttu-id="52ac8-284">Windows 10 ゲームでは、複数のプログラミング言語やグラフィックス テクノロジを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-284">There are several programming languages and graphics technologies available for use in Windows 10 games.</span></span> <span data-ttu-id="52ac8-285">どれを選ぶかは、開発しているゲームの種類、開発スタジオの経験や好み、ゲームの具体的な機能要件によって決まります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-285">The path you take depends on the type of game you’re developing, the experience and preferences of your development studio, and specific feature requirements of your game.</span></span> <span data-ttu-id="52ac8-286">C#、C++、JavaScript のどれを使うか、</span><span class="sxs-lookup"><span data-stu-id="52ac8-286">Will you use C#, C++, or JavaScript?</span></span> <span data-ttu-id="52ac8-287">DirectX、XAML、HTML5 のどれを使うか、</span><span class="sxs-lookup"><span data-stu-id="52ac8-287">DirectX, XAML, or HTML5?</span></span>

#### <a name="directx"></a><span data-ttu-id="52ac8-288">DirectX</span><span class="sxs-lookup"><span data-stu-id="52ac8-288">DirectX</span></span>

<span data-ttu-id="52ac8-289">Microsoft DirectX を使うと、最高のパフォーマンスの 2D および 3D グラフィックスとマルチメディアを生み出すことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-289">Microsoft DirectX is the choice to make for the highest-performance 2D and 3D graphics and multimedia.</span></span>

<span data-ttu-id="52ac8-290">DirectX 12 は、以前のバージョンよりも高速かつ効率的になっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-290">DirectX 12 is faster and more efficient than any previous version.</span></span> <span data-ttu-id="52ac8-291">Direct3D 12 は、より豊かなシーン、より多くのオブジェクト、より複雑な効果を実現し、Windows 10 PC や Xbox One の最新の GPU ハードウェアを十分に活用できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-291">Direct3D 12 enables richer scenes, more objects, more complex effects, and full utilization of modern GPU hardware on Windows 10 PCs and Xbox One.</span></span>

<span data-ttu-id="52ac8-292">Direct3D 11 の使い慣れたグラフィックス パイプラインを使う場合でも、Direct3D 11.3 に追加された新しいレンダリングおよび最適化機能を活かすことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-292">If you want to use the familiar graphics pipeline of Direct3D 11, you’ll still benefit from the new rendering and optimization features added to Direct3D 11.3.</span></span> <span data-ttu-id="52ac8-293">さらに、Win32 をルーツとする実証済みのデスクトップ Windows API の開発者は、Windows 10 でもそのオプションを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-293">And, if you’re a tried-and-true desktop Windows API developer with roots in Win32, you’ll still have that option in Windows 10.</span></span>

<span data-ttu-id="52ac8-294">DirectX のさまざまな機能と緊密なプラットフォーム統合により、要求の多いほとんどのゲームに必要とされる性能とパフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-294">The extensive features and deep platform integration of DirectX provide the power and performance needed by the most demanding games.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-295">UWP 用の DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-295">DirectX for UWP development</span></span></td>
        <td><span data-ttu-id="52ac8-296"><a href="directx-programming.md">DirectX プログラミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-296"><a href="directx-programming.md">DirectX programming</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-297">チュートリアル: UWP の DirectX ゲームを作成する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-297">Tutorial: How to create a UWP DirectX game</span></span></td>
        <td><span data-ttu-id="52ac8-298"><a href="tutorial--create-your-first-uwp-directx-game.md">DirectX によるシンプルな UWP ゲームの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-298"><a href="tutorial--create-your-first-uwp-directx-game.md">Create a simple UWP game with DirectX</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-299">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-299">DirectX overviews and reference</span></span></td>
        <td><span data-ttu-id="52ac8-300"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX のグラフィックスとゲーミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-300"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX Graphics and Gaming</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-301">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-301">Direct3D 12 programming guide and reference</span></span></td>
        <td><span data-ttu-id="52ac8-302"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 のグラフィックス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-302"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 Graphics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-303">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="52ac8-303">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td><span data-ttu-id="52ac8-304"><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA">Microsoft DirectX 12 とグラフィックスの教育</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-304"><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA">Microsoft DirectX 12 and Graphics Education</a></span></span></td>
    </tr>
</table>
 

#### <a name="xaml"></a><span data-ttu-id="52ac8-305">XAML</span><span class="sxs-lookup"><span data-stu-id="52ac8-305">XAML</span></span>

<span data-ttu-id="52ac8-306">XAML は、アニメーション、ストーリーボード、データ バインディング、拡張性の高いベクター ベース グラフィックス、動的なサイズ変更、シーン グラフなどの便利な機能を備える、使いやすい宣言型 UI 言語です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-306">XAML is an easy-to-use declarative UI language with convenient features like animations, storyboards, data binding, scalable vector-based graphics, dynamic resizing, and scene graphs.</span></span> <span data-ttu-id="52ac8-307">また、XAML はゲーム UI、メニュー、スプライト、2D グラフィックスに最適です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-307">XAML works great for game UI, menus, sprites, and 2D graphics.</span></span> <span data-ttu-id="52ac8-308">UI レイアウトを簡単にするため、XAML には、Expression Blend や Microsoft Visual Studio などの設計および開発ツールとの互換性があります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-308">To make UI layout easy, XAML is compatible with design and development tools like Expression Blend and Microsoft Visual Studio.</span></span> <span data-ttu-id="52ac8-309">XAML はよく C# と同時に使用されますが、希望する言語が C++ の場合や、ゲームが多くの CPU を必要とする場合は、C++ も適しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-309">XAML is commonly used with C#, but C++ is also a good choice if that’s your preferred language or if your game has high CPU demands.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-310">XAML プラットフォームの概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-310">XAML platform overview</span></span></td>
        <td><span data-ttu-id="52ac8-311"><a href="https://msdn.microsoft.com/library/windows/apps/mt228259">XAML プラットフォーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-311"><a href="https://msdn.microsoft.com/library/windows/apps/mt228259">XAML platform</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-312">XAML UI とコントロール</span><span class="sxs-lookup"><span data-stu-id="52ac8-312">XAML UI and controls</span></span></td>
        <td><span data-ttu-id="52ac8-313"><a href="https://msdn.microsoft.com/library/windows/apps/mt228348">コントロール、レイアウト、およびテキスト</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-313"><a href="https://msdn.microsoft.com/library/windows/apps/mt228348">Controls, layouts, and text</a></span></span></td>
    </tr>
</table>
 

#### <a name="html-5"></a><span data-ttu-id="52ac8-314">HTML 5</span><span class="sxs-lookup"><span data-stu-id="52ac8-314">HTML 5</span></span>

<span data-ttu-id="52ac8-315">ハイパーテキスト マークアップ言語 (HTML) は、Web ページ、アプリ、リッチ クライアントに使用される一般的な UI マークアップ言語です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-315">HyperText Markup Language (HTML) is a common UI markup language used for web pages, apps, and rich clients.</span></span> <span data-ttu-id="52ac8-316">Windows ゲームでは、HTML の使い慣れた機能、ユニバーサル Windows プラットフォーム、AppCache、Web ワーカー、キャンバス、ドラッグ アンド ドロップ、非同期プログラミング、SVG などの最新の Web 機能のサポートを備えた、全機能装備のプレゼンテーション層として HTML5 を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-316">Windows games can use HTML5 as a full-featured presentation layer with the familiar features of HTML, access to the Universal Windows Platform, and support for modern web features like AppCache, Web Workers, canvas, drag-and-drop, asynchronous programming, and SVG.</span></span> <span data-ttu-id="52ac8-317">HTML レンダリングの内部では、DirectX ハードウェア アクセラレータの機能が活用されるため、追加のコードを記述しなくても DirectX のパフォーマンスの恩恵を受けることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-317">Behind the scenes, HTML rendering takes advantage of the power of DirectX hardware acceleration, so you can still get the performance benefits of DirectX without writing any extra code.</span></span> <span data-ttu-id="52ac8-318">Web 開発に熟練している場合、Web ゲームを移植する場合、または他の選択肢よりアプローチしやすい言語およびグラフィックス層を使う場合は、HTML5 が最適です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-318">HTML5 is a good choice if you are proficient with web development, porting a web game, or want to use language and graphics layers that can be easier to approach than the other choices.</span></span> <span data-ttu-id="52ac8-319">HTML5 は JavaScript と同時に使用されますが、C# や C++/CX で作成されたコンポーネントを呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-319">HTML5 is used with JavaScript, but can also call into components created with C# or C++/CX.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-320">HTML5 とドキュメント オブジェクト モデルに関する情報</span><span class="sxs-lookup"><span data-stu-id="52ac8-320">HTML5 and Document Object Model information</span></span></td>
        <td><span data-ttu-id="52ac8-321"><a href="https://msdn.microsoft.com/library/windows/apps/br212882.aspx">HTML と DOM のリファレンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-321"><a href="https://msdn.microsoft.com/library/windows/apps/br212882.aspx">HTML and DOM reference</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-322">HTML5 W3C 勧告</span><span class="sxs-lookup"><span data-stu-id="52ac8-322">The HTML5 W3C Recommendation</span></span></td>
        <td><span data-ttu-id="52ac8-323"><a href="https://go.microsoft.com/fwlink/p/?linkid=221374">HTML5</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-323"><a href="https://go.microsoft.com/fwlink/p/?linkid=221374">HTML5</a></span></span></td>
    </tr>
</table>
 

#### <a name="combining-presentation-technologies"></a><span data-ttu-id="52ac8-324">プレゼンテーション テクノロジの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="52ac8-324">Combining presentation technologies</span></span>

<span data-ttu-id="52ac8-325">Microsoft DirectX Graphic Infrastructure (DXGI) には、複数のグラフィックス テクノロジにおける相互運用性と互換性が備わっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-325">The Microsoft DirectX Graphics Infrastructure (DXGI) provides interop and compatibility across multiple graphics technologies.</span></span> <span data-ttu-id="52ac8-326">高パフォーマンスのグラフィックスを実現するため、メニューや他のシンプルな UI には XAML を使い、複雑な 2D および 3D シーンのレンダリングには DirectX を使うことで、XAML と DirectX を組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-326">For high-performance graphics, you can combine XAML and DirectX, using XAML for menus and other simple UI, and DirectX for rendering complex 2D and 3D scenes.</span></span> <span data-ttu-id="52ac8-327">DXGI には、Direct2D、Direct3D、DirectWrite、DirectCompute、Microsoft メディア ファンデーション間の互換性も備わっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-327">DXGI also provides compatibility between Direct2D, Direct3D, DirectWrite, DirectCompute, and the Microsoft Media Foundation.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-328">DirectX Graphics Infrastructure のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-328">DirectX Graphics Infrastructure programming guide and reference</span></span></td>
        <td><span data-ttu-id="52ac8-329"><a href="https://msdn.microsoft.com/library/windows/desktop/hh404534">DXGI</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-329"><a href="https://msdn.microsoft.com/library/windows/desktop/hh404534">DXGI</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-330">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="52ac8-330">Combining DirectX and XAML</span></span></td>
        <td><span data-ttu-id="52ac8-331"><a href="directx-and-xaml-interop.md">DirectX および XAML の相互運用機能</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-331"><a href="directx-and-xaml-interop.md">DirectX and XAML interop</a></span></span></td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="52ac8-332">C++</span><span class="sxs-lookup"><span data-stu-id="52ac8-332">C++</span></span>

<span data-ttu-id="52ac8-333">C++/CX はオーバーヘッドの低い高パフォーマンスな言語であり、速度、互換性、プラットフォーム アクセスがうまく組み合わせられています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-333">C++/CX is a high-performance, low overhead language that provides the powerful combination of speed, compatibility, and platform access.</span></span> <span data-ttu-id="52ac8-334">C++/CX により、DirectX や Xbox Live など、Windows 10 のすばらしいゲーム機能すべてが使いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-334">C++/CX makes it easy to use all of the great gaming features in Windows 10, including DirectX and Xbox Live.</span></span> <span data-ttu-id="52ac8-335">既にある C++ コードとライブラリを再利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-335">You can also reuse existing C++ code and libraries.</span></span> <span data-ttu-id="52ac8-336">C++/CX を使うと、ガベージ コレクションのオーバーヘッドを生じさせない高速なネイティブ コードが作成されるため、ゲームのパフォーマンスが向上し、電力消費が低くなり、結果としてバッテリ寿命が延びます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-336">C++/CX creates fast, native code that doesn’t incur the overhead of garbage collection, so your game can have great performance and low power consumption, which leads to longer battery life.</span></span> <span data-ttu-id="52ac8-337">C++/CX を DirectX または XAML と同時に使うか、両方の組み合わせを使って、ゲームを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-337">Use C++/CX with DirectX or XAML, or create a game that uses a combination of both.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-338">C++/CX のリファレンスと概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-338">C++/CX reference and overviews</span></span></td>
        <td><span data-ttu-id="52ac8-339"><a href="https://msdn.microsoft.com/library/windows/apps/hh699871.aspx">Visual C 言語リファレンス (C + + CX)</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-339"><a href="https://msdn.microsoft.com/library/windows/apps/hh699871.aspx">Visual C++ Language Reference (C++/CX)</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-340">Visual C++ のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-340">Visual C++ programming guide and reference</span></span></td>
        <td><span data-ttu-id="52ac8-341"><a href="https://docs.microsoft.com/cpp/visual-cpp-in-visual-studio">Visual Studio 2017 の visual C</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-341"><a href="https://docs.microsoft.com/cpp/visual-cpp-in-visual-studio">Visual C++ in Visual Studio 2017</a></span></span></td>
    </tr>
</table>
 

#### <a name="c"></a><span data-ttu-id="52ac8-342">C#</span><span class="sxs-lookup"><span data-stu-id="52ac8-342">C#</span></span>

<span data-ttu-id="52ac8-343">C# ("シー シャープ" と発音) は、タイプ セーフかつオブジェクト指向のシンプルで強力な最新の革新的言語です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-343">C# (pronounced "C sharp") is a modern, innovative language that is simple, powerful, type-safe, and object-oriented.</span></span> <span data-ttu-id="52ac8-344">C# を使うと、C スタイル言語の親しみやすさと表現力を維持しながら短期間で開発できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-344">C# enables rapid development while retaining the familiarity and expressiveness of C-style languages.</span></span> <span data-ttu-id="52ac8-345">C# は使いやすい言語ですが、ポリモーフィズム、デリゲート、ラムダ、クロージャ、反復子メソッド、共変性、統合言語クエリ (LINQ) 式など、多くの高度な言語機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-345">Though easy to use, C# has numerous advanced language features like polymorphism, delegates, lambdas, closures, iterator methods, covariance, and Language-Integrated Query (LINQ) expressions.</span></span> <span data-ttu-id="52ac8-346">XAML をターゲットとする場合、ゲームの開発をすぐに始めたい場合、C# を既に使ったことがある場合、C# が最適です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-346">C# is an excellent choice if you are targeting XAML, want to get a quick start developing your game, or have previous C# experience.</span></span> <span data-ttu-id="52ac8-347">C# は主に XAML と同時に使われるめ、DirectX を使う場合は、代わりに C++ を選ぶか、ゲームの一部を DirectX とやり取りする C++ コンポーネントとして記述します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-347">C# is used primarily with XAML, so if you want to use DirectX, choose C++ instead, or write part of your game as a C++ component that interacts with DirectX.</span></span> <span data-ttu-id="52ac8-348">または、C# と C++ 用の即時モード Direct2D グラフィックス ライブラリである [Win2D](https://github.com/Microsoft/Win2D) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-348">Or, consider [Win2D](https://github.com/Microsoft/Win2D), an immediate mode Direct2D graphics libary for C# and C++.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-349">C# のプログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-349">C# programming guide and reference</span></span></td>
        <td><span data-ttu-id="52ac8-350"><a href="https://msdn.microsoft.com/library/kx37x362.aspx">C# 言語のリファレンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-350"><a href="https://msdn.microsoft.com/library/kx37x362.aspx">C# language reference</a></span></span></td>
    </tr>
</table>
 

#### <a name="javascript"></a><span data-ttu-id="52ac8-351">JavaScript</span><span class="sxs-lookup"><span data-stu-id="52ac8-351">JavaScript</span></span>

<span data-ttu-id="52ac8-352">JavaScript は、最新の Web アプリケーションやリッチ クライアント アプリケーションに広く使用されている動的なスクリプト言語です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-352">JavaScript is a dynamic scripting language widely used for modern web and rich client applications.</span></span>

<span data-ttu-id="52ac8-353">Windows JavaScript アプリは、ユニバーサル Windows プラットフォームの強力な機能に簡単かつ直感的な方法でアクセスできます (オブジェクト指向 JavaScript クラスのメソッドとプロパティとして)。</span><span class="sxs-lookup"><span data-stu-id="52ac8-353">Windows JavaScript apps can access the powerful features of the Universal Windows Platform in an easy, intuitive way—as methods and properties of object-oriented JavaScript classes.</span></span> <span data-ttu-id="52ac8-354">JavaScript は、Web 開発環境を使っていた場合、JavaScript に既に慣れている場合、HTML5、CSS、WinJS、または JavaScript ライブラリを使用する場合のゲーム開発に最適です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-354">JavaScript is a good choice for your game if you’re coming from a web development environment, are already familiar with JavaScript, or want to use HTML5, CSS, WinJS, or JavaScript libraries.</span></span> <span data-ttu-id="52ac8-355">DirectX や XAML をターゲットとする場合は、代わりに C# または C++/CX を選択してください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-355">If you’re targeting DirectX or XAML, choose C# or C++/CX instead.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-356">JavaScript と Windows ランタイムのリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-356">JavaScript and Windows Runtime reference</span></span></td>
        <td><span data-ttu-id="52ac8-357"><a href="https://msdn.microsoft.com/library/windows/apps/jj613794">JavaScript リファレンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-357"><a href="https://msdn.microsoft.com/library/windows/apps/jj613794">JavaScript reference</a></span></span></td>
    </tr>
</table>


#### <a name="use-windows-runtime-components-to-combine-languages"></a><span data-ttu-id="52ac8-358">Windows ランタイム コンポーネントを使って言語を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="52ac8-358">Use Windows Runtime Components to combine languages</span></span>

<span data-ttu-id="52ac8-359">ユニバーサル Windows プラットフォームでは、異なる言語で記述されたコンポーネントを簡単に組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-359">With the Universal Windows Platform, it’s easy to combine components written in different languages.</span></span> <span data-ttu-id="52ac8-360">C++、C#、Visual Basic で Windows ランタイム コンポーネントを作成した後、JavaScript、C#、C++、Visual Basic から呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-360">Create Windows Runtime Components in C++, C#, or Visual Basic, and then call into them from JavaScript, C#, C++, or Visual Basic.</span></span> <span data-ttu-id="52ac8-361">これは、好みの言語でゲームの一部をプログラミングする場合に最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-361">This is a great way to program portions of your game in the language of your choice.</span></span> <span data-ttu-id="52ac8-362">コンポーネントにより、特定の言語でのみ使用可能な外部ライブラリや、既に記述しているレガシ コードを使うこともできるようになります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-362">Components also let you consume external libraries that are only available in a particular language, as well as use legacy code you’ve already written.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-363">Windows ランタイム コンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-363">How to create Windows Runtime Components</span></span></td>
        <td><span data-ttu-id="52ac8-364"><a href="https://docs.microsoft.com/windows/uwp/winrt-components/creating-windows-runtime-components-in-cpp">Windows ランタイム コンポーネントの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-364"><a href="https://docs.microsoft.com/windows/uwp/winrt-components/creating-windows-runtime-components-in-cpp">Creating Windows Runtime Components</a></span></span></td>
    </tr>
</table>


### <a name="which-version-of-directx-should-your-game-use"></a><span data-ttu-id="52ac8-365">ゲームで使う Microsoft DirectX のバージョン</span><span class="sxs-lookup"><span data-stu-id="52ac8-365">Which version of DirectX should your game use?</span></span>

<span data-ttu-id="52ac8-366">ゲームを DirectX を選択する場合は、使用するバージョンを決定する必要があります。マイクロソフトの Direct3D 12 またはマイクロソフトの Direct3D 11。</span><span class="sxs-lookup"><span data-stu-id="52ac8-366">If you are choosing DirectX for your game, you'll need to decide which version to use: Microsoft Direct3D 12 or Microsoft Direct3D 11.</span></span>

<span data-ttu-id="52ac8-367">DirectX 12 は、以前のバージョンよりも高速かつ効率的になっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-367">DirectX 12 is faster and more efficient than any previous version.</span></span> <span data-ttu-id="52ac8-368">Direct3D 12 は、より豊かなシーン、より多くのオブジェクト、より複雑な効果を実現し、Windows 10 PC や Xbox One の最新の GPU ハードウェアを十分に活用できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-368">Direct3D 12 enables richer scenes, more objects, more complex effects, and full utilization of modern GPU hardware on Windows 10 PCs and Xbox One.</span></span> <span data-ttu-id="52ac8-369">Direct3D 12 は非常に低いレベルで動作するため、専門的なグラフィックス開発チームや経験豊富な DirectX 11 開発チームは、グラフィックスの最適化を十分に活かすために必要となるすべてのコントロールを利用することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-369">Since Direct3D 12 works at a very low level, it is able to give an expert graphics development team or an experienced DirectX 11 development team all the control they need to maximize graphics optimization.</span></span>

<span data-ttu-id="52ac8-370">Direct3D 11.3 は低レベル グラフィック API です。よく利用される Direct3D プログラミング モデルが使われており、GPU レンダリングに関連する多くの複雑な処理を扱うことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-370">Direct3D 11.3 is a low level graphics API that uses the familiar Direct3D programming model and handles for you more of the complexity involved in GPU rendering.</span></span> <span data-ttu-id="52ac8-371">また、Windows 10 と Xbox One でもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-371">It is also supported in Windows 10 and Xbox One.</span></span> <span data-ttu-id="52ac8-372">Direct3D 11 で作成されたエンジンを既にお持ちで、Direct3D 12 への切り替えの準備がまだ整っていない場合は、Direct3D 11 on 12 を使うことによって、ある程度のパフォーマンスの向上を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-372">If you have an existing engine written in Direct3D 11, and you're not quite ready to make the jump to Direct3D 12, you can use Direct3D 11 on 12 to achieve some performance improvements.</span></span> <span data-ttu-id="52ac8-373">バージョン 11.3 以降には、Direct3D 12 でも利用可能な新しいレンダリングと最適化の機能が含まれています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-373">Versions 11.3+ contain the new rendering and optimization features enabled also in Direct3D 12.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-374">Direct3D を選択する 12 または Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="52ac8-374">Choosing Direct3D 12 or Direct3D 11</span></span></td>
        <td><span data-ttu-id="52ac8-375"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899228">Direct3d12 は何ですか。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-375"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899228">What is Direct3D 12?</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-376">Direct3D の概要については 11</span><span class="sxs-lookup"><span data-stu-id="52ac8-376">Overview of Direct3D 11</span></span></td>
        <td><span data-ttu-id="52ac8-377"><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11 のグラフィック</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-377"><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11 Graphics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-378">Direct3D 11 on 12 の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-378">Overview of Direct3D 11 on 12</span></span></td>
        <td><span data-ttu-id="52ac8-379"><a href="https://msdn.microsoft.com/library/windows/desktop/dn913195">12 で direct3d11</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-379"><a href="https://msdn.microsoft.com/library/windows/desktop/dn913195">Direct3D 11 on 12</a></span></span></td>
    </tr>
</table>


### <a name="bridges-game-engines-and-middleware"></a><span data-ttu-id="52ac8-380">ブリッジ、ゲーム エンジン、ミドルウェア</span><span class="sxs-lookup"><span data-stu-id="52ac8-380">Bridges, game engines, and middleware</span></span>

<span data-ttu-id="52ac8-381">ゲームのニーズに応じて、ブリッジ、ゲーム エンジン、ミドルウェアを使うことにより、開発やテストに費やす時間やリソースを節約できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-381">Depending on the needs of your game, using bridges, game engines, or middleware can save development and testing time and resources.</span></span> <span data-ttu-id="52ac8-382">ここでは、ブリッジ、ゲーム エンジン、ミドルウェアの概要とリソースを示します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-382">Here are some overview and resources for bridges, game engines, and middleware.</span></span>

#### <a name="universal-windows-platform-bridges"></a><span data-ttu-id="52ac8-383">ユニバーサル Windows プラットフォーム ブリッジ</span><span class="sxs-lookup"><span data-stu-id="52ac8-383">Universal Windows Platform Bridges</span></span>

<span data-ttu-id="52ac8-384">ユニバーサル Windows プラットフォーム ブリッジは、既にあるアプリやゲームを UWP に移植するためのテクノロジです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-384">Universal Windows Platform Bridges are technologies that bring your existing app or game over to the UWP.</span></span> <span data-ttu-id="52ac8-385">ブリッジは、すぐに UWP のゲーム開発の始めるときに最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-385">Bridges are a great way to get a quick start on UWP game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-386">UWP ブリッジ</span><span class="sxs-lookup"><span data-stu-id="52ac8-386">UWP bridges</span></span></td>
        <td><span data-ttu-id="52ac8-387"><a href="https://dev.windows.com/bridges/">Windows に、コードを移動できます。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-387"><a href="https://dev.windows.com/bridges/">Bring your code to Windows</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-388">Windows Bridge for iOS</span><span class="sxs-lookup"><span data-stu-id="52ac8-388">Windows Bridge for iOS</span></span></td>
        <td><span data-ttu-id="52ac8-389"><a href="https://dev.windows.com/bridges/ios">Windows、iOS アプリを表示します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-389"><a href="https://dev.windows.com/bridges/ios">Bring your iOS apps to Windows</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-390">デスクトップ アプリケーション用 Windows ブリッジ (.NET および Win32)</span><span class="sxs-lookup"><span data-stu-id="52ac8-390">Windows Bridge for desktop applications (.NET and Win32)</span></span></td>
        <td><span data-ttu-id="52ac8-391"><a href="https://developer.microsoft.com/windows/bridges/desktop">デスクトップ アプリケーション UWP アプリへの変換します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-391"><a href="https://developer.microsoft.com/windows/bridges/desktop">Convert your desktop application to a UWP app</a></span></span></td>
    </tr>
</table>

#### <a name="playfab"></a><span data-ttu-id="52ac8-392">PlayFab</span><span class="sxs-lookup"><span data-stu-id="52ac8-392">PlayFab</span></span>

<span data-ttu-id="52ac8-393">Microsoft ファミリの一部となった PlayFab は、ライブ ゲームの完全なバックエンド プラットフォームであり、独立系のスタジオが開発を開始するための強力な手段です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-393">Now part of the Microsoft family, PlayFab is a complete back-end platform for live games and a powerful way for independent studios to get started.</span></span> <span data-ttu-id="52ac8-394">ゲーム サービス、リアルタイム分析、LiveOps によって、コストを削減しながら、収益性、エンゲージメント、リテンションを向上させます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-394">Boost revenue, engagement, and retention—while cutting costs—with game services, real-time analytics, and LiveOps.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-395">PlayFab</span><span class="sxs-lookup"><span data-stu-id="52ac8-395">PlayFab</span></span></td>
        <td><span data-ttu-id="52ac8-396"><a href="https://playfab.com/">ツールとサービスの概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-396"><a href="https://playfab.com/">Overview of tools and services</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-397">概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-397">Getting started</span></span></td>
        <td><span data-ttu-id="52ac8-398"><a href="https://api.playfab.com/docs/general-getting-started">一般的な作業の開始ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-398"><a href="https://api.playfab.com/docs/general-getting-started">General getting started guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-399">ビデオ チュートリアル シリーズ</span><span class="sxs-lookup"><span data-stu-id="52ac8-399">Video tutorial series</span></span></td>
        <td><span data-ttu-id="52ac8-400"><a href="https://www.youtube.com/watch?v=fGNpiqVi5xU&list=PLHCfyL7JpoPbLpA_oh_T5PKrfzPgCpPT5">PlayFab のコア システムについてのデモ ビデオ シリーズ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-400"><a href="https://www.youtube.com/watch?v=fGNpiqVi5xU&list=PLHCfyL7JpoPbLpA_oh_T5PKrfzPgCpPT5">Series of demo videos about PlayFab's core systems</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-401">レシピ</span><span class="sxs-lookup"><span data-stu-id="52ac8-401">Recipes</span></span></td>
        <td><span data-ttu-id="52ac8-402"><a href="https://api.playfab.com/docs/tutorials/recipes-index">人気のあるゲームのしくみと設計パターンのサンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-402"><a href="https://api.playfab.com/docs/tutorials/recipes-index">Popular game mechanics and design pattern samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-403">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="52ac8-403">Platforms</span></span></td>
        <td><span data-ttu-id="52ac8-404"><a href="https://api.playfab.com/platforms">さまざまなプラットフォームとゲーム エンジンの特定のドキュメント</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-404"><a href="https://api.playfab.com/platforms">Specific documentation for various platforms and game engines</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-405">GitHub リポジトリ</span><span class="sxs-lookup"><span data-stu-id="52ac8-405">GitHub repo</span></span></td>
        <td><span data-ttu-id="52ac8-406"><a href="https://github.com/PlayFab">Android、iOS、Windows、Unity、Unreal などのさまざまなプラットフォームのスクリプトと Sdk を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-406"><a href="https://github.com/PlayFab">Get scripts and SDKs for various platforms including Android, iOS, Windows, Unity, and Unreal.</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-407">API ドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-407">API documentation</span></span></td>
        <td><span data-ttu-id="52ac8-408"><a href="https://api.playfab.com/documentation/">残りの部分のような Web Api を使用して直接 PlayFab サービスへのアクセスします。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-408"><a href="https://api.playfab.com/documentation/">Access PlayFab service directly via REST-like Web APIs</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-409">フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-409">Forums</span></span></td>
        <td><span data-ttu-id="52ac8-410"><a href="https://community.playfab.com/index.html">PlayFab フォーラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-410"><a href="https://community.playfab.com/index.html">PlayFab forums</a></span></span></td>
    </tr>
</table>
 

#### <a name="unity"></a><span data-ttu-id="52ac8-411">Unity</span><span class="sxs-lookup"><span data-stu-id="52ac8-411">Unity</span></span>

<span data-ttu-id="52ac8-412">Unity は、美しく魅力的な 2D、3D、VR、AR ゲームやアプリを作成するためのプラットフォームを提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-412">Unity offers a platform for creating beautiful and engaging 2D, 3D, VR, and AR games and apps.</span></span> <span data-ttu-id="52ac8-413">クリエイティブな構想をすばやく実現することができ、事実上、あらゆるメディアやデバイスにコンテンツを提供できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-413">It enables you to realize your creative vision fast and delivers your content to virtually any media or device.</span></span>

<span data-ttu-id="52ac8-414">Unity 5.4 以降では、Unity は Direct3D 12 の開発をサポートします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-414">Beginning with Unity 5.4, Unity supports Direct3D 12 development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-415">Unity ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="52ac8-415">The Unity game engine</span></span></td>
        <td><span data-ttu-id="52ac8-416"><a href="https://unity3d.com/">Unity のゲーム エンジン</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-416"><a href="https://unity3d.com/">Unity - Game Engine</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-417">Unity を入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-417">Get Unity</span></span></td>
        <td><span data-ttu-id="52ac8-418"><a href="https://unity3d.com/get-unity">Unity を入手する</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-418"><a href="https://unity3d.com/get-unity">Get Unity</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-419">Windows 向けの Unity に関するドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-419">Unity documentation for Windows</span></span></td>
        <td><span data-ttu-id="52ac8-420"><a href="https://docs.unity3d.com/Manual/Windows.html">Unity マニュアル/Windows</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-420"><a href="https://docs.unity3d.com/Manual/Windows.html">Unity Manual / Windows</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-421">PlayFab を使用して LiveOps を追加する</span><span class="sxs-lookup"><span data-stu-id="52ac8-421">Add LiveOps using PlayFab</span></span></td>
        <td><span data-ttu-id="52ac8-422"><a href="https://api.playfab.com/docs/getting-started/unity-getting-started">取得する-PlayFab API 呼び出しを始めること、Unity からゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-422"><a href="https://api.playfab.com/docs/getting-started/unity-getting-started">Getting started - Make your first PlayFab API call from your Unity game</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-423">Mixer の対話機能を使用して、ゲームに対話機能を追加する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-423">How to add interactivity to your game using Mixer Interactive</span></span></td>
        <td><span data-ttu-id="52ac8-424"><a href="https://github.com/mixer/interactive-unity-plugin/wiki/Getting-started">ファースト ステップ ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-424"><a href="https://github.com/mixer/interactive-unity-plugin/wiki/Getting-started">Getting started guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-425">Unity 向け Mixer SDK</span><span class="sxs-lookup"><span data-stu-id="52ac8-425">Mixer SDK for Unity</span></span></td>
        <td><span data-ttu-id="52ac8-426"><a href="https://www.assetstore.unity3d.com/en/#!/content/88585">Mixer Unity プラグイン</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-426"><a href="https://www.assetstore.unity3d.com/en/#!/content/88585">Mixer Unity plugin</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-427">Unity 向け Mixer SDK のリファレンス ドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-427">Mixer SDK for Unity reference documentation</span></span></td>
        <td><span data-ttu-id="52ac8-428"><a href="https://dev.mixer.com/reference/interactive/csharp/index.html">Mixer Unity プラグインの API リファレンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-428"><a href="https://dev.mixer.com/reference/interactive/csharp/index.html">API reference for Mixer Unity plugin</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-429">Unity ゲームを Microsoft Store に公開する</span><span class="sxs-lookup"><span data-stu-id="52ac8-429">Publish your Unity game to Microsoft Store</span></span></td>
        <td><span data-ttu-id="52ac8-430"><a href="https://unity3d.com/partners/microsoft/porting-guides">移植のガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-430"><a href="https://unity3d.com/partners/microsoft/porting-guides">Porting guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-431">.NET API に関連するアセンブリ参照が見つからない場合のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="52ac8-431">Troubleshooting missing assembly references related to .NET APIs</span></span></td>
        <td><span data-ttu-id="52ac8-432"><a href="https://docs.microsoft.com/windows/uwp/gaming/missing-dot-net-apis-in-unity-and-uwp">Unity と UWP での .NET Api がないです。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-432"><a href="https://docs.microsoft.com/windows/uwp/gaming/missing-dot-net-apis-in-unity-and-uwp">Missing .NET APIs in Unity and UWP</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-433">ユニバーサル Windows プラットフォーム アプリとして Unity ゲームを公開する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-433">Publish your Unity game as a Universal Windows Platform app (video)</span></span></td>
        <td><span data-ttu-id="52ac8-434"><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-publish-your-Unity-game-as-a-UWP-app">あなたの Unity ゲームを UWP アプリとして発行する方法</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-434"><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/How-to-publish-your-Unity-game-as-a-UWP-app">How to publish your Unity game as a UWP app</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-435">Unity を使って Windows 向けゲームとアプリを作成する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-435">Use Unity to make Windows games and apps (video)</span></span></td>
        <td><span data-ttu-id="52ac8-436"><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/Making-games-and-apps-with-Unity">Windows のゲームや Unity を使用したアプリの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-436"><a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/Making-games-and-apps-with-Unity">Making Windows games and apps with Unity</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-437">Visual Studio を使った Unity ゲームの開発 (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-437">Unity game development using Visual Studio (video series)</span></span></td>
        <td><span data-ttu-id="52ac8-438"><a href="https://go.microsoft.com/fwlink/?LinkId=722359">Visual Studio 2015 での Unity の使用</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-438"><a href="https://go.microsoft.com/fwlink/?LinkId=722359">Using Unity with Visual Studio 2015</a></span></span></td>
    </tr>
</table>
 

#### <a name="havok"></a><span data-ttu-id="52ac8-439">Havok</span><span class="sxs-lookup"><span data-stu-id="52ac8-439">Havok</span></span>

<span data-ttu-id="52ac8-440">Havok のモジュール化された一連のツールとテクノロジによって、ゲーム クリエーターは新しいレベルの対話式操作と没入感を提供できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-440">Havok’s modular suite of tools and technologies help game creators reach new levels of interactivity and immersion.</span></span> <span data-ttu-id="52ac8-441">Havok により、非常にリアルな物理的効果、対話型のシミュレーション、魅力的な映像を実現できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-441">Havok enables highly realistic physics, interactive simulations, and stunning cinematics.</span></span> <span data-ttu-id="52ac8-442">Version 2015.1 以上では、x86、64 ビット、ARM 上の Visual Studio 2015 で UWP を正式にサポートします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-442">Version 2015.1 and higher officially supports UWP in Visual Studio 2015 on x86, 64-bit, and ARM.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-443">Havok の Web サイト</span><span class="sxs-lookup"><span data-stu-id="52ac8-443">Havok website</span></span></td>
        <td><span data-ttu-id="52ac8-444"><a href="https://www.havok.com/">Havok</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-444"><a href="https://www.havok.com/">Havok</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-445">Havok ツール スイート</span><span class="sxs-lookup"><span data-stu-id="52ac8-445">Havok tool suite</span></span></td>
        <td><span data-ttu-id="52ac8-446"><a href="https://www.havok.com/products/">Havok 製品概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-446"><a href="https://www.havok.com/products/">Havok Product Overview</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-447">Havok サポート フォーラム</span><span class="sxs-lookup"><span data-stu-id="52ac8-447">Havok support forums</span></span></td>
        <td><span data-ttu-id="52ac8-448"><a href="https://support.havok.com">Havok</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-448"><a href="https://support.havok.com">Havok</a></span></span></td>
    </tr>
</table>
 

#### <a name="monogame"></a><span data-ttu-id="52ac8-449">MonoGame</span><span class="sxs-lookup"><span data-stu-id="52ac8-449">MonoGame</span></span>

<span data-ttu-id="52ac8-450">MonoGame は、オープン ソース、クロスプラット フォームのゲーム開発フレームワークで、当初は Microsoft の XNA Framework 4.0 に基づいていました。</span><span class="sxs-lookup"><span data-stu-id="52ac8-450">MonoGame is an open source, cross-platform game development framework originally based on Microsoft's XNA Framework 4.0.</span></span> <span data-ttu-id="52ac8-451">現在、Monogame は、Windows、Windows Phone、Xbox と共に、Linux、macOS、iOS、Android、その他のいくつかのプラットフォームをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-451">Monogame currently supports Windows, Windows Phone, and Xbox, as well as Linux, macOS, iOS, Android, and several other platforms.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-452">MonoGame</span><span class="sxs-lookup"><span data-stu-id="52ac8-452">MonoGame</span></span></td>
        <td><span data-ttu-id="52ac8-453"><a href="https://www.monogame.net">MonoGame の web サイト</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-453"><a href="https://www.monogame.net">MonoGame website</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-454">MonoGame のドキュメント</span><span class="sxs-lookup"><span data-stu-id="52ac8-454">MonoGame Documentation</span></span></td>
        <td><span data-ttu-id="52ac8-455"><a href="https://www.monogame.net/documentation/">MonoGame ドキュメント (最新)</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-455"><a href="https://www.monogame.net/documentation/">MonoGame Documentation (latest)</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-456">Monogame のダウンロード</span><span class="sxs-lookup"><span data-stu-id="52ac8-456">Monogame Downloads</span></span></td>
        <td><span data-ttu-id="52ac8-457">MonoGame の Web サイトから<a href="https://www.monogame.net/downloads/">リリース、開発ビルド、ソース コードをダウンロード</a>するか、<a href="https://www.nuget.org/profiles/MonoGame">NuGet から最新のリリースを入手</a>します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-457"><a href="https://www.monogame.net/downloads/">Download releases, development builds, and source code</a> from the MonoGame website, or <a href="https://www.nuget.org/profiles/MonoGame">get the latest release via NuGet</a>.</span></span>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-458">MonoGame 2D UWP ゲームのサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-458">MonoGame 2D UWP game sample</span></span></td>
        <td><span data-ttu-id="52ac8-459"><a href="../get-started/get-started-tutorial-game-mg2d.md">MonoGame 2D での UWP ゲームを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-459"><a href="../get-started/get-started-tutorial-game-mg2d.md">Create a UWP game in MonoGame 2D</a></span></span></td>
    </tr>    
</table>


#### <a name="cocos2d"></a><span data-ttu-id="52ac8-460">Cocos2d</span><span class="sxs-lookup"><span data-stu-id="52ac8-460">Cocos2d</span></span>

<span data-ttu-id="52ac8-461">Cocos2d-x は、オープン ソース、クロス プラットフォームのゲーム開発エンジンおよびツール スイートで、UWP ゲームの構築をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-461">Cocos2d-x is a cross-platform open source game development engine and tools suite that supports building UWP games.</span></span> <span data-ttu-id="52ac8-462">バージョン 3 以降、3D 機能も追加されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-462">Beginning with version 3, 3D features are being added as well.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-463">Cocos2d-x</span><span class="sxs-lookup"><span data-stu-id="52ac8-463">Cocos2d-x</span></span></td>
        <td><span data-ttu-id="52ac8-464"><a href="https://www.cocos2d-x.org/">Cocos2d-x とは何ですか。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-464"><a href="https://www.cocos2d-x.org/">What is Cocos2d-x?</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-465">Cocos2d-x プログラマ ガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-465">Cocos2d-x programmer's guide</span></span></td>
        <td><span data-ttu-id="52ac8-466"><a href="https://www.cocos2d-x.org/programmersguide/">Cocos2d-x プログラマ ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-466"><a href="https://www.cocos2d-x.org/programmersguide/">Cocos2d-x Programmers Guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-467">Windows 10 での Cocos2d-x (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-467">Cocos2d-x on Windows 10 (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-468"><a href="https://blogs.windows.com/buildingapps/2015/06/15/running-cocos2d-x-on-windows-10/">Windows 10 で実行中の cocos2d-x</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-468"><a href="https://blogs.windows.com/buildingapps/2015/06/15/running-cocos2d-x-on-windows-10/">Running Cocos2d-x on Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-469">PlayFab を使用して LiveOps を追加する</span><span class="sxs-lookup"><span data-stu-id="52ac8-469">Add LiveOps using PlayFab</span></span></td>
        <td><span data-ttu-id="52ac8-470"><a href="https://api.playfab.com/docs/getting-started/cocos2d-x-getting-started-guide">取得する-PlayFab API 呼び出しを始めること、Cocos2d からゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-470"><a href="https://api.playfab.com/docs/getting-started/cocos2d-x-getting-started-guide">Getting started - Make your first PlayFab API call from your Cocos2d game</a></span></span></td>
    </tr>
</table>


#### <a name="unreal-engine"></a><span data-ttu-id="52ac8-471">Unreal Engine</span><span class="sxs-lookup"><span data-stu-id="52ac8-471">Unreal Engine</span></span>

<span data-ttu-id="52ac8-472">Unreal Engine 4 は、あらゆる種類のゲームや開発者に適したゲーム開発ツールがすべて揃ったスイートです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-472">Unreal Engine 4 is a complete suite of game development tools for all types of games and developers.</span></span> <span data-ttu-id="52ac8-473">最も要求の厳しいコンソールおよび PC ゲームにおいて、Unreal Engine は世界中のゲーム開発者により使用されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-473">For the most demanding console and PC games, Unreal Engine is used by game developers worldwide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-474">Unreal Engine の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-474">Unreal Engine overview</span></span></td>
        <td><span data-ttu-id="52ac8-475"><a href="https://www.unrealengine.com/what-is-unreal-engine-4">Unreal Engine 4</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-475"><a href="https://www.unrealengine.com/what-is-unreal-engine-4">Unreal Engine 4</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-476">PlayFab を使用して LiveOps を追加する - C++</span><span class="sxs-lookup"><span data-stu-id="52ac8-476">Add LiveOps using PlayFab - C++</span></span></td>
        <td><span data-ttu-id="52ac8-477"><a href="https://api.playfab.com/docs/getting-started/unreal-cpp-getting-started">取得する-PlayFab API 呼び出しを始めること、Unreal のゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-477"><a href="https://api.playfab.com/docs/getting-started/unreal-cpp-getting-started">Getting started - Make your first PlayFab API call from your Unreal game</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-478">PlayFab を使用して LiveOps を追加する - Blueprints</span><span class="sxs-lookup"><span data-stu-id="52ac8-478">Add LiveOps using PlayFab - Blueprints</span></span></td>
        <td><span data-ttu-id="52ac8-479"><a href="https://api.playfab.com/docs/getting-started/unreal-blueprints-getting-started">取得する-PlayFab API 呼び出しを始めること、Unreal のゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-479"><a href="https://api.playfab.com/docs/getting-started/unreal-blueprints-getting-started">Getting started - Make your first PlayFab API call from your Unreal game</a></span></span></td>
    </tr>
</table>

#### <a name="babylonjs"></a><span data-ttu-id="52ac8-480">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="52ac8-480">BabylonJS</span></span>

<span data-ttu-id="52ac8-481">BabylonJS は、HTML5、WebGL、WebVR、Web オーディオで 3D ゲームを構築するための完全な JavaScript フレームワークです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-481">BabylonJS is a complete JavaScript framework for building 3D games with HTML5, WebGL, WebVR, and Web Audio.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-482">BabylonJS</span><span class="sxs-lookup"><span data-stu-id="52ac8-482">BabylonJS</span></span></td>
        <td><span data-ttu-id="52ac8-483"><a href="https://www.babylonjs.com/">BabylonJS</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-483"><a href="https://www.babylonjs.com/">BabylonJS</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-484">HTML5 と BabylonJS を使用した WebGL 3D (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-484">WebGL 3D with HTML5 and BabylonJS (video series)</span></span></td>
        <td><span data-ttu-id="52ac8-485"><a href="https://channel9.msdn.com/Series/Introduction-to-WebGL-3D-with-HTML5-and-Babylonjs/01">WebGL 3D と BabylonJS 学習</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-485"><a href="https://channel9.msdn.com/Series/Introduction-to-WebGL-3D-with-HTML5-and-Babylonjs/01">Learning WebGL 3D and BabylonJS</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-486">BabylonJS を使用してクロスプラットフォーム WebGL ゲームを構築する</span><span class="sxs-lookup"><span data-stu-id="52ac8-486">Building a cross-platform WebGL game with BabylonJS</span></span></td>
        <td><span data-ttu-id="52ac8-487"><a href="https://www.smashingmagazine.com/2016/07/babylon-js-building-sponza-a-cross-platform-webgl-game/">BabylonJS を使用して、クロス プラットフォーム ゲームを開発するには</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-487"><a href="https://www.smashingmagazine.com/2016/07/babylon-js-building-sponza-a-cross-platform-webgl-game/">Use BabylonJS to develop a cross-platform game</a></span></span></td>
    </tr>    
</table>

### <a name="porting-your-game"></a><span data-ttu-id="52ac8-488">ゲームの移植</span><span class="sxs-lookup"><span data-stu-id="52ac8-488">Porting your game</span></span>

<span data-ttu-id="52ac8-489">既にゲームがある場合は、ゲームを短期間で UWP に移植するのに役立つ多くのリソースやガイドがあります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-489">If you have an existing game, there are many resources and guides available to help you quickly bring your game to the UWP.</span></span> <span data-ttu-id="52ac8-490">移植作業をすぐに開始する場合は、[ユニバーサル Windows プラットフォーム ブリッジ](#universal-windows-platform-bridges)を使うことも検討してください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-490">To jumpstart your porting efforts, you might also consider using a [Universal Windows Platform Bridge](#universal-windows-platform-bridges).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-491">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-491">Porting a Windows 8 app to a Universal Windows Platform app</span></span></td>
        <td><span data-ttu-id="52ac8-492"><a href="https://msdn.microsoft.com/library/windows/apps/mt238322">Windows ランタイム 8.x から UWP への移行</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-492"><a href="https://msdn.microsoft.com/library/windows/apps/mt238322">Move from Windows Runtime 8.x to UWP</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-493">Windows 8 アプリをユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-493">Porting a Windows 8 app to a Universal Windows Platform app (video)</span></span></td>
        <td><span data-ttu-id="52ac8-494"><a href="https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/21">8.1 の移植を Windows 10 アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-494"><a href="https://channel9.msdn.com/Series/A-Developers-Guide-to-Windows-10/21">Porting 8.1 Apps to Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-495">iOS アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-495">Porting an iOS app to a Universal Windows Platform app</span></span></td>
        <td><span data-ttu-id="52ac8-496"><a href="https://msdn.microsoft.com/library/windows/apps/mt238320">iOS から UWP への移行</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-496"><a href="https://msdn.microsoft.com/library/windows/apps/mt238320">Move from iOS to UWP</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-497">Silverlight アプリをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-497">Porting a Silverlight app to a Universal Windows Platform app</span></span></td>
        <td><span data-ttu-id="52ac8-498"><a href="https://msdn.microsoft.com/library/windows/apps/mt238323">Windows Phone Silverlight から UWP への移行</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-498"><a href="https://msdn.microsoft.com/library/windows/apps/mt238323">Move from Windows Phone Silverlight to UWP</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-499">XAML または Silverlight からユニバーサル Windows プラットフォーム アプリに移植する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-499">Porting from XAML or Silverlight to a Universal Windows Platform app (video)</span></span></td>
        <td><span data-ttu-id="52ac8-500"><a href="https://channel9.msdn.com/Events/Build/2015/3-741">XAML または Silverlight から Windows 10 にアプリを移植します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-500"><a href="https://channel9.msdn.com/Events/Build/2015/3-741">Porting an App from XAML or Silverlight to Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-501">Xbox ゲームをユニバーサル Windows プラットフォーム アプリに移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-501">Porting an Xbox game to a Universal Windows Platform app</span></span></td>
        <td><span data-ttu-id="52ac8-502"><a href="https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx">Windows 10 UWP Xbox One から移植</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-502"><a href="https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx">Porting from Xbox One to Windows 10 UWP</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-503">DirectX 9 から DirectX 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-503">Porting from DirectX 9 to DirectX 11</span></span></td>
        <td><span data-ttu-id="52ac8-504"><a href="porting-your-directx-9-game-to-windows-store.md">DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-504"><a href="porting-your-directx-9-game-to-windows-store.md">Port from DirectX 9 to Universal Windows Platform (UWP)</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-505">Direct3D 11 から Direct3D 12 に移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-505">Porting from Direct3D 11 to Direct3D 12</span></span></td>
        <td><span data-ttu-id="52ac8-506"><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709">Direct3D から移植 Direct3D を 11 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-506"><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709">Porting from Direct3D 11 to Direct3D 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-507">OpenGL ES から Direct3D 11 に移植する</span><span class="sxs-lookup"><span data-stu-id="52ac8-507">Porting from OpenGL ES to Direct3D 11</span></span></td>
        <td><span data-ttu-id="52ac8-508"><a href="port-from-opengl-es-2-0-to-directx-11-1.md">OpenGL ES 2.0 から Direct3D への移植 11</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-508"><a href="port-from-opengl-es-2-0-to-directx-11-1.md">Port from OpenGL ES 2.0 to Direct3D 11</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-509">ANGLE を使って OpenGL ES から Direct3D 11 に移行する</span><span class="sxs-lookup"><span data-stu-id="52ac8-509">OpenGL ES to Direct3D 11 using ANGLE</span></span></td>
        <td><span data-ttu-id="52ac8-510"><a href="https://go.microsoft.com/fwlink/p/?linkid=618387">角度</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-510"><a href="https://go.microsoft.com/fwlink/p/?linkid=618387">ANGLE</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-511">UWP で従来の Windows API に相当する要素</span><span class="sxs-lookup"><span data-stu-id="52ac8-511">Classic Windows API equivalents in the UWP</span></span></td>
        <td><span data-ttu-id="52ac8-512"><a href="https://msdn.microsoft.com/library/windows/apps/hh464945">Windows ユニバーサル Windows Api の代替プラットフォーム (UWP) アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-512"><a href="https://msdn.microsoft.com/library/windows/apps/hh464945">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</a></span></span></td>
    </tr>
</table>


## <a name="prototype-and-design"></a><span data-ttu-id="52ac8-513">プロトタイプとデザイン</span><span class="sxs-lookup"><span data-stu-id="52ac8-513">Prototype and design</span></span>


<span data-ttu-id="52ac8-514">作成するゲームの種類と、ゲームの構築に使うツールとグラフィックス テクノロジが決まったら、すぐにデザインとプロトタイプを開始できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-514">Now that you've decided the type of game you want to create and the tools and graphics technology you'll use to build it, you're ready to get started with the design and prototype.</span></span> <span data-ttu-id="52ac8-515">ゲームのコアはユニバーサル Windows プラットフォーム アプリであるため、そこから作業を開始します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-515">At its core, your game is a Universal Windows Platform app, so that's where you'll begin.</span></span>

### <a name="introduction-to-the-universal-windows-platform-uwp"></a><span data-ttu-id="52ac8-516">ユニバーサル Windows プラットフォーム (UWP) の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-516">Introduction to the Universal Windows Platform (UWP)</span></span>

<span data-ttu-id="52ac8-517">Windows 10 ではユニバーサル Windows プラットフォーム (UWP) が導入され、Windows 10 デバイス間で共通の API プラットフォームが提供されます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-517">Windows 10 introduces the Universal Windows Platform (UWP), which provides a common API platform across Windows 10 devices.</span></span> <span data-ttu-id="52ac8-518">UWP は、Windows ランタイム モデルを発展させて拡張したもので、まとまりのある統一されたコアとなっています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-518">UWP evolves and expands the Windows Runtime model and hones it into a cohesive, unified core.</span></span> <span data-ttu-id="52ac8-519">UWP を対象とするゲームでは、すべてのデバイスに共通する WinRT API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-519">Games that target the UWP can call WinRT APIs that are common to all devices.</span></span> <span data-ttu-id="52ac8-520">UWP により保証された API 層が提供されるため、あらゆる Windows 10 デバイスにインストールできる 1 つのアプリ パッケージを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-520">Because the UWP provides guaranteed API layers, you can choose to create a single app package that will install across Windows 10 devices.</span></span> <span data-ttu-id="52ac8-521">また、必要に応じて、ゲームが実行されるデバイスに固有の API (Win32 や .NET の従来の Windows API など) を、ゲームで呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-521">And if you want to, your game can still call APIs (including some classic Windows APIs from Win32 and .NET) that are specific to the devices your game runs on.</span></span>

<span data-ttu-id="52ac8-522">次に示すガイドは、ユニバーサル Windows プラットフォーム アプリについて詳しく説明している優れたガイドであり、このプラットフォームを理解するために一読することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-522">The following are excellent guides that discuss the Universal Windows Platform apps in detail, and are recommended reading to help you understand the platform.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-523">ユニバーサル Windows プラットフォーム アプリの概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-523">Introduction to Universal Windows Platform apps</span></span></td>
        <td><span data-ttu-id="52ac8-524"><a href="https://msdn.microsoft.com/library/windows/apps/dn726767">新機能、ユニバーサル Windows プラットフォーム アプリですか?</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-524"><a href="https://msdn.microsoft.com/library/windows/apps/dn726767">What's a Universal Windows Platform app?</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-525">UWP の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-525">Overview of the UWP</span></span></td>
        <td><span data-ttu-id="52ac8-526"><a href="https://msdn.microsoft.com/library/windows/apps/dn894631">UWP アプリ ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-526"><a href="https://msdn.microsoft.com/library/windows/apps/dn894631">Guide to UWP apps</a></span></span></td>
    </tr>
</table>
 

### <a name="getting-started-with-uwp-development"></a><span data-ttu-id="52ac8-527">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-527">Getting started with UWP development</span></span>

<span data-ttu-id="52ac8-528">ユニバーサル Windows プラットフォーム アプリを開発するための準備は非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-528">Getting set up and ready to develop a Universal Windows Platform app is quick and easy.</span></span> <span data-ttu-id="52ac8-529">以下のガイドでは、プロセスの詳しい手順を説明しています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-529">The following guides take you through the process step-by-step.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-530">UWP 開発の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-530">Getting started with UWP development</span></span></td>
        <td><span data-ttu-id="52ac8-531"><a href="https://dev.windows.com/getstarted">Windows アプリの概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-531"><a href="https://dev.windows.com/getstarted">Get started with Windows apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-532">UWP 開発の準備</span><span class="sxs-lookup"><span data-stu-id="52ac8-532">Getting set up for UWP development</span></span></td>
        <td><span data-ttu-id="52ac8-533"><a href="https://msdn.microsoft.com/library/windows/apps/dn726766">準備</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-533"><a href="https://msdn.microsoft.com/library/windows/apps/dn726766">Get set up</a></span></span></td>
    </tr>
</table>

<span data-ttu-id="52ac8-534">UWP プログラミングについて "文字どおりの初心者" である場合や、ゲームで XAML の使用を検討している場合 (「[グラフィックス テクノロジとプログラミング言語の選択](#choosing-your-graphics-technology-and-programming-language)」を参照) は、最初に[文字どおりの初心者のための Windows 10 の開発](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners)に関するビデオ シリーズをご覧になることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-534">If you're an "absolute beginner" to UWP programming, and are considering using XAML in your game (see [Choosing your graphics technology and programming language](#choosing-your-graphics-technology-and-programming-language)), the [Windows 10 development for absolute beginners](https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners) video series is a good place to start.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-535">XAML を使った Windows 10 の開発の初心者向けガイド (ビデオ シリーズ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-535">Beginners guide to Windows 10 development with XAML (Video series)</span></span></td>
        <td><span data-ttu-id="52ac8-536"><a href="https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners">超初心者向けの Windows 10 の開発</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-536"><a href="https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners">Windows 10 development for absolute beginners</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-537">XAML を使う Windows 10 の初心者向けシリーズの発表 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-537">Announcing the Windows 10 absolute beginners series using XAML (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-538"><a href="https://blogs.windows.com/buildingapps/2015/09/30/windows-10-development-for-absolute-beginners/">超初心者向けの Windows 10 の開発</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-538"><a href="https://blogs.windows.com/buildingapps/2015/09/30/windows-10-development-for-absolute-beginners/">Windows 10 development for absolute beginners</a></span></span></td>
    </tr>
</table>

### <a name="uwp-development-concepts"></a><span data-ttu-id="52ac8-539">UWP 開発の概念</span><span class="sxs-lookup"><span data-stu-id="52ac8-539">UWP development concepts</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-540">ユニバーサル Windows プラットフォーム アプリの開発の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-540">Overview of Universal Windows Platform app development</span></span></td>
        <td><span data-ttu-id="52ac8-541"><a href="https://dev.windows.com/develop">Windows アプリを開発します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-541"><a href="https://dev.windows.com/develop">Develop Windows apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-542">UWP のネットワーク プログラミングの概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-542">Overview of network programming in the UWP</span></span></td>
        <td><span data-ttu-id="52ac8-543"><a href="https://msdn.microsoft.com/library/windows/apps/mt280378">ネットワークと Web サービス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-543"><a href="https://msdn.microsoft.com/library/windows/apps/mt280378">Networking and web services</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-544">ゲームでの Windows.Web.HTTP と Windows.Networking.Sockets の使用</span><span class="sxs-lookup"><span data-stu-id="52ac8-544">Using Windows.Web.HTTP and Windows.Networking.Sockets in games</span></span></td>
        <td><span data-ttu-id="52ac8-545"><a href="work-with-networking-in-your-directx-game.md">ゲーム用のネットワーク</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-545"><a href="work-with-networking-in-your-directx-game.md">Networking for games</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-546">UWP での非同期プログラミングの概念</span><span class="sxs-lookup"><span data-stu-id="52ac8-546">Asynchronous programming concepts in the UWP</span></span></td>
        <td><span data-ttu-id="52ac8-547"><a href="https://msdn.microsoft.com/library/windows/apps/mt187335">非同期プログラミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-547"><a href="https://msdn.microsoft.com/library/windows/apps/mt187335">Asynchronous programming</a></span></span></td>
    </tr>
</table>

### <a name="windows-desktop-apisto-uwp"></a><span data-ttu-id="52ac8-548">UWP への Windows デスクトップ Api</span><span class="sxs-lookup"><span data-stu-id="52ac8-548">Windows Desktop APIs to UWP</span></span>

<span data-ttu-id="52ac8-549">Windows デスクトップ ゲームを UWP に移行する際に役立つリンクの一部を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-549">These are some links to help you move your Windows desktop game to UWP.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-550">既存の C++ コードを使った UWP ゲーム開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-550">Use existing C++ code for UWP game development</span></span></td>
        <td><span data-ttu-id="52ac8-551">「<a href="https://docs.microsoft.com/cpp/porting/how-to-use-existing-cpp-code-in-a-universal-windows-platform-app">UWP アプリで既存の C++ コードを使用します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-551"><a href="https://docs.microsoft.com/cpp/porting/how-to-use-existing-cpp-code-in-a-universal-windows-platform-app">How to: Use existing C++ code in a UWP app</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-552">Win32 API と COM API 用の UWP API</span><span class="sxs-lookup"><span data-stu-id="52ac8-552">UWP APIs for Win32 and COM APIs</span></span></td>
        <td><span data-ttu-id="52ac8-553"><a href="https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps">Win32 および COM Api の UWP アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-553"><a href="https://docs.microsoft.com/uwp/win32-and-com/win32-and-com-for-uwp-apps">Win32 and COM APIs for UWP apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-554">UWP でサポートされない CRT 関数</span><span class="sxs-lookup"><span data-stu-id="52ac8-554">Unsupported CRT functions in UWP</span></span></td>
        <td><span data-ttu-id="52ac8-555"><a href="https://msdn.microsoft.com/library/windows/apps/jj606124.aspx">ユニバーサル Windows プラットフォーム アプリでサポートされない CRT 関数</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-555"><a href="https://msdn.microsoft.com/library/windows/apps/jj606124.aspx">CRT functions not supported in Universal Windows Platform apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-556">Windows API の代替</span><span class="sxs-lookup"><span data-stu-id="52ac8-556">Alternatives for Windows APIs</span></span></td>
        <td><span data-ttu-id="52ac8-557"><a href="https://msdn.microsoft.com/library/windows/apps/mt592894.aspx">Windows ユニバーサル Windows Api の代替プラットフォーム (UWP) アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-557"><a href="https://msdn.microsoft.com/library/windows/apps/mt592894.aspx">Alternatives to Windows APIs in Universal Windows Platform (UWP) apps</a></span></span></td>
    </tr>
</table>
 

### <a name="process-lifetime-management"></a><span data-ttu-id="52ac8-558">プロセス ライフタイム管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-558">Process lifetime management</span></span>

<span data-ttu-id="52ac8-559">プロセス ライフタイム管理、つまりアプリのライフ サイクルは、ユニバーサル Windows プラットフォーム アプリが取り得るさまざまなアクティブ化状態を表します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-559">Process lifetime management, or app lifecyle, describes the various activation states that a Universal Windows Platform app can transition through.</span></span> <span data-ttu-id="52ac8-560">ゲームは、アクティブ化、中断、再開、または終了することができ、さまざまな方法でこれらの状態を移行できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-560">Your game can be activated, suspended, resumed, or terminated, and can transition through those states in a variety of ways.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-561">アプリのライフ サイクルの移行の処理</span><span class="sxs-lookup"><span data-stu-id="52ac8-561">Handling app lifecyle transitions</span></span></td>
        <td><span data-ttu-id="52ac8-562"><a href="https://msdn.microsoft.com/library/windows/apps/mt243287">アプリのライフサイクル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-562"><a href="https://msdn.microsoft.com/library/windows/apps/mt243287">App lifecycle</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-563">Microsoft Visual Studio を使ったアプリの移行のトリガー</span><span class="sxs-lookup"><span data-stu-id="52ac8-563">Using Microsoft Visual Studio to trigger app transitions</span></span></td>
        <td><span data-ttu-id="52ac8-564"><a href="https://msdn.microsoft.com/library/hh974425.aspx">トリガーする方法を中断、再開、およびバック グラウンド イベントを Visual Studio で UWP アプリ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-564"><a href="https://msdn.microsoft.com/library/hh974425.aspx">How to trigger suspend, resume, and background events for UWP apps in Visual Studio</a></span></span></td>
    </tr>
</table>
 

### <a name="designing-game-ux"></a><span data-ttu-id="52ac8-565">ゲーム UX の設計</span><span class="sxs-lookup"><span data-stu-id="52ac8-565">Designing game UX</span></span>

<span data-ttu-id="52ac8-566">優れたゲームはすばらしいデザインから始まります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-566">The genesis of a great game is inspired design.</span></span>

<span data-ttu-id="52ac8-567">ゲームは、共通のユーザー インターフェイス要素とデザイン原則をアプリと共有していますが、ユーザー エクスペリエンスの外観、機能、設計目標が独特であることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-567">Games share some common user interface elements and design principles with apps, but games often have a unique look, feel, and design goal for their user experience.</span></span> <span data-ttu-id="52ac8-568">テストされた UX をゲームで使用すべきなのはいつか、斬新で革新的な UX を使用すべきなのはいつか、という両方の側面に、よく考えられたデザインを当てはめるときにゲームは成功します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-568">Games succeed when thoughtful design is applied to both aspects—when should your game use tested UX, and when should it diverge and innovate?</span></span> <span data-ttu-id="52ac8-569">ゲームに選択したプレゼンテーション テクノロジ (DirectX、XAML、HTML5、または 3 つの組み合わせ) は、実装の細部に影響を与える可能性がありますが、適用するデザイン原則はその選択とはほとんど関係がありません。</span><span class="sxs-lookup"><span data-stu-id="52ac8-569">The presentation technology that you choose for your game—DirectX, XAML, HTML5, or some combination of the three—will influence implementation details, but the design principles you apply are largely independent of that choice.</span></span>

<span data-ttu-id="52ac8-570">UX デザインとは別に、レベルのデザイン、ペース配分、世界のデザインなどのゲームプレイのデザインには独自の様式があり、開発者や開発チームによって決定されるため、この開発ガイドに記載していません。</span><span class="sxs-lookup"><span data-stu-id="52ac8-570">Separately from UX design, gameplay design such as level design, pacing, world design, and other aspects is an art form of its own—one that's up to you and your team, and not covered in this development guide.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-571">UWP の設計の基本とガイドライン</span><span class="sxs-lookup"><span data-stu-id="52ac8-571">UWP design basics and guidelines</span></span></td>
        <td><span data-ttu-id="52ac8-572"><a href="https://developer.microsoft.com/en-us/windows/apps/design">UWP アプリの設計</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-572"><a href="https://developer.microsoft.com/en-us/windows/apps/design">Designing UWP apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-573">アプリのライフサイクルの状態の設計</span><span class="sxs-lookup"><span data-stu-id="52ac8-573">Designing for app lifecycle states</span></span></td>
        <td><span data-ttu-id="52ac8-574"><a href="https://msdn.microsoft.com/library/windows/apps/dn611862">UX ガイドラインに起動、中断、および再開</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-574"><a href="https://msdn.microsoft.com/library/windows/apps/dn611862">UX guidelines for launch, suspend, and resume</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-575">Xbox One とテレビ画面向けの UWP アプリの設計</span><span class="sxs-lookup"><span data-stu-id="52ac8-575">Design your UWP app for Xbox One and television screens</span></span></td>
        <td><span data-ttu-id="52ac8-576"><a href="https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv">Xbox およびテレビ向け設計</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-576"><a href="https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv">Designing for Xbox and TV</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-577">複数のデバイスのフォーム ファクターをターゲットに設定する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-577">Targeting multiple device form factors (video)</span></span></td>
        <td><span data-ttu-id="52ac8-578"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Designing-Games-for-a-Windows-Core-World">Windows Core 世界中のゲームの設計</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-578"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Designing-Games-for-a-Windows-Core-World">Designing Games for a Windows Core World</a></span></span></td>
    </tr>   
</table>
 

#### <a name="color-guideline-and-palette"></a><span data-ttu-id="52ac8-579">色のガイドラインとパレット</span><span class="sxs-lookup"><span data-stu-id="52ac8-579">Color guideline and palette</span></span>

<span data-ttu-id="52ac8-580">ゲームで一貫した色のガイドラインに従うと、美しさやナビゲーションの操作性が向上し、メニューや HUD の機能がプレーヤーに伝わりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-580">Following a consistent color guideline in your game improves aesthetics, aids navigation, and is a powerful tool to inform the player of menu and HUD functionality.</span></span> <span data-ttu-id="52ac8-581">警告、ダメージ、XP、成績などのゲーム要素の色が一貫していると、UI がわかりやすくなるため、ラベルによって説明する必要性が減ります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-581">Consistent coloring of game elements like warnings, damage, XP, and achievements can lead to cleaner UI and reduce the need for explicit labels.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-582">色のガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-582">Color guide</span></span></td>
        <td><span data-ttu-id="52ac8-583"><a href="https://assets.windowsphone.com/499cd2be-64ed-4b05-a4f5-cd0c9ad3f6a3/101_BestPractices_Color_InvariantCulture_Default.zip">ベスト プラクティス:色</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-583"><a href="https://assets.windowsphone.com/499cd2be-64ed-4b05-a4f5-cd0c9ad3f6a3/101_BestPractices_Color_InvariantCulture_Default.zip">Best Practices: Color</a></span></span></td>
    </tr>
</table>
 

#### <a name="typography"></a><span data-ttu-id="52ac8-584">文字体裁</span><span class="sxs-lookup"><span data-stu-id="52ac8-584">Typography</span></span>

<span data-ttu-id="52ac8-585">文字体裁を適切に使うと、UI のレイアウト、ナビゲーション、読みやすさ、雰囲気、ブランド、プレイヤーの熱中度など、多くの側面が向上します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-585">The appropriate use of typography enhances many aspects of your game, including UI layout, navigation, readability, atmosphere, brand, and player immersion.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-586">文字体裁のガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-586">Typography guide</span></span></td>
        <td><span data-ttu-id="52ac8-587"><a href="https://go.microsoft.com/fwlink/?LinkId=535007">ベスト プラクティス:文字体裁</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-587"><a href="https://go.microsoft.com/fwlink/?LinkId=535007">Best Practices: Typography</a></span></span></td>
    </tr>
</table>
 

#### <a name="ui-map"></a><span data-ttu-id="52ac8-588">UI マップ</span><span class="sxs-lookup"><span data-stu-id="52ac8-588">UI map</span></span>

<span data-ttu-id="52ac8-589">UI マップとは、ゲーム ナビゲーションのレイアウトとフローチャートで表されるメニューのことです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-589">A UI map is a layout of game navigation and menus expressed as a flowchart.</span></span> <span data-ttu-id="52ac8-590">UI マップを使うと、すべての関係者が、ゲームのインターフェイスとナビゲーション パスを理解しやすくなり、開発サイクルの初期段階で潜在的な障害や行き詰まりが明らかになります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-590">The UI map helps all involved stakeholders understand the game’s interface and navigation paths, and can expose potential roadblocks and dead ends early in the development cycle.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-591">UI マップ ガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-591">UI map guide</span></span></td>
        <td><span data-ttu-id="52ac8-592"><a href="https://go.microsoft.com/fwlink/?LinkId=535008">ベスト プラクティス:UI マップ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-592"><a href="https://go.microsoft.com/fwlink/?LinkId=535008">Best Practices: UI Map</a></span></span></td>
    </tr>
</table>

### <a name="game-audio"></a><span data-ttu-id="52ac8-593">ゲーム オーディオ</span><span class="sxs-lookup"><span data-stu-id="52ac8-593">Game audio</span></span>

<span data-ttu-id="52ac8-594">XAudio2、XAPO、Windows Sonic を使ってオーディオをゲームで実装するためのガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-594">Guides and references for implementing audio in games using XAudio2, XAPO, and Windows Sonic.</span></span> <span data-ttu-id="52ac8-595">XAudio2 は、パフォーマンスの高いオーディオ エンジンを開発するための、信号処理とミキシングの基盤を提供する低水準のオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-595">XAudio2 is a low-level audio API that provides signal processing and mixing foundation for developing high performance audio engines.</span></span> <span data-ttu-id="52ac8-596">XAPO API を使用すると、XAudio2 を使用するクロスプラットフォーム オーディオ処理オブジェクト (XAPO) を、Windows と Xbox の両方で作成できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-596">XAPO API allows the creation of cross-platform audio processing objects (XAPO) for use in XAudio2 on both Windows and Xbox.</span></span> <span data-ttu-id="52ac8-597">Windows Sonic オーディオのサポートにより、ゲームやストリーミング メディア アプリケーションに、Dolby Atmos for Home Theater、Dolby Atmos for Headphones、Windows HRTF のサポートを追加できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-597">Windows Sonic audio support allows you to add Dolby Atmos for Home Theater, Dolby Atmos for Headphones, and Windows HRTF support to your game or streaming media application.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-598">XAudio2 API</span><span class="sxs-lookup"><span data-stu-id="52ac8-598">XAudio2 APIs</span></span></td>
        <td><span data-ttu-id="52ac8-599"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049.aspx">プログラミング ガイドと XAudio2 の API リファレンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-599"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049.aspx">Programming guide and API reference for XAudio2</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-600">クロスプラット フォーム オーディオ処理オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="52ac8-600">Create cross-platform audio processing objects</span></span></td>
        <td><span data-ttu-id="52ac8-601"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415735.aspx">XAPO の概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-601"><a href="https://msdn.microsoft.com/library/windows/desktop/ee415735.aspx">XAPO Overview</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-602">オーディオの概念の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-602">Intro to audio concepts</span></span></td>
        <td><span data-ttu-id="52ac8-603"><a href="working-with-audio-in-your-directx-game.md">ゲームにオーディオ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-603"><a href="working-with-audio-in-your-directx-game.md">Audio for games</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-604">Windows Sonic の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-604">Windows Sonic overview</span></span></td>
        <td><span data-ttu-id="52ac8-605"><a href="https://msdn.microsoft.com/library/windows/desktop/mt807491.aspx">空間のサウンド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-605"><a href="https://msdn.microsoft.com/library/windows/desktop/mt807491.aspx">Spatial sound</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-606">Windows Sonic の立体音響のサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-606">Windows Sonic spatial sound samples</span></span></td>
        <td><span data-ttu-id="52ac8-607"><a href="https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/Audio">高度なテクノロジのグループの Xbox オーディオ サンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-607"><a href="https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/Audio">Xbox Advanced Technology Group audio samples</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-608">Windows Sonic をゲーム (ビデオ) に統合する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-608">Learn how to integrate Windows Sonic into your games (video)</span></span></td>
        <td><span data-ttu-id="52ac8-609"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-002">Xbox、Windows の空間のオーディオ機能を発表</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-609"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-002">Introducing Spatial Audio Capabilities for Xbox and Windows</a></span></span></td>
    </tr>
</table>

### <a name="directx-development"></a><span data-ttu-id="52ac8-610">DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-610">DirectX development</span></span>

<span data-ttu-id="52ac8-611">DirectX ゲーム開発用のガイドと参照情報を紹介します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-611">Guides and references for DirectX game development.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-612">UWP 用の DirectX 開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-612">DirectX for UWP development</span></span></td>
        <td><span data-ttu-id="52ac8-613"><a href="directx-programming.md">DirectX プログラミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-613"><a href="directx-programming.md">DirectX programming</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-614">チュートリアル: UWP の DirectX ゲームを作成する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-614">Tutorial: How to create a UWP DirectX game</span></span></td>
        <td><span data-ttu-id="52ac8-615"><a href="tutorial--create-your-first-uwp-directx-game.md">DirectX によるシンプルな UWP ゲームの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-615"><a href="tutorial--create-your-first-uwp-directx-game.md">Create a simple UWP game with DirectX</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-616">UWP アプリ モデルによる DirectX の操作</span><span class="sxs-lookup"><span data-stu-id="52ac8-616">DirectX interaction with the UWP app model</span></span></td>
        <td><span data-ttu-id="52ac8-617"><a href="about-the-uwp-user-interface-and-directx.md">アプリケーション オブジェクトと DirectX</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-617"><a href="about-the-uwp-user-interface-and-directx.md">The app object and DirectX</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-618">グラフィックスおよび DirectX 12 開発に関するビデオ (YouTube チャンネル)</span><span class="sxs-lookup"><span data-stu-id="52ac8-618">Graphics and DirectX 12 development videos (YouTube channel)</span></span></td>
        <td><span data-ttu-id="52ac8-619"><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA">Microsoft DirectX 12 とグラフィックスの教育</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-619"><a href="https://www.youtube.com/channel/UCiaX2B8XiXR70jaN7NK-FpA">Microsoft DirectX 12 and Graphics Education</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-620">DirectX の概要とリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-620">DirectX overviews and reference</span></span></td>
        <td><span data-ttu-id="52ac8-621"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX のグラフィックスとゲーミング</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-621"><a href="https://msdn.microsoft.com/library/windows/desktop/ee663274">DirectX Graphics and Gaming</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-622">Direct3D 12 プログラミング ガイドとリファレンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-622">Direct3D 12 programming guide and reference</span></span></td>
        <td><span data-ttu-id="52ac8-623"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 のグラフィックス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-623"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 Graphics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-624">DirectX 12 の基本事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-624">DirectX 12 fundamentals (video)</span></span></td>
        <td><span data-ttu-id="52ac8-625"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Better-Power-Better-Performance-Your-Game-on-DirectX12">優れた電源、パフォーマンスが向上します。DirectX 12 のゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-625"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Better-Power-Better-Performance-Your-Game-on-DirectX12">Better Power, Better Performance: Your Game on DirectX 12</a></span></span></td>
    </tr>
</table>

#### <a name="learning-direct3d-12"></a><span data-ttu-id="52ac8-626">Direct3D 12 について</span><span class="sxs-lookup"><span data-stu-id="52ac8-626">Learning Direct3D 12</span></span>

<span data-ttu-id="52ac8-627">Direct3D 12 での変更点、および Direct3D 12 を使ってプログラミングを開始する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-627">Learn what changed in Direct3D 12 and how to start programming using Direct3D 12.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-628">プログラミング環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="52ac8-628">Set up programming environment</span></span></td>
        <td><span data-ttu-id="52ac8-629"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899120.aspx">Direct3d12 プログラミング環境のセットアップ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-629"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899120.aspx">Direct3D 12 programming environment setup</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-630">基本的なコンポーネントを作成する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-630">How to create a basic component</span></span></td>
        <td><span data-ttu-id="52ac8-631"><a href="https://msdn.microsoft.com/library/windows/desktop/dn859356.aspx">Direct3d12 の基本的なコンポーネントを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-631"><a href="https://msdn.microsoft.com/library/windows/desktop/dn859356.aspx">Creating a basic Direct3D 12 component</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-632">Direct3D 12 での変更点</span><span class="sxs-lookup"><span data-stu-id="52ac8-632">Changes in Direct3D 12</span></span></td>
        <td><span data-ttu-id="52ac8-633"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899194.aspx">Direct3d11 から direct3d12 への移行、重要な変更</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-633"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899194.aspx">Important changes migrating from Direct3D 11 to Direct3D 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-634">Direct3D 11 から Direct3D 12 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-634">How to port from Direct3D 11 to Direct3D 12</span></span></td>
        <td><span data-ttu-id="52ac8-635"><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709.aspx">Direct3D から移植 Direct3D を 11 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-635"><a href="https://msdn.microsoft.com/library/windows/desktop/mt431709.aspx">Porting from Direct3D 11 to Direct3D 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-636">リソース バインディングの概念 (対象となる記述子、記述子テーブル、記述子ヒープ、およびルート署名)</span><span class="sxs-lookup"><span data-stu-id="52ac8-636">Resource binding concepts (covering descriptor, descriptor table, descriptor heap, and root signature)</span></span> </td>
        <td><span data-ttu-id="52ac8-637"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899206.aspx">Direct3d12 でリソースのバインド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-637"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899206.aspx">Resource binding in Direct3D 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-638">メモリ管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-638">Managing memory</span></span></td>
        <td><span data-ttu-id="52ac8-639"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899198.aspx">Direct3d12 でのメモリ管理</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-639"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899198.aspx">Memory management in Direct3D 12</a></span></span></td>
    </tr>
</table>
 

#### <a name="directx-tool-kit-and-libraries"></a><span data-ttu-id="52ac8-640">DirectX ツール キットとライブラリ</span><span class="sxs-lookup"><span data-stu-id="52ac8-640">DirectX Tool Kit and libraries</span></span>

<span data-ttu-id="52ac8-641">DirectX ツール キット、DirectX テクスチャ処理ライブラリ、DirectXMesh ジオメトリ処理ライブラリ、UVAtlas ライブラリ、DirectXMath ライブラリは、DirectX 開発用のテクスチャ、メッシュ、スプライト、その他のユーティリティ機能とヘルパー クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-641">The DirectX Tool Kit, DirectX texture processing library, DirectXMesh geometry processing library, UVAtlas library, and DirectXMath library provide texture, mesh, sprite, and other utility functionality and helper classes for DirectX development.</span></span> <span data-ttu-id="52ac8-642">これらのライブラリは、開発にかかる時間と労力を減らすのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-642">These libraries can help you save development time and effort.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-643">DirectX 11 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-643">Get DirectX Tool Kit for DirectX 11</span></span></td>
        <td><span data-ttu-id="52ac8-644"><a href="https://go.microsoft.com/fwlink/?LinkId=248929">DirectXTK</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-644"><a href="https://go.microsoft.com/fwlink/?LinkId=248929">DirectXTK</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-645">DirectX 12 用 DirectX ツール キットを入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-645">Get DirectX Tool Kit for DirectX 12</span></span></td>
        <td><span data-ttu-id="52ac8-646"><a href="https://go.microsoft.com/fwlink/?LinkID=615561">DirectXTK 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-646"><a href="https://go.microsoft.com/fwlink/?LinkID=615561">DirectXTK 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-647">DirectX テクスチャ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-647">Get DirectX texture processing library</span></span></td>
        <td><span data-ttu-id="52ac8-648"><a href="https://go.microsoft.com/fwlink/?LinkId=248926">DirectXTex</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-648"><a href="https://go.microsoft.com/fwlink/?LinkId=248926">DirectXTex</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-649">DirectXMesh ジオメトリ処理ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-649">Get DirectXMesh geometry processing library</span></span></td>
        <td><span data-ttu-id="52ac8-650"><a href="https://go.microsoft.com/fwlink/?LinkID=324981">DirectXMesh</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-650"><a href="https://go.microsoft.com/fwlink/?LinkID=324981">DirectXMesh</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-651">isochart テクスチャ アトラスを作成してパッケージ化するための UVAtlas を入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-651">Get UVAtlas for creating and packing isochart texture atlas</span></span></td>
        <td><span data-ttu-id="52ac8-652"><a href="https://go.microsoft.com/fwlink/?LinkID=512686">UVAtlas</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-652"><a href="https://go.microsoft.com/fwlink/?LinkID=512686">UVAtlas</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-653">DirectXMath のライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-653">Get the DirectXMath library</span></span></td>
        <td><span data-ttu-id="52ac8-654"><a href="https://go.microsoft.com/fwlink/?LinkID=615560">DirectXMath</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-654"><a href="https://go.microsoft.com/fwlink/?LinkID=615560">DirectXMath</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-655">Direct3d12 サポート DirectXTK (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-655">Direct3D 12 support in the DirectXTK (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-656"><a href="https://github.com/Microsoft/DirectXTK/issues/2">DirectX 12 のサポート</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-656"><a href="https://github.com/Microsoft/DirectXTK/issues/2">Support for DirectX 12</a></span></span></td>
    </tr>
</table>

#### <a name="directx-resources-from-partners"></a><span data-ttu-id="52ac8-657">パートナーからの DirectX リソース</span><span class="sxs-lookup"><span data-stu-id="52ac8-657">DirectX resources from partners</span></span>

<span data-ttu-id="52ac8-658">これらは、外部のパートナーによって作成された補足の DirectX ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-658">These are some additional DirectX documentation created by external partners.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-659">Nvidia:DX12」とすべきでないこと (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-659">Nvidia: DX12 Do's and Don'ts (blog post)</span></span> </td>
        <td><span data-ttu-id="52ac8-660"><a href="https://developer.nvidia.com/dx12-dos-and-donts-updated">Nvidia の Gpu での DirectX 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-660"><a href="https://developer.nvidia.com/dx12-dos-and-donts-updated">DirectX 12 on Nvidia GPUs</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-661">Intel:DirectX 12 を使用した効率的なレンダリング</span><span class="sxs-lookup"><span data-stu-id="52ac8-661">Intel: Efficient rendering with DirectX 12</span></span></td>
        <td><span data-ttu-id="52ac8-662"><a href="https://software.intel.com/sites/default/files/managed/4a/38/Efficient-Rendering-with-DirectX-12-on-Intel-Graphics.pdf">Intel グラフィックスのレンダリングに DirectX 12</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-662"><a href="https://software.intel.com/sites/default/files/managed/4a/38/Efficient-Rendering-with-DirectX-12-on-Intel-Graphics.pdf">DirectX 12 rendering on Intel Graphics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-663">Intel:DirectX 12 で複数のアダプターのサポート</span><span class="sxs-lookup"><span data-stu-id="52ac8-663">Intel: Multi adapter support in DirectX 12</span></span></td>
        <td><span data-ttu-id="52ac8-664"><a href="https://software.intel.com/articles/multi-adapter-support-in-directx-12">DirectX 12 を使用して明示的なマルチ アダプター アプリケーションを実装する方法</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-664"><a href="https://software.intel.com/articles/multi-adapter-support-in-directx-12">How to implement an explicit multi-adapter application using DirectX 12</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-665">Intel:DirectX 12 のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="52ac8-665">Intel: DirectX 12 tutorial</span></span></td>
        <td><span data-ttu-id="52ac8-666"><a href="https://software.intel.com/articles/tutorial-migrating-your-apps-to-directx-12-part-1">Intel、Suzhou あふれると Microsoft によって共同作業のホワイト ペーパー</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-666"><a href="https://software.intel.com/articles/tutorial-migrating-your-apps-to-directx-12-part-1">Collaborative white paper by Intel, Suzhou Snail and Microsoft</a></span></span></td>
    </tr>
</table>


## <a name="production"></a><span data-ttu-id="52ac8-667">実稼働</span><span class="sxs-lookup"><span data-stu-id="52ac8-667">Production</span></span>


<span data-ttu-id="52ac8-668">制作スタジオの準備が整ったら、チーム全体に作業を分散して制作サイクルに移行します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-668">Your studio is now fully engaged and moving into the production cycle, with work distributed throughout your team.</span></span> <span data-ttu-id="52ac8-669">プロトタイプの調整、リファクタリング、拡張によって、ゲームの完成品に仕上げていきます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-669">You're polishing, refactoring, and extending the prototype to craft it into a full game.</span></span>

### <a name="notifications-and-live-tiles"></a><span data-ttu-id="52ac8-670">通知とライブ タイル</span><span class="sxs-lookup"><span data-stu-id="52ac8-670">Notifications and live tiles</span></span>

<span data-ttu-id="52ac8-671">タイルとは、[スタート] メニュー上でゲームを表すものです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-671">A tile is your game's representation on the Start Menu.</span></span> <span data-ttu-id="52ac8-672">タイルや通知によって、ゲームをプレイしていない場合でも、プレイヤーに興味を持たせることができます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-672">Tiles and notifications can drive player interest even when they aren't currently playing your game.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-673">タイルとバッジの開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-673">Developing tiles and badges</span></span></td>
        <td><span data-ttu-id="52ac8-674"><a href="https://msdn.microsoft.com/library/windows/apps/mt185606">タイル、バッジ、通知</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-674"><a href="https://msdn.microsoft.com/library/windows/apps/mt185606">Tiles, badges, and notifications</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-675">ライブ タイルと通知を示すサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-675">Sample illustrating live tiles and notifications</span></span></td>
        <td><span data-ttu-id="52ac8-676"><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications">通知のサンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-676"><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Notifications">Notifications sample</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-677">アダプティブ タイル テンプレート (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-677">Adaptive tile templates (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-678"><a href="https://blogs.msdn.com/b/tiles_and_toasts/archive/2015/06/30/adaptive-tile-templates-schema-and-documentation.aspx">適応型タイル テンプレートのスキーマとドキュメント</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-678"><a href="https://blogs.msdn.com/b/tiles_and_toasts/archive/2015/06/30/adaptive-tile-templates-schema-and-documentation.aspx">Adaptive Tile Templates - Schema and Documentation</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-679">タイルとバッジの設計</span><span class="sxs-lookup"><span data-stu-id="52ac8-679">Designing tiles and badges</span></span></td>
        <td><span data-ttu-id="52ac8-680"><a href="https://msdn.microsoft.com/library/windows/apps/hh465403">タイルとバッジのガイドライン</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-680"><a href="https://msdn.microsoft.com/library/windows/apps/hh465403">Guidelines for tiles and badges</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-681">ライブ タイル テンプレートを対話形式で開発するための Windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="52ac8-681">Windows 10 app for interactively developing live tile templates</span></span></td>
        <td><span data-ttu-id="52ac8-682"><a href="https://www.microsoft.com/store/apps/9nblggh5xsl1">Notifications Visualizer</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-682"><a href="https://www.microsoft.com/store/apps/9nblggh5xsl1">Notifications Visualizer</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-683">Visual Studio 用の UWP Tile Generator 拡張機能</span><span class="sxs-lookup"><span data-stu-id="52ac8-683">UWP Tile Generator extension for Visual Studio</span></span></td>
        <td><span data-ttu-id="52ac8-684"><a href="https://visualstudiogallery.msdn.microsoft.com/09611e90-f3e8-44b7-9c83-18dba8275bb2">1 つのイメージを使用して必要なすべてのタイルを作成するためのツール</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-684"><a href="https://visualstudiogallery.msdn.microsoft.com/09611e90-f3e8-44b7-9c83-18dba8275bb2">Tool for creating all required tiles using single image</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-685">Visual Studio 用の UWP Tile Generator 拡張機能 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-685">UWP Tile Generator extension for Visual Studio (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-686"><a href="https://blogs.windows.com/buildingapps/2016/02/15/uwp-tile-generator-extension-for-visual-studio/">UWP タイル ジェネレーター ツールの使用に関するヒント</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-686"><a href="https://blogs.windows.com/buildingapps/2016/02/15/uwp-tile-generator-extension-for-visual-studio/">Tips on using the UWP Tile Generator tool</a></span></span></td>
    </tr>
</table>
 

### <a name="enable-in-app-product-add-on-purchases"></a><span data-ttu-id="52ac8-687">アプリ内製品 (アドオン) の購入を有効にします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-687">Enable in-app product (add-on) purchases</span></span>

<span data-ttu-id="52ac8-688">アドオン (アプリ内製品) は、プレイヤーがゲームを購入できる補助項目です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-688">An add-on (in-app product) is a supplementary item that players can purchase in-game.</span></span> <span data-ttu-id="52ac8-689">アドオンには、ゲーム レベル、アイテム、またはプレーヤーがお勧めするその他すべてを指定できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-689">Add-ons can be game levels, items, or anything else that your players might enjoy.</span></span> <span data-ttu-id="52ac8-690">適切に使用すると、アドオンは、ゲーム エクスペリエンスを向上させながら収益を提供できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-690">Used appropriately, add-ons can provide revenue while improving the game experience.</span></span> <span data-ttu-id="52ac8-691">パートナー センターでのゲームのアドオンの発行を定義し、ゲームのコードでのアプリ内購入を有効にします。</span><span class="sxs-lookup"><span data-stu-id="52ac8-691">You define and publish your game's add-ons through Partner Center, and enable in-app purchases in your game's code.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-692">持続性のあるアドオン</span><span class="sxs-lookup"><span data-stu-id="52ac8-692">Durable add-ons</span></span></td>
        <td><span data-ttu-id="52ac8-693"><a href="https://msdn.microsoft.com/library/windows/apps/mt219684">アプリ内製品購入を有効にする</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-693"><a href="https://msdn.microsoft.com/library/windows/apps/mt219684">Enable in-app product purchases</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-694">使用できるアドオン</span><span class="sxs-lookup"><span data-stu-id="52ac8-694">Consumable add-ons</span></span></td>
        <td><span data-ttu-id="52ac8-695"><a href="https://msdn.microsoft.com/library/windows/apps/mt219683">コンシューマブルなアプリ内製品購入を有効にする</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-695"><a href="https://msdn.microsoft.com/library/windows/apps/mt219683">Enable consumable in-app product purchases</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-696">アドオンの詳細と送信</span><span class="sxs-lookup"><span data-stu-id="52ac8-696">Add-on details and submission</span></span></td>
        <td><span data-ttu-id="52ac8-697"><a href="https://msdn.microsoft.com/library/windows/apps/mt148551">アドオンの申請</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-697"><a href="https://msdn.microsoft.com/library/windows/apps/mt148551">Add-on submissions</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-698">アドオンの売上と人口統計、ゲームを監視します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-698">Monitor add-on sales and demographics for your game</span></span></td>
        <td><span data-ttu-id="52ac8-699"><a href="https://msdn.microsoft.com/library/windows/apps/mt148538">アドオン取得レポート</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-699"><a href="https://msdn.microsoft.com/library/windows/apps/mt148538">Add-on acquisitions report</a></span></span></td>
    </tr>
</table>
 

### <a name="debugging-performance-optimization-and-monitoring"></a><span data-ttu-id="52ac8-700">デバッグとパフォーマンスの最適化と監視</span><span class="sxs-lookup"><span data-stu-id="52ac8-700">Debugging, performance optimization, and monitoring</span></span>

<span data-ttu-id="52ac8-701">パフォーマンスを最適化するには、Windows 10 のゲーム モードを活用し、ハードウェアの機能を最大限に活用して、ゲーマーに可能な限りのゲーム エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-701">To optimize performance, take advantage of Game Mode in Windows 10 to provide your gamers with the best possible gaming experience by fully utilizing the capacity of their current hardware.</span></span>

<span data-ttu-id="52ac8-702">Windows Performance Toolkit (WPT) は、Windows オペレーティング システムやアプリケーションの詳しいパフォーマンス プロファイルを生成するための一連のパフォーマンス監視ツールです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-702">The Windows Performance Toolkit (WPT) consists of performance monitoring tools that produce in-depth performance profiles of Windows operating systems and applications.</span></span> <span data-ttu-id="52ac8-703">これは、メモリ使用量を監視し、ゲームのパフォーマンスを向上させるために特に便利です。</span><span class="sxs-lookup"><span data-stu-id="52ac8-703">This is especially useful for monitoring memory usage and improving game performance.</span></span> <span data-ttu-id="52ac8-704">Windows Performance Toolkit は、Windows 10 SDK と Windows ADK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-704">The Windows Performance Toolkit is included in the Windows 10 SDK and Windows ADK.</span></span> <span data-ttu-id="52ac8-705">このツールキットは、2 つの独立したツールで構成されます。Windows Performance Recorder (WPR) と Windows パフォーマンス アナライザー (WPA)。</span><span class="sxs-lookup"><span data-stu-id="52ac8-705">This toolkit consists of two independent tools: Windows Performance Recorder (WPR) and Windows Performance Analyzer (WPA).</span></span> <span data-ttu-id="52ac8-706">[Windows Sysinternals](https://technet.microsoft.com/sysinternals/default) に含まれる ProcDump は、コマンドライン ユーティリティであり、CPU 使用量の急上昇を監視し、ゲームのクラッシュ時にダンプ ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-706">ProcDump, which is part of [Windows Sysinternals](https://technet.microsoft.com/sysinternals/default), is a command-line utility that monitors CPU spikes and generates dump files during game crashes.</span></span> 

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-707">コードのパフォーマンス テストを行う</span><span class="sxs-lookup"><span data-stu-id="52ac8-707">Performance test your code</span></span></td>
        <td><span data-ttu-id="52ac8-708"><a href="https://www.visualstudio.com/team-services/cloud-load-testing/">クラウド ベースのロード テスト</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-708"><a href="https://www.visualstudio.com/team-services/cloud-load-testing/">Cloud based load testing</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-709">ゲーム デバイス情報を使用して Xbox 本体のタイプを取得する</span><span class="sxs-lookup"><span data-stu-id="52ac8-709">Get Xbox console type using Gaming Device Information</span></span></td>
        <td><span data-ttu-id="52ac8-710"><a href="https://msdn.microsoft.com/library/windows/desktop/mt825235">ゲームのデバイス情報</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-710"><a href="https://msdn.microsoft.com/library/windows/desktop/mt825235">Gaming Device Information</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-711">ゲーム モードの API の使用によるハードウェア リソースへの排他的または優先的なアクセスを使ったパフォーマンスの向上</span><span class="sxs-lookup"><span data-stu-id="52ac8-711">Improve performance by getting exclusive or priority access to hardware resources using Game Mode APIs</span></span></td>
        <td><span data-ttu-id="52ac8-712"><a href="https://msdn.microsoft.com/library/windows/desktop/mt808808">ゲーム モード</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-712"><a href="https://msdn.microsoft.com/library/windows/desktop/mt808808">Game Mode</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-713">Windows 10 SDK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-713">Get Windows Performance Toolkit (WPT) from Windows 10 SDK</span></span></td>
        <td><span data-ttu-id="52ac8-714"><a href="https://developer.microsoft.com/windows/downloads/windows-10-sdk">Windows 10 SDK</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-714"><a href="https://developer.microsoft.com/windows/downloads/windows-10-sdk">Windows 10 SDK</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-715">Windows ADK から Windows Performance Toolkit (WPT) を入手する</span><span class="sxs-lookup"><span data-stu-id="52ac8-715">Get Windows Performance Toolkit (WPT) from Windows ADK</span></span></td>
        <td><span data-ttu-id="52ac8-716"><a href="https://msdn.microsoft.com/windows/hardware/dn913721.aspx">Windows ADK</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-716"><a href="https://msdn.microsoft.com/windows/hardware/dn913721.aspx">Windows ADK</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-717">Windows Performance Analyzer を使って応答しない UI のトラブルシューティングを行う (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-717">Troubleshoot unresponsible UI using Windows Performance Analyzer (video)</span></span></td>
        <td><span data-ttu-id="52ac8-718"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-156-Critical-Path-Analysis-with-Windows-Performance-Analyzer">WPA では、クリティカル パス分析</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-718"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-156-Critical-Path-Analysis-with-Windows-Performance-Analyzer">Critical path analysis with WPA</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-719">Windows Performance Recorder を使ってメモリ使用量とメモリ リークを診断する (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-719">Diagnose memory usage and leaks using Windows Performance Recorder (video)</span></span></td>
        <td><span data-ttu-id="52ac8-720"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-154-Memory-Footprint-and-Leaks">メモリ使用量やリーク</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-720"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-154-Memory-Footprint-and-Leaks">Memory footprint and leaks</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-721">ProcDump を取得する</span><span class="sxs-lookup"><span data-stu-id="52ac8-721">Get ProcDump</span></span></td>
        <td><span data-ttu-id="52ac8-722"><a href="https://technet.microsoft.com/sysinternals/dd996900">ProcDump</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-722"><a href="https://technet.microsoft.com/sysinternals/dd996900">ProcDump</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-723">ProcDump の使い方 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-723">Learn to use ProcDump (video)</span></span></td>
        <td><span data-ttu-id="52ac8-724"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-131-Windows-10-SDK">ダンプ ファイルを作成する ProcDump を構成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-724"><a href="https://channel9.msdn.com/Shows/Defrag-Tools/Defrag-Tools-131-Windows-10-SDK">Configure ProcDump to create dump files</a></span></span></td>
    </tr>
</table>

### <a name="advanced-directx-techniques-and-concepts"></a><span data-ttu-id="52ac8-725">高度な DirectX の手法と概念</span><span class="sxs-lookup"><span data-stu-id="52ac8-725">Advanced DirectX techniques and concepts</span></span>

<span data-ttu-id="52ac8-726">DirectX の開発には微妙で複雑な部分があります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-726">Some portions of DirectX development can be nuanced and complex.</span></span> <span data-ttu-id="52ac8-727">運用環境で、DirectX エンジンの詳細を掘り下げる必要がある場合や、難しいパフォーマンスの問題をデバッグする場合は、このセクションで紹介するリソースや情報が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-727">When you get to the point in production where you need to dig down into the details of your DirectX engine, or debug difficult performance problems, the resources and information in this section can help.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-728">Windows の PIX</span><span class="sxs-lookup"><span data-stu-id="52ac8-728">PIX on Windows</span></span></td>
        <td><span data-ttu-id="52ac8-729"><a href="https://blogs.msdn.microsoft.com/pix/2017/01/17/introducing-pix-on-windows-beta/">パフォーマンスのチューニングと、Windows での DirectX 12 のデバッグ ツール</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-729"><a href="https://blogs.msdn.microsoft.com/pix/2017/01/17/introducing-pix-on-windows-beta/">Performance tuning and debugging tool for DirectX 12 on Windows</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-730">D3D12 開発のデバッグと検証のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-730">Debugging and validation tools for D3D12 development (video)</span></span></td>
        <td><span data-ttu-id="52ac8-731"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-003">D3D12 のパフォーマンス チューニングと PIX と GPU の検証を使用したデバッグ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-731"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-003">D3D12 Performance Tuning and Debugging with PIX and GPU Validation</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-732">グラフィックスとパフォーマンスの最適化 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-732">Optimizing graphics and performance (video)</span></span></td>
        <td><span data-ttu-id="52ac8-733"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Advanced-DirectX12-Graphics-and-Performance">高度な DirectX 12 のグラフィックスとパフォーマンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-733"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Advanced-DirectX12-Graphics-and-Performance">Advanced DirectX 12 Graphics and Performance</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-734">DirectX グラフィックスのデバッグ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-734">DirectX graphics debugging (video)</span></span></td>
        <td><span data-ttu-id="52ac8-735"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Solve-the-Tough-Graphics-Problems-with-your-Game-Using-DirectX-Tools">DirectX ツールを使用して、ゲームに大変なグラフィックスの問題を解決します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-735"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Solve-the-Tough-Graphics-Problems-with-your-Game-Using-DirectX-Tools">Solve the tough graphics problems with your game using DirectX Tools</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-736">DirectX 12 をデバッグするための Visual Studio 2015 のツール (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-736">Visual Studio 2015 tools for debugging DirectX 12 (video)</span></span></td>
        <td><span data-ttu-id="52ac8-737"><a href="https://channel9.msdn.com/Series/ConnectOn-Demand/212">Visual Studio 2015 での Windows 10 用の DirectX ツール</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-737"><a href="https://channel9.msdn.com/Series/ConnectOn-Demand/212">DirectX tools for Windows 10 in Visual Studio 2015</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-738">Direct3D 12 プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="52ac8-738">Direct3D 12 programming guide</span></span></td>
        <td><span data-ttu-id="52ac8-739"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 のプログラミング ガイド</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-739"><a href="https://msdn.microsoft.com/library/windows/desktop/dn903821">Direct3D 12 Programming Guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-740">DirectX と XAML の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="52ac8-740">Combining DirectX and XAML</span></span></td>
        <td><span data-ttu-id="52ac8-741"><a href="directx-and-xaml-interop.md">DirectX および XAML の相互運用機能</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-741"><a href="directx-and-xaml-interop.md">DirectX and XAML interop</a></span></span></td>
    </tr>
</table>

### <a name="high-dynamic-range-hdr-content-development"></a><span data-ttu-id="52ac8-742">ハイ ダイナミック レンジ (HDR) コンテンツの開発</span><span class="sxs-lookup"><span data-stu-id="52ac8-742">High dynamic range (HDR) content development</span></span>

<span data-ttu-id="52ac8-743">HDR のフル カラー機能を使用するゲーム コンテンツを構築します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-743">Build game content that uses the full color capabilities of HDR.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-744">HDR の概要と色の概念 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-744">Introduction to HDR and color concepts (video)</span></span></td>
        <td><span data-ttu-id="52ac8-745"><a href="https://channel9.msdn.com/Events/Build/2017/P4061">HDR および DirectX での高度なカラーを照明</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-745"><a href="https://channel9.msdn.com/Events/Build/2017/P4061">Lighting up HDR and advanced color in DirectX</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-746">HDR コンテンツをレンダリングする方法と、現在のディスプレイが HDR コンテンツをサポートするかどうかを検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-746">Learn how to render HDR content and detect whether the current display supports it</span></span></td>
        <td><span data-ttu-id="52ac8-747"><a href="https://github.com/Microsoft/DirectX-Graphics-Samples/tree/master/Samples/UWP/D3D12HDR">HDR サンプル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-747"><a href="https://github.com/Microsoft/DirectX-Graphics-Samples/tree/master/Samples/UWP/D3D12HDR">HDR sample</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-748">DirectX を使用して高度な色を作成および構成する</span><span class="sxs-lookup"><span data-stu-id="52ac8-748">Create and configure an advanced color using DirectX</span></span></td>
        <td><span data-ttu-id="52ac8-749"><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/D2DAdvancedColorImages">Direct2D 高度なカラー イメージのレンダリングの例</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-749"><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/D2DAdvancedColorImages">Direct2D advanced color image rendering sample</a></span></span></td>
    </tr>   
</table>


### <a name="globalization-and-localization"></a><span data-ttu-id="52ac8-750">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="52ac8-750">Globalization and localization</span></span>

<span data-ttu-id="52ac8-751">Windows プラットフォーム用の多言語対応ゲームを開発し、Microsoft の有力製品に組み込まれている地域と言語の機能について説明します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-751">Develop world-ready games for the Windows platform and learn about the international features built into Microsoft’s top products.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-752">世界市場向けのゲームの準備</span><span class="sxs-lookup"><span data-stu-id="52ac8-752">Preparing your game for the global market</span></span></td>
        <td><span data-ttu-id="52ac8-753"><a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt186453.aspx">グローバル ユーザー向けに開発する場合のガイドライン</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-753"><a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt186453.aspx">Guidelines when developing for a global audience</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-754">言語、文化、およびテクノロジの橋渡し</span><span class="sxs-lookup"><span data-stu-id="52ac8-754">Bridging languages, cultures, and technology</span></span></td>
        <td><span data-ttu-id="52ac8-755"><a href="https://www.microsoft.com/Language/Default.aspx">言語の規則および Microsoft の一般的な用語のオンライン リソース</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-755"><a href="https://www.microsoft.com/Language/Default.aspx">Online resource for language conventions and standard Microsoft terminology</a></span></span></td>
    </tr>
</table>

## <a name="submitting-and-publishing-your-game"></a><span data-ttu-id="52ac8-756">ゲームの申請と公開</span><span class="sxs-lookup"><span data-stu-id="52ac8-756">Submitting and publishing your game</span></span>

<span data-ttu-id="52ac8-757">次のガイドと情報は、公開と申請のプロセスをできるだけスムーズに進めるために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-757">The following guides and information help make the publishing and submission process as smooth as possible.</span></span>

### <a name="publishing"></a><span data-ttu-id="52ac8-758">公開</span><span class="sxs-lookup"><span data-stu-id="52ac8-758">Publishing</span></span>

<span data-ttu-id="52ac8-759">使用して[パートナー センター](https://partner.microsoft.com/dashboard)発行して、ゲームのパッケージを管理します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-759">You'll use [Partner Center](https://partner.microsoft.com/dashboard) to publish and manage your game packages.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-760">パートナー センターのアプリの発行</span><span class="sxs-lookup"><span data-stu-id="52ac8-760">Partner Center app publishing</span></span></td>
        <td><span data-ttu-id="52ac8-761"><a href="https://dev.windows.com/publish">Windows アプリを発行します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-761"><a href="https://dev.windows.com/publish">Publish Windows apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-762">パートナー センターの詳細 (GDN) の発行</span><span class="sxs-lookup"><span data-stu-id="52ac8-762">Partner Center advanced publishing (GDN)</span></span></td>
        <td><span data-ttu-id="52ac8-763"><a href="https://developer.xboxlive.com/en-us/windows/documentation/Pages/home.aspx">パートナー センターの公開に関するガイドの詳細</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-763"><a href="https://developer.xboxlive.com/en-us/windows/documentation/Pages/home.aspx">Partner Center advanced publishing guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-764">Azure Active Directory (AAD) を使用して、パートナー センター アカウントにユーザーを追加するには</span><span class="sxs-lookup"><span data-stu-id="52ac8-764">Use Azure Active Directory (AAD) to add users to your Partner Center account</span></span></td>
        <td><span data-ttu-id="52ac8-765"><a href="https://docs.microsoft.com/windows/uwp/publish/manage-account-users">アカウントのユーザーを管理します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-765"><a href="https://docs.microsoft.com/windows/uwp/publish/manage-account-users">Manage account users</a></span></span></td>
    </tr>   
    <tr>
        <td><span data-ttu-id="52ac8-766">ゲームの評価 (ブログの投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-766">Rating your game (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-767"><a href="https://blogs.windows.com/buildingapps/2016/01/06/now-available-single-age-rating-system-to-simplify-app-submissions/">1 つのワークフローを IARC システムを使用して、年齢区分を割り当てる</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-767"><a href="https://blogs.windows.com/buildingapps/2016/01/06/now-available-single-age-rating-system-to-simplify-app-submissions/">Single workflow to assign age ratings using IARC system</a></span></span></td>
    </tr>
</table>

#### <a name="packaging-and-uploading"></a><span data-ttu-id="52ac8-768">パッケージ化とアップロード</span><span class="sxs-lookup"><span data-stu-id="52ac8-768">Packaging and uploading</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-769">ストリーミング インストールとオプション パッケージを使用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-769">Learn to use streaming install and optional packages (video)</span></span></td>
        <td><span data-ttu-id="52ac8-770"><a href="https://channel9.msdn.com/Events/Build/2017/B8093">Nextgen UWP アプリの配布:拡張可能なストリームできる、コンポーネント化されたアプリの構築</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-770"><a href="https://channel9.msdn.com/Events/Build/2017/B8093">Nextgen UWP app distribution: Building extensible, stream-able, componentized apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-771">コンテンツの分割とグループ化によるストリーミング インストールの実現</span><span class="sxs-lookup"><span data-stu-id="52ac8-771">Divide and group content to enable streaming install</span></span></td>
        <td><span data-ttu-id="52ac8-772"><a href="../packaging/streaming-install.md">UWP アプリのストリーミング インストール</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-772"><a href="../packaging/streaming-install.md">UWP App Streaming install</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-773">DLC ゲーム コンテンツのようなオプション パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="52ac8-773">Create optional packages like DLC game content</span></span></td>
        <td><span data-ttu-id="52ac8-774"><a href="../packaging/optional-packages.md">オプション パッケージと関連セットの作成</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-774"><a href="../packaging/optional-packages.md">Optional packages and related set authoring</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-775">UWP ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="52ac8-775">Package your UWP game</span></span></td>
        <td><span data-ttu-id="52ac8-776"><a href="../packaging/index.md">アプリのパッケージ化</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-776"><a href="../packaging/index.md">Packaging apps</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-777">UWP DirectX ゲームのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="52ac8-777">Package your UWP DirectX game</span></span></td>
        <td><span data-ttu-id="52ac8-778"><a href="package-your-windows-store-directx-game.md">UWP の DirectX ゲームをパッケージ化します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-778"><a href="package-your-windows-store-directx-game.md">Package your UWP DirectX game</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-779">サード パーティ開発者としてのゲームのパッケージ化 (ブログ投稿)</span><span class="sxs-lookup"><span data-stu-id="52ac8-779">Packaging your game as a 3rd party developer (blog post)</span></span></td>
        <td><span data-ttu-id="52ac8-780"><a href="https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/">発行元のストア アカウントのアクセス権を持たない uploadable パッケージを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-780"><a href="https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/">Create uploadable packages without publisher's store account access</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-781">MakeAppx を使用したアプリ パッケージとアプリ パッケージ バンドルの作成</span><span class="sxs-lookup"><span data-stu-id="52ac8-781">Creating app packages and app package bundles using MakeAppx</span></span></td>
        <td><span data-ttu-id="52ac8-782"><a href="https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool">App packager ツール MakeAppx.exe を使用してパッケージを作成します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-782"><a href="https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool">Create packages using app packager tool MakeAppx.exe</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-783">SignTool を使用したファイルへのデジタル署名</span><span class="sxs-lookup"><span data-stu-id="52ac8-783">Signing your files digitally using SignTool</span></span></td>
        <td><span data-ttu-id="52ac8-784"><a href="https://msdn.microsoft.com/library/windows/desktop/aa387764">ファイルに署名し、SignTool を使用してファイルの署名を確認します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-784"><a href="https://msdn.microsoft.com/library/windows/desktop/aa387764">Sign files and verify signatures in files using SignTool</a></span></span></td>
    </tr>    
    <tr>
        <td><span data-ttu-id="52ac8-785">ゲームのアップロードとバージョン管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-785">Uploading and versioning your game</span></span></td>
        <td><span data-ttu-id="52ac8-786"><a href="https://msdn.microsoft.com/library/windows/apps/mt148542">アプリ パッケージをアップロードします。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-786"><a href="https://msdn.microsoft.com/library/windows/apps/mt148542">Upload app packages</a></span></span></td>
    </tr>
</table>


### <a name="policies-and-certification"></a><span data-ttu-id="52ac8-787">ポリシーと認定</span><span class="sxs-lookup"><span data-stu-id="52ac8-787">Policies and certification</span></span>

<span data-ttu-id="52ac8-788">認定に関する問題によってゲームのリリースを延期しないでください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-788">Don't let certification issues delay your game's release.</span></span> <span data-ttu-id="52ac8-789">ここでは、ポリシーと注意が必要な一般的な認定の問題を示します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-789">Here are policies and common certification issues to be aware of.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-790">Microsoft Store アプリ開発者契約</span><span class="sxs-lookup"><span data-stu-id="52ac8-790">Microsoft Store App Developer Agreement</span></span></td>
        <td><span data-ttu-id="52ac8-791"><a href="https://msdn.microsoft.com/library/windows/apps/hh694058">アプリ開発者契約</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-791"><a href="https://msdn.microsoft.com/library/windows/apps/hh694058">App Developer Agreement</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-792">Microsoft Store でアプリを公開するためのポリシー</span><span class="sxs-lookup"><span data-stu-id="52ac8-792">Policies for publishing apps in the Microsoft Store</span></span></td>
        <td><span data-ttu-id="52ac8-793"><a href="https://msdn.microsoft.com/library/windows/apps/dn764944">Microsoft Store ポリシー</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-793"><a href="https://msdn.microsoft.com/library/windows/apps/dn764944">Microsoft Store Policies</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-794">一般的なアプリの認定の問題を回避する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-794">How to avoid some common app certification issues</span></span></td>
        <td><span data-ttu-id="52ac8-795"><a href="https://msdn.microsoft.com/library/windows/apps/jj657968">一般的な認定エラーを回避します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-795"><a href="https://msdn.microsoft.com/library/windows/apps/jj657968">Avoid common certification failures</a></span></span></td>
    </tr>
</table>
 

### <a name="store-manifest-storemanifestxml"></a><span data-ttu-id="52ac8-796">ストア マニフェスト (StoreManifest.xml)</span><span class="sxs-lookup"><span data-stu-id="52ac8-796">Store manifest (StoreManifest.xml)</span></span>

<span data-ttu-id="52ac8-797">ストア マニフェスト (StoreManifest.xml) は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-797">The store manifest (StoreManifest.xml) is an optional configuration file that can be included in your app package.</span></span> <span data-ttu-id="52ac8-798">ストア マニフェストには、AppxManifest.xml ファイルに含まれていないその他の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="52ac8-798">The store manifest provides additional features that are not part of the AppxManifest.xml file.</span></span> <span data-ttu-id="52ac8-799">たとえば、ターゲット デバイスが指定された DirectX の最小機能レベルまたは指定された最小システム メモリの条件を満たしていない場合に、ストア マニフェストを使ってゲームのインストールをブロックできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-799">For example, you can use the store manifest to block installation of your game if a target device doesn't have the specified minimum DirectX feature level, or the specified minimum system memory.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-800">ストア マニフェストのスキーマ</span><span class="sxs-lookup"><span data-stu-id="52ac8-800">Store manifest schema</span></span></td>
        <td><span data-ttu-id="52ac8-801"><a href="https://msdn.microsoft.com/library/windows/apps/mt617335">StoreManifest スキーマ (Windows 10)</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-801"><a href="https://msdn.microsoft.com/library/windows/apps/mt617335">StoreManifest schema (Windows 10)</a></span></span></td>
    </tr>
</table>
 

## <a name="game-lifecycle-management"></a><span data-ttu-id="52ac8-802">ゲームのライフサイクル管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-802">Game lifecycle management</span></span>


<span data-ttu-id="52ac8-803">開発が終了し、ゲームを出荷しても、"ゲーム オーバー" というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="52ac8-803">After you've finished development and shipped your game, it's not "game over".</span></span> <span data-ttu-id="52ac8-804">バージョン 1 の開発は終了ですが、市場でのゲームの旅は始まったばかりです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-804">You may be done with development on version one, but your game's journey in the marketplace has only just begun.</span></span> <span data-ttu-id="52ac8-805">使用状況やエラー レポートの監視、ユーザーからのフィードバックへの対応、ゲームの更新プログラムの公開という作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="52ac8-805">You'll want to monitor usage and error reporting, respond to user feedback, and publish updates to your game.</span></span>

### <a name="partner-center-analytics-and-promotion"></a><span data-ttu-id="52ac8-806">パートナー センターの分析とプロモーション</span><span class="sxs-lookup"><span data-stu-id="52ac8-806">Partner Center analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-807">パートナー センターの分析</span><span class="sxs-lookup"><span data-stu-id="52ac8-807">Partner Center analytics</span></span></td>
        <td><span data-ttu-id="52ac8-808"><a href="https://msdn.microsoft.com/library/windows/apps/mt148522">アプリのパフォーマンスを分析します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-808"><a href="https://msdn.microsoft.com/library/windows/apps/mt148522">Analyze app performance</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-809">ゲーム内で Xbox の機能を使用してユーザーを引き付ける方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-809">Learn how your customers are engaging with the Xbox features in your game</span></span></td>
        <td><span data-ttu-id="52ac8-810"><a href="../publish/xbox-analytics-report.md">Xbox の分析レポート</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-810"><a href="../publish/xbox-analytics-report.md">Xbox analytics report</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-811">顧客のレビューへの返信</span><span class="sxs-lookup"><span data-stu-id="52ac8-811">Responding to customer reviews</span></span></td>
        <td><span data-ttu-id="52ac8-812"><a href="https://msdn.microsoft.com/library/windows/apps/mt148546">顧客のレビューに返信する</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-812"><a href="https://msdn.microsoft.com/library/windows/apps/mt148546">Respond to customer reviews</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-813">ゲームの販売を促進する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-813">Ways to promote your game</span></span></td>
        <td><span data-ttu-id="52ac8-814"><a href="https://dev.windows.com/store-promotion">アプリの販売促進</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-814"><a href="https://dev.windows.com/store-promotion">Promote your apps</a></span></span></td>
    </tr>
</table>
 

### <a name="visual-studio-application-insights"></a><span data-ttu-id="52ac8-815">Visual Studio Application Insights</span><span class="sxs-lookup"><span data-stu-id="52ac8-815">Visual Studio Application Insights</span></span>

<span data-ttu-id="52ac8-816">Visual Studio Application Insights は、公開されたゲームのパフォーマンス、利用統計情報、および使用状況の分析を提供します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-816">Visual Studio Application Insights provides performance, telemetry, and usage analytics for your published game.</span></span> <span data-ttu-id="52ac8-817">Application Insights は、リリース後のゲームの問題の検出と解決、使用状況の継続的な監視と向上、プレイヤーがゲームを操作する方法の把握に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-817">Application Insights helps you detect and solve issues after your game is released, continuously monitor and improve usage, and understand how players are continuing to interact with your game.</span></span> <span data-ttu-id="52ac8-818">Application Insights は、アプリに SDK を追加することで機能し、[Azure ポータル](https://portal.azure.com/)に利用統計情報を送信します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-818">Application Insights works by adding an SDK into your app, which sends telemetry to the [Azure portal](https://portal.azure.com/).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-819">アプリケーションのパフォーマンスと使用状況の分析</span><span class="sxs-lookup"><span data-stu-id="52ac8-819">Application performance and usage analytics</span></span></td>
        <td><span data-ttu-id="52ac8-820"><a href="https://azure.microsoft.com/documentation/articles/app-insights-get-started/">Visual Studio Application Insights</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-820"><a href="https://azure.microsoft.com/documentation/articles/app-insights-get-started/">Visual Studio Application Insights</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-821">Windows アプリでの Application Insights の有効化</span><span class="sxs-lookup"><span data-stu-id="52ac8-821">Enable Application Insights in Windows apps</span></span></td>
        <td><span data-ttu-id="52ac8-822"><a href="https://azure.microsoft.com/documentation/articles/app-insights-windows-get-started/">Windows Phone とストア アプリ用の application Insights</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-822"><a href="https://azure.microsoft.com/documentation/articles/app-insights-windows-get-started/">Application Insights for Windows Phone and Store apps</a></span></span></td>
    </tr>
</table>


### <a name="third-party-solutions-for-analytics-and-promotion"></a><span data-ttu-id="52ac8-823">分析とプロモーションのためのサード パーティ ソリューション</span><span class="sxs-lookup"><span data-stu-id="52ac8-823">Third party solutions for analytics and promotion</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-824">GameAnalytics を使用してプレイヤーの動作を理解する</span><span class="sxs-lookup"><span data-stu-id="52ac8-824">Understand player behavior using GameAnalytics</span></span></td>
        <td><span data-ttu-id="52ac8-825"><a href="https://www.gameanalytics.com/">GameAnalytics</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-825"><a href="https://www.gameanalytics.com/">GameAnalytics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-826">UWP ゲームを Google Analytics に接続する</span><span class="sxs-lookup"><span data-stu-id="52ac8-826">Connect your UWP game to Google Analytics</span></span></td>
        <td><span data-ttu-id="52ac8-827"><a href="https://github.com/dotnet/windows-sdk-for-google-analytics">Google アナリティクスの Windows SDK を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-827"><a href="https://github.com/dotnet/windows-sdk-for-google-analytics">Get Windows SDK for Google Analytics</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-828">Google Analytics で Windows SDK を利用する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-828">Learn how to use Windows SDK for Google Analytics (video)</span></span></td>
        <td><span data-ttu-id="52ac8-829"><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-the-Windows-SDK-for-Google-Analytics">Google Analytics 用 Windows SDK の概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-829"><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-the-Windows-SDK-for-Google-Analytics">Getting started with Windows SDK for Google Analytics</a></span></span></td>
    </tr>    
    <tr>
        <td><span data-ttu-id="52ac8-830">Facebook のアプリ インストール広告を使って Facebook ユーザー向けにゲームのプロモーションを行う</span><span class="sxs-lookup"><span data-stu-id="52ac8-830">Use Facebook App Installs Ads to promote your game to Facebook users</span></span></td>
        <td><span data-ttu-id="52ac8-831"><a href="https://github.com/Microsoft/winsdkfb">Facebook の Windows SDK を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-831"><a href="https://github.com/Microsoft/winsdkfb">Get Windows SDK for Facebook</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-832">Facebook のアプリ インストール広告の使用方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-832">Learn how to use Facebook App Installs Ads (video)</span></span></td>
        <td><span data-ttu-id="52ac8-833"><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-Facebook-App-Install-Ads">Facebook for Windows SDK の概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-833"><a href="https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Creators-Update/Getting-started-with-Facebook-App-Install-Ads">Getting started with Windows SDK for Facebook</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-834">Vungle を使用してゲームにビデオ広告を追加する</span><span class="sxs-lookup"><span data-stu-id="52ac8-834">Use Vungle to add video ads into your games</span></span></td>
        <td><span data-ttu-id="52ac8-835"><a href="https://v.vungle.com/sdk">Vungle の Windows SDK を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-835"><a href="https://v.vungle.com/sdk">Get Windows SDK for Vungle</a></span></span></td>
    </tr>
</table>
 

### <a name="creating-and-managing-content-updates"></a><span data-ttu-id="52ac8-836">コンテンツの更新プログラムの作成と管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-836">Creating and managing content updates</span></span>

<span data-ttu-id="52ac8-837">公開されたゲームを更新するには、大きいバージョン番号を持つ新しいアプリ パッケージを申請します。</span><span class="sxs-lookup"><span data-stu-id="52ac8-837">To update your published game, submit a new app package with a higher version number.</span></span> <span data-ttu-id="52ac8-838">このパッケージの申請と認定が終了すると、自動的にユーザーに更新プログラムとして公開されます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-838">After the package makes its way through submission and certification, it will automatically be available to customers as an update.</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-839">ゲームの更新とバージョン管理</span><span class="sxs-lookup"><span data-stu-id="52ac8-839">Updating and versioning your game</span></span></td>
        <td><span data-ttu-id="52ac8-840"><a href="https://msdn.microsoft.com/library/windows/apps/mt188602">パッケージのバージョン番号</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-840"><a href="https://msdn.microsoft.com/library/windows/apps/mt188602">Package version numbering</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-841">ゲームのパッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="52ac8-841">Game package management guidance</span></span></td>
        <td><span data-ttu-id="52ac8-842"><a href="https://msdn.microsoft.com/library/windows/apps/mt188602">アプリ パッケージの管理のためのガイダンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-842"><a href="https://msdn.microsoft.com/library/windows/apps/mt188602">Guidance for app package management</a></span></span></td>
    </tr>
</table>


## <a name="adding-xbox-live-to-your-game"></a><span data-ttu-id="52ac8-843">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="52ac8-843">Adding Xbox Live to your game</span></span>

<span data-ttu-id="52ac8-844">Xbox Live は、世界中の何百万ものゲーマーを結びつける最高のゲーミング ネットワークです。</span><span class="sxs-lookup"><span data-stu-id="52ac8-844">Xbox Live is a premier gaming network that connects millions of gamers across the world.</span></span> <span data-ttu-id="52ac8-845">開発者は、Xbox Live プレゼンス、ランキング、クラウド保存、ゲーム ハブ、クラブ、パーティー チャット、ゲーム DVR など、ゲームの対象ユーザーを組織的に拡大できる Xbox Live の機能にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-845">Developers gain access to Xbox Live features that can organically grow their game’s audience, including Xbox Live presence, Leaderboards, Cloud Saves, Game Hubs, Clubs, Party Chat, Game DVR, and more.</span></span>

> [!Note]
> <span data-ttu-id="52ac8-846">Xbox Live 対応のタイトルを開発する場合、いくつかのオプションを利用できます。</span><span class="sxs-lookup"><span data-stu-id="52ac8-846">If you would like to develop Xbox Live enabled titles, there are several options are available to you.</span></span> <span data-ttu-id="52ac8-847">さまざまなプログラムについて詳しくは、「[開発者プログラムの概要](../xbox-live/developer-program-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52ac8-847">For info about the various programs, see [Developer program overview](../xbox-live/developer-program-overview.md).</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-848">Xbox Live の概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-848">Xbox Live overview</span></span></td>
        <td><span data-ttu-id="52ac8-849"><a href="../xbox-live/index.md">開発者ガイドの Xbox Live</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-849"><a href="../xbox-live/index.md">Xbox Live developer guide</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-850">プログラムによって利用できる機能を理解する</span><span class="sxs-lookup"><span data-stu-id="52ac8-850">Understand which features are available depending on program</span></span></td>
        <td><span data-ttu-id="52ac8-851"><a href="../xbox-live/developer-program-overview.md#feature-table">開発者向けプログラムの概要:機能テーブル</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-851"><a href="../xbox-live/developer-program-overview.md#feature-table">Developer program overview: Feature table</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-852">Xbox Live ゲーム開発に役立つリソースへのリンク</span><span class="sxs-lookup"><span data-stu-id="52ac8-852">Links to useful resources for developing Xbox Live games</span></span></td>
        <td><span data-ttu-id="52ac8-853"><a href="../xbox-live/xbox-live-resources.md">Xbox Live のリソース</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-853"><a href="../xbox-live/xbox-live-resources.md">Xbox Live resources</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-854">Xbox Live サービスから情報を取得する方法</span><span class="sxs-lookup"><span data-stu-id="52ac8-854">Learn how to get info from Xbox Live services</span></span></td>
        <td><span data-ttu-id="52ac8-855"><a href="../xbox-live/introduction-to-xbox-live-apis.md">Xbox Live Api の概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-855"><a href="../xbox-live/introduction-to-xbox-live-apis.md">Introduction to Xbox Live APIs</a></span></span></td>
    </tr>
</table>


### <a name="for-developers-in-the-xbox-live-creators-program"></a><span data-ttu-id="52ac8-856">Xbox Live クリエーターズ プログラム開発者向け</span><span class="sxs-lookup"><span data-stu-id="52ac8-856">For developers in the Xbox Live Creators Program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-857">概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-857">Overview</span></span></td>
        <td><span data-ttu-id="52ac8-858"><a href="../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md">Xbox Live クリエーターズ プログラムを概要します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-858"><a href="../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md">Get started with the Xbox Live Creators Program</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-859">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="52ac8-859">Add Xbox Live to your game</span></span></td>
        <td><span data-ttu-id="52ac8-860"><a href="../xbox-live/get-started-with-creators/creators-step-by-step-guide.md">Xbox Live クリエーターズ プログラムを統合するステップ バイ ステップ ガイドします。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-860"><a href="../xbox-live/get-started-with-creators/creators-step-by-step-guide.md">Step by step guide to integrate Xbox Live Creators Program</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-861">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="52ac8-861">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td><span data-ttu-id="52ac8-862"><a href="../xbox-live/get-started-with-creators/develop-creators-title-with-unity.md">Unity ゲーム エンジンで、Xbox Live クリエーターズ プログラムのタイトルを開発を開始します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-862"><a href="../xbox-live/get-started-with-creators/develop-creators-title-with-unity.md">Get started developing an Xbox Live Creators Program title with the Unity game engine</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-863">開発サンドボックスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="52ac8-863">Set up your development sandbox</span></span></td>
        <td><span data-ttu-id="52ac8-864"><a href="../xbox-live/get-started-with-creators/xbox-live-sandboxes-creators.md">Xbox Live のサンド ボックスの概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-864"><a href="../xbox-live/get-started-with-creators/xbox-live-sandboxes-creators.md">Xbox Live sandboxes introduction</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-865">テスト用のアカウントを設定する</span><span class="sxs-lookup"><span data-stu-id="52ac8-865">Set up accounts for testing</span></span></td>
        <td><span data-ttu-id="52ac8-866"><a href="../xbox-live/get-started-with-creators/authorize-xbox-live-accounts.md">テスト環境で Xbox Live アカウントを承認します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-866"><a href="../xbox-live/get-started-with-creators/authorize-xbox-live-accounts.md">Authorize Xbox Live accounts in your test environment</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-867">Xbox Live クリエーターズ プログラム向けサンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-867">Samples for Xbox Live Creators Program</span></span></td>
        <td><span data-ttu-id="52ac8-868"><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK">クリエーターズ プログラムの開発者向けサンプル コード</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-868"><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/CreatorsSDK">Code samples for Creators Program developers</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-869">クロスプラット フォームの Xbox Live エクスペリエンスを UWP ゲームに統合する方法 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-869">Learn how to integrate cross-platform Xbox Live experiences in UWP games (video)</span></span></td>
        <td><span data-ttu-id="52ac8-870"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-005">Xbox Live クリエーターズ プログラム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-870"><a href="https://channel9.msdn.com/Events/GDC/GDC-2017/GDC2017-005">Xbox Live Creators Program</a></span></span></td>
    </tr>  
</table>

### <a name="for-managed-partners-and-developers-in-the-idxbox-program"></a><span data-ttu-id="52ac8-871">対象パートナーおよび ID@Xbox プログラムの開発者向け</span><span class="sxs-lookup"><span data-stu-id="52ac8-871">For managed partners and developers in the ID@Xbox program</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-872">概要</span><span class="sxs-lookup"><span data-stu-id="52ac8-872">Overview</span></span></td>
        <td><span data-ttu-id="52ac8-873"><a href="../xbox-live/get-started-with-partner/get-started-with-xbox-live-partner.md">管理対象のパートナーや、ID 開発者として Xbox Live の概要します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-873"><a href="../xbox-live/get-started-with-partner/get-started-with-xbox-live-partner.md">Get started with Xbox Live as a managed partner or an ID developer</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-874">ゲームへの Xbox Live の追加</span><span class="sxs-lookup"><span data-stu-id="52ac8-874">Add Xbox Live to your game</span></span></td>
        <td><span data-ttu-id="52ac8-875"><a href="../xbox-live/get-started-with-partner/partners-step-by-step-guide.md">管理対象のパートナーと ID のメンバーの Xbox Live を統合するステップ バイ ステップ ガイドします。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-875"><a href="../xbox-live/get-started-with-partner/partners-step-by-step-guide.md">Step by step guide to integrate Xbox Live for managed partners and ID members</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-876">Unity を使用して作成された UWP ゲームに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="52ac8-876">Add Xbox Live to your UWP game created using Unity</span></span></td>
        <td><span data-ttu-id="52ac8-877"><a href="../xbox-live/get-started-with-partner/partner-unity-uwp-il2cpp.md">Xbox Live にサポートを追加 Unity for UWP il2cpp バック エンド スクリプト バックエンドでの ID と管理対象のパートナー</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-877"><a href="../xbox-live/get-started-with-partner/partner-unity-uwp-il2cpp.md">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID and managed partners</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-878">開発サンドボックスをセットアップする</span><span class="sxs-lookup"><span data-stu-id="52ac8-878">Set up your development sandbox</span></span></td>
        <td><span data-ttu-id="52ac8-879"><a href="../xbox-live/get-started-with-partner/advanced-xbox-live-sandboxes.md">高度な Xbox Live のサンド ボックス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-879"><a href="../xbox-live/get-started-with-partner/advanced-xbox-live-sandboxes.md">Advanced Xbox Live sandboxes</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-880">Xbox Live を使うためのゲームの要件 (GDN)</span><span class="sxs-lookup"><span data-stu-id="52ac8-880">Requirements for games that use Xbox Live (GDN)</span></span></td>
        <td><span data-ttu-id="52ac8-881"><a href="https://go.microsoft.com/fwlink/?LinkId=533217">Windows 10 の Xbox の Xbox 要件が Live します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-881"><a href="https://go.microsoft.com/fwlink/?LinkId=533217">Xbox Requirements for Xbox Live on Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-882">サンプル</span><span class="sxs-lookup"><span data-stu-id="52ac8-882">Samples</span></span></td>
        <td><span data-ttu-id="52ac8-883"><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK">コード サンプルID@Xbox開発者</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-883"><a href="https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK">Code samples for ID@Xbox developers</a></span></span></td>
    </tr>  
    <tr>
        <td><span data-ttu-id="52ac8-884">Xbox Live のゲーム開発の概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-884">Overview of Xbox Live game development (video)</span></span></td>
        <td><span data-ttu-id="52ac8-885"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Developing-with-Xbox-Live-for-Windows-10">Windows 10 向け Live Xbox を使用した開発</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-885"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Developing-with-Xbox-Live-for-Windows-10">Developing with Xbox Live for Windows 10</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-886">クロス プラットフォーム マッチメイキング (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-886">Cross-platform matchmaking (video)</span></span></td>
        <td><span data-ttu-id="52ac8-887"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Xbox-Live-Multiplayer-Introducing-services-for-cross-platform-matchmaking-and-gameplay">Xbox Live マルチプレイヤー:クロス プラットフォームのマッチメイ キングとゲームプレイのサービスの概要</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-887"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Xbox-Live-Multiplayer-Introducing-services-for-cross-platform-matchmaking-and-gameplay">Xbox Live Multiplayer: Introducing services for cross-platform matchmaking and gameplay</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-888">Fable Legends でのクロス デバイスのゲームプレイ (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-888">Cross-device gameplay in Fable Legends (video)</span></span></td>
        <td><span data-ttu-id="52ac8-889"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Fable-Legends-Cross-device-Gameplay-with-Xbox-Live">Fable 凡例:クロス デバイス ゲームプレイ xbox Live します。</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-889"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Fable-Legends-Cross-device-Gameplay-with-Xbox-Live">Fable Legends: Cross-device Gameplay with Xbox Live</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-890">Xbox Live の統計情報や達成度 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-890">Xbox Live stats and achievements (video)</span></span></td>
        <td><span data-ttu-id="52ac8-891"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Best-Practices-for-Leveraging-Cloud-Based-User-Stats-and-Achievements-in-Xbox-Live">クラウド ベースのユーザーの統計を利用するためのベスト プラクティスし、アチーブメントで Xbox Live</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-891"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Best-Practices-for-Leveraging-Cloud-Based-User-Stats-and-Achievements-in-Xbox-Live">Best Practices for Leveraging Cloud-Based User Stats and Achievements in Xbox Live</a></span></span></td>
    </tr>
</table>


## <a name="additional-resources"></a><span data-ttu-id="52ac8-892">その他の資料</span><span class="sxs-lookup"><span data-stu-id="52ac8-892">Additional resources</span></span>

<table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <tr>
        <td><span data-ttu-id="52ac8-893">ゲーム開発ビデオ</span><span class="sxs-lookup"><span data-stu-id="52ac8-893">Game development videos</span></span></td>
        <td><span data-ttu-id="52ac8-894"><a href="https://docs.microsoft.com/windows/uwp/gaming/game-development-videos">GDC//build などの主要なカンファレンスのビデオ</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-894"><a href="https://docs.microsoft.com/windows/uwp/gaming/game-development-videos">Videos from major conferences like GDC and //build</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-895">インディーズ ゲーム開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-895">Indie game development (video)</span></span></td>
        <td><span data-ttu-id="52ac8-896"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/New-Opportunities-for-Independent-Developers">個人開発者に新しい機会</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-896"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/New-Opportunities-for-Independent-Developers">New Opportunities for Independent Developers</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-897">マルチコア モバイル デバイスに関する考慮事項 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-897">Considerations for multi-core mobile devices (video)</span></span></td>
        <td><span data-ttu-id="52ac8-898"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Sustained-gaming-performance-in-multi-core-mobile-devices">マルチコアのモバイル デバイスで持続的なゲームのパフォーマンス</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-898"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/Sustained-gaming-performance-in-multi-core-mobile-devices">Sustained Gaming Performance in multi-core mobile devices</a></span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="52ac8-899">Windows 10 デスクトップ ゲームの開発 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="52ac8-899">Developing Windows 10 desktop games (video)</span></span></td>
        <td><span data-ttu-id="52ac8-900"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/PC-Games-for-Windows-10">Windows 10 の PC ゲーム</a></span><span class="sxs-lookup"><span data-stu-id="52ac8-900"><a href="https://channel9.msdn.com/Events/GDC/GDC-2015/PC-Games-for-Windows-10">PC Games for Windows 10</a></span></span></td>
    </tr>
</table>



 

 

 
