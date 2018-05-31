---
author: serenaz
Description: Learn how to use page transitions in your UWP apps.
title: UWP アプリのページ切り替え効果
template: detail.hbs
ms.author: sezhen
ms.date: 04/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
pm-contact: stmoy
ms.localizationpriority: medium
ms.openlocfilehash: dc42199eba00071f5dbabd83a4ae524298a619ee
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1818436"
---
# <a name="page-transitions"></a>ページ切り替え効果

ページ切り替え効果は、ユーザーがアプリ内のページ間を移動するときに再生されるアニメーションです。 ページ切り替え効果により、ナビゲーション階層の最上位にいるのか、兄弟ページ間を移動しているのか、またはページ階層をより深く移動しているのかを、ユーザーが理解しやすくなります。

アプリ内のページ間のナビゲーションについて 2 つの異なるアニメーション (*ページの更新*および*ドリル*) が提供されており、[NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo)のサブクラスとして表されています。

## <a name="page-refresh"></a>ページの更新

ページの更新は、受信したコンテンツのスライド アップ アニメーションとフェード イン アニメーションの組み合わせです。 ユーザーが処理を開始したという意識を持てるようにします。

ページの更新は、ユーザーがナビゲーション スタックの最上位に移動したときに使用します ([タブ](../controls-and-patterns/tabs-pivot.md) 間や[左側のナビゲーション](../controls-and-patterns/navigationview.md)の項目間の移動など)。 既定では、[Frame.Navigate()](/uwp/api/windows.ui.xaml.controls.frame.navigate)はページの更新を使用します。

![ページの更新のアニメーション](images/page-refresh.gif)

ページの更新のアニメーションは、[EntranceNavigationTransitionInfoClass](/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo) で表されます。

```csharp
// Explicitly play the page refresh animation
myFrame.Navigate(typeof(Page2), null, new EntranceNavigationTransitionInfo());
```

## <a name="drill"></a>ドリル

ドリルは、項目を選択した後で詳細情報を表示するなど、ユーザーがアプリ内でより深く移動するときに使用します。

ユーザーがアプリ内をより深く移動したという意識を持てるようにします。

![ドリルのアニメーション](images/drill.gif)

ドリルのアニメーションは、[DrillInNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) クラスで表されます。

```csharp
// Play the drill in animation
myFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
```

## <a name="suppress"></a>抑制

アニメーションの抑制は、[接続型アニメーション](connected-animation.md)または暗黙的な表示/非表示アニメーションを使用して独自の切り替え効果を作成している場合に役立ちます。

ナビゲーション中にアニメーションの再生を回避するには、[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を他の [NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo) サブタイプの代わりに使用します。

```csharp
// Suppress the default animation
myFrame.Navigate(typeof(Page2), null, new SuppressNavigationTransitionInfo());
```

## <a name="backwards-navigation"></a>逆方向のナビゲーション

既定では、[Frame.GoBack()](/uwp/api/windows.ui.xaml.controls.frame.goback) は、ページへの移動時に再生されるアニメーションに基づいて、対応する "戻る" アニメーションを再生します。 たとえば、ページへの移動にドリルを使用するアプリでは、ユーザーが逆方向に移動するときにドリルアウトが表示されます。

逆方向に移動するときに特定の切り替え効果を再生するには、`Frame.GoBack(NavigationTransitionInfo)` を使用します。 これは、たとえば応答性の高いマスター/詳細シナリオなど、画面サイズに基づいて移動動作を動的に変更する場合に役立ちます。

## <a name="related-topics"></a>関連トピック

- [2 つのページ間の移動](../basics/navigate-between-two-pages.md)
- [UWP アプリのモーション](index.md)
