---
description: "UWP アプリにコントロールとパターンを追加する方法についての設計ガイダンスとコーディングの手順を説明します。 アプリで使用できる 45 種類以上の強力なコントロールを紹介します。"
title: "UWP のコントロールとパターン - Windows アプリ開発"
author: mijacobs
keywords: "UWP コントロール, ユーザー インターフェイス, アプリ コントロール"
label: Controls & patterns
template: detail.hbs
ms.author: mijacobs
ms.date: 09/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: ce2e611c-c419-4a14-9095-b88ac711d1b8
ms.openlocfilehash: 0946a32df990f08f00f07ad0094125709b45dcaf
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="controls-and-patterns-for-uwp-apps"></a><span data-ttu-id="9f53c-105">UWP アプリのコントロールとパターン</span><span class="sxs-lookup"><span data-stu-id="9f53c-105">Controls and patterns for UWP apps</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="9f53c-106">UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="9f53c-106">In UWP app development, a <i>control</i> is a UI element that displays content or enables interaction.</span></span> <span data-ttu-id="9f53c-107">コントロールとは、ユーザー インターフェイスの構成要素です。</span><span class="sxs-lookup"><span data-stu-id="9f53c-107">Controls are the building blocks of the user interface.</span></span> <span data-ttu-id="9f53c-108"><i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。</span><span class="sxs-lookup"><span data-stu-id="9f53c-108">A <i>pattern</i> is a recipe for combining several controls to make something new.</span></span>

<span data-ttu-id="9f53c-109">単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="9f53c-109">We provide 45+ controls for you to use, ranging from simple buttons to powerful data controls like the grid view.</span></span>  <span data-ttu-id="9f53c-110">これらのコントロールは Fluent Design System の一部です。すべでのデバイスやあらゆる画面サイズで見栄えがよく、力強い、スケーラブルな UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="9f53c-110">These controls are a part of the Fluent Design System and can help you create a bold, scalable UI that looks great on all devices and screen sizes.</span></span> 

<span data-ttu-id="9f53c-111">このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="9f53c-111">The articles in this section provide design guidance and coding instructions for adding controls & patterns to your UWP app.</span></span> 

## <a name="intro"></a><span data-ttu-id="9f53c-112">はじめに</span><span class="sxs-lookup"><span data-stu-id="9f53c-112">Intro</span></span>

<span data-ttu-id="9f53c-113">XAML と C# でコントロールを追加し、スタイルを指定するための一般的な手順とコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="9f53c-113">General instructions and code examples for adding and styling controls in XAML and C#.</span></span>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>[<span data-ttu-id="9f53c-114">コントロールの追加とイベントの処理</span><span class="sxs-lookup"><span data-stu-id="9f53c-114">Add controls and handle events</span></span>](controls-and-events-intro.md)</b> <br/>
<span data-ttu-id="9f53c-115">アプリにコントロールを追加するには、アプリの UI にコントロールを追加する、コントロールのプロパティを設定する、コントロールを動作させるためのコードをコントロールのイベント ハンドラーに追加するといった、3 つの重要な手順があります。</span><span class="sxs-lookup"><span data-stu-id="9f53c-115">There are 3 key steps to adding controls to your app: Add a control to your app UI, set properties on the control, and add code to the control's event handlers so that it does something.</span></span></li>
</ul> 
</p>
  </div>
  <div class="side-by-side-content-right">
   <p><b>[<span data-ttu-id="9f53c-116">コントロールのスタイル</span><span class="sxs-lookup"><span data-stu-id="9f53c-116">Styling controls</span></span>](styling-controls.md)</b> <br/>
<span data-ttu-id="9f53c-117">XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="9f53c-117">You can customize the appearance of your apps in many ways by using the XAML framework.</span></span> <span data-ttu-id="9f53c-118">スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。</span><span class="sxs-lookup"><span data-stu-id="9f53c-118">Styles let you set control properties and reuse those settings for a consistent appearance across multiple controls.</span></span></p>
  </div>
</div>
</div>

## <a name="alphabetical-index"></a><span data-ttu-id="9f53c-119">アルファベット順インデックス</span><span class="sxs-lookup"><span data-stu-id="9f53c-119">Alphabetical index</span></span> 

<span data-ttu-id="9f53c-120">特定のコントロールとパターンに関する詳細情報を説明します。</span><span class="sxs-lookup"><span data-stu-id="9f53c-120">Detailed information about specific controls and patterns.</span></span> <span data-ttu-id="9f53c-121">(機能別に並べ替えた一覧については、「[機能別コントロールのインデックス](controls-by-function.md)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="9f53c-121">(For a list sorted by function, see [Index of controls by function](controls-by-function.md).)</span></span>

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;" >
<ul style="margin-top: 0px; padding-top: 0px; list-style-type: none;">
<li style="list-style-type: none;">[<span data-ttu-id="9f53c-122">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="9f53c-122">Auto-suggest box</span></span>](auto-suggest-box.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-123">バー</span><span class="sxs-lookup"><span data-stu-id="9f53c-123">Bars</span></span>](app-bars.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-124">ボタン</span><span class="sxs-lookup"><span data-stu-id="9f53c-124">Buttons</span></span>](buttons.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-125">チェックボックス</span><span class="sxs-lookup"><span data-stu-id="9f53c-125">Checkbox</span></span> ](checkbox.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-126">カラー ピッカー</span><span class="sxs-lookup"><span data-stu-id="9f53c-126">Color picker</span></span>](color-picker.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-127">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-127">Date and time controls</span></span>](date-and-time.md)</li>


<li style="list-style-type: none;">[<span data-ttu-id="9f53c-128">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="9f53c-128">Dialogs and flyouts</span></span>](dialogs.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-129">フリップ ビュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-129">Flip view</span></span>](flipview.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-130">ハブ</span><span class="sxs-lookup"><span data-stu-id="9f53c-130">Hub</span></span>](hub.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-131">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="9f53c-131">Hyperlinks</span></span>](hyperlinks.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-132">画像とイメージ ブラシ</span><span class="sxs-lookup"><span data-stu-id="9f53c-132">Images and image brushes</span></span>](images-imagebrushes.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-133">インク コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-133">Inking controls</span></span>](inking-controls.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-134">リスト</span><span class="sxs-lookup"><span data-stu-id="9f53c-134">Lists</span></span>](lists.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-135">マップ コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-135">Map control</span></span>](../maps-and-location/controls-map.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-136">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="9f53c-136">Master/details</span></span>](master-details.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-137">メディア再生</span><span class="sxs-lookup"><span data-stu-id="9f53c-137">Media playback</span></span>](media-playback.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-138">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-138">Menus and context menus</span></span>](menus.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-139">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-139">Nav view</span></span>](navigationview.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-140">ユーザー画像</span><span class="sxs-lookup"><span data-stu-id="9f53c-140">Person picture</span></span>](person-picture.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-141">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-141">Progress controls</span></span>](progress-controls.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-142">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="9f53c-142">Radio button</span></span>](radio-button.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-143">評価コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-143">Rating control</span></span>](rating.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-144">スクロール コントロールとパン コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-144">Scrolling and panning controls</span></span>](scroll-controls.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-145">検索</span><span class="sxs-lookup"><span data-stu-id="9f53c-145">Search</span></span>](search.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-146">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="9f53c-146">Semantic zoom</span></span>](semantic-zoom.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-147">スライダー</span><span class="sxs-lookup"><span data-stu-id="9f53c-147">Slider</span></span>](slider.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-148">分割ビュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-148">Split view</span></span>](split-view.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-149">タブとピボット</span><span class="sxs-lookup"><span data-stu-id="9f53c-149">Tabs and pivots</span></span>](tabs-pivot.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-150">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-150">Text controls</span></span>](text-controls.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-151">タイル、バッジ、および通知</span><span class="sxs-lookup"><span data-stu-id="9f53c-151">Tiles, badges, and notifications</span></span>](tiles-badges-notifications.md)</li>


<li style="list-style-type: none;">[<span data-ttu-id="9f53c-152">トグル</span><span class="sxs-lookup"><span data-stu-id="9f53c-152">Toggle</span></span>](toggles.md)</li>
<li style="list-style-type: none;">[<span data-ttu-id="9f53c-153">ヒント</span><span class="sxs-lookup"><span data-stu-id="9f53c-153">Tooltips</span></span>](tooltips.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-154">ツリー ビュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-154">Tree view</span></span>](tree-view.md)</li>

<li style="list-style-type: none;">[<span data-ttu-id="9f53c-155">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="9f53c-155">Web view</span></span>](web-view.md)</li>
</ul>
</div>

## <a name="additional-controls"></a><span data-ttu-id="9f53c-156">その他のコントロール</span><span class="sxs-lookup"><span data-stu-id="9f53c-156">Additional controls</span></span>

<span data-ttu-id="9f53c-157">UWP 開発用の追加のコントロールは、[Telerik](http://www.telerik.com/)、[SyncFusion](https://www.syncfusion.com/products/uwp)、[DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/)、[Infragistics](http://www.infragistics.com/products/universal-windows-platform)、[ComponentOne](https://www.componentone.com/Studio/Platform/UWP)、[ActiPro](http://www.actiprosoftware.com/products/controls/universal) などの企業から入手できます。</span><span class="sxs-lookup"><span data-stu-id="9f53c-157">Additional controls for UWP development are available from companies such as [Telerik](http://www.telerik.com/), [SyncFusion](https://www.syncfusion.com/products/uwp), [DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/), [Infragistics](http://www.infragistics.com/products/universal-windows-platform), [ComponentOne](https://www.componentone.com/Studio/Platform/UWP), and [ActiPro](http://www.actiprosoftware.com/products/controls/universal).</span></span> <span data-ttu-id="9f53c-158">これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="9f53c-158">These controls provide additional support for enterprise and .NET developers by augmenting the standard system controls with custom controls and services.</span></span>  

<span data-ttu-id="9f53c-159">これらのコントロールの詳しい情報については、GitHub の[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database) サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9f53c-159">If you're interested in learning more about these controls, check out the [Customer orders database](https://github.com/Microsoft/Windows-appsample-customers-orders-database) sample on GitHub.</span></span> <span data-ttu-id="9f53c-160">このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。</span><span class="sxs-lookup"><span data-stu-id="9f53c-160">This sample makes use of the data grid control and data entry validation from Telerik, which is part of their UI for UWP suite.</span></span> <span data-ttu-id="9f53c-161">UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="9f53c-161">The UI for UWP suite is a collection of over 20 controls that is available as an open source project through the .NET foundation.</span></span>
