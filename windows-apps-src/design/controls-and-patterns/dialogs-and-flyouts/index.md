---
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ダイアログとポップアップ
template: detail.hbs
ms.date: 07/06/2018
ms.topic: article
keywords: Windows 10、UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2d5635a41bec716487c08dd57e6ba2ac360649ad
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7984638"
---
# <a name="dialogs-and-flyouts"></a><span data-ttu-id="752fe-103">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="752fe-103">Dialogs and flyouts</span></span>



<span data-ttu-id="752fe-104">ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="752fe-104">Dialogs and flyouts are transient UI elements that appear when something happens that requires notification, approval, or additional information from the user.</span></span>

> <span data-ttu-id="752fe-105">**重要な API**: [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)、[Flyout クラス](/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span><span class="sxs-lookup"><span data-stu-id="752fe-105">**Important APIs**: [ContentDialog class](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog), [Flyout class](/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span></span>


:::row:::
    :::column:::
        **Dialogs**
        
        ![Example of a dialog](../images/dialogs/dialog_RS2_delete_file.png)

        Dialogs are modal UI overlays that provide contextual app information. Dialogs block interactions with the app window until being explicitly dismissed. They often request some kind of action from the user.
    :::column-end:::
    :::column::: 
        **Flyouts**

        ![Example of a flyout](../images/flyout-example2.png)

        A flyout is a lightweight contextual popup that displays UI related to what the user is doing. It includes placement and sizing logic, and can be used to reveal a secondary control or show more detail about an item.

        Unlike a dialog, a flyout can be quickly dismissed by tapping or clicking somewhere outside the flyout, pressing the Escape key or Back button, resizing the app window, or changing the device's orientation.
    :::column-end:::
:::row-end:::


## <a name="is-this-the-right-control"></a><span data-ttu-id="752fe-106">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="752fe-106">Is this the right control?</span></span>

<span data-ttu-id="752fe-107">ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。</span><span class="sxs-lookup"><span data-stu-id="752fe-107">Dialogs and flyouts make sure that users are aware of important information, but they also disrupt the user experience.</span></span> <span data-ttu-id="752fe-108">ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="752fe-108">Because dialogs are modal (blocking), they interrupt users, preventing them from doing anything else until they interact with the dialog.</span></span> <span data-ttu-id="752fe-109">ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。</span><span class="sxs-lookup"><span data-stu-id="752fe-109">Flyouts provide a less jarring experience, but displaying too many flyouts can be distracting.</span></span>

<span data-ttu-id="752fe-110">ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="752fe-110">Once you've determined that you want to use a dialog or flyout, you need to choose which one to use.</span></span>

<span data-ttu-id="752fe-111">ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="752fe-111">Given that dialogs block interactions and flyouts do not, dialogs should be reserved for situations where you want the user to drop everything to focus on a specific bit of information or answer a question.</span></span> <span data-ttu-id="752fe-112">一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="752fe-112">Flyouts, on the other hand, can be used when you want to call attention to something, but it's ok if the user wants to ignore it.</span></span>

:::row:::
    :::column:::
   <p><b><span data-ttu-id="752fe-113">ダイアログの用途:</span><span class="sxs-lookup"><span data-stu-id="752fe-113">Use a dialog for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="752fe-114">続行前にユーザーが読んだり確認したりする<b>必要のある重要な</b>情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="752fe-114">Expressing important information that the user <b>must</b> read and acknowledge before proceeding.</span></span> <span data-ttu-id="752fe-115">次のようなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="752fe-115">Examples include:</span></span>
<ul>
  <li><span data-ttu-id="752fe-116">ユーザーのセキュリティが侵害される可能性がある場合</span><span class="sxs-lookup"><span data-stu-id="752fe-116">When the user's security might be compromised</span></span></li>
  <li><span data-ttu-id="752fe-117">ユーザーが重要な資産に永続的な変更を加えようとしている場合</span><span class="sxs-lookup"><span data-stu-id="752fe-117">When the user is about to permanently alter a valuable asset</span></span></li>
  <li><span data-ttu-id="752fe-118">ユーザーが重要な資産を削除しようとしている場合</span><span class="sxs-lookup"><span data-stu-id="752fe-118">When the user is about to delete a valuable asset</span></span></li>
  <li><span data-ttu-id="752fe-119">アプリ内購入を確認する場合</span><span class="sxs-lookup"><span data-stu-id="752fe-119">To confirm an in-app purchase</span></span></li>
</ul>

</li>
<li><span data-ttu-id="752fe-120">接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="752fe-120">Error messages that apply to the overall app context, such as a connectivity error.</span></span></li>
<li><span data-ttu-id="752fe-121">アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など)</span><span class="sxs-lookup"><span data-stu-id="752fe-121">Questions, when the app needs to ask the user a blocking question, such as when the app can't choose on the user's behalf.</span></span> <span data-ttu-id="752fe-122">ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="752fe-122">A blocking question can't be ignored or postponed, and should offer the user well-defined choices.</span></span></li>
</ul>
</p>
    :::column-end:::
    :::column:::
   <p><b><span data-ttu-id="752fe-123">ポップアップの用途:</span><span class="sxs-lookup"><span data-stu-id="752fe-123">Use a flyout for...</span></span></b> <br/>
<ul>
<li><span data-ttu-id="752fe-124">操作を完了する前に、必要な追加情報を収集する場合。</span><span class="sxs-lookup"><span data-stu-id="752fe-124">Collecting additional information needed before an action can be completed.</span></span></li>
<li><span data-ttu-id="752fe-125">一部の場合のみに意味がある情報を表示する場合。</span><span class="sxs-lookup"><span data-stu-id="752fe-125">Displaying info that's only relevant some of the time.</span></span> <span data-ttu-id="752fe-126">たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="752fe-126">For example, in a photo gallery app, when the user clicks an image thumbnail, you might use a flyout to display a large version of the image.</span></span></li>
<li><span data-ttu-id="752fe-127">詳細やページ上の項目の長い説明などの詳しい情報の表示。</span><span class="sxs-lookup"><span data-stu-id="752fe-127">Displaying more information, such as details or longer descriptions of an item on the page.</span></span></li>
</ul></p>
    :::column-end:::
:::row-end:::


## <a name="ways-to-avoid-using-dialogs-and-flyouts"></a><span data-ttu-id="752fe-128">ダイアログとポップアップを使用しないようにする方法</span><span class="sxs-lookup"><span data-stu-id="752fe-128">Ways to avoid using dialogs and flyouts</span></span>

<span data-ttu-id="752fe-129">伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="752fe-129">Consider the importance of the information you want to share: is it important enough to interrupt the user?</span></span> <span data-ttu-id="752fe-130">また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。</span><span class="sxs-lookup"><span data-stu-id="752fe-130">Also consider how frequently the information needs to be shown; if you're showing a dialog or notification every few minutes, you might want to allocate space for this info in the primary UI instead.</span></span> <span data-ttu-id="752fe-131">たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="752fe-131">For example, in a chat client, rather than showing a flyout every time a friend logs in, you might display a list of friends who are online at the moment and highlight friends as they log on.</span></span>

<span data-ttu-id="752fe-132">ダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。</span><span class="sxs-lookup"><span data-stu-id="752fe-132">Dialogs are frequently used to confirm an action (such as deleting a file) before executing it.</span></span> <span data-ttu-id="752fe-133">ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。</span><span class="sxs-lookup"><span data-stu-id="752fe-133">If you expect the user to perform a particular action frequently, consider providing a way for the user to undo the action if it was a mistake, rather than forcing users to confirm the action every time.</span></span>

## <a name="how-to-create-a-dialog"></a><span data-ttu-id="752fe-134">ダイアログを作成する方法</span><span class="sxs-lookup"><span data-stu-id="752fe-134">How to create a dialog</span></span>

<span data-ttu-id="752fe-135">[ダイアログ ボックスの記事](dialogs.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="752fe-135">See the [Dialogs article](dialogs.md).</span></span> 

## <a name="how-to-create-a-flyout"></a><span data-ttu-id="752fe-136">ポップアップを作成する方法</span><span class="sxs-lookup"><span data-stu-id="752fe-136">How to create a flyout</span></span>

<span data-ttu-id="752fe-137">[ポップアップの記事](flyouts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="752fe-137">See the [Flyout article](flyouts.md).</span></span> 

## <a name="examples"></a><span data-ttu-id="752fe-138">例</span><span class="sxs-lookup"><span data-stu-id="752fe-138">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="752fe-139">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="752fe-139">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="752fe-140"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="752fe-140">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> or <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="752fe-141">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="752fe-141">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="752fe-142">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="752fe-142">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

