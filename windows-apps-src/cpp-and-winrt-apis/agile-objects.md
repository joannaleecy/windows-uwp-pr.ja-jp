---
author: stevewhims
description: アジャイル オブジェクトは、いずれかのスレッドからアクセスできます。 お使いの C++/WinRT 型は既定ではアジャイルですが、オプトアウトできます。
title: C++/WinRT でのアジャイル オブジェクト
ms.author: stwhi
ms.date: 04/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、アジャイル、オブジェクト、アジリティ、IAgileObject
ms.localizationpriority: medium
ms.openlocfilehash: 9af1fb0a9d23727924ae3c165bc8977fb9cc7774
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4536797"
---
# <a name="agile-objects-in-cwinrt"></a>C++/WinRT におけるアジャイル オブジェクト
ほとんどの場合、Windows ランタイム クラスのインスタンス (標準 C++ オブジェクトなど) は任意のスレッドからアクセスできます。 このようなクラスは*アジャイル*です。 Windows に組み込まれている Windows ランタイム クラスのうち少数はアジャイル以外ですが、それらを使用するときに、スレッド モデルおよびマーシャリング動作を考慮する必要があります (マーシャリングではスレッドまたはプロセスの境界を越えてデータが渡されます)。 アジャイルであるすべての Windows ランタイム オブジェクトの値として適切なため、独自[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)の種類は既定でアジャイルです。

ただしオプトアウトすることができます。たとえば、特定のシングルスレッド アパートメントなど、特別な理由で特定の型のオブジェクトを存在させることが必要な場合があります。 これは通常、再入の要件で行う必要があります。 それでもますます、ユーザー インターフェイス (UI) API ではアジャイル オブジェクトを提供するようになっています。 一般に、アジリティは最も単純で最もパフォーマンスの高いオプションです。 また、アクティベーション ファクトリを実装する際は、対応するランタイム クラスがアジャイルではない場合でもアジャイルにする必要があります。

> [!NOTE]
> Windows ランタイムは COM に基づいています。 COM の用語では、アジャイル クラスは `ThreadingModel` = *両方*に登録されています。 COM スレッド モデルの詳細については、「[COM スレッド モデルの理解と使用](https://msdn.microsoft.com/library/ms809971)」をご覧ください。

## <a name="code-examples"></a>コード例
実装例を使用して、C++/WinRT でアジリティがどのようにサポートされるか実証してみましょう。

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

struct MyType : implements<MyType, IStringable>
{
    winrt::hstring ToString(){ ... }
};
```

オプトアウトしていないため、この実装はアジャイルです。 [**Winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体は [**IAgileObject**](https://msdn.microsoft.com/library/windows/desktop/hh802476) と [**IMarshal**](https://docs.microsoft.com/previous-versions/windows/embedded/ms887993) を実装します。 **IMarshal** 実装は、**IAgileObject** について知らないレガシー コードで適切な処理を行うために **CoCreateFreeThreadedMarshaler** を使用します。

このコードでは、オブジェクトのアジリティを確認します。 `myimpl` がアジャイルではない場合に [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) の呼び出しで例外がスローされます。

```cppwinrt
winrt::com_ptr<MyType> myimpl = winrt::make_self<MyType>();
winrt::com_ptr<IAgileObject> iagileobject = myimpl.as<IAgileObject>();
```

例外を処理する代わりに、[**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) を呼び出すことができます。

```cppwinrt
winrt::com_ptr<IAgileObject> iagileobject = myimpl.try_as<IAgileObject>();
if (iagileobject) { /* myimpl is agile. */ }
```

**IAgileObject** には独自のメソッドがないため、これを使用してできることは多くありません。 この次のバリアントはより一般的です。

```cppwinrt
if (myimpl.try_as<IAgileObject>()) { /* myimpl is agile. */ }
```

**IAgileObject** は、*マーカー インターフェイス*です。 **IAgileObject** へのクエリの単なる成功または失敗が、それから得られる情報とユーティリティの範囲です。

## <a name="opting-out-of-agile-object-support"></a>アジャイル オブジェクトのサポートのオプトアウト
[**winrt::non_agile**](/uwp/cpp-ref-for-winrt/non_agile) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、アジャイル オブジェクトのサポートを明示的にオプトアウトすることを選択することができます。

**winrt::implements** から直接派生する場合。

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, non_agile>
{
    ...
}
```

ランタイム クラスを作成している場合。

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, non_agile>
{
    ...
}
```

可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。

アジリティをオプトアウトするかしないか、IMarshal を自分で実装できます。 たとえば、おそらく marshal-by-value (値渡しのマーシャリング) セマンティクスをサポートするために、[**non_agile**] マーカーを使用し、既定のアジリティの実装を回避して、自分で IMarshal を実装することができます。

## <a name="agile-references-winrtagileref"></a>アジャイル リファレンス (winrt::agile_ref)
アジャイルではないオブジェクトを使用していて、ただしいくつかの可能性のあるアジャイルのコンテキストでそれを渡す必要がある場合、1 つのオプションは、[**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref) 構造体のテンプレートを使用して、非アジャイル型のインスタンス、または非アジャイル オブジェクトのインターフェイスへのアジャイルのリファレンスを取得することです。

```cppwinrt
NonAgileType nonagile_obj;
winrt::agile_ref<NonAgileType> agile{ nonagile_obj };
```
または、[**winrt::make_agile**](/uwp/cpp-ref-for-winrt/make-agile) ヘルパー関数を使用できます。

```cppwinrt
NonAgileType nonagile_obj;
auto agile = winrt::make_agile(nonagile_obj);
```

どちらの場合でも、`agile` を異なるアパートメント内のスレッドに自由に渡して、そこで使用できるようになりました。

```cppwinrt
co_await resume_background();
NonAgileType nonagile_obj_again = agile.get();
winrt::hstring message = nonagile_obj_again.Message();
```

[**Agile_ref::get**](/uwp/cpp-ref-for-winrt/agile-ref#agilerefget-function) の呼び出しでは、**get** が呼びだされたスレッド コンテキスト内で安全に使用できるプロキシを返します。

## <a name="important-apis"></a>重要な API
* [IAgileObject インターフェイス](https://msdn.microsoft.com/library/windows/desktop/hh802476)
* [IMarshal インターフェイス](https://docs.microsoft.com/previous-versions/windows/embedded/ms887993)
* [winrt::agile_ref 構造体テンプレート](/uwp/cpp-ref-for-winrt/agile-ref)
* [winrt::implements 構造体テンプレート](/uwp/cpp-ref-for-winrt/implements)
* [winrt::make_agile 関数テンプレート](/uwp/cpp-ref-for-winrt/make-agile)
* [winrt::non_agile マーカー構造体](/uwp/cpp-ref-for-winrt/non_agile)
* [winrt::Windows::Foundation::IUnknown::as 関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [winrt::Windows::Foundation::IUnknown::try_as 関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)

## <a name="related-topics"></a>関連トピック
* [COM スレッド モデルの理解と使用](https://msdn.microsoft.com/library/ms809971)
