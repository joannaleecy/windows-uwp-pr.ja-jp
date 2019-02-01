---
description: この記事では、デスクトップ アプリケーションで UWP XAML UI をホストする方法について説明します。
title: デスクトップ アプリケーションで API をホストしている UWP XAML の使用
ms.date: 01/11/2019
ms.topic: article
keywords: windows 10、uwp、windows フォーム、wpf、win32
ms.localizationpriority: medium
ms.openlocfilehash: efd7dc687b9aba2e3c07b0afefa2e4fa49b882b1
ms.sourcegitcommit: 2d2483819957619b6de21b678caf887f3b1342af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/01/2019
ms.locfileid: "9042314"
---
# <a name="using-the-uwp-xaml-hosting-api-in-a-desktop-application"></a>デスクトップ アプリケーションで API をホストしている UWP XAML の使用

> [!NOTE]
> UWP XAML ホスティング API と XAML 諸島現在利用可能な開発者プレビューとしてします。 試すことに、独自のプロトタイプ コードのようになりましたをお勧めしますがない使用することに運用コードでこの時点でお勧めしますしないでください。 これらの機能は引き続き成熟して、将来の Windows リリースに安定します。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。
>
> についてフィードバックがある場合、XAML 諸島は[WindowsCommunityToolkit リポジトリ](https://github.com/windows-toolkit/WindowsCommunityToolkit/issues)で新しい懸案事項を作成し、コメントのままに存在します。 お客様のフィードバックを個別に提出する場合に送信できますXamlIslandsFeedback@microsoft.comします。 Insights、およびシナリオはにとって非常に重要です。

Windows 10 Insider Preview SDK ビルド 17709、UWP 以外のデスクトップ アプリケーション (WPF、Windows フォーム、および C++ の Win32 アプリケーションを含む) は、ウィンドウのハンドル (に関連付けられている任意の UI 要素で UWP コントロールをホストする*API をホストしている UWP XAML*を使用することができます。HWND)。 この API では、最新の Windows 10 の UI 機能のみで利用可能な UWP コントロールを使用するデスクトップ アプリケーションを UWP 以外でできます。 たとえば、UWP 以外のデスクトップ アプリケーションでは、 [Fluent Design System](../design/fluent-design-system/index.md)を使用して、 [Windows Ink](../design/input/pen-and-stylus-interactions.md)をサポートしている UWP コントロールをホストするには、この API を使用できます。

API をホストしている UWP XAML より広範な一連の提供、開発者のデスクトップ アプリケーションを UWP 以外に Fluent UI を表示するコントロールの基盤を提供します。 このシナリオは、 *XAML 諸島*と呼ばれます。 この開発者シナリオについて詳しくは、[デスクトップ アプリケーションで UWP コントロール](xaml-host-controls.md)を参照してください。

## <a name="is-the-uwp-xaml-hosting-api-right-for-your-desktop-application"></a>UWP XAML をホストしている API、デスクトップ アプリケーションの右かどうか。

API をホストしている UWP XAML では、デスクトップ アプリケーションで UWP コントロールのホスティングの低レベルのインフラストラクチャを提供します。 一部の種類のデスクトップ アプリケーションでは、代替、便利な Api を使用してこの目標を達成するオプションがあります。  

* C++ Win32 デスクトップ アプリケーションがあり、アプリケーションで UWP コントロールをホストする場合は、API をホストしている UWP XAML を使う必要があります。 この種類のアプリケーションの候補はありません。

* WPF および Windows フォーム アプリケーションでは、お勧めします UWP XAML ではなく、Windows コミュニティ ツールキットで[ラップされたコントロール](xaml-host-controls.md#wrapped-controls)と[ホスト コントロール](xaml-host-controls.md#host-controls)が使用して API をホストしています。 これらのコントロールでは、内部的に API をホストしている UWP XAML を使用し、シンプルな開発エクスペリエンスを提供します。 ただし、選択した場合は、この種類のアプリケーションで直接 API をホストしている UWP XAML を使用することができます。

## <a name="related-samples"></a>関連するサンプル

コードで API をホストしている UWP XAML を使用する方法は、アプリケーション、およびその他の要因のデザイン、アプリケーションの種類によって異なります。 完全なアプリケーションのコンテキストでこの API を使用する方法を示すために、この記事では次のサンプルからのコードを参照します。

### <a name="c-win32"></a>C++ Win32

GitHub で C++ Win32 アプリケーションで API をホストしている UWP XAML を使用する方法を示すサンプルがいくつかあります。

  * [XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)します。 このサンプルでは、C++ の Win32 アプリケーションを UWP [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), [InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)と[MediaPlayerElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement)コントロールを追加する方法を示します。
  * [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)します。 このサンプルでは、C++ の Win32 アプリケーションをいくつかの基本的な UWP コントロールを追加し、DPI の変更を処理する方法を示します。

### <a name="wpf-and-windows-forms"></a>WPF および Windows フォーム

Windows コミュニティ ツールキットで[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)コントロールは、WPF および Windows フォーム アプリケーションで API をホストしている UWP を使用するためのリファレンス サンプルとして機能します。 ソース コードは、次の場所から入手できます。

  * [ここ](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Wpf.UI.XamlHost)に、コントロールの WPF バージョンです。 WPF バージョンは、 [**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)から派生します。
  * [ここ](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Forms.UI.XamlHost)に、コントロールの Windows フォーム バージョンです。 Windows フォーム バージョンは、 [**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)から派生します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP XAML では、これらの前提条件があります。

* Windows 10 Insider Preview ビルド 17709 (またはそれ以降のビルド) と Windows SDK の対応する Insider Preview ビルドします。 これは、進化する機能であるため、最適なエクスペリエンスをお勧めします利用可能な最新のビルドを使用します。

* デスクトップ アプリケーションの API をホストしている UWP XAML を使用するには、UWP Api を呼び出すことができるように、プロジェクトを構成する必要があります。

    * **C++ Win32:** 使用するプロジェクトを構成することをお勧めします[、C++/WinRT](../cpp-and-winrt-apis/index.md)します。 手順については、次を参照してください。[を追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。

    * **Windows フォーム、WPF:**[次の手順](../porting/desktop-to-uwp-enhance.md)に従います。

## <a name="architecture-of-xaml-islands"></a>XAML 諸島のアーキテクチャ

API をホストしている UWP XAML には、 [**Windows.UI.Xaml.Hosting**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間で、 [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)、 [**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)、およびその他の関連する型が含まれています。 デスクトップ アプリケーションでは、UWP コントロールをレンダリングし、キーボード フォーカス ナビゲーションと要素をルートにこの API を使用できます。 デスクトップ アプリケーションは、サイズもや、必要に応じて、UWP コントロールを配置します。

デスクトップ アプリケーションで API をホストしている XAML を使って XAML 島を作成するときのオブジェクトの次の階層必要があります。

* 基本レベルで XAML 島をホストするアプリケーションの UI 要素は、します。 この UI 要素には、ウィンドウのハンドル (HWND) 必要があります。 XAML 島をホストできる UI 要素の例には、WPF アプリケーション、Windows フォーム アプリケーションで[**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)および C++ Win32 アプリケーションの[ウィンドウ](https://docs.microsoft.com/windows/desktop/winmsg/about-windows)の[**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)が含まれます。

* 次のレベルは、 **DesktopWindowXamlSource**オブジェクトです。 このオブジェクトは、XAML 島をホストするため、インフラストラクチャを提供します。 コードは、このオブジェクトを作成して、親の UI 要素にアタッチすることを行います。

* **DesktopWindowXamlSource**を作成するとき、このオブジェクトは自動的に、UWP コントロールをホストするネイティブ子ウィンドウを作成します。 このネイティブ子ウィンドウが、コードから抽象化ほとんどが、そのハンドル (HWND) 必要な場合にアクセスすることができます。

* 最後に、最上位レベルのデスクトップ アプリケーションをホストする UWP コントロールです。 これは、 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)、Windows SDK とカスタム ユーザー コントロールによって提供されるすべての UWP コントロールを含むから派生した任意の UWP オブジェクトです。

次の図は、XAML 島内のオブジェクトの階層を示しています。

![DesktopWindowXamlSource アーキテクチャ](images/xaml-hosting-api-rev2.png)

## <a name="how-to-host-uwp-xaml-controls"></a>UWP XAML コントロールをホストする方法

API をホストしている UWP XAML を使用して、アプリケーションで UWP コントロールをホストするための主な手順を次に示します。

1. [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)でそれをホストする[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトのいずれかのアプリケーションを作成する前に、現在のスレッドの UWP XAML フレームワークを初期化します。

    * **DesktopWindowXamlSource**オブジェクトをインスタンス化するときにこのフレームワークの初期化する**Windows.UI.Xaml.UIElement**オブジェクトのいずれかの作成前に、アプリケーションは**DesktopWindowXamlSource**オブジェクトを作成する場合. このシナリオでは、フレームワークを初期化する独自のコードを追加する必要はありません。

    * ただし、それらをホストする**DesktopWindowXamlSource**オブジェクトを作成する前に、アプリケーションは**Windows.UI.Xaml.UIElement**オブジェクトを作成する場合、アプリケーション呼び出す必要があります、静的な[**WindowsXamlManager.InitializeForCurrentThread**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager.initializeforcurrentthread) **Windows.UI.Xaml.UIElement**オブジェクトがインスタンス化する前に、UWP XAML フレームワークを明示的に初期化します。 **DesktopWindowXamlSource**をホストする親 UI 要素がインスタンス化されるとき、アプリケーションは以下のメソッドを呼び出す通常必要があります。

    ```cppwinrt
    Windows::UI::Xaml::Hosting::WindowsXamlManager windowsXamlManager =
        Windows::UI::Xaml::Hosting::WindowsXamlManager::InitializeForCurrentThread();
    ```

    ```csharp
    global::Windows.UI.Xaml.Hosting.WindowsXamlManager windowsXamlManager =
        global::Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
    ```

    > [!NOTE]
    > このメソッドは、UWP XAML フレームワークへの参照が含まれている[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)オブジェクトを返します。 特定のスレッドで必要な数の**WindowsXamlManager**オブジェクトを作成することができます。 ただし、各オブジェクトは、UWP XAML フレームワークへの参照を保持しているために、最終的に XAML リソースが解放されることを確認するオブジェクトを破棄する必要があります。

2. [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを作成し、それを親ウィンドウ ハンドルに関連付けられているアプリケーションで UI 要素にアタッチします。

    これを行うには、これらの手順に従う必要があります。

    1. **DesktopWindowXamlSource**オブジェクトを作成し、 **IDesktopWindowXamlSourceNative** COM インターフェイスにキャストします。 このインターフェイスがで宣言されている、 ```windows.ui.xaml.hosting.desktopwindowxamlsource.h``` Windows sdk ヘッダー ファイルです。 C++ Win32 プロジェクトでは、このヘッダー ファイルを直接参照できます。 WPF または Windows フォーム プロジェクトで[**ComImport**](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.comimportattribute)属性を使って、アプリケーション コードでは、このインターフェイスを宣言する必要があります。 インターフェイスの宣言は、インターフェイスの宣言を正確に一致することを確認```windows.ui.xaml.hosting.desktopwindowxamlsource.h```します。

    2. **IDesktopWindowXamlSourceNative**インターフェイスの**AttachToWindow**メソッドを呼び出すし、アプリケーションの親の UI 要素のウィンドウのハンドルを渡します。

    3. 初期**DesktopWindowXamlSource**に含まれている内部子ウィンドウのサイズを設定します。 既定では、この内部子ウィンドウは幅と高さを 0 に設定されます。 ウィンドウのサイズを設定しない場合、 **DesktopWindowXamlSource**に追加する任意の UWP コントロールは表示されません。 **DesktopWindowXamlSource**で内部子ウィンドウにアクセスするには、 **IDesktopWindowXamlSourceNative**インターフェイスの**WindowHandle**プロパティを使用します。 次の例では、ウィンドウのサイズを設定するのに[SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数を使用します。

    このプロセスを示すコード例をいくつかを示します。

    ```cppwinrt
    // This example assumes you already have an HWND variable named 'parentHwnd' that
    // contains the handle of the parent window.
    Windows::UI::Xaml::Hosting::DesktopWindowXamlSource desktopWindowXamlSource;
    auto interop = desktopWindowXamlSource.as<IDesktopWindowXamlSourceNative>();
    check_hresult(interop->AttachToWindow(parentHwnd));

    HWND childInteropHwnd = nullptr;
    interop->get_WindowHandle(&childInteropHwnd);

    SetWindowPos(childInteropHwnd, 0, 0, 0, 300, 300, SWP_SHOWWINDOW);
    ```

    ```csharp
    // This WPF example assumes you already have an HwndHost named 'parentHwndHost'
    // that will act as the parent UI elemnt for your XAML island. It also assumes
    // you have used the DllImport attribute to import SetWindowPos from user32.dll
    // as a static method into a class named NativeMethods.
    Windows.UI.Xaml.Hosting.DesktopWindowXamlSource desktopWindowXamlSource =
        new Windows.UI.Xaml.Hosting.DesktopWindowXamlSource();

    IntPtr iUnknownPtr = System.Runtime.InteropServices.Marshal.GetIUnknownForObject(
        desktopWindowXamlSource);
    IDesktopWindowXamlSourceNative desktopWindowXamlSourceNative =
        System.Runtime.InteropServices.Marshal.Marshal.GetTypedObjectForIUnknown(
            iUnknownPtr, typeof(IDesktopWindowXamlSourceNative))
            as IDesktopWindowXamlSourceNative;

    desktopWindowXamlSourceNative.AttachToWindow(parentHwndHost.Handle);

    var childInteropHwnd = desktopWindowXamlSourceNative.WindowHandle;
    NativeMethods.SetWindowPos(childInteropHwnd, HWND_TOP, 0, 0, 300, 300, SWP_SHOWWINDOW);
    ```

3. **DesktopWindowXamlSource**オブジェクトの[**コンテンツ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.content)プロパティをホストする**Windows.UI.Xaml.UIElement**を設定します。 次の例では、名前付き[**Windows.UI.Xaml.Controls.Grid**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid) ```myGrid``` **Content**プロパティにします。

   ```cppwinrt
   desktopWindowXamlSource.Content(myGrid);
   ```

   ```csharp
   desktopWindowXamlSource.Content = myGrid;
   ```

実用的なサンプル アプリケーションのコンテキストでこれらのタスクを示す完全な例については、次のコード ファイルを参照してください。

  * **C++ Win32:**[XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)サンプル[Main.cpp](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting/blob/master/XamlHostingSample/Main.cpp)ファイルまたは[XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)サンプル[Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)ファイルを参照してください。
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。


## <a name="how-to-host-custom-uwp-xaml-controls"></a>どのようにカスタム ホストに UWP XAML コントロール

> [!IMPORTANT]
> 現時点では、サード パーティからカスタムの UWP XAML コントロールは、c# WPF および Windows フォーム アプリケーションでのみサポートされます。 アプリケーションでそれに対してコンパイルするため、コントロールのソース コードが必要です。

カスタム UWP XAML コントロール (自分で定義するコントロール、または、サード パーティによって提供されるコントロール) をホストする場合は、[前のセクション](#how-to-host-uwp-xaml-controls)で説明されているプロセスに加え、次の追加タスクを実行する必要があります。

1. [**Windows.UI.Xaml.Application**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application)から派生しも[**IXamlMetadataProvider**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider)を実装するカスタム型を定義します。 この型は、アプリケーションの現在のディレクトリのアセンブリ内でカスタムの UWP XAML 型のメタデータを読み込むルート メタデータ プロバイダーとして機能します。

    これを行う方法を示す例では、Windows コミュニティ ツールキットの[XamlApplication.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/XamlApplication.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームは、これらの種類のアプリ内の API をホストしている UWP XAML を使用する方法を示すための共有**WindowsXamlHost**クラスの実装の一部です。

2. UWP XAML コントロールの型名が割り当てられている場合は、ルートのメタデータは、プロバイダーの[**GetXamlType**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider.getxamltype)メソッドを呼び出して、実行時に、コードでこの割り当て可能性があります (Visual Studio の [プロパティ] ウィンドウに割り当てられるこれを有効にすることもできます)。

    これを行う方法を示す例では、Windows コミュニティ ツールキットの[UWPTypeFactory.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/UWPTypeFactory.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームの**WindowsXamlHost**クラスの共有の実装の一部です。

3. カスタムの UWP XAML コントロールのソース コードをホスト アプリケーションのソリューションに統合、カスタム コントロールをビルドして次の[手順](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost#add-a-custom-uwp-control)で、アプリケーションで使用します。

## <a name="how-to-handle-keyboard-focus-navigation"></a>キーボード フォーカス ナビゲーションを処理する方法

ユーザーが (たとえば、**タブ**または方向/方向キーを押す) によって、キーボードを使用して、アプリケーション内の UI 要素を移動、 **DesktopWindowXamlSource**オブジェクトと、フォーカスをプログラムにより移動する必要があります。 ユーザーのキーボード ナビゲーション、 **DesktopWindowXamlSource**UI のナビゲーションの順序で最初の[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトにフォーカスを移動に達すると、次にフォーカスを移動引き続き**Windows.UI.Xaml.UIElement**要素、およびし、UI の親要素に**DesktopWindowXamlSource**から戻る移動フォーカスを通じてユーザーの循環に応じてオブジェクトです。  

API をホストしている UWP XAML では、これらのタスクを達成するために、いくつかの型とメンバーを提供します。

1. キーボード ナビゲーションに入ると、 **DesktopWindowXamlSource**、 [**GotFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.gotfocus)イベントが発生します。 このイベントを処理し、プログラムで[**NavigateFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.navigatefocus)メソッドを使用して最初のホストされた**Windows.UI.Xaml.UIElement**にフォーカスを移動します。

2. ユーザーを**DesktopWindowXamlSource**の最後のフォーカス可能な要素では、 **Tab**キーまたは方向キーを押すと、 [**TakeFocusRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.takefocusrequested)イベントが発生します。 このイベントを処理し、プログラムによって、ホスト アプリケーションの次のフォーカス可能な要素にフォーカスを移動します。 たとえば、 **DesktopWindowXamlSource**が[**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)でホストされている場所の WPF アプリケーションでは、ホスト アプリケーションの次のフォーカス可能な要素にフォーカスを転送するのに[**MoveFocus**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.movefocus)メソッドを使用することができます。

実用的なサンプル アプリケーションのコンテキストでこれを行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.Focus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs)ファイルを参照してください。

## <a name="how-to-handle-layout-changes"></a>レイアウトの変更を処理する方法

親の UI 要素のサイズを変更するときは、UWP コントロールが期待どおりに表示していることを確認するために必要なレイアウト変更を処理する必要があります。 考慮すべきいくつかの重要なシナリオを次に示します。

1. 親の UI 要素は、四角形の領域に合わせて**DesktopWindowXamlSource**をホストしている**Windows.UI.Xaml.UIElement の**ために必要なサイズを取得する必要がある場合は、 **Windows.UI.Xaml.UIElement の[**メジャー**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.measure)メソッドを呼び出す**. 例:
    * WPF アプリケーションで[**MeasureOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.measureoverride)メソッドの**DesktopWindowXamlSource**をホストしている[**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)から実行する可能性があります。
    * Windows フォーム アプリケーションで**DesktopWindowXamlSource**をホストしている[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**推奨**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.getpreferredsize)メソッドから実行する可能性があります。

2. 親の UI 要素の変更、サイズ、[**配置**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.arrange)のメソッドを呼び出してルート**Windows.UI.Xaml.UIElement**するときは、 **DesktopWindowXamlSource**でホストしています。 例:
    * WPF アプリケーションで**DesktopWindowXamlSource**をホストしている[**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)オブジェクトの[**ArrangeOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.arrangeoverride)メソッドから実行する可能性があります。
    * Windows フォーム アプリケーションでこれを行います[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**SizeChanged**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.sizechanged)イベント ハンドラーから**DesktopWindowXamlSource**をホストしています。

実用的なサンプル アプリケーションのコンテキストでこれを行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。

## <a name="how-to-handle-dpi-changes"></a>DPI の変更を処理する方法

レンダリング トランス フォームで、UWP コントロールを構成する、アプリで DPI の変更をリッスンする必要があります (たとえば、ユーザーは、さまざまな画面 DPI のモニターの間で、ウィンドウをドラッグ) 場合に、UWP がコントロールをホストしているウィンドウの DPI の変更を処理する場合は、、ウィンドウの位置を更新し、DPI の変更に応答で、UWP コントロールの変換をレンダリングします。

次の手順では、C++ の Win32 アプリケーションのコンテキストでは、このプロセスを処理する 1 つの方法を示しています。 完全な例では、GitHub で[XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)サンプル[Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)と[Desktop.h](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.h)のコード ファイルを参照してください。

1. [**ScaleTransform**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.scaletransform)オブジェクトをアプリを維持し、UWP コントロールの[**RenderTransform**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.rendertransform)メソッドに割り当てます。 次の例は、C++ Win32 アプリケーションで[**Windows.UI.Xaml.Controls.Grid**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)制御されます。

    ```cppwinrt
    // Private fields maintained by your app, such as in a window class you have defined.
    Windows::UI::Xaml::Media::ScaleTransform m_scale;
    Windows::UI::Xaml::Controls::Grid m_rootGrid;

    // Code that runs during initialization, such as the constructor for a window class you have defined.
    m_rootGrid.RenderTransform(m_scale);
    ```

2. 関数では、 [**3 番目のプロシージャ**](https://msdn.microsoft.com/library/windows/desktop/ms633573.aspx)、 [**WM_DPICHANGED**](https://docs.microsoft.com/windows/desktop/hidpi/wm-dpichanged)メッセージをリッスンします。 このメッセージに応答します。
    * メッセージに渡された四角形に UWP コントロールを含む、ウィンドウのサイズを変更するのにには、 [**SetWindowPos**](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数を使用します。
    * 新しい DPI の値に従って**ScaleTransform**オブジェクトの x 軸と y 軸のスケール ファクターを更新します。
    * UWP コントロールのレイアウトと外観に必要な調整を加えます。 次のコード例は、[**パディング**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid.padding)の DPI の変更への応答でホストされている**Windows.UI.Xaml.Controls.Grid**コントロールを調整します。

    ```cppwinrt
    LRESULT HandleDpiChange(HWND hWnd, WPARAM wParam, LPARAM lParam)
    {
        HWND hWndStatic = GetWindow(hWnd, GW_CHILD);
        if (hWndStatic != nullptr)
        {
            UINT uDpi = HIWORD(wParam);

            // Resize the window
            auto lprcNewScale = reinterpret_cast<RECT*>(lParam);

            SetWindowPos(hWnd, nullptr, lprcNewScale->left, lprcNewScale->top,
                lprcNewScale->right - lprcNewScale->left, lprcNewScale->bottom - lprcNewScale->top,
                SWP_NOZORDER | SWP_NOACTIVATE);

            NewScale(uDpi);
          }
          return 0;
    }

    void NewScale(UINT dpi) {

        auto scaleFactor = (float)dpi / 100;

        if (m_scale != nullptr) {
            m_scale.ScaleX(scaleFactor);
            m_scale.ScaleY(scaleFactor);
        }

        ApplyCorrection(scaleFactor);
    }

    void ApplyCorrection(float scaleFactor) {
        float rightCorrection = (m_rootGrid.Width() * scaleFactor - m_rootGrid.Width()) / scaleFactor;
        float bottomCorrection = (m_rootGrid.Height() * scaleFactor - m_rootGrid.Height()) / scaleFactor;

        m_rootGrid.Padding(Windows::UI::Xaml::ThicknessHelper::FromLengths(0, 0, rightCorrection, bottomCorrection));
    }
    ```

2. モニター DPI に対応するアプリケーションを構成するには、[マニフェストのサイド バイ サイド アセンブリ](https://docs.microsoft.com/windows/desktop/SbsCs/application-manifests)をプロジェクトに追加し、設定```<dpiAwareness>```要素を```PerMonitorV2```します。 この値について詳しくは、 [**DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2**](https://docs.microsoft.com/windows/desktop/hidpi/dpi-awareness-context)の説明を参照してください。

    ```xml
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
    <assembly xmlns="urn:schemas-microsoft-com:asm.v1" manifestVersion="1.0">
        <application xmlns="urn:schemas-microsoft-com:asm.v3">
            <windowsSettings>
                <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
            </windowsSettings>
        </application>
    </assembly>
    ```

    完全な例サイド バイ サイド アセンブリ マニフェストでは、GitHub で[XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)サンプル[XamlIslandsWin32.exe.manifest](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/XamlIslandsWin32.exe.manifest)ファイルを参照してください。

## <a name="limitations"></a>制限事項

API をホストしている XAML では、Windows 10 の他のすべての種類を XAML コントロールをホストするのと同じ制限を共有します。 詳細な一覧については、 [XAML ホスト コントロールの制限事項](xaml-host-controls.md#limitations)を参照してください。

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="error-using-uwp-xaml-hosting-api-in-a-uwp-app"></a>UWP アプリで API をホストしている UWP XAML を使用してエラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージで**COMException** :"DesktopWindowXamlSource アクティブ化できません。 この種類の使用できません、UWP アプリで。" または、"WindowsXamlManager アクティブ化できません。 この種類の使用できません、UWP アプリで。" | このエラーは、API をホストしている UWP XAML を使用しようとしていることを示します (具体的には、しようとする[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)または[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)の型をインスタンス化)、UWP アプリでします。 API をホストしている UWP XAML が UWP 以外のデスクトップ アプリ、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用するのみ想定されています。 |

### <a name="error-attaching-to-a-window-on-a-different-thread"></a>別のスレッドでのウィンドウにアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージで**COMException** :「AttachToWindow メソッドは、指定した HWND が別のスレッドで作成されたために失敗しました」。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すし、別のスレッドで作成されたウィンドウの HWND が渡されたことを示します。 このメソッドは、メソッドを呼び出すことのコードと同じスレッドで作成されたウィンドウの HWND 渡す必要があります。 |

### <a name="error-attaching-to-a-window-on-a-different-top-level-window"></a>さまざまなトップレベル ウィンドウで、ウィンドウにアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージで**COMException** :「AttachToWindow メソッドは、指定した HWND が、同じスレッドで以前 AttachToWindow に渡された HWND よりもさまざまなトップレベル ウィンドウから下降ために失敗しました」。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すし、このメソッドに前の呼び出しで指定したウィンドウよりもさまざまなトップレベル ウィンドウから下降ウィンドウの HWND が渡されたことを示します同じスレッドします。</p></p>アプリケーションは、特定のスレッドで**IDesktopWindowXamlSourceNative.AttachToWindow**を呼び出し、同じスレッドで他のすべての[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを同じトップレベル ウィンドウの子孫である windows 接続のみ**IDesktopWindowXamlSourceNative.AttachToWindow**の最初の呼び出しで渡されたします。 **DesktopWindowXamlSource**のすべてのオブジェクトは特定のスレッドを閉じると、[次へ] **DesktopWindowXamlSource**が自由にもう一度任意のウィンドウにアタッチできます。</p></p>この問題を解決するには、このスレッドで他のトップレベル ウィンドウにバインドされているか、この**DesktopWindowXamlSource**の新しいスレッドを作成するすべての**DesktopWindowXamlSource**オブジェクトを閉じるか。 |

## <a name="related-topics"></a>関連トピック

* [デスクトップ アプリケーションの UWP コントロール](xaml-host-controls.md)
