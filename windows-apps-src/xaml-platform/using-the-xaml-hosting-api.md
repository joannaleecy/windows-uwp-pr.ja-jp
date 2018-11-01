---
author: mcleanbyron
description: この資料では、デスクトップ アプリケーションで UWP の XAML UI をホストする方法について説明します。
title: デスクトップ アプリケーションで API をホストしている UWP の XAML を使用してください。
ms.author: mcleans
ms.date: 09/21/2018
ms.topic: article
keywords: windows 10、uwp、windows フォーム、wpf、win32
ms.localizationpriority: medium
ms.openlocfilehash: 2ba64e32a25feaee9245bbfe2b598c756b29df98
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919700"
---
# <a name="using-the-uwp-xaml-hosting-api-in-a-desktop-application"></a>デスクトップ アプリケーションで API をホストしている UWP の XAML を使用してください。

> [!NOTE]
> UWP XAML API をホストしている現在は、開発者向けプレビュー版として。 私たちをお勧めするプロトタイプのコードでは、この API を今すぐ試してが勧めしませんを使用すること、実稼働コードでこの時点で。 この API は、成熟し、将来のリリースの Windows の安定化を続けます。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

17709 ビルド 10 内部プレビュー SDK の Windows では、UWP ではないデスクトップ ・ アプリケーション (WPF、Windows フォーム、および C++ の Win32 アプリケーションを含む) は、UWP のコントロールをホストする*API をホストしている UWP の XAML*を使用して、ウィンドウ ハンドルである (関連付けられている任意の UI 要素HWND)。 この API を使用すると、UWP コントロールによって提供される最新の Windows 10 UI 機能を使用するデスクトップ アプリケーションを UWP ではないです。 たとえば、UWP ではないのデスクトップ アプリケーションでは、[流暢な設計のシステム](../design/fluent-design-system/index.md)を使用し、 [Windows のインク](../design/input/pen-and-stylus-interactions.md)をサポートしている UWP コントロールをホストするには、この API を使用できます。

API をホストしている UWP の XAML では、広範な開発者がデスクトップ アプリケーション以外の UWP を Fluent UI を表示するを有効にするコントロールの基盤を提供します。 このシナリオは、 *XAML の島*と呼ばれます。 このシナリオの詳細については、[デスクトップ アプリケーションで UWP のコントロール](xaml-host-controls.md)を参照してください。

## <a name="is-the-uwp-xaml-hosting-api-right-for-your-desktop-application"></a>UWP XAML ホスト API をデスクトップ アプリケーションの右のでしょうか。

API をホストしている UWP の XAML は、デスクトップ アプリケーションで UWP コントロールをホストするための低レベルのインフラストラクチャを提供します。 いくつかの種類のデスクトップ アプリケーションでは、この目標を達成するのには、代替の方が便利な Api を使用するオプションがあります。  

* C++ の Win32 デスクトップ アプリケーションがある場合、アプリケーションで UWP のコントロールをホストする場合は、API をホストしている UWP の XAML を使用する必要があります。 これらの種類のアプリケーションのための代替手段はありません。

* WPF と Windows フォーム アプリケーションでは、お勧め UWP の XAML ではなく Windows コミュニティ Toolkit で[ラップされたコントロール](xaml-host-controls.md#wrapped-controls)と[ホスト コントロール](xaml-host-controls.md#host-controls)を使用すること API をホストします。 これらのコントロール ホスト API を内部的に UWP の XAML を使用して、シンプルな開発エクスペリエンスを提供 ただし、選択した場合これらの種類のアプリケーションで直接 API をホストしている UWP の XAML を使用できます。

## <a name="related-samples"></a>関連するサンプル

UWP XAML コード内のホスト API を使用する方法は、アプリケーション、およびその他の要因の設計、アプリケーションの種類によって異なります。 完全なアプリケーションのコンテキストでこの API を使用する方法を説明するため、この資料はコードを次のサンプルです。

### <a name="c-win32"></a>C++ の Win32

GitHub に C++ の Win32 アプリケーションでは API をホストしている UWP の XAML を使用する方法を示すサンプルがいくつかあります。

  * [XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)。 このサンプルでは、C++ の Win32 アプリケーションに UWP [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)、 [InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)、 [MediaPlayerElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement)コントロールを追加する方法を示します。
  * [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)。 このサンプルでは、C++ の Win32 アプリケーションにいくつかの基本的な UWP コントロールを追加し、DPI の変更を処理する方法を示します。

### <a name="wpf-and-windows-forms"></a>WPF と Windows フォーム

Windows コミュニティの Toolkit では、 [WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost)コントロールは、WPF および Windows フォーム アプリケーションで API をホストしている UWP を使用するための参照例として機能します。 ソース コードは、次の場所から入手できます。

  * [ここ](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost)に、コントロールの WPF バージョン。 WPF のバージョンは、 [**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)から派生します。
  * [ここ](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost)に、コントロールの Windows フォームのバージョン。 Windows フォームのバージョンは、 [**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)から派生します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP の XAML では、これらの前提条件があります。

* 17709 (またはそれ以降のビルド) を構築する 10 内部者プレビューの Windows および Windows SDK の対応する内部関係者によるプレビュー ビルドします。 これは、進化する機能であるため、最大限に活用できることをお勧め最新の利用可能なビルドを使用します。

* デスクトップ アプリケーションで API をホストしている UWP の XAML を使用するには、UWP Api を呼び出すことができますので、プロジェクトを構成する必要があります。

    * **C++ Win32:** 使用するプロジェクトを構成することをお勧めします。 [C + + WinRT](../cpp-and-winrt-apis/index.md)。 ダウンロードしてインストール、 [C + + WinRT Visual Studio 拡張機能 (VSIX)](https://aka.ms/cppwinrt/vsix) Visual Studio のマーケットプ レースから、追加、```<CppWinRTEnabled>true</CppWinRTEnabled>```として説明されている[ここで](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix).vcxproj ファイルのプロパティ。

    * **Windows フォームと WPF:**[これらの指示](../porting/desktop-to-uwp-enhance.md)に従います。

## <a name="architecture-of-xaml-islands"></a>XAML の島のアーキテクチャ

API をホストしている UWP の XAML には、 [**Windows.UI.Xaml.Hosting**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間内の[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)、 [**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)、およびその他の関連する型が含まれています。 デスクトップのアプリケーションでは、UWP コントロールをレンダリングし、キーボード フォーカスのナビゲーション要素との間をルーティングするこの API を使用できます。 デスクトップ ・ アプリケーションは、サイズもと必要に応じて、UWP コントロールを配置します。

ホスト API をデスクトップ アプリケーションで XAML を使用して XAML の島を作成するとき、次の階層構造のオブジェクトが用意されます。

* 基本レベルで XAML の島をホストするアプリケーションの UI 要素は、です。 この UI 要素には、ウィンドウ ハンドル (HWND) が必要です。 XAML 島をホストできる UI 要素の例には、WPF アプリケーション、Windows フォーム アプリケーションの場合は、 [**System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)および C++ の Win32 アプリケーションの[ウィンドウ](https://docs.microsoft.com/windows/desktop/winmsg/about-windows)の[**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)が含まれます。

* 次のレベルは、 **DesktopWindowXamlSource**オブジェクトです。 このオブジェクトは、XAML の島をホストするためのインフラストラクチャを提供します。 コードは、このオブジェクトを作成し、UI の親要素にアタッチします。

* の**DesktopWindowXamlSource**を作成するとき、このオブジェクトは自動的に UWP コントロールをホストするためのネイティブの子ウィンドウを作成します。 このネイティブの子ウィンドウはほとんどの場合、コードから抽象化されたが、ハンドル (HWND) 必要な場合にアクセスすることができます。

* 最後に、最上部には、デスクトップ アプリケーションでホストする UWP コントロールです。 [**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)などのカスタム ユーザー コントロールも、Windows SDK で提供される任意の UWP コントロールから派生した任意の UWP オブジェクトを指定できます。

次の図は、XAML のアイランド内のオブジェクトの階層を示しています。

![DesktopWindowXamlSource アーキテクチャ](images/xaml-hosting-api-rev2.png)

## <a name="how-to-host-uwp-xaml-controls"></a>UWP の XAML コントロールをホストする方法

UWP アプリケーションでコントロールをホストする API をホストしている UWP の XAML を使用する主な手順を次に示します。

1. [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)でそれをホストする[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトのいずれかのアプリケーションを作成する前に、現在のスレッドの UWP の XAML フレームワークを初期化します。

    * **DesktopWindowXamlSource**オブジェクトをインスタンス化するときにこのフレームワークの初期化するアプリケーションは、任意の**Windows.UI.Xaml.UIElement**オブジェクトを作成する前に、 **DesktopWindowXamlSource**オブジェクトを作成する場合. このシナリオでは、フレームワークを初期化するために独自のコードを追加する必要はありません。

    * ただし、アプリケーションは、それらをホストする**DesktopWindowXamlSource**オブジェクトを作成する前に、 **Windows.UI.Xaml.UIElement**オブジェクトを作成する場合、アプリケーション呼び出す必要があります静的[**WindowsXamlManager.InitializeForCurrentThread**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager.initializeforcurrentthread) **Windows.UI.Xaml.UIElement**オブジェクトをインスタンス化する前に明示的に UWP XAML フレームワークを初期化します。 **DesktopWindowXamlSource**をホストする親 UI 要素がインスタンス化されるとき、アプリケーションはこのメソッドを呼び出す一般的です。

    ```cppwinrt
    Windows::UI::Xaml::Hosting::WindowsXamlManager windowsXamlManager =
        Windows::UI::Xaml::Hosting::WindowsXamlManager::InitializeForCurrentThread();
    ```

    ```csharp
    global::Windows.UI.Xaml.Hosting.WindowsXamlManager windowsXamlManager =
        global::Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
    ```

    > [!NOTE]
    > UWP の XAML フレームワークへの参照を格納する[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)オブジェクトを返します。 特定のスレッドで必要な数の**WindowsXamlManager**オブジェクトを作成することができます。 ただし、各オブジェクトは、UWP の XAML フレームワークへの参照を保持しているために、XAML リソースが最終的に解放されることを確認するのにはオブジェクトを破棄する必要があります。

2. [**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを作成し、親ウィンドウ ハンドルに関連付けられているアプリケーションの UI 要素にアタッチします。

    これを行うには、これらの手順を実行する必要があります。

    1. **DesktopWindowXamlSource**オブジェクトを作成し、 **IDesktopWindowXamlSourceNative** COM インターフェイスにキャストします。 このインターフェイスで宣言されている、 ```windows.ui.xaml.hosting.desktopwindowxamlsource.h``` 、Windows SDK のヘッダー ファイルです。 C++ の Win32 プロジェクトでは、このヘッダー ファイルを直接参照することができます。 WPF または Windows フォーム プロジェクトでは、 [**ComImport**](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.comimportattribute)属性を使用して、アプリケーション コードでこのインターフェイスを宣言する必要があります。 インターフェイス宣言の中では、インターフェイス宣言では、完全に一致するかどうかを確認```windows.ui.xaml.hosting.desktopwindowxamlsource.h```。

    2. **IDesktopWindowXamlSourceNative**インタ フェースの**AttachToWindow**メソッドを呼び出すし、アプリケーションで親の UI 要素のウィンドウ ハンドルを渡します。

    3. **DesktopWindowXamlSource**に含まれる内部の子ウィンドウの初期サイズを設定します。 既定では、この内部の子ウィンドウは、幅および高さが 0 に設定されます。 ウィンドウのサイズを設定しない場合は、 **DesktopWindowXamlSource**に追加するすべての UWP コントロールは表示されません。 **DesktopWindowXamlSource**で内部の子ウィンドウにアクセスするには、 **IDesktopWindowXamlSourceNative**インターフェイスの**WindowHandle**プロパティを使用します。 次の例では、ウィンドウのサイズを設定するのには[SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数を使用します。

    このプロセスを説明するいくつかのコード例を次に示します。

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

3. [**コンテンツ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.content)オブジェクトのプロパティに、 **DesktopWindowXamlSource**をホストする**Windows.UI.Xaml.UIElement**を設定します。 次の例では、 [**Windows.UI.Xaml.Controls.Grid**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)という名前の```myGrid```**コンテンツ**のプロパティにします。

   ```cppwinrt
   desktopWindowXamlSource.Content(myGrid);
   ```

   ```csharp
   desktopWindowXamlSource.Content = myGrid;
   ```

実用的なサンプル アプリケーションのコンテキストでこれらのタスクを示す完全な例については、次のコード ファイルを参照してください。

  * **C++ Win32:**[Main.cpp](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting/blob/master/XamlHostingSample/Main.cpp)ファイル[XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)のサンプルや、 [Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp) 、 [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)のサンプル ファイルを参照してください。
  * **WPF:** Windows コミュニティの Toolkit で[WindowsXamlHostBase.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティの Toolkit で[WindowsXamlHostBase.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHost.cs)ファイルを参照してください。


## <a name="how-to-host-custom-uwp-xaml-controls"></a>どのようにコントロールするのにはカスタムのホスト UWP の XAML

> [!IMPORTANT]
> 現時点では、サード パーティから UWP の XAML のカスタム コントロールは、C# WPF および Windows フォーム アプリケーションでのみサポートされます。 それに対して、アプリケーションにコンパイルするためのコントロールのソース コードが必要です。

カスタム UWP XAML コントロール (ユーザー定義コントロール、またはサード パーティによって提供されるコントロール) をホストする場合は、次の追加のタスクだけでなく、[前のセクション](#how-to-host-uwp-xaml-controls)で説明する処理を行う必要があります。

1. [**Windows.UI.Xaml.Application**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application)から派生し、また[**IXamlMetadataProvider**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider)を実装するカスタム型を定義します。 この型は、アプリケーションの現在のディレクトリ内のアセンブリにカスタムの UWP の XAML 型のメタデータを読み込むためのルートのメタデータ プロバイダーとして機能します。

    これを行う方法を示す例では、Windows コミュニティの Toolkit では、 [XamlApplication.cs](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Windows.Interop.WindowsXamlHost.Shared/XamlApplication.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームは、これらの種類のアプリケーションで API をホストしている UWP の XAML を使用する方法を示すための**WindowsXamlHost**クラスの共有の実装の一部です。

2. UWP XAML コントロールの型名が割り当てられている場合に、ルートのメタデータ プロバイダーの[**GetXamlType**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider.getxamltype)メソッドを呼び出します (この割り当てることができますコードの実行時、または Visual Studio のプロパティ] ウィンドウで指定するのにはこれを有効にすることもできます)。

    これを行う方法を示す例では、Windows コミュニティの Toolkit では、 [UWPTypeFactory.cs](https://github.com/Microsoft/WindowsCommunityToolkit/tree/master/Microsoft.Toolkit.Win32/Microsoft.Windows.Interop.WindowsXamlHost.Shared/UWPTypeFactory.cs)コード ファイルを参照してください。 このファイルは、WPF および Windows フォームの**WindowsXamlHost**クラスの共有の実装の一部です。

3. UWP の XAML のカスタムのコントロールのソース コードをホスト アプリケーションのソリューションに統合、カスタム コントロールを作成、次の[手順](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost#add-a-custom-uwp-control)によって、アプリケーションで使用します。

## <a name="how-to-handle-keyboard-focus-navigation"></a>キーボード フォーカスのナビゲーションを処理する方法

移動すると、ユーザー (たとえば、**タブ**と矢印キーを押す) をキーボードを使用してアプリケーション内の UI 要素をプログラムを使用して**DesktopWindowXamlSource**オブジェクトとの間にフォーカスを移動する必要があります。 次にフォーカスを移動するのにはユーザーのキーボード ナビゲーションに達すると、 **DesktopWindowXamlSource**で、UI のナビゲーション順序内の最初の[**Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)オブジェクトにフォーカスを移動を続ける**Windows.UI.Xaml.UIElement**オブジェクトを要素とし、 **DesktopWindowXamlSource**から戻ると、親の UI 要素にフォーカスを移動ユーザーのサイクルとして。  

UWP XAML ホスト API は、これらのタスクを達成するために、いくつかの型およびメンバーを提供します。

1. キーボード ナビゲーション、 **DesktopWindowXamlSource**に入ると、 [**GotFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.gotfocus)イベントが発生します。 このイベントを処理し、プログラムを使用して、 [**NavigateFocus**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.navigatefocus)メソッドを使用して、最初のホストされている**Windows.UI.Xaml.UIElement**にフォーカスを移動します。

2. ユーザーが、 **DesktopWindowXamlSource**にフォーカスを設定できる最後の要素に、 **Tab**キーまたは方向キーを押すと、 [**TakeFocusRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.takefocusrequested)イベントが発生します。 このイベントを処理し、プログラムを使用してホスト アプリケーションの次のフォーカス可能な要素にフォーカスを移動します。 などの**DesktopWindowXamlSource**が、 [**System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)でホストされている WPF アプリケーションでは、ホスト アプリケーションの次のフォーカス可能な要素にフォーカスを移動するのには[**MoveFocus**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.movefocus)メソッドを使用することができます。

実用的なサンプル アプリケーションのコンテキストでこの操作を行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティの Toolkit では、 [WindowsXamlHostBase.Focus.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティの Toolkit では、 [WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs)ファイルを参照してください。

## <a name="how-to-handle-layout-changes"></a>レイアウトの変更を処理する方法

UI の親要素のサイズを変更するときは、UWP コントロールが期待どおりの表示を確認するために必要なレイアウト変更を処理する必要があります。 考慮すべきいくつかの重要なシナリオを次に示します。

1. 親の UI 要素では、 **DesktopWindowXamlSource**でホストしている**Windows.UI.Xaml.UIElement**が収まる四角形領域のサイズを取得する必要がある、 **Windows.UI.Xaml.UIElement の[**測定**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.measure)メソッドを呼び出す**. 以下に例を示します。
    * WPF アプリケーションで**DesktopWindowXamlSource**をホストする、 [**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)の[**MeasureOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.measureoverride)メソッドから実行することがあります。
    * Windows フォーム アプリケーションで**DesktopWindowXamlSource**をホストしている[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**推奨**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.getpreferredsize)メソッドから実行することがあります。

2. 、UI の要素の変更の親のサイズ、[**配置**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.arrange)のメソッドを呼び出すルート**Windows.UI.Xaml.UIElement**をするとき、 **DesktopWindowXamlSource**でホストしています。 以下に例を示します。
    * WPF アプリケーションで**DesktopWindowXamlSource**をホストする、 [**HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)オブジェクトの[**ArrangeOverride**](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.arrangeoverride)メソッドから実行することがあります。
    * Windows フォーム アプリケーションでこれを行いますし、[**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)の[**SizeChanged**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.sizechanged)イベントのハンドラーから**DesktopWindowXamlSource**をホストしています。

実用的なサンプル アプリケーションのコンテキストでこの操作を行う方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** Windows コミュニティの Toolkit では、 [WindowsXamlHost.Layout.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。  
  * **Windows フォーム:** Windows コミュニティの Toolkit では、 [WindowsXamlHost.Layout.cs](https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/Microsoft.Toolkit.Win32/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs)ファイルを参照してください。

## <a name="how-to-handle-dpi-changes"></a>DPI の変更を処理する方法

UWP コントロールを構成する描画変換を使用して、アプリケーションでは、DPI の変更をリッスンする必要があります (たとえば、ユーザーは、さまざまな画面 DPI のモニター間でウィンドウをドラッグした) 場合に、UWP がコントロールをホストしている DPI の変更] ウィンドウを処理する場合は、、ウィンドウの位置を更新して、DPI の変更への応答で、UWP コントロールのトランス フォームをレンダリングします。

次の手順では、C++ の Win32 アプリケーションのコンテキストでは、このプロセスを処理する方法の 1 つを示しています。 完全な例では、GitHub に、 [Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)と[Desktop.h](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.h)のコード サンプル内のファイル[XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)を参照してください。

1. アプリ、 [**ScaleTransform**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.scaletransform)オブジェクトを管理し、UWP コントロールの[**調整**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.rendertransform)方法に割り当てます。 次の使用例は、C++ の Win32 アプリケーションでは、 [**Windows.UI.Xaml.Controls.Grid**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)コントロールをします。

    ```cppwinrt
    // Private fields maintained by your app, such as in a window class you have defined.
    Windows::UI::Xaml::Media::ScaleTransform m_scale;
    Windows::UI::Xaml::Controls::Grid m_rootGrid;

    // Code that runs during initialization, such as the constructor for a window class you have defined.
    m_rootGrid.RenderTransform(m_scale);
    ```

2. 、 [**WindowProc**](https://msdn.microsoft.com/library/windows/desktop/ms633573.aspx)関数に[**WM_DPICHANGED**](https://docs.microsoft.com/windows/desktop/hidpi/wm-dpichanged)メッセージをリッスンします。 このメッセージに応答します。
    * [**SetWindowPos**](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)関数を使用すると、メッセージに渡される四角形に UWP コントロールを含むウィンドウのサイズを変更します。
    * 新しい DPI 値に従って**ScaleTransform**オブジェクトの x 軸と y 軸のスケール係数を更新します。
    * UWP コントロールのレイアウトと外観を必要な調整を行います。 次のコード例では、[**パディング**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid.padding)の DPI の変更への応答でホストされている**Windows.UI.Xaml.Controls.Grid**コントロールを調整します。

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

2. モニター DPI に対応するアプリケーションを構成するには、[サイド バイ サイド アセンブリ マニフェスト](https://docs.microsoft.com/windows/desktop/SbsCs/application-manifests)をプロジェクトに追加し、設定```<dpiAwareness>```要素を```PerMonitorV2```。 この値の詳細については、 [**DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2**](https://docs.microsoft.com/windows/desktop/hidpi/dpi-awareness-context)の説明を参照してください。

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

    完全な例のサイド バイ サイド アセンブリ マニフェストでは、GitHub に、 [XamlIslandsWin32.exe.manifest](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/XamlIslandsWin32.exe.manifest) 、 [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)のサンプル ファイルを参照してください。

## <a name="limitations"></a>制限事項

API をホストしている XAML は、Windows の 10 の他のすべての種類のホスト コントロールの XAML と同じ制限を共有します。 詳細については、 [XAML のホスト コントロールの制限事項](xaml-host-controls.md#limitations)を参照してください。

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="error-using-uwp-xaml-hosting-api-in-a-uwp-app"></a>UWP アプリケーションでは API をホストしている UWP の XAML を使用してエラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージでは、 **COMException**を受け取ります:"DesktopWindowXamlSource をアクティブにできません。 この型では使用できません UWP アプリケーションです。」 または、"WindowsXamlManager をアクティブにできません。 この型では使用できません UWP アプリケーションです。」 | このエラーは、API をホストしている UWP の XAML を使用しようとしていることを示します (具体的には、しようとする[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)または[**WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)の型のインスタンスを作成する) アプリケーションで UWP です。 UWP XAML API をホストしていることを目的以外の UWP のデスクトップ アプリケーション、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用します。 |

### <a name="error-attaching-to-a-window-on-a-different-thread"></a>別のスレッド上のウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージでは、 **COMException**を受け取ります。」AttachToWindow メソッドは、指定された HWND は、別のスレッドで作成されたため失敗しました」。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すし、別のスレッドで作成されたウィンドウの HWND を渡すことを示します。 このメソッドにはメソッドの呼び出し元のコードと同じスレッドで作成されたウィンドウの HWND を渡す必要があります。 |

### <a name="error-attaching-to-a-window-on-a-different-top-level-window"></a>別のトップレベル ウィンドウのウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリは次のメッセージでは、 **COMException**を受け取ります:「AttachToWindow メソッドは、同じスレッドで以前 AttachToWindow に渡された HWND よりも別のトップレベル ウィンドウの HWND を指定した地点に降下ために失敗しました」。 | このエラーは、アプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**メソッドを呼び出すし、このメソッドへの前回の呼び出しで指定したよりも別の最上位ウィンドウから降下するウィンドウの HWND に渡されることを示します。同じスレッドです。</p></p>特定のスレッドのアプリケーションが**IDesktopWindowXamlSourceNative.AttachToWindow**を呼び出すと、同じスレッドで他のすべての[**DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)オブジェクトを同じトップレベル ウィンドウの子孫である windows に接続のみ**IDesktopWindowXamlSourceNative.AttachToWindow**の最初の呼び出しで渡されました。 特定のスレッドのすべての**DesktopWindowXamlSource**オブジェクトが閉じられると、次の**DesktopWindowXamlSource**は自由に任意のウィンドウをもう一度接続します。</p></p>この問題を解決するには、いずれかの方法は、このスレッドで他のトップ レベル ウィンドウにバインドされているか、この**DesktopWindowXamlSource**の新しいスレッドを作成するすべての**DesktopWindowXamlSource**オブジェクトを閉じます。 |

## <a name="related-topics"></a>関連トピック

* [デスクトップ アプリケーションの UWP コントロール](xaml-host-controls.md)
