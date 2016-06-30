---
author: mtoepke
title: "DirectX と XAML の相互運用機能"
description: "ユニバーサル Windows プラットフォーム (UWP) ゲームで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。"
ms.assetid: 0fb2819a-61ed-129d-6564-0b67debf5c6b
translationtype: Human Translation
ms.sourcegitcommit: 36bc5dcbefa6b288bf39aea3df42f1031f0b43df
ms.openlocfilehash: 97e694ae2fb8af30a35aa9ebdb714db50a506e6c

---

# DirectX と XAML の相互運用機能


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ユニバーサル Windows プラットフォーム (UWP) ゲームで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。 XAML と DirectX を組み合わせれば、DirectX でレンダリングしたコンテンツと相互運用できる柔軟なユーザー インターフェイス フレームワークを構築できます。これは、グラフィックスを多用するアプリで特に役立ちます。 ここでは、DirectX を使った UWP アプリの構造について説明し、DirectX と連携する UWP アプリを構築するときに使う重要な型を示します。

> **注**  DirectX API は Windows ランタイム型として定義されていないため、DirectX と相互運用する XAMLUWP コンポーネントを開発するときは Visual C++ コンポーネント拡張機能 (C++/CX) を使うのが一般的です。 また、DirectX の呼び出しを独立した Windows ランタイム メタデータ ファイルにラップすると、C# と DirectX を利用する XAML を使って UWP アプリを作成できます。

 

## XAML と DirectX


DirectX には、2D と 3D のグラフィックス用に、Direct2D と Microsoft Direct3D という 2 つの強力なライブラリがあります。 XAML でも基本的な 2D のプリミティブと効果はサポートされますが、モデリングやゲームなどの多くのアプリでは、より複雑なグラフィックス サポートが必要になります。 そのようなアプリでは、Direct2D と Direct3D を使ってグラフィックスの一部または全体をレンダリングし、それ以外の部分には XAML を使うことができます。

XAML と DirectX の相互運用シナリオでは、次の 2 つの概念を理解する必要があります。

-   共有サーフェイス。[**Windows::UI::Xaml::Media::Brush**](https://msdn.microsoft.com/library/windows/apps/br228076) 型を使って DirectX で間接的に描画を行うことができる、サイズが指定されたディスプレイの領域です。この領域は XAML で定義されます。 共有サーフェイスについては、スワップ チェーンを表示する呼び出しの制御は行いません。 共有サーフェイスの更新は XAML フレームワークの更新に同期されます。
-   スワップ チェーン。 DirectX のレンダリング パイプラインのバック バッファーを提供します。これはレンダー ターゲットの完了後に表示するメモリの領域です。

次に、DirectX を使う目的を確認します。 表示ウィンドウのサイズに収まる 1 つのコントロールを作ったりアニメーション化したりするために使うのか、 作ったサーフェイスが他のサーフェイスまたは画面の端でふさがれる可能性はあるのか、 ゲームなどのようにリアルタイムでレンダリングして制御する必要がある出力をサーフェイスに表示するのかを確認します。

DirectX をどのように使うかを決めたら、目的に応じて次のいずれかの Windows ランタイム型を使って、DirectX のレンダリングを Windows ストア アプリに組み込みます。

-   静的な画像を構成する場合やイベント駆動型の複雑な画像を描画する場合は、[**Windows::UI::Xaml::Media::Imaging::SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) を使って共有サーフェイスに描画します。 これは、サイズが指定された DirectX の描画サーフェイスを処理する型です。 通常は、ドキュメントや UI 要素でビットマップとして表示する画像やテクスチャを構成する場合に使います。 この型は、高パフォーマンスのゲームのようなリアルタイムのインタラクティビティには適しません。 **SurfaceImageSource** オブジェクトの更新が XAML ユーザー インターフェイスの更新に同期されるため、フレーム レートが安定しない、リアルタイムの入力に対する応答が遅いなど、ユーザーへの視覚的フィードバックに待ち時間が生じるためです。 ただし、動的なコントロールやデータ シミュレーションであれば、更新に時間はかからず問題ありません。

    [
              **SurfaceImageSource**
            ](https://msdn.microsoft.com/library/windows/apps/hh702041) グラフィックス オブジェクトは、他の XAML UI 要素と合成できます。 それらを変換または投影すると、XAML フレームワークに不透明度や z インデックスの値が適用されます。

-   画像が画面上のスペースよりも大きく、ユーザーがパンまたはズームできる場合は、[**Windows::UI::Xaml::Media::Imaging::VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) を使います。 これは、画面よりも大きいサイズが指定された DirectX の描画サーフェイスを処理する型です。 [
            **SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) と同様に、複雑な画像やコントロールを動的に構成する場合に使います。 また、**SurfaceImageSource** と同様に、高パフォーマンスのゲームには適しません。 **VirtualSurfaceImageSource** を使うことができる XAML 要素には、マップ コントロールや、画像が多い大きなドキュメント ビューアーなどがあります。

-   リアルタイムで更新されるグラフィックスを DirectX を使って表示する場合や、短い待ち時間で定期的に更新を行う必要がある場合は、[**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) クラスを使います。これにより、XAML フレームワークの更新タイマーに同期せずにグラフィックスを更新することができます。 この型を使うと、グラフィックス デバイスのスワップ チェーン ([**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)) に直接アクセスし、XAML をレンダー ターゲットの上に配置できます。 この型は、ゲームなどの全画面の DirectX アプリで XAML ベースのユーザー インターフェイスが必要な場合に便利です。 Microsoft DirectX Graphics Infrastructure (DXGI)、Direct2D、Direct3D も含めて、この方法を使うには、DirectX に関する知識が必要です。 詳しくは、「[Direct3D 11 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ff476345)」をご覧ください。

## SurfaceImageSource


[
              **SurfaceImageSource**
            ](https://msdn.microsoft.com/library/windows/apps/hh702041) は、DirectX で描画を行うための共有サーフェイスを提供し、ビットからアプリのコンテンツを構成します。

[
            **SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。

1.  [
            **SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) コンストラクターに高さと幅の値を渡して、共有サーフェイスのサイズを定義します。 アルファ (不透明度) のサポートが必要かどうかも指定できます。

    次に例を示します。

    `SurfaceImageSource^ surfaceImageSource = ref new SurfaceImageSource(400, 300);`

2.  [
            **ISurfaceImageSourceNative**](https://msdn.microsoft.com/library/windows/desktop/hh848322) へのポインターを取得します。 [
            **SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトを [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISurfaceImageSourceNative** 実装を取得します。 この実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。

    ```cpp
    Microsoft::WRL::ComPtr<ISurfaceImageSourceNative> m_sisNative;
    // ...
    IInspectable* sisInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(surfaceImageSource);
    sisInspectable->QueryInterface(__uuidof(ISurfaceImageSourceNative), (void **)&m_sisNative);
    ```

3.  [
            **D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) を呼び出してから [**ISurfaceImageSourceNative::SetDevice**](https://msdn.microsoft.com/library/windows/desktop/hh848325) にデバイスとコンテキストを渡して、DXGI デバイスを設定します。 次に例を示します。

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device>              m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext>           m_d3dContext;
    // ...
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
            &m_d3dContext
            )
        );  
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);
    // ...
    m_sisNative->SetDevice(dxgiDevice.Get());
    ```

4.  [
            **IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) オブジェクトへのポインターを [**ISurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) に渡し、DirectX を使ってそのサーフェイスに描画します。 *updateRect* パラメーターで更新対象として指定した領域だけが描画されます。

    > **注**   各 [**IDXGIDevice**](https://msdn.microsoft.com/library/windows/desktop/bb174527) でアクティブにできる未処理の [**BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) 操作は、一度に 1 つだけです。

     

    このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。 このオフセットを使って、[**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) 内の描画する位置を特定できます。

    ```cpp
    ComPtr<IDXGISurface> surface;

    HRESULT beginDrawHR = m_sisNative->BeginDraw(updateRect, &surface, &offset);
    if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET)
    {
              // Device changed
    }
    else
    {
        // Draw to IDXGISurface (the surface paramater)
    }
    ```

5.  [
            **ISurfaceImageSourceNative::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848324) を呼び出してビットマップを終了します。 このビットマップを [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101) に渡します。

    ```cpp
    m_sisNative->EndDraw();
    // ...
    // The SurfaceImageSource object's underlying ISurfaceImageSourceNative object contains the completed bitmap.
    ImageBrush^ brush = ref new ImageBrush();
    brush->ImageSource = surfaceImageSource;
    ```

6.  [
            **ImageBrush**](https://msdn.microsoft.com/library/windows/apps/br210101) を使ってビットマップを描画します。

> **注**   現在、[**SurfaceImageSource::SetSource**](https://msdn.microsoft.com/library/windows/apps/br243255) (**IBitmapSource::SetSource** から継承) を呼び出すと例外がスローされます。 [
            **SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトから呼び出さないでください。

 

## VirtualSurfaceImageSource


[
              **VirtualSurfaceImageSource**
            ](https://msdn.microsoft.com/library/windows/apps/hh702050) は、コンテンツが画面に収まらず、仮想化しないと最適なレンダリングにならない場合に、[**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) を拡張します。

[
              **VirtualSurfaceImageSource**
            ](https://msdn.microsoft.com/library/windows/apps/hh702050) が [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041) と異なる点は、[**IVirtualSurfaceImageSourceCallbacksNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848337) コールバックを使うことです。このコールバックを実装することで、サーフェイスの領域が画面に表示できるようになったときに領域が更新されます。 非表示の領域をクリアする必要はありません。この処理は XAML フレームワークで行われます。

[
            **VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトをコード ビハインドで作成および更新する基本的なプロセスを次に示します。

1.  サイズを指定して [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) のインスタンスを作成します。 次に例を示します。

    `VirtualSurfaceImageSource^ virtualSIS = ref new VirtualSurfaceImageSource(2000, 2000);`

2.  [
            **IVirtualSurfaceImageSourceNative**](https://msdn.microsoft.com/library/windows/desktop/hh848328) へのポインターを取得します。 [
            **VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトを [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) または [**IUnknown**](https://msdn.microsoft.com/library/windows/desktop/ms680509) としてキャストし、それに対する [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出して、基になる **IVirtualSurfaceImageSourceNative** 実装を取得します。 この実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。

    ```cpp
    Microsoft::WRL::ComPtr<IVirtualSurfaceImageSourceNative>  m_vsisNative;
    // ...
    IInspectable* vsisInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(virtualSIS);
    vsisInspectable->QueryInterface(__uuidof(IVirtualSurfaceImageSourceNative), (void **)&m_vsisNative);
    ```

3.  [
            **IVirtualSurfaceImageSourceNative::SetDevice**](https://msdn.microsoft.com/library/windows/desktop/hh848325) を呼び出して DXGI デバイスを設定します。 次に例を示します。

    ```cpp
    Microsoft::WRL::ComPtr<ID3D11Device>              m_d3dDevice;
    Microsoft::WRL::ComPtr<ID3D11DeviceContext>           m_d3dContext;
    // ...
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
            &m_d3dContext
            )
        );  
    Microsoft::WRL::ComPtr<IDXGIDevice> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);
    // ...
    m_vsisNative->SetDevice(dxgiDevice.Get());
    ```

4.  [
            **IVirtualSurfaceImageSourceNative::RegisterForUpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848334) を呼び出して、[**IVirtualSurfaceUpdatesCallbackNative**](https://msdn.microsoft.com/library/windows/desktop/hh848336) の実装への参照を渡します。

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

    [
            **VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050) の領域を更新する必要がある場合、フレームワークで [**IVirtualSurfaceUpdatesCallbackNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848334) の実装が呼び出されます。

    これが発生するのは、領域を描画する必要があるとフレームワークで特定されたとき (ユーザーがサーフェイスのビューをパンまたはズームしたときなど) と、その領域に対する [**IVirtualSurfaceImageSourceNative::Invalidate**](https://msdn.microsoft.com/library/windows/desktop/hh848332) がアプリで呼び出されたときです。

5.  [
            **IVirtualSurfaceImageSourceNative::UpdatesNeeded**](https://msdn.microsoft.com/library/windows/desktop/hh848337) で、[**IVirtualSurfaceImageSourceNative::GetUpdateRectCount**](https://msdn.microsoft.com/library/windows/desktop/hh848329) メソッドと [**IVirtualSurfaceImageSourceNative::GetUpdateRects**](https://msdn.microsoft.com/library/windows/desktop/hh848330) メソッドを使って、描画する必要があるサーフェイスの領域を特定します。

    ```cpp
    HRESULT STDMETHODCALLTYPE MyContentImageSource::UpdatesNeeded()
    {
        HRESULT hr = S_OK;

        try
        {
            ULONG drawingBoundsCount = 0;  

                  m_vsisNative->GetUpdateRectCount(&drawingBoundsCount);
            std::unique_ptr<RECT[]> drawingBounds(new RECT[drawingBoundsCount]);
            m_vsisNative->GetUpdateRects(drawingBounds.get(), drawingBoundsCount);
            
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

    1.  [
            **IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) オブジェクトへのポインターを [**IVirtualSurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) に渡し、DirectX を使ってそのサーフェイスに描画します。 *updateRect* パラメーターで更新対象として指定した領域だけが描画されます。

        [
            **IlSurfaceImageSourceNative::BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) と同様に、このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。 このオフセットを使って、[**IDXGISurface**](https://msdn.microsoft.com/library/windows/desktop/bb174565) 内の描画する位置を特定できます。

        > **注**   各 [**IDXGIDevice**](https://msdn.microsoft.com/library/windows/desktop/bb174527) でアクティブにできる未処理の [**BeginDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848323) 操作は、一度に 1 つだけです。

         

        ```cpp
        ComPtr<IDXGISurface> bigSurface;

        HRESULT beginDrawHR = m_vsisNative->BeginDraw(updateRect, &bigSurface, &offset);
        if (beginDrawHR == DXGI_ERROR_DEVICE_REMOVED || beginDrawHR == DXGI_ERROR_DEVICE_RESET)
        {
                  // Device changed
        }
        else
        {
            // Draw to IDXGISurface
        }
        ```

    2.  具体的なコンテンツをその領域に描画します。ただし、パフォーマンスを高めるために描画を限られた領域に制限します。

    3.  [
            **IVirtualSurfaceImageSourceNative::EndDraw**](https://msdn.microsoft.com/library/windows/desktop/hh848324) を呼び出します。 結果のビットマップが返されます。

## SwapChainPanel とゲーム


[
              **SwapChainPanel**
            ](https://msdn.microsoft.com/library/windows/apps/dn252834) は、高パフォーマンスのグラフィックスやゲームをサポートするために設計された Windows ランタイム型です。この型でスワップ チェーンを直接管理します。 この例では、独自の DirectX スワップ チェーンを作成し、レンダリングされるコンテンツの表示を管理します。 その後、メニュー、ヘッドアップ ディスプレイ、その他の UI オーバーレイなどの XAML 要素を **SwapChainPanel** オブジェクトに追加できます。

フォーマンスを高めるために、[**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) 型には次のような制限事項があります。

-   [
            **SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) インスタンスの数はアプリごとに 4 つ以下です。
-   **Opacity**、**RenderTransform**、**Projection**、**Clip** の各プロパティの [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) による継承はサポートされていません。
-   DirectX スワップ チェーンの高さと幅 ([**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、アプリ ウィンドウの現在のサイズに設定することをお勧めします。 このように設定しないと、表示されるコンテンツのサイズが自動的に調整されます (**DXGI\_SCALING\_STRETCH** を使用)。
-   DirectX スワップ チェーンのスケーリング モード ([**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、**DXGI\_SCALING\_STRETCH** に設定する必要があります。
-   DirectX スワップ チェーンのアルファ モード ([**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) を **DXGI\_ALPHA\_MODE\_PREMULTIPLIED** に設定することはできません。
-   DirectX スワップ チェーンを作成するときは、[**IDXGIFactory2::CreateSwapChainForComposition**](https://msdn.microsoft.com/library/windows/desktop/hh404558) を呼び出す必要があります。

[
            **SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) の更新は、XAML フレームワークの更新ではなく、アプリのニーズに基づいて行います。 **SwapChainPanel** の更新を XAML フレームワークの更新に同期する必要がある場合は、[**Windows::UI::Xaml::Media::CompositionTarget::Rendering**](https://msdn.microsoft.com/library/windows/apps/br228127) イベントに登録します。 このイベントに登録しないと、**SwapChainPanel** を更新するスレッドと異なるスレッドから XAML 要素を更新する場合に、クロス スレッドの問題についての検討が必要になります。

次に、[**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) を使うアプリを設計する際の一般的なヒントをいくつか紹介します。

-   [
              **SwapChainPanel**
            ](https://msdn.microsoft.com/library/windows/apps/dn252834) は [**Windows::UI::Xaml::Controls::Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) から継承され、同様のレイアウト動作をサポートします。 **Grid** 型とそのプロパティについて確認しておいてください。

-   DirectX スワップ チェーンの設定後、[**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) に対する入力イベントはすべて他の XAML 要素と同じように機能します。 **SwapChainPanel** に対しては背景ブラシを設定しません。また、**SwapChainPanel** を使わない DirectX アプリとは異なり、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトからの入力イベントを直接処理する必要はありません。

-   • XAML 視覚要素のコンテンツのうち、ビジュアル ツリーで [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) の直接の子の下にあるコンテンツは、いずれも **SwapChainPanel** オブジェクトの直接の子のレイアウト サイズに合わせてクリッピングされます。 変換後にそれらのレイアウトの境界に収まらないコンテンツはレンダリングされません。 そのため、XAML の [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) でアニメーション化する XAML コンテンツをビジュアル ツリーに配置するときは、アニメーションのすべての範囲がレイアウトの境界に収まる大きさの要素の下に配置します。

-   [
            **SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) の直接の子にする XAML 視覚要素の数を制限します。 近接する要素は、できるだけ共通の親の下にまとめます。 ただし、XAML 要素が多すぎたり必要以上に大きいと全体のパフォーマンスに影響することがあるため、直接の子視覚要素の数とサイズについてはパフォーマンスとのバランスに注意する必要があります。 同様に、アプリの **SwapChainPanel** の子 XAML 要素を単一の全画面の要素にすると、過剰な描画が増えてアプリのパフォーマンスが低下するため、このような要素は作成しないようにします。 一般に、アプリの **SwapChainPanel** に対して作成する直接の子 XAML 視覚要素は 8 つまでにします。また、各要素のレイアウト サイズは、要素のコンテンツを表示するために必要な大きさに制限する必要があります。 ただし、**SwapChainPanel** の子要素の下のビジュアル ツリーについては、ある程度複雑にしてもパフォーマンスはそれほど低下しません。

> **注**   一般に、DirectX アプリでは、サイズが表示ウィンドウのサイズ (通常は、ほとんどの Windows ストア ゲームのネイティブの画面解像度) と同じである横方向のスワップ チェーンを作る必要があります。 これにより、表示される XAML オーバーレイがない場合はアプリで最適なスワップ チェーンの実装が使われます。 縦モードに回転した場合、アプリは既にあるスワップ チェーンで [**IDXGISwapChain1::SetRotation**](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出し、必要に応じてコンテンツに変換を適用して、同じスワップ チェーンで [**SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) をもう一度呼び出す必要があります。 同様に、アプリは、[**IDXGISwapChain::ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) 呼び出しによってスワップ チェーンのサイズが変更されるたびに、同じスワップ チェーンで **SetSwapChain** をもう一度呼び出す必要があります。

 

[
            **SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。

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

2.  [
            **ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143) へのポインターを取得します。 [
            **SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトを [**IInspectable**](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISwapChainPanelNative** 実装を取得します。

    ```cpp
    Microsoft::WRL::ComPtr<ISwapChainPanelNative> m_swapChainNative;
    // ...
    IInspectable* panelInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(swapChainPanel);
    panelInspectable->QueryInterface(__uuidof(ISwapChainPanelNative), (void **)&m_swapChainNative);
    ```

3.  DXGI デバイスとスワップ チェーンを作成し、スワップ チェーンを [**SetSwapChain**](https://msdn.microsoft.com/library/windows/desktop/dn302144) に渡して [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143) に設定します。

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

## 関連トピック


* [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702041)
* [**VirtualSurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/hh702050)
* [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834)
* [**ISwapChainPanelNative**](https://msdn.microsoft.com/library/windows/desktop/dn302143)
* [Direct3D 11 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ff476345)

 

 







<!--HONumber=Jun16_HO4-->


