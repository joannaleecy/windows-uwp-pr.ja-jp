---
Description: UWP アプリでページの切り替え効果を使用する方法について説明します。
title: UWP アプリのページ切り替え効果
template: detail.hbs
ms.date: 04/08/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 38fe6b92828459f91ba6ea2f836d274c2cc8d761
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646457"
---
# <a name="page-transitions"></a>ページ切り替え効果

ページ切り替え効果により、ユーザーがアプリ内のページ間を移動するため、ページ間の関係がフィードバックされます。 ページ切り替え効果により、ナビゲーション階層の最上位にいるのか、兄弟ページ間を移動しているのか、またはページ階層をより深く移動しているのかを、ユーザーが理解しやすくなります。

アプリ内のページ間のナビゲーションについて 2 つの異なるアニメーション (*ページの更新*および*ドリル*) が提供されており、[**NavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo) のサブクラスとして表されています。

## <a name="page-refresh"></a>ページの更新

ページの更新は、受信したコンテンツのスライド アップ アニメーションとフェード イン アニメーションの組み合わせです。 ページの更新は、ユーザーがナビゲーション スタックの最上位に移動したときに使用します (タブ間や左側のナビゲーションの項目間の移動など)。

ユーザーが処理を開始したという意識を持てるようにします。

![ページの更新のアニメーション](images/page-refresh.gif)

ページの更新のアニメーションは、[**EntranceNavigationTransitionInfoClass**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo) で表されます。

```csharp
// Explicitly play the page refresh animation
myFrame.Navigate(typeof(Page2), null, new EntranceNavigationTransitionInfo());

```

**注意**:A [**フレーム**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame)自動的に使用して[ **NavigationThemeTransition** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationthemetransition)を 2 つのページ間のナビゲーションをアニメーション化します。 既定では、アニメーションはページの更新です。

## <a name="drill"></a>ドリル

ドリルは、項目を選択した後で詳細情報を表示するなど、ユーザーがアプリ内でより深く移動するときに使用します。

ユーザーがアプリ内をより深く移動したという意識を持てるようにします。

![ドリルのアニメーション](images/drill.gif)

ドリルのアニメーションは、[**DrillInNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) クラスで表されます。

```csharp
// Play the drill in animation
myFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
```

## <a name="horizontal-slide"></a>水平方向のスライド

水平方向のスライドを使用して、互いの横にある兄弟のページが表示されることを示します。 [NavigationView](../controls-and-patterns/navigationview.md)コントロールでは、上部のナビゲーションでのこのアニメーションを自動的に使用しますが、独自の水平方向のナビゲーション エクスペリエンスを構築する場合するを実装できます SlideNavigationTransitionInfo で水平方向にスライドします。

必要な感情は、ユーザーが互いの横にあるページ間で移動することです。 

```csharp
// Navigate to the right, ie. from LeftPage to RightPage
myFrame.Navigate(typeof(RightPage), null, new SlideNavigationTransitionInfo() { SlideNavigationTransitionEffect.FromRight } );

// Navigate to the left, ie. from RightPage to LeftPage
myFrame.Navigate(typeof(LeftPage), null, new SlideNavigationTransitionInfo() { SlideNavigationTransitionEffect.FromLeft } );
```

## <a name="suppress"></a>抑制

ナビゲーション中にアニメーションの再生を回避するには、[**SuppressNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を他の **NavigationTransitionInfo** サブタイプの代わりに使用します。

```csharp
// Suppress the default animation
myFrame.Navigate(typeof(Page2), null, new SuppressNavigationTransitionInfo());
```

アニメーションの抑制は、[接続型アニメーション](connected-animation.md)または暗黙的な表示/非表示アニメーションを使用して独自の切り替え効果を作成している場合に役立ちます。

## <a name="backwards-navigation"></a>逆方向のナビゲーション

`Frame.GoBack(NavigationTransitionInfo)` を使用して逆方向に移動するときに特定の切り替え効果を再生することができます。

これは、たとえば応答性の高いマスター/詳細シナリオなど、画面サイズに基づいて移動動作を動的に変更する場合に役立ちます。

## <a name="related-topics"></a>関連トピック

- [2 つのページ間を移動します。](../basics/navigate-between-two-pages.md)
- [UWP アプリでのモーション](index.md)
