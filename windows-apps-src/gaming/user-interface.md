---
title: DirectX ゲーム プロジェクト テンプレート
description: ユニバーサル Windows プラットフォーム (UWP) および DirectX ゲームを作成するためのテンプレートについて説明します。
ms.assetid: 41b6cd76-5c9a-e2b7-ef6f-bfbf6ef7331d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, テンプレート
ms.localizationpriority: medium
ms.openlocfilehash: 9a4491fe9a3bb97a73652c40a2968f2f53c377b5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634247"
---
# <a name="directx-game-project-templates"></a><span data-ttu-id="7db5a-104">DirectX ゲーム プロジェクト テンプレート</span><span class="sxs-lookup"><span data-stu-id="7db5a-104">DirectX game project templates</span></span>



<span data-ttu-id="7db5a-105">DirectX とユニバーサル Windows プラットフォーム (UWP) のテンプレートは、ゲームの出発点として使ってプロジェクトをすばやく作成することができます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-105">The DirectX and Universal Windows Platform (UWP) templates allow you to quickly create a project as a starting point for your game.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7db5a-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="7db5a-106">Prerequisites</span></span>


<span data-ttu-id="7db5a-107">プロジェクトを作成するには、次の作業が必要です。</span><span class="sxs-lookup"><span data-stu-id="7db5a-107">To create the project you need to:</span></span>

-   <span data-ttu-id="7db5a-108">[Microsoft Visual Studio 2015 のダウンロード](https://www.visualstudio.com/vs-2015-product-editions)します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-108">[Download Microsoft Visual Studio 2015](https://www.visualstudio.com/vs-2015-product-editions).</span></span> <span data-ttu-id="7db5a-109">Visual Studio 2015 では、グラフィックスのデバッグ ツールなど、プログラミング ツールがあります。</span><span class="sxs-lookup"><span data-stu-id="7db5a-109">Visual Studio 2015 has tools for graphics programming, such as debugging tools.</span></span> <span data-ttu-id="7db5a-110">DirectX グラフィックス、ゲーム機能、ツールの概要については、「[DirectX ゲーム開発用の Visual Studio ツール](set-up-visual-studio-for-game-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7db5a-110">For an overview of DirectX graphics and gaming features and tools, see [Visual Studio tools for DirectX game development](set-up-visual-studio-for-game-development.md).</span></span>

## <a name="choosing-a-template"></a><span data-ttu-id="7db5a-111">テンプレートの選択</span><span class="sxs-lookup"><span data-stu-id="7db5a-111">Choosing a template</span></span>


<span data-ttu-id="7db5a-112">Visual Studio 2015 には、DirectX および UWP の 3 つのテンプレートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7db5a-112">Visual Studio 2015 includes three DirectX and UWP templates:</span></span>

-   <span data-ttu-id="7db5a-113">DirectX 11 アプリ (ユニバーサル Windows) - DirectX 11 アプリ (ユニバーサル Windows) テンプレートは、DirectX 11 を使ってアプリ ウィンドウに直接レンダリングする UWP プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-113">DirectX 11 App (Universal Windows) - The DirectX 11 App (Universal Windows) template creates a UWP project, which renders directly to an app window using DirectX 11.</span></span>
-   <span data-ttu-id="7db5a-114">DirectX 12 アプリ (ユニバーサル Windows) - DirectX 12 アプリ (ユニバーサル Windows) テンプレートは、DirectX 12 を使ってアプリ ウィンドウに直接レンダリングする UWP プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-114">DirectX 12 App (Universal Windows) - The DirectX 12 App (Universal Windows) template creates a project UWP, which renders directly to an app window using DirectX 12.</span></span>
-   <span data-ttu-id="7db5a-115">DirectX 11 および XAML アプリ (ユニバーサル Windows) - DirectX 11 および XAML アプリ (ユニバーサル Windows) テンプレートは、DirectX 11 を使って XAML コントロール内にレンダリングする UWP プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-115">DirectX 11 and XAML App (Universal Windows) - The DirectX 11 and XAML App (Universal Windows) template creates a UWP project, which renders inside a XAML control using DirectX 11.</span></span> <span data-ttu-id="7db5a-116">このテンプレートは [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) を使うため、XAML UI コントロールを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-116">This template uses a [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834), so you can use XAML UI controls.</span></span> <span data-ttu-id="7db5a-117">そのため、ユーザー インターフェイス要素をより簡単に追加できますが、XAML テンプレートを使うとパフォーマンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="7db5a-117">This can make adding user interface elements easier, but using the XAML template may result in lower performance.</span></span>

<span data-ttu-id="7db5a-118">どちらのテンプレートを使うかは、必要なパフォーマンスと利用するテクノロジによって異なります。</span><span class="sxs-lookup"><span data-stu-id="7db5a-118">Which template you choose depends on the performance and what technologies you want to use.</span></span>

## <a name="template-structure"></a><span data-ttu-id="7db5a-119">テンプレートの構造</span><span class="sxs-lookup"><span data-stu-id="7db5a-119">Template structure</span></span>


<span data-ttu-id="7db5a-120">DirectX ユニバーサル Windows テンプレートには、次のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7db5a-120">The DirectX Universal Windows templates contain the following files:</span></span>

-   <span data-ttu-id="7db5a-121">pch.h and pch.cpp - プリコンパイル済みヘッダーのサポートです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-121">pch.h and pch.cpp - Precompiled header support.</span></span>
-   <span data-ttu-id="7db5a-122">Package.appxmanifest - アプリの展開パッケージのプロパティです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-122">Package.appxmanifest - The properties of the deployment package for the app.</span></span>
-   <span data-ttu-id="7db5a-123">\*.pfx のアプリケーション用の証明書。</span><span class="sxs-lookup"><span data-stu-id="7db5a-123">\*.pfx - Certificates for the application.</span></span>
-   <span data-ttu-id="7db5a-124">外部の依存関係 - プロジェクトが使う外部ファイルへのリンクです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-124">External Dependencies - Links to external files the project use.s</span></span>
-   <span data-ttu-id="7db5a-125">\*Main.h と\*Main.cpp にアプリケーション資産を管理する、アプリケーションの状態を更新およびフレームのレンダリング方法。</span><span class="sxs-lookup"><span data-stu-id="7db5a-125">\*Main.h and \*Main.cpp - Methods for managing application assets, updating application state, and rendering the frame.</span></span>
-   <span data-ttu-id="7db5a-126">App.h と App.cpp - アプリのメイン エントリ ポイントです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-126">App.h and App.cpp - Main entry point for the application.</span></span> <span data-ttu-id="7db5a-127">アプリと Windows シェルを接続し、アプリケーション ライフサイクル イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-127">Connects the app with the Windows shell and handles application lifecycle events.</span></span> <span data-ttu-id="7db5a-128">これらのファイルは、DirectX 11 アプリ (ユニバーサル Windows) と DirectX 12 アプリ (ユニバーサル Windows) のテンプレートにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-128">These files only appear in the DirectX 11 App (Universal Windows) and DirectX 12 App (Universal Windows) templates.</span></span>
-   <span data-ttu-id="7db5a-129">App.xaml、App.xaml.cpp、App.xaml.h - アプリのメイン エントリ ポイントです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-129">App.xaml, App.xaml.cpp, and App.xaml.h - Main entry point for the application.</span></span> <span data-ttu-id="7db5a-130">アプリと Windows シェルを接続し、アプリケーション ライフサイクル イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-130">Connects the app with the Windows shell and handles application lifecycle events.</span></span> <span data-ttu-id="7db5a-131">これらのファイルは、DirectX 11 および XAML アプリ (ユニバーサル Windows) のテンプレートにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-131">These files only appear in the DirectX 11 and XAML App (Universal Windows) template.</span></span>
-   <span data-ttu-id="7db5a-132">DirectXPage.xaml、DirectXPage.xaml.cpp、DirectXPage.xaml.h - DirectX SwapChainPanel をホストするページ。</span><span class="sxs-lookup"><span data-stu-id="7db5a-132">DirectXPage.xaml, DirectXPage.xaml.cpp, and DirectXPage.xaml.h - A page that hosts a DirectX SwapChainPanel.</span></span> <span data-ttu-id="7db5a-133">これらのファイルは、DirectX 11 および XAML アプリ (ユニバーサル Windows) のテンプレートにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-133">These files only appear in the DirectX 11 and XAML App (Universal Windows) template.</span></span>
-   <span data-ttu-id="7db5a-134">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="7db5a-134">Content</span></span>
    -   <span data-ttu-id="7db5a-135">Sample3DSceneRenderer.h and Sample3DSceneRenderer.cpp - 基本的なレンダリング パイプラインをインスタンス化するサンプル レンダラーです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-135">Sample3DSceneRenderer.h and Sample3DSceneRenderer.cpp - A sample renderer that instantiates a basic rendering pipeline.</span></span>
    -   <span data-ttu-id="7db5a-136">SampleFpsTextRenderer.h and SampleFpsTextRenderer.cpp - Direct2D と DirectWrite を使って画面の右下隅に現在の FPS 値をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="7db5a-136">SampleFpsTextRenderer.h and SampleFpsTextRenderer.cpp - Renders the current FPS value in the bottom right corner of the screen using Direct2D and DirectWrite.</span></span> <span data-ttu-id="7db5a-137">これらのファイルは、DirectX 11 アプリ (ユニバーサル Windows) と DirectX 11 および XAML アプリ (ユニバーサル Windows) のテンプレートにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-137">These files only appear in the DirectX 11 App (Universal Windows) and DirectX 11 and XAML App (Universal Windows) templates.</span></span>
    -   <span data-ttu-id="7db5a-138">SamplePixelShader.hlsl - シンプルなサンプル ピクセル シェーダーです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-138">SamplePixelShader.hlsl - A simple example pixel shader.</span></span>
    -   <span data-ttu-id="7db5a-139">SampleVertexShader.hlsl - シンプルなサンプル頂点シェーダーです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-139">SampleVertexShader.hlsl - A simple example vertex shader.</span></span>
    -   <span data-ttu-id="7db5a-140">ShaderStructures.h - サンプル頂点シェーダーに日付を送信するために使われる構造体。</span><span class="sxs-lookup"><span data-stu-id="7db5a-140">ShaderStructures.h - Structures used to send date to the example vertex shader.</span></span>
-   <span data-ttu-id="7db5a-141">共通</span><span class="sxs-lookup"><span data-stu-id="7db5a-141">Common</span></span>
    -   <span data-ttu-id="7db5a-142">StepTimer.h - アニメーションとシミュレーションのタイミングを行うためのヘルパー クラスです。</span><span class="sxs-lookup"><span data-stu-id="7db5a-142">StepTimer.h - A helper class for animation and simulation timing.</span></span>
    -   <span data-ttu-id="7db5a-143">DirectXHelper.h - その他のヘルパー関数。</span><span class="sxs-lookup"><span data-stu-id="7db5a-143">DirectXHelper.h - Misc Helper functions.</span></span>
    -   <span data-ttu-id="7db5a-144">DeviceResources.h and Device Resources.cpp - 消失または作成されるデバイスについて通知する DeviceResources を所有するアプリケーションにインターフェイスを提供します。</span><span class="sxs-lookup"><span data-stu-id="7db5a-144">DeviceResources.h and Device Resources.cpp - Provides an interface for an application that owns DeviceResources to be notified of the device being lost or created.</span></span>
    -   <span data-ttu-id="7db5a-145">d3dx12.h - D3DX12 ユーティリティ ライブラリが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7db5a-145">d3dx12.h - Contains the D3DX12 utility library.</span></span> <span data-ttu-id="7db5a-146">このファイルは、DirectX 12 アプリ (ユニバーサル Windows) にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-146">This file only appears in the DirectX 12 App (Universal Windows).</span></span>
-   <span data-ttu-id="7db5a-147">アセット - アプリケーションが使うロゴとスプラッシュ画面の画像です。</span><span class="sxs-lookup"><span data-stu-id="7db5a-147">Assets - Logo and splashscreen images used by the application.</span></span>

## <a name="next-steps"></a><span data-ttu-id="7db5a-148">次のステップ</span><span class="sxs-lookup"><span data-stu-id="7db5a-148">Next steps</span></span>


<span data-ttu-id="7db5a-149">これで、出発点に立つことができました。次は、ゲーム開発の知識と Microsoft Store ゲームの開発スキルを学びます。</span><span class="sxs-lookup"><span data-stu-id="7db5a-149">Now that you have a starting point, add to it to build your game development knowledge and Microsoft Store game development skills.</span></span>

<span data-ttu-id="7db5a-150">既にあるゲームを移植する場合は、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7db5a-150">If you are porting an existing game, see the following topics.</span></span>

-   [<span data-ttu-id="7db5a-151">OpenGL ES 2.0 から Direct3D への移植 11.1</span><span class="sxs-lookup"><span data-stu-id="7db5a-151">Port from OpenGL ES 2.0 to Direct3D 11.1</span></span>](port-from-opengl-es-2-0-to-directx-11-1.md)
-   [<span data-ttu-id="7db5a-152">DirectX 9 からユニバーサル Windows プラットフォームへの移植</span><span class="sxs-lookup"><span data-stu-id="7db5a-152">Port from DirectX 9 to Universal Windows Platform</span></span>](porting-your-directx-9-game-to-windows-store.md)

<span data-ttu-id="7db5a-153">新しい DirectX ゲームを作成する場合は、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7db5a-153">If you are creating a new DirectX game, see the following topics.</span></span>

-   [<span data-ttu-id="7db5a-154">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="7db5a-154">Create a simple UWP game with DirectX</span></span>](tutorial--create-your-first-uwp-directx-game.md)
-   [<span data-ttu-id="7db5a-155">Marble Maze、C++ および DirectX でのユニバーサル Windows プラットフォーム ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="7db5a-155">Developing Marble Maze, a Universal Windows Platform game in C++ and DirectX</span></span>](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)