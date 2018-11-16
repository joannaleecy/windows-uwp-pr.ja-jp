---
author: stevewhims
description: このトピックでは、C++/WinRT API を実装する Windows、サード パーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。
title: C++/WinRT での API の使用
ms.author: stwhi
ms.date: 05/08/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、投影、プロジェクション、実装、ランタイム クラス、ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: cffda0c15e8234f57486995308c335842ce058c8
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6982547"
---
# <a name="consume-apis-with-cwinrt"></a>C++/WinRT での API の使用

このトピックでは、使用する方法を示しています。 [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Api、Windows の一部になっているかどうか、サード パーティ コンポーネント ベンダーで実装されたまたはユーザー自身が実装されます。

## <a name="if-the-api-is-in-a-windows-namespace"></a>API が Windows 名前空間に含まれる場合
これは Windows ランタイム API を使用する際に最も一般的なケースです。 メタデータで定義される Windows 名前空間のすべての型について、C++/WinRT は C++ 対応の同等の型を定義します (*投影された型*と呼ばれます)。 投影された型には Windows の型と同じ完全修飾名がありますが、C++ の構文を使用して **winrt** 名前空間に配置されます。 たとえば、[**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) は **winrt::Windows::Foundation::Uri** として C++/WinRT に投影されます。

次に簡単なコード例を示します。

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    winrt::init_apartment();
    Uri contosoUri{ L"http://www.contoso.com" };
    Uri combinedUri = contosoUri.CombineUri(L"products");
}
```

インクルードするヘッダー `winrt/Windows.Foundation.h` は SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\` フォルダー内にあります。 このフォルダー内のヘッダーには、C++/WinRT に投影された Windows の名前空間の型が含まれます。 この例では、`winrt/Windows.Foundation.h` に、ランタイム クラス [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) に投影された型である**winrt::Windows::Foundation::Uri** が含まれています。

> [!TIP]
> Windows 名前空間から型を使用する場合は、この名前空間に対応する C++/WinRT ヘッダーを含めます。 `using namespace` ディレクティブはオプションですが、便利です。

上記のコード例では、C++/WinRT の初期化後、公開されているいずれかのコンストラクターを介して投影される型 **winrt::Windows::Foundation::Uri** の値をスタックに割り当てます (この場合は、[**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_))。 このため、最も一般的な使用事例を使用します。 C++/WinRT 投影型の値を取得したら、それにはすべての同じメンバーが含まれるため、実際の Windows ランタイム型のインスタンスのように扱うことができます。

実際に、投影される値はプロキシです。基本的には、バッキング オブジェクトへのスマート ポインターに過ぎません。 投影された値のコンストラクターは [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) を呼び出し、Windows ランタイムのバッキング クラスのインスタンス (この場合は **Windows.Foundation.Uri**) を作成し、投影された新しい値の内部にそのオブジェクトの既定のインターフェイスを保存します。 次のように、投影された値のメンバーを呼び出す実際に委任するバッキング オブジェクトにはスマート ポインターを介して状態の変更が発生することができます。

![投影された Windows::Foundation::Uri 型](images/uri.png)

`contosoUri` の値が範囲外になると破壊し、その参照を既定のインターフェイスに解放します。 その参照が、Windows ランタイムの **Windows.Foundation.Uri** バッキング オブジェクトへの最後の参照である場合、そのバッキング オブジェクトも破壊します。

> [!TIP]
> *投影された型*は、自身の API を使用するためのランタイム クラスに対するラッパーです。 *投影されたインターフェイス*は Windows ランタイム インターフェイスに対するラッパーです。

## <a name="cwinrt-projection-headers"></a>C++/WinRT プロジェクション ヘッダー
Windows 名前空間 API を C++/WinRT から使用するには、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt` フォルダーからのヘッダーを含めます。 下位の名前空間の型では、その直接の親の名前空間の型を参照するのが一般的です。 したがって、各 C++/WinRT プロジェクションのヘッダーには、その親の名前空間のヘッダー ファイルが自動的に含まれるため、それを明示的に含める*必要*はありません。 ただし、含めてもエラーは発生しません。

たとえば、[**Windows::Security::Cryptography::Certificates**](/uwp/api/windows.security.cryptography.certificates) 名前空間では、それと同等の C++/WinRT 型定義が `winrt/Windows.Security.Cryptography.Certificates.h` に存在します。 **Windows::Security::Cryptography::Certificates** の型には、親である **Windows::Security::Cryptography** 名前空間の型が必要であり、その名前空間の型には、自信の親である **Windows::Security** の型が必要になる場合があります。

そのため、`winrt/Windows.Security.Cryptography.Certificates.h` を含める場合、そのファイルには `winrt/Windows.Security.Cryptography.h` が含まれ、`winrt/Windows.Security.Cryptography.h` には `winrt/Windows.Security.h` が含まれます。 `winrt/Windows.h` は存在しないため、その証跡はそこで停止します。 この推移的な包含プロセスは、第 2 レベルの名前空間で停止します。

このプロセスには、必要な*宣言*を指定するヘッダー ファイルと、親の名前空間で定義されたクラスの*実装*が推移的に含まれます。

1 つの名前空間内の型のメンバーは、他の関連のない名前空間で 1 つまたは複数の型を参照できます。 コンパイラがこれらのメンバーの定義を正常にコンパイルするためには、コンパイラーはこれらのすべての型の終了の型の宣言を参照する必要があります。 したがって、各 C++/WinRT プロジェクション ヘッダーには、任意の依存タイプを*宣言*する必要がある名前空間ヘッダーが含まれます。 親の名前空間とは異なり、このプロセスは参照された型の*実装*を追加*しません*。

> [!IMPORTANT]
> 関連しない名前空間で宣言されている型 (インスタンス化、メソッドの呼び出しなど) を実際に*使用*する場合は、その型の適切な名前空間ヘッダー ファイルを含める必要があります。 *実装*ではなく*宣言*のみが自動的に含められます。

たとえば、`winrt/Windows.Security.Cryptography.Certificates.h` のみを含める場合、これらの名前空間などから推移的に宣言が取得されます。

- Windows.Foundation
- Windows.Foundation.Collections
- Windows.Networking
- Windows.Storage.Streams
- Windows.Security.Cryptography

つまり、一部の API は含まれているヘッダー内で事前宣言されます。 ただし、その定義はまだ含まれていないヘッダー内にあります。 そのため、[**Windows::Foundation::Uri::RawUri**](/uwp/api/windows.foundation.uri.rawuri) を呼び出す場合は、メンバーが未定義であることを示すリンカ エラーが表示されます。 解決策として、`#include <winrt/Windows.Foundation.h>` を明示的に指定します。 一般に、このようなリンカ エラーが表示された場合は、API の名前空間で付けられた名前のヘッダーを含めてから、リビルドしてください。

## <a name="accessing-members-via-the-object-via-an-interface-or-via-the-abi"></a>オブジェクト、インターフェイス、ABI を介したメンバーへのアクセス
C++/WinRT プロジェクションでは、Windows ランタイム クラスのランタイム表現は、基になる ABI インターフェイスに過ぎません。 ただし、必要に応じて、その作成者が意図した方法でクラスに対してコードを記述することができます。 たとえば、[**Uri**](/uwp/api/windows.foundation.uri) の **ToString** メソッドをクラスのメソッドのように呼び出すことができます (実際、バックグラウンドでは、それは別の **IStringable** インターフェイスのメソッドです)。

```cppwinrt
Uri contosoUri{ L"http://www.contoso.com" };
WINRT_ASSERT(contosoUri.ToString() == L"http://www.contoso.com/"); // QueryInterface is called at this point.
```

この利便性は、適切なインターフェイスに対するクエリによって実現されます。 ただし、常に開発者が制御できます。 IStringable インターフェイスを自身で取得し、それを直接使用することで、多少のパフォーマンスのためにその利便性を若干手放すことを選択することもできます。 次のコード例では、実行時に (1 回限りのクエリにより) 実際の IStringable インターフェイス ポインターを取得します。 その後、**ToString** への呼び出しは直接的であり、**QueryInterface** へのそれ以降の呼び出しを回避します。

```cppwinrt
IStringable stringable = contosoUri; // One-off QueryInterface.
WINRT_ASSERT(stringable.ToString() == L"http://www.contoso.com/");
```

同じインターフェイスでいくつかのメソッドを呼び出すことがわかっている場合は、この方法を選択できます。

また、ABI レベルでメンバーにアクセスする場合にも選択することができます。 次のコード例で方法を示します。また、[C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)に詳細とコード例が記載されています。

```cppwinrt
int port = contosoUri.Port(); // Access the Port "property" accessor via C++/WinRT.

winrt::com_ptr<ABI::Windows::Foundation::IUriRuntimeClass> abiUri = contosoUri.as<ABI::Windows::Foundation::IUriRuntimeClass>();
HRESULT hr = abiUri->get_Port(&port); // Access the get_Port ABI function.
```

## <a name="delayed-initialization"></a>初期化の遅延
投影された型の既定のコンストラクターでも、Windows ランタイムのバッキング オブジェクトが作成されます。 作業を後に遅らせることができるように、Windows ランタイム オブジェクトを作成しないで投影された型の変数を作成する場合は、これを実行できます。 投影された型の特別な C++/WinRT `nullptr_t` コンストラクターを使用して変数またはフィールドを宣言します。

```cppwinrt
#include <winrt/Windows.Storage.Streams.h>
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer m_gamerPicBuffer{ nullptr };
};
```

`nullptr_t` コンストラクターを*除く*投影された型のすべてのコンストラクターにより、Windows ランタイムのバッキング オブジェクトが作成されます。 `nullptr_t` コンストラクターは、基本的には何もしません。 投影されたオブジェクトがそれ以降に初期化されることが想定されます。 そのため、ランタイム クラスに既定のコンストラクターがあるかどうかに関係なく、効率的な初期化の遅延にこの方法を使用することができます。

## <a name="if-the-api-is-implemented-in-a-windows-runtime-component"></a>API が Windows ランタイム コンポーネントに実装されている場合
このセクションは、コンポーネントを自分で作成した場合またはベンダーから提供された場合に適用されます。

> [!NOTE]
> C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) のインストールと使用については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

アプリケーション プロジェクトで、Windows ランタイム コンポーネントの Windows ランタイム メタデータ (`.winmd`) ファイルを参照してビルドします。 作成中、`cppwinrt.exe` ツールで、コンポーネントの API サーフェイスをすべて定義する (*投影する*) 標準的な C++ ライブラリを生成します。 つまり、生成されたライブラリにはコンポーネントに投影された型が含まれます。

次に、Windows 名前空間の型と同じように、いずれかのコンストラクターを介してヘッダーを追加し、投影された型を作成します。 アプリケーション プロジェクトのスタートアップ コードにより、ランタイム クラスが登録され、投影された型のコンストラクターは [**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) を呼び出し、参照するコンポーネントからランタイム クラスをアクティブ化します。

```cppwinrt
#include <winrt/BankAccountWRC.h>

struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount bankAccount;
    ...
};
```

詳細、コード、および Windows ランタイム コンポーネントに実装する API の使用に関するチュートリアルについては、「[C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)」を参照してください。

## <a name="if-the-api-is-implemented-in-the-consuming-project"></a>API が使用中のプロジェクトに実装される場合
XAML UI で使用する型が XAML と同じプロジェクト内にある場合でも、ランタイム クラスを指定する必要があります。

このシナリオでは、ランタイム クラスの Windows ランタイム メタデータ (`.winmd`) から投影される型を生成します。 この場合も、ヘッダーを含めますが、自身の `nullptr` コンストラクターを介して投影される型を作成します。 このコンストラクターは初期化されないため、[**winrt::make**](/uwp/cpp-ref-for-winrt/make) ヘルパー関数を介してインスタンスに値を割り当て、必要なコンストラクター引数を渡す必要があります。 使用中のコードと同じプロジェクトに実装されるランタイム クラスは、Windows ランタイム/COM のアクティブ化を介して登録またはインスタンス化する必要がありません。

```cppwinrt
// MainPage.h
...
struct MainPage : MainPageT<MainPage>
{
    ...
    private:
        Bookstore::BookstoreViewModel m_mainViewModel{ nullptr };
        ...
    };
}
...
// MainPage.cpp
...
#include "BookstoreViewModel.h"

MainPage::MainPage()
{
    m_mainViewModel = winrt::make<Bookstore::implementation::BookstoreViewModel>();
    ...
}
```

詳細、コード、および使用中のプロジェクトに実装するランタイム クラスの使用に関するチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」をご覧ください。

## <a name="instantiating-and-returning-projected-types-and-interfaces"></a>投影された型とインターフェイスをインスタンス化して返す
次に、使用中のプロジェクトで投影された型とインターフェイスの例を示します。 (など、この例では)、投影された型ツールで生成されたは、作成することは自分で何かに注意してください。

```cppwinrt
struct MyRuntimeClass : MyProject::IMyRuntimeClass, impl::require<MyRuntimeClass,
    Windows::Foundation::IStringable, Windows::Foundation::IClosable>
```

**MyRuntimeClass** は投影された型で、投影されたインターフェイスには、**IMyRuntimeClass**、**IStringable**、および **IClosable** が含まれます。 このトピックでは、投影された型をインスタンス化する際のさまざまな方法について説明します。 次の、**MyRuntimeClass** を使用する際のリマインダーと概要の例を示します。

```cppwinrt
// The runtime class is implemented in another compilation unit (it's either a Windows API,
// or it's implemented in a second- or third-party component).
MyProject::MyRuntimeClass myrc1;

// The runtime class is implemented in the same compilation unit.
MyProject::MyRuntimeClass myrc2{ nullptr };
myrc2 = winrt::make<MyProject::implementation::MyRuntimeClass>();
```

- 投影された型のすべてのインターフェイスのメンバーにアクセスできます。
- 投影された型を呼び出し元に返すことができます。
- 投影される型とインターフェイスは [**winrt::Windows::Foundation::IUnknown**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown) から取得します。 そのため、投影された型またはインターフェイスで [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) を呼び出すと、投影された他のインターフェイスもクエリされるため、使用するか、呼び出し元に戻すことができます。 **as** メンバー関数は [**QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521) と同じように動作します。

```cppwinrt
void f(MyProject::MyRuntimeClass const& myrc)
{
    myrc.ToString();
    myrc.Close();
    IClosable iclosable = myrc.as<IClosable>();
    iclosable.Close();
}
```

## <a name="activation-factories"></a>アクティベーション ファクトリ
C++/WinRT オブジェクトを作成する便利で直接的な方法は次のとおりです。

```cppwinrt
using namespace winrt::Windows::Globalization::NumberFormatting;
...
CurrencyFormatter currency{ L"USD" };
```

ただし、場合によっては、自分でアクティベーション ファクトリを作成し、都合のよいときにそこからオブジェクトを作成することが必要になります。 [**winrt::get_activation_factory**](/uwp/cpp-ref-for-winrt/get-activation-factory) 関数テンプレートを使用して行う方法を示す例をいくつか示します。

```cppwinrt
using namespace winrt::Windows::Globalization::NumberFormatting;
...
auto factory = winrt::get_activation_factory<CurrencyFormatter, ICurrencyFormatterFactory>();
CurrencyFormatter currency = factory.CreateCurrencyFormatterCode(L"USD");
```

```cppwinrt
using namespace winrt::Windows::Foundation;
...
auto factory = winrt::get_activation_factory<Uri, IUriRuntimeClassFactory>();
Uri account = factory.CreateUri(L"http://www.contoso.com");
```

上の 2 つの例のクラスとは、Windows の名前空間の型です。 次の例では、**BankAccountWRC::BankAccount** は Windows ランタイム コンポーネントに実装されたカスタム型です。

```cppwinrt
auto factory = winrt::get_activation_factory<BankAccountWRC::BankAccount>();
BankAccountWRC::BankAccount account = factory.ActivateInstance<BankAccountWRC::BankAccount>();
```

## <a name="important-apis"></a>重要な API
* [QueryInterface インターフェイス](https://msdn.microsoft.com/library/windows/desktop/ms682521)
* [RoActivateInstance 関数](https://msdn.microsoft.com/library/br224646)
* [Windows::Foundation::Uri クラス](/uwp/api/windows.foundation.uri)
* [winrt::get_activation_factory 関数テンプレート](/uwp/cpp-ref-for-winrt/get-activation-factory)
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)
* [winrt::Windows::Foundation::IUnknown 構造体](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)
* [C++/WinRT と ABI 間の相互運用](interop-winrt-abi.md)
* [C++/WinRT の概要](intro-to-using-cpp-with-winrt.md)
* [XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
