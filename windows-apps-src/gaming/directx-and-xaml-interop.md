---
title: DirectX と XAML の相互運用機能
description: ユニバーサル Windows プラットフォーム (UWP) ゲームで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。
ms.assetid: 0fb2819a-61ed-129d-6564-0b67debf5c6b
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, XAML の相互運用機能
ms.localizationpriority: medium
ms.openlocfilehash: 34fb65ec53f6addccf8723b451d333d602c17908
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9046212"
---
# <a name="directx-and-xaml-interop"></a><span data-ttu-id="21ad6-104">DirectX と XAML の相互運用機能</span><span class="sxs-lookup"><span data-stu-id="21ad6-104">DirectX and XAML interop</span></span>



<span data-ttu-id="21ad6-105">ユニバーサル Windows プラットフォーム (UWP) ゲームまたはアプリで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-105">You can use Extensible Application Markup Language (XAML) and Microsoft DirectX together in your Universal Windows Platform (UWP) game or app.</span></span> <span data-ttu-id="21ad6-106">XAML と DirectX を組み合わせれば、DirectX でレンダリングしたコンテンツと相互運用できる柔軟なユーザー インターフェイス フレームワークを構築できます。これは、グラフィックスを多用するアプリで特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-106">The combination of XAML and DirectX lets you build flexible user interface frameworks that interop with your DirectX-rendered content, and is particularly useful for graphics-intensive apps.</span></span> <span data-ttu-id="21ad6-107">ここでは、DirectX を使った UWP アプリの構造について説明し、DirectX と連携する UWP アプリを構築するときに使う重要な型を示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-107">This topic explains the structure of a UWP app that uses DirectX and identifies the important types to use when building your UWP app to work with DirectX.</span></span>

<span data-ttu-id="21ad6-108">アプリが主に 2D レンダリングに重点を置いているときは、[Win2D](https://github.com/microsoft/win2d) Windows ランタイム ライブラリの使用が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-108">If your app mainly focuses on 2D rendering, you may want to use the [Win2D](https://github.com/microsoft/win2d) Windows Runtime library.</span></span> <span data-ttu-id="21ad6-109">このライブラリは Microsoft によって管理されており、コア Direct2D のテクノロジを基盤として構築されています。</span><span class="sxs-lookup"><span data-stu-id="21ad6-109">This library is maintained by Microsoft and built on top of the core Direct2D technologies.</span></span> <span data-ttu-id="21ad6-110">2D グラフィックスを実装する使用パターンを大幅に簡略化し、このドキュメントで説明する手法の一部の便利な抽象化が含まれています。</span><span class="sxs-lookup"><span data-stu-id="21ad6-110">It greatly simplifies the usage pattern to implement 2D graphics and includes helpful abstractions for some of the techniques described in this document.</span></span> <span data-ttu-id="21ad6-111">詳しくは、プロジェクトのページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21ad6-111">See the project page for more details.</span></span> <span data-ttu-id="21ad6-112">このドキュメントでは、Win2D を使用*しない*ことを選択したアプリ開発者向けのガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-112">This document covers guidance for app developers who choose *not* to use Win2D.</span></span>

> <span data-ttu-id="21ad6-113">**注:** DirectX Api として定義されていない Windows ランタイム型では、通常では VisualC コンポーネント拡張機能を使用するため (、C++/cli CX) を DirectX と相互運用する XAML UWP コンポーネントを開発します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-113">**Note**DirectX APIs are not defined as Windows Runtime types, so you typically use VisualC++ component extensions (C++/CX) to develop XAML UWP components that interoperate with DirectX.</span></span> <span data-ttu-id="21ad6-114">また、DirectX の呼び出しを独立した Windows ランタイム メタデータ ファイルにラップすると、C# と DirectX を利用する XAML を使って UWP アプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-114">Also, you can create a UWP app with C# and XAML that uses DirectX, if you wrap the DirectX calls in a separate Windows Runtime metadata file.</span></span>

 

## <a name="xaml-and-directx"></a><span data-ttu-id="21ad6-115">XAML と DirectX</span><span class="sxs-lookup"><span data-stu-id="21ad6-115">XAML and DirectX</span></span>

<span data-ttu-id="21ad6-116">DirectX には、2D と 3D のグラフィックス用に、Direct2D と Microsoft Direct3D という 2 つの強力なライブラリがあります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-116">DirectX provides two powerful libraries for 2D and 3D graphics: Direct2D and Microsoft Direct3D.</span></span> <span data-ttu-id="21ad6-117">XAML でも基本的な 2D のプリミティブと効果はサポートされますが、モデリングやゲームなどの多くのアプリでは、より複雑なグラフィックス サポートが必要になります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-117">Although XAML provides support for basic 2D primitives and effects, many apps, such as modeling and gaming, need more complex graphics support.</span></span> <span data-ttu-id="21ad6-118">そのようなアプリでは、Direct2D と Direct3D を使ってグラフィックスの一部または全体をレンダリングし、それ以外の部分には XAML を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-118">For these, you can use Direct2D and Direct3D to render part or all of the graphics and use XAML for everything else.</span></span>

<span data-ttu-id="21ad6-119">カスタム XAML と DirectX の相互運用機能を実装する場合は、次の 2 つの概念を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-119">If you are implementing custom XAML and DirectX interop, you need to know these two concepts:</span></span>

-   <span data-ttu-id="21ad6-120">共有サーフェイス。[Windows::UI::Xaml::Media::ImageSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imagesource.aspx) 型を使って DirectX で間接的に描画を行うことができる、サイズが指定されたディスプレイの領域です。この領域は XAML で定義されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-120">Shared surfaces are sized regions of the display, defined by XAML, that you can use DirectX to draw into indirectly, using [Windows::UI::Xaml::Media::ImageSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imagesource.aspx) types.</span></span> <span data-ttu-id="21ad6-121">共有サーフェイスについては、新しいコンテンツが画面に表示される正確なタイミングを制御する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-121">For shared surfaces, you don't control the precise timing for when new content appears on-screen.</span></span> <span data-ttu-id="21ad6-122">共有サーフェイスの更新は XAML フレームワークの更新に同期されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-122">Rather, updates to the shared surface are synced to the XAML framework's updates.</span></span>
-   <span data-ttu-id="21ad6-123">[スワップ チェーン](https://msdn.microsoft.com/library/windows/desktop/bb206356(v=vs.85).aspx)。最小限の待ち時間でグラフィックスを表示するために使用されるバッファーのコレクションを表します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-123">[Swap chains](https://msdn.microsoft.com/library/windows/desktop/bb206356(v=vs.85).aspx) represent a collection of buffers used to display graphics at minimal latency.</span></span> <span data-ttu-id="21ad6-124">通常、スワップ チェーンは、UI スレッドとは別に、1 秒あたり 60 フレームで更新されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-124">Typically, swap chains are updated at 60 frames per second separately from the UI thread.</span></span> <span data-ttu-id="21ad6-125">ただし、スワップ チェーンは高速な更新をサポートするために、より多くのメモリと CPU リソースを使用します。また、複数のスレッドを管理する必要があるために使用することが難しくなります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-125">However, swap chains use more memory and CPU resources in order to support rapid updates, and are more difficult to use since you have to manage multiple threads.</span></span>

<span data-ttu-id="21ad6-126">次に、DirectX を使う目的を確認します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-126">Consider what you are using DirectX for.</span></span> <span data-ttu-id="21ad6-127">表示ウィンドウのサイズに収まる 1 つのコントロールを作ったりアニメーション化したりするために使うのか、</span><span class="sxs-lookup"><span data-stu-id="21ad6-127">Will it be used to composite or animate a single control that fits within the dimensions of the display window?</span></span> <span data-ttu-id="21ad6-128">ゲームなどのようにリアルタイムでレンダリングして制御する必要がある出力をサーフェイスに表示するのかを確認します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-128">Will it contain output that needs to be rendered and controlled in real-time, as in a game?</span></span> <span data-ttu-id="21ad6-129">このような場合は、おそらくスワップ チェーンを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-129">If so, you will probably need to implement a swap chain.</span></span> <span data-ttu-id="21ad6-130">それ以外の場合は、共有サーフェイスを使用する方法で問題はありません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-130">Otherwise, should be fine using a shared surface.</span></span>

<span data-ttu-id="21ad6-131">DirectX をどのように使うかを決めたら、目的に応じて次のいずれかの Windows ランタイム型を使って、DirectX のレンダリングを UWP アプリに組み込みます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-131">Once you've determined how you intend to use DirectX, you use one of these Windows Runtime types to incorporate DirectX rendering into your UWP app:</span></span>

-   <span data-ttu-id="21ad6-132">静的な画像を構成する場合やイベント駆動型の複雑な画像を描画する場合は、[Windows::UI::Xaml::Media::Imaging::SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) を使って共有サーフェイスに描画します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-132">If you want to compose a static image, or draw a complex image on event-driven intervals, draw to a shared surface with [Windows::UI::Xaml::Media::Imaging::SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041).</span></span> <span data-ttu-id="21ad6-133">これは、サイズが指定された DirectX の描画サーフェイスを処理する型です。</span><span class="sxs-lookup"><span data-stu-id="21ad6-133">This type handles a sized DirectX drawing surface.</span></span> <span data-ttu-id="21ad6-134">通常は、ドキュメントや UI 要素でビットマップとして表示する画像やテクスチャを構成する場合に使います。</span><span class="sxs-lookup"><span data-stu-id="21ad6-134">Typically, you use this type when composing an image or texture as a bitmap for display in a document or UI element.</span></span> <span data-ttu-id="21ad6-135">この型は、高パフォーマンスのゲームのようなリアルタイムのインタラクティビティには適しません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-135">It doesn't work well for real-time interactivity, such as a high-performance game.</span></span> <span data-ttu-id="21ad6-136">**SurfaceImageSource** オブジェクトの更新が XAML ユーザー インターフェイスの更新に同期されるため、フレーム レートが安定しない、リアルタイムの入力に対する応答が遅いなど、ユーザーへの視覚的フィードバックに待ち時間が生じるためです。</span><span class="sxs-lookup"><span data-stu-id="21ad6-136">That's because updates to a **SurfaceImageSource** object are synced to XAML user interface updates, and that can introduce latency into the visual feedback you provide to the user, like a fluctuating frame rate or a perceived poor response to real-time input.</span></span> <span data-ttu-id="21ad6-137">ただし、動的なコントロールやデータ シミュレーションであれば、更新に時間はかからず問題ありません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-137">Updates are still quick enough for dynamic controls or data simulations, though!</span></span>

-   <span data-ttu-id="21ad6-138">画像が画面上のスペースよりも大きく、ユーザーがパンまたはズームできる場合は、[Windows::UI::Xaml::Media::Imaging::VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) を使います。</span><span class="sxs-lookup"><span data-stu-id="21ad6-138">If the image is larger than the provided screen real estate, and can be panned or zoomed by the user, use [Windows::UI::Xaml::Media::Imaging::VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050).</span></span> <span data-ttu-id="21ad6-139">これは、画面よりも大きいサイズが指定された DirectX の描画サーフェイスを処理する型です。</span><span class="sxs-lookup"><span data-stu-id="21ad6-139">This type handles a sized DirectX drawing surface that is larger than the screen.</span></span> <span data-ttu-id="21ad6-140">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) と同様に、複雑な画像やコントロールを動的に構成する場合に使います。</span><span class="sxs-lookup"><span data-stu-id="21ad6-140">Like [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041), you use this when composing a complex image or control dynamically.</span></span> <span data-ttu-id="21ad6-141">また、**SurfaceImageSource** と同様に、高パフォーマンスのゲームには適しません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-141">And, also like **SurfaceImageSource**, it doesn't work well for high-performance games.</span></span> <span data-ttu-id="21ad6-142">**VirtualSurfaceImageSource** を使うことができる XAML 要素には、マップ コントロールや、画像が多い大きなドキュメント ビューアーなどがあります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-142">Some examples of XAML elements that could use a **VirtualSurfaceImageSource** are map controls, or a large, image-dense document viewer.</span></span>

-   <span data-ttu-id="21ad6-143">リアルタイムで更新されるグラフィックスを DirectX を使って表示する場合や、短い待ち時間で定期的に更新を行う必要がある場合は、[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) クラスを使います。これにより、XAML フレームワークの更新タイマーに同期せずにグラフィックスを更新することができます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-143">If you are using DirectX to present graphics updated in real-time, or in a situation where the updates must come on regular low-latency intervals, use the [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) class, so you can refresh the graphics without syncing to the XAML framework refresh timer.</span></span> <span data-ttu-id="21ad6-144">この型を使うと、グラフィックス デバイスのスワップ チェーン ([IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631)) に直接アクセスし、XAML をレンダー ターゲットの上に配置できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-144">This type enables you to access the graphics device's swap chain ([IDXGISwapChain1](https://msdn.microsoft.com/library/windows/desktop/hh404631)) directly and layer XAML atop the render target.</span></span> <span data-ttu-id="21ad6-145">この型は、ゲームなどの全画面の DirectX アプリで XAML ベースのユーザー インターフェイスが必要な場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="21ad6-145">This type works great for games and full-screen DirectX apps that require a XAML-based user interface.</span></span> <span data-ttu-id="21ad6-146">Microsoft DirectX Graphics Infrastructure (DXGI)、Direct2D、Direct3D も含めて、この方法を使うには、DirectX に関する知識が必要です。</span><span class="sxs-lookup"><span data-stu-id="21ad6-146">You must know DirectX well to use this approach, including the Microsoft DirectX Graphics Infrastructure (DXGI), Direct2D, and Direct3D technologies.</span></span> <span data-ttu-id="21ad6-147">詳しくは、「[Direct3D 11 用プログラミング ガイド](https://msdn.microsoft.com/library/windows/desktop/ff476345)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="21ad6-147">For more info, see [Programming Guide for Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476345).</span></span>

## <a name="surfaceimagesource"></a><span data-ttu-id="21ad6-148">SurfaceImageSource</span><span class="sxs-lookup"><span data-stu-id="21ad6-148">SurfaceImageSource</span></span>


<span data-ttu-id="21ad6-149">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) は、DirectX で描画を行うための共有サーフェイスを提供し、ビットからアプリのコンテンツを構成します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-149">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) provides DirectX shared surfaces to draw into and then composes the bits into app content.</span></span>

<span data-ttu-id="21ad6-150">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-150">Here is the basic process for creating and updating a [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) object in the code-behind:</span></span>

1.  <span data-ttu-id="21ad6-151">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) コンストラクターに高さと幅の値を渡して、共有サーフェイスのサイズを定義します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-151">Define the size of the shared surface by passing the height and width to the [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) constructor.</span></span> <span data-ttu-id="21ad6-152">アルファ (不透明度) のサポートが必要かどうかも指定できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-152">You can also indicate whether the surface needs alpha (opacity) support.</span></span>

    <span data-ttu-id="21ad6-153">例:</span><span class="sxs-lookup"><span data-stu-id="21ad6-153">For example:</span></span>

    `SurfaceImageSource^ surfaceImageSource = ref new SurfaceImageSource(400, 300);`

2.  <span data-ttu-id="21ad6-154">[ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137) へのポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-154">Get a pointer to [ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137).</span></span> <span data-ttu-id="21ad6-155">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISurfaceImageSourceNativeWithD2D** 実装を取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-155">Cast the [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) object as [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (or **IUnknown**), and call **QueryInterface** on it to get the underlying **ISurfaceImageSourceNativeWithD2D** implementation.</span></span> <span data-ttu-id="21ad6-156">この実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-156">You use the methods defined on this implementation to set the device and run the draw operations.</span></span>

    ```cpp
    Microsoft::WRL::ComPtr<ISurfaceImageSourceNativeWithD2D> m_sisNativeWithD2D;

    // ...

    IInspectable* sisInspectable = 
        (IInspectable*) reinterpret_cast<IInspectable*>(surfaceImageSource);

    sisInspectable->QueryInterface(
        __uuidof(ISurfaceImageSourceNativeWithD2D), 
        (void **)&m_sisNativeWithD2D);
    ```

3.  <span data-ttu-id="21ad6-157">最初に [D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) と [D2D1CreateDevice](https://msdn.microsoft.com/library/windows/desktop/hh404272(v=vs.85).aspx) を呼び出してから、デバイスとコンテキストを [ISurfaceImageSourceNativeWithD2D::SetDevice](https://msdn.microsoft.com/library/dn302141.aspx) に渡して、DXGI デバイスと D2D デバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-157">Create the DXGI and D2D devices by first calling [D3D11CreateDevice](https://msdn.microsoft.com/library/windows/desktop/ff476082) and [D2D1CreateDevice](https://msdn.microsoft.com/library/windows/desktop/hh404272(v=vs.85).aspx) then passing the device and context to [ISurfaceImageSourceNativeWithD2D::SetDevice](https://msdn.microsoft.com/library/dn302141.aspx).</span></span> 

    > [!NOTE]
    > <span data-ttu-id="21ad6-158">バックグラウンド スレッドから **SurfaceImageSource** に描画する場合は、DXGI デバイスでマルチスレッド アクセスも有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-158">If you will be drawing to your **SurfaceImageSource** from a background thread, you'll also need to ensure that the DXGI device has enabled multi-threaded access.</span></span> <span data-ttu-id="21ad6-159">この有効化は、パフォーマンス上の理由で、バック グラウンド スレッドから描画する場合にのみ行ってください。</span><span class="sxs-lookup"><span data-stu-id="21ad6-159">This should only be done if you will be drawing from a background thread, for performance reasons.</span></span>

    <span data-ttu-id="21ad6-160">例:</span><span class="sxs-lookup"><span data-stu-id="21ad6-160">For example:</span></span>

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

4.  <span data-ttu-id="21ad6-161">[ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/bb174565) オブジェクトへのポインターを [ISurfaceImageSourceNativeWithD2D::BeginDraw](https://msdn.microsoft.com/library/dn302138.aspx) に渡し、返された描画コンテキストを使って、**SurfaceImageSource** 内に目的の四角形のコンテンツを描画します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-161">Provide a pointer to [ID2D1DeviceContext](https://msdn.microsoft.com/library/windows/desktop/bb174565) object to [ISurfaceImageSourceNativeWithD2D::BeginDraw](https://msdn.microsoft.com/library/dn302138.aspx), and use the returned drawing context to draw the contents of the desired rectangle within the **SurfaceImageSource**.</span></span> <span data-ttu-id="21ad6-162">**ISurfaceImageSourceNativeWithD2D::BeginDraw** と描画のコマンドは、バック グラウンド スレッドから呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-162">**ISurfaceImageSourceNativeWithD2D::BeginDraw** and the drawing commands can be called from a background thread.</span></span> <span data-ttu-id="21ad6-163">*updateRect* パラメーターで更新対象として指定した領域だけが描画されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-163">Only the area specified for update in the *updateRect* parameter is drawn.</span></span>

    <span data-ttu-id="21ad6-164">このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-164">This method returns the point (x,y) offset of the updated target rectangle in the *offset* parameter.</span></span> <span data-ttu-id="21ad6-165">このオフセットを使って、更新されたコンテンツを **ID2D1DeviceContext** で描画する位置を特定できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-165">You use this offset to determine where to draw your updated content with the **ID2D1DeviceContext**.</span></span>

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

5. <span data-ttu-id="21ad6-166">[ISurfaceImageSourceNativeWithD2D::EndDraw](https://msdn.microsoft.com/library/dn302139.aspx) を呼び出してビットマップを終了します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-166">Call [ISurfaceImageSourceNativeWithD2D::EndDraw](https://msdn.microsoft.com/library/dn302139.aspx) to complete the bitmap.</span></span> <span data-ttu-id="21ad6-167">ビットマップは、XAML の [Image](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) または [ImageBrush](https://msdn.microsoft.com/library/windows/apps/br210101) のソースとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-167">The bitmap can be used as a source for a XAML [Image](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) or [ImageBrush](https://msdn.microsoft.com/library/windows/apps/br210101).</span></span> <span data-ttu-id="21ad6-168">**ISurfaceImageSourceNativeWithD2D::EndDraw** は、UI スレッドからのみ呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-168">**ISurfaceImageSourceNativeWithD2D::EndDraw** must be called only from the UI thread.</span></span>

    ```cpp
    m_sisNative->EndDraw();

    // ...
    // The SurfaceImageSource object's underlying 
    // ISurfaceImageSourceNativeWithD2D object contains the completed bitmap.

    ImageBrush^ brush = ref new ImageBrush();
    brush->ImageSource = surfaceImageSource;
    ```

    > [!NOTE]
    > <span data-ttu-id="21ad6-169">現在、[SurfaceImageSource::SetSource](https://msdn.microsoft.com/library/windows/apps/br243255) (**IBitmapSource::SetSource** から継承) を呼び出すと例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-169">Calling [SurfaceImageSource::SetSource](https://msdn.microsoft.com/library/windows/apps/br243255) (inherited from **IBitmapSource::SetSource**) currently throws an exception.</span></span> <span data-ttu-id="21ad6-170">[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) オブジェクトからは呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="21ad6-170">Do not call it from your [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) object.</span></span>

    > [!NOTE]
    > <span data-ttu-id="21ad6-171">アプリケーションでは、関連する [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) が非表示になっている間は **SurfaceImageSource** へ描画しないようにする必要があります。描画すると、**ISurfaceImageSourceNativeWithD2D** API が失敗します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-171">Applications must avoid drawing to **SurfaceImageSource** while their associated [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) is hidden, otherwise **ISurfaceImageSourceNativeWithD2D** APIs will fail.</span></span> <span data-ttu-id="21ad6-172">これを行うためには、[Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) イベントのイベント リスナーとして登録し、表示の変更を追跡します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-172">To accomplish this, register as an event listener for the [Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) event to track visibility changes.</span></span>

## <a name="virtualsurfaceimagesource"></a><span data-ttu-id="21ad6-173">VirtualSurfaceImageSource</span><span class="sxs-lookup"><span data-stu-id="21ad6-173">VirtualSurfaceImageSource</span></span>

<span data-ttu-id="21ad6-174">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) は、コンテンツが画面に収まらず、仮想化しないと最適なレンダリングにならない場合に、[SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) を拡張します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-174">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) extends [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) when the content is potentially larger than what can fit on screen and so the content must be virtualized to render optimally.</span></span>

<span data-ttu-id="21ad6-175">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) が [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) と異なる点は、[IVirtualSurfaceImageSourceCallbacksNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337) コールバックを使うことです。このコールバックを実装することで、サーフェイスの領域が画面に表示できるようになったときに領域が更新されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-175">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) differs from [SurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702041) in that it uses a callback, [IVirtualSurfaceImageSourceCallbacksNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337), that you implement to update regions of the surface as they become visible on the screen.</span></span> <span data-ttu-id="21ad6-176">非表示の領域をクリアする必要はありません。この処理は XAML フレームワークで行われます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-176">You do not need to clear regions that are hidden, as the XAML framework takes care of that for you.</span></span>

<span data-ttu-id="21ad6-177">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトをコード ビハインドで作成および更新する基本的なプロセスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-177">Here is the basic process for creating and updating a [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) object in the code-behind:</span></span>

1.  <span data-ttu-id="21ad6-178">サイズを指定して [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) のインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-178">Create an instance of [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) with the size that you want.</span></span> <span data-ttu-id="21ad6-179">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-179">For example:</span></span>

    ```cpp
    VirtualSurfaceImageSource^ virtualSIS = 
        ref new VirtualSurfaceImageSource(2000, 2000);
    ```

2.  <span data-ttu-id="21ad6-180">[IVirtualSurfaceImageSourceNative](https://msdn.microsoft.com/library/windows/desktop/hh848328) と [ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137) へのポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-180">Get pointers to [IVirtualSurfaceImageSourceNative](https://msdn.microsoft.com/library/windows/desktop/hh848328) and [ISurfaceImageSourceNativeWithD2D](https://msdn.microsoft.com/library/windows/desktop/dn302137).</span></span> <span data-ttu-id="21ad6-181">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) または [IUnknown](https://msdn.microsoft.com/library/windows/desktop/ms680509) としてキャストし、それに対する [QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521) を呼び出して、基になる **IVirtualSurfaceImageSourceNative** 実装と **ISurfaceImageSourceNativeWithD2D** 実装を取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-181">Cast the [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) object as [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) or [IUnknown](https://msdn.microsoft.com/library/windows/desktop/ms680509), and call [QueryInterface](https://msdn.microsoft.com/library/windows/desktop/ms682521) on it to get the underlying **IVirtualSurfaceImageSourceNative** and **ISurfaceImageSourceNativeWithD2D** implementations.</span></span> <span data-ttu-id="21ad6-182">これらの実装で定義されているメソッドを使って、デバイスを設定し、描画操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-182">You use the methods defined on these implementations to set the device and run the draw operations.</span></span>

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

3.  <span data-ttu-id="21ad6-183">最初に **D3D11CreateDevice** と **D2D1CreateDevice** を呼び出してから、D2D デバイスを **ISurfaceImageSourceNativeWithD2D::SetDevice** に渡して、DXGI デバイスと D2D デバイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-183">Create the DXGI and D2D devices by first calling **D3D11CreateDevice** and **D2D1CreateDevice**, and then pass the D2D device to **ISurfaceImageSourceNativeWithD2D::SetDevice**.</span></span>

    > [!NOTE]
    > <span data-ttu-id="21ad6-184">バックグラウンド スレッドから **VirtualSurfaceImageSource** に描画する場合は、DXGI デバイスでマルチスレッド アクセスも有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-184">If you will be drawing to your **VirtualSurfaceImageSource** from a background thread, you'll also need to ensure that the DXGI device has enabled multi-threaded access.</span></span> <span data-ttu-id="21ad6-185">この有効化は、パフォーマンス上の理由で、バック グラウンド スレッドから描画する場合にのみ行ってください。</span><span class="sxs-lookup"><span data-stu-id="21ad6-185">This should only be done if you will be drawing from a background thread, for performance reasons.</span></span>

    <span data-ttu-id="21ad6-186">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-186">For example:</span></span>

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

4.  <span data-ttu-id="21ad6-187">[IVirtualSurfaceImageSourceNative::RegisterForUpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334) を呼び出して、[IVirtualSurfaceUpdatesCallbackNative](https://msdn.microsoft.com/library/windows/desktop/hh848336) の実装への参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-187">Call [IVirtualSurfaceImageSourceNative::RegisterForUpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334), passing in a reference to your implementation of [IVirtualSurfaceUpdatesCallbackNative](https://msdn.microsoft.com/library/windows/desktop/hh848336).</span></span>

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

    <span data-ttu-id="21ad6-188">[VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) の領域を更新する必要がある場合、フレームワークで [IVirtualSurfaceUpdatesCallbackNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334) の実装が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-188">The framework calls your implementation of [IVirtualSurfaceUpdatesCallbackNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848334) when a region of the [VirtualSurfaceImageSource](https://msdn.microsoft.com/library/windows/apps/hh702050) needs to be updated.</span></span>

    <span data-ttu-id="21ad6-189">これが発生するのは、領域を描画する必要があるとフレームワークで判断されたとき (ユーザーがサーフェイスのビューをパンまたはズームしたときなど)、およびその領域に対する [IVirtualSurfaceImageSourceNative::Invalidate](https://msdn.microsoft.com/library/windows/desktop/hh848332) がアプリで呼び出されたときです。</span><span class="sxs-lookup"><span data-stu-id="21ad6-189">This can happen either when the framework determines the region needs to be drawn (such as when the user pans or zooms the view of the surface), or after the app has called [IVirtualSurfaceImageSourceNative::Invalidate](https://msdn.microsoft.com/library/windows/desktop/hh848332) on that region.</span></span>

5.  <span data-ttu-id="21ad6-190">[IVirtualSurfaceImageSourceNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337) で、[IVirtualSurfaceImageSourceNative::GetUpdateRectCount](https://msdn.microsoft.com/library/windows/desktop/hh848329) メソッドと [IVirtualSurfaceImageSourceNative::GetUpdateRects](https://msdn.microsoft.com/library/windows/desktop/hh848330) メソッドを使って、描画する必要があるサーフェイスの領域を特定します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-190">In [IVirtualSurfaceImageSourceNative::UpdatesNeeded](https://msdn.microsoft.com/library/windows/desktop/hh848337), use the [IVirtualSurfaceImageSourceNative::GetUpdateRectCount](https://msdn.microsoft.com/library/windows/desktop/hh848329) and [IVirtualSurfaceImageSourceNative::GetUpdateRects](https://msdn.microsoft.com/library/windows/desktop/hh848330) methods to determine which region(s) of the surface must be drawn.</span></span>

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

6.  <span data-ttu-id="21ad6-191">最後に、更新する必要がある領域ごとに以下を行います。</span><span class="sxs-lookup"><span data-stu-id="21ad6-191">Lastly, for each region that must be updated:</span></span>

    1.  <span data-ttu-id="21ad6-192">**ID2D1DeviceContext** オブジェクトへのポインターを **ISurfaceImageSourceNativeWithD2D::BeginDraw** に渡し、返された描画コンテキストを使って、**SurfaceImageSource** 内に目的の四角形のコンテンツを描画します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-192">Provide a pointer to the **ID2D1DeviceContext** object to **ISurfaceImageSourceNativeWithD2D::BeginDraw**, and use the returned drawing context to draw the contents of the desired rectangle within the **SurfaceImageSource**.</span></span> <span data-ttu-id="21ad6-193">**ISurfaceImageSourceNativeWithD2D::BeginDraw** と描画のコマンドは、バック グラウンド スレッドから呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-193">**ISurfaceImageSourceNativeWithD2D::BeginDraw** and the drawing commands can be called from a background thread.</span></span> <span data-ttu-id="21ad6-194">*updateRect* パラメーターで更新対象として指定した領域だけが描画されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-194">Only the area specified for update in the *updateRect* parameter is drawn.</span></span>

        <span data-ttu-id="21ad6-195">このメソッドは、更新されるターゲットの四角形の位置 (x、y) を示すオフセットを *offset* パラメーターで返します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-195">This method returns the point (x,y) offset of the updated target rectangle in the *offset* parameter.</span></span> <span data-ttu-id="21ad6-196">このオフセットを使って、更新されたコンテンツを **ID2D1DeviceContext** で描画する位置を特定できます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-196">You use this offset to determine where to draw your updated content with the **ID2D1DeviceContext**.</span></span>

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

    2.  <span data-ttu-id="21ad6-197">具体的なコンテンツをその領域に描画します。ただし、パフォーマンスを高めるために描画を限られた領域に制限します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-197">Draw the specific content to that region, but constrain your drawing to the bounded regions for better performance.</span></span>

    3.  <span data-ttu-id="21ad6-198">**ISurfaceImageSourceNativeWithD2D::EndDraw** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-198">Call **ISurfaceImageSourceNativeWithD2D::EndDraw**.</span></span> <span data-ttu-id="21ad6-199">結果のビットマップが返されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-199">The result is a bitmap.</span></span>

> [!NOTE]
> <span data-ttu-id="21ad6-200">アプリケーションでは、関連する [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) が非表示になっている間は **SurfaceImageSource** へ描画しないようにする必要があります。描画すると、**ISurfaceImageSourceNativeWithD2D** API が失敗します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-200">Applications must avoid drawing to **SurfaceImageSource** while their associated [Window](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window) is hidden, otherwise **ISurfaceImageSourceNativeWithD2D** APIs will fail.</span></span> <span data-ttu-id="21ad6-201">これを行うためには、[Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) イベントのイベント リスナーとして登録し、表示の変更を追跡します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-201">To accomplish this, register as an event listener for the [Window.VisibilityChanged](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Window.VisibilityChanged) event to track visibility changes.</span></span>

## <a name="swapchainpanel-and-gaming"></a><span data-ttu-id="21ad6-202">SwapChainPanel とゲーム</span><span class="sxs-lookup"><span data-stu-id="21ad6-202">SwapChainPanel and gaming</span></span>


<span data-ttu-id="21ad6-203">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) は、高パフォーマンスのグラフィックスやゲームをサポートするために設計された Windows ランタイム型です。この型でスワップ チェーンを直接管理します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-203">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) is the Windows Runtime type designed to support high-performance graphics and gaming, where you manage the swap chain directly.</span></span> <span data-ttu-id="21ad6-204">この例では、独自の DirectX スワップ チェーンを作成し、レンダリングされるコンテンツの表示を管理します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-204">In this case, you create your own DirectX swap chain and manage the presentation of your rendered content.</span></span>

<span data-ttu-id="21ad6-205">パフォーマンスを高めるために、[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) 型には次のような制限事項があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-205">To ensure good performance, there are certain limitations to the [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) type:</span></span>

-   <span data-ttu-id="21ad6-206">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) インスタンスの数は、アプリごとに 4 つ以下です。</span><span class="sxs-lookup"><span data-stu-id="21ad6-206">There are no more than 4 [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) instances per app.</span></span>
-   <span data-ttu-id="21ad6-207">DirectX スワップ チェーンの高さと幅 ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、スワップ チェーン要素の現在のサイズに設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="21ad6-207">You should set the DirectX swap chain's height and width (in [DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to the current dimensions of the swap chain element.</span></span> <span data-ttu-id="21ad6-208">このように設定しないと、表示されるコンテンツのサイズが自動的に調整されます (**DXGI\_SCALING\_STRETCH** を使用)。</span><span class="sxs-lookup"><span data-stu-id="21ad6-208">If you don't, the display content will be scaled (using **DXGI\_SCALING\_STRETCH**) to fit.</span></span>
-   <span data-ttu-id="21ad6-209">DirectX スワップ チェーンのスケーリング モード ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) は、**DXGI\_SCALING\_STRETCH** に設定する必要があります</span><span class="sxs-lookup"><span data-stu-id="21ad6-209">You must set the DirectX swap chain's scaling mode (in [DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to **DXGI\_SCALING\_STRETCH**.</span></span>
-   <span data-ttu-id="21ad6-210">DirectX スワップ チェーンのアルファ モード ([DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528) で設定) を **DXGI\_ALPHA\_MODE\_PREMULTIPLIED** に設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-210">You can't set the DirectX swap chain's alpha mode (in [DXGI\_SWAP\_CHAIN\_DESC1](https://msdn.microsoft.com/library/windows/desktop/hh404528)) to **DXGI\_ALPHA\_MODE\_PREMULTIPLIED**.</span></span>
-   <span data-ttu-id="21ad6-211">DirectX スワップ チェーンを作成するときは、[IDXGIFactory2::CreateSwapChainForComposition](https://msdn.microsoft.com/library/windows/desktop/hh404558) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-211">You must create the DirectX swap chain by calling [IDXGIFactory2::CreateSwapChainForComposition](https://msdn.microsoft.com/library/windows/desktop/hh404558).</span></span>

<span data-ttu-id="21ad6-212">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) の更新は、XAML フレームワークの更新ではなく、アプリのニーズに基づいて行います。</span><span class="sxs-lookup"><span data-stu-id="21ad6-212">You update the [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) based on the needs of your app, and not the updates of the XAML framework.</span></span> <span data-ttu-id="21ad6-213">**SwapChainPanel** の更新を XAML フレームワークの更新に同期する必要がある場合は、[Windows::UI::Xaml::Media::CompositionTarget::Rendering](https://msdn.microsoft.com/library/windows/apps/br228127) イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-213">If you need to synchronize the updates of **SwapChainPanel** to those of the XAML framework, register for the [Windows::UI::Xaml::Media::CompositionTarget::Rendering](https://msdn.microsoft.com/library/windows/apps/br228127) event.</span></span> <span data-ttu-id="21ad6-214">このイベントに登録しないと、**SwapChainPanel** を更新するスレッドと異なるスレッドから XAML 要素を更新する場合に、クロス スレッドの問題についての検討が必要になります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-214">Otherwise, you must consider any cross-thread issues if you try to update the XAML elements from a different thread than the one updating the **SwapChainPanel**.</span></span>

<span data-ttu-id="21ad6-215">**SwapChainPanel** に対する待機時間の短いポインター入力を受信する必要がある場合は、[SwapChainPanel::CreateCoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.swapchainpanel.createcoreindependentinputsource) を使用します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-215">If you need to receive low-latency pointer input to your **SwapChainPanel**, use [SwapChainPanel::CreateCoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.swapchainpanel.createcoreindependentinputsource).</span></span> <span data-ttu-id="21ad6-216">このメソッドは、バックグラウンド スレッドで最小限の待機時間で入力イベントを受信するために使用できる [CoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coreindependentinputsource) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-216">This method returns a [CoreIndependentInputSource](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coreindependentinputsource) object that can be used to receive input events at minimal latency on a background thread.</span></span> <span data-ttu-id="21ad6-217">このメソッドが呼び出されると、すべての入力がバックグラウンド スレッドにリダイレクトされるため、**SwapChainPanel** について通常の XAML ポインター入力イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="21ad6-217">Note that once this method is called, normal XAML pointer input events will not be fired for the **SwapChainPanel**, since all input will be redirected to the background thread.</span></span>


> <span data-ttu-id="21ad6-218">**注**   一般に、DirectX アプリでは、サイズが表示ウィンドウのサイズ (通常は、ほとんどの Microsoft Store ゲームのネイティブの画面解像度) と同じである横方向のスワップ チェーンを作る必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-218">**Note**   In general, your DirectX apps should create swap chains in landscape orientation, and equal to the display window size (which is usually the native screen resolution in most Microsoft Store games).</span></span> <span data-ttu-id="21ad6-219">これにより、表示される XAML オーバーレイがない場合はアプリで最適なスワップ チェーンの実装が使われます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-219">This ensures that your app uses the optimal swap chain implementation when it doesn't have any visible XAML overlay.</span></span> <span data-ttu-id="21ad6-220">縦モードに回転した場合、アプリは既にあるスワップ チェーンで [IDXGISwapChain1::SetRotation](https://msdn.microsoft.com/library/windows/desktop/hh446801) を呼び出し、必要に応じてコンテンツに変換を適用して、同じスワップ チェーンで [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144) をもう一度呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-220">If the app is rotated to portrait mode, your app should call [IDXGISwapChain1::SetRotation](https://msdn.microsoft.com/library/windows/desktop/hh446801) on the existing swap chain, apply a transform to the content if needed, and then call [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144) again on the same swap chain.</span></span> <span data-ttu-id="21ad6-221">同様に、アプリは、[IDXGISwapChain::ResizeBuffers](https://msdn.microsoft.com/library/windows/desktop/bb174577) 呼び出しによってスワップ チェーンのサイズが変更されるたびに、同じスワップ チェーンで **SetSwapChain** をもう一度呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="21ad6-221">Similarly, your app should call **SetSwapChain** again on the same swap chain whenever the swap chain is resized by calling [IDXGISwapChain::ResizeBuffers](https://msdn.microsoft.com/library/windows/desktop/bb174577).</span></span>


 

<span data-ttu-id="21ad6-222">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトをコード ビハインドで作って更新する基本的なプロセスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-222">Here is basic process for creating and updating a [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) object in the code-behind:</span></span>

1.  <span data-ttu-id="21ad6-223">アプリのスワップ チェーン パネルのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-223">Get an instance of a swap chain panel for your app.</span></span> <span data-ttu-id="21ad6-224">これらのインスタンスは、XAML では `<SwapChainPanel>` タグを使って示されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-224">The instances are indicated in your XAML with the `<SwapChainPanel>` tag.</span></span>

    `Windows::UI::Xaml::Controls::SwapChainPanel^ swapChainPanel;`

    <span data-ttu-id="21ad6-225">`<SwapChainPanel>` タグの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-225">Here is an example `<SwapChainPanel>` tag.</span></span>

    ```xml
    <SwapChainPanel x:Name="swapChainPanel">
        <SwapChainPanel.ColumnDefinitions>
            <ColumnDefinition Width="300*"/>
            <ColumnDefinition Width="1069*"/>
        </SwapChainPanel.ColumnDefinitions>
    …
    ```

2.  <span data-ttu-id="21ad6-226">[ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143) へのポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-226">Get a pointer to [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143).</span></span> <span data-ttu-id="21ad6-227">[SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) オブジェクトを [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (または **IUnknown**) としてキャストし、それに対する **QueryInterface** を呼び出して、基になる **ISwapChainPanelNative** 実装を取得します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-227">Cast the [SwapChainPanel](https://msdn.microsoft.com/library/windows/apps/dn252834) object as [IInspectable](https://msdn.microsoft.com/library/windows/desktop/br205821) (or **IUnknown**), and call **QueryInterface** on it to get the underlying **ISwapChainPanelNative** implementation.</span></span>

    ```cpp
    Microsoft::WRL::ComPtr<ISwapChainPanelNative> m_swapChainNative;
    // ...
    IInspectable* panelInspectable = (IInspectable*) reinterpret_cast<IInspectable*>(swapChainPanel);
    panelInspectable->QueryInterface(__uuidof(ISwapChainPanelNative), (void **)&m_swapChainNative);
    ```

3.  <span data-ttu-id="21ad6-228">DXGI デバイスとスワップ チェーンを作成し、スワップ チェーンを [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144) に渡して [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143) に設定します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-228">Create the DXGI device and the swap chain, and set the swap chain to [ISwapChainPanelNative](https://msdn.microsoft.com/library/windows/desktop/dn302143) by passing it to [SetSwapChain](https://msdn.microsoft.com/library/windows/desktop/dn302144).</span></span>

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

4.  <span data-ttu-id="21ad6-229">DirectX スワップ チェーンに描画し、それを渡してコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="21ad6-229">Draw to the DirectX swap chain, and present it to display the contents.</span></span>

    ```cpp
    HRESULT hr = m_swapChain->Present(1, 0);
    ```

    <span data-ttu-id="21ad6-230">XAML 要素は、Windows ランタイムのレイアウトやレンダリング ロジックから更新が通知されると更新されます。</span><span class="sxs-lookup"><span data-stu-id="21ad6-230">The XAML elements are refreshed when the Windows Runtime layout/render logic signals an update.</span></span>

## <a name="related-topics"></a><span data-ttu-id="21ad6-231">関連トピック</span><span class="sxs-lookup"><span data-stu-id="21ad6-231">Related topics</span></span>

* [<span data-ttu-id="21ad6-232">Win2D</span><span class="sxs-lookup"><span data-stu-id="21ad6-232">Win2D</span></span>](https://microsoft.github.io/Win2D/html/Introduction.htm)
* [<span data-ttu-id="21ad6-233">SurfaceImageSource</span><span class="sxs-lookup"><span data-stu-id="21ad6-233">SurfaceImageSource</span></span>](https://msdn.microsoft.com/library/windows/apps/hh702041)
* [<span data-ttu-id="21ad6-234">VirtualSurfaceImageSource</span><span class="sxs-lookup"><span data-stu-id="21ad6-234">VirtualSurfaceImageSource</span></span>](https://msdn.microsoft.com/library/windows/apps/hh702050)
* [<span data-ttu-id="21ad6-235">SwapChainPanel</span><span class="sxs-lookup"><span data-stu-id="21ad6-235">SwapChainPanel</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252834)
* [<span data-ttu-id="21ad6-236">ISwapChainPanelNative</span><span class="sxs-lookup"><span data-stu-id="21ad6-236">ISwapChainPanelNative</span></span>](https://msdn.microsoft.com/library/windows/desktop/dn302143)
* [<span data-ttu-id="21ad6-237">Direct3D 11 用プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="21ad6-237">Programming Guide for Direct3D 11</span></span>](https://msdn.microsoft.com/library/windows/desktop/ff476345)

 

 




