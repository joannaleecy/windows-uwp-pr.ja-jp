---
title: Windows ランタイム コンポーネントでイベントを生成する
ms.assetid: 3F7744E8-8A3C-4203-A1CE-B18584E89000
description: JavaScript は、イベントを受信することができるように、バック グラウンド スレッドでユーザー定義のデリゲート型のイベントを発生させる方法。
ms.date: 07/19/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 851f8a25055c90dfd592d5a68c733258bcd5f7b5
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8198226"
---
# <a name="raising-events-in-windows-runtime-components"></a><span data-ttu-id="6b4fc-104">Windows ランタイム コンポーネントでイベントを生成する</span><span class="sxs-lookup"><span data-stu-id="6b4fc-104">Raising Events in Windows Runtime Components</span></span>
> [!NOTE]
> <span data-ttu-id="6b4fc-105">イベントを発生させる方法については、 [、C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) Windows ランタイム コンポーネントを参照してください[、C++ でのイベントの作成/WinRT](../cpp-and-winrt-apis/author-events.md)します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-105">To learn how to raise events in a [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) Windows Runtime Component, see [Author events in C++/WinRT](../cpp-and-winrt-apis/author-events.md).</span></span>

<span data-ttu-id="6b4fc-106">Windows ランタイム コンポーネントを使って、ユーザー定義のデリゲート型のイベントをバック グラウンド スレッド (ワーカー スレッド) で発生させ、このイベントを JavaScript で受け取る場合、以下のいずれかの方法でイベントを実装し、発生させることができます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-106">If your Windows Runtime component raises an event of a user-defined delegate type on a background thread (worker thread) and you want JavaScript to be able to receive the event, you can implement and/or raise it in one of these ways:</span></span>

-   <span data-ttu-id="6b4fc-107">(オプション 1) [Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) でイベントを生成し、JavaScript のスレッド コンテキストにマーシャリングします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-107">(Option 1) Raise the event through the [Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) to marshal the event to the JavaScript thread context.</span></span> <span data-ttu-id="6b4fc-108">通常はこれが最適な方法ですが、シナリオによっては最速のパフォーマンスを実現できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-108">Although typically this is the best option, in some scenarios it might not provide the fastest performance.</span></span>
-   <span data-ttu-id="6b4fc-109">(オプション 2) [Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; を使用します。ただし、型情報が失われます (ただし、イベントの型情報が失われます)。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-109">(Option 2) Use [Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; but lose type information (but lose the event type information).</span></span> <span data-ttu-id="6b4fc-110">オプション 1 を実行できない場合、または十分なパフォーマンスが得られない場合、型情報が失われても問題がなければ、これは 2 番目に良い方法です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-110">If Option 1 is not feasible or its performance is not adequate, then this is a good second choice if loss of type information is acceptable.</span></span>
-   <span data-ttu-id="6b4fc-111">(オプション 3) コンポーネントに対し、独自のプロキシとスタブを作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-111">(Option 3) Create your own proxy and stub for the component.</span></span> <span data-ttu-id="6b4fc-112">このオプションは実装が最も難しいですが、型情報も保持され、要求が厳しいシナリオの場合に、オプション 1 よりパフォーマンスが高くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-112">This option is the most difficult to implement, but it preserves type information and might provide better performance compared to Option 1 in demanding scenarios.</span></span>

<span data-ttu-id="6b4fc-113">これらのオプションをいずれも使用せずに、バックグラウンド スレッドでイベントを生成すると、JavaScript クライアントはイベントを受け取りません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-113">If you just raise an event on a background thread without using one of these options, a JavaScript client will not receive the event.</span></span>

## <a name="background"></a><span data-ttu-id="6b4fc-114">背景</span><span class="sxs-lookup"><span data-stu-id="6b4fc-114">Background</span></span>

<span data-ttu-id="6b4fc-115">すべての Windows ランタイム コンポーネントとアプリは、どの言語を使用して作成しても、基本的に COM オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-115">All Windows Runtime components and apps are fundamentally COM objects, no matter what language you use to create them.</span></span> <span data-ttu-id="6b4fc-116">Windows API では、ほとんどのコンポーネントはアジャイル COM オブジェクトで、バックグラウンド スレッドと UI スレッドで同じようにオブジェクトと通信できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-116">In the Windows API, most of the components are agile COM objects that can communicate equally well with objects on the background thread and on the UI thread.</span></span> <span data-ttu-id="6b4fc-117">COM オブジェクトをアジャイルにできない場合は、UI スレッドとバックグラウンド スレッドの境界を越えて他の COM オブジェクトと通信できるように、プロキシおよびスタブと呼ばれるヘルパー オブジェクトが必要になります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-117">If a COM object can’t be made agile, then it requires helper objects known as proxies and stubs to communicate with other COM objects across the UI thread-background thread boundary.</span></span> <span data-ttu-id="6b4fc-118">(COM の用語では、これをスレッド アパートメント間の通信と呼びます。)</span><span class="sxs-lookup"><span data-stu-id="6b4fc-118">(In COM terms, this is known as communication between thread apartments.)</span></span>

<span data-ttu-id="6b4fc-119">Windows API のほとんどのオブジェクトは、アジャイルであるか、プロキシとスタブが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-119">Most of the objects in the Windows API are either agile or have proxies and stubs built in.</span></span> <span data-ttu-id="6b4fc-120">ただし、Windows.Foundation.[TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) などのジェネリックな型は、型引数を指定するまでは完全な型ではないため、プロキシとスタブを作成できません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-120">However, proxies and stubs can’t be created for generic types such as Windows.Foundation.[TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) because they are not complete types until you provide the type argument.</span></span> <span data-ttu-id="6b4fc-121">プロキシまたはスタブがないために問題が発生するのは、JavaScript クライアントのみですが、コンポーネントを C++ や .NET 言語からだけでなく JavaScript からも使用したい場合は、次の 3 つのオプションのいずれかを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-121">It's only with JavaScript clients that the lack of proxies or stubs becomes an issue, but if you want your component to be usable from JavaScript as well as from C++ or a .NET language, then you must use one of the following three options.</span></span>

## <a name="option-1-raise-the-event-through-the-coredispatcher"></a><span data-ttu-id="6b4fc-122">(オプション 1) CoreDispatcher でイベントを生成する</span><span class="sxs-lookup"><span data-stu-id="6b4fc-122">(Option 1) Raise the event through the CoreDispatcher</span></span>

<span data-ttu-id="6b4fc-123">[Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx) を使用するとユーザー定義のデリゲート型のイベントを送信でき、JavaScript でそのイベントを受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-123">You can send events of any user-defined delegate type by using the [Windows.UI.Core.CoreDispatcher](https://msdn.microsoft.com/library/windows/apps/windows.ui.core.coredispatcher.aspx), and JavaScript will be able to receive them.</span></span> <span data-ttu-id="6b4fc-124">どのオプションを使用すればよいかわからない場合は、最初にこのオプションを試してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-124">If you are unsure which option to use, try this one first.</span></span> <span data-ttu-id="6b4fc-125">イベントの発生からイベントの処理までの待ち時間が問題になる場合は、他のオプションを試してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-125">If latency between the event firing and the event handling becomes an issue, then try one of the other options.</span></span>

<span data-ttu-id="6b4fc-126">次の例は、CoreDispatcher を使用して厳密に型指定されされたイベントを生成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-126">The following example shows how to use the CoreDispatcher to raise a strongly-typed event.</span></span> <span data-ttu-id="6b4fc-127">型引数は Toast で、Object ではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-127">Notice that the type argument is Toast, not Object.</span></span>

```csharp
public event EventHandler<Toast> ToastCompletedEvent;
private void OnToastCompleted(Toast args)
{
    var completedEvent = ToastCompletedEvent;
    if (completedEvent != null)
    {
        completedEvent(this, args);
    }
}

public void MakeToastWithDispatcher(string message)
{
    Toast toast = new Toast(message);
    // Assume you have a CoreDispatcher at class scope.
    // Initialize it here, then use it from the background thread.
    var window = Windows.UI.Core.CoreWindow.GetForCurrentThread();
    m_dispatcher = window.Dispatcher;

    Task.Run( () =>
    {
        if (ToastCompletedEvent != null)
        {
            m_dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            new DispatchedHandler(() =>
            {
                this.OnToastCompleted(toast);
            })); // end m_dispatcher.RunAsync
         }
     }); // end Task.Run
}
```

## <a name="option-2-use-eventhandlerltobjectgt-but-lose-type-information"></a><span data-ttu-id="6b4fc-128">(オプション 2) EventHandler&lt;Object&gt; を使用するが、型情報が失われる</span><span class="sxs-lookup"><span data-stu-id="6b4fc-128">(Option 2) Use EventHandler&lt;Object&gt; but lose type information</span></span>

<span data-ttu-id="6b4fc-129">バック グラウンド スレッドからイベントを送信するもう 1 つの方法は、[Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; をイベントの型として使用することです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-129">Another way to send an event from a background thread is to use [Windows.Foundation.EventHandler](https://msdn.microsoft.com/library/windows/apps/br206577.aspx)&lt;Object&gt; as the type of the event.</span></span> <span data-ttu-id="6b4fc-130">Windows により、ジェネリック型が具体的にインスタンス化され、プロキシとスタブが提供されます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-130">Windows provides this concrete instantiation of the generic type and provides a proxy and stub for it.</span></span> <span data-ttu-id="6b4fc-131">欠点は、イベント引数の型情報と送信者が失われることです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-131">The downside is that the type information of your event args and sender is lost.</span></span> <span data-ttu-id="6b4fc-132">C++ および .NET クライアントは、イベントを受け取ったときにキャストする型の情報をドキュメントから得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-132">C++ and .NET clients must know through documentation what type to cast back to when the event is received.</span></span> <span data-ttu-id="6b4fc-133">JavaScript クライアントでは、元の型情報は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-133">JavaScript clients don’t need the original type information.</span></span> <span data-ttu-id="6b4fc-134">メタデータの名前に基づいて、引数のプロパティを見つけます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-134">They find the arg properties, based on their names in the metadata.</span></span>

<span data-ttu-id="6b4fc-135">次の例は、C# で Windows.Foundation.EventHandler&lt;Object&gt; を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-135">This example shows how to use Windows.Foundation.EventHandler&lt;Object&gt; in C#:</span></span>

```csharp
public sealed Class1
{
// Declare the event
public event EventHandler<Object> ToastCompletedEvent;

    // Raise the event
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message);
        // Fire the event from a background thread to allow this thread to continue
        Task.Run(() =>
        {
            if (ToastCompletedEvent != null)
            {
                OnToastCompleted(toast);
            }
        });
    }

    private void OnToastCompleted(Toast args)
    {
        var completedEvent = ToastCompletedEvent;
        if (completedEvent != null)
        {
            completedEvent(this, args);
        }
    }
}
```

<span data-ttu-id="6b4fc-136">JavaScript 側では、次のようにこのイベントを利用します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-136">You consume this event on the JavaScript side like this:</span></span>

```javascript
toastCompletedEventHandler: function (event) {
   var toastType = event.toast.toastType;
   document.getElementById("toasterOutput").innerHTML = "<p>Made " + toastType + " toast</p>";
}
```

## <a name="option-3-create-your-own-proxy-and-stub"></a><span data-ttu-id="6b4fc-137">(オプション 3) 独自のプロキシとスタブを作成する</span><span class="sxs-lookup"><span data-stu-id="6b4fc-137">(Option 3) Create your own proxy and stub</span></span>

<span data-ttu-id="6b4fc-138">型情報を完全に保持するユーザー定義のイベント型で十分なパフォーマンスを得るには、独自のプロキシとスタブのオブジェクトを作成し、アプリ パッケージに埋め込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-138">For potential performance gains on user-defined event types that have fully-preserved type information, you have to create your own proxy and stub objects and embed them in your app package.</span></span> <span data-ttu-id="6b4fc-139">通常、このオプションを使用しなければならないのはまれで、他の 2 つのオプションをどちらも使用できない場合のみです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-139">Typically, you have to use this option only in rare situations where neither of the other two options are adequate.</span></span> <span data-ttu-id="6b4fc-140">また、このオプションで他の 2 つのオプションよりも高いパフォーマンスが実現されるという保証はありません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-140">Also, there is no guarantee that this option will provide better performance than the other two options.</span></span> <span data-ttu-id="6b4fc-141">実際のパフォーマンスは、さまざまな要因によって決まります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-141">Actual performance depends on many factors.</span></span> <span data-ttu-id="6b4fc-142">アプリケーションでの実際のパフォーマンスを測定し、イベントが実際にボトルネックになっているかどうかを判別するには、Visual Studio プロファイラーまたは他のプロファイリング ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-142">Use the Visual Studio profiler or other profiling tools to measure actual performance in your application and determine whether the event is in fact a bottleneck.</span></span>

<span data-ttu-id="6b4fc-143">ここからは、C# を使用して基本的な Windows ランタイム コンポーネントを作成した後、C++ を使用してプロキシおよびスタブの DLL を作成する方法について説明します。これにより、非同期操作でコンポーネントにより生成された Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt; イベントを、JavaScript で利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-143">The rest of this article shows how to use C# to create a basic Windows Runtime component, and then use C++ to create a DLL for the proxy and stub that will enable JavaScript to consume a Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt; event that's raised by the component in an async operation.</span></span> <span data-ttu-id="6b4fc-144">(C++ または Visual Basic を使用してコンポーネントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-144">(You can also use C++ or Visual Basic to create the component.</span></span> <span data-ttu-id="6b4fc-145">プロキシとスタブの作成に関連する手順は同じです。このチュートリアルは、Windows ランタイム インプロセス コンポーネントを作成するサンプル (C++/CX) に基づいて、その目的を説明します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-145">The steps that are related to creating the proxies and stubs are the same.) This walkthrough is based on Creating a Windows Runtime in-process component sample (C++/CX) and helps explain its purposes.</span></span>

<span data-ttu-id="6b4fc-146">このチュートリアルの内容は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-146">This walkthrough has these parts:</span></span>

-   <span data-ttu-id="6b4fc-147">ここでは、2 つの基本的な Windows ランタイム クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-147">Here you will create two basic Windows Runtime classes.</span></span> <span data-ttu-id="6b4fc-148">1 つのクラスでは、[Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) 型のイベントを公開し、もう 1 つのクラスは、TValue の引数として JavaScript に返される型です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-148">One class exposes an event of type [Windows.Foundation.TypedEventHandler&lt;TSender, TResult&gt;](https://msdn.microsoft.com/library/windows/apps/br225997.aspx) and the other class is the type that's returned to JavaScript as the argument for TValue.</span></span> <span data-ttu-id="6b4fc-149">後の手順を完了するまで、これらのクラスは JavaScript と通信できません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-149">These classes can't communicate with JavaScript until you complete the later steps.</span></span>
-   <span data-ttu-id="6b4fc-150">このアプリは、メイン クラス オブジェクトをアクティブ化し、メソッドを呼び出して、Windows ランタイム コンポーネントで生成されたイベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-150">This app activates the main class object, calls a method, and handles an event that's raised by the Windows Runtime component.</span></span>
-   <span data-ttu-id="6b4fc-151">これらはプロキシおよびスタブのクラスを生成するツールで必要です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-151">These are required by the tools that generate the proxy and stub classes.</span></span>
-   <span data-ttu-id="6b4fc-152">その後、IDL ファイルを使用して、プロキシおよびスタブの C ソース コードを生成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-152">You then use the IDL file to generate the C source code for the proxy and stub.</span></span>
-   <span data-ttu-id="6b4fc-153">プロキシ/スタブ オブジェクトを登録すると、COM ランタイムがこれらを認識し、アプリ プロジェクトでプロキシ/スタブ DLL を参照できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-153">Register the proxy-stub objects so that the COM runtime can find them, and reference the proxy-stub DLL in the app project.</span></span>

## <a name="to-create-the-windows-runtime-component"></a><span data-ttu-id="6b4fc-154">Windows ランタイム コンポーネントを作成するには</span><span class="sxs-lookup"><span data-stu-id="6b4fc-154">To create the Windows Runtime component</span></span>

<span data-ttu-id="6b4fc-155">Visual Studio のメニュー バーから **[ファイル]、[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-155">In Visual Studio, on the menu bar, choose **File &gt; New Project**.</span></span> <span data-ttu-id="6b4fc-156">**[新しいプロジェクト]** ダイアログ ボックスで、**[JavaScript]、[ユニバーサル Windows]** の順に展開し、**[空のアプリケーション]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-156">In the **New Project** dialog box, expand **JavaScript &gt; Universal Windows** and then select **Blank App**.</span></span> <span data-ttu-id="6b4fc-157">プロジェクトに、「ToasterApplication」という名前を付け、**[OK]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-157">Name the project ToasterApplication and then choose the **OK** button.</span></span>

<span data-ttu-id="6b4fc-158">ソリューションに C# Windows ランタイム コンポーネントを追加します。ソリューション エクスプ ローラーで、ソリューションのショートカット メニューを開き、**[追加]、[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-158">Add a C# Windows Runtime component to the solution: In Solution Explorer, open the shortcut menu for the solution and then choose **Add &gt; New Project**.</span></span> <span data-ttu-id="6b4fc-159">展開**Visual C#] &gt; Microsoft Store**し、 **Windows ランタイム コンポーネント**を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-159">Expand **Visual C# &gt; Microsoft Store** and then select **Windows Runtime Component**.</span></span> <span data-ttu-id="6b4fc-160">プロジェクトに、「ToasterComponent」という名前を付け、**[OK]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-160">Name the project ToasterComponent and then choose the **OK** button.</span></span> <span data-ttu-id="6b4fc-161">ToasterComponent は、後の手順で作成するコンポーネントのルート名前空間になります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-161">ToasterComponent will be the root namespace for the components you will create in later steps.</span></span>

<span data-ttu-id="6b4fc-162">ソリューション エクスプローラーでソリューションのショートカット メニューを開き、**[プロパティ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-162">In Solution Explorer, open the shortcut menu for the solution and then choose **Properties**.</span></span> <span data-ttu-id="6b4fc-163">**[プロパティ ページ]** ダイアログ ボックスの左側のウィンドウで、**[構成プロパティ]** を選択して、ダイアログ ボックスの上部の **[構成]** を **[デバッグ]** に、**[プラットフォーム]** を [x86]、[x64]、または [ARM] に設定します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-163">In the **Property Pages** dialog box, select **Configuration Properties** in the left pane, and then at the top of the dialog box, set **Configuration** to **Debug** and **Platform** to x86, x64, or ARM.</span></span> <span data-ttu-id="6b4fc-164">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-164">Choose the **OK** button.</span></span>

<span data-ttu-id="6b4fc-165">**重要な**プラットフォーム = 後で、ソリューションに追加するネイティブ コード Win32 DLL の無効であるために、任意の CPU は機能しません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-165">**Important**Platform = Any CPU won’t work because it's not valid for the native-code Win32 DLL that you'll add to the solution later.</span></span>

<span data-ttu-id="6b4fc-166">ソリューション エクスプ ローラーで、「class1.cs」を「ToasterComponent.cs」という名前に変更して、プロジェクトの名前と一致するようにします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-166">In Solution Explorer, rename class1.cs to ToasterComponent.cs so that it matches the name of the project.</span></span> <span data-ttu-id="6b4fc-167">Visual Studio により、新しいファイル名と一致するように、ファイル内のクラス名が自動的に変更されます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-167">Visual Studio automatically renames the class in the file to match the new file name.</span></span>

<span data-ttu-id="6b4fc-168">.cs ファイルで、Windows.Foundation 名前空間の using ディレクティブを追加して、TypedEventHandler をスコープに取り込みます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-168">In the .cs file, add a using directive for the Windows.Foundation namespace to bring TypedEventHandler into scope.</span></span>

<span data-ttu-id="6b4fc-169">プロキシとスタブが必要な場合、コンポーネントではインターフェイスを使用して、パブリック メンバーを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-169">When you require proxies and stubs, your component must use interfaces to expose its public members.</span></span> <span data-ttu-id="6b4fc-170">ToasterComponent.cs では、トースター用に 1 つ、トースターが生成するトースト用にもう 1 つインターフェイスを定義します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-170">In ToasterComponent.cs, define an interface for the toaster, and another one for the Toast that the toaster produces.</span></span>

<span data-ttu-id="6b4fc-171">**注:** c# ではこの手順を省略することができます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-171">**Note**In C# you can skip this step.</span></span> <span data-ttu-id="6b4fc-172">代わりに、クラスを作成した後に、ショートカット メニューを開き、**[リファクター]、[インターフェイスの抽出]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-172">Instead, first create a class, and then open its shortcut menu and choose **Refactor &gt; Extract Interface**.</span></span> <span data-ttu-id="6b4fc-173">生成されたコードで、インターフェイスのパブリック アクセシビリティを手動で指定します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-173">In the code that's generated, manually give the interfaces public accessibility.</span></span>

```csharp
    public interface IToaster
        {
            void MakeToast(String message);
            event TypedEventHandler<Toaster, Toast> ToastCompletedEvent;

        }
        public interface IToast
        {
            String ToastType { get; }
        }
```

<span data-ttu-id="6b4fc-174">IToast インターフェイスには、トーストの型を取得して書き込むことができる文字列があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-174">The IToast interface has a string that can be retrieved to describe the type of toast.</span></span> <span data-ttu-id="6b4fc-175">IToaster インターフェイスには、トーストを作成するメソッドと、トーストが作成されたことを示すイベントがあります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-175">The IToaster interface has a method to make toast, and an event to indicate that the toast is made.</span></span> <span data-ttu-id="6b4fc-176">このイベントでは、トーストの特定の部分 (つまり型) が返されるため型指定されたイベントと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-176">Because this event returns the particular piece (that is, type) of toast, it's known as a typed event.</span></span>

<span data-ttu-id="6b4fc-177">次に、これらのインターフェイスを実装したクラスをパブリックにしてシールする必要があります。これにより、後でプログラミングする JavaScript アプリからアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-177">Next, we need classes that implement these interfaces, and are public and sealed so that they are accessible from the JavaScript app that you'll program later.</span></span>

```csharp
    public sealed class Toast : IToast
        {
            private string _toastType;

            public string ToastType
            {
                get
                {
                    return _toastType;
                }
            }
            internal Toast(String toastType)
            {
                _toastType = toastType;
            }

        }
        public sealed class Toaster : IToaster
        {
            public event TypedEventHandler<Toaster, Toast> ToastCompletedEvent;

            private void OnToastCompleted(Toast args)
            {
                var completedEvent = ToastCompletedEvent;
                if (completedEvent != null)
                {
                    completedEvent(this, args);
                }
            }

            public void MakeToast(string message)
            {
                Toast toast = new Toast(message);
                // Fire the event from a thread-pool thread to enable this thread to continue
                Windows.System.Threading.ThreadPool.RunAsync(
                (IAsyncAction action) =>
                {
                    if (ToastCompletedEvent != null)
                    {
                        OnToastCompleted(toast);
                    }
                });
           }
        }
```

<span data-ttu-id="6b4fc-178">上記のコードでは、トーストを作成し、スレッド プールの作業項目を起動して、通知を生成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-178">In the preceding code, we create the toast and then spin up a thread-pool work item to fire the notification.</span></span> <span data-ttu-id="6b4fc-179">IDE では、非同期呼び出しに対して await キーワードを適用することを推奨している場合がありますが、メソッドで操作結果に依存する処理は行わないため、ここでは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-179">Although the IDE might suggest that you apply the await keyword to the async call, it isn’t necessary in this case because the method doesn’t do any work that depends on the results of the operation.</span></span>

<span data-ttu-id="6b4fc-180">**注:** 上記のコードでは、非同期呼び出しは、ThreadPool.RunAsync 使用するためにのみ、バック グラウンド スレッドでイベントを発生させる簡単な方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-180">**Note**The async call in the preceding code uses ThreadPool.RunAsync solely to demonstrate a simple way to fire the event on a background thread.</span></span> <span data-ttu-id="6b4fc-181">この特定のメソッドは、次の例で示すように記述することもできます。.NET のタスク スケジューラは、async/await 呼び出しを自動的にマーシャリングして UI スレッドに返すため、正常に動作します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-181">You could write this particular method as shown in the following example, and it would work fine because the .NET Task scheduler automatically marshals async/await calls back to the UI thread.</span></span>
  
```csharp
    public async void MakeToast(string message)
    {
        Toast toast = new Toast(message)
        await Task.Delay(new Random().Next(1000));
        OnToastCompleted(toast);
    }
```

<span data-ttu-id="6b4fc-182">ここでプロジェクトをビルドする場合、正常にビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-182">If you build the project now, it should build cleanly.</span></span>

## <a name="to-program-the-javascript-app"></a><span data-ttu-id="6b4fc-183">JavaScript アプリをプログラミングするには</span><span class="sxs-lookup"><span data-stu-id="6b4fc-183">To program the JavaScript app</span></span>

<span data-ttu-id="6b4fc-184">使うトーストは、クラスを使用することが発生する JavaScript アプリにボタンを追加できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-184">Now we can add a button to the JavaScript app to cause it to use the class we just defined to make toast.</span></span> <span data-ttu-id="6b4fc-185">これは前、に先ほど作成した ToasterComponent プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-185">Before we do this, we must add a reference to the ToasterComponent project we just created.</span></span> <span data-ttu-id="6b4fc-186">ソリューション エクスプ ローラーで、ToasterApplication プロジェクトのショートカット メニューを開き、選択**追加&gt;への参照**、し、**新しい参照の追加**ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-186">In Solution Explorer, open the shortcut menu for the ToasterApplication project, choose **Add &gt; References**, and then choose the **Add New Reference** button.</span></span> <span data-ttu-id="6b4fc-187">[参照の追加] ダイアログ ボックスで、ソリューションでは、下の左側のウィンドウでコンポーネント プロジェクトを選択し、中央のウィンドウで [ToasterComponent します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-187">In the Add Reference dialog box, in the left pane under Solution, select the component project, and then in the middle pane, select ToasterComponent.</span></span> <span data-ttu-id="6b4fc-188">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-188">Choose the **OK** button.</span></span>

<span data-ttu-id="6b4fc-189">ソリューション エクスプ ローラーで ToasterApplication プロジェクトのショートカット メニューを開くし、**スタートアップ プロジェクトとして設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-189">In Solution Explorer, open the shortcut menu for the ToasterApplication project and then choose **Set as Startup Project**.</span></span>

<span data-ttu-id="6b4fc-190">Default.js ファイルの最後に、コンポーネントを呼び出すと、もう一度によって呼び出された関数を含む名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-190">At the end of the default.js file, add a namespace to contain the functions to call the component and be called back by it.</span></span> <span data-ttu-id="6b4fc-191">名前空間には、トーストを確認し、トースト完了イベントを処理する 1 つの 2 つの関数があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-191">The namespace will have two functions, one to make toast and one to handle the toast-complete event.</span></span> <span data-ttu-id="6b4fc-192">MakeToast の実装は、トースター オブジェクトを作成し、イベント ハンドラーを登録、により、トースト通知。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-192">The implementation of makeToast creates a Toaster object, registers the event handler, and makes the toast.</span></span> <span data-ttu-id="6b4fc-193">これまでは、イベント ハンドラーはありません、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-193">So far, the event handler doesn’t do much, as shown here:</span></span>

```javascript
    WinJS.Namespace.define("ToasterApplication"), {
       makeToast: function () {

          var toaster = new ToasterComponent.Toaster();
          //toaster.addEventListener("ontoastcompletedevent", ToasterApplication.toastCompletedEventHandler);
          toaster.ontoastcompletedevent = ToasterApplication.toastCompletedEventHandler;
          toaster.makeToast("Peanut Butter");
       },

       toastCompletedEventHandler: function(event) {
           // The sender of the event (the delegate's first type parameter)
           // is mapped to event.target. The second argument of the delegate
           // is contained in event, which means in this case event is a
           // Toast class, with a toastType string.
           var toastType = event.toastType;

           document.getElementById('toastOutput').innerHTML = "<p>Made " + toastType + " toast</p>";
        },
    });
```

<span data-ttu-id="6b4fc-194">MakeToast 関数は、ボタンにフックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-194">The makeToast function must be hooked up to a button.</span></span> <span data-ttu-id="6b4fc-195">ボタン、トーストの結果を出力する一部の領域など、default.html を更新します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-195">Update default.html to include a button and some space to output the result of making toast:</span></span>

```html
    <body>
        <h1>Click the button to make toast</h1>
        <button onclick="ToasterApplication.makeToast()">Make Toast!</button>
        <div id="toasterOutput">
            <p>No Toast Yet...</p>
        </div>
    </body>
```

<span data-ttu-id="6b4fc-196">TypedEventHandler を使って減少が生じない場合お客様ができるようになりましたすることがローカル コンピューターでアプリを実行し、トーストを作成するボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-196">If we weren’t using a TypedEventHandler, we would now be able to run the app on the local machine and click the button to make toast.</span></span> <span data-ttu-id="6b4fc-197">ただし、アプリで何も起こりません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-197">But in our app, nothing happens.</span></span> <span data-ttu-id="6b4fc-198">その理由を確認するには、ToastCompletedEvent を起動するマネージ コードをデバッグしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-198">To find out why, let’s debug the managed code that fires the ToastCompletedEvent.</span></span> <span data-ttu-id="6b4fc-199">プロジェクトを停止し、メニュー バーで、次のように選択します。**デバッグ&gt;トースター アプリケーションのプロパティ**します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-199">Stop the project, and then on the menu bar, choose **Debug &gt; Toaster Application properties**.</span></span> <span data-ttu-id="6b4fc-200">**マネージのみ**を**デバッガーの種類**を変更します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-200">Change **Debugger Type** to **Managed Only**.</span></span> <span data-ttu-id="6b4fc-201">もう一度選択メニュー バーで、**デバッグ&gt;例外**、し、**共通言語ランタイム例外**を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-201">Again on the menu bar, choose **Debug &gt; Exceptions**, and then select **Common Language Runtime Exceptions**.</span></span>

<span data-ttu-id="6b4fc-202">ここでアプリを実行し、メーカー トースト ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-202">Now run the app and click the make-toast button.</span></span> <span data-ttu-id="6b4fc-203">デバッガーは、無効なキャスト例外をキャッチします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-203">The debugger catches an invalid cast exception.</span></span> <span data-ttu-id="6b4fc-204">そのメッセージからは分かりありませんが、プロキシは、そのインターフェイスの不足しているために、この例外が発生しています。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-204">Although it’s not obvious from its message, this exception is occurring because proxies are missing for that interface.</span></span>

![不足しているプロキシ](./images/debuggererrormissingproxy.png)

<span data-ttu-id="6b4fc-206">プロキシとスタブのコンポーネントを作成するのには、最初に、インターフェイスに一意の ID または GUID を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-206">The first step in creating a proxy and stub for a component is to add a unique ID or GUID to the interfaces.</span></span> <span data-ttu-id="6b4fc-207">ただし、使用する GUID 形式は、c#、Visual Basic、または他の .NET 言語または C++ でをコーディングしているかどうかに応じて異なります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-207">However, the GUID format to use differs depending on whether you're coding in C#, Visual Basic, or another .NET language, or in C++.</span></span>

## <a name="to-generate-guids-for-the-components-interfaces-c-and-other-net-languages"></a><span data-ttu-id="6b4fc-208">(C# と他の .NET 言語) コンポーネントのインターフェイスの Guid を生成するには</span><span class="sxs-lookup"><span data-stu-id="6b4fc-208">To generate GUIDs for the component's interfaces (C# and other .NET languages)</span></span>

<span data-ttu-id="6b4fc-209">メニュー バーで、選択ツール&gt;GUID を作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-209">On the menu bar, choose Tools &gt; Create GUID.</span></span> <span data-ttu-id="6b4fc-210">ダイアログ ボックスで、5 を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-210">In the dialog box, select 5.</span></span> <span data-ttu-id="6b4fc-211">\[Guid ("…」という xxxx xxxx) \]。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-211">\[Guid(“xxxxxxxx-xxxx...xxxx)\].</span></span> <span data-ttu-id="6b4fc-212">新しい GUID ボタンを選択し、コピーのボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-212">Choose the New GUID button and then choose the Copy button.</span></span>

![guid ジェネレーター ツール](./images/guidgeneratortool.png)

<span data-ttu-id="6b4fc-214">インターフェイスの定義に戻るし、次の例に示すように、IToaster インターフェイスの直前に新しい GUID を貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-214">Go back to the interface definition, and then paste the new GUID just before the IToaster interface, as shown in the following example.</span></span> <span data-ttu-id="6b4fc-215">(この例でに GUID を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-215">(Don't use the GUID in the example.</span></span> <span data-ttu-id="6b4fc-216">一意のすべてのインターフェイスがあります、独自の GUID。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-216">Every unique interface should have its own GUID.)</span></span>

```cpp
[Guid("FC198F74-A808-4E2A-9255-264746965B9F")]
        public interface IToaster...
```

<span data-ttu-id="6b4fc-217">追加の using ディレクティブ System.Runtime.InteropServices 名前空間をします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-217">Add a using directive for the System.Runtime.InteropServices namespace.</span></span>

<span data-ttu-id="6b4fc-218">IToast インターフェイスの次の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-218">Repeat these steps for the IToast interface.</span></span>

## <a name="to-generate-guids-for-the-components-interfaces-c"></a><span data-ttu-id="6b4fc-219">(C++) のコンポーネントのインターフェイスの Guid を生成するには</span><span class="sxs-lookup"><span data-stu-id="6b4fc-219">To generate GUIDs for the component's interfaces (C++)</span></span>

<span data-ttu-id="6b4fc-220">メニュー バーで、選択ツール&gt;GUID を作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-220">On the menu bar, choose Tools &gt; Create GUID.</span></span> <span data-ttu-id="6b4fc-221">ダイアログ ボックスで 3 を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-221">In the dialog box, select 3.</span></span> <span data-ttu-id="6b4fc-222">静的な const 構造体 GUID = {...} します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-222">static const struct GUID = {...}.</span></span> <span data-ttu-id="6b4fc-223">新しい GUID ボタンを選択し、コピーのボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-223">Choose the New GUID button and then choose the Copy button.</span></span>

<span data-ttu-id="6b4fc-224">IToaster インターフェイス定義の直前に GUID を貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-224">Paste the GUID just before the IToaster interface definition.</span></span> <span data-ttu-id="6b4fc-225">貼り付けた後 GUID は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-225">After you paste, the GUID should resemble the following example.</span></span> <span data-ttu-id="6b4fc-226">(この例でに GUID を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-226">(Don't use the GUID in the example.</span></span> <span data-ttu-id="6b4fc-227">一意のすべてのインターフェイスがあります、独自の GUID。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-227">Every unique interface should have its own GUID.)</span></span>
```cpp
// {F8D30778-9EAF-409C-BCCD-C8B24442B09B}
    static const GUID <<name>> = { 0xf8d30778, 0x9eaf, 0x409c, { 0xbc, 0xcd, 0xc8, 0xb2, 0x44, 0x42, 0xb0, 0x9b } };
```
<span data-ttu-id="6b4fc-228">使って、追加ディレクティブを Windows.Foundation.Metadata プロセスは、そのをスコープに取り込みます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-228">Add a using directive for Windows.Foundation.Metadata to bring GuidAttribute into scope.</span></span>

<span data-ttu-id="6b4fc-229">今すぐに手動で変換 const GUID、プロセスは、そのフォーマットの次の例に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-229">Now manually convert the const GUID to a GuidAttribute so that it's formatted as shown in the following example.</span></span> <span data-ttu-id="6b4fc-230">角かっことかっこ、中かっこは置き換えられ、後続のセミコロンを削除することを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-230">Notice that the curly braces are replaced with brackets and parentheses, and the trailing semicolon is removed.</span></span>
```cpp
// {E976784C-AADE-4EA4-A4C0-B0C2FD1307C3}
    [GuidAttribute(0xe976784c, 0xaade, 0x4ea4, 0xa4, 0xc0, 0xb0, 0xc2, 0xfd, 0x13, 0x7, 0xc3)]
    public interface IToaster
    {...
```
<span data-ttu-id="6b4fc-231">IToast インターフェイスの次の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-231">Repeat these steps for the IToast interface.</span></span>

<span data-ttu-id="6b4fc-232">インターフェイスでは、一意の Id をしたら、します winmdidl コマンド ライン ツールに、.winmd ファイルを与えて IDL ファイルを作成し、MIDL コマンド ライン ツールにその IDL ファイルを与えてプロキシおよびスタブの C ソース コードを生成できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-232">Now that the interfaces have unique IDs, we can create an IDL file by feeding the .winmd file into the winmdidl command-line tool, and then generate the C source code for the proxy and stub by feeding that IDL file into the MIDL command-line tool.</span></span> <span data-ttu-id="6b4fc-233">Visual Studio はマイクロソフトの場合は、次の手順に示すようにビルド後のイベントを作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-233">Visual Studio do this for us if we create post-build events as shown in the following steps.</span></span>

## <a name="to-generate-the-proxy-and-stub-source-code"></a><span data-ttu-id="6b4fc-234">プロキシを生成し、ソース コードのスタブ</span><span class="sxs-lookup"><span data-stu-id="6b4fc-234">To generate the proxy and stub source code</span></span>

<span data-ttu-id="6b4fc-235">ソリューション エクスプ ローラーで、ビルド後のカスタム イベントを追加するには、ToasterComponent プロジェクトのショートカット メニューを開くし、プロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-235">To add a custom post-build event, in Solution Explorer, open the shortcut menu for the ToasterComponent project and then choose Properties.</span></span> <span data-ttu-id="6b4fc-236">プロパティ ページの左側のウィンドウで、ビルド イベントを選択し、ビルド後の編集ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-236">In the left pane of the property pages, select Build Events, and then choose the Edit Post-build button.</span></span> <span data-ttu-id="6b4fc-237">ビルド後のコマンド ラインを次のコマンドを追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-237">Add the following commands to the post-build command line.</span></span> <span data-ttu-id="6b4fc-238">(バッチ ファイルを呼び出す必要がありますまず winmdidl ツールを見つけるに環境変数を設定します。)</span><span class="sxs-lookup"><span data-stu-id="6b4fc-238">(The batch file must be called first to set the environment variables to find the winmdidl tool.)</span></span>

```cpp
call "$(DevEnvDir)..\..\vc\vcvarsall.bat" $(PlatformName)
winmdidl /outdir:output "$(TargetPath)"
midl /metadata_dir "%WindowsSdkDir%References\CommonConfiguration\Neutral" /iid "$(ProjectDir)$(TargetName)_i.c" /env win32 /h "$(ProjectDir)$(TargetName).h" /winmd "Output\$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(ProjectDir)dlldata.c" /proxy "$(ProjectDir)$(TargetName)_p.c" "Output\$(TargetName).idl"
```

<span data-ttu-id="6b4fc-239">**重要な**、ARM 用または x64 構成をプロジェクトから、x64、または arm32 MIDL/env パラメーターを変更します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-239">**Important**For an ARM or x64 project configuration, change the MIDL /env parameter to x64 or arm32.</span></span>

<span data-ttu-id="6b4fc-240">IDL ファイルは、.winmd ファイルが変更されるたびに再生されるようにするには、変更する**ビルド後のイベントの実行**に**ビルドがプロジェクトの出力を更新する場合**。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-240">To make sure the IDL file is regenerated every time the .winmd file is changed, change **Run the post-build event** to **When the build updates the project output.**</span></span>
<span data-ttu-id="6b4fc-241">このビルド イベントのプロパティ ページのようになります:![ビルド イベント</span><span class="sxs-lookup"><span data-stu-id="6b4fc-241">The Build Events property page should resemble this: ![build events</span></span>](./images/buildevents.png)

<span data-ttu-id="6b4fc-242">生成し、コンパイル IDL ソリューションをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-242">Rebuild the solution to generate and compile the IDL.</span></span>

<span data-ttu-id="6b4fc-243">MIDL が、ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および ToasterComponent プロジェクト ディレクトリに dlldata.c を探すことで、ソリューションを正しくコンパイルすることを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-243">You can verify that MIDL correctly compiled the solution by looking for ToasterComponent.h, ToasterComponent_i.c, ToasterComponent_p.c, and dlldata.c in the ToasterComponent project directory.</span></span>

## <a name="to-compile-the-proxy-and-stub-code-into-a-dll"></a><span data-ttu-id="6b4fc-244">コンパイル プロキシとスタブの DLL にコードを</span><span class="sxs-lookup"><span data-stu-id="6b4fc-244">To compile the proxy and stub code into a DLL</span></span>

<span data-ttu-id="6b4fc-245">これで、必要なファイルがある、DLL、C++ ファイルを生成することをコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-245">Now that you have the required files, you can compile them to produce a DLL, which is a C++ file.</span></span> <span data-ttu-id="6b4fc-246">できるだけ簡単にするには、プロキシの構築をサポートする新しいプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-246">To make this as easy as possible, add a new project to support building the proxies.</span></span> <span data-ttu-id="6b4fc-247">ToasterApplication ソリューションのショートカット メニューを開くし、選択**追加 > [新しいプロジェクト**します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-247">Open the shortcut menu for the ToasterApplication solution and then choose **Add > New Project**.</span></span> <span data-ttu-id="6b4fc-248">**新しいプロジェクト**] ダイアログ ボックスの左側のウィンドウで、展開**Visual C &gt; Windows&gt;ユニバーサル Windows**、し、中央のウィンドウで**DLL (UWP アプリ)** を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-248">In the left pane of the **New Project** dialog box, expand **Visual C++ &gt; Windows &gt; Univeral Windows**, and then in the middle pane, select **DLL (UWP apps)**.</span></span> <span data-ttu-id="6b4fc-249">(C++ Windows ランタイム コンポーネント プロジェクトではないことに注意してください)。プロジェクトのプロキシの名前し、 **[ok]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-249">(Notice that this is NOT a C++ Windows Runtime Component project.) Name the project Proxies and then choose the **OK** button.</span></span> <span data-ttu-id="6b4fc-250">これらのファイルは、c# クラスで変更があったときに、ビルド後のイベントによって更新されます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-250">These files will be updated by the post-build events when something changes in the C# class.</span></span>

<span data-ttu-id="6b4fc-251">既定では、プロキシ プロジェクトには、ヘッダー .h ファイルと C++ .cpp ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-251">By default, the Proxies project generates header .h files and C++ .cpp files.</span></span> <span data-ttu-id="6b4fc-252">MIDL から生成されたファイルから、DLL が組み込まれている、ため、.h ファイルと .cpp ファイルは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-252">Because the DLL is built from the files produced from MIDL, the .h and .cpp files are not required.</span></span> <span data-ttu-id="6b4fc-253">ソリューション エクスプ ローラーで、それらのショートカット メニューを開き、選択**を削除する**には、および、削除を確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-253">In Solution Explorer, open the shortcut menu for them, choose **Remove**, and then confirm the deletion.</span></span>

<span data-ttu-id="6b4fc-254">これで、プロジェクトが空で、追加できます戻る MIDL で生成したファイル。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-254">Now that the project is empty, you can add back the MIDL-generated files.</span></span> <span data-ttu-id="6b4fc-255">プロキシのプロジェクトのショートカット メニューを開き、選択**追加 > [既存項目の**。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-255">Open the shortcut menu for the Proxies project, and then choose **Add > Existing Item.**</span></span> <span data-ttu-id="6b4fc-256">ダイアログ ボックスで ToasterComponent プロジェクト ディレクトリに移動し、これらのファイルを選択: ToasterComponent.h、ToasterComponent_i.c、ToasterComponent_p.c、および dlldata.c ファイル。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-256">In the dialog box, navigate to the ToasterComponent project directory and select these files: ToasterComponent.h, ToasterComponent_i.c, ToasterComponent_p.c, and dlldata.c files.</span></span> <span data-ttu-id="6b4fc-257">**追加**ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-257">Choose the **Add** button.</span></span>

<span data-ttu-id="6b4fc-258">プロジェクトで、プロキシ dlldata.c で説明されている DLL のエクスポートを定義する .def ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-258">In the Proxies project, create a .def file to define the DLL exports described in dlldata.c.</span></span> <span data-ttu-id="6b4fc-259">プロジェクトのショートカット メニューを開き、選択**追加 > [新しい項目の**します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-259">Open the shortcut menu for the project, and then choose **Add > New Item**.</span></span> <span data-ttu-id="6b4fc-260">ダイアログ ボックスの左側のウィンドウでコードを選択し、中央のウィンドウでモジュール定義ファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-260">In the left pane of the dialog box, select Code and then in the middle pane, select Module-Definition File.</span></span> <span data-ttu-id="6b4fc-261">ファイル proxies.def の名前し、**追加**のボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-261">Name the file proxies.def and then choose the **Add** button.</span></span> <span data-ttu-id="6b4fc-262">この .def ファイルを開き、dlldata.c で定義されているエクスポートを含むように変更します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-262">Open this .def file and modify it to include the EXPORTS that are defined in dlldata.c:</span></span>

```cpp
EXPORTS
    DllCanUnloadNow         PRIVATE
    DllGetClassObject       PRIVATE
```

<span data-ttu-id="6b4fc-263">ここでプロジェクトをビルドする場合は失敗します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-263">If you build the project now, it will fail.</span></span> <span data-ttu-id="6b4fc-264">このプロジェクトで正しくコンパイルするには、プロジェクトのコンパイルし、リンクする方法を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-264">To correctly compile this project, you have to change how the project is compiled and linked.</span></span> <span data-ttu-id="6b4fc-265">ソリューション エクスプ ローラーでプロキシ プロジェクトのショートカット メニューを開くし、**プロパティ**を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-265">In Solution Explorer, open the shortcut menu for the Proxies project and then choose **Properties**.</span></span> <span data-ttu-id="6b4fc-266">プロパティ ページを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-266">Change the property pages as follows.</span></span>

<span data-ttu-id="6b4fc-267">左側のウィンドウで、選択**C/C++ > プリプロセッサ**とし、右側のウィンドウで、**プリプロセッサの定義**を選択して、下方向キー] をクリックし、**編集**します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-267">In the left pane, select **C/C++ > Preprocessor**, and then in the right pane, select **Preprocessor Definitions**, choose the down-arrow button, and then select **Edit**.</span></span> <span data-ttu-id="6b4fc-268">これらの定義を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-268">Add these definitions in the box:</span></span>

```cpp
WIN32;_WINDOWS
```
<span data-ttu-id="6b4fc-269">[ **C/C++ > プリコンパイル済みヘッダー**、**プリコンパイル済みヘッダーを使用しない**を**プリコンパイル済みヘッダー**に変更し、 **[適用**] ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-269">Under **C/C++ > Precompiled Headers**, change **Precompiled Header** to **Not Using Precompiled Headers**, and then choose the **Apply** button.</span></span>

<span data-ttu-id="6b4fc-270">[**リンカー > 一般的な**、**キメ**s を**インポート ライブラリの無視**に変更し、 **[適用**] ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-270">Under **Linker > General**, change **Ignore Import Library** to **Ye**s, and then choose the **Apply** button.</span></span>

<span data-ttu-id="6b4fc-271">[**リンカー > 入力**、**追加の依存関係**を選択して、下方向キー] をクリックし、**編集**します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-271">Under **Linker > Input**, select **Additional Dependencies**, choose the down-arrow button, and then select **Edit**.</span></span> <span data-ttu-id="6b4fc-272">このテキスト ボックスに追加します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-272">Add this text in the box:</span></span>

```cpp
rpcrt4.lib;runtimeobject.lib
```

<span data-ttu-id="6b4fc-273">リストの行に直接これらのライブラリを貼り付けられません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-273">Do not paste these libs directly into the list row.</span></span> <span data-ttu-id="6b4fc-274">**編集**ボックスを使用して、Visual Studio の MSBuild が適切な追加の依存関係を維持することを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-274">Use the **Edit** box to ensure that MSBuild in Visual Studio will maintain the correct additional dependencies.</span></span>

<span data-ttu-id="6b4fc-275">これらの変更を加えた場合は、**プロパティ ページ**] ダイアログ ボックスで、[ **OK** ] を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-275">When you have made these changes, choose the **OK** button in the **Property Pages** dialog box.</span></span>

<span data-ttu-id="6b4fc-276">次に、ToasterComponent プロジェクトに対して依存関係を実行します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-276">Next, take a dependency on the ToasterComponent project.</span></span> <span data-ttu-id="6b4fc-277">これにより、トースターがプロキシ プロジェクトをビルドする前にビルドされます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-277">This ensures that the Toaster will build before the proxy project builds.</span></span> <span data-ttu-id="6b4fc-278">トースター プロジェクトは、プロキシをビルドするファイルを生成するために必要です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-278">This is required because the Toaster project is responsible for generating the files to build the proxy.</span></span>

<span data-ttu-id="6b4fc-279">プロキシのプロジェクトのショートカット メニューを開き、プロジェクトの依存関係を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-279">Open the shortcut menu for the Proxies project and then choose Project Dependencies.</span></span> <span data-ttu-id="6b4fc-280">プロキシ プロジェクトによって異なります ToasterComponent プロジェクトを Visual Studio それらのビルドを正しい順序であることを確認することを示すチェック ボックスを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-280">Select the check boxes to indicate that the Proxies project depends on the ToasterComponent project, to ensure that Visual Studio builds them in the correct order.</span></span>

<span data-ttu-id="6b4fc-281">ソリューションのビルドを選択して正しくことを確認**ビルド > ソリューションのリビルド**Visual Studio のメニュー バー。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-281">Verify that the solution builds correctly by choosing **Build > Rebuild Solution** on the Visual Studio menu bar.</span></span>


## <a name="to-register-the-proxy-and-stub"></a><span data-ttu-id="6b4fc-282">プロキシとスタブを登録するには</span><span class="sxs-lookup"><span data-stu-id="6b4fc-282">To register the proxy and stub</span></span>

<span data-ttu-id="6b4fc-283">ToasterApplication プロジェクトで、package.appxmanifest のショートカット メニューを開き**で開く**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-283">In the ToasterApplication project, open the shortcut menu for package.appxmanifest and then choose **Open With**.</span></span> <span data-ttu-id="6b4fc-284">ファイルを開く] ダイアログ ボックスで、 **XML のテキスト エディター**を選択し、 **[ok]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-284">In the Open With dialog box, select **XML Text Editor** and then choose the **OK** button.</span></span> <span data-ttu-id="6b4fc-285">プロキシの Guid に基づく windows.activatableClass.proxyStub 拡張機能の登録とを提供するいくつかの XML で貼り付けを行いましょう。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-285">We're going to paste in some XML that provides a windows.activatableClass.proxyStub extension registration and which are based on the GUIDs in the proxy.</span></span> <span data-ttu-id="6b4fc-286">.Appxmanifest ファイルで使用する Guid を見つけるには、ToasterComponent_i.c を開きます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-286">To find the GUIDs to use in the .appxmanifest file, open ToasterComponent_i.c.</span></span> <span data-ttu-id="6b4fc-287">次の例でもののようなエントリを検索します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-287">Find entries that resemble the ones in the following example.</span></span> <span data-ttu-id="6b4fc-288">IToast、IToaster の定義にも注目してくださいし、3 番目のインターフェイス、2 つのパラメーターを持つ型指定されたイベント ハンドラー: トースターとトーストします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-288">Also notice the definitions for IToast, IToaster, and a third interface—a typed event handler that has two parameters: a Toaster and Toast.</span></span> <span data-ttu-id="6b4fc-289">これにより、トースター クラスで定義されているイベントが一致します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-289">This matches the event that's defined in the Toaster class.</span></span> <span data-ttu-id="6b4fc-290">IToast および IToaster の Guid が、C# のコード ファイル内のインターフェイスで定義されている Guid と一致していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-290">Notice that the GUIDs for IToast and IToaster match the GUIDs that are defined on the interfaces in the C# file.</span></span> <span data-ttu-id="6b4fc-291">型指定されたイベント ハンドラーのインターフェイスが自動生成されたのため、このインターフェイスの GUID も自動的に生成できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-291">Because the typed event handler interface is autogenerated, the GUID for this interface is also autogenerated.</span></span>

```cpp
MIDL_DEFINE_GUID(IID, IID___FITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast,0x1ecafeff,0x1ee1,0x504a,0x9a,0xf5,0xa6,0x8c,0x6f,0xb2,0xb4,0x7d);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToast,0xF8D30778,0x9EAF,0x409C,0xBC,0xCD,0xC8,0xB2,0x44,0x42,0xB0,0x9B);

MIDL_DEFINE_GUID(IID, IID___x_ToasterComponent_CIToaster,0xE976784C,0xAADE,0x4EA4,0xA4,0xC0,0xB0,0xC2,0xFD,0x13,0x07,0xC3);
```

<span data-ttu-id="6b4fc-292">Guid をコピーします現在では、追加のあるノードと名前、拡張機能内の package.appxmanifest に貼り付けることや、それらを再フォーマットします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-292">Now we copy the GUIDs, paste them in package.appxmanifest in a node that we add and name Extensions, and then reformat them.</span></span> <span data-ttu-id="6b4fc-293">マニフェスト エントリに、次の例のようになります: が、ここでも、独自の Guid を使用してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-293">The manifest entry resembles the following example—but again, remember to use your own GUIDs.</span></span> <span data-ttu-id="6b4fc-294">XML のクラス Id GUID が ITypedEventHandler2 として同じであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-294">Notice that the ClassId GUID in the XML is the same as ITypedEventHandler2.</span></span> <span data-ttu-id="6b4fc-295">これは、その GUID が ToasterComponent_i.c に記載されている最初の 1 つであるためです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-295">This is because that GUID is the first one that's listed in ToasterComponent_i.c.</span></span> <span data-ttu-id="6b4fc-296">Guid をここと小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-296">The GUIDs here are case-insensitive.</span></span> <span data-ttu-id="6b4fc-297">IToast と IToaster Guid を手動で再フォーマットではなくインターフェイス定義に戻ってし、正しい形式には、プロセスは、その値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-297">Instead of manually reformatting the GUIDs for IToast and IToaster, you can go back into the interface definitions and get the GuidAttribute value, which has the correct format.</span></span> <span data-ttu-id="6b4fc-298">C++ では、正しい形式の GUID にはコメントです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-298">In C++, there is a correctly-formatted GUID in the comment.</span></span> <span data-ttu-id="6b4fc-299">いずれの場合で、クラス Id とイベント ハンドラーの両方に使用される GUID を手動で再フォーマットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-299">In any case, you must manually reformat the GUID that's used for both the ClassId and the event handler.</span></span>

```cpp
      <Extensions> <!--Use your own GUIDs!!!-->
        <Extension Category="windows.activatableClass.proxyStub">
          <ProxyStub ClassId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d">
            <Path>Proxies.dll</Path>
            <Interface Name="IToast" InterfaceId="F8D30778-9EAF-409C-BCCD-C8B24442B09B"/>
            <Interface Name="IToaster"  InterfaceId="E976784C-AADE-4EA4-A4C0-B0C2FD1307C3"/>  
            <Interface Name="ITypedEventHandler_2_ToasterComponent__CToaster_ToasterComponent__CToast" InterfaceId="1ecafeff-1ee1-504a-9af5-a68c6fb2b47d"/>
          </ProxyStub>      
        </Extension>
      </Extensions>
```

<span data-ttu-id="6b4fc-300">パッケージのノードの直接の子とリソース ノードなどのピアとして、拡張機能の XML ノードに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-300">Paste the Extensions XML node as a direct child of the Package node, and a peer of, for example, the Resources node.</span></span>

<span data-ttu-id="6b4fc-301">に移行する前にすることが重要ことを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-301">Before moving on, it’s important to ensure that:</span></span>

-   <span data-ttu-id="6b4fc-302">ProxyStub クラス Id は、ToasterComponent\_i.c ファイル内の最初の GUID に設定されます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-302">The ProxyStub ClassId is set to the first GUID in the ToasterComponent\_i.c file.</span></span> <span data-ttu-id="6b4fc-303">クラス Id は、このファイルで定義されている最初の GUID を使用します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-303">Use the first GUID that's defined in this file for the classId.</span></span> <span data-ttu-id="6b4fc-304">(これに ITypedEventHandler2 の GUID と同じ)。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-304">(This might be the same as the GUID for ITypedEventHandler2.)</span></span>
-   <span data-ttu-id="6b4fc-305">パスは、バイナリのプロキシのパッケージ相対パスです。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-305">The Path is the package relative path of the proxy binary.</span></span> <span data-ttu-id="6b4fc-306">(このチュートリアルで proxies.dll は ToasterApplication.winmd と同じフォルダーに) です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-306">(In this walkthrough, proxies.dll is in the same folder as ToasterApplication.winmd.)</span></span>
-   <span data-ttu-id="6b4fc-307">Guid は、正しい形式にします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-307">The GUIDs are in the correct format.</span></span> <span data-ttu-id="6b4fc-308">(これは簡単に問題を取得できます) です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-308">(This is easy to get wrong.)</span></span>
-   <span data-ttu-id="6b4fc-309">マニフェストにインターフェイス Id では、ToasterComponent\_i.c ファイルで Iid と一致します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-309">The interface IDs in the manifest match the IIDs in ToasterComponent\_i.c file.</span></span>
-   <span data-ttu-id="6b4fc-310">インターフェイス名は、マニフェストに固有です。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-310">The interface names are unique in the manifest.</span></span> <span data-ttu-id="6b4fc-311">これらは、システムによって使用されていない、ため、値を選択できます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-311">Because these are not used by the system, you can choose the values.</span></span> <span data-ttu-id="6b4fc-312">明確に定義されているインターフェイスに一致するインターフェイス名を選択することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-312">It is a good practice to choose interface names that clearly match interfaces that you have defined.</span></span> <span data-ttu-id="6b4fc-313">生成されたインターフェイスは、名前は、生成されたインターフェイスの示唆してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-313">For generated interfaces, the names should be indicative of the generated interfaces.</span></span> <span data-ttu-id="6b4fc-314">インターフェイス名を生成するために、ToasterComponent\_i.c ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-314">You can use the ToasterComponent\_i.c file to help you generate interface names.</span></span>

<span data-ttu-id="6b4fc-315">ソリューションを今すぐ実行しようとする場合はエラーが表示される proxies.dll がペイロードの一部ではありません。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-315">If you try to run the solution now, you will get an error that proxies.dll is not part of the payload.</span></span> <span data-ttu-id="6b4fc-316">ToasterApplication プロジェクトで**参照設定**] フォルダーのショートカット メニューを開き、 **[参照の追加**を選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-316">Open the shortcut menu for the **References** folder in the ToasterApplication project and then choose **Add Reference**.</span></span> <span data-ttu-id="6b4fc-317">プロキシのプロジェクトの横にあるチェック ボックスを選択します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-317">Select the check box next to the Proxies project.</span></span> <span data-ttu-id="6b4fc-318">また、ToasterComponent の横にあるチェック ボックスも選択されていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-318">Also, make sure that the check box next to ToasterComponent is also selected.</span></span> <span data-ttu-id="6b4fc-319">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-319">Choose the **OK** button.</span></span>

<span data-ttu-id="6b4fc-320">プロジェクトをビルドするようになりました。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-320">The project should now build.</span></span> <span data-ttu-id="6b4fc-321">プロジェクトを実行し、トーストを作成できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6b4fc-321">Run the project and verify that you can make toast.</span></span>

## <a name="related-topics"></a><span data-ttu-id="6b4fc-322">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6b4fc-322">Related topics</span></span>

* [<span data-ttu-id="6b4fc-323">C++ での Windows ランタイム コンポーネントの作成</span><span class="sxs-lookup"><span data-stu-id="6b4fc-323">Creating Windows Runtime Components in C++</span></span>](creating-windows-runtime-components-in-cpp.md)
