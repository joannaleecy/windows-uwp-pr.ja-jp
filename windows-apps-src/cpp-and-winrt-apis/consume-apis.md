---
author: stevewhims
description: このトピックでは、C++/WinRT API を実装する Windows、サード パーティ コンポーネント ベンダー、またはユーザー自身に応じた使用方法について説明します。
title: C++/WinRT での API の使用
ms.author: stwhi
ms.date: 04/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、投影、プロジェクション、実装、ランタイム クラス、ライセンス認証
ms.localizationpriority: medium
ms.openlocfilehash: e777aca8f1d9f3892f67b10c785c056b14c8070c
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832246"
---
# <a name="consume-apis-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) での API の使用
> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

このトピックでは、C++/WinRT API が Windows に含まれるかどうか、サード パーティ コンポーネント ベンダーで実装するかどうか、またはユーザー自身が実装するかどうかに応じて、その使用方法について説明します。

## <a name="if-the-api-is-in-a-windows-namespace"></a>API が Windows 名前空間に含まれる場合
これは Windows ランタイム API を使用する際に最も一般的なケースです。 次に簡単なコード例を示します。

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    winrt::init_apartment();
    Uri contosoUri{ L"http://www.contoso.com" };
}
```

インクルードするヘッダー `winrt/Windows.Foundation.h` は SDK に含まれるもので、`%WindowsSdkDir%Include<WindowsTargetPlatformVersion>\cppwinrt\winrt\` フォルダー内にあります。 このフォルダー内のヘッダーには、C++/WinRT に投影された Windows API が含まれます。 Windows 名前空間から型を使用する場合は、この名前空間に対応する C++/WinRT プロジェクション ヘッダーを含めます。 `using namespace` ディレクティブはオプションですが、便利です。

この例では、`winrt/Windows.Foundation.h` にランタイム クラス [**Windows::Foundation::Uri**](/uwp/api/windows.foundation.uri) に投影された型が含まれています。

> [!TIP]
> *投影された型*は、自身の API を使用するためのランタイム クラスに対するラッパーです。 *投影されたインターフェイス*は Windows ランタイム インターフェイスに対するラッパーです。

上記のコード例では、C++/WinRT の初期化後、公開されているいずれかのコンストラクターを介して投影される型 **Uri** を作成します (この場合は、[**Uri(String)**](/uwp/api/windows.foundation.uri#Windows_Foundation_Uri__ctor_System_String_))。 このため、最も一般的な使用事例を使用します。

## <a name="if-the-api-is-implemented-in-a-windows-runtime-component"></a>API が Windows ランタイム コンポーネントに実装されている場合
このセクションは、コンポーネントを自分で作成した場合またはベンダーから提供された場合に適用されます。

> [!NOTE]
> 現在利用可能な C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) の詳細については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

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
    m_mainViewModel = make<Bookstore::implementation::BookstoreViewModel>();
    ...
}
```

詳細、コード、および使用中のプロジェクトに実装するランタイム クラスの使用に関するチュートリアルについては、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)」をご覧ください。

## <a name="instantiating-and-returning-projected-types-and-interfaces"></a>投影された型とインターフェイスをインスタンス化して返す
次に、使用中のプロジェクトで投影された型とインターフェイスの例を示します。

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

## <a name="important-apis"></a>重要な API
* [winrt::make 関数テンプレート](/uwp/cpp-ref-for-winrt/make)
* [winrt::Windows::Foundation::IUnknown::as](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT でのイベントの作成](author-events.md#create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component)
* [XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md#add-a-property-of-type-bookstoreviewmodel-to-mainpage)
