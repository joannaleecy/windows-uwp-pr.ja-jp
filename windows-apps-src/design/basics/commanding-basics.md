---
Description: ユニバーサル Windows プラットフォーム (UWP) アプリでは、コマンド要素は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 11/01/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ac2bd55d1cea25359c3c609148c7098532d76c46
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654057"
---
# <a name="command-design-basics-for-uwp-apps"></a>UWP アプリのコマンド設計の基本

ユニバーサル Windows プラットフォーム (UWP) アプリで*コマンド要素*ユーザーが電子メールを送信する、項目の削除、フォームの送信などの操作を実行できるようにする対話型の UI 要素を示します。 *インターフェイスをコマンド*コマンドの共通の要素、それをホストするコマンド サーフェス、対話をサポートしているエクスペリエンスを提供するは構成されています。

## <a name="provide-the-best-command-experience"></a>コマンドの最善のエクスペリエンスを提供します。

コマンド インターフェイスの最も重要な側面は、ユーザーが実行可能にしています。 アプリの機能を計画するときは、これらのタスクと有効にするユーザー エクスペリエンスを実現するための手順を検討してください。 これらのエクスペリエンスの最初のドラフトが完了するとそれらを実装するツールとの相互作用に意思決定を行うことができます。

いくつかの一般的なコマンド エクスペリエンスを次に示します。

- 情報の送信または提出
- 設定とオプションの選択
- コンテンツの検索とフィルター処理
- ファイルを開く、保存する、削除する
- コンテンツの編集または作成

クリエイティブ、コマンドのエクスペリエンスの設計にあります。 どの入力デバイス、アプリの選択をサポートし、各デバイスにアプリの反応します。 広範な機能と設定をサポートすると、アプリで使用できる、ポータブル コンピューター、およびアクセス可能な限り (を参照してください[コマンド実行のユニバーサル Windows プラットフォーム (UWP) アプリのデザイン](../controls-and-patterns/commanding.md)詳細)。



<!--
When designing a command interface, the most important decision is choosing what a user can do. To plan the right type of interactions, focus on your app - consider the user experiences you want to enable, and what steps users will need to take. Once you decide what you want users to accomplish, then you can provide them the tools to do so.
-->

## <a name="choose-the-right-command-elements"></a>適切なコマンド要素を選択します。

コマンド インターフェイスの右の要素を使用すると、直感的で使いやすいアプリと、はるかに困難で混乱を招くアプリ間の差ことできます。 コマンド要素の包括的なセットでは、ユニバーサル Windows プラットフォーム (UWP) で使用することができます。 いくつかの最も一般的な UWP コマンド要素の一覧を示します。

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

全一覧については、「[コントロールと UI 要素](../controls-and-patterns/index.md)」をご覧ください。

## <a name="place-commands-on-the-right-surface"></a>適切なサーフェスへのコマンドの配置

アプリ キャンバスまたはコマンド バー、コマンド バーのフライアウト、メニュー バーやダイアログなどの特殊なコマンドのコンテナーを含む、アプリでさまざまな画面にコマンド要素を配置できます。

常にユーザーがコンテンツを直接操作できるようにしようとすることではなくコマンド、コマンド ボタンと下矢印ではなく、リストのアイテムの再構成にドラッグ アンド ドロップなどのコンテンツに対して作用します。 

ただし、この可能性がありますできません入力の特定のデバイスまたは特定のユーザーの能力と基本設定を考慮に入れるためとき。 このような場合、できるだけ多くのコマンド実行アフォーを提供し、アプリでのコマンドの画面でこれらのコマンド要素を配置します。

最も一般的ないくつかのコマンド サーフェスの一覧を次に示します。

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

## <a name="provide-command-feedback"></a>コマンドのフィードバックを提供します。 

コマンドのフィードバックは、操作やコマンドが検出されました、コマンドが解釈され、処理する方法と、コマンドが成功したかどうかをユーザーに通信します。 これにより、ユーザーのところ、次に操作できる内容を理解できます。 フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。

> [!NOTE]
> 必要な場合にのみ、およびそれが他の場所で使用できない場合にのみ、フィードバックを提供します。 値を追加する場合を除き、クリーンですっきりアプリケーション UI を保持します。

アプリでフィードバックを提供する方法をいくつか示します。

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

       <a href="../controls-and-patterns/dialogs-and-flyouts/index.md">フライアウト</a>は軽量のコンテキスト ポップアップをタップするか、フライアウトの外部どこかクリックして消去できます。
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
> アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。

### <a name="when-to-confirm-or-undo-actions"></a>アクションを確認または元に戻すタイミング

適切に設計された方法に関係なく、アプリケーションの UI は、すべてのユーザーですかそれらを希望するアクションを実行します。 または最近の操作を元に戻す方法を提供することで、アクションの確認を要求することで、アプリはこのような状況に役立ちます。

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

##  <a name="optimize-for-specific-input-types"></a>特定の入力タイプの最適化

特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。

