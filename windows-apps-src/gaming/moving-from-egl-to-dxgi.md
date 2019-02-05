---
title: EGL コードと DXGI および Direct3D の比較
description: DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。 このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。
ms.assetid: 90f5ecf1-dd5d-fea3-bed8-57a228898d2a
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, EGL, DXGI, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: 19c857ae5274be70d19a14d5bbf47adb595b5676
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9049699"
---
# <a name="compare-egl-code-to-dxgi-and-direct3d"></a>EGL コードと DXGI および Direct3D の比較




**重要な API**

-   [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575)
-   [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)
-   [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)

DirectX Graphics Interface (DXGI) といくつかの Direct3D API は EGL と同じ役割を果たします。 このトピックは EGL の観点から DXGI と Direct3D 11 を理解するのに役立ちます。

DXGI と Direct3D は EGL に似ており、グラフィックス リソースを構成するためのメソッドや、シェーダーの描画先となり、ウィンドウに結果を表示するために使われるレンダリング コンテキストを取得するためのメソッドがあります。 ただし、DXGI と Direct3D にはかなりのオプションがあるため、EGL からの移植の際には、適切に設定するための余分な作業が必要です。

> **注:** このガイダンスは、Khronos Group の EGL 1.4 のオープンな仕様に基づく: [Khronos Native Platform Graphics Interface (EGL Version 1.4 - April 6, 2011年) \[PDF\]](https://www.khronos.org/registry/egl/specs/eglspec.1.4.20110406.pdf)します。 その他のプラットフォームと開発言語に固有の構文の違いは、このガイダンスでは説明していません。

 

## <a name="how-does-dxgi-and-direct3d-compare"></a>DXGI と Direct3D の比較方法


DXGI および Direct3D と比較したときの EGL の大きなメリットは、比較的簡単にウィンドウ サーフェスへの描画を開始できることです。 これは、OpenGL ES 2.0 と EGL が複数のプラットフォーム プロバイダーによって実装された仕様であるのに対し、DXGI と Direct3D はハードウェア ベンダーのドライバーが準拠する必要のある単一のリファレンスであるためです。 つまり、Microsoft がやるべきことは、特定のベンダーが提供する機能のサブセットに注力したり、ベンダー固有のセットアップ コマンドをよりシンプルな API に結合することで得られた機能のサブセットに注力したりすることではなく、可能な限り幅広いベンダー機能をサポートする API のセットを実装することです。 一方、Direct3D は、非常に幅広いグラフィックス ハードウェア プラットフォームと機能レベルに対応し、プラットフォームで経験を積んだ開発者向けの柔軟性を提供する API の単一のセットを提供します。

EGL と同様に、DXGI と Direct3D には次の動作のための API が用意されています。

-   フレーム バッファーを取得し、その読み書きを行う (DXGI では "スワップ チェーン")。
-   フレーム バッファーを UI ウィンドウに関連付ける。
-   描画の場所となるレンダリング コンテキストを取得、構成する。
-   特定のレンダリング コンテキストのグラフィックス パイプラインにコマンドを発行する。
-   シェーダー リソースを作成して管理し、レンダリング コンテキストに関連付ける。
-   特定のレンダー ターゲットにレンダリングする (テクスチャなど)。
-   グラフィックス リソースを使ったレンダリングの結果でウィンドウの表示サーフェスを更新する。

グラフィックス パイプラインを構成するための基本的な Direct3D プロセスを確認するには、DirectX 11 アプリ (ユニバーサル Windows) テンプレートは、Microsoft Visual Studio2015 してください。 その基本レンダリング クラスは、Direct3D 11 のグラフィックス インフラストラクチャを設定し、それに基づいて基本的なリソースを構成したり、画面の回転などのユニバーサル Windows プラットフォーム (UWP) アプリの機能をサポートしたりするうえで、適切なベースラインとなります。

EGL は Direct3D 11 と比べて API が非常に少なくなっています。プラットフォームに特定の命名規則や専門用語に慣れていないと、Direct3D 11 の理解は難しい場合があります。 ここでは、初心者の役に立つ簡単な概要を示します。

まず、基本的な EGL オブジェクトと Direct3D インターフェイスのマッピングを確かめます。

| EGL のアブストラクション | Direct3D での同様の表現                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **EGLDisplay**  | UWP アプリ向けの Direct3D では、表示ハンドルは [**Windows::UI::CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) API (または HWND を公開する **ICoreWindowInterop** インターフェイス) を通じて取得されます。 アダプターとハードウェア構成は、それぞれ [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) COM インターフェイスと [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/hh404543) COM インターフェイスを使って設定されます。                                                                                                                                                                                                                                                           |
| **EGLSurface**  | Direct3D では、[**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) ([**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (表示バッファー) などの DXGI リソースを取得するために使われるファクトリ パターンの実装) を含め、特定の DXGI インターフェイスでバッファーなどのウィンドウ リソース (表示またはオフ スクリーン) を作成し、構成します。 グラフィックス デバイスとそのリソースを表す [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) は、[**D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) で取得されます。 レンダー ターゲットには、[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) インターフェイスを使います。 |
| **EGLContext**  | Direct3D では、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) インターフェイスでコマンドを構成し、グラフィックス パイプラインに発行します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **EGLConfig**   | Direct3D 11 では、バッファー、テクスチャ、ステンシル、シェーダーなどのグラフィックス リソースを、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インターフェイスのメソッドで作成、構成します。                                                                                                                                                                                                                                                                                                                                                                                                                                                      |

 

ここで、UWP アプリ用の DXGI と Direct3D でシンプルなグラフィックスの表示、リソース、コンテキストを設定するための最も基本的なプロセスを示します。

1.  [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出してアプリの中心的な UI スレッドの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトへのハンドルを取得します。
2.  UWP アプリの場合、[**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) で [**IDXGIAdapter2**](https://msdn.microsoft.com/library/windows/desktop/hh404537) からスワップ チェーンを取得し、手順 1. で取得した [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の参照をそれに渡します。 [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) インスタンスが返されます。 そのスコープをレンダラー オブジェクトとそのレンダリング スレッドに設定します。
3.  [**D3D11Device::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) メソッドを呼び出して [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) のインスタンスを取得します。 そのスコープもレンダラー オブジェクトにします。
4.  レンダラーの [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトのメソッドを使ってシェーダーやテクスチャなどのリソースを作成します。
5.  バッファーを定義し、シェーダーを実行して、パイプライン ステージを管理します。それには、レンダラーの [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクトのメソッドを使います。
6.  パイプラインが実行され、フレームがバック バッファーに描画されたら、[**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) でそれを画面に表示します。

このプロセスについて詳しく調べるには、「[DirectX グラフィックスの概要](https://msdn.microsoft.com/library/windows/desktop/hh309467)」をご覧ください。 この記事の残りの部分では、基本的なグラフィックス パイプラインの設定と管理に関する一般的な手順の多くについて説明します。
> **注:**  Windows デスクトップ アプリが[**D3D11Device::CreateDeviceAndSwapChain**](https://msdn.microsoft.com/library/windows/desktop/ff476083)などの Direct3D スワップ チェーンを取得するためさまざまな Api があるし、 [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)オブジェクトを使わないでください。

 

## <a name="obtaining-a-window-for-display"></a>表示のためのウィンドウの取得


この例では、Microsoft Windows プラットフォームに固有のウィンドウ リソース用の HWND が eglGetDisplay に渡されます。 Apple の iOS (Cocoa) や Google の Android などの他のプラットフォームには、ウィンドウ リソースへの別のハンドルや参照があり、別の呼び出し構文が存在することもあります。 表示を取得した後で初期化し、優先する構成を設定して、描画先のバック バッファーを持つサーフェスを作成します。

EGL を使った表示の取得と構成

``` syntax
// Obtain an EGL display object.
EGLDisplay display = eglGetDisplay(GetDC(hWnd));
if (display == EGL_NO_DISPLAY)
{
  return EGL_FALSE;
}

// Initialize the display
if (!eglInitialize(display, &majorVersion, &minorVersion))
{
  return EGL_FALSE;
}

// Obtain the display configs
if (!eglGetConfigs(display, NULL, 0, &numConfigs))
{
  return EGL_FALSE;
}

// Choose the display config
if (!eglChooseConfig(display, attribList, &config, 1, &numConfigs))
{
  return EGL_FALSE;
}

// Create a surface
surface = eglCreateWindowSurface(display, config, (EGLNativeWindowType)hWnd, NULL);
if (surface == EGL_NO_SURFACE)
{
  return EGL_FALSE;
}
```

Direct3D では、UWP アプリのメイン ウィンドウは [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトで表されます。このオブジェクトは、Direct3D 向けに構築した "ビュー プロバイダー" の初期化プロセスの一環として [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出すことでアプリ オブジェクトから取得できます  (Direct3D と XAML の相互運用機能を使っている場合は、XAML フレームワークのビュー プロバイダーを使います)。Direct3D ビュー プロバイダーの作成プロセスについては、「[DirectX Windows ストア アプリでビューを表示するための設定方法](https://msdn.microsoft.com/library/windows/apps/hh465077)」で説明します。

Direct3D の CoreWindow の取得

``` syntax
CoreWindow::GetForCurrentThread();
```

[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の参照を取得したら、ウィンドウをアクティブ化する必要があります。それにより、メイン オブジェクトの **Run** メソッドが実行され、ウィンドウ イベントの処理が開始されます。 その後、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) を作成し、それらを使って基になる [**IDXGIDevice1**](https://msdn.microsoft.com/library/windows/desktop/ff471331) と [**IDXGIAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174523) を取得します。その結果、[**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556) オブジェクトを取得して、[**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) の構成に基づいてスワップ チェーンのリソースを作成できます。

Direct3D の CoreWindow での DXGI スワップ チェーンの構成と設定

``` syntax
// Called when the CoreWindow object is created (or re-created).
void SimpleDirect3DApp::SetWindow(CoreWindow^ window)
{
  // Register event handlers with the CoreWindow object.
  // ...

  // Obtain your ID3D11Device1 and ID3D11DeviceContext1 objects
  // In this example, m_d3dDevice contains the scoped ID3D11Device1 object
  // ...

  ComPtr<IDXGIDevice1>  dxgiDevice;
  // Get the underlying DXGI device of the Direct3D device.
  m_d3dDevice.As(&dxgiDevice);

  ComPtr<IDXGIAdapter> dxgiAdapter;
  dxgiDevice->GetAdapter(&dxgiAdapter);

  ComPtr<IDXGIFactory2> dxgiFactory;
  dxgiAdapter->GetParent(
    __uuidof(IDXGIFactory2), 
    &dxgiFactory);

  DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};
  swapChainDesc.Width = static_cast<UINT>(m_d3dRenderTargetSize.Width); // Match the size of the window.
  swapChainDesc.Height = static_cast<UINT>(m_d3dRenderTargetSize.Height);
  swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM; // This is the most common swap chain format.
  swapChainDesc.Stereo = false;
  swapChainDesc.SampleDesc.Count = 1; // Don't use multi-sampling.
  swapChainDesc.SampleDesc.Quality = 0;
  swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
  swapChainDesc.BufferCount = 2; // Use double-buffering to minimize latency.
  swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // All UWP apps must use this SwapEffect.
  swapChainDesc.Flags = 0;

  // ...

  Windows::UI::Core::CoreWindow^ window = m_window.Get();
  dxgiFactory->CreateSwapChainForCoreWindow(
    m_d3dDevice.Get(),
    reinterpret_cast<IUnknown*>(window),
    &swapChainDesc,
    nullptr, // Allow on all displays.
    &m_swapChainCoreWindow);
}
```

フレームを表示する準備をした後で [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) メソッドを呼び出します。

Direct3D 11 には、EGLSurface と同じアブストラクションがないことに注意してください  ([**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343) はありますが、使い方が異なります)。概念的に最も近いのは、シェーダー パイプラインの描画先のバック バッファーとしてテクスチャ ([**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)) を割り当てるための [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) オブジェクトです。

Direct3D 11 でのスワップ チェーンのバック バッファーの設定

``` syntax
ComPtr<ID3D11RenderTargetView>    m_d3dRenderTargetViewWin; // scoped to renderer object

// ...

ComPtr<ID3D11Texture2D> backBuffer2;
    
m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(&backBuffer2));

m_d3dDevice->CreateRenderTargetView(
  backBuffer2.Get(),
  nullptr,
    &m_d3dRenderTargetViewWin);
```

ウィンドウが作成されたときや、ウィンドウのサイズが変更されたときに、その都度以下のコードを呼び出すことをお勧めします。 レンダリング中には、頂点バッファーやシェーダーなどの他のサブリソースを設定する前に、[**ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) でレンダー ターゲット ビューを設定します。

``` syntax
// Set the render target for the draw operation.
m_d3dContext->OMSetRenderTargets(
        1,
        d3dRenderTargetView.GetAddressOf(),
        nullptr);
```

## <a name="creating-a-rendering-context"></a>レンダリング コンテキストの作成


EGL 1.4 では、"表示" は、ウィンドウ リソースのセットを表します。 通常は、表示のための "サーフェス" を構成するために、表示オブジェクトに一連の属性を提供し、サーフェスを取得します。 サーフェスのコンテンツを表示するためのコンテキストを作成するには、そのコンテキストを作成したうえで、サーフェスと表示にバインドします。

呼び出しのフローは通常、次のようになります。

-   表示 (ウィンドウ リソース) へのハンドルを使って eglGetDisplay を呼び出し、表示オブジェクトを取得します。
-   eglInitialize で表示を初期化します。
-   使用できる表示の構成を取得し、eglGetConfigs と eglChooseConfig でそのいずれかを選びます。
-   eglCreateWindowSurface でウィンドウ サーフェスを作成します。
-   eglCreateContext で描画用の表示コンテキストを作成します。
-   eglMakeCurrent で表示とサーフェスに表示コンテキストをバインドします。

前のセクションでは EGLDisplay と EGLSurface を作成しました。次に、EGLDisplay を使ってコンテキストを作成し、そのコンテキストを表示に関連付けます。それには、構成済みの EGLSurface を使って出力をパラメーター化します。

EGL 1.4 でのレンダリング コンテキストの取得

```cpp
// Configure your EGLDisplay and obtain an EGLSurface here ...
// ...

// Create a drawing context from the EGLDisplay
context = eglCreateContext(display, config, EGL_NO_CONTEXT, contextAttribs);
if (context == EGL_NO_CONTEXT)
{
  return EGL_FALSE;
}   
   
// Make the context current
if (!eglMakeCurrent(display, surface, surface, context))
{
  return EGL_FALSE;
}
```

Direct3D 11 のレンダリング コンテキストは、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトで表されます。これはアダプターを表し、バッファーやシェーダーなどの Direct3D リソースを作成するために利用できます。Direct3D 11 のレンダリング コンテキストは [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクトでも表され、これを使うと、グラフィックス パイプラインを管理し、シェーダーを実行できます。

Direct3D の機能レベルに注意してください。 これらは、DirectX 9.1 から DirectX 11 までの Direct3D ハードウェア プラットフォームをサポートするために使われます。 タブレットなど、低電力のグラフィックス ハードウェアを使う多くのプラットフォームは、DirectX 9.1 の機能にしかアクセスできません。サポートされている古いグラフィックス ハードウェアは、9.1 ～ 11 です。

DXGI と Direct3D でのレンダリング コンテキストの作成

```cpp

// ... 

UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;
ComPtr<IDXGIDevice> dxgiDevice;

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
ComPtr<ID3D11DeviceContext> d3dContext;

D3D11CreateDevice(
  nullptr, // Specify nullptr to use the default adapter.
  D3D_DRIVER_TYPE_HARDWARE,
  nullptr,
  creationFlags, // Set set debug and Direct2D compatibility flags.
  featureLevels, // List of feature levels this app can support.
  ARRAYSIZE(featureLevels),
  D3D11_SDK_VERSION, // Always set this to D3D11_SDK_VERSION for UWP apps.
  &device, // Returns the Direct3D device created.
  &m_featureLevel, // Returns feature level of device created.
  &d3dContext // Returns the device immediate context.
);
```

## <a name="drawing-into-a-texture-or-pixmap-resource"></a>テクスチャまたは pixmap リソースへの描画


OpenGL ES 2.0 でテクスチャに描画するには、ピクセル バッファー (PBuffer) を構成します。 それに対して EGLSurface を正常に構成して作成したら、それにレンダリング コンテキストを提供し、シェーダー パイプラインを実行してテクスチャに描画できます。

OpenGL ES 2.0 でのピクセル バッファーへの描画

``` syntax
// Create a pixel buffer surface to draw into
EGLConfig pBufConfig;
EGLint totalpBufAttrs;

const EGLint pBufConfigAttrs[] =
{
    // Configure the pBuffer here...
};
 
eglChooseConfig(eglDsplay, pBufConfigAttrs, &pBufConfig, 1, &totalpBufAttrs);
EGLSurface pBuffer = eglCreatePbufferSurface(eglDisplay, pBufConfig, EGL_TEXTURE_RGBA); 
```

Direct3D 11 では、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) リソースを作成してそれをレンダー ターゲットにします。 レンダー ターゲットの構成には [**D3D11\_RENDER\_TARGET\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476201) を使います。 このレンダー ターゲットを使って [**ID3D11DeviceContext::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407) メソッド (またはデバイス コンテキストに対する同様の Draw\* 操作) を呼び出すと、結果がテクスチャに描画されます。

Direct3D 11 でのテクスチャへの描画

``` syntax
ComPtr<ID3D11Texture2D> renderTarget1;

D3D11_RENDER_TARGET_VIEW_DESC renderTargetDesc = {0};
// Configure renderTargetDesc here ...

m_d3dDevice->CreateRenderTargetView(
  renderTarget1.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);

// Later, in your render loop...

// Set the render target for the draw operation.
m_d3dContext->OMSetRenderTargets(
        1,
        d3dRenderTargetView.GetAddressOf(),
        nullptr);
```

このテクスチャは、[**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628) に関連付けられている場合はシェーダーに渡すことができます。

## <a name="drawing-to-the-screen"></a>画面への描画


EGLContext を使ってバッファーの構成とデータの更新を行ったら、それにバインドされているシェーダーを実行し、glDrawElements でバック バッファーに結果を描画します。 eglSwapBuffers を呼び出してバック バッファーを表示します。

Open GL ES 2.0: 画面への描画

``` syntax
glDrawElements(GL_TRIANGLES, renderer->numIndices, GL_UNSIGNED_INT, 0);

eglSwapBuffers(drawContext->eglDisplay, drawContext->eglSurface);
```

Direct3D 11 では、[**IDXGISwapChain::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) でバッファーを構成してシェーダーにバインドします。 次に、いずれかの [**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)\* メソッドを呼び出してシェーダーを実行し、スワップ チェーンのバック バッファーとして構成されたレンダー ターゲットに結果を描画します。 その後、単純に **IDXGISwapChain::Present1** を呼び出してバック バッファーをディスプレイに表示します。

Direct3D 11: 画面への描画

``` syntax

m_d3dContext->DrawIndexed(
        m_indexCount,
        0,
        0);

// ...

m_swapChainCoreWindow->Present1(1, 0, &parameters);
```

## <a name="releasing-graphics-resources"></a>グラフィックス リソースの解放


EGL では、eglTerminate に EGLDisplay を渡して、ウィンドウ リソースを解放します。

EGL 1.4 での表示の終了

```cpp
EGLBoolean eglTerminate(eglDisplay);
```

UWP アプリでは、[**CoreWindow::Close**](https://msdn.microsoft.com/library/windows/apps/br208260) で CoreWindow を閉じることができますが、これはセカンダリ UI ウィンドウに対してのみ使うことができます。 プライマリ UI スレッドとその関連の CoreWindow は閉じることはできません。オペレーティング システムによって有効期限切れの処理が行われます。 ただし、セカンダリ CoreWindow が閉じると、[**CoreWindow::Closed**](https://msdn.microsoft.com/library/windows/apps/br208261) イベントが発生します。

## <a name="api-reference-mapping-for-egl-to-direct3d-11"></a>EGL と Direct3D 11 のマッピングを示す API リファレンス


| EGL API                          | 同様の Direct3D 11 API または動作                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|----------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| eglBindAPI                       | なし。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| eglBindTexImage                  | [**ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) を呼び出して 2D テクスチャを設定します。                                                                                                                                                                                                                                                                                                                                                                                          |
| eglChooseConfig                  | Direct3D は一連の既定のフレーム バッファー構成を提供しません。 スワップ チェーンの構成                                                                                                                                                                                                                                                                                                                                                                                           |
| eglCopyBuffers                   | バッファー データをコピーするには、[**ID3D11DeviceContext::CopyStructureCount**](https://msdn.microsoft.com/library/windows/desktop/ff476393) を呼び出します。 リソースをコピーするには、[**ID3DDeviceCOntext::CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392) を呼び出します。                                                                                                                                                                                                                                                      |
| eglCreateContext                 | Direct3D デバイス コンテキストを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出します。これは、Direct3D デバイスへのハンドルと既定の Direct3D イミディエイト コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクト) の両方を返します。 返された [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトで [**ID3D11Device2::CreateDeferredContext**](https://msdn.microsoft.com/library/windows/desktop/dn280495) を呼び出して、Direct3D 遅延コンテキストを作成することもできます。 |
| eglCreatePbufferFromClientBuffer | すべてのバッファーは、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) などの Direct3D サブリソースとして、読み取りと書き込みが行われます。 [**ID3D11DeviceContext1:CopyResource**](https://msdn.microsoft.com/library/windows/desktop/ff476392) などのメソッドを使って、互換性のあるサブリソース型の間でコピーします。                                                                                                                                                                                                     |
| eglCreatePbufferSurface          | スワップ チェーンなしで Direct3D デバイスを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 静的メソッドを呼び出します。 Direct3D レンダー ターゲット ビューでは、[**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。                                                                                                                                                                                                                               |
| eglCreatePixmapSurface           | スワップ チェーンなしで Direct3D デバイスを作成するには、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 静的メソッドを呼び出します。 Direct3D レンダー ターゲット ビューでは、[**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。                                                                                                                                                                                                                               |
| eglCreateWindowSurface           | [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) (表示バッファー向け) と [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) (グラフィックス デバイスとそのリソースの仮想インターフェイス) を取得します。 **IDXGISwapChain1** に提供するフレーム バッファーを作成するために使用できる [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) を定義するには、**ID3D11Device1** を使います。                                                                                         |
| eglDestroyContext                | なし。 レンダー ターゲット ビューを削除するには、[**ID3D11DeviceContext::DiscardView1**](https://msdn.microsoft.com/library/windows/desktop/jj247573) を使います。 親 [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) を閉じるには、インスタンスを null に設定し、プラットフォームがそのリソースを再利用するまで待機します。 デバイス コンテキストを直接破棄することはできません。                                                                                                                                                |
| eglDestroySurface                | なし。 グラフィックス リソースは、UWP アプリの CoreWindow がプラットフォームによって閉じられたときにクリーンアップされます。                                                                                                                                                                                                                                                                                                                                                                                                 |
| eglGetCurrentDisplay             | 現在のメイン アプリ ウィンドウへの参照を取得するには、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出します。                                                                                                                                                                                                                                                                                                                                                         |
| eglGetCurrentSurface             | これが現在の [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) です。 通常、これのスコープはレンダラー オブジェクトに限定されます。                                                                                                                                                                                                                                                                                                                                                         |
| eglGetError                      | エラーは、DirectX インターフェイスのほとんどのメソッドによって返される HRESULT として取得されます。 メソッドから HRESULT が返されない場合は、[**GetLastError**](https://msdn.microsoft.com/library/windows/desktop/ms679360) を呼び出します。 システム エラーを anHRESULTvalue 変換、[**HRESULT\_FROM\_WIN32**](https://msdn.microsoft.com/library/windows/desktop/ms680746)を使用してマクロです。                                                                                                                                                                                                  |
| eglInitialize                    | 現在のメイン アプリ ウィンドウへの参照を取得するには、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出します。                                                                                                                                                                                                                                                                                                                                                         |
| eglMakeCurrent                   | [**ID3D11DeviceContext1::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) を使って、現在のコンテキストに描画するためのレンダー ターゲットを設定します。                                                                                                                                                                                                                                                                                                                                  |
| eglQueryContext                  | なし。 ただし、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インスタンスからレンダリング ターゲットと一部の構成データを取得できます  (利用できるメソッドの一覧については、リンクをご覧ください)。                                                                                                                                                                                                                                                                                           |
| eglQuerySurface                  | なし。 ただし、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インスタンスのメソッドからビューポートと現在のグラフィックス ハードウェアに関するデータを取得できます  (利用できるメソッドの一覧については、リンクをご覧ください)。                                                                                                                                                                                                                                                                               |
| eglReleaseTexImage               | なし。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| eglReleaseThread                 | 一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。                                                                                                                                                                                                                                                                                                                                                                              |
| eglSurfaceAttrib                 | Direct3D のレンダー ターゲット ビューを構成するには、[**D3D11\_RENDER\_TARGET\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476201) を使います。                                                                                                                                                                                                                                                                                                                                                               |
| eglSwapBuffers                   | [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) を使います。                                                                                                                                                                                                                                                                                                                                                                                                                     |
| eglSwapInterval                  | 「[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)」をご覧ください。                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| eglTerminate                     | グラフィックス パイプラインの出力を表示するために使う CoreWindow は、オペレーティング システムによって管理されます。                                                                                                                                                                                                                                                                                                                                                                                          |
| eglWaitClient                    | 共有サーフェスについては、IDXGIKeyedMutex を使います。 一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。                                                                                                                                                                                                                                                                                                                                    |
| eglWaitGL                        | 共有サーフェスについては、IDXGIKeyedMutex を使います。 一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。                                                                                                                                                                                                                                                                                                                                    |
| eglWaitNative                    | 共有サーフェスについては、IDXGIKeyedMutex を使います。 一般的な GPU マルチスレッドについては、「[マルチスレッド](https://msdn.microsoft.com/library/windows/desktop/ff476891)」をご覧ください。                                                                                                                                                                                                                                                                                                                                    |

 

 

 




