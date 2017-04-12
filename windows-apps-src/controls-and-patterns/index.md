---
description: "UWP アプリにコントロールとパターンを追加する方法についての設計ガイダンスとコーディングの手順を説明します。 アプリで使用できる 45 種類以上の強力なコントロールを紹介します。"
title: "UWP のコントロールとパターン - Windows アプリ開発"
author: mijacobs
keywords: "UWP コントロール, ユーザー インターフェイス, アプリ コントロール"
label: Controls & patterns
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: ce2e611c-c419-4a14-9095-b88ac711d1b8
ms.openlocfilehash: 7b525267c8f4d24af95f6d41d46d33a3adf10f8f
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="controls-and-patterns-for-uwp-apps"></a>UWP アプリのコントロールとパターン
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。 コントロールとは、ユーザー インターフェイスの構成要素です。 単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。 <i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。

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

特定のコントロールとパターンに関する詳細情報を説明します。

(機能別に並べ替えた一覧については、「[機能別コントロールのインデックス](controls-by-function.md)」をご覧ください。)

<div class="uwpd-list-of-links">
<ul>

<li>[自動提案ボックス](auto-suggest-box.md)</li>

<li>[バー](app-bars.md)</li>

<li>[ボタン](buttons.md)</li>

<li>[チェック ボックス ](checkbox.md)</li>

<li>[日付と時刻コントロール](date-and-time.md)
<ul>

<li>[カレンダーの日付の選択コントロール](calendar-date-picker.md)</li>

<li>[カレンダー ビュー](calendar-view.md)</li>

<li>[日付の選択コントロール](date-picker.md)</li>

<li>[時刻の選択コントロール](time-picker.md)</li>
</ul>
</li>


<li>[ダイアログとポップアップ](dialogs.md)</li>

<li>[フリップ ビュー](flipview.md)</li>

<li>[ハブ](hub.md)</li>

<li>[ハイパーリンク](hyperlinks.md)</li>

<li>[画像とイメージ ブラシ](images-imagebrushes.md)</li>

<li>[リスト](lists.md)</li>

<li>[マップ コントロール](../maps-and-location/controls-map.md)</li>

<li>[マスター/詳細](master-details.md)</li>

<li>[メディア再生](media-playback.md)
<ul>
<li>[カスタム トランスポート コントロール](custom-transport-controls.md)</li>
</ul>
</li>

<li>[メニューとコンテキスト メニュー](menus.md)</li>

<li>[ナビゲーション ウィンドウ](nav-pane.md)</li>

<li>[プログレス コントロール](progress-controls.md)</li>

<li>[ラジオ ボタン](radio-button.md)</li>

<li>[スクロール コントロールとパン コントロール](scroll-controls.md)</li>

<li>[検索](search.md)</li>

<li>[セマンティック ズーム](semantic-zoom.md)</li>

<li>[スライダー](slider.md)</li>

<li>[分割ビュー](split-view.md)</li>

<li>[タブとピボット](tabs-pivot.md)</li>

<li>[テキスト コントロール](text-controls.md)
<ul>

<li>[ラベル](labels.md)</li>

<li>[パスワード ボックス](password-box.md)</li>

<li>[リッチ エディット ボックス](rich-edit-box.md)</li>

<li>[リッチ テキスト ブロック](rich-text-block.md)</li>

<li>[スペル チェックと予測](spell-checking-and-prediction.md)</li>

<li>[テキスト ブロック](text-block.md)</li>

<li>[テキスト ボックス](text-box.md)</li>
</ul>
</li>



<li>[タイル、バッジ、通知](tiles-badges-notifications.md)
<ul>

<li>[タイル](tiles-and-notifications-creating-tiles.md)</li>

<li>[アダプティブ タイル](tiles-and-notifications-create-adaptive-tiles.md)</li>

<li>[アダプティブ タイルのスキーマ](tiles-and-notifications-adaptive-tiles-schema.md)</li>

<li>[アセットのガイドライン](tiles-and-notifications-app-assets.md)</li>

<li>[特別なタイル テンプレート](tiles-and-notifications-special-tile-templates-catalog.md)</li>

<li>[アダプティブ トースト通知と対話型トースト通知](tiles-and-notifications-adaptive-interactive-toasts.md)</li>

<li>[バッジ通知](tiles-and-notifications-badges.md)</li>

<li>[Notifications Visualizer](tiles-and-notifications-notifications-visualizer.md)</li>

<li>[通知の配信方法](tiles-and-notifications-choosing-a-notification-delivery-method.md)</li>

<li>[ローカル タイル通知](tiles-and-notifications-sending-a-local-tile-notification.md)</li>

<li>[定期的な通知](tiles-and-notifications-periodic-notification-overview.md)</li>

<li>[WNS](tiles-and-notifications-windows-push-notification-services--wns--overview.md)</li>

<li>[直接通知](tiles-and-notifications-raw-notification-overview.md)</li>
</ul>
</li>


<li>[トグル](toggles.md)</li>
<li>[ヒント](tooltips.md)</li>

<li>[Web ビュー](web-view.md)</li>
</ul>
</div>

## <a name="additional-controls-options"></a>その他のコントロール オプション

UWP 開発用の追加のコントロールは、[Telerik](http://www.telerik.com/)、[SyncFusion](https://www.syncfusion.com/products/uwp)、[DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/)、[Infragistics](http://www.infragistics.com/products/universal-windows-platform)、[ComponentOne](https://www.componentone.com/Studio/Platform/UWP)、[ActiPro](http://www.actiprosoftware.com/products/controls/universal) などの企業から入手できます。 これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。  

これらのコントロールの詳しい情報については、GitHub の[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database) サンプルをご覧ください。 このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。 UWP スイート用の UI は、.NET の基盤を通じたオープン ソース プロジェクトとして使用可能な 20 を超えるコントロールのコレクションです。

![顧客注文データベースのイメージ](images/customerOrdersDataGrid.png)