---
description: この記事では、お客様のデスクトップ アプリケーションで UWP XAML の UI をホストする方法について説明します。
title: デスクトップ アプリケーションで API をホストしている UWP XAML を使用します。
ms.date: 04/19/2019
ms.topic: article
keywords: windows 10、uwp、windows フォーム、wpf、win32、xaml 諸島
ms.localizationpriority: medium
ms.custom: 19H1
ms.openlocfilehash: 9cb18abec43a4439b6d4750df797be5a1620a3aa
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63812746"
---
# <a name="using-the-uwp-xaml-hosting-api-in-a-desktop-application"></a>デスクトップ アプリケーションで API をホストしている UWP XAML を使用します。

以降では、Windows 10、バージョンが 1903、デスクトップ アプリケーションを UWP 以外 (WPF、Windows フォームなどとC++Win32 アプリケーション) を使用できます、 *API をホストしている UWP XAML*に関連付けられている任意の UI 要素に UWP コントロールをホストする、ウィンドウ ハンドル (HWND)。 この API は、のみ UWP コントロールを使用して利用できる最新の Windows 10 の UI 機能を使用するデスクトップ アプリケーションを UWP 以外を使用できます。 デスクトップ アプリケーションを UWP 以外が使用する UWP コントロールをホストするには、この API を使用するなど、 [Fluent Design System](../design/fluent-design-system/index.md)サポートと[Windows インク](../design/input/pen-and-stylus-interactions.md)します。

API をホストしている UWP XAML では、開発者がデスクトップ アプリケーションを UWP 以外に Fluent UI を表示できるようにするコントロールの広範なセットの基盤を提供します。 この機能は呼*XAML 諸島*します。 この機能の概要については、次を参照してください。[デスクトップ アプリケーションでの UWP コントロール](xaml-host-controls.md)します。

> [!NOTE]
> XAML 諸島に関するフィードバックをした場合で新しい問題を作成、 [Microsoft.Toolkit.Win32 リポジトリ](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/issues)がコメントを残すとします。 プライベート フィードバックを送信する場合に送信できますXamlIslandsFeedback@microsoft.comします。 Insights とシナリオは弊社にとって非常に重要です。

## <a name="should-you-use-the-uwp-xaml-hosting-api"></a>API をホストしている UWP XAML を使用する必要がありますか。

API をホストしている UWP XAML は、デスクトップ アプリケーションでの UWP コントロールをホストするための低レベルのインフラストラクチャを提供します。 いくつかの種類のデスクトップ アプリケーションでは、代替方法でより便利な Api を使用して、この目標を達成するオプションがあります。  

* C++ Win32 デスクトップ アプリケーションがあり、アプリケーションで UWP コントロールをホストする場合は、API をホストしている UWP XAML を使用する必要があります。 これらの種類のアプリケーションのための代替手段はありません。

* WPF と Windows フォーム アプリケーションでは、強くお勧めを使用すること、[コントロールをラップ](xaml-host-controls.md#wrapped-controls)と[ホスト コントロール](xaml-host-controls.md#host-controls)直接 API をホストしている UWP XAML を使用する代わりに Windows Community Toolkit にします。 これらのコントロールでは、内部的に API をホストしている UWP XAML を使用し、すべてのキーボード ナビゲーションとレイアウトの変更を含め、直接 API をホストしている UWP XAML を使用している場合、自分で処理する必要がなくなり、動作を実装します。 ただし、選択した場合、この種のアプリケーションで直接 API をホストする UWP XAML を使用することができます。

この記事では、Windows コミュニティのツールキットで提供されるコントロールではなく、アプリケーションで直接 API をホストしている UWP XAML を使用する方法について説明します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP XAML では、これらの前提条件があります。

* Windows 10、バージョンが 1903 (またはそれ以降) と、対応する Windows SDK のビルドします。
* Windows ランタイム Api を使用し、次の XAML 諸島を有効にするプロジェクトを構成する[手順](xaml-host-controls.md#requirements)します。

## <a name="architecture-of-xaml-islands"></a>XAML 諸島のアーキテクチャ

API をホストしている UWP XAML には、これらのメインの Windows ランタイム型および COM インターフェイスが含まれています。

* [**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)します。 このクラスは、UWP XAML フレームワークを表します。 このクラスは、単一の静的な[ **InitializeForCurrentThread** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager.initializeforcurrentthread)デスクトップ アプリケーションでは、現在のスレッドで UWP XAML フレームワークを初期化するメソッド。

* [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)します。 このクラスは、お客様のデスクトップ アプリケーションでホストしている UWP XAML コンテンツのインスタンスを表します。 このクラスの最も重要なメンバーは、 [**コンテンツ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.content)プロパティ。 このプロパティに割り当てる、 [ **Windows.UI.Xaml.UIElement** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)をホストします。 このクラスには、ルーティングのキーボード フォーカスのナビゲーションに、および XAML 諸島からの他のメンバーもあります。

* **IDesktopWindowXamlSourceNative**と**IDesktopWindowXamlSourceNative2** COM インターフェイスです。 **IDesktopWindowXamlSourceNative**提供、 **AttachToWindow**メソッドは、親の UI 要素に、アプリケーションで XAML の島をアタッチするために使用します。 **IDesktopWindowXamlSourceNative2**提供、 **PreTranslateMessage**メソッドで、特定の Windows メッセージを正しく処理するため、UWP XAML フレームワークを使用します。
    > [!NOTE]
    > これらのインターフェイスが宣言されている、 **windows.ui.xaml.hosting.desktopwindowxamlsource.h** Windows sdk ヘッダー ファイル。 既定では、このファイルは、%programfiles (x86) %\Windows Kits\10\Include で\\< ビルド番号\>\um します。 C++ Win32 プロジェクトでは、このヘッダー ファイルを直接参照することができます。 WPF や Windows フォーム プロジェクトでは、アプリケーション コードを使用してインターフェイスを宣言する必要があります、 [ **ComImport** ](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.comimportattribute)属性。 インターフェイスの宣言内の宣言を正確に一致するかどうかを確認**windows.ui.xaml.hosting.desktopwindowxamlsource.h**します。

次の図は、デスクトップ アプリケーションでホストされている XAML アイランド内のオブジェクトの階層を示します。

![DesktopWindowXamlSource アーキテクチャ](images/xaml-hosting-api-rev2.png)

* 基本レベルで XAML の島をホストするアプリケーションで UI 要素は、します。 この UI 要素には、ウィンドウ ハンドル (HWND) が必要です。 XAML の島をホストできる UI 要素の例として、 [ **System.Windows.Interop.HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost) WPF アプリケーション、 [ **System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control) Windows フォーム アプリケーションの場合、[ウィンドウ](https://docs.microsoft.com/windows/desktop/winmsg/about-windows)のC++Win32 アプリケーション。

* レベルは、次を**DesktopWindowXamlSource**オブジェクト。 このオブジェクトは、XAML の島をホストするためのインフラストラクチャを提供します。 コードは、このオブジェクトを作成し、親の UI 要素にアタッチします。

* 作成するときに、 **DesktopWindowXamlSource**、このオブジェクトは、UWP コントロールをホストするネイティブの子ウィンドウを自動的に作成されます。 このネイティブ子ウィンドウはほとんどの場合、コードから抽象化されていますが、そのハンドル (HWND) に必要な場合にアクセスできます。

* 最後に、最上位レベルでは、デスクトップ アプリケーションをホストする UWP コントロールです。 これは、任意の UWP オブジェクトから派生した[ **Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)など、UWP、Windows SDK によって提供されるだけではなくカスタム ユーザー コントロール。

## <a name="related-samples"></a>関連するサンプル

コードで API をホストしている UWP XAML を使用する方法は、アプリケーション、およびその他の要因のデザイン、アプリケーションの種類によって異なります。 この記事では、完全なアプリケーションのコンテキストでこの API を使用する方法を説明するには、次のサンプルからコードを指します。

### <a name="c-win32"></a>C++ Win32

[C++Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。 このサンプルでは、パッケージ化されていないで UWP ユーザー コントロールのホストの完全な実装C++Win32 アプリケーション (つまり、MSIX パッケージに組み込まれていないアプリケーション)。

### <a name="wpf-and-windows-forms"></a>WPF と Windows フォーム

[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost) Windows の Community Toolkit のコントロールは、UWP、WPF、Windows フォーム アプリケーションでのホスティング API を使用するための参照をサンプルとして機能します。 ソース コードは、次の場所には。

  * コントロールの WPF バージョン[ここに移動して](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Wpf.UI.XamlHost)します。 派生した WPF バージョン[ **System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)します。

  * コントロールの Windows フォーム バージョン[ここに移動して](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Forms.UI.XamlHost)します。 派生した Windows フォーム バージョン[ **System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)します。

## <a name="host-uwp-xaml-controls"></a>ホストの UWP XAML コントロールします。

API をホストしている UWP XAML を使用して、アプリケーションでの UWP コントロールをホストする主な手順を次に示します。

1. いずれかのアプリケーションを作成する前に、現在のスレッドの UWP XAML フレームワークを初期化、 [ **Windows.UI.Xaml.UIElement** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)でホストするオブジェクト、 [ **DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)します。

    * アプリケーションを作成する場合、 **DesktopWindowXamlSource**オブジェクトのいずれかの作成前に、 **Windows.UI.Xaml.UIElement**オブジェクトの場合、このフレームワークは、インスタンス化するときの初期化は、**DesktopWindowXamlSource**オブジェクト。 このシナリオでは、フレームワークを初期化するために独自のコードを追加する必要はありません。

    * ただし、アプリケーションを作成する場合、 **Windows.UI.Xaml.UIElement**オブジェクトを作成する前に、 **DesktopWindowXamlSource**オブジェクト、それらをホストするアプリケーションは、静的なを呼び出す必要があります[**WindowsXamlManager.InitializeForCurrentThread** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager.initializeforcurrentthread)メソッドの前に、UWP XAML フレームワークを明示的に初期化するために、 **Windows.UI.Xaml.UIElement**オブジェクトは、インスタンス化します。 親の UI 要素をホストするときに、アプリケーションはこのメソッドを呼び出す通常必要があります、 **DesktopWindowXamlSource**インスタンス化されます。

    ```cppwinrt
    Windows::UI::Xaml::Hosting::WindowsXamlManager windowsXamlManager =
        Windows::UI::Xaml::Hosting::WindowsXamlManager::InitializeForCurrentThread();
    ```

    ```csharp
    global::Windows.UI.Xaml.Hosting.WindowsXamlManager windowsXamlManager =
        global::Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
    ```

    > [!NOTE]
    > このメソッドが戻る、 [ **WindowsXamlManager** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager) UWP XAML フレームワークへの参照を格納しているオブジェクト。 数だけ作成できます**WindowsXamlManager**オブジェクトを特定のスレッド上でどのようにします。 ただし、各オブジェクトは、UWP XAML フレームワークへの参照を保持しているために、XAML リソースが最終的に解放されることを確認するオブジェクトを破棄する必要があります。

2. 作成、 [ **DesktopWindowXamlSource** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトし、親ウィンドウ ハンドルに関連付けられているアプリケーションの UI 要素にアタッチします。

    これを行うには、これらの手順に従う必要があります。

    1. 作成、 **DesktopWindowXamlSource**オブジェクトおよびにキャスト、 **IDesktopWindowXamlSourceNative**または**IDesktopWindowXamlSourceNative2** COM インターフェイスです。

    2. 呼び出す、 **AttachToWindow**のメソッド、 **IDesktopWindowXamlSourceNative**または**IDesktopWindowXamlSourceNative2**インターフェイスし、のウィンドウ ハンドルを渡す、アプリケーションの UI 要素を親。

    3. 含まれる内部の子ウィンドウの初期サイズを設定、 **DesktopWindowXamlSource**します。 既定では、この内部の子ウィンドウは、幅と高さが 0 に設定されます。 追加するすべての UWP コントロール、ウィンドウのサイズを設定していない場合、 **DesktopWindowXamlSource**は表示されません。 内部の子ウィンドウにアクセスする、 **DesktopWindowXamlSource**を使用して、 **WindowHandle**のプロパティ、 **IDesktopWindowXamlSourceNative**または**IDesktopWindowXamlSourceNative2**インターフェイス。 次の例を使用して、 [SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)ウィンドウのサイズを設定します。

    このプロセスを示すいくつかのコード例を示します。

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
    // that will act as the parent UI element for your XAML Island. It also assumes
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

3. 設定、 **Windows.UI.Xaml.UIElement**をホストする、 [**コンテンツ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.content)のプロパティ、 **DesktopWindowXamlSource**オブジェクト。 次の例のセットを[ **Windows.UI.Xaml.Controls.Grid** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)という```myGrid```を**コンテンツ**プロパティ。

   ```cppwinrt
   desktopWindowXamlSource.Content(myGrid);
   ```

   ```csharp
   desktopWindowXamlSource.Content = myGrid;
   ```

実際のサンプル アプリケーションのコンテキストでこれらのタスクを示す完全な例では、次のコード ファイルを参照してください。

  * **C++ Win32:** 参照してください、 [XamlBridge.cpp](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island/SampleCppApp/XamlBridge.cpp)ファイル、 [ C++ Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。

  * **WPF:** 参照してください、 [WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHost.cs) Windows コミュニティ ツールキット内のファイル。  

  * **Windows フォーム:** 参照してください、 [WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHost.cs) Windows コミュニティ ツールキット内のファイル。

## <a name="handle-keyboard-input-and-focus-navigation"></a>キーボードの入力とフォーカスのナビゲーションを処理します。

アプリで XAML 諸島をホストするときに、キーボードの入力とフォーカスのナビゲーションを正しく処理するために必要ないくつかの点があります。

### <a name="keyboard-input"></a>キーボード入力

各 XAML 島のキーボード入力を正しく処理するには、アプリケーションは特定のメッセージを正しく処理できるように、UWP XAML フレームワークにすべての Windows メッセージを渡す必要があります。 メッセージ ループがアクセスできるアプリケーション内の場所、キャスト、 **DesktopWindowXamlSource**オブジェクトの各 XAML 島、 **IDesktopWindowXamlSourceNative2** COM インターフェイスです。 次に呼び出す、 **PreTranslateMessage**メソッドのこのインターフェイスと現在のメッセージを渡します。

  * A C++ Win32 アプリケーションで呼び出すことができます**PreTranslateMessage**メイン メッセージ ループで直接します。 例については、次を参照してください。、 [SampleApp.cpp](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island/SampleCppApp/SampleApp.cpp#L61)でコード ファイル、 [ C++ Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。

  * WPF アプリケーションを呼び出すことができます**PreTranslateMessage**のイベント ハンドラーから、 [ **ComponentDispatcher.ThreadFilterMessage** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.componentdispatcher.threadfiltermessage?view=netframework-4.7.2)イベント。 例については、次を参照してください。、 [WindowsXamlHostBase.Focus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs#L177) Windows コミュニティのツールキットでのファイル。

  * Windows フォーム アプリケーションを呼び出すことができます**PreTranslateMessage**のオーバーライドから、 [ **Control.PreprocessMessage** ](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.preprocessmessage?view=netframework-4.7.2)メソッド。 例については、次を参照してください。、 [WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs#L100) Windows コミュニティのツールキットでのファイル。

### <a name="keyboard-focus-navigation"></a>キーボード フォーカスのナビゲーション

キーボードを使用して、アプリケーションで UI 要素を通じて、ユーザーが移動したときに (たとえば、キーを押して**タブ**または方向/矢印キー)、プログラムでの入出力にフォーカスを移動する必要があります、 **DesktopWindowXamlSource**オブジェクト。 ユーザーのキーボード ナビゲーションが達したとき、 **DesktopWindowXamlSource**、最初にフォーカスを移動[ **Windows.UI.Xaml.UIElement** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)ナビゲーション順でのオブジェクト次にフォーカスを移動、ui では、引き続き**Windows.UI.Xaml.UIElement**オブジェクトとして、ユーザーが要素をサイクルしバックアップ フォーカスの移動、 **DesktopWindowXamlSource**と親の UI 要素にします。  

API をホストしている UWP XAML では、これらのタスクを達成するために、いくつかの型とメンバーを提供します。

* キーボード ナビゲーションが入力した場合、 **DesktopWindowXamlSource**、 [ **GotFocus** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.gotfocus)イベントが発生します。 このイベントを処理し、最初にフォーカスを移動プログラムでホストされている**Windows.UI.Xaml.UIElement**を使用して、 [ **NavigateFocus** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.navigatefocus)メソッド。

* フォーカスを設定できる最後の要素で、ユーザーの場合、 **DesktopWindowXamlSource**を押すと、**タブ**キーまたは方向キー、 [ **TakeFocusRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.takefocusrequested)イベントが発生します。 このイベントを処理し、プログラムによって、ホスト アプリケーションにフォーカスを設定できる次の要素にフォーカスを移動します。 たとえば、WPF アプリケーションで場所、 **DesktopWindowXamlSource**でホストされている、 [ **System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)、使用することができます、 [ **MoveFocus** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.movefocus)ホスト アプリケーションにフォーカスを設定できる次の要素にフォーカスを転送する方法。

これは実際のサンプル アプリケーションのコンテキストで実行する方法を示す例については、次のコード ファイルを参照してください。

  * **WPF:** 参照してください、 [WindowsXamlHostBase.Focus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs) Windows コミュニティのツールキットでのファイル。  

  * **Windows フォーム:** 参照してください、 [WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs) Windows コミュニティのツールキットでのファイル。

## <a name="handle-layout-changes"></a>レイアウトの変更を処理します。

ユーザーが親の UI 要素のサイズを変更した UWP コントロールが期待どおりに表示していることを確認するために必要なレイアウト変更を処理する必要があります。 考慮すべき重要なシナリオを以下に示します。

* C++ Win32 アプリケーション、アプリケーションを使用してホストされている XAML 島を再配置できますが、WM_SIZE メッセージを処理する際に、 [SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数。 例については、次を参照してください。、 [SampleApp.cpp](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island/SampleCppApp/SampleApp.cpp#L191)でコード ファイル、 [ C++ Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。

* 親の UI 要素が収まる四角形領域のサイズを取得する必要がある場合、 **Windows.UI.Xaml.UIElement**でホストしている、 **DesktopWindowXamlSource**を呼び出し、 [**メジャー** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.measure)のメソッド、 **Windows.UI.Xaml.UIElement**します。 次に、例を示します。

    * WPF アプリケーションでこれから行うことがあります、 [ **MeasureOverride** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.measureoverride)のメソッド、 [ **HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)をホストする、 **DesktopWindowXamlSource**します。 例については、次を参照してください。、 [WindowsXamlHostBase.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。

    * Windows フォーム アプリケーションでこれから行うことがあります、 [ **GetPreferredSize** ](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.getpreferredsize)のメソッド、 [**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control) をホストする**DesktopWindowXamlSource**します。 例については、次を参照してください。、 [WindowsXamlHostBase.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。

* 親の UI 要素のサイズが変更されたときに呼び出す、 [**配置**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.arrange)ルートのメソッド**Windows.UI.Xaml.UIElement**でホストしている、 **DesktopWindowXamlSource**します。 次に、例を示します。

    * WPF アプリケーションでこれから行うことがあります、 [ **ArrangeOverride** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.arrangeoverride)のメソッド、 [ **HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost) をホストしているオブジェクト**DesktopWindowXamlSource**します。 例については、次を参照してください。、 [WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。

    * Windows フォーム アプリケーションでこれを行いますのハンドラーから、 [ **SizeChanged** ](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.sizechanged)のイベント、 [**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)をホストする、**DesktopWindowXamlSource**します。 例については、次を参照してください。、 [WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。

## <a name="handle-dpi-changes"></a>DPI 変更を処理します。

UWP XAML フレームワークは、(たとえば、さまざまな画面の DPI のモニター間でウィンドウを出た) ときに自動的にホストされている UWP コントロールの DPI 変更を処理します。 最良の結果をお勧めする、Windows フォーム、WPF、またはC++モニターごとの DPI に対応する Win32 アプリケーションを構成します。

モニターごとの DPI に対応するアプリケーションを構成するには追加、[サイド バイ サイド アセンブリ マニフェスト](https://docs.microsoft.com/windows/desktop/SbsCs/application-manifests)にプロジェクトを設定し```<dpiAwareness>```要素を```PerMonitorV2```します。 この値の詳細については、の説明を参照してください。 [ **DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2**](https://docs.microsoft.com/windows/desktop/hidpi/dpi-awareness-context)します。

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

## <a name="host-custom-uwp-xaml-controls"></a>UWP XAML のカスタム ホストを制御します。

> [!IMPORTANT]
> カスタムの UWP XAML コントロールをホストするには、それに対して、アプリケーションでコンパイルするために、コントロールのソース コードが必要です。

説明されているプロセスに加え、次の追加タスクを実行する必要があります (ユーザー定義コントロールまたはサード パーティによって提供されるコントロール) に、カスタム UWP XAML コントロールをホストする場合、[前のセクション](#host-uwp-xaml-controls)します。

1. 派生したカスタム型を定義する[ **Windows.UI.Xaml.Application** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application)も実装[ **IXamlMetadataProvider**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider)します。 この型は、アプリケーションの現在のディレクトリのアセンブリ内でカスタムの UWP XAML 型のメタデータの読み込みをルートのメタデータ プロバイダーとして機能します。

2. 呼び出す、 [ **GetXamlType** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider.getxamltype) UWP XAML コントロールの型名が割り当てられている場合は、ルートのメタデータのプロバイダーのメソッド (この、実行時にコードに割り当てることがまたは、これを有効にすることもできます。割り当てられている Visual Studio のプロパティ] ウィンドウで)。

    例については、次のコード ファイルを参照してください。
      * **C++ Win32:** 参照してください、 [XamlApplication.cpp](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island/Microsoft.UI.Xaml.Markup/XamlApplication.cpp)でコード ファイル、 [ C++ Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。

      * **WPF と Windows フォーム**:参照してください、 [XamlApplication.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/XamlApplication.cs)と[UWPTypeFactory.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/UWPTypeFactory.cs)コードでは、Windows の Community Toolkit ファイル。 これらのファイルの共有の実装の一部である、 **WindowsXamlHost** WPF と Windows フォームは、これらの種類のアプリで API をホストしている UWP XAML を使用する方法を示すためのクラス。

3. ホスト アプリケーションのソリューションにカスタムの UWP XAML コントロールのソース コードを統合、カスタムのコントロールをビルドおよびアプリケーションで使用します。 WPF や Windows フォーム アプリケーションの手順については、次を参照してください。[手順](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost#add-a-custom-uwp-control)します。 例については、 C++ Win32 アプリケーションを参照してください、 [Microsoft.UI.Xaml.Markup](https://github.com/marb2000/XamlIslands/tree/master/19H1_Insider_Samples/CppWin32App_With_Island/Microsoft.UI.Xaml.Markup)と[MyApp](https://github.com/marb2000/XamlIslands/tree/master/19H1_Insider_Samples/CppWin32App_With_Island/MyApp)プロジェクトで、 [ C++ Win32 サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)します。

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="error-using-uwp-xaml-hosting-api-in-a-uwp-app"></a>UWP アプリで API をホストしている UWP XAML を使用してエラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。"DesktopWindowXamlSource をアクティブ化できません。 この型では使用できません、UWP アプリです。" または、"WindowsXamlManager をアクティブ化できません。 この型では使用できません、UWP アプリです。" | このエラーは、API をホストしている UWP XAML を使用しようとしていることを示します (具体的には、インスタンスを作成しようとしてには、 [ **DesktopWindowXamlSource** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)または[ **WindowsXamlManager** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)型) で UWP アプリです。 API をホストしている UWP XAML の目的はのみ、非 UWP のデスクトップ アプリ、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用します。 |

### <a name="error-attaching-to-a-window-on-a-different-thread"></a>別のスレッドで、ウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。「AttachToWindow メソッドは、別のスレッドで、指定した HWND が作成されたために失敗しました」。 | このエラーは、アプリケーションと呼ばれることを示します、 **IDesktopWindowXamlSourceNative::AttachToWindow**メソッド別のスレッドが作成されているウィンドウの HWND が渡されます。 このメソッドにコードのメソッドを呼び出すことと同じスレッドが作成されているウィンドウの HWND を渡す必要があります。 |

### <a name="error-attaching-to-a-window-on-a-different-top-level-window"></a>別の最上位ウィンドウ上のウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。「AttachToWindow メソッドは、同じスレッドで、AttachToWindow に渡された以前 HWND よりも、別の最上位ウィンドウから、指定した HWND が降下ために失敗しました」。 | このエラーは、アプリケーションと呼ばれることを示します、 **IDesktopWindowXamlSourceNative::AttachToWindow**メソッドで指定した期間よりも、別の最上位ウィンドウから下降ウィンドウの HWND を渡し、同じスレッドでは、このメソッドの呼び出し前です。</p></p>アプリケーションの呼び出し後**IDesktopWindowXamlSourceNative::AttachToWindow**特定のスレッドで他のすべての[ **DesktopWindowXamlSource** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)同じオブジェクトスレッドは、最初の呼び出しで渡された同じトップレベル ウィンドウの子孫である windows にのみアタッチできます**IDesktopWindowXamlSourceNative::AttachToWindow**します。 ときにすべて、 **DesktopWindowXamlSource**オブジェクトは特定のスレッドで、[次へ] を閉じる**DesktopWindowXamlSource**は無料で任意のウィンドウを再度アタッチします。</p></p>この問題を解決するには、いずれかを閉じますすべて**DesktopWindowXamlSource**このスレッドで他の最上位ウィンドウにバインドされているか、この新しいスレッドを作成するオブジェクト**DesktopWindowXamlSource**します。 |

## <a name="related-topics"></a>関連トピック

* [デスクトップ アプリケーションでの UWP コントロール](xaml-host-controls.md)
* [C++Win32 XAML 諸島サンプル](https://github.com/marb2000/XamlIslands/blob/master/19H1_Insider_Samples/CppWin32App_With_Island)
