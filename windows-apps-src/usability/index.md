---
description: "このセクションの設計とコーディングの手順は、特定の種類の入力とデバイス用に UWP アプリをカスタマイズする場合に役立ちます。"
title: "UWP アプリの操作性 - Windows アプリ開発"
author: mijacobs
translationtype: Human Translation
ms.sourcegitcommit: 9f75c39d26bd0c8858f404ab4fcd3d23562ea033
ms.openlocfilehash: f02713dfee278866af53c6dd529d2faa3e9f625c

---

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

# UWP アプリの操作性

UWP アプリは、さまざまな入力を自動的に処理し、さまざまなデバイスで実行できます。タッチ入力を有効にする場合や、アプリを電話で実行できるようにする場合に、追加の作業は何も必要ありません。 

ただし、特定の種類の入力やデバイス用にアプリを最適化することが必要になる場合もあります。 たとえば、ペイント アプリを作成している場合は、必要に応じてペン入力の処理方法をカスタマイズできます。 

このセクションの設計とコーディングの手順は、特定の種類の入力とデバイス用に UWP アプリをカスタマイズする場合に役立ちます。 

## アクセシビリティ

アクセシビリティの目的は、従来のユーザー インターフェイスを使用するのが難しいユーザーにとってアプリを使いやすいものにすることです。 状況によってはアクセシビリティの要件が法律で定められているものもありますが、 できるだけ多くの人にアプリを使ってもらえるように、法的要件に関係なくアクセシビリティの問題に対処することをお勧めします。

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[アクセシビリティの概要](../accessibility/accessibility-overview.md)</b> <br/> この記事では、UWP アプリのアクセシビリティ シナリオに関連する概念とテクノロジの概要を示します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[包括的なソフトウェアの設計](../accessibility/designing-inclusive-software.md)</b><br/>Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリでの包括性を備えた設計の進化について説明します。  アクセシビリティを考慮して、包括的なソフトウェアを設計、構築します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[包括的な Windows アプリの開発](../accessibility/developing-inclusive-windows-apps.md)</b><br/> この記事は、アクセシビリティ対応の UWP アプリを開発するためのロードマップです。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[アクセシビリティ テスト](../accessibility/accessibility-testing.md) </b><br/>UWP アプリをアクセシビリティ対応にするためのテスト手順です。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[ストア内のアクセシビリティ](../accessibility/accessibility-in-the-store.md)</b><br/>UWP アプリがアクセシビリティ対応であることを Windows ストアで宣言するために必要なことを説明します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[アクセシビリティのチェック リスト](../accessibility/accessibility-checklist.md)</b><br/>UWP アプリをアクセシビリティ対応にするために役立つチェック リストを示します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[基本的なアクセシビリティ情報の開示](../accessibility/basic-accessibility-information.md)</b><br/>基本的なアクセシビリティ情報は、多くの場合、名前、役割、値に分類されます。 このトピックでは、支援技術が必要とする基本情報をアプリで公開するのに役立つコードについて説明します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[キーボードのアクセシビリティ](../accessibility/keyboard-accessibility.md)</b><br/>アプリに十分なキーボード操作機能が備わっていない場合、視覚障碍や運動障碍のあるユーザーはアプリをうまく使うことができなかったり、まったく使うことができない可能性があります。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[ハイ コントラスト テーマ](../accessibility/high-contrast-themes.md)</b><br/>ハイ コントラスト テーマがアクティブになっているときに UWP アプリを使えることを確かめるために必要な手順について説明します。 </p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[アクセシビリティに対応したテキストの要件](../accessibility/accessible-text-requirements.md)</b><br/>このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。 また、UWP アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[アクセシビリティ対応にするために避ける事項](../accessibility/practices-to-avoid.md)</b><br/>アクセシビリティ対応の UWP アプリを作成するために避ける事項の一覧を表示します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[カスタム オートメーション ピア](../accessibility/custom-automation-peers.md)</b><br/>UI オートメーションに対するオートメーション ピアの概念について説明します。また、独自のカスタム UI クラスに対してオートメーションのサポートを提供する方法についても説明します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[コントロール パターンとインターフェイス](../accessibility/control-patterns-and-interfaces.md)</b><br/>Microsoft UI オートメーションのコントロール パターン、それらにアクセスするためにクライアントが使うクラス、それらを実装するためにプロバイダーが使うインターフェイスを紹介します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b></b>   
</p>
  </div>
</div>
</div>



## グローバリゼーションとローカライズ

Windows は世界中で利用されており、文化、地域、言語の異なるユーザーがいます。 ユーザーは、自分の使用言語としてどの言語でも指定でき、複数の言語を指定することもできます。 住んでいる地域として世界中のどの場所を指定することもでき、地域を問わずどの言語でも指定できます。 グローバリゼーションとローカライズによってアプリの適応性を直ちに高めることにより、潜在的な市場が広がります。 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[推奨と非推奨](../globalizing/guidelines-and-checklist-for-globalizing-your-app.md)</b><br/>広範なユーザー向けにアプリをグローバル化したり、特定の市場を対象にアプリをローカライズするときは、次のベスト プラクティスに従ってください。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[グローバル対応の形式の使用](../globalizing/use-global-ready-formats.md)</b><br/>日付、時刻、数字、通貨を適切に書式設定することで、グローバル対応のアプリを開発します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[言語と地域の管理](../globalizing/manage-language-and-region.md)</b><br/>Windows で提供される言語と地域についてのさまざまな設定を使って、Windows がアプリの UI リソースをどのように選び、UI 要素のフォーマットをどのように決定するかを制御します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[パターンを使った日付と時刻の書式設定](../globalizing/use-patterns-to-format-dates-and-times.md)</b><br/>希望するどおりの形式で日付と時刻を表示するには、[<strong>DateTimeFormatting</strong>](https://msdn.microsoft.com/library/windows/apps/br206859) API をカスタム パターンと共に使用します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[レイアウトやフォントの調整と RTL のサポート](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)</b><br/>RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[ローカライズのためにアプリの準備をする](../globalizing/prepare-your-app-for-localization.md)</b><br/>他の市場、言語、または地域に向けたローカライズのためにアプリを準備します。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[UI 文字列をリソースに格納する](../globalizing/put-ui-strings-into-resources.md)</b><br/>UI の文字列リソースをリソース ファイルに格納します。 その後、これらの文字列をコードやマークアップから参照できます。</p>
  </div>
  <div class="side-by-side-content-right">
<b></b>   
<p></p>
  </div>
</div>
</div>


## アプリの設定

アプリの設定を利用することで、ユーザーがアプリをカスタマイズしたり、個人のニーズや好みに合わせてアプリを最適化したりすることができます。 適切な設定を提供し、適切に保存することで、優れたユーザー エクスペリエンスをさらに向上させることができます。 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[ガイドライン](../app-settings/guidelines-for-app-settings.md)</b><br/>アプリ設定を作成し表示する際のベスト プラクティス。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[アプリ データの保存と取得](../app-settings/store-and-retrieve-app-data.md)</b><br/>ローカル アプリ データ、ローミング アプリ データ、一時アプリ データの保存方法と取得方法。</p>
  </div>
</div>
</div>

## アプリ内ヘルプ
アプリの設計がどれほど優れていても、ユーザーはヘルプを必要とする場合があります。 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[アプリのヘルプのガイドライン](../app-help-guidelines/guidelines-for-app-help.md)</b><br/>アプリケーションが複雑な場合には、ユーザーに効果的なヘルプを提供することにより、ユーザー エクスペリエンスを大幅に改善できます。 
</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[説明 UI](../app-help-guidelines/instructional-ui.md)</b><br/>特定のタッチ操作など、ユーザーにわかりにくいアプリの機能をユーザーに伝えると便利な場合があります。 このような場合は、わかりにくいと思われる機能をユーザーが検出し使用できるように、UI を使ってユーザーに指示を示す必要があります。</p>
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<p><b>[アプリ内ヘルプ](../app-help-guidelines/in-app-help.md)</b><br/>多くの場合、アプリケーション内でユーザーがヘルプの表示を選んだときに、ヘルプが表示されるのが適切な方法です。 アプリ内ヘルプを作成するときは、次のガイドラインを考慮してください。</p>
  </div>
  <div class="side-by-side-content-right">
<p><b>[外部のヘルプ](../app-help-guidelines/external-help.md)</b><br/>多くの場合、アプリケーション内でユーザーがヘルプの表示を選んだときに、ヘルプが表示されるのが適切な方法です。 アプリ内ヘルプを作成するときは、次のガイドラインを考慮してください。</p>
  </div>
</div>
</div>






<!--HONumber=Jun16_HO4-->


