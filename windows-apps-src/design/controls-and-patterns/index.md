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
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7564576"
---
# <a name="controls-and-patterns-for-uwp-apps"></a>UWP アプリのコントロールとパターン
 

UWP アプリ開発では、<i>コントロール</i>は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。 コントロールとは、ユーザー インターフェイスの構成要素です。 <i>パターン</i>とは、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。

単純なボタンから、グリッド ビューのような強力なデータ コントロールまで、ユーザーが使用できる 45 種類以上のコントロールが用意されています。  これらのコントロールは Fluent Design System の一部です。すべでのデバイスやあらゆる画面サイズで見栄えがよく、力強い、スケーラブルな UI を作成できます。 

このセクションの記事では、UWP アプリにコントロールとパターンを追加するための設計ガイダンスとコーディングの手順を説明します。 

## <a name="intro"></a>はじめに

XAML と C# でコントロールを追加し、スタイルを指定するための一般的な手順とコード例を示します。

:::row:::
    :::column:::
      <p><b><a href="controls-and-events-intro.md">コントロールの追加とイベントの処理</a></b> <br/>
アプリにコントロールを追加するには、アプリの UI にコントロールを追加する、コントロールのプロパティを設定する、コントロールを動作させるためのコードをコントロールのイベント ハンドラーに追加するといった、3 つの重要な手順があります。</p>
    :::column-end:::
    :::column:::
      <p><b><a href="xaml-styles.md">コントロールのスタイル</a></b> <br/>
XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。 スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。</p>
    :::column-end:::
:::row-end:::

## <a name="get-the-windows-ui-library"></a>Windows UI のライブラリを入手します。
一部のコントロールは、Windows UI のライブラリでのみ利用できます。 それを取得するのには、 [Windows UI のライブラリの概要とインストールの手順](/uwp/toolkits/winui/)をご覧ください。

## <a name="alphabetical-index"></a>アルファベット順インデックス 

特定のコントロールとパターンに関する詳細情報を説明します。 (機能別に並べ替えた一覧については、「<a href="controls-by-function.md">機能別コントロールのインデックス</a>」をご覧ください。)

<div style="column-count: 2; column-gap: 40px; margin-top: 40px;" >
<ul style="margin-top: 0px; padding-top: 0px; list-style-type: none;">
<li style="list-style-type: none;"><a href="auto-suggest-box.md">自動提案ボックス</a></li>

<li style="list-style-type: none;"><a href="app-bars.md">バー</a></li>

<li style="list-style-type: none;"><a href="buttons.md">ボタン</a></li>

<li style="list-style-type: none;"><a href="checkbox.md">チェックボックス </a></li>

<li style="list-style-type: none;"><a href="color-picker.md">カラー ピッカー</a></li>

<li style="list-style-type: none;"><a href="contact-card.md">連絡先カード</a></li>

<li style="list-style-type: none;"><a href="date-and-time.md">日付と時刻コントロール</a></li>

<li style="list-style-type: none;"><a href="dialogs-and-flyouts/index.md">ダイアログとポップアップ</a></li>

<li style="list-style-type: none;"><a href="flipview.md">フリップ ビュー</a></li>

<li style="list-style-type: none;"><a href="forms.md">フォーム</a></li>

<li style="list-style-type: none;"><a href="hub.md">Hub</a></li>

<li style="list-style-type: none;"><a href="hyperlinks.md">ハイパーリンク</a></li>

<li style="list-style-type: none;"><a href="images-imagebrushes.md">画像とイメージ ブラシ</a></li>

<li style="list-style-type: none;"><a href="inking-controls.md">インク コントロール</a></li>

<li style="list-style-type: none;"><a href="lists.md">リスト</a></li>

<li style="list-style-type: none;"><a href="../../maps-and-location/controls-map.md">マップ コントロール</a></li>

<li style="list-style-type: none;"><a href="master-details.md">マスター/詳細</a></li>

<li style="list-style-type: none;"><a href="media-playback.md">メディア再生</a></li>

<li style="list-style-type: none;"><a href="menus.md">メニューとコンテキスト メニュー</a></li>

<li style="list-style-type: none;"><a href="navigationview.md">ナビゲーション ビュー</a></li>

<li style="list-style-type: none;"><a href="person-picture.md">ユーザー画像</a></li>

<li style="list-style-type: none;"><a href="pivot.md">ピボット</a></li>

<li style="list-style-type: none;"><a href="progress-controls.md">プログレス コントロール</a></li>

<li style="list-style-type: none;"><a href="radio-button.md">ラジオ ボタン</a></li>

<li style="list-style-type: none;"><a href="rating.md">評価コントロール</a></li>

<li style="list-style-type: none;"><a href="scroll-controls.md">スクロール コントロールとパン コントロール</a></li>

<li style="list-style-type: none;"><a href="search.md">検索</a></li>

<li style="list-style-type: none;"><a href="semantic-zoom.md">セマンティック ズーム</a></li>

<li style="list-style-type: none;"><a href="shapes.md">図形</a></li>

<li style="list-style-type: none;"><a href="slider.md">Slider</a></li>

<li style="list-style-type: none;"><a href="split-view.md">分割ビュー</a></li>

<li style="list-style-type: none;"><a href="text-controls.md">テキスト コントロール</a></li>


<li style="list-style-type: none;"><a href="toggles.md">トグル</a></li>
<li style="list-style-type: none;"><a href="tooltips.md">ヒント</a></li>

<li style="list-style-type: none;"><a href="tree-view.md">ツリー ビュー</a></li>

<li style="list-style-type: none;"><a href="web-view.md">Web ビュー</a></li>
</ul>
</div>

## <a name="xaml-controls-gallery"></a>XAML コントロール ギャラリー

Microsoft Store から _XAML コントロール ギャラリー_ アプリを入手し、これらのコントロールおよび Fluent Design System の動作を確認します。 このアプリは、この Web サイトの対話型コンパニオンです。 このアプリがインストールされている場合、個々のコントロール ページのリンクを使用して、アプリを起動し、コントロールの動作を確認することができます。

<a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a>

<a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a>

<img src="images/xaml-controls-gallery.png" alt="XAML Controls Gallery screen" />

## <a name="additional-controls"></a>その他のコントロール

UWP 開発用の追加のコントロールは、<a href="http://www.telerik.com/">Telerik</a>、<a href="https://www.syncfusion.com/products/uwp">SyncFusion</a>、<a href="https://www.devexpress.com/Products/NET/Controls/Win10Apps/">DevExpress</a>、<a href="http://www.infragistics.com/products/universal-windows-platform">Infragistics</a>、<a href="https://www.componentone.com/Studio/Platform/UWP">ComponentOne</a>、<a href="http://www.actiprosoftware.com/products/controls/universal">ActiPro</a> などの企業から入手できます。 これらのコントロールは、カスタム コントロールおよびサービスによって標準システム コントロールを補うことにより、エンタープライズおよび .NET 開発者に追加のサポートを提供します。  

これらのコントロールの詳しい情報については、GitHub の<a href="https://github.com/Microsoft/Windows-appsample-customers-orders-database">顧客注文データベース</a> サンプルをご覧ください。 このサンプルでは、Telerik によるデータ グリッド コントロールおよびデータ入力検証を使っています。これは、UWP スイート用の UI の一部となっています。 UI for UWP スイートは、.NET Foundation を通じてオープン ソース プロジェクトとして利用できる、20 を超えるコントロールのコレクションです。
