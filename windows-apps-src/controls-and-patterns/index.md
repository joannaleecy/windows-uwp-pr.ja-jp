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
# <a name="controls-and-patterns-for-uwp-apps"></a>UWP アプリのコントロールとパターン
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。 コントロールとは、ユーザー インターフェイスの構成要素です。 <i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。

単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。  これらのコントロールは Fluent Design System の一部です。すべでのデバイスやあらゆる画面サイズで見栄えがよく、力強い、スケーラブルな UI を作成できます。 

このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を説明します。 

## <a name="intro"></a>はじめに

XAML と C# でコントロールを追加し、スタイルを指定するための一般的な手順とコード例を示します。

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>[コントロールの追加とイベントの処理](controls-and-events-intro.md)</b> <br/>
アプリにコントロールを追加するには、アプリの UI にコントロールを追加する、コントロールのプロパティを設定する、コントロールを動作させるためのコードをコントロールのイベント ハンドラーに追加するといった、3 つの重要な手順があります。</li>
</ul> 
</p>
  </div>
  <div class="side-by-side-content-right">
   <p><b>[コントロールのスタイル](styling-controls.md)</b> <br/>
XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。 スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。</p>
  </div>
</div>
</div>

## <a name="alphabetical-index"></a>アルファベット順インデックス 

特定のコントロールとパターンに関する詳細情報を説明します。 (機能別に並べ替えた一覧については、「[機能別コントロールのインデックス](controls-by-function.md)」をご覧ください。)

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;" >
<ul style="margin-top: 0px; padding-top: 0px; list-style-type: none;">
<li style="list-style-type: none;">[自動提案ボックス](auto-suggest-box.md)</li>

<li style="list-style-type: none;">[バー](app-bars.md)</li>

<li style="list-style-type: none;">[ボタン](buttons.md)</li>

<li style="list-style-type: none;">[チェックボックス ](checkbox.md)</li>

<li style="list-style-type: none;">[カラー ピッカー](color-picker.md)</li>

<li style="list-style-type: none;">[日付と時刻コントロール](date-and-time.md)</li>


<li style="list-style-type: none;">[ダイアログとポップアップ](dialogs.md)</li>

<li style="list-style-type: none;">[フリップ ビュー](flipview.md)</li>

<li style="list-style-type: none;">[ハブ](hub.md)</li>

<li style="list-style-type: none;">[ハイパーリンク](hyperlinks.md)</li>

<li style="list-style-type: none;">[画像とイメージ ブラシ](images-imagebrushes.md)</li>

<li style="list-style-type: none;">[インク コントロール](inking-controls.md)</li>

<li style="list-style-type: none;">[リスト](lists.md)</li>

<li style="list-style-type: none;">[マップ コントロール](../maps-and-location/controls-map.md)</li>

<li style="list-style-type: none;">[マスター/詳細](master-details.md)</li>

<li style="list-style-type: none;">[メディア再生](media-playback.md)</li>

<li style="list-style-type: none;">[メニューとコンテキスト メニュー](menus.md)</li>

<li style="list-style-type: none;">[ナビゲーション ビュー](navigationview.md)</li>

<li style="list-style-type: none;">[ユーザー画像](person-picture.md)</li>

<li style="list-style-type: none;">[プログレス コントロール](progress-controls.md)</li>

<li style="list-style-type: none;">[ラジオ ボタン](radio-button.md)</li>

<li style="list-style-type: none;">[評価コントロール](rating.md)</li>

<li style="list-style-type: none;">[スクロール コントロールとパン コントロール](scroll-controls.md)</li>

<li style="list-style-type: none;">[検索](search.md)</li>

<li style="list-style-type: none;">[セマンティック ズーム](semantic-zoom.md)</li>

<li style="list-style-type: none;">[スライダー](slider.md)</li>

<li style="list-style-type: none;">[分割ビュー](split-view.md)</li>

<li style="list-style-type: none;">[タブとピボット](tabs-pivot.md)</li>

<li style="list-style-type: none;">[テキスト コントロール](text-controls.md)</li>

<li style="list-style-type: none;">[タイル、バッジ、および通知](tiles-badges-notifications.md)</li>


<li style="list-style-type: none;">[トグル](toggles.md)</li>
<li style="list-style-type: none;">[ヒント](tooltips.md)</li>

<li style="list-style-type: none;">[ツリー ビュー](tree-view.md)</li>

<li style="list-style-type: none;">[Web ビュー](web-view.md)</li>
</ul>
</div>

## <a name="additional-controls"></a>その他のコントロール

UWP 開発用の追加のコントロールは、[Telerik](http://www.telerik.com/)、[SyncFusion](https://www.syncfusion.com/products/uwp)、[DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/)、[Infragistics](http://www.infragistics.com/products/universal-windows-platform)、[ComponentOne](https://www.componentone.com/Studio/Platform/UWP)、[ActiPro](http://www.actiprosoftware.com/products/controls/universal) などの企業から入手できます。 これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。  

これらのコントロールの詳しい情報については、GitHub の[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database) サンプルをご覧ください。 このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。 UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。
