---
description: アジャイル オブジェクトは、いずれかのスレッドからアクセスできます。 お使いの C++/WinRT 型は既定ではアジャイルですが、オプトアウトできます。
title: C++/WinRT でのアジャイル オブジェクト
ms.date: 10/20/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、アジャイル、オブジェクト、アジリティ、IAgileObject
ms.localizationpriority: medium
ms.openlocfilehash: 2481396d9348250e14ebfc2d1f940b663b405f77
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639667"
---
# <a name="agile-objects-in-cwinrt"></a>アジャイル オブジェクト c++/cli WinRT

ほとんどの場合に、Windows ランタイム クラスのインスタンスを (ほとんどの標準の C++ オブジェクトは、次のこと) と同様、どのスレッドからアクセスできます。 このような Windows ランタイム クラスは、*アジャイル*します。 Windows に付属する Windows ランタイム クラスの数が少ないは非アジャイルですがそれらを使用する場合は、スレッド モデルとマーシャ リング動作を考慮する必要がありますのみ (マーシャ リング データが渡されるアパートメントの境界を越えて)。 俊敏性を高め、すべての Windows ランタイム オブジェクトの適切な既定値は、独自[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)型が既定でアジャイルです。

ただし、オプトアウトできます。配置、たとえば、シングル スレッド アパートメントで、型のオブジェクトを必要とする特別な理由があります。 これは通常、再入の要件で行う必要があります。 それでもますます、ユーザー インターフェイス (UI) API ではアジャイル オブジェクトを提供するようになっています。 一般に、アジリティは最も単純で最もパフォーマンスの高いオプションです。 また、アクティベーション ファクトリを実装する際は、対応するランタイム クラスがアジャイルではない場合でもアジャイルにする必要があります。

> [!NOTE]
> Windows ランタイムは COM に基づいています。 COM の用語では、アジャイル クラスは `ThreadingModel` = *両方*に登録されています。 COM スレッド モデル、およびアパートメントの詳細については、次を参照してください。 [COM スレッド モデルを使用すると理解](https://msdn.microsoft.com/library/ms809971)します。

## <a name="code-examples"></a>コード例

説明するためにランタイム クラスの実装例を使用してみましょうか C +/cli WinRT 機敏性をサポートしています。

```cppwinrt
#include <winrt/Windows.Foundation.h>

using namespace winrt;
using namespace Windows::Foundation;

struct MyType : winrt::implements<MyType, IStringable>
{
    winrt::hstring ToString(){ ... }
};
```

オプトアウトしていないため、この実装はアジャイルです。 [  **Winrt::implements**](/uwp/cpp-ref-for-winrt/implements) 基本構造体は [**IAgileObject**](https://msdn.microsoft.com/library/windows/desktop/hh802476) と [**IMarshal**](/windows/desktop/api/objidl/nn-objidl-imarshal) を実装します。 **IMarshal** 実装は、**IAgileObject** について知らないレガシー コードで適切な処理を行うために **CoCreateFreeThreadedMarshaler** を使用します。

このコードでは、オブジェクトのアジリティを確認します。 `myimpl` がアジャイルではない場合に [**IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function) の呼び出しで例外がスローされます。

```cppwinrt
winrt::com_ptr<MyType> myimpl{ winrt::make_self<MyType>() };
winrt::com_ptr<IAgileObject> iagileobject{ myimpl.as<IAgileObject>() };
```

例外を処理する代わりに、[**IUnknown::try_as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function) を呼び出すことができます。

```cppwinrt
winrt::com_ptr<IAgileObject> iagileobject{ myimpl.try_as<IAgileObject>() };
if (iagileobject) { /* myimpl is agile. */ }
```

**IAgileObject** には独自のメソッドがないため、これを使用してできることは多くありません。 この次のバリアントはより一般的です。

```cppwinrt
if (myimpl.try_as<IAgileObject>()) { /* myimpl is agile. */ }
```

**IAgileObject** は、*マーカー インターフェイス*です。 **IAgileObject** へのクエリの単なる成功または失敗が、それから得られる情報とユーティリティの範囲です。

## <a name="opting-out-of-agile-object-support"></a>アジャイル オブジェクトのサポートのオプトアウト

[  **winrt::non_agile**](/uwp/cpp-ref-for-winrt/non-agile) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、アジャイル オブジェクトのサポートを明示的にオプトアウトすることを選択することができます。

**winrt::implements** から直接派生する場合。

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, winrt::non_agile>
{
    ...
}
```

ランタイム クラスを作成している場合。

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, winrt::non_agile>
{
    ...
}
```

可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。

機敏性をオプトアウトするかどうかを実装できます**IMarshal**自分でします。 たとえば、使用することができます、 **winrt::non_agile**を既定の機敏性の実装を回避し、実装のマーカー **IMarshal**自分で&mdash;値渡しのマーシャ リング セマンティクスをサポートする場合。

## <a name="agile-references-winrtagileref"></a>アジャイル リファレンス (winrt::agile_ref)

アジャイルではないオブジェクトを使用していて、ただしいくつかの可能性のあるアジャイルのコンテキストでそれを渡す必要がある場合、1 つのオプションは、[**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref) 構造体のテンプレートを使用して、非アジャイル型のインスタンス、または非アジャイル オブジェクトのインターフェイスへのアジャイルのリファレンスを取得することです。

```cppwinrt
NonAgileType nonagile_obj;
winrt::agile_ref<NonAgileType> agile{ nonagile_obj };
```

または、[**winrt::make_agile**](/uwp/cpp-ref-for-winrt/make-agile) ヘルパー関数を使用できます。

```cppwinrt
NonAgileType nonagile_obj;
auto agile{ winrt::make_agile(nonagile_obj) };
```

どちらの場合でも、`agile` を異なるアパートメント内のスレッドに自由に渡して、そこで使用できるようになりました。

```cppwinrt
co_await resume_background();
NonAgileType nonagile_obj_again{ agile.get() };
winrt::hstring message{ nonagile_obj_again.Message() };
```

[  **Agile_ref::get**](/uwp/cpp-ref-for-winrt/agile-ref#agilerefget-function) の呼び出しでは、**get** が呼びだされたスレッド コンテキスト内で安全に使用できるプロキシを返します。

## <a name="important-apis"></a>重要な API

* [IAgileObject インターフェイス](https://msdn.microsoft.com/library/windows/desktop/hh802476)
* [IMarshal インターフェイス](https://docs.microsoft.com/previous-versions/windows/embedded/ms887993)
* [winrt::agile_ref 構造体のテンプレート](/uwp/cpp-ref-for-winrt/agile-ref)
* [winrt::implements 構造体のテンプレート](/uwp/cpp-ref-for-winrt/implements)
* [winrt::make_agile 関数テンプレート](/uwp/cpp-ref-for-winrt/make-agile)
* [winrt::non_agile マーカー構造体](/uwp/cpp-ref-for-winrt/non-agile)
* [winrt::Windows::Foundation::IUnknown:: 関数として](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)
* [winrt::Windows::Foundation::IUnknown::try_as 関数](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)

## <a name="related-topics"></a>関連トピック

* [理解し、COM スレッド モデルの使用](https://msdn.microsoft.com/library/ms809971)
