---
title: ゲーム サンプルの紹介
description: UWP DirectX ゲームの XAML オーバーレイを実装する方法について説明します。
keywords: DirectX, XAML
ms.date: 10/24/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7cb1c9f9cf6cbc6cce0c5d4547ed503bb9a06e56
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7696231"
---
# <a name="extend-the-game-sample"></a><span data-ttu-id="3ef2b-104">ゲーム サンプルの紹介</span><span class="sxs-lookup"><span data-stu-id="3ef2b-104">Extend the game sample</span></span>

<span data-ttu-id="3ef2b-105">基本的なユニバーサル Windows プラットフォーム (UWP) DirectX 3D ゲームの主なコンポーネントについて説明してきました。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-105">At this point we've covered the key components of a basic Universal Windows Platform (UWP) DirectX 3D game.</span></span> <span data-ttu-id="3ef2b-106">ビュー プロバイダーやレンダリング パイプラインなどのゲームのフレームワークをセットアップして、基本的なゲーム ループを実装することができます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-106">You can set up the framework for a game, including the view provider and rendering pipeline, and implement a basic game loop.</span></span> <span data-ttu-id="3ef2b-107">また、基本的なユーザー インターフェイス オーバーレイの作成、サウンドの組み込み、コントロールの実装を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-107">You can also create a basic user interface overlay, incorporate sounds, and implement controls.</span></span> <span data-ttu-id="3ef2b-108">これで独自のゲームを作成することができるはずですが、他のヘルプや情報が必要な場合は以下のリソースを参照してください。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-108">You're on your way to creating a game of your own, but if you need more help and info, check out these resources.</span></span>

-   [<span data-ttu-id="3ef2b-109">DirectX のグラフィックスとゲーミング</span><span class="sxs-lookup"><span data-stu-id="3ef2b-109">DirectX Graphics and Gaming</span></span>](https://msdn.microsoft.com/library/windows/desktop/ee663274)
-   [<span data-ttu-id="3ef2b-110">Direct3D 11 の概要</span><span class="sxs-lookup"><span data-stu-id="3ef2b-110">Direct3D 11 Overview</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476345)
-   [<span data-ttu-id="3ef2b-111">Direct3D 11 のリファレンス</span><span class="sxs-lookup"><span data-stu-id="3ef2b-111">Direct3D 11 Reference</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476147)

## <a name="using-xaml-for-the-overlay"></a><span data-ttu-id="3ef2b-112">オーバーレイに XAML を適用</span><span class="sxs-lookup"><span data-stu-id="3ef2b-112">Using XAML for the overlay</span></span>


<span data-ttu-id="3ef2b-113">ここで詳しく説明していない方法の 1 つとして、オーバーレイに対し [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) に代わり XAML を使う方法があります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-113">One alternative that we didn't discuss in depth is the use of XAML instead of [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) for the overlay.</span></span> <span data-ttu-id="3ef2b-114">XAML には、Direct2D に比べ、ユーザー インターフェイス要素を描画するときの利点が数多くあります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-114">XAML has many benefits over Direct2D for drawing user interface elements.</span></span> <span data-ttu-id="3ef2b-115">最も重要な利点は、windows 10 の外観を便利な DirectX ゲームに組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-115">The most important benefit is that it makes incorporating the Windows10 look and feel into your DirectX game more convenient.</span></span> <span data-ttu-id="3ef2b-116">UWP アプリを定義する共通した要素、スタイル、動作の多くが XAML モデルに緊密に統合されるため、ゲーム開発者による実装作業がはるかに容易になります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-116">Many of the common elements, styles, and behaviors that define a UWP app are tightly integrated into the XAML model, making it far less work for a game developer to implement.</span></span> <span data-ttu-id="3ef2b-117">作成するゲームのデザインに複雑なユーザー インターフェイスが含まれる場合は、Direct2D の代わりに XAML の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-117">If your own game design has a complicated user interface, consider using XAML instead of Direct2D.</span></span>

<span data-ttu-id="3ef2b-118">XAML を使用して、以前に作成した Direct2D のゲーム インターフェイスに似たインターフェイスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-118">With XAML, we can make a game interface that looks similar to the Direct2D one made earlier.</span></span>

### <a name="xaml"></a><span data-ttu-id="3ef2b-119">XAML</span><span class="sxs-lookup"><span data-stu-id="3ef2b-119">XAML</span></span>
![XAML オーバーレイ](./images/simple-dx-game-extend-xaml.PNG)

### <a name="direct2d"></a><span data-ttu-id="3ef2b-121">Direct2D</span><span class="sxs-lookup"><span data-stu-id="3ef2b-121">Direct2D</span></span>
![D2D オーバーレイ](./images/simple-dx-game-extend-d2d.PNG)

<span data-ttu-id="3ef2b-123">最終的な結果は類似していますが、Direct2D と XAML でのインターフェイスの実装には多くの相違点があります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-123">While they have similar end results, there are a number of differences between implementing Direct2D and XAML interfaces.</span></span>

<span data-ttu-id="3ef2b-124">機能</span><span class="sxs-lookup"><span data-stu-id="3ef2b-124">Feature</span></span> | <span data-ttu-id="3ef2b-125">XAML</span><span class="sxs-lookup"><span data-stu-id="3ef2b-125">XAML</span></span>| <span data-ttu-id="3ef2b-126">Direct2D</span><span class="sxs-lookup"><span data-stu-id="3ef2b-126">Direct2D</span></span>
:----------|:----------- | :-----------
<span data-ttu-id="3ef2b-127">オーバーレイの定義</span><span class="sxs-lookup"><span data-stu-id="3ef2b-127">Defining overlay</span></span> | <span data-ttu-id="3ef2b-128">XAML ファイル `\*.xaml` で定義されます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-128">Defined in a XAML file, `\*.xaml`.</span></span> <span data-ttu-id="3ef2b-129">XAML を理解すると、より複雑なオーバーレイの作成や構成は、Direct2D と比べて簡単になります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-129">Once understanding XAML, creating and configuring more complicated overlays are made simpiler when compared to Direct2D.</span></span>| <span data-ttu-id="3ef2b-130">Direct2D プリミティブの集合として定義され、[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) 文字列が手作業で配置され、Direct2D ターゲット バッファーに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-130">Defined as a collection of Direct2D primitives and [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) strings manually placed and written to a Direct2D target buffer.</span></span> 
<span data-ttu-id="3ef2b-131">ユーザー インターフェイス要素</span><span class="sxs-lookup"><span data-stu-id="3ef2b-131">User interface elements</span></span> | <span data-ttu-id="3ef2b-132">XAML ユーザー インターフェイス要素は、[**Windows::UI::Xaml**](https://msdn.microsoft.com/library/windows/apps/br209045) や [**Windows::UI::Xaml::Controls**](https://msdn.microsoft.com/library/windows/apps/br227716) を含め、Windows ランタイム XAML API の一部である標準化要素から採用されます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-132">XAML user interface elements come from standardized elements that are part of the Windows Runtime XAML APIs, including [**Windows::UI::Xaml**](https://msdn.microsoft.com/library/windows/apps/br209045) and [**Windows::UI::Xaml::Controls**](https://msdn.microsoft.com/library/windows/apps/br227716).</span></span> <span data-ttu-id="3ef2b-133">XAML ユーザー インターフェイス要素の動作を処理するコードは、コード ビハインド ファイル、Main.xaml.cpp で定義されます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-133">The code that handles the behavior of the XAML user interface elements is defined in a codebehind file, Main.xaml.cpp.</span></span> | <span data-ttu-id="3ef2b-134">四角形と楕円のような単純な図形を描画することができます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-134">Simple shapes can be drawn like rectangles and ellipses.</span></span>
<span data-ttu-id="3ef2b-135">ウィンドウのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="3ef2b-135">Window resizing</span></span> | <span data-ttu-id="3ef2b-136">ハンドルのサイズ変更やビュー状態変更イベントが自然に処理され、これに伴いオーバーレイが変形されます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-136">Naturally handles resize and view state change events, transforming the overlay accordingly</span></span> | <span data-ttu-id="3ef2b-137">オーバーレイのコンポーネントを再描画する方法を手動で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-137">Need to manually specify how to redraw the overlay's components.</span></span>


<span data-ttu-id="3ef2b-138">もう 1 つの大きな違いは、[スワップ チェーン](https://docs.microsoft.com/windows/uwp/graphics-concepts/swap-chains)です。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-138">Another big difference involves the [swap chain](https://docs.microsoft.com/windows/uwp/graphics-concepts/swap-chains).</span></span> <span data-ttu-id="3ef2b-139">スワップ チェーンを [**Windows::UI::Core::CoreWindow**](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) オブジェクトに結合する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-139">You don't have to attach the swap chain to a [**Windows::UI::Core::CoreWindow**](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) object.</span></span> <span data-ttu-id="3ef2b-140">代わりに、新しい [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel) オブジェクトの構築時に、XAML を統合する DirectX アプリによりスワップ チェーンが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-140">Instead, a DirectX app that incorporates XAML associates a swap chain when a new [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel) object is constructed.</span></span> 

<span data-ttu-id="3ef2b-141">次のスニペットは、[**DirectXPage.xaml**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml) ファイルで **SwapChainPanel** の XAML を宣言する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-141">The following snippet show how to declare XAML for the **SwapChainPanel** in the [**DirectXPage.xaml**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml) file.</span></span>
```xml
<Page
    x:Class="Simple3DGameXaml.DirectXPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:Simple3DGameXaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">


    <SwapChainPanel x:Name="DXSwapChainPanel">

    <!-- ... XAML user controls and elements -->

    </SwapChainPanel>
</Page>
```

<span data-ttu-id="3ef2b-142">**SwapChainPanel** オブジェクトは、アプリ シングルトンによる[起動時](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp#L45-L51)に作成された現在のウィンドウ オブジェクトの [**Content**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.Content) プロパティとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-142">The **SwapChainPanel** object is set as the [**Content**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.Content) property of the current window object created [at launch](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp#L45-L51) by the app singleton.</span></span>

```cpp
void App::OnLaunched(_In_ LaunchActivatedEventArgs^ /* args */)
{
    m_mainPage = ref new DirectXPage();

    Window::Current->Content = m_mainPage;
    // Bring the application to the foreground so that it's visible
    Window::Current->Activate();
}
```


<span data-ttu-id="3ef2b-143">XAML で定義された [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel) パネル インスタンスに、設定済みのスワップ チェーンを結合するには、下層にある固有の [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/dn302143) インターフェイス実装に対するポインターを取得し、これに [**ISwapChainPanelNative::SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) を呼び出して、設定済みのスワップ チェーンを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-143">To attach the configured swap chain to the [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel) instance defined by your XAML, you must obtain a pointer to the underlying native [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/dn302143) interface implementation and call [**ISwapChainPanelNative::SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) on it, passing it your configured swap chain.</span></span> 

<span data-ttu-id="3ef2b-144">[**DX::DeviceResources::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/Common/DeviceResources.cpp#L218-L521) の次のスニペットは、DirectX/XAML の相互運用機能でこの処理を行う場合の詳細を示しています。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-144">The following snippet from  [**DX::DeviceResources::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/Common/DeviceResources.cpp#L218-L521) details this for DirectX/XAML interop:</span></span>

```cpp
        ComPtr<IDXGIDevice3> dxgiDevice;
        DX::ThrowIfFailed(
            m_d3dDevice.As(&dxgiDevice)
            );

        ComPtr<IDXGIAdapter> dxgiAdapter;
        DX::ThrowIfFailed(
            dxgiDevice->GetAdapter(&dxgiAdapter)
            );

        ComPtr<IDXGIFactory2> dxgiFactory;
        DX::ThrowIfFailed(
            dxgiAdapter->GetParent(IID_PPV_ARGS(&dxgiFactory))
            );

        // When using XAML interop, the swap chain must be created for composition.
        DX::ThrowIfFailed(
            dxgiFactory->CreateSwapChainForComposition(
                m_d3dDevice.Get(),
                &swapChainDesc,
                nullptr,
                &m_swapChain
                )
            );

        // Associate swap chain with SwapChainPanel
        // UI changes will need to be dispatched back to the UI thread
        m_swapChainPanel->Dispatcher->RunAsync(CoreDispatcherPriority::High, ref new DispatchedHandler([=]()
        {
            // Get backing native interface for SwapChainPanel
            ComPtr<ISwapChainPanelNative> panelNative;
            DX::ThrowIfFailed(
                reinterpret_cast<IUnknown*>(m_swapChainPanel)->QueryInterface(IID_PPV_ARGS(&panelNative))
                );
            DX::ThrowIfFailed(
                panelNative->SetSwapChain(m_swapChain.Get())
                );
        }, CallbackContext::Any));

        // Ensure that DXGI does not queue more than one frame at a time. This both reduces latency and
        // ensures that the application will only render after each VSync, minimizing power consumption.
        DX::ThrowIfFailed(
            dxgiDevice->SetMaximumFrameLatency(1)
            );
    }
```

<span data-ttu-id="3ef2b-145">このプロセスについて詳しくは、[DirectX と XAML の相互運用機能](directx-and-xaml-interop.md)に関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-145">For more info about this process, see [DirectX and XAML interop](directx-and-xaml-interop.md).</span></span>

## <a name="sample"></a><span data-ttu-id="3ef2b-146">サンプル</span><span class="sxs-lookup"><span data-stu-id="3ef2b-146">Sample</span></span>

<span data-ttu-id="3ef2b-147">このゲームのオーバーレイに XAML を使ったバージョンをダウンロードするには、「[Direct3D シューティング ゲームのサンプル (XAML)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameXaml)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-147">To download the version of this game that uses XAML for the overlay, go to the [Direct3D shooting game sample (XAML)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameXaml).</span></span>


<span data-ttu-id="3ef2b-148">その他のトピックに示すゲーム サンプルのバージョンとは異なり、XAML のバージョンでは [App.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/App.cpp) と [GameInfoOverlay.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp) の代わりに、[App.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp) と [DirectXPage.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml.cpp) の各ファイルでフレームワークを定義しています。</span><span class="sxs-lookup"><span data-stu-id="3ef2b-148">Unlike the version of the game sample discussed in the rest of these topics, the XAML version defines its framework in the [App.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp) and [DirectXPage.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml.cpp) files, instead of [App.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/App.cpp) and [GameInfoOverlay.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp), respectively.</span></span>