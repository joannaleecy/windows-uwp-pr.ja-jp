---
author: QuinnRadich
Description: Learn how to use page transitions in your UWP apps.
title: UWP アプリのページ切り替え効果
template: detail.hbs
ms.author: quradic
ms.date: 04/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: stmoy
ms.localizationpriority: medium
ms.openlocfilehash: 0afc2c55ab0d0bdd2bee0206f986b2724d331eaf
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4019786"
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

**注**: [**フレーム**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame)は自動的に [**NavigationThemeTransition**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationthemetransition) を使用して 2 つのページ間のナビゲーションをアニメーション化します。 既定では、アニメーションはページの更新です。

## <a name="drill"></a>ドリル

ドリルは、項目を選択した後で詳細情報を表示するなど、ユーザーがアプリ内でより深く移動するときに使用します。

ユーザーがアプリ内をより深く移動したという意識を持てるようにします。

![ドリルのアニメーション](images/drill.gif)

ドリルのアニメーションは、[**DrillInNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) クラスで表されます。

```csharp
// Play the drill in animation
myFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
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

- [2 つのページ間の移動](../basics/navigate-between-two-pages.md)
- [UWP アプリのモーション](index.md)
