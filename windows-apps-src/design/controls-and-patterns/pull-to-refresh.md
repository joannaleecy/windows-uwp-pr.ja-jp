---
author: Jwmsft
Description: Use the pull-to-refresh control to get new content into a list.
title: 引っ張って更新
label: Pull-to-refresh
template: detail.hbs
ms.author: jimwalk
ms.date: 03/07/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: aaeb1e74-b795-4015-bf41-02cb1d6f467e
pm-contact: predavid
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 8b1dd6bd1bc165a79ba123c94e63e1dcfa58ec21
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6184104"
---
# <a name="pull-to-refresh"></a><span data-ttu-id="222ba-103">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="222ba-103">Pull to refresh</span></span>

<span data-ttu-id="222ba-104">引っ張って更新を使うと、タッチ操作でデータの一覧を引き下げることで、より多くのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="222ba-104">Pull-to-refresh lets a user pull down on a list of data using touch in order to retrieve more data.</span></span> <span data-ttu-id="222ba-105">引っ張って更新は、タッチ スクリーンを備えたデバイスで広く使用されます。</span><span class="sxs-lookup"><span data-stu-id="222ba-105">Pull-to-refresh is widely used on devices with a touch screen.</span></span> <span data-ttu-id="222ba-106">ここに表示されている API を使用して、アプリに引っ張って更新を実装できます。</span><span class="sxs-lookup"><span data-stu-id="222ba-106">You can use the APIs shown here to implement pull-to-refresh in your app.</span></span>

> <span data-ttu-id="222ba-107">**重要な API**: [RefreshContainer](/uwp/api/windows.ui.xaml.controls.refreshcontainer)、[RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer)</span><span class="sxs-lookup"><span data-stu-id="222ba-107">**Important APIs**: [RefreshContainer](/uwp/api/windows.ui.xaml.controls.refreshcontainer), [RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer)</span></span>

![引っ張って更新 gif](images/Pull-To-Refresh.gif)

## <a name="is-this-the-right-control"></a><span data-ttu-id="222ba-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="222ba-109">Is this the right control?</span></span>

<span data-ttu-id="222ba-110">ユーザーが定期的に更新するデータのリストやグリッドがあり、アプリがタッチ操作主体のデバイスで実行されることが多いときは、引っ張って更新を使います。</span><span class="sxs-lookup"><span data-stu-id="222ba-110">Use pull-to-refresh when you have a list or grid of data that the user might want to refresh regularly, and your app is likely to be running on touch-first devices.</span></span>

<span data-ttu-id="222ba-111">[RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer) を使用して、更新ボタンなど他の方法で呼び出される一貫した更新エクスペリエンスを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="222ba-111">You can also use the [RefreshVisualizer](/uwp/api/windows.ui.xaml.controls.refreshvisualizer) to create a consistent refresh experience that is invoked in other ways, such as by a refresh button.</span></span>

## <a name="refresh-controls"></a><span data-ttu-id="222ba-112">更新コントロール</span><span class="sxs-lookup"><span data-stu-id="222ba-112">Refresh controls</span></span>

<span data-ttu-id="222ba-113">引っ張って更新は、2 つのコントロールで有効になっています。</span><span class="sxs-lookup"><span data-stu-id="222ba-113">Pull-to-refresh is enabled by 2 controls.</span></span>

- <span data-ttu-id="222ba-114">**RefreshContainer** - 引っ張って更新エクスペリエンスのラッパーを提供する ContentControl。</span><span class="sxs-lookup"><span data-stu-id="222ba-114">**RefreshContainer** - a ContentControl that provides a wrapper for the pull-to-refresh experience.</span></span> <span data-ttu-id="222ba-115">これは、タッチ操作を処理し、その内部更新ビジュアライザーの状態を管理します。</span><span class="sxs-lookup"><span data-stu-id="222ba-115">It handles the touch interactions and manages the state of its internal refresh visualizer.</span></span>
- <span data-ttu-id="222ba-116">**RefreshVisualizer** - 次のセクションで説明されている更新の視覚エフェクトをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="222ba-116">**RefreshVisualizer** - encapsulates the refresh visualization explained in the next section.</span></span>

<span data-ttu-id="222ba-117">メインのコントロールは、ユーザーが更新をトリガするためにプルするコンテンツ全体のラッパーとして配置する **RefreshContainer** です。</span><span class="sxs-lookup"><span data-stu-id="222ba-117">The main control is the **RefreshContainer**, which you place as a wrapper around the content that the user pulls to trigger a refresh.</span></span> <span data-ttu-id="222ba-118">RefreshContainer はタッチでのみ機能するため、タッチ インターフェイスを持たないユーザーが使用できる更新ボタンを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="222ba-118">RefreshContainer works only with touch, so we recommend that you also have a refresh button available for users who don't have a touch interface.</span></span> <span data-ttu-id="222ba-119">更新ボタンは、コマンド バーまたは更新されるサーフェスに近い場所など、アプリの適切な場所に配置できます。</span><span class="sxs-lookup"><span data-stu-id="222ba-119">You can position the refresh button at a suitable location in the app, either on a command bar or at a location close to the surface being refreshed.</span></span>

## <a name="refresh-visualization"></a><span data-ttu-id="222ba-120">更新の視覚エフェクト</span><span class="sxs-lookup"><span data-stu-id="222ba-120">Refresh visualization</span></span>

<span data-ttu-id="222ba-121">既定の更新の視覚エフェクトは、更新が発生したときに通信するために使用される循環進行スピンと、更新が開始された後の更新の進行状況です。</span><span class="sxs-lookup"><span data-stu-id="222ba-121">The default refresh visualization is a circular progress spinner that is used to communicate when a refresh will happen and the progress of the refresh after it is initiated.</span></span> <span data-ttu-id="222ba-122">更新ビジュアライザーには、5 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="222ba-122">The refresh visualizer has 5 states.</span></span>

 <span data-ttu-id="222ba-123">ユーザーが更新を開始するために一覧でプル ダウンする必要がある距離を_しきい値_といいます。</span><span class="sxs-lookup"><span data-stu-id="222ba-123">The distance the user needs to pull down on a list to initiate a refresh is called the _threshold_.</span></span> <span data-ttu-id="222ba-124">ビジュアライザー[状態](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.State) は、このしきい値に関連するプル状態によって決まります。</span><span class="sxs-lookup"><span data-stu-id="222ba-124">The visualizer [State](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.State) is determined by the pull state as it relates to this threshold.</span></span> <span data-ttu-id="222ba-125">使用可能な値は、[RefreshVisualizerState](/uwp/api/windows.ui.xaml.controls.refreshvisualizerstate) 列挙に含まれています。</span><span class="sxs-lookup"><span data-stu-id="222ba-125">The possible values are contained in the [RefreshVisualizerState](/uwp/api/windows.ui.xaml.controls.refreshvisualizerstate) enumeration.</span></span>

### <a name="idle"></a><span data-ttu-id="222ba-126">アイドル</span><span class="sxs-lookup"><span data-stu-id="222ba-126">Idle</span></span>

<span data-ttu-id="222ba-127">ビジュアライザーの既定の状態は**アイドル**です。</span><span class="sxs-lookup"><span data-stu-id="222ba-127">The visualizer's default state is **Idle**.</span></span> <span data-ttu-id="222ba-128">ユーザーはタッチを介して RefreshContainer と対話しておらず、実行中の更新はありません。</span><span class="sxs-lookup"><span data-stu-id="222ba-128">The user is not interacting with the RefreshContainer via touch, and there is not a refresh in progress.</span></span>

<span data-ttu-id="222ba-129">視覚的に、更新ビジュアライザーの証拠はありません。</span><span class="sxs-lookup"><span data-stu-id="222ba-129">Visually, there is no evidence of the refresh visualizer.</span></span>

### <a name="interacting"></a><span data-ttu-id="222ba-130">操作中</span><span class="sxs-lookup"><span data-stu-id="222ba-130">Interacting</span></span>

<span data-ttu-id="222ba-131">ユーザーが PullDirection プロパティで指定された方向にリストをプルすると、しきい値に達する前にビジュアライザーは**対話**状態になります。</span><span class="sxs-lookup"><span data-stu-id="222ba-131">When the user pulls the list in the direction specified by the PullDirection property, and before the threshold is reached, the visualizer is in the **Interacting** state.</span></span>

- <span data-ttu-id="222ba-132">この状態でユーザーがコントロールを離すと、コントロールは**アイドル**に戻ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-132">If the user releases the control while in this state, the control returns to **Idle**.</span></span>

    ![引っ張って更新の事前しきい値](images/ptr-prethreshold.png)

    <span data-ttu-id="222ba-134">視覚的に、アイコンは無効 (60% の不透明度) として表示されます。</span><span class="sxs-lookup"><span data-stu-id="222ba-134">Visually, the icon is displayed as disabled (60% opacity).</span></span> <span data-ttu-id="222ba-135">さらに、アイコンはスクロールの操作で 1 回転します。</span><span class="sxs-lookup"><span data-stu-id="222ba-135">In addition, the icon spins one full rotation with the scroll action.</span></span>

- <span data-ttu-id="222ba-136">ユーザーがしきい値を超えてリストをプルすると、ビジュアライザーは**操作中**から**保留中**に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="222ba-136">If the user pulls the list past the threshold, the visualizer transitions from **Interacting** to **Pending**.</span></span>

    ![しきい値にある引っ張って更新](images/ptr-atthreshold.png)

    <span data-ttu-id="222ba-138">視覚的に、アイコンが 100% の不透明度に切り替わり、切り替えの過程でサイズは最大 150％ になり、その後 100％ に戻ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-138">Visually, the icon switches to 100% opacity and pulses in size up to 150% and then back to 100% size during the transition.</span></span>

### <a name="pending"></a><span data-ttu-id="222ba-139">保留中</span><span class="sxs-lookup"><span data-stu-id="222ba-139">Pending</span></span>

<span data-ttu-id="222ba-140">ユーザーがしきい値を超えてリストをプルした場合、ビジュアライザーは**保留中**状態になります。</span><span class="sxs-lookup"><span data-stu-id="222ba-140">When the user has pulled the list past the threshold, the visualizer is in the **Pending** state.</span></span>

- <span data-ttu-id="222ba-141">ユーザーがリストを解放せずにしきい値を超えて戻すと、**操作中**状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-141">If the user moves the list back above the threshold without releasing it, it returns to the **Interacting** state.</span></span>
- <span data-ttu-id="222ba-142">ユーザーがリストを解放すると、更新要求が開始され、**更新中**状態に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="222ba-142">If the user releases the list, a refresh request is initiated and it transitions to the **Refreshing** state.</span></span>

![引っ張って更新の事後しきい値](images/ptr-postthreshold.png)

<span data-ttu-id="222ba-144">図で表すと、アイコンはサイズと不透明度のどちらも 100% になります。</span><span class="sxs-lookup"><span data-stu-id="222ba-144">Visually, the icon is 100% in both size and opacity.</span></span> <span data-ttu-id="222ba-145">この状態では、アイコンはスクロール操作で下に移動し続けますが、回転することはありません。</span><span class="sxs-lookup"><span data-stu-id="222ba-145">In this state, the icon continues to move down with the scroll action but no longer spins.</span></span>

### <a name="refreshing"></a><span data-ttu-id="222ba-146">更新しています</span><span class="sxs-lookup"><span data-stu-id="222ba-146">Refreshing</span></span>

<span data-ttu-id="222ba-147">ユーザーがしきい値を超えてビジュアライザーを解放すると、**更新中**状態になります。</span><span class="sxs-lookup"><span data-stu-id="222ba-147">When the user releases the visualiser past the threshold, it's in the **Refreshing** state.</span></span>

<span data-ttu-id="222ba-148">この状態に入ると、**RefreshRequested** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="222ba-148">When this state is entered, the **RefreshRequested** event is raised.</span></span> <span data-ttu-id="222ba-149">これは、アプリのコンテンツの更新を開始する信号です。</span><span class="sxs-lookup"><span data-stu-id="222ba-149">This is the signal to start the app's content refresh.</span></span> <span data-ttu-id="222ba-150">イベントの引数 ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) には、イベント ハンドラーでハンドルを取得する必要がある [Deferral](/uwp/api/windows.foundation.deferral) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="222ba-150">The event args ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) contain a [Deferral](/uwp/api/windows.foundation.deferral) object, which you should take a handle to in the event handler.</span></span> <span data-ttu-id="222ba-151">その後、更新を実行するコードが完了した時点で、延期を完了とマークする必要があります。</span><span class="sxs-lookup"><span data-stu-id="222ba-151">Then, you should mark the deferral as completed when your code to perform the refresh has completed.</span></span>

<span data-ttu-id="222ba-152">更新が完了すると、ビジュアライザーは**アイドル**状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-152">When the refresh is complete, the visualizer returns to the **Idle** state.</span></span>

<span data-ttu-id="222ba-153">図で表すと、アイコンはしきい値の位置に戻り、更新の期間中回転します。</span><span class="sxs-lookup"><span data-stu-id="222ba-153">Visually, the icon settles back to the threshold location and spins for the duration of the refresh.</span></span> <span data-ttu-id="222ba-154">この回転は、更新の進行状況を表示するために使用され、受信したコンテンツのアニメーションによって置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="222ba-154">This spinning is used to show progress of the refresh and is replaced by the animation of the incoming content.</span></span>

### <a name="peeking"></a><span data-ttu-id="222ba-155">ピーク</span><span class="sxs-lookup"><span data-stu-id="222ba-155">Peeking</span></span>

<span data-ttu-id="222ba-156">ユーザーが、更新が許可されていない開始位置から更新方向でプルすると、ビジュアライザーは**ピーク**状態に入ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-156">When the user pulls in the refresh direction from a start position where a refresh is not allowed, the visualizer enters the **Peeking** state.</span></span> <span data-ttu-id="222ba-157">これは通常、ユーザーがプルを開始したときに ScrollViewer が 0 の位置にない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="222ba-157">This typically happens when the ScrollViewer is not at position 0 when the user starts to pull.</span></span>

- <span data-ttu-id="222ba-158">この状態でユーザーがコントロールを離すと、コントロールは**アイドル**に戻ります。</span><span class="sxs-lookup"><span data-stu-id="222ba-158">If the user releases the control while in this state, the control returns to **Idle**.</span></span>

## <a name="pull-direction"></a><span data-ttu-id="222ba-159">プルの方向</span><span class="sxs-lookup"><span data-stu-id="222ba-159">Pull direction</span></span>

<span data-ttu-id="222ba-160">既定では、ユーザーはリストを上から下へプルして更新を開始します。</span><span class="sxs-lookup"><span data-stu-id="222ba-160">By default, the user pulls a list from top to bottom to initiate a refresh.</span></span> <span data-ttu-id="222ba-161">リストまたはグリッドの方向が異なる場合は、更新コンテナーのプル方向を変更して一致させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="222ba-161">If you have a list or grid with a different orientation, you should change the pull direction of the refresh container to match.</span></span>

<span data-ttu-id="222ba-162">[PullDirection](/uwp/api/windows.ui.xaml.controls.refreshcontainer.PullDirection) プロパティは、次の [RefreshPullDirection](/uwp/api/windows.ui.xaml.controls.refreshpulldirection) 値のいずれかを取ります。**BottomToTop**、**TopToBottom**、**RightToLeft**、または **LeftToRight**。</span><span class="sxs-lookup"><span data-stu-id="222ba-162">The [PullDirection](/uwp/api/windows.ui.xaml.controls.refreshcontainer.PullDirection) property takes one of these [RefreshPullDirection](/uwp/api/windows.ui.xaml.controls.refreshpulldirection) values: **BottomToTop**, **TopToBottom**, **RightToLeft**, or **LeftToRight**.</span></span>

<span data-ttu-id="222ba-163">プルの方向を変更すると、ビジュアライザーの進行スピンの開始位置は、プルの方向に適した位置で矢印が起動するように自動的に回転します。</span><span class="sxs-lookup"><span data-stu-id="222ba-163">When you change the pull dircetion, the starting position of the visualizer's progress spinner automatically rotates so the arrow starts in the appropriate position for the pull direction.</span></span> <span data-ttu-id="222ba-164">必要に応じて、[RefreshVisualizer.Orientation](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.Orientation) プロパティを変更して自動の動作をオーバーライドできます。</span><span class="sxs-lookup"><span data-stu-id="222ba-164">If needed, you can change the [RefreshVisualizer.Orientation](/uwp/api/windows.ui.xaml.controls.refreshvisualizer.Orientation) property to override the automatic behavior.</span></span> <span data-ttu-id="222ba-165">ほとんどの場合、既定値の**自動**のままにしておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="222ba-165">In most cases, we recommend leaving the default value of **Auto**.</span></span>

## <a name="implement-pull-to-refresh"></a><span data-ttu-id="222ba-166">引っ張って更新を実装する</span><span class="sxs-lookup"><span data-stu-id="222ba-166">Implement pull-to-refresh</span></span>

<span data-ttu-id="222ba-167">引っ張って更新機能をリストに追加するにはいくつかの手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="222ba-167">To add pull-to-refresh functionality to a list requires just a few steps.</span></span>

1. <span data-ttu-id="222ba-168">**RefreshContainer** コントロールでリストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="222ba-168">Wrap your list in a **RefreshContainer** control.</span></span>
1. <span data-ttu-id="222ba-169">**RefreshRequested** イベントを処理してコンテンツを更新します。</span><span class="sxs-lookup"><span data-stu-id="222ba-169">Handle the **RefreshRequested** event to refresh your content.</span></span>
1. <span data-ttu-id="222ba-170">必要に応じて、**RequestRefresh** (たとえば、ボタンのクリックで) を呼び出して更新を開始します。</span><span class="sxs-lookup"><span data-stu-id="222ba-170">Optionally, initiate a refresh by calling **RequestRefresh** (for example, from a button click).</span></span>

> [!NOTE]
> <span data-ttu-id="222ba-171">単体で RefreshVisualizer をインスタンス化することができます。</span><span class="sxs-lookup"><span data-stu-id="222ba-171">You can instantiate a RefreshVisualizer on its own.</span></span> <span data-ttu-id="222ba-172">ただし、タッチ非対応シナリオに対しても、コンテンツを RefreshContainer で折り返し、RefreshContainer.Visualizer プロパティによって提供される RefreshVisualizer を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="222ba-172">However, we recommend that you wrap your content in a RefreshContainer and use the RefreshVisualizer provided by the RefreshContainer.Visualizer property, even for non-touch scenarios.</span></span> <span data-ttu-id="222ba-173">この記事では、ビジュアライザーが常に更新コンテナーから取得されることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="222ba-173">In this article, we assume that the visualizer is always obtained from the refresh container.</span></span>

> <span data-ttu-id="222ba-174">さらに便宜上、更新コンテナーの RequestRefresh と RefreshRequested メンバーを使用します。</span><span class="sxs-lookup"><span data-stu-id="222ba-174">In addition, use the refresh container's RequestRefresh and RefreshRequested members for convenience.</span></span> `refreshContainer.RequestRefresh()` <span data-ttu-id="222ba-175">`refreshContainer.Visualizer.RequestRefresh()` に相当し、いずれかで RefreshContainer.RefreshRequested イベントと RefreshVisualizer.RefreshRequested イベントの両方が発生します。</span><span class="sxs-lookup"><span data-stu-id="222ba-175">is equivalent to `refreshContainer.Visualizer.RequestRefresh()`, and either will raise both the RefreshContainer.RefreshRequested event and the RefreshVisualizer.RefreshRequested events.</span></span>

### <a name="request-a-refresh"></a><span data-ttu-id="222ba-176">更新の要求</span><span class="sxs-lookup"><span data-stu-id="222ba-176">Request a refresh</span></span>

<span data-ttu-id="222ba-177">更新コンテナーは、ユーザーがタッチ経由でコンテンツを更新するためのタッチ操作を処理します。</span><span class="sxs-lookup"><span data-stu-id="222ba-177">The refresh container handles touch interactions to let a user refresh content via touch.</span></span> <span data-ttu-id="222ba-178">更新ボタンまたは音声コントロールなど、タッチ非対応インターフェイス用の他のアフォーダンスを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="222ba-178">We recommend that you provide other affordances for non-touch interfaces, like a refresh button or voice control.</span></span>

<span data-ttu-id="222ba-179">更新を開始するには、[RequestRefresh](/uwp/api/windows.ui.xaml.controls.refreshcontainer.RequestRefresh) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="222ba-179">To initiate a refresh, call the [RequestRefresh](/uwp/api/windows.ui.xaml.controls.refreshcontainer.RequestRefresh) method.</span></span>

```csharp
// See the Examples section for the full code.
private void RefreshButtonClick(object sender, RoutedEventArgs e)
{
    RefreshContainer.RequestRefresh();
}
```

<span data-ttu-id="222ba-180">RequestRefresh を呼び出すと、ビジュアライザーの状態は直接**アイドル状態**から**更新中**に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="222ba-180">When you call RequestRefresh, the visualizer state goes directly from **Idle** to **Refreshing**.</span></span>

### <a name="handle-a-refresh-request"></a><span data-ttu-id="222ba-181">更新要求の処理</span><span class="sxs-lookup"><span data-stu-id="222ba-181">Handle a refresh request</span></span>

<span data-ttu-id="222ba-182">必要に応じて新しいコンテンツを取得するには、RefreshRequested イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="222ba-182">To get fresh content when needed, handle the RefreshRequested event.</span></span> <span data-ttu-id="222ba-183">イベント ハンドラーで、新しいコンテンツを取得するアプリに固有のコードが必要です。</span><span class="sxs-lookup"><span data-stu-id="222ba-183">In the event handler, you'll need code specific to your app to get the fresh content.</span></span>

<span data-ttu-id="222ba-184">イベントの引数 ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) には、[Deferral](/uwp/api/windows.foundation.deferral) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="222ba-184">The event args ([RefreshRequestedEventArgs](/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)) contain a [Deferral](/uwp/api/windows.foundation.deferral) object.</span></span> <span data-ttu-id="222ba-185">イベント ハンドラーで、延期へのハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="222ba-185">Get a handle to the deferral in the event handler.</span></span> <span data-ttu-id="222ba-186">その後、更新を実行するコードが完了した時点で、延期を完了とマークします。</span><span class="sxs-lookup"><span data-stu-id="222ba-186">Then, mark the deferral as completed when your code to perform the refresh has completed.</span></span>

```csharp
// See the Examples section for the full code.
private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
{
    // Respond to a request by performing a refresh and using the deferral object.
    using (var RefreshCompletionDeferral = args.GetDeferral())
    {
        // Do some async operation to refresh the content

         await FetchAndInsertItemsAsync(3);

        // The 'using' statement ensures the deferral is marked as complete.
        // Otherwise, you'd call
        // RefreshCompletionDeferral.Complete();
        // RefreshCompletionDeferral.Dispose();
    }
}
```

### <a name="respond-to-state-changes"></a><span data-ttu-id="222ba-187">状態の変更への対応</span><span class="sxs-lookup"><span data-stu-id="222ba-187">Respond to state changes</span></span>

<span data-ttu-id="222ba-188">必要に応じて、ビジュアライザーの状態の変更に対応できます。</span><span class="sxs-lookup"><span data-stu-id="222ba-188">You can respond to changes in the visualizer's state, if needed.</span></span> <span data-ttu-id="222ba-189">たとえば、複数の更新要求を防ぐために、ビジュアライザーが更新中は更新ボタンを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="222ba-189">For example, to prevent multiple refresh requests, you can disable a refresh button while the visualizer is refreshing.</span></span>

```csharp
// See the Examples section for the full code.
private void Visualizer_RefreshStateChanged(RefreshVisualizer sender, RefreshStateChangedEventArgs args)
{
    // Respond to visualizer state changes.
    // Disable the refresh button if the visualizer is refreshing.
    if (args.NewState == RefreshVisualizerState.Refreshing)
    {
        RefreshButton.IsEnabled = false;
    }
    else
    {
        RefreshButton.IsEnabled = true;
    }
}
```

## <a name="examples"></a><span data-ttu-id="222ba-190">例</span><span class="sxs-lookup"><span data-stu-id="222ba-190">Examples</span></span>

### <a name="using-a-scrollviewer-in-a-refreshcontainer"></a><span data-ttu-id="222ba-191">RefreshContainer での ScrollViewer の使用</span><span class="sxs-lookup"><span data-stu-id="222ba-191">Using a ScrollViewer in a RefreshContainer</span></span>

<span data-ttu-id="222ba-192">この例では、スクロール ビューアーで引っ張って更新を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="222ba-192">This example shows how to use pull-to-refresh with a scroll viewer.</span></span>

```xaml
<RefreshContainer>
    <ScrollViewer VerticalScrollMode="Enabled"
                  VerticalScrollBarVisibility="Auto"
                  HorizontalScrollBarVisibility="Auto">
 
        <!-- Scrollviewer content -->

    </ScrollViewer>
</RefreshContainer>
```

### <a name="adding-pull-to-refresh-to-a-listview"></a><span data-ttu-id="222ba-193">ListView に引っ張って更新を追加する</span><span class="sxs-lookup"><span data-stu-id="222ba-193">Adding pull-to-refresh to a ListView</span></span>

<span data-ttu-id="222ba-194">この例では、リスト ビューで引っ張って更新を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="222ba-194">This example shows how to use pull-to-refresh with a list view.</span></span>

```xaml
<StackPanel Margin="0,40" Width="280">
    <CommandBar OverflowButtonVisibility="Collapsed">
        <AppBarButton x:Name="RefreshButton" Click="RefreshButtonClick"
                      Icon="Refresh" Label="Refresh"/>
        <CommandBar.Content>
            <TextBlock Text="List of items" 
                       Style="{StaticResource TitleTextBlockStyle}"
                       Margin="12,8"/>
        </CommandBar.Content>
    </CommandBar>

    <RefreshContainer x:Name="RefreshContainer">
        <ListView x:Name="ListView1" Height="400">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <Grid Height="80">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <TextBlock Text="{x:Bind Path=Header}"
                                   Style="{StaticResource SubtitleTextBlockStyle}"
                                   Grid.Row="0"/>
                        <TextBlock Text="{x:Bind Path=Date}"
                                   Style="{StaticResource CaptionTextBlockStyle}"
                                   Grid.Row="1"/>
                        <TextBlock Text="{x:Bind Path=Body}"
                                   Style="{StaticResource BodyTextBlockStyle}"
                                   Grid.Row="2"
                                   Margin="0,4,0,0" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </RefreshContainer>
</StackPanel>
```

```csharp
public sealed partial class MainPage : Page
{
    public ObservableCollection<ListItemData> Items { get; set; } 
        = new ObservableCollection<ListItemData>();

    public MainPage()
    {
        this.InitializeComponent();

        Loaded += MainPage_Loaded;
        ListView1.ItemsSource = Items;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Loaded -= MainPage_Loaded;
        RefreshContainer.RefreshRequested += RefreshContainer_RefreshRequested;
        RefreshContainer.Visualizer.RefreshStateChanged += Visualizer_RefreshStateChanged;

        // Add some initial content to the list.
        await FetchAndInsertItemsAsync(2);
    }

    private void RefreshButtonClick(object sender, RoutedEventArgs e)
    {
        RefreshContainer.RequestRefresh();
    }

    private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
    {
        // Respond to a request by performing a refresh and using the deferral object.
        using (var RefreshCompletionDeferral = args.GetDeferral())
        {
            // Do some async operation to refresh the content

            await FetchAndInsertItemsAsync(3);

            // The 'using' statement ensures the deferral is marked as complete.
            // Otherwise, you'd call
            // RefreshCompletionDeferral.Complete();
            // RefreshCompletionDeferral.Dispose();
        }
    }

    private void Visualizer_RefreshStateChanged(RefreshVisualizer sender, RefreshStateChangedEventArgs args)
    {
        // Respond to visualizer state changes.
        // Disable the refresh button if the visualizer is refreshing.
        if (args.NewState == RefreshVisualizerState.Refreshing)
        {
            RefreshButton.IsEnabled = false;
        }
        else
        {
            RefreshButton.IsEnabled = true;
        }
    }

    // App specific code to get fresh data.
    private async Task FetchAndInsertItemsAsync(int updateCount)
    {
        for (int i = 0; i < updateCount; ++i)
        {
            // Simulate delay while we go fetch new items.
            await Task.Delay(1000);
            Items.Insert(0, GetNextItem());
        }
    }

    private ListItemData GetNextItem()
    {
        return new ListItemData()
        {
            Header = "Header " + DateTime.Now.Second.ToString(),
            Date = DateTime.Now.ToLongDateString(),
            Body = DateTime.Now.ToLongTimeString()
        };
    }
}

public class ListItemData
{
    public string Header { get; set; }
    public string Date { get; set; }
    public string Body { get; set; }
}
```

## <a name="related-articles"></a><span data-ttu-id="222ba-195">関連記事</span><span class="sxs-lookup"><span data-stu-id="222ba-195">Related articles</span></span>

- [<span data-ttu-id="222ba-196">タッチ操作</span><span class="sxs-lookup"><span data-stu-id="222ba-196">Touch interactions</span></span>](../input/touch-interactions.md)
- [<span data-ttu-id="222ba-197">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="222ba-197">List view and grid view</span></span>](listview-and-gridview.md)
- [<span data-ttu-id="222ba-198">項目コンテナーやテンプレート</span><span class="sxs-lookup"><span data-stu-id="222ba-198">Item containers and templates</span></span>](item-containers-templates.md)
- [<span data-ttu-id="222ba-199">数式アニメーション</span><span class="sxs-lookup"><span data-stu-id="222ba-199">Expression animations</span></span>](../../composition/composition-animation.md)
