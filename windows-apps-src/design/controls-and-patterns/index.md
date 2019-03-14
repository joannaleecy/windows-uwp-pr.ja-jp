---
description: UWP アプリにコントロールとパターンを追加する方法についての設計ガイダンスとコーディングの手順を説明します。 アプリで使用できる 45 種類以上の強力なコントロールを紹介します。
title: UWP のコントロールとパターン - Windows アプリ開発
keywords: 'UWP コントロール, ユーザー インターフェイス, アプリ コントロール'
label: Controls & patterns
template: detail.hbs
ms.date: 11/16/2017
ms.topic: article
ms.assetid: ce2e611c-c419-4a14-9095-b88ac711d1b8
ms.localizationpriority: medium
---
# <a name="controls-and-patterns-for-uwp-apps"></a><span data-ttu-id="134a0-105">UWP アプリのコントロールとパターン</span><span class="sxs-lookup"><span data-stu-id="134a0-105">Controls and patterns for UWP apps</span></span>
 

<span data-ttu-id="134a0-106">UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="134a0-106">In UWP app development, a <i>control</i> is a UI element that displays content or enables interaction.</span></span> <span data-ttu-id="134a0-107">コントロールとは、ユーザー インターフェイスの構成要素です。</span><span class="sxs-lookup"><span data-stu-id="134a0-107">Controls are the building blocks of the user interface.</span></span> <span data-ttu-id="134a0-108"><i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。</span><span class="sxs-lookup"><span data-stu-id="134a0-108">A <i>pattern</i> is a recipe for combining several controls to make something new.</span></span>

<span data-ttu-id="134a0-109">単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="134a0-109">We provide 45+ controls for you to use, ranging from simple buttons to powerful data controls like the grid view.</span></span>  <span data-ttu-id="134a0-110">これらのコントロールは Fluent Design System の一部です。すべでのデバイスやあらゆる画面サイズで見栄えがよく、力強い、スケーラブルな UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="134a0-110">These controls are a part of the Fluent Design System and can help you create a bold, scalable UI that looks great on all devices and screen sizes.</span></span> 

<span data-ttu-id="134a0-111">このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を示します。</span><span class="sxs-lookup"><span data-stu-id="134a0-111">The articles in this section provide design guidance and coding instructions for adding controls & patterns to your UWP app.</span></span> 

## <a name="intro"></a><span data-ttu-id="134a0-112">はじめに</span><span class="sxs-lookup"><span data-stu-id="134a0-112">Intro</span></span>

<span data-ttu-id="134a0-113">XAML と C# でコントロールを追加し、スタイルを指定するための一般的な手順とコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="134a0-113">General instructions and code examples for adding and styling controls in XAML and C#.</span></span>

:::row:::
    :::column:::
      <p><span data-ttu-id="134a0-114"><b><a href="controls-and-events-intro.md">コントロールを追加し、イベントを処理する</a></b> </span><span class="sxs-lookup"><span data-stu-id="134a0-114"><b><a href="controls-and-events-intro.md">Add controls and handle events</a></b> </span></span><br/>
<span data-ttu-id="134a0-115">アプリにコントロールを追加するには、3 つの重要な手順があります。アプリの UI にコントロールを追加し、コントロールのプロパティを設定し、コントロールを動作させるためのコードをコントロールのイベント ハンドラーに追加します。</span><span class="sxs-lookup"><span data-stu-id="134a0-115">There are 3 key steps to adding controls to your app: Add a control to your app UI, set properties on the control, and add code to the control's event handlers so that it does something.</span></span></p>
    :::column-end:::
    :::column:::
      <p><span data-ttu-id="134a0-116"><b><a href="xaml-styles.md">コントロールのスタイル指定</a></b> </span><span class="sxs-lookup"><span data-stu-id="134a0-116"><b><a href="xaml-styles.md">Styling controls</a></b> </span></span><br/>
<span data-ttu-id="134a0-117">XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="134a0-117">You can customize the appearance of your apps in many ways by using the XAML framework.</span></span> <span data-ttu-id="134a0-118">スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。</span><span class="sxs-lookup"><span data-stu-id="134a0-118">Styles let you set control properties and reuse those settings for a consistent appearance across multiple controls.</span></span></p>
    :::column-end:::
:::row-end:::

## <a name="get-the-windows-ui-library"></a><span data-ttu-id="134a0-119">Windows UI ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="134a0-119">Get the Windows UI Library</span></span>
<span data-ttu-id="134a0-120">一部のコントロールは、Windows UI ライブラリでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="134a0-120">Some controls are only available in the Windows UI Library.</span></span> <span data-ttu-id="134a0-121">これを入手する場合は、[Windows UI ライブラリの概要とインストール手順](/uwp/toolkits/winui/)に関するページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="134a0-121">To get it, see the [Windows UI Library overview and installation instructions](/uwp/toolkits/winui/).</span></span>

## <a name="alphabetical-index"></a><span data-ttu-id="134a0-122">アルファベット順インデックス</span><span class="sxs-lookup"><span data-stu-id="134a0-122">Alphabetical index</span></span> 

<span data-ttu-id="134a0-123">特定のコントロールとパターンに関する詳細情報を説明します。</span><span class="sxs-lookup"><span data-stu-id="134a0-123">Detailed information about specific controls and patterns.</span></span> <span data-ttu-id="134a0-124">(機能別に並べ替えた一覧については、「<a href="controls-by-function.md">機能別コントロールのインデックス</a>」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="134a0-124">(For a list sorted by function, see <a href="controls-by-function.md">Index of controls by function</a>.)</span></span>

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;" >
<ul style="margin-top: 0px; padding-top: 0px; list-style-type: none;">
<li style="list-style-type: none;"><span data-ttu-id="134a0-125"><a href="auto-suggest-box.md">自動提案ボックス</a></span><span class="sxs-lookup"><span data-stu-id="134a0-125"><a href="auto-suggest-box.md">Auto-suggest box</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-126"><a href="app-bars.md">バー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-126"><a href="app-bars.md">Bars</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-127"><a href="buttons.md">ボタン</a></span><span class="sxs-lookup"><span data-stu-id="134a0-127"><a href="buttons.md">Buttons</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-128"><a href="checkbox.md">チェックボックス</a></span><span class="sxs-lookup"><span data-stu-id="134a0-128"><a href="checkbox.md">Checkbox </a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-129"><a href="color-picker.md">カラー ピッカー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-129"><a href="color-picker.md">Color picker</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-130"><a href="contact-card.md">連絡先カード</a></span><span class="sxs-lookup"><span data-stu-id="134a0-130"><a href="contact-card.md">Contact card</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-131"><a href="date-and-time.md">日付と時刻コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-131"><a href="date-and-time.md">Date and time controls</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-132"><a href="dialogs-and-flyouts/index.md">ダイアログとポップアップ</a></span><span class="sxs-lookup"><span data-stu-id="134a0-132"><a href="dialogs-and-flyouts/index.md">Dialogs and flyouts</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-133"><a href="flipview.md">FlipView</a></span><span class="sxs-lookup"><span data-stu-id="134a0-133"><a href="flipview.md">Flip view</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-134"><a href="forms.md">フォーム</a></span><span class="sxs-lookup"><span data-stu-id="134a0-134"><a href="forms.md">Forms</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-135"><a href="hyperlinks.md">ハイパーリンク</a></span><span class="sxs-lookup"><span data-stu-id="134a0-135"><a href="hyperlinks.md">Hyperlinks</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-136"><a href="images-imagebrushes.md">画像とイメージ ブラシ</a></span><span class="sxs-lookup"><span data-stu-id="134a0-136"><a href="images-imagebrushes.md">Images and image brushes</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-137"><a href="inking-controls.md">インク コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-137"><a href="inking-controls.md">Inking controls</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-138"><a href="lists.md">リスト</a></span><span class="sxs-lookup"><span data-stu-id="134a0-138"><a href="lists.md">Lists</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-139"><a href="../../maps-and-location/controls-map.md">マップ コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-139"><a href="../../maps-and-location/controls-map.md">Map control</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-140"><a href="master-details.md">マスター/詳細</a></span><span class="sxs-lookup"><span data-stu-id="134a0-140"><a href="master-details.md">Master/details</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-141"><a href="media-playback.md">メディア再生</a></span><span class="sxs-lookup"><span data-stu-id="134a0-141"><a href="media-playback.md">Media playback</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-142"><a href="menus.md">メニューとショートカット メニュー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-142"><a href="menus.md">Menus and context menus</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-143"><a href="navigationview.md">ナビゲーション ビュー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-143"><a href="navigationview.md">Navigation view</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-144"><a href="person-picture.md">ユーザー画像</a></span><span class="sxs-lookup"><span data-stu-id="134a0-144"><a href="person-picture.md">Person picture</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-145"><a href="pivot.md">ピボット</a></span><span class="sxs-lookup"><span data-stu-id="134a0-145"><a href="pivot.md">Pivot</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-146"><a href="progress-controls.md">プログレス コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-146"><a href="progress-controls.md">Progress controls</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-147"><a href="radio-button.md">ラジオ ボタン</a></span><span class="sxs-lookup"><span data-stu-id="134a0-147"><a href="radio-button.md">Radio button</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-148"><a href="rating.md">評価コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-148"><a href="rating.md">Rating control</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-149"><a href="scroll-controls.md">スクロール コントロールとパン コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-149"><a href="scroll-controls.md">Scrolling and panning controls</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-150"><a href="search.md">検索</a></span><span class="sxs-lookup"><span data-stu-id="134a0-150"><a href="search.md">Search</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-151"><a href="semantic-zoom.md">セマンティック ズーム</a></span><span class="sxs-lookup"><span data-stu-id="134a0-151"><a href="semantic-zoom.md">Semantic zoom</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-152"><a href="shapes.md">図形</a></span><span class="sxs-lookup"><span data-stu-id="134a0-152"><a href="shapes.md">Shapes</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-153"><a href="slider.md">スライダー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-153"><a href="slider.md">Slider</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-154"><a href="split-view.md">分割ビュー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-154"><a href="split-view.md">Split view</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-155"><a href="text-controls.md">テキスト コントロール</a></span><span class="sxs-lookup"><span data-stu-id="134a0-155"><a href="text-controls.md">Text controls</a></span></span></li>


<li style="list-style-type: none;"><span data-ttu-id="134a0-156"><a href="toggles.md">トグル</a></span><span class="sxs-lookup"><span data-stu-id="134a0-156"><a href="toggles.md">Toggle</a></span></span></li>
<li style="list-style-type: none;"><span data-ttu-id="134a0-157"><a href="tooltips.md">ヒント</a></span><span class="sxs-lookup"><span data-stu-id="134a0-157"><a href="tooltips.md">Tooltips</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-158"><a href="tree-view.md">ツリー ビュー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-158"><a href="tree-view.md">Tree view</a></span></span></li>

<li style="list-style-type: none;"><span data-ttu-id="134a0-159"><a href="web-view.md">Web ビュー</a></span><span class="sxs-lookup"><span data-stu-id="134a0-159"><a href="web-view.md">Web view</a></span></span></li>
</ul>
</div>

## <a name="xaml-controls-gallery"></a><span data-ttu-id="134a0-160">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="134a0-160">XAML Controls Gallery</span></span>

<span data-ttu-id="134a0-161">Microsoft Store から _XAML コントロール ギャラリー_ アプリを入手し、これらのコントロールおよび Fluent Design System の動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="134a0-161">Get the _XAML Controls Gallery_ app from the Microsoft Store to see these controls and the Fluent Design System in action.</span></span> <span data-ttu-id="134a0-162">このアプリは、この Web サイトの対話型コンパニオンです。</span><span class="sxs-lookup"><span data-stu-id="134a0-162">The app is an interactive companion to this website.</span></span> <span data-ttu-id="134a0-163">このアプリがインストールされている場合、個々のコントロール ページのリンクを使用して、アプリを起動し、コントロールの動作を確認することができます。</span><span class="sxs-lookup"><span data-stu-id="134a0-163">When you have it installed, you can use links on individual control pages to launch the app and see the control in action.</span></span>

<span data-ttu-id="134a0-164"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="134a0-164"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span>

<span data-ttu-id="134a0-165"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="134a0-165"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span>

<img src="images/xaml-controls-gallery.png" alt="XAML Controls Gallery screen" />

## <a name="additional-controls"></a><span data-ttu-id="134a0-166">その他のコントロール</span><span class="sxs-lookup"><span data-stu-id="134a0-166">Additional controls</span></span>

<span data-ttu-id="134a0-167">UWP 開発用の追加のコントロールは、<a href="https://www.telerik.com/">Telerik</a>、<a href="https://www.syncfusion.com/products/uwp">SyncFusion</a>、<a href="https://www.devexpress.com/Products/NET/Controls/Win10Apps/">DevExpress</a>、<a href="https://www.infragistics.com/products/universal-windows-platform">Infragistics</a>、<a href="https://www.componentone.com/Studio/Platform/UWP">ComponentOne</a>、<a href="https://www.actiprosoftware.com/products/controls/universal">ActiPro</a> などの企業から入手できます。</span><span class="sxs-lookup"><span data-stu-id="134a0-167">Additional controls for UWP development are available from companies such as <a href="https://www.telerik.com/">Telerik</a>, <a href="https://www.syncfusion.com/products/uwp">SyncFusion</a>, <a href="https://www.devexpress.com/Products/NET/Controls/Win10Apps/">DevExpress</a>, <a href="https://www.infragistics.com/products/universal-windows-platform">Infragistics</a>, <a href="https://www.componentone.com/Studio/Platform/UWP">ComponentOne</a>, and <a href="https://www.actiprosoftware.com/products/controls/universal">ActiPro</a>.</span></span> <span data-ttu-id="134a0-168">これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。</span><span class="sxs-lookup"><span data-stu-id="134a0-168">These controls provide additional support for enterprise and .NET developers by augmenting the standard system controls with custom controls and services.</span></span>  

<span data-ttu-id="134a0-169">これらのコントロールの詳しい情報については、GitHub の<a href="https://github.com/Microsoft/Windows-appsample-customers-orders-database">顧客注文データベース</a> サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="134a0-169">If you're interested in learning more about these controls, check out the <a href="https://github.com/Microsoft/Windows-appsample-customers-orders-database">Customer orders database</a> sample on GitHub.</span></span> <span data-ttu-id="134a0-170">このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。</span><span class="sxs-lookup"><span data-stu-id="134a0-170">This sample makes use of the data grid control and data entry validation from Telerik, which is part of their UI for UWP suite.</span></span> <span data-ttu-id="134a0-171">UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="134a0-171">The UI for UWP suite is a collection of over 20 controls that is available as an open source project through the .NET foundation.</span></span>
