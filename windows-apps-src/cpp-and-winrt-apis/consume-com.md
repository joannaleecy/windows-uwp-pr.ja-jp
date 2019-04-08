---
description: このトピックでは、完全な Direct2D コードの例を使用し、C++/WinRT を使って COM クラスとインターフェイスを利用する方法を示します。
title: C++/WinRT での COM コンポーネントの使用
ms.date: 07/23/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、COM、コンポーネント、クラス、インターフェイス
ms.localizationpriority: medium
ms.openlocfilehash: 129477689e12de2634b422a0fc4487b283e3bf03
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644807"
---
# <a name="consume-com-components-with-cwinrt"></a>C++/WinRT での COM コンポーネントの使用

機能を使用することができます、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) DirectX Api のパフォーマンスの高い、2-d および 3-D グラフィックスなどの COM コンポーネントを使用するライブラリ。 C +/cli WinRT はパフォーマンスを損なうことがなく、DirectX を使用する最も簡単な方法です。 このトピックでは、Direct2D のコード例を使用して、C + を使用する方法について説明/cli WinRT の COM クラスとインターフェイスを使用します。 同じの C + 内での COM および Windows ランタイム プログラミングを混在させることができます、もちろん、/cli WinRT プロジェクト。

このトピックの最後には、最小限の Direct2D アプリケーションの完全なソース コードの一覧があります。 そのコードからの抜粋のリフトが C + を使用して COM コンポーネントを使用する方法を説明するために使用され/cli WinRT C + のさまざまな機能を使用して/cli WinRT ライブラリ。

## <a name="com-smart-pointers-winrtcomptruwpcpp-ref-for-winrtcom-ptr"></a>COM スマート ポインター ([**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr))

COM をプログラムするオブジェクト (つまり、また、バック グラウンドでの Windows ランタイム Api では、COM の進化したものである場合は true) ではなく、インターフェイスを直接操作します。 COM クラスの関数を呼び出すにはたとえば、アクティブ化する、クラス、インターフェイスを取得し、そのインターフェイスの関数を呼び出します。 オブジェクトの状態にアクセスするにアクセスしないデータ メンバーは直接代わりに、インターフェイスのアクセサーとミューテーター関数を呼び出します。

具体的には、インターフェイスとの対話について話している*ポインター*します。 そのため、c++ COM スマート ポインター型の存在を利点が/cli WinRT&mdash;、 [ **winrt::com_ptr** ](/uwp/cpp-ref-for-winrt/com-ptr)型。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
```

上記のコードに初期化されていないのスマート ポインターを宣言する方法を示しています、 [ **ID2D1Factory1** ](https://msdn.microsoft.com/library/Hh404596) COM インターフェイスです。 まだ指しているために、スマート ポインターに初期化されていません、 **ID2D1Factory1** (それが指していないインターフェイスで)、実際のオブジェクトに属しているインターフェイス。 。 これを行う可能性がありますが、COM 参照カウントを指す、インターフェイスの所有するオブジェクトの有効期間を管理し、そのインターフェイスの関数を呼び出すことで、メディアを使用して機能があります (スマート ポインターをされている)。

## <a name="com-functions-that-return-an-interface-pointer-as-void"></a>としてインターフェイス ポインターを返す COM 関数**void**

呼び出すことができます、 [ **com_ptr::put_void** ](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)初期化されていないのスマート ポインターに書き込む関数には、生のポインターの基になります。

```cppwinrt
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    &options,
    factory.put_void()
);
```

呼び出し前のコード、 [ **D2D1CreateFactory** ](/windows/desktop/api/d2d1/nf-d2d1-d2d1createfactory)を返す関数、 **ID2D1Factory1**インターフェイス ポインターがその最後のパラメーターを使用して**void\* \*** 型。 多くの COM 関数が返す、 **void\*\*** します。 このような関数では、使用[ **com_ptr::put_void** ](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)示すようにします。

## <a name="com-functions-that-return-a-specific-interface-pointer"></a>特定のインターフェイス ポインターを返す COM 関数

[ **D3D11CreateDevice** ](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数が返される、 [ **ID3D11Device** ](https://msdn.microsoft.com/library/Hh404596)がその antepenultimate パラメーターを使用してインターフェイス ポインター**ID3D11Device\* \*** 型。 そのような特定のインターフェイス ポインターを返す関数を使用して[ **com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)します。

```cppwinrt
winrt::com_ptr<ID3D11Device> device;
D3D11CreateDevice(
    ...
    device.put(),
    ...);
```

生の呼び出す方法を示しますこの 1 つ前に、のセクションのコード例**D2D1CreateFactory**関数。 実際には、このトピックのコード例を呼び出すときに**D2D1CreateFactory**生の API をラップするヘルパー関数テンプレートを使用して、コード例が実際に使用するように[ **com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function).

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    options,
    factory.put());
```

## <a name="com-functions-that-return-an-interface-pointer-as-iunknown"></a>としてインターフェイス ポインターを返す COM 関数**IUnknown**

[ **DWriteCreateFactory** ](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数では、DirectWrite ファクトリのインターフェイス ポインターを返しますが、最後のパラメーターを使用して[ **IUnknown** ](https://msdn.microsoft.com/library/windows/desktop/ms680509)型。 このような関数の場合、使用[ **com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)、解釈をキャストするが、 **IUnknown**します。

```cppwinrt
DWriteCreateFactory(
    DWRITE_FACTORY_TYPE_SHARED,
    __uuidof(dwriteFactory2),
    reinterpret_cast<IUnknown**>(dwriteFactory2.put()));
```

## <a name="re-seat-a-winrtcomptr"></a>再度接続クライアント ライセンスを**winrt::com_ptr**

> [!IMPORTANT]
> ある場合、 [ **winrt::com_ptr** ](/uwp/cpp-ref-for-winrt/com-ptr)を既に接続されている (その内部の生のポインターは、ターゲットを既に持って) 再を別のオブジェクトを指す接続クライアント ライセンスするし、最初に割り当てる必要があります`nullptr`&mdash;次のコード例で示すようにします。 ない場合は、既に取り付けられていない**com_ptr**に対処する問題を描画 (を呼び出すと[ **com_ptr::put** ](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[ **com_ptr:。put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)) によって、その内部ポインターが null でないことをアサートします。

```cppwinrt
winrt::com_ptr<ID2D1SolidColorBrush> brush;
...
    brush.put()
...
brush = nullptr; // Important because we're about to re-seat
target->CreateSolidColorBrush(
    color_orange,
    D2D1::BrushProperties(0.8f),
    brush.put()));
```

## <a name="handle-hresult-error-codes"></a>HRESULT エラー コードを処理します。

COM 関数の場合から返された HRESULT の値を確認し、エラー コードを表すことは、例外をスロー、 [ **winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)します。

```cppwinrt
winrt::check_hresult(D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    options,
    factory.put_void()));
```

## <a name="com-functions-that-take-a-specific-interface-pointer"></a>特定のインターフェイス ポインターを使用する COM 関数

呼び出すことができます、 [ **com_ptr::get** ](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function)関数に渡す、 **com_ptr**を同じ型の特定のインターフェイス ポインターを受け取る関数。

```cppwinrt
... ExampleFunction(
    winrt::com_ptr<ID2D1Factory1> const& factory,
    winrt::com_ptr<IDXGIDevice> const& dxdevice)
{
    ...
    winrt::check_hresult(factory->CreateDevice(dxdevice.get(), ...));
    ...
}
```

## <a name="com-functions-that-take-an-iunknown-interface-pointer"></a>COM 関数を受け取る、 **IUnknown**インターフェイス ポインター

呼び出すことができます、 [ **winrt::get_unknown** ](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function) free 関数に渡す、 **com_ptr**を受け取る関数に、 **IUnknown**インターフェイスポインター。

```cppwinrt
winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
    ...
    winrt::get_unknown(CoreWindow::GetForCurrentThread()),
    ...));
```

## <a name="passing-and-returning-com-smart-pointers"></a>受け渡しおよび返却 COM スマート ポインター

形式で COM スマート ポインターを取り込む関数、 **winrt::com_ptr**定数の参照渡しまたは参照渡し、これを実行する必要があります。

```cppwinrt
... GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device) ...

... CreateDevice(..., winrt::com_ptr<ID3D11Device>& device) ...
```

返す関数、 **winrt::com_ptr**値によってこれを行う必要があります。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> CreateFactory() ...
```

## <a name="query-a-com-smart-pointer-for-a-different-interface"></a>別のインターフェイスの COM スマート ポインターをクエリします。

使用することができます、 [ **com_ptr::as** ](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)別のインターフェイスの COM スマート ポインターのクエリを実行する関数。 関数は、クエリが成功しなかった場合、例外をスローします。

```cppwinrt
void ExampleFunction(winrt::com_ptr<ID3D11Device> const& device)
{
    ...
    winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };
    ...
}
```

また、使用して[ **com_ptr::try_as**](/uwp/cpp-ref-for-winrt/com-ptr#comptrtryas-function)、に対して確認できる値を返す`nullptr`にクエリが成功したかどうかを参照してください。

## <a name="full-source-code-listing-of-a-minimal-direct2d-application"></a>Direct2D アプリケーションに最小限の完全なソース コードの一覧

ビルドし、Visual Studio でこのソース コード例、最初を実行する場合は、作成、新しい**Core アプリ (C +/cli WinRT)** します。 `Direct2D` プロジェクトの適切な名前ですが、という名前を好きなデザイン。 開いている`App.cpp`内容をすべてを削除し、以下のリストを貼り付けます。

```cppwinrt
#include "pch.h"
#include <d2d1_1.h>
#include <d3d11.h>
#include <dxgi1_2.h>
#include <winrt/Windows.Graphics.Display.h>

using namespace winrt;

using namespace Windows;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::UI;
using namespace Windows::UI::Core;
using namespace Windows::Graphics::Display;

namespace
{
    winrt::com_ptr<ID2D1Factory1> CreateFactory()
    {
        D2D1_FACTORY_OPTIONS options{};

#ifdef _DEBUG
        options.debugLevel = D2D1_DEBUG_LEVEL_INFORMATION;
#endif

        winrt::com_ptr<ID2D1Factory1> factory;

        winrt::check_hresult(D2D1CreateFactory(
            D2D1_FACTORY_TYPE_SINGLE_THREADED,
            options,
            factory.put()));

        return factory;
    }

    HRESULT CreateDevice(D3D_DRIVER_TYPE const type, winrt::com_ptr<ID3D11Device>& device)
    {
        WINRT_ASSERT(!device);

        return D3D11CreateDevice(
            nullptr,
            type,
            nullptr,
            D3D11_CREATE_DEVICE_BGRA_SUPPORT,
            nullptr, 0,
            D3D11_SDK_VERSION,
            device.put(),
            nullptr,
            nullptr);
    }

    winrt::com_ptr<ID3D11Device> CreateDevice()
    {
        winrt::com_ptr<ID3D11Device> device;
        HRESULT hr{ CreateDevice(D3D_DRIVER_TYPE_HARDWARE, device) };

        if (DXGI_ERROR_UNSUPPORTED == hr)
        {
            hr = CreateDevice(D3D_DRIVER_TYPE_WARP, device);
        }

        winrt::check_hresult(hr);
        return device;
    }

    winrt::com_ptr<ID2D1DeviceContext> CreateRenderTarget(
        winrt::com_ptr<ID2D1Factory1> const& factory,
        winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(factory);
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };

        winrt::com_ptr<ID2D1Device> d2device;
        winrt::check_hresult(factory->CreateDevice(dxdevice.get(), d2device.put()));

        winrt::com_ptr<ID2D1DeviceContext> target;
        winrt::check_hresult(d2device->CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS_NONE, target.put()));
        return target;
    }

    winrt::com_ptr<IDXGIFactory2> GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };

        winrt::com_ptr<IDXGIAdapter> adapter;
        winrt::check_hresult(dxdevice->GetAdapter(adapter.put()));

        winrt::com_ptr<IDXGIFactory2> factory;
        winrt::check_hresult(adapter->GetParent(__uuidof(factory), factory.put_void()));
        return factory;
    }

    void CreateDeviceSwapChainBitmap(
        winrt::com_ptr<IDXGISwapChain1> const& swapchain,
        winrt::com_ptr<ID2D1DeviceContext> const& target)
    {
        WINRT_ASSERT(swapchain);
        WINRT_ASSERT(target);

        winrt::com_ptr<IDXGISurface> surface;
        winrt::check_hresult(swapchain->GetBuffer(0, __uuidof(surface), surface.put_void()));

        D2D1_BITMAP_PROPERTIES1 const props{ D2D1::BitmapProperties1(
            D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS_CANNOT_DRAW,
            D2D1::PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_IGNORE)) };

        winrt::com_ptr<ID2D1Bitmap1> bitmap;

        winrt::check_hresult(target->CreateBitmapFromDxgiSurface(surface.get(),
            props,
            bitmap.put()));

        target->SetTarget(bitmap.get());
    }

    winrt::com_ptr<IDXGISwapChain1> CreateSwapChainForCoreWindow(winrt::com_ptr<ID3D11Device> const& device)
    {
        WINRT_ASSERT(device);

        winrt::com_ptr<IDXGIFactory2> const factory{ GetDxgiFactory(device) };

        DXGI_SWAP_CHAIN_DESC1 props{};
        props.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
        props.SampleDesc.Count = 1;
        props.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
        props.BufferCount = 2;
        props.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;

        winrt::com_ptr<IDXGISwapChain1> swapChain;

        winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
            device.get(),
            winrt::get_unknown(CoreWindow::GetForCurrentThread()),
            &props,
            nullptr, // all or nothing
            swapChain.put()));

        return swapChain;
    }

    constexpr D2D1_COLOR_F color_white{ 1.0f,  1.0f,  1.0f,  1.0f };
    constexpr D2D1_COLOR_F color_orange{ 0.92f,  0.38f,  0.208f,  1.0f };
}

struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    winrt::com_ptr<ID2D1Factory1> m_factory;
    winrt::com_ptr<ID2D1DeviceContext> m_target;
    winrt::com_ptr<IDXGISwapChain1> m_swapChain;
    winrt::com_ptr<ID2D1SolidColorBrush> m_brush;
    float m_dpi{};

    IFrameworkView CreateView()
    {
        return *this;
    }

    void Initialize(CoreApplicationView const&)
    {
    }

    void Load(hstring const&)
    {
        CoreWindow const window{ CoreWindow::GetForCurrentThread() };

        window.SizeChanged([&](auto&&...)
        {
            if (m_target)
            {
                ResizeSwapChainBitmap();
                Render();
            }
        });

        DisplayInformation const display{ DisplayInformation::GetForCurrentView() };
        m_dpi = display.LogicalDpi();

        display.DpiChanged([&](DisplayInformation const& display, IInspectable const&)
        {
            if (m_target)
            {
                m_dpi = display.LogicalDpi();
                m_target->SetDpi(m_dpi, m_dpi);
                CreateDeviceSizeResources();
                Render();
            }
        });

        m_factory = CreateFactory();
        CreateDeviceIndependentResources();
    }

    void Uninitialize()
    {
    }

    void Run()
    {
        CoreWindow const window{ CoreWindow::GetForCurrentThread() };
        window.Activate();

        Render();
        CoreDispatcher const dispatcher{ window.Dispatcher() };
        dispatcher.ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
    }

    void SetWindow(CoreWindow const&) {}

    void Draw()
    {
        m_target->Clear(color_white);

        D2D1_SIZE_F const size{ m_target->GetSize() };
        D2D1_RECT_F const rect{ 100.0f, 100.0f, size.width - 100.0f, size.height - 100.0f };
        m_target->DrawRectangle(rect, m_brush.get(), 100.0f);

        char buffer[1024];
        (void)snprintf(buffer, sizeof(buffer), "Draw %.2f x %.2f @ %.2f\n", size.width, size.height, m_dpi);
        ::OutputDebugStringA(buffer);
    }

    void Render()
    {
        if (!m_target)
        {
            winrt::com_ptr<ID3D11Device> const device{ CreateDevice() };
            m_target = CreateRenderTarget(m_factory, device);
            m_swapChain = CreateSwapChainForCoreWindow(device);

            CreateDeviceSwapChainBitmap(m_swapChain, m_target);

            m_target->SetDpi(m_dpi, m_dpi);

            CreateDeviceResources();
            CreateDeviceSizeResources();
        }

        m_target->BeginDraw();
        Draw();
        m_target->EndDraw();

        HRESULT const hr{ m_swapChain->Present(1, 0) };

        if (S_OK != hr && DXGI_STATUS_OCCLUDED != hr)
        {
            ReleaseDevice();
        }
    }

    void ReleaseDevice()
    {
        m_target = nullptr;
        m_swapChain = nullptr;

        ReleaseDeviceResources();
    }

    void ResizeSwapChainBitmap()
    {
        WINRT_ASSERT(m_target);
        WINRT_ASSERT(m_swapChain);

        m_target->SetTarget(nullptr);

        if (S_OK == m_swapChain->ResizeBuffers(0, // all buffers
            0, 0, // client area
            DXGI_FORMAT_UNKNOWN, // preserve format
            0)) // flags
        {
            CreateDeviceSwapChainBitmap(m_swapChain, m_target);
            CreateDeviceSizeResources();
        }
        else
        {
            ReleaseDevice();
        }
    }

    void CreateDeviceIndependentResources()
    {
    }

    void CreateDeviceResources()
    {
        winrt::check_hresult(m_target->CreateSolidColorBrush(
            color_orange,
            D2D1::BrushProperties(0.8f),
            m_brush.put()));
    }

    void CreateDeviceSizeResources()
    {
    }

    void ReleaseDeviceResources()
    {
        m_brush = nullptr;
    }
};

int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    CoreApplication::Run(App());
}
```

## <a name="working-with-com-types-such-as-bstr-and-variant"></a>BSTR や VARIANT などの COM 型の使用

ご覧のとおり、C +/cli WinRT を実装して、COM インターフェイスを呼び出すことのサポートを提供します。 BSTR や VARIANT などの COM 型の使用が常に (適切な Api) と、未加工の形式で使用するオプション。 など、フレームワークによって提供されるラッパーを使用することもできます、 [Active Template Library (ATL)](/cpp/atl/active-template-library-atl-concepts)、または、Visual C コンパイラの[COM サポート](/cpp/cpp/compiler-com-support)、または独自のラッパーでも。

## <a name="important-apis"></a>重要な API
* [winrt::check_hresult 関数](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [winrt::com_ptr 構造体のテンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)
