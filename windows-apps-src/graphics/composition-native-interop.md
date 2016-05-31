---
author: scottmill
ms.assetid: 16ad97eb-23f1-0264-23a9-a1791b4a5b95
title: BeginDraw と EndDraw によるコンポジションでの DirectX と Direct2D のネイティブ相互運用
description: Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイスが用意されています。
---
# BeginDraw と EndDraw によるコンポジションでの DirectX と Direct2D のネイティブ相互運用

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

Windows.UI.Composition API には、コンテンツをコンポジターに直接移行できるようにするネイティブの相互運用インターフェイス、[**ICompositorInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620068)、[**ICompositionDrawingSurfaceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620058)、[**ICompositionGraphicsDeviceInterop**](https://msdn.microsoft.com/library/windows/apps/Mt620065) が用意されています。

ネイティブ相互運用は、DirectX テクスチャに対応するサーフェス オブジェクトを中心に構成されています。 サーフェスは [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) というファクトリ オブジェクトから作成されます。 このオブジェクトは、サーフェスへのビデオ メモリの割り当てに使う Direct2D または Direct3D デバイス オブジェクトに対応します。 コンポジション API により DirectX デバイスが作成されることはありません。 このオブジェクトを作成して **CompositionGraphicsDevice** オブジェクトに渡すのは、アプリケーションの担当です。 アプリケーションは一度に複数の **CompositionGraphicsDevice** オブジェクトを作成できます。複数の **CompositionGraphicsDevice** オブジェクトにレンダリング デバイスと同じ DirectX デバイスを使ってもかまいません。

## サーフェスの作成

各 [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) はサーフェスのファクトリとして機能します。 各サーフェスは初期サイズ (0,0 の場合もあり) で作成されますが、有効ピクセル数はありません。 その初期状態のサーフェスはすぐに、ビジュアル オブジェクト ツリーで、たとえば [**CompositionSurfaceBrush**](https://msdn.microsoft.com/library/windows/apps/Mt589415) と [**SpriteVisual**](https://msdn.microsoft.com/library/windows/apps/Mt589433) によって使えますが、その初期状態のサーフェスは画面出力に影響を与えません。 このサーフェスは、指定したアルファ モードが "不透明" であったとしても、すべての用途で完全に透明です。

場合によっては、DirectX デバイスが使えなくなっています。 この状態になるのは、特に、アプリケーションから特定の DirectX API に無効な引数が渡された場合、グラフィック アダプターがシステムによってリセットされた場合、またはドライバーが更新された場合です。 Direct3D には、非同期的にデバイスが何らかの理由で失われているかどうかの検出に、アプリケーションが使える API があります。 DirectX デバイスが失われている場合、アプリケーションはそのデバイスを破棄した後、新しいデバイスを作成し、問題のある DirectX デバイスに関連付けられていた [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) オブジェクトすべてに渡す必要があります。

## サーフェスへのピクセルの読み込み

サーフェスにピクセルを読み込むために、アプリケーションは [**BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620059.aspx) メソッドを呼び出す必要があります。このメソッドが、アプリケーションの要求に応じて、テクスチャや Direct2D のコンテキストを表す DirectX インターフェイスを返します。 アプリケーションはそのテクスチャにピクセルをレンダリングまたはアップロードする必要があります。 その操作が終了したら、アプリケーションは [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) メソッドを呼び出す必要があります。 その時点でのみ新しいピクセルはコンポジションに使えますが、次にビジュアル オブジェクト ツリーへのすべての変更がコミットされるまで、まだ画面には表示されません。 **EndDraw** が呼び出される前に、ビジュアル オブジェクト ツリーがコミットされた場合、進行中の更新は画面に表示されず、サーフェスには引き続き **BeginDraw** の前の内容が表示されます。 **EndDraw** が呼び出されると、BeginDraw によって返されたテクスチャや Direct2D コンテキスト ポインターは無効化されます。 アプリケーションは **EndDraw** の呼び出し後にそのポインターをキャッシュすることはありません。

アプリケーションは、どの [**CompositionGraphicsDevice**](https://msdn.microsoft.com/library/windows/apps/Dn706749) に対しても、一度に 1 つのサーフェスでのみ BeginDraw を呼び出すことができます。 [
            **BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620059.aspx) を呼び出した後、アプリケーションはそのサーフェスで [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) を呼び出してから、別のサーフェスで **BeginDraw** を呼び出す必要があります。 API がアジャイルであるため、アプリケーションは、複数のワーカー スレッドからレンダリングを実行する場合、これらの呼び出しの同期を担当します。 アプリケーションが一時的にあるサーフェスのレンダリングを中断し、別のサーフェスに切り替える場合、アプリケーションは [**SuspendDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620064.aspx) メソッドを使えます。 これにより、別の **BeginDraw** は成功しますが、画面上のコンポジションに対する最初のサーフェスの更新はできなくなります。 これにより、アプリケーションはトランザクション方式で複数の更新を行えます。 サーフェスが中断されたら、アプリケーションは [**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062) メソッドを呼び出して更新を続けるか、**EndDraw** を呼び出して更新の終了を宣言できます。 つまり、どの **CompositionGraphicsDevice** に対しても、一度に 1 つのサーフェスのみをアクティブに更新できます。 各グラフィックス デバイスはそれぞれ独立してこの状態を保つため、2 つのサーフェスが異なるグラフィックス デバイスに属していれば、アプリケーションはそれらのサーフェスに同時にレンダリングできます。 ただしその結果、これらの 2 つのサーフェス用のビデオ メモリが一緒にプールされなくなるため、メモリの使用効率は下がります。

アプリケーションが間違った操作を実行した場合、[**BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620059.aspx)、[**SuspendDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620064.aspx)、[**ResumeDraw**](https://msdn.microsoft.com/library/windows/apps/mt620062)、[**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の各メソッドはエラーを返します (無効な引数を渡した場合や、あるサーフェスで **EndDraw** を呼び出す前に、別のサーフェスで **BeginDraw** を呼び出した場合など)。 この種のエラーはアプリケーションのバグを表します。たとえば "fail fast" を使って処理される可能性があります。 DirectX デバイスが失われた場合も、**BeginDraw** はエラーを返すことがあります。 アプリケーションが DirectX デバイスを再作成して再試行できるため、このエラーは致命的ではありません。 このように、アプリケーションでは単にレンダリングをスキップすることで、デバイスが失われた場合に対処する必要があります。 **BeginDraw** が失敗した場合、それがどのような理由であっても、アプリケーションが **EndDraw** を呼び出さないようにしてください。最初の時点で失敗した描画開始が成功することはないためです。

## スクロール

パフォーマンス上の理由から、アプリケーションが [**BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620059.aspx) を呼び出すとき、返されるテクスチャの内容がサーフェスの前の内容であるとは限りません。 アプリケーションでは、内容がランダムであることを想定して、確実にすべてのピクセルがタッチされるようにする必要があります。そのためには、レンダリング前にサーフェスをクリアするか、更新された四角形全体を十分に埋められる不透明なコンテンツを描画します。 また、テクスチャ ポインターが **BeginDraw** と [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) の呼び出し間でのみ有効であることも相まって、アプリケーションはサーフェスから前の内容をコピーできません。 この理由から、[**Scroll**](https://msdn.microsoft.com/library/windows/apps/mt620063) メソッドが用意されています。このメソッドを使うと、アプリケーションは同じサーフェスでピクセルをコピーできるようになります。

## 使用例

次のサンプルでは、アプリケーションが描画サーフェスを作成する簡単なシナリオを示しており、[**BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/apps/mt620059.aspx) と [**EndDraw**](https://msdn.microsoft.com/library/windows/apps/mt620060) を使ってサーフェスにテキストを読み込みます。 アプリケーションは次のように、テキストを DirectWrite を使ってレイアウトし、Direct2D を使ってレンダリングします。 コンポジション グラフィックス デバイスは初期化時に直接 Direct2D デバイスを受け取ります。 これにより、**BeginDraw** は ID2D1DeviceContext インターフェイス ポインターを返すことができます。この方法は、アプリケーションが Direct2D コンテキストを作成して、返される ID3D11Texture2D インターフェイスを各描画操作でラップするよりも、かなり効率的です。

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

 

 






<!--HONumber=May16_HO2-->


