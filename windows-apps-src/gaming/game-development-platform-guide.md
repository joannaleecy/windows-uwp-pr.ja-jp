---
author: mtoepke
title: ユニバーサル Windows プラットフォーム (UWP) アプリのゲーム テクノロジ
description: このガイドでは、ユニバーサル Windows プラットフォーム UWP ゲームの開発に利用できるテクノロジについて説明します。
ms.assetid: bc4d4648-0d6e-efbb-7608-80bd09decd6e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, テクノロジ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 496e0f8386b60247090035d4c4d1f7aa986f8560
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690758"
---
# <a name="game-technologies-for-uwp-apps"></a><span data-ttu-id="fb006-104">UWP アプリのゲーム テクノロジ</span><span class="sxs-lookup"><span data-stu-id="fb006-104">Game technologies for UWP apps</span></span>



<span data-ttu-id="fb006-105">このガイドでは、ユニバーサル Windows プラットフォーム (UWP) ゲームの開発に利用できるテクノロジについて説明します。</span><span class="sxs-lookup"><span data-stu-id="fb006-105">In this guide, you'll learn about the technologies available for developing Universal Windows Platform (UWP) games.</span></span>

##  <a name="benefits-of-windows-10-for-game-development"></a><span data-ttu-id="fb006-106">ゲーム開発向けの Windows 10 のメリット</span><span class="sxs-lookup"><span data-stu-id="fb006-106">Benefits of Windows 10 for game development</span></span>


<span data-ttu-id="fb006-107">Windows 10 で UWP が導入されたことにより、作成した Windows 10 のタイトルはすべての Microsoft プラットフォームに対応できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-107">With the introduction of UWP in Windows 10, your Windows 10 titles will be able to span all of the Microsoft platforms.</span></span> <span data-ttu-id="fb006-108">以前のバージョンの Windows から無料で移行できるため、Windows 10 のユーザー数は着実に増加しています。</span><span class="sxs-lookup"><span data-stu-id="fb006-108">With free migration from previous versions of Windows, there is a steadily increasing number of Windows 10 clients.</span></span> <span data-ttu-id="fb006-109">これらの 2 つの事実を組み合わせると、Windows 10 のタイトルは、Microsoft Store を通じて膨大な数のユーザーに提供できることを意味します。</span><span class="sxs-lookup"><span data-stu-id="fb006-109">The combination of these two things means that your Windows 10 titles will be able to reach a huge number of customers through the Microsoft Store.</span></span>

<span data-ttu-id="fb006-110">また Windows 10 には、特にゲームに便利な、多くの新しい機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-110">In addition, Windows 10 offers many new features that are particularly beneficial to games:</span></span>

-   <span data-ttu-id="fb006-111">メモリのページングの削減および全体的なメモリ システム サイズの削減</span><span class="sxs-lookup"><span data-stu-id="fb006-111">Reduced memory paging and reduced overall memory system size</span></span>
-   <span data-ttu-id="fb006-112">グラフィックス メモリの管理機能の向上により、フォアグラウンドのゲームに、より多くのメモリがアクティブに割り当てられ、保護されます。</span><span class="sxs-lookup"><span data-stu-id="fb006-112">Improved graphics memory management actively allocates and protects more memory for the foreground game</span></span>

## <a name="uwp-games-with-c-and-directx"></a><span data-ttu-id="fb006-113">C++ と DirectX を使った UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="fb006-113">UWP Games with C++ and DirectX</span></span>


<span data-ttu-id="fb006-114">高パフォーマンスを必要とするリアルタイム ゲームでは、DirectX API を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-114">Real-time games requiring high performance should make use of the DirectX APIs.</span></span> <span data-ttu-id="fb006-115">DirectX は、3D ゲームなど、高パフォーマンスを必要とするゲームやマルチメディア アプリケーションを作成するための、ネイティブ API のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="fb006-115">DirectX is a collection of native APIs for creating games and multimedia applications that require high performance, such as 3D games.</span></span>

## <a name="development-environment"></a><span data-ttu-id="fb006-116">開発環境</span><span class="sxs-lookup"><span data-stu-id="fb006-116">Development Environment</span></span>


<span data-ttu-id="fb006-117">UWP 用のゲームを作成するには、Visual Studio 2015 以降をインストールして開発環境をセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-117">To create games for UWP, you'll need to set up your development environment by installing Visual Studio 2015 and later.</span></span> <span data-ttu-id="fb006-118">Visual Studio 2015 を使うことによって、UWP アプリを作成でき、ゲーム開発用のツールが提供されます。</span><span class="sxs-lookup"><span data-stu-id="fb006-118">Visual Studio 2015 allows you to create UWP apps and provides tools for game development:</span></span>

-   <span data-ttu-id="fb006-119">Visual Studio の DX ゲームのプログラミング用ツール: Visual Studio には、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするためのツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-119">Visual Studio tools for DX game programming - Visual Studio provides tools for creating, editing, previewing, and exporting image, model, and shader resources.</span></span> <span data-ttu-id="fb006-120">また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。</span><span class="sxs-lookup"><span data-stu-id="fb006-120">There are also tools that you can use to convert resources at build time and debug DirectX graphics code.</span></span> <span data-ttu-id="fb006-121">詳しくは、「[ゲーム プログラミング用の Visual Studio ツールの使用](set-up-visual-studio-for-game-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-121">For more information, see [Use Visual Studio tools for game programming](set-up-visual-studio-for-game-development.md).</span></span>
-   <span data-ttu-id="fb006-122">Visual Studio グラフィックス診断機能: オプション機能として、グラフィックス診断ツールを Windows 内から利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="fb006-122">Visual Studio graphics diagnostics features - Graphics diagnostic tools are now available from within Windows as an optional feature.</span></span> <span data-ttu-id="fb006-123">診断ツールを使って、グラフィックス デバッグやグラフィックス フレーム分析を実行し、リアルタイムで GPU 使用率を監視できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-123">The diagnostic tools allow you to do graphics debugging, graphics frame analysis, and monitor GPU usage in real time.</span></span> <span data-ttu-id="fb006-124">詳しくは、「[DirectX ランタイムと Visual Studio グラフィックス診断機能の使用](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-124">For more information, see [Use the DirectX runtime and Visual Studio graphics diagnostic features](use-the-directx-runtime-and-visual-studio-graphics-diagnostic-features.md).</span></span>

<span data-ttu-id="fb006-125">詳しくは、「ユニバーサル Windows プラットフォームと [DirectX プログラミング](directx-programming.md)環境の準備」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-125">For more information, see Prepare your Universal Windows Platform and [DirectX programming](directx-programming.md).</span></span>

## <a name="getting-started-with-directx-game-project-templates"></a><span data-ttu-id="fb006-126">DirectX ゲーム プロジェクト テンプレートの概要</span><span class="sxs-lookup"><span data-stu-id="fb006-126">Getting Started with DirectX Game Project Templates</span></span>


<span data-ttu-id="fb006-127">開発環境をセットアップすると、DirectX 関連のプロジェクト テンプレートのいずれかを使って UWP DirectX ゲームを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-127">After setting up your development environment, you can use one of the DirectX related project templates to create your UWP DirectX game.</span></span> <span data-ttu-id="fb006-128">Visual Studio 2015 には、新しい UWP DirectX プロジェクトを作成するためのテンプレートとして、**DirectX 11 アプリ (ユニバーサル Windows)**、**DirectX 12 アプリ (ユニバーサル Windows)**、**DirectX 11 および XAML アプリ (ユニバーサル Windows)** の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="fb006-128">Visual Studio 2015 has three templates available for creating new UWP DirectX projects, **DirectX 11 App (Universal Windows)**, **DirectX 12 App (Universal Windows)**, and **DirectX 11 and XAML App (Universal Windows)**.</span></span> <span data-ttu-id="fb006-129">詳しくは、「[テンプレートからのユニバーサル Windows プラットフォームおよび DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-129">For more information, see [Create a Universal Windows Platform and DirectX game project from a template](user-interface.md).</span></span>

## <a name="windows-10-apis"></a><span data-ttu-id="fb006-130">Windows 10 API</span><span class="sxs-lookup"><span data-stu-id="fb006-130">Windows 10 APIs</span></span>


<span data-ttu-id="fb006-131">Windows 10 では、ゲーム開発に役立つさまざまな API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-131">Windows 10 provides an extensive collection of APIs that are useful for game development.</span></span> <span data-ttu-id="fb006-132">3D グラフィックス、2D グラフィックス、オーディオ、入力、テキスト リソース、ユーザー インターフェイス、ネットワークなど、ゲームのほとんどすべての側面にかかわる API が用意されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-132">There are APIs for almost all aspects of games including, 3D Graphics, 2D Graphics, Audio, Input, Text Resources, User Interface, and networking.</span></span>

<span data-ttu-id="fb006-133">ゲーム開発に関連する API は数多くありますが、すべてのゲームですべての API を使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="fb006-133">There are many APIs related to game development, but not all games need to use all of the APIs.</span></span> <span data-ttu-id="fb006-134">たとえば、3D グラフィックスと Direct3D のみを利用するゲームもあれば、2D グラフィックスと Direct2D のみを利用するゲームもあります。また、その両方を使用するゲームもあります。</span><span class="sxs-lookup"><span data-stu-id="fb006-134">For example, some games will only use 3D graphics and only make use of Direct3D, some games may only use 2D graphics and only make use of Direct2D, and still other games may make use of both.</span></span> <span data-ttu-id="fb006-135">次の図は、ゲーム開発に関連する API を機能別にグループ分けしています。</span><span class="sxs-lookup"><span data-stu-id="fb006-135">The following diagram shows the game development related APIs grouped by functionality type.</span></span>

![ゲーム プラットフォーム テクノロジ](images/gameplatformtechnologies.png)

-   <span data-ttu-id="fb006-137">3D グラフィックス: Windows 10 では、Direct3D 11 と [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121) の 2 つの 3D グラフィックス API セットをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="fb006-137">3D Graphics - Windows 10 supports two 3D graphics API sets, Direct3D 11, and [Direct3D 12](https://msdn.microsoft.com/library/windows/desktop/dn899121).</span></span> <span data-ttu-id="fb006-138">これら API はいずれも、3D および 2D グラフィックスを作成する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-138">Both of these APIs provide the capability to create 3D and 2D graphics.</span></span> <span data-ttu-id="fb006-139">Direct3D 11 と Direct3D 12 を同時に使うことはありませんが、いずれも 2D グラフィックスおよび UI グループのすべての API と共に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="fb006-139">Direct3D 11 and Direct3D 12 are not used together, but either can be used with any of the APIs in the 2D Graphics and UI group.</span></span> <span data-ttu-id="fb006-140">ゲームでグラフィックス API を使う方法について詳しくは、「[DirectX ゲームの基本的な 3D グラフィックス](an-introduction-to-3d-graphics-with-directx.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-140">For more information about using the graphics APIs in your game, see [Basic 3D graphics for DirectX games](an-introduction-to-3d-graphics-with-directx.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-141">API</span><span class="sxs-lookup"><span data-stu-id="fb006-141">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-142">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-142">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-143">Direct3D 12</span><span class="sxs-lookup"><span data-stu-id="fb006-143">Direct3D 12</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-144">Direct3D 12 では、DirectX の核となる 3D グラフィックス API である Direct3D の次期バージョンが導入されます。</span><span class="sxs-lookup"><span data-stu-id="fb006-144">Direct3D 12 introduces the next version of Direct3D, the 3D graphics API at the heart of DirectX.</span></span> <span data-ttu-id="fb006-145">このバージョンの Direct3D は、以前のバージョンの Direct3D よりも高速かつ効率的になるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-145">This version of Direct3D is designed to be faster and more efficient than previous versions of Direct3D.</span></span> <span data-ttu-id="fb006-146">Direct3D 12 の速度の向上のトレードオフは、より下位レベルで動作することであり、グラフィックス リソースを自分で管理する必要があることです。また、速度の向上を実現するには、広範なグラフィックスのプログラミングの経験が必要です。</span><span class="sxs-lookup"><span data-stu-id="fb006-146">The tradeoff for Direct3D 12's increased speed is that it is lower level and requires you to manage your graphics resources yourself and have more extensive graphics programming experience to realize the increased speed.</span></span></p>
    <p><strong><span data-ttu-id="fb006-147">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-147">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-148">Direct3D 12 は、ゲームのパフォーマンスを最大化する必要があり、ゲームが CPU バウンドである場合に使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-148">Use Direct3D 12 when you need to maximize your game's performance and your game is CPU bound.</span></span></p>
    <p><strong><span data-ttu-id="fb006-149">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-149">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-150"><a href="https://msdn.microsoft.com/library/windows/desktop/dn899121">Direct3d 12</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-150">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dn899121">Direct3d 12</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-151">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="fb006-151">Direct3D 11</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-152">Direct3D 11 は、以前のバージョンの Direct3D であり、D3D 12 より上位レベルのハードウェア アブストラクションを使用して 3D グラフィックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-152">Direct3D 11 is the previous version of Direct3D and allows you to create 3D graphics using a higher level of hardware abstraction than D3D 12.</span></span></p>
    <p><strong><span data-ttu-id="fb006-153">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-153">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-154">Direct3D 11 のコードが既にある場合、ゲームが CPU バウンドではない場合、またはリソースが自動的に管理されるメリットが必要な場合は、Direct3D 11 を使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-154">Use Direct3D 11 if you have existing Direct3D 11 code, your game is not CPU bound, or you want the benefit of having resources managed for you.</span></span></p>
    <p><strong><span data-ttu-id="fb006-155">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-155">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-156"><a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-156">See the <a href="https://msdn.microsoft.com/library/windows/desktop/ff476080">Direct3D 11</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-157">2D グラフィックスおよび UI API: テキストやユーザー インターフェイスなどの 2D グラフィックスに関する API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-157">2D Graphics and UI - APIs concerning 2D graphics such as text and user interfaces.</span></span> <span data-ttu-id="fb006-158">すべての 2D グラフィックスおよび UI API はオプションです。</span><span class="sxs-lookup"><span data-stu-id="fb006-158">All of the 2D graphics and UI APIs are optional.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-159">API</span><span class="sxs-lookup"><span data-stu-id="fb006-159">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-160">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-160">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-161">Direct2D</span><span class="sxs-lookup"><span data-stu-id="fb006-161">Direct2D</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-162">Direct2D は、2D ジオメトリ、ビットマップ、テキストの高パフォーマンスかつ高品質のレンダリングを実現する、ハードウェア アクセラレータによる、即時モードの 2D グラフィックス API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-162">Direct2D is a hardware-accelerated, immediate-mode, 2-D graphics API that provides high performance and high-quality rendering for 2-D geometry, bitmaps, and text.</span></span> <span data-ttu-id="fb006-163">Direct2D API は Direct3D を基にして構築されており、GDI、GDI+、Direct3D とも適切に相互運用できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-163">The Direct2D API is built on Direct3D and is designed to interoperate well with GDI, GDI+, and Direct3D.</span></span></p>
    <p><strong><span data-ttu-id="fb006-164">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-164">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-165">Direct2D は、横スクロール ゲームやボード ゲームなどの純粋な 2D ゲーム用のグラフィックスを提供するために、Direct3D の代わりに使うことができます。また、ユーザー インターフェイスやヘッドアップ ディスプレイなど、3D ゲーム内での 2D グラフィックスの作成を簡素化するために Direct3D と共に使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="fb006-165">Direct2D can be used instead of Direct3D to provide graphics for pure 2D games such as a side-scroller or board game, or can be used with Direct3D to simplify creation of 2D graphics in a 3D game, such as a user interface or heads-up-display.</span></span></p>
    <p><strong><span data-ttu-id="fb006-166">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-166">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-167"><a href="https://msdn.microsoft.com/library/windows/desktop/dd370990">Direct2D</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-167">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dd370990">Direct2D</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-168">DirectWrite</span><span class="sxs-lookup"><span data-stu-id="fb006-168">DirectWrite</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-169">DirectWrite は、テキストを操作するための追加の機能を提供します。Direct3D や Direct2D と共に使用して、ユーザー インターフェイスや、テキストが必要なその他の領域にテキスト出力を提供できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-169">DirectWrite provides extra capabilities for working with text and can be used with Direct3D or Direct2D to provide text output for user interfaces or other areas where text is required.</span></span> <span data-ttu-id="fb006-170">DirectWrite は、複数形式のテキストの測定、描画、ヒット テストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="fb006-170">DirectWrite supports measuring, drawing, and hit-testing of multi-format text.</span></span> <span data-ttu-id="fb006-171">DirectWrite は、グローバル アプリケーションとローカライズされたアプリケーションで、サポートされているすべての言語のテキストを処理します。</span><span class="sxs-lookup"><span data-stu-id="fb006-171">DirectWrite handles text in all supported languages for global and localized applications.</span></span> <span data-ttu-id="fb006-172">DirectWrite は、独自のレイアウトと Unicode からグリフへの処理を実行する必要がある開発者に、下位レベルのグリフ レンダリング API も提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-172">DirectWrite also provides a low-level glyph rendering API for developers who want to perform their own layout and Unicode-to-glyph processing.</span></span></p>
    <p><strong><span data-ttu-id="fb006-173">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-173">When to use</span></span></strong></p>
    <p></p>
    <p><strong><span data-ttu-id="fb006-174">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-174">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-175"><a href="https://msdn.microsoft.com/library/windows/desktop/dd368038">DirectWrite</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-175">See the <a href="https://msdn.microsoft.com/library/windows/desktop/dd368038">DirectWrite</a> documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-176">DirectComposition</span><span class="sxs-lookup"><span data-stu-id="fb006-176">DirectComposition</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-177">DirectComposition は、変換、効果、アニメーションを使って、高パフォーマンスのビットマップ合成を実現できる Windows コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="fb006-177">DirectComposition is a Windows component that enables high-performance bitmap composition with transforms, effects, and animations.</span></span> <span data-ttu-id="fb006-178">アプリケーション開発者は、DirectComposition API によって、ビジュアル要素間で機能豊富で柔軟な切り替えのアニメーションを使った、視覚的に魅力のあるユーザー インターフェイスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-178">Application developers can use the DirectComposition API to create visually engaging user interfaces that feature rich and fluid animated transitions from one visual to another.</span></span></p>
    <p><strong><span data-ttu-id="fb006-179">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-179">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-180">DirectComposition は、視覚要素を合成し、切り替えのアニメーションを作成するプロセスを簡略化するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-180">DirectComposition is designed to simplify the process of composing visuals and creating animated transitions.</span></span> <span data-ttu-id="fb006-181">複雑なユーザー インターフェイスがゲームに必要な場合、DirectComposition を使って、簡単に UI を作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-181">If your game requires complex user interfaces, you can use DirectComposition to simplify the creation and management of the UI.</span></span></p>
    <p><strong><span data-ttu-id="fb006-182">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-182">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-183"><a href="https://msdn.microsoft.com/library/windows/desktop/hh437371">DirectComposition</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-183">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh437371">DirectComposition</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-184">オーディオ: オーディオの再生やオーディオ エフェクトの適用に関する API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-184">Audio - APIs concerning playing audio and applying audio effects.</span></span> <span data-ttu-id="fb006-185">ゲームでオーディオ API を使う方法について詳しくは、「[ゲームのオーディオ](working-with-audio-in-your-directx-game.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-185">For information about using the audio APIs in your game, see [Audio for games](working-with-audio-in-your-directx-game.md).</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-186">API</span><span class="sxs-lookup"><span data-stu-id="fb006-186">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-187">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-187">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-188">XAudio2</span><span class="sxs-lookup"><span data-stu-id="fb006-188">XAudio2</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-189">XAudio2 は、信号処理とミキシングの基礎を提供する下位レベルのオーディオ API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-189">XAudio2 is a low-level audio API that provides a foundation for signal processing and mixing.</span></span> <span data-ttu-id="fb006-190">XAudio は、カスタム オーディオ エフェクトや、オーディオ エフェクトとフィルターの複雑なチェーンを作成する機能を維持しながら、ゲーム オーディオ エンジンに対する応答性が高くなるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="fb006-190">XAudio is designed to be very responsive for game audio engines while maintaining the ability to create custom audio effects and complex chains of audio effects and filters.</span></span></p>
    <p><strong><span data-ttu-id="fb006-191">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-191">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-192">ゲームでオーバーヘッドと遅延を最小限に抑えながらサウンドを再生する必要がある場合、XAudio2 を使用します。</span><span class="sxs-lookup"><span data-stu-id="fb006-192">Use XAudio2 when your game needs to play sounds with minimal overhead and delay.</span></span></p>
    <p><strong><span data-ttu-id="fb006-193">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-193">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-194"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405049">XAudio2</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-194">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh405049">XAudio2</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-195">メディア ファンデーション</span><span class="sxs-lookup"><span data-stu-id="fb006-195">Media Foundation</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-196">Microsoft メディア ファンデーションは、オーディオとビデオの両方のメディア ファイルやストリームの再生用として設計されていますが、XAudio2 よりも高いレベルの機能が必要とされている場合や、追加のオーバーヘッドを許容できる場合にゲームで利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="fb006-196">Microsoft Media Foundation is designed for the playback of media files and streams, both audio and video, but can also be used in games when higher level functionality than XAudio2 is required and some additional overhead is acceptable.</span></span></p>
    <p><strong><span data-ttu-id="fb006-197">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-197">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-198">メディア ファンデーションは、特に、ゲーム中の映画的なシーンや非対話型のコンポーネントに利用できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-198">Media foundation is particularly useful for cinematic scenes or non-interactive components of your game.</span></span> <span data-ttu-id="fb006-199">また、メディア ファンデーションは、XAudio2 を使って再生するオーディオ ファイルをデコードするのに便利です。</span><span class="sxs-lookup"><span data-stu-id="fb006-199">Media foundation is also useful for decoding audio files for playback using XAudio2.</span></span></p>
    <p><strong><span data-ttu-id="fb006-200">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-200">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-201"><a href="https://msdn.microsoft.com/library/windows/desktop/ms694197">Microsoft メディア ファンデーション</a>の概要をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-201">See the <a href="https://msdn.microsoft.com/library/windows/desktop/ms694197">Microsoft Media Foundation</a> overview.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-202">入力: キーボード、マウス、ゲームパッド、その他のユーザー入力ソースからの入力に関する API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-202">Input - APIs concerning input from the keyboard, mouse, gamepad, and other user input sources.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-203">API</span><span class="sxs-lookup"><span data-stu-id="fb006-203">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-204">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-204">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-205">XInput</span><span class="sxs-lookup"><span data-stu-id="fb006-205">XInput</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-206">XInput ゲーム コント ローラー API によって、アプリケーションでゲーム コントローラーからの入力を受信できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-206">The XInput Game Controller API enables applications to receive input from game controllers.</span></span></p>
    <p><strong><span data-ttu-id="fb006-207">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-207">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-208">ゲームでゲームパッドからの入力をサポートする必要がある場合や、XInput のコードが既にある場合は、引き続き XInput を利用できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-208">If your game needs to support gampad input and you have existing XInput code, you can continue to make use of XInput.</span></span> <span data-ttu-id="fb006-209">UWP の場合、XInput は Windows.Gaming.Input に置き換えられたため、新しい入力コードを記述する場合は、XInput ではなく Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-209">XInput has been replaced by Windows.Gaming.Input for UWP, and if you're writing new input code, you should use Windows.Gaming.Input instead of XInput.</span></span></p>
    <p><strong><span data-ttu-id="fb006-210">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-210">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-211"><a href="https://msdn.microsoft.com/library/windows/desktop/hh405053">XInput</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-211">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh405053">XInput</a> documentation.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-212">Windows.Gaming.Input</span><span class="sxs-lookup"><span data-stu-id="fb006-212">Windows.Gaming.Input</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-213">Windows.Gaming.Input API は XInput を置き換える API であり、同じ機能を提供すると共に、XInput に比べて次のような利点があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-213">The Windows.Gaming.Input API replaces XInput and provides the same functionality with the following advantages over Xinput:</span></span></p>
    <ul>
    <li><span data-ttu-id="fb006-214">リソースの使用量が少ない</span><span class="sxs-lookup"><span data-stu-id="fb006-214">Lower resource usage</span></span></li>
    <li><span data-ttu-id="fb006-215">入力を取得するための API 呼び出しの待ち時間が短い</span><span class="sxs-lookup"><span data-stu-id="fb006-215">Lower API call latency for retrieving input</span></span></li>
    <li><span data-ttu-id="fb006-216">同時に 4 つ以上のゲームパッドを処理する機能</span><span class="sxs-lookup"><span data-stu-id="fb006-216">The ability to work with more than 4 gamepads at once</span></span></li>
    <li><span data-ttu-id="fb006-217">トリガー バイブレーション モーターなど、追加の Xbox One ゲームパッド機能にアクセスする機能</span><span class="sxs-lookup"><span data-stu-id="fb006-217">The ability to access additional Xbox One gamepad features, such as the trigger vibration motors</span></span></li>
    <li><span data-ttu-id="fb006-218">コントローラー接続/切断をポーリングではなくイベントで通知する機能</span><span class="sxs-lookup"><span data-stu-id="fb006-218">The ability to be notified when controllers connect/disconnect via event instead of polling</span></span></li>
    <li><span data-ttu-id="fb006-219">入力を特定のユーザー (Windows.System.User) に関連付ける機能</span><span class="sxs-lookup"><span data-stu-id="fb006-219">The ability to attribute input to a specific user (Windows.System.User)</span></span></li>
    </ul>
    <p><strong><span data-ttu-id="fb006-220">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-220">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-221">ゲームでゲームパッド入力をサポートする必要があるが、XInput の既存のコードを使っていない場合や、上に示したメリットのいずれかが必要である場合は、Windows.Gaming.Input を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-221">If your game needs to support gamepad input and is not using existing XInput code or you need one of the benefits listed above, you should make use of Windows.Gaming.Input.</span></span></p>
    <p><strong><span data-ttu-id="fb006-222">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-222">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-223"><a href="https://msdn.microsoft.com/library/windows/apps/dn707817">Windows.Gaming.Input</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-223">See the <a href="https://msdn.microsoft.com/library/windows/apps/dn707817">Windows.Gaming.Input</a> documentation.</span></span></p></td>
    </tr>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-224">Windows.UI.Core.CoreWindow</span><span class="sxs-lookup"><span data-stu-id="fb006-224">Windows.UI.Core.CoreWindow</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-225">Windows.UI.Core.CoreWindow クラスは、ポインターのボタンの押下や移動を追跡するためのイベント、キーの押下やリリースのイベントを提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-225">The Windows.UI.Core.CoreWindow class provides events for tracking pointer presses and movement, and key down and key up events.</span></span></p>
    <p><strong><span data-ttu-id="fb006-226">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-226">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-227">ゲームでマウスやキーの押下を追跡する必要がある場合、Windows.UI.Core.CoreWindows のイベントを使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-227">Use Windows.UI.Core.CoreWindows events when you need to track the mouse or key presses in your game.</span></span></p>
    <p><strong><span data-ttu-id="fb006-228">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-228">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-229">ゲームでマウスやキーボードを使う方法について詳しくは、「<a href="https://docs.microsoft.com/windows/uwp/gaming/tutorial--adding-move-look-controls-to-your-directx-game">ゲームのムーブ/ルック コントロール</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-229">See <a href="https://docs.microsoft.com/windows/uwp/gaming/tutorial--adding-move-look-controls-to-your-directx-game">Move-look controls for games</a> for more information about using the mouse or keyboard in your game.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-230">数値演算: 一般的に使用される数値演算の簡素化に関する API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-230">Math - APIs concerning simplifying commonly used mathematical operations.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-231">API</span><span class="sxs-lookup"><span data-stu-id="fb006-231">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-232">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-232">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-233">DirectXMath</span><span class="sxs-lookup"><span data-stu-id="fb006-233">DirectXMath</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-234">DirectXMath API は、ゲームで一般的な線形代数およびグラフィックスの数値演算用の SIMD フレンドリな C++ の型および関数を提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-234">The DirectXMath API provides SIMD-friendly C++ types and functions for common linear algebra and graphics math operations common to games.</span></span></p>
    <p><strong><span data-ttu-id="fb006-235">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-235">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-236">DirectXMath の使用はオプションであり、一般的な数値演算を簡素化します。</span><span class="sxs-lookup"><span data-stu-id="fb006-236">Use of DirectXMath is optional and simplifies common mathematical operations.</span></span></p>
    <p><strong><span data-ttu-id="fb006-237">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-237">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-238"><a href="https://msdn.microsoft.com/library/windows/desktop/hh437833">DirectXMath</a> に関連するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-238">See the <a href="https://msdn.microsoft.com/library/windows/desktop/hh437833">DirectXMath</a> documentation.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-239">ネットワーク: インターネットまたはプライベート ネットワーク上の他のコンピューターやデバイスとの通信に関する API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-239">Networking - APIs concerning communicating with other computers and devices over either the Internet or private networks.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-240">API</span><span class="sxs-lookup"><span data-stu-id="fb006-240">API</span></span></th>
    <th align="left"><span data-ttu-id="fb006-241">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-241">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-242">Windows.Networking.Sockets</span><span class="sxs-lookup"><span data-stu-id="fb006-242">Windows.Networking.Sockets</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-243">Windows.Networking.Sockets 名前空間は、信頼性の高いまたは信頼性の低いネットワーク通信を実現する TCP および UDP ソケットを提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-243">The Windows.Networking.Sockets namespace provides TCP and UDP sockets that allow reliable or unreliable network communication.</span></span></p>
    <p><strong><span data-ttu-id="fb006-244">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-244">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-245">Windows.Networking.Sockets は、ゲームがネットワーク経由で他のコンピューターやデバイスと通信する必要がある場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fb006-245">Use Windows.Networking.Sockets if your game needs to communicate with other computers or devices over the network.</span></span></p>
    <p><strong><span data-ttu-id="fb006-246">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-246">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-247">「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-247">See <a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">Work with networking in your game</a>.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-248">Windows.Web.HTTP</span><span class="sxs-lookup"><span data-stu-id="fb006-248">Windows.Web.HTTP</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-249">Windows.Web.HTTP 名前空間では、Web サイトへのアクセスに利用できる、HTTP サーバーへの信頼性の高い接続を実現できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-249">The Windows.Web.HTTP namespace provides a reliable connection to HTTP servers that can be used to access a web site.</span></span></p>
    <p><strong><span data-ttu-id="fb006-250">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-250">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-251">ゲームで Web サイトにアクセスして情報を取得または保存する必要がある場合に、Windows.Web.HTTP を使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-251">Use Windows.Web.HTTP when your game needs to access a web site to retrieve or store information.</span></span></p>
    <p><strong><span data-ttu-id="fb006-252">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-252">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-253">「<a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">ゲームでのネットワークの使用</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-253">See <a href="https://docs.microsoft.com/windows/uwp/gaming/work-with-networking-in-your-directx-game">Work with networking in your game</a>.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

-   <span data-ttu-id="fb006-254">サポート ユーティリティ: Windows 10 API に基づいて構築されたライブラリです。</span><span class="sxs-lookup"><span data-stu-id="fb006-254">Support Utilities - Libraries that build on the Windows 10 APIs.</span></span>

    <table>
    <colgroup>
    <col width="50%" />
    <col width="50%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left"><span data-ttu-id="fb006-255">ライブラリ</span><span class="sxs-lookup"><span data-stu-id="fb006-255">Library</span></span></th>
    <th align="left"><span data-ttu-id="fb006-256">説明</span><span class="sxs-lookup"><span data-stu-id="fb006-256">Description</span></span></th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
    <td align="left"><span data-ttu-id="fb006-257">DirectX ツール キット</span><span class="sxs-lookup"><span data-stu-id="fb006-257">DirectX Tool Kit</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-258">DirectX ツール キット (DirectXTK) は、C++ で DirectX 11.x コードを作成するためのヘルパー クラスのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="fb006-258">The DirectX Tool Kit (DirectXTK) is a collection of helper classes for writing DirectX 11.x code in C++.</span></span></p>
    <p><strong><span data-ttu-id="fb006-259">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-259">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-260">C++ を使っている開発者がレガシ D3DX ユーティリティ コードに代わる最新のユーティリティを探している場合や、XNA Game Studio を使っている開発者がネイティブ C++ に移行する場合に、DirectX ツール キットを使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-260">Use the DirectX Tool Kit if you're a C++ developer looking for a modern replacement to the legacy D3DX utility code or you're an XNA Game Studio developer transitioning to native C++.</span></span></p>
    <p><strong><span data-ttu-id="fb006-261">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-261">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-262">DirectX ツール キットのプロジェクト ページ <a href="https://github.com/Microsoft/DirectXTK">https://github.com/Microsoft/DirectXTK</a> を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb006-262">See the DirectX Tool Kit project page, <a href="https://github.com/Microsoft/DirectXTK">https://github.com/Microsoft/DirectXTK</a>.</span></span></p></td>
    </tr>
    <tr class="even">
    <td align="left"><span data-ttu-id="fb006-263">Win2D</span><span class="sxs-lookup"><span data-stu-id="fb006-263">Win2D</span></span></td>
    <td align="left"><p><span data-ttu-id="fb006-264">Win2D は、即時モードの 2D グラフィックス レンダリング用の、使いやすい Windows ランタイム API です。</span><span class="sxs-lookup"><span data-stu-id="fb006-264">Win2D is an easy-to-use Windows Runtime API for immediate mode 2D graphics rendering.</span></span></p>
    <p><strong><span data-ttu-id="fb006-265">使う状況</span><span class="sxs-lookup"><span data-stu-id="fb006-265">When to use</span></span></strong></p>
    <p><span data-ttu-id="fb006-266">C++ を使っている開発者が Direct2D と DirectWrite の使いやすい WinRT ラッパーを必要としている場合や、C# を使っている開発者が Direct2D と DirectWrite を使う必要がある場合に、Win2D を使います。</span><span class="sxs-lookup"><span data-stu-id="fb006-266">Use Win2D if you're a C++ developer and want an easier to use WinRT wrapper for Direct2D and DirectWrite, or you're a C# developer wanting to use Direct2D and DirectWrite.</span></span></p>
    <p><strong><span data-ttu-id="fb006-267">詳細情報</span><span class="sxs-lookup"><span data-stu-id="fb006-267">For more information</span></span></strong></p>
    <p><span data-ttu-id="fb006-268">Win2D プロジェクト ページ <a href="https://github.com/Microsoft/Win2D">https://github.com/Microsoft/Win2D</a> を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb006-268">See the Win2D project page, <a href="https://github.com/Microsoft/Win2D">https://github.com/Microsoft/Win2D</a>.</span></span></p></td>
    </tr>
    </tbody>
    </table>

     

## <a name="xbox-live-services"></a><span data-ttu-id="fb006-269">Xbox Live サービス</span><span class="sxs-lookup"><span data-stu-id="fb006-269">Xbox Live Services</span></span>

<span data-ttu-id="fb006-270">[Xbox Live クリエーターズ プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator) では、開発者はだれでも Xbox Live を自分の UWP ゲームに統合して、Xbox One や Windows 10 に公開することができます。</span><span class="sxs-lookup"><span data-stu-id="fb006-270">The [Xbox Live Creators Program](https://developer.microsoft.com/games/xbox/xboxlive/creator) allows any developer to integrate Xbox Live into their UWP game and publish to Xbox One and Windows 10.</span></span> <span data-ttu-id="fb006-271">最小限の開発時間で、サインイン、プレゼンス、ランキングなどの Xbox Live ソーシャル エクスペリエンスをタイトルに統合できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-271">Integrate Xbox Live social experiences such as sign-in, presence, leaderboards, and more into your title, with minimal development time.</span></span> <span data-ttu-id="fb006-272">Xbox Live のソーシャル機能では、5,500 万人以上のアクティブ ゲーマーに情報を発信して、オーディエンスを自然に増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="fb006-272">Xbox Live social features are designed to organically grow your audience, spreading awareness to over 55 million active gamers.</span></span>

<span data-ttu-id="fb006-273">Xbox Live の他の機能にアクセスしたり、マーケティングと開発に関する専用のサポートを受けたり、Xbox One ストアのメイン ページで取り上げられたりすることを希望する場合は、[ID@Xbox](http://www.xbox.com/developers/id) プログラムへの登録を申し込んでください。</span><span class="sxs-lookup"><span data-stu-id="fb006-273">If you want access to even more Xbox Live capabilities, dedicated marketing and development support, and the chance to be featured in the main Xbox One store, apply to the [ID@Xbox](http://www.xbox.com/developers/id) program.</span></span> <span data-ttu-id="fb006-274">Xbox Live クリエーターズ プログラム、および ID@Xbox プログラムで利用できる機能については、[機能表](../xbox-live/developer-program-overview.md#feature-table)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-274">To see which features are available to the Xbox Live Creators Program and ID@Xbox program, see the [Feature table](../xbox-live/developer-program-overview.md#feature-table).</span></span>

<span data-ttu-id="fb006-275">詳しくは、「[ゲームへの Xbox Live の追加](e2e.md#adding-xbox-live-to-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-275">For more info, go to [Adding Xbox Live to your game](e2e.md#adding-xbox-live-to-your-game).</span></span>

##  <a name="alternatives-to-writing-games-with-directx-and-uwp"></a><span data-ttu-id="fb006-276">DirectX と UWP を使ったゲーム作成の代替手段</span><span class="sxs-lookup"><span data-stu-id="fb006-276">Alternatives to writing games with DirectX and UWP</span></span>


### <a name="uwp-games-without-directx"></a><span data-ttu-id="fb006-277">DirectX を使わない UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="fb006-277">UWP Games without DirectX</span></span>

<span data-ttu-id="fb006-278">カード ゲームやボード ゲームなど、最低限のパフォーマンスの要件を満たす単純なゲームは、DirectX を使わずに作成でき、必ずしも C++ で記述されている必要はありません。</span><span class="sxs-lookup"><span data-stu-id="fb006-278">Simpler games with minimal performance requirements, such as card games or board games, can be written without DirectX and don't necessarily need to be written in C++.</span></span> <span data-ttu-id="fb006-279">このような種類のゲームでは、C#、Visual Basic、C++、HTML/JavaScript など、UWP でサポートされている言語のいずれかを利用できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-279">These sort of games can make use of any of the languages supported by UWP such as C#, Visual Basic, C++, and HTML/JavaScript.</span></span> <span data-ttu-id="fb006-280">パフォーマンスと負荷の高いグラフィックスがゲームで必要な場合は、[JavaScript と HTML5 のタッチ ゲームのサンプル](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031)を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="fb006-280">If performance and intensive graphics are not a requirement for your game, checkout [JavaScript and HTML5 touch game sample](http://code.msdn.microsoft.com/windowsapps/JavaScript-and-HTML5-touch-d96f6031) as an example.</span></span>

### <a name="game-engines"></a><span data-ttu-id="fb006-281">ゲーム エンジン</span><span class="sxs-lookup"><span data-stu-id="fb006-281">Game Engines</span></span>

<span data-ttu-id="fb006-282">Windows ゲーム開発 API を使って独自のゲーム エンジンを作成する代替手段として、Windows ゲーム開発 API を基にして作成された多くの高品質ゲーム エンジンを、Windows プラットフォームでのゲームの開発に利用できます。</span><span class="sxs-lookup"><span data-stu-id="fb006-282">As an alternative to writing your own game engine using the Windows game development APIs, many high quality game engines that build on the Windows game development APIs are available for developing games on Windows platforms.</span></span> <span data-ttu-id="fb006-283">ゲーム エンジンまたはライブラリを検討する場合、複数のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="fb006-283">When considering a game engine or library, you have multiple options:</span></span>

-   <span data-ttu-id="fb006-284">フル ゲーム エンジン: フル ゲーム エンジンは、ゲーム エンジンをゼロから作成する場合に使用する、グラフィックス、オーディオ、入力、ネットワークなどの Windows 10 API のほとんどまたはすべてをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="fb006-284">Full game engine - A full game engine encapsulates most or all of the Windows 10 APIs you would use when writing a game engine from scratch, such as graphics, audio, input, and networking.</span></span> <span data-ttu-id="fb006-285">また、フル ゲーム エンジンは、人工知能や経路探索などのゲーム ロジック機能も備えています。</span><span class="sxs-lookup"><span data-stu-id="fb006-285">Full game engines may also provide game logic functionality such as artificial intelligence and pathfinding.</span></span>
-   <span data-ttu-id="fb006-286">グラフィックス エンジン: グラフィックス エンジンは、Windows 10 のグラフィックス API をカプセル化して、グラフィックス リソースを管理し、さまざまなモデルとワールドの形式をサポートします。</span><span class="sxs-lookup"><span data-stu-id="fb006-286">Graphics engine - Graphics engines encapsulate the Windows 10 graphics APIs, manage graphics resources, and support a variety of model and world formats.</span></span>
-   <span data-ttu-id="fb006-287">オーディオ エンジン: オーディオ エンジンは Windows 10 のオーディオ API をカプセル化して、オーディオ リソースを管理し、高度なオーディオ処理とエフェクトを提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-287">Audio engine - Audio engines encapsulate the Windows 10 audio APIs, manage audio resources, and provide advanced audio processing and effects.</span></span>
-   <span data-ttu-id="fb006-288">ネットワーク エンジン: ネットワーク エンジンは、Windows 10 のネットワーク API をカプセル化して、ピア ツー ピアまたはサーバー ベースのマルチプレイヤーのサポートをゲームに追加します。また、多数のプレイヤーをサポートするための高度なネットワーク機能が含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="fb006-288">Network engine - Network engines encapsulate Windows 10 networking APIs for adding peer-to-peer or server-based multiplayer support to your game, and may include advanced networking functionality to support large numbers of players.</span></span>
-   <span data-ttu-id="fb006-289">人工知能と経路探索エンジン: AI と経路探索エンジンは、ゲーム内でエージェントの動作を制御するためのフレームワークを提供します。</span><span class="sxs-lookup"><span data-stu-id="fb006-289">Artificial intelligence and pathfinding engine - AI and pathfinding engines provide a framework for controlling the behavior of agents in your game.</span></span>
-   <span data-ttu-id="fb006-290">特殊な用途のエンジン: インベントリ システムやダイアログ ツリーなど、発生する可能性があるほぼすべてのゲーム開発関連タスクを処理するために、さまざまな追加のエンジンが存在します。</span><span class="sxs-lookup"><span data-stu-id="fb006-290">Special purpose engines - A variety of additional engines exist for handling almost any game development related task you might run into, such as creating inventory systems and dialog trees.</span></span>

## <a name="submitting-a-game-to-the-store"></a><span data-ttu-id="fb006-291">ストアへのゲームの提出</span><span class="sxs-lookup"><span data-stu-id="fb006-291">Submitting a game to the Store</span></span>


<span data-ttu-id="fb006-292">ゲームを公開する準備ができたら、開発者アカウントを作成して、ゲームを Microsoft Store に提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb006-292">Once you’re ready to publish your game, you’ll need to create a developer account and submit your game to the Microsoft Store.</span></span>

<span data-ttu-id="fb006-293">Microsoft Store へのゲームの提出については、「[ゲームの申請と公開](e2e.md#submitting-and-publishing-your-game)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fb006-293">For information about submitting your game to the Microsoft Store, see [Submitting and publishing your game](e2e.md#submitting-and-publishing-your-game).</span></span>

 

 




