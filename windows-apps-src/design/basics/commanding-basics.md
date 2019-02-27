---
Description: In a Universal Windows Platform (UWP) app, command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 11/01/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ac2bd55d1cea25359c3c609148c7098532d76c46
ms.sourcegitcommit: ff131135248c85a8a2542fc55437099d549cfaa5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9117592"
---
# <a name="command-design-basics-for-uwp-apps"></a>UWP アプリのコマンド設計の基本

ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメールの送信、項目の削除、フォームの送信などの操作を実行できる対話型の UI 要素をします。 *コマンド インターフェイス*は、一般的なコマンド要素、それらをホストするコマンド サーフェス、サポートされる操作、および提供するエクスペリエンスで構成されます。

## <a name="provide-the-best-command-experience"></a>最適なコマンド エクスペリエンスを提供します。

コマンド インターフェイスの最も重要な側面を使うと、ユーザーが実行しています。 アプリの機能を計画する際は、これらのタスクと有効にするユーザー エクスペリエンスを実現するための手順を検討してください。 これらのエクスペリエンスの初期の下書きが完了したら、し、決定を行うツールと対話式操作でそれらを実装します。

一般的ないくつかのコマンドのエクスペリエンスを以下に示します。

- 情報の送信または提出
- 設定とオプションの選択
- コンテンツの検索とフィルター処理
- ファイルを開く、保存する、削除する
- コンテンツの編集または作成

コマンド エクスペリエンスの設計と創造的なあります。 選択する入力デバイス、アプリをサポートし、各デバイスにアプリがどのように対応するか。 広範な機能や基本設定をサポートすることによって、アプリで使用できる、ポータブル コンピューター、およびアクセス可能な限り (詳細については、[ユニバーサル Windows プラットフォーム (UWP) アプリ用のコマンド実行のデザイン](../controls-and-patterns/commanding.md)をご覧ください)。



<!--
When designing a command interface, the most important decision is choosing what a user can do. To plan the right type of interactions, focus on your app - consider the user experiences you want to enable, and what steps users will need to take. Once you decide what you want users to accomplish, then you can provide them the tools to do so.
-->

## <a name="choose-the-right-command-elements"></a>適切なコマンド要素を選択します。

コマンド インターフェイスで適切な要素を使うことを直感的で使いやすいアプリと困難、混乱を招くアプリの違いことができます。 包括的な一連のコマンド要素は、ユニバーサル Windows プラットフォーム (UWP) で使用できます。 次に、最も一般的な UWP コマンド要素の一部の一覧を示します。

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

アプリのキャンバスやコマンド バー、コマンド バーのポップアップ、メニュー バーでは、ダイアログなどの特殊なコマンド コンテナーを含む、アプリでの多くのサーフェスにコマンド要素を配置できます。

常にユーザーが直接コンテンツを操作できるようにするではなくを通じてコマンド、コンテンツを上下に移動するコマンド ボタンではなく、ドラッグ アンド ドロップ リスト項目を配置し直すなどの動作を表します。 

ただし、このできない可能性があります、特定の入力デバイスまたは特定のユーザーの機能と設定に対応するときです。 このような場合は、できるだけ多くのコマンド実行アフォー ダンスを提供し、これらのコマンド要素をアプリでのコマンド サーフェスに配置します。

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

コマンドのフィードバックは、操作やコマンドが検出された、コマンドを解釈され、処理する方法と、コマンドが成功したかどうかをユーザーに通信します。 これにより、実行したこと、および次に実行できる機能を把握することができます。 フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。

> [!NOTE]
> 必要な場合にのみ、およびそれが別の場所で利用できない場合にのみ、フィードバックを提供します。 値を追加する場合を除き、簡潔、アプリの UI を維持します。

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

       <a href="../controls-and-patterns/dialogs-and-flyouts/index.md">ポップアップ</a>は、軽量のコンテキスト ポップアップをタップするか、どこかクリックすると、ポップアップの外側で閉じることができます。
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

適切に設計されたアプリケーションの UI は、すべてのユーザーであってアクションを実行します。 最近の操作を元に戻す方法を提供するや、アクションの確認を求めるによってこれらの状況で、アプリが役立ちます。

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

