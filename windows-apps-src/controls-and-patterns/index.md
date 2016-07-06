---
description: "UWP アプリにコントロールとパターンを追加する方法についての設計ガイダンスとコーディングの手順を説明します。"
title: "コントロールとパターン - Windows アプリ開発"
author: mijacobs
translationtype: Human Translation
ms.sourcegitcommit: 9f75c39d26bd0c8858f404ab4fcd3d23562ea033
ms.openlocfilehash: 0562e3df0c2abbb0808df5f75ff4fe0b96eb6d7e

---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


# UWP アプリのコントロールとパターン

UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。 コントロールとは、ユーザー インターフェイスの構成要素です。 単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。 <i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。

このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を説明します。 

## はじめに

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

## アルファベット順インデックス 

特定のコントロールとパターンに関する詳細情報を説明します。

(機能別に並べ替えた一覧については、「[機能別コントロールのインデックス](controls-by-function.md)」をご覧ください。)

<div class="uwpd-list-of-links">
<ul>

<li>[アクティブなキャンバス](active-canvas.md)</li>

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


<li>[ダイアログ、ポップアップ、メニュー](dialogs-popups-menus.md)</li>

<li>[FlipView](flipview.md)</li>

<li>[ハブ](hub.md)</li>

<li>[ハイパーリンク](hyperlinks.md)</li>

<li>[画像とイメージ ブラシ](images-imagebrushes.md)</li>

<li>[リスト](lists.md)</li>

<li>[マスター/詳細](master-details.md)</li>

<li>[メディア再生](media-playback.md)</li>

<li>[カスタム トランスポート コントロール](custom-transport-controls.md)</li>

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

<li>[フォント](fonts.md)</li>
<li>[ラベル](labels.md)</li>

<li>[パスワード ボックス](password-box.md)</li>

<li>[リッチ エディット ボックス](rich-edit-box.md)</li>

<li>[リッチ テキスト ブロック](rich-text-block.md)</li>

<li>[Segoe MDL2 アイコン](segoe-ui-symbol-font.md)</li>

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



<!--HONumber=Jun16_HO4-->


