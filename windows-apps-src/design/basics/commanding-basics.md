---
author: mijacobs
Description: In a Universal Windows Platform (UWP) app, command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 10/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 104788b98377b55564fcc204ecc161521d071c6b
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4572868"
---
#  <a name="command-design-basics-for-uwp-apps"></a><span data-ttu-id="577a0-103">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="577a0-103">Command design basics for UWP apps</span></span>

<span data-ttu-id="577a0-104">ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="577a0-104">In a Universal Windows Platform (UWP) app, *command elements* are interactive UI elements that enable users to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> <span data-ttu-id="577a0-105">この記事では、一般的なコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするためのコマンド サーフェスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="577a0-105">This article describes common command elements, the interactions they support, and the command surfaces for hosting them.</span></span>

## <a name="provide-the-right-type-of-interactions"></a><span data-ttu-id="577a0-106">適切な種類の操作の提供</span><span class="sxs-lookup"><span data-stu-id="577a0-106">Provide the right type of interactions</span></span>

<span data-ttu-id="577a0-107">コマンド インターフェイスを設計する際、最も重要な決定はユーザーが何を実行できる必要があるかという点です。</span><span class="sxs-lookup"><span data-stu-id="577a0-107">When designing a command interface, the most important decision is choosing what users should be able to do.</span></span> <span data-ttu-id="577a0-108">適切な種類の操作を計画するには、アプリに集中して、有効にするユーザー エクスペリエンス、およびユーザーが行う必要がある操作の手順を検討します。</span><span class="sxs-lookup"><span data-stu-id="577a0-108">To plan the right type of interactions, focus on your app - consider the user experiences you want to enable, and what steps users will need to take.</span></span> <span data-ttu-id="577a0-109">ユーザーが実行できる操作を決定したら、それを行うためのツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="577a0-109">Once you decide what you want users to accomplish, then you can provide them the tools to do so.</span></span>

<span data-ttu-id="577a0-110">アプリで提供する操作には次のものがあります。</span><span class="sxs-lookup"><span data-stu-id="577a0-110">Some interactions you might want to provide your app include:</span></span>

- <span data-ttu-id="577a0-111">情報の送信または提出</span><span class="sxs-lookup"><span data-stu-id="577a0-111">Sending or submiting information</span></span> 
- <span data-ttu-id="577a0-112">設定とオプションの選択</span><span class="sxs-lookup"><span data-stu-id="577a0-112">Selecting settings and choices</span></span>
- <span data-ttu-id="577a0-113">コンテンツの検索とフィルター処理</span><span class="sxs-lookup"><span data-stu-id="577a0-113">Searching and filtering content</span></span>
- <span data-ttu-id="577a0-114">ファイルを開く、保存する、削除する</span><span class="sxs-lookup"><span data-stu-id="577a0-114">Opening, saving, and deleting files</span></span>
- <span data-ttu-id="577a0-115">コンテンツの編集または作成</span><span class="sxs-lookup"><span data-stu-id="577a0-115">Editing or creating content</span></span>

## <a name="use-the-right-command-element-for-the-interaction"></a><span data-ttu-id="577a0-116">操作に適切なコマンド要素を使用</span><span class="sxs-lookup"><span data-stu-id="577a0-116">Use the right command element for the interaction</span></span>

<span data-ttu-id="577a0-117">適切な要素を使ってコマンド操作を実行することは、直感的で使いやすいアプリとなるか、使いにくくてややこしいアプリとなるかの分かれ目になります。</span><span class="sxs-lookup"><span data-stu-id="577a0-117">Using the right elements to enable command interactions can make the difference between an intuitive, easy-to-use app and a difficult, confusing app.</span></span> <span data-ttu-id="577a0-118">ユニバーサル Windows プラットフォーム (UWP) には、アプリで使うことができる多くのコマンド要素セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="577a0-118">The Universal Windows Platform (UWP) provides a large set of command elements that you can use in your app.</span></span> <span data-ttu-id="577a0-119">最も一般的ないくつかのコントロールの一覧と、それによって可能になる操作の概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="577a0-119">Here's a list of some of the most common controls and a summary of the interactions they can enable.</span></span>

:::row:::
    :::column:::
        ![button image](images/commanding/thumbnail-button.svg)
    :::column-end:::
    :::column span="2":::
        <b>Buttons</b>

        <a href="../controls-and-patterns/buttons.md" style="text-decoration:none">Buttons</a> trigger an immediate action. Examples include sending an email, submitting form data, or confirming an action in a dialog.
:::row-end:::

:::row:::
    :::column:::
        ![list image](images/commanding/thumbnail-list.svg)
    :::column-end:::
    :::column span="2":::
        <b>Lists</b>

        <a href="../controls-and-patterns/lists.md" style="text-decoration:none">Lists</a> present items in a interactive list or a grid. Usually used for many options or display items. Examples include drop-down list, list box, list view and grid view.
:::row-end:::

:::row:::
    :::column:::
        ![selection control image](images/commanding/thumbnail-selection.svg)
    :::column-end:::
    :::column span="2":::
        <b>Selection controls</b>

        Lets users choose from a few options, such as when completing a survey or configuring app settings. Examples include <a href="../controls-and-patterns/checkbox.md">check box</a>, <a href="../controls-and-patterns/radio-button.md">radio button</a>, and <a href="../controls-and-patterns/toggles.md">toggle switch</a>.
:::row-end:::

:::row:::
    :::column:::
        ![Calendar  image](images/commanding/thumbnail-calendar.svg)
    :::column-end:::
    :::column span="2":::
        <b>Calendar, date and time pickers</b>

        <a href="../controls-and-patterns/date-and-time.md">Calendar, date and time pickers</a> enable users to view and modify date and time info, such as when creating an event or setting an alarm. Examples include calendar date picker, calendar view, date picker, time picker.
:::row-end:::

:::row:::
    :::column:::
        ![Predictive text entry image](images/commanding/thumbnail-autosuggest.svg)
    :::column-end:::
    :::column span="2":::
        <b>Predictive text entry</b>

        Provides suggestions as users type, such as when entering data or performing queries. Examples include <a href="../controls-and-patterns/auto-suggest-box.md">auto-suggest box</a>.<br>
:::row-end:::

<span data-ttu-id="577a0-120">全一覧については、「[コントロールと UI 要素](../controls-and-patterns/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="577a0-120">For a complete list, see [Controls and UI elements](../controls-and-patterns/index.md)</span></span>

## <a name="place-commands-on-the-right-surface"></a><span data-ttu-id="577a0-121">適切なサーフェスへのコマンドの配置</span><span class="sxs-lookup"><span data-stu-id="577a0-121">Place commands on the right surface</span></span>

<span data-ttu-id="577a0-122">アプリのキャンバスや、コマンド バー、コマンド バーのポップアップ、メニュー バー、およびダイアログなどの特殊なコマンド コンテナーを含む、アプリでの多くのサーフェスにコマンド要素を配置できます。</span><span class="sxs-lookup"><span data-stu-id="577a0-122">You can place command elements on a number of surfaces in your app, including the app canvas or special command containers, such as a command bar, command bar flyout, menu bar, and dialog.</span></span>

<span data-ttu-id="577a0-123">、可能であれば、する必要があることをユーザーがコンテンツを操作するコマンドを使用してではなく、コンテンツを直接操作に注意してください。</span><span class="sxs-lookup"><span data-stu-id="577a0-123">Note that, whenever possible, you should let users manipulate content directly rather than use commands that act on the content.</span></span> <span data-ttu-id="577a0-124">たとえば、上下に移動するコマンド ボタンを使うのではなく、リスト項目をドラッグ アンド ドロップしてリストを並べ替えることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="577a0-124">For example, allow users to rearrange lists by dragging and dropping list items, rather than using up and down command buttons.</span></span>

<span data-ttu-id="577a0-125">ユーザーが直接コンテンツを操作できない場合は、コマンド要素をアプリのコマンド サーフェスに配置します。</span><span class="sxs-lookup"><span data-stu-id="577a0-125">Otherwise, if users can't manipulate content directly, then place command elements on a command surface in your app.</span></span> <span data-ttu-id="577a0-126">最も一般的ないくつかのコマンド サーフェスの一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="577a0-126">Here's a list of some of the most common command surfaces.</span></span>

:::row:::
    :::column:::
        ![app canvas image](images/commanding/thumbnail-canvas.svg)
    :::column-end:::
    :::column span="2":::
        <b>App canvas (content area)</b>

        If a command is constantly needed for users to complete core scenarios, put it on the canvas. Because you can put commands near (or on) the objects they affect, putting commands on the canvas makes them easy and obvious to use. However, choose the commands you put on the canvas carefully. Too many commands on the app canvas take up valuable screen space and can overwhelm the user. If the command won't be frequently used, consider putting it in another command surface.
:::row-end:::

:::row:::
    :::column:::
        ![commandbar image](images/commanding/thumbnail-commandbar.svg)
    :::column-end:::
    :::column span="2":::
        <b>Command bars and menu bars</b>

        <a href="../controls-and-patterns/app-bars.md">Command bars</a> help organize commands and make them easy to access. Command bars can be placed at the top of the screen, at the bottom of the screen, or at both the top and bottom of the screen (a <a href="../controls-and-patterns/menus.md#create-a-menu-bar">MenuBar</a> can also be used when the functionality in your app is too complex for a command bar).
:::row-end:::

:::row:::
    :::column:::
        ![context menu image](images/commanding/thumbnail-contextmenu.svg)
    :::column-end:::
    :::column span="2":::
        <b>Menus and context menus</b>

        <p>Menus and context menus save space by organizing commands and hiding them until the user needs them. Users typically access a menu or context menu by clicking a button or right-clicking a control.</p> 

        <p>The <a href="../controls-and-patterns/command-bar-flyout.md">command bar flyout </a> is a type of contextual menu that combines the benefits of a command bar and a context menu into a single control. It can provide shortcuts to commonly-used actions and provide access to secondary commands that are only relevant in certain contexts, such as clipboard or custom commands.</p>

        <p>UWP also provides a set of traditional menus and context menus; for more info, see the <a href="../controls-and-patterns/menus.md">menus and context menus overview</a>.</p>
:::row-end:::

## <a name="provide-feedback-for-interactions"></a><span data-ttu-id="577a0-127">操作に対するフィードバックの提供</span><span class="sxs-lookup"><span data-stu-id="577a0-127">Provide feedback for interactions</span></span>

<span data-ttu-id="577a0-128">フィードバックでコマンドの実行結果を伝えると、ユーザーは実行したことと次に実行できることを把握することができます。</span><span class="sxs-lookup"><span data-stu-id="577a0-128">Feedback communicates the results of commands and allows users to understand what they've done, and what they can do next.</span></span> <span data-ttu-id="577a0-129">フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。</span><span class="sxs-lookup"><span data-stu-id="577a0-129">Ideally, feedback should be integrated naturally in your UI, so users don't have to be interrupted, or take additional action unless absolutely necessary.</span></span> 

<span data-ttu-id="577a0-130">アプリでフィードバックを提供する方法をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="577a0-130">Here are some ways to provide feedback in your app.</span></span>

:::row:::
    :::column:::
        ![commandbar content area image](images/commanding/thumbnail-commandbar2.svg)
    :::column-end:::
    :::column span="2":::
        <b>Command bar</b>

        The content area of the <a href="../controls-and-patterns/app-bars.md">command bar</a> is an intuitive place to communicate status to users if they'd like to see feedback.
:::row-end:::

:::row:::
    :::column:::
        ![Flyout image](images/commanding/thumbnail-flyout.svg)
    :::column-end:::
    :::column span="2":::
        <b>Flyouts</b>

       <span data-ttu-id="577a0-131"><a href="../controls-and-patterns/dialogs-and-flyouts/index.md">ポップアップ</a>は、軽量のコンテキストに沿ったポップアップをタップするか、どこかクリックすると、ポップアップ外で閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="577a0-131"><a href="../controls-and-patterns/dialogs-and-flyouts/index.md">Flyouts</a> are lightweight contextual popups that can be dismissed by tapping or clicking somewhere outside the flyout.</span></span>
:::row-end:::

:::row:::
    :::column:::
        ![Dialog image](images/commanding/thumbnail-dialog.svg)
    :::column-end:::
    :::column span="2":::
        <b>Dialog controls</b>

        <a href="../controls-and-patterns/dialogs-and-flyouts/index.md">Dialog controls</a> are modal UI overlays that provide contextual app information. In most cases, dialogs block interactions with the app window until being explicitly dismissed, and often request some kind of action from the user. Dialogs can be disruptive and should only be used in certain situations. For more info, see the [When to confirm or undo actions](#when-to-confirm-or-undo-actions) section.
    :::column-end:::
:::row-end:::

> [!TIP]
> <span data-ttu-id="577a0-132">アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。</span><span class="sxs-lookup"><span data-stu-id="577a0-132">Be careful of how much your app uses confirmation dialogs; they can be very helpful when the user makes a mistake, but they are a hindrance whenever the user is trying to perform an action intentionally.</span></span>

### <a name="when-to-confirm-or-undo-actions"></a><span data-ttu-id="577a0-133">アクションを確認または元に戻すタイミング</span><span class="sxs-lookup"><span data-stu-id="577a0-133">When to confirm or undo actions</span></span>

<span data-ttu-id="577a0-134">適切に設計されたユーザー インターフェイスであっても、ユーザーがどれほど慎重に作業したとしても、すべてのユーザーは必ず意図しないアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="577a0-134">No matter how well-designed the user interface is and no matter how careful the user is, at some point, all users will perform an action they wish they hadn't.</span></span> <span data-ttu-id="577a0-135">ユーザーにアクションの確認を求めたり、最近のアクションを元に戻す方法を用意したりして、アプリでこのような状況に対処することができます。</span><span class="sxs-lookup"><span data-stu-id="577a0-135">Your app can help in these situations by requiring the user to confirm an action, or by providing a way of undoing recent actions.</span></span>

:::row:::
    :::column:::
        ![do image](images/do.svg)

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
:::row-end:::

##  <a name="optimize-for-specific-input-types"></a><span data-ttu-id="577a0-136">特定の入力タイプの最適化</span><span class="sxs-lookup"><span data-stu-id="577a0-136">Optimize for specific input types</span></span>

<span data-ttu-id="577a0-137">特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="577a0-137">See the [Interaction primer](../input/index.md) for more detail on optimizing user experiences around a specific input type or device.</span></span>

