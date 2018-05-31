---
author: stevewhims
description: C++/WinRT の弱参照サポートは利用に応じた料金制度であるため、オブジェクトが IWeakReferenceSource を照会しない限り、料金はかかりません。
title: C++/WinRT の弱参照
ms.author: stwhi
ms.date: 04/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、弱、参照
ms.localizationpriority: medium
ms.openlocfilehash: 63ffad19c0ae8a52737ae13a54e5657df875d0b5
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832606"
---
# <a name="weak-references-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) の弱参照
循環参照や弱参照が必要とならないように独自の C++/WinRT API を設計することはできるはずですし、まったく行わないことはないはずです。 ただし、XAML ベースの UI フレームワークのネイティブ実装を考えると、フレームワークの歴史的設計が理由で、C++/WinRT の弱参照メカニズムは循環参照を処理するために必要になります。 XAML 以外では、弱参照を使用する必要性は考えにくいようです (ただし、理論上は弱参照に関して XAML に特有なことは存在しません)。

宣言するすべての型について、いつどこで弱参照が必要になるかが C++/WinRT に対してすぐに明白になるわけではありません。 したがって、C++/WinRT は構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) で弱参照サポートを自動的に提供し、そこから直接的または間接的に独自の C++/WinRT の型を派生します。 利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](https://msdn.microsoft.com/library/br224609) で実際に照会されない限り料金はかかりません。 また、[そのサポートを除外する](#opting-out-of-weak-reference-support)ことを明示的に選択することができます。

## <a name="code-examples"></a>コード例
[**winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) 構造体テンプレートは、クラス インスタンスへの弱参照を取得するための 1 つのオプションです。

```cppwinrt
Class c;
winrt::weak_ref<Class> weak{ c };
```
または、[**winrt::make_weak**](/uwp/cpp-ref-for-winrt/make-weak) ヘルパー関数を使用できます。

```cppwinrt
Class c;
auto weak = winrt::make_weak(c);
```

弱参照を作成してもオブジェクト自体の参照カウントには影響しません。制御ブロックが割り当てられるだけです。 その制御ブロックが弱参照セマンティクスの実装を処理します。 その後、弱参照から強参照への昇格を試みて、成功した場合は使用することができます。

```cppwinrt
if (Class strong = weak.get())
{
    // use strong, for example strong.DoWork();
}
```

他の強参照が存在する場合、[**weak_ref::get**](/uwp/cpp-ref-for-winrt/weak-ref#weakrefget-function) の呼び出しにより参照カウントが増分され、呼び出し元に強参照が返されます。

## <a name="a-weak-reference-to-the-this-pointer"></a>*this* ポインターへの弱参照
C++/WinRT オブジェクトは、構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) から直接的または間接的に派生します。 保護されたメンバー関数 [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) は、C++/WinRT オブジェクトの *this* ポインターへの弱参照を返します。 [**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) は、強参照を取得します。

## <a name="opting-out-of-weak-reference-support"></a>弱参照サポートの除外
弱参照サポートは自動です。 ただし、[**winrt::no_weak_ref**](/uwp/cpp-ref-for-winrt/no-weak-ref) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、そのサポートを明示的に除外することを選択できます。

**winrt::implements** から直接派生する場合。

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, no_weak_ref>
{
    ...
}
```

ランタイム クラスを作成している場合。

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, no_weak_ref>
{
    ...
}
```

可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。 除外された型に対して弱参照を要求すると、コンパイラーは "*これは弱参照サポート専用です*" というメッセージで知らせます。

## <a name="important-apis"></a>重要な API
* [implements::get_weak 関数](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [winrt::make_weak 関数テンプレート](/uwp/cpp-ref-for-winrt/make-weak)
* [winrt::no_weak_ref マーカー構造体](/uwp/cpp-ref-for-winrt/no-weak-ref)
* [winrt::weak_ref 構造体テンプレート](/uwp/cpp-ref-for-winrt/weak-ref)
