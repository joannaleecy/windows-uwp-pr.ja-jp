---
author: mijacobs
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ダイアログとポップアップ
label: Dialogs
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 7b263fda1de798473f581e2191d3fa01385060e6
ms.sourcegitcommit: e4627686138ec8c885696c4c511f2f05195cf8ff
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/17/2018
ms.locfileid: "1893847"
---
# <a name="dialogs-and-flyouts"></a><span data-ttu-id="f9c54-103">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="f9c54-103">Dialogs and flyouts</span></span>



<span data-ttu-id="f9c54-104">ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="f9c54-104">Dialogs and flyouts are transient UI elements that appear when something happens that requires notification, approval, or additional information from the user.</span></span>

> <span data-ttu-id="f9c54-105">**重要な API**: [ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)、[Flyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span><span class="sxs-lookup"><span data-stu-id="f9c54-105">**Important APIs**: [ContentDialog class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog), [Flyout class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span></span>


<span data-ttu-id="f9c54-106">:::row::: :::column::: **ダイアログ**</span><span class="sxs-lookup"><span data-stu-id="f9c54-106">:::row::: :::column::: **Dialogs**</span></span>
        
        ![Example of a dialog](images/dialogs/dialog_RS2_delete_file.png)

        Dialogs are modal UI overlays that provide contextual app information. Dialogs block interactions with the app window until being explicitly dismissed. They often request some kind of action from the user.
    :::column-end:::
    :::column::: 
        **Flyouts**

        ![Example of a flyout](images/flyout-example2.png)

        A flyout is a lightweight contextual popup that displays UI related to what the user is doing. It includes placement and sizing logic, and can be used to reveal a secondary control or show more detail about an item.

        Unlike a dialog, a flyout can be quickly dismissed by tapping or clicking somewhere outside the flyout, pressing the Escape key or Back button, resizing the app window, or changing the device's orientation.
    :::column-end:::
<span data-ttu-id="f9c54-107">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="f9c54-107">:::row-end:::</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="f9c54-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="f9c54-108">Is this the right control?</span></span>

* <span data-ttu-id="f9c54-109">重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求したりするには、ダイアログを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-109">Use dialogs to notify users of important information or to request confirmation or additional info before an action can be completed.</span></span>
* <span data-ttu-id="f9c54-110">[ヒント](tooltips.md)や[コンテキスト メニュー](menus.md)の変わりにポップアップを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-110">Don't use a flyout instead of [tooltip](tooltips.md) or [context menu](menus.md).</span></span> <span data-ttu-id="f9c54-111">指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-111">Use a tooltip to show a short description that hides after a specified time.</span></span> <span data-ttu-id="f9c54-112">UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-112">Use a context menu for contextual actions related to a UI element, such as copy and paste.</span></span>  


<span data-ttu-id="f9c54-113">ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-113">Dialogs and flyouts make sure that users are aware of important information, but they also disrupt the user experience.</span></span> <span data-ttu-id="f9c54-114">ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="f9c54-114">Because dialogs are modal (blocking), they interrupt users, preventing them from doing anything else until they interact with the dialog.</span></span> <span data-ttu-id="f9c54-115">ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-115">Flyouts provide a less jarring experience, but displaying too many flyouts can be distracting.</span></span>

<span data-ttu-id="f9c54-116">伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-116">Consider the importance of the information you want to share: is it important enough to interrupt the user?</span></span> <span data-ttu-id="f9c54-117">また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-117">Also consider how frequently the information needs to be shown; if you're showing a dialog or notification every few minutes, you might want to allocate space for this info in the primary UI instead.</span></span> <span data-ttu-id="f9c54-118">たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-118">For example, in a chat client, rather than showing a flyout every time a friend logs in, you might display a list of friends who are online at the moment and highlight friends as they log on.</span></span>

<span data-ttu-id="f9c54-119">ダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-119">Dialogs are frequently used to confirm an action (such as deleting a file) before executing it.</span></span> <span data-ttu-id="f9c54-120">ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-120">If you expect the user to perform a particular action frequently, consider providing a way for the user to undo the action if it was a mistake, rather than forcing users to confirm the action every time.</span></span>

## <a name="examples"></a><span data-ttu-id="f9c54-121">例</span><span class="sxs-lookup"><span data-stu-id="f9c54-121">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="f9c54-122">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="f9c54-122">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="f9c54-123"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="f9c54-123">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> or <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="f9c54-124">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="f9c54-124">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="f9c54-125">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="f9c54-125">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="dialogs-vs-flyouts"></a><span data-ttu-id="f9c54-126">ダイアログとポップアップの比較</span><span class="sxs-lookup"><span data-stu-id="f9c54-126">Dialogs vs. flyouts</span></span>

<span data-ttu-id="f9c54-127">ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-127">Once you've determined that you want to use a dialog or flyout, you need to choose which one to use.</span></span>

<span data-ttu-id="f9c54-128">ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-128">Given that dialogs block interactions and flyouts do not, dialogs should be reserved for situations where you want the user to drop everything to focus on a specific bit of information or answer a question.</span></span> <span data-ttu-id="f9c54-129">一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-129">Flyouts, on the other hand, can be used when you want to call attention to something, but it's ok if the user wants to ignore it.</span></span>

<span data-ttu-id="f9c54-130">:::row::: :::column:::</span><span class="sxs-lookup"><span data-stu-id="f9c54-130">:::row::: :::column:::</span></span>
   <p><b><span data-ttu-id="f9c54-131">ダイアログの用途:</span><span class="sxs-lookup"><span data-stu-id="f9c54-131">Use a dialog for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="f9c54-132">続行前にユーザーが読んだり確認したりする<b>必要のある重要な</b>情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="f9c54-132">Expressing important information that the user <b>must</b> read and acknowledge before proceeding.</span></span> <span data-ttu-id="f9c54-133">次のようなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-133">Examples include:</span></span>
<ul>
  <li><span data-ttu-id="f9c54-134">ユーザーのセキュリティが侵害される可能性がある場合</span><span class="sxs-lookup"><span data-stu-id="f9c54-134">When the user's security might be compromised</span></span></li>
  <li><span data-ttu-id="f9c54-135">ユーザーが重要な資産に永続的な変更を加えようとしている場合</span><span class="sxs-lookup"><span data-stu-id="f9c54-135">When the user is about to permanently alter a valuable asset</span></span></li>
  <li><span data-ttu-id="f9c54-136">ユーザーが重要な資産を削除しようとしている場合</span><span class="sxs-lookup"><span data-stu-id="f9c54-136">When the user is about to delete a valuable asset</span></span></li>
  <li><span data-ttu-id="f9c54-137">アプリ内購入を確認する場合</span><span class="sxs-lookup"><span data-stu-id="f9c54-137">To confirm an in-app purchase</span></span></li>
</ul>

</li>
<li><span data-ttu-id="f9c54-138">接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="f9c54-138">Error messages that apply to the overall app context, such as a connectivity error.</span></span></li>
<li><span data-ttu-id="f9c54-139">アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など)</span><span class="sxs-lookup"><span data-stu-id="f9c54-139">Questions, when the app needs to ask the user a blocking question, such as when the app can't choose on the user's behalf.</span></span> <span data-ttu-id="f9c54-140">ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-140">A blocking question can't be ignored or postponed, and should offer the user well-defined choices.</span></span></li>
</ul>
</p>
<span data-ttu-id="f9c54-141">:::column-end::: :::column:::</span><span class="sxs-lookup"><span data-stu-id="f9c54-141">:::column-end::: :::column:::</span></span> <p><b><span data-ttu-id="f9c54-142">ポップアップの用途:</span><span class="sxs-lookup"><span data-stu-id="f9c54-142">Use a flyout for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="f9c54-143">操作を完了する前に、必要な追加情報を収集する場合。</span><span class="sxs-lookup"><span data-stu-id="f9c54-143">Collecting additional information needed before an action can be completed.</span></span></li>
<li><span data-ttu-id="f9c54-144">一部の場合のみに意味がある情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="f9c54-144">Displaying info that's only relevant some of the time.</span></span> <span data-ttu-id="f9c54-145">たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-145">For example, in a photo gallery app, when the user clicks an image thumbnail, you might use a flyout to display a large version of the image.</span></span></li>
<li><span data-ttu-id="f9c54-146">詳細やページ上の項目の長い説明などの詳しい情報の表示。</span><span class="sxs-lookup"><span data-stu-id="f9c54-146">Displaying more information, such as details or longer descriptions of an item on the page.</span></span></li>
</ul></p>
<span data-ttu-id="f9c54-147">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="f9c54-147">:::column-end::: :::row-end:::</span></span>



## <a name="dialogs"></a><span data-ttu-id="f9c54-148">ダイアログ</span><span class="sxs-lookup"><span data-stu-id="f9c54-148">Dialogs</span></span>
### <a name="general-guidelines"></a><span data-ttu-id="f9c54-149">一般的なガイドライン</span><span class="sxs-lookup"><span data-stu-id="f9c54-149">General guidelines</span></span>

-   <span data-ttu-id="f9c54-150">ダイアログ内のテキストの 1 行目で、問題やユーザーの目的 (実行する内容) を明確に示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-150">Clearly identify the issue or the user's objective in the first line of the dialog's text.</span></span>
-   <span data-ttu-id="f9c54-151">ダイアログのタイトルは主な説明で、省略可能です。</span><span class="sxs-lookup"><span data-stu-id="f9c54-151">The dialog title is the main instruction and is optional.</span></span>
    -   <span data-ttu-id="f9c54-152">簡潔なタイトルを使って、ユーザーがそのダイアログで行う必要がある操作を説明します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-152">Use a short title to explain what people need to do with the dialog.</span></span>
    -   <span data-ttu-id="f9c54-153">ダイアログを使って、簡単なメッセージ、エラー、または質問を表示する場合は、タイトルを省略することもできます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-153">If you're using the dialog to deliver a simple message, error or question, you can optionally omit the title.</span></span> <span data-ttu-id="f9c54-154">主な情報はコンテンツのテキストを使って伝えます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-154">Rely on the content text to deliver that core information.</span></span>
    -   <span data-ttu-id="f9c54-155">タイトルは、ボタンの選択に直接関連するものにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-155">Make sure that the title relates directly to the button choices.</span></span>
-   <span data-ttu-id="f9c54-156">ダイアログ コンテンツには説明のテキストを含め、これは必須です。</span><span class="sxs-lookup"><span data-stu-id="f9c54-156">The dialog content contains the descriptive text and is required.</span></span>
    -   <span data-ttu-id="f9c54-157">メッセージ、エラー、または操作をブロック質問をできる限り簡潔に示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-157">Present the message, error, or blocking question as simply as possible.</span></span>
    -   <span data-ttu-id="f9c54-158">ダイアログ タイトルを使う場合は、コンテンツ領域を詳しい情報の提示や用語の定義に使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-158">If a dialog title is used, use the content area to provide more detail or define terminology.</span></span> <span data-ttu-id="f9c54-159">タイトルの言葉づかいを変えただけの文を繰り返さないようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-159">Don't repeat the title with slightly different wording.</span></span>
-   <span data-ttu-id="f9c54-160">少なくとも 1 つのダイアログ ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-160">At least one dialog button must appear.</span></span>
    -   <span data-ttu-id="f9c54-161">ダイアログに、安全で非破壊的なアクションに対応する "OK"、"閉じる"、"キャンセル" などのボタンが少なくとも 1 つのあるようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-161">Ensure that your dialog has at least one button corresponding to a safe, nondestructive action like "Got it!", "Close", or "Cancel".</span></span> <span data-ttu-id="f9c54-162">このボタンを追加するには、CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-162">Use the CloseButton API to add this button.</span></span>
    -   <span data-ttu-id="f9c54-163">ボタンのテキストには、主な説明またはコンテンツに対する具体的な応答を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-163">Use specific responses to the main instruction or content as button text.</span></span> <span data-ttu-id="f9c54-164">たとえば、主な説明が "使っているコンピューターへの AppName からのアクセスを許可しますか?" の場合、"許可" ボタンと "ブロック" ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-164">An example is, "Do you want to allow AppName to access your location?", followed by "Allow" and "Block" buttons.</span></span> <span data-ttu-id="f9c54-165">具体的な応答の言葉はすばやく理解できるので、効率的に判断できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-165">Specific responses can be understood more quickly, resulting in efficient decision making.</span></span>
    - <span data-ttu-id="f9c54-166">アクション ボタンのテキストは簡潔にします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-166">Ensure that the text of the action buttons is concise.</span></span> <span data-ttu-id="f9c54-167">短い文字列にすると、ユーザーがすばやく確実に選択できるようになります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-167">Short strings enable the user to make a choice quickly and confidently.</span></span>
    - <span data-ttu-id="f9c54-168">安全で非破壊的なアクションに加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-168">In addition to the safe, nondestructive action, you may optionally present the user with one or two action buttons related to the main instruction.</span></span> <span data-ttu-id="f9c54-169">このような "処理実行" アクション ボタンでは、ダイアログの重要な点を確認します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-169">These "do it" action buttons confirm the main point of the dialog.</span></span> <span data-ttu-id="f9c54-170">このような "処理実行" アクションを追加するには、PrimaryButton API と SecondaryButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-170">Use the PrimaryButton and SecondaryButton APIs to add these "do it" actions.</span></span>
    - <span data-ttu-id="f9c54-171">"処理実行" アクション ボタンは一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-171">The "do it" action button(s) should appears as the leftmost buttons.</span></span> <span data-ttu-id="f9c54-172">安全で非破壊的なアクションは一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-172">The safe, nondestructive action should appear as the rightmost button.</span></span>
    - <span data-ttu-id="f9c54-173">必要に応じて、ダイアログの 3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-173">You may optionally choose to differentiate one of the three buttons as the dialog's default button.</span></span> <span data-ttu-id="f9c54-174">ボタンの 1 つを区別するには DefaultButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-174">Use the DefaultButton API to differentiate one of the buttons.</span></span>  
-   <span data-ttu-id="f9c54-175">パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-175">Don't use dialogs for errors that are contextual to a specific place on the page, such as validation errors (in password fields, for example), use the app's canvas itself to show inline errors.</span></span>
- <span data-ttu-id="f9c54-176">ダイアログ エクスペリエンスを構築するには、[ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-176">Use the [ContentDialog class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog) to build your dialog experience.</span></span> <span data-ttu-id="f9c54-177">非推奨の MessageDialog API は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="f9c54-177">Don't use the deprecated MessageDialog API.</span></span>

### <a name="dialog-scenarios"></a><span data-ttu-id="f9c54-178">ダイアログのシナリオ</span><span class="sxs-lookup"><span data-stu-id="f9c54-178">Dialog scenarios</span></span>
<span data-ttu-id="f9c54-179">ダイアログでユーザー操作がブロックされたとき、ユーザーがダイアログを閉じる主な方法はボタンであるため、ダイアログに "閉じる" や "OK" などの安全で非破壊的なボタンが少なくとも 1 つは含まれるようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-179">Because dialogs block user interaction, and because buttons are the primary mechanism for users to dismiss the dialog, ensure that your dialog contains at least one "safe" and nondestructive button such as "Close" or "Got it!".</span></span> **<span data-ttu-id="f9c54-180">すべてのダイアログには、ダイアログを閉じるための少なくとも 1 つの安全なアクション ボタンを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-180">All dialogs should contain at least one safe action button to close the dialog.</span></span>** <span data-ttu-id="f9c54-181">これにより、ユーザーはアクションを実行することなく安心してダイアログを閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-181">This ensures that the user can confidently close the dialog without performing an action.</span></span><br>![ボタンを 1 つ備えたダイアログ](images/dialogs/dialog_RS2_one_button.png)

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

<span data-ttu-id="f9c54-183">ダイアログにブロック質問を表示する場合、ダイアログには質問に関連するアクション ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-183">When dialogs are used to display a blocking question, your dialog should present the user with action buttons related to the question.</span></span> <span data-ttu-id="f9c54-184">安全で非破壊的なボタンは、1 つまたは 2 つの "処理実行" アクション ボタンを伴っている場合があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-184">The "safe" and nondestructive button may be accompanied by one or two "do it" action buttons.</span></span> <span data-ttu-id="f9c54-185">複数のオプションを表示するときは、提示されている質問に関して "処理実行" アクションと安全な "処理非実行" アクションをボタンが明確に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-185">When presenting the user with multiple options, ensure that the buttons clearly explain the "do it" and safe/"don’t do it" actions related to the question proposed.</span></span>

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

<span data-ttu-id="f9c54-187">ボタンを 3 つ備えたダイアログは、2 つの "処理実行" アクションと 1 つの "処理非実行" アクションを表示するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-187">Three button dialogs are used when you present the user with two "do it" actions and a "don’t do it" action.</span></span> <span data-ttu-id="f9c54-188">ボタンを 3 つ備えたダイアログは、セカンダリ アクションと安全な "閉じる" アクションを明確に区別して慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-188">Three button dialogs should be used sparingly with clear distinctions between the secondary action and the safe/close action.</span></span>

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

### <a name="the-three-dialog-buttons"></a><span data-ttu-id="f9c54-190">ダイアログの 3 つのボタン</span><span class="sxs-lookup"><span data-stu-id="f9c54-190">The three dialog buttons</span></span>
<span data-ttu-id="f9c54-191">ContentDialog には、ダイアログ エクスペリエンスを構築するために使用できる、3 種類のボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-191">ContentDialog has three different types of buttons that you can use to build a dialog experience.</span></span>

- <span data-ttu-id="f9c54-192">**CloseButton** - 必須 - ユーザーがダイアログを終了できる安全で非破壊的なアクションを表します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-192">**CloseButton** - Required - Represents the safe, nondestructive action that enables the user to exit the dialog.</span></span> <span data-ttu-id="f9c54-193">一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-193">Appears as the rightmost button.</span></span>
- <span data-ttu-id="f9c54-194">**PrimaryButton** - 省略可能 - 1 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-194">**PrimaryButton** - Optional - Represents the first "do it" action.</span></span> <span data-ttu-id="f9c54-195">一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-195">Appears as the leftmost button.</span></span>
- <span data-ttu-id="f9c54-196">**SecondaryButton** - 省略可能 - 2 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-196">**SecondaryButton** - Optional - Represents the second "do it" action.</span></span> <span data-ttu-id="f9c54-197">中央のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-197">Appears as the middle button.</span></span>

<span data-ttu-id="f9c54-198">組み込みのボタンを使用すると、ボタンが適切な位置に表示され、キーボード イベントに正しく反応し、コマンド領域がスクリーン キーボード使用時にも表示されたままになり、ダイアログの外観が他のダイアログと一貫性のあるものになります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-198">Using the built-in buttons will position the buttons appropriately, ensure that they correctly respond to keyboard events, ensure that the command area remains visible even when the on-screen keyboard is up, and will make the dialog look consistent with other dialogs.</span></span>

#### <a name="closebutton"></a><span data-ttu-id="f9c54-199">CloseButton</span><span class="sxs-lookup"><span data-stu-id="f9c54-199">CloseButton</span></span>
<span data-ttu-id="f9c54-200">すべてのダイアログには、ユーザーが安心してダイアログを終了できる、安全で非破壊的なアクション ボタンが含まれる必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-200">Every dialog should contain a safe, nondestructive action button that enables the user to confidently exit the dialog.</span></span>

<span data-ttu-id="f9c54-201">このボタンを作成するには、ContentDialog.CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-201">Use the ContentDialog.CloseButton API to create this button.</span></span> <span data-ttu-id="f9c54-202">これにより、マウス、キーボード、タッチ、およびゲームパッドを含むすべての入力に対して、適切なユーザー エクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-202">This allows you to create the right user experience for all inputs including mouse, keyboard, touch, and gamepad.</span></span> <span data-ttu-id="f9c54-203">このエクスペリエンスは以下の場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-203">This experience will happen when:</span></span>
<ol>
    <li><span data-ttu-id="f9c54-204">ユーザーが CloseButton をクリックまたはタップする</span><span class="sxs-lookup"><span data-stu-id="f9c54-204">The user clicks or taps on the CloseButton</span></span> </li>
    <li><span data-ttu-id="f9c54-205">ユーザーがシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-205">The user presses the system back button</span></span> </li>
    <li><span data-ttu-id="f9c54-206">ユーザーがキーボードの Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-206">The user presses the ESC button on the keyboard</span></span> </li>
    <li><span data-ttu-id="f9c54-207">ユーザーがゲームパッドの B を押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-207">The user presses Gamepad B</span></span> </li>
</ol>

<span data-ttu-id="f9c54-208">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-208">When the user clicks a dialog button, the [ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns a [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to let you know which button the user clicks.</span></span> <span data-ttu-id="f9c54-209">CloseButton を押すと ContentDialogResult.None が返されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-209">Pressing on the CloseButton returns ContentDialogResult.None.</span></span>

#### <a name="primarybutton-and-secondarybutton"></a><span data-ttu-id="f9c54-210">PrimaryButton と SecondaryButton</span><span class="sxs-lookup"><span data-stu-id="f9c54-210">PrimaryButton and SecondaryButton</span></span>
<span data-ttu-id="f9c54-211">CloseButton に加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-211">In addition to the CloseButton, you may optionally present the user with one or two action buttons related to the main instruction.</span></span>
<span data-ttu-id="f9c54-212">1 つ目の "処理実行" アクションには PrimaryButton、2 つ目の "処理実行" アクションには SecondaryButton を使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-212">Leverage PrimaryButton for the first "do it" action, and SecondaryButton for the second "do it" action.</span></span> <span data-ttu-id="f9c54-213">ボタンを 3 つ備えたダイアログでは、通常、PrimaryButton は肯定的な "処理実行" アクションを示し、SecondaryButton は中立的または二次的な "処理実行" アクションを示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-213">In three-button dialogs, the PrimaryButton generally represents the affirmative "do it" action, while the SecondaryButton generally represents a neutral or secondary "do it" action.</span></span>
<span data-ttu-id="f9c54-214">たとえば、ユーザーがアプリからサービスに登録するように求められる場合があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-214">For example, an app may prompt the user to subscribe to a service.</span></span> <span data-ttu-id="f9c54-215">肯定的な "処理実行" アクションとして PrimaryButton は "サブスクライブする" というテキストを表示し、中立的な "処理実行" アクションとして SecondaryButton は "試してみる" というテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-215">The PrimaryButton as the affirmative "do it" action would host the Subscribe text, while the SecondaryButton as the neutral "do it" action would host the Try it text.</span></span> <span data-ttu-id="f9c54-216">CloseButton は、ユーザーがいずれのアクションも実行せずにキャンセルできるようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-216">The CloseButton would allow the user to cancel without performing either action.</span></span>

<span data-ttu-id="f9c54-217">ユーザーが PrimaryButton をクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Primary を返します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-217">When the user clicks on the PrimaryButton, the [ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns ContentDialogResult.Primary.</span></span>
<span data-ttu-id="f9c54-218">ユーザーが SecondaryButton をクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Secondary を返します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-218">When the user clicks on the SecondaryButton, the [ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns ContentDialogResult.Secondary.</span></span>

![ボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button.png)

#### <a name="defaultbutton"></a><span data-ttu-id="f9c54-220">DefaultButton</span><span class="sxs-lookup"><span data-stu-id="f9c54-220">DefaultButton</span></span>
<span data-ttu-id="f9c54-221">必要に応じて、3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-221">You may optionally choose to differentiate one of the three buttons as the default button.</span></span> <span data-ttu-id="f9c54-222">既定のボタンを指定すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-222">Specifying the default button causes the following to happen:</span></span>
- <span data-ttu-id="f9c54-223">ボタンにアクセント ボタンとして視覚的な効果が適用される</span><span class="sxs-lookup"><span data-stu-id="f9c54-223">The button receives the Accent Button visual treatment</span></span>
- <span data-ttu-id="f9c54-224">ボタンが Enter キーに自動的に応答する</span><span class="sxs-lookup"><span data-stu-id="f9c54-224">The button will respond to the ENTER key automatically</span></span>
    - <span data-ttu-id="f9c54-225">ユーザーがキーボードの Enter キーを押すと、既定のボタンに関連付けられているクリック ハンドラーが起動し、ContentDialogResult は既定のボタンに関連付けられている値を返す</span><span class="sxs-lookup"><span data-stu-id="f9c54-225">When the user presses the ENTER key on the keyboard, the click handler associated with the Default Button will fire and the ContentDialogResult will return the value associated with the Default Button</span></span>
    - <span data-ttu-id="f9c54-226">ユーザーが Enter を処理するコントロールにキーボード フォーカスを置いている場合、既定のボタンは Enter が押されても反応しない</span><span class="sxs-lookup"><span data-stu-id="f9c54-226">If the user has placed Keyboard Focus on a control that handles ENTER, the Default Button will not respond to ENTER presses</span></span>
- <span data-ttu-id="f9c54-227">ダイアログのコンテンツにフォーカス可能な UI が含まれていない限り、ダイアログが開くとボタンが自動的にフォーカスされる</span><span class="sxs-lookup"><span data-stu-id="f9c54-227">The button will receive focus automatically when the Dialog is opened unless the dialog’s content contains focusable UI</span></span>

<span data-ttu-id="f9c54-228">既定のボタンを指定するには、ContentDialog.DefaultButton プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f9c54-228">Use the ContentDialog.DefaultButton property to indicate the default button.</span></span> <span data-ttu-id="f9c54-229">既定では、既定のボタンは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="f9c54-229">By default, no default button is set.</span></span>

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

### <a name="confirmation-dialogs-okcancel"></a><span data-ttu-id="f9c54-231">確認ダイアログ ([OK]/[キャンセル])</span><span class="sxs-lookup"><span data-stu-id="f9c54-231">Confirmation dialogs (OK/Cancel)</span></span>
<span data-ttu-id="f9c54-232">確認ダイアログにより、ユーザーはアクションを実行するかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-232">A confirmation dialog gives users the chance to confirm that they want to perform an action.</span></span> <span data-ttu-id="f9c54-233">アクションを確認するか、キャンセルを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-233">They can affirm the action, or choose to cancel.</span></span>  
<span data-ttu-id="f9c54-234">一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-234">A typical confirmation dialog has two buttons: an affirmation ("OK") button and a cancel button.</span></span>  

<ul>
    <li>
        <p><span data-ttu-id="f9c54-235">一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-235">In general, the affirmation button should be on the left (the primary button) and the cancel button (the secondary button) should be on the right.</span></span></p>
        <img alt="An OK/cancel dialog" src="images/dialogs/dialog_RS2_delete_file.png" />
    </li>
    <li><span data-ttu-id="f9c54-236">一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-236">As noted in the general recommendations section, use buttons with text that identifies specific responses to the main instruction or content.</span></span>
    </li>
</ul>

> <span data-ttu-id="f9c54-237">一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-237">Some platforms put the affirmation button on the right instead of the left.</span></span> <span data-ttu-id="f9c54-238">それでは、左側に確認ボタンを配置するのはなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="f9c54-238">So why do we recommend putting it on the left?</span></span>  <span data-ttu-id="f9c54-239">ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-239">If you assume that the majority of users are right-handed and they hold their phone with that hand, it's actually more comfortable to press the affirmation button when it's on the left, because the button is more likely to be within the user's thumb-arc. Buttons on the right-side of the screen require the user to pull their thumb inward into a less-comfortable position.</span></span>

### <a name="create-a-dialog"></a><span data-ttu-id="f9c54-240">ダイアログの作成</span><span class="sxs-lookup"><span data-stu-id="f9c54-240">Create a dialog</span></span>
<span data-ttu-id="f9c54-241">ダイアログを作成するには、[ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-241">To create a dialog, you use the [ContentDialog class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog).</span></span> <span data-ttu-id="f9c54-242">ダイアログはコードまたはマークアップで作成できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-242">You can create a dialog in code or markup.</span></span> <span data-ttu-id="f9c54-243">通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。</span><span class="sxs-lookup"><span data-stu-id="f9c54-243">Although its usually easier to define UI elements in XAML, in the case of a simple dialog, it's actually easier to just use code.</span></span> <span data-ttu-id="f9c54-244">この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドを使ってそれを表示しています。</span><span class="sxs-lookup"><span data-stu-id="f9c54-244">This example creates a dialog to notify the user that there's no WiFi connection, and then uses the [ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method to display it.</span></span>

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

<span data-ttu-id="f9c54-245">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドは [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-245">When the user clicks a dialog button, the [ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns a [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to let you know which button the user clicks.</span></span>

<span data-ttu-id="f9c54-246">この例でのダイアログは、質問を行い、[ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) の戻り値を使用してユーザーの応答を確認します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-246">The dialog in this example asks a question and uses the returned [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to determine the user's response.</span></span>

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

## <a name="flyouts"></a><span data-ttu-id="f9c54-247">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="f9c54-247">Flyouts</span></span>
###  <a name="create-a-flyout"></a><span data-ttu-id="f9c54-248">ポップアップの作成</span><span class="sxs-lookup"><span data-stu-id="f9c54-248">Create a flyout</span></span>

<span data-ttu-id="f9c54-249">ポップアップは、コンテンツとして任意の UI を表示できる簡易非表示コンテナーです。</span><span class="sxs-lookup"><span data-stu-id="f9c54-249">A flyout is a light dismiss container that can show arbitrary UI as its content.</span></span> <span data-ttu-id="f9c54-250">ポップアップには、他のポップアップやコンテキスト メニューを含めて、入れ子になったエクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-250">Flyouts can contain other flyouts or context menus to create a nested experience.</span></span>

![ポップアップ内で入れ子になったコンテキスト メニュー](images/flyout-nested.png)

<span data-ttu-id="f9c54-252">ポップアップは、特定のコントロールにアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-252">Flyouts are attached to specific controls.</span></span> <span data-ttu-id="f9c54-253">[Placement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement) プロパティを使って、ポップアップが表示される場所 (上、左、下、右、またはフル) を指定します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-253">You can use the [Placement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement) property to specify where a flyout appears: Top, Left, Bottom, Right, or Full.</span></span> <span data-ttu-id="f9c54-254">[完全配置モード](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-254">If you select the [Full placement mode](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode), the app stretches the flyout and centers it inside the app window.</span></span> <span data-ttu-id="f9c54-255">[Button](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button)などの一部のコントロールは、ポップアップや[コンテキスト メニュー](menus.md)を関連付けるために使用できる [Flyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) プロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-255">Some controls, such as [Button](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button), provide a [Flyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) property that you can use to associate a flyout or [context menu](menus.md).</span></span>

<span data-ttu-id="f9c54-256">この例では、ボタンが押されたときに、いくつかのテキストを表示するシンプルなポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-256">This example creates a simple flyout that displays some text when the button is pressed.</span></span>
````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="This is a flyout!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

<span data-ttu-id="f9c54-257">コントロールに Flyout プロパティがない場合には、代わりに [FlyoutBase.AttachedFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.AttachedFlyoutProperty) 添付プロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-257">If the control doesn't have a flyout property, you can use the [FlyoutBase.AttachedFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.AttachedFlyoutProperty) attached property instead.</span></span> <span data-ttu-id="f9c54-258">これを行う場合には、さらに [FlyoutBase.ShowAttachedFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase#Windows_UI_Xaml_Controls_Primitives_FlyoutBase_ShowAttachedFlyout_Windows_UI_Xaml_FrameworkElement_)メソッドを呼び出して、ポップアップを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-258">When you do this, you also need to call the [FlyoutBase.ShowAttachedFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase#Windows_UI_Xaml_Controls_Primitives_FlyoutBase_ShowAttachedFlyout_Windows_UI_Xaml_FrameworkElement_) method to show the flyout.</span></span>

<span data-ttu-id="f9c54-259">この例では、画像に簡単なポップアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-259">This example adds a simple flyout to an image.</span></span> <span data-ttu-id="f9c54-260">ユーザーが画像をタップしたときに、アプリはポップアップを表示します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-260">When the user taps the image, the app shows the flyout.</span></span>

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

<span data-ttu-id="f9c54-261">前に示した例では、ポップアップはインラインで定義されています。</span><span class="sxs-lookup"><span data-stu-id="f9c54-261">The previous examples defined their flyouts inline.</span></span> <span data-ttu-id="f9c54-262">ポップアップを静的なリソースとして定義して、複数の要素で使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-262">You can also define a flyout as a static resource and then use it with multiple elements.</span></span> <span data-ttu-id="f9c54-263">この例では、サムネイルがタップされたときに大きな画像を表示する、より複雑なポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-263">This example creates a more complicated flyout that displays a larger version of an image when its thumbnail is tapped.</span></span>

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

### <a name="style-a-flyout"></a><span data-ttu-id="f9c54-264">ポップアップのスタイルを設定する</span><span class="sxs-lookup"><span data-stu-id="f9c54-264">Style a flyout</span></span>
<span data-ttu-id="f9c54-265">ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle) を変更します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-265">To style a Flyout, modify its [FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle).</span></span> <span data-ttu-id="f9c54-266">次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c54-266">This example shows a paragraph of wrapping text and makes the text block accessible to a screen reader.</span></span>

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

#### <a name="styling-flyouts-for-10-foot-experience"></a><span data-ttu-id="f9c54-268">10 フィート エクスペリエンス向けのポップアップのスタイル指定</span><span class="sxs-lookup"><span data-stu-id="f9c54-268">Styling flyouts for 10-foot experience</span></span>

<span data-ttu-id="f9c54-269">ポップアップなどの簡易非表示コントロールは、閉じるまでの間、一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-269">Light dismiss controls like flyout trap keyboard and gamepad focus inside their transient UI until dismissed.</span></span> <span data-ttu-id="f9c54-270">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-270">To provide a visual cue for this behavior, light dismiss controls on Xbox draw an overlay that dims the contrast and visibility of out of scope UI.</span></span> <span data-ttu-id="f9c54-271">この動作は、[`LightDismissOverlayMode`](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) プロパティを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-271">This behavior can be modified with the [`LightDismissOverlayMode`](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) property.</span></span> <span data-ttu-id="f9c54-272">既定では、ポップアウトは Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-272">By default, flyouts will draw the light dismiss overlay on Xbox but not other device families, but apps can choose to force the overlay to be always **On** or always **Off**.</span></span>

![ポップアップと暗転オーバーレイ](images/flyout-smoke.png)

```xaml
<MenuFlyout LightDismissOverlayMode="On">
```

### <a name="light-dismiss-behavior"></a><span data-ttu-id="f9c54-274">簡易非表示の動作</span><span class="sxs-lookup"><span data-stu-id="f9c54-274">Light dismiss behavior</span></span>
<span data-ttu-id="f9c54-275">ポップアウトは、次のクイック簡易非表示アクションで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-275">Flyouts can be closed with a quick light dismiss action, including</span></span>
-   <span data-ttu-id="f9c54-276">ポップアップの外側をタップする</span><span class="sxs-lookup"><span data-stu-id="f9c54-276">Tap outside the flyout</span></span>
-   <span data-ttu-id="f9c54-277">Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-277">Press the Escape keyboard key</span></span>
-   <span data-ttu-id="f9c54-278">ハードウェアまたはソフトウェアのシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-278">Press the hardware or software system Back button</span></span>
-   <span data-ttu-id="f9c54-279">ゲームパッドの B ボタンを押す</span><span class="sxs-lookup"><span data-stu-id="f9c54-279">Press the gamepad B button</span></span>

<span data-ttu-id="f9c54-280">タップで非表示にする場合、通常ではこのジェスチャは吸収されて下の UI に渡されません。</span><span class="sxs-lookup"><span data-stu-id="f9c54-280">When dismissing with a tap, this gesture is typically absorbed and not passed on to the UI underneath.</span></span> <span data-ttu-id="f9c54-281">たとえば、開いているポップアウトの背後にボタンが見えている場合、ユーザーが 1 回目のタップでポップアップを閉じても、このボタンはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="f9c54-281">For example, if there’s a button visible behind an open flyout, the user’s first tap dismisses the flyout but does not activate this button.</span></span> <span data-ttu-id="f9c54-282">ボタンを押すには、もう 1 回タップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c54-282">Pressing the button requires a second tap.</span></span>

<span data-ttu-id="f9c54-283">この動作は、ボタンをポップアウトの入力パススルー要素として指定することで変更できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-283">You can change this behavior by designating the button as an input pass-through element for the flyout.</span></span> <span data-ttu-id="f9c54-284">上記の簡易非表示アクションの結果、ポップアウトが閉じます。また、タップ イベントがその指定された `OverlayInputPassThroughElement` に渡されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-284">The flyout will close as a result of the light dismiss actions described above and will also pass the tap event to its designated `OverlayInputPassThroughElement`.</span></span> <span data-ttu-id="f9c54-285">機能的に似た項目でユーザー操作を高速化するには、この動作の採用を検討します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-285">Consider adopting this behavior to speed up user interactions on functionally similar items.</span></span> <span data-ttu-id="f9c54-286">アプリにお気に入りのコレクションがあり、コレクションの各項目にアタッチされたポップアウトがある場合は、ユーザーがすばやく連続して複数のポップアウトを操作したい可能性があると考えるのが妥当です。</span><span class="sxs-lookup"><span data-stu-id="f9c54-286">If your app has a favorites collection and each item in the collection includes an attached flyout, it's reasonable to expect that users may want to interact with multiple flyouts in rapid succession.</span></span>

[!NOTE] <span data-ttu-id="f9c54-287">破壊的なアクションを実行するオーバーレイの入力パススルー要素を指定しないように注意します。</span><span class="sxs-lookup"><span data-stu-id="f9c54-287">Be careful not to designate an overlay input pass-through element which results in a destructive action.</span></span> <span data-ttu-id="f9c54-288">ユーザーは、プライマリ UI をアクティブ化しない、控えめな簡易非表示アクションに慣れています。</span><span class="sxs-lookup"><span data-stu-id="f9c54-288">Users have become habituated to discreet light dismiss actions which do not activate primary UI.</span></span> <span data-ttu-id="f9c54-289">予期しない動作や中断動作を避けるために、閉じる、削除、または同様の破壊的なボタンは簡易非表示でアクティブ化しないでください。</span><span class="sxs-lookup"><span data-stu-id="f9c54-289">Close, Delete or similarly destructive buttons should not activate on light dismiss to avoid unexpected and disruptive behavior.</span></span>

<span data-ttu-id="f9c54-290">次の例では、FavoritesBar にある 3 つすべてのボタンが 1 回目のタップでアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-290">In the following example, all three buttons inside FavoritesBar will be activated on the first tap.</span></span>

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

## <a name="get-the-sample-code"></a><span data-ttu-id="f9c54-291">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="f9c54-291">Get the sample code</span></span>

- <span data-ttu-id="f9c54-292">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="f9c54-292">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="f9c54-293">関連記事</span><span class="sxs-lookup"><span data-stu-id="f9c54-293">Related articles</span></span>
- [<span data-ttu-id="f9c54-294">ヒント</span><span class="sxs-lookup"><span data-stu-id="f9c54-294">Tooltips</span></span>](tooltips.md)
- [<span data-ttu-id="f9c54-295">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="f9c54-295">Menus and context menu</span></span>](menus.md)
- [<span data-ttu-id="f9c54-296">Flyout クラス</span><span class="sxs-lookup"><span data-stu-id="f9c54-296">Flyout class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [<span data-ttu-id="f9c54-297">ContentDialog クラス</span><span class="sxs-lookup"><span data-stu-id="f9c54-297">ContentDialog class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)
