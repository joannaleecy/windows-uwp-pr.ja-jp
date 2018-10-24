---
author: stevewhims
description: Windows ランタイムは参照カウントのシステムです。重要での重要性、およびの違いについて理解するシステムで強力なと弱参照します。
title: C++/WinRT の弱参照
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、強力な弱、参照
ms.localizationpriority: medium
ms.openlocfilehash: 414a73c8df31e4547b8bd154945a8e9960529320
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5445589"
---
# <a name="strong-and-weak-references-in-cwinrt"></a>強度への参照 c++/WinRT

Windows ランタイムは参照カウントのシステムです。システムではこのようなことを認識するの重要性と区別、厳密なと弱参照 (と参照はどちらも、暗黙的な*この*ポインターなど) に重要です。 このトピックでわかるこれらの参照を適切に管理する方法を知ることを意味スムーズに実行される信頼性の高いシステムと役に立ちません障害が発生した 1 つの違いことができます。 言語プロジェクションで高度にサポートされているヘルパー関数を提供することによって[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)だけと正しくより複雑なシステムの構築の作業で中間が満たしていること。

## <a name="safely-accessing-the-this-pointer-in-a-class-member-coroutine"></a>クラスのメンバー コルーチンで*この*ポインターを安全にアクセスします。

以下に示すコードでは、クラスのメンバー関数は、コルーチンの一般的な例を示します。

```cppwinrt
// pch.h
#pragma once
#include <iostream>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"

using namespace winrt;
using namespace Windows::Foundation;
using namespace std::chrono_literals;

struct MyClass : winrt::implements<MyClass, IInspectable>
{
    winrt::hstring m_value{ L"Hello, World!" };

    IAsyncOperation<winrt::hstring> RetrieveValueAsync()
    {
        co_await 5s;
        co_return m_value;
    }
};

int main()
{
    winrt::init_apartment();

    auto myclass_instance{ winrt::make_self<MyClass>() };
    auto async{ myclass_instance->RetrieveValueAsync() };

    winrt::hstring result{ async.get() };
    std::wcout << result.c_str() << std::endl;
}
```

**MyClass::RetrieveValueAsync**の間、動作し、のコピーを返す最終的にし、`MyClass::m_value`データ メンバーです。 **RetrieveValueAsync**を呼び出すと、非同期のオブジェクトを作成して、そのオブジェクトには、暗黙的な*この*ポインター (最終的には、これから`m_value`へのアクセスが)。

イベントの完全な順序を次に示します。

1. **メイン**、 **MyClass**のインスタンスを作成 (`myclass_instance`)。
2. `async`オブジェクトを作成すると、(経由で、*この*) を指す`myclass_instance`します。
3. **Winrt::Windows::Foundation::IAsyncAction::get**関数は、数秒をブロックし、 **RetrieveValueAsync**の結果を返します。
4. 値を返します。 **RetrieveValueAsync** `this->m_value`します。

手順 4 は、*この*が有効である限りも安全です。

しかし、非同期操作が完了する前にクラスのインスタンスを破棄する場合。 すべての種類の非同期メソッドが完了する前に、クラスのインスタンスはスコープ外になる可能性がある方法があります。 クラスのインスタンスに設定してそれをシミュレートできますが、`nullptr`します。

```cppwinrt
int main()
{
    winrt::init_apartment();

    auto myclass_instance{ winrt::make_self<MyClass>() };
    auto async{ myclass_instance->RetrieveValueAsync() };
    myclass_instance = nullptr; // Simulate the class instance going out of scope.

    winrt::hstring result{ async.get() }; // Behavior is now undefined; crashing is likely.
    std::wcout << result.c_str() << std::endl;
}
```

クラスのインスタンスを破棄します以降、ようもう一度を参照しない直接します。 もちろん、非同期のオブジェクトに、*この*ポインターがありを使ってアプリをクラスのインスタンス内に格納されている値をコピーしようとしています。 コルーチンは、メンバー関数と impunity で、*この*ポインターを使用できるようにすることが想定します。

この変更をコードでは、実行問題は、手順 4 でクラスのインスタンスを破棄すると、*この*が無効になるためです。 非同期のオブジェクトがクラスのインスタンス内の変数にアクセスしようとすると、すぐにはクラッシュ (何か完全未定義)。

解決策は、非同期操作を提供する、&mdash;コルーチン&mdash;クラスのインスタンスに、独自の強参照します。 現在書き込まれたとして、コルーチン効果的にポインターを保持 raw*この*クラスのインスタンスただし、外にあるクラスのインスタンスを維持するのに十分な。

クラスのインスタンスを維持するには、下に表示される**RetrieveValueAsync**の実装を変更します。

```cppwinrt
IAsyncOperation<winrt::hstring> RetrieveValueAsync()
{
    auto strong_this{ get_strong() }; // Keep *this* alive.
    co_await 5s;
    co_return m_value;
}
```

C++/WinRT オブジェクトから直接的または間接的に派生[**winrt::implements**](/uwp/cpp-ref-for-winrt/implements)テンプレート c++/WinRT オブジェクトは、*この*ポインターへの強参照を取得する[**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)保護されたメンバー関数を呼び出すことができます。 実際に使用する必要がないことに注意してください、`strong_this`変数です。呼び出す**get_strong**参照カウントをインクリメントし、有効な暗黙的な*この*ポインターを保持します。

これは、手順 4 を取得したとき以前の問題を解決します。 クラスのインスタンスを他のすべての参照が非表示になった場合でも、コルーチンはその依存関係が安定したことを保証するための予防措置を実行します。

強参照が適切ながない場合、 [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) *この*への弱参照を取得する代わりに呼び出すことができます。 だけ*この*にアクセスする前に強参照を取得することを確認します。

```cppwinrt
IAsyncOperation<winrt::hstring> RetrieveValueAsync()
{
    auto weak_this{ get_weak() }; // Maybe keep *this* alive.

    co_await 5s;

    if (auto strong_this{ weak_this.get() })
    {
        co_return m_value;
    }
    else
    {
        co_return L"";
    }
}
```

上記の例では弱参照は、強参照が残っていないときに破棄されないクラスのインスタンスを保持しません。 メンバー変数にアクセスする前に強参照を取得できるかどうかをチェックする方法を提供します。

## <a name="safely-accessing-the-this-pointer-with-an-event-handling-delegate"></a>イベント処理デリゲートを使用して*この*ポインターを安全にアクセスします。

### <a name="the-scenario"></a>シナリオ

イベント処理に関する一般的な情報を参照してください。 [C + でデリゲートを使用してイベントを処理/WinRT](handle-events.md)します。

前のセクションには、コルーチンと同時実行の領域で、有効期間の潜在的な問題が強調表示されます。 ただし、オブジェクトのメンバー関数をして内のラムダ関数が、イベント受信側 (イベントを処理するオブジェクト) と、イベント ソース (オブジェクトの相対的な有効期間を考慮する必要があります、オブジェクトのメンバー関数をまたは内からイベントを処理する場合イベントを発生させる)。 コード例をいくつか見てみましょう。

以下のコードは、最初に追加されているすべてのデリゲートによって処理される一般的なイベントを発生させる簡単な**EventSource**クラスを定義します。 [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler)デリゲート型を使用する例イベントが発生したらが、問題と解決策を次には、すべてのデリゲート型に適用されます。

次に、 **EventRecipient**クラスは、ラムダ関数の形式で**EventSource::Event**イベントのハンドラーを提供します。

```cppwinrt
// pch.h
#pragma once
#include <iostream>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"

using namespace winrt;
using namespace Windows::Foundation;

struct EventSource
{
    winrt::event<EventHandler<int>> m_event;

    void Event(EventHandler<int> const& handler)
    {
        m_event.add(handler);
    }

    void RaiseEvent()
    {
        m_event(nullptr, 0);
    }
};

struct EventRecipient : winrt::implements<EventRecipient, IInspectable>
{
    winrt::hstring m_value{ L"Hello, World!" };

    void Register(EventSource& event_source)
    {
        event_source.Event([&](auto&& ...)
        {
            std::wcout << m_value.c_str() << std::endl;
        });
    }
};

int main()
{
    winrt::init_apartment();

    EventSource event_source;
    auto event_recipient{ winrt::make_self<EventRecipient>() };
    event_recipient->Register(event_source);
    event_source.RaiseEvent();
}
```

パターンは、イベント受信側が、*この*ポインター上に依存ラムダ イベント ハンドラーを持っています。 イベント受信者は、イベント ソースを失います、されるたびに、それらの依存関係を失います。 それらの場合は、共通ですが、パターンが適しています。 UI ページでそのページ上にあるコントロールで発生したイベントを処理するときなど、明らかな場合があります。 ページのボタンの状態を続ける&mdash;ため、ハンドラーは、ボタンもを失います。 これは、受信側がソースを所有する場合 (データ メンバーとしてなど)、または受信側とソースが兄弟関係にあり、他のオブジェクトによって直接所有されている場合に当てはまります。 ハンドラーが依存する*このオブジェクト*に表示されない場合、有効期間の強弱を気にしなくても、通常どおり*このオブジェクト*をキャプチャできます。

*この*が自身表示されない (完了と非同期アクションと非同期操作で発生した進行状況イベントのハンドラーを含む) のハンドラーでの使用、対処する方法を理解することが重要である場合はまだあります。

- 非同期メソッドを実装するためにコルーチンを作成する場合は可能です。
- 特定の XAML UI フレームワーク オブジェクト ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel) など) を使用するまれなケースで、イベント ソースから登録解除しなくても、受信側が最終処理される場合は可能です。

### <a name="the-issue"></a>問題

この次のバージョンの**主な**機能は、イベント受信側が破棄されるときの動作をシミュレート (おそらくがスコープ外)、イベント ソースがまだイベントを発生させるときにします。

```cppwinrt
int main()
{
    winrt::init_apartment();

    EventSource event_source;
    auto event_recipient{ winrt::make_self<EventRecipient>() };
    event_recipient->Register(event_source);
    event_recipient = nullptr; // Simulate the event recipient going out of scope.
    event_source.RaiseEvent(); // Behavior is now undefined within the lambda event handler; crashing is likely.
}
```

イベント受信側が破棄されるが含まれるラムダのイベント ハンドラーが**イベント**のイベントをサブスクライブしても。 そのイベントを発生すると、ラムダが正しくないその時点で、*この*ポインターを逆参照しようとします。 そのため、アクセス違反ハンドラー (またはコルーチンが継続する) のコードからそれを使用しようとしています。

> [!IMPORTANT]
> *この*オブジェクトの有効期間を検討する必要があります、このような状況が発生した場合キャプチャされた*この*オブジェクトのキャプチャ状態を続けるかどうか。 しない場合、キャプチャ強参照または弱参照を以下で説明します。
>
> または&mdash;、シナリオに適している場合、およびスレッドの考慮事項を使うとも&mdash;別のオプションは、ハンドラーを取り消すと、イベント、または受信側のデストラクターで、受信側が完了したら、します。 [登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)を参照してください。

これは、どのよう、ハンドラーに登録します。

```cppwinrt
event_source.Event([&](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

ラムダは、参照によって、ローカル変数を自動的にキャプチャします。 そのため、この例では、お同等も記述できます。

```cppwinrt
event_source.Event([this](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

どちらの場合も、raw*この*ポインターをキャプチャしますしているだけです。 参照カウントに有効に何ができないように、現在破棄されるようにします。

### <a name="the-solution"></a>ソリューション

解決策は、強参照をキャプチャします。 強参照が*は*、参照カウントと増加、キープア ライブの現在のオブジェクト*は*維持します。 キャプチャ変数を宣言するだけです (と呼ばれる`strong_this`この例では)、および[**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)、強参照を*この*ポインターを取得します。 これを呼び出して初期化します。

```cppwinrt
event_source.Event([this, strong_this { get_strong()}](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

現在のオブジェクトの自動キャプチャを省略し、データ メンバーにアクセスする、暗黙的な*この*経由の代わりに、キャプチャ変数もできます。

```cppwinrt
event_source.Event([strong_this { get_strong()}](auto&& ...)
{
    std::wcout << strong_this->m_value.c_str() << std::endl;
});
```

強参照が適切ながない場合、 [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) *この*への弱参照を取得する代わりに呼び出すことができます。 だけも取得できます強参照からのメンバーにアクセスする前に確認します。

```cppwinrt
event_source.Event([weak_this{ get_weak() }](auto&& ...)
{
    if (auto strong_this{ weak_this.get() })
    {
        std::wcout << strong_this->m_value.c_str() << std::endl;
    }
});
```

### <a name="if-you-use-a-member-function-as-a-delegate"></a>デリゲートとしてメンバー関数を使用する場合

ほか、ラムダ関数では、これらの原則にも適用、デリゲートとしてメンバー関数を使用します。 構文とは異なる、いくつかのコードを見てみましょう。 まず、raw*この*ポインターを使用して、安全でない可能性のあるメンバー関数イベント ハンドラーを次に示します。

```cppwinrt
struct EventRecipient : winrt::implements<EventRecipient, IInspectable>
{
    winrt::hstring m_value{ L"Hello, World!" };

    void Register(EventSource& event_source)
    {
        event_source.Event({ this, &EventRecipient::OnEvent });
    }

    void OnEvent(IInspectable const& /* sender */, int /* args */)
    {
        std::wcout << m_value.c_str() << std::endl;
    }
};
```

これは、オブジェクトとそのメンバー関数を参照する標準的な従来の方法です。 これを安全にするには、するには&mdash;Windows SDK のバージョン 10.0.17763.0 (Windows 10、バージョン 1809) の時点で&mdash;強参照またはハンドラーが登録された時点で弱参照を確立します。 その時点では、イベントの受信者オブジェクトがまだ有効にする呼ばれます。

強参照では、 [**get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)の代わりに、raw*この*ポインターを呼び出すだけです。 C++/WinRT により、結果として得られるデリゲートが現在のオブジェクトの強参照を保持しています。

```cppwinrt
event_source.Event({ get_strong(), &EventRecipient::OnEvent });
```

弱参照を[**get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)を呼び出します。 C++/WinRT により、結果として得られるデリゲートは弱参照を保持します。 、最後に、バック グラウンドでデリゲート解決するには、厳密な 1 への弱参照しようとして成功した場合のみ、メンバー関数を呼び出します。

```cppwinrt
event_source.Event({ get_weak(), &EventRecipient::OnEvent });
```

### <a name="a-weak-reference-example-using-swapchainpanelcompositionscalechanged"></a>**SwapChainPanel::CompositionScaleChanged**を使用して、弱参照例

このコード例では、別の図の弱参照を使用して[**SwapChainPanel::CompositionScaleChanged**](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged)イベントを使用します。 コードでは、受信者への弱参照をキャプチャするラムダを使用して、イベント ハンドラーを登録します。

```cppwinrt
winrt::Windows::UI::Xaml::Controls::SwapChainPanel m_swapChainPanel;
winrt::event_token m_compositionScaleChangedEventToken;

void RegisterEventHandler()
{
    m_compositionScaleChangedEventToken = m_swapChainPanel.CompositionScaleChanged([weak_this{ get_weak() }]
        (Windows::UI::Xaml::Controls::SwapChainPanel const& sender,
        Windows::Foundation::IInspectable const& object)
    {
        if (auto strong_this{ weak_this.get() })
        {
            strong_this->OnCompositionScaleChanged(sender, object);
        }
    });
}

void OnCompositionScaleChanged(Windows::UI::Xaml::Controls::SwapChainPanel const& sender,
    Windows::Foundation::IInspectable const& object)
{
    // Here, we know that the "this" object is valid.
}
```

ラムダのキャプチャ句で、一時変数を作成し、*このオブジェクト*の弱参照を表示します。 ラムダ式の本文で、*このオブジェクト*の強参照を取得する場合は、**OnCompositionScaleChanged** 関数が呼び出されます。 これにより、**OnCompositionScaleChanged** 内で*このオブジェクト*を安全に使用することができます。

## <a name="weak-references-in-cwinrt"></a>C++/WinRT の弱参照

上で使用されている弱参照をしました。 一般に、循環参照を失わずに適しています。 たとえば、XAML ベース UI フレームワークのネイティブ実装&mdash;フレームワークの歴史的設計&mdash;、弱参照メカニズム C + + WinRT は循環参照を処理する必要があります。 XAML 以外では、おそらく必要はありません弱参照を使用する (は何もしない本質的に XAML 固有ユーザーに関する)。 はなく、高く、はず設計独自 C + + 循環参照や弱参照が必要とを回避するように WinRT Api です。 

宣言するすべての型について、いつどこで弱参照が必要になるかが C++/WinRT に対してすぐに明白になるわけではありません。 したがって、C++/WinRT は構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) で弱参照サポートを自動的に提供し、そこから直接的または間接的に独自の C++/WinRT の型を派生します。 利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource) で実際に照会されない限り料金はかかりません。 また、[そのサポートを除外する](#opting-out-of-weak-reference-support)ことを明示的に選択することができます。

### <a name="code-examples"></a>コード例
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

### <a name="opting-out-of-weak-reference-support"></a>弱参照サポートの除外
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
