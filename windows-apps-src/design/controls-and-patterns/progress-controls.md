---
author: serenaz
Description: A progress control provides feedback to the user that a long-running operation is underway.
title: プログレス コントロールのガイドライン
ms.assetid: FD53B716-C43D-408D-8B07-522BC1F3DF9D
label: Progress controls
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: jeffarn
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 7010ac62e2311e4882105db992a43007ed0276f8
ms.sourcegitcommit: b8c77ac8e40a27cf762328d730c121c28de5fbc4
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2018
ms.locfileid: "1672676"
---
# <a name="progress-controls"></a><span data-ttu-id="fa05a-103">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="fa05a-103">Progress controls</span></span>

 

<span data-ttu-id="fa05a-104">プログレス コントロールは、時間のかかる操作が進行中であることを示すフィードバックをユーザーに返します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-104">A progress control provides feedback to the user that a long-running operation is underway.</span></span> <span data-ttu-id="fa05a-105">使用されているインジケーターに応じて、進行状況インジケーターが表示されているときはユーザーはアプリを操作できないことを知らせたり、待ち時間の長さを示したりできます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-105">It can mean that the user cannot interact with the app when the progress indicator is visible, and can also indicate how long the wait time might be, depending on the indicator used.</span></span>

> <span data-ttu-id="fa05a-106">**重要な API**: [ProgressBar クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)、[IsIndeterminate プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.isindeterminate.aspx)、[ProgressRing クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)、[IsActive プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.isactive.aspx)</span><span class="sxs-lookup"><span data-stu-id="fa05a-106">**Important APIs**: [ProgressBar class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx), [IsIndeterminate property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.isindeterminate.aspx), [ProgressRing class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx), [IsActive property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.isactive.aspx)</span></span>

## <a name="types-of-progress"></a><span data-ttu-id="fa05a-107">プログレス コントロールの種類</span><span class="sxs-lookup"><span data-stu-id="fa05a-107">Types of progress</span></span>

<span data-ttu-id="fa05a-108">操作が進行中であることをユーザー示すコントロールは 2 つあります。ProgressBar または ProgressRing を使います。</span><span class="sxs-lookup"><span data-stu-id="fa05a-108">There are two controls to show the user that an operation is underway – either through a ProgressBar or through a ProgressRing.</span></span>

-   <span data-ttu-id="fa05a-109">ProgressBar の*確定*状態では、タスクが完了しているパーセンテージを表示します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-109">The ProgressBar *determinate* state shows the percentage completed of a task.</span></span> <span data-ttu-id="fa05a-110">これは、期間がわかっている操作の間に使いますが、その進行状況でユーザーのアプリとのやり取りはブロックされません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-110">This should be used during an operation whose duration is known, but it's progress should not block the user's interaction with the app.</span></span>
-   <span data-ttu-id="fa05a-111">ProgressBar の*不確定*状態は、操作が進行中であることを示します。ユーザーのアプリとのやり取りはブロックされず、完了時間は不明です。</span><span class="sxs-lookup"><span data-stu-id="fa05a-111">The ProgressBar *indeterminate* state shows that an operation is underway, does not block user interaction with the app, and its completion time is unknown.</span></span>
-   <span data-ttu-id="fa05a-112">ProgressRing には*不確定*状態だけがあり、操作が完了するまでさらにユーザーのやり取りがブロックされるときに使います。</span><span class="sxs-lookup"><span data-stu-id="fa05a-112">The ProgressRing only has an *indeterminate* state, and should be used when any further user interaction is blocked until the operation has completed.</span></span>

<span data-ttu-id="fa05a-113">なお、プログレス コントロールは読み取り専用で、対話型ではありません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-113">Additionally, a progress control is read only, and not interactive.</span></span> <span data-ttu-id="fa05a-114">つまり、ユーザーはこれらのコントロールを直接呼び出したり、使ったりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-114">Meaning that the user cannot invoke or use these controls directly.</span></span>

![ProgressBar 状態](images/ProgressBar_TwoStates.png)

*<span data-ttu-id="fa05a-116">上から下へ、不確定 ProgressBar と確定 ProgressBar</span><span class="sxs-lookup"><span data-stu-id="fa05a-116">Top to bottom - Indeterminate ProgressBar and a determinate ProgressBar</span></span>*

![ProgressRing 状態](images/ProgressRing_SingleState.png)

*<span data-ttu-id="fa05a-118">不確定の ProgressRing</span><span class="sxs-lookup"><span data-stu-id="fa05a-118">An indeterminate ProgressRing</span></span>*

## <a name="examples"></a><span data-ttu-id="fa05a-119">例</span><span class="sxs-lookup"><span data-stu-id="fa05a-119">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="fa05a-120">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="fa05a-120">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="fa05a-121"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ProgressBar">ProgressBar</a> または <a href="xamlcontrolsgallery:/item/ProgressRing">ProgressRing</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="fa05a-121">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ProgressBar">ProgressBar</a> or <a href="xamlcontrolsgallery:/item/ProgressRing">ProgressRing</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="fa05a-122">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="fa05a-122">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="fa05a-123">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="fa05a-123">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="when-to-use-each-control"></a><span data-ttu-id="fa05a-124">各コントロールを使う状況</span><span class="sxs-lookup"><span data-stu-id="fa05a-124">When to use each control</span></span>

<span data-ttu-id="fa05a-125">何が起こっているかを表示するとき、どのコントロールを使うか、どの状態 (確定または不確定) を使うかが明白でない場合があります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-125">It's not always obvious what control or what state (determinate vs indeterminate) to use when trying to show something is happening.</span></span> <span data-ttu-id="fa05a-126">タスクの内容が明らかでプログレス コントロールを使う必要がないときもあり、プログレス コントロールを使う場合でも、どういう操作が進行中かをユーザーに説明するために 1 行のテキストが必要なときもあります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-126">Sometimes a task is obvious enough that it doesn’t require a progress control at all – and sometimes even if a progress control is used, a line of text is still necessary in order to explain to the user what operation is underway.</span></span>

### <a name="progressbar"></a><span data-ttu-id="fa05a-127">ProgressBar</span><span class="sxs-lookup"><span data-stu-id="fa05a-127">ProgressBar</span></span>
-   **<span data-ttu-id="fa05a-128">コントロールには定義された期間や予測可能な終了時期があるか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-128">Does the control have a defined duration or predictable end?</span></span>**

    <span data-ttu-id="fa05a-129">確定 ProgressBar を使用し、パーセンテージや値を適宜更新します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-129">Use a determinate ProgressBar then, and update the percentage or value accordingly.</span></span>

-   **<span data-ttu-id="fa05a-130">ユーザーは操作の進行状況を監視しなくても操作を続けることができるか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-130">Can the user continue without having to monitor the operation’s progress?</span></span>**

    <span data-ttu-id="fa05a-131">ProgressBar の使用中、やり取りは非モーダルであり、通常はその操作が完了するまでユーザーがブロックされることはありません。操作が完了するまで、その他の方法でアプリを使い続けることができます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-131">When a ProgressBar is in use, interaction is non-modal, typically meaning that the user is not blocked by that operation’s completion, and can continue to use the app in other ways until that aspect has completed.</span></span>

-   **<span data-ttu-id="fa05a-132">キーワード</span><span class="sxs-lookup"><span data-stu-id="fa05a-132">Keywords</span></span>**

    <span data-ttu-id="fa05a-133">操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressBar の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="fa05a-133">If your operation falls around these keywords, or if you’re showing text that alongside the progress operation that matches these keywords; consider using a ProgressBar:</span></span>

    - *<span data-ttu-id="fa05a-134">読み込んでいます...</span><span class="sxs-lookup"><span data-stu-id="fa05a-134">Loading...</span></span>*
    - *<span data-ttu-id="fa05a-135">取得しています</span><span class="sxs-lookup"><span data-stu-id="fa05a-135">Retrieving</span></span>*
    - *<span data-ttu-id="fa05a-136">処理しています...</span><span class="sxs-lookup"><span data-stu-id="fa05a-136">Working...</span></span>*

### <a name="progressring"></a><span data-ttu-id="fa05a-137">ProgressRing</span><span class="sxs-lookup"><span data-stu-id="fa05a-137">ProgressRing</span></span>

-   **<span data-ttu-id="fa05a-138">この操作によってユーザーは続行できるまで待つことになるか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-138">Will the operation cause the user to wait to continue?</span></span>**

    <span data-ttu-id="fa05a-139">操作によって、操作が完了するまでアプリとのすべて (または大部分) のやり取りを待つことが必要になる場合は、ProgressRing の方が適しています。</span><span class="sxs-lookup"><span data-stu-id="fa05a-139">If an operation requires all (or a large portion of) interaction with the app to wait until it has been completed, then the ProgressRing is the better choice.</span></span> <span data-ttu-id="fa05a-140">ProgressRing コントロールはモーダル操作向けに使われます。つまり、ProgressRing が消えるまでユーザーはブロックされます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-140">The ProgressRing control is used for modal interactions, meaning that the user is blocked until the ProgressRing disappears.</span></span>

-   **<span data-ttu-id="fa05a-141">アプリはユーザーがタスクを完了するのを待っているか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-141">Is the app waiting for the user to complete a task?</span></span>**

    <span data-ttu-id="fa05a-142">待っている場合は、ProgressRing を使って不明の待ち時間をユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-142">If so, use a ProgressRing, as they’re meant to indicate an unknown wait time for the user.</span></span>

-   **<span data-ttu-id="fa05a-143">キーワード</span><span class="sxs-lookup"><span data-stu-id="fa05a-143">Keywords</span></span>**

    <span data-ttu-id="fa05a-144">操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressRing の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="fa05a-144">If your operation falls around these keywords, or if you’re showing text alongside the progress operation that matches these keywords; consider using a ProgressRing:</span></span>

    - *<span data-ttu-id="fa05a-145">更新しています</span><span class="sxs-lookup"><span data-stu-id="fa05a-145">Refreshing</span></span>*
    - *<span data-ttu-id="fa05a-146">サインインしています...</span><span class="sxs-lookup"><span data-stu-id="fa05a-146">Signing in...</span></span>*
    - *<span data-ttu-id="fa05a-147">接続しています...</span><span class="sxs-lookup"><span data-stu-id="fa05a-147">Connecting...</span></span>*

### <a name="no-progress-indication-necessary"></a><span data-ttu-id="fa05a-148">進行状況を示す必要なし</span><span class="sxs-lookup"><span data-stu-id="fa05a-148">No progress indication necessary</span></span>
-   **<span data-ttu-id="fa05a-149">何かが行われていることをユーザーが知る必要があるか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-149">Does the user need to know that something is happening?</span></span>**

    <span data-ttu-id="fa05a-150">たとえば、アプリがバックグラウンドで何かをダウンロードしていて、ダウンロードを開始したのがユーザーでない場合、ユーザーは必ずしもそのことを知る必要がありません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-150">For example, if the app is downloading something in the background and the user didn’t initiate the download, the user doesn’t necessarily need to know about it.</span></span>

-   **<span data-ttu-id="fa05a-151">操作が、ユーザーのアクティビティをブロックしないバックグラウンド アクティビティであり、ユーザーにはほとんど関与しない (少しだけ関与する) か?</span><span class="sxs-lookup"><span data-stu-id="fa05a-151">Is the operation a background activity that doesn't block user activity and is of minimal (but still some) interest to the user?</span></span>**

    <span data-ttu-id="fa05a-152">アプリが、常に見えている必要はないものの、進行状況を表示する必要はあるタスクを実行している場合は、テキストを使います。</span><span class="sxs-lookup"><span data-stu-id="fa05a-152">Use text when your app is performing tasks that don't have to be visible all the time, but you still need to show the status.</span></span>

-   **<span data-ttu-id="fa05a-153">ユーザーは操作の完了だけを気にしているか?</span><span class="sxs-lookup"><span data-stu-id="fa05a-153">Does the user only care about the completion of the operation?</span></span>**

    <span data-ttu-id="fa05a-154">操作が完了したときだけ通知を表示するか、操作がすぐに完了したというビジュアルを表示し、最後の仕上げをバック グラウンドで実行することが最良のときがあります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-154">Sometimes it’s best to show a notice only when the operation is completed, or give a visual that the operation has been completed immediately, and run the finishing touches in the background.</span></span>

## <a name="progress-controls-best-practices"></a><span data-ttu-id="fa05a-155">プログレス コントロールのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="fa05a-155">Progress controls best practices</span></span>

<span data-ttu-id="fa05a-156">これらのさまざまなプログレス コントロールを使用する状況と場所の視覚的な表現をいくつか表示することが最良のときがあります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-156">Sometimes it’s best to see some visual representations of when and where to use these different progress controls:</span></span>

**<span data-ttu-id="fa05a-157">ProgressBar - 確定</span><span class="sxs-lookup"><span data-stu-id="fa05a-157">ProgressBar - Determinate</span></span>**

![ProgressBar の確定状態の例](images/PB_DeterminateExample.png)

<span data-ttu-id="fa05a-159">最初の例は確定 ProgressBar です。</span><span class="sxs-lookup"><span data-stu-id="fa05a-159">The first example is the determinate ProgressBar.</span></span> <span data-ttu-id="fa05a-160">操作の期間がわかっていて、インストール、ダウンロード、設定などを行うときは、確定 ProgressBar が最良です。</span><span class="sxs-lookup"><span data-stu-id="fa05a-160">When the duration of the operation is known, when installing, downloading, setting up, etc; a determinate ProgressBar is best.</span></span>

**<span data-ttu-id="fa05a-161">ProgressBar - 不確定</span><span class="sxs-lookup"><span data-stu-id="fa05a-161">ProgressBar - Indeterminate</span></span>**

![ProgressBar の不確定状態の例](images/PB_IndeterminateExample.png)

<span data-ttu-id="fa05a-163">操作にどの程度の時間がかかるかがわからないときは、不確定 ProgressBar を使います。</span><span class="sxs-lookup"><span data-stu-id="fa05a-163">When it is not known how long the operation will take, use an indeterminate ProgressBar.</span></span> <span data-ttu-id="fa05a-164">不確定 ProgressBar は、仮想化されたリストに入力し、不確定 ProgressBar から確定 ProgressBar への滑らかな視覚的な遷移を作成するときにも適切です。</span><span class="sxs-lookup"><span data-stu-id="fa05a-164">Indeterminate ProgressBars are also good when filling a virtualized list, and creating a smooth visual transition between an indeterminate to determinate ProgressBar.</span></span>

-   **<span data-ttu-id="fa05a-165">仮想化されたコレクション内の操作か?</span><span class="sxs-lookup"><span data-stu-id="fa05a-165">Is the operation in a virtualized collection?</span></span>**

    <span data-ttu-id="fa05a-166">その場合は、各リスト項目に進行状況インジケーターを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="fa05a-166">If so, do not put a progress indicator on each list item as they appear.</span></span> <span data-ttu-id="fa05a-167">代わりに ProgressBar を使い、読み込まれている項目のコレクションの一番上にそれを配置して、項目が取得されていることを示します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-167">Instead, use a ProgressBar and place it at the top of the collection of items being loaded in, to show that the items are being fetched.</span></span>

**<span data-ttu-id="fa05a-168">ProgressRing - 不確定</span><span class="sxs-lookup"><span data-stu-id="fa05a-168">ProgressRing - Indeterminate</span></span>**

![ProgressRing の不確定状態の例](images/PR_IndeterminateExample.png)

<span data-ttu-id="fa05a-170">ユーザーのそれ以上のアプリとのやり取りが停止されたとき、またはアプリがユーザーの入力を待っているときは、不確定 ProgressRing が使われます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-170">The indeterminate ProgressRing is used when any further user interaction with the app is halted, or the app is waiting for the user’s input to continue.</span></span> <span data-ttu-id="fa05a-171">上記の「サインインしています…」の例は、</span><span class="sxs-lookup"><span data-stu-id="fa05a-171">The “signing in…”</span></span> <span data-ttu-id="fa05a-172">ProgressRing の完全なシナリオであり、ユーザーはサインインが完了するまでアプリの使用を続けることはできません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-172">example above is a perfect scenario for the ProgressRing, the user cannot continue using the app until the sign is has completed.</span></span>

## <a name="customizing-a-progress-control"></a><span data-ttu-id="fa05a-173">プログレス コントロールのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="fa05a-173">Customizing a progress control</span></span>

<span data-ttu-id="fa05a-174">両方のプログレス コントロールはかなりシンプルですが、コントロールの視覚的な機能の一部はカスタマイズの方法が明白ではありません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-174">Both progress controls are rather simple; but some visual features of the controls are not obvious to customize.</span></span>

**<span data-ttu-id="fa05a-175">ProgressRing のサイズの設定</span><span class="sxs-lookup"><span data-stu-id="fa05a-175">Sizing the ProgressRing</span></span>**

<span data-ttu-id="fa05a-176">ProgressRing は必要なサイズに変更できますが、20 x 20 epx までしか縮小できません。</span><span class="sxs-lookup"><span data-stu-id="fa05a-176">The ProgressRing can be sized as large as you want, but can only be as small as 20x20epx.</span></span> <span data-ttu-id="fa05a-177">ProgressRing のサイズを変更するには、高さと幅を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-177">In order to resize a ProgressRing, you must set its height and width.</span></span> <span data-ttu-id="fa05a-178">高さまたは幅だけが設定された場合、最小サイズ (20 x 20 epx) が想定されます。逆に高さと幅が 2 つの異なるサイズに設定された場合、小さい方のサイズが想定されます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-178">If only height or width are set, the control will assume minimum sizing (20x20epx) – conversely if the height and width are set to two different sizes, the smaller of the sizes will be assumed.</span></span>
<span data-ttu-id="fa05a-179">ProgressRing を必要な大きさにするには、高さと幅を同じ値に設定してください。</span><span class="sxs-lookup"><span data-stu-id="fa05a-179">To ensure your ProgressRing is correct for your needs, set both the height and the width to the same value:</span></span>

```XAML
<ProgressRing Height="100" Width="100"/>
```

<span data-ttu-id="fa05a-180">ProgressRing を表示してアニメーション化するには、IsActive プロパティを true に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa05a-180">To make your ProgressRing visible, and animate, you must set the IsActive property to true:</span></span>

```XAML
<ProgressRing IsActive="True" Height="100" Width="100"/>
```

```C#
progressRing.IsActive = true;
```

**<span data-ttu-id="fa05a-181">プログレス コントロールの色の設定</span><span class="sxs-lookup"><span data-stu-id="fa05a-181">Coloring the progress controls</span></span>**

<span data-ttu-id="fa05a-182">既定では、プログレス コントロールのメインの色はシステムのアクセント カラーに設定されます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-182">By default, the main coloring of the progress controls is set to the accent color of the system.</span></span> <span data-ttu-id="fa05a-183">このブラシを上書きするには、どちらかのコントロールの foreground プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="fa05a-183">To override this brush simply change the foreground property on either control.</span></span>

```XAML
<ProgressRing IsActive="True" Height="100" Width="100" Foreground="Blue"/>
<ProgressBar Width="100" Foreground="Green"/>
```

<span data-ttu-id="fa05a-184">ProgressRing の前景色を変更すると、ドットの色が変更されます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-184">Changing the foreground color for the ProgressRing will change the colors of the dots.</span></span> <span data-ttu-id="fa05a-185">ProgressBar の foreground プロパティを変更すると、バーの塗りつぶしの色が変更されます。バーの塗りつぶされない部分を変更するには、background プロパティを上書きします。</span><span class="sxs-lookup"><span data-stu-id="fa05a-185">The foreground property for the ProgressBar will change the fill color of the bar – to alter the unfilled portion of the bar, simply override the background property.</span></span>

**<span data-ttu-id="fa05a-186">待機カーソルの表示</span><span class="sxs-lookup"><span data-stu-id="fa05a-186">Showing a wait cursor</span></span>**

<span data-ttu-id="fa05a-187">アプリまたは操作で処理に少し時間がかかり、待機カーソルが表示されているアプリまたは領域では待機カーソルが消えるまでやり取りできないことをユーザーに示す必要があるときは、簡潔な待機カーソルを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fa05a-187">Sometimes it’s best to just show a brief wait cursor, when the app or operation needs time to think, and you need to indicate to the user that the app or area where the wait cursor is visible should not be interacted with until the wait cursor has disappeared.</span></span>

```C#
Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 10);
```

## <a name="get-the-sample-code"></a><span data-ttu-id="fa05a-188">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="fa05a-188">Get the sample code</span></span>

- <span data-ttu-id="fa05a-189">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="fa05a-189">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="fa05a-190">関連記事</span><span class="sxs-lookup"><span data-stu-id="fa05a-190">Related articles</span></span>

- [<span data-ttu-id="fa05a-191">ProgressBar クラス</span><span class="sxs-lookup"><span data-stu-id="fa05a-191">ProgressBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227529)
- [<span data-ttu-id="fa05a-192">ProgressRing クラス</span><span class="sxs-lookup"><span data-stu-id="fa05a-192">ProgressRing class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227538)

**<span data-ttu-id="fa05a-193">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="fa05a-193">For developers (XAML)</span></span>**
- [<span data-ttu-id="fa05a-194">プログレス コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="fa05a-194">Adding progress controls</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh780651)
- [<span data-ttu-id="fa05a-195">Windows Phone 向けのカスタム進行状況不定バーを作成する方法</span><span class="sxs-lookup"><span data-stu-id="fa05a-195">How to create a custom indeterminate progress bar for Windows Phone</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=392426)