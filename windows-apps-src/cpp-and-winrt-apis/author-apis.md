---
author: stevewhims
description: このトピックでは、直接的または間接的に **winrt::implements** 基本構造体を使用して、C++/WinRT API を作成する方法を示します。
title: C++/WinRT での API の作成
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 標準, c++, cpp, winrt, 投影された, プロジェクション, 実装, インプリメント, ランタイム クラス, ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: 2476161954c1d4d49fcf9f8f74cd1b7cf9180c0a
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4533716"
---
# <a name="author-apis-with-cwinrt"></a>C++/WinRT での API の作成

このトピックでは、作成する方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)直接的または間接的に[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)を使用して、Api 基本構造体をします。 このコンテキストで*作成者*の同義語は、*生成*、または*実装*です。 このトピックでは、C++/WinRT で API を実装するために、次のシナリオをこの順序で説明します。

- Windows ランタイム クラス (ランタイム クラス) は作成*しません*。アプリ内でのローカルの使用のために 1 つまたは複数の Windows ランタイム インターフェイスを実装するだけです。 この場合、**winrt::implements** から直接派生し、機能を実装します。
- ランタイム クラスを作成*します*。 アプリで使用するコンポーネントを作成している場合があります。 または、XAML ユーザー インターフェイス (UI) で使用する型を作成していることがあり、その場合は両方を実装して、同じのコンパイル ユニット内のランタイム クラスを使用しています。 このような場合、ツールで **winrt::implements** から派生するクラスを生成することができます。

どちらの場合も、C++/WinRT API を実装する型は、*実装型*と呼ばれます。

> [!IMPORTANT]
> 実装型の概念を投影型と区別することは重要です。 投影型については、「[C++/WinRT での API の使用](consume-apis.md)」で説明します。

## <a name="if-youre-not-authoring-a-runtime-class"></a>ランタイム クラスを作成*していない*場合
最も単純なシナリオは、ローカル使用のための Windows ランタイム インターフェイスを実装しているケースです。 ランタイム クラスは必要ありません。通常の C++ のクラスだけです。 たとえば、[**CoreApplication**](/uwp/api/windows.applicationmodel.core.coreapplication) に基づいてアプリを記述している場合があります。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

Visual Studio で、 **Visual C** > **Windows ユニバーサル** > **コア アプリ (、C++/WinRT)** プロジェクト テンプレートは、 **CoreApplication**パターンを示しています。 パターンは、[**Windows::ApplicationModel::Core::IFrameworkViewSource**](/uwp/api/windows.applicationmodel.core.iframeworkviewsource) の実装を [**coreapplication::run**](/uwp/api/windows.applicationmodel.core.coreapplication.run) に渡して開始します。

```cppwinrt
using namespace Windows::ApplicationModel::Core;
int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    IFrameworkViewSource source = ...
    CoreApplication::Run(source);
}
```

**CoreApplication** はインターフェイスを使用してアプリの最初のビューを作成します。 概念的には、**IFrameworkViewSource** は次のように見えます。

```cppwinrt
struct IFrameworkViewSource : IInspectable
{
    IFrameworkView CreateView();
};
```

さらに、概念的には、**CoreApplication::run** の実装は次のように見えます。

```cppwinrt
void Run(IFrameworkViewSource viewSource) const
{
    IFrameworkView view = viewSource.CreateView();
    ...
}
```

したがって、開発者は、**IFrameworkViewSource** インターフェイスを実装します。 C++/WinRT には、基本構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) があり、COM スタイルのプログラミングを使用せずにインターフェイス (1 つまたは複数) を簡単に実装することができます。 **実装**から型を派生して、インターフェイスの機能を実装するだけです。 以下にその方法を示します。

```cppwinrt
// App.cpp
...
struct App : implements<App, IFrameworkViewSource>
{
    IFrameworkView CreateView()
    {
        return ...
    }
}
...
```

**IFrameworkViewSource** に対応済みです。 次に、**IFrameworkView** インターフェイスを実装するオブジェクトを返します。 **アプリ**上にそのインターフェイスを実装することも選択できます。 次のコード例は、少なくともウィンドウを起動してデスクトップ上で実行する最小限のアプリを表します。

```cppwinrt
// App.cpp
...
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    IFrameworkView CreateView()
    {
        return *this;
    }

    void Initialize(CoreApplicationView const &) {}

    void Load(hstring const&) {}

    void Run()
    {
        CoreWindow window = CoreWindow::GetForCurrentThread();
        window.Activate();

        CoreDispatcher dispatcher = window.Dispatcher();
        dispatcher.ProcessEvents(CoreProcessEventsOption::ProcessUntilQuit);
    }

    void SetWindow(CoreWindow const & window)
    {
        // Prepare app visuals here
    }

    void Uninitialize() {}
};
...
```

**アプリ**型*が ***IFrameworkViewSource** であるため、**Run** に渡すことだけができます。

```cppwinrt
using namespace Windows::ApplicationModel::Core;
int __stdcall wWinMain(HINSTANCE, HINSTANCE, PWSTR, int)
{
    CoreApplication::Run(App{});
}
```

## <a name="if-youre-authoring-a-runtime-class-in-a-windows-runtime-component"></a>Windows ランタイム コンポーネントでランタイム クラスを作成する場合
型が、アプリケーションから使用する Windows ランタイム コンポーネントにパッケージ化されている場合は、ランタイム クラスである必要があります。

> [!TIP]
> インターフェイス定義言語 (IDL) ファイルを編集するときに、ビルドのパフォーマンスを最適化するために、また IDL からその生成されたソース コード ファイルへの論理的な通信手段のために、各ランタイム クラスを独自の IDL (.idl) ファイル内で宣言することをお勧めします。 Visual Studio では、生成されるすべての `.winmd` ファイルをルート名前空間と同じ名前の単一のファイルにマージします。 その最終的な `.winmd` ファイルが、コンポーネントのユーザーが参照するファイルになります。

次に例を示します。

```idl
// MyRuntimeClass.idl
namespace MyProject
{
    runtimeclass MyRuntimeClass
    {
        // Declaring a constructor (or constructors) in the IDL causes the runtime class to be
        // activatable from outside the compilation unit.
        MyRuntimeClass();
        String Name;
    }
}
```

この IDL では、Windows ランタイム (ランタイム) クラスを宣言します。 ランタイム クラスは、通常実行可能な境界を越えて、モダン COM インターフェイス経由でアクティブ化および使用可能な型です。 プロジェクトに IDL ファイルを追加し、ビルドすると、C++/WinRT ツールチェーン (`midl.exe` および `cppwinrt.exe`) が実装型を生成します。 上記の IDL の例を使用すると、実装型は、`\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` と `MyRuntimeClass.cpp` という名前のソース コード ファイルの **winrt::MyProject::implementation::MyRuntimeClass** という名前の C++ 構造体スタブです。

実装型は次のようになります。

```cppwinrt
// MyRuntimeClass.h
...
namespace winrt::MyProject::implementation
{
    struct MyRuntimeClass : MyRuntimeClassT<MyRuntimeClass>
    {
        MyRuntimeClass() = default;

        hstring Name();
        void Name(hstring const& value);
    };
}

// winrt::MyProject::factory_implementation::MyRuntimeClass is here, too.
```

使用されている F バインド ポリモーフィズム パターンに注意してください (**MyRuntimeClass** は、その基本である **MyRuntimeClassT** へのテンプレート引数としてそれ自体を使用します)。 これは、CRTP (curiously recurring template pattern (奇妙に再帰したテンプレート パターン)) とも呼ばれます。 上方向に継承チェーンをたどると、**MyRuntimeClass_base** が見つかります。

```cppwinrt
template <typename D, typename... I>
struct MyRuntimeClass_base : implements<D, MyProject::IMyRuntimeClass, I...>
```

そのため、このシナリオでは、継承のルートの階層はもう一度 [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体のテンプレートです。

詳細、コード、および Windows ランタイム コンポーネントの API の作成に関するチュートリアルについては、「[C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)」を参照してください。

## <a name="if-youre-authoring-a-runtime-class-to-be-referenced-in-your-xaml-ui"></a>XAML UI で参照されるランタイム クラスを作成する場合
型が XAML UI によって参照される場合、XAML と同じプロジェクトになっていても、ランタイム クラスである必要があります。 通常は実行可能な境界を越えてアクティブ化されますが、ランタイム クラスでは、代わりにそれを実装するコンパイル ユニット内で使用できます。

このシナリオでは、API を使用する * および * のどちらも作成します。 ランタイム クラスを実装するための手順は、Windows ランタイム コンポーネントと基本的に同じです。 このため、前のセクション [Windows ランタイム コンポーネントでランタイム クラスを作成する場合](#if-youre-authoring-a-runtime-class-in-a-windows-runtime-component)を参照してください。 これと唯一異なる詳細な点は、IDL から、C++/WinRT ツールチェーンが、実装型だけでなく投影型も生成することです。 このシナリオでは "**MyRuntimeClass**" というだけではあいまいなことを理解することは重要です。これは、その名前を持つさまざまな種類の複数のエンティティがあるためです。

- **MyRuntimeClass** はランタイム クラスの名前です。 ただし、これは実際には IDL で宣言され、一部のプログラミング言語で実装されたアブストラクションです。
- **MyRuntimeClass** は、C++ 構造体 **winrt::MyProject::implementation::MyRuntimeClass** の名前です。これはランタイム クラスの C++/WinRT の実装です。 すでに見たように、プロジェクトを別に実装および使用している場合、この構造体は実装しているプロジェクトにのみ存在します。 これは*実装型*、または*実装*です。 この型は、(`cppwinrt.exe` ツールによって) ファイル `\MyProject\MyProject\Generated Files\sources\MyRuntimeClass.h` と `MyRuntimeClass.cpp` で生成されます。
- **MyRuntimeClass** は C++ 構造体 **winrt::MyProject::MyRuntimeClass** の形式の投影型の名前です。 プロジェクトを別に実装および使用している場合、この構造体は使用しているプロジェクトにのみ存在します。 これは*投影型*、または*投影*です。 この型は、(`cppwinrt.exe` によって) ファイル `\MyProject\MyProject\Generated Files\winrt\impl\MyProject.2.h` で生成されます。

![投影型と実装型](images/myruntimeclass.png)

このトピックに関連する投影型の一部を次に示します。

```cppwinrt
// MyProject.2.h
...
namespace winrt::MyProject
{
    struct MyRuntimeClass : MyProject::IMyRuntimeClass
    {
        MyRuntimeClass(std::nullptr_t) noexcept {}
        MyRuntimeClass();
    };
}
```

ランタイム クラスで **INotifyPropertyChanged** インターフェイスを実装する例のチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」を参照してください。

このシナリオでランタイム クラスを使用するための手順は、「[C++/WinRT での API の使用](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project)」で説明しています。

## <a name="runtime-class-constructors"></a>ランタイム クラスのコンストラクター
上記で見た一覧から除くためのポイントを次に示します。

- 各コンストラクターを IDL で宣言することで、コンストラクターは実装型と投影型の両方で生成されます。 IDL で宣言したコンストラクターは、*別の*コンパイル ユニットからランタイム クラスを使用するために使用されます。
- コンストラクターを IDL で宣言してもしなくても、`nullptr_t` をとるコンストラクターのオーバーロードは投影型で生成されます。 `nullptr_t` コンストラクターの呼び出しは、*同じ*コンパイル ユニットからのランタイム クラスの使用における *2 つの手順のうちの最初の手順*です。 詳細とコード例については、「[C++/WinRT での API の使用](consume-apis.md#if-the-api-is-implemented-in-the-consuming-project)」を参照してください。
- *同じ*コンパイル ユニットからランタイム クラスを使用している場合、(`MyRuntimeClass.h` の) 実装型で非既定のコンストラクターを直接実装することもできます。

> [!NOTE]
> ランタイム クラスが別のコンパイル ユニットから使用することが予測される場合は (これは一般的です)、IDL にコンストラクター (少なくとも既定のコンストラクター) を含めます。 これを行うことで、実装型とともにファクトリの実装も取得します。
> 
> 同じコンパイル ユニット内でのみランタイム クラスを作成および使用する場合は、IDL でコンストラクターを宣言しないでください。 ファクトリの実装は不要であり、生成されません。 実装型の既定のコンストラクターが削除されますが、簡単に編集して、代わりに既定にすることができます。
> 
> 同じコンパイル ユニット内でのみランタイム クラスを作成および使用する場合は、コンストラクターのパラメーターが必要であり、実装型で直接必要なコンストラクターを作成します。

## <a name="instantiating-and-returning-implementation-types-and-interfaces"></a>実装型とインターフェイスをインスタンス化して返す
このセクションでは、[**IStringable**](/uwp/api/windows.foundation.istringable) および [**IClosable**](/uwp/api/windows.foundation.iclosable) インターフェイスを実装する、**MyType** という名前の実装型を例として見ていきましょう。

[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) から直接 **MyType** を派生できます (ランタイム クラスではありません)。

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

struct MyType : implements<MyType, IStringable, IClosable>
{
    winrt::hstring ToString(){ ... }
    void Close(){}
};
```

または IDL から生成することができます (これはランタイム クラスです)。

```idl
// MyType.idl
namespace MyProject
{
    runtimeclass MyType: Windows.Foundation.IStringable, Windows.Foundation.IClosable
    {
        MyType();
    }    
}
```

**MyType** から、プロジェクションの一部として使用するまたは返すことができる **IStringable** または **IClosable** オブジェクトへ移動するには、[**winrt::make**](/uwp/cpp-ref-for-winrt/make) 関数テンプレートを呼び出すことができます。 **ように**実装型の既定のインターフェイスを返します。

```cppwinrt
IStringable istringable = winrt::make<MyType>();
```

> [!NOTE]
> ただし、XAML UI から型を参照している場合は、同じプロジェクト内に実装型と投影型の両方があります。 その場合は、**作成**投影型のインスタンスを返します。 そのシナリオのコード例については、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」を参照してください。

**IStringable** インターフェイスのメンバーを呼び出すには (上記のコード例の場合) `istringable` のみ使用できます。 ただし C++/WinRT インターフェイス (投影されたインターフェイス) は [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown) から派生します。 そのため、他の投影型またはインターフェイスも使うかを返す[**iunknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) (または[**iunknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)) にクエリを呼び出すことができます。

```cppwinrt
istringable.ToString();
IClosable iclosable = istringable.as<IClosable>();
iclosable.Close();
```

すべての実装のメンバーにアクセスし、後でインターフェイスを呼び出し元に返す必要がある場合、[**winrt::make_self**](/uwp/cpp-ref-for-winrt/make-self) 関数テンプレートを使用します。 **make_self** は、実装型をラッピングする [**winrt::com_ptr**](/uwp/cpp-ref-for-winrt/com-ptr) を返します。 (矢印演算子を使用して) そのインターフェイスのすべてのメンバーにアクセスすることができます。これをそのまま呼び出し元に返すか、またはそこで **as** を呼び出して結果として得られるインターフェイス オブジェクトを呼び出し元に返します。

```cppwinrt
winrt::com_ptr<MyType> myimpl = winrt::make_self<MyType>();
myimpl->ToString();
myimpl->Close();
IClosable iclosable = myimpl.as<IClosable>();
iclosable.Close();
```

**MyType** クラスは、プロジェクションの一部ではなく、実装です。 ただしこの方法では、仮想関数呼び出しのオーバーヘッドがなく、その実装メソッドを直接呼び出すことができます。 上記の例では、**MyType::ToString** が **IStringable** で投影されたメソッドと同じ署名を使用するにもかかわらず、アプリケーション バイナリ インターフェイス (ABI) を交差することなく非仮想メソッドを直接呼び出しています。 **Com_ptr** は **MyType** 構造体へのポインターを保持するだけであるため、`myimpl` 変数と矢印演算子を介して、**MyType** の他の内部の詳細にもアクセスできます。

インターフェイス オブジェクトの場合があり、実装上のインターフェイスが分かる場合、に戻ることが[**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self)関数テンプレートを使用して実装します。 もう一度、これは仮想関数の呼び出しを回避し、実装で直接取得することができる手法です。

> [!NOTE]
> [**Winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi) [**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self)ではなくを呼び出す必要がありますし、後で、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールしていない場合。

次に例を示します。 [ **BgLabelControl**カスタム コントロール クラスの実装](xaml-cust-ctrl.md#implement-the-bglabelcontrol-custom-control-class)には、別の例があります。

```cppwinrt
void ImplFromIClosable(IClosable const& from)
{
    MyType* myimpl = winrt::get_self<MyType>(from);
    myimpl->ToString();
    myimpl->Close();
}
```

ただし元のインターフェイス オブジェクトのみ参照に保持されます。 ** これを保持する場合は、[**com_ptr::copy_from**](/uwp/cpp-ref-for-winrt/com-ptr#comptrcopyfrom-function) を呼び出すことができます。

```cppwinrt
winrt::com_ptr<MyType> impl;
impl.copy_from(winrt::get_self<MyType>(from));
// com_ptr::copy_from ensures that AddRef is called.
```

実装型自体は、**winrt::Windows::Foundation::IUnknown** から派生したものではないため、**as** 関数はありません。 その場合でも、1 つのインスタンスを作成し、そのインターフェイスのすべてのメンバーにアクセスできます。 ただしこれを行う場合、未処理の実装型のインスタンスを呼び出し元に返さないでください。 代わりに、前に示した手法のいずれかを使用して、投影されるインターフェイスまたは **com_ptr** を返します。

```cppwinrt
MyType myimpl;
myimpl.ToString();
myimpl.Close();
IClosable ic1 = myimpl.as<IClosable>(); // error
```

実装型のインスタンスがある場合は、対応する投影型を想定している関数にこれを渡す必要があり、その後実行できます。 実装型に存在する変換演算子 (実装型がによって生成された、`cppwinrt.exe`ツール) によりこのできます。

## <a name="deriving-from-a-type-that-has-a-non-default-constructor"></a>既定以外のコンス トラクターを持つ型からの派生
[**ToggleButtonAutomationPeer::ToggleButtonAutomationPeer(ToggleButton)**](/uwp/api/windows.ui.xaml.automation.peers.togglebuttonautomationpeer.-ctor#Windows_UI_Xaml_Automation_Peers_ToggleButtonAutomationPeer__ctor_Windows_UI_Xaml_Controls_Primitives_ToggleButton_)は、既定以外のコンス トラクターの例を示します。 既定のコンストラクターがないので、**ToggleButtonAutomationPeer** を作成するには、*オーナー* に渡す必要があります。 したがって、**ToggleButtonAutomationPeer** から派生する場合、*オーナー* を受け取りベースに渡すコンストラクターを提供する必要があります。 実際には次のようになります。

```idl
// MySpecializedToggleButton.idl
namespace MyNamespace
{
    runtimeclass MySpecializedToggleButton :
        Windows.UI.Xaml.Controls.Primitives.ToggleButton
    {
        ...
    };
}
```

```idl
// MySpecializedToggleButtonAutomationPeer.idl
namespace MyNamespace
{
    runtimeclass MySpecializedToggleButtonAutomationPeer :
        Windows.UI.Xaml.Automation.Peers.ToggleButtonAutomationPeer
    {
        MySpecializedToggleButtonAutomationPeer(MySpecializedToggleButton owner);
    };
}
```

実装型の生成されるコンストラクターは次のようになります。

```cppwinrt
// MySpecializedToggleButtonAutomationPeer.cpp
...
MySpecializedToggleButtonAutomationPeer::MySpecializedToggleButtonAutomationPeer
    (MyNamespace::MySpecializedToggleButton const& owner)
{
    ...
}
...
```

唯一のない部分は、基底クラスにコンストラクター パラメーターを渡す必要があることです。 上述の F バインド ポリモーフィズム パターンを覚えていますか。 C++/WinRT で使われるそのパターンの詳細を理解したら、基底クラスと呼ばれるものが何かを理解することができます (または実装クラスのヘッダー ファイルだけを参照することができます)。 これは、このケースで基底クラス コンストラクターを呼び出す方法です。

```cppwinrt
// MySpecializedToggleButtonAutomationPeer.cpp
...
MySpecializedToggleButtonAutomationPeer::MySpecializedToggleButtonAutomationPeer
    (MyNamespace::MySpecializedToggleButton const& owner) : 
    MySpecializedToggleButtonAutomationPeerT<MySpecializedToggleButtonAutomationPeer>(owner)
{
    ...
}
...
```

基底クラス コンストラクターは、**ToggleButton** を期待します。 そして **MySpecializedToggleButton*** は ***ToggleButton** です。

(基底クラスにコンストラクター パラメーターを渡すために) 上記で説明した編集を行うまで、コンパイラは、コンストラクターにフラグを設定し、(この場合は)  **MySpecializedToggleButtonAutomationPeer_base&lt;MySpecializedToggleButtonAutomationPeer&gt;** と呼ばれる型で利用可能な適切な既定のコンストラクターがないことを指摘します。 実際には、実装型の基底クラスの基底クラスです。

## <a name="important-apis"></a>重要な API
* [winrt::com_ptr 構造体テンプレート](/uwp/cpp-ref-for-winrt/com-ptr)
* [winrt::com_ptr::copy_from 関数](/uwp/cpp-ref-for-winrt/com-ptr#comptrcopyfrom-function)
* [winrt::from_abi 関数テンプレート](/uwp/cpp-ref-for-winrt/from-abi)
* [winrt::get_self 関数テンプレート](/uwp/cpp-ref-for-winrt/get-self)
* [winrt::implements 構造体テンプレート](/uwp/cpp-ref-for-winrt/implements)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)
* [winrt::make_self 関数テンプレート](/uwp/cpp-ref-for-winrt/make-self)
* [winrt::Windows::Foundation::IUnknown::as 関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の使用](consume-apis.md)
* [XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
