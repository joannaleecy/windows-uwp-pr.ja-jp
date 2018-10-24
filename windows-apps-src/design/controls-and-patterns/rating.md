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
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5441134"
---
# <a name="rating-control"></a><span data-ttu-id="6a45a-104">評価コントロール</span><span class="sxs-lookup"><span data-stu-id="6a45a-104">Rating control</span></span>

<span data-ttu-id="6a45a-105">評価コントロールでは、ユーザーが評価の確認と設定を行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。</span><span class="sxs-lookup"><span data-stu-id="6a45a-105">The rating control allows users to view and set ratings that reflect degrees of satisfaction with content and services.</span></span> <span data-ttu-id="6a45a-106">ユーザーはタッチ、ペン、マウス、ゲームパッド、キーボードで評価コントロールを操作できます。</span><span class="sxs-lookup"><span data-stu-id="6a45a-106">Users can interact with the rating control with touch, pen, mouse, gamepad or keyboard.</span></span> <span data-ttu-id="6a45a-107">次のガイダンスでは、評価コントロールの機能を使用して、柔軟性とカスタマイズを提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="6a45a-107">The follow guidance shows how to use the rating control's features to provide flexibility and customization.</span></span>

> <span data-ttu-id="6a45a-108">**重要な API**: [RatingControl クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingcontrol)</span><span class="sxs-lookup"><span data-stu-id="6a45a-108">**Important APIs**: [RatingControl class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingcontrol)</span></span>

![評価コントロールの例](images/rating_rs2_doc_ratings_intro.png)

## <a name="examples"></a><span data-ttu-id="6a45a-110">例</span><span class="sxs-lookup"><span data-stu-id="6a45a-110">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="6a45a-111">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="6a45a-111">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="6a45a-112"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RatingControl">アプリを開き、RatingControl の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="6a45a-112">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/RatingControl">open the app and see the RatingControl in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="6a45a-113">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="6a45a-113">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="6a45a-114">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="6a45a-114">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

### <a name="editable-rating-with-placeholder-value"></a><span data-ttu-id="6a45a-115">編集可能な評価とプレースホルダーの値</span><span class="sxs-lookup"><span data-stu-id="6a45a-115">Editable rating with placeholder value</span></span>

<span data-ttu-id="6a45a-116">おそらく、最も一般的な評価コントロールの使用方法は、平均評価値を表示した状態で、ユーザーが自分の評価値を入力できるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="6a45a-116">Perhaps the most common way to use the rating control is to display an average rating while still allowing the user to enter their own rating value.</span></span> <span data-ttu-id="6a45a-117">このシナリオでは、評価コントロールは最初、特定のサービスまたは特定の種類のコンテンツ (音楽、ビデオ、書籍など) のユーザー全員の平均満足度を反映するように設定されています。</span><span class="sxs-lookup"><span data-stu-id="6a45a-117">In this scenario, the rating control is initially set to reflect the average satisfaction rating of all users of a particular service or type of content (such as a music, videos, books, etc.).</span></span> <span data-ttu-id="6a45a-118">ユーザーが個別に項目を評価する目的でコントロールを操作するまで、この状態は変わりません。</span><span class="sxs-lookup"><span data-stu-id="6a45a-118">It remains in this state until a user interacts with the control with the goal of individually rating an item.</span></span> <span data-ttu-id="6a45a-119">この操作によって、評価コントロールの状態が変化して、ユーザー個人の満足度評価が反映されます。</span><span class="sxs-lookup"><span data-stu-id="6a45a-119">This interaction changes the state of the ratings control to reflect the user's personal satisfaction rating.</span></span>

#### <a name="initial-average-rating-state"></a><span data-ttu-id="6a45a-120">初期の平均評価値状態</span><span class="sxs-lookup"><span data-stu-id="6a45a-120">Initial average rating state</span></span>
![初期の平均評価値状態](images/rating_rs2_doc_movie_aggregate.png)

#### <a name="representation-of-user-rating-once-set"></a><span data-ttu-id="6a45a-122">ユーザー評価が設定された後の表示</span><span class="sxs-lookup"><span data-stu-id="6a45a-122">Representation of user rating once set</span></span>

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

### <a name="read-only-rating-mode"></a><span data-ttu-id="6a45a-124">読み取り専用評価モード</span><span class="sxs-lookup"><span data-stu-id="6a45a-124">Read-only rating mode</span></span>

<span data-ttu-id="6a45a-125">お勧めのコンテンツに表示されているコンテンツの評価を表示する場合や、コメントの一覧とそれに対応する評価を表示する場合など、セカンダリ コンテンツの評価の表示が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="6a45a-125">Sometimes you need to show ratings of secondary content, such as that displayed in recommended content or when displaying a list of comments and their corresponding ratings.</span></span> <span data-ttu-id="6a45a-126">この場合、ユーザーは評価を編集できてはならないため、コントロールを読み取り専用にします。</span><span class="sxs-lookup"><span data-stu-id="6a45a-126">In this case, the user shouldn’t be able to edit the rating, so you can make the control read-only.</span></span>
<span data-ttu-id="6a45a-127">また、読み取り専用モードは、UI 設計とパフォーマンスの両方の理由から、仮想化された大きなコンテンツ一覧で評価コントロールを使用する場合にも推奨されています。</span><span class="sxs-lookup"><span data-stu-id="6a45a-127">The read only mode is also the recommended way of using the rating control when it is used in very large virtualized lists of content, for both UI design and performance reasons.</span></span>

![読み取り専用の長い一覧](images/rating_rs2_doc_reviews.png)

<span data-ttu-id="6a45a-129">これを行うには、以下のようにします。</span><span class="sxs-lookup"><span data-stu-id="6a45a-129">To do this you would do the following:</span></span>

```XAML
<RatingControl IsReadOnly="True"/>
```

## <a name="additional-functionality"></a><span data-ttu-id="6a45a-130">追加機能</span><span class="sxs-lookup"><span data-stu-id="6a45a-130">Additional functionality</span></span>

<span data-ttu-id="6a45a-131">評価コントロールでは、多くの追加機能が使用できます。</span><span class="sxs-lookup"><span data-stu-id="6a45a-131">The rating control has many additional features which can be used.</span></span> <span data-ttu-id="6a45a-132">これらの機能の使用方法について詳しくは、MSDN のリファレンス ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6a45a-132">Details for using these features can be found in our MSDN reference documentation.</span></span>
<span data-ttu-id="6a45a-133">追加機能の一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6a45a-133">Here is a non-comprehensive list of additional functionality:</span></span>
-   <span data-ttu-id="6a45a-134">長い一覧での優れたパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="6a45a-134">Great long list performance</span></span>
-   <span data-ttu-id="6a45a-135">狭い UI シナリオにおけるコンパクト サイズでの表示</span><span class="sxs-lookup"><span data-stu-id="6a45a-135">Compact sizing for tight UI scenarios</span></span>
-   <span data-ttu-id="6a45a-136">継続的な値の入力と評価</span><span class="sxs-lookup"><span data-stu-id="6a45a-136">Continuous value fill and rating</span></span>
-   <span data-ttu-id="6a45a-137">間隔カスタマイズ</span><span class="sxs-lookup"><span data-stu-id="6a45a-137">Spacing customization</span></span>
-   <span data-ttu-id="6a45a-138">増加アニメーションの無効化</span><span class="sxs-lookup"><span data-stu-id="6a45a-138">Disable growth animations</span></span>
-   <span data-ttu-id="6a45a-139">星の数のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="6a45a-139">Customization of the number of stars</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="6a45a-140">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="6a45a-140">Get the sample code</span></span>

- <span data-ttu-id="6a45a-141">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="6a45a-141">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>