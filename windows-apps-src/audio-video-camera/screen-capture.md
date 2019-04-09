---
title: 画面の取り込み
description: Windows.Graphics.Capture 名前空間 には、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、コラボレーティブでインタラクティブなエクスペリエンスを構築できます。
ms.assetid: 349C959D-9C74-44E7-B5F6-EBDB5CA87B9F
ms.date: 11/30/2018
ms.topic: article
dev_langs:
- csharp
- vb
keywords: Windows 10, UWP, 画面キャプチャ
ms.localizationpriority: medium
ms.openlocfilehash: 7bbe52de6e148ff86f492ee2c490e5dda388ffa1
ms.sourcegitcommit: 703f23f0cd2037997b6540335d32d344d5604974
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/02/2019
ms.locfileid: "58867888"
---
# <a name="screen-capture"></a>画面の取り込み

Windows 10、バージョン 1803 以降では、[Windows.Graphics.Capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture) に、ディスプレイまたはアプリケーション ウィンドウからフレームを取得する API が用意されています。これにより、ビデオ ストリームやスナップショットを作成して、共同作業に対応したインタラクティブなエクスペリエンスを構築できます。

画面キャプチャでは、開発者がセキュリティで保護されたシステム UI を起動し、エンド ユーザーがこれを使ってキャプチャ対象のディスプレイまたはアプリケーション ウィンドウを選択すると、アクティブにキャプチャされた項目の周囲に、それを通知する黄色の枠線がシステムによって描画されます。 複数の同時キャプチャ セッションの場合は、キャプチャされる各項目が黄色の枠線で囲まれます。

> [!NOTE]
> 画面キャプチャ Api は、デスクトップと Windows Mixed Reality イマーシブ ヘッドセットでのみサポートされます。

## <a name="add-the-screen-capture-capability"></a>画面キャプチャ機能を追加する

Api にある、 **Windows.Graphics.Capture**名前空間には、アプリケーションのマニフェストで宣言する一般的な機能が必要があります。
    
1. 開いている**Package.appxmanifest**で、**ソリューション エクスプ ローラー**します。
2. **[機能]** タブをクリックします。
3. 確認**グラフィックス キャプチャ**します。

![グラフィックス キャプチャ](images/screen-capture-1.png)

## <a name="launch-the-system-ui-to-start-screen-capture"></a>システム UI を起動して画面キャプチャを開始する

システム UI を起動する前に、アプリケーションが現在、画面キャプチャに対応しているかどうかを確認できます。 アプリケーションで画面キャプチャを使用できなくなる理由はいくつかあります。たとえば、デバイスがハードウェア要件を満たしていない場合や、キャプチャ対象のアプリケーションが画面キャプチャをブロックしている場合などです。 [GraphicsCaptureSession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession) クラスで **IsSupported** メソッドを使用して、UWP の画面キャプチャがサポートされているかどうかを判断します。

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

```vb
Public Sub OnInitialization()
    If Not GraphicsCaptureSession.IsSupported Then
        CaptureButton.Visibility = Visibility.Collapsed
    End If
End Sub
```

画面キャプチャがサポートされていることを確認したら、[GraphicsCapturePicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker) クラスを使用して、システム ピッカー UI を起動します。 エンド ユーザーは、この UI を使用して、画面キャプチャするディスプレイまたはアプリケーション ウィンドウを選択します。 ピッカーによって [GraphicsCaptureItem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)が返されます。これは、**GraphicsCaptureSession** の作成に使用します。

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

```vb
Public Async Function StartCaptureAsync() As Task
    ' The GraphicsCapturePicker follows the same pattern the
    ' file pickers do. 
    Dim picker As New GraphicsCapturePicker
    Dim item As GraphicsCaptureItem = Await picker.PickSingleItemAsync()

    ' The item may be null if the user dismissed the
    ' control without making a selection or hit Cancel.
    If item IsNot Nothing Then
        StartCaptureInternal(item)
    End If
End Function
```

UI コードであるため、UI スレッドで呼び出される必要があります。 アプリケーションのページの分離コードから呼び出している場合 (など**MainPage.xaml.cs**) が自動的には、この操作実行されますが、そうでない場合、次のコードで UI スレッドで実行することを強制できます。

```cs
CoreWindow window = CoreApplication.MainView.CoreWindow;
           
await window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
{
    await StartCaptureAsync();
});
```

```vb
Dim window As CoreWindow = CoreApplication.MainView.CoreWindow
Await window.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                 Async Sub() Await StartCaptureAsync())
```

## <a name="create-a-capture-frame-pool-and-capture-session"></a>キャプチャ フレーム プールとキャプチャ セッションを作成する

使用して、 **GraphicsCaptureItem**、作成、 [Direct3D11CaptureFramePool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool) 、D3D デバイスのピクセル形式をサポートします (**DXGI\_形式\_B8G8R8A8\_UNORM**)、(任意の整数を指定できます) が目的のフレームとフレームの数、サイズ。 **GraphicsCaptureItem** クラスの **ContentSize** プロパティをフレーム サイズとして使用できます。

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

```vb
WithEvents CaptureItem As GraphicsCaptureItem
WithEvents FramePool As Direct3D11CaptureFramePool
Private _canvasDevice As CanvasDevice
Private _session As GraphicsCaptureSession

Private Sub StartCaptureInternal(item As GraphicsCaptureItem)
    CaptureItem = item

    FramePool = Direct3D11CaptureFramePool.Create(
        _canvasDevice, ' D3D device 
        DirectXPixelFormat.B8G8R8A8UIntNormalized, ' Pixel format 
        2, '  Number of frames
        CaptureItem.Size) ' Size of the buffers 
End Sub
```

次に、**GraphicsCaptureItem** を **CreateCaptureSession** メソッドに渡して、**Direct3D11CaptureFramePool** の **GraphicsCaptureSession** クラスのインスタンスを取得します。

```cs
_session = _framePool.CreateCaptureSession(_item);
```

```vb
_session = FramePool.CreateCaptureSession(CaptureItem)
```

システム UI でユーザーがアプリケーション ウィンドウまたはディスプレイのキャプチャに明示的に同意すると、**GraphicsCaptureItem** を複数の **CaptureSession** オブジェクトに関連付けることができるようになります。 これにより、アプリケーションは、同じ項目をさまざまなエクスペリエンス向けにキャプチャできます。

同時に複数の項目をキャプチャするには、キャプチャする項目ごとにアプリケーションがキャプチャ セッションを作成する必要があり、それにはキャプチャする項目ごとにピッカー UI を起動する必要があります。

## <a name="acquire-capture-frames"></a>キャプチャ フレームを取得する

フレーム プールとキャプチャ セッションを作成した後、**GraphicsCaptureSession** インスタンスで **StartCapture** メソッドを呼び出して、アプリへのキャプチャ フレームの送信を開始することをシステムに通知します。

```cs
_session.StartCapture();
```

```vb
_session.StartCapture()
```

これらのキャプチャー フレーム、つまり [Direct3D11CaptureFrame](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe)オブジェクトを取得するには、**Direct3D11CaptureFramePool.FrameArrived** イベントを使用できます。

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

```vb
Private Sub FramePool_FrameArrived(sender As Direct3D11CaptureFramePool, args As Object) Handles FramePool.FrameArrived
    ' The FrameArrived event is raised for every frame on the thread
    ' that created the Direct3D11CaptureFramePool. This means we 
    ' don't have to do a null-check here, as we know we're the only 
    ' one dequeueing frames in our application.  

    ' NOTE Disposing the frame retires it And returns  
    ' the buffer to the pool.

    Using frame = FramePool.TryGetNextFrame()
        ProcessFrame(frame)
    End Using
End Sub
```

UI スレッドで **FrameArrived** を使用することはできれば避けることをお勧めします。このイベントは新しいフレームが使用可能になるたびに発生するため、頻繁に発生します。 それでもなお UI スレッドで **FrameArrived** をリッスンする場合は、イベントが発生するたびにどの程度の作業が必要になるかを考慮してください。

これに代わる方法として、**Direct3D11CaptureFramePool.TryGetNextFrame**メソッドを使用し、必要なフレームをすべて取得し終わるまで、フレームを手動で取得することができます。

**Direct3D11CaptureFrame**オブジェクトには、**ContentSize**、**Surface**、**SystemRelativeTime** の 3 つのプロパティが含まれています **SystemRelativeTime** は、他のメディア要素との同期に使用する QPC ([QueryPerformanceCounter](https://msdn.microsoft.com/library/windows/desktop/ms644904)) 時間です。

## <a name="processing-capture-frames"></a>キャプチャ フレームの処理

**Direct3D11CaptureFramePool** の各フレームは、**TryGetNextFrame** を呼び出したときにチェック アウトされ、**Direct3D11CaptureFrame** オブジェクトの有効期間に従ってチェック インされます。 ネイティブ アプリケーションの場合、**Direct3D11CaptureFrame** オブジェクトを解放するだけで、フレームがフレーム プールにチェック インされます。 管理されているアプリケーションの場合は、**Direct3D11CaptureFrame.Dispose** (C++ では **Close**) メソッドの使用をお勧めします。 **Direct3D11CaptureFrame** によって [IClosable](https://docs.microsoft.com/uwp/api/Windows.Foundation.IClosable) インターフェイスが実装されます。これは C# の呼び出し元に、[IDisposable](https://msdn.microsoft.com/library/system.idisposable.aspx) として投影されます。

フレームのチェックイン後、アプリケーションは、**Direct3D11CaptureFrame** オブジェクトへの参照を保存してはならず、その基になる Direct3D サーフェスへの参照も保存できません。

フレームの処理中は、アプリケーションによって、[ID3D11Multithread](https://msdn.microsoft.com/library/windows/desktop/mt644886) を **Direct3D11CaptureFramePool** オブジェクトに関連付けられた同じデバイスにロックすることをお勧めします。

基になる Direct3D サーフェスは、常に **Direct3D11CaptureFramePool** の作成時 (または再作成時) に指定されたサイズとなります。 コンテンツがフレームよりも大きい場合、コンテンツはフレームのサイズにクリップされます。 コンテンツがフレームより小さい場合、フレームの残りの部分には未定義のデータが格納されます。 未定義のコンテンツが表示されないように、アプリケーションで、その **Direct3D11CaptureFrame** の **ContentSize** プロパティを使用して、サブ矩形をコピーして取り出すことをお勧めします。

## <a name="react-to-capture-item-resizing-or-device-lost"></a>キャプチャ項目のサイズ変更またはデバイス喪失に対応する

キャプチャ プロセス中に、アプリケーションで **Direct3D11CaptureFramePool** について変更が必要になることがあります。 たとえば、新しい Direct3D デバイスの提供や、フレーム バッファー サイズの変更、さらにプール内のバッファー数の変更などの場合です。 このような各シナリオでは、**Direct3D11CaptureFramePool**  オブジェクトに対して **Recreate** メソッドを使用することをお勧めします。

**Recreate** を呼び出すと、すべての既存のフレームが破棄されます。 これにより、アプリケーションがアクセスできなくなったデバイスの Direct3D サーフェスを基とするフレームが渡されることがなくなります。 このため、**Recreate** を呼び出す前に、保留中のすべてのフレームを処理することをお勧めします。

## <a name="putting-it-all-together"></a>完成したコードの例

次のコード スニペットは、UWP アプリケーションで画面キャプチャを実装する方法のエンド ツー エンド例です。 このサンプルで、フロント エンドにボタンがあるをクリックすると、呼び出し、 **Button_ClickAsync**メソッド。

> [!NOTE]
> このスニペットを使用して[Win2D](https://microsoft.github.io/Win2D/html/Introduction.htm)、2D グラフィックス レンダリングのライブラリです。 プロジェクト用に設定する方法については、マニュアルを参照してください。

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

```vb
Imports System.Numerics
Imports Microsoft.Graphics.Canvas
Imports Microsoft.Graphics.Canvas.UI.Composition
Imports Windows.Graphics
Imports Windows.Graphics.Capture
Imports Windows.Graphics.DirectX
Imports Windows.UI
Imports Windows.UI.Composition
Imports Windows.UI.Xaml.Hosting

Partial Public NotInheritable Class MainPage
    Inherits Page
    
    ' Capture API objects.
    WithEvents CaptureItem As GraphicsCaptureItem
    WithEvents FramePool As Direct3D11CaptureFramePool

    Private _lastSize As SizeInt32
    Private _session As GraphicsCaptureSession

    ' Non-API related members.
    Private _canvasDevice As CanvasDevice
    Private _compositionGraphicsDevice As CompositionGraphicsDevice
    Private _compositor As Compositor
    Private _surface As CompositionDrawingSurface

    Sub New()
        InitializeComponent()
        Setup()
    End Sub

    Private Sub Setup()
        _canvasDevice = New CanvasDevice()
        _compositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(Window.Current.Compositor, _canvasDevice)
        _compositor = Window.Current.Compositor
        _surface = _compositionGraphicsDevice.CreateDrawingSurface(
            New Size(400, 400), DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied)
        Dim visual = _compositor.CreateSpriteVisual()
        visual.RelativeSizeAdjustment = Vector2.One
        Dim brush = _compositor.CreateSurfaceBrush(_surface)
        brush.HorizontalAlignmentRatio = 0.5F
        brush.VerticalAlignmentRatio = 0.5F
        brush.Stretch = CompositionStretch.Uniform
        visual.Brush = brush
        ElementCompositionPreview.SetElementChildVisual(Me, visual)
    End Sub

    Public Async Function StartCaptureAsync() As Task
        ' The GraphicsCapturePicker follows the same pattern the
        ' file pickers do. 
        Dim picker As New GraphicsCapturePicker
        Dim item As GraphicsCaptureItem = Await picker.PickSingleItemAsync()

        ' The item may be null if the user dismissed the
        ' control without making a selection or hit Cancel.
        If item IsNot Nothing Then
            StartCaptureInternal(item)
        End If
    End Function

    Private Sub StartCaptureInternal(item As GraphicsCaptureItem)
        ' Stop the previous capture if we had one.
        StopCapture()

        CaptureItem = item
        _lastSize = CaptureItem.Size

        FramePool = Direct3D11CaptureFramePool.Create(
            _canvasDevice, ' D3D device 
            DirectXPixelFormat.B8G8R8A8UIntNormalized, ' Pixel format 
            2, '  Number of frames
            CaptureItem.Size) ' Size of the buffers 

        _session = FramePool.CreateCaptureSession(CaptureItem)
        _session.StartCapture()
    End Sub

    Private Sub FramePool_FrameArrived(sender As Direct3D11CaptureFramePool, args As Object) Handles FramePool.FrameArrived
        ' The FrameArrived event is raised for every frame on the thread
        ' that created the Direct3D11CaptureFramePool. This means we 
        ' don't have to do a null-check here, as we know we're the only 
        ' one dequeueing frames in our application.  

        ' NOTE Disposing the frame retires it And returns  
        ' the buffer to the pool.

        Using frame = FramePool.TryGetNextFrame()
            ProcessFrame(frame)
        End Using
    End Sub

    Private Sub CaptureItem_Closed(sender As GraphicsCaptureItem, args As Object) Handles CaptureItem.Closed
        StopCapture()
    End Sub

    Public Sub StopCapture()
        _session?.Dispose()
        FramePool?.Dispose()
        CaptureItem = Nothing
        _session = Nothing
        FramePool = Nothing
    End Sub

    Private Sub ProcessFrame(frame As Direct3D11CaptureFrame)
        ' Resize and device-lost leverage the same function on the
        ' Direct3D11CaptureFramePool. Refactoring it this way avoids 
        ' throwing in the catch block below (device creation could always 
        ' fail) along with ensuring that resize completes successfully And 
        ' isn't vulnerable to device-lost.

        Dim needsReset As Boolean = False
        Dim recreateDevice As Boolean = False

        If (frame.ContentSize.Width <> _lastSize.Width) OrElse
            (frame.ContentSize.Height <> _lastSize.Height) Then
            needsReset = True
            _lastSize = frame.ContentSize
        End If

        Try
            ' Take the D3D11 surface and draw it into a  
            ' Composition surface.

            ' Convert our D3D11 surface into a Win2D object.
            Dim bitmap = CanvasBitmap.CreateFromDirect3D11Surface(
                _canvasDevice,
                frame.Surface)

            ' Helper that handles the drawing for us.
            FillSurfaceWithBitmap(bitmap)
            ' This is the device-lost convention for Win2D.
        Catch e As Exception When _canvasDevice.IsDeviceLost(e.HResult)
            ' We lost our graphics device. Recreate it and reset 
            ' our Direct3D11CaptureFramePool.  
            needsReset = True
            recreateDevice = True
        End Try

        If needsReset Then
            ResetFramePool(frame.ContentSize, recreateDevice)
        End If
    End Sub

    Private Sub FillSurfaceWithBitmap(canvasBitmap As CanvasBitmap)
        CanvasComposition.Resize(_surface, canvasBitmap.Size)

        Using session = CanvasComposition.CreateDrawingSession(_surface)
            session.Clear(Colors.Transparent)
            session.DrawImage(canvasBitmap)
        End Using
    End Sub

    Private Sub ResetFramePool(size As SizeInt32, recreateDevice As Boolean)
        Do
            Try
                If recreateDevice Then
                    _canvasDevice = New CanvasDevice()
                End If
                FramePool.Recreate(_canvasDevice, DirectXPixelFormat.B8G8R8A8UIntNormalized, 2, size)
                ' This is the device-lost convention for Win2D.
            Catch e As Exception When _canvasDevice.IsDeviceLost(e.HResult)
                _canvasDevice = Nothing
                recreateDevice = True
            End Try
        Loop While _canvasDevice Is Nothing
    End Sub

    Private Async Sub Button_ClickAsync(sender As Object, e As RoutedEventArgs) Handles CaptureButton.Click
        Await StartCaptureAsync()
    End Sub

End Class
```

## <a name="record-a-video"></a>ビデオを記録します。

より簡単に実行できるアプリケーションのビデオを記録する場合、 [Windows.Media.AppRecording 名前空間](https://docs.microsoft.com/uwp/api/windows.media.apprecording)します。 これは、デスクトップでのみ機能するためのデスクトップ拡張機能 SDK の一部、プロジェクトからへの参照を追加する必要があります。 参照してください[デバイス ファミリの概要](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)詳細についてはします。

## <a name="see-also"></a>関連項目

* [Windows.Graphics.Capture 名前空間](https://docs.microsoft.com/uwp/api/windows.graphics.capture)
