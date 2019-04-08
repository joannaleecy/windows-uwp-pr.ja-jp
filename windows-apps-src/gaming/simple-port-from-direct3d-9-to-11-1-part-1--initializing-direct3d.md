---
title: Direct3D 11 の初期化
description: Direct3D デバイスとデバイス コンテキストへのハンドルを取得する方法や、DXGI を使ってスワップ チェーンを設定する方法など、Direct3D 9 の初期化コードを Direct3D 11 に変換する方法について説明します。
ms.assetid: 1bd5e8b7-fd9d-065c-9ff3-1a9b1c90da29
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, Direct3D 11, 初期化, 移植, Direct3D 9
ms.localizationpriority: medium
ms.openlocfilehash: 2aaf6dcc001a09e33588ac18898767b9cf92819c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604187"
---
# <a name="initialize-direct3d-11"></a>Direct3D 11 の初期化



**要約**

-   第 1 部:Direct3D 11 の初期化
-   [パート 2: レンダリングのフレームワークを変換します。](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)
-   [パート 3:ポート、ゲームのループ](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)


Direct3D デバイスとデバイス コンテキストへのハンドルを取得する方法や、DXGI を使ってスワップ チェーンを設定する方法など、Direct3D 9 の初期化コードを Direct3D 11 に変換する方法について説明します。 「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」のパート 1 です。

## <a name="initialize-the-direct3d-device"></a>Direct3D デバイスの初期化


Direct3D 9 では、[**IDirect3D9::CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/bb174313) を呼び出して、Direct3D デバイスへのハンドルを作成しました。 最初に [**IDirect3D9 interface**](https://msdn.microsoft.com/library/windows/desktop/bb174300) へのポインターを取得し、Direct3D デバイスとスワップ チェーンの構成を制御するさまざまなパラメーターを指定しました。 それを実行する前に、[**GetDeviceCaps**](https://msdn.microsoft.com/library/windows/desktop/dd144877) を呼び出して、デバイスが実行できない処理を求めていないことを確認しました。

Direct3D 9

```cpp
UINT32 AdapterOrdinal = 0;
D3DDEVTYPE DeviceType = D3DDEVTYPE_HAL;
D3DCAPS9 caps;
m_pD3D->GetDeviceCaps(AdapterOrdinal, DeviceType, &caps); // caps bits

D3DPRESENT_PARAMETERS params;
ZeroMemory(&params, sizeof(D3DPRESENT_PARAMETERS));

// Swap chain parameters:
params.hDeviceWindow = m_hWnd;
params.AutoDepthStencilFormat = D3DFMT_D24X8;
params.BackBufferFormat = D3DFMT_X8R8G8B8;
params.MultiSampleQuality = D3DMULTISAMPLE_NONE;
params.MultiSampleType = D3DMULTISAMPLE_NONE;
params.SwapEffect = D3DSWAPEFFECT_DISCARD;
params.Windowed = true;
params.PresentationInterval = 0;
params.BackBufferCount = 2;
params.BackBufferWidth = 0;
params.BackBufferHeight = 0;
params.EnableAutoDepthStencil = true;
params.Flags = 2;

m_pD3D->CreateDevice(
    0,
    D3DDEVTYPE_HAL,
    m_hWnd,
    64,
    &params,
    &m_pd3dDevice
    );
```

Direct3D 11 では、デバイス コンテキストとグラフィックス インフラストラクチャはデバイス自体とは別と見なされます。 初期化は複数の手順に分かれます。

まず、デバイスを作成します。 デバイスでサポートしている機能レベルの一覧を取得します。これにより、GPU に関する必要な情報がほとんどわかります。 また、Direct3D にアクセスするためだけに、インターフェイスを作成する必要がありません。 代わりに、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) コア API を使います。 これにより、デバイスへのハンドルとデバイスのイミディエイト コンテキストが提供されます。 デバイス コンテキストは、パイプラインの状態を設定し、レンダリング コマンドを生成するために使われます。

Direct3D 11 デバイスとコンテキストを作成すると、COM のポインター機能を利用して、最新バージョンのインターフェイスを取得できます。このインターフェイスには追加機能が含まれているため、常に取得することをお勧めします。

> **注**   D3D\_機能\_レベル\_9\_(2.0 のシェーダー モデルに対応) する 1 は、Microsoft Store ゲームがサポートするために必要な最小のレベル。 (9 をサポートしていない場合、ゲームの ARM のパッケージの証明が失敗する\_1)。かどうかは、ゲームにも、シェーダー モデル 3 の機能のレンダリング パスが含まれています、D3D を含める必要があります\_機能\_レベル\_9\_配列内の 3。

 

Direct3D 11

```cpp
// This flag adds support for surfaces with a different color channel 
// ordering than the API default. It is required for compatibility with
// Direct2D.
UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)
// If the project is in a debug build, enable debugging via SDK Layers.
creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

// This example only uses feature level 9.1.
D3D_FEATURE_LEVEL featureLevels[] = 
{
    D3D_FEATURE_LEVEL_9_1
};

// Create the Direct3D 11 API device object and a corresponding context.
ComPtr<ID3D11Device> device;
ComPtr<ID3D11DeviceContext> context;
D3D11CreateDevice(
    nullptr, // Specify nullptr to use the default adapter.
    D3D_DRIVER_TYPE_HARDWARE,
    nullptr,
    creationFlags,
    featureLevels,
    ARRAYSIZE(featureLevels),
    D3D11_SDK_VERSION, // UWP apps must set this to D3D11_SDK_VERSION.
    &device, // Returns the Direct3D device created.
    nullptr,
    &context // Returns the device immediate context.
    );

// Store pointers to the Direct3D 11.2 API device and immediate context.
device.As(&m_d3dDevice);

context.As(&m_d3dContext);
```

## <a name="create-a-swap-chain"></a>スワップ チェーンの作成


Direct3D 11 には、DirectX Graphics Infrastructure (DXGI) と呼ばれるデバイス API が含まれています。 DXGI インターフェイスを使うと、(たとえば、) スワップ チェーンを構成する方法を制御し、共有デバイスを設定できます。 Direct3D の初期化のこの手順では、DXGI を使って、スワップ チェーンを作成します。 デバイスを作成しているため、インターフェイス チェーンに従って DXGI アダプターに戻ることができます。

Direct3D デバイスでは、DXGI の COM インターフェイスを実装します。 最初に、そのインターフェイスを取得し、それを使って、デバイスをホストしている DXGI アダプターを要求する必要があります。 次に、DXGI アダプターを使って、DXGI ファクトリを作成します。

> **注**   COM インターフェイスのうち、最初の応答が使用することがありますので[ **QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521)します。 しかし、代わりに、[**Microsoft::WRL::ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) スマート ポインターを使ってください。 次に、[**As()**](https://msdn.microsoft.com/library/windows/apps/br230426.aspx) メソッドを呼び出して、適切なインターフェイスの種類の空の COM ポインターを提供します。

 

**Direct3d11**

```cpp
ComPtr<IDXGIDevice2> dxgiDevice;
m_d3dDevice.As(&dxgiDevice);

// Then, the adapter hosting the device;
ComPtr<IDXGIAdapter> dxgiAdapter;
dxgiDevice->GetAdapter(&dxgiAdapter);

// Then, the factory that created the adapter interface:
ComPtr<IDXGIFactory2> dxgiFactory;
dxgiAdapter->GetParent(
    __uuidof(IDXGIFactory2),
    &dxgiFactory
    );
```

DXGI ファクトリを作成したので、それを使って、スワップ チェーンを作成できます。 スワップ チェーンのパラメーターを定義します。 画面の形式を指定する必要があります選択します[ **DXGI\_形式\_B8G8R8A8\_UNORM** ](https://msdn.microsoft.com/library/windows/desktop/bb173059) Direct2D との互換性があるためです。 画面のスケーリング、マルチサンプリング、ステレオ レンダリングは、この例では使わないため、オフにします。 CoreWindow で直接実行するため、幅と高さを 0 に設定したままにし、全画面の値を自動的に取得できます。

> **注**  常にセット、 *SDKVersion* D3D11 パラメーター\_SDK\_UWP アプリのバージョン。

 

**Direct3d11**

```cpp
ComPtr<IDXGISwapChain1> swapChain;
dxgiFactory->CreateSwapChainForCoreWindow(
    m_d3dDevice.Get(),
    reinterpret_cast<IUnknown*>(window),
    &swapChainDesc,
    nullptr,
    &swapChain
    );
swapChain.As(&m_swapChain);
```

画面に表示できる実際よりもより多くの場合、レンダリングは確実に、1 を使用してフレームの待機時間を設定します[ **DXGI\_スワップ\_効果\_反転\_シーケンシャル**](https://msdn.microsoft.com/library/windows/desktop/bb173077). これにより、電力が節約されます。また、これはストアの認定の要件です。このチュートリアルのパート 2 では、画面への表示について詳しく説明します。

> **注**  を使用することができますマルチ スレッド (たとえば、 [ **ThreadPool** ](https://msdn.microsoft.com/library/windows/apps/br229642)作業項目) レンダリング スレッドがブロックされている間に他の作業を続行します。

 

**Direct3d11**

```cpp
dxgiDevice->SetMaximumFrameLatency(1);
```

これで、レンダリングのためにバック バッファーを設定できるようになりました。

## <a name="configure-the-back-buffer-as-a-render-target"></a>レンダー ターゲットとしてのバック バッファーの構成


最初に、バック バッファーへのハンドルを取得する必要があります  (注: バック バッファーが、DXGI スワップ チェーンによって所有されている DirectX 9 で Direct3D デバイスによって所有されている一方です。)レンダー ターゲットを作成して、レンダー ターゲットとして使用する Direct3D デバイスを説明し、*ビュー*バック バッファーを使用します。

**Direct3d11**

```cpp
ComPtr<ID3D11Texture2D> backBuffer;
m_swapChain->GetBuffer(
    0,
    __uuidof(ID3D11Texture2D),
    &backBuffer
    );

// Create a render target view on the back buffer.
m_d3dDevice->CreateRenderTargetView(
    backBuffer.Get(),
    nullptr,
    &m_renderTargetView
    );
```

これでデバイス コンテキストが使えるようになりました。 デバイス コンテキスト インターフェイスを使って、新しく作成したレンダー ターゲット ビューを使うように Direct3D に指示します。 ウィンドウ全体をビューポートとしてターゲットにできるように、バック バッファーの幅と高さを取得します。 バック バッファーはスワップ チェーンに関連付けられています。そのため、ウィンドウ サイズが変更された場合 (ユーザーがゲーム ウィンドウを別のモニターにドラッグした場合など) は、バック バッファーのサイズを変更し、一部の設定をやり直す必要があります。

**Direct3d11**

```cpp
D3D11_TEXTURE2D_DESC backBufferDesc = {0};
backBuffer->GetDesc(&backBufferDesc);

CD3D11_VIEWPORT viewport(
    0.0f,
    0.0f,
    static_cast<float>(backBufferDesc.Width),
    static_cast<float>(backBufferDesc.Height)
    );

m_d3dContext->RSSetViewports(1, &viewport);
```

デバイス ハンドルと全画面のレンダー ターゲットを作成したので、ジオメトリを読み込み、描画する準備ができました。 引き続き[パート 2。レンダリング](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)します。

 

 




