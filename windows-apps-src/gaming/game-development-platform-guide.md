---
author: mtoepke
title: "ユニバーサル Windows プラットフォーム (UWP) アプリのゲーム テクノロジ"
description: "このガイドでは、ユニバーサル Windows プラットフォーム UWP ゲームの開発に利用できるテクノロジについて説明します。"
ms.assetid: bc4d4648-0d6e-efbb-7608-80bd09decd6e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, テクノロジ, DirectX"
ms.openlocfilehash: afbab8d6e38bad7c72d4863f97d90b7eb8ff4cac
ms.sourcegitcommit: ae20971c4c8276034cd22fd7e10b0e3ddfddf480
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="game-technologies-for-uwp-apps"></a><span data-ttu-id="5cf1d-104">UWP アプリのゲーム テクノロジ</span><span class="sxs-lookup"><span data-stu-id="5cf1d-104">Game technologies for UWP apps</span></span>


<span data-ttu-id="5cf1d-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="5cf1d-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="5cf1d-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="5cf1d-107">このガイドでは、ユニバーサル Windows プラットフォーム UWP ゲームの開発に利用できるテクノロジについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-107">In this guide, you'll learn about the technologies available for developing Universal Windows Platform (UWP) games.</span></span>

##  <a name="benefits-of-windows-10-for-game-development"></a><span data-ttu-id="5cf1d-108">ゲーム開発向けの Windows 10 のメリット</span><span class="sxs-lookup"><span data-stu-id="5cf1d-108">Benefits of Windows 10 for game development</span></span>


<span data-ttu-id="5cf1d-109">Windows 10 で UWP が導入されたことにより、作成した Windows 10 のタイトルはすべての Microsoft プラットフォームに対応できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-109">With the introduction of UWP in Windows 10, your Windows 10 titles will be able to span all of the Microsoft platforms.</span></span> <span data-ttu-id="5cf1d-110">以前のバージョンの Windows から無料で移行できるため、Windows 10 のユーザー数は着実に増加しています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-110">With free migration from previous versions of Windows, there is a steadily increasing number of Windows 10 clients.</span></span> <span data-ttu-id="5cf1d-111">これらの 2 つの事実を組み合わせると、Windows 10 のタイトルは、Windows ストアを通じて膨大な数のユーザーに提供できることを意味します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-111">The combination of these two things means that your Windows 10 titles will be able to reach a huge number of customers through the Windows Store.</span></span>

<span data-ttu-id="5cf1d-112">また Windows 10 には、特にゲームに便利な、多くの新しい機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-112">In addition, Windows 10 offers many new features that are particularly beneficial to games:</span></span>

-   <span data-ttu-id="5cf1d-113">メモリのページングの削減および全体的なメモリ システム サイズの削減</span><span class="sxs-lookup"><span data-stu-id="5cf1d-113">Reduced memory paging and reduced overall memory system size</span></span>
-   <span data-ttu-id="5cf1d-114">グラフィックス メモリの管理機能の向上により、フォアグラウンドのゲームに、より多くのメモリがアクティブに割り当てられ、保護されます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-114">Improved graphics memory management actively allocates and protects more memory for the foreground game</span></span>

## <a name="uwp-games-with-c-and-directx"></a><span data-ttu-id="5cf1d-115">C++ と DirectX を使った UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="5cf1d-115">UWP Games with C++ and DirectX</span></span>


<span data-ttu-id="5cf1d-116">高パフォーマンスを必要とするリアルタイム ゲームでは、DirectX API を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-116">Real-time games requiring high performance should make use of the DirectX APIs.</span></span> <span data-ttu-id="5cf1d-117">DirectX は、3D ゲームなど、高パフォーマンスを必要とするゲームやマルチメディア アプリケーションを作成するための、ネイティブ API のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-117">DirectX is a collection of native APIs for creating games and multimedia applications that require high performance, such as 3D games.</span></span>

## <a name="development-environment"></a><span data-ttu-id="5cf1d-118">開発環境</span><span class="sxs-lookup"><span data-stu-id="5cf1d-118">Development Environment</span></span>


<span data-ttu-id="5cf1d-119">UWP 用のゲームを作成するには、Visual Studio 2015 以降をインストールして開発環境をセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-119">To create games for UWP, you'll need to set up your development environment by installing Visual Studio 2015 and later.</span></span> <span data-ttu-id="5cf1d-120">Visual Studio 2015 を使うことによって、UWP アプリを作成でき、ゲーム開発用のツールが提供されます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-120">Visual Studio 2015 allows you to create UWP apps and provides tools for game development:</span></span>

-   <span data-ttu-id="5cf1d-121">Visual Studio の DX ゲームのプログラミング用ツール: Visual Studio には、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするためのツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-121">Visual Studio tools for DX game programming - Visual Studio provides tools for creating, editing, previewing, and exporting image, model, and shader resources.</span></span> <span data-ttu-id="5cf1d-122">また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-122">There are also tools that you can use to convert resources at build time and debug DirectX graphics code.</span></span> <span data-ttu-id="5cf1d-123">詳しくは、「[ゲーム プログラミング用の Visual Studio ツールの使用](set-up-visual-studio-for-game-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-123">For more information, see [Use Visual Studio tools for game programming](set-up-visual-studio-for-game-development.md).</span></span>
-   <span data-ttu-id="5cf1d-124">Visual Studio グラフィックス診断機能: オプション機能として、グラフィックス診断ツールを Windows 内から利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-124">Visual Studio graphics diagnostics features - Graphics diagnostic tools are now available from within Windows as an optional feature.</span></span> <span data-ttu-id="5cf1d-125">診断ツールを使って、グラフィックス デバッグやグラフィックス フレーム分析を実行し、リアルタイムで GPU 使用率を監視できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-125">The diagnostic tools allow you to do graphics debugging, graphics frame analysis, and monitor GPU usage in real time.</span></span> <span data-ttu-id="5cf1d-126">詳しくは、「[DirectX ランタイムと Visual Studio グラフィックス診断機能の使用](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-126">For more information, see [Use the DirectX runtime and Visual Studio graphics diagnostic features](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md).</span></span>

<span data-ttu-id="5cf1d-127">詳しくは、「ユニバーサル Windows プラットフォームと [DirectX プログラミング](directx-programming.md)環境の準備」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-127">For more information, see Prepare your Universal Windows Platform and [DirectX programming](directx-programming.md).</span></span>

## <a name="getting-started-with-directx-game-project-templates"></a><span data-ttu-id="5cf1d-128">DirectX ゲーム プロジェクト テンプレートの概要</span><span class="sxs-lookup"><span data-stu-id="5cf1d-128">Getting Started with DirectX Game Project Templates</span></span>


<span data-ttu-id="5cf1d-129">開発環境をセットアップすると、DirectX 関連のプロジェクト テンプレートのいずれかを使って UWP DirectX ゲームを作成できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-129">After setting up you development environment, you can use one of the DirectX related project templates to create your UWP DirectX game.</span></span> <span data-ttu-id="5cf1d-130">Visual Studio 2015 には、新しい UWP DirectX プロジェクトを作成するためのテンプレートとして、**DirectX 11 アプリ (ユニバーサル Windows)**、**DirectX 12 アプリ (ユニバーサル Windows)**、**DirectX 11 および XAML アプリ (ユニバーサル Windows)** の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-130">Visual Studio 2015 has three templates available for creating new UWP DirectX projects, **DirectX 11 App (Universal Windows)**, **DirectX 12 App (Universal Windows)**, and **DirectX 11 and XAML App (Universal Windows)**.</span></span> <span data-ttu-id="5cf1d-131">詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-131">For more information, see [Create a Universal Windows Platform and DirectX game project from a template](user-interface.md).</span></span>

## <a name="windows-10-apis"></a><span data-ttu-id="5cf1d-132">Windows 10 API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-132">Windows 10 APIs</span></span>


<span data-ttu-id="5cf1d-133">Windows 10 では、ゲーム開発に役立つさまざまな API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-133">Windows 10 provides a an extensive collection of APIs that are useful for game development.</span></span> <span data-ttu-id="5cf1d-134">3D グラフィックス、2D グラフィックス、オーディオ、入力、テキスト リソース、ユーザー インターフェイス、ネットワークなど、ゲームのほとんどすべての側面にかかわる API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-134">There are APIs for almost all aspects of games including, 3D Graphics, 2D Graphics, Audio, Input, Text Resources, User Interface, and networking.</span></span>

<span data-ttu-id="5cf1d-135">ゲーム開発に関連する API は数多くありますが、すべてのゲームですべての API を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-135">There are many APIs related to game development, but not all games need to use all of the APIs.</span></span> <span data-ttu-id="5cf1d-136">たとえば、3D グラフィックスと Direct3D のみを利用するゲームもあれば、2D グラフィックスと Direct2D のみを利用するゲームもあります。また、その両方を使用するゲームもあります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-136">For example, some games will only use 3D graphics and only make use of Direct3D, some games may only use 2D graphics and only make use of Direct2D, and still other games may make use of both.</span></span> <span data-ttu-id="5cf1d-137">次の図は、ゲーム開発に関連する API を機能別にグループ分けしています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-137">The following diagram shows the game development related APIs grouped by functionality type.</span></span>

![ゲーム プラットフォーム テクノロジ](images/gameplatformtechnologies.png)

-   <span data-ttu-id="5cf1d-139">3D グラフィックス: Windows 10 では、Direct3D 11 と [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) の 2 つの 3D グラフィックス API セットをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-139">3D Graphics - Windows 10 supports two 3D graphics API sets, Direct3D 11, and [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121).</span></span> <span data-ttu-id="5cf1d-140">これら API はいずれも、3D および 2D グラフィックスを作成する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-140">Both of these APIs provide the capability to create 3D and 2D graphics.</span></span> <span data-ttu-id="5cf1d-141">Direct3D 11 と Direct3D 12 を同時に使うことはありませんが、いずれも 2D グラフィックスおよび UI グループのすべての API と共に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-141">Direct3D 11 and Direct3D 12 are not used together, but either can be used with any of the APIs in the 2D Graphics and UI group.</span></span> <span data-ttu-id="5cf1d-142">ゲームでグラフィックス API を使う方法について詳しくは、「[DirectX ゲームの基本的な 3D グラフィックス](an-introduction-to-3d-graphics-with-directx.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-142">For more information about using the graphics APIs in your game, see [Basic 3D graphics for DirectX games](an-introduction-to-3d-graphics-with-directx.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-143">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-143">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-144">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-144">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-145">Direct3D 12</span><span class="sxs-lookup"><span data-stu-id="5cf1d-145">Direct3D 12</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-146">Direct3D 12 では、DirectX の核となる 3D グラフィックス API である Direct3D の次期バージョンが導入されます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-146">Direct3D 12 introduces the next version of Direct3D, the 3D graphics API at the heart of DirectX.</span></span> <span data-ttu-id="5cf1d-147">このバージョンの Direct3D は、以前のバージョンの Direct3D よりも高速かつ効率的になるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-147">This version of Direct3D is designed to be faster and more efficient than previous versions of Direct3D.</span></span> <span data-ttu-id="5cf1d-148">Direct3D 12 の速度の向上のトレードオフは、より下位レベルで動作することであり、グラフィックス リソースを自分で管理する必要があることです。また、速度の向上を実現するには、広範なグラフィックスのプログラミングの経験が必要です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-148">The tradeoff for Direct3D 12's increased speed is that it is lower level and requires you to manage your graphics resources yourself and have more extensive graphics programming experience to realize the increased speed.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-149">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-149">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-150">Direct3D 12 は、ゲームのパフォーマンスを最大化する必要があり、ゲームが CPU バウンドである場合に使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-150">Use Direct3D 12 when you need to maximize your game's performance and your game is CPU bound.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-151">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-151">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-152">[Direct3d 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-152">See the [Direct3d 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-153">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="5cf1d-153">Direct3D 11</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-154">Direct3D 11 は、以前のバージョンの Direct3D であり、D3D 12 より上位レベルのハードウェア アブストラクションを使用して 3D グラフィックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-154">Direct3D 11 is the previous version of Direct3D and allows you to create 3D graphics using a higher level of hardware abstraction than D3D 12.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-155">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-155">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-156">Direct3D 11 のコードが既にある場合、ゲームが CPU バウンドではない場合、またはリソースが自動的に管理されるメリットが必要な場合は、Direct3D 11 を使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-156">Use Direct3D 11 if you have existing Direct3D 11 code, your game is not CPU bound, or you want the benefit of having resources managed for you.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-157">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-157">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-158">[Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476080) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-158">See the [Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476080) documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-159">2D グラフィックスおよび UI API: テキストやユーザー インターフェイスなどの 2D グラフィックスに関する API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-159">2D Graphics and UI - APIs concerning 2D graphics such as text and user interfaces.</span></span> <span data-ttu-id="5cf1d-160">すべての 2D グラフィックスおよび UI API はオプションです。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-160">All of the 2D graphics and UI APIs are optional.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-161">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-161">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-162">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-162">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-163">Direct2D</span><span class="sxs-lookup"><span data-stu-id="5cf1d-163">Direct2D</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-164">Direct2D は、2D ジオメトリ、ビットマップ、テキストの高パフォーマンスかつ高品質のレンダリングを実現する、ハードウェア アクセラレータによる、即時モードの 2D グラフィックス API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-164">Direct2D is a hardware-accelerated, immediate-mode, 2-D graphics API that provides high performance and high-quality rendering for 2-D geometry, bitmaps, and text.</span></span> <span data-ttu-id="5cf1d-165">Direct2D API は Direct3D を基にして構築されており、GDI、GDI+、Direct3D とも適切に相互運用できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-165">The Direct2D API is built on Direct3D and is designed to interoperate well with GDI, GDI+, and Direct3D.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-166">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-166">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-167">Direct2D は、横スクロール ゲームやボード ゲームなどの純粋な 2D ゲーム用のグラフィックスを提供するために、Direct3D の代わりに使うことができます。また、ユーザー インターフェイスやヘッドアップ ディスプレイなど、3D ゲーム内での 2D グラフィックスの作成を簡素化するために Direct3D と共に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-167">Direct2D can be used instead of Direct3D to provide graphics for pure 2D games such as a side-scroller or board game, or can be used with Direct3D to simplify creation of 2D graphics in a 3D game, such as a user interface or heads-up-display.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-168">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-168">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-169">[Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-169">See the [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-170">DirectWrite</span><span class="sxs-lookup"><span data-stu-id="5cf1d-170">DirectWrite</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-171">DirectWrite は、テキストを操作するための追加の機能を提供します。Direct3D や Direct2D と共に使用して、ユーザー インターフェイスや、テキストが必要なその他の領域にテキスト出力を提供できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-171">DirectWrite provides extra capabilities for working with text and can be used with Direct3D or Direct2D to provide text output for user interfaces or other areas where text is required.</span></span> <span data-ttu-id="5cf1d-172">DirectWrite は、複数形式のテキストの測定、描画、ヒット テストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-172">DirectWrite supports measuring, drawing, and hit-testing of multi-format text.</span></span> <span data-ttu-id="5cf1d-173">DirectWrite は、グローバル アプリケーションとローカライズされたアプリケーションで、サポートされているすべての言語のテキストを処理します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-173">DirectWrite handles text in all supported languages for global and localized applications.</span></span> <span data-ttu-id="5cf1d-174">DirectWrite は、独自のレイアウトと Unicode からグリフへの処理を実行する必要がある開発者に、下位レベルのグリフ レンダリング API も提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-174">DirectWrite also provides a low-level glyph rendering API for developers who want to perform their own layout and Unicode-to-glyph processing.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-175">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-175">When to use</span></span></strong></p>
    <p></p>
    <p><strong><span data-ttu-id="5cf1d-176">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-176">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-177">[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-177">See the [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-178">DirectComposition</span><span class="sxs-lookup"><span data-stu-id="5cf1d-178">DirectComposition</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-179">DirectComposition は、変換、効果、アニメーションを使って、高パフォーマンスのビットマップ合成を実現できる Windows コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-179">DirectComposition is a Windows component that enables high-performance bitmap composition with transforms, effects, and animations.</span></span> <span data-ttu-id="5cf1d-180">アプリケーション開発者は、DirectComposition API によって、ビジュアル要素間で機能豊富で柔軟な切り替えのアニメーションを使った、視覚的に魅力のあるユーザー インターフェイスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-180">Application developers can use the DirectComposition API to create visually engaging user interfaces that feature rich and fluid animated transitions from one visual to another.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-181">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-181">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-182">DirectComposition は、視覚要素を合成し、切り替えのアニメーションを作成するプロセスを簡略化するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-182">DirectComposition is designed to simplify the process of composing visuals and creating animated transitions.</span></span> <span data-ttu-id="5cf1d-183">複雑なユーザー インターフェイスがゲームに必要な場合、DirectComposition を使って、簡単に UI を作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-183">If your game requires complex user interfaces, you can use DirectComposition to simplify the creation and management of the UI.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-184">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-184">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-185">[DirectComposition](https://msdn.microsoft.com/library/windows/desktop/hh437371) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-185">See the [DirectComposition](https://msdn.microsoft.com/library/windows/desktop/hh437371) documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-186">オーディオ: オーディオの再生やオーディオ エフェクトの適用に関する API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-186">Audio - APIs concerning playing audio and applying audio effects.</span></span> <span data-ttu-id="5cf1d-187">ゲームでオーディオ API を使う方法について詳しくは、「[ゲームのオーディオ](working-with-audio-in-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-187">For information about using the audio APIs in your game, see [Audio for games](working-with-audio-in-your-directx-game.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-188">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-188">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-189">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-189">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-190">XAudio2</span><span class="sxs-lookup"><span data-stu-id="5cf1d-190">XAudio2</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-191">XAudio2 は、信号処理とミキシングの基礎を提供する下位レベルのオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-191">XAudio2 is a low-level audio API that provides a foundation for signal processing and mixing.</span></span> <span data-ttu-id="5cf1d-192">XAudio は、カスタム オーディオ エフェクトや、オーディオ エフェクトとフィルターの複雑なチェーンを作成する機能を維持しながら、ゲーム オーディオ エンジンに対する応答性が高くなるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-192">XAudio is designed to be very responsive for game audio engines while maintaining the ability to create custom audio effects and complex chains of audio effects and filters.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-193">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-193">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-194">ゲームでオーバーヘッドと遅延を最小限に抑えながらサウンドを再生する必要がある場合、XAudio2 を使用します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-194">Use XAudio2 when your game needs to play sounds with minimal overhead and delay.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-195">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-195">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-196">[XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-196">See the [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-197">メディア ファンデーション</span><span class="sxs-lookup"><span data-stu-id="5cf1d-197">Media Foundation</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-198">Microsoft メディア ファンデーションは、オーディオとビデオの両方のメディア ファイルやストリームの再生用として設計されていますが、XAudio2 よりも高いレベルの機能が必要とされている場合や、追加のオーバーヘッドを許容できる場合にゲームで利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-198">Microsoft Media Foundation is designed for the playback of media files and streams, both audio and video, but can also be used in games when higher level functionality than XAudio2 is required and some additional overhead is acceptable.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-199">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-199">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-200">メディア ファンデーションは、特に、ゲーム中の映画的なシーンや非対話型のコンポーネントに利用できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-200">Media foundation is particularly useful for cinematic scenes or non-interactive components of your game.</span></span> <span data-ttu-id="5cf1d-201">また、メディア ファンデーションは、XAudio2 を使って再生するオーディオ ファイルをデコードするのに便利です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-201">Media foundation is also useful for decoding audio files for playback using XAudio2.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-202">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-202">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-203">「[Microsoft メディア ファンデーションの概要](https://msdn.microsoft.com/library/windows/desktop/ms694197)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-203">See the [Microsoft Media Foundation overview](https://msdn.microsoft.com/library/windows/desktop/ms694197).</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-204">入力: キーボード、マウス、ゲームパッド、その他のユーザー入力ソースからの入力に関する API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-204">Input - APIs concerning input from the keyboard, mouse, gamepad, and other user input sources.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-205">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-205">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-206">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-206">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-207">XInput</span><span class="sxs-lookup"><span data-stu-id="5cf1d-207">XInput</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-208">XInput ゲーム コント ローラー API によって、アプリケーションでゲーム コントローラーからの入力を受信できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-208">The XInput Game Controller API enables applications to receive input from game controllers.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-209">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-209">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-210">ゲームでゲームパッドからの入力をサポートする必要がある場合や、XInput のコードが既にある場合は、引き続き XInput を利用できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-210">If your game needs to support gampad input and you have existing XInput code, you can continue to make use of XInput.</span></span> <span data-ttu-id="5cf1d-211">UWP の場合、XInput は Windows.Gaming.Input に置き換えられたため、新しい入力コードを記述する場合は、XInput ではなく Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-211">XInput has been replaced by Windows.Gaming.Input for UWP, and if you're writing new input code, you should use Windows.Gaming.Input instead of XInput.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-212">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-212">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-213">[XInput](https://msdn.microsoft.com/library/windows/desktop/hh405053) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-213">See the [XInput](https://msdn.microsoft.com/library/windows/desktop/hh405053) documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-214">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="5cf1d-214">Windows.Gaming.Input</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-215">Windows.Gaming.Input API は XInput を置き換える API であり、同じ機能を提供すると共に、XInput に比べて次のような利点があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-215">The Windows.Gaming.Input API replaces XInput and provides the same functionality with the following advantages over Xinput:</span></span></p>
    <ul>
    <li><span data-ttu-id="5cf1d-216">リソースの使用量が少ない</span><span class="sxs-lookup"><span data-stu-id="5cf1d-216">Lower resource usage</span></span></li>
    <li><span data-ttu-id="5cf1d-217">入力を取得するための API 呼び出しの待ち時間が短い</span><span class="sxs-lookup"><span data-stu-id="5cf1d-217">Lower API call latency for retrieving input</span></span></li>
    <li><span data-ttu-id="5cf1d-218">同時に 4 つ以上のゲームパッドを処理する機能</span><span class="sxs-lookup"><span data-stu-id="5cf1d-218">The ability to work with more than 4 gamepads at once</span></span></li>
    <li><span data-ttu-id="5cf1d-219">トリガー バイブレーション モーターなど、追加の Xbox One ゲームパッド機能にアクセスする機能</span><span class="sxs-lookup"><span data-stu-id="5cf1d-219">The ability to access addition Xbox One gamepad features, such as the trigger vibration motors</span></span></li>
    <li><span data-ttu-id="5cf1d-220">コントローラー接続/切断をポーリングではなくイベントで通知する機能</span><span class="sxs-lookup"><span data-stu-id="5cf1d-220">The ability to be notified when controllers connect/disconnect via event instead of polling</span></span></li>
    <li><span data-ttu-id="5cf1d-221">入力を特定のユーザー (Windows.System.User) に関連付ける機能</span><span class="sxs-lookup"><span data-stu-id="5cf1d-221">The ability to attribute input to a specific user (Windows.System.User)</span></span></li>
    </ul>
    <p><strong><span data-ttu-id="5cf1d-222">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-222">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-223">ゲームでゲームパッド入力をサポートする必要があるが、XInput の既存のコードを使っていない場合や、上に示したメリットのいずれかが必要である場合は、Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-223">If your game needs to support gamepad input and is not using existing XInput code or you need one of the benefits listed above, you should make use of Windows.Gaming.Input.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-224">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-224">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-225">「<strong>Windows.Gaming.Input</strong> (https://msdn.microsoft.com/library/windows/apps/dn707817)」のドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-225">See the [<strong>Windows.Gaming.Input</strong>](https://msdn.microsoft.com/library/windows/apps/dn707817) documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-226">Windows.UI.Core.CoreWindow</span><span class="sxs-lookup"><span data-stu-id="5cf1d-226">Windows.UI.Core.CoreWindow</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-227">Windows.UI.Core.CoreWindow クラスは、ポインターのボタンの押下や移動を追跡するためのイベント、キーの押下やリリースのイベントを提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-227">The Windows.UI.Core.CoreWindow class provides events for tracking pointer presses and movement, and key down and key up events.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-228">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-228">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-229">ゲームでマウスやキーの押下を追跡する必要がある場合、Windows.UI.Core.CoreWindows のイベントを使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-229">Use Windows.UI.Core.CoreWindows events when you need to track the mouse or key presses in your game.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-230">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-230">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-231">ゲームでマウスやキーボードを使う方法について詳しくは、「[ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-231">See [Move-look controls for games](tutorial--adding-move-look-controls-to-your-directx-game.md) for more information about using the mouse or keyboard in your game.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-232">数値演算: 一般的に使用される数値演算の簡素化に関する API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-232">Math - APIs concerning simplifying commonly used mathematical operations.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-233">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-233">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-234">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-234">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-235">DirectXMath</span><span class="sxs-lookup"><span data-stu-id="5cf1d-235">DirectXMath</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-236">DirectXMath API は、ゲームで一般的な線形代数およびグラフィックスの数値演算用の SIMD フレンドリな C++ の型および関数を提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-236">The DirectXMath API provides SIMD-friendly C++ types and functions for common linear algebra and graphics math operations common to games.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-237">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-237">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-238">DirectXMath の使用はオプションであり、一般的な数値演算を簡素化します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-238">Use of DirectXMath is optional and simplifies common mathematical operations.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-239">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-239">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-240">[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-240">See the [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-241">ネットワーク: インターネットまたはプライベート ネットワーク上の他のコンピューターやデバイスとの通信に関する API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-241">Networking - APIs concerning communicating with other computers and devices over either the Internet or private networks.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-242">API</span><span class="sxs-lookup"><span data-stu-id="5cf1d-242">API</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-243">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-243">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-244">Windows.Networking.Sockets</span><span class="sxs-lookup"><span data-stu-id="5cf1d-244">Windows.Networking.Sockets</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-245">Windows.Networking.Sockets 名前空間は、信頼性の高いまたは信頼性の低いネットワーク通信を実現する TCP および UDP ソケットを提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-245">The Windows.Networking.Sockets namespace provides TCP and UDP sockets that allow reliable or unreliable network communication.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-246">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-246">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-247">Windows.Networking.Sockets は、ゲームがネットワーク経由で他のコンピューターやデバイスと通信する必要がある場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-247">Use Windows.Networking.Sockets if your game needs to communicate with other computers or devices over the network.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-248">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-248">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-249">「[ゲームでのネットワークの使用](work-with-networking-in-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-249">See [Work with networking in your game](work-with-networking-in-your-directx-game.md).</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-250">Windows.Web.HTTP</span><span class="sxs-lookup"><span data-stu-id="5cf1d-250">Windows.Web.HTTP</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-251">Windows.Web.HTTP 名前空間では、Web サイトへのアクセスに利用できる、HTTP サーバーへの信頼性の高い接続を実現できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-251">The Windows.Web.HTTP namespace provides a reliable connection to HTTP servers that can be used to access a web site.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-252">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-252">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-253">ゲームで Web サイトにアクセスして情報を取得または保存する必要がある場合に、Windows.Web.HTTP を使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-253">Use Windows.Web.HTTP when your game needs to access a web site to retrieve or store information.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-254">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-254">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-255">「[ゲームでのネットワークの使用](work-with-networking-in-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-255">See [Work with networking in your game](work-with-networking-in-your-directx-game.md).</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="5cf1d-256">サポート ユーティリティ: Windows 10 API に基づいて構築されたライブラリです。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-256">Support Utilities - Libraries that build on the Windows 10 APIs.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="5cf1d-257">ライブラリ</span><span class="sxs-lookup"><span data-stu-id="5cf1d-257">Library</span></span></th>
    <th align="left"><span data-ttu-id="5cf1d-258">説明</span><span class="sxs-lookup"><span data-stu-id="5cf1d-258">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="5cf1d-259">DirectX ツール キット</span><span class="sxs-lookup"><span data-stu-id="5cf1d-259">DirectX Tool Kit</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-260">DirectX ツール キット (DirectXTK) は、C++ で DirectX 11.x コードを作成するためのヘルパー クラスのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-260">The DirectX Tool Kit (DirectXTK) is a collection of helper classes for writing DirectX 11.x code in C++.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-261">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-261">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-262">C++ を使っている開発者がレガシ D3DX ユーティリティ コードに代わる最新のユーティリティを探している場合や、XNA Game Studio を使っている開発者がネイティブ C++ に移行する場合に、DirectX ツール キットを使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-262">Use the DirectX Tool Kit if you're a C++ developer looking for a modern replacement to the legacy D3DX utility code or you're an XNA Game Studio developer transitioning to native C++.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-263">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-263">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-264">DirectX ツール キット プロジェクトのページ [https://github.com/Microsoft/DirectXTK](https://github.com/Microsoft/DirectXTK) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-264">See the DirectX Tool Kit project page, [https://github.com/Microsoft/DirectXTK](https://github.com/Microsoft/DirectXTK).</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="5cf1d-265">Win2D</span><span class="sxs-lookup"><span data-stu-id="5cf1d-265">Win2D</span></span></td>
    <td align="left"><p><span data-ttu-id="5cf1d-266">Win2D は、即時モードの 2D グラフィックス レンダリング用の、使いやすい Windows ランタイム API です。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-266">Win2D is an easy-to-use Windows Runtime API for immediate mode 2D graphics rendering.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-267">使う状況</span><span class="sxs-lookup"><span data-stu-id="5cf1d-267">When to use</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-268">C++ を使っている開発者が Direct2D と DirectWrite の使いやすい WinRT ラッパーを必要としている場合や、C# を使っている開発者が Direct2D と DirectWrite を使う必要がある場合に、Win2D を使います。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-268">Use Win2D if you're a C++ developer and want an easier to use WinRT wrapper for Direct2D and DirectWrite, or you're a C# developer wanting to use Direct2D and DirectWrite.</span></span></p>
    <p><strong><span data-ttu-id="5cf1d-269">詳細情報</span><span class="sxs-lookup"><span data-stu-id="5cf1d-269">For more information</span></span></strong></p>
    <p><span data-ttu-id="5cf1d-270">Win2D プロジェクトのページ [https://github.com/Microsoft/Win2D](https://github.com/Microsoft/Win2D) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-270">See the Win2D project page, [https://github.com/Microsoft/Win2D](https://github.com/Microsoft/Win2D).</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

## <a name="xbox-live-services"></a><span data-ttu-id="5cf1d-271">Xbox Live サービス</span><span class="sxs-lookup"><span data-stu-id="5cf1d-271">Xbox Live Services</span></span>

<span data-ttu-id="5cf1d-272">[Xbox Live クリエーターズ プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator) では、開発者はだれでも Xbox Live を自分の UWP ゲームに統合して、Xbox One や Windows 10 に公開することができます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-272">The [Xbox Live Creators Program](https://developer.microsoft.com/games/xbox/xboxlive/creator) allows any developer to integrate Xbox Live into their UWP game and publish to Xbox One and Windows 10.</span></span> <span data-ttu-id="5cf1d-273">最小限の開発時間で、サインイン、プレゼンス、ランキングなどの Xbox Live ソーシャル エクスペリエンスをタイトルに統合できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-273">Integrate Xbox Live social experiences such as sign-in, presence, leaderboards, and more into your title, with minimal development time.</span></span> <span data-ttu-id="5cf1d-274">Xbox Live のソーシャル機能では、5,500 万人以上のアクティブ ゲーマーに情報を発信して、オーディエンスを自然に増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-274">Xbox Live social features are designed to organically grow your audience, spreading awareness to over 55 million active gamers.</span></span>

<span data-ttu-id="5cf1d-275">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-275">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](http://www.xbox.com/developers/id) program.</span></span> <span data-ttu-id="5cf1d-276">Xbox Live クリエーターズ プログラム、および ID@Xbox プログラムで利用できる機能については、[機能表](../xbox-live/developer-program-overview.md#feature-table)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-276">To see which features are available to the Xbox Live Creators Program and ID@Xbox program, see the [Feature table](../xbox-live/developer-program-overview.md#feature-table).</span></span>

<span data-ttu-id="5cf1d-277">詳しくは、「[ゲームへの Xbox Live の追加](e2e.md#adding-xbox-live-to-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-277">For more info, go to [Adding Xbox Live to your game](e2e.md#adding-xbox-live-to-your-game).</span></span>

##  <a name="alternatives-to-writing-games-with-directx-and-uwp"></a><span data-ttu-id="5cf1d-278">DirectX と UWP を使ったゲーム作成の代替手段</span><span class="sxs-lookup"><span data-stu-id="5cf1d-278">Alternatives to writing games with DirectX and UWP</span></span>


### <a name="uwp-games-without-directx"></a><span data-ttu-id="5cf1d-279">DirectX を使わない UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="5cf1d-279">UWP Games without DirectX</span></span>

<span data-ttu-id="5cf1d-280">カード ゲームやボード ゲームなど、最低限のパフォーマンスの要件を満たす単純なゲームは、DirectX を使わずに作成でき、必ずしも C++ で記述されている必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-280">Simpler games with minimal performance requirements, such as card games or board games, can be written without DirectX and don't necessarily need to be written in C++.</span></span> <span data-ttu-id="5cf1d-281">このような種類のゲームでは、C#、Visual Basic、C++、HTML/JavaScript など、UWP でサポートされている言語のいずれかを利用できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-281">These sort of games can make use of any of the languages supported by UWP such as C#, Visual Basic, C++, and HTML/JavaScript.</span></span> <span data-ttu-id="5cf1d-282">パフォーマンスと負荷の高いグラフィックスがゲームで必要な場合は、[JavaScript と HTML5 のタッチ ゲームのサンプル](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-282">If performance and intensive graphics are not a requirement for your game, checkout [JavaScript and HTML5 touch game sample](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031) as an example.</span></span>

### <a name="game-engines"></a><span data-ttu-id="5cf1d-283">ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="5cf1d-283">Game Engines</span></span>

<span data-ttu-id="5cf1d-284">Windows ゲーム開発 API を使って独自のゲーム エンジンを作成する代替手段として、Windows ゲーム開発 API を基にして作成された多くの高品質ゲーム エンジンを、Windows プラットフォームでのゲームの開発に利用できます。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-284">As an alternative to writing your own game engine using the Windows game development APIs, many high quality game engines that build on the Windows game development APIs are available for developing games on Windows platforms.</span></span> <span data-ttu-id="5cf1d-285">ゲーム エンジンまたはライブラリを検討する場合、複数のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-285">When considering a game engine or library, you have multiple options:</span></span>

-   <span data-ttu-id="5cf1d-286">フル ゲーム エンジン: フル ゲーム エンジンは、ゲーム エンジンをゼロから作成する場合に使用する、グラフィックス、オーディオ、入力、ネットワークなどの Windows 10 API のほとんどまたはすべてをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-286">Full game engine - A full game engine encapsulates most or all of the Windows 10 APIs you would use when writing a game engine from scratch, such as graphics, audio, input, and networking.</span></span> <span data-ttu-id="5cf1d-287">また、フル ゲーム エンジンは、人工知能や経路探索などのゲーム ロジック機能も備えています。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-287">Full game engines may also provide game logic functionality such as artificial intelligence and pathfinding.</span></span>
-   <span data-ttu-id="5cf1d-288">グラフィックス エンジン: グラフィックス エンジンは、Windows 10 のグラフィックス API をカプセル化して、グラフィックス リソースを管理し、さまざまなモデルとワールドの形式をサポートします。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-288">Graphics engine - Graphics engines encapsulate the Windows 10 graphics APIs, manage graphics resources, and support a variety of model and world formats.</span></span>
-   <span data-ttu-id="5cf1d-289">オーディオ エンジン: オーディオ エンジンは Windows 10 のオーディオ API をカプセル化して、オーディオ リソースを管理し、高度なオーディオ処理とエフェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-289">Audio engine - Audio engines encapsulate the Windows 10 audio APIs, manage audio resources, and provide advanced audio processing and effects.</span></span>
-   <span data-ttu-id="5cf1d-290">ネットワーク エンジン: ネットワーク エンジンは、Windows 10 のネットワーク API をカプセル化して、ピア ツー ピアまたはサーバー ベースのマルチプレイヤーのサポートをゲームに追加します。また、多数のプレイヤーをサポートするための高度なネットワーク機能が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-290">Network engine - Network engines encapsulate Windows 10 networking APIs for adding peer-to-peer or server-based multiplayer support to your game, and may include advanced networking functionality to support large numbers of players.</span></span>
-   <span data-ttu-id="5cf1d-291">人工知能と経路探索エンジン: AI と経路探索エンジンは、ゲーム内でエージェントの動作を制御するためのフレームワークを提供します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-291">Artificial intelligence and pathfinding engine - AI and pathfinding engines provide a framework for controlling the behavior of agents in your game.</span></span>
-   <span data-ttu-id="5cf1d-292">特殊な用途のエンジン: インベントリ システムやダイアログ ツリーなど、発生する可能性があるほぼすべてのゲーム開発関連タスクを処理するために、さまざまな追加のエンジンが存在します。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-292">Special purpose engines - A variety of additional engines exist for handling almost any game development related task you might run into, such as creating inventory systems and dialog trees.</span></span>

## <a name="submitting-a-game-to-the-store"></a><span data-ttu-id="5cf1d-293">ストアへのゲームの提出</span><span class="sxs-lookup"><span data-stu-id="5cf1d-293">Submitting a game to the Store</span></span>


<span data-ttu-id="5cf1d-294">ゲームを公開する準備ができたら、開発者アカウントを作成して、ゲームを Windows ストアに提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-294">Once you’re ready to publish your game, you’ll need to create a developer account and submit your game to the Windows Store.</span></span>

<span data-ttu-id="5cf1d-295">Windows ストアへのゲームの提出については、「[ゲームの申請と公開](e2e.md#submitting-and-publishing-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5cf1d-295">For information about submitting your game to the Windows Store, see [Submitting and publishing your game](e2e.md#submitting-and-publishing-your-game).</span></span>

 

 




