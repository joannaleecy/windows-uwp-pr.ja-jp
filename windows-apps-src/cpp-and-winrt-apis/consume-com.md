---
author: stevewhims
description: このトピックでは、Direct2D の完全なコード例を使用して、C++ を使用する方法を示して/WinRT COM クラスとインターフェイスを利用します。
title: C++/WinRT での COM コンポーネントの使用
ms.author: stwhi
ms.date: 07/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、COM、コンポーネント、クラス、インターフェイス
ms.localizationpriority: medium
ms.openlocfilehash: 8af5a8149faab3bece62e4da5d41138aaede16e7
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4355213"
---
# <a name="consume-com-components-with-cwinrt"></a>C++/WinRT での COM コンポーネントの使用

機能を使用する、 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)ライブラリを DirectX Api の高パフォーマンスの 2-d および 3-D グラフィックスなどの COM コンポーネントを使用します。 C++/cli/winrt はパフォーマンスを損なうことがなく、DirectX を使用する最も簡単な方法です。 このトピックでは、Direct2D のコード例を使用して、C++ を使用する方法を示して/WinRT COM クラスとインターフェイスを利用します。 もちろん、内で、同じ C + COM と Windows ランタイムのプログラミングを混在させることができます/WinRT プロジェクトです。

このトピックの最後に、最小限の Direct2D アプリケーションの完全なソース コードの登録情報がわかります。 そのコードからの抜粋を放したし、それらを使用すると、COM コンポーネントを使用して、C++ を使用する方法を説明します + C + のさまざまな機能を使用して WinRT/WinRT ライブラリ。

## <a name="com-smart-pointers-winrtcomptruwpcpp-ref-for-winrtcom-ptr"></a>COM のスマート ポインター ([**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr))

Com プログラミングする (つまりのバック グラウンドでの Windows ランタイム Api では、COM の進化したものである場合は true も) オブジェクトではなく、インターフェイスを直接操作します。 COM クラスで関数を呼び出す、たとえば、アクティブ化する、クラス、インターフェイスを取得し、そのインターフェイスの関数を呼び出します。 オブジェクトの状態にアクセスするにしない直接アクセスする、データ メンバーです。代わりに、インターフェイスのアクセサーとミューテーター関数を呼び出します。

具体的には、インターフェイス*ポインター*を操作について説明しています。 、そのことのメリット c++ COM スマート ポインターの種類の存在と/WinRT&mdash; [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)型です。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
```

上記のコードは、 [**ID2D1Factory1**](https://msdn.microsoft.com/library/Hh404596) COM インターフェイスへの初期化されていないスマート ポインターを宣言する方法を示しています。 (いないポイント インターフェイスにまったく)、実際のオブジェクトに属する**ID2D1Factory1**インターフェイスをポイントされていないため、スマート ポインターは初期化されていません。 これを行う可能性があります。COM 参照カウントを指すインターフェイスの所有するオブジェクトの有効期間を管理して、そのインターフェイスの関数を呼び出す中に経由する機能を備えて (いるスマート ポインター)。

## <a name="com-functions-that-return-an-interface-pointer-as-void"></a>**Void**としてインターフェイス ポインターを返す COM 関数

初期化されていないのスマート ポインターの生のポインターを基になるに書き込む[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)関数を呼び出すことができます。

```cppwinrt
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    &options,
    factory.put_void()
);
```

上記のコードは、最後のパラメーターを介して**ID2D1Factory1**インターフェイス ポインターを返す[**D2D1CreateFactory**](/windows/desktop/api/d2d1/nf-d2d1-d2d1createfactory)関数を呼び出し、 **void\ * \ *** の種類。 COM 関数の多くを返す、 **void\ * \ *** します。 このような関数に示す[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を使用します。

## <a name="com-functions-that-return-a-specific-interface-pointer"></a>特定のインターフェイス ポインターを返す COM 関数

[**D3D11CreateDevice**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数では、 [**ID3D11Device**](https://msdn.microsoft.com/library/Hh404596)インターフェイス ポインターを返しますがその antepenultimate パラメーターを介して**ID3D11Device\ * \ *** の種類。 そのような特定のインターフェイス ポインターを返す関数では、 [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)を使用します。

```cppwinrt
winrt::com_ptr<ID3D11Device> device;
D3D11CreateDevice(
    ...
    device.put(),
    ...);
```

前にこのセクションのコード例は、生**D2D1CreateFactory**関数を呼び出す方法を示しています。 実際には、このトピックのコード例では、 **D2D1CreateFactory**を呼び出し、生の API をラップするヘルパー関数テンプレートを使用し、ためのコード例は、 [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)実際を使用します。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    options,
    factory.put());
```

## <a name="com-functions-that-return-an-interface-pointer-as-iunknown"></a>**IUnknown**としてインターフェイス ポインターを返す COM 関数

[**DWriteCreateFactory**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数は、 [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509)型には、最後のパラメーターを介して DirectWrite ファクトリのインターフェイス ポインターを返します。 このような関数の場合は、使用[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)が解釈へのキャストを**IUnknown**します。

```cppwinrt
DWriteCreateFactory(
    DWRITE_FACTORY_TYPE_SHARED,
    __uuidof(dwriteFactory2),
    reinterpret_cast<IUnknown**>(dwriteFactory2.put()));
```

## <a name="re-seat-a-winrtcomptr"></a>**Winrt::com_ptr**を再シートします。

> [!IMPORTANT]
> 既に取り付けられている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうか (その内部の生のポインターが既にターゲット) し、再シートを別のオブジェクトを指す場合、最初に割り当てる必要があります`nullptr`を&mdash;次のコード例に示すようにします。 ない場合は、し、既に取り付けられている**com_ptr**描画問題 ( [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を呼び出す) と、注意をによって、内部のポインターが null でないことをアサートします。

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

COM 関数から返された HRESULT の値をチェックして例外をスローするエラー コードを表すこと、 [**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)を呼び出します。

```cppwinrt
winrt::check_hresult(D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    options,
    factory.put_void()));
```

## <a name="com-functions-that-take-a-specific-interface-pointer"></a>特定のインターフェイス ポインターを受け取る COM 関数

同じ種類の特定のインターフェイス ポインターを受け取る関数に渡すと、 **com_ptr** [**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function)関数を呼び出すことができます。

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

## <a name="com-functions-that-take-an-iunknown-interface-pointer"></a>**IUnknown**インターフェイス ポインターを受け取る COM 関数

**IUnknown**インターフェイス ポインターを受け取る関数に渡すと、 **com_ptr**に[**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)自由関数を呼び出すことができます。

```cppwinrt
winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
    ...
    winrt::get_unknown(CoreWindow::GetForCurrentThread()),
    ...));
```

## <a name="passing-and-returning-com-smart-pointers"></a>スマート ポインターを渡すことと、COM を返す

**Winrt::com_ptr**の形式で COM スマート ポインターを受ける関数な定数の参照または参照。

```cppwinrt
... GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device) ...

... CreateDevice(..., winrt::com_ptr<ID3D11Device>& device) ...
```

**Winrt::com_ptr**を返す関数で行ってください値。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> CreateFactory() ...
```

## <a name="query-a-com-smart-pointer-for-a-different-interface"></a>さまざまなインターフェイスの COM スマート ポインターを照会します。

[**Com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)関数を使用すると、さまざまなインターフェイスの COM スマート ポインターを照会します。 関数は、クエリが成功しない場合に例外をスローします。

```cppwinrt
void ExampleFunction(winrt::com_ptr<ID3D11Device> const& device)
{
    ...
    winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };
    ...
}
```

また、 [**com_ptr::try_as**](/uwp/cpp-ref-for-winrt/com-ptr#comptrtryas-function)、に対してチェックできる数値を返します。 これを使用して`nullptr`クエリが成功したかどうかを確認します。

## <a name="full-source-code-listing-of-a-minimal-direct2d-application"></a>Direct2D アプリケーションを最小限の完全なソース コードの一覧

ビルドして Visual Studio で、このソース コード例、最初を実行する場合は、作成、新しい**コア アプリ (、C++/WinRT)** します。 `Direct2D` プロジェクトの適切な名前ですが、どのようなという名前ことができます。 開いている`App.cpp`、その内容全体を削除し、以下のリストを貼り付けます。

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

        WINRT_TRACE("Draw %.2f x %.2f @ %.2f\n", size.width, size.height, m_dpi);
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

## <a name="working-with-com-types-such-as-bstr-and-variant"></a>BSTR や VARIANT など、COM 型の操作

わかるように、C + + WinRT の両方を実装して、COM インターフェイスの呼び出しのサポートを提供します。 BSTR バリアントなどの COM 型の使用は常に (適切な Api) と共に、生の形式でそれらを使用するオプション。 または、[アクティブなテンプレート ライブラリ (ATL)](/cpp/atl/active-template-library-atl-concepts)などのフレームワークまたは Visual C コンパイラの[COM のサポート](/cpp/cpp/compiler-com-support)、または独自のラッパーによっても提供されているラッパーを使用することができます。

## <a name="important-apis"></a>重要な API
* [winrt::check_hresult 関数](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [winrt::com_ptr 構造体テンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)
