---
title: ゲーム ループの移植
description: IFrameworkView を作成して、全画面表示の CoreWindow を制御する方法など、ユニバーサル Windows プラットフォーム (UWP) ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。
ms.assetid: 070dd802-cb27-4672-12ba-a7f036ff495c
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, ゲーム ループ, Direct3D 9, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 8b0cf6352d400371b54a54d71176c4d8e1dc457d
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7707616"
---
# <a name="port-the-game-loop"></a><span data-ttu-id="c21ab-104">ゲーム ループの移植</span><span class="sxs-lookup"><span data-stu-id="c21ab-104">Port the game loop</span></span>



**<span data-ttu-id="c21ab-105">概要</span><span class="sxs-lookup"><span data-stu-id="c21ab-105">Summary</span></span>**

-   [<span data-ttu-id="c21ab-106">パート 1: Direct3D 11 の初期化</span><span class="sxs-lookup"><span data-stu-id="c21ab-106">Part 1: Initialize Direct3D 11</span></span>](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   [<span data-ttu-id="c21ab-107">パート 2: レンダリング フレームワークの変換</span><span class="sxs-lookup"><span data-stu-id="c21ab-107">Part 2: Convert the rendering framework</span></span>](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)
-   <span data-ttu-id="c21ab-108">パート 3: ゲーム ループの移植</span><span class="sxs-lookup"><span data-stu-id="c21ab-108">Part 3: Port the game loop</span></span>


<span data-ttu-id="c21ab-109">[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を作成して、全画面表示の [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を制御する方法など、ユニバーサル Windows プラットフォーム (UWP) ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c21ab-109">Shows how to implement a window for a Universal Windows Platform (UWP) game and how to bring over the game loop, including how to build an [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) to control a full-screen [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="c21ab-110">「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="c21ab-110">Part 3 of the [Port a simple Direct3D 9 app to DirectX 11 and UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md) walkthrough.</span></span>

## <a name="create-a-window"></a><span data-ttu-id="c21ab-111">ウィンドウの作成</span><span class="sxs-lookup"><span data-stu-id="c21ab-111">Create a window</span></span>


<span data-ttu-id="c21ab-112">Direct3D 9 のビューポートを使ってデスクトップ ウィンドウを設定するためには、デスクトップ アプリ用の従来のウィンドウ フレームワークを実装する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="c21ab-112">To set up a desktop window with a Direct3D 9 viewport, we had to implement the traditional windowing framework for desktop apps.</span></span> <span data-ttu-id="c21ab-113">また、HWND の作成、ウィンドウ サイズの設定、ウィンドウ処理コールバックの提供、ウィンドウの表示などを実行する必要もありました。</span><span class="sxs-lookup"><span data-stu-id="c21ab-113">We had to create an HWND, set the window size, provide a window processing callback, make it visible, and so on.</span></span>

<span data-ttu-id="c21ab-114">UWP 環境には、はるかに簡単なシステムが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c21ab-114">The UWP environment has a much simpler system.</span></span> <span data-ttu-id="c21ab-115">DirectX を使った Microsoft Store ゲームでは、従来のウィンドウを設定する代わりに、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を実装します。</span><span class="sxs-lookup"><span data-stu-id="c21ab-115">Instead of setting up a traditional window, a Microsoft Store game using DirectX implements [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478).</span></span> <span data-ttu-id="c21ab-116">このインターフェイスは、アプリ コンテナー内の [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) で直接 DirectX アプリやゲームを実行するために存在します。</span><span class="sxs-lookup"><span data-stu-id="c21ab-116">This interface exists for DirectX apps and games to run directly in a [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) inside the app container.</span></span>

> <span data-ttu-id="c21ab-117">**注:**  Windows は、ソース アプリケーション オブジェクトや[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)などのリソースへの管理ポインターを提供します。</span><span class="sxs-lookup"><span data-stu-id="c21ab-117">**Note** Windows supplies managed pointers to resources such as the source application object and the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="c21ab-118">[**オブジェクト演算子 (^) へのハンドル**を] を参照してください。https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspxします。</span><span class="sxs-lookup"><span data-stu-id="c21ab-118">See [**Handle to Object Operator (^)**]https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspx.</span></span>

 

<span data-ttu-id="c21ab-119">"main" クラスには、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) から継承し、5 つの **IFrameworkView** メソッド ([**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495)、[**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509)、[**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)、[**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505)、[**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523)) を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c21ab-119">Your "main" class needs to inherit from [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) and implement the five **IFrameworkView** methods: [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495), [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509), [**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501), [**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505), and [**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523).</span></span> <span data-ttu-id="c21ab-120">(実質的に) ゲームが存在する場所となる **IFrameworkView** の作成に加えて、**IFrameworkView** のインスタンスを作成するファクトリ クラスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c21ab-120">In addition to creating the **IFrameworkView**, which is (essentially) where your game will reside, you need to implement a factory class that creates an instance of your **IFrameworkView**.</span></span> <span data-ttu-id="c21ab-121">ゲームにはこれまでどおり **main()** と呼ばれるメソッドを含む実行可能ファイルが存在しますが、main で実行できる操作は、ファクトリを使って、**IFrameworkView** のインスタンスを作成することだけです。</span><span class="sxs-lookup"><span data-stu-id="c21ab-121">Your game still has an executable with a method called **main()**, but all main can do is use the factory to create the **IFrameworkView** instance.</span></span>

<span data-ttu-id="c21ab-122">main 関数</span><span class="sxs-lookup"><span data-stu-id="c21ab-122">Main function</span></span>

```cpp
//-----------------------------------------------------------------------------
// Required method for a DirectX-only app.
// The main function is only used to initialize the app's IFrameworkView class.
//-----------------------------------------------------------------------------
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

<span data-ttu-id="c21ab-123">IFrameworkView ファクトリ</span><span class="sxs-lookup"><span data-stu-id="c21ab-123">IFrameworkView factory</span></span>

```cpp
//-----------------------------------------------------------------------------
// This class creates our IFrameworkView.
//-----------------------------------------------------------------------------
ref class Direct3DApplicationSource sealed : 
    Windows::ApplicationModel::Core::IFrameworkViewSource
{
public:
    virtual Windows::ApplicationModel::Core::IFrameworkView^ CreateView()
    {
        return ref new Cube11();
    };
};
```

## <a name="port-the-game-loop"></a><span data-ttu-id="c21ab-124">ゲーム ループの移植</span><span class="sxs-lookup"><span data-stu-id="c21ab-124">Port the game loop</span></span>


<span data-ttu-id="c21ab-125">次に、Direct3D 9 の実装のゲーム ループを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c21ab-125">Let's look at the game loop from our Direct3D 9 implementation.</span></span> <span data-ttu-id="c21ab-126">このコードは、アプリの main 関数内に存在します。</span><span class="sxs-lookup"><span data-stu-id="c21ab-126">This code exists in the app's main function.</span></span> <span data-ttu-id="c21ab-127">このループの各反復では、ウィンドウ メッセージを処理するか、フレームをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="c21ab-127">Each iteration of this loop processes a window message or renders a frame.</span></span>

<span data-ttu-id="c21ab-128">Direct3D 9 デスクトップ ゲームのゲーム ループ</span><span class="sxs-lookup"><span data-stu-id="c21ab-128">Game loop in Direct3D 9 desktop game</span></span>

```cpp
while(WM_QUIT != msg.message)
{
    // Process window events.
    // Use PeekMessage() so we can use idle time to render the scene. 
    bGotMsg = (PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE) != 0);

    if(bGotMsg)
    {
        // Translate and dispatch the message
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    else
    {
        // Render a new frame.
        // Render frames during idle time (when no messages are waiting).
        RenderFrame();
    }
}
```

<span data-ttu-id="c21ab-129">このゲーム ループは、UWP バージョンのゲームと似ていますが、それよりも簡単です。</span><span class="sxs-lookup"><span data-stu-id="c21ab-129">The game loop is similar - but easier - in the UWP version of our game:</span></span>

<span data-ttu-id="c21ab-130">このゲームは [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) クラス内で機能するため、ゲーム ループは (**main()** ではなく) [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="c21ab-130">The game loop goes in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method (instead of **main()**) because our game functions within the [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) class.</span></span>

<span data-ttu-id="c21ab-131">メッセージ処理フレームワークを実装し、[**PeekMessage**](https://msdn.microsoft.com/library/windows/desktop/ms644943) を呼び出す代わりに、アプリ ウィンドウの [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) に組み込まれている [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) メソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c21ab-131">Instead of implementing a message handling framework and calling [**PeekMessage**](https://msdn.microsoft.com/library/windows/desktop/ms644943), we can call the [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) method built in to our app window's [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211).</span></span> <span data-ttu-id="c21ab-132">ゲーム ループで分岐し、メッセージを処理する必要はありません。**ProcessEvents** を呼び出し、次に進むだけです。</span><span class="sxs-lookup"><span data-stu-id="c21ab-132">There's no need for the game loop to branch and handle messages - just call **ProcessEvents** and proceed.</span></span>

<span data-ttu-id="c21ab-133">Direct3D 11 Microsoft Store ゲームのゲーム ループ</span><span class="sxs-lookup"><span data-stu-id="c21ab-133">Game loop in Direct3D 11 Microsoft Store game</span></span>

```cpp
// UWP apps should not exit. Use app lifecycle events instead.
while (true)
{
    // Process window events.
    auto dispatcher = CoreWindow::GetForCurrentThread()->Dispatcher;
    dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

    // Render a new frame.
    RenderFrame();
}
```

<span data-ttu-id="c21ab-134">これで、DirectX 9 の例と同じように、基本的なグラフィックス インフラストラクチャをセットアップし、同じカラフルな立方体をレンダリングする UWP アプリが完成しました。</span><span class="sxs-lookup"><span data-stu-id="c21ab-134">Now we have a UWP app that sets up the same basic graphics infrastructure, and renders the same colorful cube, as our DirectX 9 example.</span></span>

## <a name="where-do-i-go-from-here"></a><span data-ttu-id="c21ab-135">次の段階</span><span class="sxs-lookup"><span data-stu-id="c21ab-135">Where do I go from here?</span></span>


<span data-ttu-id="c21ab-136">「[DirectX 11 の移植に関する FAQ](directx-porting-faq.md)」をブックマークに追加してください。</span><span class="sxs-lookup"><span data-stu-id="c21ab-136">Bookmark the [DirectX 11 porting FAQ](directx-porting-faq.md).</span></span>

<span data-ttu-id="c21ab-137">DirectX UWP テンプレートには、ゲームですぐに使うことができる堅牢な Direct3D デバイス インフラストラクチャが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c21ab-137">The DirectX UWP templates include a robust Direct3D device infrastructure that's ready for use with your game.</span></span> <span data-ttu-id="c21ab-138">適切なテンプレートを選ぶためのガイダンスについては、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c21ab-138">See [Create a DirectX game project from a template](user-interface.md) for guidance on picking the right template.</span></span>

<span data-ttu-id="c21ab-139">Microsoft Store ゲームの開発に関する次の詳しい記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c21ab-139">Visit the following in-depth Microsoft Store game game development articles:</span></span>

-   [<span data-ttu-id="c21ab-140">チュートリアル: DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="c21ab-140">Walkthrough: a simple UWP game with DirectX</span></span>](tutorial--create-your-first-uwp-directx-game.md)
-   [<span data-ttu-id="c21ab-141">ゲームのオーディオ</span><span class="sxs-lookup"><span data-stu-id="c21ab-141">Audio for games</span></span>](working-with-audio-in-your-directx-game.md)
-   [<span data-ttu-id="c21ab-142">ゲームのムーブ/ルック コントロール</span><span class="sxs-lookup"><span data-stu-id="c21ab-142">Move-look controls for games</span></span>](tutorial--adding-move-look-controls-to-your-directx-game.md)

 

 




