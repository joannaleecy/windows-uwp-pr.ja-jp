---
author: QuinnRadich
description: ユーザーが評価の確認と設定を行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。
title: 評価コントロール
template: detail.hbs
ms.author: quradic
ms.date: 10/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
pm-contact: abarlow
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 242ecdaf128e1e01b1bdeac4cce649504b8efc74
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4155037"
---
# <a name="rating-control"></a>評価コントロール

評価コントロールでは、ユーザーが評価の確認と設定を行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。 ユーザーはタッチ、ペン、マウス、ゲームパッド、キーボードで評価コントロールを操作できます。 次のガイダンスでは、評価コントロールの機能を使用して、柔軟性とカスタマイズを提供する方法を示します。

> **重要な API**: [RatingControl クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingcontrol)

![評価コントロールの例](images/rating_rs2_doc_ratings_intro.png)

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RatingControl">アプリを開き、RatingControl の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

### <a name="editable-rating-with-placeholder-value"></a>編集可能な評価とプレースホルダーの値

おそらく、最も一般的な評価コントロールの使用方法は、平均評価値を表示した状態で、ユーザーが自分の評価値を入力できるようにすることです。 このシナリオでは、評価コントロールは最初、特定のサービスまたは特定の種類のコンテンツ (音楽、ビデオ、書籍など) のユーザー全員の平均満足度を反映するように設定されています。 ユーザーが個別に項目を評価する目的でコントロールを操作するまで、この状態は変わりません。 この操作によって、評価コントロールの状態が変化して、ユーザー個人の満足度評価が反映されます。

#### <a name="initial-average-rating-state"></a>初期の平均評価値状態
![初期の平均評価値状態](images/rating_rs2_doc_movie_aggregate.png)

#### <a name="representation-of-user-rating-once-set"></a>ユーザー評価が設定された後の表示

![ユーザー評価が設定された後の表示](images/rating_rs2_doc_movie_user.png)

```XAML
<RatingControl x:Name="MyRating" ValueChanged="RatingChanged"/>
```

```csharp
private void RatingChanged(RatingControl sender, object args)
{
    if (sender.Value == null)
    {
        MyRating.Caption = "(" + SomeWebService.HowManyPreviousRatings() + ")";
    }

    else
    {
        MyRating.Caption = "Your rating";
    }
}
```

### <a name="read-only-rating-mode"></a>読み取り専用評価モード

お勧めのコンテンツに表示されているコンテンツの評価を表示する場合や、コメントの一覧とそれに対応する評価を表示する場合など、セカンダリ コンテンツの評価の表示が必要な場合があります。 この場合、ユーザーは評価を編集できてはならないため、コントロールを読み取り専用にします。
また、読み取り専用モードは、UI 設計とパフォーマンスの両方の理由から、仮想化された大きなコンテンツ一覧で評価コントロールを使用する場合にも推奨されています。

![読み取り専用の長い一覧](images/rating_rs2_doc_reviews.png)

これを行うには、以下のようにします。

```XAML
<RatingControl IsReadOnly="True"/>
```

## <a name="additional-functionality"></a>追加機能

評価コントロールでは、多くの追加機能が使用できます。 これらの機能の使用方法について詳しくは、MSDN のリファレンス ドキュメントをご覧ください。
追加機能の一部を次に示します。
-   長い一覧での優れたパフォーマンス
-   狭い UI シナリオにおけるコンパクト サイズでの表示
-   継続的な値の入力と評価
-   間隔カスタマイズ
-   増加アニメーションの無効化
-   星の数のカスタマイズ

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。