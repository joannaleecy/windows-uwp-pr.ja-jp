---
Description: Receive, process, and manage input data from pointing devices such as touch, mouse, pen/stylus, and touchpad, in your Universal Windows Platform (UWP) applications.
title: ポインター入力の処理
ms.assetid: BDBC9E33-4037-4671-9596-471DCF855C82
label: Handle pointer input
template: detail.hbs
keywords: ペン, マウス, タッチパッド, タッチ, ポインター, 入力, ユーザー操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f1030e6cddf5a0ded289545de752d926789314ed
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8344091"
---
# <a name="handle-pointer-input"></a><span data-ttu-id="b64af-103">ポインター入力の処理</span><span class="sxs-lookup"><span data-stu-id="b64af-103">Handle pointer input</span></span>

<span data-ttu-id="b64af-104">ユニバーサル Windows プラットフォーム (UWP) アプリケーションで、ポインティング デバイス (タッチ、マウス、ペン/スタイラス、タッチパッドなど) からの入力データを受け取り、処理、管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-104">Receive, process, and manage input data from pointing devices (such as touch, mouse, pen/stylus, and touchpad) in your Universal Windows Platform (UWP) applications.</span></span>

> [!Important]
> <span data-ttu-id="b64af-105">明確で適切に定義された要件があり、プラットフォーム コントロールが対応している操作ではシナリオがサポートされない場合にのみ、カスタムの操作を作成してください。</span><span class="sxs-lookup"><span data-stu-id="b64af-105">Create custom interactions only if there is a clear, well-defined requirement and the interactions supported by the platform controls don't support your scenario.</span></span>  
> <span data-ttu-id="b64af-106">Windows アプリケーションでの操作エクスペリエンスをカスタマイズすると、ユーザーは、それらのエクスペリエンスは一貫性があり、直感的で、見つけやすいものであることを期待します。</span><span class="sxs-lookup"><span data-stu-id="b64af-106">If you customize the interaction experiences in your Windows application, users expect them to be consistent, intuitive, and discoverable.</span></span> <span data-ttu-id="b64af-107">このため、カスタム操作は[プラットフォーム コントロール](../controls-and-patterns/controls-by-function.md)でサポートされている操作に基づいて作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b64af-107">For these reasons, we recommend that you model your custom interactions on those supported by the [platform controls](../controls-and-patterns/controls-by-function.md).</span></span> <span data-ttu-id="b64af-108">プラットフォーム コントロールには、標準的な操作、アニメーション化された物理的効果、視覚的フィードバック、アクセシビリティなど、ユニバーサル Windows プラットフォーム (UWP) の完全なユーザー操作エクスペリエンスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="b64af-108">The platform controls provide the full Universal Windows Platform (UWP) user interaction experience, including standard interactions, animated physics effects, visual feedback, and accessibility.</span></span> 

## <a name="important-apis"></a><span data-ttu-id="b64af-109">重要な API</span><span class="sxs-lookup"><span data-stu-id="b64af-109">Important APIs</span></span>
- [<span data-ttu-id="b64af-110">Windows.Devices.Input</span><span class="sxs-lookup"><span data-stu-id="b64af-110">Windows.Devices.Input</span></span>](https://msdn.microsoft.com/library/windows/apps/br225648)
- [<span data-ttu-id="b64af-111">Windows.UI.Input</span><span class="sxs-lookup"><span data-stu-id="b64af-111">Windows.UI.Input</span></span>](https://msdn.microsoft.com/library/windows/apps/br208383)
- [<span data-ttu-id="b64af-112">Windows.UI.Xaml.Input</span><span class="sxs-lookup"><span data-stu-id="b64af-112">Windows.UI.Xaml.Input</span></span>](https://msdn.microsoft.com/library/windows/apps/br242084)

## <a name="pointers"></a><span data-ttu-id="b64af-113">ポインター</span><span class="sxs-lookup"><span data-stu-id="b64af-113">Pointers</span></span>
<span data-ttu-id="b64af-114">ほとんどの操作エクスペリエンスでは、通常ユーザーが、タッチ、マウス、ペン/スタイラス、タッチパッドなどの入力デバイスを使ってポイントすることによって、操作の対象となるオブジェクトを特定します。</span><span class="sxs-lookup"><span data-stu-id="b64af-114">Most interaction experiences typically involve the user identifying the object they want to interact with by pointing at it through input devices such as touch, mouse, pen/stylus, and touchpad.</span></span> <span data-ttu-id="b64af-115">これらの入力デバイスによって提供される生のヒューマン インターフェイス デバイス (HID) のデータには、多くの共通するプロパティが含まれているため、データは統合入力スタックに昇格および集約され、デバイスに依存しないポインター データとして公開されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-115">Because the raw Human Interface Device (HID) data provided by these input devices includes many common properties, the data is promoted and consolidated into a unified input stack and exposed as device-agnostic pointer data.</span></span> <span data-ttu-id="b64af-116">このため、UWP アプリケーションでは、使われている入力デバイスを意識することなく、このデータを利用できます。</span><span class="sxs-lookup"><span data-stu-id="b64af-116">Your UWP applications can then consume this data without worrying about the input device being used.</span></span>

> [!NOTE]
> <span data-ttu-id="b64af-117">アプリで必要な場合は、デバイス固有の情報も HID の生データから昇格されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-117">Device-specific info is also promoted from the raw HID data should your app require it.</span></span>
 

<span data-ttu-id="b64af-118">入力スタックの各入力ポイント (または接触) は、さまざまなポインター イベント ハンドラーの [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) パラメーターによって公開される [**Pointer**](https://msdn.microsoft.com/library/windows/apps/br227968) オブジェクトで表されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-118">Each input point (or contact) on the input stack is represented by a [**Pointer**](https://msdn.microsoft.com/library/windows/apps/br227968) object exposed through the [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) parameter in the various pointer event handlers.</span></span> <span data-ttu-id="b64af-119">マルチペンまたはマルチタッチ入力の場合、各接触は固有の入力ポインターとして扱われます。</span><span class="sxs-lookup"><span data-stu-id="b64af-119">In the case of multi-pen or multi-touch input, each contact is treated as a unique input pointer.</span></span>

## <a name="pointer-events"></a><span data-ttu-id="b64af-120">ポインター イベント</span><span class="sxs-lookup"><span data-stu-id="b64af-120">Pointer events</span></span>


<span data-ttu-id="b64af-121">ポインター イベントは、入力デバイスの種類や (範囲または接触の) 検出状態などの基本情報、および位置、圧力、接触形状などの拡張情報を公開します。</span><span class="sxs-lookup"><span data-stu-id="b64af-121">Pointer events expose basic info such as input device type and detection state (in range or in contact), and extended info such as location, pressure, and contact geometry.</span></span> <span data-ttu-id="b64af-122">さらに、ユーザーが押したマウス ボタンは何か、ペンの消しゴム ボタンは使われているかなど、特定のデバイスのプロパティも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b64af-122">In addition, specific device properties such as which mouse button a user pressed or whether the pen eraser tip is being used are also available.</span></span> <span data-ttu-id="b64af-123">アプリで入力デバイスとその機能を区別する必要がある場合は、「[入力デバイスの識別](identify-input-devices.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b64af-123">If your app needs to differentiate between input devices and their capabilities, see [Identify input devices](identify-input-devices.md).</span></span>

<span data-ttu-id="b64af-124">UWP アプリでは、次のポインター イベントをリッスンすることができます。</span><span class="sxs-lookup"><span data-stu-id="b64af-124">UWP apps can listen for the following pointer events:</span></span>

> [!NOTE]
> <span data-ttu-id="b64af-125">ポインターの入力を特定の UI 要素に制限するには、ポインター イベント ハンドラー内で、その要素に対して [**CapturePointer**](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b64af-125">Constrain pointer input to a specific UI element by calling  [**CapturePointer**](https://msdn.microsoft.com/library/windows/apps/br208918) on that element within a pointer event handler.</span></span> <span data-ttu-id="b64af-126">要素によってポインターがキャプチャされると、そのオブジェクトだけがポインター入力イベントを受け取ります。これは、ポインターがオブジェクトの境界領域の外部に移動した場合でも同様です。</span><span class="sxs-lookup"><span data-stu-id="b64af-126">When a pointer is captured by an element, only that object receives pointer input events, even when the pointer moves outside the bounding area of the object.</span></span> <span data-ttu-id="b64af-127">**CapturePointer** が成功するには、[**IsInContact**](https://msdn.microsoft.com/library/windows/apps/br227976) (マウス ボタンの押下、タッチやスタイラスの接触) が true であることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b64af-127">The [**IsInContact**](https://msdn.microsoft.com/library/windows/apps/br227976) (mouse button pressed, touch or stylus in contact) must be true for **CapturePointer** to be successful.</span></span>
 

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="b64af-128">イベント</span><span class="sxs-lookup"><span data-stu-id="b64af-128">Event</span></span></th>
<th align="left"><span data-ttu-id="b64af-129">説明</span><span class="sxs-lookup"><span data-stu-id="b64af-129">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208964"><strong><span data-ttu-id="b64af-130">PointerCanceled</span><span class="sxs-lookup"><span data-stu-id="b64af-130">PointerCanceled</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-131">プラットフォームでポインターが取り消されると発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-131">Occurs when a pointer is canceled by the platform.</span></span> <span data-ttu-id="b64af-132">これは、次のような場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="b64af-132">This can occur in the following circumstances:</span></span></p>
<ul>
<li><span data-ttu-id="b64af-133">入力サーフェスの範囲内でペンが検出されると、タッチ ポインターは取り消されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-133">Touch pointers are canceled when a pen is detected within range of the input surface.</span></span></li>
<li><span data-ttu-id="b64af-134">100 ミリ秒を超えてもアクティブな接触が検出されません。</span><span class="sxs-lookup"><span data-stu-id="b64af-134">An active contact is not detected for more than 100 ms.</span></span></li>
<li><span data-ttu-id="b64af-135">モニター/ディスプレイが変更されました (解像度、設定、マルチモニター構成)。</span><span class="sxs-lookup"><span data-stu-id="b64af-135">Monitor/display is changed (resolution, settings, multi-mon configuration).</span></span></li>
<li><span data-ttu-id="b64af-136">デスクトップがロックされているか、ユーザーがログオフしました。</span><span class="sxs-lookup"><span data-stu-id="b64af-136">The desktop is locked or the user has logged off.</span></span></li>
<li><span data-ttu-id="b64af-137">同時に接触した数がデバイスでサポートされる数を超えています。</span><span class="sxs-lookup"><span data-stu-id="b64af-137">The number of simultaneous contacts exceeded the number supported by the device.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208965"><strong><span data-ttu-id="b64af-138">PointerCaptureLost</span><span class="sxs-lookup"><span data-stu-id="b64af-138">PointerCaptureLost</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-139">別の UI 要素がポインターをキャプチャしたか、ポインターが離されたか、別のポインターがプログラムでキャプチャされたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-139">Occurs when another UI element captures the pointer, the pointer was released, or another pointer was programmatically captured.</span></span></p>
<div class="alert"><span data-ttu-id="b64af-140">
<strong>注:</strong>対応するポインター キャプチャ イベントはありません。</span><span class="sxs-lookup"><span data-stu-id="b64af-140">
<strong>Note</strong>There is no corresponding pointer capture event.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208968"><strong><span data-ttu-id="b64af-141">PointerEntered</span><span class="sxs-lookup"><span data-stu-id="b64af-141">PointerEntered</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-142">ポインターが要素の境界領域内に入ったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-142">Occurs when a pointer enters the bounding area of an element.</span></span> <span data-ttu-id="b64af-143">これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="b64af-143">This can happen in slightly different ways for touch, touchpad, mouse, and pen input.</span></span></p>
<ul>
<li><span data-ttu-id="b64af-144">タッチでは、このイベントが発生するには、直接タッチするか、要素の境界領域内に移動することによって、指が接触する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b64af-144">Touch requires a finger contact to fire this event, either from a direct touch down on the element or from moving into the bounding area of the element.</span></span></li>
<li><span data-ttu-id="b64af-145">マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-145">Mouse and touchpad both have an on-screen cursor that is always visible and fires this event even if no mouse or touchpad button is pressed.</span></span></li>
<li><span data-ttu-id="b64af-146">タッチと同様に、直接ペンでタッチするか、要素の境界領域内に移動することによって、このイベントが起動されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-146">Like touch, pen fires this event with a direct pen down on the element or from moving into the bounding area of the element.</span></span> <span data-ttu-id="b64af-147">ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、true の場合に、このイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-147">However, pen also has a hover state ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) that, when true, fires this event.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208969"><strong><span data-ttu-id="b64af-148">PointerExited</span><span class="sxs-lookup"><span data-stu-id="b64af-148">PointerExited</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-149">ポインターが要素の境界領域から出たときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-149">Occurs when a pointer leaves the bounding area of an element.</span></span> <span data-ttu-id="b64af-150">これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="b64af-150">This can happen in slightly different ways for touch, touchpad, mouse, and pen input.</span></span></p>
<ul>
<li><span data-ttu-id="b64af-151">タッチでは、指が接触している必要があり、ポインターが要素の境界領域から外へ移動したときにこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-151">Touch requires a finger contact and fires this event when the pointer moves out of the bounding area of the element.</span></span></li>
<li><span data-ttu-id="b64af-152">マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-152">Mouse and touchpad both have an on-screen cursor that is always visible and fires this event even if no mouse or touchpad button is pressed.</span></span></li>
<li><span data-ttu-id="b64af-153">タッチと同様に、ペンでは、要素の境界領域の外へ移動したときにこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-153">Like touch, pen fires this event when moving out of the bounding area of the element.</span></span> <span data-ttu-id="b64af-154">ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true から false に変化したときに、このイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-154">However, pen also has a hover state ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) that fires this event when the state changes from true to false.</span></span></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208970"><strong><span data-ttu-id="b64af-155">PointerMoved</span><span class="sxs-lookup"><span data-stu-id="b64af-155">PointerMoved</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-156">要素の境界領域内で、ポインターの座標、ボタンの状態、圧力、傾き、または接触形状 (たとえば、幅と高さ) が変化したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-156">Occurs when a pointer changes coordinates, button state, pressure, tilt, or contact geometry (for example, width and height) within the bounding area of an element.</span></span> <span data-ttu-id="b64af-157">これは、タッチ、タッチパッド、マウス、ペン入力で発生方法が少し異なります。</span><span class="sxs-lookup"><span data-stu-id="b64af-157">This can happen in slightly different ways for touch, touchpad, mouse, and pen input.</span></span></p>
<ul>
<li><span data-ttu-id="b64af-158">タッチでは、指が接触している必要があり、要素の境界領域内に接触した場合にのみ、このイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-158">Touch requires a finger contact and fires this event only when in contact within the bounding area of the element.</span></span></li>
<li><span data-ttu-id="b64af-159">マウスとタッチパッドでは、常に表示される画面上のカーソルがあり、マウスやタッチパッドのボタンが押されなくてもこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-159">Mouse and touchpad both have an on-screen cursor that is always visible and fires this event even if no mouse or touchpad button is pressed.</span></span></li>
<li><span data-ttu-id="b64af-160">タッチと同様に、ペンでは、要素の境界領域内に接触したときにこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-160">Like touch, pen fires this event when in contact within the bounding area of the element.</span></span> <span data-ttu-id="b64af-161">ただし、ペンにはホバー状態 ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) もあり、状態が true で、要素の境界領域内にあるときに、このイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-161">However, pen also has a hover state ([IsInRange](https://msdn.microsoft.com/library/windows/apps/br227977)) that, when true and within the bounding area of the element, fires this event.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208971"><strong><span data-ttu-id="b64af-162">PointerPressed</span><span class="sxs-lookup"><span data-stu-id="b64af-162">PointerPressed</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-163">要素の境界領域内でポインターを押すアクション (タッチして押す、マウス ボタンを押す、ペンで押す、タッチパッドのボタンを押すなど) を行うと発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-163">Occurs when the pointer indicates a press action (such as a touch down, mouse button down, pen down, or touchpad button down) within the bounding area of an element.</span></span></p>
<p><span data-ttu-id="b64af-164">このイベントのハンドラーから [CapturePointer](https://msdn.microsoft.com/library/windows/apps/br208918) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="b64af-164">[CapturePointer](https://msdn.microsoft.com/library/windows/apps/br208918) must be called from the handler for this event.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208972"><strong><span data-ttu-id="b64af-165">PointerReleased</span><span class="sxs-lookup"><span data-stu-id="b64af-165">PointerReleased</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-166">要素の境界領域内でポインターを離すアクション (タッチを離す、マウス ボタンを離す、ペンを離す、タッチパッドのボタンを離すなど) を行ったとき、またはポインターが境界領域の外部でキャプチャされた場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-166">Occurs when the pointer indicates a release action (such as a touch up, mouse button up, pen up, or touchpad button up) within the bounding area of an element or, if the pointer is captured, outside the bounding area.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="https://msdn.microsoft.com/library/windows/apps/br208973"><strong><span data-ttu-id="b64af-167">PointerWheelChanged</span><span class="sxs-lookup"><span data-stu-id="b64af-167">PointerWheelChanged</span></span></strong></a></p></td>
<td align="left"><p><span data-ttu-id="b64af-168">マウス ホイールが回転したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="b64af-168">Occurs when the mouse wheel is rotated.</span></span></p>
<p><span data-ttu-id="b64af-169">マウス入力が最初に検出されたときに、マウス入力が、割り当てられている単一のポインターと関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="b64af-169">Mouse input is associated with a single pointer assigned when mouse input is first detected.</span></span> <span data-ttu-id="b64af-170">マウス ボタン (左ボタン、ホイール、または右ボタン) をクリックすると、[PointerMoved](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってポインターとそのボタンの間に 2 番目の関連付けが行われます。</span><span class="sxs-lookup"><span data-stu-id="b64af-170">Clicking a mouse button (left, wheel, or right) creates a secondary association between the pointer and that button through the [PointerMoved](https://msdn.microsoft.com/library/windows/apps/br208970) event.</span></span></p></td>
</tr>
</tbody>
</table> 

## <a name="pointer-event-example"></a><span data-ttu-id="b64af-171">ポインター イベントの例</span><span class="sxs-lookup"><span data-stu-id="b64af-171">Pointer event example</span></span>

<span data-ttu-id="b64af-172">ここでは、基本的なポインター追跡アプリのコード スニペットを示し、複数のポインター イベントをリッスンして処理し、関連付けられたポインターのさまざまなプロパティを取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b64af-172">Here are some code snippets from a basic pointer tracking app that show how to listen for and handle events for multiple pointers, and get various properties for the associated pointers.</span></span>

![ポインター アプリケーションの UI](images/pointers/pointers1.gif)

**<span data-ttu-id="b64af-174">このサンプルは、「[Pointer input sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers.zip)」(ポインター入力のサンプル (基本)) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="b64af-174">Download this sample from [Pointer input sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers.zip)</span></span>**

### <a name="create-the-ui"></a><span data-ttu-id="b64af-175">UI を作成する</span><span class="sxs-lookup"><span data-stu-id="b64af-175">Create the UI</span></span>

<span data-ttu-id="b64af-176">この例では、ポインター入力を利用するオブジェクトとして [Rectangle](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.shapes.rectangle) (`Target`) を使います。</span><span class="sxs-lookup"><span data-stu-id="b64af-176">For this example, we use a [Rectangle](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.shapes.rectangle) (`Target`) as the object consuming pointer input.</span></span> <span data-ttu-id="b64af-177">ポインターの状態が変わると、ターゲットの色が変わります。</span><span class="sxs-lookup"><span data-stu-id="b64af-177">The color of the target changes when the pointer status changes.</span></span>

<span data-ttu-id="b64af-178">ポインターの移動に従って動く浮動の [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) に、各ポインターの詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-178">Details for each pointer are displayed in a floating [TextBlock](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBlock) that follows the pointer as it moves.</span></span> <span data-ttu-id="b64af-179">ポインター イベント自体は、四角形の右側にある [RichTextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichTextBlock) で報告されます。</span><span class="sxs-lookup"><span data-stu-id="b64af-179">The pointer events themselves are reported in the [RichTextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichTextBlock) to the right of the rectangle.</span></span>

<span data-ttu-id="b64af-180">この例の UI で使われる Extensible Application Markup Language (XAML) を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-180">This is the Extensible Application Markup Language (XAML) for the UI in this example.</span></span> 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="250"/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="320" />
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Canvas Name="Container" 
            Grid.Column="0"
            Grid.Row="1"
            HorizontalAlignment="Center" 
            VerticalAlignment="Center" 
            Margin="245,0" 
            Height="320"  Width="640">
        <Rectangle Name="Target" 
                    Fill="#FF0000" 
                    Stroke="Black" 
                    StrokeThickness="0"
                    Height="320" Width="640" />
    </Canvas>
    <Grid Grid.Column="1" Grid.Row="0" Grid.RowSpan="3">
        <Grid.RowDefinitions>
            <RowDefinition Height="50" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Button Name="buttonClear" 
                Grid.Row="0"
                Content="Clear"
                Foreground="White"
                HorizontalAlignment="Stretch" 
                VerticalAlignment="Stretch">
        </Button>
        <ScrollViewer Name="eventLogScrollViewer" Grid.Row="1" 
                        VerticalScrollMode="Auto" 
                        Background="Black">                
            <RichTextBlock Name="eventLog"  
                        TextWrapping="Wrap" 
                        Foreground="#FFFFFF" 
                        ScrollViewer.VerticalScrollBarVisibility="Visible" 
                        ScrollViewer.HorizontalScrollBarVisibility="Disabled"
                        Grid.ColumnSpan="2">
            </RichTextBlock>
        </ScrollViewer>
    </Grid>
</Grid>
```

### <a name="listen-for-pointer-events"></a><span data-ttu-id="b64af-181">ポインター イベントをリッスンする</span><span class="sxs-lookup"><span data-stu-id="b64af-181">Listen for pointer events</span></span>

<span data-ttu-id="b64af-182">ほとんどの場合は、イベント ハンドラーの [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) を介してポインター情報を取得することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b64af-182">In most cases, we recommend that you get pointer info through the [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) of the event handler.</span></span>

<span data-ttu-id="b64af-183">必要なポインターの詳細をイベント引数が公開していない場合は、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) メソッドと [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドによって公開される拡張 [**PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) 情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="b64af-183">If the event argument doesn't expose the pointer details required, you can get access to extended [**PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) info exposed through the [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) and [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) methods of [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076).</span></span>

<span data-ttu-id="b64af-184">次のコードでは、アクティブな各ポインターを追跡するためのグローバル ディクショナリ オブジェクトを設定し、ターゲット オブジェクトのさまざまなポインター イベント リスナーを識別しています。</span><span class="sxs-lookup"><span data-stu-id="b64af-184">The following code sets up the global dictionary object for tracking each active pointer, and identifies the various pointer event listeners for the target object.</span></span>

```CSharp
// Dictionary to maintain information about each active pointer. 
// An entry is added during PointerPressed/PointerEntered events and removed 
// during PointerReleased/PointerCaptureLost/PointerCanceled/PointerExited events.
Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;

public MainPage()
{
    this.InitializeComponent();

    // Initialize the dictionary.
    pointers = new Dictionary<uint, Windows.UI.Xaml.Input.Pointer>();

    // Declare the pointer event handlers.
    Target.PointerPressed += 
        new PointerEventHandler(Target_PointerPressed);
    Target.PointerEntered += 
        new PointerEventHandler(Target_PointerEntered);
    Target.PointerReleased += 
        new PointerEventHandler(Target_PointerReleased);
    Target.PointerExited += 
        new PointerEventHandler(Target_PointerExited);
    Target.PointerCanceled += 
        new PointerEventHandler(Target_PointerCanceled);
    Target.PointerCaptureLost += 
        new PointerEventHandler(Target_PointerCaptureLost);
    Target.PointerMoved += 
        new PointerEventHandler(Target_PointerMoved);
    Target.PointerWheelChanged += 
        new PointerEventHandler(Target_PointerWheelChanged);

    buttonClear.Click += 
        new RoutedEventHandler(ButtonClear_Click);
}
```

### <a name="handle-pointer-events"></a><span data-ttu-id="b64af-185">ポインター イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="b64af-185">Handle pointer events</span></span>

<span data-ttu-id="b64af-186">次に、UI フィードバックを使って基本的なポインター イベント ハンドラーを示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-186">Next, we use UI feedback to demonstrate basic pointer event handlers.</span></span>

-   <span data-ttu-id="b64af-187">このハンドラーは、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-187">This handler manages the [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) event.</span></span> <span data-ttu-id="b64af-188">イベント ログにイベントを追加し、アクティブなポインターのディクショナリにポインターを追加して、ポインターの詳細を表示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-188">We add the event to the event log, add the pointer to the active pointer dictionary, and display the pointer details.</span></span>

    > [!NOTE]
    > <span data-ttu-id="b64af-189">[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントと [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは、常にペアで発生するわけではありません。</span><span class="sxs-lookup"><span data-stu-id="b64af-189">[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) and [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) events do not always occur in pairs.</span></span> <span data-ttu-id="b64af-190">アプリでは、ポインターの押下を終了させる可能性のあるすべてのイベント ([**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969)、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964)、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) など) をリッスンして処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b64af-190">Your app should listen for and handle any event that might conclude a pointer down (such as [**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969), [**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964), and [**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965)).</span></span>      

```csharp
/// <summary>
/// The pointer pressed event handler.
/// PointerPressed and PointerReleased don't always occur in pairs. 
/// Your app should listen for and handle any event that can conclude 
/// a pointer down (PointerExited, PointerCanceled, PointerCaptureLost).
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Down: " + ptrPt.PointerId);

    // Lock the pointer to the target.
    Target.CapturePointer(e.Pointer);

    // Update event log.
    UpdateEventLog("Pointer captured: " + ptrPt.PointerId);

    // Check if pointer exists in dictionary (ie, enter occurred prior to press).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    // Change background color of target when pointer contact detected.
    Target.Fill = new SolidColorBrush(Windows.UI.Colors.Green);

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-191">このハンドラーは、[**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-191">This handler manages the [**PointerEntered**](https://msdn.microsoft.com/library/windows/apps/br208968) event.</span></span> <span data-ttu-id="b64af-192">イベント ログにイベントを追加し、ポインター コレクションにポインターを追加して、ポインターの詳細を表示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-192">We add the event to the event log, add the pointer to the pointer collection, and display the pointer details.</span></span>

```csharp
/// <summary>
/// The pointer entered event handler.
/// We do not capture the pointer on this event.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Entered: " + ptrPt.PointerId);

    // Check if pointer already exists (if enter occurred prior to down).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    if (pointers.Count == 0)
    {
        // Change background color of target when pointer contact detected.
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
    }

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-193">このハンドラーは、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-193">This handler manages the [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) event.</span></span> <span data-ttu-id="b64af-194">イベント ログにイベントを追加し、ポインターの詳細を更新します。</span><span class="sxs-lookup"><span data-stu-id="b64af-194">We add the event to the event log and update the pointer details.</span></span>

    > [!Important]
    > <span data-ttu-id="b64af-195">マウス入力が最初に検出されたときに、マウス入力が、割り当てられている単一のポインターと関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="b64af-195">Mouse input is associated with a single pointer assigned when mouse input is first detected.</span></span> <span data-ttu-id="b64af-196">マウス ボタン (左ボタン、ホイール、または右ボタン) をクリックすると、[**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) イベントによってポインターとそのボタンの間に 2 番目の関連付けが行われます。</span><span class="sxs-lookup"><span data-stu-id="b64af-196">Clicking a mouse button (left, wheel, or right) creates a secondary association between the pointer and that button through the [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/br208971) event.</span></span> <span data-ttu-id="b64af-197">[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントは、同じマウス ボタンを離したときにだけ発生します (イベントが完了するまではそのポインターに他のボタンが関連付けられることはありません)。</span><span class="sxs-lookup"><span data-stu-id="b64af-197">The [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) event is fired only when that same mouse button is released (no other button can be associated with the pointer until this event is complete).</span></span> <span data-ttu-id="b64af-198">この排他的な関連付けのために、他のマウス ボタンをクリックした場合は、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) イベントによってルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="b64af-198">Because of this exclusive association, other mouse button clicks are routed through the [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/br208970) event.</span></span>     

```csharp
/// <summary>
/// The pointer moved event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerMoved(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Multiple, simultaneous mouse button inputs are processed here.
    // Mouse input is associated with a single pointer assigned when 
    // mouse input is first detected. 
    // Clicking additional mouse buttons (left, wheel, or right) during 
    // the interaction creates secondary associations between those buttons 
    // and the pointer through the pointer pressed event. 
    // The pointer released event is fired only when the last mouse button 
    // associated with the interaction (not necessarily the initial button) 
    // is released. 
    // Because of this exclusive association, other mouse button clicks are 
    // routed through the pointer move event.          
    if (ptrPt.PointerDevice.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
    {
        if (ptrPt.Properties.IsLeftButtonPressed)
        {
            UpdateEventLog("Left button: " + ptrPt.PointerId);
        }
        if (ptrPt.Properties.IsMiddleButtonPressed)
        {
            UpdateEventLog("Wheel button: " + ptrPt.PointerId);
        }
        if (ptrPt.Properties.IsRightButtonPressed)
        {
            UpdateEventLog("Right button: " + ptrPt.PointerId);
        }
    }

    // Display pointer details.
    UpdateInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-199">このハンドラーは、[**PointerWheelChanged**](https://msdn.microsoft.com/library/windows/apps/br208973) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-199">This handler manages the [**PointerWheelChanged**](https://msdn.microsoft.com/library/windows/apps/br208973) event.</span></span> <span data-ttu-id="b64af-200">イベント ログにイベントを追加し、ポインター配列にポインターを追加して (必要な場合)、ポインターの詳細を表示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-200">We add the event to the event log, add the pointer to the pointer array (if necessary), and display the pointer details.</span></span>

```csharp
/// <summary>
/// The pointer wheel event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Mouse wheel: " + ptrPt.PointerId);

    // Check if pointer already exists (for example, enter occurred prior to wheel).
    if (!pointers.ContainsKey(ptrPt.PointerId))
    {
        // Add contact to dictionary.
        pointers[ptrPt.PointerId] = e.Pointer;
    }

    // Display pointer details.
    CreateInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-201">このハンドラーは、デジタイザーとの接触の終了を示す [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-201">This handler manages the [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) event where contact with the digitizer is terminated.</span></span> <span data-ttu-id="b64af-202">イベント ログにイベントを追加し、ポインター コレクションからポインターを削除して、ポインターの詳細を更新します。</span><span class="sxs-lookup"><span data-stu-id="b64af-202">We add the event to the event log, remove the pointer from the pointer collection, and update the pointer details.</span></span>

```csharp
/// <summary>
/// The pointer released event handler.
/// PointerPressed and PointerReleased don't always occur in pairs. 
/// Your app should listen for and handle any event that can conclude 
/// a pointer down (PointerExited, PointerCanceled, PointerCaptureLost).
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
void Target_PointerReleased(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Up: " + ptrPt.PointerId);

    // If event source is mouse or touchpad and the pointer is still 
    // over the target, retain pointer and pointer details.
    // Return without removing pointer from pointers dictionary.
    // For this example, we assume a maximum of one mouse pointer.
    if (ptrPt.PointerDevice.PointerDeviceType != Windows.Devices.Input.PointerDeviceType.Mouse)
    {
        // Update target UI.
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);

        DestroyInfoPop(ptrPt);

        // Remove contact from dictionary.
        if (pointers.ContainsKey(ptrPt.PointerId))
        {
            pointers[ptrPt.PointerId] = null;
            pointers.Remove(ptrPt.PointerId);
        }

        // Release the pointer from the target.
        Target.ReleasePointerCapture(e.Pointer);

        // Update event log.
        UpdateEventLog("Pointer released: " + ptrPt.PointerId);
    }
    else
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
    }
}
```

-   <span data-ttu-id="b64af-203">このハンドラーは、[**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969) イベントを管理します (デジタイザーとの接触を維持する場合)。</span><span class="sxs-lookup"><span data-stu-id="b64af-203">This handler manages the [**PointerExited**](https://msdn.microsoft.com/library/windows/apps/br208969) event (when contact with the digitizer is maintained).</span></span> <span data-ttu-id="b64af-204">イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。</span><span class="sxs-lookup"><span data-stu-id="b64af-204">We add the event to the event log, remove the pointer from the pointer array, and update the pointer details.</span></span>

```csharp
/// <summary>
/// The pointer exited event handler.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerExited(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer exited: " + ptrPt.PointerId);

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
    }

    // Update the UI and pointer details.
    DestroyInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-205">このハンドラーは、[**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-205">This handler manages the [**PointerCanceled**](https://msdn.microsoft.com/library/windows/apps/br208964) event.</span></span> <span data-ttu-id="b64af-206">イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。</span><span class="sxs-lookup"><span data-stu-id="b64af-206">We add the event to the event log, remove the pointer from the pointer array, and update the pointer details.</span></span>

```csharp
/// <summary>
/// The pointer canceled event handler.
/// Fires for for various reasons, including: 
///    - Touch contact canceled by pen coming into range of the surface.
///    - The device doesn't report an active contact for more than 100ms.
///    - The desktop is locked or the user logged off. 
///    - The number of simultaneous contacts exceeded the number supported by the device.
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerCanceled(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer canceled: " + ptrPt.PointerId);

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
    }

    DestroyInfoPop(ptrPt);
}
```

-   <span data-ttu-id="b64af-207">このハンドラーは、[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) イベントを管理します。</span><span class="sxs-lookup"><span data-stu-id="b64af-207">This handler manages the [**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) event.</span></span> <span data-ttu-id="b64af-208">イベント ログにイベントを追加し、ポインター配列からポインターを削除して、ポインターの詳細を更新します。</span><span class="sxs-lookup"><span data-stu-id="b64af-208">We add the event to the event log, remove the pointer from the pointer array, and update the pointer details.</span></span>

    > [!NOTE]
    > <span data-ttu-id="b64af-209">[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) が [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) の代わりに発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="b64af-209">[**PointerCaptureLost**](https://msdn.microsoft.com/library/windows/apps/br208965) can occur instead of [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972).</span></span> <span data-ttu-id="b64af-210">ポインターのキャプチャは、さまざまな理由で失われることがあります。たとえば、ユーザーの操作、プログラムによる別のポインターのキャプチャ、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972) の呼び出しなどが原因となります。</span><span class="sxs-lookup"><span data-stu-id="b64af-210">Pointer capture can be lost for various reasons including user interaction, programmatic capture of another pointer, calling [**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/br208972).</span></span>     

```csharp
/// <summary>
/// The pointer capture lost event handler.
/// Fires for various reasons, including: 
///    - User interactions
///    - Programmatic capture of another pointer
///    - Captured pointer was deliberately released
// PointerCaptureLost can fire instead of PointerReleased. 
/// </summary>
/// <param name="sender">Source of the pointer event.</param>
/// <param name="e">Event args for the pointer routed event.</param>
private void Target_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
{
    // Prevent most handlers along the event route from handling the same event again.
    e.Handled = true;

    PointerPoint ptrPt = e.GetCurrentPoint(Target);

    // Update event log.
    UpdateEventLog("Pointer capture lost: " + ptrPt.PointerId);

    if (pointers.Count == 0)
    {
        Target.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
    }

    // Remove contact from dictionary.
    if (pointers.ContainsKey(ptrPt.PointerId))
    {
        pointers[ptrPt.PointerId] = null;
        pointers.Remove(ptrPt.PointerId);
    }

    DestroyInfoPop(ptrPt);
}
```

### <a name="get-pointer-properties"></a><span data-ttu-id="b64af-211">ポインターのプロパティを取得する</span><span class="sxs-lookup"><span data-stu-id="b64af-211">Get pointer properties</span></span>

<span data-ttu-id="b64af-212">前に説明したように、ほとんどの拡張ポインター情報は、[**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076) の [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) メソッドと [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) メソッドで取得した [**Windows.UI.Input.PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) オブジェクトから取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b64af-212">As stated earlier, you must get most extended pointer info from a [**Windows.UI.Input.PointerPoint**](https://msdn.microsoft.com/library/windows/apps/br242038) object obtained through the [**GetCurrentPoint**](https://msdn.microsoft.com/library/windows/apps/hh943077) and [**GetIntermediatePoints**](https://msdn.microsoft.com/library/windows/apps/hh943078) methods of [**PointerRoutedEventArgs**](https://msdn.microsoft.com/library/windows/apps/hh943076).</span></span> <span data-ttu-id="b64af-213">次のコード スニペットでその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-213">The following code snippets show how.</span></span>

-   <span data-ttu-id="b64af-214">最初に、ポインターごとに新しい [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を作成します。</span><span class="sxs-lookup"><span data-stu-id="b64af-214">First, we create a new [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) for each pointer.</span></span>

```csharp
/// <summary>
/// Create the pointer info popup.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
void CreateInfoPop(PointerPoint ptrPt)
{
    TextBlock pointerDetails = new TextBlock();
    pointerDetails.Name = ptrPt.PointerId.ToString();
    pointerDetails.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
    pointerDetails.Text = QueryPointer(ptrPt);

    TranslateTransform x = new TranslateTransform();
    x.X = ptrPt.Position.X + 20;
    x.Y = ptrPt.Position.Y + 20;
    pointerDetails.RenderTransform = x;

    Container.Children.Add(pointerDetails);
}
```

-   <span data-ttu-id="b64af-215">次に、そのポインターと関連付けられた、既にある [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) でポインター情報を更新するための手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="b64af-215">Then we provide a way to update the pointer info in an existing [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) associated with that pointer.</span></span>

```csharp
/// <summary>
/// Update the pointer info popup.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
void UpdateInfoPop(PointerPoint ptrPt)
{
    foreach (var pointerDetails in Container.Children)
    {
        if (pointerDetails.GetType().ToString() == "Windows.UI.Xaml.Controls.TextBlock")
        {
            TextBlock textBlock = (TextBlock)pointerDetails;
            if (textBlock.Name == ptrPt.PointerId.ToString())
            {
                // To get pointer location details, we need extended pointer info.
                // We get the pointer info through the getCurrentPoint method
                // of the event argument. 
                TranslateTransform x = new TranslateTransform();
                x.X = ptrPt.Position.X + 20;
                x.Y = ptrPt.Position.Y + 20;
                pointerDetails.RenderTransform = x;
                textBlock.Text = QueryPointer(ptrPt);
            }
        }
    }
}
```

-   <span data-ttu-id="b64af-216">最後に、さまざまなポインター プロパティを照会します。</span><span class="sxs-lookup"><span data-stu-id="b64af-216">Finally, we query various pointer properties.</span></span>

```csharp
/// <summary>
/// Get pointer details.
/// </summary>
/// <param name="ptrPt">Reference to the input pointer.</param>
/// <returns>A string composed of pointer details.</returns>
String QueryPointer(PointerPoint ptrPt)
{
    String details = "";

    switch (ptrPt.PointerDevice.PointerDeviceType)
    {
        case Windows.Devices.Input.PointerDeviceType.Mouse:
            details += "\nPointer type: mouse";
            break;
        case Windows.Devices.Input.PointerDeviceType.Pen:
            details += "\nPointer type: pen";
            if (ptrPt.IsInContact)
            {
                details += "\nPressure: " + ptrPt.Properties.Pressure;
                details += "\nrotation: " + ptrPt.Properties.Orientation;
                details += "\nTilt X: " + ptrPt.Properties.XTilt;
                details += "\nTilt Y: " + ptrPt.Properties.YTilt;
                details += "\nBarrel button pressed: " + ptrPt.Properties.IsBarrelButtonPressed;
            }
            break;
        case Windows.Devices.Input.PointerDeviceType.Touch:
            details += "\nPointer type: touch";
            details += "\nrotation: " + ptrPt.Properties.Orientation;
            details += "\nTilt X: " + ptrPt.Properties.XTilt;
            details += "\nTilt Y: " + ptrPt.Properties.YTilt;
            break;
        default:
            details += "\nPointer type: n/a";
            break;
    }

    GeneralTransform gt = Target.TransformToVisual(this);
    Point screenPoint;

    screenPoint = gt.TransformPoint(new Point(ptrPt.Position.X, ptrPt.Position.Y));
    details += "\nPointer Id: " + ptrPt.PointerId.ToString() +
        "\nPointer location (target): " + Math.Round(ptrPt.Position.X) + ", " + Math.Round(ptrPt.Position.Y) +
        "\nPointer location (container): " + Math.Round(screenPoint.X) + ", " + Math.Round(screenPoint.Y);

    return details;
}
```

## <a name="primary-pointer"></a><span data-ttu-id="b64af-217">プライマリ ポインター</span><span class="sxs-lookup"><span data-stu-id="b64af-217">Primary pointer</span></span>
<span data-ttu-id="b64af-218">タッチ デジタイザーやタッチパッドなどの一部の入力デバイスでは、マウスまたはペンといった一般的な単一ポインターよりも多くのポインターをサポートします (Surface Hub での 2 つのペン入力のサポートが代表的な例です)。</span><span class="sxs-lookup"><span data-stu-id="b64af-218">Some input devices, such as a touch digitizer or touchpad, support more than the typical single pointer of a mouse or a pen (in most cases as the Surface Hub supports two pen inputs).</span></span> 

<span data-ttu-id="b64af-219">単一のプライマリ ポインターを識別し、区別するには、**[PointerPointerProperties](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties)** クラスの読み取り専用の **[IsPrimary](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties.IsPrimary)** プロパティを使います (プライマリ ポインターとは、常に入力シーケンスで検出される最初のポインターを指します)。</span><span class="sxs-lookup"><span data-stu-id="b64af-219">Use the read-only **[IsPrimary](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties.IsPrimary)** property of the **[PointerPointerProperties](https://docs.microsoft.com/uwp/api/windows.ui.input.pointerpointproperties)** class to identify and differentiate a single primary pointer (the primary pointer is always the first pointer detected during an input sequence).</span></span> 

<span data-ttu-id="b64af-220">プライマリ ポインターを識別することにより、プライマリ ポインターを使って、マウスやペン入力のエミュレート、操作のカスタマイズ、他の特定の機能や UI の提供を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="b64af-220">By identifying the primary pointer, you can use it to emulate mouse or pen input, customize interactions, or provide some other specific functionality or UI.</span></span>

> [!NOTE]
> <span data-ttu-id="b64af-221">入力シーケンスでプライマリ ポインターが離されたり、取り消されたり、または失われたりすると、新しい入力シーケンスが開始されるまでプライマリ入力ポインターは作成されません (入力シーケンスは、すべてのポインターが離されたり、取り消されたり、または失われたりすると終了します)。</span><span class="sxs-lookup"><span data-stu-id="b64af-221">If the primary pointer is released, canceled, or lost during an input sequence, a primary input pointer is not created until a new input sequence is initiated (an input sequence ends when all pointers have been released, canceled, or lost).</span></span>

## <a name="primary-pointer-animation-example"></a><span data-ttu-id="b64af-222">プライマリ ポインター アニメーションの例</span><span class="sxs-lookup"><span data-stu-id="b64af-222">Primary pointer animation example</span></span>

<span data-ttu-id="b64af-223">以下のコード スニペットは、特別な視覚的フィードバックを使って、ユーザーがアプリケーションでポインター入力を区別できるようにする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b64af-223">These code snippets show how you can provide special visual feedback to help a user differentiate between pointer inputs in your application.</span></span>

<span data-ttu-id="b64af-224">この特定のアプリでは、色とアニメーションの両方を使って、プライマリ ポインターを強調表示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-224">This particular app uses both color and animation to highlight the primary pointer.</span></span>

![アニメーション化された視覚的フィードバックを使ったポインター アプリケーション](images/pointers/pointers-usercontrol-animation.gif)

**<span data-ttu-id="b64af-226">このサンプルは、「[Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)」(ポインター入力のサンプル (アニメーションを使った UserControl)) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="b64af-226">Download this sample from [Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)</span></span>**

### <a name="visual-feedback"></a><span data-ttu-id="b64af-227">視覚的なフィードバック</span><span class="sxs-lookup"><span data-stu-id="b64af-227">Visual feedback</span></span>

<span data-ttu-id="b64af-228">ここでは、XAML の **[Ellipse](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes.ellipse)** オブジェクトに基づいて、**[UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol)** を定義します。これにより、各ポインターのキャンバス上の位置が強調表示されます。また、**[Storyboard](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.animation.storyboard)** を使って、プライマリ ポインターに対応する楕円をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="b64af-228">We define a **[UserControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol)**, based on a XAML **[Ellipse](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes.ellipse)** object, that highlights where each pointer is on the canvas and uses a **[Storyboard](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.animation.storyboard)** to animate the ellipse that corresponds to the primary pointer.</span></span>

**<span data-ttu-id="b64af-229">XAML を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-229">Here's the XAML:</span></span>**

```xaml
<UserControl
    x:Class="UWP_Pointers.PointerEllipse"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:UWP_Pointers"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="100"
    d:DesignWidth="100">

    <UserControl.Resources>
        <Style x:Key="EllipseStyle" TargetType="Ellipse">
            <Setter Property="Transitions">
                <Setter.Value>
                    <TransitionCollection>
                        <ContentThemeTransition/>
                    </TransitionCollection>
                </Setter.Value>
            </Setter>
        </Style>
        
        <Storyboard x:Name="myStoryboard">
            <!-- Animates the value of a Double property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <DoubleAnimation
              Storyboard.TargetName="ellipse"
              Storyboard.TargetProperty="(RenderTransform).(ScaleTransform.ScaleY)"  
              Duration="0:0:1" 
              AutoReverse="True" 
              RepeatBehavior="Forever" From="1.0" To="1.4">
            </DoubleAnimation>

            <!-- Animates the value of a Double property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <DoubleAnimation
              Storyboard.TargetName="ellipse"
              Storyboard.TargetProperty="(RenderTransform).(ScaleTransform.ScaleX)"  
              Duration="0:0:1" 
              AutoReverse="True" 
              RepeatBehavior="Forever" From="1.0" To="1.4">
            </DoubleAnimation>

            <!-- Animates the value of a Color property between 
            two target values using linear interpolation over the 
            specified Duration. -->
            <ColorAnimation 
                Storyboard.TargetName="ellipse" 
                EnableDependentAnimation="True" 
                Storyboard.TargetProperty="(Fill).(SolidColorBrush.Color)" 
                From="White" To="Red"  Duration="0:0:1" 
                AutoReverse="True" RepeatBehavior="Forever"/>
        </Storyboard>
    </UserControl.Resources>

    <Grid x:Name="CompositionContainer">
        <Ellipse Name="ellipse" 
        StrokeThickness="2" 
        Width="{x:Bind Diameter}" 
        Height="{x:Bind Diameter}"  
        Style="{StaticResource EllipseStyle}" />
    </Grid>
</UserControl>
```

<span data-ttu-id="b64af-230">コードビハインドを次に示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-230">And here's the code-behind:</span></span>
```csharp
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at 
// https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_Pointers
{
    /// <summary>
    /// Pointer feedback object.
    /// </summary>
    public sealed partial class PointerEllipse : UserControl
    {
        // Reference to the application canvas.
        Canvas canvas;

        /// <summary>
        /// Ellipse UI for pointer feedback.
        /// </summary>
        /// <param name="c">The drawing canvas.</param>
        public PointerEllipse(Canvas c)
        {
            this.InitializeComponent();
            canvas = c;
        }

        /// <summary>
        /// Gets or sets the pointer Id to associate with the PointerEllipse object.
        /// </summary>
        public uint PointerId
        {
            get { return (uint)GetValue(PointerIdProperty); }
            set { SetValue(PointerIdProperty, value); }
        }
        // Using a DependencyProperty as the backing store for PointerId.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointerIdProperty =
            DependencyProperty.Register("PointerId", typeof(uint), 
                typeof(PointerEllipse), new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets whether the associated pointer is Primary.
        /// </summary>
        public bool PrimaryPointer
        {
            get { return (bool)GetValue(PrimaryPointerProperty); }
            set
            {
                SetValue(PrimaryPointerProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for PrimaryPointer.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrimaryPointerProperty =
            DependencyProperty.Register("PrimaryPointer", typeof(bool), 
                typeof(PointerEllipse), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the ellipse style based on whether the pointer is Primary.
        /// </summary>
        public bool PrimaryEllipse 
        {
            get { return (bool)GetValue(PrimaryEllipseProperty); }
            set
            {
                SetValue(PrimaryEllipseProperty, value);
                if (value)
                {
                    SolidColorBrush fillBrush = 
                        (SolidColorBrush)Application.Current.Resources["PrimaryFillBrush"];
                    SolidColorBrush strokeBrush = 
                        (SolidColorBrush)Application.Current.Resources["PrimaryStrokeBrush"];

                    ellipse.Fill = fillBrush;
                    ellipse.Stroke = strokeBrush;
                    ellipse.RenderTransform = new CompositeTransform();
                    ellipse.RenderTransformOrigin = new Point(.5, .5);
                    myStoryboard.Begin();
                }
                else
                {
                    SolidColorBrush fillBrush = 
                        (SolidColorBrush)Application.Current.Resources["SecondaryFillBrush"];
                    SolidColorBrush strokeBrush = 
                        (SolidColorBrush)Application.Current.Resources["SecondaryStrokeBrush"];
                    ellipse.Fill = fillBrush;
                    ellipse.Stroke = strokeBrush;
                }
            }
        }
        // Using a DependencyProperty as the backing store for PrimaryEllipse.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrimaryEllipseProperty =
            DependencyProperty.Register("PrimaryEllipse", 
                typeof(bool), typeof(PointerEllipse), new PropertyMetadata(false));


        /// <summary>
        /// Gets or sets the diameter of the PointerEllipse object.
        /// </summary>
        public int Diameter
        {
            get { return (int)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Diameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(int), 
                typeof(PointerEllipse), new PropertyMetadata(120));
    }
}
```

### <a name="create-the-ui"></a><span data-ttu-id="b64af-231">UI を作成する</span><span class="sxs-lookup"><span data-stu-id="b64af-231">Create the UI</span></span>
<span data-ttu-id="b64af-232">この例の UI は入力の **[Canvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas)** に制限されます。ここでは、すべてのポインターを追跡し、ポインター カウンターやプライマリ ポインター識別子を含むヘッダー バーと共に、ポインター インジケーターとプライマリ ポインター アニメーションをレンダリングします (該当する場合)。</span><span class="sxs-lookup"><span data-stu-id="b64af-232">The UI in this example is limited to the input **[Canvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas)** where we track any pointers and render the pointer indicators and primary pointer animation (if applicable), along with a header bar containing a pointer counter and a primary pointer identifier.</span></span>

<span data-ttu-id="b64af-233">MainPage.xaml を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b64af-233">Here's the MainPage.xaml:</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" 
                Orientation="Horizontal" 
                Grid.Row="0">
        <StackPanel.Transitions>
            <TransitionCollection>
                <AddDeleteThemeTransition/>
            </TransitionCollection>
        </StackPanel.Transitions>
        <TextBlock x:Name="Header" 
                    Text="Basic pointer tracking sample - IsPrimary" 
                    Style="{ThemeResource HeaderTextBlockStyle}" 
                    Margin="10,0,0,0" />
        <TextBlock x:Name="PointerCounterLabel"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="Number of pointers: " 
                    Margin="50,0,0,0"/>
        <TextBlock x:Name="PointerCounter"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="0" 
                    Margin="10,0,0,0"/>
        <TextBlock x:Name="PointerPrimaryLabel"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="Primary: " 
                    Margin="50,0,0,0"/>
        <TextBlock x:Name="PointerPrimary"
                    VerticalAlignment="Center"                 
                    Style="{ThemeResource BodyTextBlockStyle}"
                    Text="n/a" 
                    Margin="10,0,0,0"/>
    </StackPanel>
    
    <Grid Grid.Row="1">
        <!--The canvas where we render the pointer UI.-->
        <Canvas x:Name="pointerCanvas"/>
    </Grid>
</Grid>
```

### <a name="handle-pointer-events"></a><span data-ttu-id="b64af-234">ポインター イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="b64af-234">Handle pointer events</span></span>

<span data-ttu-id="b64af-235">最後に、MainPage.xaml.cs のコード ビハインドで、基本的なポインター イベント ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="b64af-235">Finally, we define our basic pointer event handlers in the MainPage.xaml.cs code-behind.</span></span> <span data-ttu-id="b64af-236">ここでは、コードを再現しません。基本的なコードは前の例で示されているためです。動作するサンプルは「[Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)」(ポインター入力のサンプル (アニメーションを使った UserControl)) でダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="b64af-236">We won't reproduce the code here as the basics were covered in the previous example, but you can download the working sample from [Pointer input sample (UserControl with animation)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip).</span></span>

## <a name="related-articles"></a><span data-ttu-id="b64af-237">関連記事</span><span class="sxs-lookup"><span data-stu-id="b64af-237">Related articles</span></span>

**<span data-ttu-id="b64af-238">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-238">Topic samples</span></span>**
* [<span data-ttu-id="b64af-239">ポインター入力のサンプル (基本)</span><span class="sxs-lookup"><span data-stu-id="b64af-239">Pointer input sample (basic)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers.zip)
* [<span data-ttu-id="b64af-240">ポインター入力のサンプル (アニメーションを使った UserControl)</span><span class="sxs-lookup"><span data-stu-id="b64af-240">Pointer input sample (UserControl with animation)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-pointers-animation.zip)

**<span data-ttu-id="b64af-241">その他のサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-241">Other samples</span></span>**
* [<span data-ttu-id="b64af-242">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-242">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="b64af-243">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-243">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="b64af-244">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-244">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="b64af-245">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-245">Focus visuals sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="b64af-246">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="b64af-246">Archive samples</span></span>**
* [<span data-ttu-id="b64af-247">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-247">Input: XAML user input events sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="b64af-248">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-248">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="b64af-249">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="b64af-249">Input: Manipulations and gestures (C++) sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="b64af-250">入力: タッチのヒット テストのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="b64af-250">Input: Touch hit testing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="b64af-251">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="b64af-251">XAML scrolling, panning, and zooming sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="b64af-252">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="b64af-252">Input: Simplified ink sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=246570)