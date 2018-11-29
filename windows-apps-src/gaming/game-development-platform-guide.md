---
title: ユニバーサル Windows プラットフォーム (UWP) アプリのゲーム テクノロジ
description: このガイドでは、ユニバーサル Windows プラットフォーム UWP ゲームの開発に利用できるテクノロジについて説明します。
ms.assetid: bc4d4648-0d6e-efbb-7608-80bd09decd6e
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, テクノロジ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: c6d2ebad640849cd81d6a2704f89ca1f05cc1b27
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8217893"
---
# <a name="game-technologies-for-uwp-apps"></a><span data-ttu-id="a4a06-104">UWP アプリのゲーム テクノロジ</span><span class="sxs-lookup"><span data-stu-id="a4a06-104">Game technologies for UWP apps</span></span>



<span data-ttu-id="a4a06-105">このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に利用できるテクノロジについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-105">In this guide, you'll learn about the technologies available for developing Universal Windows Platform (UWP) games.</span></span>

##  <a name="benefits-of-windows10-for-game-development"></a><span data-ttu-id="a4a06-106">ゲーム開発向けの windows 10 のメリット</span><span class="sxs-lookup"><span data-stu-id="a4a06-106">Benefits of Windows10 for game development</span></span>


<span data-ttu-id="a4a06-107">Windows 10 で UWP の導入により、windows 10 のタイトルはすべての Microsoft プラットフォームに対応することになります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-107">With the introduction of UWP in Windows10, your Windows10 titles will be able to span all of the Microsoft platforms.</span></span> <span data-ttu-id="a4a06-108">以前のバージョンの Windows から無料で移行は、windows 10 クライアント数が徐々 に増加します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-108">With free migration from previous versions of Windows, there is a steadily increasing number of Windows10 clients.</span></span> <span data-ttu-id="a4a06-109">これら 2 つの組み合わせは、windows 10 のタイトルが、Microsoft Store 経由でお客様の膨大な数に到達できることを意味します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-109">The combination of these two things means that your Windows10 titles will be able to reach a huge number of customers through the Microsoft Store.</span></span>

<span data-ttu-id="a4a06-110">さらに、windows 10 には、ゲームに特に便利な多くの新しい機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-110">In addition, Windows10 offers many new features that are particularly beneficial to games:</span></span>

-   <span data-ttu-id="a4a06-111">メモリのページングの削減および全体的なメモリ システム サイズの削減</span><span class="sxs-lookup"><span data-stu-id="a4a06-111">Reduced memory paging and reduced overall memory system size</span></span>
-   <span data-ttu-id="a4a06-112">グラフィックス メモリの管理機能の向上により、フォアグラウンドのゲームに、より多くのメモリがアクティブに割り当てられ、保護されます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-112">Improved graphics memory management actively allocates and protects more memory for the foreground game</span></span>

## <a name="uwp-games-with-c-and-directx"></a><span data-ttu-id="a4a06-113">C++ と DirectX を使った UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="a4a06-113">UWP Games with C++ and DirectX</span></span>


<span data-ttu-id="a4a06-114">高パフォーマンスを必要とするリアルタイム ゲームでは、DirectX API を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-114">Real-time games requiring high performance should make use of the DirectX APIs.</span></span> <span data-ttu-id="a4a06-115">DirectX は、3D ゲームなど、高パフォーマンスを必要とするゲームやマルチメディア アプリケーションを作成するための、ネイティブ API のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="a4a06-115">DirectX is a collection of native APIs for creating games and multimedia applications that require high performance, such as 3D games.</span></span>

## <a name="development-environment"></a><span data-ttu-id="a4a06-116">開発環境</span><span class="sxs-lookup"><span data-stu-id="a4a06-116">Development Environment</span></span>


<span data-ttu-id="a4a06-117">Uwp ゲームを作成するには、Visual Studio 2015 以降をインストールして開発環境を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-117">To create games for UWP, you'll need to set up your development environment by installing Visual Studio 2015 or later.</span></span> <span data-ttu-id="a4a06-118">お勧めします、Visual Studio の最新バージョンをインストールすることを最新の開発とセキュリティ更新プログラム。</span><span class="sxs-lookup"><span data-stu-id="a4a06-118">We recommend that you install the latest version of Visual Studio, giving you access to the latest development and security updates.</span></span> <span data-ttu-id="a4a06-119">Visual Studio では、UWP アプリを作成することができ、ゲームの開発ツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-119">Visual Studio allows you to create UWP apps and provides tools for game development:</span></span>

-   <span data-ttu-id="a4a06-120">Visual Studio の DX ゲームのプログラミング用ツール: Visual Studio には、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするためのツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-120">Visual Studio tools for DX game programming - Visual Studio provides tools for creating, editing, previewing, and exporting image, model, and shader resources.</span></span> <span data-ttu-id="a4a06-121">また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-121">There are also tools that you can use to convert resources at build time and debug DirectX graphics code.</span></span> <span data-ttu-id="a4a06-122">詳しくは、「[ゲーム プログラミング用の Visual Studio ツールの使用](set-up-visual-studio-for-game-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-122">For more information, see [Use Visual Studio tools for game programming](set-up-visual-studio-for-game-development.md).</span></span>
-   <span data-ttu-id="a4a06-123">Visual Studio グラフィックス診断機能: オプション機能として、グラフィックス診断ツールを Windows 内から利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="a4a06-123">Visual Studio graphics diagnostics features - Graphics diagnostic tools are now available from within Windows as an optional feature.</span></span> <span data-ttu-id="a4a06-124">診断ツールを使って、グラフィックス デバッグやグラフィックス フレーム分析を実行し、リアルタイムで GPU 使用率を監視できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-124">The diagnostic tools allow you to do graphics debugging, graphics frame analysis, and monitor GPU usage in real time.</span></span> <span data-ttu-id="a4a06-125">詳しくは、「[DirectX ランタイムと Visual Studio グラフィックス診断機能の使用](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-125">For more information, see [Use the DirectX runtime and Visual Studio graphics diagnostic features](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md).</span></span>

<span data-ttu-id="a4a06-126">詳しくは、「ユニバーサル Windows プラットフォームと [DirectX プログラミング](directx-programming.md)環境の準備」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-126">For more information, see Prepare your Universal Windows Platform and [DirectX programming](directx-programming.md).</span></span>

## <a name="getting-started-with-directx-game-project-templates"></a><span data-ttu-id="a4a06-127">DirectX ゲーム プロジェクト テンプレートの概要</span><span class="sxs-lookup"><span data-stu-id="a4a06-127">Getting Started with DirectX Game Project Templates</span></span>


<span data-ttu-id="a4a06-128">開発環境をセットアップすると、DirectX 関連のプロジェクト テンプレートのいずれかを使って UWP DirectX ゲームを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-128">After setting up your development environment, you can use one of the DirectX related project templates to create your UWP DirectX game.</span></span> <span data-ttu-id="a4a06-129">Visual Studio 2015 には、新しい UWP DirectX プロジェクトを作成するためのテンプレートとして、**DirectX 11 アプリ (ユニバーサル Windows)**、**DirectX 12 アプリ (ユニバーサル Windows)**、**DirectX 11 および XAML アプリ (ユニバーサル Windows)** の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-129">Visual Studio 2015 has three templates available for creating new UWP DirectX projects, **DirectX 11 App (Universal Windows)**, **DirectX 12 App (Universal Windows)**, and **DirectX 11 and XAML App (Universal Windows)**.</span></span> <span data-ttu-id="a4a06-130">詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-130">For more information, see [Create a Universal Windows Platform and DirectX game project from a template](user-interface.md).</span></span>

## <a name="windows-10-apis"></a><span data-ttu-id="a4a06-131">Windows 10 API</span><span class="sxs-lookup"><span data-stu-id="a4a06-131">Windows 10 APIs</span></span>


<span data-ttu-id="a4a06-132">Windows 10 では、ゲーム開発に役立つさまざまな API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-132">Windows 10 provides an extensive collection of APIs that are useful for game development.</span></span> <span data-ttu-id="a4a06-133">3D グラフィックス、2D グラフィックス、オーディオ、入力、テキスト リソース、ユーザー インターフェイス、ネットワークなど、ゲームのほとんどすべての側面にかかわる API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-133">There are APIs for almost all aspects of games including, 3D Graphics, 2D Graphics, Audio, Input, Text Resources, User Interface, and networking.</span></span>

<span data-ttu-id="a4a06-134">ゲーム開発に関連する API は数多くありますが、すべてのゲームですべての API を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a4a06-134">There are many APIs related to game development, but not all games need to use all of the APIs.</span></span> <span data-ttu-id="a4a06-135">たとえば、3D グラフィックスと Direct3D のみを利用するゲームもあれば、2D グラフィックスと Direct2D のみを利用するゲームもあります。また、その両方を使用するゲームもあります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-135">For example, some games will only use 3D graphics and only make use of Direct3D, some games may only use 2D graphics and only make use of Direct2D, and still other games may make use of both.</span></span> <span data-ttu-id="a4a06-136">次の図は、ゲーム開発に関連する API を機能別にグループ分けしています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-136">The following diagram shows the game development related APIs grouped by functionality type.</span></span>

![ゲーム プラットフォーム テクノロジ](images/gameplatformtechnologies.png)

-   <span data-ttu-id="a4a06-138">3D グラフィックス: Windows 10 では、Direct3D 11 と [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) の 2 つの 3D グラフィックス API セットをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-138">3D Graphics - Windows 10 supports two 3D graphics API sets, Direct3D 11, and [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121).</span></span> <span data-ttu-id="a4a06-139">これら API はいずれも、3D および 2D グラフィックスを作成する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-139">Both of these APIs provide the capability to create 3D and 2D graphics.</span></span> <span data-ttu-id="a4a06-140">Direct3D 11 と Direct3D 12 を同時に使うことはありませんが、いずれも 2D グラフィックスおよび UI グループのすべての API と共に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-140">Direct3D 11 and Direct3D 12 are not used together, but either can be used with any of the APIs in the 2D Graphics and UI group.</span></span> <span data-ttu-id="a4a06-141">ゲームでグラフィックス API を使う方法について詳しくは、「[DirectX ゲームの基本的な 3D グラフィックス](an-introduction-to-3d-graphics-with-directx.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-141">For more information about using the graphics APIs in your game, see [Basic 3D graphics for DirectX games](an-introduction-to-3d-graphics-with-directx.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-142">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-142">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-143">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-143">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-144">Direct3D 12</span><span class="sxs-lookup"><span data-stu-id="a4a06-144">Direct3D 12</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-145">Direct3D 12 では、DirectX の核となる 3D グラフィックス API である Direct3D の次期バージョンが導入されます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-145">Direct3D 12 introduces the next version of Direct3D, the 3D graphics API at the heart of DirectX.</span></span> <span data-ttu-id="a4a06-146">このバージョンの Direct3D は、以前のバージョンの Direct3D よりも高速かつ効率的になるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-146">This version of Direct3D is designed to be faster and more efficient than previous versions of Direct3D.</span></span> <span data-ttu-id="a4a06-147">Direct3D 12 の速度の向上のトレードオフは、より下位レベルで動作することであり、グラフィックス リソースを自分で管理する必要があることです。また、速度の向上を実現するには、広範なグラフィックスのプログラミングの経験が必要です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-147">The tradeoff for Direct3D 12's increased speed is that it is lower level and requires you to manage your graphics resources yourself and have more extensive graphics programming experience to realize the increased speed.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-148">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-148">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-149">Direct3D 12 は、ゲームのパフォーマンスを最大化する必要があり、ゲームが CPU バウンドである場合に使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-149">Use Direct3D 12 when you need to maximize your game's performance and your game is CPU bound.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-150">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-150">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-151"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899121">Direct3d 12</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-151">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dn899121">Direct3d 12</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-152">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="a4a06-152">Direct3D 11</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-153">Direct3D 11 は、以前のバージョンの Direct3D であり、D3D 12 より上位レベルのハードウェア アブストラクションを使用して 3D グラフィックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-153">Direct3D 11 is the previous version of Direct3D and allows you to create 3D graphics using a higher level of hardware abstraction than D3D 12.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-154">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-154">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-155">Direct3D 11 のコードが既にある場合、ゲームが CPU バウンドではない場合、またはリソースが自動的に管理されるメリットが必要な場合は、Direct3D 11 を使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-155">Use Direct3D 11 if you have existing Direct3D 11 code, your game is not CPU bound, or you want the benefit of having resources managed for you.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-156">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-156">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-157"><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-157">See the <a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-158">2D グラフィックスおよび UI API: テキストやユーザー インターフェイスなどの 2D グラフィックスに関する API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-158">2D Graphics and UI - APIs concerning 2D graphics such as text and user interfaces.</span></span> <span data-ttu-id="a4a06-159">すべての 2D グラフィックスおよび UI API はオプションです。</span><span class="sxs-lookup"><span data-stu-id="a4a06-159">All of the 2D graphics and UI APIs are optional.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-160">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-160">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-161">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-161">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-162">Direct2D</span><span class="sxs-lookup"><span data-stu-id="a4a06-162">Direct2D</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-163">Direct2D は、2D ジオメトリ、ビットマップ、テキストの高パフォーマンスかつ高品質のレンダリングを実現する、ハードウェア アクセラレータによる、即時モードの 2D グラフィックス API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-163">Direct2D is a hardware-accelerated, immediate-mode, 2-D graphics API that provides high performance and high-quality rendering for 2-D geometry, bitmaps, and text.</span></span> <span data-ttu-id="a4a06-164">Direct2D API は Direct3D を基にして構築されており、GDI、GDI+、Direct3D とも適切に相互運用できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-164">The Direct2D API is built on Direct3D and is designed to interoperate well with GDI, GDI+, and Direct3D.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-165">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-165">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-166">Direct2D は、横スクロール ゲームやボード ゲームなどの純粋な 2D ゲーム用のグラフィックスを提供するために、Direct3D の代わりに使うことができます。また、ユーザー インターフェイスやヘッドアップ ディスプレイなど、3D ゲーム内での 2D グラフィックスの作成を簡素化するために Direct3D と共に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-166">Direct2D can be used instead of Direct3D to provide graphics for pure 2D games such as a side-scroller or board game, or can be used with Direct3D to simplify creation of 2D graphics in a 3D game, such as a user interface or heads-up-display.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-167">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-167">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-168"><a href="https://msdn.microsoft.com/library/windows/desktop/dd370990">Direct2D</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-168">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dd370990">Direct2D</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-169">DirectWrite</span><span class="sxs-lookup"><span data-stu-id="a4a06-169">DirectWrite</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-170">DirectWrite は、テキストを操作するための追加の機能を提供します。Direct3D や Direct2D と共に使用して、ユーザー インターフェイスや、テキストが必要なその他の領域にテキスト出力を提供できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-170">DirectWrite provides extra capabilities for working with text and can be used with Direct3D or Direct2D to provide text output for user interfaces or other areas where text is required.</span></span> <span data-ttu-id="a4a06-171">DirectWrite は、複数形式のテキストの測定、描画、ヒット テストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a4a06-171">DirectWrite supports measuring, drawing, and hit-testing of multi-format text.</span></span> <span data-ttu-id="a4a06-172">DirectWrite は、グローバル アプリケーションとローカライズされたアプリケーションで、サポートされているすべての言語のテキストを処理します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-172">DirectWrite handles text in all supported languages for global and localized applications.</span></span> <span data-ttu-id="a4a06-173">DirectWrite は、独自のレイアウトと Unicode からグリフへの処理を実行する必要がある開発者に、下位レベルのグリフ レンダリング API も提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-173">DirectWrite also provides a low-level glyph rendering API for developers who want to perform their own layout and Unicode-to-glyph processing.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-174">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-174">When to use</span></span></strong></p>
    <p></p>
    <p><strong><span data-ttu-id="a4a06-175">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-175">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-176"><a href="https://msdn.microsoft.com/library/windows/desktop/dd368038">DirectWrite</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-176">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dd368038">DirectWrite</a> documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-177">DirectComposition</span><span class="sxs-lookup"><span data-stu-id="a4a06-177">DirectComposition</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-178">DirectComposition は、変換、効果、アニメーションを使って、高パフォーマンスのビットマップ合成を実現できる Windows コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="a4a06-178">DirectComposition is a Windows component that enables high-performance bitmap composition with transforms, effects, and animations.</span></span> <span data-ttu-id="a4a06-179">アプリケーション開発者は、DirectComposition API によって、ビジュアル要素間で機能豊富で柔軟な切り替えのアニメーションを使った、視覚的に魅力のあるユーザー インターフェイスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-179">Application developers can use the DirectComposition API to create visually engaging user interfaces that feature rich and fluid animated transitions from one visual to another.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-180">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-180">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-181">DirectComposition は、視覚要素を合成し、切り替えのアニメーションを作成するプロセスを簡略化するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-181">DirectComposition is designed to simplify the process of composing visuals and creating animated transitions.</span></span> <span data-ttu-id="a4a06-182">複雑なユーザー インターフェイスがゲームに必要な場合、DirectComposition を使って、簡単に UI を作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-182">If your game requires complex user interfaces, you can use DirectComposition to simplify the creation and management of the UI.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-183">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-183">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-184"><a href="https://msdn.microsoft.com/library/windows/desktop/hh437371">DirectComposition</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-184">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh437371">DirectComposition</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-185">オーディオ: オーディオの再生やオーディオ エフェクトの適用に関する API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-185">Audio - APIs concerning playing audio and applying audio effects.</span></span> <span data-ttu-id="a4a06-186">ゲームでオーディオ API を使う方法について詳しくは、「[ゲームのオーディオ](working-with-audio-in-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-186">For information about using the audio APIs in your game, see [Audio for games](working-with-audio-in-your-directx-game.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-187">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-187">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-188">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-188">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-189">XAudio2</span><span class="sxs-lookup"><span data-stu-id="a4a06-189">XAudio2</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-190">XAudio2 は、信号処理とミキシングの基礎を提供する下位レベルのオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-190">XAudio2 is a low-level audio API that provides a foundation for signal processing and mixing.</span></span> <span data-ttu-id="a4a06-191">XAudio は、カスタム オーディオ エフェクトや、オーディオ エフェクトとフィルターの複雑なチェーンを作成する機能を維持しながら、ゲーム オーディオ エンジンに対する応答性が高くなるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-191">XAudio is designed to be very responsive for game audio engines while maintaining the ability to create custom audio effects and complex chains of audio effects and filters.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-192">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-192">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-193">ゲームでオーバーヘッドと遅延を最小限に抑えながらサウンドを再生する必要がある場合、XAudio2 を使用します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-193">Use XAudio2 when your game needs to play sounds with minimal overhead and delay.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-194">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-194">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-195"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049">XAudio2</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-195">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh405049">XAudio2</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-196">メディア ファンデーション</span><span class="sxs-lookup"><span data-stu-id="a4a06-196">Media Foundation</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-197">Microsoft メディア ファンデーションは、オーディオとビデオの両方のメディア ファイルやストリームの再生用として設計されていますが、XAudio2 よりも高いレベルの機能が必要とされている場合や、追加のオーバーヘッドを許容できる場合にゲームで利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-197">Microsoft Media Foundation is designed for the playback of media files and streams, both audio and video, but can also be used in games when higher level functionality than XAudio2 is required and some additional overhead is acceptable.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-198">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-198">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-199">メディア ファンデーションは、特に、ゲーム中の映画的なシーンや非対話型のコンポーネントに利用できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-199">Media foundation is particularly useful for cinematic scenes or non-interactive components of your game.</span></span> <span data-ttu-id="a4a06-200">また、メディア ファンデーションは、XAudio2 を使って再生するオーディオ ファイルをデコードするのに便利です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-200">Media foundation is also useful for decoding audio files for playback using XAudio2.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-201">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-201">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-202"><a href="https://msdn.microsoft.com/library/windows/desktop/ms694197">Microsoft メディア ファンデーション</a>の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-202">See the <a href="https://msdn.microsoft.com/library/windows/desktop/ms694197">Microsoft Media Foundation</a> overview.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-203">入力: キーボード、マウス、ゲームパッド、その他のユーザー入力ソースからの入力に関する API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-203">Input - APIs concerning input from the keyboard, mouse, gamepad, and other user input sources.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-204">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-204">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-205">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-205">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-206">XInput</span><span class="sxs-lookup"><span data-stu-id="a4a06-206">XInput</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-207">XInput ゲーム コント ローラー API によって、アプリケーションでゲーム コントローラーからの入力を受信できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-207">The XInput Game Controller API enables applications to receive input from game controllers.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-208">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-208">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-209">ゲームでゲームパッドからの入力をサポートする必要がある場合や、XInput のコードが既にある場合は、引き続き XInput を利用できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-209">If your game needs to support gampad input and you have existing XInput code, you can continue to make use of XInput.</span></span> <span data-ttu-id="a4a06-210">UWP の場合、XInput は Windows.Gaming.Input に置き換えられたため、新しい入力コードを記述する場合は、XInput ではなく Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-210">XInput has been replaced by Windows.Gaming.Input for UWP, and if you're writing new input code, you should use Windows.Gaming.Input instead of XInput.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-211">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-211">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-212"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405053">XInput</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-212">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh405053">XInput</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-213">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="a4a06-213">Windows.Gaming.Input</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-214">Windows.Gaming.Input API は XInput を置き換える API であり、同じ機能を提供すると共に、XInput に比べて次のような利点があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-214">The Windows.Gaming.Input API replaces XInput and provides the same functionality with the following advantages over Xinput:</span></span></p>
    <ul>
    <li><span data-ttu-id="a4a06-215">リソースの使用量が少ない</span><span class="sxs-lookup"><span data-stu-id="a4a06-215">Lower resource usage</span></span></li>
    <li><span data-ttu-id="a4a06-216">入力を取得するための API 呼び出しの待ち時間が短い</span><span class="sxs-lookup"><span data-stu-id="a4a06-216">Lower API call latency for retrieving input</span></span></li>
    <li><span data-ttu-id="a4a06-217">同時に 4 つ以上のゲームパッドを処理する機能</span><span class="sxs-lookup"><span data-stu-id="a4a06-217">The ability to work with more than 4 gamepads at once</span></span></li>
    <li><span data-ttu-id="a4a06-218">トリガー バイブレーション モーターなど、追加の Xbox One ゲームパッド機能にアクセスする機能</span><span class="sxs-lookup"><span data-stu-id="a4a06-218">The ability to access additional Xbox One gamepad features, such as the trigger vibration motors</span></span></li>
    <li><span data-ttu-id="a4a06-219">コントローラー接続/切断をポーリングではなくイベントで通知する機能</span><span class="sxs-lookup"><span data-stu-id="a4a06-219">The ability to be notified when controllers connect/disconnect via event instead of polling</span></span></li>
    <li><span data-ttu-id="a4a06-220">入力を特定のユーザー (Windows.System.User) に関連付ける機能</span><span class="sxs-lookup"><span data-stu-id="a4a06-220">The ability to attribute input to a specific user (Windows.System.User)</span></span></li>
    </ul>
    <p><strong><span data-ttu-id="a4a06-221">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-221">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-222">ゲームでゲームパッド入力をサポートする必要があるが、XInput の既存のコードを使っていない場合や、上に示したメリットのいずれかが必要である場合は、Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-222">If your game needs to support gamepad input and is not using existing XInput code or you need one of the benefits listed above, you should make use of Windows.Gaming.Input.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-223">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-223">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-224"><a href="https://msdn.microsoft.com/library/windows/apps/dn707817">Windows.Gaming.Input</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-224">See the <a href="https://msdn.microsoft.com/library/windows/apps/dn707817">Windows.Gaming.Input</a> documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-225">Windows.UI.Core.CoreWindow</span><span class="sxs-lookup"><span data-stu-id="a4a06-225">Windows.UI.Core.CoreWindow</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-226">Windows.UI.Core.CoreWindow クラスは、ポインターのボタンの押下や移動を追跡するためのイベント、キーの押下やリリースのイベントを提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-226">The Windows.UI.Core.CoreWindow class provides events for tracking pointer presses and movement, and key down and key up events.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-227">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-227">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-228">ゲームでマウスやキーの押下を追跡する必要がある場合、Windows.UI.Core.CoreWindows のイベントを使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-228">Use Windows.UI.Core.CoreWindows events when you need to track the mouse or key presses in your game.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-229">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-229">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-230">ゲームでマウスやキーボードを使う方法について詳しくは、「<a href="https://docs.microsoft.com/windows/uwp/gaming/tutorial--adding-move-look-controls-to-your-directx-game">ゲームのムーブ/ルック コントロール</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-230">See <a href="https://docs.microsoft.com/windows/uwp/gaming/tutorial--adding-move-look-controls-to-your-directx-game">Move-look controls for games</a> for more information about using the mouse or keyboard in your game.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-231">数値演算: 一般的に使用される数値演算の簡素化に関する API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-231">Math - APIs concerning simplifying commonly used mathematical operations.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-232">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-232">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-233">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-233">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-234">DirectXMath</span><span class="sxs-lookup"><span data-stu-id="a4a06-234">DirectXMath</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-235">DirectXMath API は、ゲームで一般的な線形代数およびグラフィックスの数値演算用の SIMD フレンドリな C++ の型および関数を提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-235">The DirectXMath API provides SIMD-friendly C++ types and functions for common linear algebra and graphics math operations common to games.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-236">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-236">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-237">DirectXMath の使用はオプションであり、一般的な数値演算を簡素化します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-237">Use of DirectXMath is optional and simplifies common mathematical operations.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-238">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-238">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-239"><a href="https://msdn.microsoft.com/library/windows/desktop/hh437833">DirectXMath</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-239">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh437833">DirectXMath</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-240">ネットワーク: インターネットまたはプライベート ネットワーク上の他のコンピューターやデバイスとの通信に関する API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-240">Networking - APIs concerning communicating with other computers and devices over either the Internet or private networks.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-241">API</span><span class="sxs-lookup"><span data-stu-id="a4a06-241">API</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-242">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-242">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-243">Windows.Networking.Sockets</span><span class="sxs-lookup"><span data-stu-id="a4a06-243">Windows.Networking.Sockets</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-244">Windows.Networking.Sockets 名前空間は、信頼性の高いまたは信頼性の低いネットワーク通信を実現する TCP および UDP ソケットを提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-244">The Windows.Networking.Sockets namespace provides TCP and UDP sockets that allow reliable or unreliable network communication.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-245">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-245">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-246">Windows.Networking.Sockets は、ゲームがネットワーク経由で他のコンピューターやデバイスと通信する必要がある場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-246">Use Windows.Networking.Sockets if your game needs to communicate with other computers or devices over the network.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-247">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-247">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-248">「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-248">See <a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">Work with networking in your game</a>.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-249">Windows.Web.HTTP</span><span class="sxs-lookup"><span data-stu-id="a4a06-249">Windows.Web.HTTP</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-250">Windows.Web.HTTP 名前空間では、Web サイトへのアクセスに利用できる、HTTP サーバーへの信頼性の高い接続を実現できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-250">The Windows.Web.HTTP namespace provides a reliable connection to HTTP servers that can be used to access a web site.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-251">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-251">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-252">ゲームで Web サイトにアクセスして情報を取得または保存する必要がある場合に、Windows.Web.HTTP を使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-252">Use Windows.Web.HTTP when your game needs to access a web site to retrieve or store information.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-253">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-253">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-254">「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-254">See <a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">Work with networking in your game</a>.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="a4a06-255">サポート ユーティリティ: Windows 10 API に基づいて構築されたライブラリです。</span><span class="sxs-lookup"><span data-stu-id="a4a06-255">Support Utilities - Libraries that build on the Windows 10 APIs.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="a4a06-256">ライブラリ</span><span class="sxs-lookup"><span data-stu-id="a4a06-256">Library</span></span></th>
    <th align="left"><span data-ttu-id="a4a06-257">説明</span><span class="sxs-lookup"><span data-stu-id="a4a06-257">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="a4a06-258">DirectX ツール キット</span><span class="sxs-lookup"><span data-stu-id="a4a06-258">DirectX Tool Kit</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-259">DirectX ツール キット (DirectXTK) は、C++ で DirectX 11.x コードを作成するためのヘルパー クラスのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="a4a06-259">The DirectX Tool Kit (DirectXTK) is a collection of helper classes for writing DirectX 11.x code in C++.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-260">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-260">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-261">C++ を使っている開発者がレガシ D3DX ユーティリティ コードに代わる最新のユーティリティを探している場合や、XNA Game Studio を使っている開発者がネイティブ C++ に移行する場合に、DirectX ツール キットを使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-261">Use the DirectX Tool Kit if you're a C++ developer looking for a modern replacement to the legacy D3DX utility code or you're an XNA Game Studio developer transitioning to native C++.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-262">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-262">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-263">DirectX ツール キットのプロジェクト ページ <a href="https://github.com/Microsoft/DirectXTK">https://github.com/Microsoft/DirectXTK</a> を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-263">See the DirectX Tool Kit project page, <a href="https://github.com/Microsoft/DirectXTK">https://github.com/Microsoft/DirectXTK</a>.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="a4a06-264">Win2D</span><span class="sxs-lookup"><span data-stu-id="a4a06-264">Win2D</span></span></td>
    <td align="left"><p><span data-ttu-id="a4a06-265">Win2D は、即時モードの 2D グラフィックス レンダリング用の、使いやすい Windows ランタイム API です。</span><span class="sxs-lookup"><span data-stu-id="a4a06-265">Win2D is an easy-to-use Windows Runtime API for immediate mode 2D graphics rendering.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-266">使う状況</span><span class="sxs-lookup"><span data-stu-id="a4a06-266">When to use</span></span></strong></p>
    <p><span data-ttu-id="a4a06-267">C++ を使っている開発者が Direct2D と DirectWrite の使いやすい WinRT ラッパーを必要としている場合や、C# を使っている開発者が Direct2D と DirectWrite を使う必要がある場合に、Win2D を使います。</span><span class="sxs-lookup"><span data-stu-id="a4a06-267">Use Win2D if you're a C++ developer and want an easier to use WinRT wrapper for Direct2D and DirectWrite, or you're a C# developer wanting to use Direct2D and DirectWrite.</span></span></p>
    <p><strong><span data-ttu-id="a4a06-268">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a4a06-268">For more information</span></span></strong></p>
    <p><span data-ttu-id="a4a06-269">Win2D プロジェクト ページ <a href="https://github.com/Microsoft/Win2D">https://github.com/Microsoft/Win2D</a> を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-269">See the Win2D project page, <a href="https://github.com/Microsoft/Win2D">https://github.com/Microsoft/Win2D</a>.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

## <a name="xbox-live-services"></a><span data-ttu-id="a4a06-270">Xbox Live サービス</span><span class="sxs-lookup"><span data-stu-id="a4a06-270">Xbox Live Services</span></span>

<span data-ttu-id="a4a06-271">[Xbox Live クリエーターズ プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator)には、自分の UWP ゲームに Xbox Live を統合して、Xbox One と windows 10 に公開するすべての開発者ができます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-271">The [Xbox Live Creators Program](https://developer.microsoft.com/games/xbox/xboxlive/creator) allows any developer to integrate Xbox Live into their UWP game and publish to Xbox One and Windows10.</span></span> <span data-ttu-id="a4a06-272">最小限の開発時間で、サインイン、プレゼンス、ランキングなどの Xbox Live ソーシャル エクスペリエンスをタイトルに統合できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-272">Integrate Xbox Live social experiences such as sign-in, presence, leaderboards, and more into your title, with minimal development time.</span></span> <span data-ttu-id="a4a06-273">Xbox Live のソーシャル機能では、5,500 万人以上のアクティブ ゲーマーに情報を発信して、オーディエンスを自然に増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-273">Xbox Live social features are designed to organically grow your audience, spreading awareness to over 55 million active gamers.</span></span>

<span data-ttu-id="a4a06-274">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-274">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](http://www.xbox.com/developers/id) program.</span></span> <span data-ttu-id="a4a06-275">Xbox Live クリエーターズ プログラム、および ID@Xbox プログラムで利用できる機能については、[機能表](../xbox-live/developer-program-overview.md#feature-table)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-275">To see which features are available to the Xbox Live Creators Program and ID@Xbox program, see the [Feature table](../xbox-live/developer-program-overview.md#feature-table).</span></span>

<span data-ttu-id="a4a06-276">詳しくは、「[ゲームへの Xbox Live の追加](e2e.md#adding-xbox-live-to-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-276">For more info, go to [Adding Xbox Live to your game](e2e.md#adding-xbox-live-to-your-game).</span></span>

##  <a name="alternatives-to-writing-games-with-directx-and-uwp"></a><span data-ttu-id="a4a06-277">DirectX と UWP を使ったゲーム作成の代替手段</span><span class="sxs-lookup"><span data-stu-id="a4a06-277">Alternatives to writing games with DirectX and UWP</span></span>


### <a name="uwp-games-without-directx"></a><span data-ttu-id="a4a06-278">DirectX を使わない UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="a4a06-278">UWP Games without DirectX</span></span>

<span data-ttu-id="a4a06-279">カード ゲームやボード ゲームなど、最低限のパフォーマンスの要件を満たす単純なゲームは、DirectX を使わずに作成でき、必ずしも C++ で記述されている必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a4a06-279">Simpler games with minimal performance requirements, such as card games or board games, can be written without DirectX and don't necessarily need to be written in C++.</span></span> <span data-ttu-id="a4a06-280">このような種類のゲームでは、C#、Visual Basic、C++、HTML/JavaScript など、UWP でサポートされている言語のいずれかを利用できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-280">These sort of games can make use of any of the languages supported by UWP such as C#, Visual Basic, C++, and HTML/JavaScript.</span></span> <span data-ttu-id="a4a06-281">パフォーマンスと負荷の高いグラフィックスがゲームで必要な場合は、[JavaScript と HTML5 のタッチ ゲームのサンプル](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-281">If performance and intensive graphics are not a requirement for your game, checkout [JavaScript and HTML5 touch game sample](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031) as an example.</span></span>

### <a name="game-engines"></a><span data-ttu-id="a4a06-282">ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="a4a06-282">Game Engines</span></span>

<span data-ttu-id="a4a06-283">Windows ゲーム開発 API を使って独自のゲーム エンジンを作成する代替手段として、Windows ゲーム開発 API を基にして作成された多くの高品質ゲーム エンジンを、Windows プラットフォームでのゲームの開発に利用できます。</span><span class="sxs-lookup"><span data-stu-id="a4a06-283">As an alternative to writing your own game engine using the Windows game development APIs, many high quality game engines that build on the Windows game development APIs are available for developing games on Windows platforms.</span></span> <span data-ttu-id="a4a06-284">ゲーム エンジンまたはライブラリを検討する場合、複数のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-284">When considering a game engine or library, you have multiple options:</span></span>

-   <span data-ttu-id="a4a06-285">フル ゲーム エンジン: フル ゲーム エンジンは、ゲーム エンジンをゼロから作成する場合に使用する、グラフィックス、オーディオ、入力、ネットワークなどの Windows 10 API のほとんどまたはすべてをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-285">Full game engine - A full game engine encapsulates most or all of the Windows 10 APIs you would use when writing a game engine from scratch, such as graphics, audio, input, and networking.</span></span> <span data-ttu-id="a4a06-286">また、フル ゲーム エンジンは、人工知能や経路探索などのゲーム ロジック機能も備えています。</span><span class="sxs-lookup"><span data-stu-id="a4a06-286">Full game engines may also provide game logic functionality such as artificial intelligence and pathfinding.</span></span>
-   <span data-ttu-id="a4a06-287">グラフィックス エンジン: グラフィックス エンジンは、Windows 10 のグラフィックス API をカプセル化して、グラフィックス リソースを管理し、さまざまなモデルとワールドの形式をサポートします。</span><span class="sxs-lookup"><span data-stu-id="a4a06-287">Graphics engine - Graphics engines encapsulate the Windows 10 graphics APIs, manage graphics resources, and support a variety of model and world formats.</span></span>
-   <span data-ttu-id="a4a06-288">オーディオ エンジン: オーディオ エンジンは Windows 10 のオーディオ API をカプセル化して、オーディオ リソースを管理し、高度なオーディオ処理とエフェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-288">Audio engine - Audio engines encapsulate the Windows 10 audio APIs, manage audio resources, and provide advanced audio processing and effects.</span></span>
-   <span data-ttu-id="a4a06-289">ネットワーク エンジン: ネットワーク エンジンは、Windows 10 のネットワーク API をカプセル化して、ピア ツー ピアまたはサーバー ベースのマルチプレイヤーのサポートをゲームに追加します。また、多数のプレイヤーをサポートするための高度なネットワーク機能が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-289">Network engine - Network engines encapsulate Windows 10 networking APIs for adding peer-to-peer or server-based multiplayer support to your game, and may include advanced networking functionality to support large numbers of players.</span></span>
-   <span data-ttu-id="a4a06-290">人工知能と経路探索エンジン: AI と経路探索エンジンは、ゲーム内でエージェントの動作を制御するためのフレームワークを提供します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-290">Artificial intelligence and pathfinding engine - AI and pathfinding engines provide a framework for controlling the behavior of agents in your game.</span></span>
-   <span data-ttu-id="a4a06-291">特殊な用途のエンジン: インベントリ システムやダイアログ ツリーなど、発生する可能性があるほぼすべてのゲーム開発関連タスクを処理するために、さまざまな追加のエンジンが存在します。</span><span class="sxs-lookup"><span data-stu-id="a4a06-291">Special purpose engines - A variety of additional engines exist for handling almost any game development related task you might run into, such as creating inventory systems and dialog trees.</span></span>

## <a name="submitting-a-game-to-the-store"></a><span data-ttu-id="a4a06-292">ストアへのゲームの提出</span><span class="sxs-lookup"><span data-stu-id="a4a06-292">Submitting a game to the Store</span></span>


<span data-ttu-id="a4a06-293">ゲームを公開する準備ができたら、開発者アカウントを作成して、ゲームを Microsoft Store に提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4a06-293">Once you’re ready to publish your game, you’ll need to create a developer account and submit your game to the Microsoft Store.</span></span>

<span data-ttu-id="a4a06-294">Microsoft Store へのゲームの提出については、「[ゲームの申請と公開](e2e.md#submitting-and-publishing-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4a06-294">For information about submitting your game to the Microsoft Store, see [Submitting and publishing your game](e2e.md#submitting-and-publishing-your-game).</span></span>

 

 




