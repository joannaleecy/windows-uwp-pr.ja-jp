---
author: stevewhims
description: このトピックでは、完全な Direct2D コード例を使用して、C キーを使用する方法を示す +/WinRT COM クラスとインターフェイスを使用します。
title: DirectX と C + では、その他の COM Api を利用する +/WinRT
ms.author: stwhi
ms.date: 07/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c、cpp、winrt、インターフェイス、COM、コンポーネント、クラス
ms.localizationpriority: medium
ms.openlocfilehash: b87eb90ed5ecf731cc851e81e81ad016956e5fea
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2837094"
---
# <a name="consume-directx-and-other-com-apis-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>DirectX およびその他の COM Api を消費[C + +/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

C キーの機能を使用する +/WinRT ライブラリ DirectX Api のハイ パフォーマンス 2-d と 3-D グラフィックなど、COM コンポーネントを使用します。 C + +/WinRT が最も簡単な方法は、パフォーマンスを損なうことがなく、DirectX を使用します。 このトピックでは、Direct2D の例を使用して、C キーを使用する方法を示す +/WinRT COM クラスとインターフェイスを使用します。 内で同じの C + COM および Windows ランタイムのプログラミングを混在させる、もちろん、+/WinRT プロジェクト。

このトピックの最後には、最低限 Direct2D アプリケーションの完全なソース コードの一覧が表示されます。 ここではそのコードからの抜粋を取り出し、C キーを使用して、COM コンポーネントを使用する方法を説明するために使用される +/C + のさまざまな機能を使用して WinRT +/WinRT ライブラリします。

## <a name="com-smart-pointers-winrtcomptruwpcpp-ref-for-winrtcom-ptr"></a>COM スマート ポインター ([**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr))

Com プログラムするには、(の COM の進化には、Windows ランタイム Api の行われる場合は true も) オブジェクトではなく、インターフェイスを直接を操作します。 COM クラスで関数を呼び出す、たとえば、アクティブにする、クラス、インターフェイスを取得し、そのインターフェイスで関数を呼び出します。 オブジェクトの状態にアクセスするにはしない、データ メンバーに直接アクセスします。代わりに、インターフェイスのアクセサーおよびミューテーターの関数を呼び出します。

具体的には、*ポインター*のインターフェイスの操作について話しています。 および C + COM スマート ポインターの種類の有無によるメリットは、+/WinRT&mdash; [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)入力します。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
```

上記のコードでは、 [**ID2D1Factory1**](https://msdn.microsoft.com/library/Hh404596) COM インターフェイスへの初期化されていないスマート ポインターを宣言する方法を示します。 スマート ポインターは (いないをポイントのインターフェイスをまったく)、実際のオブジェクトに属している**ID2D1Factory1**インターフェイスをポイントされていないために、初期化されていません。 これを行う可能性があります。あり (スマート ポインターされている) COM 参照カウント] をポイントするインターフェイスの所有するオブジェクトの有効期間を管理して、そのインターフェイスで関数を呼び出す中で機能します。

## <a name="com-functions-that-return-an-interface-pointer-as-void"></a>COM 関数としてインターフェイス ポインターを返す**void\ * \ ***

書き込みを初期化されていないスマート ポインターの生のポインターを基になる[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)関数を呼び出すことができます。

```cppwinrt
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    &options,
    factory.put_void()
);
```

上記のコードを**ID2D1Factory1**インターフェイス ポインターを返すには、最後のパラメーターを使用して[**D2D1CreateFactory**](/windows/desktop/api/d2d1/nf-d2d1-d2d1createfactory)関数を呼び出し、 **void\ * \ *** 入力します。 COM 関数の多くを返す、 **void\ * \ *** します。 このような機能に[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を使用します。

## <a name="com-functions-that-return-a-specific-interface-pointer"></a>特定のインターフェイスのポインターを返す COM 関数

[**D3D11CreateDevice**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)返します[**ID3D11Device**](https://msdn.microsoft.com/library/Hh404596)インターフェイス ポインターには、antepenultimate パラメーターを使って**ID3D11Device\ * \ *** 入力します。 このような特定のインターフェイスのポインターを返す関数、 [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)を使用します。

```cppwinrt
winrt::com_ptr<ID3D11Device> device;
D3D11CreateDevice(
    ...
    device.put(),
    ...);
```

前に、のセクションで、コードの例では、生**D2D1CreateFactory**関数を呼び出す方法を示します。 実際には、このトピックの例では、 **D2D1CreateFactory**を呼び出し、生 API をラップするヘルパー関数テンプレートが使用されているし、実際に使用[**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)をコードの例。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> factory;
D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    options,
    factory.put());
```

## <a name="com-functions-that-return-an-interface-pointer-as-iunknown"></a>COM 関数としてインターフェイス ポインターを返す**IUnknown\ * \ ***

[**DWriteCreateFactory**](/windows/desktop/api/dwrite/nf-dwrite-dwritecreatefactory)関数では、DirectWrite ファクトリ インターフェイス ポインターを返しますが、最後のパラメーターを使って**IUnknown\ * \ *** 入力します。 [**Com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)を使用して、このような関数が解釈キャストする**IUnknown\ * \ *** します。

```cppwinrt
DWriteCreateFactory(
    DWRITE_FACTORY_TYPE_SHARED,
    __uuidof(dwriteFactory2),
    reinterpret_cast<IUnknown**>(dwriteFactory2.put()));
```

## <a name="re-seat-a-winrtcomptr"></a>の**winrt::com_ptr**をもう一度接続します。

> [!IMPORTANT]
> 既に固定されている[**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr)があるかどうかは (その内部生ポインターは既にターゲット) し、もう一度、別のオブジェクトを指すように固定する、まずを割り当てる必要があります`nullptr`に&mdash;コード例を次に示すようにします。 ない場合は、[既に固定**com_ptr**は描画問題 ( [**com_ptr::put**](/uwp/cpp-ref-for-winrt/com-ptr#comptrput-function)または[**com_ptr::put_void**](/uwp/cpp-ref-for-winrt/com-ptr#comptrputvoid-function)を呼び出す) 場合は、対応するによって、その内部ポインターが null でないことを表明します。

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

、COM 関数から返される HRESULT の値をチェックして、エラー コードを表すこと例外、 [**winrt::check_hresult**](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)を呼び出します。

```cppwinrt
winrt::check_hresult(D2D1CreateFactory(
    D2D1_FACTORY_TYPE_SINGLE_THREADED,
    __uuidof(factory),
    options,
    factory.put_void()));
```

## <a name="com-functions-that-take-a-specific-interface-pointer"></a>特定のインターフェイスのポインターを受け取る COM 関数

関数に渡す、 **com_ptr**同じ種類の特定のインターフェイス ポインターを移動できるように[**com_ptr::get**](/uwp/cpp-ref-for-winrt/com-ptr#comptrget-function)関数を呼び出すことができます。

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

関数に渡す、 **com_ptr** 、 **IUnknown**インターフェイス ポインターを移動するには、 [**winrt::get_unknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#getunknown-function)無料関数を呼び出すことができます。

```cppwinrt
winrt::check_hresult(factory->CreateSwapChainForCoreWindow(
    ...
    winrt::get_unknown(CoreWindow::GetForCurrentThread()),
    ...));
```

## <a name="passing-and-returning-com-smart-pointers"></a>渡すかどうかと、COM を返すスマート ポインター

関数**winrt::com_ptr**を表す COM スマート ポインターを取得する必要がありますように、定数の参照、または参照します。

```cppwinrt
... GetDxgiFactory(winrt::com_ptr<ID3D11Device> const& device) ...

... CreateDevice(..., winrt::com_ptr<ID3D11Device>& device) ...
```

の**winrt::com_ptr**を返す関数で行ってください] の値。

```cppwinrt
winrt::com_ptr<ID2D1Factory1> CreateFactory() ...
```

## <a name="query-a-com-smart-pointer-for-a-different-interface"></a>クエリの異なるインターフェイスの COM スマート ポインター

[**Com_ptr::as**](/uwp/cpp-ref-for-winrt/com-ptr#comptras-function)関数を使用すると、別のインターフェイスの COM スマート ポインターのクエリを実行します。 クエリが正常に完了しない場合は、例外を関数します。

```cppwinrt
void ExampleFunction(winrt::com_ptr<ID3D11Device> const& device)
{
    ...
    winrt::com_ptr<IDXGIDevice> const dxdevice{ device.as<IDXGIDevice>() };
    ...
}
```

または、 [**com_ptr::try_as**](/uwp/cpp-ref-for-winrt/com-ptr#comptrtryas-function)をチェックすることができる値を返すを使用して`nullptr`をクエリが成功したかどうかを確認します。

## <a name="full-source-code-listing-of-a-minimal-direct2d-application"></a>最低限 Direct2D アプリケーションの完全なソース コード

作成し、Visual Studio でこのソース コードの例、最初を実行する場合は、作成する新しい**コア アプリ (C + +/WinRT)** します。 `Direct2D` 適切なプロジェクトの名前ですが、どのようなという名前ことができます。 開いている`App.cpp`、その内容全体を削除し、以下のリストを貼り付けます。

```cppwinrt
#include "pch.h"

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

## <a name="important-apis"></a>重要な API
* [winrt::check_hresult](/uwp/cpp-ref-for-winrt/error-handling/check-hresult)
* [winrt::com_ptr](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)
