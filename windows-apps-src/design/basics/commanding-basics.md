---
author: mijacobs
Description: In a Universal Windows Platform (UWP) app, command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
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
ms.localizationpriority: medium
ms.openlocfilehash: 07b9ce7b5a57f6dc1ba202ed57e8b2d4d93e583f
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654391"
---
#  <a name="command-design-basics-for-uwp-apps"></a><span data-ttu-id="28a9d-103">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="28a9d-103">Command design basics for UWP apps</span></span>

<span data-ttu-id="28a9d-104">ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-104">In a Universal Windows Platform (UWP) app, *command elements* are interactive UI elements that enable users to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> 

<span data-ttu-id="28a9d-105">この記事では、一般的なコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするためのコマンド サーフェスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-105">This article describes common command elements, the interactions they support, and the command surfaces for hosting them.</span></span>

![マップ アプリのコマンド要素](images/maps.png)

<span data-ttu-id="28a9d-107">上に、マップ アプリのコマンド要素の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="28a9d-107">Above, see examples of command elements in the Maps app.</span></span>

## <a name="provide-the-right-type-of-interactions"></a><span data-ttu-id="28a9d-108">適切な種類の操作の提供</span><span class="sxs-lookup"><span data-stu-id="28a9d-108">Provide the right type of interactions</span></span>

<span data-ttu-id="28a9d-109">コマンド インターフェイスを設計する際、最も重要な決定はユーザーが何を実行できる必要があるかという点です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-109">When designing a command interface, the most important decision is choosing what users should be able to do.</span></span> <span data-ttu-id="28a9d-110">適切な種類の操作を計画するには、アプリに集中して、有効にするユーザー エクスペリエンス、およびユーザーが行う必要がある操作の手順を検討します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-110">To plan the right type of interactions, focus on your app - consider the user experiences you want to enable, and what steps users will need to take.</span></span> <span data-ttu-id="28a9d-111">ユーザーが実行できる操作を決定したら、それを行うためのツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-111">Once you decide what you want users to accomplish, then you can provide them the tools to do so.</span></span>

<span data-ttu-id="28a9d-112">アプリで提供する操作には次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-112">Some interactions you might want to provide your app include:</span></span>

- <span data-ttu-id="28a9d-113">情報の送信または提出</span><span class="sxs-lookup"><span data-stu-id="28a9d-113">Sending or submiting information</span></span> 
- <span data-ttu-id="28a9d-114">設定とオプションの選択</span><span class="sxs-lookup"><span data-stu-id="28a9d-114">Selecting settings and choices</span></span>
- <span data-ttu-id="28a9d-115">コンテンツの検索とフィルター処理</span><span class="sxs-lookup"><span data-stu-id="28a9d-115">Searching and filtering content</span></span>
- <span data-ttu-id="28a9d-116">ファイルを開く、保存する、削除する</span><span class="sxs-lookup"><span data-stu-id="28a9d-116">Opening, saving, and deleting files</span></span>
- <span data-ttu-id="28a9d-117">コンテンツの編集または作成</span><span class="sxs-lookup"><span data-stu-id="28a9d-117">Editing or creating content</span></span>

## <a name="use-the-right-command-element-for-the-interaction"></a><span data-ttu-id="28a9d-118">操作に適切なコマンド要素を使用</span><span class="sxs-lookup"><span data-stu-id="28a9d-118">Use the right command element for the interaction</span></span>

<span data-ttu-id="28a9d-119">適切な要素を使ってコマンド操作を実行することは、直感的で使いやすいアプリとなるか、使いにくくてややこしいアプリとなるかの分かれ目になります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-119">Using the right elements to enable command interactions can make the difference between an intuitive, easy-to-use app and a difficult, confusing app.</span></span> <span data-ttu-id="28a9d-120">ユニバーサル Windows プラットフォーム (UWP) には、アプリで使うことができる多くのコマンド要素セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="28a9d-120">The Universal Windows Platform (UWP) provides a large set of command elements that you can use in your app.</span></span> <span data-ttu-id="28a9d-121">最も一般的ないくつかのコントロールの一覧と、それによって可能になる操作の概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-121">Here's a list of some of the most common controls and a summary of the interactions they can enable.</span></span>

<div class="mx-responsive-img">
<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="28a9d-122">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="28a9d-122">Category</span></span></th>
<th align="left"><span data-ttu-id="28a9d-123">要素</span><span class="sxs-lookup"><span data-stu-id="28a9d-123">Elements</span></span></th>
<th align="left"><span data-ttu-id="28a9d-124">操作</span><span class="sxs-lookup"><span data-stu-id="28a9d-124">Interaction</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b><span data-ttu-id="28a9d-125">ボタン</span><span class="sxs-lookup"><span data-stu-id="28a9d-125">Buttons</span></span></b><br/><br/>
    <img src="../controls-and-patterns/images/controls/button.png" alt="button" /></td>
<td align="left"><a href="../controls-and-patterns/buttons.md"><span data-ttu-id="28a9d-126">ボタン</span><span class="sxs-lookup"><span data-stu-id="28a9d-126">Button</span></span></a></td>
<td align="left"><span data-ttu-id="28a9d-127">即座にアクションをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-127">Triggers an immediate action.</span></span> <span data-ttu-id="28a9d-128">メールの送信、フォーム データの送信、ダイアログでのアクションの確認などの操作です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-128">Examples include sending an email, submitting form data, or confirming an action in a dialog.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="28a9d-129">リスト</span><span class="sxs-lookup"><span data-stu-id="28a9d-129">Lists</span></span><br/><br/>
    <img src="../controls-and-patterns/images/controls/combo-box-open.png" alt="drop down list" /></td>
<td align="left"><a href="../controls-and-patterns/lists.md"><span data-ttu-id="28a9d-130">ドロップダウン リスト、リスト ボックス、リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="28a9d-130">drop-down list, list box, list view and grid view</span></span></a></td>
<td align="left"><span data-ttu-id="28a9d-131">対話型のリストまたはグリッド内に項目を表示します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-131">Presents items in a interactive list or a grid.</span></span> <span data-ttu-id="28a9d-132">通常、オプションや表示項目が多い場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-132">Usually used for many options or display items.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="28a9d-133">選択コントロール</span><span class="sxs-lookup"><span data-stu-id="28a9d-133">Selection controls</span></span><br/><br/>
    <img src="../controls-and-patterns/images/controls/radio-button.png" alt="radio button" /></td>
<td align="left"><span data-ttu-id="28a9d-134"><a href="../controls-and-patterns/checkbox.md">チェック ボックス</a>、<a href="../controls-and-patterns/radio-button.md">ラジオ ボタン</a>、<a href="../controls-and-patterns/toggles.md">トグル スイッチ</a></span><span class="sxs-lookup"><span data-stu-id="28a9d-134"><a href="../controls-and-patterns/checkbox.md">check box</a>, <a href="../controls-and-patterns/radio-button.md">radio button</a>, <a href="../controls-and-patterns/toggles.md">toggle switch</a></span></span></td>
<td align="left"><span data-ttu-id="28a9d-135">アンケートに入力するときや、アプリ設定を構成するときなどに、ユーザーがいくつかのオプションから選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-135">Lets users choose from a few options, such as when completing a survey or configuring app settings.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="28a9d-136">日付/時刻選択ツール</span><span class="sxs-lookup"><span data-stu-id="28a9d-136">Date and time pickers</span></span><br/><br/>
    <img src="../controls-and-patterns/images/controls/calendar-date-picker-open.png" alt="date picker" /></td>
<td align="left"><a href="../controls-and-patterns/date-and-time.md"><span data-ttu-id="28a9d-137">カレンダーの日付選択ツール、カレンダー ビュー、日付の選択、時刻の選択</span><span class="sxs-lookup"><span data-stu-id="28a9d-137">calendar date picker, calendar view, date picker, time picker</span></span></a></td>
<td align="left"><span data-ttu-id="28a9d-138">イベントを作成するときや、アラームを設定するときなどに、ユーザーが日時情報を表示して変更できるようにします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-138">Enables users to view and modify date and time info, such as when creating an event or setting an alarm.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="28a9d-139">テキスト予測入力</span><span class="sxs-lookup"><span data-stu-id="28a9d-139">Predictive text entry</span></span><br/><br/>
    <img src="../controls-and-patterns/images/controls/auto-suggest-box.png" alt="autosuggest box" /></td>
<td align="left"><a href="../controls-and-patterns/auto-suggest-box.md"><span data-ttu-id="28a9d-140">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="28a9d-140">Auto-suggest box</span></span></a></td>
<td align="left"><span data-ttu-id="28a9d-141">データを入力したりクエリを実行したりするときに、ユーザーが入力するにつれて入力候補を表示します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-141">Provides suggestions as users type, such as when entering data or performing queries.</span></span></td>
</tr>
</tbody>
</table>
</div>

<span data-ttu-id="28a9d-142">全一覧については、「[コントロールと UI 要素](https://dev.windows.com/design/controls-patterns)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-142">For a complete list, see [Controls and UI elements](https://dev.windows.com/design/controls-patterns)</span></span>

##  <a name="place-commands-on-the-right-surface"></a><span data-ttu-id="28a9d-143">適切なサーフェスへのコマンドの配置</span><span class="sxs-lookup"><span data-stu-id="28a9d-143">Place commands on the right surface</span></span>
<span data-ttu-id="28a9d-144">アプリのキャンバスや、コマンド バー、メニュー、ダイアログ、ポップアップなどの特殊なコマンド要素を含む、アプリの多くのサーフェスにコマンド要素を配置できます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-144">You can place command elements on a number of surfaces in your app, including the app canvas or special command containers, such as command bars, menus, dialogs, and flyouts.</span></span>

<span data-ttu-id="28a9d-145">できる限り、コンテンツを操作するコマンドを用意せず、ユーザーがコンテンツを直接操作できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-145">Note that, whenever possible, you should allow users to manipulate content directly rather than use commands that act on the content.</span></span> <span data-ttu-id="28a9d-146">たとえば、上下に移動するコマンド ボタンを使うのではなく、リスト項目をドラッグ アンド ドロップしてリストを並べ替えることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-146">For example, allow users to rearrange lists by dragging and dropping list items, rather than using up and down command buttons.</span></span>
  
<span data-ttu-id="28a9d-147">ユーザーが直接コンテンツを操作できない場合は、コマンド要素をアプリのコマンド サーフェスに配置します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-147">Otherwise, if users can't manipulate content directly, then place command elements on a command surface in your app:</span></span>

<div class="mx-responsive-img">
<table class="uwpd-top-aligned-table">

<tr class="header">
<th align="left"><span data-ttu-id="28a9d-148">サーフェス</span><span class="sxs-lookup"><span data-stu-id="28a9d-148">Surface</span></span></th>
<th align="left"><span data-ttu-id="28a9d-149">説明</span><span class="sxs-lookup"><span data-stu-id="28a9d-149">Description</span></span></th>
<th align="left"><span data-ttu-id="28a9d-150">例</span><span class="sxs-lookup"><span data-stu-id="28a9d-150">Example</span></span></th>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top"><span data-ttu-id="28a9d-151">アプリのキャンバス (コンテンツ領域)</span><span class="sxs-lookup"><span data-stu-id="28a9d-151">App canvas (content area)</span></span>
<p><img src="images/content-area.png" alt="The content area of an app" /></p></td>

<td align="left" style="vertical-align: top;"><span data-ttu-id="28a9d-152">ユーザーがコア シナリオを完了するためにあるコマンドが常に必要な場合は、そのコマンドをキャンバスに配置できます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-152">If a command is constantly needed for users to complete core scenarios, put it on the canvas.</span></span> <span data-ttu-id="28a9d-153">コマンドは影響を与えるオブジェクトの近く (またはその上) に配置できるため、キャンバスにコマンドを配置すると使い方がわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-153">Because you can put commands near (or on) the objects they affect, putting commands on the canvas makes them easy and obvious to use.</span></span>
<p><span data-ttu-id="28a9d-154">ただし、キャンバスに配置するコマンドは慎重に選んでください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-154">However, choose the commands you put on the canvas carefully.</span></span> <span data-ttu-id="28a9d-155">アプリのキャンバスにコマンドが多すぎると、貴重な画面のスペースがなくなり、ユーザーを困惑させる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-155">Too many commands on the app canvas take up valuable screen space and can overwhelm the user.</span></span> <span data-ttu-id="28a9d-156">それほど頻繁に使わないコマンドの場合、別のコマンド サーフェスに配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-156">If the command won't be frequently used, consider putting it in another command surface.</span></span></p> 
</td><td>
<span data-ttu-id="28a9d-157">マップ アプリのキャンバス上の自動提案ボックス。</span><span class="sxs-lookup"><span data-stu-id="28a9d-157">An autosuggest box on the Maps app canvas.</span></span>
<br></br>
  <img src="images/maps-canvas.png" alt="autosuggest box on Maps app canvas"/>
</td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/app-bars.md"><span data-ttu-id="28a9d-158">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="28a9d-158">Command bar</span></span></a>
<p><img src="../controls-and-patterns/images/controls_appbar_icons.png" alt="Example of a command bar with icons" /></p></td>
<td align="left" style="vertical-align: top;"> <span data-ttu-id="28a9d-159">コマンド バーを使うと、コマンドを整理しやすくなり、アクセスしやすくなります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-159">Command bars help organize commands and make them easy to access.</span></span> <span data-ttu-id="28a9d-160">コマンド バーは画面の上部または画面の下部、あるいは画面の上部と下部の両方に配置できます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-160">Command bars can be placed at the top of the screen, at the bottom of the screen, or at both the top and bottom of the screen.</span></span> 
</td>
<td>
<span data-ttu-id="28a9d-161">マップ アプリの上部のコマンド バー。</span><span class="sxs-lookup"><span data-stu-id="28a9d-161">A command bar at the top of the Maps app.</span></span>
<br></br>
<img src="images/maps-commandbar.png" alt="command bar in Maps app"/>
</td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/menus.md"><span data-ttu-id="28a9d-162">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="28a9d-162">Menus and context menus</span></span></a>
<p><img src="images/controls-contextmenu-singlepane.png" alt="Example of a single-pane context menu" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="28a9d-163">複数のコマンドをコマンド メニューにグループ化してスペースを節約することで、効率性が高まる場合があります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-163">Sometimes it is more efficient to group multiple commands into a command menu to save space.</span></span> <span data-ttu-id="28a9d-164">メニューとコンテキスト メニューは、ユーザーが要求したときにコマンドやオプションの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-164">Menus and context menus display a list of commands or options when the user requests them.</span></span>
<p><span data-ttu-id="28a9d-165">ショートカット メニューは、よく使うアクションへのショートカットを提供し、クリップボードやカスタム コマンドなど、特定のコンテキストにのみ関連するセカンダリ コマンドにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-165">Context menus can provide shortcuts to commonly-used actions and provide access to secondary commands that are only relevant in certain contexts, such as clipboard or custom commands.</span></span> <span data-ttu-id="28a9d-166">コンテキスト メニューは通常、ユーザーが右クリックすることで表示されます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-166">Context menus are usually prompted by a user right-clicking.</span></span></p>
</td><td>
<span data-ttu-id="28a9d-167">マップ アプリでユーザーが右クリックすると、コンテキスト メニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-167">A context menu appears when users right-click in the Maps app.</span></span>
<br></br>
  <img src="images/maps-contextmenu.png" alt="context menu in Maps app"/>
</td>
</tr>
</table>
</div>

## <a name="provide-feedback-for-interactions"></a><span data-ttu-id="28a9d-168">操作に対するフィードバックの提供</span><span class="sxs-lookup"><span data-stu-id="28a9d-168">Provide feedback for interactions</span></span>

<span data-ttu-id="28a9d-169">フィードバックでコマンドの実行結果を伝えると、ユーザーは実行したことと次に実行できることを把握することができます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-169">Feedback communicates the results of commands and allows users to understand what they've done, and what they can do next.</span></span> <span data-ttu-id="28a9d-170">フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-170">Ideally, feedback should be integrated naturally in your UI, so users don't have to be interrupted, or take additional action unless absolutely necessary.</span></span> 

<span data-ttu-id="28a9d-171">アプリでフィードバックを提供する方法をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-171">Here are some ways to provide feedback in your app.</span></span>

<div class="mx-responsive-img">
<table class="uwpd-top-aligned-table">

<tr class="header">
<th align="left"><span data-ttu-id="28a9d-172">サーフェス</span><span class="sxs-lookup"><span data-stu-id="28a9d-172">Surface</span></span></th>
<th align="left"><span data-ttu-id="28a9d-173">説明</span><span class="sxs-lookup"><span data-stu-id="28a9d-173">Description</span></span></th>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"> <a href="../controls-and-patterns/app-bars.md"><span data-ttu-id="28a9d-174">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="28a9d-174">Command bar</span></span></a>
<p><img src="../controls-and-patterns/images/controls_appbar_icons.png" alt="Example of a command bar with icons" /></p>
</td>
<td align="left" style="vertical-align: top;"> <span data-ttu-id="28a9d-175">コマンド バーのコンテンツ領域は、ユーザーがフィードバックの表示を求めている場合にユーザーに状態を伝えるための直感的でわかりやすい場所です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-175">The content area of the command bar is an intuative place to communicate status to users if they'd like to see feedback.</span></span>
<p>
  <img src="images/commandbar_anatomy.png" alt="Command bar content area for feedback"/>
  </p>
</td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/dialogs.md"><span data-ttu-id="28a9d-176">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="28a9d-176">Flyout</span></span></a>
<p><img src="images/controls-flyout-default-200.png" alt="Image of default flyout" /></p></td>
<td align="left" style="vertical-align: top;">
<span data-ttu-id="28a9d-177">その外側をタップするかクリックすることで閉じることができる、軽量な状況依存のポップアップ。</span><span class="sxs-lookup"><span data-stu-id="28a9d-177">A lightweight contextual popup that can be dismissed by tapping or clicking somewhere outside the flyout.</span></span>
<p>
  <img src="../controls-and-patterns/images/controls/flyout.png" alt="Flyout above button"/>
  </p>
</td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/dialogs.md"><span data-ttu-id="28a9d-178">ダイアログ コントロール</span><span class="sxs-lookup"><span data-stu-id="28a9d-178">Dialog controls</span></span></a>
<p><img src="images/controls-dialog-twobutton-200.png" alt="Example of a simple two-button dialog" /></p></td>
<td align="left" style="vertical-align: top;"><span data-ttu-id="28a9d-179">ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="28a9d-179">Dialogs are modal UI overlays that provide contextual app information.</span></span> <span data-ttu-id="28a9d-180">ほとんどの場合、ダイアログは明示的に閉じられまでアプリ ウィンドウの操作を妨げます。また、多くの場合、ユーザーに操作を要求します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-180">In most cases, dialogs block interactions with the app window until being explicitly dismissed, and often request some kind of action from the user.</span></span>
<p><span data-ttu-id="28a9d-181">ダイアログは、煩わしく感じることがあるため、特定の状況でのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-181">Dialogs can be disruptive and should only be used in certain situations.</span></span> <span data-ttu-id="28a9d-182">詳しくは、「[アクションを確認または元に戻すタイミング](#when-to-confirm-or-undo-actions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-182">For more info, see the [When to confirm or undo actions](#when-to-confirm-or-undo-actions) section.</span></span></p>
<p>
  <img src="../controls-and-patterns/images/dialogs/dialog_RS2_delete_file.png" alt="dialog delete file"/></p>
</td>
</tr>

</table>
</div>

> [!TIP]
> <span data-ttu-id="28a9d-183">アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。</span><span class="sxs-lookup"><span data-stu-id="28a9d-183">Be careful of how much your app uses confirmation dialogs; they can be very helpful when the user makes a mistake, but they are a hindrance whenever the user is trying to perform an action intentionally.</span></span>

### <a name="when-to-confirm-or-undo-actions"></a><span data-ttu-id="28a9d-184">アクションを確認または元に戻すタイミング</span><span class="sxs-lookup"><span data-stu-id="28a9d-184">When to confirm or undo actions</span></span>

<span data-ttu-id="28a9d-185">適切に設計されたユーザー インターフェイスであっても、ユーザーがどれほど慎重に作業したとしても、すべてのユーザーは必ず意図しないアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="28a9d-185">No matter how well-designed the user interface is and no matter how careful the user is, at some point, all users will perform an action they wish they hadn't.</span></span> <span data-ttu-id="28a9d-186">ユーザーにアクションの確認を求めたり、最近のアクションを元に戻す方法を用意したりして、アプリでこのような状況に対処することができます。</span><span class="sxs-lookup"><span data-stu-id="28a9d-186">Your app can help in these situations by requiring the user to confirm an action, or by providing a way of undoing recent actions.</span></span>

-   <span data-ttu-id="28a9d-187">元に戻すことができず、実行結果が重大な操作の場合は、確認ダイアログ ボックスの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="28a9d-187">For actions that can't be undone and have major consequences, we recommend using a confirmation dialog.</span></span> <span data-ttu-id="28a9d-188">このような操作の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="28a9d-188">Examples of such actions include:</span></span>
    -   <span data-ttu-id="28a9d-189">ファイルを上書きする</span><span class="sxs-lookup"><span data-stu-id="28a9d-189">Overwriting a file</span></span>
    -   <span data-ttu-id="28a9d-190">ファイルを保存せずに終了する</span><span class="sxs-lookup"><span data-stu-id="28a9d-190">Not saving a file before closing</span></span>
    -   <span data-ttu-id="28a9d-191">ファイルやデータを完全に削除することを確認する</span><span class="sxs-lookup"><span data-stu-id="28a9d-191">Confirming permanent deletion of a file or data</span></span>
    -   <span data-ttu-id="28a9d-192">購入する (確認メッセージを表示しないことをユーザーが選択した場合を除く)</span><span class="sxs-lookup"><span data-stu-id="28a9d-192">Making a purchase (unless the user opts out of requiring a confirmation)</span></span>
    -   <span data-ttu-id="28a9d-193">何かへのサインアップなどのフォームを送信する</span><span class="sxs-lookup"><span data-stu-id="28a9d-193">Submitting a form, such as signing up for something</span></span>
-   <span data-ttu-id="28a9d-194">元に戻すことができる操作の場合は、通常、単純な "元に戻す" コマンドを提供すれば十分です。</span><span class="sxs-lookup"><span data-stu-id="28a9d-194">For actions that can be undone, offering a simple undo command is usually enough.</span></span> <span data-ttu-id="28a9d-195">このような操作の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="28a9d-195">Examples of such actions include:</span></span>
    -   <span data-ttu-id="28a9d-196">ファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="28a9d-196">Deleting a file</span></span>
    -   <span data-ttu-id="28a9d-197">メールを削除する (完全には削除しない)</span><span class="sxs-lookup"><span data-stu-id="28a9d-197">Deleting an email (not permanently)</span></span>
    -   <span data-ttu-id="28a9d-198">コンテンツを変更する、またはテキストを編集する</span><span class="sxs-lookup"><span data-stu-id="28a9d-198">Modifying content or editing text</span></span>
    -   <span data-ttu-id="28a9d-199">ファイル名を変更する</span><span class="sxs-lookup"><span data-stu-id="28a9d-199">Renaming a file</span></span>

##  <a name="optimize-for-specific-input-types"></a><span data-ttu-id="28a9d-200">特定の入力タイプの最適化</span><span class="sxs-lookup"><span data-stu-id="28a9d-200">Optimize for specific input types</span></span>

<span data-ttu-id="28a9d-201">特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28a9d-201">See the [Interaction primer](../input/index.md) for more detail on optimizing user experiences around a specific input type or device.</span></span>