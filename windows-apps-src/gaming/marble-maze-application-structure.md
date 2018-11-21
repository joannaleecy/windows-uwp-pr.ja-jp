---
author: eliotcowley
title: Marble Maze のアプリケーション構造
description: DirectX ユニバーサル Windows プラットフォーム (UWP) アプリの構造は、従来のデスクトップ アプリケーションとは異なります。
ms.assetid: 6080f0d3-478a-8bbe-d064-73fd3d432074
ms.author: elcowle
ms.date: 09/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サンプル, DirectX, 構造
ms.localizationpriority: medium
ms.openlocfilehash: 1272200bf128443c82807aec9df5559f207819e1
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7444798"
---
# <a name="marble-maze-application-structure"></a><span data-ttu-id="e9fd4-104">Marble Maze のアプリケーション構造</span><span class="sxs-lookup"><span data-stu-id="e9fd4-104">Marble Maze application structure</span></span>




<span data-ttu-id="e9fd4-105">DirectX ユニバーサル Windows プラットフォーム (UWP) アプリの構造は、従来のデスクトップ アプリケーションとは異なります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-105">The structure of a DirectX Universal Windows Platform (UWP) app differs from that of a traditional desktop application.</span></span> <span data-ttu-id="e9fd4-106">[HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751) などのハンドル型や [CreateWindow](https://msdn.microsoft.com/library/windows/desktop/ms632679) などの関数は使いません。それよりも新しい、オブジェクト指向に沿った方法で UWP アプリを開発できるように、Windows ランタイムには [Windows::UI::Core::ICoreWindow](https://msdn.microsoft.com/library/windows/apps/br208296) をはじめとするインターフェイスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-106">Instead of working with handle types such as [HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751) and functions such as [CreateWindow](https://msdn.microsoft.com/library/windows/desktop/ms632679), the Windows Runtime provides interfaces such as [Windows::UI::Core::ICoreWindow](https://msdn.microsoft.com/library/windows/apps/br208296) so that you can develop UWP apps in a more modern, object-oriented manner.</span></span> <span data-ttu-id="e9fd4-107">ここでは、Marble Maze アプリ コードがどのように構成されているかを確認します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-107">This section of the documentation shows how the Marble Maze app code is structured.</span></span>

> [!NOTE]
> <span data-ttu-id="e9fd4-108">このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-108">The sample code that corresponds to this document is found in the [DirectX Marble Maze game sample](http://go.microsoft.com/fwlink/?LinkId=624011).</span></span>

 
## 
<span data-ttu-id="e9fd4-109">このドキュメントでは、ゲーム コードを構成する際に重要となるいくつかのことがらについて説明します。取り上げる内容は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-109">Here are some of the key points that this document discusses for when you structure your game code:</span></span>

-   <span data-ttu-id="e9fd4-110">初期化フェーズでは、ゲームで使うランタイムとライブラリ コンポーネントをセットアップし、ゲーム固有のリソースを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-110">In the initialization phase, set up the runtime and library components that your game uses, and load game-specific resources.</span></span>
-   <span data-ttu-id="e9fd4-111">UWP アプリは、起動から 5 秒以内にイベントの処理を開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-111">UWP apps must start processing events within 5 seconds of launch.</span></span> <span data-ttu-id="e9fd4-112">そのため、アプリを読み込むときは、主要なリソースだけを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-112">Therefore, load only essential resources when you load your app.</span></span> <span data-ttu-id="e9fd4-113">大きなリソースはバックグラウンドで読み込んで、進行状況画面を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-113">Games should load large resources in the background and display a progress screen.</span></span>
-   <span data-ttu-id="e9fd4-114">ゲーム ループでは、Windows イベントへの応答、ユーザー入力の読み取り、シーン オブジェクトの更新、シーンの表示を行います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-114">In the game loop, respond to Windows events, read user input, update scene objects, and render the scene.</span></span>
-   <span data-ttu-id="e9fd4-115">イベント ハンドラーを使って、ウィンドウのイベントに応答します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-115">Use event handlers to respond to window events.</span></span> <span data-ttu-id="e9fd4-116">これは、デスクトップ Windows アプリケーションからのウィンドウ メッセージに代わるものです。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-116">(These replace the window messages from desktop Windows applications.)</span></span>
-   <span data-ttu-id="e9fd4-117">ステート マシンを使って、ゲーム ロジックのフローと順序を制御します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-117">Use a state machine to control the flow and order of the game logic.</span></span>

##  <a name="file-organization"></a><span data-ttu-id="e9fd4-118">ファイルの構成</span><span class="sxs-lookup"><span data-stu-id="e9fd4-118">File organization</span></span>


<span data-ttu-id="e9fd4-119">Marble Maze の一部のコンポーネントは、変更なしで、またはわずかな変更だけで、任意のゲームに再利用できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-119">Some of the components in Marble Maze can be reused with any game with little or no modification.</span></span> <span data-ttu-id="e9fd4-120">独自のゲームを開発する際には、これらのファイルから得られたアイデアや構造を応用できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-120">For your own game, you can adapt the organization and ideas that these files provide.</span></span> <span data-ttu-id="e9fd4-121">次の表は、重要なソース コード ファイルについて簡単に説明しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-121">The following table briefly describes the important source code files.</span></span>

| <span data-ttu-id="e9fd4-122">ファイル</span><span class="sxs-lookup"><span data-stu-id="e9fd4-122">Files</span></span>                                      | <span data-ttu-id="e9fd4-123">説明</span><span class="sxs-lookup"><span data-stu-id="e9fd4-123">Description</span></span>                                                                                                                                                                          |
|--------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e9fd4-124">App.h、App.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-124">App.h, App.cpp</span></span>               | <span data-ttu-id="e9fd4-125">アプリのビュー (ウィンドウ、スレッド、イベント) をカプセル化する **App** クラスと **DirectXApplicationSource** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-125">Defines the **App** and **DirectXApplicationSource** classes, which encapsulate the view (window, thread, and events) of the app.</span></span>                                                     |
| <span data-ttu-id="e9fd4-126">Audio.h、Audio.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-126">Audio.h, Audio.cpp</span></span>                         | <span data-ttu-id="e9fd4-127">オーディオ リソースを管理する **Audio** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-127">Defines the **Audio** class, which manages audio resources.</span></span>                                                                                                                          |
| <span data-ttu-id="e9fd4-128">BasicLoader.h、BasicLoader.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-128">BasicLoader.h, BasicLoader.cpp</span></span>             | <span data-ttu-id="e9fd4-129">テクスチャ、メッシュ、シェーダーの読み込みに役立つユーティリティ メソッドを提供する **BasicLoader** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-129">Defines the **BasicLoader** class, which provides utility methods that help you load textures, meshes, and shaders.</span></span>                                                                  |
| <span data-ttu-id="e9fd4-130">BasicMath.h</span><span class="sxs-lookup"><span data-stu-id="e9fd4-130">BasicMath.h</span></span>                                | <span data-ttu-id="e9fd4-131">ベクターやマトリックスのデータと計算の操作に役立つ構造と関数を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-131">Defines structures and functions that help you work with vector and matrix data and computations.</span></span> <span data-ttu-id="e9fd4-132">これらの関数の多くは、HLSL シェーダーの種類と互換性があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-132">Many of these functions are compatible with HLSL shader types.</span></span>                     |
| <span data-ttu-id="e9fd4-133">BasicReaderWriter.h、BasicReaderWriter.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-133">BasicReaderWriter.h, BasicReaderWriter.cpp</span></span> | <span data-ttu-id="e9fd4-134">UWP アプリのファイル データの読み取りと書き込みのために Windows ランタイムを使う **BasicReaderWriter** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-134">Defines the **BasicReaderWriter** class, which uses the Windows Runtime to read and write file data in a UWP app.</span></span>                                                                    |
| <span data-ttu-id="e9fd4-135">BasicShapes.h、BasicShapes.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-135">BasicShapes.h, BasicShapes.cpp</span></span>             | <span data-ttu-id="e9fd4-136">立方体や球体などの基本的な図形を作るためのユーティリティ メソッドを提供する **BasicShapes** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-136">Defines the **BasicShapes** class, which provides utility methods for creating basic shapes such as cubes and spheres.</span></span> <span data-ttu-id="e9fd4-137">これらのファイルは、Marble Maze の実装では使用されません。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-137">(These files are not used by the Marble Maze implementation).</span></span> |                                                                                  |
| <span data-ttu-id="e9fd4-138">Camera.h、Camera.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-138">Camera.h, Camera.cpp</span></span>                       | <span data-ttu-id="e9fd4-139">カメラの位置と向きを保持する **Camera** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-139">Defines the **Camera** class, which provides the position and orientation of a camera.</span></span>                                                                                               |
| <span data-ttu-id="e9fd4-140">Collision.h、Collision.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-140">Collision.h, Collision.cpp</span></span>                 | <span data-ttu-id="e9fd4-141">大理石と、迷路などの他のオブジェクトとの衝突情報を管理します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-141">Manages collision info between the marble and other objects, such as the maze.</span></span>                                                                                                       |
| <span data-ttu-id="e9fd4-142">DDSTextureLoader.h、DDSTextureLoader.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-142">DDSTextureLoader.h, DDSTextureLoader.cpp</span></span>   | <span data-ttu-id="e9fd4-143">メモリ バッファーから .dds 形式のテクスチャを読み込む **CreateDDSTextureFromMemory** 関数を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-143">Defines the **CreateDDSTextureFromMemory** function, which loads textures that are in .dds format from a memory buffer.</span></span>                                                              |
| <span data-ttu-id="e9fd4-144">DirectXHelper.h</span><span class="sxs-lookup"><span data-stu-id="e9fd4-144">DirectXHelper.h</span></span>             | <span data-ttu-id="e9fd4-145">多くの DirectX UWP アプリに有用な DirectX ヘルパー関数を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-145">Defines DirectX helper functions that are useful to many DirectX UWP apps.</span></span>                                                                            |
| <span data-ttu-id="e9fd4-146">LoadScreen.h、LoadScreen.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-146">LoadScreen.h, LoadScreen.cpp</span></span>               | <span data-ttu-id="e9fd4-147">アプリの初期化時に読み込み画面を表示する **LoadScreen** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-147">Defines the **LoadScreen** class, which displays a loading screen during app initialization.</span></span>                                                                                         |
| <span data-ttu-id="e9fd4-148">MarbleMazeMain.h、MarbleMazeMain.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-148">MarbleMazeMain.h, MarbleMazeMain.cpp</span></span>               | <span data-ttu-id="e9fd4-149">ゲーム固有のリソースを管理し、ゲーム ロジックの多くを定義する **MarbleMazeMain** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-149">Defines the **MarbleMazeMain** class, which manages game-specific resources and defines much of the game logic.</span></span>                                                                          |
| <span data-ttu-id="e9fd4-150">MediaStreamer.h、MediaStreamer.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-150">MediaStreamer.h, MediaStreamer.cpp</span></span>         | <span data-ttu-id="e9fd4-151">メディア ファンデーションを使ってゲームによるオーディオ リソースの管理を補助する **MediaStreamer** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-151">Defines the **MediaStreamer** class, which uses Media Foundation to help the game manage audio resources.</span></span>                                                                            |
| <span data-ttu-id="e9fd4-152">PersistentState.h、PersistentState.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-152">PersistentState.h, PersistentState.cpp</span></span>     | <span data-ttu-id="e9fd4-153">バッキング ストアとの間でプリミティブ データ型の読み取りと書き込みを行う **PersistentState** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-153">Defines the **PersistentState** class, which reads and writes primitive data types from and to a backing store.</span></span>                                                                      |
| <span data-ttu-id="e9fd4-154">Physics.h、Physics.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-154">Physics.h, Physics.cpp</span></span>                     | <span data-ttu-id="e9fd4-155">大理石と迷路間の物理シミュレーションを実装する **Physics** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-155">Defines the **Physics** class, which implements the physics simulation between the marble and the maze.</span></span>                                                                              |
| <span data-ttu-id="e9fd4-156">Primitives.h</span><span class="sxs-lookup"><span data-stu-id="e9fd4-156">Primitives.h</span></span>                               | <span data-ttu-id="e9fd4-157">ゲームで使われる幾何学型を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-157">Defines geometric types that are used by the game.</span></span>                                                                                                                                   |
| <span data-ttu-id="e9fd4-158">SampleOverlay.h、SampleOverlay.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-158">SampleOverlay.h, SampleOverlay.cpp</span></span>         | <span data-ttu-id="e9fd4-159">一般的な 2D とユーザー インターフェイスのデータと操作を提供する **SampleOverlay** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-159">Defines the **SampleOverlay** class, which provides common 2D and user-interface data and operations.</span></span>                                                                               |
| <span data-ttu-id="e9fd4-160">SDKMesh.h、SDKMesh.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-160">SDKMesh.h, SDKMesh.cpp</span></span>                     | <span data-ttu-id="e9fd4-161">SDK メッシュ (.sdkmesh) 形式のメッシュを読み込んで表示する **SDKMesh** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-161">Defines the **SDKMesh** class, which loads and renders meshes that are in SDK Mesh (.sdkmesh) format.</span></span>                                                                                |
| <span data-ttu-id="e9fd4-162">StepTimer.h</span><span class="sxs-lookup"><span data-stu-id="e9fd4-162">StepTimer.h</span></span>               | <span data-ttu-id="e9fd4-163">合計時間と経過時間を簡単に取得できるようにする **StepTimer** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-163">Defines the **StepTimer** class, which provides an easy way to get total and elapsed times.</span></span>
| <span data-ttu-id="e9fd4-164">UserInterface.h、UserInterface.cpp</span><span class="sxs-lookup"><span data-stu-id="e9fd4-164">UserInterface.h, UserInterface.cpp</span></span>         | <span data-ttu-id="e9fd4-165">メニュー システムやハイ スコア表などのユーザー インターフェイスに関連する機能を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-165">Defines functionality that's related to the user interface, such as the menu system and the high score table.</span></span>                                                                        |

 

##  <a name="design-time-versus-run-time-resource-formats"></a><span data-ttu-id="e9fd4-166">設計時と実行時のリソース形式</span><span class="sxs-lookup"><span data-stu-id="e9fd4-166">Design-time versus run-time resource formats</span></span>


<span data-ttu-id="e9fd4-167">できれば、より効率的にゲームのリソースを読み込むために、設計時形式ではなく実行時形式を使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-167">When you can, use run-time formats instead of design-time formats to more efficiently load game resources.</span></span>

<span data-ttu-id="e9fd4-168">*設計時*形式は、リソースを設計するときに使う形式です。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-168">A *design-time* format is the format you use when you design your resource.</span></span> <span data-ttu-id="e9fd4-169">通常、3D デザイナーは設計時形式で作業します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-169">Typically, 3D designers work with design-time formats.</span></span> <span data-ttu-id="e9fd4-170">一部の設計時形式はテキスト ベースであり、任意のテキスト ベース エディターで変更できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-170">Some design-time formats are also text-based so that you can modify them in any text-based editor.</span></span> <span data-ttu-id="e9fd4-171">設計時形式は冗長で、ゲームが必要とするよりも多くの情報を持っている場合があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-171">Design-time formats can be verbose and contain more information than your game requires.</span></span> <span data-ttu-id="e9fd4-172">*実行時*形式は、ゲームが読み取るバイナリ形式です。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-172">A *run-time* format is the binary format that is read by your game.</span></span> <span data-ttu-id="e9fd4-173">実行時形式は通常、対応する設計時形式よりもコンパクトで、効率的に読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-173">Run-time formats are typically more compact and more efficient to load than the corresponding design-time formats.</span></span> <span data-ttu-id="e9fd4-174">そのため、ゲームの大多数は実行時に実行時アセットを使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-174">This is why the majority of games use run-time assets at run time.</span></span>

<span data-ttu-id="e9fd4-175">ゲームは設計時形式を直接読み取れますが、別の実行時形式を使うことには、いくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-175">Although your game can directly read a design-time format, there are several benefits to using a separate run-time format.</span></span> <span data-ttu-id="e9fd4-176">実行時形式は多くの場合、よりコンパクトであり、必要なディスク領域が少なく、ネットワークでの転送にかかる時間も短くなります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-176">Because run-time formats are often more compact, they require less disk space and require less time to transfer over a network.</span></span> <span data-ttu-id="e9fd4-177">また、実行時形式は通常、メモリ マップ データ構造として表されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-177">Also, run-time formats are often represented as memory-mapped data structures.</span></span> <span data-ttu-id="e9fd4-178">そのため、XML ベースのテキスト ファイルなどよりも大幅に速くメモリに読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-178">Therefore, they can be loaded into memory much faster than, for example, an XML-based text file.</span></span> <span data-ttu-id="e9fd4-179">さらに、個別の実行時形式は通常はバイナリ形式でエンコードされており、エンド ユーザーによる変更がより難しくなっています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-179">Finally, because separate run-time formats are typically binary-encoded, they are more difficult for the end-user to modify.</span></span>

<span data-ttu-id="e9fd4-180">HLSL シェーダーは、設計時と実行時で異なる形式を使うリソースの 1 例です。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-180">HLSL shaders are one example of resources that use different design-time and run-time formats.</span></span> <span data-ttu-id="e9fd4-181">Marble Maze は、設計時形式として .hlsl、実行時形式として .cso を使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-181">Marble Maze uses .hlsl as the design-time format, and .cso as the run-time format.</span></span> <span data-ttu-id="e9fd4-182">.hlsl ファイルはシェーダーのソース コードを保持します。.cso ファイルは対応するシェーダーのバイト コードを保持します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-182">A .hlsl file holds source code for the shader; a .cso file holds the corresponding shader byte code.</span></span> <span data-ttu-id="e9fd4-183">オフラインで .hlsl ファイルを変換してゲームに .cso ファイルを渡すと、ゲームの読み込み時に HLSL ソース ファイルをバイト コードに変換する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-183">When you convert .hlsl files offline and provide .cso files with your game, you avoid the need to convert HLSL source files to byte code when your game loads.</span></span>

<span data-ttu-id="e9fd4-184">教育的な理由で、Marble Maze プロジェクトには多くのリソースの設計時形式と実行時形式の両方が含まれていますが、ゲームのソース プロジェクトで保持する必要があるのは設計時形式だけです。実行時形式には、必要になったときに変換します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-184">For instructional reasons, the Marble Maze project includes both the design-time format and the run-time format for many resources, but you only have to maintain the design-time formats in the source project for your own game because you can convert them to run-time formats when you need them.</span></span> <span data-ttu-id="e9fd4-185">このドキュメントでは、設計時形式を実行時形式に変換する方法について説明しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-185">This documentation shows how to convert the design-time formats to the run-time formats.</span></span>

##  <a name="application-life-cycle"></a><span data-ttu-id="e9fd4-186">アプリケーション ライフ サイクル</span><span class="sxs-lookup"><span data-stu-id="e9fd4-186">Application life cycle</span></span>


<span data-ttu-id="e9fd4-187">Marble Maze は、一般的な UWP アプリのライフ サイクルに従っています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-187">Marble Maze follows the life cycle of a typical UWP app.</span></span> <span data-ttu-id="e9fd4-188">UWP アプリのライフ サイクルについて詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-188">For more info about the life cycle of a UWP app, see [App lifecycle](https://msdn.microsoft.com/library/windows/apps/mt243287).</span></span>

<span data-ttu-id="e9fd4-189">UWP ゲームの初期化時には、通常、Direct3D、Direct2D などのランタイム コンポーネントと、ゲームで使われる入力、オーディオ、または物理ライブラリが初期化されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-189">When a UWP game initializes, it typically initializes runtime components such as Direct3D, Direct2D, and any input, audio, or physics libraries that it uses.</span></span> <span data-ttu-id="e9fd4-190">また、ゲームを開始する前に必要なゲーム固有のリソースも読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-190">It also loads game-specific resources that are required before the game begins.</span></span> <span data-ttu-id="e9fd4-191">この初期化は、ゲーム セッション中に 1 回行われます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-191">This initialization occurs one time during a game session.</span></span>

<span data-ttu-id="e9fd4-192">初期化後、ゲームは通常、*ゲーム ループ*を実行します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-192">After initialization, games typically run the *game loop*.</span></span> <span data-ttu-id="e9fd4-193">このループでは、ゲームは通常、4 つの操作を実行します。それらは、Windows イベントの処理、入力の収集、シーン オブジェクトの更新、シーンの表示です。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-193">In this loop, games typically perform four actions: process Windows events, collect input, update scene objects, and render the scene.</span></span> <span data-ttu-id="e9fd4-194">ゲームがシーンを更新するときに、現在の入力状態をシーン オブジェクトに適用し、オブジェクトの衝突などの物理的なイベントをシミュレートすることができます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-194">When the game updates the scene, it can apply the current input state to the scene objects and simulate physical events, such as object collisions.</span></span> <span data-ttu-id="e9fd4-195">また、効果音の再生やネットワーク経由のデータ送信など、その他のアクティビティも実行できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-195">The game can also perform other activities such as playing sound effects or sending data over the network.</span></span> <span data-ttu-id="e9fd4-196">ゲームがシーンを表示するときに、シーンの現在の状態がキャプチャされ、ディスプレイ デバイスに描画されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-196">When the game renders the scene, it captures the current state of the scene and draws it to the display device.</span></span> <span data-ttu-id="e9fd4-197">以降のセクションでは、これらのアクティビティについてさらに詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-197">The following sections describe these activities in greater detail.</span></span>

##  <a name="adding-to-the-template"></a><span data-ttu-id="e9fd4-198">テンプレートへの追加</span><span class="sxs-lookup"><span data-stu-id="e9fd4-198">Adding to the template</span></span>


<span data-ttu-id="e9fd4-199">**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートは、Direct3D によるレンダリング先にできるコア ウィンドウを作成します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-199">The **DirectX 11 App (Universal Windows)** template creates a core window to which you can render with Direct3D.</span></span> <span data-ttu-id="e9fd4-200">また、テンプレートには、UWP アプリで 3D コンテンツをレンダリングする際に必要な Direct3D デバイス リソースをすべて作成する **DeviceResources** クラスも含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-200">The template also includes the **DeviceResources** class that creates all of the Direct3D device resources needed for rendering 3D content in a UWP app.</span></span>

<span data-ttu-id="e9fd4-201">**App** クラスは、**MarbleMazeMain** クラス オブジェクトを作成し、リソースの読み込みを開始し、ループしてタイマーを更新し、フレームごとに **MarbleMazeMain::Render** レンダリング メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-201">The **App** class creates the **MarbleMazeMain** class object, starts the loading of resources, loops to update the timer, and calls the **MarbleMazeMain::Render** method each frame.</span></span> <span data-ttu-id="e9fd4-202">**App::OnWindowSizeChanged**、**App::OnDpiChanged**、および **App::OnOrientationChanged** メソッドはそれぞれ **MarbleMazeMain::CreateWindowSizeDependentResources** メソッドを呼び出し、**App::Run** メソッドは **MarbleMazeMain::Update** および **MarbleMazeMain::Render** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-202">The **App::OnWindowSizeChanged**, **App::OnDpiChanged**, and **App::OnOrientationChanged** methods each call the **MarbleMazeMain::CreateWindowSizeDependentResources** method, and the **App::Run** method calls the **MarbleMazeMain::Update** and **MarbleMazeMain::Render** methods.</span></span>

<span data-ttu-id="e9fd4-203">次の例は、**App::SetWindow** メソッドが **MarbleMazeMain** クラス オブジェクトを作成する箇所を示しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-203">The following example shows where the **App::SetWindow** method creates the **MarbleMazeMain** class object.</span></span> <span data-ttu-id="e9fd4-204">Direct3D オブジェクトを使ってレンダリングできるように、**DeviceResources** クラスがメソッドに渡されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-204">The **DeviceResources** class is passed to the method so it can use the Direct3D objects for rendering.</span></span>

```cpp
    m_main = std::unique_ptr<MarbleMazeMain>(new MarbleMazeMain(m_deviceResources));
```

<span data-ttu-id="e9fd4-205">**App** クラスは、ゲームのリソースの遅延読み込みも開始します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-205">The **App** class also starts loading the deferred resources for the game.</span></span> <span data-ttu-id="e9fd4-206">詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-206">See the next section for more detail.</span></span>

<span data-ttu-id="e9fd4-207">さらに、**App** クラスは [CoreWindow](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) イベント用のイベント ハンドラーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-207">Additionally, the **App** class sets up the event handlers for the [CoreWindow](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) events.</span></span> <span data-ttu-id="e9fd4-208">これらのイベントのハンドラーが呼び出されると、入力が **MarbleMazeMain** クラスに渡されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-208">When the handlers for these events are called, they pass the input to the **MarbleMazeMain** class.</span></span>

## <a name="loading-game-assets-in-the-background"></a><span data-ttu-id="e9fd4-209">バックグラウンドでのゲーム アセットの読み込み</span><span class="sxs-lookup"><span data-stu-id="e9fd4-209">Loading game assets in the background</span></span>


<span data-ttu-id="e9fd4-210">起動後 5 秒以内にゲームがウィンドウ イベントに応答できるようにするために、ゲーム アセットは非同期的に、またはバックグラウンドで読み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-210">To ensure that your game can respond to window events within 5 seconds after it is launched, we recommend that you load your game assets asynchronously, or in the background.</span></span> <span data-ttu-id="e9fd4-211">バックグラウンドでのアセットの読み込み中、ゲームはウィンドウ イベントに応答できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-211">As assets load in the background, your game can respond to window events.</span></span>

> [!NOTE]
> <span data-ttu-id="e9fd4-212">また、準備ができたらメイン メニューを表示することもでき、残りのアセットをバックグラウンドで読み込み続けることができます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-212">You can also display the main menu when it is ready, and allow the remaining assets to continue loading in the background.</span></span> <span data-ttu-id="e9fd4-213">すべてのリソースが読み込まれる前にユーザーがメニューのオプションを選択した場合は、進行状況バーを表示するなどして、シーン リソースが読み込み中であることを示すことができます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-213">If the user selects an option from the menu before all resources are loaded, you can indicate that scene resources are continuing to load by displaying a progress bar, for example.</span></span>

 

<span data-ttu-id="e9fd4-214">ゲームに含まれているゲーム アセットが比較的少ない場合でも、非同期的に読み込むことをお勧めします。これには 2 つの理由があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-214">Even if your game contains relatively few game assets, it is good practice to load them asynchronously for two reasons.</span></span> <span data-ttu-id="e9fd4-215">1 つの理由は、すべてのデバイスとすべての構成ですべてのリソースをすばやく読み込めることを保証することが難しいことです。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-215">One reason is that it is difficult to guarantee that all of your resources will load quickly on all devices and all configurations.</span></span> <span data-ttu-id="e9fd4-216">また、非同期的な読み込みを早期に組み込むことによって、機能の追加による規模の拡大にもコードが対応できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-216">Also, by incorporating asynchronous loading early, your code is ready to scale as you add functionality.</span></span>

<span data-ttu-id="e9fd4-217">非同期のアセット読み込みは、**App::Load** メソッドで始まります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-217">Asynchronous asset loading begins with the **App::Load** method.</span></span> <span data-ttu-id="e9fd4-218">このメソッドは [task](https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class) クラスを使って、バックグラウンドでゲーム アセットを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-218">This method uses the [task](https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class) class to load game assets in the background.</span></span>

```cpp
    task<void>([=]()
    {
        m_main->LoadDeferredResources(true, false);
    });
```

<span data-ttu-id="e9fd4-219">**MarbleMazeMain** クラスは、非同期読み込みが完了したことを示す *m\_deferredResourcesReady* フラグを定義します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-219">The **MarbleMazeMain** class defines the *m\_deferredResourcesReady* flag to indicate that asynchronous loading is complete.</span></span> <span data-ttu-id="e9fd4-220">**MarbleMazeMain::LoadDeferredResources** メソッドは、ゲーム リソースを読み込んで、このフラグを設定します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-220">The **MarbleMazeMain::LoadDeferredResources** method loads the game resources and then sets this flag.</span></span> <span data-ttu-id="e9fd4-221">アプリの更新 (**MarbleMazeMain::Update**) フェーズとレンダリング (**MarbleMazeMain::Render**) フェーズでは、このフラグを確認します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-221">The update (**MarbleMazeMain::Update**) and render (**MarbleMazeMain::Render**) phases of the app check this flag.</span></span> <span data-ttu-id="e9fd4-222">このフラグが設定されると、ゲームは正常に続行されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-222">When this flag is set, the game continues as normal.</span></span> <span data-ttu-id="e9fd4-223">フラグがまだ設定されていない場合、ゲームは読み込み画面を表示します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-223">If the flag is not yet set, the game shows the loading screen.</span></span>

<span data-ttu-id="e9fd4-224">UWP アプリの非同期プログラミングについて詳しくは、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-224">For more information about asynchronous programming for UWP apps, see [Asynchronous programming in C++](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span>

> [!TIP]
> <span data-ttu-id="e9fd4-225">Windows ランタイム C++ ライブラリの一部であるゲーム コード (つまり DLL) を記述している場合は、アプリとその他のライブラリで使える非同期操作を作る方法を学ぶために「[UWP アプリ用に C++ で非同期操作を作成](https://docs.microsoft.com/cpp/parallel/concrt/creating-asynchronous-operations-in-cpp-for-windows-store-apps)」を読むことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-225">If you’re writing game code that is part of a Windows Runtime C++ Library (in other words, a DLL), consider whether to read [Creating Asynchronous Operations in C++ for UWP apps](https://docs.microsoft.com/cpp/parallel/concrt/creating-asynchronous-operations-in-cpp-for-windows-store-apps) to learn how to create asynchronous operations that can be consumed by apps and other libraries.</span></span>

 

## <a name="the-game-loop"></a><span data-ttu-id="e9fd4-226">ゲーム ループ</span><span class="sxs-lookup"><span data-stu-id="e9fd4-226">The game loop</span></span>


<span data-ttu-id="e9fd4-227">**App::Run** メソッドは、メイン ゲーム ループ (**MarbleMazeMain::Update**) を実行します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-227">The **App::Run** method runs the main game loop (**MarbleMazeMain::Update**).</span></span> <span data-ttu-id="e9fd4-228">このメソッドはフレームごとに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-228">This method is called every frame.</span></span>

<span data-ttu-id="e9fd4-229">ゲーム固有のコードからビューとウィンドウのコードを分離しやすくするために、**App::Run** メソッドの実装では更新とレンダリングの呼び出しが **MarbleMazeMain** オブジェクトに転送されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-229">To help separate view and window code from game-specific code, we implemented the **App::Run** method to forward update and render calls to the **MarbleMazeMain** object.</span></span>

<span data-ttu-id="e9fd4-230">次の例は、メイン ゲーム ループが含まれている **App::Run** メソッドを示しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-230">The following example shows the **App::Run** method, which includes the main game loop.</span></span> <span data-ttu-id="e9fd4-231">ゲーム ループは合計時間とフレーム時間の変数を更新し、シーンの更新とレンダリングを行います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-231">The game loop updates the total time and frame time variables, and then updates and renders the scene.</span></span> <span data-ttu-id="e9fd4-232">これにより、ウィンドウが表示されているときにだけコンテンツがレンダリングされることも保証されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-232">This also makes sure that content is only rendered when the window is visible.</span></span>

```cpp
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->
                ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->
                ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }

    // The app is exiting so do the same thing as if the app were being suspended.
    m_main->OnSuspending();

#ifdef _DEBUG
    // Dump debug info when exiting.
    DumpD3DDebug();
#endif //_DEGBUG
}
```

## <a name="the-state-machine"></a><span data-ttu-id="e9fd4-233">ステート マシン</span><span class="sxs-lookup"><span data-stu-id="e9fd4-233">The state machine</span></span>


<span data-ttu-id="e9fd4-234">ゲームは通常、ゲーム ロジックのフローと順序を制御するために、*ステート マシン* (*有限ステート マシン*、FSM とも呼ばれます) を備えています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-234">Games typically contain a *state machine* (also known as a *finite state machine*, or FSM) to control the flow and order of the game logic.</span></span> <span data-ttu-id="e9fd4-235">ステート マシンには、特定の数の状態と、状態間を遷移する機能が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-235">A state machine contains a given number of states and the ability to transition among them.</span></span> <span data-ttu-id="e9fd4-236">通常、ステート マシンは*初期*状態から始まり、1 つ以上の*中間*状態に遷移し、*終端*状態で終了します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-236">A state machine typically starts from an *initial* state, transitions to one or more *intermediate* states, and possibly ends at a *terminal* state.</span></span>

<span data-ttu-id="e9fd4-237">ゲーム ループでは多くの場合、現在のゲームの状態に固有のロジックを実行できるように、ステート マシンを使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-237">A game loop often uses a state machine so that it can perform the logic that is specific to the current game state.</span></span> <span data-ttu-id="e9fd4-238">Marble Maze では、ゲームの各状態を定義する **GameState** 列挙が定義されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-238">Marble Maze defines the **GameState** enumeration, which defines each possible state of the game.</span></span>

```cpp
enum class GameState
{
    Initial,
    MainMenu,
    HighScoreDisplay,
    PreGameCountdown,
    InGameActive,
    InGamePaused,
    PostGameResults,
};
```

<span data-ttu-id="e9fd4-239">たとえば、**MainMenu** 状態は、メイン メニューが表示され、ゲームがアクティブでないと定義されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-239">The **MainMenu** state, for example, defines that the main menu appears, and that the game is not active.</span></span> <span data-ttu-id="e9fd4-240">反対に、**InGameActive** 状態は、ゲームがアクティブで、メニューが表示されていないと定義されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-240">Conversely, the **InGameActive** state defines that the game is active, and that the menu does not appear.</span></span> <span data-ttu-id="e9fd4-241">**MarbleMazeMain** クラスは、アクティブなゲームの状態を保持するために、**m\_gameState** メンバー変数を定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-241">The **MarbleMazeMain** class defines the **m\_gameState** member variable to hold the active game state.</span></span>

<span data-ttu-id="e9fd4-242">**MarbleMazeMain::Update** メソッドと **MarbleMazeMain::Render** メソッドは、現在の状態のロジックを実行するために、switch ステートメントを使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-242">The **MarbleMazeMain::Update** and **MarbleMazeMain::Render** methods use switch statements to perform logic for the current state.</span></span> <span data-ttu-id="e9fd4-243">次の例は、**MarbleMazeMain::Update** メソッドでのこの switch ステートメントがどのようなものかを示しています (構造をわかりやすく示すために、細部は削除されています)。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-243">The following example shows what a switch statement might look like for the **MarbleMazeMain::Update** method (details are removed to illustrate the structure).</span></span>

```cpp
switch (m_gameState)
{
case GameState::MainMenu:
    // Do something with the main menu. 
    break;

case GameState::HighScoreDisplay:
    // Do something with the high-score table. 
    break;

case GameState::PostGameResults:
    // Do something with the game results. 
    break;

case GameState::InGamePaused:
    // Handle the paused state. 
    break;
}
```

<span data-ttu-id="e9fd4-244">ゲーム ロジックまたはレンダリングが特定のゲーム状態に依存する場合、このドキュメントではそれを強調して示しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-244">When game logic or rendering depends on a specific game state, we emphasize it in this documentation.</span></span>

## <a name="handling-app-and-window-events"></a><span data-ttu-id="e9fd4-245">アプリとウィンドウのイベントの処理</span><span class="sxs-lookup"><span data-stu-id="e9fd4-245">Handling app and window events</span></span>


<span data-ttu-id="e9fd4-246">Windows ランタイムには、Windows メッセージをより簡単に管理できるようにするために、オブジェクト指向のイベント処理システムが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-246">The Windows Runtime provides an object-oriented event-handling system so that you can more easily manage Windows messages.</span></span> <span data-ttu-id="e9fd4-247">アプリケーションのイベントを使うには、イベントに応答するイベント ハンドラーまたはイベント処理メソッドを準備する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-247">To consume an event in an application, you must provide an event handler, or event-handling method, that responds to the event.</span></span> <span data-ttu-id="e9fd4-248">また、イベント ハンドラーをイベント ソースに登録する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-248">You must also register the event handler with the event source.</span></span> <span data-ttu-id="e9fd4-249">このプロセスは、一般に、イベントの関連付けと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-249">This process is often referred to as event wiring.</span></span>

### <a name="supporting-suspend-resume-and-restart"></a><span data-ttu-id="e9fd4-250">中断、再開、再起動の処理</span><span class="sxs-lookup"><span data-stu-id="e9fd4-250">Supporting suspend, resume, and restart</span></span>

<span data-ttu-id="e9fd4-251">ユーザーがアプリを切り替えた場合、または Windows が低電力状態に切り替わった場合は、Marble Maze を中断できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-251">Marble Maze is suspended when the user switches away from it or when Windows enters a low power state.</span></span> <span data-ttu-id="e9fd4-252">ゲームは、ユーザーがフォアグラウンドにゲームを移行した場合、または Windows が低電力状態から復帰した場合に再開されます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-252">The game is resumed when the user moves it to the foreground or when Windows comes out of a low power state.</span></span> <span data-ttu-id="e9fd4-253">通常は、アプリを閉じません。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-253">Generally, you don't close apps.</span></span> <span data-ttu-id="e9fd4-254">アプリが中断状態にあり、アプリが使っているメモリなどのリソースを Windows が必要とする場合、Windows はアプリを終了できます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-254">Windows can terminate the app when it's in the suspended state and Windows requires the resources, such as memory, that the app is using.</span></span> <span data-ttu-id="e9fd4-255">アプリが中断または再開されるときに、Windows はアプリに通知しますが、終了されるときには通知しません。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-255">Windows notifies an app when it is about to be suspended or resumed, but it doesn't notify the app when it's about to be terminated.</span></span> <span data-ttu-id="e9fd4-256">そのため、アプリが中断されることを Windows がアプリに通知した時点で、アプリが再起動されるときに現在のユーザー状態を復元するために必要なすべてのデータをアプリが保存できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-256">Therefore, your app must be able to save—at the point when Windows notifies your app that it is about to be suspended—any data that would be required to restore the current user state when the app is restarted.</span></span> <span data-ttu-id="e9fd4-257">保存の負荷が高い特別なユーザー状態がアプリにある場合は、アプリが中断通知を受信する前であっても、状態を定期的に保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-257">If your app has significant user state that is expensive to save, you may also need to save state regularly, even before your app receives the suspend notification.</span></span> <span data-ttu-id="e9fd4-258">Marble Maze は、次の 2 つの理由で、中断と再開の通知に応答します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-258">Marble Maze responds to suspend and resume notifications for two reasons:</span></span>

1.  <span data-ttu-id="e9fd4-259">アプリが一時停止されるときに、ゲームは現在のゲーム状態を保存し、オーディオの再生を一時停止します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-259">When the app is suspended, the game saves the current game state and pauses audio playback.</span></span> <span data-ttu-id="e9fd4-260">アプリが再開されるときに、ゲームはオーディオ再生を再開します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-260">When the app is resumed, the game resumes audio playback.</span></span>
2.  <span data-ttu-id="e9fd4-261">アプリが閉じられ、後で再起動されるとき、ゲームは前の状態から再開します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-261">When the app is closed and later restarted, the game resumes from its previous state.</span></span>

<span data-ttu-id="e9fd4-262">Marble Maze は、中断と再開をサポートするために、次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-262">Marble Maze performs the following tasks to support suspend and resume:</span></span>

-   <span data-ttu-id="e9fd4-263">ユーザーがチェックポイントに達したときのような、ゲームの重要なポイントで、状態を固定ストレージに保存します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-263">It saves its state to persistent storage at key points in the game, such as when the user reaches a checkpoint.</span></span>
-   <span data-ttu-id="e9fd4-264">中断の通知に対応して、状態を固定ストレージに保存します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-264">It responds to suspend notifications by saving its state to persistent storage.</span></span>
-   <span data-ttu-id="e9fd4-265">再開の通知に対応して、状態を固定ストレージから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-265">It responds to resume notifications by loading its state from persistent storage.</span></span> <span data-ttu-id="e9fd4-266">起動中に、以前の状態も読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-266">It also loads the previous state during startup.</span></span>

<span data-ttu-id="e9fd4-267">中断と再開をサポートするために、Marble Maze は **PersistentState** クラスを定義しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-267">To support suspend and resume, Marble Maze defines the **PersistentState** class.</span></span> <span data-ttu-id="e9fd4-268">**PersistentState.h** と **PersistentState.cpp** をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-268">(See **PersistentState.h** and **PersistentState.cpp**).</span></span> <span data-ttu-id="e9fd4-269">このクラスは、プロパティの読み取りと書き込みに [Windows::Foundation::Collections::IPropertySet](https://docs.microsoft.com/uwp/api/Windows.Foundation.Collections.IPropertySet) インターフェイスを使います。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-269">This class uses the [Windows::Foundation::Collections::IPropertySet](https://docs.microsoft.com/uwp/api/Windows.Foundation.Collections.IPropertySet) interface to read and write properties.</span></span> <span data-ttu-id="e9fd4-270">**PersistentState** クラスには、バッキング ストアとの間でプリミティブ データ型 (**bool**、**int**、**float**、[XMFLOAT3](https://msdn.microsoft.com/library/windows/desktop/ee419475)、[Platform::String](https://docs.microsoft.com/cpp/cppcx/platform-string-class) など) の読み取りと書き込みを行うメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-270">The **PersistentState** class provides methods that read and write primitive data types (such as **bool**, **int**, **float**, [XMFLOAT3](https://msdn.microsoft.com/library/windows/desktop/ee419475), and [Platform::String](https://docs.microsoft.com/cpp/cppcx/platform-string-class)), from and to a backing store.</span></span>

```cpp
ref class PersistentState
{
internal:
    void Initialize(
        _In_ Windows::Foundation::Collections::IPropertySet^ settingsValues,
        _In_ Platform::String^ key
        );

    void SaveBool(Platform::String^ key, bool value);
    void SaveInt32(Platform::String^ key, int value);
    void SaveSingle(Platform::String^ key, float value);
    void SaveXMFLOAT3(Platform::String^ key, DirectX::XMFLOAT3 value);
    void SaveString(Platform::String^ key, Platform::String^ string);

    bool LoadBool(Platform::String^ key, bool defaultValue);
    int  LoadInt32(Platform::String^ key, int defaultValue);
    float LoadSingle(Platform::String^ key, float defaultValue);

    DirectX::XMFLOAT3 LoadXMFLOAT3(
        Platform::String^ key, 
        DirectX::XMFLOAT3 defaultValue);

    Platform::String^ LoadString(
        Platform::String^ key, 
        Platform::String^ defaultValue);

private:
    Platform::String^ m_keyName;
    Windows::Foundation::Collections::IPropertySet^ m_settingsValues;
};
```

<span data-ttu-id="e9fd4-271">**MarbleMazeMain** クラスは **PersistentState** オブジェクトを保持しています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-271">The **MarbleMazeMain** class holds a **PersistentState** object.</span></span> <span data-ttu-id="e9fd4-272">**MarbleMazeMain** コンストラクターは、このオブジェクトを初期化し、ローカル アプリケーション データ ストアをバッキング データ ストアとして提供します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-272">The **MarbleMazeMain** constructor initializes this object and provides the local application data store as the backing data store.</span></span>

```cpp
m_persistentState = ref new PersistentState();

m_persistentState->Initialize(
    Windows::Storage::ApplicationData::Current->LocalSettings->Values,
    "MarbleMaze");
```

<span data-ttu-id="e9fd4-273">Marble Maze は、大理石がチェックポイントやゴールを通過したときに **MarbleMazeMain::Update** メソッドで状態を保存し、ウィンドウからフォーカスが移動されたときに **MarbleMazeMain::OnFocusChange** メソッドで状態を保存します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-273">Marble Maze saves its state when the marble passes over a checkpoint or the goal (in the **MarbleMazeMain::Update** method), and when the window loses focus (in the **MarbleMazeMain::OnFocusChange** method).</span></span> <span data-ttu-id="e9fd4-274">中断の通知に対処できる時間は数秒しかないので、ゲームが大量の状態データを保持する場合は、同様の方法でときどき状態を固定ストレージに保存することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-274">If your game holds a large amount of state data, we recommend that you occasionally save state to persistent storage in a similar manner because you only have a few seconds to respond to the suspend notification.</span></span> <span data-ttu-id="e9fd4-275">これにより、アプリが中断通知を受け取ったときに、変更があった状態データを保存するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-275">Therefore, when your app receives a suspend notification, it only has to save the state data that has changed.</span></span>

<span data-ttu-id="e9fd4-276">中断と再開の通知に応答するために、**MarbleMazeMain** クラスは、中断時と再開時に呼び出される **SaveState** メソッドと **LoadState** メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-276">To respond to suspend and resume notifications, the **MarbleMazeMain** class defines the **SaveState** and **LoadState** methods that are called on suspend and resume.</span></span> <span data-ttu-id="e9fd4-277">**MarbleMazeMain::OnSuspending** メソッドは中断イベントを処理し、**MarbleMazeMain::OnResuming** メソッドは再開イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-277">The **MarbleMazeMain::OnSuspending** method handles the suspend event and the **MarbleMazeMain::OnResuming** method handles the resume event.</span></span>

<span data-ttu-id="e9fd4-278">**MarbleMazeMain::OnSuspending** メソッドはゲーム状態を保存し、オーディオを一時停止します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-278">The **MarbleMazeMain::OnSuspending** method saves game state and suspends audio.</span></span>

```cpp
void MarbleMazeMain::OnSuspending()
{
    SaveState();
    m_audio.SuspendAudio();
}
```

<span data-ttu-id="e9fd4-279">**MarbleMazeMain::SaveState** メソッドは、大理石の現在位置と速度、最新のチェックポイント、ハイ スコア表など、ゲームの状態の値を保存します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-279">The **MarbleMazeMain::SaveState** method saves game state values such as the current position and velocity of the marble, the most recent checkpoint, and the high-score table.</span></span>

```cpp
void MarbleMazeMain::SaveState()
{
    m_persistentState->SaveXMFLOAT3(":Position", m_physics.GetPosition());
    m_persistentState->SaveXMFLOAT3(":Velocity", m_physics.GetVelocity());

    m_persistentState->SaveSingle(
        ":ElapsedTime", 
        m_inGameStopwatchTimer.GetElapsedTime());

    m_persistentState->SaveInt32(":GameState", static_cast<int>(m_gameState));
    m_persistentState->SaveInt32(":Checkpoint", static_cast<int>(m_currentCheckpoint));

    int i = 0;
    HighScoreEntries entries = m_highScoreTable.GetEntries();
    const int bufferLength = 16;
    char16 str[bufferLength];

    m_persistentState->SaveInt32(":ScoreCount", static_cast<int>(entries.size()));

    for (auto iter = entries.begin(); iter != entries.end(); ++iter)
    {
        int len = swprintf_s(str, bufferLength, L"%d", i++);
        Platform::String^ string = ref new Platform::String(str, len);

        m_persistentState->SaveSingle(
            Platform::String::Concat(":ScoreTime", string), 
            iter->elapsedTime);

        m_persistentState->SaveString(
            Platform::String::Concat(":ScoreTag", string), 
            iter->tag);
    }
}
```

<span data-ttu-id="e9fd4-280">ゲームの再開時に必要なのは、オーディオの再開だけです。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-280">When the game resumes, it only has to resume audio.</span></span> <span data-ttu-id="e9fd4-281">状態は既にメモリに読み込まれているので、固定ストレージから状態を読み込む必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-281">It doesn't have to load state from persistent storage because the state is already loaded in memory.</span></span>

<span data-ttu-id="e9fd4-282">オーディオの一時停止と再開の方法は、ドキュメント「[Marble Maze のサンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-282">How the game suspends and resumes audio is explained in the document [Adding audio to the Marble Maze sample](adding-audio-to-the-marble-maze-sample.md).</span></span>

<span data-ttu-id="e9fd4-283">再起動をサポートするために、起動中に呼び出される **MarbleMazeMain** コンストラクターは **MarbleMazeMain::LoadState** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-283">To support restart, the **MarbleMazeMain** constructor, which is called during startup, calls the **MarbleMazeMain::LoadState** method.</span></span> <span data-ttu-id="e9fd4-284">**MarbleMazeMain::LoadState** メソッドは状態を読み取り、その状態をゲーム オブジェクトに適用します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-284">The **MarbleMazeMain::LoadState** method reads and applies the state to the game objects.</span></span> <span data-ttu-id="e9fd4-285">また、このメソッドは、ゲームが中断されたときにゲームが一時停止またはアクティブであった場合は、現在のゲームの状態を一時停止に設定します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-285">This method also sets the current game state to paused if the game was paused or active when it was suspended.</span></span> <span data-ttu-id="e9fd4-286">突然動作が始まってユーザーを驚かせることがないように、ゲームを一時停止にします。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-286">We pause the game so that the user is not surprised by unexpected activity.</span></span> <span data-ttu-id="e9fd4-287">また、ゲームが中断されたときにゲームがゲームプレイ状態でなかった場合は、メイン メニューに移動します。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-287">It also moves to the main menu if the game was not in a gameplay state when it was suspended.</span></span>

```cpp
void MarbleMazeMain::LoadState()
{
    XMFLOAT3 position = m_persistentState->LoadXMFLOAT3(
        ":Position", 
        m_physics.GetPosition());

    XMFLOAT3 velocity = m_persistentState->LoadXMFLOAT3(
        ":Velocity", 
        m_physics.GetVelocity());

    float elapsedTime = m_persistentState->LoadSingle(":ElapsedTime", 0.0f);

    int gameState = m_persistentState->LoadInt32(
        ":GameState", 
        static_cast<int>(m_gameState));

    int currentCheckpoint = m_persistentState->LoadInt32(
        ":Checkpoint", 
        static_cast<int>(m_currentCheckpoint));

    switch (static_cast<GameState>(gameState))
    {
    case GameState::Initial:
        break;

    case GameState::MainMenu:
    case GameState::HighScoreDisplay:
    case GameState::PreGameCountdown:
    case GameState::PostGameResults:
        SetGameState(GameState::MainMenu);
        break;

    case GameState::InGameActive:
    case GameState::InGamePaused:
        m_inGameStopwatchTimer.SetVisible(true);
        m_inGameStopwatchTimer.SetElapsedTime(elapsedTime);
        m_physics.SetPosition(position);
        m_physics.SetVelocity(velocity);
        m_currentCheckpoint = currentCheckpoint;
        SetGameState(GameState::InGamePaused);
        break;
    }

    int count = m_persistentState->LoadInt32(":ScoreCount", 0);

    const int bufferLength = 16;
    char16 str[bufferLength];

    for (int i = 0; i < count; i++)
    {
        HighScoreEntry entry;
        int len = swprintf_s(str, bufferLength, L"%d", i);
        Platform::String^ string = ref new Platform::String(str, len);

        entry.elapsedTime = m_persistentState->LoadSingle(
            Platform::String::Concat(":ScoreTime", string), 
            0.0f);

        entry.tag = m_persistentState->LoadString(
            Platform::String::Concat(":ScoreTag", string), 
            L"");

        m_highScoreTable.AddScoreToTable(entry);
    }
}
```

> [!IMPORTANT]
> <span data-ttu-id="e9fd4-288">Marble Maze は、コールド スタート (つまり、以前の中断イベントがない、初めての起動) と、中断状態からの再開とを区別しません。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-288">Marble Maze doesn't distinguish between cold starting—that is, starting for the first time without a prior suspend event—and resuming from a suspended state.</span></span> <span data-ttu-id="e9fd4-289">これは、すべての UWP アプリにお勧めする設計です。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-289">This is recommended design for all UWP apps.</span></span>

<span data-ttu-id="e9fd4-290">アプリケーション データについて詳しくは、「[設定と他のアプリ データを保存して取得する](https://msdn.microsoft.com/library/windows/apps/mt299098)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-290">For more info about application data, see [Store and retrieve settings and other app data](https://msdn.microsoft.com/library/windows/apps/mt299098).</span></span>

##  <a name="next-steps"></a><span data-ttu-id="e9fd4-291">次の手順</span><span class="sxs-lookup"><span data-stu-id="e9fd4-291">Next steps</span></span>


<span data-ttu-id="e9fd4-292">視覚的なリソースを扱う際の主な手法については、「[Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9fd4-292">Read [Adding visual content to the Marble Maze sample](adding-visual-content-to-the-marble-maze-sample.md) for information about some of the key practices to keep in mind when you work with visual resources.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e9fd4-293">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e9fd4-293">Related topics</span></span>

* [<span data-ttu-id="e9fd4-294">Marble Maze サンプルへの視覚的なコンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="e9fd4-294">Adding visual content to the Marble Maze sample</span></span>](adding-visual-content-to-the-marble-maze-sample.md)
* [<span data-ttu-id="e9fd4-295">Marble Maze サンプルの基礎</span><span class="sxs-lookup"><span data-stu-id="e9fd4-295">Marble Maze sample fundamentals</span></span>](marble-maze-sample-fundamentals.md)
* [<span data-ttu-id="e9fd4-296">Marble Maze、C++ と DirectX での UWP ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="e9fd4-296">Developing Marble Maze, a UWP game in C++ and DirectX</span></span>](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




