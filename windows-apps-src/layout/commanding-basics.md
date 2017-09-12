---
author: mijacobs
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリでは、コマンド要素は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。"
title: "ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本"
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 868221cce04688ea2f7ab50e3062579932fbbd80
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
#  <a name="command-design-basics-for-uwp-apps"></a><span data-ttu-id="f4f00-104">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="f4f00-104">Command design basics for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="f4f00-105">ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="f4f00-105">In a Universal Windows Platform (UWP) app, *command elements* are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> <span data-ttu-id="f4f00-106">この記事では、ボタンやチェック ボックスなどのコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするコマンド サーフェス (コマンド バーやショートカット メニューなど) について説明します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-106">This article describes the command elements, such as buttons and check boxes, the interactions they support, and the command surfaces (such as command bars and context menus) for hosting them.</span></span>

> <span data-ttu-id="f4f00-107">**重要な API**: [ICommand インターフェイス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Input.ICommand)、[Button クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Button)、[CommandBar クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.commandbar)、[MenuFlyout クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.MenuFlyout)</span><span class="sxs-lookup"><span data-stu-id="f4f00-107">**Important APIs**: [ICommand interface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Input.ICommand), [Button class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Button), [CommandBar class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.commandbar), [MenuFlyout class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.MenuFlyout)</span></span>

## <a name="provide-the-right-type-of-interactions"></a><span data-ttu-id="f4f00-108">適切な種類の操作の提供</span><span class="sxs-lookup"><span data-stu-id="f4f00-108">Provide the right type of interactions</span></span>

<span data-ttu-id="f4f00-109">コマンド インターフェイスを設計する際、最も重要な決定はユーザーが何を実行できる必要があるかという点です。</span><span class="sxs-lookup"><span data-stu-id="f4f00-109">When designing a command interface, the most important decision is choosing what users should be able to do.</span></span> <span data-ttu-id="f4f00-110">たとえば、フォト アプリを作成している場合、ユーザーには写真を編集するツールが必要です。</span><span class="sxs-lookup"><span data-stu-id="f4f00-110">For example, if you're creating a photo app, the user will need tools to edit their photos.</span></span> <span data-ttu-id="f4f00-111">ただし、写真を表示できるソーシャル メディア アプリを作成している場合は、イメージ編集の優先度は高く可能性があるので、スペース節約のために編集ツールを省略できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-111">However, if you're creating a social media app that happens to display photos, image editing might not be a priority and so editing tools can be omitted to save space.</span></span> <span data-ttu-id="f4f00-112">ユーザーが達成する目的を決定して、それに役立つツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-112">Decide what you want users to accomplish and provide the tools to help them do it.</span></span>

<span data-ttu-id="f4f00-113">アプリの適切なインターフェイスを計画する際の推奨事項については、「[アプリの計画](https://msdn.microsoft.com/library/windows/apps/hh465427.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-113">For recommendations about how to plan the right interactions for your app, see [Plan your app](https://msdn.microsoft.com/library/windows/apps/hh465427.aspx).</span></span>

## <a name="use-the-right-command-element-for-the-interaction"></a><span data-ttu-id="f4f00-114">操作に適切なコマンド要素を使用</span><span class="sxs-lookup"><span data-stu-id="f4f00-114">Use the right command element for the interaction</span></span>


<span data-ttu-id="f4f00-115">適切な操作に適切な要素を使うことは、直感的に使うことができるアプリとなるか、使いにくくてややこしいアプリとなるかの分かれ目になります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-115">Using the right elements for the right interactions can mean the difference between an app that feels intuitive to use and one that seems difficult or confusing.</span></span> <span data-ttu-id="f4f00-116">ユニバーサル Windows プラットフォーム (UWP) には、アプリで使うことができる多くのコマンド要素セットがコントロールの形で用意されています。</span><span class="sxs-lookup"><span data-stu-id="f4f00-116">The Universal Windows Platform (UWP) provides a large set of command elements, in the form of controls, that you can use in your app.</span></span> <span data-ttu-id="f4f00-117">最も一般的ないくつかのコントロールの一覧と、それによって可能になる操作の概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-117">Here's a list of some of the most common controls and a summary of the interactions they enable.</span></span>

| <span data-ttu-id="f4f00-118">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="f4f00-118">Category</span></span>              | <span data-ttu-id="f4f00-119">要素</span><span class="sxs-lookup"><span data-stu-id="f4f00-119">Elements</span></span>                                                                                                                                                                                                            | <span data-ttu-id="f4f00-120">操作</span><span class="sxs-lookup"><span data-stu-id="f4f00-120">Interaction</span></span>                                                                                                                                        |
|-----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="f4f00-121">ボタン</span><span class="sxs-lookup"><span data-stu-id="f4f00-121">Buttons</span></span>               | [<span data-ttu-id="f4f00-122">ボタン</span><span class="sxs-lookup"><span data-stu-id="f4f00-122">Button</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465470)                                                                                                                                                     | <span data-ttu-id="f4f00-123">メール送信、ダイアログでのアクションの確認、フォーム データの送信など、即座にアクションをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-123">Triggers an immediate action, such as sending an email, confirming an action in a dialog, submitting form data.</span></span>                                    |
| <span data-ttu-id="f4f00-124">日付/時刻選択ツール</span><span class="sxs-lookup"><span data-stu-id="f4f00-124">Date and time pickers</span></span> | [<span data-ttu-id="f4f00-125">カレンダーの日付選択ツール、カレンダー ビュー、日付の選択、時刻の選択</span><span class="sxs-lookup"><span data-stu-id="f4f00-125">calendar date picker, calendar view, date picker, time picker</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465466)                                                                                                                 | <span data-ttu-id="f4f00-126">クレジット カードの有効期限を入力したり、アラームを設定したりするときなどに、ユーザーが日時情報を表示して変更できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-126">Enables the user to view and modify date and time info, such as when entering a credit card expiration date or setting an alarm.</span></span>                   |
| <span data-ttu-id="f4f00-127">リスト</span><span class="sxs-lookup"><span data-stu-id="f4f00-127">Lists</span></span>                 | [<span data-ttu-id="f4f00-128">ドロップダウン リスト、リスト ボックス、リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="f4f00-128">drop-down list, list box, list view and grid view</span></span>](https://msdn.microsoft.com/library/windows/apps/mt186889)                                                                                                                                              | <span data-ttu-id="f4f00-129">対話型のリストまたはグリッド内に項目を表示します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-129">Presents items in a interactive list or a grid.</span></span> <span data-ttu-id="f4f00-130">これらの要素を使うと、ユーザーは新着の一覧からムービーを選んだり、在庫を管理したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-130">Use these elements to let users select a movie from a list of new releases or manage an inventory.</span></span> |
| <span data-ttu-id="f4f00-131">テキスト予測入力</span><span class="sxs-lookup"><span data-stu-id="f4f00-131">Predictive text entry</span></span> | [<span data-ttu-id="f4f00-132">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="f4f00-132">Auto-suggest box</span></span>](https://msdn.microsoft.com/library/windows/apps/dn997762)                                                                                                                                                                    | <span data-ttu-id="f4f00-133">入力候補を表示して、ユーザーがデータを入力したりクエリを実行したりする時間を節約できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-133">Saves users time when entering data or performing queries by providing suggestions as they type.</span></span>                                                   |
| <span data-ttu-id="f4f00-134">選択コントロール</span><span class="sxs-lookup"><span data-stu-id="f4f00-134">Selection controls</span></span>    | <span data-ttu-id="f4f00-135">[チェック ボックス](https://msdn.microsoft.com/library/windows/apps/hh700393)、[ラジオ ボタン](https://msdn.microsoft.com/library/windows/apps/hh700395)、[トグル スイッチ](https://msdn.microsoft.com/library/windows/apps/hh465475)</span><span class="sxs-lookup"><span data-stu-id="f4f00-135">[check box](https://msdn.microsoft.com/library/windows/apps/hh700393), [radio button](https://msdn.microsoft.com/library/windows/apps/hh700395), [toggle switch](https://msdn.microsoft.com/library/windows/apps/hh465475)</span></span> | <span data-ttu-id="f4f00-136">アンケートに入力するときや、アプリ設定を構成するときなど、ユーザーがさまざまなオプションを選ぶことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-136">Lets the user choose between different options, such as when completing a survey or configuring app settings.</span></span>                                      |

 

<span data-ttu-id="f4f00-137">全一覧については、「[コントロールと UI 要素](https://dev.windows.com/design/controls-patterns)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-137">For a complete list, see [Controls and UI elements](https://dev.windows.com/design/controls-patterns)</span></span>

##  <a name="place-commands-on-the-right-surface"></a><span data-ttu-id="f4f00-138">適切なサーフェスへのコマンドの配置</span><span class="sxs-lookup"><span data-stu-id="f4f00-138">Place commands on the right surface</span></span>


<span data-ttu-id="f4f00-139">アプリのキャンバス (アプリのコンテンツ領域) や、コマンド バー、メニュー、ダイアログ、ポップアップなどコマンド コンテナーとして機能する特殊なコマンド要素を含む、アプリの多くのサーフェスにコマンド要素を配置できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-139">You can place command elements on a number of surfaces in your app, including the app canvas (the content area of your app) or special command elements that can act as command containers, such as command bars, menus, dialogs, and flyouts.</span></span> <span data-ttu-id="f4f00-140">コマンドを配置する際の一般的な推奨事項は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f4f00-140">Here are some general recommendations for placing commands:</span></span>

-   <span data-ttu-id="f4f00-141">できる限り、コンテンツを操作するコマンドを用意せず、アプリのキャンバス上でユーザーがコンテンツを直接操作できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-141">Whenever possible, let users directly manipulate the content on the app's canvas, rather than adding commands that act on the content.</span></span> <span data-ttu-id="f4f00-142">たとえば、旅行アプリで旅行計画を編集するときに、リスト内のアクティビティを上下に移動するコマンド ボタンを使うのではなく、キャンバスのリスト上でアクティビティをドラッグ アンド ドロップできるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-142">For example, in the travel app, let users rearrange their itinerary by dragging and dropping activities in a list on the canvas, rather than by selecting the activity and using Up or Down command buttons.</span></span>
-   <span data-ttu-id="f4f00-143">ユーザーが直接コンテンツを操作できない場合は、コマンドを次の UI サーフェスのいずれかに配置します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-143">Otherwise, place commands on one of these UI surfaces if users can't manipulate content directly:</span></span>

    -   <span data-ttu-id="f4f00-144">[コマンド バー](https://msdn.microsoft.com/library/windows/apps/hh465302): ほとんどのコマンドはコマンド バーに配置してください。コマンドを整理しやすくなり、アクセスしやすくなります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-144">In the [command bar](https://msdn.microsoft.com/library/windows/apps/hh465302): You should put most commands on the command bar, which helps to organize commands and makes them easy to access.</span></span>
    -   <span data-ttu-id="f4f00-145">アプリのキャンバス上: 目的が 1 つに限られているページまたはビューは、その目的用のコマンドをキャンバス上に直接配置できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-145">On the app's canvas: If the user is on a page or view that has a single purpose, you can provide commands for that purpose directly on the canvas.</span></span> <span data-ttu-id="f4f00-146">しかし、このようなコマンドはなるべく作らないでください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-146">There should be very few of these commands.</span></span>
    -   <span data-ttu-id="f4f00-147">[ショートカット メニュー](https://msdn.microsoft.com/library/windows/apps/hh465308): クリップボードの操作 (切り取り、コピー、貼り付けなど) や、選択できないコンテンツに実行するコマンド (地図の目的の位置にピンを追加するなど) に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-147">In a [context menu](https://msdn.microsoft.com/library/windows/apps/hh465308): You can use context menus for clipboard actions (such as cut, copy, and paste), or for commands that apply to content that cannot be selected (like adding a push pin to a location on a map).</span></span>

<span data-ttu-id="f4f00-148">Windows に用意されたコマンド サーフェスの一覧と、それらを使用する際の推奨事項を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-148">Here's a list of the command surfaces that Windows provides and recommendations for when to use them.</span></span>

<table class="uwpd-top-aligned-table">

<tr class="header">
<th align="left"><span data-ttu-id="f4f00-149">サーフェス</span><span class="sxs-lookup"><span data-stu-id="f4f00-149">Surface</span></span></th>
<th align="left"><span data-ttu-id="f4f00-150">説明</span><span class="sxs-lookup"><span data-stu-id="f4f00-150">Description</span></span></th>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top"><span data-ttu-id="f4f00-151">アプリのキャンバス (コンテンツ領域)</span><span class="sxs-lookup"><span data-stu-id="f4f00-151">App canvas (content area)</span></span>
<p><img src="images/content-area.png" alt="The content area of an app" /></p></td>

<td align="left" style="vertical-align: top;"><span data-ttu-id="f4f00-152">あるコマンドが重要で、ユーザーが中心的なシナリオを完了するうえで常に必要な場合は、そのコマンドをキャンバス (アプリのコンテンツ領域) に配置できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-152">If a command is critical and is constantly needed for the user to complete the core scenarios, put it on the canvas (the content area of your app).</span></span> <span data-ttu-id="f4f00-153">コマンドは影響を与えるオブジェクトの近く (またはその上) に配置できるため、キャンバスにコマンドを配置すると使い方がわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-153">Because you can put commands near (or on) the objects they affect, putting commands on the canvas makes them easy and obvious to use.</span></span>
<p><span data-ttu-id="f4f00-154">ただし、キャンバスに配置するコマンドは慎重に選んでください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-154">However, choose the commands you put on the canvas carefully.</span></span> <span data-ttu-id="f4f00-155">アプリのキャンバスにコマンドが多すぎると、貴重な画面のスペースがなくなり、ユーザーを困惑させる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-155">Too many commands on the app canvas takes up valuable screen space and can overwhelm the user.</span></span> <span data-ttu-id="f4f00-156">それほど頻繁に使わないコマンドの場合、メニューやコマンド バーの [その他] 領域など、別のコマンド サーフェスに配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-156">If the command won't be frequently used, consider putting it in another command surface, such as menu or the command bar's &quot;More&quot; area.</span></span></p></td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;">[<span data-ttu-id="f4f00-157">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="f4f00-157">Command bar</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465302)
<p><img src="images/controls-appbar-icons-200.png" alt="Example of a command bar with icons" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="f4f00-158">コマンド バーを使うと、ユーザーはアクションに簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-158">Command bars provide users with easy access to actions.</span></span> <span data-ttu-id="f4f00-159">コマンド バーは、ユーザーのコンテキストに固有のコマンドまたはオプション (写真の選択や描画モードなど) を表示するためにも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-159">You can use a command bar to show commands or options that are specific to the user's context, such as a photo selection or drawing mode.</span></span>
<p><span data-ttu-id="f4f00-160">コマンド バーは画面の上部または画面の下部、あるいは画面の上部と下部の両方に配置できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-160">Command bars can be placed at the top of the screen, at the bottom of the screen, or at both the top and bottom of the screen.</span></span> <span data-ttu-id="f4f00-161">写真編集アプリのこの設計は、コンテンツ領域とコマンド バーを示しています。</span><span class="sxs-lookup"><span data-stu-id="f4f00-161">This design of a photo editing app shows the content area and the command bar:</span></span></p>
<p><img src="images/commands-appcanvas-example.png" alt="A photo app" /></p>
<p><span data-ttu-id="f4f00-162">コマンド バーについて詳しくは、「[コマンド バーのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465302)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-162">For more information about command bars, see the [Guidelines for command bar](https://msdn.microsoft.com/library/windows/apps/hh465302) article.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;">[<span data-ttu-id="f4f00-163">メニューとショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="f4f00-163">Menus and context menus</span></span>](../controls-and-patterns/menus.md)
<p><img src="images/controls-contextmenu-singlepane.png" alt="Example of a single-pane context menu" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="f4f00-164">複数のコマンドをコマンド メニューにグループ化することで効率性が高まる場合があります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-164">Sometimes it is more efficient to group multiple commands into a command menu.</span></span> <span data-ttu-id="f4f00-165">メニューを使うと、より狭い場所により多くのオプションを表示できます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-165">Menus let you present more options with less space.</span></span> <span data-ttu-id="f4f00-166">メニューには対話的なコントロールを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-166">Menus can include interactive controls.</span></span>
<p><span data-ttu-id="f4f00-167">ショートカット メニューは、よく使うアクションへのショートカットを提供し、特定のコンテキストにのみ関連するセカンダリ コマンドにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-167">Context menus can provide shortcuts to commonly-used actions and provide access to secondary commands that are only relevant in certain contexts.</span></span></p>
<p><span data-ttu-id="f4f00-168">ショートカット メニューは、次の種類のコマンドとコマンド シナリオを対象としています。</span><span class="sxs-lookup"><span data-stu-id="f4f00-168">Context menus are for the following types of commands and command scenarios:</span></span></p>
<ul>
<li><span data-ttu-id="f4f00-169">選んだテキストに対する状況依存の操作 (コピー、切り取り、貼り付け、スペル チェックなど)。</span><span class="sxs-lookup"><span data-stu-id="f4f00-169">Contextual actions on text selections, such as Copy, Cut, Paste, Check Spelling, and so on.</span></span></li>
<li><span data-ttu-id="f4f00-170">操作する必要があるものの、選択することも、他の方法で指定することもできないオブジェクトのためのコマンド。</span><span class="sxs-lookup"><span data-stu-id="f4f00-170">Commands for an object that needs to be acted upon but that can't be selected or otherwise indicated.</span></span></li>
<li><span data-ttu-id="f4f00-171">クリップボード コマンドの表示。</span><span class="sxs-lookup"><span data-stu-id="f4f00-171">Showing clipboard commands.</span></span></li>
<li><span data-ttu-id="f4f00-172">カスタム コマンド。</span><span class="sxs-lookup"><span data-stu-id="f4f00-172">Custom commands.</span></span></li>
</ul>
<p><span data-ttu-id="f4f00-173">この例は、ショートカット メニューを使って経路の変更、経路のブックマーク登録、別の電車の選択を行う地下鉄アプリのデザインを示しています。</span><span class="sxs-lookup"><span data-stu-id="f4f00-173">This example shows the design for a subway app that uses a context menu to modify the route, bookmark a route, or select another train.</span></span></p>
<p><img src="images/subway/uap-subway-ak-8in-dashboard-200.png" alt="A context menu in an subway app" /></p>
<p><span data-ttu-id="f4f00-174">ショートカット メニューについて詳しくは、「[ショートカット メニューのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465308)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-174">For more info about context menus, see the [Guidelines for context menu](https://msdn.microsoft.com/library/windows/apps/hh465308) article.</span></span></p></td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;">[<span data-ttu-id="f4f00-175">ダイアログ コントロール</span><span class="sxs-lookup"><span data-stu-id="f4f00-175">Dialog controls</span></span>](../controls-and-patterns/dialogs.md)
<p><img src="images/controls-dialog-twobutton-200.png" alt="Example of a simple two-button dialog" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="f4f00-176">ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="f4f00-176">Dialogs are modal UI overlays that provide contextual app information.</span></span> <span data-ttu-id="f4f00-177">ほとんどの場合、ダイアログは明示的に閉じられまでアプリ ウィンドウの操作を妨げます。また、多くの場合、ユーザーに操作を要求します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-177">In most cases, dialogs block interactions with the app window until being explicitly dismissed, and often request some kind of action from the user.</span></span>
<p><span data-ttu-id="f4f00-178">ダイアログは、煩わしく感じることがあるため、特定の状況でのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-178">Dialogs can be disruptive and should only be used in certain situations.</span></span> <span data-ttu-id="f4f00-179">詳しくは、「[アクションを確認または元に戻すタイミング](#whentoconfirm)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-179">For more info, see the [When to confirm or undo actions](#whentoconfirm) section.</span></span></p></td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;">[<span data-ttu-id="f4f00-180">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="f4f00-180">Flyout</span></span>](../controls-and-patterns/dialogs.md)
<p><img src="images/controls-flyout-default-200.png" alt="Image of default flyout" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="f4f00-181">ユーザーが現在操作している内容に関係する UI を表示する軽量な状況依存のポップアップです。</span><span class="sxs-lookup"><span data-stu-id="f4f00-181">A lightweight contextual popup that displays UI related to what the user is doing.</span></span> <span data-ttu-id="f4f00-182">ポップアップは、次の目的で使います。</span><span class="sxs-lookup"><span data-stu-id="f4f00-182">Use a flyout to:</span></span>
<p></p>
<ul>
<li><span data-ttu-id="f4f00-183">メニューを表示する。</span><span class="sxs-lookup"><span data-stu-id="f4f00-183">Show a menu.</span></span></li>
<li><span data-ttu-id="f4f00-184">項目の詳細を表示する。</span><span class="sxs-lookup"><span data-stu-id="f4f00-184">Show more detail about an item.</span></span></li>
<li><span data-ttu-id="f4f00-185">アプリの操作をブロックしないでユーザーにアクションの確認を求める。</span><span class="sxs-lookup"><span data-stu-id="f4f00-185">Ask the user to confirm an action without blocking interaction with the app.</span></span></li>
</ul>
<p><span data-ttu-id="f4f00-186">ポップアップは、その外側をタップするかクリックすることで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-186">Flyouts can be dismissed by tapping or clicking somewhere outside the flyout.</span></span> <span data-ttu-id="f4f00-187">ポップアップ コントロールについて詳しくは、「[ダイアログとポップアップ](../controls-and-patterns/dialogs.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-187">For more info about flyout controls, see the [Dialogs and flyouts](../controls-and-patterns/dialogs.md) article.</span></span></p></td>
</tr>
</table>

 

## <a name="when-to-confirm-or-undo-actions"></a><span data-ttu-id="f4f00-188">アクションを確認または元に戻すタイミング</span><span class="sxs-lookup"><span data-stu-id="f4f00-188">When to confirm or undo actions</span></span>


<span data-ttu-id="f4f00-189">適切に設計されたユーザー インターフェイスであっても、ユーザーがどれほど慎重に作業したとしても、すべてのユーザーは必ず意図しないアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="f4f00-189">No matter how well-designed the user interface is and no matter how careful the user is, at some point, all users will perform an action they wish they hadn't.</span></span> <span data-ttu-id="f4f00-190">ユーザーにアクションの確認を求めたり、最近のアクションを元に戻す方法を用意したりして、アプリでこのような状況に対処することができます。</span><span class="sxs-lookup"><span data-stu-id="f4f00-190">Your app can help in these situations by requiring the user to confirm an action, or by providing a way of undoing recent actions.</span></span>

-   <span data-ttu-id="f4f00-191">元に戻すことができず、実行結果が重大な操作の場合は、確認ダイアログ ボックスの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f4f00-191">For actions that can't be undone and have major consequences, we recommend using a confirmation dialog.</span></span> <span data-ttu-id="f4f00-192">このような操作の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f4f00-192">Examples of such actions include:</span></span>
    -   <span data-ttu-id="f4f00-193">ファイルを上書きする</span><span class="sxs-lookup"><span data-stu-id="f4f00-193">Overwriting a file</span></span>
    -   <span data-ttu-id="f4f00-194">ファイルを保存せずに終了する</span><span class="sxs-lookup"><span data-stu-id="f4f00-194">Not saving a file before closing</span></span>
    -   <span data-ttu-id="f4f00-195">ファイルやデータを完全に削除することを確認する</span><span class="sxs-lookup"><span data-stu-id="f4f00-195">Confirming permanent deletion of a file or data</span></span>
    -   <span data-ttu-id="f4f00-196">購入する (確認メッセージを表示しないことをユーザーが選択した場合を除く)</span><span class="sxs-lookup"><span data-stu-id="f4f00-196">Making a purchase (unless the user opts out of requiring a confirmation)</span></span>
    -   <span data-ttu-id="f4f00-197">何かへのサインアップなどのフォームを送信する</span><span class="sxs-lookup"><span data-stu-id="f4f00-197">Submitting a form, such as signing up for something</span></span>
-   <span data-ttu-id="f4f00-198">元に戻すことができる操作の場合は、通常、単純な "元に戻す" コマンドを提供すれば十分です。</span><span class="sxs-lookup"><span data-stu-id="f4f00-198">For actions that can be undone, offering a simple undo command is usually enough.</span></span> <span data-ttu-id="f4f00-199">このような操作の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f4f00-199">Examples of such actions include:</span></span>
    -   <span data-ttu-id="f4f00-200">ファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="f4f00-200">Deleting a file</span></span>
    -   <span data-ttu-id="f4f00-201">メールを削除する (完全には削除しない)</span><span class="sxs-lookup"><span data-stu-id="f4f00-201">Deleting an email (not permanently)</span></span>
    -   <span data-ttu-id="f4f00-202">コンテンツを変更する、またはテキストを編集する</span><span class="sxs-lookup"><span data-stu-id="f4f00-202">Modifying content or editing text</span></span>
    -   <span data-ttu-id="f4f00-203">ファイル名を変更する</span><span class="sxs-lookup"><span data-stu-id="f4f00-203">Renaming a file</span></span>

> [!TIP]
> <span data-ttu-id="f4f00-204">アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。</span><span class="sxs-lookup"><span data-stu-id="f4f00-204">Be careful of how much your app uses confirmation dialogs; they can be very helpful when the user makes a mistake, but they are a hindrance whenever the user is trying to perform an action intentionally.</span></span>

 

##  <a name="optimize-for-specific-input-types"></a><span data-ttu-id="f4f00-205">特定の入力タイプの最適化</span><span class="sxs-lookup"><span data-stu-id="f4f00-205">Optimize for specific input types</span></span>


<span data-ttu-id="f4f00-206">特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input-and-devices/input-primer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4f00-206">See the [Interaction primer](../input-and-devices/input-primer.md) for more detail on optimizing user experiences around a specific input type or device.</span></span>




 

 




