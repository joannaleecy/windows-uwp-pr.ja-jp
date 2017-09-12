---
author: mijacobs
Description: "ダイアログとポップアップは、ユーザーが要求したとき、または通知や許可を必要とする状況が発生したときに表示される一時的な UI 要素です。"
title: "ダイアログとポップアップ"
label: Dialogs
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: a1e7ecd60c960459d8d146bbda0fa6fba4bfc7f6
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="dialogs-and-flyouts"></a><span data-ttu-id="ebd7d-104">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-104">Dialogs and flyouts</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="ebd7d-105">ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-105">Dialogs and flyouts are transient UI elements that appear when something happens that requires notification, approval, or additional information from the user.</span></span>

> <span data-ttu-id="ebd7d-106">**重要な API**: [ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)、[Flyout クラス](https://msdn.microsoft.com/library/windows/apps/dn279496)</span><span class="sxs-lookup"><span data-stu-id="ebd7d-106">**Important APIs**: [ContentDialog class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx), [Flyout class](https://msdn.microsoft.com/library/windows/apps/dn279496)</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b><span data-ttu-id="ebd7d-107">ダイアログ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-107">Dialogs</span></span></b> <br/><br/>
    ![ダイアログの例](images/dialogs/dialog_RS2_delete_file.png)</p>
<p><span data-ttu-id="ebd7d-109">ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-109">Dialogs are modal UI overlays that provide contextual app information.</span></span> <span data-ttu-id="ebd7d-110">ダイアログは、明示的に閉じられるまでアプリ ウィンドウの対話式操作をブロックします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-110">Dialogs block interactions with the app window until being explicitly dismissed.</span></span> <span data-ttu-id="ebd7d-111">多くの場合、ユーザーに何らかの操作を要求します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-111">They often request some kind of action from the user.</span></span>   
</p><br/>

  </div>
  <div class="side-by-side-content-right">
   <p><b><span data-ttu-id="ebd7d-112">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-112">Flyouts</span></span></b> <br/><br/>
   ![ポップアップの例](images/flyout-example2.png)</p>
<p><span data-ttu-id="ebd7d-114">ポップアップ (flyout) は、ユーザーが現在操作している内容に関係する UI を表示する軽量な状況依存のポップアップです。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-114">A flyout is a lightweight contextual popup that displays UI related to what the user is doing.</span></span> <span data-ttu-id="ebd7d-115">このポップアップは、配置ロジックとサイズ設定ロジックを備えており、セカンダリ コントロールを表示する場合、または項目の詳細を表示する場合に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-115">It includes placement and sizing logic, and can be used to reveal a secondary control or show more detail about an item.</span></span>
</p><p><span data-ttu-id="ebd7d-116">ダイアログとは異なり、ポップアップは、それ以外の場所をタップまたはクリックするか、Esc キーまたは戻るボタンを押すか、アプリ ウィンドウのサイズを変更するか、デバイスの向きを変更することで、すばやく閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-116">Unlike a dialog, a flyout can be quickly dismissed by tapping or clicking somewhere outside the flyout, pressing the Escape key or Back button, resizing the app window, or changing the device's orientation.</span></span>
</p><br/>

  </div>
</div>
</div>

## <a name="is-this-the-right-control"></a><span data-ttu-id="ebd7d-117">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ebd7d-117">Is this the right control?</span></span>

* <span data-ttu-id="ebd7d-118">重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求したりするには、ダイアログを使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-118">Use dialogs to notify users of important information or to request confirmation or additional info before an action can be completed.</span></span>
* <span data-ttu-id="ebd7d-119">[ヒント](tooltips.md)や[コンテキスト メニュー](menus.md)の変わりにポップアップを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-119">Don't use a flyout instead of [tooltip](tooltips.md) or [context menu](menus.md).</span></span> <span data-ttu-id="ebd7d-120">指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-120">Use a tooltip to show a short description that hides after a specified time.</span></span> <span data-ttu-id="ebd7d-121">UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-121">Use a context menu for contextual actions related to a UI element, such as copy and paste.</span></span>  


<span data-ttu-id="ebd7d-122">ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-122">Dialogs and flyouts make sure that users are aware of important information, but they also disrupt the user experience.</span></span> <span data-ttu-id="ebd7d-123">ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-123">Because dialogs are modal (blocking), they interrupt users, preventing them from doing anything else until they interact with the dialog.</span></span> <span data-ttu-id="ebd7d-124">ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-124">Flyouts provide a less jarring experience, but displaying too many flyouts can be distracting.</span></span>

<span data-ttu-id="ebd7d-125">伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-125">Consider the importance of the information you want to share: is it important enough to interrupt the user?</span></span> <span data-ttu-id="ebd7d-126">また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-126">Also consider how frequently the information needs to be shown; if you're showing a dialog or notification every few minutes, you might want to allocate space for this info in the primary UI instead.</span></span> <span data-ttu-id="ebd7d-127">たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-127">For example, in a chat client, rather than showing a flyout every time a friend logs in, you might display a list of friends who are online at the moment and highlight friends as they log on.</span></span>

<span data-ttu-id="ebd7d-128">ダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-128">Dialogs are frequently used to confirm an action (such as deleting a file) before executing it.</span></span> <span data-ttu-id="ebd7d-129">ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-129">If you expect the user to perform a particular action frequently, consider providing a way for the user to undo the action if it was a mistake, rather than forcing users to confirm the action every time.</span></span>

## <a name="dialogs-vs-flyouts"></a><span data-ttu-id="ebd7d-130">ダイアログとポップアップの比較</span><span class="sxs-lookup"><span data-stu-id="ebd7d-130">Dialogs vs. flyouts</span></span>

<span data-ttu-id="ebd7d-131">ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-131">Once you've determined that you want to use a dialog or flyout, you need to choose which one to use.</span></span>

<span data-ttu-id="ebd7d-132">ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-132">Given that dialogs block interactions and flyouts do not, dialogs should be reserved for situations where you want the user to drop everything to focus on a specific bit of information or answer a question.</span></span> <span data-ttu-id="ebd7d-133">一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-133">Flyouts, on the other hand, can be used when you want to call attention to something, but it's ok if the user wants to ignore it.</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b><span data-ttu-id="ebd7d-134">ダイアログの用途:</span><span class="sxs-lookup"><span data-stu-id="ebd7d-134">Use a dialog for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="ebd7d-135">続行前にユーザーが読んだり確認したりする**必要のある重要な**情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-135">Expressing important information that the user **must** read and acknowledge before proceeding.</span></span> <span data-ttu-id="ebd7d-136">次のようなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-136">Examples include:</span></span>
<ul>
  <li><span data-ttu-id="ebd7d-137">ユーザーのセキュリティが侵害される可能性がある場合</span><span class="sxs-lookup"><span data-stu-id="ebd7d-137">When the user's security might be compromised</span></span></li>
  <li><span data-ttu-id="ebd7d-138">ユーザーが重要な資産に永続的な変更を加えようとしている場合</span><span class="sxs-lookup"><span data-stu-id="ebd7d-138">When the user is about to permanently alter a valuable asset</span></span></li>
  <li><span data-ttu-id="ebd7d-139">ユーザーが重要な資産を削除しようとしている場合</span><span class="sxs-lookup"><span data-stu-id="ebd7d-139">When the user is about to delete a valuable asset</span></span></li>
  <li><span data-ttu-id="ebd7d-140">アプリ内購入を確認する場合</span><span class="sxs-lookup"><span data-stu-id="ebd7d-140">To confirm an in-app purchase</span></span></li>
</ul>

</li>
<li><span data-ttu-id="ebd7d-141">接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-141">Error messages that apply to the overall app context, such as a connectivity error.</span></span></li>
<li><span data-ttu-id="ebd7d-142">アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など)</span><span class="sxs-lookup"><span data-stu-id="ebd7d-142">Questions, when the app needs to ask the user a blocking question, such as when the app can't choose on the user's behalf.</span></span> <span data-ttu-id="ebd7d-143">ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-143">A blocking question can't be ignored or postponed, and should offer the user well-defined choices.</span></span></li>
</ul>
</p>
  </div>
  <div class="side-by-side-content-right">
   <p><b><span data-ttu-id="ebd7d-144">ポップアップの用途:</span><span class="sxs-lookup"><span data-stu-id="ebd7d-144">Use a flyout for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="ebd7d-145">操作を完了する前に、必要な追加情報を収集する場合。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-145">Collecting additional information needed before an action can be completed.</span></span></li>
<li><span data-ttu-id="ebd7d-146">一部の場合のみに意味がある情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-146">Displaying info that's only relevant some of the time.</span></span> <span data-ttu-id="ebd7d-147">たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-147">For example, in a photo gallery app, when the user clicks an image thumbnail, you might use a flyout to display a large version of the image.</span></span></li>
<li><span data-ttu-id="ebd7d-148">詳細やページ上の項目の長い説明などの詳しい情報の表示。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-148">Displaying more information, such as details or longer descriptions of an item on the page.</span></span></li>
</ul></p>
  </div>
</div>
</div>

## <a name="dialogs"></a><span data-ttu-id="ebd7d-149">ダイアログ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-149">Dialogs</span></span>
### <a name="general-guidelines"></a><span data-ttu-id="ebd7d-150">一般的なガイドライン</span><span class="sxs-lookup"><span data-stu-id="ebd7d-150">General guidelines</span></span>

-   <span data-ttu-id="ebd7d-151">ダイアログ内のテキストの 1 行目で、問題やユーザーの目的 (実行する内容) を明確に示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-151">Clearly identify the issue or the user's objective in the first line of the dialog's text.</span></span>
-   <span data-ttu-id="ebd7d-152">ダイアログのタイトルは主な説明で、省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-152">The dialog title is the main instruction and is optional.</span></span>
    -   <span data-ttu-id="ebd7d-153">簡潔なタイトルを使って、ユーザーがそのダイアログで行う必要がある操作を説明します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-153">Use a short title to explain what people need to do with the dialog.</span></span>
    -   <span data-ttu-id="ebd7d-154">ダイアログを使って、簡単なメッセージ、エラー、または質問を表示する場合は、タイトルを省略することもできます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-154">If you're using the dialog to deliver a simple message, error or question, you can optionally omit the title.</span></span> <span data-ttu-id="ebd7d-155">主な情報はコンテンツのテキストを使って伝えます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-155">Rely on the content text to deliver that core information.</span></span>
    -   <span data-ttu-id="ebd7d-156">タイトルは、ボタンの選択に直接関連するものにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-156">Make sure that the title relates directly to the button choices.</span></span>
-   <span data-ttu-id="ebd7d-157">ダイアログ コンテンツには説明のテキストを含め、これは必須です。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-157">The dialog content contains the descriptive text and is required.</span></span>
    -   <span data-ttu-id="ebd7d-158">メッセージ、エラー、または操作をブロック質問をできる限り簡潔に示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-158">Present the message, error, or blocking question as simply as possible.</span></span>
    -   <span data-ttu-id="ebd7d-159">ダイアログ タイトルを使う場合は、コンテンツ領域を詳しい情報の提示や用語の定義に使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-159">If a dialog title is used, use the content area to provide more detail or define terminology.</span></span> <span data-ttu-id="ebd7d-160">タイトルの言葉づかいを変えただけの文を繰り返さないようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-160">Don't repeat the title with slightly different wording.</span></span>
-   <span data-ttu-id="ebd7d-161">少なくとも 1 つのダイアログ ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-161">At least one dialog button must appear.</span></span>
    -   <span data-ttu-id="ebd7d-162">ダイアログに、安全で非破壊的なアクションに対応する "OK"、"閉じる"、"キャンセル" などのボタンが少なくとも 1 つのあるようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-162">Ensure that your dialog has at least one button corresponding to a safe, nondestructive action like "Got it!", "Close", or "Cancel".</span></span> <span data-ttu-id="ebd7d-163">このボタンを追加するには、CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-163">Use the CloseButton API to add this button.</span></span>
    -   <span data-ttu-id="ebd7d-164">ボタンのテキストには、主な説明またはコンテンツに対する具体的な応答を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-164">Use specific responses to the main instruction or content as button text.</span></span> <span data-ttu-id="ebd7d-165">たとえば、主な説明が "使っているコンピューターへの AppName からのアクセスを許可しますか?" の場合、"許可" ボタンと "ブロック" ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-165">An example is, "Do you want to allow AppName to access your location?", followed by "Allow" and "Block" buttons.</span></span> <span data-ttu-id="ebd7d-166">具体的な応答の言葉はすばやく理解できるので、効率的に判断できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-166">Specific responses can be understood more quickly, resulting in efficient decision making.</span></span>
    - <span data-ttu-id="ebd7d-167">アクション ボタンのテキストは簡潔にします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-167">Ensure that the text of the action buttons is concise.</span></span> <span data-ttu-id="ebd7d-168">短い文字列にすると、ユーザーがすばやく確実に選択できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-168">Short strings enable the user to make a choice quickly and confidently.</span></span>
    - <span data-ttu-id="ebd7d-169">安全で非破壊的なアクションに加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-169">In addition to the safe, nondestructive action, you may optionally present the user with one or two action buttons related to the main instruction.</span></span> <span data-ttu-id="ebd7d-170">このような "処理実行" アクション ボタンでは、ダイアログの重要な点を確認します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-170">These "do it" action buttons confirm the main point of the dialog.</span></span> <span data-ttu-id="ebd7d-171">このような "処理実行" アクションを追加するには、PrimaryButton API と SecondaryButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-171">Use the PrimaryButton and SecondaryButton APIs to add these "do it" actions.</span></span>
    - <span data-ttu-id="ebd7d-172">"処理実行" アクション ボタンは一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-172">The "do it" action button(s) should appears as the leftmost buttons.</span></span> <span data-ttu-id="ebd7d-173">安全で非破壊的なアクションは一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-173">The safe, nondestructive action should appear as the rightmost button.</span></span>
    - <span data-ttu-id="ebd7d-174">必要に応じて、ダイアログの 3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-174">You may optionally choose to differentiate one of the three buttons as the dialog's default button.</span></span> <span data-ttu-id="ebd7d-175">ボタンの 1 つを区別するには DefaultButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-175">Use the DefaultButton API to differentiate one of the buttons.</span></span>  
-   <span data-ttu-id="ebd7d-176">パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-176">Don't use dialogs for errors that are contextual to a specific place on the page, such as validation errors (in password fields, for example), use the app's canvas itself to show inline errors.</span></span>
- <span data-ttu-id="ebd7d-177">ダイアログ エクスペリエンスを構築するには、[ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)を使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-177">Use the [ContentDialog class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx) to build your dialog experience.</span></span> <span data-ttu-id="ebd7d-178">非推奨の MessageDialog API は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-178">Don't use the deprecated MessageDialog API.</span></span>

### <a name="dialog-scenarios"></a><span data-ttu-id="ebd7d-179">ダイアログのシナリオ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-179">Dialog scenarios</span></span>
<span data-ttu-id="ebd7d-180">ダイアログでユーザー操作がブロックされたとき、ユーザーがダイアログを閉じる主な方法はボタンであるため、ダイアログに "閉じる" や "OK" などの安全で非破壊的なボタンが少なくとも 1 つは含まれるようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-180">Because dialogs block user interaction, and because buttons are the primary mechanism for users to dismiss the dialog, ensure that your dialog contains at least one "safe" and nondestructive button such as "Close" or "Got it!".</span></span> **<span data-ttu-id="ebd7d-181">すべてのダイアログには、ダイアログを閉じるための少なくとも 1 つの安全なアクション ボタンを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-181">All dialogs should contain at least one safe action button to close the dialog.</span></span>** <span data-ttu-id="ebd7d-182">これにより、ユーザーはアクションを実行することなく安心してダイアログを閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-182">This ensures that the user can confidently close the dialog without performing an action.</span></span>
![ボタンを 1 つ備えたダイアログ](images/dialogs/dialog_RS2_one_button.png)

```csharp
private async void DisplayNoWifiDialog()
{
    ContentDialog noWifiDialog = new ContentDialog
    {
        Title = "No wifi connection",
        Content = "Check your connection and try again.",
        CloseButtonText = "Ok"
    };

    ContentDialogResult result = await noWifiDialog.ShowAsync();
}
```

<span data-ttu-id="ebd7d-184">ダイアログにブロック質問を表示する場合、ダイアログには質問に関連するアクション ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-184">When dialogs are used to display a blocking question, your dialog should present the user with action buttons related to the question.</span></span> <span data-ttu-id="ebd7d-185">安全で非破壊的なボタンは、1 つまたは 2 つの "処理実行" アクション ボタンを伴っている場合があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-185">The "safe" and nondestructive button may be accompanied by one or two "do it" action buttons.</span></span> <span data-ttu-id="ebd7d-186">複数のオプションを表示するときは、提示されている質問に関して "処理実行" アクションと安全な "処理非実行" アクションをボタンが明確に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-186">When presenting the user with multiple options, ensure that the buttons clearly explain the "do it" and safe/"don’t do it" actions related to the question proposed.</span></span>

![ボタンを 2 つ備えたダイアログ](images/dialogs/dialog_RS2_two_button.png)

```csharp
private async void DisplayLocationPromptDialog()
{
    ContentDialog locationPromptDialog = new ContentDialog
    {
        Title = "Allow AppName to access your location?",
        Content = "AppName uses this information to help you find places, connect with friends, and more.",
        CloseButtonText = "Block",
        PrimaryButtonText = "Allow"
    };

    ContentDialogResult result = await locationPromptDialog.ShowAsync();
}
```

<span data-ttu-id="ebd7d-188">ボタンを 3 つ備えたダイアログは、2 つの "処理実行" アクションと 1 つの "処理非実行" アクションを表示するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-188">Three button dialogs are used when you present the user with two "do it" actions and a "don’t do it" action.</span></span> <span data-ttu-id="ebd7d-189">ボタンを 3 つ備えたダイアログは、セカンダリ アクションと安全な "閉じる" アクションを明確に区別して慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-189">Three button dialogs should be used sparingly with clear distinctions between the secondary action and the safe/close action.</span></span>

![ボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button.png)

```csharp
private async void DisplaySubscribeDialog()
{
    ContentDialog subscribeDialog = new ContentDialog
    {
        Title = "Subscribe to App Service?",
        Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
        CloseButtonText = "Not Now",
        PrimaryButtonText = "Subscribe",
        SecondaryButtonText = "Try it"
    };

    ContentDialogResult result = await subscribeDialog.ShowAsync();
}
```

### <a name="the-three-dialog-buttons"></a><span data-ttu-id="ebd7d-191">ダイアログの 3 つのボタン</span><span class="sxs-lookup"><span data-stu-id="ebd7d-191">The three dialog buttons</span></span>
<span data-ttu-id="ebd7d-192">ContentDialog には、ダイアログ エクスペリエンスを構築するために使用できる、3 種類のボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-192">ContentDialog has three different types of buttons that you can use to build a dialog experience.</span></span>

- <span data-ttu-id="ebd7d-193">**CloseButton** - 必須 - ユーザーがダイアログを終了できる安全で非破壊的なアクションを表します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-193">**CloseButton** - Required - Represents the safe, nondestructive action that enables the user to exit the dialog.</span></span> <span data-ttu-id="ebd7d-194">一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-194">Appears as the rightmost button.</span></span>
- <span data-ttu-id="ebd7d-195">**PrimaryButton** - 省略可能 - 1 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-195">**PrimaryButton** - Optional - Represents the first "do it" action.</span></span> <span data-ttu-id="ebd7d-196">一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-196">Appears as the leftmost button.</span></span>
- <span data-ttu-id="ebd7d-197">**SecondaryButton** - 省略可能 - 2 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-197">**SecondaryButton** - Optional - Represents the second "do it" action.</span></span> <span data-ttu-id="ebd7d-198">中央のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-198">Appears as the middle button.</span></span>

<span data-ttu-id="ebd7d-199">組み込みのボタンを使用すると、ボタンが適切な位置に表示され、キーボード イベントに正しく反応し、コマンド領域がスクリーン キーボード使用時にも表示されたままになり、ダイアログの外観が他のダイアログと一貫性のあるものになります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-199">Using the built-in buttons will position the buttons appropriately, ensure that they correctly respond to keyboard events, ensure that the command area remains visible even when the on-screen keyboard is up, and will make the dialog look consistent with other dialogs.</span></span>

#### <a name="closebutton"></a><span data-ttu-id="ebd7d-200">CloseButton</span><span class="sxs-lookup"><span data-stu-id="ebd7d-200">CloseButton</span></span>
<span data-ttu-id="ebd7d-201">すべてのダイアログには、ユーザーが安心してダイアログを終了できる、安全で非破壊的なアクション ボタンが含まれる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-201">Every dialog should contain a safe, nondestructive action button that enables the user to confidently exit the dialog.</span></span>

<span data-ttu-id="ebd7d-202">このボタンを作成するには、ContentDialog.CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-202">Use the ContentDialog.CloseButton API to create this button.</span></span> <span data-ttu-id="ebd7d-203">これにより、マウス、キーボード、タッチ、およびゲームパッドを含むすべての入力に対して、適切なユーザー エクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-203">This allows you to create the right user experience for all inputs including mouse, keyboard, touch, and gamepad.</span></span> <span data-ttu-id="ebd7d-204">このエクスペリエンスは以下の場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-204">This experience will happen when:</span></span>
<ol>
    <li><span data-ttu-id="ebd7d-205">ユーザーが CloseButton をクリックまたはタップする</span><span class="sxs-lookup"><span data-stu-id="ebd7d-205">The user clicks or taps on the CloseButton</span></span> </li>
    <li><span data-ttu-id="ebd7d-206">ユーザーがシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-206">The user presses the system back button</span></span> </li>
    <li><span data-ttu-id="ebd7d-207">ユーザーがキーボードの Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-207">The user presses the ESC button on the keyboard</span></span> </li>
    <li><span data-ttu-id="ebd7d-208">ユーザーがゲームパッドの B を押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-208">The user presses Gamepad B</span></span> </li>
</ol>

<span data-ttu-id="ebd7d-209">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) メソッドは [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-209">When the user clicks a dialog button, the [ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) method returns a [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) to let you know which button the user clicks.</span></span> <span data-ttu-id="ebd7d-210">CloseButton を押すと ContentDialogResult.None が返されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-210">Pressing on the CloseButton returns ContentDialogResult.None.</span></span>

#### <a name="primarybutton-and-secondarybutton"></a><span data-ttu-id="ebd7d-211">PrimaryButton と SecondaryButton</span><span class="sxs-lookup"><span data-stu-id="ebd7d-211">PrimaryButton and SecondaryButton</span></span>
<span data-ttu-id="ebd7d-212">CloseButton に加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-212">In addition to the CloseButton, you may optionally present the user with one or two action buttons related to the main instruction.</span></span>
<span data-ttu-id="ebd7d-213">1 つ目の "処理実行" アクションには PrimaryButton、2 つ目の "処理実行" アクションには SecondaryButton を使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-213">Leverage PrimaryButton for the first "do it" action, and SecondaryButton for the second "do it" action.</span></span> <span data-ttu-id="ebd7d-214">ボタンを 3 つ備えたダイアログでは、通常、PrimaryButton は肯定的な "処理実行" アクションを示し、SecondaryButton は中立的または二次的な "処理実行" アクションを示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-214">In three-button dialogs, the PrimaryButton generally represents the affirmative "do it" action, while the SecondaryButton generally represents a neutral or secondary "do it" action.</span></span>
<span data-ttu-id="ebd7d-215">たとえば、ユーザーがアプリからサービスに登録するように求められる場合があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-215">For example, an app may prompt the user to subscribe to a service.</span></span> <span data-ttu-id="ebd7d-216">肯定的な "処理実行" アクションとして PrimaryButton は "サブスクライブする" というテキストを表示し、中立的な "処理実行" アクションとして SecondaryButton は "試してみる" というテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-216">The PrimaryButton as the affirmative "do it" action would host the Subscribe text, while the SecondaryButton as the neutral "do it" action would host the Try it text.</span></span> <span data-ttu-id="ebd7d-217">CloseButton は、ユーザーがいずれのアクションも実行せずにキャンセルできるようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-217">The CloseButton would allow the user to cancel without performing either action.</span></span>

<span data-ttu-id="ebd7d-218">ユーザーが PrimaryButton をクリックすると、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) メソッドは ContentDialogResult.Primary を返します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-218">When the user clicks on the PrimaryButton, the [ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) method returns ContentDialogResult.Primary.</span></span>
<span data-ttu-id="ebd7d-219">ユーザーが SecondaryButton をクリックすると、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) メソッドは ContentDialogResult.Secondary を返します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-219">When the user clicks on the SecondaryButton, the [ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) method returns ContentDialogResult.Secondary.</span></span>

![ボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button.png)

#### <a name="defaultbutton"></a><span data-ttu-id="ebd7d-221">DefaultButton</span><span class="sxs-lookup"><span data-stu-id="ebd7d-221">DefaultButton</span></span>
<span data-ttu-id="ebd7d-222">必要に応じて、3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-222">You may optionally choose to differentiate one of the three buttons as the default button.</span></span> <span data-ttu-id="ebd7d-223">既定のボタンを指定すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-223">Specifying the default button causes the following to happen:</span></span>
- <span data-ttu-id="ebd7d-224">ボタンにアクセント ボタンとして視覚的な効果が適用される</span><span class="sxs-lookup"><span data-stu-id="ebd7d-224">The button receives the Accent Button visual treatment</span></span>
- <span data-ttu-id="ebd7d-225">ボタンが Enter キーに自動的に応答する</span><span class="sxs-lookup"><span data-stu-id="ebd7d-225">The button will respond to the ENTER key automatically</span></span>
    - <span data-ttu-id="ebd7d-226">ユーザーがキーボードの Enter キーを押すと、既定のボタンに関連付けられているクリック ハンドラーが起動し、ContentDialogResult は既定のボタンに関連付けられている値を返す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-226">When the user presses the ENTER key on the keyboard, the click handler associated with the Default Button will fire and the ContentDialogResult will return the value associated with the Default Button</span></span>
    - <span data-ttu-id="ebd7d-227">ユーザーが Enter を処理するコントロールにキーボード フォーカスを置いている場合、既定のボタンは Enter が押されても反応しない</span><span class="sxs-lookup"><span data-stu-id="ebd7d-227">If the user has placed Keyboard Focus on a control that handles ENTER, the Default Button will not respond to ENTER presses</span></span>
- <span data-ttu-id="ebd7d-228">ダイアログのコンテンツにフォーカス可能な UI が含まれていない限り、ダイアログが開くとボタンが自動的にフォーカスされる</span><span class="sxs-lookup"><span data-stu-id="ebd7d-228">The button will receive focus automatically when the Dialog is opened unless the dialog’s content contains focusable UI</span></span>

<span data-ttu-id="ebd7d-229">既定のボタンを指定するには、ContentDialog.DefaultButton プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-229">Use the ContentDialog.DefaultButton property to indicate the default button.</span></span> <span data-ttu-id="ebd7d-230">既定では、既定のボタンは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-230">By default, no default button is set.</span></span>

![既定のボタンを含むボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button_default.png)

```csharp
private async void DisplaySubscribeDialog()
{
    ContentDialog subscribeDialog = new ContentDialog
    {
        Title = "Subscribe to App Service?",
        Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
        CloseButtonText = "Not Now",
        PrimaryButtonText = "Subscribe",
        SecondaryButtonText = "Try it",
        DefaultButton = ContentDialogButton.Primary
    };

    ContentDialogResult result = await subscribeDialog.ShowAsync();
}
```

### <a name="confirmation-dialogs-okcancel"></a><span data-ttu-id="ebd7d-232">確認ダイアログ ([OK]/[キャンセル])</span><span class="sxs-lookup"><span data-stu-id="ebd7d-232">Confirmation dialogs (OK/Cancel)</span></span>
<span data-ttu-id="ebd7d-233">確認ダイアログにより、ユーザーはアクションを実行するかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-233">A confirmation dialog gives users the chance to confirm that they want to perform an action.</span></span> <span data-ttu-id="ebd7d-234">アクションを確認するか、キャンセルを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-234">They can affirm the action, or choose to cancel.</span></span>  
<span data-ttu-id="ebd7d-235">一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-235">A typical confirmation dialog has two buttons: an affirmation ("OK") button and a cancel button.</span></span>  

<ul>
    <li>
        <p><span data-ttu-id="ebd7d-236">一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-236">In general, the affirmation button should be on the left (the primary button) and the cancel button (the secondary button) should be on the right.</span></span></p>
         ![[OK]/[キャンセル] ダイアログ ボックス](images/dialogs/dialog_RS2_delete_file.png)

    </li>
    <li><span data-ttu-id="ebd7d-238">一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-238">As noted in the general recommendations section, use buttons with text that identifies specific responses to the main instruction or content.</span></span>
    </li>
</ul>

> <span data-ttu-id="ebd7d-239">一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-239">Some platforms put the affirmation button on the right instead of the left.</span></span> <span data-ttu-id="ebd7d-240">それでは、左側に確認ボタンを配置するのはなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-240">So why do we recommend putting it on the left?</span></span>  <span data-ttu-id="ebd7d-241">ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-241">If you assume that the majority of users are right-handed and they hold their phone with that hand, it's actually more comfortable to press the affirmation button when it's on the left, because the button is more likely to be within the user's thumb-arc.</span></span> <span data-ttu-id="ebd7d-242">画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-242">Buttons on the right-side of the screen require the user to pull their thumb inward into a less-comfortable position.</span></span>

### <a name="create-a-dialog"></a><span data-ttu-id="ebd7d-243">ダイアログの作成</span><span class="sxs-lookup"><span data-stu-id="ebd7d-243">Create a dialog</span></span>
<span data-ttu-id="ebd7d-244">ダイアログを作成するには、[ContentDialog クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-244">To create a dialog, you use the [ContentDialog class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx).</span></span> <span data-ttu-id="ebd7d-245">ダイアログはコードまたはマークアップで作成できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-245">You can create a dialog in code or markup.</span></span> <span data-ttu-id="ebd7d-246">通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-246">Although its usually easier to define UI elements in XAML, in the case of a simple dialog, it's actually easier to just use code.</span></span> <span data-ttu-id="ebd7d-247">この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx)メソッドを使ってそれを表示しています。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-247">This example creates a dialog to notify the user that there's no WiFi connection, and then uses the [ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) method to display it.</span></span>

```csharp
private async void DisplayNoWifiDialog()
{
    ContentDialog noWifiDialog = new ContentDialog
    {
        Title = "No wifi connection",
        Content = "Check your connection and try again.",
        CloseButtonText = "Ok"
    };

    ContentDialogResult result = await noWifiDialog.ShowAsync();
}
```

<span data-ttu-id="ebd7d-248">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx)メソッドは [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-248">When the user clicks a dialog button, the [ShowAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialog.showasync.aspx) method returns a [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) to let you know which button the user clicks.</span></span>

<span data-ttu-id="ebd7d-249">この例でのダイアログは、質問を行い、[ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) の戻り値を使用してユーザーの応答を確認します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-249">The dialog in this example asks a question and uses the returned [ContentDialogResult](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.contentdialogresult.aspx) to determine the user's response.</span></span>

```csharp
private async void DisplayDeleteFileDialog()
{
    ContentDialog deleteFileDialog = new ContentDialog
    {
        Title = "Delete file permanently?",
        Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
        PrimaryButtonText = "Delete",
        CloseButtonText = "Cancel"
    };

    ContentDialogResult result = await deleteFileDialog.ShowAsync();

    // Delete the file if the user clicked the primary button.
    /// Otherwise, do nothing.
    if (result == ContentDialogResult.Primary)
    {
        // Delete the file.
    }
    else
    {
        // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
        // Do nothing.
    }
}
```

## <a name="flyouts"></a><span data-ttu-id="ebd7d-250">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="ebd7d-250">Flyouts</span></span>
###  <a name="create-a-flyout"></a><span data-ttu-id="ebd7d-251">ポップアップの作成</span><span class="sxs-lookup"><span data-stu-id="ebd7d-251">Create a flyout</span></span>

<span data-ttu-id="ebd7d-252">ポップアップは、コンテンツとして任意の UI を表示できる簡易非表示コンテナーです。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-252">A flyout is a light dismiss container that can show arbitrary UI as its content.</span></span> <span data-ttu-id="ebd7d-253">ポップアップには、他のポップアップやコンテキスト メニューを含めて、入れ子になったエクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-253">Flyouts can contain other flyouts or context menus to create a nested experience.</span></span>

![ポップアップ内で入れ子になったコンテキスト メニュー](images/flyout-nested.png)

<span data-ttu-id="ebd7d-255">ポップアップは、特定のコントロールにアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-255">Flyouts are attached to specific controls.</span></span> <span data-ttu-id="ebd7d-256">[Placement](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.placement.aspx) プロパティを使って、ポップアップが表示される場所 (上、左、下、右、またはフル) を指定します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-256">You can use the [Placement](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.placement.aspx) property to specify where a flyout appears: Top, Left, Bottom, Right, or Full.</span></span> <span data-ttu-id="ebd7d-257">[完全配置モード](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutplacementmode.aspx)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-257">If you select the [Full placement mode](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutplacementmode.aspx), the app stretches the flyout and centers it inside the app window.</span></span> <span data-ttu-id="ebd7d-258">[Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)などの一部のコントロールは、ポップアップや[コンテキスト メニュー](menus.md)を関連付けるために使用できる [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) プロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-258">Some controls, such as [Button](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx), provide a [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) property that you can use to associate a flyout or [context menu](menus.md).</span></span>

<span data-ttu-id="ebd7d-259">この例では、ボタンが押されたときに、いくつかのテキストを表示するシンプルなポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-259">This example creates a simple flyout that displays some text when the button is pressed.</span></span>
````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="This is a flyout!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

<span data-ttu-id="ebd7d-260">コントロールに Flyout プロパティがない場合には、代わりに [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) 添付プロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-260">If the control doesn't have a flyout property, you can use the [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) attached property instead.</span></span> <span data-ttu-id="ebd7d-261">これを行う場合には、さらに [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout)メソッドを呼び出して、ポップアップを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-261">When you do this, you also need to call the [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) method to show the flyout.</span></span>

<span data-ttu-id="ebd7d-262">この例では、画像に簡単なポップアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-262">This example adds a simple flyout to an image.</span></span> <span data-ttu-id="ebd7d-263">ユーザーが画像をタップしたときに、アプリはポップアップを表示します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-263">When the user taps the image, the app shows the flyout.</span></span>

````xaml
<Image Source="Assets/cliff.jpg" Width="50" Height="50"
  Margin="10" Tapped="Image_Tapped">
  <FlyoutBase.AttachedFlyout>
    <Flyout>
      <TextBlock Text="This is some text in a flyout."  />
    </Flyout>        
  </FlyoutBase.AttachedFlyout>
</Image>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
}
````

<span data-ttu-id="ebd7d-264">前に示した例では、ポップアップはインラインで定義されています。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-264">The previous examples defined their flyouts inline.</span></span> <span data-ttu-id="ebd7d-265">ポップアップを静的なリソースとして定義して、複数の要素で使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-265">You can also define a flyout as a static resource and then use it with multiple elements.</span></span> <span data-ttu-id="ebd7d-266">この例では、サムネイルがタップされたときに大きな画像を表示する、より複雑なポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-266">This example creates a more complicated flyout that displays a larger version of an image when its thumbnail is tapped.</span></span>

````xaml
<!-- Declare the shared flyout as a resource. -->
<Page.Resources>
    <Flyout x:Key="ImagePreviewFlyout" Placement="Right">
        <!-- The flyout's DataContext must be the Image Source
             of the image the flyout is attached to. -->
        <Image Source="{Binding Path=Source}"
            MaxHeight="400" MaxWidth="400" Stretch="Uniform"/>
    </Flyout>
</Page.Resources>
````

````xaml
<!-- Assign the flyout to each element that shares it. -->
<StackPanel>
    <Image Source="Assets/cliff.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/grapes.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/rainier.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
</StackPanel>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);  
}
````

### <a name="style-a-flyout"></a><span data-ttu-id="ebd7d-267">ポップアップのスタイルを設定する</span><span class="sxs-lookup"><span data-stu-id="ebd7d-267">Style a flyout</span></span>
<span data-ttu-id="ebd7d-268">ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.flyoutpresenterstyle.aspx) を変更します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-268">To style a Flyout, modify its [FlyoutPresenterStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.flyoutpresenterstyle.aspx).</span></span> <span data-ttu-id="ebd7d-269">次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-269">This example shows a paragraph of wrapping text and makes the text block accessible to a screen reader.</span></span>

![折り返しのあるテキストを使ったアクセシビリティ対応のポップアップ](images/flyout-wrapping-text.png)

````xaml
<Flyout>
  <Flyout.FlyoutPresenterStyle>
    <Style TargetType="FlyoutPresenter">
      <Setter Property="ScrollViewer.HorizontalScrollMode"
          Value="Disabled"/>
      <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
      <Setter Property="IsTabStop" Value="True"/>
      <Setter Property="TabNavigation" Value="Cycle"/>
    </Style>
  </Flyout.FlyoutPresenterStyle>
  <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."/>
</Flyout>
````

#### <a name="styling-flyouts-for-10-foot-experience"></a><span data-ttu-id="ebd7d-271">10 フィート エクスペリエンス向けのポップアップのスタイル指定</span><span class="sxs-lookup"><span data-stu-id="ebd7d-271">Styling flyouts for 10-foot experience</span></span>

<span data-ttu-id="ebd7d-272">ポップアップなどの簡易非表示コントロールは、閉じるまでの間、一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-272">Light dismiss controls like flyout trap keyboard and gamepad focus inside their transient UI until dismissed.</span></span> <span data-ttu-id="ebd7d-273">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-273">To provide a visual cue for this behavior, light dismiss controls on Xbox draw an overlay that dims the contrast and visibility of out of scope UI.</span></span> <span data-ttu-id="ebd7d-274">この動作は、[`LightDismissOverlayMode`](https://msdn.microsoft.com/ library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-274">This behavior can be modified with the [`LightDismissOverlayMode`](https://msdn.microsoft.com/ library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) property.</span></span> <span data-ttu-id="ebd7d-275">既定では、ポップアウトは Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-275">By default, flyouts will draw the light dismiss overlay on Xbox but not other device families, but apps can choose to force the overlay to be always **On** or always **Off**.</span></span>

![ポップアップと暗転オーバーレイ](images/flyout-smoke.png)

```xaml
<MenuFlyout LightDismissOverlayMode="On">
```

### <a name="light-dismiss-behavior"></a><span data-ttu-id="ebd7d-277">簡易非表示の動作</span><span class="sxs-lookup"><span data-stu-id="ebd7d-277">Light dismiss behavior</span></span>
<span data-ttu-id="ebd7d-278">ポップアウトは、次のクイック簡易非表示アクションで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-278">Flyouts can be closed with a quick light dismiss action, including</span></span>
-    <span data-ttu-id="ebd7d-279">ポップアップの外側をタップする</span><span class="sxs-lookup"><span data-stu-id="ebd7d-279">Tap outside the flyout</span></span>
-    <span data-ttu-id="ebd7d-280">Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-280">Press the Escape keyboard key</span></span>
-    <span data-ttu-id="ebd7d-281">ハードウェアまたはソフトウェアのシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-281">Press the hardware or software system Back button</span></span>
-    <span data-ttu-id="ebd7d-282">ゲームパッドの B ボタンを押す</span><span class="sxs-lookup"><span data-stu-id="ebd7d-282">Press the gamepad B button</span></span>

<span data-ttu-id="ebd7d-283">タップで非表示にする場合、通常ではこのジェスチャは吸収されて下の UI に渡されません。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-283">When dismissing with a tap, this gesture is typically absorbed and not passed on to the UI underneath.</span></span> <span data-ttu-id="ebd7d-284">たとえば、開いているポップアウトの背後にボタンが見えている場合、ユーザーが 1 回目のタップでポップアップを閉じても、このボタンはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-284">For example, if there’s a button visible behind an open flyout, the user’s first tap dismisses the flyout but does not activate this button.</span></span> <span data-ttu-id="ebd7d-285">ボタンを押すには、もう 1 回タップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-285">Pressing the button requires a second tap.</span></span>

<span data-ttu-id="ebd7d-286">この動作は、ボタンをポップアウトの入力パススルー要素として指定することで変更できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-286">You can change this behavior by designating the button as an input pass-through element for the flyout.</span></span> <span data-ttu-id="ebd7d-287">上記の簡易非表示アクションの結果、ポップアウトが閉じます。また、タップ イベントがその指定された `OverlayInputPassThroughElement` に渡されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-287">The flyout will close as a result of the light dismiss actions described above and will also pass the tap event to its designated `OverlayInputPassThroughElement`.</span></span> <span data-ttu-id="ebd7d-288">機能的に似た項目でユーザー操作を高速化するには、この動作の採用を検討します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-288">Consider adopting this behavior to speed up user interactions on functionally similar items.</span></span> <span data-ttu-id="ebd7d-289">アプリにお気に入りのコレクションがあり、コレクションの各項目にアタッチされたポップアウトがある場合は、ユーザーがすばやく連続して複数のポップアウトを操作したい可能性があると考えるのが妥当です。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-289">If your app has a favorites collection and each item in the collection includes an attached flyout, it's reasonable to expect that users may want to interact with multiple flyouts in rapid succession.</span></span>

[!NOTE] <span data-ttu-id="ebd7d-290">破壊的なアクションを実行するオーバーレイの入力パススルー要素を指定しないように注意します。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-290">Be careful not to designate an overlay input pass-through element which results in a destructive action.</span></span> <span data-ttu-id="ebd7d-291">ユーザーは、プライマリ UI をアクティブ化しない、控えめな簡易非表示アクションに慣れています。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-291">Users have become habituated to discreet light dismiss actions which do not activate primary UI.</span></span> <span data-ttu-id="ebd7d-292">予期しない動作や中断動作を避けるために、閉じる、削除、または同様の破壊的なボタンは簡易非表示でアクティブ化しないでください。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-292">Close, Delete or similarly destructive buttons should not activate on light dismiss to avoid unexpected and disruptive behavior.</span></span>

<span data-ttu-id="ebd7d-293">次の例では、FavoritesBar にある 3 つすべてのボタンが 1 回目のタップでアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-293">In the following example, all three buttons inside FavoritesBar will be activated on the first tap.</span></span>

````xaml
<Page>
    <Page.Resources>
        <Flyout x:Name="TravelFlyout" x:Key="TravelFlyout"
                OverlayInputPassThroughElement="{x:Bind FavoritesBar}">
            <StackPanel>
                <HyperlinkButton Content="Washington Trails Association"/>
                <HyperlinkButton Content="Washington Cascades - Go Northwest! A Travel Guide"/>  
            </StackPanel>
        </Flyout>
    </Page.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="FavoritesBar" Orientation="Horizontal">
            <HyperlinkButton x:Name="PageLinkBtn">Bing</HyperlinkButton>  
            <Button x:Name="Folder1" Content="Travel" Flyout="{StaticResource TravelFlyout}"/>
            <Button x:Name="Folder2" Content="Entertainment" Click="Folder2_Click"/>
        </StackPanel>
        <ScrollViewer Grid.Row="1">
            <WebView x:Name="WebContent"/>
        </ScrollViewer>
    </Grid>
</Page>
````
````csharp
private void Folder2_Click(object sender, RoutedEventArgs e)
{
     Flyout flyout = new Flyout();
     flyout.OverlayInputPassThroughElement = FavoritesBar;
     ...
     flyout.ShowAt(sender as FrameworkElement);
{
````

## <a name="get-the-samples"></a><span data-ttu-id="ebd7d-294">サンプルの入手</span><span class="sxs-lookup"><span data-stu-id="ebd7d-294">Get the samples</span></span>
*   [<span data-ttu-id="ebd7d-295">XAML UI の基本</span><span class="sxs-lookup"><span data-stu-id="ebd7d-295">XAML UI basics</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    <span data-ttu-id="ebd7d-296">インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ebd7d-296">See all of the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="ebd7d-297">関連記事</span><span class="sxs-lookup"><span data-stu-id="ebd7d-297">Related articles</span></span>
- [<span data-ttu-id="ebd7d-298">ヒント</span><span class="sxs-lookup"><span data-stu-id="ebd7d-298">Tooltips</span></span>](tooltips.md)
- [<span data-ttu-id="ebd7d-299">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="ebd7d-299">Menus and context menu</span></span>](menus.md)
- [<span data-ttu-id="ebd7d-300">Flyout クラス</span><span class="sxs-lookup"><span data-stu-id="ebd7d-300">Flyout class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279496)
- [<span data-ttu-id="ebd7d-301">ContentDialog クラス</span><span class="sxs-lookup"><span data-stu-id="ebd7d-301">ContentDialog class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentdialog.aspx)