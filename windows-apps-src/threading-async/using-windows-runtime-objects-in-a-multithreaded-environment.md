---
title: マルチスレッド環境での Windows ランタイム オブジェクトの使用 | Microsoft Docs
description: この記事では、C# および Visual Basic コードからオブジェクト (Windows ランタイム や Windows ランタイム コンポーネントによって提供されるオブジェクト) を呼び出すとき、.NET Framework がどのようにこの呼び出しを処理するかについて説明します。
ms.date: 01/14/2017
ms.topic: article
ms.assetid: 43ffd28c-c4df-405c-bf5c-29c94e0d142b
keywords: Windows 10, UWP, タイマー, スレッド
ms.localizationpriority: medium
ms.openlocfilehash: 82e1431a6689ef9ece91cef7e2b018e24f834039
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8343714"
---
# <a name="using-windows-runtime-objects-in-a-multithreaded-environment"></a><span data-ttu-id="2f256-104">マルチスレッド環境での Windows ランタイム オブジェクトの使用</span><span class="sxs-lookup"><span data-stu-id="2f256-104">Using Windows Runtime objects in a multithreaded environment</span></span>
<span data-ttu-id="2f256-105">この記事では、C# および Visual Basic コードからオブジェクト (Windows ランタイム や Windows ランタイム コンポーネントによって提供されるオブジェクト) を呼び出すとき、.NET Framework がどのようにこの呼び出しを処理するかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2f256-105">This article discusses the way the .NET Framework handles calls from C# and Visual Basic code to objects that are provided by the Windows Runtime or by Windows Runtime Components.</span></span>

<span data-ttu-id="2f256-106">.NET Framework では、既定で、特別な処理をせずに、複数のスレッドからどのようなオブジェクトにでもアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="2f256-106">In the .NET Framework, you can access any object from multiple threads by default, without special handling.</span></span> <span data-ttu-id="2f256-107">必要なものは、オブジェクトへの参照だけです。</span><span class="sxs-lookup"><span data-stu-id="2f256-107">All you need is a reference to the object.</span></span> <span data-ttu-id="2f256-108">Windows ランタイム では、このようなオブジェクトは*アジャイル*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2f256-108">In the Windows Runtime, such objects are called *agile*.</span></span> <span data-ttu-id="2f256-109">ほとんどの Windows ランタイム クラスはアジャイルですが、アジャイルでないクラスもいくつかあります。またアジャイル クラスであっても、特別な処理が必要となる場合があります。</span><span class="sxs-lookup"><span data-stu-id="2f256-109">Most Windows Runtime classes are agile, but a few classes are not, and even agile classes may require special handling.</span></span>

<span data-ttu-id="2f256-110">可能であれば、Windows ランタイム などの他のソースからのオブジェクトは共通言語ランタイム (CLR) によって処理されます。この場合、これらのオブジェクトは、.NET Framework オブジェクトであるかのように扱われます。</span><span class="sxs-lookup"><span data-stu-id="2f256-110">Wherever possible, the common language runtime (CLR) treats objects from other sources, such as the Windows Runtime, as if they were .NET Framework objects:</span></span>

- <span data-ttu-id="2f256-111">オブジェクトによって [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) インターフェイスが実装されるか、オブジェクトの [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性の値が [MarshalingType.Agile](http://go.microsoft.com/fwlink/p/?LinkId=256023) である場合、CLR はこのオブジェクトをアジャイルとして処理します。</span><span class="sxs-lookup"><span data-stu-id="2f256-111">If the object implements the [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) interface, or has the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.Agile](http://go.microsoft.com/fwlink/p/?LinkId=256023), the CLR treats it as agile.</span></span>

- <span data-ttu-id="2f256-112">ターゲット オブジェクトのスレッド コンテキストに対して行われるスレッドからの呼び出しを CLR がマーシャリングできる場合、それは透過的に行われます。</span><span class="sxs-lookup"><span data-stu-id="2f256-112">If CLR can marshal a call from the thread where it was made to the threading context of the target object, it does so transparently.</span></span>

- <span data-ttu-id="2f256-113">オブジェクトの [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性の値が [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023) である場合、このクラスはマーシャリング情報を提供しません。</span><span class="sxs-lookup"><span data-stu-id="2f256-113">If the object has the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023), the class does not provide marshaling information.</span></span> <span data-ttu-id="2f256-114">CLR は呼び出しをマーシャリングできないため、オブジェクトを使用できるのはそのオブジェクトが作成されたスレッド コンテキスト内のみであることを示すメッセージと共に [InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-114">The CLR cannot marshal the call, so it throws an [InvalidCastException](/dotnet/api/system.invalidcastexception) exception with a message indicating that the object can be used only in the threading context where it was created.</span></span>

<span data-ttu-id="2f256-115">以下のセクションでは、こうした動作がさまざまなソースからのオブジェクトに対してどのような影響を与えるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2f256-115">The following sections describe the effects of this behavior on objects from various sources.</span></span>

## <a name="objects-from-a-windows-runtime-component-that-is-written-in-c-or-visual-basic"></a><span data-ttu-id="2f256-116">C# または Visual Basic で記述された Windows ランタイム コンポーネントからのオブジェクト</span><span class="sxs-lookup"><span data-stu-id="2f256-116">Objects from a Windows Runtime component that is written in C# or Visual Basic</span></span>
<span data-ttu-id="2f256-117">アクティブ化できるコンポーネントのすべての型は、既定でアジャイルになります。</span><span class="sxs-lookup"><span data-stu-id="2f256-117">All the types in the component that can be activated are agile by default.</span></span>

> [!NOTE]
>  <span data-ttu-id="2f256-118">アジャイルであるからといって、スレッド セーフでもあるというわけではありません。</span><span class="sxs-lookup"><span data-stu-id="2f256-118">Agility doesn't imply thread safety.</span></span> <span data-ttu-id="2f256-119">Windows ランタイム および .NET Framework のどちらの場合も、ほとんどのクラスはスレッド セーフではありません。これは、スレッド セーフはパフォーマンス コストを伴うためです。また、ほとんどのオブジェクトは、複数のスレッドによってアクセスされることはありません。</span><span class="sxs-lookup"><span data-stu-id="2f256-119">In both the Windows Runtime and the .NET Framework, most classes are not thread safe because thread safety has a performance cost, and most objects are never accessed by multiple threads.</span></span> <span data-ttu-id="2f256-120">必要な場合にのみ、個々のオブジェクトへのアクセスを同期する (またはスレッド セーフなクラスを使用する) ことがより効率的な方法です。</span><span class="sxs-lookup"><span data-stu-id="2f256-120">It's more efficient to synchronize access to individual objects (or to use thread-safe classes) only as necessary.</span></span>

<span data-ttu-id="2f256-121">Windows ランタイム コンポーネントを作成する場合、既定値をオーバーライドができます。</span><span class="sxs-lookup"><span data-stu-id="2f256-121">When you author a Windows Runtime component, you can override the default.</span></span> <span data-ttu-id="2f256-122">[ICustomQueryInterface](/dotnet/api/system.runtime.interopservices.icustomqueryinterface) インターフェイスと [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) インターフェイスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f256-122">See the [ICustomQueryInterface](/dotnet/api/system.runtime.interopservices.icustomqueryinterface) interface and the [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) interface.</span></span>

## <a name="objects-from-the-windows-runtime"></a><span data-ttu-id="2f256-123">Windows ランタイム からのオブジェクト</span><span class="sxs-lookup"><span data-stu-id="2f256-123">Objects from the Windows Runtime</span></span>
<span data-ttu-id="2f256-124">Windows ランタイム のほとんどのクラスはアジャイルであり、CLR はこれらをアジャイルとして処理します。</span><span class="sxs-lookup"><span data-stu-id="2f256-124">Most classes in the Windows Runtime are agile, and the CLR treats them as agile.</span></span> <span data-ttu-id="2f256-125">これらのクラスに関するドキュメントでは、クラスの属性として "MarshalingBehaviorAttribute(Agile)" が示されています。</span><span class="sxs-lookup"><span data-stu-id="2f256-125">The documentation for these classes lists "MarshalingBehaviorAttribute(Agile)" among the class attributes.</span></span> <span data-ttu-id="2f256-126">ただし、これらのアジャイル クラスの一部に属するメンバー (XAML コントロールなど) は、UI スレッド上で呼び出されない場合、例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-126">However, the members of some of these agile classes, such as XAML controls, throw exceptions if they aren't called on the UI thread.</span></span> <span data-ttu-id="2f256-127">たとえば、次のコードでは、バック グラウンド スレッドを使用して、クリックされたボタンのプロパティを設定しようとします。</span><span class="sxs-lookup"><span data-stu-id="2f256-127">For example, the following code tries to use a background thread to set a property of the button that was clicked.</span></span> <span data-ttu-id="2f256-128">ボタンの [Content](http://go.microsoft.com/fwlink/p/?LinkId=256025) プロパティは例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-128">The button's [Content](http://go.microsoft.com/fwlink/p/?LinkId=256025) property throws an exception.</span></span>

```csharp
private async void Button_Click_2(object sender, RoutedEventArgs e)
{
    Button b = (Button) sender;
    await Task.Run(() => {
        b.Content += ".";
    });
}
```

```vb
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
    Dim b As Button = CType(sender, Button)
    Await Task.Run(Sub()
                       b.Content &= "."
                   End Sub)
End Sub
```

<span data-ttu-id="2f256-129">ボタンの [Dispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256026) プロパティ、または UI スレッドのコンテキスト (ボタンがあるページなど) に存在する任意のオブジェクトの `Dispatcher` プロパティを使用すれば、ボタンに安全にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="2f256-129">You can access the button safely by using its [Dispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256026) property, or the `Dispatcher` property of any object that exists in the context of the UI thread (such as the page the button is on).</span></span> <span data-ttu-id="2f256-130">次のコードでは、[CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトの [RunAsync](http://go.microsoft.com/fwlink/p/?LinkId=256030) メソッドを使用して、UI スレッドに呼び出しをディスパッチします。</span><span class="sxs-lookup"><span data-stu-id="2f256-130">The following code uses the [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object's [RunAsync](http://go.microsoft.com/fwlink/p/?LinkId=256030) method to dispatch the call on the UI thread.</span></span>

```csharp
private async void Button_Click_2(object sender, RoutedEventArgs e)
{
    Button b = (Button) sender;
    await b.Dispatcher.RunAsync(
        Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            b.Content += ".";
    });
}

```

```vb
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
    Dim b As Button = CType(sender, Button)
    Await b.Dispatcher.RunAsync(
        Windows.UI.Core.CoreDispatcherPriority.Normal,
        Sub()
            b.Content &= "."
        End Sub)
End Sub
```

> [!NOTE]
>  <span data-ttu-id="2f256-131">`Dispatcher` プロパティが別のスレッドから呼び出された場合、このプロパティは例外をスローしません。</span><span class="sxs-lookup"><span data-stu-id="2f256-131">The `Dispatcher` property does not throw an exception when it's called from another thread.</span></span>

<span data-ttu-id="2f256-132">UI スレッドで作成された Windows ランタイム オブジェクトの有効期間は、スレッドの有効期間によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="2f256-132">The lifetime of a Windows Runtime object that is created on the UI thread is bounded by the lifetime of the thread.</span></span> <span data-ttu-id="2f256-133">ウィンドウが閉じられた後は、UI スレッド上のオブジェクトにはアクセスしないでください。</span><span class="sxs-lookup"><span data-stu-id="2f256-133">Do not try to access objects on a UI thread after the window has closed.</span></span>

<span data-ttu-id="2f256-134">XAML コントロールを継承したり、XAML コントロールのセットを作成したりすることによって、独自のコントロールを作成する場合、作成したコントロールは .NET Framework オブジェクトであるため、アジャイルになります。</span><span class="sxs-lookup"><span data-stu-id="2f256-134">If you create your own control by inheriting a XAML control, or by composing a set of XAML controls, your control is agile because it's a .NET Framework object.</span></span> <span data-ttu-id="2f256-135">ただし、そのコントロールの基底クラスまたは構成要素であるクラスのメンバーを呼び出す場合や、継承されたメンバーを呼び出す場合は、それらのメンバーは UI スレッド以外のいずれかのスレッドから呼び出されると、例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-135">However, if it calls members of its base class or constituent classes, or if you call inherited members, those members will throw exceptions when they are called from any thread except the UI thread.</span></span>

### <a name="classes-that-cant-be-marshaled"></a><span data-ttu-id="2f256-136">マーシャリングできないクラス</span><span class="sxs-lookup"><span data-stu-id="2f256-136">Classes that can't be marshaled</span></span>
<span data-ttu-id="2f256-137">マーシャリング情報が提供されない Windows ランタイム クラスには、値が [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023) である [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) 属性が含まれます。</span><span class="sxs-lookup"><span data-stu-id="2f256-137">Windows Runtime classes that do not provide marshaling information have the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023).</span></span> <span data-ttu-id="2f256-138">このようなクラスに関するドキュメントでは、クラスの属性として "MarshalingBehaviorAttribute(None)" が示されています。</span><span class="sxs-lookup"><span data-stu-id="2f256-138">The documentation for such a class lists "MarshalingBehaviorAttribute(None)" among its attributes.</span></span>

<span data-ttu-id="2f256-139">次のコードでは、UI スレッドに [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) オブジェクトを作成して、スレッド プールのスレッドからオブジェクトのプロパティを設定しようとします。</span><span class="sxs-lookup"><span data-stu-id="2f256-139">The following code creates a [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) object on the UI thread, and then tries to set a property of the object from a thread pool thread.</span></span> <span data-ttu-id="2f256-140">CLR は呼び出しをマーシャリングできないため、オブジェクトを使用できるのはそのオブジェクトが作成されたスレッド コンテキスト内のみであることを示すメッセージと共に [System.InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-140">The CLR is unable to marshal the call, and throws a [System.InvalidCastException](/dotnet/api/system.invalidcastexception) exception with a message indicating that the object can be used only in the threading context where it was created.</span></span>

```csharp
Windows.Media.Capture.CameraCaptureUI ccui;

private async void Button_Click_1(object sender, RoutedEventArgs e)
{
    ccui = new Windows.Media.Capture.CameraCaptureUI();

    await Task.Run(() => {
        ccui.PhotoSettings.AllowCropping = true;
    });
}

```

```vb
Private ccui As Windows.Media.Capture.CameraCaptureUI

Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
    ccui = New Windows.Media.Capture.CameraCaptureUI()

    Await Task.Run(Sub()
                       ccui.PhotoSettings.AllowCropping = True
                   End Sub)
End Sub
```

<span data-ttu-id="2f256-141">[CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) に関するドキュメントでは、クラスの属性として "ThreadingAttribute(STA)" も示されています。これは、このクラスのオブジェクトが UI スレッドなどシングル スレッドのコンテキストで作成される必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="2f256-141">The documentation for [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) also lists "ThreadingAttribute(STA)" among the class's attributes, because it must be created in a single-threaded context such as the UI thread.</span></span>

<span data-ttu-id="2f256-142">別のスレッドから [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) オブジェクトにアクセスする場合、UI スレッドの [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトをキャッシュしておき、後でこのオブジェクト使用して、その別のスレッドに呼び出しをディスパッチすることができます。</span><span class="sxs-lookup"><span data-stu-id="2f256-142">If you want to access the [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) object from another thread, you can cache the [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object for the UI thread and use it later to dispatch the call on that thread.</span></span> <span data-ttu-id="2f256-143">または、次のコードに示すように、ページなどの XAML オブジェクトからディスパッチャーを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="2f256-143">Or you can obtain the dispatcher from a XAML object such as the page, as shown in the following code.</span></span>

```csharp
Windows.Media.Capture.CameraCaptureUI ccui;

private async void Button_Click_3(object sender, RoutedEventArgs e)
{
    ccui = new Windows.Media.Capture.CameraCaptureUI();

    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            ccui.PhotoSettings.AllowCropping = true;
        });
}

```

```vb
Dim ccui As Windows.Media.Capture.CameraCaptureUI

Private Async Sub Button_Click_3(sender As Object, e As RoutedEventArgs)

    ccui = New Windows.Media.Capture.CameraCaptureUI()

    Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                Sub()
                                    ccui.PhotoSettings.AllowCropping = True
                                End Sub)
End Sub
```

## <a name="objects-from-a-windows-runtime-component-that-is-written-in-c"></a><span data-ttu-id="2f256-144">C++ で記述された Windows ランタイム コンポーネントからのオブジェクト</span><span class="sxs-lookup"><span data-stu-id="2f256-144">Objects from a Windows Runtime component that is written in C++</span></span>
<span data-ttu-id="2f256-145">既定では、アクティブ化できるコンポーネントのクラスはアジャイルです。</span><span class="sxs-lookup"><span data-stu-id="2f256-145">By default, classes in the component that can be activated are agile.</span></span> <span data-ttu-id="2f256-146">ただし、C++ ではスレッド モデルやマーシャリングの動作に対して非常に多数の制御を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="2f256-146">However, C++ allows a significant amount of control over threading models and marshaling behavior.</span></span> <span data-ttu-id="2f256-147">この記事で既に説明したように、CLR はアジャイル クラスを認識し、クラスがアジャイルでない場合は呼び出しをマーシャリングしようとします。また、クラスにマーシャリング情報がない場合は、[System.InvalidCastException](/dotnet/api/system.invalidcastexception) 例外をスローします。</span><span class="sxs-lookup"><span data-stu-id="2f256-147">As described earlier in this article, the CLR recognizes agile classes, tries to marshal calls when classes are not agile, and throws a [System.InvalidCastException](/dotnet/api/system.invalidcastexception) exception when a class has no marshaling information.</span></span>

<span data-ttu-id="2f256-148">UI スレッドで実行され、UI スレッド以外のスレッドから呼び出された場合に例外をスローするオブジェクトでは、UI スレッドの [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) オブジェクトを使用して呼び出しをディスパッチできます。</span><span class="sxs-lookup"><span data-stu-id="2f256-148">For objects that run on the UI thread and throw exceptions when they are called from a thread other than the UI thread, you can use the UI thread’s [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object to dispatch the call.</span></span>

## <a name="see-also"></a><span data-ttu-id="2f256-149">関連項目</span><span class="sxs-lookup"><span data-stu-id="2f256-149">See Also</span></span>
[<span data-ttu-id="2f256-150">C# ガイド</span><span class="sxs-lookup"><span data-stu-id="2f256-150">C# Guide</span></span>](/dotnet/articles/csharp/)

[<span data-ttu-id="2f256-151">Visual Basic ガイド</span><span class="sxs-lookup"><span data-stu-id="2f256-151">Visual Basic Guide</span></span>](/dotnet/articles/visual-basic/)
