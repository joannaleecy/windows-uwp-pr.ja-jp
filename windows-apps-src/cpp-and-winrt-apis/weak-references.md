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
# <a name="strong-and-weak-references-in-cwinrt"></a><span data-ttu-id="c94aa-104">強力と脆弱の参照を c++/cli WinRT</span><span class="sxs-lookup"><span data-stu-id="c94aa-104">Strong and weak references in C++/WinRT</span></span>

<span data-ttu-id="c94aa-105">Windows ランタイムは、参照カウント システムです。重要性およびの違いについて理解するための重要なシステムでこのような強力と脆弱の参照 (および参照がどちらも、暗黙的ななどを*この*ポインター)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-105">The Windows Runtime is a reference-counted system; and in such a system it's important for you to know about the significance of, and distinction between, strong and weak references (and references that are neither, such as the implicit *this* pointer).</span></span> <span data-ttu-id="c94aa-106">このトピックで後ほど、これらの参照を正しく管理する方法についての知識とスムーズに実行される信頼性の高いシステムと予期しない障害が発生した 1 つの違いを意味します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-106">As you'll see in this topic, knowing how to manage these references correctly can mean the difference between a reliable system that runs smoothly, and one that crashes unpredictably.</span></span> <span data-ttu-id="c94aa-107">言語プロジェクションの詳細をサポートするヘルパー関数を提供することで[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)簡単かつ正しくより複雑なシステムの構築の作業の半分が満たしていること。</span><span class="sxs-lookup"><span data-stu-id="c94aa-107">By providing helper functions that have deep support in the language projection, [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) meets you halfway in your work of building more complex systems simply and correctly.</span></span>

## <a name="safely-accessing-the-this-pointer-in-a-class-member-coroutine"></a><span data-ttu-id="c94aa-108">安全にアクセスする、*この*クラス メンバーのコルーチンでのポインター</span><span class="sxs-lookup"><span data-stu-id="c94aa-108">Safely accessing the *this* pointer in a class-member coroutine</span></span>

<span data-ttu-id="c94aa-109">コード リストは、クラスのメンバー関数は、コルーチンの典型的な例を示します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-109">The code listing below shows a typical example of a coroutine that's a member function of a class.</span></span>

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

<span data-ttu-id="c94aa-110">**MyClass::RetrieveValueAsync**がしばらくの間、機能、最終的に制御が戻るのコピーと、`MyClass::m_value`データ メンバー。</span><span class="sxs-lookup"><span data-stu-id="c94aa-110">**MyClass::RetrieveValueAsync** does work for a while, and then eventually it returns a copy of the `MyClass::m_value` data member.</span></span> <span data-ttu-id="c94aa-111">呼び出す**RetrieveValueAsync**非同期オブジェクトを作成し、そのオブジェクトが暗黙的な*この*ポインター (最終的には、これを`m_value`にアクセス)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-111">Calling **RetrieveValueAsync** causes an asynchronous object to be created, and that object has an implicit *this* pointer (through which, eventually, `m_value` is accessed).</span></span>

<span data-ttu-id="c94aa-112">イベントの完全なシーケンスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-112">Here's the full sequence of events.</span></span>

1. <span data-ttu-id="c94aa-113">**メイン**のインスタンス**MyClass**が作成されます (`myclass_instance`)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-113">In **main**, an instance of **MyClass** is created (`myclass_instance`).</span></span>
2. <span data-ttu-id="c94aa-114">`async`オブジェクトを作成すると、ポイント (を使用してその*この*) に`myclass_instance`します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-114">The `async` object is created, pointing (via its *this*) to `myclass_instance`.</span></span>
3. <span data-ttu-id="c94aa-115">**Winrt::Windows::Foundation::IAsyncAction::get**関数は、数秒間をブロックしの結果を返します**RetrieveValueAsync**します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-115">The **winrt::Windows::Foundation::IAsyncAction::get** function blocks for a few seconds, and then returns the result of **RetrieveValueAsync**.</span></span>
4. <span data-ttu-id="c94aa-116">**RetrieveValueAsync**の値を返します`this->m_value`します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-116">**RetrieveValueAsync** returns the value of `this->m_value`.</span></span>

<span data-ttu-id="c94aa-117">手順 4 では安全な限り*この*は有効です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-117">Step 4 is safe as long as *this* is valid.</span></span>

<span data-ttu-id="c94aa-118">しかし、非同期操作が完了する前に、クラスのインスタンスが破棄される場合でしょうか。</span><span class="sxs-lookup"><span data-stu-id="c94aa-118">But, what if the class instance is destroyed before the async operation completes?</span></span> <span data-ttu-id="c94aa-119">これは、すべての種類の方法は、非同期メソッドが完了する前に、クラスのインスタンスはスコープ外に出る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-119">There are all kinds of ways the class instance could go out of scope before the asynchronous method has completed.</span></span> <span data-ttu-id="c94aa-120">クラスのインスタンスに設定してそれをシミュレートできますが、`nullptr`します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-120">But, we can simulate it by setting the class instance to `nullptr`.</span></span>

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

<span data-ttu-id="c94aa-121">クラスのインスタンスを破棄しました後、もう一度を参照しない直接しましたように見えます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-121">After the point where we destroy the class instance, it looks like we don't directly refer to it again.</span></span> <span data-ttu-id="c94aa-122">非同期のオブジェクトはもちろん、*この*を使用して、クラスのインスタンス内で格納されている値をコピーしようとしへのポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-122">But of course the asynchronous object has a *this* pointer to it, and tries to use that to copy the value stored inside the class instance.</span></span> <span data-ttu-id="c94aa-123">コルーチンは、メンバー関数と使用できることが必要ですが、*この*impunity のポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-123">The coroutine is a member function, and it expects to be able to use its *this* pointer with impunity.</span></span>

<span data-ttu-id="c94aa-124">コードにこの変更により問題が発生、手順 4. で、クラスのインスタンスが破棄されたため、および*この*が無効になっています。</span><span class="sxs-lookup"><span data-stu-id="c94aa-124">With this change to the code, we run into a problem in step 4, because the class instance has been destroyed, and *this* is no longer valid.</span></span> <span data-ttu-id="c94aa-125">非同期のオブジェクトが、クラスのインスタンス内の変数にアクセスしようとすると、すぐにはクラッシュ (または何か完全に定義されていません)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-125">As soon as the asynchronous object attempts to access the variable inside the class instance, it will crash (or do something entirely undefined).</span></span>

<span data-ttu-id="c94aa-126">解決する非同期操作を付与するには&mdash;コルーチン&mdash;クラスのインスタンスへの独自の強力な参照です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-126">The solution is to give the asynchronous operation&mdash;the coroutine&mdash;its own strong reference to the class instance.</span></span> <span data-ttu-id="c94aa-127">現在の記述で、コルーチンを効率的に raw 保持*この*クラスのインスタンスへのポインターが、クラスのインスタンスを維持するのに十分な。</span><span class="sxs-lookup"><span data-stu-id="c94aa-127">As currently written, the coroutine effectively holds a raw *this* pointer to the class instance; but that's not enough to keep the class instance alive.</span></span>

<span data-ttu-id="c94aa-128">実装を変更すると、クラスのインスタンスを維持する**RetrieveValueAsync**以下に示す。</span><span class="sxs-lookup"><span data-stu-id="c94aa-128">To keep the class instance alive, change the implementation of **RetrieveValueAsync** to that shown below.</span></span>

```cppwinrt
IAsyncOperation<winrt::hstring> RetrieveValueAsync()
{
    auto strong_this{ get_strong() }; // Keep *this* alive.
    co_await 5s;
    co_return m_value;
}
```

<span data-ttu-id="c94aa-129">ため、c++/cli WinRT オブジェクト直接的または間接的に派生から、 [ **winrt::implements** ](/uwp/cpp-ref-for-winrt/implements)テンプレート、C +/cli WinRT オブジェクトを呼び出すことができます、 [ **implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)プロテクト メンバー関数への強い参照を取得するその*この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-129">Because a C++/WinRT object directly or indirectly derives from the [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) template, the C++/WinRT object can call its [**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) protected member function to retrieve a strong reference to its *this* pointer.</span></span> <span data-ttu-id="c94aa-130">実際に使用する必要がないことに注意してください、`strong_this`変数; を呼び出すだけ**get_strong** 、参照カウントをインクリメントし、暗黙的な保持*この*ポインターが無効です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-130">Note that there's no need to actually use the `strong_this` variable; just calling **get_strong** increments your reference count, and keeps your implicit *this* pointer valid.</span></span>

<span data-ttu-id="c94aa-131">これは、手順 4 に移動するときに以前の問題を解決します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-131">This resolves the problem that we previously had when we got to step 4.</span></span> <span data-ttu-id="c94aa-132">クラスのインスタンスへの他のすべての参照が表示されない場合でも、コルーチンがその依存関係が安定したことを保証する予防措置を取得します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-132">Even if all other references to the class instance disappear, the coroutine has taken the precaution of guaranteeing that its dependencies are stable.</span></span>

<span data-ttu-id="c94aa-133">強い参照が、適切でないかどうかは、代わりに呼び出すことができます[ **implements::get_weak** ](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)への弱い参照を取得する*この*します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-133">If a strong reference isn't appropriate, then you can instead call [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) to retrieve a weak reference to *this*.</span></span> <span data-ttu-id="c94aa-134">アクセスする前に強い参照を取得するにはことを確認して*この*します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-134">Just confirm that you can retrieve a strong reference before accessing *this*.</span></span>

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

<span data-ttu-id="c94aa-135">上記の例で、弱い参照は、強い参照が残っていないときに破棄されないクラス インスタンスを保持しません。</span><span class="sxs-lookup"><span data-stu-id="c94aa-135">In the example above, the weak reference doesn't keep the class instance from being destroyed when no strong references remain.</span></span> <span data-ttu-id="c94aa-136">ただしをメンバー変数にアクセスする前に強い参照を取得できるかどうかを確認する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-136">But it gives you a way of checking whether a strong reference can be acquired before accessing the member variable.</span></span>

## <a name="safely-accessing-the-this-pointer-with-an-event-handling-delegate"></a><span data-ttu-id="c94aa-137">安全にアクセスする、*この*イベント処理デリゲートを使用してポインター</span><span class="sxs-lookup"><span data-stu-id="c94aa-137">Safely accessing the *this* pointer with an event-handling delegate</span></span>

### <a name="the-scenario"></a><span data-ttu-id="c94aa-138">シナリオ</span><span class="sxs-lookup"><span data-stu-id="c94aa-138">The scenario</span></span>

<span data-ttu-id="c94aa-139">イベント処理に関する一般的な情報は、次を参照してください。 [C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-139">For general info about event-handling, see [Handle events by using delegates in C++/WinRT](handle-events.md).</span></span>

<span data-ttu-id="c94aa-140">前のセクションには、コルーチンと同時実行性の面での潜在的な有効期間に関する問題が強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-140">The previous section highlighted potential lifetime issues in the areas of coroutines and concurrency.</span></span> <span data-ttu-id="c94aa-141">オブジェクトのメンバー関数、または内からイベントを処理する場合してオブジェクトのメンバー関数は、内側のラムダ関数がイベント受信者 (イベントを処理するオブジェクト) とイベント ソース (オブジェクトの相対的な有効期間について考慮する必要がありますが、イベントの発生)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-141">But, if you handle an event with an object's member function, or from within a lambda function inside an object's member function, then you need to think about the relative lifetimes of the event recipient (the object handling the event) and the event source (the object raising the event).</span></span> <span data-ttu-id="c94aa-142">コード例をいくつか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c94aa-142">Let's look at some code examples.</span></span>

<span data-ttu-id="c94aa-143">コード優先リスト定義、単純な**EventSource**クラスに追加された任意のデリゲートによって処理される一般的なイベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-143">The code listing below first defines a simple **EventSource** class, which raises a generic event that's handled by any delegates that have been added to it.</span></span> <span data-ttu-id="c94aa-144">このイベントの例の動作を使用する、 [ **Windows::Foundation::EventHandler** ](/uwp/api/windows.foundation.eventhandler)デリゲートの型が問題と解決策をここでは、すべてのデリゲート型に適用されます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-144">This example event happens to use the [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) delegate type, but the issues and remedies here apply to any and all delegate types.</span></span>

<span data-ttu-id="c94aa-145">次に、 **EventRecipient**クラスのハンドラーを提供する、 **EventSource::Event**ラムダ関数の形式でイベント。</span><span class="sxs-lookup"><span data-stu-id="c94aa-145">Then, the **EventRecipient** class provides a handler for the **EventSource::Event** event in the form of a lambda function.</span></span>

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

<span data-ttu-id="c94aa-146">イベント受信者が上の依存関係を持つラムダ イベント ハンドラーを持っているパターンは、その*この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-146">The pattern is that the event recipient has a lambda event handler with dependencies on its *this* pointer.</span></span> <span data-ttu-id="c94aa-147">イベント受信者には、イベントのソースよりも長く保持、たびに、これらの依存関係はよりも長くなります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-147">Whenever the event recipient outlives the event source, it outlives those dependencies.</span></span> <span data-ttu-id="c94aa-148">その場合は、共通ですが、パターンにも動作します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-148">And in those cases, which are common, the pattern works well.</span></span> <span data-ttu-id="c94aa-149">UI ページでそのページ上にあるコントロールで発生したイベントを処理するときなど、明らかな場合があります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-149">Some of these cases are obvious, such as when a UI page handles an event raised by a control that's on the page.</span></span> <span data-ttu-id="c94aa-150">ページには、ボタンがよりも長く保持&mdash;ハンドラーもよりも長く保持、ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-150">The page outlives the button&mdash;so, the handler also outlives the button.</span></span> <span data-ttu-id="c94aa-151">これは、受信側がソースを所有する場合 (データ メンバーとしてなど)、または受信側とソースが兄弟関係にあり、他のオブジェクトによって直接所有されている場合に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-151">This holds true any time the recipient owns the source (as a data member, for example), or any time the recipient and the source are siblings and directly owned by some other object.</span></span> <span data-ttu-id="c94aa-152">ハンドラーが依存する*このオブジェクト*に表示されない場合、有効期間の強弱を気にしなくても、通常どおり*このオブジェクト*をキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-152">If you're sure you have a case where the handler won't outlive the *this* that it depends on, then you can capture *this* normally, without consideration for strong or weak lifetime.</span></span>

<span data-ttu-id="c94aa-153">場合はまだあります、*これ*ハンドラー (非同期アクションおよび操作によって生成される入力候補および進行状況のイベントのハンドラーを含む) での使用がよりも長く保持とその対処方法を理解することが重要とします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-153">But there are still cases where *this* doesn't outlive its use in a handler (including handlers for completion and progress events raised by asynchronous actions and operations), and it's important to know how to deal with them.</span></span>

- <span data-ttu-id="c94aa-154">非同期メソッドを実装するためにコルーチンを作成する場合は可能です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-154">If you're authoring a coroutine to implement an asynchronous method, then it's possible.</span></span>
- <span data-ttu-id="c94aa-155">特定の XAML UI フレームワーク オブジェクト ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel) など) を使用するまれなケースで、イベント ソースから登録解除しなくても、受信側が最終処理される場合は可能です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-155">In rare cases with certain XAML UI framework objects ([**SwapChainPanel**](/uwp/api/windows.ui.xaml.controls.swapchainpanel), for example), then it's possible, if the recipient is finalized without unregistering from the event source.</span></span>

### <a name="the-issue"></a><span data-ttu-id="c94aa-156">問題</span><span class="sxs-lookup"><span data-stu-id="c94aa-156">The issue</span></span>

<span data-ttu-id="c94aa-157">次のバージョンの**メイン**関数は、イベントの受信者が破棄されるときの動作をシミュレート (おそらくこれがスコープ外) イベント ソースがイベントを発生させても中にします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-157">This next version of the **main** function simulates what happens when the event recipient is destroyed (perhaps it goes out of scope) while the event source is still raising events.</span></span>

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

<span data-ttu-id="c94aa-158">イベント受信者が破棄されるが、内のラムダのイベント ハンドラーがまだサブスクライブしている、**イベント**イベント。</span><span class="sxs-lookup"><span data-stu-id="c94aa-158">The event recipient is destroyed, but the lambda event handler within it is still subscribed to the **Event** event.</span></span> <span data-ttu-id="c94aa-159">ラムダが逆参照しようとしたそのイベントが発生したときに、*この*ポインターで、その時点では無効です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-159">When that event is raised, the lambda attempts to dereference the *this* pointer, which is at that point invalid.</span></span> <span data-ttu-id="c94aa-160">コード ハンドラー (または、コルーチンの継続で) からのアクセス違反の結果、それを使用しようとしています。</span><span class="sxs-lookup"><span data-stu-id="c94aa-160">So, an access violation results from code in the handler (or in a coroutine's continuation) attempting to use it.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c94aa-161">、このような状況が発生した場合の有効期間について考慮する必要があります、*これ*オブジェクトかどうかと、キャプチャされた*これ*オブジェクトには、キャプチャよりも長くなります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-161">If you encounter a situation like this, then you'll need to think about the lifetime of the *this* object; and whether or not the captured *this* object outlives the capture.</span></span> <span data-ttu-id="c94aa-162">場合は、キャプチャ、強力なまたは弱い参照の場合は、以下をご紹介します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-162">If it doesn't, then capture it with a strong or a weak reference, as we'll demonstrate below.</span></span>
>
> <span data-ttu-id="c94aa-163">または&mdash;である場合、シナリオ、スレッドの場合の考慮事項もできるようなります。&mdash;別のオプションは、イベント、または受信者のデストラクターでは、受信者が完了した後、ハンドラーを失効することです。</span><span class="sxs-lookup"><span data-stu-id="c94aa-163">Or&mdash;if it makes sense for your scenario, and if threading considerations make it even possible&mdash;then another option is to revoke the handler after the recipient is done with the event, or in the recipient's destructor.</span></span> <span data-ttu-id="c94aa-164">参照してください[登録されたデリゲートを取り消す](handle-events.md#revoke-a-registered-delegate)します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-164">See [Revoke a registered delegate](handle-events.md#revoke-a-registered-delegate).</span></span>

<span data-ttu-id="c94aa-165">これは、ハンドラーを登録する方法です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-165">This is how we're registering the handler.</span></span>

```cppwinrt
event_source.Event([&](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

<span data-ttu-id="c94aa-166">ラムダは、参照によって任意のローカル変数を自動的にキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-166">The lambda automatically captures any local variables by reference.</span></span> <span data-ttu-id="c94aa-167">そのため、この例で同等にも記述できます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-167">So, for this example, we could equivalently have written this.</span></span>

```cppwinrt
event_source.Event([this](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

<span data-ttu-id="c94aa-168">どちらの場合にのみキャプチャするため、生*この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-168">In both cases, we're just capturing the raw *this* pointer.</span></span> <span data-ttu-id="c94aa-169">何も起こりません参照カウント、何も、現在のオブジェクトを妨げてから破棄されるようにします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-169">And that has no effect on reference-counting, so nothing is preventing the current object from being destroyed.</span></span>

### <a name="the-solution"></a><span data-ttu-id="c94aa-170">ソリューション</span><span class="sxs-lookup"><span data-stu-id="c94aa-170">The solution</span></span>

<span data-ttu-id="c94aa-171">このソリューションでは、強い参照をキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-171">The solution is to capture a strong reference.</span></span> <span data-ttu-id="c94aa-172">強い参照*は*され、参照カウントをインクリメント*は*現在のオブジェクトを維持します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-172">A strong reference *does* increment the reference count, and it *does* keep the current object alive.</span></span> <span data-ttu-id="c94aa-173">キャプチャ変数を宣言するだけです (と呼ばれる`strong_this`この例では) への呼び出しで初期化と[ **implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function)への強い参照を取得しています、 *この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-173">You just declare a capture variable (called `strong_this` in this example), and initialize it with a call to [**implements.get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function), which retrieves a strong reference to our *this* pointer.</span></span>

```cppwinrt
event_source.Event([this, strong_this { get_strong()}](auto&& ...)
{
    std::wcout << m_value.c_str() << std::endl;
});
```

<span data-ttu-id="c94aa-174">でも、現在のオブジェクトの自動的なキャプチャを省略しの代わりに、暗黙の型を使用してキャプチャ変数を通じてデータ メンバーにアクセスできます*この*します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-174">You can even omit the automatic capture of the current object, and access the data member through the capture variable instead of via the implicit *this*.</span></span>

```cppwinrt
event_source.Event([strong_this { get_strong()}](auto&& ...)
{
    std::wcout << strong_this->m_value.c_str() << std::endl;
});
```

<span data-ttu-id="c94aa-175">強い参照が、適切でないかどうかは、代わりに呼び出すことができます[ **implements::get_weak** ](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)への弱い参照を取得する*この*します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-175">If a strong reference isn't appropriate, then you can instead call [**implements::get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function) to retrieve a weak reference to *this*.</span></span> <span data-ttu-id="c94aa-176">だけを引き続き取得できる強い参照からメンバーにアクセスする前に確認します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-176">Just confirm that you can still retrieve a strong reference from it before accessing members.</span></span>

```cppwinrt
event_source.Event([weak_this{ get_weak() }](auto&& ...)
{
    if (auto strong_this{ weak_this.get() })
    {
        std::wcout << strong_this->m_value.c_str() << std::endl;
    }
});
```

### <a name="if-you-use-a-member-function-as-a-delegate"></a><span data-ttu-id="c94aa-177">メンバー関数をデリゲートとして使用する場合</span><span class="sxs-lookup"><span data-stu-id="c94aa-177">If you use a member function as a delegate</span></span>

<span data-ttu-id="c94aa-178">だけでなくラムダ関数の場合は、これらの原則にも適用されます、代理人としてメンバー関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-178">As well as lambda functions, these principles also apply to using a member function as your delegate.</span></span> <span data-ttu-id="c94aa-179">構文は異なります、いくつかのコードを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c94aa-179">The syntax is different, so let's look at some code.</span></span> <span data-ttu-id="c94aa-180">最初に、raw を使用して、安全でないメンバー関数イベントのハンドラーをここでは*この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-180">First, here's the potentially unsafe member function event handler, using a raw *this* pointer.</span></span>

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

<span data-ttu-id="c94aa-181">これは、オブジェクトとそのメンバー関数を参照する標準的な従来の方法です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-181">This is the standard, conventional way to refer to an object and its member function.</span></span> <span data-ttu-id="c94aa-182">セーフにするには、するには&mdash;時点では、Windows SDK のバージョン (Windows 10、バージョンは 1809) 10.0.17763.0&mdash;強力なまたはハンドラーが登録されている時点で弱い参照を確立します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-182">To make this safe, you can&mdash;as of version 10.0.17763.0 (Windows 10, version 1809) of the Windows SDK&mdash;establish a strong or a weak reference at the point where the handler is registered.</span></span> <span data-ttu-id="c94aa-183">その時点では、イベントの受信者オブジェクトはまだ有効な状態に呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-183">At that point, the event recipient object is known to be still alive.</span></span>

<span data-ttu-id="c94aa-184">強力な参照を呼び出すだけ[ **get_strong** ](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) 、生の代わりに*この*ポインター。</span><span class="sxs-lookup"><span data-stu-id="c94aa-184">For a strong reference, just call [**get_strong**](/uwp/cpp-ref-for-winrt/implements#implementsgetstrong-function) in place of the raw *this* pointer.</span></span> <span data-ttu-id="c94aa-185">C +/cli WinRT により得られたデリゲートが、現在のオブジェクトへの強い参照を保持しているようになります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-185">C++/WinRT ensures that the resulting delegate holds a strong reference to the current object.</span></span>

```cppwinrt
event_source.Event({ get_strong(), &EventRecipient::OnEvent });
```

<span data-ttu-id="c94aa-186">弱い参照の場合は、呼び出す[ **get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-186">For a weak reference, call [**get_weak**](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function).</span></span> <span data-ttu-id="c94aa-187">C +/cli WinRT により得られたデリゲートが弱い参照を保持しているようになります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-187">C++/WinRT ensures that the resulting delegate holds a weak reference.</span></span> <span data-ttu-id="c94aa-188">過去 1 分間にあると、バック グラウンドでデリゲートに厳密な弱い参照を解決しようとして成功した場合のみ、メンバー関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-188">At the last minute, and behind the scenes, the delegate attempts to resolve the weak reference to a strong one, and only calls the member function if it's successful.</span></span>

```cppwinrt
event_source.Event({ get_weak(), &EventRecipient::OnEvent });
```

### <a name="a-weak-reference-example-using-swapchainpanelcompositionscalechanged"></a><span data-ttu-id="c94aa-189">弱い参照の使用例を使用して、 **SwapChainPanel::CompositionScaleChanged**</span><span class="sxs-lookup"><span data-stu-id="c94aa-189">A weak reference example using **SwapChainPanel::CompositionScaleChanged**</span></span>

<span data-ttu-id="c94aa-190">このコード例では使用して、 [ **SwapChainPanel::CompositionScaleChanged** ](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged)弱い参照の他の図を使用してイベント。</span><span class="sxs-lookup"><span data-stu-id="c94aa-190">In this code example, we use the [**SwapChainPanel::CompositionScaleChanged**](/uwp/api/windows.ui.xaml.controls.swapchainpanel.compositionscalechanged) event by way of another illustration of weak references.</span></span> <span data-ttu-id="c94aa-191">コードでは、受信者への弱い参照をキャプチャするラムダを使用して、イベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-191">The code registers an event handler using a lambda that captures a weak reference to the recipient.</span></span>

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

<span data-ttu-id="c94aa-192">ラムダのキャプチャ句で、一時変数を作成し、*このオブジェクト*の弱参照を表示します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-192">In the lamba capture clause, a temporary variable is created, representing a weak reference to *this*.</span></span> <span data-ttu-id="c94aa-193">ラムダ式の本文で、*このオブジェクト*の強参照を取得する場合は、**OnCompositionScaleChanged** 関数が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-193">In the body of the lambda, if a strong reference to *this* can be obtained, then the **OnCompositionScaleChanged** function is called.</span></span> <span data-ttu-id="c94aa-194">これにより、**OnCompositionScaleChanged** 内で*このオブジェクト*を安全に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-194">That way, inside **OnCompositionScaleChanged**, *this* can safely be used.</span></span>

## <a name="weak-references-in-cwinrt"></a><span data-ttu-id="c94aa-195">C++/WinRT の弱参照</span><span class="sxs-lookup"><span data-stu-id="c94aa-195">Weak references in C++/WinRT</span></span>

<span data-ttu-id="c94aa-196">上記は、弱い参照が使用されている説明しました。</span><span class="sxs-lookup"><span data-stu-id="c94aa-196">Above, we saw weak references being used.</span></span> <span data-ttu-id="c94aa-197">一般に、循環参照の重大な場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="c94aa-197">In general, they're good for breaking cyclic references.</span></span> <span data-ttu-id="c94aa-198">XAML ベースの UI フレームワークのネイティブ実装の例では、&mdash;フレームワークの歴史的な設計により&mdash;弱い参照メカニズム C +/cli WinRT 循環参照を処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c94aa-198">For example, for the native implementation of the XAML-based UI framework&mdash;because of the historic design of the framework&mdash;the weak reference mechanism in C++/WinRT is necessary to handle cyclic references.</span></span> <span data-ttu-id="c94aa-199">XAML では、外部で、可能性があります必要はありません弱い参照を使用する (not が何も本質的に XAML 固有それらについて)。</span><span class="sxs-lookup"><span data-stu-id="c94aa-199">Outside of XAML, though, you likely won't need to use weak references (not that there's anything inherently XAML-specific about them).</span></span> <span data-ttu-id="c94aa-200">はなく、たいてい、はず設計独自 C +/cli WinRT Api の循環参照と弱い参照する必要が生じないようにします。</span><span class="sxs-lookup"><span data-stu-id="c94aa-200">Rather you should, more often than not, be able to design your own C++/WinRT APIs in such a way as to avoid the need for cyclic references and weak references.</span></span> 

<span data-ttu-id="c94aa-201">宣言するすべての型について、いつどこで弱参照が必要になるかが C++/WinRT に対してすぐに明白になるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="c94aa-201">For any given type that you declare, it's not immediately obvious to C++/WinRT whether or when weak references are needed.</span></span> <span data-ttu-id="c94aa-202">したがって、C++/WinRT は構造体テンプレート [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements) で弱参照サポートを自動的に提供し、そこから直接的または間接的に独自の C++/WinRT の型を派生します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-202">So, C++/WinRT provides weak reference support automatically on the struct template [**winrt::implements**](/uwp/cpp-ref-for-winrt/implements), from which your own C++/WinRT types directly or indirectly derive.</span></span> <span data-ttu-id="c94aa-203">利用に応じた料金制度であるため、オブジェクトが [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource) で実際に照会されない限り料金はかかりません。</span><span class="sxs-lookup"><span data-stu-id="c94aa-203">It's pay-for-play, in that it doesn't cost you anything unless your object is actually queried for [**IWeakReferenceSource**](/windows/desktop/api/weakreference/nn-weakreference-iweakreferencesource).</span></span> <span data-ttu-id="c94aa-204">また、[そのサポートを除外する](#opting-out-of-weak-reference-support)ことを明示的に選択することができます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-204">And you can choose explicitly to [opt out of that support](#opting-out-of-weak-reference-support).</span></span>

### <a name="code-examples"></a><span data-ttu-id="c94aa-205">コード例</span><span class="sxs-lookup"><span data-stu-id="c94aa-205">Code examples</span></span>
<span data-ttu-id="c94aa-206">[  **winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) 構造体テンプレートは、クラス インスタンスへの弱参照を取得するための 1 つのオプションです。</span><span class="sxs-lookup"><span data-stu-id="c94aa-206">The [**winrt::weak_ref**](/uwp/cpp-ref-for-winrt/weak-ref) struct template is one option for getting a weak reference to a class instance.</span></span>

```cppwinrt
Class c;
winrt::weak_ref<Class> weak{ c };
```

<span data-ttu-id="c94aa-207">または、[**winrt::make_weak**](/uwp/cpp-ref-for-winrt/make-weak) ヘルパー関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-207">Or, you can use the use the [**winrt::make_weak**](/uwp/cpp-ref-for-winrt/make-weak) helper function.</span></span>

```cppwinrt
Class c;
auto weak = winrt::make_weak(c);
```

<span data-ttu-id="c94aa-208">弱参照を作成してもオブジェクト自体の参照カウントには影響しません。制御ブロックが割り当てられるだけです。</span><span class="sxs-lookup"><span data-stu-id="c94aa-208">Creating a weak reference doesn't affect the reference count on the object itself; it just causes a control block to be allocated.</span></span> <span data-ttu-id="c94aa-209">その制御ブロックが弱参照セマンティクスの実装を処理します。</span><span class="sxs-lookup"><span data-stu-id="c94aa-209">That control block takes care of implementing the weak reference semantics.</span></span> <span data-ttu-id="c94aa-210">その後、弱参照から強参照への昇格を試みて、成功した場合は使用することができます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-210">You can then try to promote the weak reference to a strong reference and, if successful, use it.</span></span>

```cppwinrt
if (Class strong = weak.get())
{
    // use strong, for example strong.DoWork();
}
```

<span data-ttu-id="c94aa-211">他の強参照が存在する場合、[**weak_ref::get**](/uwp/cpp-ref-for-winrt/weak-ref#weakrefget-function) の呼び出しにより参照カウントが増分され、呼び出し元に強参照が返されます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-211">Provided that some other strong reference still exists, the [**weak_ref::get**](/uwp/cpp-ref-for-winrt/weak-ref#weakrefget-function) call increments the reference count and returns the strong reference to the caller.</span></span>

### <a name="opting-out-of-weak-reference-support"></a><span data-ttu-id="c94aa-212">弱参照サポートの除外</span><span class="sxs-lookup"><span data-stu-id="c94aa-212">Opting out of weak reference support</span></span>
<span data-ttu-id="c94aa-213">弱参照サポートは自動です。</span><span class="sxs-lookup"><span data-stu-id="c94aa-213">Weak reference support is automatic.</span></span> <span data-ttu-id="c94aa-214">ただし、[**winrt::no_weak_ref**](/uwp/cpp-ref-for-winrt/no-weak-ref) マーカー構造体をテンプレート引数として基底クラスに渡すことによって、そのサポートを明示的に除外することを選択できます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-214">But you can choose explicitly to opt out of that support by passing the [**winrt::no_weak_ref**](/uwp/cpp-ref-for-winrt/no-weak-ref) marker struct as a template argument to your base class.</span></span>

<span data-ttu-id="c94aa-215">**winrt::implements** から直接派生する場合。</span><span class="sxs-lookup"><span data-stu-id="c94aa-215">If you derive directly from **winrt::implements**.</span></span>

```cppwinrt
struct MyImplementation: implements<MyImplementation, IStringable, no_weak_ref>
{
    ...
}
```

<span data-ttu-id="c94aa-216">ランタイム クラスを作成している場合。</span><span class="sxs-lookup"><span data-stu-id="c94aa-216">If you're authoring a runtime class.</span></span>

```cppwinrt
struct MyRuntimeClass: MyRuntimeClassT<MyRuntimeClass, no_weak_ref>
{
    ...
}
```

<span data-ttu-id="c94aa-217">可変個引数パラメーター パックのどこにマーカー構造体が現れるかは関係ありません。</span><span class="sxs-lookup"><span data-stu-id="c94aa-217">It doesn't matter where in the variadic parameter pack the marker struct appears.</span></span> <span data-ttu-id="c94aa-218">除外された型に対して弱参照を要求すると、コンパイラーは "*これは弱参照サポート専用です*" というメッセージで知らせます。</span><span class="sxs-lookup"><span data-stu-id="c94aa-218">If you request a weak reference for an opted-out type, then the compiler will help you out with "*This is only for weak ref support*".</span></span>

## <a name="important-apis"></a><span data-ttu-id="c94aa-219">重要な API</span><span class="sxs-lookup"><span data-stu-id="c94aa-219">Important APIs</span></span>
* [<span data-ttu-id="c94aa-220">implements::get_weak 関数</span><span class="sxs-lookup"><span data-stu-id="c94aa-220">implements::get_weak function</span></span>](/uwp/cpp-ref-for-winrt/implements#implementsgetweak-function)
* [<span data-ttu-id="c94aa-221">winrt::make_weak 関数テンプレート</span><span class="sxs-lookup"><span data-stu-id="c94aa-221">winrt::make_weak function template</span></span>](/uwp/cpp-ref-for-winrt/make-weak)
* [<span data-ttu-id="c94aa-222">winrt::no_weak_ref マーカー構造体</span><span class="sxs-lookup"><span data-stu-id="c94aa-222">winrt::no_weak_ref marker struct</span></span>](/uwp/cpp-ref-for-winrt/no-weak-ref)
* [<span data-ttu-id="c94aa-223">winrt::weak_ref 構造体のテンプレート</span><span class="sxs-lookup"><span data-stu-id="c94aa-223">winrt::weak_ref struct template</span></span>](/uwp/cpp-ref-for-winrt/weak-ref)
