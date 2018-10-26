---
author: msatranjr
title: Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー
description: .NET Framework が Windows ランタイム コンポーネントをサポートすることにより、ユニバーサル Windows プラットフォーム (UWP) のイベント パターンと .NET Framework のイベント パターンの違いを意識することなく、イベント コンポーネントを簡単に宣言することができます。
ms.assetid: 6A66D80A-5481-47F8-9499-42AC8FDA0EB4
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 99e215f382bbfe409ac72d021540a471294634ca
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5549674"
---
# <a name="custom-events-and-event-accessors-in-windows-runtime-components"></a><span data-ttu-id="79f49-104">Windows ランタイム コンポーネントのカスタム イベントおよびイベント アクセサー</span><span class="sxs-lookup"><span data-stu-id="79f49-104">Custom events and event accessors in Windows Runtime Components</span></span>



<span data-ttu-id="79f49-105">.NET Framework が Windows ランタイム コンポーネントをサポートすることにより、ユニバーサル Windows プラットフォーム (UWP) のイベント パターンと .NET Framework のイベント パターンの違いを意識することなく、イベント コンポーネントを簡単に宣言することができます。</span><span class="sxs-lookup"><span data-stu-id="79f49-105">.NET Framework support for Windows Runtime Components makes it easy to declare events components by hiding the differences between the Universal Windows Platform (UWP) event pattern and the .NET Framework event pattern.</span></span> <span data-ttu-id="79f49-106">ただし、Windows ランタイム コンポーネントのカスタム イベント アクセサーを宣言する場合、UWP で使われるパターンに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="79f49-106">However, when you declare custom event accessors in a Windows Runtime Component, you must follow the pattern used in the UWP.</span></span>

## <a name="registering-events"></a><span data-ttu-id="79f49-107">イベントの登録</span><span class="sxs-lookup"><span data-stu-id="79f49-107">Registering events</span></span>


<span data-ttu-id="79f49-108">UWP のイベントを処理するための登録を行うと、add アクセサーはトークンを返します。</span><span class="sxs-lookup"><span data-stu-id="79f49-108">When you register to handle an event in the UWP, the add accessor returns a token.</span></span> <span data-ttu-id="79f49-109">登録を解除するには、このトークンを remove アクセサーに渡します。</span><span class="sxs-lookup"><span data-stu-id="79f49-109">To unregister, you pass this token to the remove accessor.</span></span> <span data-ttu-id="79f49-110">これは、UWP イベントの add と remove アクセサーが、これまで使ってきたアクセサーとは異なるシグニチャを持つことを意味します。</span><span class="sxs-lookup"><span data-stu-id="79f49-110">This means that the add and remove accessors for UWP events have different signatures from the accessors you're used to.</span></span>

<span data-ttu-id="79f49-111">Visual Basic と C# コンパイラはこのプロセスを簡略化します。Windows ランタイム コンポーネントのカスタム アクセサーでイベントを宣言すると、コンパイラは自動的に UWP パターンを使います。</span><span class="sxs-lookup"><span data-stu-id="79f49-111">Fortunately, the Visual Basic and C# compilers simplify this process: When you declare an event with custom accessors in a Windows Runtime Component, the compilers automatically use the UWP pattern.</span></span> <span data-ttu-id="79f49-112">たとえば、add アクセサーがトークンを返さない場合、コンパイル エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="79f49-112">For example, you get a compiler error if your add accessor doesn't return a token.</span></span> <span data-ttu-id="79f49-113">.NET Framework には、実装をサポートするための 2 種類の型が用意されています。</span><span class="sxs-lookup"><span data-stu-id="79f49-113">The .NET Framework provides two types to support the implementation:</span></span>

-   <span data-ttu-id="79f49-114">[EventRegistrationToken](https://msdn.microsoft.com/library/windows/apps/windows.foundation.eventregistrationtoken.aspx) 構造体はトークンを表します。</span><span class="sxs-lookup"><span data-stu-id="79f49-114">The [EventRegistrationToken](https://msdn.microsoft.com/library/windows/apps/windows.foundation.eventregistrationtoken.aspx) structure represents the token.</span></span>
-   <span data-ttu-id="79f49-115">[EventRegistrationTokenTable&lt;T&gt;](https://msdn.microsoft.com/library/hh138412.aspx) クラスはトークンを作成し、トークンとイベント ハンドラーの間の対応付けを保持します。</span><span class="sxs-lookup"><span data-stu-id="79f49-115">The [EventRegistrationTokenTable&lt;T&gt;](https://msdn.microsoft.com/library/hh138412.aspx) class creates tokens and maintains a mapping between tokens and event handlers.</span></span> <span data-ttu-id="79f49-116">ジェネリック型引数は、イベント引数の型です。</span><span class="sxs-lookup"><span data-stu-id="79f49-116">The generic type argument is the event argument type.</span></span> <span data-ttu-id="79f49-117">イベント ハンドラーがイベントに対して最初に登録されたときに、イベントごとにこのクラスのインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="79f49-117">You create an instance of this class for each event, the first time an event handler is registered for that event.</span></span>

<span data-ttu-id="79f49-118">NumberChanged イベントの次のコードは、UWP イベントの基本パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="79f49-118">The following code for the NumberChanged event shows the basic pattern for UWP events.</span></span> <span data-ttu-id="79f49-119">この例では、イベント引数オブジェクトのコンストラクターである NumberChangedEventArgs は、変更された数値を表す単一の整数パラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="79f49-119">In this example, the constructor for the event argument object, NumberChangedEventArgs, takes a single integer parameter that represents the changed numeric value.</span></span>

> <span data-ttu-id="79f49-120">**注:** これは Windows ランタイム コンポーネントで宣言する通常のイベントのコンパイラが使う同じパターンです。</span><span class="sxs-lookup"><span data-stu-id="79f49-120">**Note**This is the same pattern the compilers use for ordinary events that you declare in a Windows Runtime Component.</span></span>

 
> [!div class="tabbedCodeSnippets"]
> ```csharp
> private EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>     m_NumberChangedTokenTable = null;
>
> public event EventHandler<NumberChangedEventArgs> NumberChanged
> {
>     add
>     {
>         return EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .AddEventHandler(value);
>     }
>     remove
>     {
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .RemoveEventHandler(value);
>     }
> }
>
> internal void OnNumberChanged(int newValue)
> {
>     EventHandler<NumberChangedEventArgs> temp =
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>         .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>         .InvocationList;
>     if (temp != null)
>     {
>         temp(this, new NumberChangedEventArgs(newValue));
>     }
> }
> ```
> ```vb
> Private m_NumberChangedTokenTable As  _
>     EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs))
>
> Public Custom Event NumberChanged As EventHandler(Of NumberChangedEventArgs)
>
>     AddHandler(ByVal handler As EventHandler(Of NumberChangedEventArgs))
>         Return EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             AddEventHandler(handler)
>     End AddHandler
>
>     RemoveHandler(ByVal token As EventRegistrationToken)
>         EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             RemoveEventHandler(token)
>     End RemoveHandler
>
>     RaiseEvent(ByVal sender As Class1, ByVal args As NumberChangedEventArgs)
>         Dim temp As EventHandler(Of NumberChangedEventArgs) = _
>             EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             InvocationList
>         If temp IsNot Nothing Then
>             temp(sender, args)
>         End If
>     End RaiseEvent
> End Event
> ```

<span data-ttu-id="79f49-121">static (Visual Basic では Shared) GetOrCreateEventRegistrationTokenTable メソッドは、イベントの EventRegistrationTokenTable&lt;T&gt; オブジェクトのインスタンスを限定的に作成します。</span><span class="sxs-lookup"><span data-stu-id="79f49-121">The static (Shared in Visual Basic) GetOrCreateEventRegistrationTokenTable method creates the event’s instance of the EventRegistrationTokenTable&lt;T&gt; object lazily.</span></span> <span data-ttu-id="79f49-122">トークン テーブルのインスタンスを保持するクラス レベルのフィールドを、このメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="79f49-122">Pass the class-level field that will hold the token table instance to this method.</span></span> <span data-ttu-id="79f49-123">フィールドが空の場合、メソッドはテーブルを作成し、テーブルへの参照をフィールドに格納し、テーブルへの参照を返します。</span><span class="sxs-lookup"><span data-stu-id="79f49-123">If the field is empty, the method creates the table, stores a reference to the table in the field, and returns a reference to the table.</span></span> <span data-ttu-id="79f49-124">フィールドにトークン テーブルへの参照が既に含まれている場合、このメソッドはその参照を返します。</span><span class="sxs-lookup"><span data-stu-id="79f49-124">If the field already contains a token table reference, the method just returns that reference.</span></span>

> <span data-ttu-id="79f49-125">**重要な**スレッド セーフでは、イベントの EventRegistrationTokenTable インスタンスを保持するフィールドを確認する&lt;T&gt;クラス レベルのフィールドである必要があります。</span><span class="sxs-lookup"><span data-stu-id="79f49-125">**Important**To ensure thread safety, the field that holds the event’s instance of EventRegistrationTokenTable&lt;T&gt; must be a class-level field.</span></span> <span data-ttu-id="79f49-126">クラス レベルのフィールドである場合、GetOrCreateEventRegistrationTokenTable メソッドでは、複数のスレッドがトークン テーブルの作成を試みるときに、すべてのスレッドでテーブルの同じインスタンスが取得されます。</span><span class="sxs-lookup"><span data-stu-id="79f49-126">If it is a class-level field, the GetOrCreateEventRegistrationTokenTable method ensures that when multiple threads try to create the token table, all threads get the same instance of the table.</span></span> <span data-ttu-id="79f49-127">特定のイベントでは、GetOrCreateEventRegistrationTokenTable メソッドのすべての呼び出しは、同じクラス レベルのフィールドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="79f49-127">For a given event, all calls to the GetOrCreateEventRegistrationTokenTable method must use the same class-level field.</span></span>

<span data-ttu-id="79f49-128">remove アクセサーや [RaiseEvent](https://msdn.microsoft.com/library/fwd3bwed.aspx) メソッド (C# では OnRaiseEvent メソッド) で GetOrCreateEventRegistrationTokenTable メソッドを呼び出すことによって、イベント ハンドラー デリゲートが追加される前にこれらのメソッドを呼び出した場合、例外は発生しません。</span><span class="sxs-lookup"><span data-stu-id="79f49-128">Calling the GetOrCreateEventRegistrationTokenTable method in the remove accessor and in the [RaiseEvent](https://msdn.microsoft.com/library/fwd3bwed.aspx) method (the OnRaiseEvent method in C#) ensures that no exceptions occur if these methods are called before any event handler delegates have been added.</span></span>

<span data-ttu-id="79f49-129">UWP イベント パターンで使われる EventRegistrationTokenTable&lt;T&gt; クラスの他のメンバーには、次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="79f49-129">The other members of the EventRegistrationTokenTable&lt;T&gt; class that are used in the UWP event pattern include the following:</span></span>

-   <span data-ttu-id="79f49-130">[AddEventHandler](https://msdn.microsoft.com/library/hh138458.aspx) メソッドは、イベント ハンドラー デリゲートのトークンを生成し、デリゲートをテーブルに保存し、デリゲートを呼び出しリストに追加して、トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="79f49-130">The [AddEventHandler](https://msdn.microsoft.com/library/hh138458.aspx) method generates a token for the event handler delegate, stores the delegate in the table, adds it to the invocation list, and returns the token.</span></span>
-   <span data-ttu-id="79f49-131">[RemoveEventHandler(EventRegistrationToken)](https://msdn.microsoft.com/library/hh138425.aspx) メソッド オーバーロードは、テーブルと呼び出しリストからデリゲートを削除します。</span><span class="sxs-lookup"><span data-stu-id="79f49-131">The [RemoveEventHandler(EventRegistrationToken)](https://msdn.microsoft.com/library/hh138425.aspx) method overload removes the delegate from the table and from the invocation list.</span></span>

    ><span data-ttu-id="79f49-132">**注:**、AddEventHandler と removeeventhandler (eventregistrationtoken) メソッドは、スレッド セーフを確保するためにテーブルをロックします。</span><span class="sxs-lookup"><span data-stu-id="79f49-132">**Note**The AddEventHandler and RemoveEventHandler(EventRegistrationToken) methods lock the table to help ensure thread safety.</span></span>

-   <span data-ttu-id="79f49-133"> [InvocationList](https://msdn.microsoft.com/library/hh138465.aspx) プロパティは、イベントを処理するために現在登録されているすべてのイベント ハンドラーを含むデリゲートを返します。</span><span class="sxs-lookup"><span data-stu-id="79f49-133">The [InvocationList](https://msdn.microsoft.com/library/hh138465.aspx) property returns a delegate that includes all the event handlers that are currently registered to handle the event.</span></span> <span data-ttu-id="79f49-134">このデリゲートを使ってイベントを発生させるか、Delegate クラスのメソッドを使ってハンドラーを個別に呼び出します。</span><span class="sxs-lookup"><span data-stu-id="79f49-134">Use this delegate to raise the event, or use the methods of the Delegate class to invoke the handlers individually.</span></span>

    ><span data-ttu-id="79f49-135">**注:**、この記事の前半での例で示したパターンに従うし、デリゲートを呼び出す前に一時変数にコピーことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="79f49-135">**Note**We recommend that you follow the pattern shown in the example provided earlier in this article, and copy the delegate to a temporary variable before invoking it.</span></span> <span data-ttu-id="79f49-136">これにより、あるスレッドが最後のハンドラーを削除して、別のスレッドがデリゲートを呼び出す直前にデリゲートが null となる競合状態を回避できます。</span><span class="sxs-lookup"><span data-stu-id="79f49-136">This avoids a race condition in which one thread removes the last handler, reducing the delegate to null just before another thread tries to invoke the delegate.</span></span> <span data-ttu-id="79f49-137">デリゲートは変更できないため、コピーは引き続き有効です。</span><span class="sxs-lookup"><span data-stu-id="79f49-137">Delegates are immutable, so the copy is still valid.</span></span>

<span data-ttu-id="79f49-138">必要に応じて、独自のコードをアクセサーに配置します。</span><span class="sxs-lookup"><span data-stu-id="79f49-138">Place your own code in the accessors as appropriate.</span></span> <span data-ttu-id="79f49-139">スレッド セーフが問題の場合、独自のロックをコードに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="79f49-139">If thread safety is an issue, you must provide your own locking for your code.</span></span>

<span data-ttu-id="79f49-140">C# ユーザー: UWP イベント パターンでカスタム イベント アクセサーを作成すると、コンパイラは通常の構文のショートカットを提供しません。</span><span class="sxs-lookup"><span data-stu-id="79f49-140">C# users: When you write custom event accessors in the UWP event pattern, the compiler doesn't provide the usual syntactic shortcuts.</span></span> <span data-ttu-id="79f49-141">コードでイベント名を使うとエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="79f49-141">It generates errors if you use the name of the event in your code.</span></span>

<span data-ttu-id="79f49-142">Visual Basic ユーザー: .NET Framework では、イベントは登録されたすべてのイベント ハンドラーを表すマルチキャスト デリゲートにすぎません。</span><span class="sxs-lookup"><span data-stu-id="79f49-142">Visual Basic users: In the .NET Framework, an event is just a multicast delegate that represents all the registered event handlers.</span></span> <span data-ttu-id="79f49-143">イベントを発生させることは、デリゲートを呼び出すことを意味します。</span><span class="sxs-lookup"><span data-stu-id="79f49-143">Raising the event just means invoking the delegate.</span></span> <span data-ttu-id="79f49-144">一般に、Visual Basic の構文はデリゲートとの対話を非表示にします。また、スレッド セーフに関するメモに説明されているように、コンパイラはデリゲートを呼び出す前にデリゲートをコピーします。</span><span class="sxs-lookup"><span data-stu-id="79f49-144">Visual Basic syntax generally hides the interactions with the delegate, and the compiler copies the delegate before invoking it, as described in the note about thread safety.</span></span> <span data-ttu-id="79f49-145">Windows ランタイム コンポーネントでカスタム イベントを作成する場合、デリゲートを直接扱う必要があります。</span><span class="sxs-lookup"><span data-stu-id="79f49-145">When you create a custom event in a Windows Runtime Component, you have to deal with the delegate directly.</span></span> <span data-ttu-id="79f49-146">これは、たとえばハンドラーを個別に呼び出す場合、[MulticastDelegate.GetInvocationList](https://msdn.microsoft.com/library/system.multicastdelegate.getinvocationlist.aspx) メソッドを使って、イベント ハンドラーごとに個別のデリゲートが含まれる配列を取得できることも意味します。</span><span class="sxs-lookup"><span data-stu-id="79f49-146">This also means that you can, for example, use the [MulticastDelegate.GetInvocationList](https://msdn.microsoft.com/library/system.multicastdelegate.getinvocationlist.aspx) method to get an array that contains a separate delegate for each event handler, if you want to invoke the handlers separately.</span></span>

## <a name="related-topics"></a><span data-ttu-id="79f49-147">関連トピック</span><span class="sxs-lookup"><span data-stu-id="79f49-147">Related topics</span></span>

* [<span data-ttu-id="79f49-148">イベント (Visual Basic)</span><span class="sxs-lookup"><span data-stu-id="79f49-148">Events (Visual Basic)</span></span>](https://msdn.microsoft.com/library/ms172877.aspx)
* [<span data-ttu-id="79f49-149">イベント (C# プログラミング ガイド)</span><span class="sxs-lookup"><span data-stu-id="79f49-149">Events (C# Programming Guide)</span></span>](https://msdn.microsoft.com/library/awbftdfh.aspx)
* [<span data-ttu-id="79f49-150">UWP アプリの概要の .NET</span><span class="sxs-lookup"><span data-stu-id="79f49-150">.NET for UWP apps Overview</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)
* [<span data-ttu-id="79f49-151">UWP アプリの .NET</span><span class="sxs-lookup"><span data-stu-id="79f49-151">.NET for UWP apps</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)
* [<span data-ttu-id="79f49-152">チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し</span><span class="sxs-lookup"><span data-stu-id="79f49-152">Walkthrough: Creating a Simple Windows Runtime Component and calling it from JavaScript</span></span>](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)
