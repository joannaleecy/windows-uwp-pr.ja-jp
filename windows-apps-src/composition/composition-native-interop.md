---
author: jwmsft
ms.assetid: 16ad97eb-23f1-0264-23a9-a1791b4a5b95
title: コンポジションのネイティブ相互運用
description: Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイスが用意されています。
ms.author: jimwalk
ms.date: 06/22/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3c5ba97e8e4a3f875e3afbc5a9067ab19b34a35d
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6470970"
---
# <a name="composition-native-interoperation-with-directx-and-direct2d"></a>コンポジションでの DirectX と Direct2D のネイティブ相互運用

Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイス、[**ICompositorInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620068)、[**ICompositionDrawingSurfaceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620058)、[**ICompositionGraphicsDeviceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620065) が用意されています。

ネイティブ相互運用は、DirectX テクスチャに対応するサーフェス オブジェクトを中心に構成されています。 サーフェスは [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) というファクトリ オブジェクトから作成されます。 このオブジェクトは、サーフェスへのビデオ メモリの割り当てに使う Direct2D または Direct3D デバイス オブジェクトに対応します。 コンポジション API により DirectX デバイスが作成されることはありません。 このオブジェクトを作成して **CompositionGraphicsDevice** オブジェクトに渡すのは、アプリケーションの担当です。 アプリケーションは一度に複数の **CompositionGraphicsDevice** オブジェクトを作成できます。複数の **CompositionGraphicsDevice** オブジェクトにレンダリング デバイスと同じ DirectX デバイスを使ってもかまいません。

## <a name="creating-a-surface"></a>サーフェスの作成

各 [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) はサーフェスのファクトリとして機能します。 各サーフェスは初期サイズ (0,0 の場合もあり) で作成されますが、有効ピクセル数はありません。 その初期状態のサーフェスはすぐに、ビジュアル オブジェクト ツリーで、たとえば [**CompositionSurfaceBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589415) と [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) によって使えますが、その初期状態のサーフェスは画面出力に影響を与えません。 このサーフェスは、指定したアルファ モードが "不透明" であったとしても、すべての用途で完全に透明です。

場合によっては、DirectX デバイスが使えなくなっています。 この状態になるのは、特に、アプリケーションから特定の DirectX API に無効な引数が渡された場合、グラフィック アダプターがシステムによってリセットされた場合、またはドライバーが更新された場合です。 Direct3D には、非同期的にデバイスが何らかの理由で失われているかどうかの検出に、アプリケーションが使える API があります。 DirectX デバイスが失われている場合、アプリケーションはそのデバイスを破棄した後、新しいデバイスを作成し、問題のある DirectX デバイスに関連付けられていた [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) オブジェクトすべてに渡す必要があります。

## <a name="loading-pixels-into-a-surface"></a>サーフェスへのピクセルの読み込み

サーフェスにピクセルを読み込むために、アプリケーションは [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) メソッドを呼び出す必要があります。このメソッドが、アプリケーションの要求に応じて、テクスチャや Direct2D のコンテキストを表す DirectX インターフェイスを返します。 アプリケーションはそのテクスチャにピクセルをレンダリングまたはアップロードする必要があります。 その操作が終了したら、アプリケーションは [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) メソッドを呼び出す必要があります。 その時点でのみ新しいピクセルはコンポジションに使えますが、次にビジュアル オブジェクト ツリーへのすべての変更がコミットされるまで、まだ画面には表示されません。 **EndDraw** が呼び出される前に、ビジュアル オブジェクト ツリーがコミットされた場合、進行中の更新は画面に表示されず、サーフェスには引き続き **BeginDraw** の前の内容が表示されます。 **EndDraw** が呼び出されると、BeginDraw によって返されたテクスチャや Direct2D コンテキスト ポインターは無効化されます。 アプリケーションは **EndDraw** の呼び出し後にそのポインターをキャッシュすることはありません。

アプリケーションは、どの [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) に対しても、一度に 1 つのサーフェスでのみ BeginDraw を呼び出すことができます。 [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) を呼び出した後、アプリケーションはそのサーフェスで [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) を呼び出してから、別のサーフェスで **BeginDraw** を呼び出す必要があります。 API がアジャイルであるため、アプリケーションは、複数のワーカー スレッドからレンダリングを実行する場合、これらの呼び出しの同期を担当します。 アプリケーションが一時的にあるサーフェスのレンダリングを中断し、別のサーフェスに切り替える場合、アプリケーションは [**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx) メソッドを使えます。 これにより、別の **BeginDraw** は成功しますが、画面上のコンポジションに対する最初のサーフェスの更新はできなくなります。 これにより、アプリケーションはトランザクション方式で複数の更新を行えます。 サーフェスが中断されたら、アプリケーションは [**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062) メソッドを呼び出して更新を続けるか、**EndDraw** を呼び出して更新の終了を宣言できます。 つまり、どの **CompositionGraphicsDevice** に対しても、一度に 1 つのサーフェスのみをアクティブに更新できます。 各グラフィックス デバイスはそれぞれ独立してこの状態を保つため、2 つのサーフェスが異なるグラフィックス デバイスに属していれば、アプリケーションはそれらのサーフェスに同時にレンダリングできます。 ただしその結果、これらの 2 つのサーフェス用のビデオ メモリが一緒にプールされなくなるため、メモリの使用効率は下がります。

アプリケーションが間違った操作を実行した場合、[**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx)、[**SuspendDraw**](https://msdn.microsoft.com/library/windows/apps/mt620064.aspx)、[**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062)、[**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の各メソッドはエラーを返します (無効な引数を渡した場合や、あるサーフェスで **EndDraw** を呼び出す前に、別のサーフェスで **BeginDraw** を呼び出した場合など)。 この種のエラーはアプリケーションのバグを表します。たとえば "fail fast" を使って処理される可能性があります。 DirectX デバイスが失われた場合も、**BeginDraw** はエラーを返すことがあります。 アプリケーションが DirectX デバイスを再作成して再試行できるため、このエラーは致命的ではありません。 このように、アプリケーションでは単にレンダリングをスキップすることで、デバイスが失われた場合に対処する必要があります。 **BeginDraw** が失敗した場合、それがどのような理由であっても、アプリケーションが **EndDraw** を呼び出さないようにしてください。最初の時点で失敗した描画開始が成功することはないためです。

## <a name="scrolling"></a>スクロール

パフォーマンス上の理由から、アプリケーションが [**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx) を呼び出すとき、返されるテクスチャの内容がサーフェスの前の内容であるとは限りません。 アプリケーションでは、内容がランダムであることを想定して、確実にすべてのピクセルがタッチされるようにする必要があります。そのためには、レンダリング前にサーフェスをクリアするか、更新された四角形全体を十分に埋められる不透明なコンテンツを描画します。 また、テクスチャ ポインターが **BeginDraw** と [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の呼び出し間でのみ有効であることも相まって、アプリケーションはサーフェスから前の内容をコピーできません。 この理由から、[**Scroll**](https://msdn.microsoft.com/library/windows/apps/mt620063) メソッドが用意されています。このメソッドを使うと、アプリケーションは同じサーフェスでピクセルをコピーできるようになります。

## <a name="usage-example"></a>使用例

次のコード例は、相互運用のシナリオを示しています。 例では、相互運用性のヘッダーと DirectWrite の COM ベースと Direct2D Api を使用してテキストを表示するコードからの種類と共に Windows コンポジションでの Windows ランタイムに基づくサーフェス領域からの種類を結合します。 例では、これらのテクノロジの間の相互運用にシームレスに[**BeginDraw**](https://msdn.microsoft.com/library/windows/apps/mt620059.aspx)と[**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060)を使用します。 例では、DirectWrite を使用して、テキストがレイアウトし、Direct2D を使ってレンダリングします。 コンポジション グラフィックス デバイスは初期化時に直接 Direct2D デバイスを受け取ります。 これにより、アプリケーションを作成して、Direct2D コンテキストを各描画操作で返される ID3D11Texture2D インターフェイスをラップするよりもかなり効率的は**ID2D1DeviceContext**インターフェイス ポインターを返す**BeginDraw**できます。

次の 2 つのコード例があります。 最初に、 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)の例 (これが完了すると)、し、c++/cli CX のコード例 (の例では、DirectWrite and Direct2D の部分を省略する)。

C++ を使用する/WinRT 以下のコード例は最初に、新規作成**コア アプリ (、C++/WinRT)** Visual Studio でプロジェクト (要件については、次を参照してください。 [、C++、Visual Studio サポート/WinRT、と VSIX](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt#visual-studio-support-for-cwinrt-and-the-vsix))。 プロジェクトを作成する際に、ターゲット バージョン**Windows 10 バージョン 1803 (10.0; として選択します。ビルド 17134)** します。 および対象となるこのコードが組み込まれているテストのバージョンです。 内容を置き換える、`App.cpp`し、以下に示すコードをソース コード ファイルをビルドして実行します。 アプリケーションのレンダリング、文字列「こんにちは, World!」 で透明の背景に黒のテキスト。

```cppwinrt
// App.cpp
//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH 
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//*********************************************************

#include "pch.h"

#include <D2d1_1.h>
#include <D3d11_4.h>
#include <Dwrite.h>
#include <Windows.Graphics.DirectX.Direct3D11.interop.h>
#include <Windows.ui.composition.interop.h>
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Graphics.DirectX.h>
#include <winrt/Windows.Graphics.DirectX.Direct3D11.h>
#include <winrt/Windows.UI.Composition.h>

using namespace winrt;
using namespace winrt::Windows::ApplicationModel::Core;
using namespace winrt::Windows::Foundation;
using namespace winrt::Windows::Foundation::Numerics;
using namespace winrt::Windows::Graphics::DirectX;
using namespace winrt::Windows::Graphics::DirectX::Direct3D11;
using namespace winrt::Windows::UI;
using namespace winrt::Windows::UI::Composition;
using namespace winrt::Windows::UI::Core;

namespace abi
{
    using namespace ABI::Windows::Foundation;
    using namespace ABI::Windows::Graphics::DirectX;
    using namespace ABI::Windows::UI::Composition;
}

// An app-provided helper to render lines of text.
struct SampleText
{
    SampleText(winrt::com_ptr<::IDWriteTextLayout> const& text, CompositionGraphicsDevice const& compositionGraphicsDevice) :
        m_text(text),
        m_compositionGraphicsDevice(compositionGraphicsDevice)
    {
        // Create the surface just big enough to hold the formatted text block.
        DWRITE_TEXT_METRICS metrics;
        winrt::check_hresult(m_text->GetMetrics(&metrics));
        winrt::Windows::Foundation::Size surfaceSize{ metrics.width, metrics.height };

        CompositionDrawingSurface drawingSurface{ m_compositionGraphicsDevice.CreateDrawingSurface(
            surfaceSize,
            DirectXPixelFormat::B8G8R8A8UIntNormalized,
            DirectXAlphaMode::Premultiplied) };

        // Cache the interop pointer, since that's what we always use.
        m_drawingSurfaceInterop = drawingSurface.as<abi::ICompositionDrawingSurfaceInterop>();

        // Draw the text
        DrawText();

        // If the rendering device is lost, the application will recreate and replace it. We then
        // own redrawing our pixels.
        m_deviceReplacedEventToken = m_compositionGraphicsDevice.RenderingDeviceReplaced(
            [this](CompositionGraphicsDevice const&, RenderingDeviceReplacedEventArgs const&)
        {
            // Draw the text again.
            DrawText();
            return S_OK;
        });
    }

    ~SampleText()
    {
        m_compositionGraphicsDevice.RenderingDeviceReplaced(m_deviceReplacedEventToken);
    }

    // Return the underlying surface to the caller.
    auto Surface()
    {
        // To the caller, the fact that we have a drawing surface is an implementation detail.
        // Return the base interface instead.
        return m_drawingSurfaceInterop.as<ICompositionSurface>();
    }

private:
    // The text to draw.
    winrt::com_ptr<::IDWriteTextLayout> m_text;

    // The composition surface that we use in the visual tree.
    winrt::com_ptr<abi::ICompositionDrawingSurfaceInterop> m_drawingSurfaceInterop;

    // The device that owns the surface.
    CompositionGraphicsDevice m_compositionGraphicsDevice{ nullptr };
    //winrt::com_ptr<abi::ICompositionGraphicsDevice> m_compositionGraphicsDevice2;

    // For managing our event notifier.
    winrt::event_token m_deviceReplacedEventToken;

    // We may detect device loss on BeginDraw calls. This helper handles this condition or other
    // errors.
    bool CheckForDeviceRemoved(HRESULT hr)
    {
        if (hr == S_OK)
        {
            // Everything is fine: go ahead and draw.
            return true;
        }

        if (hr == DXGI_ERROR_DEVICE_REMOVED)
        {
            // We can't draw at this time, but this failure is recoverable. Just skip drawing for
            // now. We will be asked to draw again once the Direct3D device is recreated.
            return false;
        }

        // Any other error is unexpected and, therefore, fatal.
        winrt::check_hresult(hr);
        return true;
    }

    // Renders the text into our composition surface
    void DrawText()
    {
        // Begin our update of the surface pixels. If this is our first update, we are required
        // to specify the entire surface, which nullptr is shorthand for (but, as it works out,
        // any time we make an update we touch the entire surface, so we always pass nullptr).
        winrt::com_ptr<::ID2D1DeviceContext> d2dDeviceContext;
        POINT offset;
        if (CheckForDeviceRemoved(m_drawingSurfaceInterop->BeginDraw(nullptr,
            __uuidof(ID2D1DeviceContext), d2dDeviceContext.put_void(), &offset)))
        {
            d2dDeviceContext->Clear(D2D1::ColorF(D2D1::ColorF::Black, 0.f));

            // Create a solid color brush for the text. A more sophisticated application might want
            // to cache and reuse a brush across all text elements instead, taking care to recreate
            // it in the event of device removed.
            winrt::com_ptr<::ID2D1SolidColorBrush> brush;
            winrt::check_hresult(d2dDeviceContext->CreateSolidColorBrush(
                D2D1::ColorF(D2D1::ColorF::Black, 1.0f), brush.put()));

            // Draw the line of text at the specified offset, which corresponds to the top-left
            // corner of our drawing surface. Notice we don't call BeginDraw on the D2D device
            // context; this has already been done for us by the composition API.
            d2dDeviceContext->DrawTextLayout(D2D1::Point2F((float)offset.x, (float)offset.y), m_text.get(),
                brush.get());

            // Our update is done. EndDraw never indicates rendering device removed, so any
            // failure here is unexpected and, therefore, fatal.
            winrt::check_hresult(m_drawingSurfaceInterop->EndDraw());
        }
    }
};

struct DeviceLostEventArgs
{
    DeviceLostEventArgs(IDirect3DDevice const& device) : m_device(device) {}
    IDirect3DDevice Device() { return m_device; }
    static DeviceLostEventArgs Create(IDirect3DDevice const& device) { return DeviceLostEventArgs{ device }; }

private:
    IDirect3DDevice m_device;
};

struct DeviceLostHelper
{
    DeviceLostHelper() = default;

    ~DeviceLostHelper()
    {
        StopWatchingCurrentDevice();
        m_onDeviceLostHandler = nullptr;
    }

    IDirect3DDevice CurrentlyWatchedDevice() { return m_device; }

    void WatchDevice(winrt::com_ptr<::IDXGIDevice> const& dxgiDevice)
    {
        // If we're currently listening to a device, then stop.
        StopWatchingCurrentDevice();

        // Set the current device to the new device.
        m_device = nullptr;
        winrt::check_hresult(::CreateDirect3D11DeviceFromDXGIDevice(dxgiDevice.get(), reinterpret_cast<::IInspectable**>(winrt::put_abi(m_device))));

        // Get the DXGI Device.
        m_dxgiDevice = dxgiDevice;

        // QI For the ID3D11Device4 interface.
        winrt::com_ptr<::ID3D11Device4> d3dDevice{ m_dxgiDevice.as<::ID3D11Device4>() };

        // Create a wait struct.
        m_onDeviceLostHandler = nullptr;
        m_onDeviceLostHandler = ::CreateThreadpoolWait(DeviceLostHelper::OnDeviceLost, (PVOID)this, nullptr);

        // Create a handle and a cookie.
        m_eventHandle = ::CreateEvent(nullptr, false, false, nullptr);
        winrt::check_bool(bool{ m_eventHandle });
        m_cookie = 0;

        // Register for device lost.
        ::SetThreadpoolWait(m_onDeviceLostHandler, m_eventHandle.get(), nullptr);
        winrt::check_hresult(d3dDevice->RegisterDeviceRemovedEvent(m_eventHandle.get(), &m_cookie));
    }

    void StopWatchingCurrentDevice()
    {
        if (m_dxgiDevice)
        {
            // QI For the ID3D11Device4 interface.
            auto d3dDevice{ m_dxgiDevice.as<::ID3D11Device4>() };

            // Unregister from the device lost event.
            ::CloseThreadpoolWait(m_onDeviceLostHandler);
            d3dDevice->UnregisterDeviceRemoved(m_cookie);

            // Clear member variables.
            m_onDeviceLostHandler = nullptr;
            m_eventHandle.close();
            m_cookie = 0;
            m_device = nullptr;
        }
    }

    void DeviceLost(winrt::delegate<DeviceLostHelper const*, DeviceLostEventArgs const&> const& handler)
    {
        m_deviceLost = handler;
    }

    winrt::delegate<DeviceLostHelper const*, DeviceLostEventArgs const&> m_deviceLost;

private:
    void RaiseDeviceLostEvent(IDirect3DDevice const& oldDevice)
    {
        m_deviceLost(this, DeviceLostEventArgs::Create(oldDevice));
    }

    static void CALLBACK OnDeviceLost(PTP_CALLBACK_INSTANCE /* instance */, PVOID context, PTP_WAIT /* wait */, TP_WAIT_RESULT /* waitResult */)
    {
        auto deviceLostHelper = reinterpret_cast<DeviceLostHelper*>(context);
        auto oldDevice = deviceLostHelper->m_device;
        deviceLostHelper->StopWatchingCurrentDevice();
        deviceLostHelper->RaiseDeviceLostEvent(oldDevice);
    }

private:
    IDirect3DDevice m_device;
    winrt::com_ptr<::IDXGIDevice> m_dxgiDevice;
    PTP_WAIT m_onDeviceLostHandler{ nullptr };
    winrt::handle m_eventHandle;
    DWORD m_cookie{ 0 };
};

struct SampleApp : implements<SampleApp, IFrameworkViewSource, IFrameworkView>
{
    IFrameworkView CreateView()
    {
        return *this;
    }

    void Initialize(CoreApplicationView const &)
    {
    }

    // Run once when the application starts up
    void Initialize()
    {
        // Create a Direct2D device.
        CreateDirect2DDevice();

        // To create a composition graphics device, we need to QI for another interface
        winrt::com_ptr<abi::ICompositorInterop> compositorInterop{ m_compositor.as<abi::ICompositorInterop>() };

        // Create a graphics device backed by our D3D device
        winrt::com_ptr<abi::ICompositionGraphicsDevice> compositionGraphicsDeviceIface;
        winrt::check_hresult(compositorInterop->CreateGraphicsDevice(
            m_d2dDevice.get(),
            compositionGraphicsDeviceIface.put()));
        m_compositionGraphicsDevice = compositionGraphicsDeviceIface.as<CompositionGraphicsDevice>();
    }

    void Load(hstring const&)
    {
    }

    void Uninitialize()
    {
    }

    void Run()
    {
        CoreWindow window = CoreWindow::GetForCurrentThread();
        window.Activate();

        CoreDispatcher dispatcher = window.Dispatcher();
        dispatcher.ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
    }

    void SetWindow(CoreWindow const& window)
    {
        m_compositor = Compositor{};
        m_target = m_compositor.CreateTargetForCurrentView();
        ContainerVisual root = m_compositor.CreateContainerVisual();
        m_target.Root(root);

        Initialize();

        winrt::check_hresult(
            ::DWriteCreateFactory(
                DWRITE_FACTORY_TYPE_SHARED,
                __uuidof(m_dWriteFactory),
                reinterpret_cast<::IUnknown**>(m_dWriteFactory.put())
            )
        );

        winrt::check_hresult(
            m_dWriteFactory->CreateTextFormat(
                L"Segoe UI",
                nullptr,
                DWRITE_FONT_WEIGHT_REGULAR,
                DWRITE_FONT_STYLE_NORMAL,
                DWRITE_FONT_STRETCH_NORMAL,
                36.f,
                L"en-US",
                m_textFormat.put()
            )
        );

        Rect windowBounds{ window.Bounds() };
        std::wstring text{ L"Hello, World!" };

        winrt::check_hresult(
            m_dWriteFactory->CreateTextLayout(
                text.c_str(),
                (uint32_t)text.size(),
                m_textFormat.get(),
                windowBounds.Width,
                windowBounds.Height,
                m_textLayout.put()
            )
        );

        Visual textVisual{ CreateVisualFromTextLayout(m_textLayout) };
        textVisual.Size({ windowBounds.Width, windowBounds.Height });
        root.Children().InsertAtTop(textVisual);
    }

    // Called when Direct3D signals the device lost event.
    void OnDirect3DDeviceLost(DeviceLostHelper const* /* sender */, DeviceLostEventArgs const& /* args */)
    {
        // Create a new Direct2D device.
        CreateDirect2DDevice();

        // Restore our composition graphics device to good health.
        winrt::com_ptr<abi::ICompositionGraphicsDeviceInterop> compositionGraphicsDeviceInterop{ m_compositionGraphicsDevice.as<abi::ICompositionGraphicsDeviceInterop>() };
        winrt::check_hresult(compositionGraphicsDeviceInterop->SetRenderingDevice(m_d2dDevice.get()));
    }

    // Create a surface that is asynchronously filled with an image
    ICompositionSurface CreateSurfaceFromTextLayout(winrt::com_ptr<::IDWriteTextLayout> const& text)
    {
        // Create our wrapper object that will handle downloading and decoding the image (assume
        // throwing new here).
        SampleText textSurface{ text, m_compositionGraphicsDevice };

        // The caller is only interested in the underlying surface.
        return textSurface.Surface();
    }

    // Create a visual that holds an image.
    Visual CreateVisualFromTextLayout(winrt::com_ptr<::IDWriteTextLayout> const& text)
    {
        // Create a sprite visual
        SpriteVisual spriteVisual{ m_compositor.CreateSpriteVisual() };

        // The sprite visual needs a brush to hold the image.
        CompositionSurfaceBrush surfaceBrush{
            m_compositor.CreateSurfaceBrush(CreateSurfaceFromTextLayout(text))
        };

        // Associate the brush with the visual.
        CompositionBrush brush{ surfaceBrush.as<CompositionBrush>() };
        spriteVisual.Brush(brush);

        // Return the visual to the caller as an IVisual.
        return spriteVisual;
    }

private:
    CompositionTarget m_target{ nullptr };
    Compositor m_compositor{ nullptr };
    winrt::com_ptr<::ID2D1Device> m_d2dDevice;
    winrt::com_ptr<::IDXGIDevice> m_dxgiDevice;
    //winrt::com_ptr<abi::ICompositionGraphicsDevice> m_compositionGraphicsDevice;
    CompositionGraphicsDevice m_compositionGraphicsDevice{ nullptr };
    std::vector<SampleText> m_textSurfaces;
    DeviceLostHelper m_deviceLostHelper;
    winrt::com_ptr<::IDWriteFactory> m_dWriteFactory;
    winrt::com_ptr<::IDWriteTextFormat> m_textFormat;
    winrt::com_ptr<::IDWriteTextLayout> m_textLayout;


    // This helper creates a Direct2D device, and registers for a device loss
    // notification on the underlying Direct3D device. When that notification is
    // raised, the OnDirect3DDeviceLost method is called.
    void CreateDirect2DDevice()
    {
        uint32_t createDeviceFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

        // Array with DirectX hardware feature levels in order of preference.
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
        winrt::com_ptr<::ID3D11Device> d3DDevice;
        winrt::com_ptr<::ID3D11DeviceContext> d3DImmediateContext;
        D3D_FEATURE_LEVEL d3dFeatureLevel{ D3D_FEATURE_LEVEL_9_1 };

        winrt::check_hresult(
            ::D3D11CreateDevice(
                nullptr, // Default adapter.
                D3D_DRIVER_TYPE_HARDWARE,
                0, // Not asking for a software driver, so not passing a module to one.
                createDeviceFlags, // Set debug and Direct2D compatibility flags.
                featureLevels,
                ARRAYSIZE(featureLevels),
                D3D11_SDK_VERSION,
                d3DDevice.put(),
                &d3dFeatureLevel,
                d3DImmediateContext.put()
            )
        );

        // Initialize Direct2D resources.
        D2D1_FACTORY_OPTIONS d2d1FactoryOptions{ D2D1_DEBUG_LEVEL_NONE };

        // Initialize the Direct2D Factory.
        winrt::com_ptr<::ID2D1Factory1> d2D1Factory;
        winrt::check_hresult(
            ::D2D1CreateFactory(
                D2D1_FACTORY_TYPE_SINGLE_THREADED,
                __uuidof(d2D1Factory),
                &d2d1FactoryOptions,
                d2D1Factory.put_void()
            )
        );

        // Create the Direct2D device object.
        // Obtain the underlying DXGI device of the Direct3D device.
        m_dxgiDevice = d3DDevice.as<::IDXGIDevice>();

        m_d2dDevice = nullptr;
        winrt::check_hresult(
            d2D1Factory->CreateDevice(m_dxgiDevice.get(), m_d2dDevice.put())
        );

        m_deviceLostHelper.WatchDevice(m_dxgiDevice);
        m_deviceLostHelper.DeviceLost({ this, &SampleApp::OnDirect3DDeviceLost });
    }
};

int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    CoreApplication::Run(SampleApp());
}
```

```cpp
//------------------------------------------------------------------------------
//
// Copyright (C) Microsoft. All rights reserved.
//
//------------------------------------------------------------------------------

#include "stdafx.h"

using namespace Microsoft::WRL;
using namespace Windows::Foundation;
using namespace Windows::Graphics::DirectX;
using namespace Windows::UI::Composition;

// This is an app-provided helper to render lines of text
class SampleText
{
private:
    // The text to draw
    ComPtr<IDWriteTextLayout> _text;

    // The composition surface that we use in the visual tree
    ComPtr<ICompositionDrawingSurfaceInterop> _drawingSurfaceInterop;

    // The device that owns the surface
    ComPtr<ICompositionGraphicsDevice> _compositionGraphicsDevice;

    // For managing our event notifier
    EventRegistrationToken _deviceReplacedEventToken;

public:
    SampleText(IDWriteTextLayout* text, ICompositionGraphicsDevice* compositionGraphicsDevice) :
        _text(text),
        _compositionGraphicsDevice(compositionGraphicsDevice)
    {
        // Create the surface just big enough to hold the formatted text block.
        DWRITE_TEXT_METRICS metrics;
        FailFastOnFailure(text->GetMetrics(&metrics));
        Windows::Foundation::Size surfaceSize = { metrics.width, metrics.height };
        ComPtr<ICompositionDrawingSurface> drawingSurface;
        FailFastOnFailure(_compositionGraphicsDevice->CreateDrawingSurface(
            surfaceSize,
            DirectXPixelFormat::DirectXPixelFormat_B8G8R8A8UIntNormalized,
            DirectXAlphaMode::DirectXAlphaMode_Ignore,
            &drawingSurface));

        // Cache the interop pointer, since that's what we always use.
        FailFastOnFailure(drawingSurface.As(&_drawingSurfaceInterop));

        // Draw the text
        DrawText();

        // If the rendering device is lost, the application will recreate and replace it. We then
        // own redrawing our pixels.
        FailFastOnFailure(_compositionGraphicsDevice->add_RenderingDeviceReplaced(
            Callback<RenderingDeviceReplacedEventHandler>([this](
                ICompositionGraphicsDevice* source, IRenderingDeviceReplacedEventArgs* args)
                -> HRESULT
            {
                // Draw the text again
                DrawText();
                return S_OK;
            }).Get(),
            &_deviceReplacedEventToken));
    }

    ~SampleText()
    {
        FailFastOnFailure(_compositionGraphicsDevice->remove_RenderingDeviceReplaced(
            _deviceReplacedEventToken));
    }

    // Return the underlying surface to the caller
    ComPtr<ICompositionSurface> get_Surface()
    {
        // To the caller, the fact that we have a drawing surface is an implementation detail.
        // Return the base interface instead
        ComPtr<ICompositionSurface> surface;
        FailFastOnFailure(_drawingSurfaceInterop.As(&surface));
        return surface;
    }

private:
    // We may detect device loss on BeginDraw calls. This helper handles this condition or other
    // errors.
    bool CheckForDeviceRemoved(HRESULT hr)
    {
        if (SUCCEEDED(hr))
        {
            // Everything is fine -- go ahead and draw
            return true;
        }
        else if (hr == DXGI_ERROR_DEVICE_REMOVED)
        {
            // We can't draw at this time, but this failure is recoverable. Just skip drawing for
            // now. We will be asked to draw again once the Direct3D device is recreated
            return false;
        }
        else
        {
            // Any other error is unexpected and, therefore, fatal
            FailFast();
        }
    }

    // Renders the text into our composition surface
    void DrawText()
    {
        // Begin our update of the surface pixels. If this is our first update, we are required
        // to specify the entire surface, which nullptr is shorthand for (but, as it works out,
        // any time we make an update we touch the entire surface, so we always pass nullptr).
        ComPtr<ID2D1DeviceContext> d2dDeviceContext;
        POINT offset;
        if (CheckForDeviceRemoved(_drawingSurfaceInterop->BeginDraw(nullptr,
            __uuidof(ID2D1DeviceContext), &d2dDeviceContext, &offset)))
        {
            // Create a solid color brush for the text. A more sophisticated application might want
            // to cache and reuse a brush across all text elements instead, taking care to recreate
            // it in the event of device removed.
            ComPtr<ID2D1SolidColorBrush> brush;
            FailFastOnFailure(d2dDeviceContext->CreateSolidColorBrush(
                D2D1::ColorF(D2D1::ColorF::Black, 1.0f), &brush));

            // Draw the line of text at the specified offset, which corresponds to the top-left
            // corner of our drawing surface. Notice we don't call BeginDraw on the D2D device
            // context; this has already been done for us by the composition API.
            d2dDeviceContext->DrawTextLayout(D2D1::Point2F(offset.x, offset.y), _text.Get(),
                brush.Get());

            // Our update is done. EndDraw never indicates rendering device removed, so any
            // failure here is unexpected and, therefore, fatal.
            FailFastOnFailure(_drawingSurfaceInterop->EndDraw());
        }
    }
};

class SampleApp
{
    ComPtr<ICompositor> _compositor;
    ComPtr<ID2D1Device> _d2dDevice;
    ComPtr<ICompositionGraphicsDevice> _compositionGraphicsDevice;
    std::vector<ComPtr<SampleText>> _textSurfaces;

public:
    // Run once when the application starts up
    void Initialize(ICompositor* compositor)
    {
        // Cache the compositor (created outside of this method)
        _compositor = compositor;

        // Create a Direct2D device (helper implementation not shown here)
        FailFastOnFailure(CreateDirect2DDevice(&_d2dDevice));

        // To create a composition graphics device, we need to QI for another interface
        ComPtr<ICompositorInterop> compositorInterop;
        FailFastOnFailure(_compositor.As(&compositorInterop));

        // Create a graphics device backed by our D3D device
        FailFastOnFailure(compositorInterop->CreateGraphicsDevice(
            _d2dDevice.Get(),
            &_compositionGraphicsDevice));
    }

    // Called when Direct3D signals the device lost event
    void OnDirect3DDeviceLost()
    {
        // Create a new device
        FailFastOnFailure(CreateDirect2DDevice(_d2dDevice.ReleaseAndGetAddressOf()));

        // Restore our composition graphics device to good health
        ComPtr<ICompositionGraphicsDeviceInterop> compositionGraphicsDeviceInterop;
        FailFastOnFailure(_compositionGraphicsDevice.As(&compositionGraphicsDeviceInterop));
        FailFastOnFailure(compositionGraphicsDeviceInterop->SetRenderingDevice(_d2dDevice.Get()));
    }

    // Create a surface that is asynchronously filled with an image
    ComPtr<ICompositionSurface> CreateSurfaceFromTextLayout(IDWriteTextLayout* text)
    {
        // Create our wrapper object that will handle downloading and decoding the image (assume
        // throwing new here)
        SampleText* textSurface = new SampleText(text, _compositionGraphicsDevice.Get());

        // Keep our image alive
        _textSurfaces.push_back(textSurface);

        // The caller is only interested in the underlying surface
        return textSurface->get_Surface();
    }

    // Create a visual that holds an image
    ComPtr<IVisual> CreateVisualFromTextLayout(IDWriteTextLayout* text)
    {
        // Create a sprite visual
        ComPtr<ISpriteVisual> spriteVisual;
        FailFastOnFailure(_compositor->CreateSpriteVisual(&spriteVisual));

        // The sprite visual needs a brush to hold the image
        ComPtr<ICompositionSurfaceBrush> surfaceBrush;
        FailFastOnFailure(_compositor->CreateSurfaceBrushWithSurface(
            CreateSurfaceFromTextLayout(text).Get(),
            &surfaceBrush));

        // Associate the brush with the visual
        ComPtr<ICompositionBrush> brush;
        FailFastOnFailure(surfaceBrush.As(&brush));
        FailFastOnFailure(spriteVisual->put_Brush(brush.Get()));

        // Return the visual to the caller as the base class
        ComPtr<IVisual> visual;
        FailFastOnFailure(spriteVisual.As(&visual));

        return visual;
    }

private:
    // This helper (implementation not shown here) creates a Direct2D device and registers
    // for a device loss notification on the underlying Direct3D device. When that notification is
    // raised, assume the OnDirect3DDeviceLost method is called.
    HRESULT CreateDirect2DDevice(ID2D1Device** ppDevice);
};
```
