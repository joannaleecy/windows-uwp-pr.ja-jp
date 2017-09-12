---
description: "さまざまなデバイスや画面サイズで、ナビゲーションがわかりやすく見た目にも優れた UWP アプリを設計およびコーディングする方法について説明します。"
title: "UWP アプリのレイアウトの設計 - Windows アプリ開発"
author: mijacobs
keywords: "UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス"
label: Layout
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: 1aa12606-8a99-4db3-8311-90e02fde9cf1
ms.openlocfilehash: 4c1b4617b3b58cb613bcca8d5df456621af730fa
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="layout-for-uwp-apps"></a><span data-ttu-id="551ec-104">UWP アプリのレイアウト</span><span class="sxs-lookup"><span data-stu-id="551ec-104">Layout for UWP apps</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="551ec-105">アプリの構造、ページ レイアウト、ナビゲーションは、アプリのユーザー エクスペリエンスの基盤となるものです。</span><span class="sxs-lookup"><span data-stu-id="551ec-105">App structure, page layout, and navigation are the foundation of your app's user experience.</span></span> <span data-ttu-id="551ec-106">このセクションの記事は、Fluent Design System を使って、さまざまなデバイスや画面サイズで簡単に操作でき、適切に表示されるアプリを作成する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="551ec-106">The articles in this section use the Fluent Design System to help you create an app that is easy to navigate and looks great on a variety of devices and screen sizes.</span></span>

## <a name="intro"></a><span data-ttu-id="551ec-107">はじめに</span><span class="sxs-lookup"><span data-stu-id="551ec-107">Intro</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  <p><b>[<span data-ttu-id="551ec-108">アプリの UI 設計の概要</span><span class="sxs-lookup"><span data-stu-id="551ec-108">Intro to app UI design</span></span>](design-and-ui-intro.md)</b><br />
<span data-ttu-id="551ec-109">UWP アプリを設計する場合、さまざまなディスプレイ サイズを持つさまざまなデバイスに合ったユーザー インターフェイスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="551ec-109">When you design a UWP app, you create a user interface that suits a variety of devices with different display sizes.</span></span> <span data-ttu-id="551ec-110">この記事では、Fluent Design System の概要、UWP アプリの UI に関連する機能や利点の概要と、応答性の高い UI を設計するためのヒントやコツを示します。</span><span class="sxs-lookup"><span data-stu-id="551ec-110">This article provides an introduction to the Fluent Design System, an overview of UI-related features and benefits of UWP apps and some tips & tricks for designing a responsive UI.</span></span> </p>
  </div>
  <div class="side-by-side-content-right">
    ![複数のデバイスで実行されるアプリ](images/rspd-reposition-type1-sm.png)
  </div>
</div>
</div>

## <a name="app-layout-and-structure"></a><span data-ttu-id="551ec-112">アプリのレイアウトと構造</span><span class="sxs-lookup"><span data-stu-id="551ec-112">App layout and structure</span></span>
<span data-ttu-id="551ec-113">アプリを構築し、ナビゲーション、コマンド、コンテンツという 3 種類の UI 要素を使うには、次の推奨事項を確認してください。</span><span class="sxs-lookup"><span data-stu-id="551ec-113">Check out these recommendations for structuring your app and using the three types of UI elements: navigation, command, and content.</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p>
<b>[<span data-ttu-id="551ec-114">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="551ec-114">Navigation basics</span></span>](navigation-basics.md)</b><br/>
<span data-ttu-id="551ec-115">UWP アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。</span><span class="sxs-lookup"><span data-stu-id="551ec-115">Navigation in UWP apps is based on a flexible model of navigation structures, navigation elements, and system-level features.</span></span> <span data-ttu-id="551ec-116">この記事では、これらの構成要素を紹介します。また、これらの構成要素を組み合わせて使い、優れたナビゲーション エクスペリエンスを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="551ec-116">This article introduces you to these components and shows you how to use them together to create a good navigation experience.</span></span>
</p>
<p>
<b>[<span data-ttu-id="551ec-117">コンテンツの基本</span><span class="sxs-lookup"><span data-stu-id="551ec-117">Content basics</span></span>](content-basics.md)</b><br/>
<span data-ttu-id="551ec-118">どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="551ec-118">The main purpose of any app is to provide access to content: in a photo-editing app, the photo is the content; in a travel app, maps and info about travel destinations is the content; and so on.</span></span> <span data-ttu-id="551ec-119">この記事では、3 つのコンテンツ シナリオ (使用、作成、対話式操作) でのコンテンツの設計に関する推奨事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="551ec-119">This article provides content design recommendations for the three content scenarios: consumption, creation, and interaction.</span></span>
</p> 
  </div>
  <div class="side-by-side-content-right">
<p><b>[<span data-ttu-id="551ec-120">コマンドの基本</span><span class="sxs-lookup"><span data-stu-id="551ec-120">Command basics</span></span>](commanding-basics.md)</b> <br />
<span data-ttu-id="551ec-121">コマンド要素は、ユーザーがメール送信、項目の削除、フォームの送信などの操作を実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="551ec-121">Command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> <span data-ttu-id="551ec-122">この記事では、ボタンやチェック ボックスなどのコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするコマンド サーフェス (コマンド バーやショートカット メニューなど) について説明します。</span><span class="sxs-lookup"><span data-stu-id="551ec-122">This article describes the command elements, such as buttons and check boxes, the interactions they support, and the command surfaces (such as command bars and context menus) for hosting them.</span></span></p>
  </div>
</div>
</div>

## <a name="page-layout"></a><span data-ttu-id="551ec-123">ページのレイアウト</span><span class="sxs-lookup"><span data-stu-id="551ec-123">Page layout</span></span> 
<span data-ttu-id="551ec-124">次の記事は、さまざまな画面サイズ、ウィンドウ サイズ、解像度、向きで適切に表示される柔軟な UI を作成する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="551ec-124">These articles help you create a flexible UI that looks great on different screen sizes, window sizes, resolutions, and orientations.</span></span> 

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;">

<div style="-webkit-column-break-inside: avoid; page-break-inside: avoid; break-inside: avoid;">
<p style="margin-top: 0px; padding-top: 0px;"><b>[<span data-ttu-id="551ec-125">画面のサイズとブレークポイント</span><span class="sxs-lookup"><span data-stu-id="551ec-125">Screen sizes and breakpoints</span></span>](screen-sizes-and-breakpoints-for-responsive-design.md)</b><br/>
<span data-ttu-id="551ec-126">対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。</span><span class="sxs-lookup"><span data-stu-id="551ec-126">The number of device targets and screen sizes across the Windows 10 ecosystem is too great to worry about optimizing your UI for each one.</span></span> <span data-ttu-id="551ec-127">その代わり、360、640、1024、および 1366 epx という 4 種類の主要なキー幅 ("ブレークポイント" とも呼ばれます) を設計することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="551ec-127">Instead, we recommended designing for a few key widths (also called "breakpoints"): 360, 640, 1024 and 1366 epx.</span></span></p>
</div>

<div style="-webkit-column-break-inside: avoid; page-break-inside: avoid; break-inside: avoid;">
  <p><b>[<span data-ttu-id="551ec-128">XAML を使ったレイアウトの定義</span><span class="sxs-lookup"><span data-stu-id="551ec-128">Define layouts with XAML</span></span>](layouts-with-xaml.md)</b> <br/>
<span data-ttu-id="551ec-129">XAML プロパティとレイアウト パネルを使って、アプリの応答性と適応性を高める方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="551ec-129">How to use XAML properties and layout panels to make your app responsive and adaptive.</span></span></p>
</div>
<div style="-webkit-column-break-inside: avoid; page-break-inside: avoid; break-inside: avoid;">
   <p><b>[<span data-ttu-id="551ec-130">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="551ec-130">Layout panels</span></span>](layout-panels.md)</b> <br />
<span data-ttu-id="551ec-131">各レイアウト パネルの種類を説明し、パネルを使って XAML UI 要素をレイアウトする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="551ec-131">Learn about each type of layout each panel and show how to use them to layout XAML UI elements.</span></span></p> 
</div>
<div style="-webkit-column-break-inside: avoid; page-break-inside: avoid; break-inside: avoid;">
 <p><b>[<span data-ttu-id="551ec-132">配置、余白、パディング</span><span class="sxs-lookup"><span data-stu-id="551ec-132">Alignment, margins, and padding</span></span>](alignment-margin-padding.md)</b> <br />
<span data-ttu-id="551ec-133">サイズのプロパティ (幅、高さ、および制約) に加え、要素は、配置、余白、パディングのプロパティも含むことができ、これらは、要素がレイアウト パスに移動し、UI に表示されるときにレイアウト動作に影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="551ec-133">In addition to dimension properties (width, height, and constraints) elements can also have alignment, margin, and padding properties that influence the layout behavior when an element goes through a layout pass and is rendered in a UI.</span></span></p> 
</div>
<div style="-webkit-column-break-inside: avoid; page-break-inside: avoid; break-inside: avoid;">
 <p><b>[<span data-ttu-id="551ec-134">Grid と StackPanel を使ったレイアウトを作成する</span><span class="sxs-lookup"><span data-stu-id="551ec-134">Create layouts with Grid and StackPanel</span></span>](grid-tutorial.md)</b> <br />
<span data-ttu-id="551ec-135">ここでは、XAML の Grid 要素と StackPanel 要素を使って単純な天気予報アプリのレイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="551ec-135">Use XAML to create the layout for a simple weather app using the Grid and StackPanel elements.</span></span> </p> 
</div>

</div>



