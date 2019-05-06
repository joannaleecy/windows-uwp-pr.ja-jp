---
title: Win32 でのビジュアル層の使用
description: Win32 デスクトップ アプリの UI を強化するために、ビジュアル レイヤーを使用します。
template: detail.hbs
ms.date: 03/18/2019
ms.topic: article
keywords: UWP、レンダリング、合成、win32
ms.localizationpriority: medium
ms.openlocfilehash: cfaa0d19b7a7361c5d604636c30beda0f416d063
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174117"
---
# <a name="using-the-visual-layer-with-win32"></a>Win32 でのビジュアル層の使用

Windows ランタイムの合成 Api を使用することができます (とも呼ばれる、[ビジュアル層](visual-layer.md)) Win32 アプリを Windows 10 のユーザー用に光を最新のエクスペリエンスを作成します。

このチュートリアルの完成したコードは GitHub で入手できます。[Win32 HelloComposition サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/HelloComposition)します。

その UI コンポジションを正確に制御を必要とするユニバーサルの Windows アプリケーションへのアクセスがある、 [Windows.UI.Composition](/uwp/api/windows.ui.composition) UI の構成し、表示方法をきめ細かに制御する名前空間。 この合成 API はただしでは、UWP アプリに限定されません。 Win32 デスクトップ アプリケーションでは、UWP と Windows 10 の最新のコンポジション システムを利用できます。

## <a name="prerequisites"></a>前提条件

UWP API をホストしているが、これらの前提条件です。

- Win32 でも UWP を使用してアプリ開発の知識があると仮定します。 For more info, see:
  - [Win32 の概要とC++](/windows/desktop/learnwin32/learn-to-program-for-windows)
  - [Windows 10 アプリを概要します。](/windows/uwp/get-started/)
  - [Windows 10 のデスクトップ アプリケーションを拡張します。](/windows/uwp/porting/desktop-to-uwp-enhance)
- Windows 10 バージョン 1803 以降
- Windows 10 SDK 17134 またはそれ以降

## <a name="how-to-use-composition-apis-from-a-win32-desktop-application"></a>Win32 デスクトップ アプリケーションから合成 Api を使用する方法

このチュートリアルでは、単純な Win32 を作成C++アプリを UWP の合成要素を追加します。 焦点は正しく、プロジェクトの構成、相互運用機能のコードの作成、および Windows 合成 Api を使用して単純なものを描画します。 次のような完成したアプリが表示されます。

![実行中のアプリの UI](images/interop/win32-comp-interop-app-ui.png)

## <a name="create-a-c-win32-project-in-visual-studio"></a>作成、 C++ Visual Studio での Win32 プロジェクト

最初の手順では、Visual Studio で、Win32 アプリ プロジェクトを作成します。

新しい Win32 アプリケーション プロジェクトを作成するC++という_HelloComposition_:

1. Visual Studio を開き、選択**ファイル** > **新規** > **プロジェクト**します。

    **新しいプロジェクト**ダイアログ ボックスが開きます。
1. 下、**インストール済み**カテゴリで、展開、 **Visual C++** ノードをクリックして**Windows デスクトップ**します。
1. 選択、 **Windows デスクトップ アプリケーション**テンプレート。
1. 名前を入力します_HelloComposition_、 をクリックし、 **OK**します。

    Visual Studio では、プロジェクトを作成し、メイン アプリケーション ファイルのエディターを開きます。

## <a name="configure-the-project-to-use-windows-runtime-apis"></a>Windows ランタイム Api を使用してプロジェクトを構成します。

使用して Windows ランタイム (WinRT) アプリの Win32 Api を使用するC++/WinRT です。 追加する Visual Studio プロジェクトを構成する必要があるC++/WinRT サポートします。

(詳細については、次を参照してください。[概要C++/WinRT - 追加する Windows デスクトップ アプリケーション プロジェクトを変更するC++/WinRT サポート](../cpp-and-winrt-apis/get-started.md#modify-a-windows-desktop-application-project-to-add-cwinrt-support))。

1. **プロジェクト**] メニューの [プロジェクトのプロパティを開きます (_HelloComposition プロパティ_) を指定した値に設定は、次の設定を確認してください。

    - **構成**、_すべての構成_します。 **プラットフォーム**、_すべてのプラットフォーム_します。
    - **構成プロパティ** > **全般** > **Windows SDK バージョン** = _10.0.17763.0_以上

    ![SDK バージョンを設定](images/interop/sdk-version.png)

    - **C/C++** > **言語** >   **C++言語標準** = _ISO C++ 17 標準 (/stf:c + + 17)_

    ![標準的な言語を設定します。](images/interop/language-standard.png)

    - **リンカー** > **入力** > **追加の依存関係**含める必要があります"_windowsapp.lib_"。 これは、一覧に含まれていませんを追加します。

    ![リンカーの依存関係を追加します。](images/interop/linker-dependencies.png)

1. プリコンパイル済みヘッダーを更新します。

    - 名前を変更`stdafx.h`と`stdafx.cpp`に`pch.h`と`pch.cpp`、それぞれします。
    - プロジェクトのプロパティを設定**C/C++** > **プリコンパイル済みヘッダー** > **プリコンパイル済みヘッダー ファイル**に*pch.h*します。
    - 検索し、置換`#include "stdafx.h"`で`#include "pch.h"`ですべてのファイル。

        (**編集** > **検索し、置換** > **ファイル内の検索**)

        ![検索し、置換 stdafx.h](images/interop/replace-stdafx.png)

    - `pch.h`、含める`winrt/base.h`と`unknwn.h`します。

        ```cppwinrt
        // reference additional headers your program requires here
        #include <unknwn.h>
        #include <winrt/base.h>
        ```

進む前にエラーがないかどうかを確認するには、この時点でプロジェクトをビルドすることをお勧めします。

## <a name="create-a-class-to-host-composition-elements"></a>ホストの合成要素のクラスを作成します。

コンテンツのホストにビジュアル層で作成、クラスを作成 (_CompositionHost_) を相互運用機能を管理し、合成要素を作成します。 これは、構成などの合成 Api をホストするための大部分を実行します。

- 取得、[コンポジター](/uwp/api/windows.ui.composition.compositor)が作成され、オブジェクトを管理、 [Windows.UI.Composition](/uwp/api/windows.ui.composition)名前空間。
- 作成、 [DispatcherQueueController](/uwp/api/windows.system.dispatcherqueuecontroller)/[DispatcherQueue](/uwp/api/windows.system.dispatcherqueue) WinRT Api のタスクを管理します。
- 作成、 [DesktopWindowTarget](/uwp/api/windows.ui.composition.desktop.desktopwindowtarget)と合成オブジェクトを表示する合成コンテナー。

このクラスをシングルトン スレッド処理の問題を回避すること。 たとえば、CompositionHost のと同じスレッド上の 2 番目のインスタンスをインスタンス化すると、エラーが発生するは、スレッドあたりの 1 つのディスパッチャー キューのみ作成します。

> [!TIP]
> 必要がある場合は、すべてのコードは、チュートリアルを使用すると適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。

1. プロジェクトに新しいクラス ファイルを追加します。
    - **ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。
    - コンテキスト メニューで選択**追加** > **クラス.**.
    - **クラスの追加**ダイアログ ボックスで、クラス名_CompositionHost.cs_、 をクリックし、**追加**します。

1. ヘッダーを含めると_using_合成相互運用機能に必要な。
    - CompositionHost.h でこれらの追加_が含まれています_ファイルの上部にあります。

    ```cppwinrt
    #pragma once
    #include <winrt/Windows.UI.Composition.Desktop.h>
    #include <windows.ui.composition.interop.h>
    #include <DispatcherQueue.h>
    ```

    - CompositionHost.cpp でこれらの追加_using_後に、ファイルの上部にある_が含まれています_します。

    ```cppwinrt
    using namespace winrt;
    using namespace Windows::System;
    using namespace Windows::UI;
    using namespace Windows::UI::Composition;
    using namespace Windows::UI::Composition::Desktop;
    using namespace Windows::Foundation::Numerics;
    ```

1. シングルトン パターンを使用するクラスを編集します。
    - CompositionHost.h でプライベート コンストラクターを確認します。
    - 宣言のパブリック静的_GetInstance_メソッド。

    ```cppwinrt
    class CompositionHost
    {
    public:
        ~CompositionHost();
        static CompositionHost* GetInstance();

    private:
        CompositionHost();
    };
    ```

    - CompositionHost.cpp、追加の定義、 _GetInstance_メソッド。

    ```cppwinrt
    CompositionHost* CompositionHost::GetInstance()
    {
        static CompositionHost instance;
        return &instance;
    }
    ```

1. CompositionHost.h には、変数のプライベート メンバーを宣言、コンポジター、DispatcherQueueController、および DesktopWindowTarget。

    ```cppwinrt
    winrt::Windows::UI::Composition::Compositor m_compositor{ nullptr };
    winrt::Windows::System::DispatcherQueueController m_dispatcherQueueController{ nullptr };
    winrt::Windows::UI::Composition::Desktop::DesktopWindowTarget m_target{ nullptr };
    ```

1. 合成相互運用オブジェクトを初期化するためにパブリック メソッドを追加します。
    > [!NOTE]
    > _初期化_、呼び出すことが、 _EnsureDispatcherQueue_、 _CreateDesktopWindowTarget_、および_CreateCompositionRoot_メソッド。 次の手順では、これらのメソッドを作成します。

    - という名前のパブリック メソッドを宣言で CompositionHost.h、_初期化_を引数として、HWND を受け取る。

    ```cppwinrt
    void Initialize(HWND hwnd);
    ```

    - CompositionHost.cpp、追加の定義、_初期化_メソッド。

    ```cppwinrt
    void CompositionHost::Initialize(HWND hwnd)
    {
        EnsureDispatcherQueue();
        if (m_dispatcherQueueController) m_compositor = Compositor();

        CreateDesktopWindowTarget(hwnd);
        CreateCompositionRoot();
    }
    ```

1. Windows 合成を使用するスレッドのディスパッチャー キューを作成します。

    ディスパッチャー キューを持つため、このメソッドは 1 つ目の初期化中にスレッドには、コンポジターを作成する必要があります。

    - という名前のプライベート メソッドを宣言で CompositionHost.h、 _EnsureDispatcherQueue_します。

    ```cppwinrt
    void EnsureDispatcherQueue();
    ```

    - CompositionHost.cpp、追加の定義、 _EnsureDispatcherQueue_メソッド。

    ```cppwinrt
    void CompositionHost::EnsureDispatcherQueue()
    {
        namespace abi = ABI::Windows::System;

        if (m_dispatcherQueueController == nullptr)
        {
            DispatcherQueueOptions options
            {
                sizeof(DispatcherQueueOptions), /* dwSize */
                DQTYPE_THREAD_CURRENT,          /* threadType */
                DQTAT_COM_ASTA                  /* apartmentType */
            };

            Windows::System::DispatcherQueueController controller{ nullptr };
            check_hresult(CreateDispatcherQueueController(options, reinterpret_cast<abi::IDispatcherQueueController**>(put_abi(controller))));
            m_dispatcherQueueController = controller;
        }
    }
    ```

1. 合成ターゲットとしては、アプリのウィンドウを登録します。
    - という名前のプライベート メソッドを宣言で CompositionHost.h、 _CreateDesktopWindowTarget_を引数として、HWND を受け取る。

    ```cppwinrt
    void CreateDesktopWindowTarget(HWND window);
    ```

    - CompositionHost.cpp、追加の定義、 _CreateDesktopWindowTarget_メソッド。

    ```cppwinrt
    void CompositionHost::CreateDesktopWindowTarget(HWND window)
    {
        namespace abi = ABI::Windows::UI::Composition::Desktop;

        auto interop = m_compositor.as<abi::ICompositorDesktopInterop>();
        DesktopWindowTarget target{ nullptr };
        check_hresult(interop->CreateDesktopWindowTarget(window, false, reinterpret_cast<abi::IDesktopWindowTarget**>(put_abi(target))));
        m_target = target;
    }
    ```

1. ビジュアル オブジェクトを保持するためにルート ビジュアル コンテナーを作成します。
    - という名前のプライベート メソッドを宣言で CompositionHost.h、 _CreateCompositionRoot_します。

    ```cppwinrt
    void CreateCompositionRoot();
    ```

    - CompositionHost.cpp、追加の定義、 _CreateCompositionRoot_メソッド。

    ```cppwinrt
    void CompositionHost::CreateCompositionRoot()
    {
        auto root = m_compositor.CreateContainerVisual();
        root.RelativeSizeAdjustment({ 1.0f, 1.0f });
        root.Offset({ 24, 24, 0 });
        m_target.Root(root);
    }
    ```

エラーがないかどうかを確認するには、現在のプロジェクトをビルドします。

これらのメソッドは、ビジュアル層の UWP と Win32 Api の間の相互運用機能に必要なコンポーネントを設定します。 これで、アプリにコンテンツを追加できます。

### <a name="add-composition-elements"></a>合成要素を追加します。

インフラストラクチャを導入するに表示する合成コンテンツを生成できます。

この例では、単純な四角形を作成するコードを追加する[SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)します。

1. 合成要素を追加します。
    - CompositionHost.h でという名前のパブリック メソッドを宣言_AddElement_を受け取る 3 **float**引数として値。

    ```cppwinrt
    void AddElement(float size, float x, float y);
    ```

    - CompositionHost.cpp、追加の定義、 _AddElement_メソッド。

    ```cppwinrt
    void CompositionHost::AddElement(float size, float x, float y)
    {
        if (m_target.Root())
        {
            auto visuals = m_target.Root().as<ContainerVisual>().Children();
            auto visual = m_compositor.CreateSpriteVisual();

            visual.Brush(m_compositor.CreateColorBrush({ 0xDC, 0x5B, 0x9B, 0xD5 }));
            visual.Size({ size, size });
            visual.Offset({ x, y, 0.0f, });

            visuals.InsertAtTop(visual);
        }
    }
    ```

## <a name="create-and-show-the-window"></a>作成し、ウィンドウを表示します。

ここで、UWP コンポジションのコンテンツを Win32 の UI に追加できます。 使用して、アプリケーションの_InitInstance_ Windows 合成を初期化し、コンテンツを生成するメソッド。

1. HelloComposition.cpp、含める_CompositionHost.h_ファイルの上部にあります。

    ```cppwinrt
    #include "CompositionHost.h"
    ```

1. `InitInstance`メソッドの初期化し、CompositionHost クラスを使用するコードを追加します。

    HWND が作成されると呼び出しの前に、次のコードを追加`ShowWindow`します。

    ```cppwinrt
    CompositionHost* compHost = CompositionHost::GetInstance();
    compHost->Initialize(hWnd);
    compHost->AddElement(150, 10, 10);
    ```

ビルドして、アプリを実行することができますようになりました。 必要がある場合は、すべてのコードは、適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。

アプリを実行するときに、UI に追加、青い四角形が表示されます。

## <a name="additional-resources"></a>その他の資料

- [Win32 HelloComposition サンプル (GitHub)](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/cpp/HelloComposition)
- [Win32 の概要とC++](/windows/desktop/learnwin32/learn-to-program-for-windows)
- [Windows 10 アプリの概要](/windows/uwp/get-started/)(UWP)
- [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)(UWP)
- [名前空間の Windows.UI.Composition](/uwp/api/windows.ui.composition) (UWP)

## <a name="complete-code"></a>コードを完成させる

CompositionHost クラスと InitInstance メソッドの完全なコードを次に示します。

### <a name="compositionhosth"></a>CompositionHost.h

```cppwinrt
#pragma once
#include <winrt/Windows.UI.Composition.Desktop.h>
#include <windows.ui.composition.interop.h>
#include <DispatcherQueue.h>

class CompositionHost
{
public:
    ~CompositionHost();
    static CompositionHost* GetInstance();

    void Initialize(HWND hwnd);
    void AddElement(float size, float x, float y);

private:
    CompositionHost();

    void CreateDesktopWindowTarget(HWND window);
    void EnsureDispatcherQueue();
    void CreateCompositionRoot();

    winrt::Windows::UI::Composition::Compositor m_compositor{ nullptr };
    winrt::Windows::UI::Composition::Desktop::DesktopWindowTarget m_target{ nullptr };
    winrt::Windows::System::DispatcherQueueController m_dispatcherQueueController{ nullptr };
};
```

### <a name="compositionhostcpp"></a>CompositionHost.cpp

```cppwinrt
#include "pch.h"
#include "CompositionHost.h"

using namespace winrt;
using namespace Windows::System;
using namespace Windows::UI;
using namespace Windows::UI::Composition;
using namespace Windows::UI::Composition::Desktop;
using namespace Windows::Foundation::Numerics;

CompositionHost::CompositionHost()
{
}

CompositionHost* CompositionHost::GetInstance()
{
    static CompositionHost instance;
    return &instance;
}

CompositionHost::~CompositionHost()
{
}

void CompositionHost::Initialize(HWND hwnd)
{
    EnsureDispatcherQueue();
    if (m_dispatcherQueueController) m_compositor = Compositor();

    if (m_compositor)
    {
        CreateDesktopWindowTarget(hwnd);
        CreateCompositionRoot();
    }
}

void CompositionHost::EnsureDispatcherQueue()
{
    namespace abi = ABI::Windows::System;

    if (m_dispatcherQueueController == nullptr)
    {
        DispatcherQueueOptions options
        {
            sizeof(DispatcherQueueOptions), /* dwSize */
            DQTYPE_THREAD_CURRENT,          /* threadType */
            DQTAT_COM_ASTA                  /* apartmentType */
        };

        Windows::System::DispatcherQueueController controller{ nullptr };
        check_hresult(CreateDispatcherQueueController(options, reinterpret_cast<abi::IDispatcherQueueController**>(put_abi(controller))));
        m_dispatcherQueueController = controller;
    }
}

void CompositionHost::CreateDesktopWindowTarget(HWND window)
{
    namespace abi = ABI::Windows::UI::Composition::Desktop;

    auto interop = m_compositor.as<abi::ICompositorDesktopInterop>();
    DesktopWindowTarget target{ nullptr };
    check_hresult(interop->CreateDesktopWindowTarget(window, false, reinterpret_cast<abi::IDesktopWindowTarget**>(put_abi(target))));
    m_target = target;
}

void CompositionHost::CreateCompositionRoot()
{
    auto root = m_compositor.CreateContainerVisual();
    root.RelativeSizeAdjustment({ 1.0f, 1.0f });
    root.Offset({ 24, 24, 0 });
    m_target.Root(root);
}

void CompositionHost::AddElement(float size, float x, float y)
{
    if (m_target.Root())
    {
        auto visuals = m_target.Root().as<ContainerVisual>().Children();
        auto visual = m_compositor.CreateSpriteVisual();

        visual.Brush(m_compositor.CreateColorBrush({ 0xDC, 0x5B, 0x9B, 0xD5 }));
        visual.Size({ size, size });
        visual.Offset({ x, y, 0.0f, });

        visuals.InsertAtTop(visual);
    }
}
```

### <a name="hellocompositioncpp---initinstance"></a>HelloComposition.cpp - InitInstance

```cppwinrt
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   CompositionHost* compHost = CompositionHost::GetInstance();
   compHost->Initialize(hWnd);
   compHost->AddElement(150, 10, 10);

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}
```