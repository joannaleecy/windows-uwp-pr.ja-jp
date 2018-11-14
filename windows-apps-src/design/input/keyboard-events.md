---
author: Karl-Bridge-Microsoft
Description: Respond to keystroke actions from hardware or software keyboards in your apps using both keyboard and class event handlers.
title: キーボード イベント
ms.assetid: ac500772-d6ed-4a3a-825b-210a9c3c8f59
label: Keyboard events
template: detail.hbs
keywords: キーボード, ゲームパッド, リモート, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, キーのリリース, キーの押下
ms.author: kbridge
ms.date: 03/29/2017
ms.topic: article
pm-contact: chigy
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4a9abc16a4992dedead598f96061811c82c5a5c5
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6200209"
---
# <a name="keyboard-events"></a><span data-ttu-id="3b887-103">キーボード イベント</span><span class="sxs-lookup"><span data-stu-id="3b887-103">Keyboard events</span></span>

## <a name="keyboard-events-and-focus"></a><span data-ttu-id="3b887-104">キーボード イベントとフォーカス</span><span class="sxs-lookup"><span data-stu-id="3b887-104">Keyboard events and focus</span></span>

<span data-ttu-id="3b887-105">次のキーボード イベントは、ハードウェア キーボードとタッチ キーボードの両方で発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-105">The following keyboard events can occur for both hardware and touch keyboards.</span></span>

| <span data-ttu-id="3b887-106">イベント</span><span class="sxs-lookup"><span data-stu-id="3b887-106">Event</span></span>                                      | <span data-ttu-id="3b887-107">説明</span><span class="sxs-lookup"><span data-stu-id="3b887-107">Description</span></span>                    |
|--------------------------------------------|--------------------------------|
| [**<span data-ttu-id="3b887-108">KeyDown</span><span class="sxs-lookup"><span data-stu-id="3b887-108">KeyDown</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208941) | <span data-ttu-id="3b887-109">キーが押されると発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-109">Occurs when a key is pressed.</span></span>  |
| [**<span data-ttu-id="3b887-110">KeyUp</span><span class="sxs-lookup"><span data-stu-id="3b887-110">KeyUp</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208942)     | <span data-ttu-id="3b887-111">キーが離されると発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-111">Occurs when a key is released.</span></span> |

> [!IMPORTANT]
> <span data-ttu-id="3b887-112">一部の Windows ランタイム コントロールでは、入力イベントが内部で処理されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-112">Some Windows Runtime controls handle input events internally.</span></span> <span data-ttu-id="3b887-113">このような場合は、イベント リスナーに関連付けられているハンドラーが呼び出されないため、入力イベントが発生しないように見えることがあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-113">In these cases, it might appear that an input event doesn't occur because your event listener doesn't invoke the associated handler.</span></span> <span data-ttu-id="3b887-114">通常、これらのキーのサブセットはクラス ハンドラーで処理され、基本的なキーボード アクセシビリティのビルトイン サポートが提供されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-114">Typically, this subset of keys is processed by the class handler to provide built in support of basic keyboard accessibility.</span></span> <span data-ttu-id="3b887-115">たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) クラスでは、Space キーと Enter キーの [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) イベント (および [**OnPointerPressed**](https://msdn.microsoft.com/library/windows/apps/hh967989)) がオーバーライドされ、コントロールの [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントにルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="3b887-115">For example, the [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) class overrides the [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) events for both the Space key and the Enter key (as well as [**OnPointerPressed**](https://msdn.microsoft.com/library/windows/apps/hh967989)) and routes them to the [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event of the control.</span></span> <span data-ttu-id="3b887-116">キーの押下がコントロール クラスで処理された場合、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="3b887-116">When a key press is handled by the control class, the [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events are not raised.</span></span>  
> <span data-ttu-id="3b887-117">これで、ボタンの実行に対応するキーボード操作が組み込まれ、ボタンを指でタップした場合やマウスでクリックした場合と同様の動作がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="3b887-117">This provides a built-in keyboard equivalent for invoking the button, similar to tapping it with a finger or clicking it with a mouse.</span></span> <span data-ttu-id="3b887-118">Space キーと Enter キー以外のキーについては、通常どおり [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) と [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-118">Keys other than Space or Enter still fire [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events.</span></span> <span data-ttu-id="3b887-119">クラス ベースのイベント処理の動作について詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」(特に「コントロールの入力イベント ハンドラー」セクション) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-119">For more info about how class-based handling of events works (specifically, the "Input event handlers in controls" section), see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584).</span></span>


<span data-ttu-id="3b887-120">UI のコントロールに入力フォーカスがあるときにだけ、キーボード イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-120">Controls in your UI generate keyboard events only when they have input focus.</span></span> <span data-ttu-id="3b887-121">個々のコントロールは、ユーザーがレイアウト上でコントロールを直接クリックまたはタップするか、Tab キーを使ってコンテンツ領域内のタブ順に入ると、フォーカスを取得します。</span><span class="sxs-lookup"><span data-stu-id="3b887-121">An individual control gains focus when the user clicks or taps directly on that control in the layout, or uses the Tab key to step into a tab sequence within the content area.</span></span>

<span data-ttu-id="3b887-122">コントロールの [**Focus**](https://msdn.microsoft.com/library/windows/apps/hh702161) メソッドを呼び出して、フォーカスを適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-122">You can also call a control's [**Focus**](https://msdn.microsoft.com/library/windows/apps/hh702161) method to force focus.</span></span> <span data-ttu-id="3b887-123">これは、UI が読み込まれたときに既定ではキーボード フォーカスが設定されないため、ショートカット キーを実装する場合に必要です。</span><span class="sxs-lookup"><span data-stu-id="3b887-123">This is necessary when you implement shortcut keys, because keyboard focus is not set by default when your UI loads.</span></span> <span data-ttu-id="3b887-124">詳しくは、このトピックの「**ショートカット キーの例**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-124">For more info, see the **Shortcut keys example** later in this topic.</span></span>

<span data-ttu-id="3b887-125">コントロールが入力フォーカスを受け取るには、コントロールが有効にされ、表示されている必要があります。また、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) プロパティ値と [**HitTestVisible**](https://msdn.microsoft.com/library/windows/apps/br208933) プロパティ値が **true** に設定されている必要もあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-125">For a control to receive input focus, it must be enabled, visible, and have [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/br209422) and [**HitTestVisible**](https://msdn.microsoft.com/library/windows/apps/br208933) property values of **true**.</span></span> <span data-ttu-id="3b887-126">これは、ほとんどのコントロールの既定の状態です。</span><span class="sxs-lookup"><span data-stu-id="3b887-126">This is the default state for most controls.</span></span> <span data-ttu-id="3b887-127">コントロールに入力フォーカスがあると、このトピックで後ほど説明するように、キーボード入力イベントを発生させ、応答することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-127">When a control has input focus, it can raise and respond to keyboard input events as described later in this topic.</span></span> <span data-ttu-id="3b887-128">また、[**GotFocus**](https://msdn.microsoft.com/library/windows/apps/br208927) イベントと [**LostFocus**](https://msdn.microsoft.com/library/windows/apps/br208943) イベントを処理して、フォーカスを受け取るコントロールやフォーカスを失うコントロールに応答することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-128">You can also respond to a control that is receiving or losing focus by handling the [**GotFocus**](https://msdn.microsoft.com/library/windows/apps/br208927) and [**LostFocus**](https://msdn.microsoft.com/library/windows/apps/br208943) events.</span></span>

<span data-ttu-id="3b887-129">既定では、コントロールのタブ順は、Extensible Application Markup Language (XAML) 内の出現順になっています。</span><span class="sxs-lookup"><span data-stu-id="3b887-129">By default, the tab sequence of controls is the order in which they appear in the Extensible Application Markup Language (XAML).</span></span> <span data-ttu-id="3b887-130">ただし、[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) プロパティを使って、この順序を変更できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-130">However, you can modify this order by using the [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/br209461) property.</span></span> <span data-ttu-id="3b887-131">詳しくは、「[キーボード アクセシビリティの実装](https://msdn.microsoft.com/library/windows/apps/hh868161)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-131">For more info, see [Implementing keyboard accessibility](https://msdn.microsoft.com/library/windows/apps/hh868161).</span></span>

## <a name="keyboard-event-handlers"></a><span data-ttu-id="3b887-132">キーボード イベント ハンドラー</span><span class="sxs-lookup"><span data-stu-id="3b887-132">Keyboard event handlers</span></span>


<span data-ttu-id="3b887-133">入力イベント ハンドラーは、次の情報を提供するデリゲートを実装します。</span><span class="sxs-lookup"><span data-stu-id="3b887-133">An input event handler implements a delegate that provides the following information:</span></span>

-   <span data-ttu-id="3b887-134">イベントのセンダー。</span><span class="sxs-lookup"><span data-stu-id="3b887-134">The sender of the event.</span></span> <span data-ttu-id="3b887-135">センダーは、イベント ハンドラーがアタッチされているオブジェクトを報告します。</span><span class="sxs-lookup"><span data-stu-id="3b887-135">The sender reports the object where the event handler is attached.</span></span>
-   <span data-ttu-id="3b887-136">イベント データ。</span><span class="sxs-lookup"><span data-stu-id="3b887-136">Event data.</span></span> <span data-ttu-id="3b887-137">キーボード イベントの場合、イベント データは [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) のインスタンスです。</span><span class="sxs-lookup"><span data-stu-id="3b887-137">For keyboard events, that data will be an instance of [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072).</span></span> <span data-ttu-id="3b887-138">ハンドラーのデリゲートは [**KeyEventHandler**](https://msdn.microsoft.com/library/windows/apps/br227904) です。</span><span class="sxs-lookup"><span data-stu-id="3b887-138">The delegate for handlers is [**KeyEventHandler**](https://msdn.microsoft.com/library/windows/apps/br227904).</span></span> <span data-ttu-id="3b887-139">ハンドラーに関するほとんどのシナリオで、最もよく使われる **KeyRoutedEventArgs** のプロパティは、[**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) です。場合によっては、[**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075) も使われます。</span><span class="sxs-lookup"><span data-stu-id="3b887-139">The most relevant properties of **KeyRoutedEventArgs** for most handler scenarios are [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) and possibly [**KeyStatus**](https://msdn.microsoft.com/library/windows/apps/hh943075).</span></span>
-   <span data-ttu-id="3b887-140">[**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810)。</span><span class="sxs-lookup"><span data-stu-id="3b887-140">[**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810).</span></span> <span data-ttu-id="3b887-141">キーボード イベントはルーティング イベントであるため、イベント データには **OriginalSource** があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-141">Because the keyboard events are routed events, the event data provides **OriginalSource**.</span></span> <span data-ttu-id="3b887-142">イベントがオブジェクト ツリーをバブルアップするように意図的に設定した場合、**OriginalSource** がセンダーではなく対象のオブジェクトとなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-142">If you deliberately allow events to bubble up through an object tree, **OriginalSource** is sometimes the object of concern rather than sender.</span></span> <span data-ttu-id="3b887-143">ただし、この動作は設計によって異なります。</span><span class="sxs-lookup"><span data-stu-id="3b887-143">However, that depends on your design.</span></span> <span data-ttu-id="3b887-144">センダーではなく **OriginalSource** を使う方法について詳しくは、このトピックの「キーボード ルーティング イベント」または「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-144">For more information about how you might use **OriginalSource** rather than sender, see the "Keyboard Routed Events" section of this topic, or [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584).</span></span>

### <a name="attaching-a-keyboard-event-handler"></a><span data-ttu-id="3b887-145">キーボード イベント ハンドラーのアタッチ</span><span class="sxs-lookup"><span data-stu-id="3b887-145">Attaching a keyboard event handler</span></span>

<span data-ttu-id="3b887-146">イベントがメンバーとして含まれているオブジェクトに対して、キーボード イベント ハンドラー関数をアタッチできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-146">You can attach keyboard event-handler functions for any object that includes the event as a member.</span></span> <span data-ttu-id="3b887-147">[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 派生クラスにもアタッチできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-147">This includes any [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) derived class.</span></span> <span data-ttu-id="3b887-148">XAML で [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする方法を次の例に示します。</span><span class="sxs-lookup"><span data-stu-id="3b887-148">The following XAML example shows how to attach handlers for the [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) event for a [**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704).</span></span>

```xaml
<Grid KeyUp="Grid_KeyUp">
  ...
</Grid>
```

<span data-ttu-id="3b887-149">コードを使ってイベント ハンドラーをアタッチすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-149">You can also attach an event handler in code.</span></span> <span data-ttu-id="3b887-150">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-150">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584).</span></span>

### <a name="defining-a-keyboard-event-handler"></a><span data-ttu-id="3b887-151">キーボード イベント ハンドラーの定義</span><span class="sxs-lookup"><span data-stu-id="3b887-151">Defining a keyboard event handler</span></span>

<span data-ttu-id="3b887-152">次の例は、前の例でアタッチした [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの定義の一部です。</span><span class="sxs-lookup"><span data-stu-id="3b887-152">The following example shows the incomplete event handler definition for the [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) event handler that was attached in the preceding example.</span></span>

```csharp
void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
{
    //handling code here
}
```

```vb
Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As KeyRoutedEventArgs)
    ' handling code here
End Sub
```

```c++
void MyProject::MainPage::Grid_KeyUp(
  Platform::Object^ sender,
  Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
  {
      //handling code here
  }
```

### <a name="using-keyroutedeventargs"></a><span data-ttu-id="3b887-153">KeyRoutedEventArgs の使用</span><span class="sxs-lookup"><span data-stu-id="3b887-153">Using KeyRoutedEventArgs</span></span>

<span data-ttu-id="3b887-154">キーボード イベントはいずれもイベント データに [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) を使います。**KeyRoutedEventArgs** には次のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-154">All keyboard events use [**KeyRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943072) for event data, and **KeyRoutedEventArgs** contains the following properties:</span></span>

-   [**<span data-ttu-id="3b887-155">Key</span><span class="sxs-lookup"><span data-stu-id="3b887-155">Key</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh943074)
-   [**<span data-ttu-id="3b887-156">KeyStatus</span><span class="sxs-lookup"><span data-stu-id="3b887-156">KeyStatus</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh943075)
-   [**<span data-ttu-id="3b887-157">Handled</span><span class="sxs-lookup"><span data-stu-id="3b887-157">Handled</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh943073)
-   <span data-ttu-id="3b887-158">[**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) ([**RoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br208809) から継承)</span><span class="sxs-lookup"><span data-stu-id="3b887-158">[**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) (inherited from [**RoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br208809))</span></span>

### <a name="key"></a><span data-ttu-id="3b887-159">キー</span><span class="sxs-lookup"><span data-stu-id="3b887-159">Key</span></span>

<span data-ttu-id="3b887-160">キーが押されると、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-160">The [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) event is raised if a key is pressed.</span></span> <span data-ttu-id="3b887-161">同様に、キーが離されると、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-161">Likewise, [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) is raised if a key is released.</span></span> <span data-ttu-id="3b887-162">通常、特定のキー値を処理するにはイベントをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="3b887-162">Usually, you listen to the events to process a specific key value.</span></span> <span data-ttu-id="3b887-163">押されたキーまたは離されたキーを特定するには、イベント データの [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) 値を調べます。</span><span class="sxs-lookup"><span data-stu-id="3b887-163">To determine which key is pressed or released, check the [**Key**](https://msdn.microsoft.com/library/windows/apps/hh943074) value in the event data.</span></span> <span data-ttu-id="3b887-164">**Key** は [**VirtualKey**](https://msdn.microsoft.com/library/windows/apps/br241812) 値を返します。</span><span class="sxs-lookup"><span data-stu-id="3b887-164">**Key** returns a [**VirtualKey**](https://msdn.microsoft.com/library/windows/apps/br241812) value.</span></span> <span data-ttu-id="3b887-165">**VirtualKey** 列挙体には、サポートされているすべてのキーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3b887-165">The **VirtualKey** enumeration includes all the supported keys.</span></span>

### <a name="modifier-keys"></a><span data-ttu-id="3b887-166">修飾キー</span><span class="sxs-lookup"><span data-stu-id="3b887-166">Modifier keys</span></span>

<span data-ttu-id="3b887-167">修飾キーは、Ctrl、Shift など、一般的に他のキーと組み合わせて押されるキーです。</span><span class="sxs-lookup"><span data-stu-id="3b887-167">Modifier keys are keys such as Ctrl or Shift that users typically press in combination with other keys.</span></span> <span data-ttu-id="3b887-168">アプリでは、これらのキーの組み合わせをキーボード ショートカットとして使って、アプリ コマンドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-168">Your app can use these combinations as keyboard shortcuts to invoke app commands.</span></span>

<span data-ttu-id="3b887-169">ショートカット キーの組み合わせを検出するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベント ハンドラーや [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーでコードを使います。</span><span class="sxs-lookup"><span data-stu-id="3b887-169">You detect shortcut key combinations by using code in your [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) event handlers.</span></span> <span data-ttu-id="3b887-170">目的とする修飾キーが押された状態を追跡することができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-170">You can then track the pressed state of the modifier keys you are interested in.</span></span> <span data-ttu-id="3b887-171">修飾キー以外のキーのキーボード イベントが発生した場合は、同時に修飾キーが押された状態になっていないかどうかを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-171">When a keyboard event occurs for a non-modifier key, you can check whether a modifier key is in the pressed state at the same time.</span></span>

> [!NOTE]
> <span data-ttu-id="3b887-172">Alt キーは **VirtualKey.Menu** 値で表されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-172">The Alt key is represented by the **VirtualKey.Menu** value.</span></span>

 

### <a name="shortcut-keys-example"></a><span data-ttu-id="3b887-173">ショートカット キーの例</span><span class="sxs-lookup"><span data-stu-id="3b887-173">Shortcut keys example</span></span>


<span data-ttu-id="3b887-174">ショートカット キーを実装する方法を次の例で示します。</span><span class="sxs-lookup"><span data-stu-id="3b887-174">The following example demonstrates how to implement shortcut keys.</span></span> <span data-ttu-id="3b887-175">この例では、ユーザーは [Play]、[Pause]、[Stop] の各ボタンまたは Ctrl + P、Ctrl + A、Ctrl + S の各キーボード ショートカットを使って、メディアの再生を制御できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-175">In this example, users can control media playback using Play, Pause, and Stop buttons or Ctrl+P, Ctrl+A, and Ctrl+S keyboard shortcuts.</span></span> <span data-ttu-id="3b887-176">ボタンの XAML では、ボタン ラベルのヒントや [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/br209081) プロパティを使って、ショートカット キーを示します。</span><span class="sxs-lookup"><span data-stu-id="3b887-176">The button XAML shows the shortcuts by using tooltips and [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/br209081) properties in the button labels.</span></span> <span data-ttu-id="3b887-177">このアプリ内の説明は、アプリの操作性とアクセシビリティを向上させるために重要です。</span><span class="sxs-lookup"><span data-stu-id="3b887-177">This self-documentation is important to increase the usability and accessibility of your app.</span></span> <span data-ttu-id="3b887-178">詳しくは、「[キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-178">For more info, see [Keyboard accessibility](https://msdn.microsoft.com/library/windows/apps/mt244347).</span></span>

<span data-ttu-id="3b887-179">ページが読み込まれるときに、入力フォーカスをページそのものに設定していることにも注目してください。</span><span class="sxs-lookup"><span data-stu-id="3b887-179">Note also that the page sets input focus to itself when it is loaded.</span></span> <span data-ttu-id="3b887-180">この手順を実行しなければ、最初の入力フォーカスがどのコントロールにも設定されず、ユーザーが手動で入力フォーカスを設定する (Tab キーを使ってコントロールを選ぶ、コントロールをクリックするなど) までアプリで入力イベントが発生しません。</span><span class="sxs-lookup"><span data-stu-id="3b887-180">Without this step, no control has initial input focus, and the app does not raise input events until the user sets the input focus manually (for example, by tabbing to or clicking a control).</span></span>

```xaml
<Grid KeyDown="Grid_KeyDown">

  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>

  <MediaElement x:Name="DemoMovie" Source="xbox.wmv"
    Width="500" Height="500" Margin="20" HorizontalAlignment="Center" />

  <StackPanel Grid.Row="1" Margin="10"
    Orientation="Horizontal" HorizontalAlignment="Center">

    <Button x:Name="PlayButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+P"
      AutomationProperties.AcceleratorKey="Control P">
      <TextBlock>Play</TextBlock>
    </Button>

    <Button x:Name="PauseButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+A"
      AutomationProperties.AcceleratorKey="Control A">
      <TextBlock>Pause</TextBlock>
    </Button>

    <Button x:Name="StopButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+S"
      AutomationProperties.AcceleratorKey="Control S">
      <TextBlock>Stop</TextBlock>
    </Button>

  </StackPanel>

</Grid>
```

```c++
//showing implementations but not header definitions
void MainPage::OnNavigatedTo(NavigationEventArgs^ e)
{
    (void) e;    // Unused parameter
    this->Loaded+=ref new RoutedEventHandler(this,&amp;MainPage::ProgrammaticFocus);
}
void MainPage::ProgrammaticFocus(Object^ sender, RoutedEventArgs^ e) {
    this->Focus(Windows::UI::Xaml::FocusState::Programmatic);
}

void KeyboardSupport::MainPage::MediaButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    FrameworkElement^ fe = safe_cast<FrameworkElement^>(sender);
    if (fe->Name == "PlayButton") {DemoMovie->Play();}
    if (fe->Name == "PauseButton") {DemoMovie->Pause();}
    if (fe->Name == "StopButton") {DemoMovie->Stop();}
}


bool KeyboardSupport::MainPage::IsCtrlKeyPressed()
{
    auto ctrlState = CoreWindow::GetForCurrentThread()->GetKeyState(VirtualKey::Control);
    return (ctrlState & CoreVirtualKeyStates::Down) == CoreVirtualKeyStates::Down;
}

void KeyboardSupport::MainPage::Grid_KeyDown(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (e->Key == VirtualKey::Control) isCtrlKeyPressed = true;
}


void KeyboardSupport::MainPage::Grid_KeyUp(Platform::Object^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs^ e)
{
    if (IsCtrlKeyPressed()) {
        if (e->Key==VirtualKey::P) { DemoMovie->Play(); }
        if (e->Key==VirtualKey::A) { DemoMovie->Pause(); }
        if (e->Key==VirtualKey::S) { DemoMovie->Stop(); }
    }
}
```

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    // Set the input focus to ensure that keyboard events are raised.
    this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
}

private void MediaButton_Click(object sender, RoutedEventArgs e)
{
    switch ((sender as Button).Name)
    {
        case "PlayButton": DemoMovie.Play(); break;
        case "PauseButton": DemoMovie.Pause(); break;
        case "StopButton": DemoMovie.Stop(); break;
    }
}

private static bool IsCtrlKeyPressed()
{
    var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
}

private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
{
    if (IsCtrlKeyPressed())
    {
        switch (e.Key)
        {
            case VirtualKey.P: DemoMovie.Play(); break;
            case VirtualKey.A: DemoMovie.Pause(); break;
            case VirtualKey.S: DemoMovie.Stop(); break;
        }
    }
}
```

```VisualBasic
Private isCtrlKeyPressed As Boolean
Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

End Sub

Private Function IsCtrlKeyPressed As Boolean
    Dim ctrlState As CoreVirtualKeyStates = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
    Return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
End Function

Private Sub Grid_KeyDown(sender As Object, e As KeyRoutedEventArgs)
    If IsCtrlKeyPressed() Then
        Select Case e.Key
            Case Windows.System.VirtualKey.P
                DemoMovie.Play()
            Case Windows.System.VirtualKey.A
                DemoMovie.Pause()
            Case Windows.System.VirtualKey.S
                DemoMovie.Stop()
        End Select
    End If
End Sub

Private Sub MediaButton_Click(sender As Object, e As RoutedEventArgs)
    Dim fe As FrameworkElement = CType(sender, FrameworkElement)
    Select Case fe.Name
        Case "PlayButton"
            DemoMovie.Play()
        Case "PauseButton"
            DemoMovie.Pause()
        Case "StopButton"
            DemoMovie.Stop()
    End Select
End Sub
```

> [!NOTE]
> <span data-ttu-id="3b887-181">XAML で [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/hh759762) または [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/hh759763) を設定すると、(その特定の操作を呼び出すためのショートカット キーを説明する) 文字列情報が提供されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-181">Setting [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/hh759762) or [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/hh759763) in XAML provides string information, which documents the shortcut key for invoking that particular action.</span></span> <span data-ttu-id="3b887-182">この情報は、ナレーターなどの Microsoft UI オートメーション クライアントによってキャプチャされ、通常は、直接ユーザーに提供されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-182">The information is captured by Microsoft UI Automation clients such as Narrator, and is typically provided directly to the user.</span></span>
>
> <span data-ttu-id="3b887-183">**AutomationProperties.AcceleratorKey** または **AutomationProperties.AccessKey** を設定しても、それだけでは操作は実行されません。</span><span class="sxs-lookup"><span data-stu-id="3b887-183">Setting **AutomationProperties.AcceleratorKey** or **AutomationProperties.AccessKey** does not have any action on its own.</span></span> <span data-ttu-id="3b887-184">実際にアプリにキーボード ショートカットの動作を実装するには、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントまたは [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントのハンドラーをアタッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-184">You will still need to attach handlers for [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) or [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events in order to actually implement the keyboard shortcut behavior in your app.</span></span> <span data-ttu-id="3b887-185">また、アクセス キーの下線も自動的には追加されません。</span><span class="sxs-lookup"><span data-stu-id="3b887-185">Also, the underline text decoration for an access key is not provided automatically.</span></span> <span data-ttu-id="3b887-186">UI で下線付きのテキストを表示する場合は、インラインの [**Underline**](https://msdn.microsoft.com/library/windows/apps/br209982) 書式設定として、ニーモニックの特定のキーのテキストに明示的に下線を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-186">You must explicitly underline the text for the specific key in your mnemonic as inline [**Underline**](https://msdn.microsoft.com/library/windows/apps/br209982) formatting if you wish to show underlined text in the UI.</span></span>

 

## <a name="keyboard-routed-events"></a><span data-ttu-id="3b887-187">キーボード ルーティング イベント</span><span class="sxs-lookup"><span data-stu-id="3b887-187">Keyboard routed events</span></span>


<span data-ttu-id="3b887-188">[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) や、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) などの特定のイベントがルーティング イベントです。</span><span class="sxs-lookup"><span data-stu-id="3b887-188">Certain events are routed events, including [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942).</span></span> <span data-ttu-id="3b887-189">ルーティング イベントでは、バブル ルーティング方式が採用されています。</span><span class="sxs-lookup"><span data-stu-id="3b887-189">Routed events use the bubbling routing strategy.</span></span> <span data-ttu-id="3b887-190">バブル ルーティング方式では、子オブジェクトで発生したイベントが、オブジェクト ツリー内で上位にある親オブジェクトに順にルーティング (バブルアップ) されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-190">The bubbling routing strategy means that an event originates from a child object and is then routed up to successive parent objects in the object tree.</span></span> <span data-ttu-id="3b887-191">つまり、同じイベントを処理し、同じイベント データを操作する機会が増えることを意味します。</span><span class="sxs-lookup"><span data-stu-id="3b887-191">This presents another opportunity to handle the same event and interact with the same event data.</span></span>

<span data-ttu-id="3b887-192">次の XAML の例では、1 つの [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) と 2 つの [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) オブジェクトについて、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="3b887-192">Consider the following XAML example, which handles [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events for a [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) and two [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) objects.</span></span> <span data-ttu-id="3b887-193">この場合、どちらかの **Button** オブジェクトにフォーカスがある間にキーを離すと、**KeyUp** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-193">In this case, if you release a key while focus is held by either **Button** object, it raises the **KeyUp** event.</span></span> <span data-ttu-id="3b887-194">イベントはその後、親 **Canvas** までバブルアップされます。</span><span class="sxs-lookup"><span data-stu-id="3b887-194">The event is then bubbled up to the parent **Canvas**.</span></span>

```xaml
<StackPanel KeyUp="StackPanel_KeyUp">
  <Button Name="ButtonA" Content="Button A"/>
  <Button Name="ButtonB" Content="Button B"/>
  <TextBlock Name="statusTextBlock"/>
</StackPanel>
```

<span data-ttu-id="3b887-195">次の例は、前に示した XAML コンテンツに対応する [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベント ハンドラーの実装方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3b887-195">The following example shows how to implement the [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) event handler for the corresponding XAML content in the preceding example.</span></span>

```csharp
void StackPanel_KeyUp(object sender, KeyRoutedEventArgs e)
{
    statusTextBlock.Text = String.Format(
        "The key {0} was pressed while focus was on {1}",
        e.Key.ToString(), (e.OriginalSource as FrameworkElement).Name);
}
```

<span data-ttu-id="3b887-196">このハンドラーで [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) プロパティが使われていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3b887-196">Notice the use of the [**OriginalSource**](https://msdn.microsoft.com/library/windows/apps/br208810) property in the preceding handler.</span></span> <span data-ttu-id="3b887-197">この例では、**OriginalSource** がイベントの発生元のオブジェクトを報告します。</span><span class="sxs-lookup"><span data-stu-id="3b887-197">Here, **OriginalSource** reports the object that raised the event.</span></span> <span data-ttu-id="3b887-198">**StackPanel** はコントロールではなく、フォーカスを受け取ることもできないため、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) がこのオブジェクトになることはありません。</span><span class="sxs-lookup"><span data-stu-id="3b887-198">The object could not be the [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) because the **StackPanel** is not a control and cannot have focus.</span></span> <span data-ttu-id="3b887-199">**StackPanel** 内の 2 つのボタンのどちらか 1 つのみがイベントの発生元である可能性がありますが、発生元を調べるにはどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="3b887-199">Only one of the two buttons within the **StackPanel** could possibly have raised the event, but which one?</span></span> <span data-ttu-id="3b887-200">親オブジェクトのイベントを処理する場合は、**OriginalSource** を使って、実際のイベント ソース オブジェクトを判別します。</span><span class="sxs-lookup"><span data-stu-id="3b887-200">You use **OriginalSource** to distinguish the actual event source object, if you are handling the event on a parent object.</span></span>

### <a name="the-handled-property-in-event-data"></a><span data-ttu-id="3b887-201">イベント データ内の Handled プロパティ</span><span class="sxs-lookup"><span data-stu-id="3b887-201">The Handled property in event data</span></span>

<span data-ttu-id="3b887-202">イベント処理の方針によっては、1 つのイベント ハンドラーだけがバブル イベントに応答するようにした方がよい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-202">Depending on your event handling strategy, you might want only one event handler to react to a bubbling event.</span></span> <span data-ttu-id="3b887-203">たとえば、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) コントロールの 1 つに、特定の [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) ハンドラーをアタッチすると、最初にそのイベントを処理するのは、このハンドラーがアタッチされたコントロールになります。</span><span class="sxs-lookup"><span data-stu-id="3b887-203">For instance, if you have a specific [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) handler attached to one of the [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) controls, it would have the first opportunity to handle that event.</span></span> <span data-ttu-id="3b887-204">このとき、親パネルではイベントが処理されないようにします。</span><span class="sxs-lookup"><span data-stu-id="3b887-204">In this case, you might not want the parent panel to also handle the event.</span></span> <span data-ttu-id="3b887-205">このようなシナリオでは、イベント データ内の [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="3b887-205">For this scenario, you can use the [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) property in the event data.</span></span>

<span data-ttu-id="3b887-206">ルーティング イベント データ クラスの [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) プロパティは、イベント ルート上で先に登録された別のハンドラーが既に処理を実行したことを示すためのプロパティで、</span><span class="sxs-lookup"><span data-stu-id="3b887-206">The purpose of the [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) property in a routed event data class is to report that another handler you registered earlier on the event route has already acted.</span></span> <span data-ttu-id="3b887-207">ルーティング イベント システムの動作に影響します。</span><span class="sxs-lookup"><span data-stu-id="3b887-207">This influences the behavior of the routed event system.</span></span> <span data-ttu-id="3b887-208">イベント ハンドラー内で **Handled** を **true** に設定すると、そのイベントのルーティングはそこで終了し、上位の親要素にイベントは送信されません。</span><span class="sxs-lookup"><span data-stu-id="3b887-208">When you set **Handled** to **true** in an event handler, that event stops routing and is not sent to successive parent elements.</span></span>

### <a name="addhandler-and-already-handled-keyboard-events"></a><span data-ttu-id="3b887-209">AddHandler イベントと処理済みキーボード イベント</span><span class="sxs-lookup"><span data-stu-id="3b887-209">AddHandler and already-handled keyboard events</span></span>

<span data-ttu-id="3b887-210">特殊な方法を利用して、既に処理済みとしてマークされているイベントに対して処理を実行できるハンドラーをアタッチすることができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-210">You can use a special technique for attaching handlers that can act on events that you already marked as handled.</span></span> <span data-ttu-id="3b887-211">この方法では、XAML 属性や、ハンドラーを追加するための言語固有の構文 (C# の場合は +=) を使わずに、[**AddHandler**](https://msdn.microsoft.com/library/windows/apps/hh702399) メソッドを使ってハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="3b887-211">This technique uses the [**AddHandler**](https://msdn.microsoft.com/library/windows/apps/hh702399) method to register a handler, rather than using XAML attributes or language-specific syntax for adding handlers, such as += in C\#.</span></span>

<span data-ttu-id="3b887-212">一般的に、この方法には、**AddHandler** API が [**RoutedEvent**](https://msdn.microsoft.com/library/windows/apps/br208808) 型のパラメーターを受け取るという制限があります。このパラメーターで対象のルーティング イベントを識別します。</span><span class="sxs-lookup"><span data-stu-id="3b887-212">A general limitation of this technique is that the **AddHandler** API takes a parameter of type [**RoutedEvent**](https://msdn.microsoft.com/library/windows/apps/br208808) idnentifying the routed event in question.</span></span> <span data-ttu-id="3b887-213">一部のルーティング イベントには **RoutedEvent** 識別子がないため、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) の状態でも処理できるルーティング イベントを識別する場合に考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-213">Not all routed events provide a **RoutedEvent** identifier, and this consideration thus affects which routed events can still be handled in the [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) case.</span></span> <span data-ttu-id="3b887-214">[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) の [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントには、ルーティング イベント識別子 ([**KeyDownEvent**](https://msdn.microsoft.com/library/windows/apps/hh702416) と [**KeyUpEvent**](https://msdn.microsoft.com/library/windows/apps/hh702418)) があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-214">The [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events have routed event identifiers ([**KeyDownEvent**](https://msdn.microsoft.com/library/windows/apps/hh702416) and [**KeyUpEvent**](https://msdn.microsoft.com/library/windows/apps/hh702418)) on [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911).</span></span> <span data-ttu-id="3b887-215">これに対し、[**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) などのイベントにはルーティング イベント識別子がないため、**AddHandler** を使う手法には利用できません。</span><span class="sxs-lookup"><span data-stu-id="3b887-215">However, other events such as [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) do not have routed event identifiers and thus cannot be used with the **AddHandler** technique.</span></span>

### <a name="overriding-keyboard-events-and-behavior"></a><span data-ttu-id="3b887-216">キーボード イベントと動作のオーバーライド</span><span class="sxs-lookup"><span data-stu-id="3b887-216">Overriding keyboard events and behavior</span></span>

<span data-ttu-id="3b887-217">特定のコントロールのキー イベント (たとえば [**GridView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridView) など) をオーバーライドして、キーボードとゲームパッドを含むさまざまな入力デバイスに一貫したフォーカス ナビゲーションを提供できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-217">You can override key events for specific controls (such as [**GridView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.GridView)) to provide consistent focus navigation for various input devices, including keyboard and gamepad.</span></span>

<span data-ttu-id="3b887-218">次の例では GridView にフォーカスを移動 KeyDown 動作をオーバーライドし、コントロールをサブクラス化コンテンツのいずれかの方向キーが押されたとき。</span><span class="sxs-lookup"><span data-stu-id="3b887-218">In the following example, we subclass the control and override the KeyDown behavior to move focus to the GridView content when any arrow key is pressed.</span></span>

```csharp
public class CustomGridView : GridView
  {
    protected override void OnKeyDown(KeyRoutedEventArgs e)
    {
      // Override arrow key behaviors.
      if (e.Key != Windows.System.VirtualKey.Left && e.Key !=
        Windows.System.VirtualKey.Right && e.Key !=
          Windows.System.VirtualKey.Down && e.Key !=
            Windows.System.VirtualKey.Up)
              base.OnKeyDown(e);
      else
        FocusManager.TryMoveFocus(FocusNavigationDirection.Down);
    }
  }
```

> [!NOTE]
> <span data-ttu-id="3b887-219">GridView がレイアウトのみに使用されている場合には、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsControl) と [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsWrapGrid) などの、他のコントロールの使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="3b887-219">If using a GridView for layout only, consider using other controls such as [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsControl) with [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.ItemsWrapGrid).</span></span>

## <a name="commanding"></a><span data-ttu-id="3b887-220">コマンド実行</span><span class="sxs-lookup"><span data-stu-id="3b887-220">Commanding</span></span>

<span data-ttu-id="3b887-221">ごく一部の UI 要素では、コマンド実行が組み込みでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="3b887-221">A small number of UI elements provide built-in support for commanding.</span></span> <span data-ttu-id="3b887-222">コマンド実行の基になる実装では、入力に関連するルーティング イベントを使います。</span><span class="sxs-lookup"><span data-stu-id="3b887-222">Commanding uses input-related routed events in its underlying implementation.</span></span> <span data-ttu-id="3b887-223">この方法では、1 つのコマンド ハンドラーを呼び出して、特定のポインター操作、特定のショートカット キーなどの関連する UI 入力を処理できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-223">It enables processing of related UI input, such as a certain pointer action or a specific accelerator key, by invoking a single command handler.</span></span>

<span data-ttu-id="3b887-224">UI 要素でコマンド実行を使うことができる場合は、個々の入力イベントではなく、コマンド実行 API を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="3b887-224">If commanding is available for a UI element, consider using its commanding APIs instead of any discrete input events.</span></span> <span data-ttu-id="3b887-225">詳しくは、「[**ButtonBase.Command**](https://msdn.microsoft.com/library/windows/apps/br227740)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-225">For more info, see [**ButtonBase.Command**](https://msdn.microsoft.com/library/windows/apps/br227740).</span></span>

<span data-ttu-id="3b887-226">[**ICommand**](https://msdn.microsoft.com/library/windows/apps/br227885) を実装して、通常のイベント ハンドラーから呼び出すコマンド機能をカプセル化することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-226">You can also implement [**ICommand**](https://msdn.microsoft.com/library/windows/apps/br227885) to encapsulate command functionality that you invoke from ordinary event handlers.</span></span> <span data-ttu-id="3b887-227">この方法では、**Command** プロパティを利用できない場合でも、コマンド実行を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-227">This enables you to use commanding even when there is no **Command** property available.</span></span>

## <a name="text-input-and-controls"></a><span data-ttu-id="3b887-228">テキスト入力とコントロール</span><span class="sxs-lookup"><span data-stu-id="3b887-228">Text input and controls</span></span>

<span data-ttu-id="3b887-229">キーボード イベントに固有の処理で対応するコントロールもあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-229">Certain controls react to keyboard events with their own handling.</span></span> <span data-ttu-id="3b887-230">たとえば、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) は、キーボードを使って入力されたテキストをキャプチャし、表示するためのコントロールです。</span><span class="sxs-lookup"><span data-stu-id="3b887-230">For instance, [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) is a control that is designed to capture and then visually represent text that was entered by using the keyboard.</span></span> <span data-ttu-id="3b887-231">このコントロールでは、キーボード操作をキャプチャするために、固有のロジックで [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) と [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) が使われます。また、テキストが実際に変化した場合には、固有の [**TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) イベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="3b887-231">It uses [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) and [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) in its own logic to capture keystrokes, then also raises its own [**TextChanged**](https://msdn.microsoft.com/library/windows/apps/br209706) event if the text actually changed.</span></span>

<span data-ttu-id="3b887-232">また、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) などのテキスト入力の処理を目的としたコントロールに、[**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) や [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) のハンドラーを追加することも通常どおりできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-232">You can still generally add handlers for [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) and [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) to a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683), or any related control that is intended to process text input.</span></span> <span data-ttu-id="3b887-233">ただし、コントロールは、その設計上、キー イベントを通じて伝達されたすべてのキー値に応答するわけではありません。</span><span class="sxs-lookup"><span data-stu-id="3b887-233">However, as part of its intended design, a control might not respond to all key values that are directed to it through key events.</span></span> <span data-ttu-id="3b887-234">動作はコントロールによって異なります。</span><span class="sxs-lookup"><span data-stu-id="3b887-234">Behavior is specific to each control.</span></span>

<span data-ttu-id="3b887-235">たとえば、[**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736) ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) の基底クラス) では、Space キーや Enter キーの操作を確認するために [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) が処理されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-235">As an example, [**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736) (the base class for [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)) processes [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) so that it can check for the Spacebar or Enter key.</span></span> <span data-ttu-id="3b887-236">**ButtonBase** では **KeyUp** を、[**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントを発生させるマウスの左ボタンを押す操作と同等と見なします。</span><span class="sxs-lookup"><span data-stu-id="3b887-236">**ButtonBase** considers **KeyUp** equivalent to a mouse left button down for purposes of raising a [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) event.</span></span> <span data-ttu-id="3b887-237">このイベント処理は、**ButtonBase** が仮想メソッド [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドする際に実現されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-237">This processing of the event is accomplished when **ButtonBase** overrides the virtual method [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983).</span></span> <span data-ttu-id="3b887-238">この実装では、[**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) が **true** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-238">In its implementation, it sets [**Handled**](https://msdn.microsoft.com/library/windows/apps/hh943073) to **true**.</span></span> <span data-ttu-id="3b887-239">このため、あるボタンの親がキー イベント (たとえば Space バー) をリッスンしていても、既に処理されたイベントをハンドラーで受け取ることはありません。</span><span class="sxs-lookup"><span data-stu-id="3b887-239">The result is that any parent of a button that is listening for a key event, in the case of a Spacebar, would not receive the already-handled event for its own handlers.</span></span>

<span data-ttu-id="3b887-240">別の例としては、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-240">Another example is [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683).</span></span> <span data-ttu-id="3b887-241">方向キーなどの一部のキーは **TextBox** ではテキストと見なされず、コントロール UI 動作に固有のキーと見なされます。</span><span class="sxs-lookup"><span data-stu-id="3b887-241">Some keys, such as the ARROW keys, are not considered text by **TextBox** and are instead considered specific to the control UI behavior.</span></span> <span data-ttu-id="3b887-242">**TextBox** は、これらのイベント ケースを処理済みとしてマークします。</span><span class="sxs-lookup"><span data-stu-id="3b887-242">The **TextBox** marks these event cases as handled.</span></span>

<span data-ttu-id="3b887-243">カスタム コントロールで [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) / [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983) をオーバーライドすると、キー イベントに対する同様のオーバーライド動作を独自に実装できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-243">Custom controls can implement their own similar override behavior for key events by overriding [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982) / [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983).</span></span> <span data-ttu-id="3b887-244">カスタム コントロールで特定のショートカット キーを処理する場合、または [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の説明で示したシナリオのようなコントロールの動作またはフォーカスの動作を使う場合、**OnKeyDown** / **OnKeyUp** のオーバーライドにこのロジックを組み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b887-244">If your custom control processes specific accelerator keys, or has control or focus behavior that is similar to the scenario described for [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683), you should place this logic in your own **OnKeyDown** / **OnKeyUp** overrides.</span></span>

## <a name="the-touch-keyboard"></a><span data-ttu-id="3b887-245">タッチ キーボード</span><span class="sxs-lookup"><span data-stu-id="3b887-245">The touch keyboard</span></span>

<span data-ttu-id="3b887-246">テキスト入力コントロールでは、タッチ キーボードが自動的にサポートされます。</span><span class="sxs-lookup"><span data-stu-id="3b887-246">Text input controls provide automatic support for the touch keyboard.</span></span> <span data-ttu-id="3b887-247">ユーザーがタッチ入力を使って、テキスト コントロールに入力フォーカスを設定すると、タッチ キーボードが自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-247">When the user sets the input focus to a text control by using touch input, the touch keyboard appears automatically.</span></span> <span data-ttu-id="3b887-248">入力フォーカスがテキスト コントロールにないときには、タッチ キーボードが表示されません。</span><span class="sxs-lookup"><span data-stu-id="3b887-248">When the input focus is not on a text control, the touch keyboard is hidden.</span></span>

<span data-ttu-id="3b887-249">タッチ キーボードが表示されると、フォーカスがある要素をユーザーが見ることができるように、UI が自動的に再配置されます。</span><span class="sxs-lookup"><span data-stu-id="3b887-249">When the touch keyboard appears, it automatically repositions your UI to ensure that the focused element remains visible.</span></span> <span data-ttu-id="3b887-250">この場合、他の重要な UI 領域が画面の表示領域外に移動することがあります。</span><span class="sxs-lookup"><span data-stu-id="3b887-250">This can cause other important areas of your UI to move off screen.</span></span> <span data-ttu-id="3b887-251">ただし、タッチ キーボードが表示されたときの既定の動作を無効にして、独自に UI を調整することができます。</span><span class="sxs-lookup"><span data-stu-id="3b887-251">However, you can disable the default behavior and make your own UI adjustments when the touch keyboard appears.</span></span> <span data-ttu-id="3b887-252">詳しくは、[タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-252">For more info, see the [Touch keyboard sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard).</span></span>

<span data-ttu-id="3b887-253">テキスト入力を必要とするカスタム コントロールを、標準のテキスト入力コントロールからの派生コントロールとして作成しない場合は、適切な UI オートメーション コントロール パターンを実装してタッチ キーボードを追加し、サポートできます。</span><span class="sxs-lookup"><span data-stu-id="3b887-253">If you create a custom control that requires text input, but does not derive from a standard text input control, you can add touch keyboard support by implementing the correct UI Automation control patterns.</span></span> <span data-ttu-id="3b887-254">詳しくは、[タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-254">For more info, see the [Touch keyboard sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard).</span></span>

<span data-ttu-id="3b887-255">タッチ キーボードのキーが押されると、ハードウェア キーボードのキーが押されたときと同様に、[**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) イベントと [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3b887-255">Key presses on the touch keyboard raise [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/br208941) and [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/br208942) events just like key presses on hardware keyboards.</span></span> <span data-ttu-id="3b887-256">ただし、タッチ キーボードでは、Ctrl + A、Ctrl + Z、Ctrl + X、Ctrl + C、Ctrl + V に対応する入力イベントは発生しません。これらは、入力コントロールでテキストを操作するために予約されています。</span><span class="sxs-lookup"><span data-stu-id="3b887-256">However, the touch keyboard will not raise input events for Ctrl+A, Ctrl+Z, Ctrl+X, Ctrl+C, and Ctrl+V, which are reserved for text manipulation in the input control.</span></span>

<span data-ttu-id="3b887-257">ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。</span><span class="sxs-lookup"><span data-stu-id="3b887-257">You can make it much faster and easier for users to enter data in your app by setting the input scope of the text control to match the kind of data you expect the user to enter.</span></span> <span data-ttu-id="3b887-258">入力値の種類は、コントロールが予期しているテキスト入力の種類のヒントとなるため、システムが、その入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-258">The input scope provides a hint at the type of text input expected by the control so the system can provide a specialized touch keyboard layout for the input type.</span></span> <span data-ttu-id="3b887-259">たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) プロパティを [**Number**](https://msdn.microsoft.com/library/windows/apps/hh702028) に設定します。</span><span class="sxs-lookup"><span data-stu-id="3b887-259">For example, if a text box is used only to enter a 4-digit PIN, set the [**InputScope**](https://msdn.microsoft.com/library/windows/apps/hh702632) property to [**Number**](https://msdn.microsoft.com/library/windows/apps/hh702028).</span></span> <span data-ttu-id="3b887-260">これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。</span><span class="sxs-lookup"><span data-stu-id="3b887-260">This tells the system to show the numeric keypad layout, which makes it easier for the user to enter the PIN.</span></span> <span data-ttu-id="3b887-261">詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3b887-261">For more detail, see [Use input scope to change the touch keyboard](https://msdn.microsoft.com/library/windows/apps/mt280229).</span></span>

## <a name="related-articles"></a><span data-ttu-id="3b887-262">関連記事</span><span class="sxs-lookup"><span data-stu-id="3b887-262">Related articles</span></span>

**<span data-ttu-id="3b887-263">開発者向け</span><span class="sxs-lookup"><span data-stu-id="3b887-263">Developers</span></span>**
* [<span data-ttu-id="3b887-264">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="3b887-264">Keyboard interactions</span></span>](keyboard-interactions.md)
* [<span data-ttu-id="3b887-265">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="3b887-265">Identify input devices</span></span>](identify-input-devices.md)
* [<span data-ttu-id="3b887-266">タッチ キーボードの表示への応答</span><span class="sxs-lookup"><span data-stu-id="3b887-266">Respond to the presence of the touch keyboard</span></span>](respond-to-the-presence-of-the-touch-keyboard.md)

**<span data-ttu-id="3b887-267">デザイナー向け</span><span class="sxs-lookup"><span data-stu-id="3b887-267">Designers</span></span>**
* [<span data-ttu-id="3b887-268">キーボードの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="3b887-268">Keyboard design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/hh972345)

**<span data-ttu-id="3b887-269">サンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-269">Samples</span></span>**
* [<span data-ttu-id="3b887-270">タッチ キーボードのサンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-270">Touch keyboard sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)
* [<span data-ttu-id="3b887-271">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-271">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="3b887-272">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-272">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="3b887-273">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-273">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="3b887-274">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="3b887-274">Archive Samples</span></span>**
* [<span data-ttu-id="3b887-275">入力サンプル</span><span class="sxs-lookup"><span data-stu-id="3b887-275">Input sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="3b887-276">入力: デバイス機能のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="3b887-276">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="3b887-277">入力: タッチ キーボードのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="3b887-277">Input: Touch keyboard sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=246019)
* [<span data-ttu-id="3b887-278">スクリーン キーボードを表示したときの対応のサンプルのページ</span><span class="sxs-lookup"><span data-stu-id="3b887-278">Responding to the appearance of the on-screen keyboard sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231633)
* [<span data-ttu-id="3b887-279">XAML テキスト編集のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="3b887-279">XAML text editing sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=251417)
 

 
