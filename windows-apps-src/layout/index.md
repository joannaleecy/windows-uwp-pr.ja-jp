---
description: "さまざまなデバイスや画面サイズで、ナビゲーションがわかりやすく見た目にも優れた UWP アプリを設計およびコーディングする方法について説明します。"
title: "UWP アプリのレイアウトの設計 - Windows アプリ開発"
author: mijacobs
keywords: "UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス"
label: Layout
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: e643b7029d5bc417437f7a1b8586424ac4345c3b

---
# <a name="layout-for-uwp-apps"></a>UWP アプリのレイアウト
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


アプリの構造、ページ レイアウト、ナビゲーションは、アプリのユーザー エクスペリエンスの基盤となるものです。 このセクションの記事は、さまざまなデバイスや画面サイズで簡単に操作でき、適切に表示されるアプリを作成する際に役立ちます。

## <a name="intro"></a>はじめに

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
  <p><b>[アプリの UI 設計の概要](design-and-ui-intro.md)</b><br />
UWP アプリを設計する場合、さまざまなディスプレイ サイズを持つさまざまなデバイスに合ったユーザー インターフェイスを作成する必要があります。 この記事では、UWP アプリの UI に関連する機能や利点の概要と、応答性の高い UI を設計するためのヒントやコツを示します。 </p>
  </div>
  <div class="side-by-side-content-right">
    ![複数のデバイスで実行されるアプリ](images/rspd-reposition-type1-sm.png)
  </div>
</div>
</div>

## <a name="app-layout-and-structure"></a>アプリのレイアウトと構造
アプリを構築し、ナビゲーション、コマンド、コンテンツという 3 種類の UI 要素を使うには、次の推奨事項を確認してください。

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p>
<b>[ナビゲーションの基本](navigation-basics.md)</b><br/>
UWP アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。 この記事では、これらの構成要素を紹介します。また、これらの構成要素を組み合わせて使い、優れたナビゲーション エクスペリエンスを作成する方法について説明します。
</p>
<p>
<b>[コンテンツの基本](content-basics.md)</b><br/>
どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。 この記事では、3 つのコンテンツ シナリオ (使用、作成、対話式操作) でのコンテンツの設計に関する推奨事項について説明します。
</p> 
  </div>
  <div class="side-by-side-content-right">
<p><b>[コマンドの基本](commanding-basics.md)</b> <br />
コマンド要素は、ユーザーがメール送信、項目の削除、フォームの送信などの操作を実行できる対話型の UI 要素です。 この記事では、ボタンやチェック ボックスなどのコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするコマンド サーフェス (コマンド バーやショートカット メニューなど) について説明します。</p>
  </div>
</div>
</div>

## <a name="page-layout"></a>ページのレイアウト 
次の記事は、さまざまな画面サイズ、ウィンドウ サイズ、解像度、向きで適切に表示される柔軟な UI を作成する際に役立ちます。 


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>[画面のサイズとブレークポイント](screen-sizes-and-breakpoints-for-responsive-design.md)</b><br/>
対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。 その代わり、360、640、1024、および 1366 epx という 4 種類の主要なキー幅 ("ブレークポイント" とも呼ばれます) を設計することをお勧めします。</p>
  </div>
  <div class="side-by-side-content-right">
 <p><b>[XAML を使ったレイアウトの定義](layouts-with-xaml.md)</b> <br/>
XAML プロパティとレイアウト パネルを使って、アプリの応答性と適応性を高める方法を説明します。</p>
  </div>
</div>
</div>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>[レイアウト パネル](layout-panels.md)</b> <br />
各レイアウト パネルの種類を説明し、パネルを使って XAML UI 要素をレイアウトする方法について説明します。</p>
  </div>
  <div class="side-by-side-content-right">
 <p><b>[配置、余白、パディング](alignment-margin-padding.md)</b> <br />
サイズのプロパティ (幅、高さ、および制約) に加え、要素は、配置、余白、パディングのプロパティも含むことができ、これらは、要素がレイアウト パスに移動し、UI に表示されるときにレイアウト動作に影響を与えます。</p> 
  </div>
</div>
</div>





<!--HONumber=Dec16_HO2-->


