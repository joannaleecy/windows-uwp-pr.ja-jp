---
title: WPF でのビジュアル層の使用
description: 既存の WPF コンテンツと組み合わせて、ビジュアル レイヤー API を使用して、高度なアニメーションや効果を作成するための手法について説明します。
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: a280b36b0ff3a34bfbd52417aec0856156aa420d
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174126"
---
# <a name="using-the-visual-layer-with-wpf"></a>WPF でのビジュアル層の使用

Windows ランタイムの合成 Api を使用することができます (とも呼ばれる、[ビジュアル層](visual-layer.md)) で、Windows Presentation Foundation (WPF) アプリ用 Windows 10 のユーザーに光を最新のエクスペリエンスを作成します。

このチュートリアルの完成したコードは GitHub で入手できます。[WPF HelloComposition サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/HelloComposition)します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP XAML では、これらの前提条件があります。

- WPF および UWP を使用してアプリ開発の知識があると仮定します。 For more info, see:
  - [概要 (WPF)](/dotnet/framework/wpf/getting-started/)
  - [Windows 10 アプリを概要します。](/windows/uwp/get-started/)
  - [Windows 10 のデスクトップ アプリケーションを拡張します。](/windows/uwp/porting/desktop-to-uwp-enhance)
- .NET framework 4.7.2 以降
- Windows 10 バージョン 1803 以降
- Windows 10 SDK 17134 またはそれ以降

## <a name="how-to-use-composition-apis-in-wpf"></a>WPF で合成 Api を使用する方法

このチュートリアルでは、単純な WPF アプリの UI を作成し、アニメーションの合成要素を追加します。 WPF と合成の両方のコンポーネントを単純に保持されますが、相互運用機能のコードは、コンポーネントの複雑さに関係なく同じです。 次のような完成したアプリが表示されます。

![実行中のアプリの UI](images/interop/wpf-comp-interop-app-ui.png)

## <a name="create-a-wpf-project"></a>WPF プロジェクトを作成します。

最初の手順では、UI のアプリケーションの定義と、XAML ページを含む WPF アプリ プロジェクトを作成します。

ビジュアルで新しい WPF アプリケーション プロジェクトを作成するC#という_HelloComposition_:

1. Visual Studio を開き、選択**ファイル** > **新規** > **プロジェクト**します。

    **新しいプロジェクト**ダイアログ ボックスが開きます。
1. 下、**インストール済み**カテゴリで、展開、 **Visual C#** ノードをクリックして**Windows デスクトップ**します。
1. 選択、 **WPF アプリ (.NET Framework)** テンプレート。
1. 名前を入力します_HelloComposition_、フレームワークを選択します **.NET Framework 4.7.2**、 をクリックし、 **OK**。

    Visual Studio では、プロジェクトを作成し、MainWindow.xaml をという名前の既定アプリケーション ウィンドウのデザイナーを開きます。

## <a name="configure-the-project-to-use-windows-runtime-apis"></a>Windows ランタイム Api を使用してプロジェクトを構成します。

Windows ランタイム (WinRT)、WPF アプリで Api を使用するには、Windows ランタイムにアクセスする Visual Studio プロジェクトを構成する必要があります。 さらに、ベクターを使用するために必要な参照を追加する必要があるために、合成 Api でベクターは広範囲に使用されます。

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

## <a name="configure-the-project-to-be-per-monitor-dpi-aware"></a>あるモニターごとの DPI 対応のプロジェクトを構成します。

表示されます。 画面の DPI 設定と一致するアプリに追加するビジュアル層のコンテンツは自動的に対応できません。 アプリの場合、モニターごとの DPI 対応を有効にすること、ビジュアル層のコンテンツの作成に使用するコード、現在の DPI スケールするときは考慮、アプリが実行されるかどうかを確認する必要があります。 ここでは、DPI 対応にするプロジェクトを構成します。 以降のセクションでは、DPI 情報を使用して、ビジュアル層のコンテンツを拡大縮小する方法を説明します。

WPF アプリは、システム DPI の既定では、認識がモニターごとの DPI 対応で app.manifest ファイルに対して自身を宣言する必要があります。 アプリ マニフェスト ファイルでモニターごとの DPI 認識を Windows レベル: オンにする

1. **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
1. コンテキスト メニューで選択**追加** > **新しい項目.**.
1. **新しい項目の追加**ダイアログ ボックスで、' アプリケーション マニフェスト ファイル ' を選択し、クリックして**追加**します。 (既定の名前をおくことができます。)
1. アプリケーション マニフェスト ファイルでこの xml とコメントを解除を見つけること。

    ```xaml
    <application xmlns="urn:schemas-microsoft-com:asm.v3">
        <windowsSettings>
          <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
        </windowsSettings>
      </application>
    ```

1. 開始後にこの設定を追加`<windowsSettings>`タグ。

    ```xaml
          <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitor</dpiAwareness>
    ```

1. 設定する必要があります、 **DoNotScaleForDpiChanges** App.config ファイルで設定します。

    App.Config を開き、内には、この xml を追加、`<configuration>`要素。

    ```xml
    <runtime>
      <AppContextSwitchOverrides value="Switch.System.Windows.DoNotScaleForDpiChanges=false"/>
    </runtime>
    ```

> [!NOTE]
> **AppContextSwitchOverrides** 1 回のみ設定できます。 既にアプリケーションに 1 つのセットがある場合は、セミコロン必要があります。 属性値内でこのスイッチを区切ります。

(詳細については、次を参照してください、[あたりモニター DPI 開発者ガイドとサンプル](https://github.com/Microsoft/WPF-Samples/tree/master/PerMonitorDPI)github。)。

## <a name="create-an-hwndhost-derived-class-to-host-composition-elements"></a>コンポジションのホスト要素に HwndHost が派生クラスを作成します。

ビジュアル層で作成するコンテンツのホストにから派生するクラスを作成する必要があります。 [HwndHost](/dotnet/api/system.windows.interop.hwndhost)します。 これは、合成 Api をホストするための構成の大部分を実行します。 このクラスを使用して[プラットフォーム呼び出しサービス (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code)と[COM 相互運用機能](/dotnet/api/system.runtime.interopservices.comimportattribute)WPF アプリに合成 Api を表示します。 PInvoke と COM 相互運用機能の詳細については、次を参照してください。[アンマネージ コードとの相互運用](/dotnet/framework/interop/index)します。

> [!TIP]
> 必要がある場合は、すべてのコードは、チュートリアルを使用すると適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。

1. 派生するプロジェクトに新しいクラス ファイルを追加[HwndHost](/dotnet/api/system.windows.interop.hwndhost)します。
    - **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
    - コンテキスト メニューで選択**追加** > **クラス.**.
    - **新しい項目の追加**ダイアログ ボックスで、クラス名_CompositionHost.cs_、 をクリックし、**追加**します。
1. 派生するクラス定義を編集、CompositionHost.cs で**HwndHost**します。

    ```csharp
    // Add
    // using System.Windows.Interop;

    namespace HelloComposition
    {
        class CompositionHost : HwndHost
        {
        }
    }
    ```

1. クラスに次のコードとコンス トラクターを追加します。

    ```csharp
    // Add
    // using Windows.UI.Composition;

    IntPtr hwndHost;
    int hostHeight, hostWidth;
    object dispatcherQueue;
    ICompositionTarget compositionTarget;

    public Compositor Compositor { get; private set; }

    public Visual Child
    {
        set
        {
            if (Compositor == null)
            {
                InitComposition(hwndHost);
            }
            compositionTarget.Root = value;
        }
    }

    internal const int
      WS_CHILD = 0x40000000,
      WS_VISIBLE = 0x10000000,
      LBS_NOTIFY = 0x00000001,
      HOST_ID = 0x00000002,
      LISTBOX_ID = 0x00000001,
      WS_VSCROLL = 0x00200000,
      WS_BORDER = 0x00800000;

    public CompositionHost(double height, double width)
    {
        hostHeight = (int)height;
        hostWidth = (int)width;
    }
    ```

1. 上書き、 **BuildWindowCore**と**次**メソッド。
    > [!NOTE]
    > BuildWindowCore でを呼び出す、 _InitializeCoreDispatcher_と_InitComposition_メソッド。 次の手順では、これらのメソッドを作成します。

    ```csharp
    // Add
    // using System.Runtime.InteropServices;

    protected override HandleRef BuildWindowCore(HandleRef hwndParent)
    {
        // Create Window
        hwndHost = IntPtr.Zero;
        hwndHost = CreateWindowEx(0, "static", "",
                                  WS_CHILD | WS_VISIBLE,
                                  0, 0,
                                  hostWidth, hostHeight,
                                  hwndParent.Handle,
                                  (IntPtr)HOST_ID,
                                  IntPtr.Zero,
                                  0);

        // Create Dispatcher Queue
        dispatcherQueue = InitializeCoreDispatcher();

        // Build Composition tree of content
        InitComposition(hwndHost);

        return new HandleRef(this, hwndHost);
    }

    protected override void DestroyWindowCore(HandleRef hwnd)
    {
        if (compositionTarget.Root != null)
        {
            compositionTarget.Root.Dispose();
        }
        DestroyWindow(hwnd.Handle);
    }
    ```

    - [CreateWindowEx](/windows/desktop/api/winuser/nf-winuser-createwindowexa)と[DestroyWindow](/windows/desktop/api/winuser/nf-winuser-destroywindow) PInvoke 宣言が必要です。 この宣言をクラスのコードの最後に配置します。

    ```csharp
    #region PInvoke declarations

    [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                  string lpszClassName,
                                                  string lpszWindowName,
                                                  int style,
                                                  int x, int y,
                                                  int width, int height,
                                                  IntPtr hwndParent,
                                                  IntPtr hMenu,
                                                  IntPtr hInst,
                                                  [MarshalAs(UnmanagedType.AsAny)] object pvParam);

    [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
    internal static extern bool DestroyWindow(IntPtr hwnd);

    #endregion PInvoke declarations
    ```

1. スレッドの初期化、 [CoreDispatcher](/uwp/api/windows.ui.core.coredispatcher)します。 Core ディスパッチャーは、ウィンドウ メッセージを処理して、イベントをディスパッチ WinRT Api を担当します。 新しいインスタンス**CoreDispatcher** CoreDispatcher を含むスレッドで作成する必要があります。
    - という名前のメソッドを作成する_InitializeCoreDispatcher_ディスパッチャー キューを設定するコードを追加します。

    ```csharp
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

    - ディスパッチャー キューには、PInvoke 宣言も必要です。 この宣言内の配置、 _PInvoke 宣言_前の手順で作成されるリージョン。

    ```csharp
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
    ```

    今すぐディスパッチャー キューの準備ができているし、初期化し、合成コンテンツの作成を開始できます。

1. 初期化、[コンポジター](/uwp/api/windows.ui.composition.compositor)します。 コンポジターがさまざまな型を作成するファクトリを[Windows.UI.Composition](/uwp/api/windows.ui.composition)ビジュアル、効果のシステム、およびアニメーション システムにまたがる名前空間。 コンポジター クラスには、ファクトリから作成されたオブジェクトの有効期間も管理します。

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
        ICompositionTarget target = (ICompositionTarget)rawObject;

        if (raw == null) { throw new Exception("QI Failed"); }
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

## <a name="create-a-usercontrol-to-add-your-content-to-the-wpf-visual-tree"></a>WPF のビジュアル ツリーにコンテンツを追加するユーザー コントロールを作成します。

HwndHost を WPF のビジュアル ツリーに追加するコンテンツは、コンポジションのホストに必要なインフラストラクチャをセットアップする最後の手順。

### <a name="create-a-usercontrol"></a>UserControl を作成します。

UserControl は、コンポジションのコンテンツを管理するコードをパッケージ化し、XAML にコンテンツを簡単に追加する便利な方法です。

1. 新しいユーザー コントロール ファイルをプロジェクトに追加します。
    - **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
    - コンテキスト メニューで選択**追加** > **ユーザー制御しています.**.
    - **新しい項目の追加**ダイアログ ボックスで、ユーザー コントロールに名前を_CompositionHostControl.xaml_、 をクリックし、**追加**します。

    CompositionHostControl.xaml と CompositionHostControl.xaml.cs の両方のファイルが作成され、プロジェクトに追加します。
1. CompositionHostControl.xaml、置き換えます、`<Grid> </Grid>`このタグ**境界線**HwndHost がである XAML コンテナーである要素。

    ```xaml
    <Border Name="CompositionHostElement"/>
    ```

ユーザー コントロールのコードで、前の手順で作成した CompositionHost クラスのインスタンスを作成し、子要素として追加_CompositionHostElement_、XAML ページで作成した境界線。

1. CompositionHostControl.xaml.cs では、構成コードで使用するオブジェクトのプライベート変数を追加します。 クラス定義の後にこれらを追加します。

    ```csharp
    CompositionHost compositionHost;
    Compositor compositor;
    Windows.UI.Composition.ContainerVisual containerVisual;
    DpiScale currentDpi;
    ```

1. ユーザー コントロールのハンドラーを追加**Loaded**イベント。 これは、CompositionHost インスタンスを設定します。

    - コンス トラクターのフック イベント ハンドラーを次に示すよう (`Loaded += CompositionHostControl_Loaded;`)。

    ```csharp
    public CompositionHostControl()
    {
        InitializeComponent();
        Loaded += CompositionHostControl_Loaded;
    }
    ```

    - 名前のイベント ハンドラー メソッドを追加*CompositionHostControl_Loaded*します。
    ```csharp
    private void CompositionHostControl_Loaded(object sender, RoutedEventArgs e)
    {
        // If the user changes the DPI scale setting for the screen the app is on,
        // the CompositionHostControl is reloaded. Don't redo this set up if it's
        // already been done.
        if (compositionHost is null)
        {
            currentDpi = VisualTreeHelper.GetDpi(this);

            compositionHost =
                new CompositionHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
            ControlHostElement.Child = compositionHost;
            compositor = compositionHost.Compositor;
            containerVisual = compositor.CreateContainerVisual();
            compositionHost.Child = containerVisual;
        }
    }
    ```

    このメソッドでは、構成コードで使用するオブジェクトを設定します。 何が起こっているかの概要を次に示します。

    - 最初に、セットアップに一度だけ実行をチェックして CompositionHost のインスタンスが既に存在するかどうかを確認します。

    ```csharp
    // If the user changes the DPI scale setting for the screen the app is on,
    // the CompositionHostControl is reloaded. Don't redo this set up if it's
    // already been done.
    if (compositionHost is null)
    {

    }
    ```

    - 現在の DPI を取得します。 これは、合成要素を適切にスケールに使用されます。

    ```csharp
    currentDpi = VisualTreeHelper.GetDpi(this);
    ```

    - CompositionHost のインスタンスを作成し、境界線の子として代入_CompositionHostElement_します。

    ```csharp
    compositionHost =
        new CompositionHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
    ControlHostElement.Child = compositionHost;
    ```

    - CompositionHost からコンポジターを取得します。

    ```csharp
    compositor = compositionHost.Compositor;
    ```

    - ビジュアル コンテナーを作成するのにには、コンポジターを使用します。 これは、合成要素を追加する合成コンテナーです。

    ```csharp
    containerVisual = compositor.CreateContainerVisual();
    compositionHost.Child = containerVisual;
    ```

### <a name="add-composition-elements"></a>合成要素を追加します。

インフラストラクチャを導入するに表示する合成コンテンツを生成できます。

この例で作成して単純な四角形をアニメーション化するコードを追加する[SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)します。

1. 合成要素を追加します。 CompositionHostControl.xaml.cs では、CompositionHostControl クラスにこれらのメソッドを追加します。

    ```csharp
    // Add
    // using System.Numerics;

    public void AddElement(float size, float offsetX, float offsetY)
    {
        var visual = compositor.CreateSpriteVisual();
        visual.Size = new Vector2(size, size);
        visual.Scale = new Vector3((float)currentDpi.DpiScaleX, (float)currentDpi.DpiScaleY, 1);
        visual.Brush = compositor.CreateColorBrush(GetRandomColor());
        visual.Offset = new Vector3(offsetX * (float)currentDpi.DpiScaleX, offsetY * (float)currentDpi.DpiScaleY, 0);

        containerVisual.Children.InsertAtTop(visual);

        AnimateSquare(visual, 3);
    }

    private void AnimateSquare(SpriteVisual visual, int delay)
    {
        float offsetX = (float)(visual.Offset.X); // Already adjusted for DPI.

        // Adjust values for DPI scale, then find the Y offset that aligns the bottom of the square
        // with the bottom of the host container. This is the value to animate to.
        var hostHeightAdj = CompositionHostElement.ActualHeight * currentDpi.DpiScaleY;
        var squareSizeAdj = visual.Size.Y * currentDpi.DpiScaleY;
        float bottom = (float)(hostHeightAdj - squareSizeAdj);

        // Create the animation only if it's needed.
        if (visual.Offset.Y != bottom)
        {
            Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
            animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
            animation.Duration = TimeSpan.FromSeconds(2);
            animation.DelayTime = TimeSpan.FromSeconds(delay);
            visual.StartAnimation("Offset", animation);
        }
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

### <a name="handle-dpi-changes"></a>DPI 変更を処理します。

コードを追加して要素をアニメーション化する現在の DPI スケールするときは考慮要素が作成されますが、アプリの実行中に、DPI の変更を考慮する必要もあります。 処理することができます、 [HwndHost.DpiChanged](/dotnet/api/system.windows.interop.hwndhost.dpichanged)新しい DPI に基づいてイベントの変更を通知し、計算の結果を調整します。

1. CompositionHostControl_Loaded メソッドで最後の行の後、DpiChanged イベントのハンドラーをフックするこれを追加します。

    ```csharp
    compositionHost.DpiChanged += CompositionHost_DpiChanged;
    ```

1. 名前のイベント ハンドラー メソッドを追加_CompositionHostDpiChanged_します。 このコードでは、スケールと、各要素のオフセットを調整し、完了しないすべてのアニメーションを再計算されます。

    ```csharp
    private void CompositionHost_DpiChanged(object sender, DpiChangedEventArgs e)
    {
        currentDpi = e.NewDpi;
        Vector3 newScale = new Vector3((float)e.NewDpi.DpiScaleX, (float)e.NewDpi.DpiScaleY, 1);

        foreach (SpriteVisual child in containerVisual.Children)
        {
            child.Scale = newScale;
            var newOffsetX = child.Offset.X * ((float)e.NewDpi.DpiScaleX / (float)e.OldDpi.DpiScaleX);
            var newOffsetY = child.Offset.Y * ((float)e.NewDpi.DpiScaleY / (float)e.OldDpi.DpiScaleY);
            child.Offset = new Vector3(newOffsetX, newOffsetY, 1);

            // Adjust animations for DPI change.
            AnimateSquare(child, 0);
        }
    }
    ```

## <a name="add-the-user-control-to-your-xaml-page"></a>XAML ページに、ユーザー コントロールを追加します。

次に、XAML UI にユーザー コントロールを追加できます。

1. MainWindow.xaml では、600 と 840 に幅にウィンドウの高さを設定します。
1. UI の XAML を追加します。 MainWindow.xaml で、ルートの間には、この XAML を追加`<Grid> </Grid>`タグ。

    ```xaml
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="210"/>
        <ColumnDefinition Width="600"/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="46"/>
        <RowDefinition/>
    </Grid.RowDefinitions>
    <Button Content="Add composition element" Click="Button_Click"
            Grid.Row="1" Margin="12,0"
            VerticalAlignment="Top" Height="40"/>
    <TextBlock Text="Composition content" FontSize="20"
               Grid.Column="1" Margin="0,12,0,4"
               HorizontalAlignment="Center"/>
    <local:CompositionHostControl x:Name="CompositionHostControl1"
                                  Grid.Row="1" Grid.Column="1"
                                  VerticalAlignment="Top"
                                  Width="600" Height="500"
                                  BorderBrush="LightGray"
                                  BorderThickness="3"/>
    ```

1. 新しい要素を作成するボタンのクリックを処理します。 (クリック イベントは既にフック、XAML でします。)

    MainWindow.xaml.cs でこれを追加*Button_Click*イベント ハンドラー メソッド。 このコードは呼び出して_CompositionHost.AddElement_ランダムに生成されたサイズおよびオフセットを新しい要素を作成します。

    ```csharp
    // Add
    // using System;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        float size = random.Next(50, 150);
        float offsetX = random.Next(0, (int)(CompositionHostControl1.ActualWidth - size));
        float offsetY = random.Next(0, (int)(CompositionHostControl1.ActualHeight/2 - size));
        CompositionHostControl1.AddElement(size, offsetX, offsetY);
    }
    ```

ビルドして、WPF アプリを実行することができますようになりました。 必要がある場合は、すべてのコードは、適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。

アプリを実行する ボタンをクリックすると、UI に追加するアニメーションの正方形が表示されます。

## <a name="next-steps"></a>次のステップ

同じインフラストラクチャ上に構築するより詳細な例については、 [WPF Visual レイヤーの統合サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WPF/VisualLayerIntegration)GitHub でします。

## <a name="additional-resources"></a>その他の資料

- [概要 (WPF)](/dotnet/framework/wpf/getting-started/) (.NET)
- [アンマネージ コードと相互運用](/dotnet/framework/interop/)(.NET)
- [Windows 10 アプリの概要](/windows/uwp/get-started/)(UWP)
- [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)(UWP)
- [名前空間の Windows.UI.Composition](/uwp/api/windows.ui.composition) (UWP)

## <a name="complete-code"></a>コードを完成させる

このチュートリアルの完全なコードを示します。

### <a name="mainwindowxaml"></a>MainWindow.xaml

```xaml
<Window x:Class="HelloComposition.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:HelloComposition"
        mc:Ignorable="d"
        Title="MainWindow" Height="600" Width="840">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="210"/>
            <ColumnDefinition Width="600"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="46"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Button Content="Add composition element" Click="Button_Click"
                Grid.Row="1" Margin="12,0"
                VerticalAlignment="Top" Height="40"/>
        <TextBlock Text="Composition content" FontSize="20"
                   Grid.Column="1" Margin="0,12,0,4"
                   HorizontalAlignment="Center"/>
        <local:CompositionHostControl x:Name="CompositionHostControl1"
                                      Grid.Row="1" Grid.Column="1"
                                      VerticalAlignment="Top"
                                      Width="600" Height="500"
                                      BorderBrush="LightGray" BorderThickness="3"/>
    </Grid>
</Window>
```

### <a name="mainwindowxamlcs"></a>MainWindow.xaml.cs

```csharp
using System;
using System.Windows;

namespace HelloComposition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            float size = random.Next(50, 150);
            float offsetX = random.Next(0, (int)(CompositionHostControl1.ActualWidth - size));
            float offsetY = random.Next(0, (int)(CompositionHostControl1.ActualHeight/2 - size));
            CompositionHostControl1.AddElement(size, offsetX, offsetY);
        }
    }
}
```

### <a name="compositionhostcontrolxaml"></a>CompositionHostControl.xaml

```xaml
<UserControl x:Class="HelloComposition.CompositionHostControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:local="clr-namespace:HelloComposition"
             mc:Ignorable="d"
             d:DesignHeight="450" d:DesignWidth="800">
    <Border Name="CompositionHostElement"/>
</UserControl>
```

### <a name="compositionhostcontrolxamlcs"></a>CompositionHostControl.xaml.cs

```csharp
using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Windows.UI.Composition;

namespace HelloComposition
{
    /// <summary>
    /// Interaction logic for CompositionHostControl.xaml
    /// </summary>
    public partial class CompositionHostControl : UserControl
    {
        CompositionHost compositionHost;
        Compositor compositor;
        Windows.UI.Composition.ContainerVisual containerVisual;
        DpiScale currentDpi;

        public CompositionHostControl()
        {
            InitializeComponent();
            Loaded += CompositionHostControl_Loaded;
        }

        private void CompositionHostControl_Loaded(object sender, RoutedEventArgs e)
        {
            // If the user changes the DPI scale setting for the screen the app is on,
            // the CompositionHostControl is reloaded. Don't redo this set up if it's
            // already been done.
            if (compositionHost is null)
            {
                currentDpi = VisualTreeHelper.GetDpi(this);

                compositionHost = new CompositionHost(CompositionHostElement.ActualHeight, CompositionHostElement.ActualWidth);
                CompositionHostElement.Child = compositionHost;
                compositor = compositionHost.Compositor;
                containerVisual = compositor.CreateContainerVisual();
                compositionHost.Child = containerVisual;
            }
        }

        protected override void OnDpiChanged(DpiScale oldDpi, DpiScale newDpi)
        {
            base.OnDpiChanged(oldDpi, newDpi);
            currentDpi = newDpi;
            Vector3 newScale = new Vector3((float)newDpi.DpiScaleX, (float)newDpi.DpiScaleY, 1);

            foreach (SpriteVisual child in containerVisual.Children)
            {
                child.Scale = newScale;
                var newOffsetX = child.Offset.X * ((float)newDpi.DpiScaleX / (float)oldDpi.DpiScaleX);
                var newOffsetY = child.Offset.Y * ((float)newDpi.DpiScaleY / (float)oldDpi.DpiScaleY);
                child.Offset = new Vector3(newOffsetX, newOffsetY, 1);

                // Adjust animations for DPI change.
                AnimateSquare(child, 0);
            }
        }

        public void AddElement(float size, float offsetX, float offsetY)
        {
            var visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(size, size);
            visual.Scale = new Vector3((float)currentDpi.DpiScaleX, (float)currentDpi.DpiScaleY, 1);
            visual.Brush = compositor.CreateColorBrush(GetRandomColor());
            visual.Offset = new Vector3(offsetX * (float)currentDpi.DpiScaleX, offsetY * (float)currentDpi.DpiScaleY, 0);

            containerVisual.Children.InsertAtTop(visual);

            AnimateSquare(visual, 3);
        }

        private void AnimateSquare(SpriteVisual visual, int delay)
        {
            float offsetX = (float)(visual.Offset.X); // Already adjusted for DPI.

            // Adjust values for DPI scale, then find the Y offset that aligns the bottom of the square
            // with the bottom of the host container. This is the value to animate to.
            var hostHeightAdj = CompositionHostElement.ActualHeight * currentDpi.DpiScaleY;
            var squareSizeAdj = visual.Size.Y * currentDpi.DpiScaleY;
            float bottom = (float)(hostHeightAdj - squareSizeAdj);

            // Create the animation only if it's needed.
            if (visual.Offset.Y != bottom)
            {
                Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
                animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
                animation.Duration = TimeSpan.FromSeconds(2);
                animation.DelayTime = TimeSpan.FromSeconds(delay);
                visual.StartAnimation("Offset", animation);
            }
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
using System.Windows.Interop;
using Windows.UI.Composition;

namespace HelloComposition
{
    class CompositionHost : HwndHost
    {
        IntPtr hwndHost;
        int hostHeight, hostWidth;
        object dispatcherQueue;
        ICompositionTarget compositionTarget;

        public Compositor Compositor { get; private set; }

        public Visual Child
        {
            set
            {
                if (Compositor == null)
                {
                    InitComposition(hwndHost);
                }
                compositionTarget.Root = value;
            }
        }

        internal const int
          WS_CHILD = 0x40000000,
          WS_VISIBLE = 0x10000000,
          LBS_NOTIFY = 0x00000001,
          HOST_ID = 0x00000002,
          LISTBOX_ID = 0x00000001,
          WS_VSCROLL = 0x00200000,
          WS_BORDER = 0x00800000;

        public CompositionHost(double height, double width)
        {
            hostHeight = (int)height;
            hostWidth = (int)width;
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            // Create Window
            hwndHost = IntPtr.Zero;
            hwndHost = CreateWindowEx(0, "static", "",
                                      WS_CHILD | WS_VISIBLE,
                                      0, 0,
                                      hostWidth, hostHeight,
                                      hwndParent.Handle,
                                      (IntPtr)HOST_ID,
                                      IntPtr.Zero,
                                      0);

            // Create Dispatcher Queue
            dispatcherQueue = InitializeCoreDispatcher();

            // Build Composition Tree of content
            InitComposition(hwndHost);

            return new HandleRef(this, hwndHost);
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            if (compositionTarget.Root != null)
            {
                compositionTarget.Root.Dispose();
            }
            DestroyWindow(hwnd.Handle);
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

            Compositor = new Compositor();
            object iunknown = Compositor as object;
            interop = (ICompositorDesktopInterop)iunknown;
            IntPtr raw;
            interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

            object rawObject = Marshal.GetObjectForIUnknown(raw);
            compositionTarget = (ICompositionTarget)rawObject;

            if (raw == null) { throw new Exception("QI Failed"); }
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


        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                      string lpszClassName,
                                                      string lpszWindowName,
                                                      int style,
                                                      int x, int y,
                                                      int width, int height,
                                                      IntPtr hwndParent,
                                                      IntPtr hMenu,
                                                      IntPtr hInst,
                                                      [MarshalAs(UnmanagedType.AsAny)] object pvParam);

        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);


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