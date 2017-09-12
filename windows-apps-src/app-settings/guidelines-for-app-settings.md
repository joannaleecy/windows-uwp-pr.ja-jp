---
author: mijacobs
Description: "この記事では、アプリ設定を作成し、表示する際のベスト プラクティスについて説明します。"
title: "アプリ設定のガイドライン"
ms.assetid: 2D765E90-3FA0-42F5-A5CB-BEDC14C3F60A
label: Guidelines
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 67714d0b7a95e1034486d39853c91c9a7590bfa5
ms.sourcegitcommit: 45490bd85e6f8d247a041841d547ecac2ff48250
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2017
---
# <a name="guidelines-for-app-settings"></a><span data-ttu-id="11ee2-104">アプリ設定のガイドライン</span><span class="sxs-lookup"><span data-stu-id="11ee2-104">Guidelines for app settings</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="11ee2-105">アプリ設定は、アプリの中でユーザーによるカスタマイズが可能な部分です。この設定は、アプリ設定のページに含まれています。</span><span class="sxs-lookup"><span data-stu-id="11ee2-105">App settings are the user-customizable portions of your app and live within an app settings page.</span></span> <span data-ttu-id="11ee2-106">たとえば、ニュース リーダー アプリのアプリ設定では、表示するニュース ソースや画面に表示する記事の数を指定できる場合があります。また、天気予報アプリのアプリ設定では、温度の既定の計測単位として摂氏または華氏を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-106">For example, app settings in a news reader app might let the user specify which news sources to display or how many columns to display on the screen, while a weather app's settings could let the user choose between Celsius and Fahrenheit as the default unit of measurement.</span></span> <span data-ttu-id="11ee2-107">この記事では、アプリ設定を作成し表示する際のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-107">This article describes best practices for creating and displaying app settings.</span></span>

![設定ウィンドウの例](images/app-settings.png)

## <a name="should-i-include-a-settings-page-in-my-app"></a><span data-ttu-id="11ee2-109">アプリに設定ページを含めるかどうか</span><span class="sxs-lookup"><span data-stu-id="11ee2-109">Should I include a settings page in my app?</span></span>

<span data-ttu-id="11ee2-110">アプリ設定のページに含めるアプリのオプションには、次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="11ee2-110">Here are examples of app options that belong in an app settings page:</span></span>

-   <span data-ttu-id="11ee2-111">アプリの動作に影響するが、頻繁な再調整を必要としない構成オプション。たとえば、天気予報アプリで温度の既定の単位として摂氏または華氏を選ぶ機能、メール アプリでアカウント設定を変更する機能、通知に関する設定、アクセシビリティ オプションなどです。</span><span class="sxs-lookup"><span data-stu-id="11ee2-111">Configuration options that affect the behavior of the app and don't require frequent readjustment, like choosing between Celsius or Fahrenheit as default units for temperature in a weather app, changing account settings for a mail app, settings for notifications, or accessibility options.</span></span>
-   <span data-ttu-id="11ee2-112">音楽、効果音、配色テーマなど、ユーザーの設定に基づくオプション。</span><span class="sxs-lookup"><span data-stu-id="11ee2-112">Options that depend on the user's preferences, like music, sound effects, or color themes.</span></span>
-   <span data-ttu-id="11ee2-113">プライバシー ポリシー、ヘルプ、アプリのバージョン、著作権情報など、頻繁にはアクセスされないアプリ情報。</span><span class="sxs-lookup"><span data-stu-id="11ee2-113">App information that isn't accessed very often, such as privacy policy, help, app version, or copyright info.</span></span>

<span data-ttu-id="11ee2-114">アプリの通常のワークフローに含まれるコマンド (お絵かきアプリでのブラシ色の変更など) は設定ページに含めません。</span><span class="sxs-lookup"><span data-stu-id="11ee2-114">Commands that are part of the typical app workflow (for example, changing the brush size in an art app) shouldn't be in a settings page.</span></span> <span data-ttu-id="11ee2-115">コマンド配置について詳しくは、「[コマンド設計の基本](https://msdn.microsoft.com/library/windows/apps/dn958433)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-115">To learn more about command placement, see [Command design basics](https://msdn.microsoft.com/library/windows/apps/dn958433).</span></span>

## <a name="general-recommendations"></a><span data-ttu-id="11ee2-116">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="11ee2-116">General recommendations</span></span>


-   <span data-ttu-id="11ee2-117">設定ページは簡潔にし、バイナリ (オン/オフ) コントロールを利用します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-117">Keep settings pages simple and make use of binary (on/off) controls.</span></span> <span data-ttu-id="11ee2-118">[トグル スイッチ](../controls-and-patterns/toggles.md)は、一般に、二者択一の設定に最適とされているコントロールです。</span><span class="sxs-lookup"><span data-stu-id="11ee2-118">A [toggle switch](../controls-and-patterns/toggles.md) is usually the best control for a binary setting.</span></span>
-   <span data-ttu-id="11ee2-119">ユーザーが相互排他的な関連するオプション (5 個まで) の中から 1 つの項目を選ぶことができるようにする場合は、[ラジオ ボタン](../controls-and-patterns/radio-button.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="11ee2-119">For settings that let users choose one item from a set of up to 5 mutually exclusive, related options, use [radio buttons](../controls-and-patterns/radio-button.md).</span></span>
-   <span data-ttu-id="11ee2-120">アプリ設定のページに、すべてのアプリ設定のエントリ ポイントを作成します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-120">Create an entry point for all app settings in your app setting's page.</span></span>
-   <span data-ttu-id="11ee2-121">設定はシンプルにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-121">Keep your settings simple.</span></span> <span data-ttu-id="11ee2-122">適切な既定値を定義し、設定の数は最小限にします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-122">Define smart defaults and keep the number of settings to a minimum.</span></span>
-   <span data-ttu-id="11ee2-123">ユーザーが設定を変更したときは、変更がすぐにアプリに反映されるようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-123">When a user changes a setting, the app should immediately reflect the change.</span></span>
-   <span data-ttu-id="11ee2-124">アプリの一般的なワークフローに関連するコマンドは追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-124">Don't include commands that are part of the common app workflow.</span></span>

## <a name="entry-point"></a><span data-ttu-id="11ee2-125">エントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="11ee2-125">Entry point</span></span>


<span data-ttu-id="11ee2-126">ユーザーがアプリ設定のページにアクセスする方法は、アプリのレイアウトに基づいている必要があります。</span><span class="sxs-lookup"><span data-stu-id="11ee2-126">The way that users get to your app settings page should be based on your app's layout.</span></span>

**<span data-ttu-id="11ee2-127">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="11ee2-127">Navigation pane</span></span>**

<span data-ttu-id="11ee2-128">ナビゲーション ウィンドウ レイアウトの場合、アプリ設定は、選択肢が示されるナビゲーション リストの最後の項目として配置し、下部にピン留めすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-128">For a nav pane layout, app settings should be the last item in the list of navigational choices and be pinned to the bottom:</span></span>

![ナビゲーション ウィンドウでのアプリ設定のエントリ ポイント](images/appsettings-entrypoint-navpane.png)

**<span data-ttu-id="11ee2-130">アプリ バー</span><span class="sxs-lookup"><span data-stu-id="11ee2-130">App bar</span></span>**

<span data-ttu-id="11ee2-131">[アプリ バー](../controls-and-patterns/app-bars.md)またはツール バーを使っている場合、設定のエントリ ポイントを [その他] オーバーフロー メニューの最後の項目として配置します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-131">If you're using an [app bar](../controls-and-patterns/app-bars.md) or tool bar, place the settings entry point as the last item in the "More" overflow menu.</span></span> <span data-ttu-id="11ee2-132">設定のエントリ ポイントを簡単に検索できることがアプリで重要となる場合は、オーバーフローではなく、アプリ バーに直接エントリ ポイントを配置します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-132">If greater discoverability for the settings entry point is important for your app, place the entry point directly on the app bar and not within the overflow.</span></span>

![アプリ バーでのアプリ設定のエントリ ポイント](images/appsettings-entrypoint-tabs.png)

**<span data-ttu-id="11ee2-134">ハブ</span><span class="sxs-lookup"><span data-stu-id="11ee2-134">Hub</span></span>**

<span data-ttu-id="11ee2-135">ハブ レイアウトを使っている場合は、アプリ設定のエントリ ポイントをアプリ バーの [その他] オーバーフロー メニュー内に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-135">If you're using a hub layout, the entry point for app settings should be placed inside the "More" overflow menu of an app bar.</span></span>

**<span data-ttu-id="11ee2-136">タブ/ピボット</span><span class="sxs-lookup"><span data-stu-id="11ee2-136">Tabs/pivots</span></span>**

<span data-ttu-id="11ee2-137">タブやピボットのレイアウトでは、アプリ設定のエントリ ポイントをナビゲーション内のトップレベルのいずれかの項目として配置することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="11ee2-137">For a tabs or pivots layout, we don't recommended placing the app settings entry point as one of the top items within the navigation.</span></span> <span data-ttu-id="11ee2-138">代わりに、アプリ設定のエントリ ポイントをアプリ バーの [その他] オーバーフロー メニュー内に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-138">Instead, the entry point for app settings should be placed inside the "More" overflow menu of an app bar.</span></span>

**<span data-ttu-id="11ee2-139">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="11ee2-139">Master-details</span></span>**

<span data-ttu-id="11ee2-140">アプリ設定のエントリをマスター/詳細ウィンドウ内の深い位置に配置するのではなく、マスター ウィンドウのトップ レベルに、最後のピン留めされた項目として配置してください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-140">Instead of burying the app settings entry point deeply within a master-details pane, make it the last pinned item on the top level of the master pane.</span></span>

## <a name="layout"></a><span data-ttu-id="11ee2-141">レイアウト</span><span class="sxs-lookup"><span data-stu-id="11ee2-141">Layout</span></span>


<span data-ttu-id="11ee2-142">デスクトップの場合でも、モバイルの場合でも、アプリ設定のウィンドウは全画面で開き、ウィンドウ全体に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-142">On both desktop and mobile, the app settings window should open full-screen and fill the whole window.</span></span> <span data-ttu-id="11ee2-143">アプリ設定のメニューに 4 つまでの最上位グループが含まれる場合は、それらのグループが 1 列分右下がりで表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-143">If your app settings menu has up to four top-level groups, those groups should cascade down one column.</span></span>

<span data-ttu-id="11ee2-144">デスクトップ:</span><span class="sxs-lookup"><span data-stu-id="11ee2-144">Desktop:</span></span>

![デスクトップにおけるアプリ設定のページのレイアウト](images/appsettings-layout-navpane-desktop.png)

<span data-ttu-id="11ee2-146">モバイル:</span><span class="sxs-lookup"><span data-stu-id="11ee2-146">Mobile:</span></span>

![電話におけるアプリ設定のページのレイアウト](images/appsettings-layout-navpane-mobile.png)

## <a name="color-mode-settings"></a><span data-ttu-id="11ee2-148">"カラー モード" の設定</span><span class="sxs-lookup"><span data-stu-id="11ee2-148">"Color mode" settings</span></span>


<span data-ttu-id="11ee2-149">アプリでユーザーがアプリのカラー モードを選択できるようにする場合は、"モードを選ぶ" という見出しを持つ[ラジオ ボタン](../controls-and-patterns/radio-button.md)または[コンボ ボックス](../controls-and-patterns/lists.md#drop-down-lists)を使ってこれらのオプションを表示します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-149">If your app allows users to choose the app's color mode, present these options using [radio buttons](../controls-and-patterns/radio-button.md) or a [combo box](../controls-and-patterns/lists.md#drop-down-lists) with the header "Choose a mode".</span></span> <span data-ttu-id="11ee2-150">オプションは次のようになっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="11ee2-150">The options should read</span></span>
- <span data-ttu-id="11ee2-151">明るい</span><span class="sxs-lookup"><span data-stu-id="11ee2-151">Light</span></span>
- <span data-ttu-id="11ee2-152">暗い</span><span class="sxs-lookup"><span data-stu-id="11ee2-152">Dark</span></span>
- <span data-ttu-id="11ee2-153">Windows の既定</span><span class="sxs-lookup"><span data-stu-id="11ee2-153">Windows default</span></span>

<span data-ttu-id="11ee2-154">また、Windows 設定アプリの [色] ページへのハイパーリンクを追加して、ユーザーが Windowsの既定のテーマを確認できるようにすることもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-154">We also recommend adding a hyperlink to the Colors page of the Windows Settings app where users can check the Windows default theme.</span></span> <span data-ttu-id="11ee2-155">ハイパーリンク テキストには、"Windows の色の設定" という文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-155">Use the string "Windows color settings" for the hyperlink text.</span></span>

!["モードを選ぶ" セクション](images/appsettings_mode.png)

<!--
<div class="microsoft-internal-note">
Detailed redlines showing preferred text strings for the "Choose a mode" section are available on [UNI](http://uni/DesignDepot.FrontEnd/#/ProductNav/2543/0/dv/?t=Windows%7CControls%7CColorMode&f=RS2).
</div>
-->

## <a name="about-section-and-give-feedback-button"></a><span data-ttu-id="11ee2-157">"バージョン情報" のセクションと "フィードバックを送信する" ためのボタン</span><span class="sxs-lookup"><span data-stu-id="11ee2-157">"About" section and "Give feedback" button</span></span>


<span data-ttu-id="11ee2-158">"バージョン情報" のセクションがアプリで必要となる場合は、そのセクション専用のアプリ設定のページを作成します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-158">If you need an "About this app" section in your app, create a dedicated app settings page for that.</span></span> <span data-ttu-id="11ee2-159">"フィードバックを送信する" ためのボタンが必要な場合は、そのボタンを "バージョン情報" を表示するページの下部に配置します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-159">If you want a "Give Feedback" button, place that toward the bottom of the "About this app" page.</span></span>

<span data-ttu-id="11ee2-160">"使用条件" や "プライバシーに関する声明" は、テキストの折り返しを使い、[ハイパーリンク ボタン](../controls-and-patterns/hyperlinks.md)として設定します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-160">"Terms of Use" and "Privacy Statement" should be [hyperlink buttons](../controls-and-patterns/hyperlinks.md) with wrapping text.</span></span>

!["バージョン情報" のセクションと "フィードバックを送信する" ためのボタン](images/appsettings-about.png)


## <a name="recommended-page-content"></a><span data-ttu-id="11ee2-162">推奨されるページのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="11ee2-162">Recommended page content</span></span>


<span data-ttu-id="11ee2-163">アプリ設定のページに含める項目の一覧を作成したら、次のガイドラインを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-163">Once you have a list of items that you want to include in your app settings page, consider these guidelines:</span></span>

-   <span data-ttu-id="11ee2-164">類似した設定や関連する設定は、1 つの設定ラベルにまとめます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-164">Group similar or related settings under one settings label.</span></span>
-   <span data-ttu-id="11ee2-165">設定の合計数は、4 つまたは 5 つ以下に制限してください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-165">Try to keep the total number of settings to a maximum of four or five.</span></span>
-   <span data-ttu-id="11ee2-166">アプリのコンテキストに関係なく、同じ設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-166">Display the same settings regardless of the app context.</span></span> <span data-ttu-id="11ee2-167">いくつかの設定が特定のコンテキストに適合しない場合は、アプリ設定のポップアップでそれらの設定を無効にします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-167">If some settings aren't relevant in a certain context, disable those in the app settings flyout.</span></span>
-   <span data-ttu-id="11ee2-168">設定のラベルは、わかりやすい 1 単語にします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-168">Use descriptive, one-word labels for settings.</span></span> <span data-ttu-id="11ee2-169">たとえば、アカウント関連の設定の場合は、設定の名前を "アカウント設定" ではなく "アカウント" にします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-169">For example, name the setting "Accounts" instead of "Account settings" for account-related settings.</span></span> <span data-ttu-id="11ee2-170">必要な設定のオプションが 1 つだけで、設定のわかりやすいラベルが思い付かない場合は、"オプション" または "既定" を使います。</span><span class="sxs-lookup"><span data-stu-id="11ee2-170">If you only want one option for your settings and the settings don't lend themselves to a descriptive label, use "Options" or "Defaults."</span></span>
-   <span data-ttu-id="11ee2-171">設定がポップアップではなく直接 Web にリンクされている場合は、[ハイパーリンク](../controls-and-patterns/hyperlinks.md)としてスタイルを設定した "ヘルプ (オンライン)" や "Web フォーラム" など、ユーザーに視覚的なヒントを与えます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-171">If a setting directly links to the web instead of to a flyout, let the user know this with a visual clue, such as "Help (online)" or "Web forums" styled as a [hyperlink](../controls-and-patterns/hyperlinks.md).</span></span> <span data-ttu-id="11ee2-172">Web への複数のリンクは、1 つの設定を使ってポップアップにまとめることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-172">Consider grouping multiple links to the web into a flyout with a single setting.</span></span> <span data-ttu-id="11ee2-173">たとえば、"バージョン情報" の設定では、使用条件、プライバシー ポリシー、アプリのサポートへのリンクを含むポップアップが開くようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-173">For example, an "About" setting could open a flyout with links to your terms of use, privacy policy, and app support.</span></span>
-   <span data-ttu-id="11ee2-174">使用頻度の高い設定にそれぞれ独自のエントリを割り当てられるように、使用頻度の低い設定は 1 つのエントリにまとめます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-174">Combine less-used settings into a single entry so that more common settings can each have their own entry.</span></span> <span data-ttu-id="11ee2-175">情報のみを含むコンテンツやリンクは、"バージョン情報" の設定に配置します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-175">Put content or links that only contain information in an "About" setting.</span></span>
-   <span data-ttu-id="11ee2-176">[アクセス許可] ウィンドウの機能と重複しないようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-176">Don't duplicate the functionality in the "Permissions" pane.</span></span> <span data-ttu-id="11ee2-177">このウィンドウは既定で用意されており、その内容を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="11ee2-177">Windows provides this pane by default and you can't modify it.</span></span>

-   <span data-ttu-id="11ee2-178">設定ポップアップへの設定コンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="11ee2-178">Add settings content to Settings flyouts</span></span>
-   <span data-ttu-id="11ee2-179">コンテンツは 1 列で上から下に表示し、必要に応じてスクロールできるようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-179">Present content from top to bottom in a single column, scrollable if necessary.</span></span> <span data-ttu-id="11ee2-180">スクロールの長さは画面の高さの 2 倍までに抑えます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-180">Limit scrolling to a maximum of twice the screen height.</span></span>
-   <span data-ttu-id="11ee2-181">アプリ設定では次のコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="11ee2-181">Use the following controls for app settings:</span></span>

    -   <span data-ttu-id="11ee2-182">[トグル スイッチ](../controls-and-patterns/toggles.md): ユーザーが値をオンまたはオフに設定できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="11ee2-182">[Toggle switches](../controls-and-patterns/toggles.md): To let users set values on or off.</span></span>
    -   <span data-ttu-id="11ee2-183">[ラジオ ボタン](../controls-and-patterns/radio-button.md): ユーザーが相互排他的な関連するオプション (5 個まで) の中から 1 つの項目を選択できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="11ee2-183">[Radio buttons](../controls-and-patterns/radio-button.md): To let users choose one item from a set of up to 5 mutually exclusive, related options.</span></span>
    -   <span data-ttu-id="11ee2-184">[テキスト入力ボックス](../controls-and-patterns/text-block.md): ユーザーがテキストを入力できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="11ee2-184">[Text input box](../controls-and-patterns/text-block.md): To let users enter text.</span></span> <span data-ttu-id="11ee2-185">ユーザーから取得するテキストの種類 (メール、パスワードなど) に応じた種類のテキスト入力ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="11ee2-185">Use the type of text input box that corresponds to the type of text you're getting from the user, such as an email or password.</span></span>
    -   <span data-ttu-id="11ee2-186">[ハイパーリンク](../controls-and-patterns/hyperlinks.md): アプリ内の別のページや外部 Web サイトに移動する場合。</span><span class="sxs-lookup"><span data-stu-id="11ee2-186">[Hyperlinks](../controls-and-patterns/hyperlinks.md): To take the user to another page within the app or to an external website.</span></span> <span data-ttu-id="11ee2-187">ユーザーがハイパーリンクをクリックすると、設定ポップアップは閉じられます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-187">When a user clicks a hyperlink, the Settings flyout will be dismissed.</span></span>
    -   <span data-ttu-id="11ee2-188">[ボタン](../controls-and-patterns/buttons.md): ユーザーが現在の設定ポップアップを閉じることなく即座に操作を開始できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="11ee2-188">[Buttons](../controls-and-patterns/buttons.md): To let users initiate an immediate action without dismissing the current Settings flyout.</span></span>
-   <span data-ttu-id="11ee2-189">使用できないコントロールがある場合は、説明用のメッセージを追加します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-189">Add a descriptive message if one of the controls is disabled.</span></span> <span data-ttu-id="11ee2-190">使用できないコントロールの上に、このメッセージを配置します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-190">Place this message above the disabled control.</span></span>
-   <span data-ttu-id="11ee2-191">設定ポップアップとヘッダーがアニメーション化された後で、コンテンツとコントロールを単一のブロックとしてアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-191">Animate content and controls as a single block after the Settings flyout and header have animated.</span></span> <span data-ttu-id="11ee2-192">[**enterPage**](https://msdn.microsoft.com/library/windows/apps/br212672)  または [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/br210288) アニメーションを使って、100 ピクセル左のオフセットでコンテンツをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-192">Animate content using the [**enterPage**](https://msdn.microsoft.com/library/windows/apps/br212672) or [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/br210288) animations with a 100px left offset.</span></span>
-   <span data-ttu-id="11ee2-193">必要に応じて、コンテンツの整理と明確化の助けになるように、セクション ヘッダー、段落、ラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="11ee2-193">Use section headers, paragraphs, and labels to aid organize and clarify content, if necessary.</span></span>
-   <span data-ttu-id="11ee2-194">設定を繰り返し表示する必要がある場合は、UI の階層を追加するか、展開/折りたたみモデルを使います。階層の深さは 2 階層までに抑えます。</span><span class="sxs-lookup"><span data-stu-id="11ee2-194">If you need to repeat settings, use an additional level of UI or an expand/collapse model, but avoid hierarchies deeper than two levels.</span></span> <span data-ttu-id="11ee2-195">たとえば、天気予報アプリの都市別の設定では、都市の一覧を表示し、ユーザーが都市をタップしたときに、新しいポップアップを開くか、展開して設定オプションを表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="11ee2-195">For example, a weather app that provides per-city settings could list the cities and let the user tap on the city to either open a new flyout or expand to show the settings options.</span></span>
-   <span data-ttu-id="11ee2-196">コントロールや Web コンテンツの読み込みに時間がかかる場合は、進行状況不定コントロールを使ってユーザーに読み込み中であることを示します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-196">If loading controls or web content takes time, use an indeterminate progress control to indicate to users that info is loading.</span></span> <span data-ttu-id="11ee2-197">詳しくは、「[プログレス コントロールのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465469)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="11ee2-197">For more info, see [Guidelines for progress controls](https://msdn.microsoft.com/library/windows/apps/hh465469).</span></span>
-   <span data-ttu-id="11ee2-198">移動や変更をコミットするためのボタンは使いません。</span><span class="sxs-lookup"><span data-stu-id="11ee2-198">Don't use buttons for navigation or to commit changes.</span></span> <span data-ttu-id="11ee2-199">別のページに移動するにはハイパーリンクを使います。また、ボタンを使って変更をコミットする代わりに、ユーザーが設定ポップアップを閉じたときにアプリ設定の変更を自動的に保存します。</span><span class="sxs-lookup"><span data-stu-id="11ee2-199">Use hyperlinks to navigate to other pages, and instead of using a button to commit changes, automatically save changes to app settings when a user dismisses the Settings flyout.</span></span>



## <a name="related-articles"></a><span data-ttu-id="11ee2-200">関連記事</span><span class="sxs-lookup"><span data-stu-id="11ee2-200">Related articles</span></span>

* [<span data-ttu-id="11ee2-201">コマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="11ee2-201">Command design basics</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958433)
* [<span data-ttu-id="11ee2-202">プログレス コントロールのガイドライン</span><span class="sxs-lookup"><span data-stu-id="11ee2-202">Guidelines for progress controls</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465469)
* [<span data-ttu-id="11ee2-203">アプリ データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="11ee2-203">Store and retrieve app data</span></span>](https://msdn.microsoft.com/library/windows/apps/mt299098)
* [**<span data-ttu-id="11ee2-204">EntranceThemeTransition</span><span class="sxs-lookup"><span data-stu-id="11ee2-204">EntranceThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210288)
