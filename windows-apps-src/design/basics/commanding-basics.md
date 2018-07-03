---
author: mijacobs
Description: In a Universal Windows Platform (UWP) app, command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 09f775ad0ba596379b6d3ddf158285849520111f
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1842569"
---
#  <a name="command-design-basics-for-uwp-apps"></a><span data-ttu-id="84e6f-103">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="84e6f-103">Command design basics for UWP apps</span></span>

<span data-ttu-id="84e6f-104">ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="84e6f-104">In a Universal Windows Platform (UWP) app, *command elements* are interactive UI elements that enable users to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> <span data-ttu-id="84e6f-105">この記事では、一般的なコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするためのコマンド サーフェスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-105">This article describes common command elements, the interactions they support, and the command surfaces for hosting them.</span></span>

## <a name="provide-the-right-type-of-interactions"></a><span data-ttu-id="84e6f-106">適切な種類の操作の提供</span><span class="sxs-lookup"><span data-stu-id="84e6f-106">Provide the right type of interactions</span></span>

<span data-ttu-id="84e6f-107">コマンド インターフェイスを設計する際、最も重要な決定はユーザーが何を実行できる必要があるかという点です。</span><span class="sxs-lookup"><span data-stu-id="84e6f-107">When designing a command interface, the most important decision is choosing what users should be able to do.</span></span> <span data-ttu-id="84e6f-108">適切な種類の操作を計画するには、アプリに集中して、有効にするユーザー エクスペリエンス、およびユーザーが行う必要がある操作の手順を検討します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-108">To plan the right type of interactions, focus on your app - consider the user experiences you want to enable, and what steps users will need to take.</span></span> <span data-ttu-id="84e6f-109">ユーザーが実行できる操作を決定したら、それを行うためのツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-109">Once you decide what you want users to accomplish, then you can provide them the tools to do so.</span></span>

<span data-ttu-id="84e6f-110">アプリで提供する操作には次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="84e6f-110">Some interactions you might want to provide your app include:</span></span>

- <span data-ttu-id="84e6f-111">情報の送信または提出</span><span class="sxs-lookup"><span data-stu-id="84e6f-111">Sending or submiting information</span></span> 
- <span data-ttu-id="84e6f-112">設定とオプションの選択</span><span class="sxs-lookup"><span data-stu-id="84e6f-112">Selecting settings and choices</span></span>
- <span data-ttu-id="84e6f-113">コンテンツの検索とフィルター処理</span><span class="sxs-lookup"><span data-stu-id="84e6f-113">Searching and filtering content</span></span>
- <span data-ttu-id="84e6f-114">ファイルを開く、保存する、削除する</span><span class="sxs-lookup"><span data-stu-id="84e6f-114">Opening, saving, and deleting files</span></span>
- <span data-ttu-id="84e6f-115">コンテンツの編集または作成</span><span class="sxs-lookup"><span data-stu-id="84e6f-115">Editing or creating content</span></span>

## <a name="use-the-right-command-element-for-the-interaction"></a><span data-ttu-id="84e6f-116">操作に適切なコマンド要素を使用</span><span class="sxs-lookup"><span data-stu-id="84e6f-116">Use the right command element for the interaction</span></span>

<span data-ttu-id="84e6f-117">適切な要素を使ってコマンド操作を実行することは、直感的で使いやすいアプリとなるか、使いにくくてややこしいアプリとなるかの分かれ目になります。</span><span class="sxs-lookup"><span data-stu-id="84e6f-117">Using the right elements to enable command interactions can make the difference between an intuitive, easy-to-use app and a difficult, confusing app.</span></span> <span data-ttu-id="84e6f-118">ユニバーサル Windows プラットフォーム (UWP) には、アプリで使うことができる多くのコマンド要素セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="84e6f-118">The Universal Windows Platform (UWP) provides a large set of command elements that you can use in your app.</span></span> <span data-ttu-id="84e6f-119">最も一般的ないくつかのコントロールの一覧と、それによって可能になる操作の概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-119">Here's a list of some of the most common controls and a summary of the interactions they can enable.</span></span>

<span data-ttu-id="84e6f-120">:::row::: :::column::: ![ボタン イメージ](images/commanding/thumbnail-button.svg) :::column-end::: :::column span="2"::: <b>ボタン</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-120">:::row::: :::column::: ![button image](images/commanding/thumbnail-button.svg) :::column-end::: :::column span="2"::: <b>Buttons</b></span></span>

        <a href="../controls-and-patterns/buttons.md" style="text-decoration:none">Buttons</a> trigger an immediate action. Examples include sending an email, submitting form data, or confirming an action in a dialog.
<span data-ttu-id="84e6f-121">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-121">:::row-end:::</span></span>

<span data-ttu-id="84e6f-122">:::row::: :::column::: ![一覧のイメージ](images/commanding/thumbnail-list.svg) :::column-end::: :::column span="2"::: <b>一覧</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-122">:::row::: :::column::: ![list image](images/commanding/thumbnail-list.svg) :::column-end::: :::column span="2"::: <b>Lists</b></span></span>

        <a href="../controls-and-patterns/lists.md" style="text-decoration:none">Lists</a> present items in a interactive list or a grid. Usually used for many options or display items. Examples include drop-down list, list box, list view and grid view.
<span data-ttu-id="84e6f-123">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-123">:::row-end:::</span></span>

<span data-ttu-id="84e6f-124">:::row::: :::column::: ![選択コントロールのイメージ](images/commanding/thumbnail-selection.svg) :::column-end::: :::column span="2"::: <b>選択コントロール</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-124">:::row::: :::column::: ![selection control image](images/commanding/thumbnail-selection.svg) :::column-end::: :::column span="2"::: <b>Selection controls</b></span></span>

        Lets users choose from a few options, such as when completing a survey or configuring app settings. Examples include <a href="../controls-and-patterns/checkbox.md">check box</a>, <a href="../controls-and-patterns/radio-button.md">radio button</a>, and <a href="../controls-and-patterns/toggles.md">toggle switch</a>.
<span data-ttu-id="84e6f-125">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-125">:::row-end:::</span></span>

<span data-ttu-id="84e6f-126">:::row::: :::column::: ![カレンダー イメージ](images/commanding/thumbnail-calendar.svg) :::column-end::: :::column span="2"::: <b>カレンダー、日付と時刻の選択機能</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-126">:::row::: :::column::: ![Calendar  image](images/commanding/thumbnail-calendar.svg) :::column-end::: :::column span="2"::: <b>Calendar, date and time pickers</b></span></span>

        <a href="../controls-and-patterns/date-and-time.md">Calendar, date and time pickers</a> enable users to view and modify date and time info, such as when creating an event or setting an alarm. Examples include calendar date picker, calendar view, date picker, time picker.
<span data-ttu-id="84e6f-127">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-127">:::row-end:::</span></span>

<span data-ttu-id="84e6f-128">:::row::: :::column::: ![テキスト予測入力のイメージ](images/commanding/thumbnail-autosuggest.svg) :::column-end::: :::column span="2"::: <b>テキスト予測入力</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-128">:::row::: :::column::: ![Predictive text entry image](images/commanding/thumbnail-autosuggest.svg) :::column-end::: :::column span="2"::: <b>Predictive text entry</b></span></span>

        Provides suggestions as users type, such as when entering data or performing queries. Examples include <a href="../controls-and-patterns/auto-suggest-box.md">auto-suggest box</a>.<br>
<span data-ttu-id="84e6f-129">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-129">:::row-end:::</span></span>

<span data-ttu-id="84e6f-130">全一覧については、「[コントロールと UI 要素](../controls-and-patterns/index.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="84e6f-130">For a complete list, see [Controls and UI elements](../controls-and-patterns/index.md)</span></span>

##  <a name="place-commands-on-the-right-surface"></a><span data-ttu-id="84e6f-131">適切なサーフェスへのコマンドの配置</span><span class="sxs-lookup"><span data-stu-id="84e6f-131">Place commands on the right surface</span></span>
<span data-ttu-id="84e6f-132">アプリのキャンバスや、コマンド バー、メニュー、ダイアログ、ポップアップなどの特殊なコマンド要素を含む、アプリの多くのサーフェスにコマンド要素を配置できます。</span><span class="sxs-lookup"><span data-stu-id="84e6f-132">You can place command elements on a number of surfaces in your app, including the app canvas or special command containers, such as command bars, menus, dialogs, and flyouts.</span></span>

<span data-ttu-id="84e6f-133">できる限り、コンテンツを操作するコマンドを用意せず、ユーザーがコンテンツを直接操作できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="84e6f-133">Note that, whenever possible, you should allow users to manipulate content directly rather than use commands that act on the content.</span></span> <span data-ttu-id="84e6f-134">たとえば、上下に移動するコマンド ボタンを使うのではなく、リスト項目をドラッグ アンド ドロップしてリストを並べ替えることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="84e6f-134">For example, allow users to rearrange lists by dragging and dropping list items, rather than using up and down command buttons.</span></span>

<span data-ttu-id="84e6f-135">ユーザーが直接コンテンツを操作できない場合は、コマンド要素をアプリのコマンド サーフェスに配置します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-135">Otherwise, if users can't manipulate content directly, then place command elements on a command surface in your app.</span></span> <span data-ttu-id="84e6f-136">最も一般的ないくつかのコマンド サーフェスの一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-136">Here's a list of some of the most common command surfaces.</span></span>

<span data-ttu-id="84e6f-137">:::row::: :::column::: ![アプリ キャンバスのイメージ](images/commanding/thumbnail-canvas.svg) :::column-end::: :::column span="2"::: <b>アプリ キャンバス (コンテンツ領域)</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-137">:::row::: :::column::: ![app canvas image](images/commanding/thumbnail-canvas.svg) :::column-end::: :::column span="2"::: <b>App canvas (content area)</b></span></span>

        If a command is constantly needed for users to complete core scenarios, put it on the canvas. Because you can put commands near (or on) the objects they affect, putting commands on the canvas makes them easy and obvious to use. However, choose the commands you put on the canvas carefully. Too many commands on the app canvas take up valuable screen space and can overwhelm the user. If the command won't be frequently used, consider putting it in another command surface.
<span data-ttu-id="84e6f-138">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-138">:::row-end:::</span></span>

<span data-ttu-id="84e6f-139">:::row::: :::column::: ![コマンド バーのイメージ](images/commanding/thumbnail-commandbar.svg) :::column-end::: :::column span="2"::: <b>コマンド バー</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-139">:::row::: :::column::: ![commandbar image](images/commanding/thumbnail-commandbar.svg) :::column-end::: :::column span="2"::: <b>Command bars</b></span></span>

        <a href="../controls-and-patterns/app-bars.md">Command bars</a> help organize commands and make them easy to access. Command bars can be placed at the top of the screen, at the bottom of the screen, or at both the top and bottom of the screen.
<span data-ttu-id="84e6f-140">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-140">:::row-end:::</span></span>

<span data-ttu-id="84e6f-141">:::row::: :::column::: ![コンテキスト メニューのイメージ](images/commanding/thumbnail-contextmenu.svg) :::column-end::: :::column span="2"::: <b>メニューとコンテキスト メニュー</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-141">:::row::: :::column::: ![context menu image](images/commanding/thumbnail-contextmenu.svg) :::column-end::: :::column span="2"::: <b>Menus and context menus</b></span></span>

        Sometimes it is more efficient to group multiple commands into a command menu to save space. <a href="../controls-and-patterns/menus.md">Menus and context menus</a> display a list of commands or options when the user requests them. Context menus can provide shortcuts to commonly-used actions and provide access to secondary commands that are only relevant in certain contexts, such as clipboard or custom commands. Context menus are usually prompted by a user right-clicking.
<span data-ttu-id="84e6f-142">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-142">:::row-end:::</span></span>

## <a name="provide-feedback-for-interactions"></a><span data-ttu-id="84e6f-143">操作に対するフィードバックの提供</span><span class="sxs-lookup"><span data-stu-id="84e6f-143">Provide feedback for interactions</span></span>

<span data-ttu-id="84e6f-144">フィードバックでコマンドの実行結果を伝えると、ユーザーは実行したことと次に実行できることを把握することができます。</span><span class="sxs-lookup"><span data-stu-id="84e6f-144">Feedback communicates the results of commands and allows users to understand what they've done, and what they can do next.</span></span> <span data-ttu-id="84e6f-145">フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。</span><span class="sxs-lookup"><span data-stu-id="84e6f-145">Ideally, feedback should be integrated naturally in your UI, so users don't have to be interrupted, or take additional action unless absolutely necessary.</span></span> 

<span data-ttu-id="84e6f-146">アプリでフィードバックを提供する方法をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-146">Here are some ways to provide feedback in your app.</span></span>

<span data-ttu-id="84e6f-147">:::row::: :::column::: ![コマンド バーのコンテンツ領域のイメージ](images/commanding/thumbnail-commandbar2.svg) :::column-end::: :::column span="2"::: <b>コマンド バー</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-147">:::row::: :::column::: ![commandbar content area image](images/commanding/thumbnail-commandbar2.svg) :::column-end::: :::column span="2"::: <b>Command bar</b></span></span>

        The content area of the <a href="../controls-and-patterns/app-bars.md">command bar</a> is an intuitive place to communicate status to users if they'd like to see feedback.
<span data-ttu-id="84e6f-148">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-148">:::row-end:::</span></span>

<span data-ttu-id="84e6f-149">:::row::: :::column::: ![ポップアップのイメージ](images/commanding/thumbnail-flyout.svg) :::column-end::: :::column span="2"::: <b>ポップアップ</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-149">:::row::: :::column::: ![Flyout image](images/commanding/thumbnail-flyout.svg) :::column-end::: :::column span="2"::: <b>Flyouts</b></span></span>

       <a href="../controls-and-patterns/dialogs.md">Flyouts</a> are lightweight contextual popups that can be dismissed by tapping or clicking somewhere outside the flyout.
<span data-ttu-id="84e6f-150">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-150">:::row-end:::</span></span>

<span data-ttu-id="84e6f-151">:::row::: :::column::: ![ダイアログのイメージ](images/commanding/thumbnail-dialog.svg) :::column-end::: :::column span="2"::: <b>ダイアログ コントロール</b></span><span class="sxs-lookup"><span data-stu-id="84e6f-151">:::row::: :::column::: ![Dialog image](images/commanding/thumbnail-dialog.svg) :::column-end::: :::column span="2"::: <b>Dialog controls</b></span></span>

        <a href="../controls-and-patterns/dialogs.md">Dialog controls</a> are modal UI overlays that provide contextual app information. In most cases, dialogs block interactions with the app window until being explicitly dismissed, and often request some kind of action from the user. Dialogs can be disruptive and should only be used in certain situations. For more info, see the [When to confirm or undo actions](#when-to-confirm-or-undo-actions) section.
    :::column-end:::
<span data-ttu-id="84e6f-152">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-152">:::row-end:::</span></span>

> [!TIP]
> <span data-ttu-id="84e6f-153">アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。</span><span class="sxs-lookup"><span data-stu-id="84e6f-153">Be careful of how much your app uses confirmation dialogs; they can be very helpful when the user makes a mistake, but they are a hindrance whenever the user is trying to perform an action intentionally.</span></span>

### <a name="when-to-confirm-or-undo-actions"></a><span data-ttu-id="84e6f-154">アクションを確認または元に戻すタイミング</span><span class="sxs-lookup"><span data-stu-id="84e6f-154">When to confirm or undo actions</span></span>

<span data-ttu-id="84e6f-155">適切に設計されたユーザー インターフェイスであっても、ユーザーがどれほど慎重に作業したとしても、すべてのユーザーは必ず意図しないアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="84e6f-155">No matter how well-designed the user interface is and no matter how careful the user is, at some point, all users will perform an action they wish they hadn't.</span></span> <span data-ttu-id="84e6f-156">ユーザーにアクションの確認を求めたり、最近のアクションを元に戻す方法を用意したりして、アプリでこのような状況に対処することができます。</span><span class="sxs-lookup"><span data-stu-id="84e6f-156">Your app can help in these situations by requiring the user to confirm an action, or by providing a way of undoing recent actions.</span></span>

<span data-ttu-id="84e6f-157">:::row::: :::column::: ![操作のイメージ</span><span class="sxs-lookup"><span data-stu-id="84e6f-157">:::row::: :::column::: ![do image</span></span>](images/do.svg)

        For actions that can't be undone and have major consequences, we recommend using a confirmation dialog. Examples of such actions include:
        -   Overwriting a file
        -   Not saving a file before closing
        -   Confirming permanent deletion of a file or data
        -   Making a purchase (unless the user opts out of requiring a confirmation)
        -   Submitting a form, such as signing up for something
    :::column-end:::
    :::column:::
        ![do image](images/do.svg)

        For actions that can be undone, offering a simple undo command is usually enough. Examples of such actions include:
        -   Deleting a file
        -   Deleting an email (not permanently)
        -   Modifying content or editing text
        -   Renaming a file
<span data-ttu-id="84e6f-158">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="84e6f-158">:::row-end:::</span></span>

##  <a name="optimize-for-specific-input-types"></a><span data-ttu-id="84e6f-159">特定の入力タイプの最適化</span><span class="sxs-lookup"><span data-stu-id="84e6f-159">Optimize for specific input types</span></span>

<span data-ttu-id="84e6f-160">特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="84e6f-160">See the [Interaction primer](../input/index.md) for more detail on optimizing user experiences around a specific input type or device.</span></span>

