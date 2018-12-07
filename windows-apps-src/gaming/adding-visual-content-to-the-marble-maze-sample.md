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
# <a name="adding-visual-content-to-the-marble-maze-sample"></a>Marble Maze サンプルへの視覚的なコンテンツの追加




このドキュメントでは、Marble Maze ゲームがユニバーサル Windows プラットフォーム (UWP) アプリ環境で Direct3D と Direct2D をどのように使うかについて説明します。パターンを学習することにより、独自のゲーム コンテンツの開発に活用できます。 Marble Maze のアプリケーション構造全体で視覚的なゲーム コンポーネントがどのように使われているかについては、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」をご覧ください。

Marble Maze の視覚的側面は、次のような基本の手順に従って開発しました。

1.  Direct3D 環境と Direct2D 環境を初期化する基本フレームワークを作ります。
2.  画像およびモデル編集プログラムを使用すると、ゲームに表示される 2 D および 3D アセットを設計できます。
3.  2 D および 3D アセットが正しく読み込まれ、ゲームに表示することを確認します。
4.  ゲーム アセットの画質を高める頂点シェーダーとピクセル シェーダーを統合します。
5.  アニメーション、ユーザー入力などのゲーム ロジックを統合します。

また、最初行いました 3D アセットを追加し、次に、2 D アセット。 たとえば、メニュー システムとタイマーを追加する前に、コア ゲーム ロジックに重点的に取り組みました。

また、開発プロセスでは、これらの手順の一部を何度も繰り返す必要がありました。 たとえば、メッシュや大理石のモデルに変更を行った場合、それらのモデルをサポートするシェーダー コードの一部も変更する必要もありました。

> [!NOTE]
> このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

 
ここでは、DirectX や視覚的なゲーム コンテンツを扱うとき、つまり DirectX グラフィックス ライブラリの初期化、シーンのリソースの読み込み、シーンの更新やレンダリングを行う際の次の重要事項について説明します。

-   ゲーム コンテンツの追加には、通常、多くの手順が必要です。 多くの場合、これらの手順を繰り返すことも必要です。 ゲーム開発者多くの場合は集中まず 3D ゲーム コンテンツを追加し、2 D のコンテンツを追加します。
-   より多くの顧客に製品を届けて優れたユーザー エクスペリエンスを提供できるように、できるだけ広範囲のグラフィックス ハードウェアをサポートするようにします。
-   設計時と実行時の形式は明確に区別します。 設計時のアセットは、柔軟性を最大限に高め、コンテンツに対する迅速な繰り返し処理ができるように構造化します。 アセットは、実行時にできるだけ効率的に読み込みとレンダリングを行うことができるように、形式を設定して圧縮します。
-   Direct3D デバイスと Direct2D デバイスの UWP アプリでの作成は、従来の Windows デスクトップ アプリでの作成とほぼ同じです。 1 つの大きな違いは、スワップ チェーンと出力ウィンドウとの関連付けの方法です。
-   ゲームを設計するときは、選択したメッシュ形式が主要なシナリオをサポートすることを確かめます。 たとえば、ゲームで衝突が必要な場合は、メッシュから衝突データを取得できることを確かめます。
-   まず、すべてのシーン オブジェクトを更新してからレンダリングすることによって、ゲーム ロジックとレンダリング ロジックを切り離します。
-   通常、3 D シーン オブジェクトを描画して、2 D オブジェクトのシーンの前面に表示されます。
-   描画と垂直ブランクを同期して、実際にディスプレイに表示されないフレームの描画にゲームが時間をかけないようにします。 *垂直ブランク*は 1 つのフレームがモニターへの描画を終了するまでの時間と、次のフレームが開始されます。

## <a name="getting-started-with-directx-graphics"></a>DirectX グラフィックスの概要


Marble Maze ユニバーサル Windows プラットフォーム (UWP) ゲームを計画したとき、選択した C++ と direct 3 d 11.1 なレンダリングと高パフォーマンスの最大の制御を必要とする 3D ゲームを作成するための最適な選択であるためです。 DirectX 11.1 は DirectX 9 から DirectX 11 までのハードウェアをサポートするため、より多くの顧客に効率よく製品を届けることができます。以前の各 DirectX バージョン用にコードを書き直す必要がないためです。

Marble Maze では、direct 3 d 11.1 を使用して、3 D のゲーム アセット (大理石と迷路) をレンダリングします。 Marble Maze では、Direct2D、DirectWrite、および Windows Imaging Component (WIC) も、描画など、メニューやタイマーは、2 D ゲーム アセットを使用します。

ゲームを開発するには計画が必要です。 読むことをお勧めします新しい DirectX グラフィックスの場合は、 [DirectX: 概要](directx-getting-started.md)、UWP DirectX ゲームの作成の基本概念を理解します。 このドキュメントで、Marble Maze のソース コードを使用すると、DirectX グラフィックスに関するより詳しい情報については、次のリソースを参照することができます。

-   [Direct3d11 グラフィックス](https://msdn.microsoft.com/library/windows/desktop/ff476080): について説明します。 direct3d11 は、ハードウェア アクセラレータによる強力の 3D グラフィックス API、Windows プラットフォームで 3 d ジオメトリをレンダリングします。
-   [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990): Direct2D について説明します。 ハードウェア アクセラレータによる、2 d グラフィックス API を提供する高パフォーマンスかつ高品質のレンダリングと、2 d ジオメトリ、ビットマップ、テキストのします。
-   [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038): 高品質のテキストのレンダリングをサポートする DirectWrite について説明します。
-   [Windows Imaging Component](https://msdn.microsoft.com/library/windows/desktop/ee719902): について説明します。 WIC、デジタル画像の低レベルの API を提供する拡張可能なプラットフォームです。

### <a name="feature-levels"></a>機能レベル

Direct3d11 では、*機能レベル*をという名前のパラダイムについて説明します。 機能レベルは、明確に定義された GPU 機能のセットです。 機能レベルを使って、Direct3D ハードウェアの以前のバージョンで実行できるようにゲームのターゲットを設定します。 Marble Maze では機能レベル 9.1 がサポートされます。高いレベルの高度な機能は必要ないためです。 所有するコンピューターがハイエンドかローエンドかにかかわらず、すべての顧客に対して優れたユーザー エクスペリエンスを実現できるように、できるだけ幅広いハードウェアをサポートし、ゲーム コンテンツをそれに合わせることをお勧めします。 機能レベルについて詳しくは、「[下位レベル ハードウェアでの Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476872)」をご覧ください。

## <a name="initializing-direct3d-and-direct2d"></a>Direct3D と Direct2D の初期化


デバイスはディスプレイ アダプターを表します。 Direct3D デバイスと Direct2D デバイスの UWP アプリでの作成は、従来の Windows デスクトップ アプリでの作成とほぼ同じです。 主な違いは、Direct3D スワップ チェーンをウィンドウ システムに関連付ける方法です。

**DeviceResources** クラスは、Direct3D と Direct2D を管理する基盤です。 このクラスは、一般的なインフラストラクチャ、いないゲーム固有のアセットを処理します。 Marble Maze は、Direct3D と Direct2D へのアクセスを提供する**DeviceResources**オブジェクトへの参照を持つにハンドル ゲーム固有のアセットを**MarbleMazeMain**クラスに定義します。

**DeviceResources**コンス トラクターは、初期化中に、デバイスに依存しないリソースと Direct3D と Direct2D デバイスを作成します。

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

**DeviceResources** クラスは、この機能を切り離して、環境が変更されたときに簡単に応答できるようにします。 たとえば、ウィンドウ サイズが変更されると **CreateWindowSizeDependentResources** メソッドを呼び出します。

###  <a name="initializing-the-direct2d-directwrite-and-wic-factories"></a>Direct2D、DirectWrite、WIC ファクトリの初期化

**DeviceResources::CreateDeviceIndependentResources** メソッドは、Direct2D、DirectWrite、WIC のファクトリを作成します。 DirectX グラフィックスにおいて、ファクトリは、グラフィックス リソースを作成するための開始点です。 Marble Maze では、メイン スレッドですべての描画を実行するため、**D2D1\_FACTORY\_TYPE\_SINGLE\_THREADED** を指定しています。

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

###  <a name="creating-the-direct3d-and-direct2d-devices"></a>Direct3D デバイスと Direct2D デバイスの作成

**DeviceResources::CreateDeviceResources** メソッドは、[D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出して、Direct3D ディスプレイ アダプターを表すデバイス オブジェクトを作成します。 Marble Maze には、機能レベル 9.1 がサポートされているため、上記**deviceresources::createdeviceresources**メソッドは、 **featureLevels**配列でレベル 9.1 11.1 からを指定します。 Direct3D はリストを順に確かめ、使用可能な最初の機能レベルをアプリに提供します。 したがって**D3D\_FEATURE\_LEVEL**配列の項目は表示高いものから順にアプリが利用可能な最高の機能レベルを取得するようにします。 **DeviceResources::CreateDeviceResources** メソッドは、**D3D11CreateDevice** から返される Direct3D 11 デバイスを照会することによって Direct3D 11.1 デバイスを取得します。

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

次に、**DeviceResources::CreateDeviceResources** メソッドが Direct2D デバイスを作成します。 Direct2D は、Direct3D との相互運用に Microsoft DirectX Graphic Infrastructure (DXGI) を使います。 DXGI によって、ビデオ メモリ サーフェスをグラフィックス ランタイム間で共有できるようになります。 Marble Maze は、Direct3D デバイスから基になる DXGI デバイスを使って、Direct2D ファクトリから Direct2D デバイスを作成します。

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

DXGI や Direct2D と Direct3D の相互運用について詳しくは、「[DXGI の概要](https://msdn.microsoft.com/library/windows/desktop/bb205075)」と「[Direct2D と Direct3D の相互運用性の概要](https://msdn.microsoft.com/library/windows/desktop/dd370966)」をご覧ください。

### <a name="associating-direct3d-with-the-view"></a>Direct3D とビューの関連付け

**DeviceResources::CreateWindowSizeDependentResources** メソッドは、スワップ チェーン、Direct3D と Direct2D のレンダー ターゲットなど、所定のウィンドウ サイズによって異なるグラフィックス リソースを作成します。 DirectX UWP アプリとデスクトップ アプリとの大きな違いは、スワップ チェーンが出力ウィンドウと関連付けられる方法です。 スワップ チェーンは、デバイスがモニターにレンダリングするバッファーを表示します。 [Marble Maze のアプリケーション構造](marble-maze-application-structure.md)では、デスクトップ アプリから UWP アプリのウィンドウ システムの異なる方法について説明します。 UWP アプリは、 [HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751)オブジェクトでは動作しない、ために、Marble Maze は、デバイス出力をビューに関連付ける[idxgifactory 2::createswapchainforcorewindow](https://msdn.microsoft.com/library/windows/desktop/hh404559)メソッドを使用する必要があります。 次の例に、スワップ チェーンを作成する **DeviceResources::CreateWindowSizeDependentResources** メソッドの一部を示します。

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

電力消費を最小限に抑えるため (ノート PC やタブレットのようなバッテリ駆動デバイスで重要)、**DeviceResources::CreateWindowSizeDependentResources** メソッドは [IDXGIDevice1::SetMaximumFrameLatency](https://msdn.microsoft.com/library/windows/desktop/ff471334) メソッドを呼び出して、垂直ブランクの後でのみゲームがレンダリングされるようにします。 垂直ブランクとの同期は、このドキュメントで[シーンの表示](#presenting-the-scene)」セクションで詳しく説明します。

```cpp
// Ensure that DXGI does not queue more than one frame at a time. This both 
// reduces latency and ensures that the application will only render after each
// VSync, minimizing power consumption.
DX::ThrowIfFailed(
    dxgiDevice->SetMaximumFrameLatency(1)
    );
```

**DeviceResources::CreateWindowSizeDependentResources** メソッドは、多くのゲームに対応する方法でグラフィックス リソースを初期化します。

> [!NOTE]
> *ビュー*という用語は、direct3d よりも、Windows ランタイムで異なる意味をいます。 Windows ランタイムでは、ビューは、アプリのユーザー インターフェイス設定のコレクション (表示領域、入力動作、処理に使うスレッドなどを含む) を指します。 ビューを作成するときは、必要な構成と設定を指定します。 アプリのビューを設定するプロセスについては、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」で説明します。
> Direct3D では、ビューという用語には複数の意味があります。 リソース ビューは、リソースにアクセスできるサブリソースを定義します。 たとえば、テクスチャ オブジェクトがシェーダー リソース ビューに関連付けられている場合、そのシェーダーは後でテクスチャにアクセスできます。 リソース ビューの 1 つの長所は、レンダリング パイプラインの段階ごとに異なる方法でデータを解釈できることです。 リソース ビューについて詳しくは、[リソース ビュー](https://msdn.microsoft.com/library/windows/desktop/ff476900#Views)を参照してください。
> ビュー変換またはビュー変換マトリックスのコンテキストで使われた場合、ビューは、カメラの位置と向きを表します。 ビュー変換は、カメラの位置と向きを基準として、ワールド内でオブジェクトを再配置します。 ビュー変換について詳しくは、「[ビュー変換 (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb206342)」をご覧ください。 Marble Maze でリソース ビューやマトリックス ビューをどのように使っているかについて、このトピックで詳しく説明しています。

 

## <a name="loading-scene-resources"></a>シーン リソースの読み込み


Marble Maze では、 **BasicLoader.h**で宣言されている**BasicLoader**クラスを使用して、テクスチャ、シェーダーを読み込みます。 Marble Maze では、 **SDKMesh**クラスを使用して、迷路と大理石の 3D メッシュを読み込みます。

Marble Maze では、応答性を保持するために、非同期的に (つまりバックグラウンドで) シーン リソースを読み込みます。 バックグラウンドでのアセットの読み込み中、ゲームはウィンドウ イベントに応答できます。 このプロセスについては、このガイドの「[バックグラウンドでのゲーム アセットの読み込み](marble-maze-application-structure.md#loading-game-assets-in-the-background)」で詳しく説明しています。

###  <a name="loading-the-2d-overlay-and-user-interface"></a>2 D オーバーレイとユーザー インターフェイスの読み込み

Marble Maze では、オーバーレイは、画面の一番上に表示される画像です。 オーバーレイは、常にシーンの前面に表示されます。 Marble Maze では、オーバーレイには、Windows ロゴとテキスト文字列**DirectX Marble Maze ゲームのサンプル**が含まれます。 オーバーレイの管理は、 **SampleOverlay.h**で定義されている**SampleOverlay**クラスによって実行されます。 Direct3D サンプルの一部としてオーバーレイを使いますが、このコードを利用すると、シーンの前面に任意の画像を表示することができます。

オーバーレイの重要な点の 1 つは、コンテンツが変化しないため、**SampleOverlay** クラスが初期化中にコンテンツを [ID2D1Bitmap1](https://msdn.microsoft.com/library/windows/desktop/hh404349) オブジェクトに描画またはキャッシュすることです。 描画時に **SampleOverlay** クラスが行う必要があるのは、画面にビットマップを描画することだけです。 このように、テキスト描画などコストの高いルーチンを、すべてのフレームで実行する必要はありません。

ユーザー インターフェイス (UI) は、メニューや、シーンの前面に表示するヘッドアップ ディスプレイ (Hud) などの 2D コンポーネントで構成されます。 Marble Maze では、次の UI 要素を定義しています。

-   ユーザーがゲームを開始したりハイ スコアを表示できるようにするためのメニュー項目。
-   プレイ開始までの 3 秒をカウント ダウンするタイマー。
-   経過したプレイ時間を追跡するタイマー。
-   最速記録を表示する表。
-   **ゲームが一時停止したときに paused**テキストです。

Marble Maze は、ゲーム固有の UI 要素を**UserInterface.h**に定義します。 Marble Maze では、**ElementBase** クラスをすべての UI 要素の基本型として定義しています。 **ElementBase** クラスは、UI 要素のサイズ、位置、配置、可視性などの属性を定義します。 さらに、要素の更新方法やレンダリング方法も制御します。

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

UI 要素の共通基底クラスを提供することで、ユーザー インターフェイスを管理する **UserInterface** クラスが行う必要があるのは、**ElementBase** オブジェクトのコレクションの保持のみになります。これにより、UI の管理が簡略化され、再利用可能なユーザー インターフェイス マネージャーが提供されます。 Marble Maze では、ゲーム固有の動作を実装する型を **ElementBase** から派生させて定義します。 たとえば、**HighScoreTable** は、ハイ スコア表の動作を定義します。 これらの型について詳しくは、ソース コードをご覧ください。

> [!NOTE]
> XAML を使用すると、シミュレーション ゲームや戦略ゲーム、見などの複雑なユーザー インターフェイスをより簡単に作成されるため、XAML を使って、UI を定義するかどうかを検討してください。 DirectX UWP ゲームで XAML ユーザー インターフェイスを開発する方法について詳しくは、[拡張ゲームのサンプル](tutorial-resources.md)、DirectX 3D シューティング ゲームのサンプルを参照するを参照してください。

 

###  <a name="loading-shaders"></a>シェーダーの読み込み

Marble Maze では、**BasicLoader::LoadShader** メソッドを使ってファイルからシェーダーを読み込みます。

シェーダーは、現在のゲームの GPU プログラミングの基本単位です。 ほぼすべての 3D グラフィックス処理は、シェーダーがモデル変換やシーンの照明の適用、またはより複雑なジオメトリ処理、文字は、テセレーションにスキンからによって駆動されます。 シェーダーのプログラミング モデルについて詳しくは、「[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561)」をご覧ください。

Marble Maze では、頂点シェーダーとピクセル シェーダーを使っています。 頂点シェーダーは、常に、入力された 1 つの頂点を処理し、出力として 1 つの頂点を生成します。 ピクセル シェーダーは、数値、テクスチャ データ、補間された頂点単位の値、その他のデータを受け取り、出力としてピクセル色を生成します。 1 つのシェーダーは一度に 1 つの要素を変換するため、複数のシェーダー パイプラインを提供するグラフィックス ハードウェアは要素のセットを並列処理できます。 GPU で使用できる並列パイプラインの数は、CPU で使用可能な数を大きく上回る可能性があります。 したがって、基本的なシェーダーでさえスループットを大幅に向上することができます。

**Marblemazemain::loaddeferredresources**メソッドは、オーバーレイを読み込んだ後、1 つの頂点シェーダーと 1 つのピクセル シェーダーを読み込みます。 これらのシェーダーの設計時のバージョンは、 **BasicVertexShader.hlsl**と**BasicPixelShader.hlsl**でそれぞれ定義されます。 Marble Maze では、レンダリング フェーズでこれらのシェーダーをボールと迷路の両方に適用します。

Marble Maze プロジェクトには、シェーダー ファイルの .hlsl バージョン (設計時の形式) と .cso バージョン (実行時形式) の両方が含まれています。 ビルド時に Visual Studio が fxc.exe エフェクト コンパイラを使って .hlsl ソース ファイルを .cso バイナリ シェーダーにコンパイルします。 エフェクト コンパイラ ツールについて詳しくは、「[エフェクト コンパイラ ツール](https://msdn.microsoft.com/library/windows/desktop/bb232919)」をご覧ください。

頂点シェーダーは、指定されたモデル マトリックス、ビュー マトリックス、プロジェクション マトリックスを使って、入力ジオメトリを変換します。 入力ジオメトリの位置データは変換されて、2 回出力されます。まずレンダリングのために必要な画面空間内に出力され、ピクセル シェーダーが照明計算を実行できるように再びワールド空間内に出力されます。 サーフェスの標準ベクターはワールド空間に変換されます。これも、これもピクセル シェーダーが照明のために使います。 テクスチャ座標は、変更されずにピクセル シェーダーに渡されます。

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

ピクセル シェーダーは、頂点シェーダーの出力を入力として受け取ります。 このシェーダーは照明計算を実行して、輪郭がぼやけたスポットライトを模倣します。このライトは、大理石の位置に合わせて迷路上を動きます。 照明は、光に直面するサーフェスで最も強くなります。 サーフェス法線が光に対して直角になるにつれて、拡散コンポーネントは減少してゼロになります。また、法線の向きが光から離れるにつれて、環境光が減少します。 大理石に近い (つまりスポットライトの中央に近い) ほど照明が強くなります。 ただし、大理石の下では柔らかい影をシミュレートするために、照明が調整されます。 実際の環境では、白い大理石のようなオブジェクトは、シーンの他のオブジェクトに拡散的にスポットライトを反射します。 これは、大理石の明るい側の半球のビューにあるサーフェスについて概算されます。 照明のその他の係数は、大理石に対する相対的な角度と距離です。 生成されるピクセル色は、サンプリングされたテクスチャと照明計算の結果を合成したものになります。

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
> コンパイルされたピクセル シェーダーには、32 の演算命令と 1 つのテクスチャ命令が含まれています。 このシェーダーは、デスクトップ コンピューターとハイエンドのタブレットで正常に動作する必要があります。 ただし、ローエンドのコンピューターでは、このシェーダーを処理することができず、対話型のフレーム レートが提供される場合があります。 対象ユーザーの標準的なハードウェアを検討し、そのハードウェアの性能に合わせてシェーダーを設計します。

 

**Marblemazemain::loaddeferredresources**メソッドでは、 **basicloader::loadshader**メソッドを使用して、シェーダーを読み込みます。 次の例では、頂点シェーダーを読み込みます。 このシェーダーの実行時形式は**basicvertexshader.cso です**。 **m\_vertexShader** メンバー変数は [ID3D11VertexShader](https://msdn.microsoft.com/library/windows/desktop/ff476641) オブジェクトです。

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

**m\_inputLayout** メンバー変数は [ID3D11InputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476575) オブジェクトです。 入力レイアウト オブジェクトは、入力アセンブラー (IA) ステージの入力状態をカプセル化します。 IA ステージの 1 つの仕事は、シェーダーの効率を向上することです。システム生成値 (*セマンティクス*) を使って、まだ処理されていないプリミティブまたは頂点のみを処理します。

[ID3D11Device::CreateInputLayout](https://msdn.microsoft.com/library/windows/desktop/ff476512) メソッドを使って、入力要素の説明の配列から入力レイアウトを作成します。 配列には 1 つまたは複数の入力要素が含まれます。各入力要素は、1 つの頂点バッファーの 1 つの頂点データ要素を記述します。 入力要素の記述のセット全体によって、IA ステージにバインドされているすべての頂点バッファーのすべての頂点データ要素を記述します。 

**layoutDesc**上記のコード スニペットでは、Marble Maze でレイアウトの記述を示します。 このレイアウトの記述には、4 つの頂点データ要素を含む頂点バッファーが記述されています。 配列の各エントリの重要な部分は、セマンティック名、データ形式、バイト オフセットです。 たとえば、**POSITION** 要素は、オブジェクト空間での頂点の位置を指定します。 これは、バイト オフセット 0 で開始し、3 つの浮動小数点コンポーネントを含みます (合計 12 バイト)。 **NORMAL** 要素は、標準ベクターを指定します。 これはバイト オフセット 12 で開始します。レイアウトで、12 バイトを必要とする **POSITION** の後にあるためです。 **NORMAL** 要素は、4 つの要素で構成される 32 ビット符号なし整数を含みます。

次の例に示すように、頂点シェーダーによって定義される **sVSInput** 構造体と入力レイアウトを比較します。 **sVSInput** 構造体は、**POSITION**、**NORMAL**、**TEXCOORD0** の各要素を定義します。 DirectX ランタイムは、シェーダーによって定義された入力構造体にレイアウトの各要素をマップします。

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

「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」では、使用できるセマンティクスのそれぞれについてさらに詳しく説明しています。

> [!NOTE]
> レイアウトでは、同じレイアウトを共有する複数のシェーダーを有効にするのには使用されていないその他のコンポーネントを指定できます。 たとえば、**TANGENT** 要素はシェーダーでは使われません。 法線マッピングなどの手法を使う場合は、**TANGENT** 要素を使うことができます。 法線マッピング (バンプ マッピング) を使うと、オブジェクトのサーフェスに対してバンプ エフェクトを作成できます。 バンプ マッピングについて詳しくは、「[バンプ マッピング (Direct3D 9)](https://msdn.microsoft.com/library/windows/desktop/bb172379)」をご覧ください。

 

入力アセンブリ ステージについて詳しくは、[入力アセンブラー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205116)と[、入力アセンブラー ステージの概要](https://msdn.microsoft.com/library/windows/desktop/bb205117)を参照してください。

頂点シェーダーとピクセル シェーダーを使ってシーンをレンダリングするプロセスについては、このドキュメントの「[シーンのレンダリング](#rendering-the-scene)」で説明しています。

### <a name="creating-the-constant-buffer"></a>定数バッファーの作成

Direct3D バッファーは、データのコレクションをグループ化します。 定数バッファーは、シェーダーにデータを渡すために使うことができるバッファーの種類の 1 つです。 Marble Maze では、定数バッファーを使って、モデル (またはワールド) ビューと、アクティブなシーン オブジェクトのためのプロジェクション マトリックスを保持します。

次の例では、 **marblemazemain::loaddeferredresources**メソッドは後でマトリックス データを保持する定数バッファーを作成する方法を示しています。 この例では、**D3D11\_BIND\_CONSTANT\_BUFFER** フラグを使って定数バッファーとしての使用を指定する **D3D11\_BUFFER\_DESC** 構造体を作成しています。 この例では、次にこの構造体を [ID3D11Device::CreateBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476501) メソッドに渡します。 **m\_constantBuffer** 変数は [ID3D11Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476351) オブジェクトです。

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

**Marblemazemain::update**メソッドは、後で、 **ConstantBuffer**オブジェクト、迷路用と大理石のいずれかを更新します。 **Marblemazemain::render**メソッドは、各オブジェクトをレンダリングする前に、各**ConstantBuffer**オブジェクトと定数バッファーをバインドします。 次の例では、 **MarbleMazeMain.h**内にある**ConstantBuffer**構造を示します。

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

定数バッファーのマップを理解するためにシェーダーのコードを**BasicVertexShader.hlsl で頂点シェーダーで定義されている**ConstantBuffer**定数バッファーに**MarbleMazeMain.h**で**ConstantBuffer**構造体を比較します**:

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

**ConstantBuffer** 構造体のレイアウトは、**cbuffer** オブジェクトと一致します。 **cbuffer** 変数は、レジスタ b0 を指定します。つまり、定数バッファー データがレジスタ 0 に格納されます。 **Marblemazemain::render**メソッドは、定数バッファーをアクティブ化するときに、レジスタ 0 を指定します。 このプロセスについては、このドキュメントの後の方で詳しく説明します。

定数バッファーについて詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」をご覧ください。 register キーワードについて詳しくは、「[register](https://msdn.microsoft.com/library/windows/desktop/dd607359)」をご覧ください。

###  <a name="loading-meshes"></a>メッシュの読み込み

Marble Maze では、実行時の形式として SDK メッシュを使います。この形式では、サンプル アプリケーションのメッシュ データを読み込む基本的な方法が提供されるためです。 本番で使うには、ゲーム固有の要件を満たすメッシュ形式を使う必要があります。

**Marblemazemain::loaddeferredresources**メソッドは、頂点シェーダーとピクセル シェーダーを読み込んだ後に、メッシュ データを読み込みます。 メッシュは頂点データのコレクションです。多くの場合、位置、法線データ、色、素材、テクスチャ座標などの情報が含まれます。 メッシュは通常 3D オーサリング ソフトウェアで作成し、アプリケーション コードとは別のファイルに保持されます。 大理石と迷路は、このゲームに使われているメッシュの 2 つの例です。

Marble Maze では、**SDKMesh** クラスを使ってメッシュを管理します。 このクラスは**SDKMesh.h**で宣言されています。 **SDKMesh** は、メッシュ データを読み込み、レンダリングし、破棄するためのメソッドを提供します。

> [!IMPORTANT]
> Marble Maze では、SDK メッシュ形式を使用して、 **SDKMesh**クラスを提供するだけです。 SDK メッシュ形式は学習用やプロトタイプの作成用に役立ちますが、ごく基本的な形式であるため、多くのゲーム開発の要件を満たさない可能性があります。 ゲーム固有の要件を満たすメッシュ形式を使うことをお勧めします。

 

次の例では、 **marblemazemain::loaddeferredresources**メソッドが**sdkmesh::create**メソッドを使用して、迷路とボールのメッシュ データをロードする方法を示しています。

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

###  <a name="loading-collision-data"></a>衝突データの読み込み

ここでは、Marble Maze で大理石と迷路の間の物理シミュレーションを実装する方法を特に説明しませんが、メッシュが読み込まれるときに物理システムのメッシュ ジオメトリが読み取られる点に注目してください。

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

大部分衝突データをロードする方法は、使う実行時の形式によって異なります。 Marble Maze が SDK メッシュ ファイルから衝突ジオメトリを読み込む方法について詳しくは、ソース コードで**MarbleMazeMain::ExtractTrianglesFromMesh**メソッドを参照してください。

## <a name="updating-game-state"></a>ゲームの状態の更新


Marble Maze では、まずすべてのシーン オブジェクトを更新してからレンダリングすることによって、ゲーム ロジックとレンダリング ロジックを分離しています。

[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)では、メイン ゲーム ループについて説明します。 ゲーム ループの一部であるシーンの更新は、Windows イベントの後の入力が処理された後で、シーンがレンダリングされる前に行います。 **Marblemazemain::update**メソッドは、UI と、ゲームの更新を処理します。

### <a name="updating-the-user-interface"></a>ユーザー インターフェイスの更新

**Marblemazemain::update**メソッドは、UI の状態を更新する**userinterface::update**メソッドを呼び出します。

```cpp
UserInterface::GetInstance().Update(
    static_cast<float>(m_timer.GetTotalSeconds()), 
    static_cast<float>(m_timer.GetElapsedSeconds()));
```

**UserInterface::Update** メソッドは、UI コレクション内の各要素を更新します。

```cpp
void UserInterface::Update(float timeTotal, float timeDelta)
{
    for (auto iter = m_elements.begin(); iter != m_elements.end(); ++iter)
    {
        (*iter)->Update(timeTotal, timeDelta);
    }
}
```

**ElementBase** ( **UserInterface.h**で定義されている) から派生するクラスでは、特定の動作を実行する**Update**メソッドを実装します。 たとえば、**StopwatchTimer::Update** メソッドは、指定された時間で経過時間を更新し、後で表示されるテキストを更新します。

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

###  <a name="updating-the-scene"></a>シーンの更新

**Marblemazemain::update**メソッドは、ステート マシン (、 **GameState**、 **m_gameState**に格納されている) の現在の状態に基づいてゲームを更新します。 ゲームがアクティブな状態 (**GameState::InGameActive**) と、Marble Maze はカメラ大理石を更新し、定数バッファーに含まれるビュー マトリックスを更新し、物理シミュレーションを更新します。

次の例では、 **marblemazemain::update**メソッドが、カメラの位置を更新する方法を示しています。 Marble Maze では、**m\_resetCamera** 変数を使って、カメラを大理石の真上に配置するためにリセットする必要があることを示します。 カメラがリセットされるのは、ゲームが開始するときか大理石が迷路を通り抜けたときです。 メイン メニューまたはハイスコア表示画面がアクティブな場合、カメラは定位置に設定されます。 それ以外の場合、Marble Maze では、*timeDelta* パラメーターを使って、カメラの位置を現在位置と目標位置の間で補間します。 目標位置は大理石の斜め前方です。 経過フレーム時間を使うと、カメラが大理石を少しずつ追いかける、つまり追跡することができます。

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

次の例では、 **marblemazemain::update**メソッドが大理石と迷路の定数バッファーを更新する方法を示しています。 迷路のモデル (ワールド) マトリックスは、常に単位マトリックスです。 要素がすべて 1 のメイン対角線を除き、単位マトリックスは、0 で構成される正方形マトリックスです。 大理石のモデル マトリックスは、位置マトリックスと回転マトリックスを掛けた値に基づいています。

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

**Marblemazemain::update**メソッドがユーザー入力を読み取るし、大理石の動きをシミュレートする方法については、[追加の入力と Marble Maze サンプルへの対話機能](adding-input-and-interactivity-to-the-marble-maze-sample.md)を参照してください。

## <a name="rendering-the-scene"></a>シーンのレンダリング


シーンがレンダリングされるとき、通常は次の手順が含まれます。

1.  現在のレンダー ターゲットの深度ステンシル バッファーを設定します。
2.  レンダーおよびステンシル ビューをクリアします。
3.  描画のために頂点シェーダーとピクセル シェーダーを準備します。
4.  シーン内の 3D オブジェクトをレンダリングします。
5.  シーンの前面に表示する 2 D オブジェクトをレンダリングします。
6.  レンダリングした画像をモニターに表示します。

**Marblemazemain::render**メソッドは、レンダー ターゲットにバインド ファイルと深度ステンシル ビュー、これらのビューをクリア、シーンを描画し、オーバーレイを描画します。

###  <a name="preparing-the-render-targets"></a>レンダー ターゲットの準備

シーンをレンダリングする前に、現在のレンダー ターゲットの深度ステンシル バッファーを設定する必要があります。 シーンが画面のすべてのピクセルに描画される保証がない場合は、レンダー ビューとステンシル ビューもクリアします。 Marble Maze では、すべてのフレームのレンダー ビューとステンシル ビューをクリアして、前のフレームに由来して表示されるアーティファクトがないことを確かめます。

次の例では、 **marblemazemain::render**メソッドが現在のものとして、レンダー ターゲットと深度/ステンシル バッファーを設定する[id 3d11devicecontext::omsetrendertargets](https://msdn.microsoft.com/library/windows/desktop/ff476464)メソッドを呼び出す方法を示しています。

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

[ID3D11RenderTargetView](https://msdn.microsoft.com/library/windows/desktop/ff476582) インターフェイスと [ID3D11DepthStencilView](https://msdn.microsoft.com/library/windows/desktop/ff476377) インターフェイスは、Direct3D 10 以降で提供されるテクスチャ ビュー機構をサポートします。 テクスチャ ビューについて詳しくは、「[テクスチャ ビュー (Direct3D 10)](https://msdn.microsoft.com/library/windows/desktop/bb205128)」をご覧ください。 [OMSetRenderTargets](https://msdn.microsoft.com/library/windows/desktop/ff476464) メソッドは、Direct3D パイプラインの出力マージャー ステージを準備します。 出力マージャー ステージについて詳しくは、「[出力マージャー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205120)」をご覧ください。

### <a name="preparing-the-vertex-and-pixel-shaders"></a>頂点シェーダーとピクセル シェーダーの準備

シーン オブジェクトをレンダリングする前に、次の手順を実行して、描画用のために頂点シェーダーとピクセル シェーダーを準備します。

1.  現在のレイアウトとしてシェーダー入力レイアウトを設定します。
2.  現在のシェーダーとして頂点シェーダーとピクセル シェーダーを設定します。
3.  シェーダーに渡す必要があるデータで定数バッファーを更新します。

> [!IMPORTANT]
> Marble Maze では、すべての 3D オブジェクトの頂点シェーダーとピクセル シェーダーのペアを 1 つを使用します。 ゲームでシェーダーのペアを複数使う場合は、別のシェーダーを使うオブジェクトを描画するたびに、これらの手順を実行する必要があります。 シェーダーの状態の変更に伴うオーバーヘッドを減らすには、同じシェーダーを使うすべてのオブジェクトごとにレンダー呼び出しをグループ化することをお勧めします。

 

このドキュメントの「[シェーダーの読み込み](#loading-shaders)」では、頂点シェーダーが作成されるときに入力レイアウトがどのように作成されるかについて説明しています。 次の例では、 **marblemazemain::render**メソッドが[id 3d11devicecontext::iasetinputlayout](https://msdn.microsoft.com/library/windows/desktop/ff476454)メソッドを使用して、現在のレイアウトとしてこのレイアウトを設定する方法を示しています。

```cpp
m_deviceResources->GetD3DDeviceContext()->IASetInputLayout(m_inputLayout.Get());
```

次の例は、 **marblemazemain::render**メソッドで、 [id 3d11devicecontext::vssetshader](https://msdn.microsoft.com/library/windows/desktop/ff476493)および[id 3d11devicecontext::pssetshader](https://msdn.microsoft.com/library/windows/desktop/ff476472)メソッドを使用して、現在のシェーダーとして頂点シェーダーとピクセル シェーダーを設定する方法を示しています。それぞれします。

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

**Marblemazemain::render**がシェーダーと入力レイアウトを設定した後、モデル、ビュー、および、迷路のプロジェクション マトリックスで定数バッファーを更新するのに[id 3d11devicecontext::updatesubresource](https://msdn.microsoft.com/library/windows/desktop/ff476486)メソッドを使用します。 **UpdateSubresource** メソッドは、CPU メモリから GPU メモリにマトリックス データをコピーします。 **Marblemazemain::update**メソッドで、 **ConstantBuffer**構造体のモデルとビュー コンポーネントが更新されることを思い出してください。 **Marblemazemain::render**メソッドは、現在の 1 つとして、この定数バッファーを設定する[id 3d11devicecontext::vssetconstantbuffers](https://msdn.microsoft.com/library/windows/desktop/ff476491)と[ID3D11DeviceContext::PSSetConstantBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476470)メソッドを呼び出します。

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

**Marblemazemain::render**メソッドは、レンダリングする大理石を準備する同様の手順を実行します。

### <a name="rendering-the-maze-and-the-marble"></a>迷路と大理石のレンダリング

現在のシェーダーをアクティブにした後、シーン オブジェクトを描画できます。 **Marblemazemain::render**メソッドは、迷路のメッシュをレンダリングする**SDKMesh::Render**メソッドを呼び出します。

```cpp
m_mazeMesh.Render(
    m_deviceResources->GetD3DDeviceContext(), 
    0, 
    INVALID_SAMPLER_SLOT, 
    INVALID_SAMPLER_SLOT);
```

**Marblemazemain::render**メソッドは、大理石をレンダリングする同様の手順を実行します。

このドキュメントで前に説明したように、**SDKMesh** クラスはデモンストレーション用に提供していますが、本番品質のゲームでの使用はお勧めしません。 ただし、**SDKMesh::Render** によって呼び出される **SDKMesh::RenderMesh** メソッドは、[ID3D11DeviceContext::IASetVertexBuffers](https://msdn.microsoft.com/library/windows/desktop/ff476456) メソッドと [ID3D11DeviceContext::IASetIndexBuffer](https://msdn.microsoft.com/library/windows/desktop/ff476453) メソッドを使ってメッシュを定義する現在の頂点バッファーとインデックス バッファーを設定し、[ID3D11DeviceContext::DrawIndexed](https://msdn.microsoft.com/library/windows/desktop/ff476410) メソッドを使ってバッファーを描画することに注目してください。 頂点バッファーとインデックス バッファーの操作方法について詳しくは、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」をご覧ください。

### <a name="drawing-the-user-interface-and-overlay"></a>ユーザー インターフェイスとオーバーレイの描画

3D シーンのオブジェクトを描画した後は、Marble Maze は、シーンの前面に表示される 2D の UI 要素を描画します。

**Marblemazemain::render**メソッドは、ユーザー インターフェイスとオーバーレイを描画して終了します。

```cpp
// Draw the user interface and the overlay.
UserInterface::GetInstance().Render(m_deviceResources->GetOrientationTransform2D());

m_deviceResources->GetD3DDeviceContext()->BeginEventInt(L"Render Overlay", 0);
m_sampleOverlay->Render();
m_deviceResources->GetD3DDeviceContext()->EndEvent();
```

**UserInterface::Render** メソッドは、[ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/hh404479) オブジェクトを使って、UI 要素を描画します。 このメソッドは、描画の状態を設定し、すべてのアクティブな UI 要素を描画してから、前の描画の状態を復元します。

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

**SampleOverlay::Render** メソッドは、同様の手法を使ってオーバーレイ ビットマップを描画します。

###  <a name="presenting-the-scene"></a>シーンの表示

すべての 2D および 3D シーンのオブジェクトを描画した後は、Marble Maze は、モニターにレンダリングの画像を表示します。 描画を垂直ブランクに同期して、実際にディスプレイに表示されないフレームの描画に時間が費やされないようにします。 Marble Maze では、シーンを表示するときにデバイスの変更も処理します。

**Marblemazemain::render**メソッドから制御が戻った後、ゲーム ループは、レンダリングされた画像をモニターに送信やディスプレイに **::deviceresources::present**メソッドを呼び出します。 **:Deviceresources::present**メソッドは、次の例に示すように、存在する操作を実行する[::present](https://msdn.microsoft.com/library/windows/desktop/bb174576)を呼び出します。

```cpp
// The first argument instructs DXGI to block until VSync, putting the application
// to sleep until the next VSync. This ensures we don't waste any cycles rendering
// frames that will never be displayed to the screen.
HRESULT hr = m_swapChain->Present(1, 0);
```

この例では、**m\_swapChain** は [IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631) オブジェクトです。 このオブジェクトの初期化については、このドキュメントの「[Direct3D と Direct2D の初期化](#initializing-direct3d-and-direct2d)」で説明しています。

[Idxgiswapchain::present](https://msdn.microsoft.com/library/windows/desktop/hh446797)、 *SyncInterval*、最初のパラメーターは、フレームを表示する前に待機する垂直ブランクの数を指定します。 Marble Maze では 1 を指定して、次の垂直ブランクまで待機することを指定しています。

[Idxgiswapchain::present](https://msdn.microsoft.com/library/windows/desktop/bb174576)メソッドは、デバイスが削除されたかどうか、またはそれ以外の場合に失敗したことを示すエラー コードを返します。 この場合、Marble Maze は、デバイスを再初期化します。

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

## <a name="next-steps"></a>次の手順


入力デバイスを操作する際の重要な手順については、「[Marble Maze サンプルへの入力と対話機能の追加](adding-input-and-interactivity-to-the-marble-maze-sample.md)」をご覧ください。 このドキュメントでは、Marble Maze がタッチ、加速度計、Xbox コント ローラー、およびマウス入力をサポートする方法について説明します。

## <a name="related-topics"></a>関連トピック


* [Marble Maze サンプルへの入力と対話機能の追加](adding-input-and-interactivity-to-the-marble-maze-sample.md)
* [Marble Maze のアプリケーション構造](marble-maze-application-structure.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




