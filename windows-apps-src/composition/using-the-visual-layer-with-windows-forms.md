---
title: Windows フォームでのビジュアル層の使用
description: 既存の Windows フォームのコンテンツと組み合わせてビジュアル層の Api を使用して、高度なアニメーションや効果を作成するための手法について説明します。
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: eef07c1088315871b558464aff4b1719cdd63962
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174125"
---
# <a name="using-the-visual-layer-with-windows-forms"></a>Windows フォームでのビジュアル層の使用

Windows ランタイムの合成 Api を使用することができます (とも呼ばれる、[ビジュアル層](visual-layer.md)) で、Windows フォーム アプリで Windows 10 のユーザー用に光を最新のエクスペリエンスを作成します。

このチュートリアルの完成したコードは GitHub で入手できます。[Windows フォーム HelloComposition サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/HelloComposition)します。

## <a name="prerequisites"></a>前提条件

UWP API をホストしているが、これらの前提条件です。

- Windows フォーム、UWP を使用してアプリ開発の知識があると仮定します。 For more info, see:
  - [Windows フォームの概要](/dotnet/framework/winforms/getting-started-with-windows-forms)
  - [Windows 10 アプリを概要します。](/windows/uwp/get-started/)
  - [Windows 10 のデスクトップ アプリケーションを拡張します。](/windows/uwp/porting/desktop-to-uwp-enhance)
- .NET framework 4.7.2 以降
- Windows 10 バージョン 1803 以降
- Windows 10 SDK 17134 またはそれ以降

## <a name="how-to-use-composition-apis-in-windows-forms"></a>Windows フォームで合成 Api を使用する方法

このチュートリアルでは、単純な Windows フォームの UI を作成し、アニメーションの合成要素を追加します。 Windows フォームと合成の両方のコンポーネントを単純に保持されますが、相互運用機能のコードは、コンポーネントの複雑さに関係なく同じです。 次のような完成したアプリが表示されます。

![実行中のアプリの UI](images/interop/wf-comp-interop-app-ui.png)

## <a name="create-a-windows-forms-project"></a>Windows フォーム プロジェクトを作成します。

最初の手順では、UI のアプリケーションの定義とメイン フォームが含まれている Windows フォーム アプリ プロジェクトを作成します。

ビジュアルで新しい Windows フォーム アプリケーション プロジェクトを作成するC#という_HelloComposition_:

1. Visual Studio を開き、選択**ファイル** > **新規** > **プロジェクト**します。<br/>**新しいプロジェクト**ダイアログ ボックスが開きます。
1. 下、**インストール済み**カテゴリで、展開、 **Visual C#** ノードをクリックして**Windows デスクトップ**します。
1. 選択、 **Windows フォーム アプリ (.NET Framework)** テンプレート。
1. 名前を入力します_HelloComposition、_ フレームワークを選択します **.NET Framework 4.7.2**、 をクリックし、 **OK**。

Visual Studio では、プロジェクトを作成し、Form1.cs という名前の既定アプリケーション ウィンドウのデザイナーを開きます。

## <a name="configure-the-project-to-use-windows-runtime-apis"></a>Windows ランタイム Api を使用してプロジェクトを構成します。

Windows ランタイム (WinRT)、Windows フォーム アプリで Api を使用するには、Windows ランタイムにアクセスする Visual Studio プロジェクトを構成する必要があります。 さらに、ベクターを使用するために必要な参照を追加する必要があるために、合成 Api でベクターは広範囲に使用されます。

NuGet パッケージのこれらのニーズの両方のアドレスを利用できます。 これらのパッケージをプロジェクトに必要な参照を追加するの最新バージョンをインストールします。  

- [Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts) (PackageReference に既定のパッケージ管理形式のセットが必要)。
- [System.Numerics.Vectors](https://www.nuget.org/packages/System.Numerics.Vectors/)

> [!NOTE]
> NuGet パッケージを使用して、プロジェクトを構成することをお勧め、中には、必要な参照を手動で追加することができます。 詳細については、次を参照してください。 [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)します。 次の表への参照を追加する必要のあるファイルを示します。

|ファイル|Location|
|--|--|
|System.Runtime.WindowsRuntime|C:\Windows\Microsoft.NET\Framework\v4.0.30319|
|Windows.Foundation.UniversalApiContract.winmd|C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*>|
|Windows.Foundation.FoundationContract.winmd|C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*>|
|System.Numerics.Vectors.dll|C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics.Vectors\v4.0_4.0.0.0__b03f5f7f11d50a3a|
|System.Numerics.dll|C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2|

## <a name="create-a-custom-control-to-manage-interop"></a>相互運用機能を管理するカスタム コントロールを作成します。

派生したカスタム コントロールを作成するビジュアル層で作成するコンテンツのホストに[コントロール](/dotnet/api/system.windows.forms.control)します。 このコントロールでは、ウィンドウにアクセスする[処理](/dotnet/api/system.windows.forms.control.handle)、ビジュアル層コンテンツのコンテナーを作成するために必要があります。

これは、合成 Api をホストするための構成の大部分を実行します。 このコントロールで使用する[プラットフォーム呼び出しサービス (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code)と[COM 相互運用機能](/dotnet/api/system.runtime.interopservices.comimportattribute)合成 Api を Windows フォーム アプリに取り込む。 PInvoke と COM 相互運用機能の詳細については、次を参照してください。[アンマネージ コードとの相互運用](/dotnet/framework/interop/index)します。

> [!TIP]
> 必要がある場合は、すべてのコードは、チュートリアルを使用すると適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。

1. 派生するプロジェクトに新しいカスタム コントロール ファイルを追加[コントロール](/dotnet/api/system.windows.forms.control)します。
    - **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
    - コンテキスト メニューで選択**追加** > **新しい項目.**.
    - **新しい項目の追加**ダイアログ ボックスで、**カスタム コントロール**します。
    - コントロールに名前を_CompositionHost.cs_、 をクリックし、**追加**します。 CompositionHost.cs がデザイン ビューで開きます。

1. CompositionHost.cs のコード ビューに切り替え、クラスに次のコードを追加します。

    ```csharp
    // Add
    // using Windows.UI.Composition;

    IntPtr hwndHost;
    object dispatcherQueue;
    protected ContainerVisual containerVisual;
    protected Compositor compositor;

    private ICompositionTarget compositionTarget;

    public Visual Child
    {
        set
        {
            if (compositor == null)
            {
                InitComposition(hwndHost);
            }
            compositionTarget.Root = value;
        }
    }
    ```

1. コンス トラクターにコードを追加します。

    コンス トラクターで呼び出して、 _InitializeCoreDispatcher_と_InitComposition_メソッド。 次の手順では、これらのメソッドを作成します。

    ```csharp
    public CompositionHost()
    {
        InitializeComponent();

        // Get the window handle.
        hwndHost = Handle;

        // Create dispatcher queue.
        dispatcherQueue = InitializeCoreDispatcher();

        // Build Composition tree of content.
        InitComposition(hwndHost);
    }

1. Initialize a thread with a [CoreDispatcher](/uwp/api/windows.ui.core.coredispatcher). The core dispatcher is responsible for processing window messages and dispatching events for WinRT APIs. New instances of **Compositor** must be created on a thread that has a CoreDispatcher.
    - Create a method named _InitializeCoreDispatcher_ and add code to set up the dispatcher queue.

    ```csharp
    // Add
    // using System.Runtime.InteropServices;

    private object InitializeCoreDispatcher()
    {
        DispatcherQueueOptions options = new DispatcherQueueOptions();
        options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
        options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
        options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

        object queue = null;
        CreateDispatcherQueueController(options, out queue);
        return queue;
    }
    ```

    - ディスパッチャー キューには、PInvoke 宣言が必要です。 この宣言をクラスのコードの最後に配置します。 (私たち内に配置このコード クラスのコードの編成を保持する領域。)

    ```csharp
    #region PInvoke declarations

    //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    //{
    //    DQTAT_COM_NONE,
    //    DQTAT_COM_ASTA,
    //    DQTAT_COM_STA
    //};
    internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    {
        DQTAT_COM_NONE = 0,
        DQTAT_COM_ASTA = 1,
        DQTAT_COM_STA = 2
    };

    //typedef enum DISPATCHERQUEUE_THREAD_TYPE
    //{
    //    DQTYPE_THREAD_DEDICATED,
    //    DQTYPE_THREAD_CURRENT
    //};
    internal enum DISPATCHERQUEUE_THREAD_TYPE
    {
        DQTYPE_THREAD_DEDICATED = 1,
        DQTYPE_THREAD_CURRENT = 2,
    };

    //struct DispatcherQueueOptions
    //{
    //    DWORD dwSize;
    //    DISPATCHERQUEUE_THREAD_TYPE threadType;
    //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct DispatcherQueueOptions
    {
        public int dwSize;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_TYPE threadType;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    };

    //HRESULT CreateDispatcherQueueController(
    //  DispatcherQueueOptions options,
    //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
    //);
    [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                            [MarshalAs(UnmanagedType.IUnknown)]
                                            out object dispatcherQueueController);

    #endregion PInvoke declarations
    ```

    今すぐディスパッチャー キューの準備ができているし、初期化し、合成コンテンツの作成を開始できます。

1. 初期化、[コンポジター](/uwp/api/windows.ui.composition.compositor)します。 コンポジターがさまざまな型を作成するファクトリを[Windows.UI.Composition](/uwp/api/windows.ui.composition)ビジュアル層、効果のシステム、およびアニメーション システムにまたがる名前空間。 コンポジター クラスには、ファクトリから作成されたオブジェクトの有効期間も管理します。

    ```csharp
    private void InitComposition(IntPtr hwndHost)
    {
        ICompositorDesktopInterop interop;

        compositor = new Compositor();
        object iunknown = compositor as object;
        interop = (ICompositorDesktopInterop)iunknown;
        IntPtr raw;
        interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

        object rawObject = Marshal.GetObjectForIUnknown(raw);
        compositionTarget = (ICompositionTarget)rawObject;

        if (raw == null) { throw new Exception("QI Failed"); }

        containerVisual = compositor.CreateContainerVisual();
        Child = containerVisual;
    }
    ```

    - **ICompositorDesktopInterop**と**ICompositionTarget** COM インポートが必要です。 このコードの後、 _CompositionHost_クラスが内部名前空間の宣言。

    ```csharp
    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }

    #endregion COM Interop
    ```

## <a name="create-a-custom-control-to-host-composition-elements"></a>コンポジションのホスト要素にカスタム コントロールを作成します。

生成および CompositionHost から派生した個別のコントロールに、合成要素を管理するコードを配置することをお勧めします。 これにより、相互運用機能のコード再利用可能な CompositionHost クラスで作成します。

ここでは、CompositionHost から派生したカスタム コントロールを作成します。 このコントロールは、フォームに追加することができますので、Visual Studio のツールボックスに追加されます。

1. CompositionHost から派生するプロジェクトに新しいカスタム コントロール ファイルを追加します。
    - **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
    - コンテキスト メニューで選択**追加** > **新しい項目.**.
    - **新しい項目の追加**ダイアログ ボックスで、**カスタム コントロール**します。
    - コントロールに名前を_CompositionHostControl.cs_、 をクリックし、**追加**します。 CompositionHostControl.cs がデザイン ビューで開きます。

1. CompositionHostControl.cs デザイン ビューのプロパティ ウィンドウで、設定、 **BackColor**プロパティを**ControlLight**します。

    背景色の設定は省略可能です。 以下に、カスタム コントロールをフォームの背景を表示できるようにします。

1. CompositionHostControl.cs のコード ビューに切り替え、CompositionHost から派生するクラスの宣言を更新します。

    ```csharp
    class CompositionHostControl : CompositionHost
    ```

1. 基本コンス トラクターを呼び出すコンス トラクターを更新します。

    ```csharp
    public CompositionHostControl() : base()
    {

    }
    ```

### <a name="add-composition-elements"></a>合成要素を追加します。

インプレース インフラストラクチャ、アプリの UI に合成コンテンツを追加できます。

この例では、CompositionHostControl クラスを作成し、単純なアニメーション化するコードを追加する[SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)します。

1. 合成要素を追加します。

    CompositionHostControl.cs では、CompositionHostControl クラスにこれらのメソッドを追加します。

    ```csharp
    // Add
    // using Windows.UI.Composition;

    public void AddElement(float size, float offsetX, float offsetY)
    {
        var visual = compositor.CreateSpriteVisual();
        visual.Size = new Vector2(size, size); // Requires references
        visual.Brush = compositor.CreateColorBrush(GetRandomColor());
        visual.Offset = new Vector3(offsetX, offsetY, 0);
        containerVisual.Children.InsertAtTop(visual);

        AnimateSquare(visual, 3);
    }

    private void AnimateSquare(SpriteVisual visual, int delay)
    {
        float offsetX = (float)(visual.Offset.X);
        Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
        float bottom = Height - visual.Size.Y;
        animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
        animation.Duration = TimeSpan.FromSeconds(2);
        animation.DelayTime = TimeSpan.FromSeconds(delay);
        visual.StartAnimation("Offset", animation);
    }

    private Windows.UI.Color GetRandomColor()
    {
        Random random = new Random();
        byte r = (byte)random.Next(0, 255);
        byte g = (byte)random.Next(0, 255);
        byte b = (byte)random.Next(0, 255);
        return Windows.UI.Color.FromArgb(255, r, g, b);
    }
    ```

## <a name="add-the-control-to-your-form"></a>コントロールをフォームに追加します。

コンポジションのコンテンツをホストするカスタム コントロールがある場合は、できたは、アプリの UI を追加できます。 ここでは、前の手順で作成した CompositionHostControl のインスタンスを追加します。 Visual Studio のツールボックスに自動的に追加 CompositionHostControl **_プロジェクト名_コンポーネント**します。

1. Form1.CS [デザイン] ビューでは、UI にボタンを追加します。

    - Form1 には、ツールボックスからボタンをドラッグします。 フォームの左上隅に配置します。 (コントロールの配置を確認するチュートリアルの開始時のイメージを参照してください)。
    - [プロパティ] ウィンドウで変更、**テキスト**プロパティから_button1_に_追加の合成要素_します。
    - すべてのテキストが表示されるよう、ボタンのサイズを変更します。

    (詳細については、次を参照してください。[方法。Windows フォームにコントロールを追加](/dotnet/framework/winforms/controls/how-to-add-controls-to-windows-forms))。

1. UI に、CompositionHostControl を追加します。

    - Form1 には、ツールボックスから、CompositionHostControl をドラッグします。 ボタンの右側に配置します。
    - フォームの残りの部分全体に表示されるので、CompositionHost のサイズを変更します。

1. ボタンのハンドルは、イベントをクリックします。

   - プロパティ ペインで、イベントの表示を切り替える稲妻をクリックします。
   - イベントの一覧で、選択、**クリックして**イベントの種類*Button_Click*、Enter キーを押します。
   - このコードは、Form1.cs で追加されます。

    ```csharp
    private void Button_Click(object sender, EventArgs e)
    {

    }
    ```

1. ボタンにコードを追加する新しい要素を作成するイベント ハンドラーをクリックします。

    - Form1.cs のコードを追加、 *Button_Click*以前に作成したイベント ハンドラー。 このコードは呼び出して_CompositionHostControl1.AddElement_ランダムに生成されたサイズおよびオフセットを新しい要素を作成します。 (CompositionHostControl のインスタンスが自動的に名前付き_compositionHostControl1_ときにフォームにドラッグします)。

    ```csharp
    // Add
    // using System;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        float size = random.Next(50, 150);
        float offsetX = random.Next(0, (int)(compositionHostControl1.Width - size));
        float offsetY = random.Next(0, (int)(compositionHostControl1.Height/2 - size));
        compositionHostControl1.AddElement(size, offsetX, offsetY);
    }
    ```

ビルドして、Windows フォーム アプリを実行することができますようになりました。 ボタンをクリックすると、UI に追加するアニメーションの正方形が表示されます。

## <a name="next-steps"></a>次のステップ

同じインフラストラクチャ上に構築するより詳細な例については、 [Windows フォームのビジュアル層の統合サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/VisualLayerIntegration)GitHub でします。

## <a name="additional-resources"></a>その他の資料

- [Windows フォームの概要](/dotnet/framework/winforms/getting-started-with-windows-forms)(.NET)
- [アンマネージ コードと相互運用](/dotnet/framework/interop/)(.NET)
- [Windows 10 アプリの概要](/windows/uwp/get-started/)(UWP)
- [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)(UWP)
- [名前空間の Windows.UI.Composition](/uwp/api/windows.ui.composition) (UWP)

## <a name="complete-code"></a>コードを完成させる

このチュートリアルの完全なコードを示します。

### <a name="form1cs"></a>Form1.cs

```csharp
using System;
using System.Windows.Forms;

namespace HelloComposition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            float size = random.Next(50, 150);
            float offsetX = random.Next(0, (int)(compositionHostControl1.Width - size));
            float offsetY = random.Next(0, (int)(compositionHostControl1.Height/2 - size));
            compositionHostControl1.AddElement(size, offsetX, offsetY);
        }
    }
}
```

### <a name="compositionhostcontrolcs"></a>CompositionHostControl.cs

```csharp
using System;
using System.Numerics;
using Windows.UI.Composition;

namespace HelloComposition
{
    class CompositionHostControl : CompositionHost
    {
        public CompositionHostControl() : base()
        {

        }

        public void AddElement(float size, float offsetX, float offsetY)
        {
            var visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(size, size); // Requires references
            visual.Brush = compositor.CreateColorBrush(GetRandomColor());
            visual.Offset = new Vector3(offsetX, offsetY, 0);
            containerVisual.Children.InsertAtTop(visual);

            AnimateSquare(visual, 3);
        }

        private void AnimateSquare(SpriteVisual visual, int delay)
        {
            float offsetX = (float)(visual.Offset.X);
            Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
            float bottom = Height - visual.Size.Y;
            animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
            animation.Duration = TimeSpan.FromSeconds(2);
            animation.DelayTime = TimeSpan.FromSeconds(delay);
            visual.StartAnimation("Offset", animation);
        }

        private Windows.UI.Color GetRandomColor()
        {
            Random random = new Random();
            byte r = (byte)random.Next(0, 255);
            byte g = (byte)random.Next(0, 255);
            byte b = (byte)random.Next(0, 255);
            return Windows.UI.Color.FromArgb(255, r, g, b);
        }
    }
}
```

### <a name="compositionhostcs"></a>CompositionHost.cs

```csharp
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.UI.Composition;

namespace HelloComposition
{
    public partial class CompositionHost : Control
    {
        IntPtr hwndHost;
        object dispatcherQueue;
        protected ContainerVisual containerVisual;
        protected Compositor compositor;
        private ICompositionTarget compositionTarget;

        public Visual Child
        {
            set
            {
                if (compositor == null)
                {
                    InitComposition(hwndHost);
                }
                compositionTarget.Root = value;
            }
        }

        public CompositionHost()
        {
            // Get the window handle.
            hwndHost = Handle;

            // Create dispatcher queue.
            dispatcherQueue = InitializeCoreDispatcher();

            // Build Composition tree of content.
            InitComposition(hwndHost);
        }

        private object InitializeCoreDispatcher()
        {
            DispatcherQueueOptions options = new DispatcherQueueOptions();
            options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
            options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
            options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

            object queue = null;
            CreateDispatcherQueueController(options, out queue);
            return queue;
        }

        private void InitComposition(IntPtr hwndHost)
        {
            ICompositorDesktopInterop interop;

            compositor = new Compositor();
            object iunknown = compositor as object;
            interop = (ICompositorDesktopInterop)iunknown;
            IntPtr raw;
            interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

            object rawObject = Marshal.GetObjectForIUnknown(raw);
            compositionTarget = (ICompositionTarget)rawObject;

            if (raw == null) { throw new Exception("QI Failed"); }

            containerVisual = compositor.CreateContainerVisual();
            Child = containerVisual;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region PInvoke declarations

        //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        //{
        //    DQTAT_COM_NONE,
        //    DQTAT_COM_ASTA,
        //    DQTAT_COM_STA
        //};
        internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        {
            DQTAT_COM_NONE = 0,
            DQTAT_COM_ASTA = 1,
            DQTAT_COM_STA = 2
        };

        //typedef enum DISPATCHERQUEUE_THREAD_TYPE
        //{
        //    DQTYPE_THREAD_DEDICATED,
        //    DQTYPE_THREAD_CURRENT
        //};
        internal enum DISPATCHERQUEUE_THREAD_TYPE
        {
            DQTYPE_THREAD_DEDICATED = 1,
            DQTYPE_THREAD_CURRENT = 2,
        };

        //struct DispatcherQueueOptions
        //{
        //    DWORD dwSize;
        //    DISPATCHERQUEUE_THREAD_TYPE threadType;
        //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        //};
        [StructLayout(LayoutKind.Sequential)]
        internal struct DispatcherQueueOptions
        {
            public int dwSize;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_TYPE threadType;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        };

        //HRESULT CreateDispatcherQueueController(
        //  DispatcherQueueOptions options,
        //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
        //);
        [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                                 [MarshalAs(UnmanagedType.IUnknown)]
                                        out object dispatcherQueueController);

        #endregion PInvoke declarations
    }

    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }
    #endregion COM Interop
}
```