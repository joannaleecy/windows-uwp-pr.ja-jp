---
author: eliotcowley
title: 画面キャプチャ
description: Windows.Graphics.Capture 名前空間 には、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、コラボレーティブでインタラクティブなエクスペリエンスを構築できます。
ms.assetid: 349C959D-9C74-44E7-B5F6-EBDB5CA87B9F
ms.author: elcowle
ms.date: 5/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 画面キャプチャ
ms.localizationpriority: medium
ms.openlocfilehash: e407842711d1bfcac0a54fdf484a38d39bc2b237
ms.sourcegitcommit: f9690c33bb85f84466560efac6f23cca2daf5a02
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2018
ms.locfileid: "1912910"
---
# <a name="screen-capture"></a><span data-ttu-id="37ee5-104">画面キャプチャ</span><span class="sxs-lookup"><span data-stu-id="37ee5-104">Screen capture</span></span>

<span data-ttu-id="37ee5-105">Windows 10、バージョン 1803 以降では、[Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture) に、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、共同作業に対応したインタラクティブなエクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-105">Starting in Windows 10, version 1803, the [Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture) namespace provides APIs to acquire frames from a display or application window, to create video streams or snapshots to build collaborative and interactive experiences.</span></span>

<span data-ttu-id="37ee5-106">画面キャプチャでは、開発者がセキュリティで保護されたシステム UI を起動し、エンド ユーザーがこれを使ってキャプチャ対象のディスプレイまたはアプリケーション ウィンドウを選択すると、アクティブにキャプチャされた項目の周囲に、それを通知する黄色の枠線がシステムによって描画されます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-106">With screen capture, developers invoke secure system UI for end users to pick the display or application window to be captured, and a yellow notification border is drawn by the system around the actively captured item.</span></span> <span data-ttu-id="37ee5-107">複数の同時キャプチャ セッションの場合は、キャプチャされる各項目が黄色の枠線で囲まれます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-107">In the case of multiple simultaneous capture sessions, a yellow border is drawn around each item being captured.</span></span>

> [!NOTE]
> <span data-ttu-id="37ee5-108">画面のキャプチャ API では、Windows 10 Pro または Enterprise が実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-108">The screen capture APIs require you to be running Windows 10 Pro or Enterprise.</span></span>

## <a name="add-the-screen-capture-capability"></a><span data-ttu-id="37ee5-109">画面キャプチャ機能を追加する</span><span class="sxs-lookup"><span data-stu-id="37ee5-109">Add the screen capture capability</span></span>

<span data-ttu-id="37ee5-110">**Windows.Graphics.Capture** 名前空間にある API を使用するには、一般的な機能をアプリケーションのマニフェストで宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-110">The APIs found in the **Windows.Graphics.Capture** namespace require a general capability to be declared in your application's manifest.</span></span> <span data-ttu-id="37ee5-111">この機能はファイルに直接追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-111">You must add this directly to the file:</span></span>
    
1. <span data-ttu-id="37ee5-112">**ソリューション エクスプローラー**で、**[Package.appxmanifest]** を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-112">Right-click **Package.appxmanifest** in the **Solution Explorer**.</span></span> 
2. <span data-ttu-id="37ee5-113">**[プログラムから開く]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-113">Select **Open With...**</span></span> 
3. <span data-ttu-id="37ee5-114">**[XML (テキスト) エディター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-114">Choose **XML (Text) Editor**.</span></span> 
4. <span data-ttu-id="37ee5-115">**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-115">Select **OK**.</span></span>
5. <span data-ttu-id="37ee5-116">**[パッケージ]** ノードで、`xmlns:uap6="http://schemas.microsoft.com/appx/manifest/uap/windows10/6"` 属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-116">In the **Package** node, add the following attribute:  `xmlns:uap6="http://schemas.microsoft.com/appx/manifest/uap/windows10/6"`</span></span>
6. <span data-ttu-id="37ee5-117">同じく **[パッケージ]** ノードで、**IgnorableNamespaces** 属性に `uap6` を追加します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-117">Also in the **Package** node, add the following to the **IgnorableNamespaces** attribute:  `uap6`</span></span>
7. <span data-ttu-id="37ee5-118">**[機能]** ノードで、`<uap6:Capability Name="graphicsCapture"/>` 要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-118">In the **Capabilities** node, add the following element:  `<uap6:Capability Name="graphicsCapture"/>`</span></span>

## <a name="launch-the-system-ui-to-start-screen-capture"></a><span data-ttu-id="37ee5-119">システム UI を起動して画面キャプチャを開始する</span><span class="sxs-lookup"><span data-stu-id="37ee5-119">Launch the system UI to start screen capture</span></span>

<span data-ttu-id="37ee5-120">システム UI を起動する前に、アプリケーションが現在、画面キャプチャに対応しているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-120">Before launching the system UI, you can check to see if your application is currently able to take screen captures.</span></span> <span data-ttu-id="37ee5-121">アプリケーションで画面キャプチャを使用できなくなる理由はいくつかあります。たとえば、デバイスがハードウェア要件を満たしていない場合や、キャプチャ対象のアプリケーションが画面キャプチャをブロックしている場合などです。</span><span class="sxs-lookup"><span data-stu-id="37ee5-121">There are several reasons why your application might not be able to use screen capture, including if the device does not meet hardware requirements or if the application targeted for capture blocks screen capture.</span></span> <span data-ttu-id="37ee5-122">[GraphicsCaptureSession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession) クラスで **IsSupported** メソッドを使用して、UWP の画面キャプチャがサポートされているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-122">Use the **IsSupported** method in the [GraphicsCaptureSession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession) class to determine if UWP screen capture is supported:</span></span>

```cs
// This runs when the application starts.
public void OnInitialization()
{
    if (!GraphicsCaptureSession.IsSupported()) 
    {
        // Hide the capture UI if screen capture is not supported.
        CaptureButton.Visibility = Visibility.Collapsed; 
    }    
}
```

<span data-ttu-id="37ee5-123">画面キャプチャがサポートされていることを確認したら、[GraphicsCapturePicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker) クラスを使用して、システム ピッカー UI を起動します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-123">Once you've verified that screen capture is supported, use the [GraphicsCapturePicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker) class to invoke the system picker UI.</span></span> <span data-ttu-id="37ee5-124">エンド ユーザーは、この UI を使用して、画面キャプチャするディスプレイまたはアプリケーション ウィンドウを選択します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-124">The end user uses this UI to select the display or application window of which to take screen captures.</span></span> <span data-ttu-id="37ee5-125">ピッカーによって [GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)が返されます。これは、**GraphicsCaptureSession** の作成に使用します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-125">The picker will return a [GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem) that will be used to create a **GraphicsCaptureSession**:</span></span>

```cs
public async Task StartCaptureAsync() 
{ 
    // The GraphicsCapturePicker follows the same pattern the 
    // file pickers do. 
    var picker = new GraphicsCapturePicker(); 
    GraphicsCaptureItem item = await picker.PickSingleItemAsync(); 

    // The item may be null if the user dismissed the 
    // control without making a selection or hit Cancel. 
    if (item != null) 
    {
        // We'll define this method later in the document.
        StartCaptureInternal(item); 
    } 
}
```

## <a name="create-a-capture-frame-pool-and-capture-session"></a><span data-ttu-id="37ee5-126">キャプチャ フレーム プールとキャプチャ セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="37ee5-126">Create a capture frame pool and capture session</span></span>

<span data-ttu-id="37ee5-127">**GraphicsCaptureItem** を使用し、対象の D3D デバイス、サポートされるピクセル形式 (**DXGI\_FORMAT\_B8G8R8A8\_UNORM**)、目的のフレーム数 (任意の整数)、フレーム サイズを指定して、[Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool) を作成します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-127">Using the **GraphicsCaptureItem**, you will create a [Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool) with your D3D device, supported pixel format (**DXGI\_FORMAT\_B8G8R8A8\_UNORM**), number of desired frames (which can be any integer), and frame size.</span></span> <span data-ttu-id="37ee5-128">**GraphicsCaptureItem** クラスの **ContentSize** プロパティをフレーム サイズとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-128">The **ContentSize** property of the **GraphicsCaptureItem** class can be used as the size of your frame:</span></span>

```cs
private GraphicsCaptureItem _item;
private Direct3D11CaptureFramePool _framePool;
private CanvasDevice _canvasDevice;
private GraphicsCaptureSession _session;

public void StartCaptureInternal(GraphicsCaptureItem item) 
{
    _item = item;

    _framePool = Direct3D11CaptureFramePool.Create( 
        _canvasDevice, // D3D device 
        DirectXPixelFormat.B8G8R8A8UIntNormalized, // Pixel format 
        2, // Number of frames 
        _item.Size); // Size of the buffers   
} 
```

<span data-ttu-id="37ee5-129">次に、**GraphicsCaptureItem** を **CreateCaptureSession** メソッドに渡して、**Direct3D11CaptureFramePool** の **GraphicsCaptureSession** クラスのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-129">Next, get an instance of the **GraphicsCaptureSession** class for your **Direct3D11CaptureFramePool** by passing the **GraphicsCaptureItem** to the **CreateCaptureSession** method:</span></span>

```cs
_session = _framePool.CreateCaptureSession(_item);
```

<span data-ttu-id="37ee5-130">システム UI でユーザーがアプリケーション ウィンドウまたはディスプレイのキャプチャに明示的に同意すると、**GraphicsCaptureItem** を複数の **CaptureSession** オブジェクトに関連付けることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-130">Once the user has explicitly given consent to capturing an application window or display in the system UI, the **GraphicsCaptureItem** can be associated to multiple **CaptureSession** objects.</span></span> <span data-ttu-id="37ee5-131">これにより、アプリケーションは、同じ項目をさまざまなエクスペリエンス向けにキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-131">This way your application can choose to capture the same item for various experiences.</span></span>

<span data-ttu-id="37ee5-132">同時に複数の項目をキャプチャするには、キャプチャする項目ごとにアプリケーションがキャプチャ セッションを作成する必要があり、それにはキャプチャする項目ごとにピッカー UI を起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-132">To capture multiple items at the same time, your application must create a capture session for each item to be captured, which requires invoking the picker UI for each item that is to be captured.</span></span>

## <a name="acquire-capture-frames"></a><span data-ttu-id="37ee5-133">キャプチャ フレームを取得する</span><span class="sxs-lookup"><span data-stu-id="37ee5-133">Acquire capture frames</span></span>

<span data-ttu-id="37ee5-134">フレーム プールとキャプチャ セッションを作成した後、**GraphicsCaptureSession** インスタンスで **StartCapture** メソッドを呼び出して、アプリへのキャプチャ フレームの送信を開始することをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-134">With your frame pool and capture session created, call the **StartCapture** method on your **GraphicsCaptureSession** instance to notify the system to start sending capture frames to your app:</span></span>

```cs
_session.StartCapture();
```

<span data-ttu-id="37ee5-135">これらのキャプチャー フレーム、つまり [Direct3D11CaptureFrame](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe)オブジェクトを取得するには、**Direct3D11CaptureFramePool.FrameArrived** イベントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-135">To acquire these capture frames, which are [Direct3D11CaptureFrame](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe) objects, you can use the **Direct3D11CaptureFramePool.FrameArrived** event:</span></span>

```cs
_framePool.FrameArrived += (s, a) => 
{ 
    // The FrameArrived event fires for every frame on the thread that         
    // created the Direct3D11CaptureFramePool. This means we don't have to 
    // do a null-check here, as we know we're the only one  
    // dequeueing frames in our application.  

    // NOTE: Disposing the frame retires it and returns  
    // the buffer to the pool.
    using (var frame = _framePool.TryGetNextFrame()) 
    {
        // We'll define this method later in the document.
        ProcessFrame(frame); 
    }  
}; 
```

<span data-ttu-id="37ee5-136">UI スレッドで **FrameArrived** を使用することはできれば避けることをお勧めします。このイベントは新しいフレームが使用可能になるたびに発生するため、頻繁に発生します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-136">It is recommended to avoid using the UI thread if possible for **FrameArrived**, as this event will be raised every time a new frame is available, which will be frequent.</span></span> <span data-ttu-id="37ee5-137">それでもなお UI スレッドで **FrameArrived** をリッスンする場合は、イベントが発生するたびにどの程度の作業が必要になるかを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="37ee5-137">If you do choose to listen to **FrameArrived** on the UI thread, be mindful of how much work you're doing every time the event fires.</span></span>

<span data-ttu-id="37ee5-138">これに代わる方法として、**Direct3D11CaptureFramePool.TryGetNextFrame**メソッドを使用し、必要なフレームをすべて取得し終わるまで、フレームを手動で取得することができます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-138">Alternatively, you can manually pull frames with the **Direct3D11CaptureFramePool.TryGetNextFrame** method until you get all of the frames that you need.</span></span>

<span data-ttu-id="37ee5-139">**Direct3D11CaptureFrame**オブジェクトには、**ContentSize**、**Surface**、**SystemRelativeTime** の 3 つのプロパティが含まれています</span><span class="sxs-lookup"><span data-stu-id="37ee5-139">The **Direct3D11CaptureFrame** object contains the properties **ContentSize**, **Surface**, and **SystemRelativeTime**.</span></span> <span data-ttu-id="37ee5-140">**SystemRelativeTime** は、他のメディア要素との同期に使用する QPC ([QueryPerformanceCounter](https://msdn.microsoft.com/library/windows/desktop/ms644904)) 時間です。</span><span class="sxs-lookup"><span data-stu-id="37ee5-140">The **SystemRelativeTime** is QPC ([QueryPerformanceCounter](https://msdn.microsoft.com/library/windows/desktop/ms644904)) time that can be used to synchronize other media elements.</span></span>

## <a name="processing-capture-frames"></a><span data-ttu-id="37ee5-141">キャプチャ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="37ee5-141">Processing capture frames</span></span>

<span data-ttu-id="37ee5-142">**Direct3D11CaptureFramePool** の各フレームは、**TryGetNextFrame** を呼び出したときにチェック アウトされ、**Direct3D11CaptureFrame** オブジェクトの有効期間に従ってチェック インされます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-142">Each frame from the **Direct3D11CaptureFramePool** is checked out when calling **TryGetNextFrame**, and checked back in according to the lifetime of the **Direct3D11CaptureFrame** object.</span></span> <span data-ttu-id="37ee5-143">ネイティブ アプリケーションの場合、**Direct3D11CaptureFrame** オブジェクトを解放するだけで、フレームがフレーム プールにチェック インされます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-143">For native applications, releasing the **Direct3D11CaptureFrame** object is enough to check the frame back in to the frame pool.</span></span> <span data-ttu-id="37ee5-144">管理されているアプリケーションの場合は、**Direct3D11CaptureFrame.Dispose** (C++ では **Close**) メソッドの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-144">For managed applications, it is recommended to use the **Direct3D11CaptureFrame.Dispose** (**Close** in C++) method.</span></span> <span data-ttu-id="37ee5-145">**Direct3D11CaptureFrame** によって [IClosable](https://docs.microsoft.com/uwp/api/Windows.Foundation.IClosable) インターフェイスが実装されます。これは C# の呼び出し元に、[IDisposable](https://msdn.microsoft.com/library/system.idisposable.aspx) として投影されます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-145">**Direct3D11CaptureFrame** implements the [IClosable](https://docs.microsoft.com/uwp/api/Windows.Foundation.IClosable) interface, which is projected as [IDisposable](https://msdn.microsoft.com/library/system.idisposable.aspx) for C# callers.</span></span>

<span data-ttu-id="37ee5-146">フレームのチェックイン後、アプリケーションは、**Direct3D11CaptureFrame** オブジェクトへの参照を保存してはならず、その基になる Direct3D サーフェスへの参照も保存できません。</span><span class="sxs-lookup"><span data-stu-id="37ee5-146">Applications should not save references to **Direct3D11CaptureFrame** objects, nor should they save references to the underlying Direct3D surface after the frame has been checked back in.</span></span>

<span data-ttu-id="37ee5-147">フレームの処理中は、アプリケーションによって、[ID3D11Multithread](https://msdn.microsoft.com/library/windows/desktop/mt644886) を **Direct3D11CaptureFramePool** オブジェクトに関連付けられた同じデバイスにロックすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-147">While processing a frame, it is recommended that applications take the [ID3D11Multithread](https://msdn.microsoft.com/library/windows/desktop/mt644886) lock on the same device that is associated with the **Direct3D11CaptureFramePool** object.</span></span>

<span data-ttu-id="37ee5-148">基になる Direct3D サーフェスは、常に **Direct3D11CaptureFramePool** の作成時 (または再作成時) に指定されたサイズとなります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-148">The underlying Direct3D surface will always be the size specified when creating (or recreating) the **Direct3D11CaptureFramePool**.</span></span> <span data-ttu-id="37ee5-149">コンテンツがフレームよりも大きい場合、コンテンツはフレームのサイズにクリップされます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-149">If content is larger than the frame, the contents are clipped to the size of the frame.</span></span> <span data-ttu-id="37ee5-150">コンテンツがフレームより小さい場合、フレームの残りの部分には未定義のデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-150">If the content is smaller than the frame, then the rest of the frame contains undefined data.</span></span> <span data-ttu-id="37ee5-151">未定義のコンテンツが表示されないように、アプリケーションで、その **Direct3D11CaptureFrame** の **ContentSize** プロパティを使用して、サブ矩形をコピーして取り出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-151">It is recommended that applications copy out a sub-rect using the **ContentSize** property for that **Direct3D11CaptureFrame** to avoid showing undefined content.</span></span>

## <a name="react-to-capture-item-resizing-or-device-lost"></a><span data-ttu-id="37ee5-152">キャプチャ項目のサイズ変更またはデバイス喪失に対応する</span><span class="sxs-lookup"><span data-stu-id="37ee5-152">React to capture item resizing or device lost</span></span>

<span data-ttu-id="37ee5-153">キャプチャ プロセス中に、アプリケーションで **Direct3D11CaptureFramePool** について変更が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-153">During the capture process, applications may wish to change aspects of their **Direct3D11CaptureFramePool**.</span></span> <span data-ttu-id="37ee5-154">たとえば、新しい Direct3D デバイスの提供や、フレーム バッファー サイズの変更、さらにプール内のバッファー数の変更などの場合です。</span><span class="sxs-lookup"><span data-stu-id="37ee5-154">This includes providing a new Direct3D device, changing the size of the frame buffers, or even changing the number of buffers within the pool.</span></span> <span data-ttu-id="37ee5-155">このような各シナリオでは、**Direct3D11CaptureFramePool**  オブジェクトに対して **Recreate** メソッドを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-155">In each of these scenarios, the **Recreate** method on the **Direct3D11CaptureFramePool** object is the recommended tool.</span></span>

<span data-ttu-id="37ee5-156">**Recreate** を呼び出すと、すべての既存のフレームが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="37ee5-156">When **Recreate** is called, all existing frames are discarded.</span></span> <span data-ttu-id="37ee5-157">これにより、アプリケーションがアクセスできなくなったデバイスの Direct3D サーフェスを基とするフレームが渡されることがなくなります。</span><span class="sxs-lookup"><span data-stu-id="37ee5-157">This is to prevent handing out frames whose underlying Direct3D surfaces belong to a device that the application may no longer have access to.</span></span> <span data-ttu-id="37ee5-158">このため、**Recreate** を呼び出す前に、保留中のすべてのフレームを処理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="37ee5-158">For this reason, it may be wise to process all pending frames before calling **Recreate**.</span></span>

## <a name="putting-it-all-together"></a><span data-ttu-id="37ee5-159">完成したコードの例</span><span class="sxs-lookup"><span data-stu-id="37ee5-159">Putting it all together</span></span>

<span data-ttu-id="37ee5-160">以下のコード スニペットは、UWP アプリケーションで画面キャプチャを実装するエンドツーエンドの例を示します。</span><span class="sxs-lookup"><span data-stu-id="37ee5-160">The following code snippet is an end-to-end example of how to implement screen capture in a UWP application:</span></span>

```cs
using Microsoft.Graphics.Canvas;
using System;
using System.Threading.Tasks;
using Windows.Graphics;
using Windows.Graphics.Capture;
using Windows.Graphics.DirectX;
using Windows.UI.Composition;

namespace CaptureSamples 
{
    class Sample
    {
        // Capture API objects.
        private SizeInt32 _lastSize; 
        private GraphicsCaptureItem _item; 
        private Direct3D11CaptureFramePool _framePool; 
        private GraphicsCaptureSession _session; 

        // Non-API related members.
        private CanvasDevice _canvasDevice; 
        private CompositionDrawingSurface _surface; 

        public async Task StartCaptureAsync() 
        { 
            // The GraphicsCapturePicker follows the same pattern the 
            // file pickers do. 
            var picker = new GraphicsCapturePicker(); 
            GraphicsCaptureItem item = await picker.PickSingleItemAsync(); 
 
            // The item may be null if the user dismissed the 
            // control without making a selection or hit Cancel. 
            if (item != null) 
            { 
                StartCaptureInternal(item); 
            }
        } 
 
        private void StartCaptureInternal(GraphicsCaptureItem item) 
        { 
             // Stop the previous capture if we had one.
            StopCapture(); 
 
            _item = item; 
            _lastSize = _item.Size; 
 
             _framePool = Direct3D11CaptureFramePool.Create( 
                _canvasDevice, // D3D device 
                DirectXPixelFormat.B8G8R8A8UIntNormalized, // Pixel format 
                2, // Number of frames 
                _item.Size); // Size of the buffers 
 
            _framePool.FrameArrived += (s, a) => 
            { 
                // The FrameArrived event is raised for every frame on the thread
                // that created the Direct3D11CaptureFramePool. This means we 
                // don't have to do a null-check here, as we know we're the only 
                // one dequeueing frames in our application.  
 
                // NOTE: Disposing the frame retires it and returns  
                // the buffer to the pool.
 
                using (var frame = _framePool.TryGetNextFrame()) 
                { 
                    ProcessFrame(frame); 
                }  
            }; 
 
            _item.Closed += (s, a) => 
            { 
                StopCapture(); 
            }; 
 
            _session = _framePool.CreateCaptureSession(_item); 
            _session.Start(); 
        } 
 
        public void StopCapture() 
        { 
            _session?.Dispose(); 
            _framePool?.Dispose(); 
            _item = null; 
            _session = null; 
            _framePool = null; 
        } 
 
        private void ProcessFrame(Direct3D11CaptureFrame frame) 
        { 
            // Resize and device-lost leverage the same function on the
            // Direct3D11CaptureFramePool. Refactoring it this way avoids 
            // throwing in the catch block below (device creation could always 
            // fail) along with ensuring that resize completes successfully and 
            // isn’t vulnerable to device-lost.   
            bool needsReset = false; 
            bool recreateDevice = false; 
 
            if ((frame.ContentSize.Width != _lastSize.Width) || 
                (frame.ContentSize.Height != _lastSize.Height)) 
            { 
                needsReset = true; 
                _lastSize = frame.ContentSize; 
            } 
            
            try 
            { 
                // Take the D3D11 surface and draw it into a  
                // Composition surface.
 
                // Convert our D3D11 surface into a Win2D object.
                var canvasBitmap = CanvasBitmap.CreateFromDirect3D11Surface( 
                    _canvasDevice, 
                    frame.Surface); 
 
                // Helper that handles the drawing for us, not shown. 
                FillSurfaceWithBitmap(_surface, canvasBitmap); 
            } 
            // This is the device-lost convention for Win2D.
            catch(Exception e) when (_canvasDevice.IsDeviceLost(e.HResult)) 
            { 
                // We lost our graphics device. Recreate it and reset 
                // our Direct3D11CaptureFramePool.  
                needsReset = true; 
                recreateDevice = true; 
            } 
 
            if (needsReset) 
            { 
                ResetFramePool(frame.ContentSize, recreateDevice); 
            }
        } 
 
        private void ResetFramePool(Vector2 size, bool recreateDevice) 
        { 
            do 
            { 
                try 
                { 
                    if (recreateDevice) 
                    { 
                        _canvasDevice = new CanvasDevice(); 
                    } 
 
                    _framePool.Recreate( 
                        _canvasDevice,  
                        DirectXPixelFormat.B8G8R8A8UIntNormalized,  
                        2, 
                        size); 
                } 
                // This is the device-lost convention for Win2D.
                catch(Exception e) when (_canvasDevice.IsDeviceLost(e.HResult)) 
                { 
                    _canvasDevice = null; 
                    recreateDevice = true; 
                } 
            } while (_canvasDevice == null); 
        } 
    } 
} 
```

## <a name="see-also"></a><span data-ttu-id="37ee5-161">関連項目</span><span class="sxs-lookup"><span data-stu-id="37ee5-161">See also</span></span>

* [<span data-ttu-id="37ee5-162">Windows.Graphics.Capture 名前空間</span><span class="sxs-lookup"><span data-stu-id="37ee5-162">Windows.Graphics.Capture Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.graphics.capture)