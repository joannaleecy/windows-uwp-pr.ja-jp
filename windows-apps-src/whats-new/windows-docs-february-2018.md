---
author: QuinnRadich
title: Windows ドキュメントの最新情報、2018 年 2 月 - UWP アプリの開発
description: 2018 年 2 月版の Windows 10 開発者向けドキュメントには、新しい機能、ビデオ、開発者向けガイダンスが追加されました
keywords: 最新情報, 更新, 機能, 開発者向けガイダンス, Windows 10, 2 月
ms.author: quradic
ms.date: 2/5/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: b55649b5a4fb0927b03d3fcaf55545a7852d6526
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4111428"
---
# <a name="whats-new-in-the-windows-developer-docs-in-february-2018"></a><span data-ttu-id="77011-104">Windows 開発者向けドキュメントの最新情報、2018 年 2 月</span><span class="sxs-lookup"><span data-stu-id="77011-104">What's New in the Windows Developer Docs in February 2018</span></span>

<span data-ttu-id="77011-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="77011-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="77011-106">ここに示す機能概要、開発者向けガイダンス、ビデオは 1 月に公開されたもので、Windows 開発者向けの新しい情報や更新情報を含んでいます。</span><span class="sxs-lookup"><span data-stu-id="77011-106">The following feature overviews, developer guidance, and videos have been made available in the month of January, containing new and updated information for Windows developers.</span></span>

<span data-ttu-id="77011-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="77011-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/create-uwp-apps.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>


## <a name="features"></a><span data-ttu-id="77011-108">機能</span><span class="sxs-lookup"><span data-stu-id="77011-108">Features</span></span>

### <a name="adaptive-and-interactive-toast-notifications"></a><span data-ttu-id="77011-109">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="77011-109">Adaptive and interactive toast notifications</span></span>

<span data-ttu-id="77011-110">アダプティブ トースト通知と対話型トースト通知で、アプリを強化できます。</span><span class="sxs-lookup"><span data-stu-id="77011-110">Enhance your app with adaptive and interactive notifications.</span></span> <span data-ttu-id="77011-111">まず[トースト通知に関する最新のガイダンス](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)で、イメージ サイズの制限、進行状況バー、入力オプションの最新情報をご確認ください。</span><span class="sxs-lookup"><span data-stu-id="77011-111">Get started with our [updated guidance on toast notifications](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md), and explore the new information on image size restrictions, progress bars, and adding input options.</span></span>

<span data-ttu-id="77011-112">[カスタム タイムスタンプ](../design/shell/tiles-and-notifications/custom-timestamps-on-toasts.md)、[カスタム オーディオ](../design/shell/tiles-and-notifications/custom-audio-on-toasts.md)、[進行状況バー](../design/shell/tiles-and-notifications/toast-progress-bar.md)で、トースト通知をさらにカスタマイズしましょう。</span><span class="sxs-lookup"><span data-stu-id="77011-112">Customize your toast notifications further with [Custom timestamps](../design/shell/tiles-and-notifications/custom-timestamps-on-toasts.md), [Custom audio](../design/shell/tiles-and-notifications/custom-audio-on-toasts.md), or [Progress bars](../design/shell/tiles-and-notifications/toast-progress-bar.md)</span></span>

<span data-ttu-id="77011-113">ユーザー デバイスに対する通知は、[通知のミラーリング](../design/shell/tiles-and-notifications/notification-mirroring.md)と[ユニバーサル承諾](../design/shell/tiles-and-notifications/universal-dismiss.md)で拡張できます。</span><span class="sxs-lookup"><span data-stu-id="77011-113">Extend notifications across your user's devices with [Notification mirroring](../design/shell/tiles-and-notifications/notification-mirroring.md) and [Universal dismiss](../design/shell/tiles-and-notifications/universal-dismiss.md).</span></span>

<span data-ttu-id="77011-114">[トースト ヘッダー](../design/shell/tiles-and-notifications/toast-headers.md)と[更新保留アクティブ化](../design/shell/tiles-and-notifications/toast-pending-update.md)を使用し、通知をグループ化して整理しましょう。</span><span class="sxs-lookup"><span data-stu-id="77011-114">Group and organize your notifications with [Toast headers](../design/shell/tiles-and-notifications/toast-headers.md) and [Pending update activation](../design/shell/tiles-and-notifications/toast-pending-update.md).</span></span>

![更新保留アクティブ化の動作](../design/shell/tiles-and-notifications/images/toast-pendingupdate.gif)

### <a name="page-layouts-with-xaml"></a><span data-ttu-id="77011-116">XAML を使ったページ レイアウト</span><span class="sxs-lookup"><span data-stu-id="77011-116">Page layouts with XAML</span></span>

<span data-ttu-id="77011-117">[XAML ページ レイアウト](../design/layout/layouts-with-xaml.md)に関するドキュメントが更新され、柔軟なレイアウトと表示状態の情報が新しく追加されました。</span><span class="sxs-lookup"><span data-stu-id="77011-117">We've updated our [XAML page layout](../design/layout/layouts-with-xaml.md) docs with new information on fluid layouts and visual states.</span></span> <span data-ttu-id="77011-118">これらの新しい機能を使用すると、使用できる表示領域に合わせてアプリ内の要素の位置がどのように呼応するかをさらに細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="77011-118">These new features allow for greater control over how the position of elements in your app respond and adapt to the available visual space.</span></span>

![XAML ページ レイアウトの余白とパディング](../design/layout/images/xaml-layout-margins-padding.png)

### <a name="subscription-add-ons-are-now-available-to-all-developers"></a><span data-ttu-id="77011-120">すべての開発者がサブスクリプション アドオンを利用できるようになりました</span><span class="sxs-lookup"><span data-stu-id="77011-120">Subscription add-ons are now available to all developers</span></span>

<span data-ttu-id="77011-121">サブスクリプション アドオンを作成して公開すると、定期的な自動課金期間を設定して、アプリ内やゲーム内でデジタル製品 (アプリの機能やデジタル コンテンツなど) を販売できます。</span><span class="sxs-lookup"><span data-stu-id="77011-121">Create and publish subscription add-ons to sell digital products in your apps and games (such as app features or digital content) with automated recurring billing periods.</span></span> <span data-ttu-id="77011-122">詳しくは、「[アプリのサブスクリプション アドオンの有効化](../monetize/enable-subscription-add-ons-for-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="77011-122">For more details, see [Enable subscription add-ons for your app](../monetize/enable-subscription-add-ons-for-your-app.md).</span></span>

## <a name="developer-guidance"></a><span data-ttu-id="77011-123">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="77011-123">Developer Guidance</span></span>

### <a name="design-basics"></a><span data-ttu-id="77011-124">設計の基本</span><span class="sxs-lookup"><span data-stu-id="77011-124">Design basics</span></span>

<span data-ttu-id="77011-125">「[UWP アプリ設計の概要](../design/basics/design-and-ui-intro.md)」には、多数の図による例示が新たに追加されています。</span><span class="sxs-lookup"><span data-stu-id="77011-125">Our [introduction to UWP app design](../design/basics/design-and-ui-intro.md) has been enhanced with a slew of new visual examples.</span></span> <span data-ttu-id="77011-126">すべての UWP でユニバーサル デザイン機能を概説し、Fluent Design System の機能を組み込む方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="77011-126">The overview of the universal design features in every UWP now highlights how you can put the capabilities of the Fluent Design System into action.</span></span>

<span data-ttu-id="77011-127">一般的なページ パターンの紹介を「[コンテンツ デザインの基本](../design/basics/content-basics.md)」に追加し、異なる種類のコンテンツをアプリで表示する方法のさまざまな例を示しています。</span><span class="sxs-lookup"><span data-stu-id="77011-127">We've added a showcase of common page patterns to our [Content design basics](../design/basics/content-basics.md), providing a gallery of examples of how your app can display diferent types of content.</span></span>

![ハブ ページ パターンの図](../design/basics/images/hub.png)

### <a name="writing-style"></a><span data-ttu-id="77011-129">記述スタイル</span><span class="sxs-lookup"><span data-stu-id="77011-129">Writing style</span></span>

<span data-ttu-id="77011-130">文体と語調に関する記事を更新および拡張し、[記述スタイルに関するガイダンス](../design/style/writing-style.md)を作成しました。</span><span class="sxs-lookup"><span data-stu-id="77011-130">We've upgraded and expanded our article on voice and tone, transforming it into [Writing style guidance](../design/style/writing-style.md).</span></span> <span data-ttu-id="77011-131">この新しいガイドでは、アプリ内に効果的なテキストを作成するための原則と、エラー メッセージやダイアログなどのコントロールに使用する記述スタイルのベスト プラクティスを示しています。</span><span class="sxs-lookup"><span data-stu-id="77011-131">This new information provides principles for creating effective text in your app, and recommends best practices for writing for controls such as error messages or dialogs.</span></span>

### <a name="getting-started-for-game-development"></a><span data-ttu-id="77011-132">ゲーム開発の概要</span><span class="sxs-lookup"><span data-stu-id="77011-132">Getting started for game development</span></span>

<span data-ttu-id="77011-133">Windows 10 用のゲーム開発に関心をお持ちですか? </span><span class="sxs-lookup"><span data-stu-id="77011-133">Interested in developing games for Windows 10?</span></span> <span data-ttu-id="77011-134">新しい[ゲーム開発の作業の概要](../gaming/getting-started.md)ページでは、セットアップ、登録、アプリとゲームの申請準備のために必要な作業全体の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="77011-134">The new [Getting started for game development](../gaming/getting-started.md) page gives you a full overview of what you need to do to get yourself set up, registered, and ready to submit your apps and games.</span></span>

## <a name="videos"></a><span data-ttu-id="77011-135">ビデオ</span><span class="sxs-lookup"><span data-stu-id="77011-135">Videos</span></span>

### <a name="xbox-live-creators-program"></a><span data-ttu-id="77011-136">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="77011-136">Xbox Live Creators Program</span></span>

<span data-ttu-id="77011-137">Xbox Live クリエーターズ プログラムでは、開発者が UWP ゲームを Xbox One と Windows 10 に簡単に公開できます。[ビデオ](https://www.youtube.com/watch?v=zpFfHHBkVq4)でプログラムの内容を確認し、[このページ](https://www.xbox.com/developers/creators-program)から開始してください。</span><span class="sxs-lookup"><span data-stu-id="77011-137">The Xbox Live Creators Program allows developers to quickly publish their UWP games to Xbox One and Windows 10.[Watch the video](https://www.youtube.com/watch?v=zpFfHHBkVq4) to learn about the program, then [check out this page](https://www.xbox.com/developers/creators-program) to get started.</span></span>

### <a name="creating-3d-app-launchers-for-windows-mixed-reality"></a><span data-ttu-id="77011-138">Windows Mixed Reality 用 3D アプリ起動ツールの作成</span><span class="sxs-lookup"><span data-stu-id="77011-138">Creating 3D app launchers for Windows Mixed Reality</span></span>

<span data-ttu-id="77011-139">3D 起動ツールとは、Mixed Reality のホーム環境にアプリの立体表現をユーザーが配置できるというユニークなものです。</span><span class="sxs-lookup"><span data-stu-id="77011-139">3D launchers provide a unique way for users to place a truly volumetric representation of your app in their Mixed Reality home environment.</span></span> <span data-ttu-id="77011-140">3D モデルを準備してアプリの起動ツールとして割り当てる方法については、[ビデオをご覧ください](https://www.youtube.com/watch?v=TxIslHsEXno)。詳しくは、[開発者ドキュメント](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_app_launchers)と[設計ガイダンス](https://developer.microsoft.com/windows/mixed-reality/3d_app_launcher_design_guidance)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="77011-140">[Watch the video](https://www.youtube.com/watch?v=TxIslHsEXno) to learn how to prepare your 3D model and assign it as the launcher for your app, then [read the developer docs](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_app_launchers) and [check out our design guidance](https://developer.microsoft.com/windows/mixed-reality/3d_app_launcher_design_guidance) for more information.</span></span>

### <a name="motion-controller-tracking"></a><span data-ttu-id="77011-141">モーション コントローラーの追跡</span><span class="sxs-lookup"><span data-stu-id="77011-141">Motion controller tracking</span></span>

<span data-ttu-id="77011-142">Windows Mixed Reality では、モーション コントローラーがユーザーの手を表します。</span><span class="sxs-lookup"><span data-stu-id="77011-142">Motion controllers represent a user's hands in Windows Mixed Reality.</span></span> <span data-ttu-id="77011-143">モーション コントローラーが Mixed Reality ヘッドセットの視野の内外にあるときの動作については、[ビデオをご覧ください](https://www.youtube.com/watch?v=rkDpRllbLII)。[コントローラーのトラッキングについて詳しくは、こちらをご覧ください。](https://developer.microsoft.com/windows/mixed-reality/motion_controllers#controller_tracking_state%E2%80%9D)</span><span class="sxs-lookup"><span data-stu-id="77011-143">[Watch the video](https://www.youtube.com/watch?v=rkDpRllbLII) to learn how the motion controllers work when they are both in and out of the field of view of the Mixed Reality headset, and [read more about controller tracking here.](https://developer.microsoft.com/windows/mixed-reality/motion_controllers#controller_tracking_state%E2%80%9D)</span></span>