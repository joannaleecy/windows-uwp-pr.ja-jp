---
title: 画面キャプチャ
description: Windows.Graphics.Capture 名前空間 には、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、コラボレーティブでインタラクティブなエクスペリエンスを構築できます。
ms.assetid: 349C959D-9C74-44E7-B5F6-EBDB5CA87B9F
ms.date: 11/30/2018
ms.topic: article
keywords: Windows 10, UWP, 画面キャプチャ
ms.localizationpriority: medium
ms.openlocfilehash: db32db6b293dce4210bebee139e05447da996b42
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8946503"
---
# <a name="screen-capture"></a><span data-ttu-id="6848d-104">画面キャプチャ</span><span class="sxs-lookup"><span data-stu-id="6848d-104">Screen capture</span></span>

<span data-ttu-id="6848d-105">Windows 10、バージョン 1803 以降では、[Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture) に、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、共同作業に対応したインタラクティブなエクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="6848d-105">Starting in Windows 10, version 1803, the [Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture) namespace provides APIs to acquire frames from a display or application window, to create video streams or snapshots to build collaborative and interactive experiences.</span></span>

<span data-ttu-id="6848d-106">画面キャプチャでは、開発者がセキュリティで保護されたシステム UI を起動し、エンド ユーザーがこれを使ってキャプチャ対象のディスプレイまたはアプリケーション ウィンドウを選択すると、アクティブにキャプチャされた項目の周囲に、それを通知する黄色の枠線がシステムによって描画されます。</span><span class="sxs-lookup"><span data-stu-id="6848d-106">With screen capture, developers invoke secure system UI for end users to pick the display or application window to be captured, and a yellow notification border is drawn by the system around the actively captured item.</span></span> <span data-ttu-id="6848d-107">複数の同時キャプチャ セッションの場合は、キャプチャされる各項目が黄色の枠線で囲まれます。</span><span class="sxs-lookup"><span data-stu-id="6848d-107">In the case of multiple simultaneous capture sessions, a yellow border is drawn around each item being captured.</span></span>

> [!NOTE]
> <span data-ttu-id="6848d-108">画面キャプチャ Api は、デスクトップと Windows Mixed Reality のイマーシブ ヘッドセットでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6848d-108">The screen capture APIs are only supported on desktop and Windows Mixed Reality immersive headsets.</span></span>

## <a name="add-the-screen-capture-capability"></a><span data-ttu-id="6848d-109">画面キャプチャ機能を追加する</span><span class="sxs-lookup"><span data-stu-id="6848d-109">Add the screen capture capability</span></span>

<span data-ttu-id="6848d-110">**Windows.Graphics.Capture**名前空間の Api では、アプリケーションのマニフェストで宣言する一般的な機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="6848d-110">The APIs found in the **Windows.Graphics.Capture** namespace require a general capability to be declared in your application's manifest:</span></span>
    
1. <span data-ttu-id="6848d-111">**ソリューション エクスプ ローラー**で、 **Package.appxmanifest**を開きます。</span><span class="sxs-lookup"><span data-stu-id="6848d-111">Open **Package.appxmanifest** in the **Solution Explorer**.</span></span>
2. <span data-ttu-id="6848d-112">**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6848d-112">Select the **Capabilities** tab.</span></span>
3. <span data-ttu-id="6848d-113">**グラフィックスのキャプチャ**を確認します。</span><span class="sxs-lookup"><span data-stu-id="6848d-113">Check **Graphics Capture**.</span></span>

![グラフィックスのキャプチャ](images/screen-capture-1.png)

## <a name="launch-the-system-ui-to-start-screen-capture"></a><span data-ttu-id="6848d-115">システム UI を起動して画面キャプチャを開始する</span><span class="sxs-lookup"><span data-stu-id="6848d-115">Launch the system UI to start screen capture</span></span>

<span data-ttu-id="6848d-116">システム UI を起動する前に、アプリケーションが現在、画面キャプチャに対応しているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="6848d-116">Before launching the system UI, you can check to see if your application is currently able to take screen captures.</span></span> <span data-ttu-id="6848d-117">アプリケーションで画面キャプチャを使用できなくなる理由はいくつかあります。たとえば、デバイスがハードウェア要件を満たしていない場合や、キャプチャ対象のアプリケーションが画面キャプチャをブロックしている場合などです。</span><span class="sxs-lookup"><span data-stu-id="6848d-117">There are several reasons why your application might not be able to use screen capture, including if the device does not meet hardware requirements or if the application targeted for capture blocks screen capture.</span></span> <span data-ttu-id="6848d-118">[GraphicsCaptureSession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession) クラスで **IsSupported** メソッドを使用して、UWP の画面キャプチャがサポートされているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="6848d-118">Use the **IsSupported** method in the [GraphicsCaptureSession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession) class to determine if UWP screen capture is supported:</span></span>

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

<span data-ttu-id="6848d-119">画面キャプチャがサポートされていることを確認したら、[GraphicsCapturePicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker) クラスを使用して、システム ピッカー UI を起動します。</span><span class="sxs-lookup"><span data-stu-id="6848d-119">Once you've verified that screen capture is supported, use the [GraphicsCapturePicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker) class to invoke the system picker UI.</span></span> <span data-ttu-id="6848d-120">エンド ユーザーは、この UI を使用して、画面キャプチャするディスプレイまたはアプリケーション ウィンドウを選択します。</span><span class="sxs-lookup"><span data-stu-id="6848d-120">The end user uses this UI to select the display or application window of which to take screen captures.</span></span> <span data-ttu-id="6848d-121">ピッカーによって [GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)が返されます。これは、**GraphicsCaptureSession** の作成に使用します。</span><span class="sxs-lookup"><span data-stu-id="6848d-121">The picker will return a [GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem) that will be used to create a **GraphicsCaptureSession**:</span></span>

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

<span data-ttu-id="6848d-122">これは UI コードであるため、UI スレッドで呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="6848d-122">Because this is UI code, it needs to be called on the UI thread.</span></span> <span data-ttu-id="6848d-123">( **MainPage.xaml.cs**) のように、アプリケーションのページの分離コードから呼び出すしている場合これを自動的に場合は、強制的に実行できます次のコードで、UI スレッドで実行されるが。</span><span class="sxs-lookup"><span data-stu-id="6848d-123">If you're calling it from the code-behind for a page of your application (like **MainPage.xaml.cs**) this is done for you automatically, but if not, you can force it to run on the UI thread with the following code:</span></span>

```cs
CoreWindow window = CoreApplication.MainView.CoreWindow;
           
await window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
{
    await StartCaptureAsync();
});
```

## <a name="create-a-capture-frame-pool-and-capture-session"></a><span data-ttu-id="6848d-124">キャプチャ フレーム プールとキャプチャ セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="6848d-124">Create a capture frame pool and capture session</span></span>

<span data-ttu-id="6848d-125">**GraphicsCaptureItem** を使用し、対象の D3D デバイス、サポートされるピクセル形式 (**DXGI\_FORMAT\_B8G8R8A8\_UNORM**)、目的のフレーム数 (任意の整数)、フレーム サイズを指定して、[Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool) を作成します。</span><span class="sxs-lookup"><span data-stu-id="6848d-125">Using the **GraphicsCaptureItem**, you will create a [Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool) with your D3D device, supported pixel format (**DXGI\_FORMAT\_B8G8R8A8\_UNORM**), number of desired frames (which can be any integer), and frame size.</span></span> <span data-ttu-id="6848d-126">**GraphicsCaptureItem** クラスの **ContentSize** プロパティをフレーム サイズとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="6848d-126">The **ContentSize** property of the **GraphicsCaptureItem** class can be used as the size of your frame:</span></span>

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

<span data-ttu-id="6848d-127">次に、**GraphicsCaptureItem** を **CreateCaptureSession** メソッドに渡して、**Direct3D11CaptureFramePool** の **GraphicsCaptureSession** クラスのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="6848d-127">Next, get an instance of the **GraphicsCaptureSession** class for your **Direct3D11CaptureFramePool** by passing the **GraphicsCaptureItem** to the **CreateCaptureSession** method:</span></span>

```cs
_session = _framePool.CreateCaptureSession(_item);
```

<span data-ttu-id="6848d-128">システム UI でユーザーがアプリケーション ウィンドウまたはディスプレイのキャプチャに明示的に同意すると、**GraphicsCaptureItem** を複数の **CaptureSession** オブジェクトに関連付けることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="6848d-128">Once the user has explicitly given consent to capturing an application window or display in the system UI, the **GraphicsCaptureItem** can be associated to multiple **CaptureSession** objects.</span></span> <span data-ttu-id="6848d-129">これにより、アプリケーションは、同じ項目をさまざまなエクスペリエンス向けにキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="6848d-129">This way your application can choose to capture the same item for various experiences.</span></span>

<span data-ttu-id="6848d-130">同時に複数の項目をキャプチャするには、キャプチャする項目ごとにアプリケーションがキャプチャ セッションを作成する必要があり、それにはキャプチャする項目ごとにピッカー UI を起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6848d-130">To capture multiple items at the same time, your application must create a capture session for each item to be captured, which requires invoking the picker UI for each item that is to be captured.</span></span>

## <a name="acquire-capture-frames"></a><span data-ttu-id="6848d-131">キャプチャ フレームを取得する</span><span class="sxs-lookup"><span data-stu-id="6848d-131">Acquire capture frames</span></span>

<span data-ttu-id="6848d-132">フレーム プールとキャプチャ セッションを作成した後、**GraphicsCaptureSession** インスタンスで **StartCapture** メソッドを呼び出して、アプリへのキャプチャ フレームの送信を開始することをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="6848d-132">With your frame pool and capture session created, call the **StartCapture** method on your **GraphicsCaptureSession** instance to notify the system to start sending capture frames to your app:</span></span>

```cs
_session.StartCapture();
```

<span data-ttu-id="6848d-133">これらのキャプチャー フレーム、つまり [Direct3D11CaptureFrame](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe)オブジェクトを取得するには、**Direct3D11CaptureFramePool.FrameArrived** イベントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="6848d-133">To acquire these capture frames, which are [Direct3D11CaptureFrame](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe) objects, you can use the **Direct3D11CaptureFramePool.FrameArrived** event:</span></span>

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

<span data-ttu-id="6848d-134">UI スレッドで **FrameArrived** を使用することはできれば避けることをお勧めします。このイベントは新しいフレームが使用可能になるたびに発生するため、頻繁に発生します。</span><span class="sxs-lookup"><span data-stu-id="6848d-134">It is recommended to avoid using the UI thread if possible for **FrameArrived**, as this event will be raised every time a new frame is available, which will be frequent.</span></span> <span data-ttu-id="6848d-135">それでもなお UI スレッドで **FrameArrived** をリッスンする場合は、イベントが発生するたびにどの程度の作業が必要になるかを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="6848d-135">If you do choose to listen to **FrameArrived** on the UI thread, be mindful of how much work you're doing every time the event fires.</span></span>

<span data-ttu-id="6848d-136">これに代わる方法として、**Direct3D11CaptureFramePool.TryGetNextFrame**メソッドを使用し、必要なフレームをすべて取得し終わるまで、フレームを手動で取得することができます。</span><span class="sxs-lookup"><span data-stu-id="6848d-136">Alternatively, you can manually pull frames with the **Direct3D11CaptureFramePool.TryGetNextFrame** method until you get all of the frames that you need.</span></span>

<span data-ttu-id="6848d-137">**Direct3D11CaptureFrame**オブジェクトには、**ContentSize**、**Surface**、**SystemRelativeTime** の 3 つのプロパティが含まれています</span><span class="sxs-lookup"><span data-stu-id="6848d-137">The **Direct3D11CaptureFrame** object contains the properties **ContentSize**, **Surface**, and **SystemRelativeTime**.</span></span> <span data-ttu-id="6848d-138">**SystemRelativeTime** は、他のメディア要素との同期に使用する QPC ([QueryPerformanceCounter](https://msdn.microsoft.com/library/windows/desktop/ms644904)) 時間です。</span><span class="sxs-lookup"><span data-stu-id="6848d-138">The **SystemRelativeTime** is QPC ([QueryPerformanceCounter](https://msdn.microsoft.com/library/windows/desktop/ms644904)) time that can be used to synchronize other media elements.</span></span>

## <a name="processing-capture-frames"></a><span data-ttu-id="6848d-139">キャプチャ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="6848d-139">Processing capture frames</span></span>

<span data-ttu-id="6848d-140">**Direct3D11CaptureFramePool** の各フレームは、**TryGetNextFrame** を呼び出したときにチェック アウトされ、**Direct3D11CaptureFrame** オブジェクトの有効期間に従ってチェック インされます。</span><span class="sxs-lookup"><span data-stu-id="6848d-140">Each frame from the **Direct3D11CaptureFramePool** is checked out when calling **TryGetNextFrame**, and checked back in according to the lifetime of the **Direct3D11CaptureFrame** object.</span></span> <span data-ttu-id="6848d-141">ネイティブ アプリケーションの場合、**Direct3D11CaptureFrame** オブジェクトを解放するだけで、フレームがフレーム プールにチェック インされます。</span><span class="sxs-lookup"><span data-stu-id="6848d-141">For native applications, releasing the **Direct3D11CaptureFrame** object is enough to check the frame back in to the frame pool.</span></span> <span data-ttu-id="6848d-142">管理されているアプリケーションの場合は、**Direct3D11CaptureFrame.Dispose** (C++ では **Close**) メソッドの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6848d-142">For managed applications, it is recommended to use the **Direct3D11CaptureFrame.Dispose** (**Close** in C++) method.</span></span> <span data-ttu-id="6848d-143">**Direct3D11CaptureFrame** によって [IClosable](https://docs.microsoft.com/uwp/api/Windows.Foundation.IClosable) インターフェイスが実装されます。これは C# の呼び出し元に、[IDisposable](https://msdn.microsoft.com/library/system.idisposable.aspx) として投影されます。</span><span class="sxs-lookup"><span data-stu-id="6848d-143">**Direct3D11CaptureFrame** implements the [IClosable](https://docs.microsoft.com/uwp/api/Windows.Foundation.IClosable) interface, which is projected as [IDisposable](https://msdn.microsoft.com/library/system.idisposable.aspx) for C# callers.</span></span>

<span data-ttu-id="6848d-144">フレームのチェックイン後、アプリケーションは、**Direct3D11CaptureFrame** オブジェクトへの参照を保存してはならず、その基になる Direct3D サーフェスへの参照も保存できません。</span><span class="sxs-lookup"><span data-stu-id="6848d-144">Applications should not save references to **Direct3D11CaptureFrame** objects, nor should they save references to the underlying Direct3D surface after the frame has been checked back in.</span></span>

<span data-ttu-id="6848d-145">フレームの処理中は、アプリケーションによって、[ID3D11Multithread](https://msdn.microsoft.com/library/windows/desktop/mt644886) を **Direct3D11CaptureFramePool** オブジェクトに関連付けられた同じデバイスにロックすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6848d-145">While processing a frame, it is recommended that applications take the [ID3D11Multithread](https://msdn.microsoft.com/library/windows/desktop/mt644886) lock on the same device that is associated with the **Direct3D11CaptureFramePool** object.</span></span>

<span data-ttu-id="6848d-146">基になる Direct3D サーフェスは、常に **Direct3D11CaptureFramePool** の作成時 (または再作成時) に指定されたサイズとなります。</span><span class="sxs-lookup"><span data-stu-id="6848d-146">The underlying Direct3D surface will always be the size specified when creating (or recreating) the **Direct3D11CaptureFramePool**.</span></span> <span data-ttu-id="6848d-147">コンテンツがフレームよりも大きい場合、コンテンツはフレームのサイズにクリップされます。</span><span class="sxs-lookup"><span data-stu-id="6848d-147">If content is larger than the frame, the contents are clipped to the size of the frame.</span></span> <span data-ttu-id="6848d-148">コンテンツがフレームより小さい場合、フレームの残りの部分には未定義のデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="6848d-148">If the content is smaller than the frame, then the rest of the frame contains undefined data.</span></span> <span data-ttu-id="6848d-149">未定義のコンテンツが表示されないように、アプリケーションで、その **Direct3D11CaptureFrame** の **ContentSize** プロパティを使用して、サブ矩形をコピーして取り出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6848d-149">It is recommended that applications copy out a sub-rect using the **ContentSize** property for that **Direct3D11CaptureFrame** to avoid showing undefined content.</span></span>

## <a name="react-to-capture-item-resizing-or-device-lost"></a><span data-ttu-id="6848d-150">キャプチャ項目のサイズ変更またはデバイス喪失に対応する</span><span class="sxs-lookup"><span data-stu-id="6848d-150">React to capture item resizing or device lost</span></span>

<span data-ttu-id="6848d-151">キャプチャ プロセス中に、アプリケーションで **Direct3D11CaptureFramePool** について変更が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="6848d-151">During the capture process, applications may wish to change aspects of their **Direct3D11CaptureFramePool**.</span></span> <span data-ttu-id="6848d-152">たとえば、新しい Direct3D デバイスの提供や、フレーム バッファー サイズの変更、さらにプール内のバッファー数の変更などの場合です。</span><span class="sxs-lookup"><span data-stu-id="6848d-152">This includes providing a new Direct3D device, changing the size of the frame buffers, or even changing the number of buffers within the pool.</span></span> <span data-ttu-id="6848d-153">このような各シナリオでは、**Direct3D11CaptureFramePool**  オブジェクトに対して **Recreate** メソッドを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6848d-153">In each of these scenarios, the **Recreate** method on the **Direct3D11CaptureFramePool** object is the recommended tool.</span></span>

<span data-ttu-id="6848d-154">**Recreate** を呼び出すと、すべての既存のフレームが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="6848d-154">When **Recreate** is called, all existing frames are discarded.</span></span> <span data-ttu-id="6848d-155">これにより、アプリケーションがアクセスできなくなったデバイスの Direct3D サーフェスを基とするフレームが渡されることがなくなります。</span><span class="sxs-lookup"><span data-stu-id="6848d-155">This is to prevent handing out frames whose underlying Direct3D surfaces belong to a device that the application may no longer have access to.</span></span> <span data-ttu-id="6848d-156">このため、**Recreate** を呼び出す前に、保留中のすべてのフレームを処理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6848d-156">For this reason, it may be wise to process all pending frames before calling **Recreate**.</span></span>

## <a name="putting-it-all-together"></a><span data-ttu-id="6848d-157">完成したコードの例</span><span class="sxs-lookup"><span data-stu-id="6848d-157">Putting it all together</span></span>

<span data-ttu-id="6848d-158">次のコード スニペットは、UWP アプリケーションで画面キャプチャを実装する方法のエンド ツー エンド例を示します。</span><span class="sxs-lookup"><span data-stu-id="6848d-158">The following code snippet is an end-to-end example of how to implement screen capture in a UWP application.</span></span> <span data-ttu-id="6848d-159">このサンプルで、フロント エンドにボタンがある、クリックすると、 **Button_ClickAsync**メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6848d-159">In this sample, we have a button in the front-end which, when clicked, calls the **Button_ClickAsync** method.</span></span>

> [!NOTE]
> <span data-ttu-id="6848d-160">このスニペットでは、 [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm)を 2D グラフィックス レンダリング用のライブラリを使用します。</span><span class="sxs-lookup"><span data-stu-id="6848d-160">This snippet uses [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm), a library for 2D graphics rendering.</span></span> <span data-ttu-id="6848d-161">プロジェクトを設定する方法については、ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6848d-161">See their documentation for information about how to set it up for your project.</span></span>

```cs
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Composition;
using System;
using System.Numerics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics;
using Windows.Graphics.Capture;
using Windows.Graphics.DirectX;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace WindowsGraphicsCapture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Capture API objects.
        private SizeInt32 _lastSize;
        private GraphicsCaptureItem _item;
        private Direct3D11CaptureFramePool _framePool;
        private GraphicsCaptureSession _session;

        // Non-API related members.
        private CanvasDevice _canvasDevice;
        private CompositionGraphicsDevice _compositionGraphicsDevice;
        private Compositor _compositor;
        private CompositionDrawingSurface _surface;

        public MainPage()
        {
            this.InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _canvasDevice = new CanvasDevice();
            _compositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(Window.Current.Compositor, _canvasDevice);
            _compositor = Window.Current.Compositor;

            _surface = _compositionGraphicsDevice.CreateDrawingSurface(
                new Size(400, 400),
                DirectXPixelFormat.B8G8R8A8UIntNormalized,
                DirectXAlphaMode.Premultiplied);    // This is the only value that currently works with the composition APIs.

            var visual = _compositor.CreateSpriteVisual();
            visual.RelativeSizeAdjustment = Vector2.One;
            var brush = _compositor.CreateSurfaceBrush(_surface);
            brush.HorizontalAlignmentRatio = 0.5f;
            brush.VerticalAlignmentRatio = 0.5f;
            brush.Stretch = CompositionStretch.Uniform;
            visual.Brush = brush;
            ElementCompositionPreview.SetElementChildVisual(this, visual);
        }

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
            _session.StartCapture();
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

                // Helper that handles the drawing for us.
                FillSurfaceWithBitmap(canvasBitmap);
            }

            // This is the device-lost convention for Win2D.
            catch (Exception e) when (_canvasDevice.IsDeviceLost(e.HResult))
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

        private void FillSurfaceWithBitmap(CanvasBitmap canvasBitmap)
        {
            CanvasComposition.Resize(_surface, canvasBitmap.Size);

            using (var session = CanvasComposition.CreateDrawingSession(_surface))
            {
                session.Clear(Colors.Transparent);
                session.DrawImage(canvasBitmap);
            }
        }

        private void ResetFramePool(SizeInt32 size, bool recreateDevice)
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
                catch (Exception e) when (_canvasDevice.IsDeviceLost(e.HResult))
                {
                    _canvasDevice = null;
                    recreateDevice = true;
                }
            } while (_canvasDevice == null);
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync();
        }
    }
}
```

## <a name="record-a-video"></a><span data-ttu-id="6848d-162">ビデオを録画します。</span><span class="sxs-lookup"><span data-stu-id="6848d-162">Record a video</span></span>

<span data-ttu-id="6848d-163">アプリケーションのビデオを記録する場合より簡単に[Windows.Media.AppRecording 名前空間](https://docs.microsoft.com/uwp/api/windows.media.apprecording)で実行できます。</span><span class="sxs-lookup"><span data-stu-id="6848d-163">If you want to record a video of your application, you can do so more easily with the [Windows.Media.AppRecording namespace](https://docs.microsoft.com/uwp/api/windows.media.apprecording).</span></span> <span data-ttu-id="6848d-164">これは、デスクトップでのみ動作するようのデスクトップ拡張 SDK の一部と、プロジェクトからへの参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6848d-164">This is part of the Desktop extension SDK, so it only works on desktop and requires that you add a reference to it from your project.</span></span> <span data-ttu-id="6848d-165">詳細については、[デバイス ファミリの概要](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6848d-165">See [Device families overview](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview) for more information.</span></span>

## <a name="see-also"></a><span data-ttu-id="6848d-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="6848d-166">See also</span></span>

* [<span data-ttu-id="6848d-167">Windows.Graphics.Capture 名前空間</span><span class="sxs-lookup"><span data-stu-id="6848d-167">Windows.Graphics.Capture Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.graphics.capture)
