---
description: Windows ランタイムは、参照カウント システムです。重要性およびの違いについて理解するための重要なシステムでこのような強力と脆弱の参照。
title: C++/WinRT の弱参照
ms.date: 10/03/2018
ms.topic: article
keywords: windows 10、uwp、標準の c++、cpp、winrt、プロジェクション、strong、弱い参照
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 507b3cee71819df1d0163380a494e6a15936109f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630817"
---
# <a name="strong-and-weak-references-in-cwinrt"></a>強力と脆弱の参照を c++/cli WinRT

Windows ランタイムは、参照カウント システムです。重要性およびの違いについて理解するための重要なシステムでこのような強力と脆弱の参照 (および参照がどちらも、暗黙的ななどを*この*ポインター)。 このトピックで後ほど、これらの参照を正しく管理する方法についての知識とスムーズに実行される信頼性の高いシステムと予期しない障害が発生した 1 つの違いを意味します。 言語プロジェクションの詳細をサポートするヘルパー関数を提供することで[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)簡単かつ正しくより複雑なシステムの構築の作業の半分が満たしていること。

## <a name="safely-accessing-the-this-pointer-in-a-class-member-coroutine"></a>安全にアクセスする、*この*クラス メンバーのコルーチンでのポインター

コード リストは、クラスのメンバー関数は、コルーチンの典型的な例を示します。

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

**MyClass::RetrieveValueAsync**がしばらくの間、機能、最終的に制御が戻るのコピーと、`MyClass::m_value`データ メンバー。 呼び出す**RetrieveValueAsync**非同期オブジェクトを作成し、そのオブジェクトが暗黙的な*この*ポインター (最終的には、これを`m_value`にアクセス)。

イベントの完全なシーケンスを次に示します。

1. **メイン**のインスタンス**MyClass**が作成されます (`myclass_instance`)。
2. `async`オブジェクトを作成すると、ポイント (を使用してその*この*) に`myclass_instance`します。
3. **Winrt::Windows::Foundation::IAsyncAction::get**関数は、数秒間をブロックしの結果を返します**RetrieveValueAsync**します。
4. **RetrieveValueAsync**の値を返します`this->m_value`します。

手順 4 では安全な限り*この*は有効です。

しかし、非同期操作が完了する前に、クラスのインスタンスが破棄される場合でしょうか。 これは、すべての種類の方法は、非同期メソッドが完了する前に、クラスのインスタンスはスコープ外に出る可能性があります。 クラスのインスタンスに設定してそれをシミュレートできますが、`nullptr`します。

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

クラスのインスタンスを破棄しました後、もう一度を参照しない直接しましたように見えます。 非同期のオブジェクトはもちろん、*この*を使用して、クラスのインスタンス内で格納されている値をコピーしようとしへのポインター。 コルーチンは、メンバー関数と使用できることが必要ですが、*この*impunity のポインター。

コードにこの変更により問題が発生、手順 4. で、クラスのインスタンスが破棄されたため、および*この*が無効になっています。 非同期のオブジェクトが、クラスのインスタンス内の変数にアクセスしようとすると、すぐにはクラッシュ (または何か完全に定義されていません)。

解決する非同期操作を付与するには&mdash;コルーチン&mdash;クラスのインスタンスへの独自の強力な参照です。 現在の記述で、コルーチンを効率的に raw 保持*この*クラスのインスタンスへのポインターが、クラスのインスタンスを維持するのに十分な。

実装を変更すると、クラスのインスタンスを維持する**RetrieveValueAsync**以下に示す。

```cppwinrt
IAsyncOperation<winrt::hstring> RetrieveValueAsync()
{
    auto strong_this{ get_strong() }; // Keep *this* alive.
    co_await 5s;
    co_return m_value;
}
```

ため、c++/cli WinRT オブジェクト直接的または間接的に派生から、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)テンプレート、C +/cli WinRT オブジェクトを呼び出すことができます、 [ **implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)プロテクト メンバー関数への強い参照を取得するその*この*ポインター。 実際に使用する必要がないことに注意してください、`strong_this`変数; を呼び出すだけ**get_strong** 、参照カウントをインクリメントし、暗黙的な保持*この*ポインターが無効です。

これは、手順 4 に移動するときに以前の問題を解決します。 クラスのインスタンスへの他のすべての参照が表示されない場合でも、コルーチンがその依存関係が安定したことを保証する予防措置を取得します。

強い参照が、適切でないかどうかは、代わりに呼び出すことができます[ **implements::get_weak** ](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)への弱い参照を取得する*この*します。 アクセスする前に強い参照を取得するにはことを確認して*この*します。

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

上記の例で、弱い参照は、強い参照が残っていないときに破棄されないクラス インスタンスを保持しません。 ただしをメンバー変数にアクセスする前に強い参照を取得できるかどうかを確認する方法を示します。

## <a name="safely-accessing-the-this-pointer-with-an-event-handling-delegate"></a>安全にアクセスする、*この*イベント処理デリゲートを使用してポインター

### <a name="the-scenario"></a>シナリオ

イベント処理に関する一般的な情報は、次を参照してください。 [C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)します。

前のセクションには、コルーチンと同時実行性の面での潜在的な有効期間に関する問題が強調表示されます。 オブジェクトのメンバー関数、または内からイベントを処理する場合してオブジェクトのメンバー関数は、内側のラムダ関数がイベント受信者 (イベントを処理するオブジェクト) とイベント ソース (オブジェクトの相対的な有効期間について考慮する必要がありますが、イベントの発生)。 コード例をいくつか見てみましょう。

コード優先リスト定義、単純な**EventSource**クラスに追加された任意のデリゲートによって処理される一般的なイベントを発生させます。 このイベントの例の動作を使用する、 [ **Windows::Foundation::EventHandler** ](/uwp/api/windows.foundation.eventhandler)デリゲートの型が問題と解決策をここでは、すべてのデリゲート型に適用されます。

次に、 **EventRecipient**クラスのハンドラーを提供する、 **EventSource::Event**ラムダ関数の形式でイベント。

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

イベント受信者が上の依存関係を持つラムダ イベント ハンドラーを持っているパターンは、その*この*ポインター。 イベント受信者には、イベントのソースよりも長く保持、たびに、これらの依存関係はよりも長くなります。 その場合は、共通ですが、パターンにも動作します。 UI ページでそのページ上にあるコントロールで発生したイベントを処理するときなど、明らかな場合があります。 ページには、ボタンがよりも長く保持&mdash;ハンドラーもよりも長く保持、ボタンをクリックします。 これは、受信側がソースを所有する場合 (データ メンバーとしてなど)、または受信側とソースが兄弟関係にあり、他のオブジェクトによって直接所有されている場合に当てはまります。 ハンドラーが依存する*このオブジェクト*に表示されない場合、有効期間の強弱を気にしなくても、通常どおり*このオブジェクト*をキャプチャできます。

場合はまだあります、*これ*ハンドラー (非同期アクションおよび操作によって生成される入力候補および進行状況のイベントのハンドラーを含む) での使用がよりも長く保持とその対処方法を理解することが重要とします。

- 非同期メソッドを実装するためにコルーチンを作成する場合は可能です。
- 特定の XAML UI フレームワーク オブジェクト ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel) など) を使用するまれなケースで、イベント ソースから登録解除しなくても、受信側が最終処理される場合は可能です。

### <a name="the-issue"></a>問題

次のバージョンの**メイン**関数は、イベントの受信者が破棄されるときの動作をシミュレート (おそらくこれがスコープ外) イベント ソースがイベントを発生させても中にします。

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

イベント受信者が破棄されるが、内のラムダのイベント ハンドラーがまだサブスクライブしている、**イベント**イベント。 ラムダが逆参照しようとしたそのイベントが発生したときに、*この*ポインターで、その時点では無効です。 コード ハンドラー (または、コルーチンの継続で) からのアクセス違反の結果、それを使用しようとしています。

> [!IMPORTANT]
> 、このような状況が発生した場合の有効期間について考慮する必要があります、*これ*オブジェクトかどうかと、キャプチャされた*これ*オブジェクトには、キャプチャよりも長くなります。 場合は、キャプチャ、強力なまたは弱い参照の場合は、以下をご紹介します。
>
> または&mdash;である場合、シナリオ、スレッドの場合の考慮事項もできるようなります。&mdash;別のオプションは、イベント、または受信者のデストラクターでは、受信者が完了した後、ハンドラーを失効することです。 参照してください[登録されたデリゲートを取り消す](handle-events.md#revoke-a-registered-delegate)します。

これは、ハンドラーを登録する方法です。

```cppwinrt
event_source.Event([&](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

ラムダは、参照によって任意のローカル変数を自動的にキャプチャします。 そのため、この例で同等にも記述できます。

```cppwinrt
event_source.Event([this](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

どちらの場合にのみキャプチャするため、生*この*ポインター。 何も起こりません参照カウント、何も、現在のオブジェクトを妨げてから破棄されるようにします。

### <a name="the-solution"></a>ソリューション

このソリューションでは、強い参照をキャプチャします。 強い参照*は*され、参照カウントをインクリメント*は*現在のオブジェクトを維持します。 キャプチャ変数を宣言するだけです (と呼ばれる`strong_this`この例では) への呼び出しで初期化と[ **implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)への強い参照を取得しています、 *この*ポインター。

```cppwinrt
event_source.Event([this, strong_this { get_strong()}](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

でも、現在のオブジェクトの自動的なキャプチャを省略しの代わりに、暗黙の型を使用してキャプチャ変数を通じてデータ メンバーにアクセスできます*この*します。

```cppwinrt
event_source.Event([strong_this { get_strong()}](auto&& ...)
{
    std::wcout << strong_this->m_value.c_str() << std::endl;
});
```

強い参照が、適切でないかどうかは、代わりに呼び出すことができます[ **implements::get_weak** ](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)への弱い参照を取得する*この*します。 だけを引き続き取得できる強い参照からメンバーにアクセスする前に確認します。

```cppwinrt
event_source.Event([weak_this{ get_weak() }](auto&& ...)
{
    if (auto strong_this{ weak_this.get() })
    {
        std::wcout << strong_this->m_value.c_str() << std::endl;
    }
});
```

### <a name="if-you-use-a-member-function-as-a-delegate"></a>メンバー関数をデリゲートとして使用する場合

だけでなくラムダ関数の場合は、これらの原則にも適用されます、代理人としてメンバー関数を使用します。 構文は異なります、いくつかのコードを見てみましょう。 最初に、raw を使用して、安全でないメンバー関数イベントのハンドラーをここでは*この*ポインター。

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

これは、オブジェクトとそのメンバー関数を参照する標準的な従来の方法です。 セーフにするには、するには&mdash;時点では、Windows SDK のバージョン (Windows 10、バージョンは 1809) 10.0.17763.0&mdash;強力なまたはハンドラーが登録されている時点で弱い参照を確立します。 その時点では、イベントの受信者オブジェクトはまだ有効な状態に呼ばれます。

強力な参照を呼び出すだけ[ **get_strong** ](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) 、生の代わりに*この*ポインター。 C +/cli WinRT により得られたデリゲートが、現在のオブジェクトへの強い参照を保持しているようになります。

```cppwinrt
event_source.Event({ get_strong(), &EventRecipient::OnEvent });
```

弱い参照の場合は、呼び出す[ **get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)します。 C +/cli WinRT により得られたデリゲートが弱い参照を保持しているようになります。 過去 1 分間にあると、バック グラウンドでデリゲートに厳密な弱い参照を解決しようとして成功した場合のみ、メンバー関数を呼び出します。

```cppwinrt
event_source.Event({ get_weak(), &EventRecipient::OnEvent });
```

### <a name="a-weak-reference-example-using-swapchainpanelcompositionscalechanged"></a>弱い参照の使用例を使用して、 **SwapChainPanel::CompositionScaleChanged**

このコード例では使用して、 [ **SwapChainPanel::CompositionScaleChanged** ](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged)弱い参照の他の図を使用してイベント。 コードでは、受信者への弱い参照をキャプチャするラムダを使用して、イベント ハンドラーを登録します。

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

上記は、弱い参照が使用されている説明しました。 一般に、循環参照の重大な場合に適しています。 XAML ベースの UI フレームワークのネイティブ実装の例では、&mdash;フレームワークの歴史的な設計により&mdash;弱い参照メカニズム C +/cli WinRT 循環参照を処理する必要があります。 XAML では、外部で、可能性があります必要はありません弱い参照を使用する (not が何も本質的に XAML 固有それらについて)。 はなく、たいてい、はず設計独自 C +/cli WinRT Api の循環参照と弱い参照する必要が生じないようにします。 

宣言するすべての型について、いつどこで弱参照が必要になるかが C++/WinRT に対してすぐに明白になるわけではありません。 したがって、C++/WinRT は構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) で弱参照サポートを自動的に提供し、そこから直接的または間接的に独自の C++/WinRT の型を派生します。 利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource) で実際に照会されない限り料金はかかりません。 また、[そのサポートを除外する](#opting-out-of-weak-reference-support)ことを明示的に選択することができます。

### <a name="code-examples"></a>コード例
[  **winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) 構造体テンプレートは、クラス インスタンスへの弱参照を取得するための 1 つのオプションです。

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
* [winrt::weak_ref 構造体のテンプレート](/uwp/cpp-ref-for-winrt/weak-ref)
