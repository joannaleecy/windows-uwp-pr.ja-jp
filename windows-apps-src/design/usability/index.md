---
description: 世界中のユーザーに対してアプリを包括的にしてアクセシビリティ対応にする方法について説明します。
keywords: UWP アプリのアクセシビリティ, グローバリゼーション, インクルーシブ デザイン アプリ, アクセシビリティ アプリの要件
title: UWP アプリの操作性 - Windows アプリ開発
author: mijacobs
layout: LandingPage
template: detail.hbs
ms.author: mijacobs
ms.date: 10/18/2017
ms.topic: landing-page
ms.assetid: e6bb3464-dd8e-402c-9c56-dd9e51002a49
ms.localizationpriority: medium
ms.openlocfilehash: 80f57ba29d31da0b4d49b620e916e39d4ef69842
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7433353"
---
# <a name="usability-for-uwp-apps"></a>UWP アプリの操作性



少しの配慮で細かい点に注意するだけで、単に優れたユーザー エクスペリエンスから、世界中のユーザーのニーズを満たす真に包括的なユーザー エクスペリエンスに変えることができます。

このセクションに示す設計とコーディングの手順に従って、アクセシビリティ機能の追加、グローバリゼーションとローカライズの有効化、ユーザーによるエクスペリエンスのカスタマイズの有効化、必要に応じたヘルプの提供を行うと、UWP アプリをより包括的なアプリにすることができます。


## <a name="accessiblity"></a>アクセシビリティ

アクセシビリティの目的は、従来のユーザー インターフェイスを使用するのが難しいユーザーにとってアプリを使いやすいものにすることです。 状況によってはアクセシビリティの要件が法律で定められているものもありますが、 できるだけ多くの人にアプリを使ってもらえるように、法的要件に関係なくアクセシビリティの問題に対処することをお勧めします。

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/accessibility-overview.md">アクセシビリティの概要</a></b> <br/> この記事では、UWP アプリのアクセシビリティ シナリオに関連する概念とテクノロジの概要を示します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/designing-inclusive-software.md">包括的なソフトウェアの設計</a></b><br/>Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリでの包括性を備えた設計の進化について説明します。  アクセシビリティを考慮して、包括的なソフトウェアを設計、構築します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/developing-inclusive-windows-apps.md">包括的な Windows アプリの開発</a></b><br/> この記事は、アクセシビリティ対応の UWP アプリを開発するためのロードマップです。</p>
                    </div>
                </div>
            </div>
        </div>
    </li> 
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/accessibility-testing.md">アクセシビリティ テスト</a> </b><br/>UWP アプリをアクセシビリティ対応にするためのテスト手順です。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/accessibility-in-the-store.md">ストア内のアクセシビリティ</a></b><br/>UWP アプリがアクセシビリティ対応であることを Microsoft Store で宣言するために必要なことを説明します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/accessibility-checklist.md">アクセシビリティのチェック リスト</a></b><br/>UWP アプリをアクセシビリティ対応にするために役立つチェック リストを示します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>        
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/basic-accessibility-information.md">基本的なアクセシビリティ情報の開示</a></b><br/>基本的なアクセシビリティ情報は、多くの場合、名前、役割、値に分類されます。 このトピックでは、支援技術が必要とする基本情報をアプリで公開するのに役立つコードについて説明します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li> 
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/keyboard-accessibility.md">キーボードのアクセシビリティ</a></b><br/>アプリに十分なキーボード操作機能が備わっていない場合、視覚障碍や運動障碍のあるユーザーはアプリをうまく使うことができなかったり、まったく使うことができない可能性があります。</p>
                    </div>
                </div>
            </div>
        </div>
    </li> 
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/high-contrast-themes.md">ハイ コントラスト テーマ</a></b><br/>ハイ コントラスト テーマがアクティブになっているときに UWP アプリを使えることを確かめるために必要な手順について説明します。 </p>
                    </div>
                </div>
            </div>
        </div>
    </li>         
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/accessible-text-requirements.md">アクセシビリティに対応したテキストの要件</a></b><br/>このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。 また、UWP アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。</p>                    
                    </div>
                </div>
            </div>
        </div>
    </li>     
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/practices-to-avoid.md">アクセシビリティ対応にするために避ける事項</a></b><br/>アクセシビリティ対応の UWP アプリを作成するために避ける事項の一覧を表示します。</p>                    
                    </div>
                </div>
            </div>
        </div>
    </li>     
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/custom-automation-peers.md">カスタム オートメーション ピア</a></b><br/>UI オートメーションに対するオートメーション ピアの概念について説明します。また、独自のカスタム UI クラスに対してオートメーションのサポートを提供する方法についても説明します。</p>                    
                    </div>
                </div>
            </div>
        </div>
    </li>     
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../accessibility/control-patterns-and-interfaces.md">コントロール パターンとインターフェイス</a></b><br/>Microsoft UI オートメーションのコントロール パターン、それらにアクセスするためにクライアントが使うクラス、それらを実装するためにプロバイダーが使うインターフェイスを紹介します。</p>                    
                    </div>
                </div>
            </div>
        </div>
    </li>     
</ul>


## <a name="globalization-and-localization"></a>グローバリゼーションとローカライズ

Windows は世界中で利用されており、言語、地域、文化の異なる多様なユーザーを対象としています。 アプリはさまざまな言語を使用するユーザーによって、さまざまな国や地域で使用されます。 中には複数の言語を話すユーザーもいます。 そのため、アプリが実行される構成には、さまざまな言語、地域、文化システムの組み合わせが関係します。 *グローバリゼーション*と*ローカライズ*によってアプリの適応性を高めることにより、潜在的な市場を拡大することができます

<a href="../globalizing/globalizing-portal.md">グローバリゼーションとローカライズ ポータル</a>

## <a name="app-settings"></a>アプリの設定

アプリの設定を利用することで、ユーザーがアプリをカスタマイズしたり、個人のニーズや好みに合わせてアプリを最適化したりすることができます。 適切な設定を提供し、適切に保存することで、優れたユーザー エクスペリエンスをさらに向上させることができます。

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../app-settings/guidelines-for-app-settings.md">ガイドライン</a></b><br/>アプリ設定を作成し表示する際のベスト プラクティス。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../app-settings/store-and-retrieve-app-data.md">アプリ データの保存と取得</a></b><br/>ローカル アプリ データ、ローミング アプリ データ、一時アプリ データの保存方法と取得方法。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
</ul>


## <a name="in-app-help"></a>アプリ内ヘルプ
アプリの設計がどれほど優れていても、ユーザーはヘルプを必要とする場合があります。

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../in-app-help/guidelines-for-app-help.md">アプリのヘルプのガイドライン</a></b><br/>アプリケーションが複雑な場合には、ユーザーに効果的なヘルプを提供することにより、ユーザー エクスペリエンスを大幅に改善できます。
</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../in-app-help/instructional-ui.md">説明 UI</a></b><br/>特定のタッチ操作など、ユーザーにわかりにくいアプリの機能をユーザーに伝えると便利な場合があります。 このような場合は、わかりにくいと思われる機能をユーザーが検出し使用できるように、UI を使ってユーザーに指示を示す必要があります。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../in-app-help/in-app-help.md">アプリ内ヘルプ</a></b><br/>多くの場合、アプリケーション内でユーザーがヘルプの表示を選んだときに、ヘルプが表示されるのが適切な方法です。 アプリ内ヘルプを作成するときは、次のガイドラインを考慮してください。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardText">
<p><b><a href="../in-app-help/external-help.md">外部のヘルプ</a></b><br/>多くの場合、アプリケーション内でユーザーがヘルプの表示を選んだときに、ヘルプが表示されるのが適切な方法です。 アプリ内ヘルプを作成するときは、次のガイドラインを考慮してください。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>        
</ul>

