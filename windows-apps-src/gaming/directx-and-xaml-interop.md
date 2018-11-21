---
author: mtoepke
title: DirectX と XAML の相互運用機能
description: ユニバーサル Windows プラットフォーム (UWP) ゲームで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。
ms.assetid: 0fb2819a-61ed-129d-6564-0b67debf5c6b
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, XAML の相互運用機能
ms.localizationpriority: medium
ms.openlocfilehash: 7f3a70be3dd31b0a5e4214621ab9fb4efa72cc54
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7437771"
---
# <a name="directx-and-xaml-interop"></a>DirectX と XAML の相互運用機能



ユニバーサル Windows プラットフォーム (UWP) ゲームまたはアプリで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。 XAML と DirectX を組み合わせれば、DirectX でレンダリングしたコンテンツと相互運用できる柔軟なユーザー インターフェイス フレームワークを構築できます。これは、グラフィックスを多用するアプリで特に役立ちます。 ここでは、DirectX を使った UWP アプリの構造について説明し、DirectX と連携する UWP アプリを構築するときに使う重要な型を示します。

アプリが主に 2D レンダリングに重点を置いているときは、[Win2D](https://github.com/microsoft/win2d) Windows ランタイム ライブラリの使用が必要になる場合があります。 このライブラリは Microsoft によって管理されており、コア Direct2D のテクノロジを基盤として構築されています。 2D グラフィックスを実装する使用パターンを大幅に簡略化し、このドキュメントで説明する手法の一部の便利な抽象化が含まれています。 詳しくは、プロジェクトのページをご覧ください。 このドキュメントでは、Win2D を使用*しない*ことを選択したアプリ開発者向けのガイダンスを示します。

> **注:** DirectX Api として定義されていない Windows ランタイム型では、通常では VisualC コンポーネント拡張機能を使用するため (、C++/cli CX) と DirectX の相互運用する XAML UWP コンポーネントを開発します。 また、DirectX の呼び出しを独立した Windows ランタイム メタデータ ファイルにラップすると、C# と DirectX を利用する XAML を使って UWP アプリを作成できます。

 

## <a name="xaml-and-directx"></a>XAML と DirectX

DirectX には、2D と 3D のグラフィックス用に、Direct2D と Microsoft Direct3D という 2 つの強力なライブラリがあります。 XAML でも基本的な 2D のプリミティブと効果はサポートされますが、モデリングやゲームなどの多くのアプリでは、より複雑なグラフィックス サポートが必要になります。 そのようなアプリでは、Direct2D と Direct3D を使ってグラフィックスの一部または全体をレンダリングし、それ以外の部分には XAML を使うことができます。

カスタム XAML と DirectX の相互運用機能を実装する場合は、次の 2 つの概念を理解する必要があります。

-   共有サーフェイス。[Windows::UI::Xaml::Media::ImageSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imagesource.aspx) 型を使って DirectX で間接的に描画を行うことができる、サイズが指定されたディスプレイの領域です。この領域は XAML で定義されます。 共有サーフェイスについては、新しいコンテンツが画面に表示される正確なタイミングを制御する必要はありません。 共有サーフェイスの更新は XAML フレームワークの更新に同期されます。
-   [スワップ チェーン](https://msdn.microsoft.com/library/windows/desktop/bb206356(v=vs.85).aspx)。最小限の待ち時間でグラフィックスを表示するために使用されるバッファーのコレクションを表します。 通常、スワップ チェーンは、UI スレッドとは別に、1 秒あたり 60 フレームで更新されます。 ただし、スワップ チェーンは高速な更新をサポートするために、より多くのメモリと CPU リソースを使用します。また、複数のスレッドを管理する必要があるために使用することが難しくなります。

次に、DirectX を使う目的を確認します。 表示ウィンドウのサイズに収まる 1 つのコントロールを作ったりアニメーション化したりするために使うのか、 ゲームなどのようにリアルタイムでレンダリングして制御する必要がある出力をサーフェイスに表示するのかを確認します。 このような場合は、おそらくスワップ チェーンを実装する必要があります。 それ以外の場合は、共有サーフェイスを使用する方法で問題はありません。

DirectX をどのように使うかを決めたら、目的に応じて次のいずれかの Windows ランタイム型を使って、DirectX のレンダリングを UWP アプリに組み込みます。

-   静的な画像を構成する場合やイベント駆動型の複雑な画像を描画する場合は、[Windows::UI::Xaml::Media::Imaging::SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) を使って共有サーフェイスに描画します。 これは、サイズが指定された DirectX の描画サーフェイスを処理する型です。 通常は、ドキュメントや UI 要素でビットマップとして表示する画像やテクスチャを構成する場合に使います。 この型は、高パフォーマンスのゲームのようなリアルタイムのインタラクティビティには適しません。 **SurfaceImageSource** オブジェクトの更新が XAML ユーザー インターフェイスの更新に同期されるため、フレーム レートが安定しない、リアルタイムの入力に対する応答が遅いなど、ユーザーへの視覚的フィードバックに待ち時間が生じるためです。 ただし、動的なコントロールやデータ シミュレーションであれば、更新に時間はかからず問題ありません。

-   画像が画面上のスペースよりも大きく、ユーザーがパンまたはズームできる場合は、[Windows::UI::Xaml::Media::Imaging::VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) を使います。 これは、画面よりも大きいサイズが指定された DirectX の描画サーフェイスを処理する型です。 [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) と同様に、複雑な画像やコントロールを動的に構成する場合に使います。 また、**SurfaceImageSource** と同様に、高パフォーマンスのゲームには適しません。 **VirtualSurfaceImageSource** を使うことができる XAML 要素には、マップ コントロールや、画像が多い大きなドキュメント ビューアーなどがあります。

-   リアルタイムで更新されるグラフィックスを DirectX を使って表示する場合や、短い待ち時間で定期的に更新を行う必要がある場合は、[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) クラスを使います。これにより、XAML フレームワークの更新タイマーに同期せずにグラフィックスを更新することができます。 この型を使うと、グラフィックス デバイスのスワップ チェーン ([IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631)) に直接アクセスし、XAML をレンダー ターゲットの上に配置できます。 この型は、ゲームなどの全画面の DirectX アプリで XAML ベースのユーザー インターフェイスが必要な場合に便利です。 Microsoft DirectX Graphics Infrastructure (DXGI)、Direct2D、Direct3D も含めて、この方法を使うには、DirectX に関する知識が必要です。 詳しくは、「[Direct3D 11 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ff476345)」をご覧ください。

## <a name="surfaceimagesource"></a>SurfaceImageSource


[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) は、DirectX で描画を行うための共有サーフェイスを提供し、ビットからアプリのコンテンツを構成します。

[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。

1.  [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) コンストラクターに高さと幅の値を渡して、共有サーフェイスのサイズを定義します。 アルファ (不透明度) のサポートが必要かどうかも指定できます。

    次に例を示します。

    `SurfaceImageSource^ surfaceImageSource = ref new SurfaceImageSource(400, 300);`

2.  [ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137) へのポインターを取得します。 [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISurfaceImageSourceNativeWithD2D** 実装を取得します。 この実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。

    ```cpp
    Microsoft::WRL::ComPtr<ISurfaceImageSourceNativeWithD2D> m_sisNativeWithD2D;

    // ...

    IInspectable* sisInspectable = 
        (IInspectable*) reinterpret_cast<IInspectable*>(surfaceImageSource);

    sisInspectable->QueryInterface(
        __uuidof(ISurfaceImageSourceNativeWithD2D), 
        (void **)&m_sisNativeWithD2D);
    ```

3.  最初に [D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) と [D2D1CreateDevice](https://msdn.microsoft.com/library/windows/desktop/hh404272(v=vs.85).aspx) を呼び出してから、デバイスとコンテキストを [ISurfaceImageSourceNativeWithD2D::SetDevice](https://msdn.microsoft.com/library/dn302141.aspx) に渡して、DXGI デバイスと D2D デバイスを作成します。 

    > [!NOTE]
    > バックグラウンド スレッドから **SurfaceImageSource** に描画する場合は、DXGI デバイスでマルチスレッド アクセスも有効になっている必要があります。 この有効化は、パフォーマンス上の理由で、バック グラウンド スレッドから描画する場合にのみ行ってください。

    次に例を示します。

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device> m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext> m_d3dContext;
    Microsoft::WRL::ComPtr<ID2D1Device> m_d2dDevice;

    // Create the DXGI device
    D3D11CreateDevice(
            NULL,
            D3D_DRIVER_TYPE_HARDWARE,
            NULL,
            flags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            &m_d3dDevice,
            NULL,
            &m_d3dContext);

    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);

    // To enable multi-threaded access (optional)
    Microsoft::WRL::ComPtr<ID3D10Multithread> d3dMultiThread;

    m_d3dDevice->QueryInterface(
        __uuidof(ID3D10Multithread), 
        (void **) &d3dMultiThread);

    d3dMultiThread->SetMultithreadProtected(TRUE);

    // Create the D2D device
    D2D1CreateDevice(m_dxgiDevice.Get(), NULL, &m_d2dDevice);

    // Set the D2D device
    m_sisNativeWithD2D->SetDevice(m_d2dDevice.Get());
    ```

4.  [ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/bb174565) オブジェクトへのポインターを [ISurfaceImageSourceNativeWithD2D::BeginDraw](https://msdn.microsoft.com/library/dn302138.aspx) に渡し、返された描画コンテキストを使って、**SurfaceImageSource** 内に目的の四角形のコンテンツを描画します。 **ISurfaceImageSourceNativeWithD2D::BeginDraw** と描画のコマンドは、バック グラウンド スレッドから呼び出すことができます。 *updateRect* パラメーターで更新対象として指定した領域だけが描画されます。

    このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。 このオフセットを使って、更新されたコンテンツを **ID2D1DeviceContext** で描画する位置を特定できます。

    ```cpp
    Microsoft::WRL::ComPtr<ID2D1DeviceContext> drawingContext;

    HRESULT beginDrawHR = m_sisNative->BeginDraw(
        updateRect, 
        &drawingContext, 
        &offset);

    if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED 
        || beginDrawHR == DXGI_ERROR_DEVICE_RESET
        || beginDrawHR == D2DERR_RECREATE_TARGET)
    {
        // The D3D and D2D device was lost and need to be re-created.
        // Recovery steps are:
        // 1) Re-create the D3D and D2D devices
        // 2) Call ISurfaceImageSourceNativeWithD2D::SetDevice with the new D2D
        //    device
        // 3) Redraw the contents of the SurfaceImageSource
    }
    else if (beginDrawHR == E_SURFACE_CONTENTS_LOST)
    {
        // The devices were not lost but the entire contents of the surface
        // were. Recovery steps are:
        // 1) Call ISurfaceImageSourceNativeWithD2D::SetDevice with the D2D 
        //    device again
        // 2) Redraw the entire contents of the SurfaceImageSource
    }
    else 
    {
        // Draw your updated rectangle with the drawingContext
    }
    ```

5. [ISurfaceImageSourceNativeWithD2D::EndDraw](https://msdn.microsoft.com/library/dn302139.aspx) を呼び出してビットマップを終了します。 ビットマップは、XAML の [Image](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) または [ImageBrush](https://msdn.microsoft.com/library/windows/apps/br210101) のソースとして使用できます。 **ISurfaceImageSourceNativeWithD2D::EndDraw** は、UI スレッドからのみ呼び出す必要があります。

    ```cpp
    m_sisNative->EndDraw();

    // ...
    // The SurfaceImageSource object's underlying 
    // ISurfaceImageSourceNativeWithD2D object contains the completed bitmap.

    ImageBrush^ brush = ref new ImageBrush();
    brush->ImageSource = surfaceImageSource;
    ```

    > [!NOTE]
    > 現在、[SurfaceImageSource::SetSource](https://msdn.microsoft.com/library/windows/apps/br243255) (**IBitmapSource::SetSource** から継承) を呼び出すと例外がスローされます。 [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトからは呼び出さないでください。

    > [!NOTE]
    > アプリケーションでは、関連する [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) が非表示になっている間は **SurfaceImageSource** へ描画しないようにする必要があります。描画すると、**ISurfaceImageSourceNativeWithD2D** API が失敗します。 これを行うためには、[Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) イベントのイベント リスナーとして登録し、表示の変更を追跡します。

## <a name="virtualsurfaceimagesource"></a>VirtualSurfaceImageSource

[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) は、コンテンツが画面に収まらず、仮想化しないと最適なレンダリングにならない場合に、[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) を拡張します。

[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) が [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) と異なる点は、[IVirtualSurfaceImageSourceCallbacksNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337) コールバックを使うことです。このコールバックを実装することで、サーフェイスの領域が画面に表示できるようになったときに領域が更新されます。 非表示の領域をクリアする必要はありません。この処理は XAML フレームワークで行われます。

[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトをコード ビハインドで作成および更新する基本的なプロセスを次に示します。

1.  サイズを指定して [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) のインスタンスを作成します。 次に例を示します。

    ```cpp
    VirtualSurfaceImageSource^ virtualSIS = 
        ref new VirtualSurfaceImageSource(2000, 2000);
    ```

2.  [IVirtualSurfaceImageSourceNative](https://msdn.microsoft.com/library/windows/desktop/hh848328) と [ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137) へのポインターを取得します。 [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) または [IUnknown](https://msdn.microsoft.com/library/windows/desktop/ms680509) としてキャストし、それに対する [QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出して、基になる **IVirtualSurfaceImageSourceNative** 実装と **ISurfaceImageSourceNativeWithD2D** 実装を取得します。 これらの実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。

    ```cpp
    Microsoft::WRL::ComPtr<IVirtualSurfaceImageSourceNative>  m_vsisNative;
    Microsoft::WRL::ComPtr<ISurfaceImageSourceNativeWithD2D> m_sisNativeWithD2D;

    // ...

    IInspectable* vsisInspectable = 
        (IInspectable*) reinterpret_cast<IInspectable*>(virtualSIS);

    vsisInspectable->QueryInterface(
        __uuidof(IVirtualSurfaceImageSourceNative), 
        (void **) &m_vsisNative);

    vsisInspectable->QueryInterface(
        __uuidof(ISurfaceImageSourceNativeWithD2D), 
        (void **) &m_sisNativeWithD2D);
    ```

3.  最初に **D3D11CreateDevice** と **D2D1CreateDevice** を呼び出してから、D2D デバイスを **ISurfaceImageSourceNativeWithD2D::SetDevice** に渡して、DXGI デバイスと D2D デバイスを作成します。

    > [!NOTE]
    > バックグラウンド スレッドから **VirtualSurfaceImageSource** に描画する場合は、DXGI デバイスでマルチスレッド アクセスも有効になっている必要があります。 この有効化は、パフォーマンス上の理由で、バック グラウンド スレッドから描画する場合にのみ行ってください。

    次に例を示します。

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device> m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext> m_d3dContext;
    Microsoft::WRL::ComPtr<ID2D1Device> m_d2dDevice;

    // Create the DXGI device
    D3D11CreateDevice(
            NULL,
            D3D_DRIVER_TYPE_HARDWARE,
            NULL,
            flags,
            featureLevels,
            ARRAYSIZE(featureLevels),
            D3D11_SDK_VERSION,
            &m_d3dDevice,
            NULL,
            &m_d3dContext);  

    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);
    
    // To enable multi-threaded access (optional)
    Microsoft::WRL::ComPtr<ID3D10Multithread> d3dMultiThread;

    m_d3dDevice->QueryInterface(
        __uuidof(ID3D10Multithread), 
        (void **) &d3dMultiThread);

    d3dMultiThread->SetMultithreadProtected(TRUE);

    // Create the D2D device
    D2D1CreateDevice(m_dxgiDevice.Get(), NULL, &m_d2dDevice);

    // Set the D2D device
    m_vsisNativeWithD2D->SetDevice(m_d2dDevice.Get());

    m_vsisNative->SetDevice(dxgiDevice.Get());
    ```

4.  [IVirtualSurfaceImageSourceNative::RegisterForUpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334) を呼び出して、[IVirtualSurfaceUpdatesCallbackNative](https://msdn.microsoft.com/library/windows/desktop/hh848336) の実装への参照を渡します。

    ```cpp
    class MyContentImageSource : public IVirtualSurfaceUpdatesCallbackNative
    {
    // ...
      private:
         virtual HRESULT STDMETHODCALLTYPE UpdatesNeeded() override;
    }

    // ...

    HRESULT STDMETHODCALLTYPE MyContentImageSource::UpdatesNeeded()
    {
      // .. Perform drawing here ...
    }

    void MyContentImageSource::Initialize()
    {
      // ...
      m_vsisNative->RegisterForUpdatesNeeded(this);
      // ...
    }
    ```

    [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) の領域を更新する必要がある場合、フレームワークで [IVirtualSurfaceUpdatesCallbackNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334) の実装が呼び出されます。

    これが発生するのは、領域を描画する必要があるとフレームワークで判断されたとき (ユーザーがサーフェイスのビューをパンまたはズームしたときなど)、およびその領域に対する [IVirtualSurfaceImageSourceNative::Invalidate](https://msdn.microsoft.com/library/windows/desktop/hh848332) がアプリで呼び出されたときです。

5.  [IVirtualSurfaceImageSourceNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337) で、[IVirtualSurfaceImageSourceNative::GetUpdateRectCount](https://msdn.microsoft.com/library/windows/desktop/hh848329) メソッドと [IVirtualSurfaceImageSourceNative::GetUpdateRects](https://msdn.microsoft.com/library/windows/desktop/hh848330) メソッドを使って、描画する必要があるサーフェイスの領域を特定します。

    ```cpp
    HRESULT STDMETHODCALLTYPE MyContentImageSource::UpdatesNeeded()
    {
        HRESULT hr = S_OK;

        try
        {
            ULONG drawingBoundsCount = 0;  
            m_vsisNative->GetUpdateRectCount(&drawingBoundsCount);

            std::unique_ptr<RECT[]> drawingBounds(
                new RECT[drawingBoundsCount]);

            m_vsisNative->GetUpdateRects(
                drawingBounds.get(), 
                drawingBoundsCount);
            
            for (ULONG i = 0; i < drawingBoundsCount; ++i)
            {
                // Drawing code here ...
            }
        }
        catch (Platform::Exception^ exception)
        {
            hr = exception->HResult;
        }

        return hr;
    }
    ```

6.  最後に、更新する必要がある領域ごとに以下を行います。

    1.  **ID2D1DeviceContext** オブジェクトへのポインターを **ISurfaceImageSourceNativeWithD2D::BeginDraw** に渡し、返された描画コンテキストを使って、**SurfaceImageSource** 内に目的の四角形のコンテンツを描画します。 **ISurfaceImageSourceNativeWithD2D::BeginDraw** と描画のコマンドは、バック グラウンド スレッドから呼び出すことができます。 *updateRect* パラメーターで更新対象として指定した領域だけが描画されます。

        このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。 このオフセットを使って、更新されたコンテンツを **ID2D1DeviceContext** で描画する位置を特定できます。

        ```cpp
        Microsoft::WRL::ComPtr<ID2D1DeviceContext> drawingContext;

        HRESULT beginDrawHR = m_sisNative->BeginDraw(
            updateRect, 
            &drawingContext, 
            &offset);

        if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED 
            || beginDrawHR == DXGI_ERROR_DEVICE_RESET 
            || beginDrawHR == D2DERR_RECREATE_TARGET)
        {
            // The D3D and D2D devices were lost and need to be re-created.
            // Recovery steps are:
            // 1) Re-create the D3D and D2D devices
            // 2) Call ISurfaceImageSourceNativeWithD2D::SetDevice with the 
            //    new D2D device
            // 3) Redraw the contents of the VirtualSurfaceImageSource
        }
        else if (beginDrawHR == E_SURFACE_CONTENTS_LOST)
        {
            // The devices were not lost but the entire contents of the 
            // surface were lost. Recovery steps are:
            // 1) Call ISurfaceImageSourceNativeWithD2D::SetDevice with the 
            //    D2D device again
            // 2) Redraw the entire contents of the VirtualSurfaceImageSource
        }
        else
        {
            // Draw your updated rectangle with the drawingContext
        }
        ```

    2.  具体的なコンテンツをその領域に描画します。ただし、パフォーマンスを高めるために描画を限られた領域に制限します。

    3.  **ISurfaceImageSourceNativeWithD2D::EndDraw** を呼び出します。 結果のビットマップが返されます。

> [!NOTE]
> アプリケーションでは、関連する [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) が非表示になっている間は **SurfaceImageSource** へ描画しないようにする必要があります。描画すると、**ISurfaceImageSourceNativeWithD2D** API が失敗します。 これを行うためには、[Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) イベントのイベント リスナーとして登録し、表示の変更を追跡します。

## <a name="swapchainpanel-and-gaming"></a>SwapChainPanel とゲーム


[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) は、高パフォーマンスのグラフィックスやゲームをサポートするために設計された Windows ランタイム型です。この型でスワップ チェーンを直接管理します。 この例では、独自の DirectX スワップ チェーンを作成し、レンダリングされるコンテンツの表示を管理します。

パフォーマンスを高めるために、[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) 型には次のような制限事項があります。

-   [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) インスタンスの数は、アプリごとに 4 つ以下です。
-   DirectX スワップ チェーンの高さと幅 ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、スワップ チェーン要素の現在のサイズに設定することをお勧めします。 このように設定しないと、表示されるコンテンツのサイズが自動的に調整されます (**DXGI\_SCALING\_STRETCH** を使用)。
-   DirectX スワップ チェーンのスケーリング モード ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、**DXGI\_SCALING\_STRETCH** に設定する必要があります
-   DirectX スワップ チェーンのアルファ モード ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) を **DXGI\_ALPHA\_MODE\_PREMULTIPLIED** に設定することはできません。
-   DirectX スワップ チェーンを作成するときは、[IDXGIFactory2::CreateSwapChainForComposition](https://msdn.microsoft.com/library/windows/desktop/hh404558) を呼び出す必要があります。

[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) の更新は、XAML フレームワークの更新ではなく、アプリのニーズに基づいて行います。 **SwapChainPanel** の更新を XAML フレームワークの更新に同期する必要がある場合は、[Windows::UI::Xaml::Media::CompositionTarget::Rendering](https://msdn.microsoft.com/library/windows/apps/br228127) イベントに登録します。 このイベントに登録しないと、**SwapChainPanel** を更新するスレッドと異なるスレッドから XAML 要素を更新する場合に、クロス スレッドの問題についての検討が必要になります。

**SwapChainPanel** に対する待機時間の短いポインター入力を受信する必要がある場合は、[SwapChainPanel::CreateCoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.swapchainpanel.createcoreindependentinputsource) を使用します。 このメソッドは、バックグラウンド スレッドで最小限の待機時間で入力イベントを受信するために使用できる [CoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coreindependentinputsource) オブジェクトを返します。 このメソッドが呼び出されると、すべての入力がバックグラウンド スレッドにリダイレクトされるため、**SwapChainPanel** について通常の XAML ポインター入力イベントは発生しません。


> **注**   一般に、DirectX アプリでは、サイズが表示ウィンドウのサイズ (通常は、ほとんどの Microsoft Store ゲームのネイティブの画面解像度) と同じである横方向のスワップ チェーンを作る必要があります。 これにより、表示される XAML オーバーレイがない場合はアプリで最適なスワップ チェーンの実装が使われます。 縦モードに回転した場合、アプリは既にあるスワップ チェーンで [IDXGISwapChain1::SetRotation](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出し、必要に応じてコンテンツに変換を適用して、同じスワップ チェーンで [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144) をもう一度呼び出す必要があります。 同様に、アプリは、[IDXGISwapChain::ResizeBuffers](https://msdn.microsoft.com/library/windows/desktop/bb174577) 呼び出しによってスワップ チェーンのサイズが変更されるたびに、同じスワップ チェーンで **SetSwapChain** をもう一度呼び出す必要があります。


 

[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。

1.  アプリのスワップ チェーン パネルのインスタンスを取得します。 これらのインスタンスは、XAML では `<SwapChainPanel>` タグを使って示されます。

    `Windows::UI::Xaml::Controls::SwapChainPanel^ swapChainPanel;`

    `<SwapChainPanel>` タグの例を次に示します。

    ```xml
    <SwapChainPanel x:Name="swapChainPanel">
        <SwapChainPanel.ColumnDefinitions>
            <ColumnDefinition Width="300*"/>
            <ColumnDefinition Width="1069*"/>
        </SwapChainPanel.ColumnDefinitions>
    …
    ```

2.  [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143) へのポインターを取得します。 [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISwapChainPanelNative** 実装を取得します。

    ```cpp
    Microsoft::WRL::ComPtr<ISwapChainPanelNative> m_swapChainNative;
    // ...
    IInspectable* panelInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(swapChainPanel);
    panelInspectable->QueryInterface(__uuidof(ISwapChainPanelNative), (void **)&m_swapChainNative);
    ```

3.  DXGI デバイスとスワップ チェーンを作成し、スワップ チェーンを [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144) に渡して [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143) に設定します。

    ```cpp
    Microsoft::WRL::ComPtr<IDXGISwapChain1>               m_swapChain;    
    // ...
    DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};
            swapChainDesc.Width = m_bounds.Width;
            swapChainDesc.Height = m_bounds.Height;
            swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;           // This is the most common swapchain format.
            swapChainDesc.Stereo = false; 
            swapChainDesc.SampleDesc.Count = 1;                          // Don't use multi-sampling.
            swapChainDesc.SampleDesc.Quality = 0;
            swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.BufferCount = 2;
            swapChainDesc.Scaling = DXGI_SCALING_STRETCH;
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // We recommend using this swap effect for all. applications
            swapChainDesc.Flags = 0;
                    
    // QI for DXGI device
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);

    // Get the DXGI adapter.
    Microsoft::WRL::ComPtr<IDXGIAdapter> dxgiAdapter;
    dxgiDevice->GetAdapter(&dxgiAdapter);

    // Get the DXGI factory.
    Microsoft::WRL::ComPtr<IDXGIFactory2> dxgiFactory;
    dxgiAdapter->GetParent(__uuidof(IDXGIFactory2), &dxgiFactory);
    // Create a swap chain by calling CreateSwapChainForComposition.
    dxgiFactory->CreateSwapChainForComposition(
                m_d3dDevice.Get(),
                &swapChainDesc,
                nullptr,        // Allow on any display. 
                &m_swapChain
                );
            
    m_swapChainNative->SetSwapChain(m_swapChain.Get());
    ```

4.  DirectX スワップ チェーンに描画し、それを渡してコンテンツを表示します。

    ```cpp
    HRESULT hr = m_swapChain->Present(1, 0);
    ```

    XAML 要素は、Windows ランタイムのレイアウトやレンダリング ロジックから更新が通知されると更新されます。

## <a name="related-topics"></a>関連トピック

* [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm)
* [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041)
* [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050)
* [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834)
* [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143)
* [Direct3D 11 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ff476345)

 

 




