---
title: ゲーム サンプルの紹介
description: UWP DirectX ゲームの XAML オーバーレイを実装する方法について説明します。
keywords: DirectX, XAML
ms.date: 10/24/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7cb1c9f9cf6cbc6cce0c5d4547ed503bb9a06e56
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8941707"
---
# <a name="extend-the-game-sample"></a>ゲーム サンプルの紹介

基本的なユニバーサル Windows プラットフォーム (UWP) DirectX 3D ゲームの主なコンポーネントについて説明してきました。 ビュー プロバイダーやレンダリング パイプラインなどのゲームのフレームワークをセットアップして、基本的なゲーム ループを実装することができます。 また、基本的なユーザー インターフェイス オーバーレイの作成、サウンドの組み込み、コントロールの実装を行うこともできます。 これで独自のゲームを作成することができるはずですが、他のヘルプや情報が必要な場合は以下のリソースを参照してください。

-   [DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/library/windows/desktop/ee663274)
-   [Direct3D 11 の概要](https://msdn.microsoft.com/library/windows/desktop/ff476345)
-   [Direct3D 11 のリファレンス](https://msdn.microsoft.com/library/windows/desktop/ff476147)

## <a name="using-xaml-for-the-overlay"></a>オーバーレイに XAML を適用


ここで詳しく説明していない方法の 1 つとして、オーバーレイに対し [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) に代わり XAML を使う方法があります。 XAML には、Direct2D に比べ、ユーザー インターフェイス要素を描画するときの利点が数多くあります。 最も重要な利点は、windows 10 の見た目や操作感を便利な DirectX ゲームに組み込むことができます。 UWP アプリを定義する共通した要素、スタイル、動作の多くが XAML モデルに緊密に統合されるため、ゲーム開発者による実装作業がはるかに容易になります。 作成するゲームのデザインに複雑なユーザー インターフェイスが含まれる場合は、Direct2D の代わりに XAML の使用を検討してください。

XAML を使用して、以前に作成した Direct2D のゲーム インターフェイスに似たインターフェイスを作成できます。

### <a name="xaml"></a>XAML
![XAML オーバーレイ](./images/simple-dx-game-extend-xaml.PNG)

### <a name="direct2d"></a>Direct2D
![D2D オーバーレイ](./images/simple-dx-game-extend-d2d.PNG)

最終的な結果は類似していますが、Direct2D と XAML でのインターフェイスの実装には多くの相違点があります。

機能 | XAML| Direct2D
:----------|:----------- | :-----------
オーバーレイの定義 | XAML ファイル `\*.xaml` で定義されます。 XAML を理解すると、より複雑なオーバーレイの作成や構成は、Direct2D と比べて簡単になります。| Direct2D プリミティブの集合として定義され、[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) 文字列が手作業で配置され、Direct2D ターゲット バッファーに書き込まれます。 
ユーザー インターフェイス要素 | XAML ユーザー インターフェイス要素は、[**Windows::UI::Xaml**](https://msdn.microsoft.com/library/windows/apps/br209045) や [**Windows::UI::Xaml::Controls**](https://msdn.microsoft.com/library/windows/apps/br227716) を含め、Windows ランタイム XAML API の一部である標準化要素から採用されます。 XAML ユーザー インターフェイス要素の動作を処理するコードは、コード ビハインド ファイル、Main.xaml.cpp で定義されます。 | 四角形と楕円のような単純な図形を描画することができます。
ウィンドウのサイズ変更 | ハンドルのサイズ変更やビュー状態変更イベントが自然に処理され、これに伴いオーバーレイが変形されます。 | オーバーレイのコンポーネントを再描画する方法を手動で指定する必要があります。


もう 1 つの大きな違いは、[スワップ チェーン](https://docs.microsoft.com/windows/uwp/graphics-concepts/swap-chains)です。 スワップ チェーンを [**Windows::UI::Core::CoreWindow**](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) オブジェクトに結合する必要はありません。 代わりに、新しい [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel) オブジェクトの構築時に、XAML を統合する DirectX アプリによりスワップ チェーンが関連付けられます。 

次のスニペットは、[**DirectXPage.xaml**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml) ファイルで **SwapChainPanel** の XAML を宣言する方法を示しています。
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

**SwapChainPanel** オブジェクトは、アプリ シングルトンによる[起動時](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp#L45-L51)に作成された現在のウィンドウ オブジェクトの [**Content**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.Content) プロパティとして設定されます。

```cpp
void App::OnLaunched(_In_ LaunchActivatedEventArgs^ /* args */)
{
    m_mainPage = ref new DirectXPage();

    Window::Current->Content = m_mainPage;
    // Bring the application to the foreground so that it's visible
    Window::Current->Activate();
}
```


XAML で定義された [**SwapChainPanel**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel) パネル インスタンスに、設定済みのスワップ チェーンを結合するには、下層にある固有の [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/dn302143) インターフェイス実装に対するポインターを取得し、これに [**ISwapChainPanelNative::SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) を呼び出して、設定済みのスワップ チェーンを渡す必要があります。 

[**DX::DeviceResources::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/Common/DeviceResources.cpp#L218-L521) の次のスニペットは、DirectX/XAML の相互運用機能でこの処理を行う場合の詳細を示しています。

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

このプロセスについて詳しくは、[DirectX と XAML の相互運用機能](directx-and-xaml-interop.md)に関するトピックをご覧ください。

## <a name="sample"></a>サンプル

このゲームのオーバーレイに XAML を使ったバージョンをダウンロードするには、「[Direct3D シューティング ゲームのサンプル (XAML)](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameXaml)」を参照してください。


その他のトピックに示すゲーム サンプルのバージョンとは異なり、XAML のバージョンでは [App.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/App.cpp) と [GameInfoOverlay.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp) の代わりに、[App.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/App.xaml.cpp) と [DirectXPage.xaml.cpp](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/DirectXPage.xaml.cpp) の各ファイルでフレームワークを定義しています。