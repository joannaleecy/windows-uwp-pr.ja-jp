---
author: normesta
ms.assetid: 23FE28F1-89C5-4A17-A732-A722648F9C5E
title: "非同期プログラミング"
description: "このトピックでは、ユニバーサル Windows プラットフォーム (UWP) での非同期プログラミングと、C#、Microsoft Visual Basic .NET、Visual C\\+\\+ コンポーネント拡張機能 (C\\+\\+/CX)、および JavaScript における非同期プログラミングの表現について説明します。"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、非同期"
ms.openlocfilehash: 042ebc335d0e0a401b3aeb761daed1ba00a43f59
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="asynchronous-programming"></a><span data-ttu-id="bd0d4-104">非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="bd0d4-104">Asynchronous programming</span></span>

<span data-ttu-id="bd0d4-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="bd0d4-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="bd0d4-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="bd0d4-107">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) での非同期プログラミングと、C#、Microsoft Visual Basic .NET、Visual C++ コンポーネント拡張機能 (C++/CX)、および JavaScript における非同期プログラミングの表現について説明します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-107">This topic describes asynchronous programming in the Universal Windows Platform (UWP) and its representation in C#, Microsoft Visual Basic .NET, Visual C++ component extensions (C++/CX), and JavaScript.</span></span>

<span data-ttu-id="bd0d4-108">非同期プログラミングを使うと、アプリが時間のかかる可能性がある操作を実行しているときでも、アプリの応答性を保つことができます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-108">Using asynchronous programming helps your app stay responsive when it does work that might take an extended amount of time.</span></span> <span data-ttu-id="bd0d4-109">たとえば、インターネットからコンテンツをダウンロードするアプリは、コンテンツが到着するまで数秒待機する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-109">For example, an app that downloads content from the Internet might spend several seconds waiting for the content to arrive.</span></span> <span data-ttu-id="bd0d4-110">UI スレッドで同期メソッドを使ってコンテンツを取得すると、アプリはメソッドから制御が返されるまでブロックされます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-110">If you used a synchronous method on the UI thread to retrieve the content, the app is blocked until the method returns.</span></span> <span data-ttu-id="bd0d4-111">アプリが操作に応答せず、応答していないと思ったユーザーが苛立ちを感じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-111">The app won't respond to user interaction, and because it seems non-responsive, the user might become frustrated.</span></span> <span data-ttu-id="bd0d4-112">これよりもはるかに優れた方法は非同期プログラミングを使うことです。非同期プログラミングでは、アプリは実行を続けて、操作が完了するまで待機している間も UI に応答します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-112">A much better way is to use asynchronous programming, where the app continues to run and respond to the UI while it waits for an operation to complete.</span></span>

<span data-ttu-id="bd0d4-113">処理の完了までに時間がかかるメソッドの場合、UWP で非同期プログラミングを使うのは標準で、例外ではありません。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-113">For methods that might take a long time to complete, asynchronous programming is the norm and not the exception in the UWP.</span></span> <span data-ttu-id="bd0d4-114">JavaScript、C#、Visual Basic、C++/CX の各言語では、非同期メソッド用の言語サポートが提供されます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-114">JavaScript, C#, Visual Basic, and C++/CX each provide language support for asynchronous methods.</span></span>

## <a name="asynchronous-programming-in-the-uwp"></a><span data-ttu-id="bd0d4-115">UWP での非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="bd0d4-115">Asynchronous programming in the UWP</span></span>

<span data-ttu-id="bd0d4-116">[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/BR241124) API や [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) API など、UWP 機能の多くは非同期 API として公開されます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-116">Many UWP features like the [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/BR241124) APIs and [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) APIs are exposed as asynchronous APIs.</span></span> <span data-ttu-id="bd0d4-117">慣例により、非同期 API 関数の名前は、API が呼び出された後に関数の実行部が実行される可能性があることを示す "Async" で終わります。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-117">By convention, the names of asynchronous APIs end with "Async" to indicate that part of their execution may take place after the API has been invoked.</span></span>

<span data-ttu-id="bd0d4-118">ユニバーサル Windows プラットフォーム (UWP) アプリで非同期 API を使う場合、コードは一貫した方法で非ブロック呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-118">When you use asynchronous APIs in your Universal Windows Platform (UWP) app, your code makes non-blocking calls in a consistent way.</span></span> <span data-ttu-id="bd0d4-119">これらの非同期パターンを独自の API 定義に実装すると、呼び出し元はコードを理解し、予測可能な方法で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-119">When you implement these asynchronous patterns in your own API definitions, callers can understand and use your code in a predictable way.</span></span>

<span data-ttu-id="bd0d4-120">次に、非同期 UWP API を呼び出す必要がある一般的なタスクをいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-120">Here are some common tasks that require calling asynchronous UWP APIs.</span></span>

-   <span data-ttu-id="bd0d4-121">メッセージ ダイアログの表示</span><span class="sxs-lookup"><span data-stu-id="bd0d4-121">Displaying a message dialog</span></span>

-   <span data-ttu-id="bd0d4-122">ファイル システムの操作 (ファイル ピッカーの表示)</span><span class="sxs-lookup"><span data-stu-id="bd0d4-122">Working with the file system, displaying a file picker</span></span>

-   <span data-ttu-id="bd0d4-123">インターネットを介したデータの送受信。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-123">Sending and receiving data to and from the Internet</span></span>

-   <span data-ttu-id="bd0d4-124">ソケット、ストリーム、接続の使用</span><span class="sxs-lookup"><span data-stu-id="bd0d4-124">Using sockets, streams, connectivity</span></span>

-   <span data-ttu-id="bd0d4-125">予定、連絡先、カレンダーの操作</span><span class="sxs-lookup"><span data-stu-id="bd0d4-125">Working with appointments, contacts, calendar</span></span>

-   <span data-ttu-id="bd0d4-126">ファイルの種類の操作 (Portable Document Format (PDF) ファイルを開く、画像やメディア形式のデコードなど)。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-126">Working with file types, such as opening Portable Document Format (PDF) files or decoding image or media formats</span></span>

-   <span data-ttu-id="bd0d4-127">デバイスやサービスの操作</span><span class="sxs-lookup"><span data-stu-id="bd0d4-127">Interacting with a device or a service</span></span>

<span data-ttu-id="bd0d4-128">UWP の非同期パターンを利用すると、スレッドの明示的な管理を完全に回避できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-128">With UWP asynchronous pattern, you may be able to avoid explicitly manage threads at all.</span></span> <span data-ttu-id="bd0d4-129">各プログラミング言語では、次に示すように独自の方法で UWP の非同期パターンがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-129">Each programming language supports the asynchronous pattern for the UWP in its own way:</span></span>

| <span data-ttu-id="bd0d4-130">プログラミング言語</span><span class="sxs-lookup"><span data-stu-id="bd0d4-130">Programming language</span></span> | <span data-ttu-id="bd0d4-131">非同期表現</span><span class="sxs-lookup"><span data-stu-id="bd0d4-131">Asynchronous representation</span></span>           |
|----------------------|---------------------------------------|
| <span data-ttu-id="bd0d4-132">C#</span><span class="sxs-lookup"><span data-stu-id="bd0d4-132">C#</span></span>                  | <span data-ttu-id="bd0d4-133">**async** キーワード、**await** 演算子</span><span class="sxs-lookup"><span data-stu-id="bd0d4-133">**async** keyword, **await** operator</span></span> |
| <span data-ttu-id="bd0d4-134">Visual Basic</span><span class="sxs-lookup"><span data-stu-id="bd0d4-134">Visual Basic</span></span>         | <span data-ttu-id="bd0d4-135">**Async** キーワード、**Await** 演算子</span><span class="sxs-lookup"><span data-stu-id="bd0d4-135">**Async** keyword, **Await** operator</span></span> |
| <span data-ttu-id="bd0d4-136">C++/CX</span><span class="sxs-lookup"><span data-stu-id="bd0d4-136">C++/CX</span></span>               | <span data-ttu-id="bd0d4-137">**task** クラス、**.then** メソッド</span><span class="sxs-lookup"><span data-stu-id="bd0d4-137">**task** class, **.then** method</span></span>      |
| <span data-ttu-id="bd0d4-138">JavaScript</span><span class="sxs-lookup"><span data-stu-id="bd0d4-138">JavaScript</span></span>           | <span data-ttu-id="bd0d4-139">promise オブジェクト、**then** 関数</span><span class="sxs-lookup"><span data-stu-id="bd0d4-139">promise object, **then** function</span></span>     |

 

## <a name="asynchronous-patterns-in-uwp-using-c-and-visual-basic"></a><span data-ttu-id="bd0d4-140">C# と Visual Basic を使った UWP での非同期パターン</span><span class="sxs-lookup"><span data-stu-id="bd0d4-140">Asynchronous patterns in UWP using C# and Visual Basic</span></span>


<span data-ttu-id="bd0d4-141">C# または Visual Basic で書かれたコードのセグメントは、通常は同期して実行されます。つまり、ある行が実行されるときには、その行は次の行が実行される前に完了します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-141">A typical segment of code written in C# or Visual Basic executes synchronously, meaning that when a line executes, it finishes before the next line executes.</span></span> <span data-ttu-id="bd0d4-142">以前は非同期実行の Microsoft .NET プログラミング モデルがありましたが、作成されたコードでは、コードで実行しようとしているタスクではなく、非同期コードを実行するしくみに重点が置かれる傾向があります。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-142">There have been previous Microsoft .NET programming models for asynchronous execution, but the resulting code tends to emphasize the mechanics of executing asynchronous code instead of focusing on the task that the code is trying to accomplish.</span></span> <span data-ttu-id="bd0d4-143">UWP、.NET framework、C# と Visual Basic のコンパイラでは、コードから非同期のしくみを取り出す機能が追加されました。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-143">The UWP, .NET framework, and C# and Visual Basic compilers have added features that abstract the asynchronous mechanics out of your code.</span></span> <span data-ttu-id="bd0d4-144">これにより、.NET や UWP を使う場合、いつどのように達成するかではなく何を達成するかに重点を置いた非同期コードを記述できます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-144">For .NET and the UWP you can write asynchronous code that focuses on what your code does instead of how and when to do it.</span></span> <span data-ttu-id="bd0d4-145">記述される非同期コードは、同期コードに類似しています。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-145">Your asynchronous code will look reasonably similar to synchronous code.</span></span> <span data-ttu-id="bd0d4-146">詳しくは、「[C# または Visual Basic での非同期 API の呼び出し](call-asynchronous-apis-in-csharp-or-visual-basic.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-146">For more info, see [Call asynchronous APIs in C# or Visual Basic](call-asynchronous-apis-in-csharp-or-visual-basic.md).</span></span>

## <a name="asynchronous-patterns-in-uwp-with-c"></a><span data-ttu-id="bd0d4-147">C++ を使った UWP での非同期パターン</span><span class="sxs-lookup"><span data-stu-id="bd0d4-147">Asynchronous patterns in UWP with C++</span></span>


<span data-ttu-id="bd0d4-148">C++/CX では、非同期プログラミングは [**task クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750113.aspx) とその [**then メソッド**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750044.aspx) に基づいています。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-148">In C++/CX, asynchronous programming is based on the [**task class**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750113.aspx), and its [**then method**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750044.aspx).</span></span> <span data-ttu-id="bd0d4-149">構文は JavaScript の promise の構文に似ています。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-149">The syntax is similar to that of JavaScript promises.</span></span> <span data-ttu-id="bd0d4-150">**task クラス**とそれに関連する型は、スレッド コンテキストの取り消しと管理に使われる機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-150">The **task class** and its related types also provide the capability for cancellation and management of the thread context.</span></span> <span data-ttu-id="bd0d4-151">詳しくは、「[C++ での非同期プログラミング](asynchronous-programming-in-cpp-universal-windows-platform-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-151">For more info, see [Asynchronous programming in C++](asynchronous-programming-in-cpp-universal-windows-platform-apps.md).</span></span>

<span data-ttu-id="bd0d4-152">[**create\_async 関数**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750102.aspx) は、JavaScript または UWP をサポートする任意の言語から利用できる非同期 API の生成をサポートします。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-152">The [**create\_async function**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750102.aspx) provides support for producing asynchronous APIs that can be consumed from JavaScript or any other language that supports the UWP.</span></span> <span data-ttu-id="bd0d4-153">詳しくは、「[C++ で非同期操作を作成](https://msdn.microsoft.com/library/windows/apps/xaml/hh750082.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-153">For more info, see [Creating Asynchronous Operations in C++](https://msdn.microsoft.com/library/windows/apps/xaml/hh750082.aspx).</span></span>

## <a name="asynchronous-patterns-in-uwp-using-javascript"></a><span data-ttu-id="bd0d4-154">JavaScript を使った UWP での非同期パターン</span><span class="sxs-lookup"><span data-stu-id="bd0d4-154">Asynchronous patterns in UWP using JavaScript</span></span>

<span data-ttu-id="bd0d4-155">JavaScript の非同期プログラミングでは、[Common JS Promises/A](http://wiki.commonjs.org/wiki/Promises/A) 提唱の標準に従って、非同期メソッドで promise オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-155">In JavaScript, asynchronous programming follows the [Common JS Promises/A](http://wiki.commonjs.org/wiki/Promises/A) proposed standard by having asynchronous methods return promise objects.</span></span> <span data-ttu-id="bd0d4-156">Promise は、UWP と JavaScript 用 Windows ライブラリの両方で使われます。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-156">Promises are used in both the UWP and Windows Library for JavaScript.</span></span>

<span data-ttu-id="bd0d4-157">promise オブジェクトは、将来取得されたときに値を表します。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-157">A promise object represents a value that will be fulfilled in the future.</span></span> <span data-ttu-id="bd0d4-158">UWP では、promise オブジェクトをファクトリ関数から取得します。ファクトリ関数には、慣例により "Async" で終わる名前が付いています。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-158">In the UWP you get a promise object from a factory function, which by convention has a name that ends with "Async".</span></span>

<span data-ttu-id="bd0d4-159">多くの場合、非同期関数の呼び出しは従来の関数の呼び出しと同じくらい簡単です。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-159">In many cases, calling an asynchronous function is almost as simple as calling a conventional function.</span></span> <span data-ttu-id="bd0d4-160">違いは、結果またはエラーに対するハンドラーの割り当てと操作の開始に [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドまたは [**done**](https://msdn.microsoft.com/library/windows/apps/Hh701079) メソッドを使うことです。</span><span class="sxs-lookup"><span data-stu-id="bd0d4-160">The difference is that you use the [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) or the [**done**](https://msdn.microsoft.com/library/windows/apps/Hh701079) method to assign the handlers for results or errors and to start the operation.</span></span>

## <a name="related-topics"></a><span data-ttu-id="bd0d4-161">関連トピック</span><span class="sxs-lookup"><span data-stu-id="bd0d4-161">Related topics</span></span>

* [<span data-ttu-id="bd0d4-162">C# または Visual Basic での非同期 API の呼び出し</span><span class="sxs-lookup"><span data-stu-id="bd0d4-162">Call asynchronous APIs in C# or Visual Basic</span></span>](call-asynchronous-apis-in-csharp-or-visual-basic.md)
* [<span data-ttu-id="bd0d4-163">Async と Await を使用した非同期プログラミング (C# と Visual Basic)</span><span class="sxs-lookup"><span data-stu-id="bd0d4-163">Asynchronous Programming with Async and Await (C# and Visual Basic)</span></span>](http://msdn.microsoft.com/library/hh191443(vs.110).aspx)
* [<span data-ttu-id="bd0d4-164">リバーシの機能のシナリオ: 非同期コード</span><span class="sxs-lookup"><span data-stu-id="bd0d4-164">Reversi sample feature scenarios: asynchronous code</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj712233.aspx#async)
