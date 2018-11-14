---
author: mijacobs
Description: This article describes best practices for creating and displaying app settings.
title: アプリ設定のガイドライン
ms.assetid: 2D765E90-3FA0-42F5-A5CB-BEDC14C3F60A
label: Guidelines
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 56a952950fa9f2d9d57d5beaed397dd72f64ea54
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6674231"
---
# <a name="guidelines-for-app-settings"></a><span data-ttu-id="082fd-103">アプリ設定のガイドライン</span><span class="sxs-lookup"><span data-stu-id="082fd-103">Guidelines for app settings</span></span>



<span data-ttu-id="082fd-104">アプリ設定は、アプリの中でユーザーによるカスタマイズが可能な部分です。この設定は、アプリ設定のページに含まれています。</span><span class="sxs-lookup"><span data-stu-id="082fd-104">App settings are the user-customizable portions of your app and live within an app settings page.</span></span> <span data-ttu-id="082fd-105">たとえば、ニュース リーダー アプリのアプリ設定では、表示するニュース ソースや画面に表示する記事の数を指定できる場合があります。また、天気予報アプリのアプリ設定では、温度の既定の計測単位として摂氏または華氏を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="082fd-105">For example, app settings in a news reader app might let the user specify which news sources to display or how many columns to display on the screen, while a weather app's settings could let the user choose between Celsius and Fahrenheit as the default unit of measurement.</span></span> <span data-ttu-id="082fd-106">この記事では、アプリ設定を作成し、表示する際のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="082fd-106">This article describes best practices for creating and displaying app settings.</span></span>


## <a name="should-i-include-a-settings-page-in-my-app"></a><span data-ttu-id="082fd-107">アプリに設定ページを含めるかどうか</span><span class="sxs-lookup"><span data-stu-id="082fd-107">Should I include a settings page in my app?</span></span>

<span data-ttu-id="082fd-108">アプリ設定のページに含めるアプリのオプションには、次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="082fd-108">Here are examples of app options that belong in an app settings page:</span></span>

-   <span data-ttu-id="082fd-109">アプリの動作に影響するが、頻繁な再調整を必要としない構成オプション。たとえば、天気予報アプリで温度の既定の単位として摂氏または華氏を選ぶ機能、メール アプリでアカウント設定を変更する機能、通知に関する設定、アクセシビリティ オプションなどです。</span><span class="sxs-lookup"><span data-stu-id="082fd-109">Configuration options that affect the behavior of the app and don't require frequent readjustment, like choosing between Celsius or Fahrenheit as default units for temperature in a weather app, changing account settings for a mail app, settings for notifications, or accessibility options.</span></span>
-   <span data-ttu-id="082fd-110">音楽、効果音、配色テーマなど、ユーザーの設定に基づくオプション。</span><span class="sxs-lookup"><span data-stu-id="082fd-110">Options that depend on the user's preferences, like music, sound effects, or color themes.</span></span>
-   <span data-ttu-id="082fd-111">プライバシー ポリシー、ヘルプ、アプリのバージョン、著作権情報など、頻繁にはアクセスされないアプリ情報。</span><span class="sxs-lookup"><span data-stu-id="082fd-111">App information that isn't accessed very often, such as privacy policy, help, app version, or copyright info.</span></span>

<span data-ttu-id="082fd-112">アプリの通常のワークフローに含まれるコマンド (お絵かきアプリでのブラシ色の変更など) は設定ページに含めません。</span><span class="sxs-lookup"><span data-stu-id="082fd-112">Commands that are part of the typical app workflow (for example, changing the brush size in an art app) shouldn't be in a settings page.</span></span> <span data-ttu-id="082fd-113">コマンド配置について詳しくは、「[コマンド設計の基本](https://msdn.microsoft.com/library/windows/apps/dn958433)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="082fd-113">To learn more about command placement, see [Command design basics](https://msdn.microsoft.com/library/windows/apps/dn958433).</span></span>

## <a name="general-recommendations"></a><span data-ttu-id="082fd-114">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="082fd-114">General recommendations</span></span>


-   <span data-ttu-id="082fd-115">設定ページは簡潔にし、バイナリ (オン/オフ) コントロールを利用します。</span><span class="sxs-lookup"><span data-stu-id="082fd-115">Keep settings pages simple and make use of binary (on/off) controls.</span></span> <span data-ttu-id="082fd-116">[トグル スイッチ](../controls-and-patterns/toggles.md)は、一般に、二者択一の設定に最適とされているコントロールです。</span><span class="sxs-lookup"><span data-stu-id="082fd-116">A [toggle switch](../controls-and-patterns/toggles.md) is usually the best control for a binary setting.</span></span>
-   <span data-ttu-id="082fd-117">ユーザーが相互排他的な関連するオプション (5 個まで) の中から 1 つの項目を選ぶことができるようにする場合は、[ラジオ ボタン](../controls-and-patterns/radio-button.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="082fd-117">For settings that let users choose one item from a set of up to 5 mutually exclusive, related options, use [radio buttons](../controls-and-patterns/radio-button.md).</span></span>
-   <span data-ttu-id="082fd-118">アプリ設定のページに、すべてのアプリ設定のエントリ ポイントを作成します。</span><span class="sxs-lookup"><span data-stu-id="082fd-118">Create an entry point for all app settings in your app setting's page.</span></span>
-   <span data-ttu-id="082fd-119">設定はシンプルにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-119">Keep your settings simple.</span></span> <span data-ttu-id="082fd-120">適切な既定値を定義し、設定の数は最小限にします。</span><span class="sxs-lookup"><span data-stu-id="082fd-120">Define smart defaults and keep the number of settings to a minimum.</span></span>
-   <span data-ttu-id="082fd-121">ユーザーが設定を変更したときは、変更がすぐにアプリに反映されるようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-121">When a user changes a setting, the app should immediately reflect the change.</span></span>
-   <span data-ttu-id="082fd-122">アプリの一般的なワークフローに関連するコマンドは追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="082fd-122">Don't include commands that are part of the common app workflow.</span></span>

## <a name="entry-point"></a><span data-ttu-id="082fd-123">エントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="082fd-123">Entry point</span></span>


<span data-ttu-id="082fd-124">ユーザーがアプリ設定のページにアクセスする方法は、アプリのレイアウトに基づいている必要があります。</span><span class="sxs-lookup"><span data-stu-id="082fd-124">The way that users get to your app settings page should be based on your app's layout.</span></span>

**<span data-ttu-id="082fd-125">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082fd-125">Navigation pane</span></span>**

<span data-ttu-id="082fd-126">ナビゲーション ウィンドウ レイアウトの場合、アプリ設定は、選択肢が示されるナビゲーション リストの最後の項目として配置し、下部にピン留めすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082fd-126">For a nav pane layout, app settings should be the last item in the list of navigational choices and be pinned to the bottom:</span></span>

![ナビゲーション ウィンドウでのアプリ設定のエントリ ポイント](images/appsettings-entrypoint-navpane.png)

**<span data-ttu-id="082fd-128">アプリ バー</span><span class="sxs-lookup"><span data-stu-id="082fd-128">App bar</span></span>**

<span data-ttu-id="082fd-129">[アプリ バー](../controls-and-patterns/app-bars.md)またはツール バーを使っている場合、設定のエントリ ポイントを [その他] オーバーフロー メニューの最後の項目として配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-129">If you're using an [app bar](../controls-and-patterns/app-bars.md) or tool bar, place the settings entry point as the last item in the "More" overflow menu.</span></span> <span data-ttu-id="082fd-130">設定のエントリ ポイントを簡単に検索できることがアプリで重要となる場合は、オーバーフローではなく、アプリ バーに直接エントリ ポイントを配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-130">If greater discoverability for the settings entry point is important for your app, place the entry point directly on the app bar and not within the overflow.</span></span>

![アプリ バーでのアプリ設定のエントリ ポイント](images/appsettings-entrypoint-tabs.png)

**<span data-ttu-id="082fd-132">ハブ</span><span class="sxs-lookup"><span data-stu-id="082fd-132">Hub</span></span>**

<span data-ttu-id="082fd-133">ハブ レイアウトを使っている場合は、アプリ設定のエントリ ポイントをアプリ バーの [その他] オーバーフロー メニュー内に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082fd-133">If you're using a hub layout, the entry point for app settings should be placed inside the "More" overflow menu of an app bar.</span></span>

**<span data-ttu-id="082fd-134">タブ/ピボット</span><span class="sxs-lookup"><span data-stu-id="082fd-134">Tabs/pivots</span></span>**

<span data-ttu-id="082fd-135">タブやピボットのレイアウトでは、アプリ設定のエントリ ポイントをナビゲーション内のトップレベルのいずれかの項目として配置することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="082fd-135">For a tabs or pivots layout, we don't recommended placing the app settings entry point as one of the top items within the navigation.</span></span> <span data-ttu-id="082fd-136">代わりに、アプリ設定のエントリ ポイントをアプリ バーの [その他] オーバーフロー メニュー内に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082fd-136">Instead, the entry point for app settings should be placed inside the "More" overflow menu of an app bar.</span></span>

**<span data-ttu-id="082fd-137">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="082fd-137">Master-details</span></span>**

<span data-ttu-id="082fd-138">アプリ設定のエントリをマスター/詳細ウィンドウ内の深い位置に配置するのではなく、マスター ウィンドウのトップ レベルに、最後のピン留めされた項目として配置してください。</span><span class="sxs-lookup"><span data-stu-id="082fd-138">Instead of burying the app settings entry point deeply within a master-details pane, make it the last pinned item on the top level of the master pane.</span></span>

## <a name="layout"></a><span data-ttu-id="082fd-139">レイアウト</span><span class="sxs-lookup"><span data-stu-id="082fd-139">Layout</span></span>


<span data-ttu-id="082fd-140">デスクトップの場合でも、モバイルの場合でも、アプリ設定のウィンドウは全画面で開き、ウィンドウ全体に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-140">On both desktop and mobile, the app settings window should open full-screen and fill the whole window.</span></span> <span data-ttu-id="082fd-141">アプリ設定のメニューに 4 つまでの最上位グループが含まれる場合は、それらのグループが 1 列分右下がりで表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-141">If your app settings menu has up to four top-level groups, those groups should cascade down one column.</span></span>

<span data-ttu-id="082fd-142">デスクトップ:</span><span class="sxs-lookup"><span data-stu-id="082fd-142">Desktop:</span></span>

![デスクトップにおけるアプリ設定のページのレイアウト](images/appsettings-layout-navpane-desktop.png)

<span data-ttu-id="082fd-144">モバイル:</span><span class="sxs-lookup"><span data-stu-id="082fd-144">Mobile:</span></span>

![電話におけるアプリ設定のページのレイアウト](images/appsettings-layout-navpane-mobile.png)

## <a name="color-mode-settings"></a><span data-ttu-id="082fd-146">"カラー モード" の設定</span><span class="sxs-lookup"><span data-stu-id="082fd-146">"Color mode" settings</span></span>


<span data-ttu-id="082fd-147">アプリでユーザーがアプリのカラー モードを選択できるようにする場合は、"アプリ モードを選ぶ" という見出しを持つ[ラジオ ボタン](../controls-and-patterns/radio-button.md)または[コンボ ボックス](../controls-and-patterns/lists.md#drop-down-lists)を使ってこれらのオプションを表示します。</span><span class="sxs-lookup"><span data-stu-id="082fd-147">If your app allows users to choose the app's color mode, present these options using [radio buttons](../controls-and-patterns/radio-button.md) or a [combo box](../controls-and-patterns/lists.md#drop-down-lists) with the header "Choose an app mode".</span></span> <span data-ttu-id="082fd-148">オプションは次のようになっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="082fd-148">The options should read</span></span>
- <span data-ttu-id="082fd-149">明るい</span><span class="sxs-lookup"><span data-stu-id="082fd-149">Light</span></span>
- <span data-ttu-id="082fd-150">暗い</span><span class="sxs-lookup"><span data-stu-id="082fd-150">Dark</span></span>
- <span data-ttu-id="082fd-151">Windows 標準</span><span class="sxs-lookup"><span data-stu-id="082fd-151">Windows default</span></span>

<span data-ttu-id="082fd-152">また、Windows 設定アプリの [色] ページへのハイパーリンクを追加して、ユーザーが現在の既定のアプリ モードにアクセスして変更できるようにすることもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082fd-152">We also recommend adding a hyperlink to the Colors page of the Windows Settings app where users can access and modify the current default app mode.</span></span> <span data-ttu-id="082fd-153">ハイパーリンク テキストには、"Windows の色の設定" という文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="082fd-153">Use the string "Windows color settings" for the hyperlink text.</span></span>

!["モードを選ぶ" セクション](images/appsettings_mode.png)

<!--
<div class="microsoft-internal-note">
Detailed redlines showing preferred text strings for the "Choose a mode" section are available on [UNI](http://uni/DesignDepot.FrontEnd/#/ProductNav/2543/0/dv/?t=Windows%7CControls%7CColorMode&f=RS2).
</div>
-->

## <a name="about-section-and-feedback-button"></a><span data-ttu-id="082fd-155">バージョン情報セクションとフィードバック ボタン</span><span class="sxs-lookup"><span data-stu-id="082fd-155">About section and Feedback button</span></span>


<span data-ttu-id="082fd-156">専用のページとして、または独自のセクションで、アプリに "バージョン情報" セクションを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082fd-156">We recommend placing  "About this App" section in your app either as a dedicated page or in its own section.</span></span> <span data-ttu-id="082fd-157">"フィードバックを送信する" ためのボタンが必要な場合は、そのボタンを "バージョン情報" を表示するページの下部に配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-157">If you want a "Send Feedback" button, place that toward the bottom of the "About this App" page.</span></span>

<span data-ttu-id="082fd-158">"法的情報" サブヘッダーの下に、"使用条件" と "プライバシーに関する声明" を配置し (折り返しのあるテキストを使った[ハイパーリンク ボタン](../controls-and-patterns/hyperlinks.md)にする必要があります)、著作権などのその他の法的情報も配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-158">Under a "Legal" subheader, place any "Terms of Use" and "Privacy Statement" (should be [hyperlink buttons](../controls-and-patterns/hyperlinks.md) with wrapping text) as well as additional legal information, such as copyright.</span></span>

!["バージョン情報" のセクションと "フィードバックを送信する" ためのボタン](images/appsettings-about.png)


## <a name="recommended-page-content"></a><span data-ttu-id="082fd-160">推奨されるページのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="082fd-160">Recommended page content</span></span>


<span data-ttu-id="082fd-161">アプリ設定のページに含める項目の一覧を作成したら、次のガイドラインを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="082fd-161">Once you have a list of items that you want to include in your app settings page, consider these guidelines:</span></span>

-   <span data-ttu-id="082fd-162">類似した設定や関連する設定は、1 つの設定ラベルにまとめます。</span><span class="sxs-lookup"><span data-stu-id="082fd-162">Group similar or related settings under one settings label.</span></span>
-   <span data-ttu-id="082fd-163">設定の合計数は、4 つまたは 5 つ以下に制限してください。</span><span class="sxs-lookup"><span data-stu-id="082fd-163">Try to keep the total number of settings to a maximum of four or five.</span></span>
-   <span data-ttu-id="082fd-164">アプリのコンテキストに関係なく、同じ設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="082fd-164">Display the same settings regardless of the app context.</span></span> <span data-ttu-id="082fd-165">いくつかの設定が特定のコンテキストに適合しない場合は、アプリ設定のポップアップでそれらの設定を無効にします。</span><span class="sxs-lookup"><span data-stu-id="082fd-165">If some settings aren't relevant in a certain context, disable those in the app settings flyout.</span></span>
-   <span data-ttu-id="082fd-166">設定のラベルは、わかりやすい 1 単語にします。</span><span class="sxs-lookup"><span data-stu-id="082fd-166">Use descriptive, one-word labels for settings.</span></span> <span data-ttu-id="082fd-167">たとえば、アカウント関連の設定の場合は、設定の名前を "アカウント設定" ではなく "アカウント" にします。</span><span class="sxs-lookup"><span data-stu-id="082fd-167">For example, name the setting "Accounts" instead of "Account settings" for account-related settings.</span></span> <span data-ttu-id="082fd-168">必要な設定のオプションが 1 つだけで、設定のわかりやすいラベルが思い付かない場合は、"オプション" または "既定" を使います。</span><span class="sxs-lookup"><span data-stu-id="082fd-168">If you only want one option for your settings and the settings don't lend themselves to a descriptive label, use "Options" or "Defaults."</span></span>
-   <span data-ttu-id="082fd-169">設定がポップアップではなく直接 Web にリンクされている場合は、[ハイパーリンク](../controls-and-patterns/hyperlinks.md)としてスタイルを設定した "ヘルプ (オンライン)" や "Web フォーラム" など、ユーザーに視覚的なヒントを与えます。</span><span class="sxs-lookup"><span data-stu-id="082fd-169">If a setting directly links to the web instead of to a flyout, let the user know this with a visual clue, such as "Help (online)" or "Web forums" styled as a [hyperlink](../controls-and-patterns/hyperlinks.md).</span></span> <span data-ttu-id="082fd-170">Web への複数のリンクは、1 つの設定を使ってポップアップにまとめることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="082fd-170">Consider grouping multiple links to the web into a flyout with a single setting.</span></span> <span data-ttu-id="082fd-171">たとえば、"バージョン情報" の設定では、使用条件、プライバシー ポリシー、アプリのサポートへのリンクを含むポップアップが開くようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-171">For example, an "About" setting could open a flyout with links to your terms of use, privacy policy, and app support.</span></span>
-   <span data-ttu-id="082fd-172">使用頻度の高い設定にそれぞれ独自のエントリを割り当てられるように、使用頻度の低い設定は 1 つのエントリにまとめます。</span><span class="sxs-lookup"><span data-stu-id="082fd-172">Combine less-used settings into a single entry so that more common settings can each have their own entry.</span></span> <span data-ttu-id="082fd-173">情報のみを含むコンテンツやリンクは、"バージョン情報" の設定に配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-173">Put content or links that only contain information in an "About" setting.</span></span>
-   <span data-ttu-id="082fd-174">[アクセス許可] ウィンドウの機能と重複しないようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-174">Don't duplicate the functionality in the "Permissions" pane.</span></span> <span data-ttu-id="082fd-175">このウィンドウは既定で用意されており、その内容を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="082fd-175">Windows provides this pane by default and you can't modify it.</span></span>

-   <span data-ttu-id="082fd-176">設定ポップアップへの設定コンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="082fd-176">Add settings content to Settings flyouts</span></span>
-   <span data-ttu-id="082fd-177">コンテンツは 1 列で上から下に表示し、必要に応じてスクロールできるようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-177">Present content from top to bottom in a single column, scrollable if necessary.</span></span> <span data-ttu-id="082fd-178">スクロールの長さは画面の高さの 2 倍までに抑えます。</span><span class="sxs-lookup"><span data-stu-id="082fd-178">Limit scrolling to a maximum of twice the screen height.</span></span>
-   <span data-ttu-id="082fd-179">アプリ設定では次のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="082fd-179">Use the following controls for app settings:</span></span>

    -   <span data-ttu-id="082fd-180">[トグル スイッチ](../controls-and-patterns/toggles.md): ユーザーが値をオンまたはオフに設定できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="082fd-180">[Toggle switches](../controls-and-patterns/toggles.md): To let users set values on or off.</span></span>
    -   <span data-ttu-id="082fd-181">[ラジオ ボタン](../controls-and-patterns/radio-button.md): ユーザーが相互排他的な関連するオプション (5 個まで) の中から 1 つの項目を選択できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="082fd-181">[Radio buttons](../controls-and-patterns/radio-button.md): To let users choose one item from a set of up to 5 mutually exclusive, related options.</span></span>
    -   <span data-ttu-id="082fd-182">[テキスト入力ボックス](../controls-and-patterns/text-block.md): ユーザーがテキストを入力できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="082fd-182">[Text input box](../controls-and-patterns/text-block.md): To let users enter text.</span></span> <span data-ttu-id="082fd-183">ユーザーから取得するテキストの種類 (メール、パスワードなど) に応じた種類のテキスト入力ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="082fd-183">Use the type of text input box that corresponds to the type of text you're getting from the user, such as an email or password.</span></span>
    -   <span data-ttu-id="082fd-184">[ハイパーリンク](../controls-and-patterns/hyperlinks.md): アプリ内の別のページや外部 Web サイトに移動する場合。</span><span class="sxs-lookup"><span data-stu-id="082fd-184">[Hyperlinks](../controls-and-patterns/hyperlinks.md): To take the user to another page within the app or to an external website.</span></span> <span data-ttu-id="082fd-185">ユーザーがハイパーリンクをクリックすると、設定ポップアップは閉じられます。</span><span class="sxs-lookup"><span data-stu-id="082fd-185">When a user clicks a hyperlink, the Settings flyout will be dismissed.</span></span>
    -   <span data-ttu-id="082fd-186">[ボタン](../controls-and-patterns/buttons.md): ユーザーが現在の設定ポップアップを閉じることなく即座に操作を開始できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="082fd-186">[Buttons](../controls-and-patterns/buttons.md): To let users initiate an immediate action without dismissing the current Settings flyout.</span></span>
-   <span data-ttu-id="082fd-187">使用できないコントロールがある場合は、説明用のメッセージを追加します。</span><span class="sxs-lookup"><span data-stu-id="082fd-187">Add a descriptive message if one of the controls is disabled.</span></span> <span data-ttu-id="082fd-188">使用できないコントロールの上に、このメッセージを配置します。</span><span class="sxs-lookup"><span data-stu-id="082fd-188">Place this message above the disabled control.</span></span>
-   <span data-ttu-id="082fd-189">設定ポップアップとヘッダーがアニメーション化された後で、コンテンツとコントロールを単一のブロックとしてアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="082fd-189">Animate content and controls as a single block after the Settings flyout and header have animated.</span></span> <span data-ttu-id="082fd-190">[**enterPage**](https://msdn.microsoft.com/library/windows/apps/br212672)  または [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/br210288) アニメーションを使って、100 ピクセル左のオフセットでコンテンツをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="082fd-190">Animate content using the [**enterPage**](https://msdn.microsoft.com/library/windows/apps/br212672) or [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/br210288) animations with a 100px left offset.</span></span>
-   <span data-ttu-id="082fd-191">必要に応じて、コンテンツの整理と明確化の助けになるように、セクション ヘッダー、段落、ラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="082fd-191">Use section headers, paragraphs, and labels to aid organize and clarify content, if necessary.</span></span>
-   <span data-ttu-id="082fd-192">設定を繰り返し表示する必要がある場合は、UI の階層を追加するか、展開/折りたたみモデルを使います。階層の深さは 2 階層までに抑えます。</span><span class="sxs-lookup"><span data-stu-id="082fd-192">If you need to repeat settings, use an additional level of UI or an expand/collapse model, but avoid hierarchies deeper than two levels.</span></span> <span data-ttu-id="082fd-193">たとえば、天気予報アプリの都市別の設定では、都市の一覧を表示し、ユーザーが都市をタップしたときに、新しいポップアップを開くか、展開して設定オプションを表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="082fd-193">For example, a weather app that provides per-city settings could list the cities and let the user tap on the city to either open a new flyout or expand to show the settings options.</span></span>
-   <span data-ttu-id="082fd-194">コントロールや Web コンテンツの読み込みに時間がかかる場合は、進行状況不定コントロールを使ってユーザーに読み込み中であることを示します。</span><span class="sxs-lookup"><span data-stu-id="082fd-194">If loading controls or web content takes time, use an indeterminate progress control to indicate to users that info is loading.</span></span> <span data-ttu-id="082fd-195">詳しくは、「[プログレス コントロールのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465469)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="082fd-195">For more info, see [Guidelines for progress controls](https://msdn.microsoft.com/library/windows/apps/hh465469).</span></span>
-   <span data-ttu-id="082fd-196">移動や変更をコミットするためのボタンは使いません。</span><span class="sxs-lookup"><span data-stu-id="082fd-196">Don't use buttons for navigation or to commit changes.</span></span> <span data-ttu-id="082fd-197">別のページに移動するにはハイパーリンクを使います。また、ボタンを使って変更をコミットする代わりに、ユーザーが設定ポップアップを閉じたときにアプリ設定の変更を自動的に保存します。</span><span class="sxs-lookup"><span data-stu-id="082fd-197">Use hyperlinks to navigate to other pages, and instead of using a button to commit changes, automatically save changes to app settings when a user dismisses the Settings flyout.</span></span>



## <a name="related-articles"></a><span data-ttu-id="082fd-198">関連記事</span><span class="sxs-lookup"><span data-stu-id="082fd-198">Related articles</span></span>

* [<span data-ttu-id="082fd-199">コマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="082fd-199">Command design basics</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958433)
* [<span data-ttu-id="082fd-200">プログレス コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="082fd-200">Guidelines for progress controls</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465469)
* [<span data-ttu-id="082fd-201">アプリ データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="082fd-201">Store and retrieve app data</span></span>](https://msdn.microsoft.com/library/windows/apps/mt299098)
* [**<span data-ttu-id="082fd-202">EntranceThemeTransition</span><span class="sxs-lookup"><span data-stu-id="082fd-202">EntranceThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210288)
