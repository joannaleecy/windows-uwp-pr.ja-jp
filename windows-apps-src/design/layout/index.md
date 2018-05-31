---
description: さまざまなデバイスや画面サイズで、ナビゲーションがわかりやすく見た目にも優れた UWP アプリを設計およびコーディングする方法について説明します。
title: UWP アプリ レイアウトの設計
author: mijacobs
layout: LandingPage
keywords: UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス
ms.author: mijacobs
ms.date: 3/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: 1aa12606-8a99-4db3-8311-90e02fde9cf1
ms.localizationpriority: medium
ms.openlocfilehash: 2bad76a2e8d6a817be8aae98da6fb8fa0386b147
ms.sourcegitcommit: 346b5c9298a6e9e78acf05944bfe13624ea7062e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/05/2018
ms.locfileid: "1707373"
---
# <a name="layout-for-uwp-apps"></a>UWP アプリのレイアウト

次の記事は、さまざまな画面サイズ、ウィンドウ サイズ、解像度、向きで適切に表示される柔軟な UI を作成する際に役立ちます。 


## <a name="responsive-layouts"></a>レスポンシブ レイアウト

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="screen-sizes-and-breakpoints-for-responsive-design.md">
                            <img src="images/landing/breakpoints.png" alt=" " style="display: block; width: 100%; height: auto;" />
                            </a>
                        </div>
                    </div> 
                    <div class="cardText">
                        <h3><a href="screen-sizes-and-breakpoints-for-responsive-design.md">画面のサイズとブレークポイント</a></h3>
                        <p>対象デバイスと、Windows 10 エコシステム全体での画面サイズの数はあまりに多いため、そのそれぞれのために UI を最適化しても意味がありません。 その代わり、いくつかの主要な幅を設計することをお勧めします。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="screen-sizes-and-breakpoints-for-responsive-design.md">
                            <img src="images/landing/reposition.png" alt=" " style="display: block; width: 100%; height: auto;"/>
                            </a>
                        </div>
                    </div>
                    <div class="cardText">
                        <h3><a href="responsive-design.md">レスポンシブ デザインの手法</a></h3>
                        <p>アプリの UI を特定の画面の幅に合わせて最適化することは、レスポンシブ デザインの作成と呼ばれます。 ここでは、アプリの UI のカスタマイズに使用できる 6 種類のレスポンシブ デザイン手法を紹介します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
</ul>

## <a name="pages-and-panels"></a>ページとパネル

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="layouts-with-xaml.md">
                            <img src="images/landing/reposition.png" alt=" " style="display: block; width: 100%; height: auto;"/>
                            </a>
                        </div>
                    </div> -->
                    <div class="cardText">
                        <h3><a href="layouts-with-xaml.md">XAML でのレスポンシブ レイアウトの作成</a></h3>
                        <p>XAML レイアウト パネルを使用して、アプリの応答性と適応性を高める方法を説明します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="layout-panels.md">
                            <img src="images/landing/reposition.png" alt=" " style="display: block; width: 100%; height: auto;"/>
                            </a>
                        </div>
                    </div> -->
                    <div class="cardText">
                        <h3><a href="layout-panels.md">レイアウト パネル</a></h3>
                        <p>各レイアウト パネルの種類を説明し、パネルを使って XAML UI 要素をレイアウトする方法について説明します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>    
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="grid-tutorial.md">
                            <img src="images/landing/reposition.png" alt=" " style="display: block; width: 100%; height: auto;"/>
                            </a>
                        </div>
                    </div> -->
                    <div class="cardText">
                        <h3><a href="grid-tutorial.md">Grid と StackPanel を使ったレイアウトを作成する</a></h3>
                        <p>ここでは、XAML の Grid 要素と StackPanel 要素を使って単純な天気予報アプリのレイアウトを作成します。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>  
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="alignment-margin-padding.md">
                            <img src="images/landing/breakpoints.png" alt=" " style="display: block; width: 100%; height: auto;" />
                            </a>
                        </div>
                    </div>  -->
                    <div class="cardText">
                        <h3><a href="alignment-margin-padding.md">配置、余白、パディング</a></h3>
                        <p>サイズのプロパティ (幅、高さ、および制約) に加え、要素は、配置、余白、パディングのプロパティも含むことができ、これらは、要素がレイアウト パスに移動し、UI に表示されるときにレイアウト動作に影響を与えます。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>

</ul>


## <a name="windows-and-views"></a>Windows とビュー

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="show-multiple-views.md">
                            <img src="images/landing/breakpoints.png" alt=" " style="display: block; width: 100%; height: auto;" />
                            </a>
                        </div>
                    </div>  -->
                    <div class="cardText">
                        <h3><a href="show-multiple-views.md">複数のビューの表示</a></h3>
                        <p>アプリの独立した部分を別々のウィンドウで表示できます。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>

</ul>

## <a name="transformations"></a>変換

<ul class="panelContent cardsH" style="margin-left: 1px">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <div class="card">
                    <!-- <div class="cardImageOuter">
                        <div class="cardImage">
                        <a href="show-multiple-views.md">
                            <img src="images/landing/breakpoints.png" alt=" " style="display: block; width: 100%; height: auto;" />
                            </a>
                        </div>
                    </div>  -->
                    <div class="cardText">
                        <h3><a href="transforms.md">回転、ずれ、スケール、その他の変換</a></h3>
                        <p>回転、ずれ、スケールの各要素に変換を使用します。 2-D コンテンツを 3-D に見えるように変換を使用することもできます。</p>
                    </div>
                </div>
            </div>
        </div>
    </li>

</ul>



