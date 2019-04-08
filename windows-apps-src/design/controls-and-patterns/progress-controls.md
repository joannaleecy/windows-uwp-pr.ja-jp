---
Description: プログレス コントロールは、時間のかかる操作が進行中であることを示すフィードバックをユーザーに返します。
title: プログレス コントロールのガイドライン
ms.assetid: FD53B716-C43D-408D-8B07-522BC1F3DF9D
label: Progress controls
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: kisai
design-contact: jeffarn
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a162d992390e8fc7d05d52303ec292fcf8e920a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634427"
---
# <a name="progress-controls"></a><span data-ttu-id="cf46f-104">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="cf46f-104">Progress controls</span></span>

 

<span data-ttu-id="cf46f-105">プログレス コントロールは、時間のかかる操作が進行中であることを示すフィードバックをユーザーに返します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-105">A progress control provides feedback to the user that a long-running operation is underway.</span></span> <span data-ttu-id="cf46f-106">使用されているインジケーターに応じて、進行状況インジケーターが表示されているときはユーザーはアプリを操作できないことを知らせたり、待ち時間の長さを示したりできます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-106">It can mean that the user cannot interact with the app when the progress indicator is visible, and can also indicate how long the wait time might be, depending on the indicator used.</span></span>

> <span data-ttu-id="cf46f-107">**重要な API**:[ProgressBar クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)、 [IsIndeterminate プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.isindeterminate.aspx)、 [ProgressRing クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)、 [IsActive プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.isactive.aspx)</span><span class="sxs-lookup"><span data-stu-id="cf46f-107">**Important APIs**: [ProgressBar class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx), [IsIndeterminate property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.isindeterminate.aspx), [ProgressRing class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx), [IsActive property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.isactive.aspx)</span></span>

## <a name="types-of-progress"></a><span data-ttu-id="cf46f-108">プログレス コントロールの種類</span><span class="sxs-lookup"><span data-stu-id="cf46f-108">Types of progress</span></span>

<span data-ttu-id="cf46f-109">操作が進行中であることをユーザー示すコントロールは 2 つあります。ProgressBar または ProgressRing を使います。</span><span class="sxs-lookup"><span data-stu-id="cf46f-109">There are two controls to show the user that an operation is underway – either through a ProgressBar or through a ProgressRing.</span></span>

-   <span data-ttu-id="cf46f-110">ProgressBar の*確定*状態では、タスクが完了しているパーセンテージを表示します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-110">The ProgressBar *determinate* state shows the percentage completed of a task.</span></span> <span data-ttu-id="cf46f-111">これは、期間がわかっている操作の間に使いますが、その進行状況でユーザーのアプリとのやり取りはブロックされません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-111">This should be used during an operation whose duration is known, but it's progress should not block the user's interaction with the app.</span></span>
-   <span data-ttu-id="cf46f-112">ProgressBar の*不確定*状態は、操作が進行中であることを示します。ユーザーのアプリとのやり取りはブロックされず、完了時間は不明です。</span><span class="sxs-lookup"><span data-stu-id="cf46f-112">The ProgressBar *indeterminate* state shows that an operation is underway, does not block user interaction with the app, and its completion time is unknown.</span></span>
-   <span data-ttu-id="cf46f-113">ProgressRing には*不確定*状態だけがあり、操作が完了するまでさらにユーザーのやり取りがブロックされるときに使います。</span><span class="sxs-lookup"><span data-stu-id="cf46f-113">The ProgressRing only has an *indeterminate* state, and should be used when any further user interaction is blocked until the operation has completed.</span></span>

<span data-ttu-id="cf46f-114">なお、プログレス コントロールは読み取り専用で、対話型ではありません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-114">Additionally, a progress control is read only, and not interactive.</span></span> <span data-ttu-id="cf46f-115">つまり、ユーザーはこれらのコントロールを直接呼び出したり、使ったりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-115">Meaning that the user cannot invoke or use these controls directly.</span></span>

![ProgressBar 状態](images/ProgressBar_TwoStates.png)

<span data-ttu-id="cf46f-117">*上から下、不確定な ProgressBar と不確定の ProgressBar*</span><span class="sxs-lookup"><span data-stu-id="cf46f-117">*Top to bottom - Indeterminate ProgressBar and a determinate ProgressBar*</span></span>

![ProgressRing 状態](images/ProgressRing_SingleState.png)

<span data-ttu-id="cf46f-119">*中間の ProgressRing*</span><span class="sxs-lookup"><span data-stu-id="cf46f-119">*An indeterminate ProgressRing*</span></span>

## <a name="examples"></a><span data-ttu-id="cf46f-120">例</span><span class="sxs-lookup"><span data-stu-id="cf46f-120">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="cf46f-121">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="cf46f-121">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="cf46f-122"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ProgressBar">ProgressBar</a> または <a href="xamlcontrolsgallery:/item/ProgressRing">ProgressRing</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="cf46f-122">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ProgressBar">ProgressBar</a> or <a href="xamlcontrolsgallery:/item/ProgressRing">ProgressRing</a> in action.</span></span></p>
    <ul>
    <li><span data-ttu-id="cf46f-123"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="cf46f-123"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="cf46f-124"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="cf46f-124"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="when-to-use-each-control"></a><span data-ttu-id="cf46f-125">各コントロールを使う状況</span><span class="sxs-lookup"><span data-stu-id="cf46f-125">When to use each control</span></span>

<span data-ttu-id="cf46f-126">何が起こっているかを表示するとき、どのコントロールを使うか、どの状態 (確定または不確定) を使うかが明白でない場合があります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-126">It's not always obvious what control or what state (determinate vs indeterminate) to use when trying to show something is happening.</span></span> <span data-ttu-id="cf46f-127">タスクの内容が明らかでプログレス コントロールを使う必要がないときもあり、プログレス コントロールを使う場合でも、どういう操作が進行中かをユーザーに説明するために 1 行のテキストが必要なときもあります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-127">Sometimes a task is obvious enough that it doesn’t require a progress control at all – and sometimes even if a progress control is used, a line of text is still necessary in order to explain to the user what operation is underway.</span></span>

### <a name="progressbar"></a><span data-ttu-id="cf46f-128">ProgressBar</span><span class="sxs-lookup"><span data-stu-id="cf46f-128">ProgressBar</span></span>
-   <span data-ttu-id="cf46f-129">**コントロールは、定義された期間または予測可能な終了にありますか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-129">**Does the control have a defined duration or predictable end?**</span></span>

    <span data-ttu-id="cf46f-130">確定 ProgressBar を使用し、パーセンテージや値を適宜更新します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-130">Use a determinate ProgressBar then, and update the percentage or value accordingly.</span></span>

-   <span data-ttu-id="cf46f-131">**ユーザーは、操作の進行状況を監視することがなく続行しますか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-131">**Can the user continue without having to monitor the operation’s progress?**</span></span>

    <span data-ttu-id="cf46f-132">ProgressBar の使用中、やり取りは非モーダルであり、通常はその操作が完了するまでユーザーがブロックされることはありません。操作が完了するまで、その他の方法でアプリを使い続けることができます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-132">When a ProgressBar is in use, interaction is non-modal, typically meaning that the user is not blocked by that operation’s completion, and can continue to use the app in other ways until that aspect has completed.</span></span>

-   <span data-ttu-id="cf46f-133">**キーワード**</span><span class="sxs-lookup"><span data-stu-id="cf46f-133">**Keywords**</span></span>

    <span data-ttu-id="cf46f-134">操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressBar の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="cf46f-134">If your operation falls around these keywords, or if you’re showing text that alongside the progress operation that matches these keywords; consider using a ProgressBar:</span></span>

    - <span data-ttu-id="cf46f-135">*読み込んでいます.*</span><span class="sxs-lookup"><span data-stu-id="cf46f-135">*Loading...*</span></span>
    - <span data-ttu-id="cf46f-136">*取得します。*</span><span class="sxs-lookup"><span data-stu-id="cf46f-136">*Retrieving*</span></span>
    - <span data-ttu-id="cf46f-137">*作業しています.*</span><span class="sxs-lookup"><span data-stu-id="cf46f-137">*Working...*</span></span>

### <a name="progressring"></a><span data-ttu-id="cf46f-138">ProgressRing</span><span class="sxs-lookup"><span data-stu-id="cf46f-138">ProgressRing</span></span>

-   <span data-ttu-id="cf46f-139">**操作が原因がユーザーに続行を待機するでしょうか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-139">**Will the operation cause the user to wait to continue?**</span></span>

    <span data-ttu-id="cf46f-140">操作によって、操作が完了するまでアプリとのすべて (または大部分) のやり取りを待つことが必要になる場合は、ProgressRing の方が適しています。</span><span class="sxs-lookup"><span data-stu-id="cf46f-140">If an operation requires all (or a large portion of) interaction with the app to wait until it has been completed, then the ProgressRing is the better choice.</span></span> <span data-ttu-id="cf46f-141">ProgressRing コントロールはモーダル操作向けに使われます。つまり、ProgressRing が消えるまでユーザーはブロックされます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-141">The ProgressRing control is used for modal interactions, meaning that the user is blocked until the ProgressRing disappears.</span></span>

-   <span data-ttu-id="cf46f-142">**アプリがタスクを実行するユーザーを待機しているでしょうか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-142">**Is the app waiting for the user to complete a task?**</span></span>

    <span data-ttu-id="cf46f-143">待っている場合は、ProgressRing を使って不明の待ち時間をユーザーに示します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-143">If so, use a ProgressRing, as they’re meant to indicate an unknown wait time for the user.</span></span>

-   <span data-ttu-id="cf46f-144">**キーワード**</span><span class="sxs-lookup"><span data-stu-id="cf46f-144">**Keywords**</span></span>

    <span data-ttu-id="cf46f-145">操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressRing の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="cf46f-145">If your operation falls around these keywords, or if you’re showing text alongside the progress operation that matches these keywords; consider using a ProgressRing:</span></span>

    - <span data-ttu-id="cf46f-146">*更新します。*</span><span class="sxs-lookup"><span data-stu-id="cf46f-146">*Refreshing*</span></span>
    - <span data-ttu-id="cf46f-147">*サインインしています.*</span><span class="sxs-lookup"><span data-stu-id="cf46f-147">*Signing in...*</span></span>
    - <span data-ttu-id="cf46f-148">*接続しています.*</span><span class="sxs-lookup"><span data-stu-id="cf46f-148">*Connecting...*</span></span>

### <a name="no-progress-indication-necessary"></a><span data-ttu-id="cf46f-149">進行状況を示す必要なし</span><span class="sxs-lookup"><span data-stu-id="cf46f-149">No progress indication necessary</span></span>
-   <span data-ttu-id="cf46f-150">**ユーザーは、何かが発生していることを把握する必要がありますか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-150">**Does the user need to know that something is happening?**</span></span>

    <span data-ttu-id="cf46f-151">たとえば、アプリがバックグラウンドで何かをダウンロードしていて、ダウンロードを開始したのがユーザーでない場合、ユーザーは必ずしもそのことを知る必要がありません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-151">For example, if the app is downloading something in the background and the user didn’t initiate the download, the user doesn’t necessarily need to know about it.</span></span>

-   <span data-ttu-id="cf46f-152">**操作内のユーザーに (ただし、まだいくつかの) 最小限の関心のある、ユーザー アクティビティをブロックしないバック グラウンド アクティビティとは**</span><span class="sxs-lookup"><span data-stu-id="cf46f-152">**Is the operation a background activity that doesn't block user activity and is of minimal (but still some) interest to the user?**</span></span>

    <span data-ttu-id="cf46f-153">アプリが、常に見えている必要はないものの、進行状況を表示する必要はあるタスクを実行している場合は、テキストを使います。</span><span class="sxs-lookup"><span data-stu-id="cf46f-153">Use text when your app is performing tasks that don't have to be visible all the time, but you still need to show the status.</span></span>

-   <span data-ttu-id="cf46f-154">**ユーザーのみに注意、操作を完了しますか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-154">**Does the user only care about the completion of the operation?**</span></span>

    <span data-ttu-id="cf46f-155">操作が完了したときだけ通知を表示するか、操作がすぐに完了したというビジュアルを表示し、最後の仕上げをバック グラウンドで実行することが最良のときがあります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-155">Sometimes it’s best to show a notice only when the operation is completed, or give a visual that the operation has been completed immediately, and run the finishing touches in the background.</span></span>

## <a name="progress-controls-best-practices"></a><span data-ttu-id="cf46f-156">プログレス コントロールのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="cf46f-156">Progress controls best practices</span></span>

<span data-ttu-id="cf46f-157">これらのさまざまなプログレス コントロールを使用する状況と場所の視覚的な表現をいくつか表示することが最良のときがあります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-157">Sometimes it’s best to see some visual representations of when and where to use these different progress controls:</span></span>

<span data-ttu-id="cf46f-158">**ProgressBar の不確定です。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-158">**ProgressBar - Determinate**</span></span>

![ProgressBar の確定状態の例](images/PB_DeterminateExample.png)

<span data-ttu-id="cf46f-160">最初の例は確定 ProgressBar です。</span><span class="sxs-lookup"><span data-stu-id="cf46f-160">The first example is the determinate ProgressBar.</span></span> <span data-ttu-id="cf46f-161">操作の期間がわかっていて、インストール、ダウンロード、設定などを行うときは、確定 ProgressBar が最良です。</span><span class="sxs-lookup"><span data-stu-id="cf46f-161">When the duration of the operation is known, when installing, downloading, setting up, etc; a determinate ProgressBar is best.</span></span>

<span data-ttu-id="cf46f-162">**ProgressBar の不確定**</span><span class="sxs-lookup"><span data-stu-id="cf46f-162">**ProgressBar - Indeterminate**</span></span>

![ProgressBar の不確定状態の例](images/PB_IndeterminateExample.png)

<span data-ttu-id="cf46f-164">操作にどの程度の時間がかかるかがわからないときは、不確定 ProgressBar を使います。</span><span class="sxs-lookup"><span data-stu-id="cf46f-164">When it is not known how long the operation will take, use an indeterminate ProgressBar.</span></span> <span data-ttu-id="cf46f-165">不確定 ProgressBar は、仮想化されたリストに入力し、不確定 ProgressBar から確定 ProgressBar への滑らかな視覚的な遷移を作成するときにも適切です。</span><span class="sxs-lookup"><span data-stu-id="cf46f-165">Indeterminate ProgressBars are also good when filling a virtualized list, and creating a smooth visual transition between an indeterminate to determinate ProgressBar.</span></span>

-   <span data-ttu-id="cf46f-166">**操作は、仮想化されたコレクション内にあるでしょうか。**</span><span class="sxs-lookup"><span data-stu-id="cf46f-166">**Is the operation in a virtualized collection?**</span></span>

    <span data-ttu-id="cf46f-167">その場合は、各リスト項目に進行状況インジケーターを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="cf46f-167">If so, do not put a progress indicator on each list item as they appear.</span></span> <span data-ttu-id="cf46f-168">代わりに ProgressBar を使い、読み込まれている項目のコレクションの一番上にそれを配置して、項目が取得されていることを示します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-168">Instead, use a ProgressBar and place it at the top of the collection of items being loaded in, to show that the items are being fetched.</span></span>

<span data-ttu-id="cf46f-169">**ProgressRing - 不確定**</span><span class="sxs-lookup"><span data-stu-id="cf46f-169">**ProgressRing - Indeterminate**</span></span>

![ProgressRing の不確定状態の例](images/PR_IndeterminateExample.png)

<span data-ttu-id="cf46f-171">ユーザーのそれ以上のアプリとのやり取りが停止されたとき、またはアプリがユーザーの入力を待っているときは、不確定 ProgressRing が使われます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-171">The indeterminate ProgressRing is used when any further user interaction with the app is halted, or the app is waiting for the user’s input to continue.</span></span> <span data-ttu-id="cf46f-172">上記の「サインインしています…」の例は、</span><span class="sxs-lookup"><span data-stu-id="cf46f-172">The “signing in…”</span></span> <span data-ttu-id="cf46f-173">ProgressRing の完全なシナリオであり、ユーザーはサインインが完了するまでアプリの使用を続けることはできません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-173">example above is a perfect scenario for the ProgressRing, the user cannot continue using the app until the sign is has completed.</span></span>

## <a name="customizing-a-progress-control"></a><span data-ttu-id="cf46f-174">プログレス コントロールのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="cf46f-174">Customizing a progress control</span></span>

<span data-ttu-id="cf46f-175">両方のプログレス コントロールはかなりシンプルですが、コントロールの視覚的な機能の一部はカスタマイズの方法が明白ではありません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-175">Both progress controls are rather simple; but some visual features of the controls are not obvious to customize.</span></span>

<span data-ttu-id="cf46f-176">**ProgressRing をサイズ変更**</span><span class="sxs-lookup"><span data-stu-id="cf46f-176">**Sizing the ProgressRing**</span></span>

<span data-ttu-id="cf46f-177">ProgressRing は必要なサイズに変更できますが、20 x 20 epx までしか縮小できません。</span><span class="sxs-lookup"><span data-stu-id="cf46f-177">The ProgressRing can be sized as large as you want, but can only be as small as 20x20epx.</span></span> <span data-ttu-id="cf46f-178">ProgressRing のサイズを変更するには、高さと幅を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-178">In order to resize a ProgressRing, you must set its height and width.</span></span> <span data-ttu-id="cf46f-179">高さまたは幅だけが設定された場合、最小サイズ (20 x 20 epx) が想定されます。逆に高さと幅が 2 つの異なるサイズに設定された場合、小さい方のサイズが想定されます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-179">If only height or width are set, the control will assume minimum sizing (20x20epx) – conversely if the height and width are set to two different sizes, the smaller of the sizes will be assumed.</span></span>
<span data-ttu-id="cf46f-180">ProgressRing を必要な大きさにするには、高さと幅を同じ値に設定してください。</span><span class="sxs-lookup"><span data-stu-id="cf46f-180">To ensure your ProgressRing is correct for your needs, set both the height and the width to the same value:</span></span>

```XAML
<ProgressRing Height="100" Width="100"/>
```

<span data-ttu-id="cf46f-181">ProgressRing を表示してアニメーション化するには、IsActive プロパティを true に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf46f-181">To make your ProgressRing visible, and animate, you must set the IsActive property to true:</span></span>

```XAML
<ProgressRing IsActive="True" Height="100" Width="100"/>
```

```C#
progressRing.IsActive = true;
```

<span data-ttu-id="cf46f-182">**進行状況コントロールを色分け表示**</span><span class="sxs-lookup"><span data-stu-id="cf46f-182">**Coloring the progress controls**</span></span>

<span data-ttu-id="cf46f-183">既定では、プログレス コントロールのメインの色はシステムのアクセント カラーに設定されます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-183">By default, the main coloring of the progress controls is set to the accent color of the system.</span></span> <span data-ttu-id="cf46f-184">このブラシを上書きするには、どちらかのコントロールの foreground プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-184">To override this brush simply change the foreground property on either control.</span></span>

```XAML
<ProgressRing IsActive="True" Height="100" Width="100" Foreground="Blue"/>
<ProgressBar Width="100" Foreground="Green"/>
```

<span data-ttu-id="cf46f-185">ProgressRing の前景色を変更すると、ドットの色が変更されます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-185">Changing the foreground color for the ProgressRing will change the colors of the dots.</span></span> <span data-ttu-id="cf46f-186">ProgressBar の foreground プロパティを変更すると、バーの塗りつぶしの色が変更されます。バーの塗りつぶされない部分を変更するには、background プロパティを上書きします。</span><span class="sxs-lookup"><span data-stu-id="cf46f-186">The foreground property for the ProgressBar will change the fill color of the bar – to alter the unfilled portion of the bar, simply override the background property.</span></span>

<span data-ttu-id="cf46f-187">**待機カーソルを表示**</span><span class="sxs-lookup"><span data-stu-id="cf46f-187">**Showing a wait cursor**</span></span>

<span data-ttu-id="cf46f-188">アプリまたは操作で処理に少し時間がかかり、待機カーソルが表示されているアプリまたは領域では待機カーソルが消えるまでやり取りできないことをユーザーに示す必要があるときは、簡潔な待機カーソルを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf46f-188">Sometimes it’s best to just show a brief wait cursor, when the app or operation needs time to think, and you need to indicate to the user that the app or area where the wait cursor is visible should not be interacted with until the wait cursor has disappeared.</span></span>

```C#
Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 10);
```

## <a name="get-the-sample-code"></a><span data-ttu-id="cf46f-189">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="cf46f-189">Get the sample code</span></span>

- <span data-ttu-id="cf46f-190">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="cf46f-190">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="cf46f-191">関連記事</span><span class="sxs-lookup"><span data-stu-id="cf46f-191">Related articles</span></span>

- [<span data-ttu-id="cf46f-192">ProgressBar クラス</span><span class="sxs-lookup"><span data-stu-id="cf46f-192">ProgressBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227529)
- [<span data-ttu-id="cf46f-193">ProgressRing クラス</span><span class="sxs-lookup"><span data-stu-id="cf46f-193">ProgressRing class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227538)

<span data-ttu-id="cf46f-194">**開発者向け (XAML)**</span><span class="sxs-lookup"><span data-stu-id="cf46f-194">**For developers (XAML)**</span></span>
- [<span data-ttu-id="cf46f-195">進行状況コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="cf46f-195">Adding progress controls</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh780651)
- [<span data-ttu-id="cf46f-196">Windows Phone のカスタムの不確定な進行状況バーを作成する方法</span><span class="sxs-lookup"><span data-stu-id="cf46f-196">How to create a custom indeterminate progress bar for Windows Phone</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=392426)
