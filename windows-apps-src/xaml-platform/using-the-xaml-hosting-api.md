---
author: mcleanbyron
description: この記事では、デスクトップ アプリケーションで UWP の XAML UI をホストする方法について説明します。
title: デスクトップ アプリケーションで API をホストしている UWP XAML を使う
ms.author: mcleans
ms.date: 09/21/2018
ms.topic: article
keywords: windows 10、uwp、windows フォーム、wpf、win32
ms.localizationpriority: medium
ms.openlocfilehash: 2ba64e32a25feaee9245bbfe2b598c756b29df98
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5861699"
---
# <a name="using-the-uwp-xaml-hosting-api-in-a-desktop-application"></a>デスクトップ アプリケーションで API をホストしている UWP XAML を使う

> [!NOTE]
> API をホストしている UWP XAML は現在、開発者プレビューとして利用できます。 プロトタイプのコードでは、この API を今すぐ試すことをお勧めしますがない使用することが運用コードでこの時点でお勧めしますしないでください。 この API は引き続き成熟して、今後の Windows リリースに安定します。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

Windows 10 Insider Preview SDK ビルド 17709、UWP 以外のデスクトップ アプリケーション (WPF、Windows フォーム、および C++ の Win32 アプリケーションを含む) は、ウィンドウのハンドル (に関連付けられている任意の UI 要素で UWP コントロールをホストする*API をホストしている UWP XAML*を使用することができます。HWND)。 この API では、最新の Windows 10 の UI 機能のみで利用可能な UWP コントロールを使用するデスクトップ アプリケーションを UWP 以外でできます。 たとえば、UWP 以外のデスクトップ アプリケーションでは、 [Fluent Design System](../design/fluent-design-system/index.md)を使用して、 [Windows Ink](../design/input/pen-and-stylus-interactions.md)をサポートする UWP コントロールをホストするには、この API を使用できます。

API をホストしている UWP XAML では、開発者が UWP 以外のデスクトップ アプリケーション Fluent UI を移植するために提供しますがコントロールのより広範な一連の基盤を提供します。 このシナリオは、 *XAML 諸島*と呼ばれます。 この開発者のシナリオについて詳しくは、[デスクトップ アプリケーションで UWP コントロール](xaml-host-controls.md)を参照してください。

## <a name="is-the-uwp-xaml-hosting-api-right-for-your-desktop-application"></a>UWP XAML をホストしている API、デスクトップ アプリケーションの右かどうか。

API をホストしている UWP XAML では、デスクトップ アプリケーションで UWP コントロールのホスティングの低レベルのインフラストラクチャを提供します。 一部の種類のデスクトップ アプリケーションでは、代替、便利な Api を使用してこの目標を達成するオプションがあります。  

* C++ Win32 デスクトップ アプリケーションがあり、アプリケーションで UWP コントロールをホストする場合は、API をホストしている UWP XAML を使う必要があります。 この種類のアプリケーションの候補はありません。

* WPF および Windows フォーム アプリケーションでは、お勧めします UWP XAML ではなく、Windows コミュニティ ツールキットで[ラップされたコントロール](xaml-host-controls.md#wrapped-controls)と[ホスト コントロール](xaml-host-controls.md#host-controls)が使用して API をホストしています。 これらのコントロールでは、内部的に API をホストしている UWP XAML を使用し、シンプルな開発エクスペリエンスを提供します。 ただし、選択した場合、この種類のアプリケーションで直接 API をホストしている UWP XAML を使用することができます。

## <a name="related-samples"></a>関連するサンプル

コードで API をホストしている UWP XAML を使用する方法は、アプリケーション、およびその他の要因のデザイン、アプリケーションの種類によって異なります。 この記事では、完全なアプリケーションのコンテキストでこの API を使用する方法を示すために、次のサンプルからのコードを指します。

### <a name="c-win32"></a>C++ Win32

GitHub で C++ Win32 アプリケーションで API をホストしている UWP XAML を使用する方法を示すサンプルがいくつかあります。

  * [XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)します。 このサンプルでは、C++ の Win32 アプリケーションを UWP [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas), [InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)と[MediaPlayerElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement)コントロールを追加する方法を示します。
  * [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)します。 このサンプルでは、C++ の Win32 アプリケーションをいくつかの基本的な UWP コントロールを追加し、DPI の変更を処理する方法を示します。

### <a name="wpf-and-windows-forms"></a>WPF および Windows フォーム

Windows コミュニティ ツールキットで[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)コントロールは、WPF および Windows フォーム アプリケーションで API をホストしている UWP を使用するためのリファレンス サンプルとして機能します。 ソース コードは、次の場所から利用できます。

  * [ここ](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost)に、コントロールの WPF バージョンです。 WPF バージョンは、 [**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)から派生します。
  * [ここ](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost)に、コントロールの Windows フォーム バージョンです。 Windows フォーム バージョンは、 [**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)から派生します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP XAML では、これらの前提条件があります。

* Windows 10 Insider Preview ビルド 17709 (またはそれ以降のビルド) と Windows SDK の対応する Insider Preview ビルドします。 これは、進化する機能であるため、最適なエクスペリエンスをお勧めします利用可能な最新のビルドを使用します。

* デスクトップ アプリケーションの API をホストしている UWP XAML を使用するための UWP Api を呼び出すことが、プロジェクトを構成する必要があります。

    * **C++ Win32:** 使用するプロジェクトを構成することをお勧めします[、C++/WinRT](../cpp-and-winrt-apis/index.md)します。 ダウンロードし、インストール、 [、C++/WinRT Visual Studio Extension (VSIX)](https://aka.ms/cppwinrt/vsix)から Visual Studio Marketplace し、追加、 ```<CppWinRTEnabled>true</CppWinRTEnabled>``` .vcxproj ファイルとして記述[は、ここ](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)にプロパティ。

    * **Windows フォーム、WPF:**[次の手順](../porting/desktop-to-uwp-enhance.md)に従います。

## <a name="architecture-of-xaml-islands"></a>XAML 諸島のアーキテクチャ

API をホストしている UWP XAML には、 [**Windows.UI.Xaml.Hosting**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間で、 [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)、 [**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)、およびその他の関連する型が含まれています。 デスクトップ アプリケーションは、UWP コントロールをレンダリングし、キーボード フォーカス ナビゲーションと要素をルートこの API を使用することができます。 デスクトップ アプリケーションは、サイズもや、必要に応じて、UWP コントロールを配置します。

デスクトップ アプリケーションで API をホストしている XAML を使って XAML 島を作成するときのオブジェクトの次の階層必要があります。

* 基本レベルでは、アプリケーションの UI 要素を XAML 島をホストします。 この UI 要素には、ウィンドウのハンドル (HWND) 必要があります。 XAML 島をホストできる UI 要素の例には、WPF アプリケーション、Windows フォーム アプリケーションで[**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)および C++ Win32 アプリケーションの[ウィンドウ](https://docs.microsoft.com/windows/desktop/winmsg/about-windows)の[**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)が含まれます。

* 次のレベルは、 **DesktopWindowXamlSource**オブジェクトです。 このオブジェクトは、XAML 島をホストするため、インフラストラクチャを提供します。 コードは、このオブジェクトを作成して、親の UI 要素にアタッチすることを行います。

* **DesktopWindowXamlSource**を作成する場合、このオブジェクトは自動的に、UWP コントロールをホストするネイティブ子ウィンドウを作成します。 このネイティブ子ウィンドウが、コードから抽象化ほとんどが、そのハンドル (HWND) 必要な場合にアクセスすることができます。

* 最後に、最上位レベルのデスクトップ アプリケーションをホストする UWP コントロールです。 これは、 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)、Windows SDK とカスタム ユーザー コントロールによって提供されるすべての UWP コントロールを含むから派生した任意の UWP オブジェクトです。

次の図は、XAML 島内のオブジェクトの階層を示しています。

![DesktopWindowXamlSource アーキテクチャ](images/xaml-hosting-api-rev2.png)

## <a name="how-to-host-uwp-xaml-controls"></a>UWP XAML コントロールをホストする方法

API をホストしている UWP XAML を使用して、アプリケーションで UWP コントロールをホストするための主な手順を次に示します。

1. アプリケーションが[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)でそれをホストする[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトのいずれかを作成する前に、現在のスレッドの UWP XAML フレームワークを初期化します。

    * **DesktopWindowXamlSource**オブジェクトをインスタンス化するとき、このフレームワークを初期化されます**Windows.UI.Xaml.UIElement**オブジェクトのいずれかの作成前に、アプリケーションは、 **DesktopWindowXamlSource**オブジェクトを作成する場合. このシナリオでは、フレームワークを初期化する独自のコードを追加する必要はありません。

    * ただし、それらをホストする**DesktopWindowXamlSource**オブジェクトの作成前に、アプリケーションは**Windows.UI.Xaml.UIElement**オブジェクトを作成する場合、アプリケーション呼び出す必要があります、静的な[**WindowsXamlManager.InitializeForCurrentThread**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager.initializeforcurrentthread) **Windows.UI.Xaml.UIElement**オブジェクトがインスタンス化する前に、UWP の XAML フレームワークを明示的に初期化します。 **DesktopWindowXamlSource**をホストしている親 UI 要素をインスタンス化と、アプリケーションは以下のメソッドを呼び出す通常必要があります。

    ```cppwinrt
    Windows::UI::Xaml::Hosting::WindowsXamlManager windowsXamlManager =
        Windows::UI::Xaml::Hosting::WindowsXamlManager::InitializeForCurrentThread();
    ```

    ```csharp
    global::Windows.UI.Xaml.Hosting.WindowsXamlManager windowsXamlManager =
        global::Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
    ```

    > [!NOTE]
    > このメソッドは、UWP の XAML フレームワークへの参照が含まれている[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)オブジェクトを返します。 特定のスレッドで必要な数の**WindowsXamlManager**オブジェクトを作成することができます。 ただし、各オブジェクトは、UWP XAML フレームワークへの参照を保持しているために、最終的に XAML リソースが解放されることを確認するオブジェクトを破棄する必要があります。

2. [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを作成し、それを親ウィンドウ ハンドルに関連付けられているアプリケーションで UI 要素にアタッチします。

    これを行うには、これらの手順に従う必要があります。

    1. **DesktopWindowXamlSource**オブジェクトを作成し、 **IDesktopWindowXamlSourceNative** COM インターフェイスにキャストします。 このインターフェイスがで宣言されている、 ```windows.ui.xaml.hosting.desktopwindowxamlsource.h``` Windows sdk ヘッダー ファイルです。 C++ Win32 プロジェクトでは、このヘッダー ファイルを直接参照できます。 WPF または Windows フォーム プロジェクトでは、 [**ComImport**](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.comimportattribute)属性を使って、アプリケーション コードでは、このインターフェイスを宣言する必要があります。 インターフェイスの宣言は、インターフェイスの宣言を正確に一致するかどうかを確認```windows.ui.xaml.hosting.desktopwindowxamlsource.h```します。

    2. **AttachToWindow** **IDesktopWindowXamlSourceNative**インターフェイスのメソッドを呼び出すし、アプリケーションの親の UI 要素のウィンドウのハンドルを渡します。

    3. 初期**DesktopWindowXamlSource**に含まれている内部子ウィンドウのサイズを設定します。 既定では、この内部子ウィンドウは幅と高さを 0 に設定されます。 ウィンドウのサイズを設定しない場合、 **DesktopWindowXamlSource**を追加する任意の UWP コントロールは表示されません。 **DesktopWindowXamlSource**で内部子ウィンドウにアクセスするには、 **IDesktopWindowXamlSourceNative**インターフェイスの**WindowHandle**プロパティを使用します。 次の例では、ウィンドウのサイズを設定するのに[SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数を使用します。

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
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。


## <a name="how-to-host-custom-uwp-xaml-controls"></a>どのようにカスタム ホストに UWP XAML コントロール

> [!IMPORTANT]
> 現時点では、サード パーティからカスタムの UWP XAML コントロールは、c# WPF および Windows フォーム アプリケーションでのみサポートされます。 アプリケーションでそれに対してコンパイルするため、コントロールのソース コードが必要です。

カスタム UWP XAML コントロール (自分で定義するコントロール、または、サード パーティによって提供されるコントロール) をホストする場合は、[前のセクション](#how-to-host-uwp-xaml-controls)で説明されているプロセスに加え、次の追加タスクを実行する必要があります。

1. [**Windows.UI.Xaml.Application**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application)から派生しも[**IXamlMetadataProvider**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider)を実装するカスタム型を定義します。 この型は、アプリケーションの現在のディレクトリのアセンブリ内でカスタムの UWP XAML 型のメタデータを読み込むルート メタデータ プロバイダーとして機能します。

    これを行う方法を示す例では、Windows コミュニティ ツールキットの[XamlApplication.cs](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Windows.Interop.WindowsXamlHost.Shared/XamlApplication.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームは、これらの種類のアプリ内の API をホストしている UWP XAML を使用する方法を示すための共有**WindowsXamlHost**クラスの実装の一部です。

2. UWP XAML コントロールの種類の名前が割り当てられている場合は、ルートのメタデータは、プロバイダーの[**GetXamlType**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider.getxamltype)メソッドを呼び出して、実行時に、コードでこの割り当て可能性があります (Visual Studio の [プロパティ] ウィンドウに割り当てられるこれを有効にすることもできます)。

    これを行う方法を示す例では、Windows コミュニティ ツールキットの[UWPTypeFactory.cs](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Windows.Interop.WindowsXamlHost.Shared/UWPTypeFactory.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームの共有**WindowsXamlHost**クラスの実装の一部です。

3. カスタムの UWP XAML コントロールのソース コードをホスト アプリケーションのソリューションに統合、カスタム コントロールをビルドして、次の[手順](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost#add-a-custom-uwp-control)で、アプリケーションで使用します。

## <a name="how-to-handle-keyboard-focus-navigation"></a>キーボード フォーカス ナビゲーションを処理する方法

移動すると、ユーザー (たとえば、**タブ**または方向/方向キーを押す) によって、キーボードを使用して、アプリケーションの UI 要素を**DesktopWindowXamlSource**オブジェクトと、フォーカスをプログラムにより移動する必要があります。 ユーザーのキーボード ナビゲーション、 **DesktopWindowXamlSource**UI のナビゲーションの順序で最初の[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトにフォーカスを移動に達すると、次にフォーカスを移動引き続き**Windows.UI.Xaml.UIElement**要素、およびし、UI の親要素に**DesktopWindowXamlSource**から戻る移動フォーカスを通じてユーザーの循環に応じてオブジェクト。  

API をホストしている UWP XAML では、これらのタスクを達成するために、いくつかの型とメンバーを提供します。

1. キーボード ナビゲーションに入ると、 **DesktopWindowXamlSource**、 [**GotFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.gotfocus)イベントが発生します。 このイベントを処理し、プログラムで[**NavigateFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.navigatefocus)メソッドを使用して最初のホストされた**Windows.UI.Xaml.UIElement**にフォーカスを移動します。

2. ユーザーが、 **DesktopWindowXamlSource**の最後のフォーカス可能な要素では、 **Tab**キーまたは方向キーを押すと、 [**TakeFocusRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.takefocusrequested)イベントが発生します。 このイベントを処理し、プログラムによって、ホスト アプリケーションの次のフォーカス可能な要素にフォーカスを移動します。 たとえば、 **DesktopWindowXamlSource**が[**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)でホストされている場所の WPF アプリケーションでは、ホスト アプリケーションの次のフォーカス可能な要素にフォーカスを転送するのに[**MoveFocus**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.movefocus)メソッドを使用することができます。

実用的なサンプル アプリケーションのコンテキストでこれを行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.Focus.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs)ファイルを参照してください。

## <a name="how-to-handle-layout-changes"></a>レイアウトの変更を処理する方法

親の UI 要素のサイズを変更するときは、想定どおりに表示、UWP コントロールを確認するために必要なレイアウト変更を処理する必要があります。 考慮すべきいくつかの重要なシナリオを次に示します。

1. 親の UI 要素は、四角形の領域に合わせて**DesktopWindowXamlSource**をホストしている**Windows.UI.Xaml.UIElement の**ために必要なサイズを取得する必要がある場合は、 **Windows.UI.Xaml.UIElement の[**測定**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.measure)メソッドを呼び出す**. 以下に例を示します。
    * WPF アプリケーションでの**DesktopWindowXamlSource**をホストしている[**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost) [**MeasureOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.measureoverride)メソッドから実行する可能性があります。
    * Windows フォーム アプリケーションで**DesktopWindowXamlSource**をホストしている[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**推奨**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.getpreferredsize)メソッドから実行する可能性があります。

2. 親の UI 要素の変更、サイズ、[**配置**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.arrange)のメソッドを呼び出してルート**Windows.UI.Xaml.UIElement**するときは、 **DesktopWindowXamlSource**でホストしています。 以下に例を示します。
    * WPF アプリケーションで**DesktopWindowXamlSource**をホストしている[**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)オブジェクトの[**ArrangeOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.arrangeoverride)メソッドから実行する可能性があります。
    * Windows フォーム アプリケーションでこれを行います[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**SizeChanged**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.sizechanged)イベント ハンドラーから**DesktopWindowXamlSource**をホストしています。

実用的なサンプル アプリケーションのコンテキストでこれを行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティ ツールキットで[WindowsXamlHost.Layout.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティ ツールキットで[WindowsXamlHost.Layout.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。

## <a name="how-to-handle-dpi-changes"></a>DPI の変更を処理する方法

アプリで DPI の変更をリッスン レンダー トランス フォームで、UWP コントロールを構成する必要があります (たとえば、ユーザーは、さまざまな画面 DPI のモニターの間で、ウィンドウをドラッグ) 場合に、UWP がコントロールをホストしている、ウィンドウの DPI の変更を処理する場合、ウィンドウの位置を更新して、DPI の変更に応答で、UWP コントロールの変換をレンダリングします。

次の手順では、C++ の Win32 アプリケーションのコンテキストでは、このプロセスを処理する 1 つの方法を示しています。 完全な例では、GitHub で[XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)サンプル[Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)と[Desktop.h](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.h)コード ファイルを参照してください。

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
    * 新しい DPI の値に基づいて**ScaleTransform**オブジェクトの x 軸と y 軸のスケール ファクターを更新します。
    * 外観と UWP コントロールのレイアウトには、必要な調整を加えます。 次のコード例は、[**パディング**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid.padding)の DPI の変更への応答でホストされている**Windows.UI.Xaml.Controls.Grid**コントロールを調整します。

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

2. モニター DPI に対応するアプリケーションを構成するには、[マニフェストのサイド バイ サイド アセンブリ](https://docs.microsoft.com/windows/desktop/SbsCs/application-manifests)をプロジェクトに追加し、設定```<dpiAwareness>```要素を```PerMonitorV2```します。 この値について詳しくは、 [**DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2**](https://docs.microsoft.com/windows/desktop/hidpi/dpi-awareness-context)の説明をご覧ください。

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

API をホストしている XAML では、Windows 10 用の XAML コントロールをホストするその他のすべての種類と同じ制限を共有します。 詳細な一覧については、 [XAML のホスト コントロールの制限事項](xaml-host-controls.md#limitations)を参照してください。

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="error-using-uwp-xaml-hosting-api-in-a-uwp-app"></a>UWP アプリで API をホストしている UWP XAML を使用してエラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは、次のメッセージでは、 **COMException**を受け取ります。"DesktopWindowXamlSource アクティブ化できません。 この種類の使用できません、UWP アプリで。" または、"WindowsXamlManager アクティブ化できません。 この種類の使用できません、UWP アプリで。" | このエラーは、API をホストしている UWP XAML を使用しようとしていることを示します (具体的には、しようとする[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)または[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)型をインスタンス化)、UWP アプリでします。 API をホストしている UWP XAML が UWP 以外のデスクトップ アプリ、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用するのみ想定されています。 |

### <a name="error-attaching-to-a-window-on-a-different-thread"></a>別のスレッドでのウィンドウにアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは、次のメッセージでは、 **COMException**を受け取ります。"AttachToWindow メソッドは、指定した HWND が別のスレッドで作成されたため失敗しました"。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すし、別のスレッドで作成されたウィンドウの HWND が渡されたことを示します。 このメソッドは、メソッドを呼び出すことのコードと同じスレッドで作成されたウィンドウの HWND 渡す必要があります。 |

### <a name="error-attaching-to-a-window-on-a-different-top-level-window"></a>さまざまなトップレベル ウィンドウで、ウィンドウにアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは、次のメッセージでは、 **COMException**を受け取ります。"AttachToWindow メソッドは、指定した HWND が、同じスレッドで以前 AttachToWindow に渡された HWND よりも、さまざまなトップレベル ウィンドウから下降ため失敗しました"。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すしよりも前の呼び出しをこのメソッドで指定した場合は、さまざまなトップレベル ウィンドウから下降ウィンドウの HWND が渡されることを示します同じスレッドします。</p></p>アプリケーションは、特定のスレッドで**IDesktopWindowXamlSourceNative.AttachToWindow**を呼び出し、同じスレッドで他のすべての[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを同じトップレベル ウィンドウの子孫 windows に接続のみ**IDesktopWindowXamlSourceNative.AttachToWindow**最初の呼び出しで渡されたします。 **DesktopWindowXamlSource**のすべてのオブジェクトは特定のスレッドを閉じると、次の**DesktopWindowXamlSource**が自由にもう一度任意のウィンドウにアタッチできます。</p></p>この問題を解決するには、このスレッドで他のトップレベル ウィンドウにバインドされている、またはこの**DesktopWindowXamlSource**の新しいスレッドを作成するすべての**DesktopWindowXamlSource**オブジェクトを閉じるか。 |

## <a name="related-topics"></a>関連トピック

* [デスクトップ アプリケーションの UWP コントロール](xaml-host-controls.md)
