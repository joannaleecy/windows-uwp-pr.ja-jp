---
description: UWP アプリにコントロールとパターンを追加する方法についての設計ガイダンスとコーディングの手順を説明します。 アプリで使用できる 45 種類以上の強力なコントロールを紹介します。
title: UWP のコントロールとパターン - Windows アプリ開発
author: mijacobs
keywords: UWP コントロール, ユーザー インターフェイス, アプリ コントロール
label: Controls & patterns
template: detail.hbs
ms.author: mijacobs
ms.date: 11/16/2017
ms.topic: article
ms.assetid: ce2e611c-c419-4a14-9095-b88ac711d1b8
ms.localizationpriority: medium
ms.openlocfilehash: e28d557280ab253a09d5697f369c694e490d3c7d
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7284367"
---
# <a name="controls-and-patterns-for-uwp-apps"></a><span data-ttu-id="1ceb5-105">UWP アプリのコントロールとパターン</span><span class="sxs-lookup"><span data-stu-id="1ceb5-105">Controls and patterns for UWP apps</span></span>
 

<span data-ttu-id="1ceb5-106">UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-106">In UWP app development, a <i>control</i> is a UI element that displays content or enables interaction.</span></span> <span data-ttu-id="1ceb5-107">コントロールとは、ユーザー インターフェイスの構成要素です。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-107">Controls are the building blocks of the user interface.</span></span> <span data-ttu-id="1ceb5-108"><i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-108">A <i>pattern</i> is a recipe for combining several controls to make something new.</span></span>

<span data-ttu-id="1ceb5-109">単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-109">We provide 45+ controls for you to use, ranging from simple buttons to powerful data controls like the grid view.</span></span>  <span data-ttu-id="1ceb5-110">これらのコントロールは Fluent Design System の一部です。すべでのデバイスやあらゆる画面サイズで見栄えがよく、力強い、スケーラブルな UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-110">These controls are a part of the Fluent Design System and can help you create a bold, scalable UI that looks great on all devices and screen sizes.</span></span> 

<span data-ttu-id="1ceb5-111">このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-111">The articles in this section provide design guidance and coding instructions for adding controls & patterns to your UWP app.</span></span> 

## <a name="intro"></a><span data-ttu-id="1ceb5-112">はじめに</span><span class="sxs-lookup"><span data-stu-id="1ceb5-112">Intro</span></span>

<span data-ttu-id="1ceb5-113">XAML と C# でコントロールを追加し、スタイルを指定するための一般的な手順とコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-113">General instructions and code examples for adding and styling controls in XAML and C#.</span></span>

:::row:::
    :::column:::
      <p><b><a href="controls-and-events-intro.md"><span data-ttu-id="1ceb5-114">コントロールの追加とイベントの処理</span><span class="sxs-lookup"><span data-stu-id="1ceb5-114">Add controls and handle events</span></span></a></b> <br/>
<span data-ttu-id="1ceb5-115">アプリにコントロールを追加するには、アプリの UI にコントロールを追加する、コントロールのプロパティを設定する、コントロールを動作させるためのコードをコントロールのイベント ハンドラーに追加するといった、3 つの重要な手順があります。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-115">There are 3 key steps to adding controls to your app: Add a control to your app UI, set properties on the control, and add code to the control's event handlers so that it does something.</span></span></p>
    :::column-end:::
    :::column:::
      <p><b><a href="xaml-styles.md"><span data-ttu-id="1ceb5-116">コントロールのスタイル</span><span class="sxs-lookup"><span data-stu-id="1ceb5-116">Styling controls</span></span></a></b> <br/>
<span data-ttu-id="1ceb5-117">XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-117">You can customize the appearance of your apps in many ways by using the XAML framework.</span></span> <span data-ttu-id="1ceb5-118">スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-118">Styles let you set control properties and reuse those settings for a consistent appearance across multiple controls.</span></span></p>
    :::column-end:::
:::row-end:::

## <a name="get-the-windows-ui-library"></a><span data-ttu-id="1ceb5-119">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-119">Get the Windows UI Library</span></span>
<span data-ttu-id="1ceb5-120">一部のコントロールは、Windows UI のライブラリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-120">Some controls are only available in the Windows UI Library.</span></span> <span data-ttu-id="1ceb5-121">それを取得するのには、 [Windows UI のライブラリの概要とインストールの手順](/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-121">To get it, see the [Windows UI Library overview and installation instructions](/uwp/toolkits/winui/).</span></span>

## <a name="alphabetical-index"></a><span data-ttu-id="1ceb5-122">アルファベット順インデックス</span><span class="sxs-lookup"><span data-stu-id="1ceb5-122">Alphabetical index</span></span> 

<span data-ttu-id="1ceb5-123">特定のコントロールとパターンに関する詳細情報を説明します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-123">Detailed information about specific controls and patterns.</span></span> <span data-ttu-id="1ceb5-124">(機能別に並べ替えた一覧については、「<a href="controls-by-function.md">機能別コントロールのインデックス</a>」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="1ceb5-124">(For a list sorted by function, see <a href="controls-by-function.md">Index of controls by function</a>.)</span></span>

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;" >
<ul style="margin-top: 0px; padding-top: 0px; list-style-type: none;">
<li style="list-style-type: none;"><a href="auto-suggest-box.md"><span data-ttu-id="1ceb5-125">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="1ceb5-125">Auto-suggest box</span></span></a></li>

<li style="list-style-type: none;"><a href="app-bars.md"><span data-ttu-id="1ceb5-126">バー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-126">Bars</span></span></a></li>

<li style="list-style-type: none;"><a href="buttons.md"><span data-ttu-id="1ceb5-127">ボタン</span><span class="sxs-lookup"><span data-stu-id="1ceb5-127">Buttons</span></span></a></li>

<li style="list-style-type: none;"><a href="checkbox.md"><span data-ttu-id="1ceb5-128">チェックボックス</span><span class="sxs-lookup"><span data-stu-id="1ceb5-128">Checkbox</span></span> </a></li>

<li style="list-style-type: none;"><a href="color-picker.md"><span data-ttu-id="1ceb5-129">カラー ピッカー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-129">Color picker</span></span></a></li>

<li style="list-style-type: none;"><a href="contact-card.md"><span data-ttu-id="1ceb5-130">連絡先カード</span><span class="sxs-lookup"><span data-stu-id="1ceb5-130">Contact card</span></span></a></li>

<li style="list-style-type: none;"><a href="date-and-time.md"><span data-ttu-id="1ceb5-131">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-131">Date and time controls</span></span></a></li>

<li style="list-style-type: none;"><a href="dialogs-and-flyouts/index.md"><span data-ttu-id="1ceb5-132">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="1ceb5-132">Dialogs and flyouts</span></span></a></li>

<li style="list-style-type: none;"><a href="flipview.md"><span data-ttu-id="1ceb5-133">フリップ ビュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-133">Flip view</span></span></a></li>

<li style="list-style-type: none;"><a href="forms.md"><span data-ttu-id="1ceb5-134">フォーム</span><span class="sxs-lookup"><span data-stu-id="1ceb5-134">Forms</span></span></a></li>

<li style="list-style-type: none;"><a href="hub.md"><span data-ttu-id="1ceb5-135">Hub</span><span class="sxs-lookup"><span data-stu-id="1ceb5-135">Hub</span></span></a></li>

<li style="list-style-type: none;"><a href="hyperlinks.md"><span data-ttu-id="1ceb5-136">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="1ceb5-136">Hyperlinks</span></span></a></li>

<li style="list-style-type: none;"><a href="images-imagebrushes.md"><span data-ttu-id="1ceb5-137">画像とイメージ ブラシ</span><span class="sxs-lookup"><span data-stu-id="1ceb5-137">Images and image brushes</span></span></a></li>

<li style="list-style-type: none;"><a href="inking-controls.md"><span data-ttu-id="1ceb5-138">インク コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-138">Inking controls</span></span></a></li>

<li style="list-style-type: none;"><a href="lists.md"><span data-ttu-id="1ceb5-139">リスト</span><span class="sxs-lookup"><span data-stu-id="1ceb5-139">Lists</span></span></a></li>

<li style="list-style-type: none;"><a href="../../maps-and-location/controls-map.md"><span data-ttu-id="1ceb5-140">マップ コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-140">Map control</span></span></a></li>

<li style="list-style-type: none;"><a href="master-details.md"><span data-ttu-id="1ceb5-141">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="1ceb5-141">Master/details</span></span></a></li>

<li style="list-style-type: none;"><a href="media-playback.md"><span data-ttu-id="1ceb5-142">メディア再生</span><span class="sxs-lookup"><span data-stu-id="1ceb5-142">Media playback</span></span></a></li>

<li style="list-style-type: none;"><a href="menus.md"><span data-ttu-id="1ceb5-143">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-143">Menus and context menus</span></span></a></li>

<li style="list-style-type: none;"><a href="navigationview.md"><span data-ttu-id="1ceb5-144">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-144">Navigation view</span></span></a></li>

<li style="list-style-type: none;"><a href="person-picture.md"><span data-ttu-id="1ceb5-145">ユーザー画像</span><span class="sxs-lookup"><span data-stu-id="1ceb5-145">Person picture</span></span></a></li>

<li style="list-style-type: none;"><a href="pivot.md"><span data-ttu-id="1ceb5-146">ピボット</span><span class="sxs-lookup"><span data-stu-id="1ceb5-146">Pivot</span></span></a></li>

<li style="list-style-type: none;"><a href="progress-controls.md"><span data-ttu-id="1ceb5-147">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-147">Progress controls</span></span></a></li>

<li style="list-style-type: none;"><a href="radio-button.md"><span data-ttu-id="1ceb5-148">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="1ceb5-148">Radio button</span></span></a></li>

<li style="list-style-type: none;"><a href="rating.md"><span data-ttu-id="1ceb5-149">評価コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-149">Rating control</span></span></a></li>

<li style="list-style-type: none;"><a href="scroll-controls.md"><span data-ttu-id="1ceb5-150">スクロール コントロールとパン コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-150">Scrolling and panning controls</span></span></a></li>

<li style="list-style-type: none;"><a href="search.md"><span data-ttu-id="1ceb5-151">検索</span><span class="sxs-lookup"><span data-stu-id="1ceb5-151">Search</span></span></a></li>

<li style="list-style-type: none;"><a href="semantic-zoom.md"><span data-ttu-id="1ceb5-152">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="1ceb5-152">Semantic zoom</span></span></a></li>

<li style="list-style-type: none;"><a href="shapes.md"><span data-ttu-id="1ceb5-153">図形</span><span class="sxs-lookup"><span data-stu-id="1ceb5-153">Shapes</span></span></a></li>

<li style="list-style-type: none;"><a href="slider.md"><span data-ttu-id="1ceb5-154">Slider</span><span class="sxs-lookup"><span data-stu-id="1ceb5-154">Slider</span></span></a></li>

<li style="list-style-type: none;"><a href="split-view.md"><span data-ttu-id="1ceb5-155">分割ビュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-155">Split view</span></span></a></li>

<li style="list-style-type: none;"><a href="text-controls.md"><span data-ttu-id="1ceb5-156">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-156">Text controls</span></span></a></li>


<li style="list-style-type: none;"><a href="toggles.md"><span data-ttu-id="1ceb5-157">トグル</span><span class="sxs-lookup"><span data-stu-id="1ceb5-157">Toggle</span></span></a></li>
<li style="list-style-type: none;"><a href="tooltips.md"><span data-ttu-id="1ceb5-158">ヒント</span><span class="sxs-lookup"><span data-stu-id="1ceb5-158">Tooltips</span></span></a></li>

<li style="list-style-type: none;"><a href="tree-view.md"><span data-ttu-id="1ceb5-159">ツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-159">Tree view</span></span></a></li>

<li style="list-style-type: none;"><a href="web-view.md"><span data-ttu-id="1ceb5-160">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-160">Web view</span></span></a></li>
</ul>
</div>

## <a name="xaml-controls-gallery"></a><span data-ttu-id="1ceb5-161">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="1ceb5-161">XAML Controls Gallery</span></span>

<span data-ttu-id="1ceb5-162">Microsoft Store から _XAML コントロール ギャラリー_ アプリを入手し、これらのコントロールおよび Fluent Design System の動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-162">Get the _XAML Controls Gallery_ app from the Microsoft Store to see these controls and the Fluent Design System in action.</span></span> <span data-ttu-id="1ceb5-163">このアプリは、この Web サイトの対話型コンパニオンです。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-163">The app is an interactive companion to this website.</span></span> <span data-ttu-id="1ceb5-164">このアプリがインストールされている場合、個々のコントロール ページのリンクを使用して、アプリを起動し、コントロールの動作を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-164">When you have it installed, you can use links on individual control pages to launch the app and see the control in action.</span></span>

<a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="1ceb5-165">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="1ceb5-165">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a>

<a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="1ceb5-166">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="1ceb5-166">Get the source code (GitHub)</span></span></a>

<img src="images/xaml-controls-gallery.png" alt="XAML Controls Gallery screen" />

## <a name="additional-controls"></a><span data-ttu-id="1ceb5-167">その他のコントロール</span><span class="sxs-lookup"><span data-stu-id="1ceb5-167">Additional controls</span></span>

<span data-ttu-id="1ceb5-168">UWP 開発用の追加のコントロールは、<a href="http://www.telerik.com/">Telerik</a>、<a href="https://www.syncfusion.com/products/uwp">SyncFusion</a>、<a href="https://www.devexpress.com/Products/NET/Controls/Win10Apps/">DevExpress</a>、<a href="http://www.infragistics.com/products/universal-windows-platform">Infragistics</a>、<a href="https://www.componentone.com/Studio/Platform/UWP">ComponentOne</a>、<a href="http://www.actiprosoftware.com/products/controls/universal">ActiPro</a> などの企業から入手できます。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-168">Additional controls for UWP development are available from companies such as <a href="http://www.telerik.com/">Telerik</a>, <a href="https://www.syncfusion.com/products/uwp">SyncFusion</a>, <a href="https://www.devexpress.com/Products/NET/Controls/Win10Apps/">DevExpress</a>, <a href="http://www.infragistics.com/products/universal-windows-platform">Infragistics</a>, <a href="https://www.componentone.com/Studio/Platform/UWP">ComponentOne</a>, and <a href="http://www.actiprosoftware.com/products/controls/universal">ActiPro</a>.</span></span> <span data-ttu-id="1ceb5-169">これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-169">These controls provide additional support for enterprise and .NET developers by augmenting the standard system controls with custom controls and services.</span></span>  

<span data-ttu-id="1ceb5-170">これらのコントロールの詳しい情報については、GitHub の<a href="https://github.com/Microsoft/Windows-appsample-customers-orders-database">顧客注文データベース</a> サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-170">If you're interested in learning more about these controls, check out the <a href="https://github.com/Microsoft/Windows-appsample-customers-orders-database">Customer orders database</a> sample on GitHub.</span></span> <span data-ttu-id="1ceb5-171">このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-171">This sample makes use of the data grid control and data entry validation from Telerik, which is part of their UI for UWP suite.</span></span> <span data-ttu-id="1ceb5-172">UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="1ceb5-172">The UI for UWP suite is a collection of over 20 controls that is available as an open source project through the .NET foundation.</span></span>
