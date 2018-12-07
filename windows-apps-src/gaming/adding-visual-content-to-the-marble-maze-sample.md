---
title: Marble Maze サンプルへの視覚的なコンテンツの追加
description: このドキュメントでは、Marble Maze ゲームがユニバーサル Windows プラットフォーム (UWP) アプリ環境で Direct3D と Direct2D をどのように使うかについて説明します。パターンを学習することにより、独自のゲーム コンテンツの開発に活用できます。
ms.assetid: 6e43422e-e1a1-b79e-2c4b-7d5b4fa88647
ms.date: 09/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、サンプル、DirectX、グラフィックス
ms.localizationpriority: medium
ms.openlocfilehash: 60dd12c3e18b82118053d72d0983e13008dd8a0e
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8784791"
---
# <a name="adding-visual-content-to-the-marble-maze-sample"></a><span data-ttu-id="927ec-104">Marble Maze サンプルへの視覚的なコンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="927ec-104">Adding visual content to the Marble Maze sample</span></span>




<span data-ttu-id="927ec-105">このドキュメントでは、Marble Maze ゲームがユニバーサル Windows プラットフォーム (UWP) アプリ環境で Direct3D と Direct2D をどのように使うかについて説明します。パターンを学習することにより、独自のゲーム コンテンツの開発に活用できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-105">This document describes how the Marble Maze game uses Direct3D and Direct2D in the Universal Windows Platform (UWP) app environment so that you can learn the patterns and adapt them when you work with your own game content.</span></span> <span data-ttu-id="927ec-106">Marble Maze のアプリケーション構造全体で視覚的なゲーム コンポーネントがどのように使われているかについては、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-106">To learn how visual game components fit in the overall application structure of Marble Maze, see [Marble Maze application structure](marble-maze-application-structure.md).</span></span>

<span data-ttu-id="927ec-107">Marble Maze の視覚的側面は、次のような基本の手順に従って開発しました。</span><span class="sxs-lookup"><span data-stu-id="927ec-107">We followed these basic steps as we developed the visual aspects of Marble Maze:</span></span>

1.  <span data-ttu-id="927ec-108">Direct3D 環境と Direct2D 環境を初期化する基本フレームワークを作ります。</span><span class="sxs-lookup"><span data-stu-id="927ec-108">Create a basic framework that initializes the Direct3D and Direct2D environments.</span></span>
2.  <span data-ttu-id="927ec-109">画像およびモデル編集プログラムを使用すると、ゲームに表示される 2 D および 3D アセットを設計できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-109">Use image and model editing programs to design the 2D and 3D assets that appear in the game.</span></span>
3.  <span data-ttu-id="927ec-110">2 D および 3D アセットが正しく読み込まれ、ゲームに表示することを確認します。</span><span class="sxs-lookup"><span data-stu-id="927ec-110">Ensure that 2D and 3D assets properly load and appear in the game.</span></span>
4.  <span data-ttu-id="927ec-111">ゲーム アセットの画質を高める頂点シェーダーとピクセル シェーダーを統合します。</span><span class="sxs-lookup"><span data-stu-id="927ec-111">Integrate vertex and pixel shaders that enhance the visual quality of the game assets.</span></span>
5.  <span data-ttu-id="927ec-112">アニメーション、ユーザー入力などのゲーム ロジックを統合します。</span><span class="sxs-lookup"><span data-stu-id="927ec-112">Integrate game logic, such as animation and user input.</span></span>

<span data-ttu-id="927ec-113">また、最初行いました 3D アセットを追加し、次に、2 D アセット。</span><span class="sxs-lookup"><span data-stu-id="927ec-113">We also focused first on adding 3D assets and then on 2D assets.</span></span> <span data-ttu-id="927ec-114">たとえば、メニュー システムとタイマーを追加する前に、コア ゲーム ロジックに重点的に取り組みました。</span><span class="sxs-lookup"><span data-stu-id="927ec-114">For example, we focused on core game logic before we added the menu system and timer.</span></span>

<span data-ttu-id="927ec-115">また、開発プロセスでは、これらの手順の一部を何度も繰り返す必要がありました。</span><span class="sxs-lookup"><span data-stu-id="927ec-115">We also needed to iterate through some of these steps multiple times during the development process.</span></span> <span data-ttu-id="927ec-116">たとえば、メッシュや大理石のモデルに変更を行った場合、それらのモデルをサポートするシェーダー コードの一部も変更する必要もありました。</span><span class="sxs-lookup"><span data-stu-id="927ec-116">For example, as we made changes to the mesh and marble models, we had to also change some of the shader code that supports those models.</span></span>

> [!NOTE]
> <span data-ttu-id="927ec-117">このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。</span><span class="sxs-lookup"><span data-stu-id="927ec-117">The sample code that corresponds to this document is found in the [DirectX Marble Maze game sample](http://go.microsoft.com/fwlink/?LinkId=624011).</span></span>

 
<span data-ttu-id="927ec-118">ここでは、DirectX や視覚的なゲーム コンテンツを扱うとき、つまり DirectX グラフィックス ライブラリの初期化、シーンのリソースの読み込み、シーンの更新やレンダリングを行う際の次の重要事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-118">Here are some of the key points that this document discusses for when you work with DirectX and visual game content, namely, when you initialize the DirectX graphics libraries, load scene resources, and update and render the scene:</span></span>

-   <span data-ttu-id="927ec-119">ゲーム コンテンツの追加には、通常、多くの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="927ec-119">Adding game content typically involves many steps.</span></span> <span data-ttu-id="927ec-120">多くの場合、これらの手順を繰り返すことも必要です。</span><span class="sxs-lookup"><span data-stu-id="927ec-120">These steps also often require iteration.</span></span> <span data-ttu-id="927ec-121">ゲーム開発者多くの場合は集中まず 3D ゲーム コンテンツを追加し、2 D のコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="927ec-121">Game developers often focus first on adding 3D game content and then on adding 2D content.</span></span>
-   <span data-ttu-id="927ec-122">より多くの顧客に製品を届けて優れたユーザー エクスペリエンスを提供できるように、できるだけ広範囲のグラフィックス ハードウェアをサポートするようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-122">Reach more customers and give them all a great experience by supporting the greatest range of graphics hardware as possible.</span></span>
-   <span data-ttu-id="927ec-123">設計時と実行時の形式は明確に区別します。</span><span class="sxs-lookup"><span data-stu-id="927ec-123">Cleanly separate design-time and run-time formats.</span></span> <span data-ttu-id="927ec-124">設計時のアセットは、柔軟性を最大限に高め、コンテンツに対する迅速な繰り返し処理ができるように構造化します。</span><span class="sxs-lookup"><span data-stu-id="927ec-124">Structure your design-time assets to maximize flexibility and enable rapid iterations on content.</span></span> <span data-ttu-id="927ec-125">アセットは、実行時にできるだけ効率的に読み込みとレンダリングを行うことができるように、形式を設定して圧縮します。</span><span class="sxs-lookup"><span data-stu-id="927ec-125">Format and compress your assets to load and render as efficiently as possible at run time.</span></span>
-   <span data-ttu-id="927ec-126">Direct3D デバイスと Direct2D デバイスの UWP アプリでの作成は、従来の Windows デスクトップ アプリでの作成とほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="927ec-126">You create the Direct3D and Direct2D devices in a UWP app much like you do in a classic Windows desktop app.</span></span> <span data-ttu-id="927ec-127">1 つの大きな違いは、スワップ チェーンと出力ウィンドウとの関連付けの方法です。</span><span class="sxs-lookup"><span data-stu-id="927ec-127">One important difference is how the swap chain is associated with the output window.</span></span>
-   <span data-ttu-id="927ec-128">ゲームを設計するときは、選択したメッシュ形式が主要なシナリオをサポートすることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="927ec-128">When you design your game, ensure that the mesh format that you choose supports your key scenarios.</span></span> <span data-ttu-id="927ec-129">たとえば、ゲームで衝突が必要な場合は、メッシュから衝突データを取得できることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="927ec-129">For example, if your game requires collision, make sure that you can obtain collision data from your meshes.</span></span>
-   <span data-ttu-id="927ec-130">まず、すべてのシーン オブジェクトを更新してからレンダリングすることによって、ゲーム ロジックとレンダリング ロジックを切り離します。</span><span class="sxs-lookup"><span data-stu-id="927ec-130">Separate game logic from rendering logic by first updating all scene objects before you render them.</span></span>
-   <span data-ttu-id="927ec-131">通常、3 D シーン オブジェクトを描画して、2 D オブジェクトのシーンの前面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-131">You typically draw your 3D scene objects, and then any 2D objects that appear in front of the scene.</span></span>
-   <span data-ttu-id="927ec-132">描画と垂直ブランクを同期して、実際にディスプレイに表示されないフレームの描画にゲームが時間をかけないようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-132">Synchronize drawing to the vertical blank to ensure that your game does not spend time drawing frames that will never be actually shown on the display.</span></span> <span data-ttu-id="927ec-133">*垂直ブランク*は 1 つのフレームがモニターへの描画を終了するまでの時間と、次のフレームが開始されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-133">A *vertical blank* is the time between when one frame finishes drawing to the monitor and the next frame begins.</span></span>

## <a name="getting-started-with-directx-graphics"></a><span data-ttu-id="927ec-134">DirectX グラフィックスの概要</span><span class="sxs-lookup"><span data-stu-id="927ec-134">Getting started with DirectX graphics</span></span>


<span data-ttu-id="927ec-135">Marble Maze ユニバーサル Windows プラットフォーム (UWP) ゲームを計画したとき、選択した C++ と direct 3 d 11.1 なレンダリングと高パフォーマンスの最大の制御を必要とする 3D ゲームを作成するための最適な選択であるためです。</span><span class="sxs-lookup"><span data-stu-id="927ec-135">When we planned the Marble Maze Universal Windows Platform (UWP) game, we chose C++ and Direct3D 11.1 because they are excellent choices for creating 3D games that require maximum control over rendering and high performance.</span></span> <span data-ttu-id="927ec-136">DirectX 11.1 は DirectX 9 から DirectX 11 までのハードウェアをサポートするため、より多くの顧客に効率よく製品を届けることができます。以前の各 DirectX バージョン用にコードを書き直す必要がないためです。</span><span class="sxs-lookup"><span data-stu-id="927ec-136">DirectX 11.1 supports hardware from DirectX 9 to DirectX 11, and therefore can help you reach more customers more efficiently because you don't have to rewrite code for each of the earlier DirectX versions.</span></span>

<span data-ttu-id="927ec-137">Marble Maze では、direct 3 d 11.1 を使用して、3 D のゲーム アセット (大理石と迷路) をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="927ec-137">Marble Maze uses Direct3D 11.1 to render the 3D game assets, namely the marble and the maze.</span></span> <span data-ttu-id="927ec-138">Marble Maze では、Direct2D、DirectWrite、および Windows Imaging Component (WIC) も、描画など、メニューやタイマーは、2 D ゲーム アセットを使用します。</span><span class="sxs-lookup"><span data-stu-id="927ec-138">Marble Maze also uses Direct2D, DirectWrite, and Windows Imaging Component (WIC) to draw the 2D game assets, such as the menus and the timer.</span></span>

<span data-ttu-id="927ec-139">ゲームを開発するには計画が必要です。</span><span class="sxs-lookup"><span data-stu-id="927ec-139">Game development requires planning.</span></span> <span data-ttu-id="927ec-140">読むことをお勧めします新しい DirectX グラフィックスの場合は、 [DirectX: 概要](directx-getting-started.md)、UWP DirectX ゲームの作成の基本概念を理解します。</span><span class="sxs-lookup"><span data-stu-id="927ec-140">If you are new to DirectX graphics, we recommend that you read [DirectX: Getting started](directx-getting-started.md) to familiarize yourself with the basic concepts of creating a UWP DirectX game.</span></span> <span data-ttu-id="927ec-141">このドキュメントで、Marble Maze のソース コードを使用すると、DirectX グラフィックスに関するより詳しい情報については、次のリソースを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="927ec-141">As you read this document and work through the Marble Maze source code, you can refer to the following resources for more in-depth information about DirectX graphics:</span></span>

-   <span data-ttu-id="927ec-142">[Direct3d11 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/ff476080): について説明します。 direct3d11 は、ハードウェア アクセラレータによる強力の 3D グラフィックス API、Windows プラットフォームで 3 d ジオメトリをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="927ec-142">[Direct3D 11 Graphics](https://msdn.microsoft.com/library/windows/desktop/ff476080): Describes Direct3D 11, a powerful, hardware-accelerated 3D graphics API for rendering 3D geometry on the Windows platform.</span></span>
-   <span data-ttu-id="927ec-143">[Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990): Direct2D について説明します。 ハードウェア アクセラレータによる、2 d グラフィックス API を提供する高パフォーマンスかつ高品質のレンダリングと、2 d ジオメトリ、ビットマップ、テキストのします。</span><span class="sxs-lookup"><span data-stu-id="927ec-143">[Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990): Describes Direct2D, a hardware-accelerated, 2D graphics API that provides high performance and high-quality rendering for 2D geometry, bitmaps, and text.</span></span>
-   <span data-ttu-id="927ec-144">[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038): 高品質のテキストのレンダリングをサポートする DirectWrite について説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-144">[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038): Describes DirectWrite, which supports high-quality text rendering.</span></span>
-   <span data-ttu-id="927ec-145">[Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902): について説明します。 WIC、デジタル画像の低レベルの API を提供する拡張可能なプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="927ec-145">[Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902): Describes WIC, an extensible platform that provides low-level API for digital images.</span></span>

### <a name="feature-levels"></a><span data-ttu-id="927ec-146">機能レベル</span><span class="sxs-lookup"><span data-stu-id="927ec-146">Feature levels</span></span>

<span data-ttu-id="927ec-147">Direct3d11 では、*機能レベル*をという名前のパラダイムについて説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-147">Direct3D 11 introduces a paradigm named *feature levels*.</span></span> <span data-ttu-id="927ec-148">機能レベルは、明確に定義された GPU 機能のセットです。</span><span class="sxs-lookup"><span data-stu-id="927ec-148">A feature level is a well-defined set of GPU functionality.</span></span> <span data-ttu-id="927ec-149">機能レベルを使って、Direct3D ハードウェアの以前のバージョンで実行できるようにゲームのターゲットを設定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-149">Use feature levels to target your game to run on earlier versions of Direct3D hardware.</span></span> <span data-ttu-id="927ec-150">Marble Maze では機能レベル 9.1 がサポートされます。高いレベルの高度な機能は必要ないためです。</span><span class="sxs-lookup"><span data-stu-id="927ec-150">Marble Maze supports feature level 9.1 because it requires no advanced features from the higher levels.</span></span> <span data-ttu-id="927ec-151">所有するコンピューターがハイエンドかローエンドかにかかわらず、すべての顧客に対して優れたユーザー エクスペリエンスを実現できるように、できるだけ幅広いハードウェアをサポートし、ゲーム コンテンツをそれに合わせることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="927ec-151">We recommend that you support the greatest range of hardware possible and scale your game content so that your customers that have either high or low-end computers all have a great experience.</span></span> <span data-ttu-id="927ec-152">機能レベルについて詳しくは、「[下位レベル ハードウェアでの Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476872)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-152">For more information about feature levels, see [Direct3D 11 on Downlevel Hardware](https://msdn.microsoft.com/library/windows/desktop/ff476872).</span></span>

## <a name="initializing-direct3d-and-direct2d"></a><span data-ttu-id="927ec-153">Direct3D と Direct2D の初期化</span><span class="sxs-lookup"><span data-stu-id="927ec-153">Initializing Direct3D and Direct2D</span></span>


<span data-ttu-id="927ec-154">デバイスはディスプレイ アダプターを表します。</span><span class="sxs-lookup"><span data-stu-id="927ec-154">A device represents the display adapter.</span></span> <span data-ttu-id="927ec-155">Direct3D デバイスと Direct2D デバイスの UWP アプリでの作成は、従来の Windows デスクトップ アプリでの作成とほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="927ec-155">You create the Direct3D and Direct2D devices in a UWP app much like you do in a classic Windows desktop app.</span></span> <span data-ttu-id="927ec-156">主な違いは、Direct3D スワップ チェーンをウィンドウ システムに関連付ける方法です。</span><span class="sxs-lookup"><span data-stu-id="927ec-156">The main difference is how you connect the Direct3D swap chain to the windowing system.</span></span>

<span data-ttu-id="927ec-157">**DeviceResources** クラスは、Direct3D と Direct2D を管理する基盤です。</span><span class="sxs-lookup"><span data-stu-id="927ec-157">The **DeviceResources** class is a foundation for managing Direct3D and Direct2D.</span></span> <span data-ttu-id="927ec-158">このクラスは、一般的なインフラストラクチャ、いないゲーム固有のアセットを処理します。</span><span class="sxs-lookup"><span data-stu-id="927ec-158">This class handles general infrastructure, not game-specific assets.</span></span> <span data-ttu-id="927ec-159">Marble Maze は、Direct3D と Direct2D へのアクセスを提供する**DeviceResources**オブジェクトへの参照を持つにハンドル ゲーム固有のアセットを**MarbleMazeMain**クラスに定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-159">Marble Maze defines the **MarbleMazeMain** class to handle game-specific assets, which has a reference to a **DeviceResources** object to give it access to Direct3D and Direct2D.</span></span>

<span data-ttu-id="927ec-160">**DeviceResources**コンス トラクターは、初期化中に、デバイスに依存しないリソースと Direct3D と Direct2D デバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-160">During initialization, the **DeviceResources** constructor creates device-independent resources and the Direct3D and Direct2D devices.</span></span>

```cpp
// Initialize the Direct3D resources required to run. 
DX::DeviceResources::DeviceResources() :
    m_screenViewport(),
    m_d3dFeatureLevel(D3D_FEATURE_LEVEL_9_1),
    m_d3dRenderTargetSize(),
    m_outputSize(),
    m_logicalSize(),
    m_nativeOrientation(DisplayOrientations::None),
    m_currentOrientation(DisplayOrientations::None),
    m_dpi(-1.0f),
    m_deviceNotify(nullptr)
{
    CreateDeviceIndependentResources();
    CreateDeviceResources();
}
```

<span data-ttu-id="927ec-161">**DeviceResources** クラスは、この機能を切り離して、環境が変更されたときに簡単に応答できるようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-161">The **DeviceResources** class separates this functionality so that it can more easily respond when the environment changes.</span></span> <span data-ttu-id="927ec-162">たとえば、ウィンドウ サイズが変更されると **CreateWindowSizeDependentResources** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-162">For example, it calls the **CreateWindowSizeDependentResources** method when the window size changes.</span></span>

###  <a name="initializing-the-direct2d-directwrite-and-wic-factories"></a><span data-ttu-id="927ec-163">Direct2D、DirectWrite、WIC ファクトリの初期化</span><span class="sxs-lookup"><span data-stu-id="927ec-163">Initializing the Direct2D, DirectWrite, and WIC factories</span></span>

<span data-ttu-id="927ec-164">**DeviceResources::CreateDeviceIndependentResources** メソッドは、Direct2D、DirectWrite、WIC のファクトリを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-164">The **DeviceResources::CreateDeviceIndependentResources** method creates the factories for Direct2D, DirectWrite, and WIC.</span></span> <span data-ttu-id="927ec-165">DirectX グラフィックスにおいて、ファクトリは、グラフィックス リソースを作成するための開始点です。</span><span class="sxs-lookup"><span data-stu-id="927ec-165">In DirectX graphics, factories are the starting points for creating graphics resources.</span></span> <span data-ttu-id="927ec-166">Marble Maze では、メイン スレッドですべての描画を実行するため、**D2D1\_FACTORY\_TYPE\_SINGLE\_THREADED** を指定しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-166">Marble Maze specifies **D2D1\_FACTORY\_TYPE\_SINGLE\_THREADED** because it performs all drawing on the main thread.</span></span>

```cpp
// These are the resources required independent of hardware. 
void DX::DeviceResources::CreateDeviceIndependentResources()
{
    // Initialize Direct2D resources.
    D2D1_FACTORY_OPTIONS options;
    ZeroMemory(&options, sizeof(D2D1_FACTORY_OPTIONS));

#if defined(_DEBUG)
    // If the project is in a debug build, enable Direct2D debugging via SDK Layers.
    options.debugLevel = D2D1_DEBUG_LEVEL_INFORMATION;
#endif

    // Initialize the Direct2D Factory.
    DX::ThrowIfFailed(
        D2D1CreateFactory(
            D2D1_FACTORY_TYPE_SINGLE_THREADED,
            __uuidof(ID2D1Factory2),
            &options,
            &m_d2dFactory
            )
        );

    // Initialize the DirectWrite Factory.
    DX::ThrowIfFailed(
        DWriteCreateFactory(
            DWRITE_FACTORY_TYPE_SHARED,
            __uuidof(IDWriteFactory2),
            &m_dwriteFactory
            )
        );

    // Initialize the Windows Imaging Component (WIC) Factory.
    DX::ThrowIfFailed(
        CoCreateInstance(
            CLSID_WICImagingFactory2,
            nullptr,
            CLSCTX_INPROC_SERVER,
            IID_PPV_ARGS(&m_wicFactory)
            )
        );
}
```

###  <a name="creating-the-direct3d-and-direct2d-devices"></a><span data-ttu-id="927ec-167">Direct3D デバイスと Direct2D デバイスの作成</span><span class="sxs-lookup"><span data-stu-id="927ec-167">Creating the Direct3D and Direct2D devices</span></span>

<span data-ttu-id="927ec-168">**DeviceResources::CreateDeviceResources** メソッドは、[D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出して、Direct3D ディスプレイ アダプターを表すデバイス オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-168">The **DeviceResources::CreateDeviceResources** method calls [D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) to create the device object that represents the Direct3D display adapter.</span></span> <span data-ttu-id="927ec-169">Marble Maze には、機能レベル 9.1 がサポートされているため、上記**deviceresources::createdeviceresources**メソッドは、 **featureLevels**配列でレベル 9.1 11.1 からを指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-169">Because Marble Maze supports feature level 9.1 and above, the **DeviceResources::CreateDeviceResources** method specifies levels 9.1 through 11.1 in the **featureLevels** array.</span></span> <span data-ttu-id="927ec-170">Direct3D はリストを順に確かめ、使用可能な最初の機能レベルをアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="927ec-170">Direct3D walks the list in order and gives the app the first feature level that is available.</span></span> <span data-ttu-id="927ec-171">したがって**D3D\_FEATURE\_LEVEL**配列の項目は表示高いものから順にアプリが利用可能な最高の機能レベルを取得するようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-171">Therefore the **D3D\_FEATURE\_LEVEL** array entries are listed from highest to lowest so that the app will get the highest feature level available.</span></span> <span data-ttu-id="927ec-172">**DeviceResources::CreateDeviceResources** メソッドは、**D3D11CreateDevice** から返される Direct3D 11 デバイスを照会することによって Direct3D 11.1 デバイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="927ec-172">The **DeviceResources::CreateDeviceResources** method obtains the Direct3D 11.1 device by querying the Direct3D 11 device that's returned from **D3D11CreateDevice**.</span></span>

```cpp
// This flag adds support for surfaces with a different color channel ordering
// than the API default. It is required for compatibility with Direct2D.
UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)
    if (DX::SdkLayersAvailable())
    {
        // If the project is in a debug build, enable debugging via SDK Layers 
        // with this flag.
        creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
    }
#endif

// This array defines the set of DirectX hardware feature levels this app will support.
// Note the ordering should be preserved.
// Don't forget to declare your application's minimum required feature level in its
// description.  All applications are assumed to support 9.1 unless otherwise stated.
D3D_FEATURE_LEVEL featureLevels[] =
{
    D3D_FEATURE_LEVEL_11_1,
    D3D_FEATURE_LEVEL_11_0,
    D3D_FEATURE_LEVEL_10_1,
    D3D_FEATURE_LEVEL_10_0,
    D3D_FEATURE_LEVEL_9_3,
    D3D_FEATURE_LEVEL_9_2,
    D3D_FEATURE_LEVEL_9_1
};

// Create the Direct3D 11 API device object and a corresponding context.
ComPtr<ID3D11Device> device;
ComPtr<ID3D11DeviceContext> context;

HRESULT hr = D3D11CreateDevice(
    nullptr,                    // Specify nullptr to use the default adapter.
    D3D_DRIVER_TYPE_HARDWARE,   // Create a device using the hardware graphics driver.
    0,                          // Should be 0 unless the driver is D3D_DRIVER_TYPE_SOFTWARE.
    creationFlags,              // Set debug and Direct2D compatibility flags.
    featureLevels,              // List of feature levels this app can support.
    ARRAYSIZE(featureLevels),   // Size of the list above.
    D3D11_SDK_VERSION,          // Always set this to D3D11_SDK_VERSION for UWP apps.
    &device,                    // Returns the Direct3D device created.
    &m_d3dFeatureLevel,         // Returns feature level of device created.
    &context                    // Returns the device immediate context.
    );

if (FAILED(hr))
{
    // If the initialization fails, fall back to the WARP device.
    // For more information on WARP, see:
    // http://go.microsoft.com/fwlink/?LinkId=286690
    DX::ThrowIfFailed(
        D3D11CreateDevice(
            nullptr,
            D3D_DRIVER_TYPE_WARP, // Create a WARP device instead of a hardware device.
            0,
            creationFlags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            &device,
            &m_d3dFeatureLevel,
            &context
            )
        );
}

// Store pointers to the Direct3D 11.1 API device and immediate context.
DX::ThrowIfFailed(
    device.As(&m_d3dDevice)
    );

DX::ThrowIfFailed(
    context.As(&m_d3dContext)
    );
```

<span data-ttu-id="927ec-173">次に、**DeviceResources::CreateDeviceResources** メソッドが Direct2D デバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-173">The **DeviceResources::CreateDeviceResources** method then creates the Direct2D device.</span></span> <span data-ttu-id="927ec-174">Direct2D は、Direct3D との相互運用に Microsoft DirectX Graphic Infrastructure (DXGI) を使います。</span><span class="sxs-lookup"><span data-stu-id="927ec-174">Direct2D uses Microsoft DirectX Graphics Infrastructure (DXGI) to interoperate with Direct3D.</span></span> <span data-ttu-id="927ec-175">DXGI によって、ビデオ メモリ サーフェスをグラフィックス ランタイム間で共有できるようになります。</span><span class="sxs-lookup"><span data-stu-id="927ec-175">DXGI enables video memory surfaces to be shared between graphics runtimes.</span></span> <span data-ttu-id="927ec-176">Marble Maze は、Direct3D デバイスから基になる DXGI デバイスを使って、Direct2D ファクトリから Direct2D デバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-176">Marble Maze uses the underlying DXGI device from the Direct3D device to create the Direct2D device from the Direct2D factory.</span></span>

```cpp
// Create the Direct2D device object and a corresponding context.
ComPtr<IDXGIDevice3> dxgiDevice;
DX::ThrowIfFailed(
    m_d3dDevice.As(&dxgiDevice)
    );

DX::ThrowIfFailed(
    m_d2dFactory->CreateDevice(dxgiDevice.Get(), &m_d2dDevice)
    );

DX::ThrowIfFailed(
    m_d2dDevice->CreateDeviceContext(
        D2D1_DEVICE_CONTEXT_OPTIONS_NONE,
        &m_d2dContext
        )
    );
```

<span data-ttu-id="927ec-177">DXGI や Direct2D と Direct3D の相互運用について詳しくは、「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」と「[Direct2D と Direct3D の相互運用性の概要](https://msdn.microsoft.com/library/windows/desktop/dd370966)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-177">For more information about DXGI and interoperability between Direct2D and Direct3D, see [DXGI Overview](https://msdn.microsoft.com/library/windows/desktop/bb205075) and [Direct2D and Direct3D Interoperability Overview](https://msdn.microsoft.com/library/windows/desktop/dd370966).</span></span>

### <a name="associating-direct3d-with-the-view"></a><span data-ttu-id="927ec-178">Direct3D とビューの関連付け</span><span class="sxs-lookup"><span data-stu-id="927ec-178">Associating Direct3D with the view</span></span>

<span data-ttu-id="927ec-179">**DeviceResources::CreateWindowSizeDependentResources** メソッドは、スワップ チェーン、Direct3D と Direct2D のレンダー ターゲットなど、所定のウィンドウ サイズによって異なるグラフィックス リソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-179">The **DeviceResources::CreateWindowSizeDependentResources** method creates the graphics resources that depend on a given window size such as the swap chain and Direct3D and Direct2D render targets.</span></span> <span data-ttu-id="927ec-180">DirectX UWP アプリとデスクトップ アプリとの大きな違いは、スワップ チェーンが出力ウィンドウと関連付けられる方法です。</span><span class="sxs-lookup"><span data-stu-id="927ec-180">One important way that a DirectX UWP app differs from a desktop app is how the swap chain is associated with the output window.</span></span> <span data-ttu-id="927ec-181">スワップ チェーンは、デバイスがモニターにレンダリングするバッファーを表示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-181">A swap chain is responsible for displaying the buffer to which the device renders on the monitor.</span></span> <span data-ttu-id="927ec-182">[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)では、デスクトップ アプリから UWP アプリのウィンドウ システムの異なる方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-182">[Marble Maze application structure](marble-maze-application-structure.md) describes how the windowing system for a UWP app differs from a desktop app.</span></span> <span data-ttu-id="927ec-183">UWP アプリは、 [HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751)オブジェクトでは動作しない、ために、Marble Maze は、デバイス出力をビューに関連付ける[idxgifactory 2::createswapchainforcorewindow](https://msdn.microsoft.com/library/windows/desktop/hh404559)メソッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-183">Because a UWP app does not work with [HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751) objects, Marble Maze must use the [IDXGIFactory2::CreateSwapChainForCoreWindow](https://msdn.microsoft.com/library/windows/desktop/hh404559) method to associate the device output to the view.</span></span> <span data-ttu-id="927ec-184">次の例に、スワップ チェーンを作成する **DeviceResources::CreateWindowSizeDependentResources** メソッドの一部を示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-184">The following example shows the part of the **DeviceResources::CreateWindowSizeDependentResources** method that creates the swap chain.</span></span>

```cpp
// Obtain the final swap chain for this window from the DXGI factory.
DX::ThrowIfFailed(
    dxgiFactory->CreateSwapChainForCoreWindow(
        m_d3dDevice.Get(),
        reinterpret_cast<IUnknown*>(m_window.Get()),
        &swapChainDesc,
        nullptr,
        &m_swapChain
        )
    );
```

<span data-ttu-id="927ec-185">電力消費を最小限に抑えるため (ノート PC やタブレットのようなバッテリ駆動デバイスで重要)、**DeviceResources::CreateWindowSizeDependentResources** メソッドは [IDXGIDevice1::SetMaximumFrameLatency](https://msdn.microsoft.com/library/windows/desktop/ff471334) メソッドを呼び出して、垂直ブランクの後でのみゲームがレンダリングされるようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-185">To minimize power consumption, which is important to do on battery-powered devices such as laptops and tablets, the **DeviceResources::CreateWindowSizeDependentResources** method calls the [IDXGIDevice1::SetMaximumFrameLatency](https://msdn.microsoft.com/library/windows/desktop/ff471334) method to ensure that the game is rendered only after the vertical blank.</span></span> <span data-ttu-id="927ec-186">垂直ブランクとの同期は、このドキュメントで[シーンの表示](#presenting-the-scene)」セクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-186">Synchronizing with the vertical blank is described in greater detail in the section [Presenting the scene](#presenting-the-scene) in this document.</span></span>

```cpp
// Ensure that DXGI does not queue more than one frame at a time. This both 
// reduces latency and ensures that the application will only render after each
// VSync, minimizing power consumption.
DX::ThrowIfFailed(
    dxgiDevice->SetMaximumFrameLatency(1)
    );
```

<span data-ttu-id="927ec-187">**DeviceResources::CreateWindowSizeDependentResources** メソッドは、多くのゲームに対応する方法でグラフィックス リソースを初期化します。</span><span class="sxs-lookup"><span data-stu-id="927ec-187">The **DeviceResources::CreateWindowSizeDependentResources** method initializes graphics resources in a way that works for most games.</span></span>

> [!NOTE]
> <span data-ttu-id="927ec-188">*ビュー*という用語は、direct3d よりも、Windows ランタイムで異なる意味をいます。</span><span class="sxs-lookup"><span data-stu-id="927ec-188">The term *view* has a different meaning in the Windows Runtime than it has in Direct3D.</span></span> <span data-ttu-id="927ec-189">Windows ランタイムでは、ビューは、アプリのユーザー インターフェイス設定のコレクション (表示領域、入力動作、処理に使うスレッドなどを含む) を指します。</span><span class="sxs-lookup"><span data-stu-id="927ec-189">In the Windows Runtime, a view refers to the collection of user interface settings for an app, including the display area and the input behaviors, plus the thread it uses for processing.</span></span> <span data-ttu-id="927ec-190">ビューを作成するときは、必要な構成と設定を指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-190">You specify the configuration and settings you need when you create a view.</span></span> <span data-ttu-id="927ec-191">アプリのビューを設定するプロセスについては、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-191">The process of setting up the app view is described in [Marble Maze application structure](marble-maze-application-structure.md).</span></span>
> <span data-ttu-id="927ec-192">Direct3D では、ビューという用語には複数の意味があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-192">In Direct3D, the term view has multiple meanings.</span></span> <span data-ttu-id="927ec-193">リソース ビューは、リソースにアクセスできるサブリソースを定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-193">A resource view defines the subresources that a resource can access.</span></span> <span data-ttu-id="927ec-194">たとえば、テクスチャ オブジェクトがシェーダー リソース ビューに関連付けられている場合、そのシェーダーは後でテクスチャにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="927ec-194">For example, when a texture object is associated with a shader resource view, that shader can later access the texture.</span></span> <span data-ttu-id="927ec-195">リソース ビューの 1 つの長所は、レンダリング パイプラインの段階ごとに異なる方法でデータを解釈できることです。</span><span class="sxs-lookup"><span data-stu-id="927ec-195">One advantage of a resource view is that you can interpret data in different ways at different stages in the rendering pipeline.</span></span> <span data-ttu-id="927ec-196">リソース ビューについて詳しくは、[リソース ビュー](https://msdn.microsoft.com/library/windows/desktop/ff476900#Views)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-196">For more information about resource views, see [Resource Views](https://msdn.microsoft.com/library/windows/desktop/ff476900#Views).</span></span>
> <span data-ttu-id="927ec-197">ビュー変換またはビュー変換マトリックスのコンテキストで使われた場合、ビューは、カメラの位置と向きを表します。</span><span class="sxs-lookup"><span data-stu-id="927ec-197">When used in the context of a view transform or view transform matrix, view refers to the location and orientation of the camera.</span></span> <span data-ttu-id="927ec-198">ビュー変換は、カメラの位置と向きを基準として、ワールド内でオブジェクトを再配置します。</span><span class="sxs-lookup"><span data-stu-id="927ec-198">A view transform relocates objects in the world around the camera’s position and orientation.</span></span> <span data-ttu-id="927ec-199">ビュー変換について詳しくは、「[ビュー変換 (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb206342)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-199">For more information about view transforms, see [View Transform (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb206342).</span></span> <span data-ttu-id="927ec-200">Marble Maze でリソース ビューやマトリックス ビューをどのように使っているかについて、このトピックで詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-200">How Marble Maze uses resource and matrix views is described in greater detail in this topic.</span></span>

 

## <a name="loading-scene-resources"></a><span data-ttu-id="927ec-201">シーン リソースの読み込み</span><span class="sxs-lookup"><span data-stu-id="927ec-201">Loading scene resources</span></span>


<span data-ttu-id="927ec-202">Marble Maze では、 **BasicLoader.h**で宣言されている**BasicLoader**クラスを使用して、テクスチャ、シェーダーを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-202">Marble Maze uses the **BasicLoader** class, which is declared in **BasicLoader.h**, to load textures and shaders.</span></span> <span data-ttu-id="927ec-203">Marble Maze では、 **SDKMesh**クラスを使用して、迷路と大理石の 3D メッシュを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-203">Marble Maze uses the **SDKMesh** class to load the 3D meshes for the maze and the marble.</span></span>

<span data-ttu-id="927ec-204">Marble Maze では、応答性を保持するために、非同期的に (つまりバックグラウンドで) シーン リソースを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-204">To ensure a responsive app, Marble Maze loads scene resources asynchronously, or in the background.</span></span> <span data-ttu-id="927ec-205">バックグラウンドでのアセットの読み込み中、ゲームはウィンドウ イベントに応答できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-205">As assets load in the background, your game can respond to window events.</span></span> <span data-ttu-id="927ec-206">このプロセスについては、このガイドの「[バックグラウンドでのゲーム アセットの読み込み](marble-maze-application-structure.md#loading-game-assets-in-the-background)」で詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-206">This process is explained in greater detail in [Loading game assets in the background](marble-maze-application-structure.md#loading-game-assets-in-the-background) in this guide.</span></span>

###  <a name="loading-the-2d-overlay-and-user-interface"></a><span data-ttu-id="927ec-207">2 D オーバーレイとユーザー インターフェイスの読み込み</span><span class="sxs-lookup"><span data-stu-id="927ec-207">Loading the 2D overlay and user interface</span></span>

<span data-ttu-id="927ec-208">Marble Maze では、オーバーレイは、画面の一番上に表示される画像です。</span><span class="sxs-lookup"><span data-stu-id="927ec-208">In Marble Maze, the overlay is the image that appears at the top of the screen.</span></span> <span data-ttu-id="927ec-209">オーバーレイは、常にシーンの前面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-209">The overlay always appears in front of the scene.</span></span> <span data-ttu-id="927ec-210">Marble Maze では、オーバーレイには、Windows ロゴとテキスト文字列**DirectX Marble Maze ゲームのサンプル**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="927ec-210">In Marble Maze, the overlay contains the Windows logo and the text string **DirectX Marble Maze game sample**.</span></span> <span data-ttu-id="927ec-211">オーバーレイの管理は、 **SampleOverlay.h**で定義されている**SampleOverlay**クラスによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-211">The management of the overlay is performed by the **SampleOverlay** class, which is defined in **SampleOverlay.h**.</span></span> <span data-ttu-id="927ec-212">Direct3D サンプルの一部としてオーバーレイを使いますが、このコードを利用すると、シーンの前面に任意の画像を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="927ec-212">Although we use the overlay as part of the Direct3D samples, you can adapt this code to display any image that appears in front of your scene.</span></span>

<span data-ttu-id="927ec-213">オーバーレイの重要な点の 1 つは、コンテンツが変化しないため、**SampleOverlay** クラスが初期化中にコンテンツを [ID2D1Bitmap1](https://msdn.microsoft.com/library/windows/desktop/hh404349) オブジェクトに描画またはキャッシュすることです。</span><span class="sxs-lookup"><span data-stu-id="927ec-213">One important aspect of the overlay is that, because its contents do not change, the **SampleOverlay** class draws, or caches, its contents to an [ID2D1Bitmap1](https://msdn.microsoft.com/library/windows/desktop/hh404349) object during initialization.</span></span> <span data-ttu-id="927ec-214">描画時に **SampleOverlay** クラスが行う必要があるのは、画面にビットマップを描画することだけです。</span><span class="sxs-lookup"><span data-stu-id="927ec-214">At draw time, the **SampleOverlay** class only has to draw the bitmap to the screen.</span></span> <span data-ttu-id="927ec-215">このように、テキスト描画などコストの高いルーチンを、すべてのフレームで実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="927ec-215">In this way, expensive routines such as text drawing do not have to be performed for every frame.</span></span>

<span data-ttu-id="927ec-216">ユーザー インターフェイス (UI) は、メニューや、シーンの前面に表示するヘッドアップ ディスプレイ (Hud) などの 2D コンポーネントで構成されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-216">The user interface (UI) consists of 2D components, such as menus and heads-up displays (HUDs), which appear in front of your scene.</span></span> <span data-ttu-id="927ec-217">Marble Maze では、次の UI 要素を定義しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-217">Marble Maze defines the following UI elements:</span></span>

-   <span data-ttu-id="927ec-218">ユーザーがゲームを開始したりハイ スコアを表示できるようにするためのメニュー項目。</span><span class="sxs-lookup"><span data-stu-id="927ec-218">Menu items that enable the user to start the game or view high scores.</span></span>
-   <span data-ttu-id="927ec-219">プレイ開始までの 3 秒をカウント ダウンするタイマー。</span><span class="sxs-lookup"><span data-stu-id="927ec-219">A timer that counts down for three seconds before play begins.</span></span>
-   <span data-ttu-id="927ec-220">経過したプレイ時間を追跡するタイマー。</span><span class="sxs-lookup"><span data-stu-id="927ec-220">A timer that tracks the elapsed play time.</span></span>
-   <span data-ttu-id="927ec-221">最速記録を表示する表。</span><span class="sxs-lookup"><span data-stu-id="927ec-221">A table that lists the fastest finish times.</span></span>
-   <span data-ttu-id="927ec-222">**ゲームが一時停止したときに paused**テキストです。</span><span class="sxs-lookup"><span data-stu-id="927ec-222">Text that reads **Paused** when the game is paused.</span></span>

<span data-ttu-id="927ec-223">Marble Maze は、ゲーム固有の UI 要素を**UserInterface.h**に定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-223">Marble Maze defines game-specific UI elements in **UserInterface.h**.</span></span> <span data-ttu-id="927ec-224">Marble Maze では、**ElementBase** クラスをすべての UI 要素の基本型として定義しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-224">Marble Maze defines the **ElementBase** class as a base type for all UI elements.</span></span> <span data-ttu-id="927ec-225">**ElementBase** クラスは、UI 要素のサイズ、位置、配置、可視性などの属性を定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-225">The **ElementBase** class defines attributes such as the size, position, alignment, and visibility of a UI element.</span></span> <span data-ttu-id="927ec-226">さらに、要素の更新方法やレンダリング方法も制御します。</span><span class="sxs-lookup"><span data-stu-id="927ec-226">It also controls how elements are updated and rendered.</span></span>

```cpp
class ElementBase
{
public:
    virtual void Initialize() { }
    virtual void Update(float timeTotal, float timeDelta) { }
    virtual void Render() { }

    void SetAlignment(AlignType horizontal, AlignType vertical);
    virtual void SetContainer(const D2D1_RECT_F& container);
    void SetVisible(bool visible);

    D2D1_RECT_F GetBounds();

    bool IsVisible() const { return m_visible; }

protected:
    ElementBase();

    virtual void CalculateSize() { }

    Alignment       m_alignment;
    D2D1_RECT_F     m_container;
    D2D1_SIZE_F     m_size;
    bool            m_visible;
};
```

<span data-ttu-id="927ec-227">UI 要素の共通基底クラスを提供することで、ユーザー インターフェイスを管理する **UserInterface** クラスが行う必要があるのは、**ElementBase** オブジェクトのコレクションの保持のみになります。これにより、UI の管理が簡略化され、再利用可能なユーザー インターフェイス マネージャーが提供されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-227">By providing a common base class for UI elements, the **UserInterface** class, which manages the user interface, need only hold a collection of **ElementBase** objects, which simplifies UI management and provides a user interface manager that is reusable.</span></span> <span data-ttu-id="927ec-228">Marble Maze では、ゲーム固有の動作を実装する型を **ElementBase** から派生させて定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-228">Marble Maze defines types that derive from **ElementBase** that implement game-specific behaviors.</span></span> <span data-ttu-id="927ec-229">たとえば、**HighScoreTable** は、ハイ スコア表の動作を定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-229">For example, **HighScoreTable** defines the behavior for the high score table.</span></span> <span data-ttu-id="927ec-230">これらの型について詳しくは、ソース コードをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-230">For more info about these types, refer to the source code.</span></span>

> [!NOTE]
> <span data-ttu-id="927ec-231">XAML を使用すると、シミュレーション ゲームや戦略ゲーム、見などの複雑なユーザー インターフェイスをより簡単に作成されるため、XAML を使って、UI を定義するかどうかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-231">Because XAML enables you to more easily create complex user interfaces, like those found in simulation and strategy games, consider whether to use XAML to define your UI.</span></span> <span data-ttu-id="927ec-232">DirectX UWP ゲームで XAML ユーザー インターフェイスを開発する方法について詳しくは、[拡張ゲームのサンプル](tutorial-resources.md)、DirectX 3D シューティング ゲームのサンプルを参照するを参照してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-232">For info about how to develop a user interface in XAML in a DirectX UWP game, see [Extend the game sample](tutorial-resources.md), which refers to the DirectX 3D shooting game sample.</span></span>

 

###  <a name="loading-shaders"></a><span data-ttu-id="927ec-233">シェーダーの読み込み</span><span class="sxs-lookup"><span data-stu-id="927ec-233">Loading shaders</span></span>

<span data-ttu-id="927ec-234">Marble Maze では、**BasicLoader::LoadShader** メソッドを使ってファイルからシェーダーを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-234">Marble Maze uses the **BasicLoader::LoadShader** method to load a shader from a file.</span></span>

<span data-ttu-id="927ec-235">シェーダーは、現在のゲームの GPU プログラミングの基本単位です。</span><span class="sxs-lookup"><span data-stu-id="927ec-235">Shaders are the fundamental unit of GPU programming in games today.</span></span> <span data-ttu-id="927ec-236">ほぼすべての 3D グラフィックス処理は、シェーダーがモデル変換やシーンの照明の適用、またはより複雑なジオメトリ処理、文字は、テセレーションにスキンからによって駆動されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-236">Nearly all 3D graphics processing is driven through shaders, whether it is model transformation and scene lighting, or more complex geometry processing, from character skinning to tessellation.</span></span> <span data-ttu-id="927ec-237">シェーダーのプログラミング モデルについて詳しくは、「[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-237">For more information about the shader programming model, see [HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561).</span></span>

<span data-ttu-id="927ec-238">Marble Maze では、頂点シェーダーとピクセル シェーダーを使っています。</span><span class="sxs-lookup"><span data-stu-id="927ec-238">Marble Maze uses vertex and pixel shaders.</span></span> <span data-ttu-id="927ec-239">頂点シェーダーは、常に、入力された 1 つの頂点を処理し、出力として 1 つの頂点を生成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-239">A vertex shader always operates on one input vertex and produces one vertex as output.</span></span> <span data-ttu-id="927ec-240">ピクセル シェーダーは、数値、テクスチャ データ、補間された頂点単位の値、その他のデータを受け取り、出力としてピクセル色を生成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-240">A pixel shader takes numeric values, texture data, interpolated per-vertex values, and other data to produce a pixel color as output.</span></span> <span data-ttu-id="927ec-241">1 つのシェーダーは一度に 1 つの要素を変換するため、複数のシェーダー パイプラインを提供するグラフィックス ハードウェアは要素のセットを並列処理できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-241">Because a shader transforms one element at a time, graphics hardware that provides multiple shader pipelines can process sets of elements in parallel.</span></span> <span data-ttu-id="927ec-242">GPU で使用できる並列パイプラインの数は、CPU で使用可能な数を大きく上回る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-242">The number of parallel pipelines that are available to the GPU can be vastly greater than the number that is available to the CPU.</span></span> <span data-ttu-id="927ec-243">したがって、基本的なシェーダーでさえスループットを大幅に向上することができます。</span><span class="sxs-lookup"><span data-stu-id="927ec-243">Therefore, even basic shaders can greatly improve throughput.</span></span>

<span data-ttu-id="927ec-244">**Marblemazemain::loaddeferredresources**メソッドは、オーバーレイを読み込んだ後、1 つの頂点シェーダーと 1 つのピクセル シェーダーを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-244">The **MarbleMazeMain::LoadDeferredResources** method loads one vertex shader and one pixel shader after it loads the overlay.</span></span> <span data-ttu-id="927ec-245">これらのシェーダーの設計時のバージョンは、 **BasicVertexShader.hlsl**と**BasicPixelShader.hlsl**でそれぞれ定義されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-245">The design-time versions of these shaders are defined in **BasicVertexShader.hlsl** and **BasicPixelShader.hlsl**, respectively.</span></span> <span data-ttu-id="927ec-246">Marble Maze では、レンダリング フェーズでこれらのシェーダーをボールと迷路の両方に適用します。</span><span class="sxs-lookup"><span data-stu-id="927ec-246">Marble Maze applies these shaders to both the ball and the maze during the rendering phase.</span></span>

<span data-ttu-id="927ec-247">Marble Maze プロジェクトには、シェーダー ファイルの .hlsl バージョン (設計時の形式) と .cso バージョン (実行時形式) の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="927ec-247">The Marble Maze project includes both .hlsl (the design-time format) and .cso (the run-time format) versions of the shader files.</span></span> <span data-ttu-id="927ec-248">ビルド時に Visual Studio が fxc.exe エフェクト コンパイラを使って .hlsl ソース ファイルを .cso バイナリ シェーダーにコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="927ec-248">At build time, Visual Studio uses the fxc.exe effect-compiler to compile your .hlsl source file into a .cso binary shader.</span></span> <span data-ttu-id="927ec-249">エフェクト コンパイラ ツールについて詳しくは、「[エフェクト コンパイラ ツール](https://msdn.microsoft.com/library/windows/desktop/bb232919)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-249">For more information about the effect-compiler tool, see [Effect-Compiler Tool](https://msdn.microsoft.com/library/windows/desktop/bb232919).</span></span>

<span data-ttu-id="927ec-250">頂点シェーダーは、指定されたモデル マトリックス、ビュー マトリックス、プロジェクション マトリックスを使って、入力ジオメトリを変換します。</span><span class="sxs-lookup"><span data-stu-id="927ec-250">The vertex shader uses the supplied model, view and projection matrices to transform the input geometry.</span></span> <span data-ttu-id="927ec-251">入力ジオメトリの位置データは変換されて、2 回出力されます。まずレンダリングのために必要な画面空間内に出力され、ピクセル シェーダーが照明計算を実行できるように再びワールド空間内に出力されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-251">Position data from the input geometry is transformed and output twice: once in screen space, which is necessary for rendering, and again in world space to enable the pixel shader to perform lighting calculations.</span></span> <span data-ttu-id="927ec-252">サーフェスの標準ベクターはワールド空間に変換されます。これも、これもピクセル シェーダーが照明のために使います。</span><span class="sxs-lookup"><span data-stu-id="927ec-252">The surface normal vector is transformed to world space, which is also used by the pixel shader for lighting.</span></span> <span data-ttu-id="927ec-253">テクスチャ座標は、変更されずにピクセル シェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-253">The texture coordinates are passed through unchanged to the pixel shader.</span></span>

```hlsl
sPSInput main(sVSInput input)
{
    sPSInput output;
    float4 temp = float4(input.pos, 1.0f);
    temp = mul(temp, model);
    output.worldPos = temp.xyz / temp.w;
    temp = mul(temp, view);
    temp = mul(temp, projection);
    output.pos = temp;
    output.tex = input.tex;
    output.norm = mul(float4(input.norm, 0.0f), model).xyz;
    return output;
}
```

<span data-ttu-id="927ec-254">ピクセル シェーダーは、頂点シェーダーの出力を入力として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="927ec-254">The pixel shader receives the output of the vertex shader as input.</span></span> <span data-ttu-id="927ec-255">このシェーダーは照明計算を実行して、輪郭がぼやけたスポットライトを模倣します。このライトは、大理石の位置に合わせて迷路上を動きます。</span><span class="sxs-lookup"><span data-stu-id="927ec-255">This shader performs lighting calculations to mimic a soft-edged spotlight that hovers over the maze and is aligned with the position of the marble.</span></span> <span data-ttu-id="927ec-256">照明は、光に直面するサーフェスで最も強くなります。</span><span class="sxs-lookup"><span data-stu-id="927ec-256">Lighting is strongest for surfaces that point directly toward the light.</span></span> <span data-ttu-id="927ec-257">サーフェス法線が光に対して直角になるにつれて、拡散コンポーネントは減少してゼロになります。また、法線の向きが光から離れるにつれて、環境光が減少します。</span><span class="sxs-lookup"><span data-stu-id="927ec-257">The diffuse component tapers off to zero as the surface normal becomes perpendicular to the light, and the ambient term diminishes as the normal points away from the light.</span></span> <span data-ttu-id="927ec-258">大理石に近い (つまりスポットライトの中央に近い) ほど照明が強くなります。</span><span class="sxs-lookup"><span data-stu-id="927ec-258">Points closer to the marble (and therefore closer to the center of the spotlight) are lit more strongly.</span></span> <span data-ttu-id="927ec-259">ただし、大理石の下では柔らかい影をシミュレートするために、照明が調整されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-259">However, lighting is modulated for points underneath the marble to simulate a soft shadow.</span></span> <span data-ttu-id="927ec-260">実際の環境では、白い大理石のようなオブジェクトは、シーンの他のオブジェクトに拡散的にスポットライトを反射します。</span><span class="sxs-lookup"><span data-stu-id="927ec-260">In a real environment, an object like the white marble would diffusely reflect the spotlight onto other objects in the scene.</span></span> <span data-ttu-id="927ec-261">これは、大理石の明るい側の半球のビューにあるサーフェスについて概算されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-261">This is approximated for the surfaces that are in view of the bright half of the marble.</span></span> <span data-ttu-id="927ec-262">照明のその他の係数は、大理石に対する相対的な角度と距離です。</span><span class="sxs-lookup"><span data-stu-id="927ec-262">The additional illumination factors are in relative angle and distance to the marble.</span></span> <span data-ttu-id="927ec-263">生成されるピクセル色は、サンプリングされたテクスチャと照明計算の結果を合成したものになります。</span><span class="sxs-lookup"><span data-stu-id="927ec-263">The resulting pixel color is a composition of the sampled texture with the result of the lighting calculations.</span></span>

```hlsl
float4 main(sPSInput input) : SV_TARGET
{
    float3 lightDirection = float3(0, 0, -1);
    float3 ambientColor = float3(0.43, 0.31, 0.24);
    float3 lightColor = 1 - ambientColor;
    float spotRadius = 50;

    // Basic ambient (Ka) and diffuse (Kd) lighting from above.
    float3 N = normalize(input.norm);
    float NdotL = dot(N, lightDirection);
    float Ka = saturate(NdotL + 1);
    float Kd = saturate(NdotL);

    // Spotlight.
    float3 vec = input.worldPos - marblePosition;
    float dist2D = sqrt(dot(vec.xy, vec.xy));
    Kd = Kd * saturate(spotRadius / dist2D);

    // Shadowing from ball.
    if (input.worldPos.z > marblePosition.z)
        Kd = Kd * saturate(dist2D / (marbleRadius * 1.5));

    // Diffuse reflection of light off ball.
    float dist3D = sqrt(dot(vec, vec));
    float3 V = normalize(vec);
    Kd += saturate(dot(-V, N)) * saturate(dot(V, lightDirection))
        * saturate(marbleRadius / dist3D);

    // Final composite.
    float4 diffuseTexture = Texture.Sample(Sampler, input.tex);
    float3 color = diffuseTexture.rgb * ((ambientColor * Ka) + (lightColor * Kd));
    return float4(color * lightStrength, diffuseTexture.a);
}
```

> [!WARNING]
> <span data-ttu-id="927ec-264">コンパイルされたピクセル シェーダーには、32 の演算命令と 1 つのテクスチャ命令が含まれています。</span><span class="sxs-lookup"><span data-stu-id="927ec-264">The compiled pixel shader contains 32 arithmetic instructions and 1 texture instruction.</span></span> <span data-ttu-id="927ec-265">このシェーダーは、デスクトップ コンピューターとハイエンドのタブレットで正常に動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-265">This shader should perform well on desktop computers and higher-end tablets.</span></span> <span data-ttu-id="927ec-266">ただし、ローエンドのコンピューターでは、このシェーダーを処理することができず、対話型のフレーム レートが提供される場合があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-266">However, a lower-end computer might not be able to process this shader and still provide an interactive frame rate.</span></span> <span data-ttu-id="927ec-267">対象ユーザーの標準的なハードウェアを検討し、そのハードウェアの性能に合わせてシェーダーを設計します。</span><span class="sxs-lookup"><span data-stu-id="927ec-267">Consider the typical hardware of your target audience and design your shaders to meet the capabilities of that hardware.</span></span>

 

<span data-ttu-id="927ec-268">**Marblemazemain::loaddeferredresources**メソッドでは、 **basicloader::loadshader**メソッドを使用して、シェーダーを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-268">The **MarbleMazeMain::LoadDeferredResources** method uses the **BasicLoader::LoadShader** method to load the shaders.</span></span> <span data-ttu-id="927ec-269">次の例では、頂点シェーダーを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-269">The following example loads the vertex shader.</span></span> <span data-ttu-id="927ec-270">このシェーダーの実行時形式は**basicvertexshader.cso です**。</span><span class="sxs-lookup"><span data-stu-id="927ec-270">The run-time format for this shader is **BasicVertexShader.cso**.</span></span> <span data-ttu-id="927ec-271">**m\_vertexShader** メンバー変数は [ID3D11VertexShader](https://msdn.microsoft.com/library/windows/desktop/ff476641) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="927ec-271">The **m\_vertexShader** member variable is an [ID3D11VertexShader](https://msdn.microsoft.com/library/windows/desktop/ff476641) object.</span></span>

```cpp
BasicLoader^ loader = ref new BasicLoader(m_deviceResources->GetD3DDevice());

D3D11_INPUT_ELEMENT_DESC layoutDesc [] =
{
    { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
    { "NORMAL", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
    { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
    { "TANGENT", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 32, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};
m_vertexStride = 44; // must set this to match the size of layoutDesc above

Platform::String^ vertexShaderName = L"BasicVertexShader.cso";
loader->LoadShader(
    vertexShaderName,
    layoutDesc,
    ARRAYSIZE(layoutDesc),
    &m_vertexShader,
    &m_inputLayout
    );
```

<span data-ttu-id="927ec-272">**m\_inputLayout** メンバー変数は [ID3D11InputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476575) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="927ec-272">The **m\_inputLayout** member variable is an [ID3D11InputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476575) object.</span></span> <span data-ttu-id="927ec-273">入力レイアウト オブジェクトは、入力アセンブラー (IA) ステージの入力状態をカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="927ec-273">The input-layout object encapsulates the input state of the input assembler (IA) stage.</span></span> <span data-ttu-id="927ec-274">IA ステージの 1 つの仕事は、シェーダーの効率を向上することです。システム生成値 (*セマンティクス*) を使って、まだ処理されていないプリミティブまたは頂点のみを処理します。</span><span class="sxs-lookup"><span data-stu-id="927ec-274">One job of the IA stage is to make shaders more efficient by using system-generated values, also known as *semantics*, to process only those primitives or vertices that have not already been processed.</span></span>

<span data-ttu-id="927ec-275">[ID3D11Device::CreateInputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476512) メソッドを使って、入力要素の説明の配列から入力レイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="927ec-275">Use the [ID3D11Device::CreateInputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476512) method to create an input-layout from an array of input-element descriptions.</span></span> <span data-ttu-id="927ec-276">配列には 1 つまたは複数の入力要素が含まれます。各入力要素は、1 つの頂点バッファーの 1 つの頂点データ要素を記述します。</span><span class="sxs-lookup"><span data-stu-id="927ec-276">The array contains one or more input elements; each input element describes one vertex-data element from one vertex buffer.</span></span> <span data-ttu-id="927ec-277">入力要素の記述のセット全体によって、IA ステージにバインドされているすべての頂点バッファーのすべての頂点データ要素を記述します。</span><span class="sxs-lookup"><span data-stu-id="927ec-277">The entire set of input-element descriptions describes all of the vertex-data elements from all of the vertex buffers that will be bound to the IA stage.</span></span> 

<span data-ttu-id="927ec-278">**layoutDesc**上記のコード スニペットでは、Marble Maze でレイアウトの記述を示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-278">**layoutDesc** in the above code snippet shows the layout description that Marble Maze uses.</span></span> <span data-ttu-id="927ec-279">このレイアウトの記述には、4 つの頂点データ要素を含む頂点バッファーが記述されています。</span><span class="sxs-lookup"><span data-stu-id="927ec-279">The layout description describes a vertex buffer that contains four vertex-data elements.</span></span> <span data-ttu-id="927ec-280">配列の各エントリの重要な部分は、セマンティック名、データ形式、バイト オフセットです。</span><span class="sxs-lookup"><span data-stu-id="927ec-280">The important parts of each entry in the array are the semantic name, data format, and byte offset .</span></span> <span data-ttu-id="927ec-281">たとえば、**POSITION** 要素は、オブジェクト空間での頂点の位置を指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-281">For example, the **POSITION** element specifies the vertex position in object space.</span></span> <span data-ttu-id="927ec-282">これは、バイト オフセット 0 で開始し、3 つの浮動小数点コンポーネントを含みます (合計 12 バイト)。</span><span class="sxs-lookup"><span data-stu-id="927ec-282">It starts at byte offset 0 and contains three floating-point components (for a total of 12 bytes).</span></span> <span data-ttu-id="927ec-283">**NORMAL** 要素は、標準ベクターを指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-283">The **NORMAL** element specifies the normal vector.</span></span> <span data-ttu-id="927ec-284">これはバイト オフセット 12 で開始します。レイアウトで、12 バイトを必要とする **POSITION** の後にあるためです。</span><span class="sxs-lookup"><span data-stu-id="927ec-284">It starts at byte offset 12 because it appears directly after **POSITION** in the layout, which requires 12 bytes.</span></span> <span data-ttu-id="927ec-285">**NORMAL** 要素は、4 つの要素で構成される 32 ビット符号なし整数を含みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-285">The **NORMAL** element contains a four-component, 32-bit unsigned-integer.</span></span>

<span data-ttu-id="927ec-286">次の例に示すように、頂点シェーダーによって定義される **sVSInput** 構造体と入力レイアウトを比較します。</span><span class="sxs-lookup"><span data-stu-id="927ec-286">Compare the input layout with the **sVSInput** structure that is defined by the vertex shader, as shown in the following example.</span></span> <span data-ttu-id="927ec-287">**sVSInput** 構造体は、**POSITION**、**NORMAL**、**TEXCOORD0** の各要素を定義します。</span><span class="sxs-lookup"><span data-stu-id="927ec-287">The **sVSInput** structure defines the **POSITION**, **NORMAL**, and **TEXCOORD0** elements.</span></span> <span data-ttu-id="927ec-288">DirectX ランタイムは、シェーダーによって定義された入力構造体にレイアウトの各要素をマップします。</span><span class="sxs-lookup"><span data-stu-id="927ec-288">The DirectX runtime maps each element in the layout to the input structure that is defined by the shader.</span></span>

```hlsl
struct sVSInput
{
    float3 pos : POSITION;
    float3 norm : NORMAL;
    float2 tex : TEXCOORD0;
};

struct sPSInput
{
    float4 pos : SV_POSITION;
    float3 norm : NORMAL;
    float2 tex : TEXCOORD0;
    float3 worldPos : TEXCOORD1;
};

sPSInput main(sVSInput input)
{
    sPSInput output;
    float4 temp = float4(input.pos, 1.0f);
    temp = mul(temp, model);
    output.worldPos = temp.xyz / temp.w;
    temp = mul(temp, view);
    temp = mul(temp, projection);
    output.pos = temp;
    output.tex = input.tex;
    output.norm = mul(float4(input.norm, 0.0f), model).xyz;
    return output;
}
```

<span data-ttu-id="927ec-289">「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」では、使用できるセマンティクスのそれぞれについてさらに詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-289">The document [Semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647) describes each of the available semantics in greater detail.</span></span>

> [!NOTE]
> <span data-ttu-id="927ec-290">レイアウトでは、同じレイアウトを共有する複数のシェーダーを有効にするのには使用されていないその他のコンポーネントを指定できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-290">In a layout, you can specify additional components that are not used to enable multiple shaders to share the same layout.</span></span> <span data-ttu-id="927ec-291">たとえば、**TANGENT** 要素はシェーダーでは使われません。</span><span class="sxs-lookup"><span data-stu-id="927ec-291">For example, the **TANGENT** element is not used by the shader.</span></span> <span data-ttu-id="927ec-292">法線マッピングなどの手法を使う場合は、**TANGENT** 要素を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="927ec-292">You can use the **TANGENT** element if you want to experiment with techniques such as normal mapping.</span></span> <span data-ttu-id="927ec-293">法線マッピング (バンプ マッピング) を使うと、オブジェクトのサーフェスに対してバンプ エフェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-293">By using normal mapping, also known as bump mapping, you can create the effect of bumps on the surfaces of objects.</span></span> <span data-ttu-id="927ec-294">バンプ マッピングについて詳しくは、「[バンプ マッピング (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb172379)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-294">For more information about bump mapping, see [Bump Mapping (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb172379).</span></span>

 

<span data-ttu-id="927ec-295">入力アセンブリ ステージについて詳しくは、[入力アセンブラー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205116)と[、入力アセンブラー ステージの概要](https://msdn.microsoft.com/library/windows/desktop/bb205117)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-295">For more information about the input assembly stage, see [Input-Assembler Stage](https://msdn.microsoft.com/library/windows/desktop/bb205116) and [Getting Started with the Input-Assembler Stage](https://msdn.microsoft.com/library/windows/desktop/bb205117).</span></span>

<span data-ttu-id="927ec-296">頂点シェーダーとピクセル シェーダーを使ってシーンをレンダリングするプロセスについては、このドキュメントの「[シーンのレンダリング](#rendering-the-scene)」で説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-296">The process of using the vertex and pixel shaders to render the scene are described in the section [Rendering the scene](#rendering-the-scene) later in this document.</span></span>

### <a name="creating-the-constant-buffer"></a><span data-ttu-id="927ec-297">定数バッファーの作成</span><span class="sxs-lookup"><span data-stu-id="927ec-297">Creating the constant buffer</span></span>

<span data-ttu-id="927ec-298">Direct3D バッファーは、データのコレクションをグループ化します。</span><span class="sxs-lookup"><span data-stu-id="927ec-298">Direct3D buffer groups a collection of data.</span></span> <span data-ttu-id="927ec-299">定数バッファーは、シェーダーにデータを渡すために使うことができるバッファーの種類の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="927ec-299">A constant buffer is a kind of buffer that you can use to pass data to shaders.</span></span> <span data-ttu-id="927ec-300">Marble Maze では、定数バッファーを使って、モデル (またはワールド) ビューと、アクティブなシーン オブジェクトのためのプロジェクション マトリックスを保持します。</span><span class="sxs-lookup"><span data-stu-id="927ec-300">Marble Maze uses a constant buffer to hold the model (or world) view, and the projection matrices for the active scene object.</span></span>

<span data-ttu-id="927ec-301">次の例では、 **marblemazemain::loaddeferredresources**メソッドは後でマトリックス データを保持する定数バッファーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-301">The following example shows how the **MarbleMazeMain::LoadDeferredResources** method creates a constant buffer that will later hold matrix data.</span></span> <span data-ttu-id="927ec-302">この例では、**D3D11\_BIND\_CONSTANT\_BUFFER** フラグを使って定数バッファーとしての使用を指定する **D3D11\_BUFFER\_DESC** 構造体を作成しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-302">The example creates a **D3D11\_BUFFER\_DESC** structure that uses the **D3D11\_BIND\_CONSTANT\_BUFFER** flag to specify usage as a constant buffer.</span></span> <span data-ttu-id="927ec-303">この例では、次にこの構造体を [ID3D11Device::CreateBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476501) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="927ec-303">This example then passes that structure to the [ID3D11Device::CreateBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476501) method.</span></span> <span data-ttu-id="927ec-304">**m\_constantBuffer** 変数は [ID3D11Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476351) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="927ec-304">The **m\_constantBuffer** variable is an [ID3D11Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476351) object.</span></span>

```cpp
// Create the constant buffer for updating model and camera data.
D3D11_BUFFER_DESC constantBufferDesc = {0};

// Multiple of 16 bytes
constantBufferDesc.ByteWidth = ((sizeof(ConstantBuffer) + 15) / 16) * 16;

constantBufferDesc.Usage               = D3D11_USAGE_DEFAULT;
constantBufferDesc.BindFlags           = D3D11_BIND_CONSTANT_BUFFER;
constantBufferDesc.CPUAccessFlags      = 0;
constantBufferDesc.MiscFlags           = 0;

// This will not be used as a structured buffer, so this parameter is ignored.
constantBufferDesc.StructureByteStride = 0;

DX::ThrowIfFailed(
    m_deviceResources->GetD3DDevice()->CreateBuffer(
        &constantBufferDesc,
        nullptr,    // leave the buffer uninitialized
        &m_constantBuffer
        )
    );
```

<span data-ttu-id="927ec-305">**Marblemazemain::update**メソッドは、後で、 **ConstantBuffer**オブジェクト、迷路用と大理石のいずれかを更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-305">The **MarbleMazeMain::Update** method later updates **ConstantBuffer** objects, one for the maze and one for the marble.</span></span> <span data-ttu-id="927ec-306">**Marblemazemain::render**メソッドは、各オブジェクトをレンダリングする前に、各**ConstantBuffer**オブジェクトと定数バッファーをバインドします。</span><span class="sxs-lookup"><span data-stu-id="927ec-306">The **MarbleMazeMain::Render** method then binds each **ConstantBuffer** object to the constant buffer before each object is rendered.</span></span> <span data-ttu-id="927ec-307">次の例では、 **MarbleMazeMain.h**内にある**ConstantBuffer**構造を示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-307">The following example shows the **ConstantBuffer** structure, which is in **MarbleMazeMain.h**.</span></span>

```cpp
// Describes the constant buffer that draws the meshes.
struct ConstantBuffer
{
    XMFLOAT4X4 model;
    XMFLOAT4X4 view;
    XMFLOAT4X4 projection;

    XMFLOAT3 marblePosition;
    float marbleRadius;
    float lightStrength;
};
```

<span data-ttu-id="927ec-308">定数バッファーのマップを理解するためにシェーダーのコードを**BasicVertexShader.hlsl で頂点シェーダーで定義されている**ConstantBuffer**定数バッファーに**MarbleMazeMain.h**で**ConstantBuffer**構造体を比較します**:</span><span class="sxs-lookup"><span data-stu-id="927ec-308">To better understand how constant buffers map to shader code, compare the **ConstantBuffer** structure in **MarbleMazeMain.h** to the **ConstantBuffer** constant buffer that is defined by the vertex shader in **BasicVertexShader.hlsl**:</span></span>

```hlsl
cbuffer ConstantBuffer : register(b0)
{
    matrix model;
    matrix view;
    matrix projection;
    float3 marblePosition;
    float marbleRadius;
    float lightStrength;
};
```

<span data-ttu-id="927ec-309">**ConstantBuffer** 構造体のレイアウトは、**cbuffer** オブジェクトと一致します。</span><span class="sxs-lookup"><span data-stu-id="927ec-309">The layout of the **ConstantBuffer** structure matches the **cbuffer** object.</span></span> <span data-ttu-id="927ec-310">**cbuffer** 変数は、レジスタ b0 を指定します。つまり、定数バッファー データがレジスタ 0 に格納されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-310">The **cbuffer** variable specifies register b0, which means that the constant buffer data is stored in register 0.</span></span> <span data-ttu-id="927ec-311">**Marblemazemain::render**メソッドは、定数バッファーをアクティブ化するときに、レジスタ 0 を指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-311">The **MarbleMazeMain::Render** method specifies register 0 when it activates the constant buffer.</span></span> <span data-ttu-id="927ec-312">このプロセスについては、このドキュメントの後の方で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-312">This process is described in greater detail later in this document.</span></span>

<span data-ttu-id="927ec-313">定数バッファーについて詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-313">For more information about constant buffers, see [Introduction to Buffers in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476898).</span></span> <span data-ttu-id="927ec-314">register キーワードについて詳しくは、「[register](https://msdn.microsoft.com/library/windows/desktop/dd607359)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-314">For more information about the register keyword, see [register](https://msdn.microsoft.com/library/windows/desktop/dd607359).</span></span>

###  <a name="loading-meshes"></a><span data-ttu-id="927ec-315">メッシュの読み込み</span><span class="sxs-lookup"><span data-stu-id="927ec-315">Loading meshes</span></span>

<span data-ttu-id="927ec-316">Marble Maze では、実行時の形式として SDK メッシュを使います。この形式では、サンプル アプリケーションのメッシュ データを読み込む基本的な方法が提供されるためです。</span><span class="sxs-lookup"><span data-stu-id="927ec-316">Marble Maze uses SDK-Mesh as the run-time format because this format provides a basic way to load mesh data for sample applications.</span></span> <span data-ttu-id="927ec-317">本番で使うには、ゲーム固有の要件を満たすメッシュ形式を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-317">For production use, you should use a mesh format that meets the specific requirements of your game.</span></span>

<span data-ttu-id="927ec-318">**Marblemazemain::loaddeferredresources**メソッドは、頂点シェーダーとピクセル シェーダーを読み込んだ後に、メッシュ データを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="927ec-318">The **MarbleMazeMain::LoadDeferredResources** method loads mesh data after it loads the vertex and pixel shaders.</span></span> <span data-ttu-id="927ec-319">メッシュは頂点データのコレクションです。多くの場合、位置、法線データ、色、素材、テクスチャ座標などの情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="927ec-319">A mesh is a collection of vertex data that often includes information such as positions, normal data, colors, materials, and texture coordinates.</span></span> <span data-ttu-id="927ec-320">メッシュは通常 3D オーサリング ソフトウェアで作成し、アプリケーション コードとは別のファイルに保持されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-320">Meshes are typically created in 3D authoring software and maintained in files that are separate from application code.</span></span> <span data-ttu-id="927ec-321">大理石と迷路は、このゲームに使われているメッシュの 2 つの例です。</span><span class="sxs-lookup"><span data-stu-id="927ec-321">The marble and the maze are two examples of meshes that the game uses.</span></span>

<span data-ttu-id="927ec-322">Marble Maze では、**SDKMesh** クラスを使ってメッシュを管理します。</span><span class="sxs-lookup"><span data-stu-id="927ec-322">Marble Maze uses the **SDKMesh** class to manage meshes.</span></span> <span data-ttu-id="927ec-323">このクラスは**SDKMesh.h**で宣言されています。</span><span class="sxs-lookup"><span data-stu-id="927ec-323">This class is declared in **SDKMesh.h**.</span></span> <span data-ttu-id="927ec-324">**SDKMesh** は、メッシュ データを読み込み、レンダリングし、破棄するためのメソッドを提供します。</span><span class="sxs-lookup"><span data-stu-id="927ec-324">**SDKMesh** provides methods to load, render, and destroy mesh data.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="927ec-325">Marble Maze では、SDK メッシュ形式を使用して、 **SDKMesh**クラスを提供するだけです。</span><span class="sxs-lookup"><span data-stu-id="927ec-325">Marble Maze uses the SDK-Mesh format and provides the **SDKMesh** class for illustration only.</span></span> <span data-ttu-id="927ec-326">SDK メッシュ形式は学習用やプロトタイプの作成用に役立ちますが、ごく基本的な形式であるため、多くのゲーム開発の要件を満たさない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-326">Although the SDK-Mesh format is useful for learning, and for creating prototypes, it is a very basic format that might not meet the requirements of most game development.</span></span> <span data-ttu-id="927ec-327">ゲーム固有の要件を満たすメッシュ形式を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="927ec-327">We recommend that you use a mesh format that meets the specific requirements of your game.</span></span>

 

<span data-ttu-id="927ec-328">次の例では、 **marblemazemain::loaddeferredresources**メソッドが**sdkmesh::create**メソッドを使用して、迷路とボールのメッシュ データをロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-328">The following example shows how the **MarbleMazeMain::LoadDeferredResources** method uses the **SDKMesh::Create** method to load mesh data for the maze and for the ball.</span></span>

```cpp
// Load the meshes.
DX::ThrowIfFailed(
    m_mazeMesh.Create(
        m_deviceResources->GetD3DDevice(),
        L"Media\\Models\\maze1.sdkmesh",
        false
        )
    );

DX::ThrowIfFailed(
    m_marbleMesh.Create(
        m_deviceResources->GetD3DDevice(),
        L"Media\\Models\\marble2.sdkmesh",
        false
        )
    );
```

###  <a name="loading-collision-data"></a><span data-ttu-id="927ec-329">衝突データの読み込み</span><span class="sxs-lookup"><span data-stu-id="927ec-329">Loading collision data</span></span>

<span data-ttu-id="927ec-330">ここでは、Marble Maze で大理石と迷路の間の物理シミュレーションを実装する方法を特に説明しませんが、メッシュが読み込まれるときに物理システムのメッシュ ジオメトリが読み取られる点に注目してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-330">Although this section does not focus on how Marble Maze implements the physics simulation between the marble and the maze, note that mesh geometry for the physics system is read when the meshes are loaded.</span></span>

```cpp
// Extract mesh geometry for the physics system.
DX::ThrowIfFailed(
    ExtractTrianglesFromMesh(
        m_mazeMesh,
        "Mesh_walls",
        m_collision.m_wallTriList
        )
    );

DX::ThrowIfFailed(
    ExtractTrianglesFromMesh(
        m_mazeMesh,
        "Mesh_Floor",
        m_collision.m_groundTriList
        )
    );

DX::ThrowIfFailed(
    ExtractTrianglesFromMesh(
        m_mazeMesh,
        "Mesh_floorSides",
        m_collision.m_floorTriList
        )
    );

m_physics.SetCollision(&m_collision);
float radius = m_marbleMesh.GetMeshBoundingBoxExtents(0).x / 2;
m_physics.SetRadius(radius);
```

<span data-ttu-id="927ec-331">大部分衝突データをロードする方法は、使う実行時の形式によって異なります。</span><span class="sxs-lookup"><span data-stu-id="927ec-331">The way that you load collision data largely depends on the run-time format that you use.</span></span> <span data-ttu-id="927ec-332">Marble Maze が SDK メッシュ ファイルから衝突ジオメトリを読み込む方法について詳しくは、ソース コードで**MarbleMazeMain::ExtractTrianglesFromMesh**メソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-332">For more information about how Marble Maze loads the collision geometry from an SDK-Mesh file, see the **MarbleMazeMain::ExtractTrianglesFromMesh** method in the source code.</span></span>

## <a name="updating-game-state"></a><span data-ttu-id="927ec-333">ゲームの状態の更新</span><span class="sxs-lookup"><span data-stu-id="927ec-333">Updating game state</span></span>


<span data-ttu-id="927ec-334">Marble Maze では、まずすべてのシーン オブジェクトを更新してからレンダリングすることによって、ゲーム ロジックとレンダリング ロジックを分離しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-334">Marble Maze separates game logic from rendering logic by first updating all scene objects before rendering them.</span></span>

<span data-ttu-id="927ec-335">[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)では、メイン ゲーム ループについて説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-335">[Marble Maze application structure](marble-maze-application-structure.md) describes the main game loop.</span></span> <span data-ttu-id="927ec-336">ゲーム ループの一部であるシーンの更新は、Windows イベントの後の入力が処理された後で、シーンがレンダリングされる前に行います。</span><span class="sxs-lookup"><span data-stu-id="927ec-336">Updating the scene, which is part of the game loop, happens after Windows events and input are processed and before the scene is rendered.</span></span> <span data-ttu-id="927ec-337">**Marblemazemain::update**メソッドは、UI と、ゲームの更新を処理します。</span><span class="sxs-lookup"><span data-stu-id="927ec-337">The **MarbleMazeMain::Update** method handles the update of the UI and the game.</span></span>

### <a name="updating-the-user-interface"></a><span data-ttu-id="927ec-338">ユーザー インターフェイスの更新</span><span class="sxs-lookup"><span data-stu-id="927ec-338">Updating the user interface</span></span>

<span data-ttu-id="927ec-339">**Marblemazemain::update**メソッドは、UI の状態を更新する**userinterface::update**メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-339">The **MarbleMazeMain::Update** method calls the **UserInterface::Update** method to update the state of the UI.</span></span>

```cpp
UserInterface::GetInstance().Update(
    static_cast<float>(m_timer.GetTotalSeconds()), 
    static_cast<float>(m_timer.GetElapsedSeconds()));
```

<span data-ttu-id="927ec-340">**UserInterface::Update** メソッドは、UI コレクション内の各要素を更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-340">The **UserInterface::Update** method updates each element in the UI collection.</span></span>

```cpp
void UserInterface::Update(float timeTotal, float timeDelta)
{
    for (auto iter = m_elements.begin(); iter != m_elements.end(); ++iter)
    {
        (*iter)->Update(timeTotal, timeDelta);
    }
}
```

<span data-ttu-id="927ec-341">**ElementBase** ( **UserInterface.h**で定義されている) から派生するクラスでは、特定の動作を実行する**Update**メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="927ec-341">Classes that derive from **ElementBase** (defined in **UserInterface.h**) implement the **Update** method to perform specific behaviors.</span></span> <span data-ttu-id="927ec-342">たとえば、**StopwatchTimer::Update** メソッドは、指定された時間で経過時間を更新し、後で表示されるテキストを更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-342">For example, the **StopwatchTimer::Update** method updates the elapsed time by the provided amount and updates the text that it later displays.</span></span>

```cpp
void StopwatchTimer::Update(float timeTotal, float timeDelta)
{
    if (m_active)
    {
        m_elapsedTime += timeDelta;

        WCHAR buffer[16];
        GetFormattedTime(buffer);
        SetText(buffer);
    }

    TextElement::Update(timeTotal, timeDelta);
}
```

###  <a name="updating-the-scene"></a><span data-ttu-id="927ec-343">シーンの更新</span><span class="sxs-lookup"><span data-stu-id="927ec-343">Updating the scene</span></span>

<span data-ttu-id="927ec-344">**Marblemazemain::update**メソッドは、ステート マシン (、 **GameState**、 **m_gameState**に格納されている) の現在の状態に基づいてゲームを更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-344">The **MarbleMazeMain::Update** method updates the game based on the current state of the state machine (the **GameState**, stored in **m_gameState**).</span></span> <span data-ttu-id="927ec-345">ゲームがアクティブな状態 (**GameState::InGameActive**) と、Marble Maze はカメラ大理石を更新し、定数バッファーに含まれるビュー マトリックスを更新し、物理シミュレーションを更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-345">When the game is in the active state (**GameState::InGameActive**), Marble Maze updates the camera to follow the marble, updates the view matrix part of the constant buffers, and updates the physics simulation.</span></span>

<span data-ttu-id="927ec-346">次の例では、 **marblemazemain::update**メソッドが、カメラの位置を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-346">The following example shows how the **MarbleMazeMain::Update** method updates the position of the camera.</span></span> <span data-ttu-id="927ec-347">Marble Maze では、**m\_resetCamera** 変数を使って、カメラを大理石の真上に配置するためにリセットする必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-347">Marble Maze uses the **m\_resetCamera** variable to flag that the camera must be reset to be located directly above the marble.</span></span> <span data-ttu-id="927ec-348">カメラがリセットされるのは、ゲームが開始するときか大理石が迷路を通り抜けたときです。</span><span class="sxs-lookup"><span data-stu-id="927ec-348">The camera is reset when the game starts or the marble falls through the maze.</span></span> <span data-ttu-id="927ec-349">メイン メニューまたはハイスコア表示画面がアクティブな場合、カメラは定位置に設定されます。</span><span class="sxs-lookup"><span data-stu-id="927ec-349">When the main menu or high score display screen is active, the camera is set at a constant location.</span></span> <span data-ttu-id="927ec-350">それ以外の場合、Marble Maze では、*timeDelta* パラメーターを使って、カメラの位置を現在位置と目標位置の間で補間します。</span><span class="sxs-lookup"><span data-stu-id="927ec-350">Otherwise, Marble Maze uses the *timeDelta* parameter to interpolate the position of the camera between its current and target positions.</span></span> <span data-ttu-id="927ec-351">目標位置は大理石の斜め前方です。</span><span class="sxs-lookup"><span data-stu-id="927ec-351">The target position is slightly above and in front of the marble.</span></span> <span data-ttu-id="927ec-352">経過フレーム時間を使うと、カメラが大理石を少しずつ追いかける、つまり追跡することができます。</span><span class="sxs-lookup"><span data-stu-id="927ec-352">Using the elapsed frame time enables the camera to gradually follow, or chase, the marble.</span></span>

```cpp
static float eyeDistance = 200.0f;
static XMFLOAT3A eyePosition = XMFLOAT3A(0, 0, 0);

// Gradually move the camera above the marble.
XMFLOAT3A targetEyePosition;
XMStoreFloat3A(
    &targetEyePosition, 
    XMLoadFloat3A(&marblePosition) - (XMLoadFloat3A(&g) * eyeDistance));

if (m_resetCamera)
{
    eyePosition = targetEyePosition;
    m_resetCamera = false;
}
else
{
    XMStoreFloat3A(
        &eyePosition, 
        XMLoadFloat3A(&eyePosition) 
            + ((XMLoadFloat3A(&targetEyePosition) - XMLoadFloat3A(&eyePosition)) 
                * min(1, static_cast<float>(m_timer.GetElapsedSeconds()) * 8)
            )
    );
}

// Look at the marble. 
if ((m_gameState == GameState::MainMenu) || (m_gameState == GameState::HighScoreDisplay))
{
    // Override camera position for menus.
    XMStoreFloat3A(
        &eyePosition, 
        XMLoadFloat3A(&marblePosition) + XMVectorSet(75.0f, -150.0f, -75.0f, 0.0f));

    m_camera->SetViewParameters(
        eyePosition, 
        marblePosition, 
        XMFLOAT3(0.0f, 0.0f, -1.0f));
}
else
{
    m_camera->SetViewParameters(eyePosition, marblePosition, XMFLOAT3(0.0f, 1.0f, 0.0f));
}
```

<span data-ttu-id="927ec-353">次の例では、 **marblemazemain::update**メソッドが大理石と迷路の定数バッファーを更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-353">The following example shows how the **MarbleMazeMain::Update** method updates the constant buffers for the marble and the maze.</span></span> <span data-ttu-id="927ec-354">迷路のモデル (ワールド) マトリックスは、常に単位マトリックスです。</span><span class="sxs-lookup"><span data-stu-id="927ec-354">The maze’s model, or world, matrix always remains the identity matrix.</span></span> <span data-ttu-id="927ec-355">要素がすべて 1 のメイン対角線を除き、単位マトリックスは、0 で構成される正方形マトリックスです。</span><span class="sxs-lookup"><span data-stu-id="927ec-355">Except for the main diagonal, whose elements are all ones, the identity matrix is a square matrix composed of zeros.</span></span> <span data-ttu-id="927ec-356">大理石のモデル マトリックスは、位置マトリックスと回転マトリックスを掛けた値に基づいています。</span><span class="sxs-lookup"><span data-stu-id="927ec-356">The marble’s model matrix is based on its position matrix times its rotation matrix.</span></span>

```cpp
// Update the model matrices based on the simulation.
XMStoreFloat4x4(&m_mazeConstantBufferData.model, XMMatrixIdentity());

XMStoreFloat4x4(
    &m_marbleConstantBufferData.model, 
    XMMatrixTranspose(
        XMMatrixMultiply(
            marbleRotationMatrix, 
            XMMatrixTranslationFromVector(XMLoadFloat3A(&marblePosition))
        )
    )
);

// Update the view matrix based on the camera.
XMFLOAT4X4 view;
m_camera->GetViewMatrix(&view);
m_mazeConstantBufferData.view = view;
m_marbleConstantBufferData.view = view;
```

<span data-ttu-id="927ec-357">**Marblemazemain::update**メソッドがユーザー入力を読み取るし、大理石の動きをシミュレートする方法については、[追加の入力と Marble Maze サンプルへの対話機能](adding-input-and-interactivity-to-the-marble-maze-sample.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-357">For information about how the **MarbleMazeMain::Update** method reads user input and simulates the motion of the marble, see [Adding input and interactivity to the Marble Maze sample](adding-input-and-interactivity-to-the-marble-maze-sample.md).</span></span>

## <a name="rendering-the-scene"></a><span data-ttu-id="927ec-358">シーンのレンダリング</span><span class="sxs-lookup"><span data-stu-id="927ec-358">Rendering the scene</span></span>


<span data-ttu-id="927ec-359">シーンがレンダリングされるとき、通常は次の手順が含まれます。</span><span class="sxs-lookup"><span data-stu-id="927ec-359">When a scene is rendered, these steps are typically included.</span></span>

1.  <span data-ttu-id="927ec-360">現在のレンダー ターゲットの深度ステンシル バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-360">Set the current render target depth-stencil buffer.</span></span>
2.  <span data-ttu-id="927ec-361">レンダーおよびステンシル ビューをクリアします。</span><span class="sxs-lookup"><span data-stu-id="927ec-361">Clear the render and stencil views.</span></span>
3.  <span data-ttu-id="927ec-362">描画のために頂点シェーダーとピクセル シェーダーを準備します。</span><span class="sxs-lookup"><span data-stu-id="927ec-362">Prepare the vertex and pixel shaders for drawing.</span></span>
4.  <span data-ttu-id="927ec-363">シーン内の 3D オブジェクトをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="927ec-363">Render the 3D objects in the scene.</span></span>
5.  <span data-ttu-id="927ec-364">シーンの前面に表示する 2 D オブジェクトをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="927ec-364">Render any 2D object that you want to appear in front of the scene.</span></span>
6.  <span data-ttu-id="927ec-365">レンダリングした画像をモニターに表示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-365">Present the rendered image to the monitor.</span></span>

<span data-ttu-id="927ec-366">**Marblemazemain::render**メソッドは、レンダー ターゲットにバインド ファイルと深度ステンシル ビュー、これらのビューをクリア、シーンを描画し、オーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="927ec-366">The **MarbleMazeMain::Render** method binds the render target and depth stencil views, clears those views, draws the scene, and then draws the overlay.</span></span>

###  <a name="preparing-the-render-targets"></a><span data-ttu-id="927ec-367">レンダー ターゲットの準備</span><span class="sxs-lookup"><span data-stu-id="927ec-367">Preparing the render targets</span></span>

<span data-ttu-id="927ec-368">シーンをレンダリングする前に、現在のレンダー ターゲットの深度ステンシル バッファーを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-368">Before you render your scene, you must set the current render target depth-stencil buffer.</span></span> <span data-ttu-id="927ec-369">シーンが画面のすべてのピクセルに描画される保証がない場合は、レンダー ビューとステンシル ビューもクリアします。</span><span class="sxs-lookup"><span data-stu-id="927ec-369">If your scene is not guaranteed to draw over every pixel on the screen, also clear the render and stencil views.</span></span> <span data-ttu-id="927ec-370">Marble Maze では、すべてのフレームのレンダー ビューとステンシル ビューをクリアして、前のフレームに由来して表示されるアーティファクトがないことを確かめます。</span><span class="sxs-lookup"><span data-stu-id="927ec-370">Marble Maze clears the render and stencil views on every frame to ensure that there are no visible artifacts from the previous frame.</span></span>

<span data-ttu-id="927ec-371">次の例では、 **marblemazemain::render**メソッドが現在のものとして、レンダー ターゲットと深度/ステンシル バッファーを設定する[id 3d11devicecontext::omsetrendertargets](https://msdn.microsoft.com/library/windows/desktop/ff476464)メソッドを呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-371">The following example shows how the **MarbleMazeMain::Render** method calls the [ID3D11DeviceContext::OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464) method to set the render target and the depth-stencil buffer as the current ones.</span></span>

```cpp
auto context = m_deviceResources->GetD3DDeviceContext();

// Reset the viewport to target the whole screen.
auto viewport = m_deviceResources->GetScreenViewport();
context->RSSetViewports(1, &viewport);

// Reset render targets to the screen.
ID3D11RenderTargetView *const targets[1] = 
    { m_deviceResources->GetBackBufferRenderTargetView() };

context->OMSetRenderTargets(1, targets, m_deviceResources->GetDepthStencilView());

// Clear the back buffer and depth stencil view.
context->ClearRenderTargetView(
    m_deviceResources->GetBackBufferRenderTargetView(), 
    DirectX::Colors::Black);

context->ClearDepthStencilView(
    m_deviceResources->GetDepthStencilView(), 
    D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 
    1.0f, 
    0);
```

<span data-ttu-id="927ec-372">[ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582) インターフェイスと [ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377) インターフェイスは、Direct3D 10 以降で提供されるテクスチャ ビュー機構をサポートします。</span><span class="sxs-lookup"><span data-stu-id="927ec-372">The [ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582) and [ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377) interfaces support the texture view mechanism that is provided by Direct3D 10 and later.</span></span> <span data-ttu-id="927ec-373">テクスチャ ビューについて詳しくは、「[テクスチャ ビュー (Direct3D 10)](https://msdn.microsoft.com/library/windows/desktop/bb205128)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-373">For more information about texture views, see [Texture Views (Direct3D 10)](https://msdn.microsoft.com/library/windows/desktop/bb205128).</span></span> <span data-ttu-id="927ec-374">[OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464) メソッドは、Direct3D パイプラインの出力マージャー ステージを準備します。</span><span class="sxs-lookup"><span data-stu-id="927ec-374">The [OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464) method prepares the output-merger stage of the Direct3D pipeline.</span></span> <span data-ttu-id="927ec-375">出力マージャー ステージについて詳しくは、「[出力マージャー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205120)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-375">For more information about the output-merger stage, see [Output-Merger Stage](https://msdn.microsoft.com/library/windows/desktop/bb205120).</span></span>

### <a name="preparing-the-vertex-and-pixel-shaders"></a><span data-ttu-id="927ec-376">頂点シェーダーとピクセル シェーダーの準備</span><span class="sxs-lookup"><span data-stu-id="927ec-376">Preparing the vertex and pixel shaders</span></span>

<span data-ttu-id="927ec-377">シーン オブジェクトをレンダリングする前に、次の手順を実行して、描画用のために頂点シェーダーとピクセル シェーダーを準備します。</span><span class="sxs-lookup"><span data-stu-id="927ec-377">Before you render the scene objects, perform the following steps to prepare the vertex and pixel shaders for drawing:</span></span>

1.  <span data-ttu-id="927ec-378">現在のレイアウトとしてシェーダー入力レイアウトを設定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-378">Set the shader input layout as the current layout.</span></span>
2.  <span data-ttu-id="927ec-379">現在のシェーダーとして頂点シェーダーとピクセル シェーダーを設定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-379">Set the vertex and pixel shaders as the current shaders.</span></span>
3.  <span data-ttu-id="927ec-380">シェーダーに渡す必要があるデータで定数バッファーを更新します。</span><span class="sxs-lookup"><span data-stu-id="927ec-380">Update any constant buffers with data that you have to pass to the shaders.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="927ec-381">Marble Maze では、すべての 3D オブジェクトの頂点シェーダーとピクセル シェーダーのペアを 1 つを使用します。</span><span class="sxs-lookup"><span data-stu-id="927ec-381">Marble Maze uses one pair of vertex and pixel shaders for all 3D objects.</span></span> <span data-ttu-id="927ec-382">ゲームでシェーダーのペアを複数使う場合は、別のシェーダーを使うオブジェクトを描画するたびに、これらの手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="927ec-382">If your game uses more than one pair of shaders, you must perform these steps each time you draw objects that use different shaders.</span></span> <span data-ttu-id="927ec-383">シェーダーの状態の変更に伴うオーバーヘッドを減らすには、同じシェーダーを使うすべてのオブジェクトごとにレンダー呼び出しをグループ化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="927ec-383">To reduce the overhead that is associated with changing the shader state, we recommend that you group render calls for all objects that use the same shaders.</span></span>

 

<span data-ttu-id="927ec-384">このドキュメントの「[シェーダーの読み込み](#loading-shaders)」では、頂点シェーダーが作成されるときに入力レイアウトがどのように作成されるかについて説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-384">The section [Loading shaders](#loading-shaders) in this document describes how the input layout is created when the vertex shader is created.</span></span> <span data-ttu-id="927ec-385">次の例では、 **marblemazemain::render**メソッドが[id 3d11devicecontext::iasetinputlayout](https://msdn.microsoft.com/library/windows/desktop/ff476454)メソッドを使用して、現在のレイアウトとしてこのレイアウトを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-385">The following example shows how the **MarbleMazeMain::Render** method uses the [ID3D11DeviceContext::IASetInputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476454) method to set this layout as the current layout.</span></span>

```cpp
m_deviceResources->GetD3DDeviceContext()->IASetInputLayout(m_inputLayout.Get());
```

<span data-ttu-id="927ec-386">次の例は、 **marblemazemain::render**メソッドで、 [id 3d11devicecontext::vssetshader](https://msdn.microsoft.com/library/windows/desktop/ff476493)および[id 3d11devicecontext::pssetshader](https://msdn.microsoft.com/library/windows/desktop/ff476472)メソッドを使用して、現在のシェーダーとして頂点シェーダーとピクセル シェーダーを設定する方法を示しています。それぞれします。</span><span class="sxs-lookup"><span data-stu-id="927ec-386">The following example shows how the **MarbleMazeMain::Render** method uses the [ID3D11DeviceContext::VSSetShader](https://msdn.microsoft.com/library/windows/desktop/ff476493) and [ID3D11DeviceContext::PSSetShader](https://msdn.microsoft.com/library/windows/desktop/ff476472) methods to set the vertex and pixel shaders as the current shaders, respectively.</span></span>

```cpp
// Set the vertex shader stage state.
m_deviceResources->GetD3DDeviceContext()->VSSetShader(
    m_vertexShader.Get(),   // use this vertex shader
    nullptr,                // don't use shader linkage
    0);                     // don't use shader linkage

m_deviceResources->GetD3DDeviceContext()->PSSetShader(
    m_pixelShader.Get(),    // use this pixel shader
    nullptr,                // don't use shader linkage
    0);                     // don't use shader linkage

m_deviceResources->GetD3DDeviceContext()->PSSetSamplers(
    0,                          // starting at the first sampler slot
    1,                          // set one sampler binding
    m_sampler.GetAddressOf());  // to use this sampler
```

<span data-ttu-id="927ec-387">**Marblemazemain::render**がシェーダーと入力レイアウトを設定した後、モデル、ビュー、および、迷路のプロジェクション マトリックスで定数バッファーを更新するのに[id 3d11devicecontext::updatesubresource](https://msdn.microsoft.com/library/windows/desktop/ff476486)メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="927ec-387">After **MarbleMazeMain::Render** sets the shaders and their input layout, it uses the [ID3D11DeviceContext::UpdateSubresource](https://msdn.microsoft.com/library/windows/desktop/ff476486) method to update the constant buffer with the model, view, and projection matrices for the maze.</span></span> <span data-ttu-id="927ec-388">**UpdateSubresource** メソッドは、CPU メモリから GPU メモリにマトリックス データをコピーします。</span><span class="sxs-lookup"><span data-stu-id="927ec-388">The **UpdateSubresource** method copies the matrix data from CPU memory to GPU memory.</span></span> <span data-ttu-id="927ec-389">**Marblemazemain::update**メソッドで、 **ConstantBuffer**構造体のモデルとビュー コンポーネントが更新されることを思い出してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-389">Recall that the model and view components of the **ConstantBuffer** structure are updated in the **MarbleMazeMain::Update** method.</span></span> <span data-ttu-id="927ec-390">**Marblemazemain::render**メソッドは、現在の 1 つとして、この定数バッファーを設定する[id 3d11devicecontext::vssetconstantbuffers](https://msdn.microsoft.com/library/windows/desktop/ff476491)と[ID3D11DeviceContext::PSSetConstantBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476470)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-390">The **MarbleMazeMain::Render** method then calls the [ID3D11DeviceContext::VSSetConstantBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476491) and [ID3D11DeviceContext::PSSetConstantBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476470) methods to set this constant buffer as the current one.</span></span>

```cpp
// Update the constant buffer with the new data.
m_deviceResources->GetD3DDeviceContext()->UpdateSubresource(
    m_constantBuffer.Get(),
    0,
    nullptr,
    &m_mazeConstantBufferData,
    0,
    0);

m_deviceResources->GetD3DDeviceContext()->VSSetConstantBuffers(
    0,                                  // starting at the first constant buffer slot
    1,                                  // set one constant buffer binding
    m_constantBuffer.GetAddressOf());   // to use this buffer

m_deviceResources->GetD3DDeviceContext()->PSSetConstantBuffers(
    0,                                  // starting at the first constant buffer slot
    1,                                  // set one constant buffer binding
    m_constantBuffer.GetAddressOf());   // to use this buffer
```

<span data-ttu-id="927ec-391">**Marblemazemain::render**メソッドは、レンダリングする大理石を準備する同様の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="927ec-391">The **MarbleMazeMain::Render** method performs similar steps to prepare the marble to be rendered.</span></span>

### <a name="rendering-the-maze-and-the-marble"></a><span data-ttu-id="927ec-392">迷路と大理石のレンダリング</span><span class="sxs-lookup"><span data-stu-id="927ec-392">Rendering the maze and the marble</span></span>

<span data-ttu-id="927ec-393">現在のシェーダーをアクティブにした後、シーン オブジェクトを描画できます。</span><span class="sxs-lookup"><span data-stu-id="927ec-393">After you activate the current shaders, you can draw your scene objects.</span></span> <span data-ttu-id="927ec-394">**Marblemazemain::render**メソッドは、迷路のメッシュをレンダリングする**SDKMesh::Render**メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-394">The **MarbleMazeMain::Render** method calls the **SDKMesh::Render** method to render the maze mesh.</span></span>

```cpp
m_mazeMesh.Render(
    m_deviceResources->GetD3DDeviceContext(), 
    0, 
    INVALID_SAMPLER_SLOT, 
    INVALID_SAMPLER_SLOT);
```

<span data-ttu-id="927ec-395">**Marblemazemain::render**メソッドは、大理石をレンダリングする同様の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="927ec-395">The **MarbleMazeMain::Render** method performs similar steps to render the marble.</span></span>

<span data-ttu-id="927ec-396">このドキュメントで前に説明したように、**SDKMesh** クラスはデモンストレーション用に提供していますが、本番品質のゲームでの使用はお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="927ec-396">As mentioned earlier in this document, the **SDKMesh** class is provided for demonstration purposes, but we do not recommend it for use in a production-quality game.</span></span> <span data-ttu-id="927ec-397">ただし、**SDKMesh::Render** によって呼び出される **SDKMesh::RenderMesh** メソッドは、[ID3D11DeviceContext::IASetVertexBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476456) メソッドと [ID3D11DeviceContext::IASetIndexBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476453) メソッドを使ってメッシュを定義する現在の頂点バッファーとインデックス バッファーを設定し、[ID3D11DeviceContext::DrawIndexed](https://msdn.microsoft.com/library/windows/desktop/ff476410) メソッドを使ってバッファーを描画することに注目してください。</span><span class="sxs-lookup"><span data-stu-id="927ec-397">However, notice that the **SDKMesh::RenderMesh** method, which is called by **SDKMesh::Render**, uses the [ID3D11DeviceContext::IASetVertexBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476456) and [ID3D11DeviceContext::IASetIndexBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476453) methods to set the current vertex and index buffers that define the mesh, and the [ID3D11DeviceContext::DrawIndexed](https://msdn.microsoft.com/library/windows/desktop/ff476410) method to draw the buffers.</span></span> <span data-ttu-id="927ec-398">頂点バッファーとインデックス バッファーの操作方法について詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-398">For more information about how to work with vertex and index buffers, see [Introduction to Buffers in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476898).</span></span>

### <a name="drawing-the-user-interface-and-overlay"></a><span data-ttu-id="927ec-399">ユーザー インターフェイスとオーバーレイの描画</span><span class="sxs-lookup"><span data-stu-id="927ec-399">Drawing the user interface and overlay</span></span>

<span data-ttu-id="927ec-400">3D シーンのオブジェクトを描画した後は、Marble Maze は、シーンの前面に表示される 2D の UI 要素を描画します。</span><span class="sxs-lookup"><span data-stu-id="927ec-400">After drawing 3D scene objects, Marble Maze draws the 2D UI elements that appear in front of the scene.</span></span>

<span data-ttu-id="927ec-401">**Marblemazemain::render**メソッドは、ユーザー インターフェイスとオーバーレイを描画して終了します。</span><span class="sxs-lookup"><span data-stu-id="927ec-401">The **MarbleMazeMain::Render** method ends by drawing the user interface and the overlay.</span></span>

```cpp
// Draw the user interface and the overlay.
UserInterface::GetInstance().Render(m_deviceResources->GetOrientationTransform2D());

m_deviceResources->GetD3DDeviceContext()->BeginEventInt(L"Render Overlay", 0);
m_sampleOverlay->Render();
m_deviceResources->GetD3DDeviceContext()->EndEvent();
```

<span data-ttu-id="927ec-402">**UserInterface::Render** メソッドは、[ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/hh404479) オブジェクトを使って、UI 要素を描画します。</span><span class="sxs-lookup"><span data-stu-id="927ec-402">The **UserInterface::Render** method uses an [ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/hh404479) object to draw the UI elements.</span></span> <span data-ttu-id="927ec-403">このメソッドは、描画の状態を設定し、すべてのアクティブな UI 要素を描画してから、前の描画の状態を復元します。</span><span class="sxs-lookup"><span data-stu-id="927ec-403">This method sets the drawing state, draws all active UI elements, and then restores the previous drawing state.</span></span>

```cpp
void UserInterface::Render(D2D1::Matrix3x2F orientation2D)
{
    m_d2dContext->SaveDrawingState(m_stateBlock.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(orientation2D);

    m_d2dContext->SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE);

    for (auto iter = m_elements.begin(); iter != m_elements.end(); ++iter)
    {
        if ((*iter)->IsVisible())
            (*iter)->Render();
    }

    // We ignore D2DERR_RECREATE_TARGET here. This error indicates that the device
    // is lost. It will be handled during the next call to Present.
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        DX::ThrowIfFailed(hr);
    }

    m_d2dContext->RestoreDrawingState(m_stateBlock.Get());
}
```

<span data-ttu-id="927ec-404">**SampleOverlay::Render** メソッドは、同様の手法を使ってオーバーレイ ビットマップを描画します。</span><span class="sxs-lookup"><span data-stu-id="927ec-404">The **SampleOverlay::Render** method uses a similar technique to draw the overlay bitmap.</span></span>

###  <a name="presenting-the-scene"></a><span data-ttu-id="927ec-405">シーンの表示</span><span class="sxs-lookup"><span data-stu-id="927ec-405">Presenting the scene</span></span>

<span data-ttu-id="927ec-406">すべての 2D および 3D シーンのオブジェクトを描画した後は、Marble Maze は、モニターにレンダリングの画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="927ec-406">After drawing all 2D and 3D scene objects, Marble Maze presents the rendered image to the monitor.</span></span> <span data-ttu-id="927ec-407">描画を垂直ブランクに同期して、実際にディスプレイに表示されないフレームの描画に時間が費やされないようにします。</span><span class="sxs-lookup"><span data-stu-id="927ec-407">It synchronizes drawing to the vertical blank to ensure that time is not spent time drawing frames that will never be actually shown on the display.</span></span> <span data-ttu-id="927ec-408">Marble Maze では、シーンを表示するときにデバイスの変更も処理します。</span><span class="sxs-lookup"><span data-stu-id="927ec-408">Marble Maze also handles device changes when it presents the scene.</span></span>

<span data-ttu-id="927ec-409">**Marblemazemain::render**メソッドから制御が戻った後、ゲーム ループは、レンダリングされた画像をモニターに送信やディスプレイに **::deviceresources::present**メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-409">After the **MarbleMazeMain::Render** method returns, the game loop calls the **DX::DeviceResources::Present** method to send the rendered image to the monitor or display.</span></span> <span data-ttu-id="927ec-410">**:Deviceresources::present**メソッドは、次の例に示すように、存在する操作を実行する[::present](https://msdn.microsoft.com/library/windows/desktop/bb174576)を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="927ec-410">The **DX::DeviceResources::Present** method calls [IDXGISwapChain::Present](https://msdn.microsoft.com/library/windows/desktop/bb174576) to perform the present operation, as shown in the following example:</span></span>

```cpp
// The first argument instructs DXGI to block until VSync, putting the application
// to sleep until the next VSync. This ensures we don't waste any cycles rendering
// frames that will never be displayed to the screen.
HRESULT hr = m_swapChain->Present(1, 0);
```

<span data-ttu-id="927ec-411">この例では、**m\_swapChain** は [IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="927ec-411">In this example, **m\_swapChain** is an [IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631) object.</span></span> <span data-ttu-id="927ec-412">このオブジェクトの初期化については、このドキュメントの「[Direct3D と Direct2D の初期化](#initializing-direct3d-and-direct2d)」で説明しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-412">The initialization of this object is described in the section [Initializing Direct3D and Direct2D](#initializing-direct3d-and-direct2d) in this document.</span></span>

<span data-ttu-id="927ec-413">[Idxgiswapchain::present](https://msdn.microsoft.com/library/windows/desktop/hh446797)、 *SyncInterval*、最初のパラメーターは、フレームを表示する前に待機する垂直ブランクの数を指定します。</span><span class="sxs-lookup"><span data-stu-id="927ec-413">The first parameter to [IDXGISwapChain::Present](https://msdn.microsoft.com/library/windows/desktop/hh446797), *SyncInterval*, specifies the number of vertical blanks to wait before presenting the frame.</span></span> <span data-ttu-id="927ec-414">Marble Maze では 1 を指定して、次の垂直ブランクまで待機することを指定しています。</span><span class="sxs-lookup"><span data-stu-id="927ec-414">Marble Maze specifies 1 so that it waits until the next vertical blank.</span></span>

<span data-ttu-id="927ec-415">[Idxgiswapchain::present](https://msdn.microsoft.com/library/windows/desktop/bb174576)メソッドは、デバイスが削除されたかどうか、またはそれ以外の場合に失敗したことを示すエラー コードを返します。</span><span class="sxs-lookup"><span data-stu-id="927ec-415">The [IDXGISwapChain::Present](https://msdn.microsoft.com/library/windows/desktop/bb174576) method returns an error code that indicates that the device was removed or otherwise failed.</span></span> <span data-ttu-id="927ec-416">この場合、Marble Maze は、デバイスを再初期化します。</span><span class="sxs-lookup"><span data-stu-id="927ec-416">In this case, Marble Maze reinitializes the device.</span></span>

```cpp
// If the device was removed either by a disconnection or a driver upgrade, we
// must recreate all device resources.
if (hr == DXGI_ERROR_DEVICE_REMOVED)
{
    HandleDeviceLost();
}
else
{
    DX::ThrowIfFailed(hr);
}
```

## <a name="next-steps"></a><span data-ttu-id="927ec-417">次の手順</span><span class="sxs-lookup"><span data-stu-id="927ec-417">Next steps</span></span>


<span data-ttu-id="927ec-418">入力デバイスを操作する際の重要な手順については、「[Marble Maze サンプルへの入力と対話機能の追加](adding-input-and-interactivity-to-the-marble-maze-sample.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="927ec-418">Read [Adding input and interactivity to the Marble Maze sample](adding-input-and-interactivity-to-the-marble-maze-sample.md) for information about some of the key practices to keep in mind when you work with input devices.</span></span> <span data-ttu-id="927ec-419">このドキュメントでは、Marble Maze がタッチ、加速度計、Xbox コント ローラー、およびマウス入力をサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="927ec-419">This document discusses how Marble Maze supports touch, accelerometer, Xbox controllers, and mouse input.</span></span>

## <a name="related-topics"></a><span data-ttu-id="927ec-420">関連トピック</span><span class="sxs-lookup"><span data-stu-id="927ec-420">Related topics</span></span>


* [<span data-ttu-id="927ec-421">Marble Maze サンプルへの入力と対話機能の追加</span><span class="sxs-lookup"><span data-stu-id="927ec-421">Adding input and interactivity to the Marble Maze sample</span></span>](adding-input-and-interactivity-to-the-marble-maze-sample.md)
* [<span data-ttu-id="927ec-422">Marble Maze のアプリケーション構造</span><span class="sxs-lookup"><span data-stu-id="927ec-422">Marble Maze application structure</span></span>](marble-maze-application-structure.md)
* [<span data-ttu-id="927ec-423">Marble Maze、C++ と DirectX での UWP ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="927ec-423">Developing Marble Maze, a UWP game in C++ and DirectX</span></span>](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




