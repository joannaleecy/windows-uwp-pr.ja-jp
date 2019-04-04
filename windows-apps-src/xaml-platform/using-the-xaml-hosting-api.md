---
description: この記事では、お客様のデスクトップ アプリケーションで UWP XAML の UI をホストする方法について説明します。
title: デスクトップ アプリケーションで API をホストしている UWP XAML を使用します。
ms.date: 01/11/2019
ms.topic: article
keywords: windows 10、uwp、windows フォーム、wpf、win32
ms.localizationpriority: medium
ms.openlocfilehash: efd7dc687b9aba2e3c07b0afefa2e4fa49b882b1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618837"
---
# <a name="using-the-uwp-xaml-hosting-api-in-a-desktop-application"></a>デスクトップ アプリケーションで API をホストしている UWP XAML を使用します。

> [!NOTE]
> UWP XAML ホスティング API と XAML アイランドは、現在開発者プレビューとして使用できます。 実際に試してみて、プロトタイプのコードで今すぐするを勧めしますが、使用することに実稼働コードでこの時点でをしないでください。 これらの機能は、成熟し、将来のリリースの Windows が安定し続けます。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。
>
> XAML 諸島に関するフィードバックをした場合で新しい問題を作成、 [WindowsCommunityToolkit リポジトリ](https://github.com/windows-toolkit/WindowsCommunityToolkit/issues)がコメントを残すとします。 プライベート フィードバックを送信する場合に送信できますXamlIslandsFeedback@microsoft.comします。 Insights とシナリオは弊社にとって非常に重要です。

Windows 10 Insider Preview SDK ビルド 17709 以降、非 UWP のデスクトップ アプリケーション (WPF、Windows フォーム、および C++ の Win32 アプリケーションを含む) を使用できます、 *API をホストしている UWP XAML*関連付けられている任意の UI 要素に UWP コントロールをホストするで、ウィンドウ ハンドル (HWND)。 この API は、のみ UWP コントロールを使用して利用できる最新の Windows 10 の UI 機能を使用するデスクトップ アプリケーションを UWP 以外を使用できます。 デスクトップ アプリケーションを UWP 以外が使用する UWP コントロールをホストするには、この API を使用するなど、 [Fluent Design System](../design/fluent-design-system/index.md)サポートと[Windows インク](../design/input/pen-and-stylus-interactions.md)します。

API をホストしている UWP XAML では、開発者がデスクトップ アプリケーションを UWP 以外に Fluent UI を表示できるようにするコントロールの広範なセットの基盤を提供します。 このシナリオとも呼ばれます*XAML 諸島*します。 この開発者向けシナリオの詳細については、[デスクトップ アプリケーションでの UWP コントロール](xaml-host-controls.md)を参照してください。

## <a name="is-the-uwp-xaml-hosting-api-right-for-your-desktop-application"></a>お客様のデスクトップ アプリケーションに適した API をホスト UWP XAML でしょうか。

API をホストしている UWP XAML は、デスクトップ アプリケーションでの UWP コントロールをホストするための低レベルのインフラストラクチャを提供します。 いくつかの種類のデスクトップ アプリケーションでは、代替方法でより便利な Api を使用して、この目標を達成するオプションがあります。  

* C++ Win32 デスクトップ アプリケーションがあり、アプリケーションで UWP コントロールをホストする場合は、API をホストしている UWP XAML を使用する必要があります。 これらの種類のアプリケーションのための代替手段はありません。

* WPF と Windows フォーム アプリケーションでは、お勧めしますを使用すること、[コントロールをラップ](xaml-host-controls.md#wrapped-controls)と[ホスト コントロール](xaml-host-controls.md#host-controls)API をホストしている UWP XAML ではなく Windows Community Toolkit にします。 これらのコントロールは、内部的に API をホストしている UWP XAML を使用して、および単純な開発エクスペリエンスを提供します。 ただし、選択した場合、この種のアプリケーションで直接 API をホストする UWP XAML を使用することができます。

## <a name="related-samples"></a>関連するサンプル

コードで API をホストしている UWP XAML を使用する方法は、アプリケーション、およびその他の要因のデザイン、アプリケーションの種類によって異なります。 この記事では、完全なアプリケーションのコンテキストでこの API を使用する方法を説明するには、次のサンプルからコードを指します。

### <a name="c-win32"></a>C++ Win32

GitHub の C++ の Win32 アプリケーションで API をホストしている UWP XAML を使用する方法を示すサンプルがいくつかあります。

  * [XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)します。 このサンプルは、UWP を追加する方法を示します[InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)、 [InkToolbar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar)、および[MediaPlayerElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediaplayerelement) C++ の Win32 アプリケーションへのコントロール。
  * [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)します。 このサンプルでは、C++ の Win32 アプリケーションにいくつかの基本的な UWP コントロールを追加して、DPI の変更を処理する方法を示します。

### <a name="wpf-and-windows-forms"></a>WPF と Windows フォーム

[WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost) Windows の Community Toolkit のコントロールは、UWP、WPF、Windows フォーム アプリケーションでのホスティング API を使用するための参照をサンプルとして機能します。 ソース コードは、次の場所には。

  * コントロールの WPF バージョン[ここに移動して](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Wpf.UI.XamlHost)します。 派生した WPF バージョン[ **System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)します。
  * コントロールの Windows フォーム バージョン[ここに移動して](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/tree/master/Microsoft.Toolkit.Forms.UI.XamlHost)します。 派生した Windows フォーム バージョン[ **System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)します。

## <a name="prerequisites"></a>前提条件

API をホストしている UWP XAML では、これらの前提条件があります。

* Windows 10 Insider Preview ビルド 17709 (またはそれ以降のビルド) と Windows SDK の対応する Insider Preview ビルドします。 これは、進化し続ける機能であるためは、使用可能な最新の使用をお勧めする最良の結果をビルドします。

* お客様のデスクトップ アプリケーションで API をホストしている UWP XAML を使用するには、UWP Api を呼び出せるようにプロジェクトを構成する必要があります。

    * **C++ Win32:** 使用するプロジェクトを構成することをお勧めします。 [C +/cli WinRT](../cpp-and-winrt-apis/index.md)します。 手順については、[C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT サポート](/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)を参照してください。

    * **Windows フォームと WPF:** 次の[手順](../porting/desktop-to-uwp-enhance.md)します。

## <a name="architecture-of-xaml-islands"></a>XAML 諸島のアーキテクチャ

API をホストしている UWP XAML を含む[ **DesktopWindowXamlSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)、 [ **WindowsXamlManager**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)、およびその他の関連する型、で[**Windows.UI.Xaml.Hosting** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)名前空間。 デスクトップ アプリケーションは、この API を使用して、UWP コントロールをレンダリングし、キーボード フォーカスのナビゲーション要素の出入りをルーティングすることができます。 デスクトップ アプリケーションは、サイズもや目的として UWP コントロールを配置します。

デスクトップ アプリケーションで API をホストしている XAML を使用して XAML 島を作成するときに、オブジェクトの階層を次の操作を元になります。

* 基本レベルで XAML の島をホストするアプリケーションで UI 要素は、します。 この UI 要素には、ウィンドウ ハンドル (HWND) が必要です。 XAML の島をホストできる UI 要素の例として、 [ **System.Windows.Interop.HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost) WPF アプリケーション、 [ **System.Windows.Forms.Control**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control) Windows フォーム アプリケーションの場合、[ウィンドウ](https://docs.microsoft.com/windows/desktop/winmsg/about-windows)C++ の Win32 アプリケーション。

* レベルは、次を**DesktopWindowXamlSource**オブジェクト。 このオブジェクトは、XAML の島をホストするためのインフラストラクチャを提供します。 コードは、このオブジェクトを作成し、親の UI 要素にアタッチします。

* 作成するときに、 **DesktopWindowXamlSource**、このオブジェクトは、UWP コントロールをホストするネイティブの子ウィンドウを自動的に作成されます。 このネイティブ子ウィンドウはほとんどの場合、コードから抽象化されていますが、そのハンドル (HWND) に必要な場合にアクセスできます。

* 最後に、最上位レベルでは、デスクトップ アプリケーションをホストする UWP コントロールです。 これは、任意の UWP オブジェクトから派生した[ **Windows.UI.Xaml.UIElement**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)など、UWP、Windows SDK によって提供されるだけではなくカスタム ユーザー コントロール。

次の図は、XAML アイランド内のオブジェクトの階層を示します。

![DesktopWindowXamlSource アーキテクチャ](images/xaml-hosting-api-rev2.png)

## <a name="how-to-host-uwp-xaml-controls"></a>UWP XAML コントロールをホストする方法

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

    1. 作成、 **DesktopWindowXamlSource**オブジェクトおよびにキャスト、 **IDesktopWindowXamlSourceNative** COM インターフェイスです。 このインターフェイスが宣言されている、 ```windows.ui.xaml.hosting.desktopwindowxamlsource.h``` Windows sdk ヘッダー ファイル。 C++ Win32 プロジェクトでは、このヘッダー ファイルを直接参照することができます。 WPF や Windows フォーム プロジェクトでは、アプリケーション コードを使用して、このインターフェイスを宣言する必要があります、 [ **ComImport** ](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.comimportattribute)属性。 インターフェイスの宣言では、インターフェイス宣言では、完全に一致するかどうかを確認```windows.ui.xaml.hosting.desktopwindowxamlsource.h```します。

    2. 呼び出す、 **AttachToWindow**のメソッド、 **IDesktopWindowXamlSourceNative**インターフェイスし、アプリケーションで親の UI 要素のウィンドウ ハンドルを渡します。

    3. 含まれる内部の子ウィンドウの初期サイズを設定、 **DesktopWindowXamlSource**します。 既定では、この内部の子ウィンドウは、幅と高さが 0 に設定されます。 追加するすべての UWP コントロール、ウィンドウのサイズを設定していない場合、 **DesktopWindowXamlSource**は表示されません。 内部の子ウィンドウにアクセスする、 **DesktopWindowXamlSource**を使用して、 **WindowHandle**のプロパティ、 **IDesktopWindowXamlSourceNative**インターフェイス。 次の例を使用して、 [SetWindowPos](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)ウィンドウのサイズを設定します。

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

3. 設定、 **Windows.UI.Xaml.UIElement**をホストする、 [**コンテンツ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.content)のプロパティ、 **DesktopWindowXamlSource**オブジェクト。 次の例のセットを[ **Windows.UI.Xaml.Controls.Grid** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)という```myGrid```を**コンテンツ**プロパティ。

   ```cppwinrt
   desktopWindowXamlSource.Content(myGrid);
   ```

   ```csharp
   desktopWindowXamlSource.Content = myGrid;
   ```

実際のサンプル アプリケーションのコンテキストでこれらのタスクを示す完全な例では、次のコード ファイルを参照してください。

  * **C++ Win32:** 参照してください、 [Main.cpp](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting/blob/master/XamlHostingSample/Main.cpp)ファイル、 [XamlHostingSample](https://github.com/Microsoft/Windows-appsample-Xaml-Hosting)サンプルまたは[Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)ファイル、 [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32)サンプル。
  * **WPF:** 参照してください、 [WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHost.cs) Windows コミュニティ ツールキット内のファイル。  
  * **Windows フォーム:** 参照してください、 [WindowsXamlHostBase.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.cs)と[WindowsXamlHost.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHost.cs) Windows コミュニティ ツールキット内のファイル。


## <a name="how-to-host-custom-uwp-xaml-controls"></a>どのカスタム ホストを UWP XAML コントロール

> [!IMPORTANT]
> 現時点では、サード パーティからのカスタムの UWP XAML コントロールでサポートされてのみC#WPF と Windows フォーム アプリケーションです。 それに対して、アプリケーションでコンパイルするためのコントロールのソース コードが必要です。

説明されているプロセスに加え、次の追加タスクを実行する必要があります (ユーザー定義コントロールまたはサード パーティによって提供されるコントロール) に、カスタム UWP XAML コントロールをホストする場合、[前のセクション](#how-to-host-uwp-xaml-controls)します。

1. 派生したカスタム型を定義する[ **Windows.UI.Xaml.Application** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application)も実装[ **IXamlMetadataProvider**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider)します。 この型は、アプリケーションの現在のディレクトリのアセンブリ内でカスタムの UWP XAML 型のメタデータの読み込みをルートのメタデータ プロバイダーとして機能します。

    これを行う方法を示す例を参照してください、 [XamlApplication.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/XamlApplication.cs) Windows コミュニティのツールキットでコード ファイル。 このファイルの共有の実装の一部である、 **WindowsXamlHost** WPF と Windows フォームは、これらの種類のアプリで API をホストしている UWP XAML を使用する方法を示すためのクラス。

2. 呼び出す、 [ **GetXamlType** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.ixamlmetadataprovider.getxamltype) UWP XAML コントロールの型名が割り当てられている場合は、ルートのメタデータのプロバイダーのメソッド (この、実行時にコードに割り当てることがまたは、これを有効にすることもできます。割り当てられている Visual Studio のプロパティ] ウィンドウで)。

    これを行う方法を示す例を参照してください、 [UWPTypeFactory.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Win32.UI.XamlHost/UWPTypeFactory.cs) Windows コミュニティのツールキットでコード ファイル。 このファイルの共有の実装の一部である、 **WindowsXamlHost** WPF と Windows フォームのクラス。

3. ホスト アプリケーションのソリューションにカスタムの UWP XAML コントロールのソース コードを統合、カスタムのコントロールをビルドおよびに従って、アプリケーションで使用して[手順](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost#add-a-custom-uwp-control)します。

## <a name="how-to-handle-keyboard-focus-navigation"></a>キーボード フォーカスのナビゲーションを処理する方法

キーボードを使用して、アプリケーションで UI 要素を通じて、ユーザーが移動したときに (たとえば、キーを押して**タブ**または方向/矢印キー)、プログラムでの入出力にフォーカスを移動する必要があります、 **DesktopWindowXamlSource**オブジェクト。 ユーザーのキーボード ナビゲーションが達したとき、 **DesktopWindowXamlSource**、最初にフォーカスを移動[ **Windows.UI.Xaml.UIElement** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)ナビゲーション順でのオブジェクト次にフォーカスを移動、ui では、引き続き**Windows.UI.Xaml.UIElement**オブジェクトとして、ユーザーが要素をサイクルしバックアップ フォーカスの移動、 **DesktopWindowXamlSource**と親の UI 要素にします。  

API をホストしている UWP XAML では、これらのタスクを達成するために、いくつかの型とメンバーを提供します。

1. キーボード ナビゲーションが入力した場合、 **DesktopWindowXamlSource**、 [ **GotFocus** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.gotfocus)イベントが発生します。 このイベントを処理し、最初にフォーカスを移動プログラムでホストされている**Windows.UI.Xaml.UIElement**を使用して、 [ **NavigateFocus** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.navigatefocus)メソッド。

2. フォーカスを設定できる最後の要素で、ユーザーの場合、 **DesktopWindowXamlSource**を押すと、**タブ**キーまたは方向キー、 [ **TakeFocusRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource.takefocusrequested)イベントが発生します。 このイベントを処理し、プログラムによって、ホスト アプリケーションにフォーカスを設定できる次の要素にフォーカスを移動します。 たとえば、WPF アプリケーションで場所、 **DesktopWindowXamlSource**でホストされている、 [ **System.Windows.Interop.HwndHost**](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)、使用することができます、 [ **MoveFocus** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.movefocus)ホスト アプリケーションにフォーカスを設定できる次の要素にフォーカスを転送する方法。

これは実際のサンプル アプリケーションのコンテキストで実行する方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** 参照してください、 [WindowsXamlHostBase.Focus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Focus.cs) Windows コミュニティのツールキットでのファイル。  
  * **Windows フォーム:** 参照してください、 [WindowsXamlHostBase.KeyboardFocus.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.KeyboardFocus.cs) Windows コミュニティのツールキットでのファイル。

## <a name="how-to-handle-layout-changes"></a>レイアウトの変更を処理する方法

ユーザーが親の UI 要素のサイズを変更した UWP コントロールが期待どおりに表示していることを確認するために必要なレイアウト変更を処理する必要があります。 考慮すべき重要なシナリオを以下に示します。

1. 親の UI 要素が収まる四角形領域のサイズを取得する必要がある場合、 **Windows.UI.Xaml.UIElement**でホストしている、 **DesktopWindowXamlSource**を呼び出し、 [**メジャー** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.measure)のメソッド、 **Windows.UI.Xaml.UIElement**します。 次に、例を示します。
    * WPF アプリケーションでこれから行うことがあります、 [ **MeasureOverride** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.measureoverride)のメソッド、 [ **HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost)をホストする、 **DesktopWindowXamlSource**します。
    * Windows フォーム アプリケーションでこれから行うことがあります、 [ **GetPreferredSize** ](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.getpreferredsize)のメソッド、 [**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control) をホストする**DesktopWindowXamlSource**します。

2. 親の UI 要素のサイズが変更されたときに呼び出す、 [**配置**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.arrange)ルートのメソッド**Windows.UI.Xaml.UIElement**でホストしている、 **DesktopWindowXamlSource**します。 次に、例を示します。
    * WPF アプリケーションでこれから行うことがあります、 [ **ArrangeOverride** ](https://docs.microsoft.com/dotnet/api/system.windows.frameworkelement.arrangeoverride)のメソッド、 [ **HwndHost** ](https://docs.microsoft.com/dotnet/api/system.windows.interop.hwndhost) をホストしているオブジェクト**DesktopWindowXamlSource**します。
    * Windows フォーム アプリケーションでこれを行いますのハンドラーから、 [ **SizeChanged** ](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.sizechanged)のイベント、 [**コントロール**](https://docs.microsoft.com/dotnet/api/system.windows.forms.control)をホストする、**DesktopWindowXamlSource**します。

これは実際のサンプル アプリケーションのコンテキストで実行する方法を示す例については、次のコード ファイルを参照してください。
  * **WPF:** 参照してください、 [WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Wpf.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。  
  * **Windows フォーム:** 参照してください、 [WindowsXamlHost.Layout.cs](https://github.com/windows-toolkit/Microsoft.Toolkit.Win32/blob/master/Microsoft.Toolkit.Forms.UI.XamlHost/WindowsXamlHostBase.Layout.cs) Windows コミュニティのツールキットでのファイル。

## <a name="how-to-handle-dpi-changes"></a>DPI 変更を処理する方法

描画変換を UWP コントロールを構成するには、リッスン、アプリでの DPI 変更の必要があります (たとえば、ユーザーは、さまざまな画面の DPI のモニター間でウィンドウをドラッグした) 場合に、UWP が制御をホストするウィンドウの DPI 変更を処理する場合は、、DPI の変更に応答に UWP コントロールの変換をレンダリングおよびウィンドウの位置を更新します。

次の手順では、C++ の Win32 アプリケーションのコンテキストでは、このプロセスを処理する 1 つの方法を説明します。 完全な例を参照してください、 [Desktop.cpp](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.cpp)と[Desktop.h](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/Desktop.h)コード ファイルで、 [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32) GitHub のサンプルです。

1. 管理、 [ **ScaleTransform** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.scaletransform)アプリ内のオブジェクトし、それを割り当てる、 [ **RenderTransform** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.rendertransform) UWP コントロールのメソッド。 次の例は、 [ **Windows.UI.Xaml.Controls.Grid** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid) C++ の Win32 アプリケーションで制御します。

    ```cppwinrt
    // Private fields maintained by your app, such as in a window class you have defined.
    Windows::UI::Xaml::Media::ScaleTransform m_scale;
    Windows::UI::Xaml::Controls::Grid m_rootGrid;

    // Code that runs during initialization, such as the constructor for a window class you have defined.
    m_rootGrid.RenderTransform(m_scale);
    ```

2. [ **WindowProc** ](https://msdn.microsoft.com/library/windows/desktop/ms633573.aspx)関数をリッスン、 [ **WM_DPICHANGED** ](https://docs.microsoft.com/windows/desktop/hidpi/wm-dpichanged)メッセージ。 このメッセージに応答します。
    * 使用して、 [ **SetWindowPos** ](https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-setwindowpos)メッセージに渡される四角形に UWP コントロールを含むウィンドウのサイズを変更する関数。
    * X 軸と y 軸のスケールの要素の更新プログラム、 **ScaleTransform**オブジェクトに従って新しい DPI 値。
    * UWP コントロールのレイアウトと外観には、必要な調整を加えます。 次のコード例を調整、 [ **Padding** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid.padding)のホスト済み**Windows.UI.Xaml.Controls.Grid** DPI の変更に応答内のコントロール。

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

2. モニターごとの DPI に対応するアプリケーションを構成するには追加、[サイド バイ サイド アセンブリ マニフェスト](https://docs.microsoft.com/windows/desktop/SbsCs/application-manifests)にプロジェクトを設定し```<dpiAwareness>```要素を```PerMonitorV2```します。 この値の詳細については、の説明を参照してください。 [ **DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2**](https://docs.microsoft.com/windows/desktop/hidpi/dpi-awareness-context)します。

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

    サイド バイ サイド アセンブリ マニフェストの完全な例を参照してください、 [XamlIslandsWin32.exe.manifest](https://github.com/clarkezone/cppwinrt/blob/master/Desktop/XamlIslandsWin32/XamlIslandsWin32.exe.manifest)ファイル、 [XamlIslands32](https://github.com/clarkezone/cppwinrt/tree/master/Desktop/XamlIslandsWin32) GitHub のサンプルです。

## <a name="limitations"></a>制限事項

API をホストしている XAML では、Windows 10 用の XAML ホスト コントロールの他のすべての型と同じ制限を共有します。 詳細な一覧についてを参照してください。 [XAML ホスト コントロールの制限事項](xaml-host-controls.md#limitations)します。

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="error-using-uwp-xaml-hosting-api-in-a-uwp-app"></a>UWP アプリで API をホストしている UWP XAML を使用してエラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。"DesktopWindowXamlSource をアクティブ化できません。 この型では使用できません、UWP アプリです。" または、"WindowsXamlManager をアクティブ化できません。 この型では使用できません、UWP アプリです。" | このエラーは、API をホストしている UWP XAML を使用しようとしていることを示します (具体的には、インスタンスを作成しようとしてには、 [ **DesktopWindowXamlSource** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)または[ **WindowsXamlManager** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.windowsxamlmanager)型) で UWP アプリです。 API をホストしている UWP XAML の目的はのみ、非 UWP のデスクトップ アプリ、WPF、Windows フォーム、および C++ の Win32 アプリケーションで使用します。 |

### <a name="error-attaching-to-a-window-on-a-different-thread"></a>別のスレッドで、ウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。「AttachToWindow メソッドは、別のスレッドで、指定した HWND が作成されたために失敗しました」。 | このエラーは、アプリケーションと呼ばれることを示します、 **IDesktopWindowXamlSourceNative.AttachToWindow**メソッド別のスレッドが作成されているウィンドウの HWND が渡されます。 このメソッドにコードのメソッドを呼び出すことと同じスレッドが作成されているウィンドウの HWND を渡す必要があります。 |

### <a name="error-attaching-to-a-window-on-a-different-top-level-window"></a>別の最上位ウィンドウ上のウィンドウへのアタッチ エラー

| 問題 | 解決方法 |
|-------|------------|
| アプリが受け取る、 **COMException**次のメッセージ。「AttachToWindow メソッドは、同じスレッドで、AttachToWindow に渡された以前 HWND よりも、別の最上位ウィンドウから、指定した HWND が降下ために失敗しました」。 | このエラーは、アプリケーションと呼ばれることを示します、 **IDesktopWindowXamlSourceNative.AttachToWindow**メソッドで指定した期間よりも、別の最上位ウィンドウから下降ウィンドウの HWND を渡し、同じスレッドでは、このメソッドの呼び出し前です。</p></p>アプリケーションの呼び出し後**IDesktopWindowXamlSourceNative.AttachToWindow**特定のスレッドで他のすべての[ **DesktopWindowXamlSource** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.desktopwindowxamlsource)同じオブジェクトスレッドは、最初の呼び出しで渡された同じトップレベル ウィンドウの子孫である windows にのみアタッチできます**IDesktopWindowXamlSourceNative.AttachToWindow**します。 ときにすべて、 **DesktopWindowXamlSource**オブジェクトは特定のスレッドで、[次へ] を閉じる**DesktopWindowXamlSource**は無料で任意のウィンドウを再度アタッチします。</p></p>この問題を解決するには、いずれかを閉じますすべて**DesktopWindowXamlSource**このスレッドで他の最上位ウィンドウにバインドされているか、この新しいスレッドを作成するオブジェクト**DesktopWindowXamlSource**します。 |

## <a name="related-topics"></a>関連トピック

* [デスクトップ アプリケーションでの UWP コントロール](xaml-host-controls.md)
