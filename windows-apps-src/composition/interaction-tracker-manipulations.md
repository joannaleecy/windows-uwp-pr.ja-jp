---
title: InteractionTracker を使用したカスタム操作
description: InteractionTracker API を使用して、カスタム操作エクスペリエンスを作成します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 9d2c965bcfbf81efe73ce8aff93cdb8b31163fbd
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8461990"
---
# <a name="custom-manipulation-experiences-with-interactiontracker"></a>InteractionTracker を使用したカスタム操作エクスペリエンス

この記事では、InteractionTracker API を使用して、カスタム操作エクスペリエンスを作成する方法について説明します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [入力駆動型アニメーション](input-driven-animations.md)
- [関係ベース アニメーション](relation-animations.md)

## <a name="why-create-custom-manipulation-experiences"></a>カスタム操作エクスペリエンスを作成する理由

ほとんどの場合、UI エクスペリエンスを作成するには、事前に作成した操作のコントロールを利用するだけで十分です。 ただし、一般的なコントロールと区別する必要がある場合はどうすればよいでしょうか。 また、入力によって動作する特別なエクスペリエンスを作成する必要がある場合や、従来の操作のモーションでは不十分な UI がある場合はどうすればよいでしょうか。 こうした状況に対応するために、カスタム エクスペリエンスが必要となるのです。 カスタム エクスペリエンスによって、アプリの開発者やデザイナーの創造力を高めることができます。ブランドやカスタムのデザイン言語をより適切に表すモーション エクスペリエンスを生み出すことができるようになります。 操作エクスペリエンスを完全にカスタマイズする際に必要となる適切な構成要素のセットは、基本部分から利用することができます。たとえば、指を画面に触れたり画面から離したりした場合の、スナップ位置や入力チェーンに対するモーションの反応などを構成できます。

次に、カスタム操作エクスペリエンスの作成に関する一般的な例をいくつか示します。

- カスタムのスワイプを追加して、動作の削除/非表示を行う
- 入力によって動作する効果 (コンテンツをぼかすためのパン)
- 調整された操作のモーションを使用したカスタム コントロール (カスタムの ListView や ScrollViewer など)

![スワイプによるスクロールの例](images/animation/swipe-scroller.gif)

![引き出されるようなアニメーション化の例](images/animation/pull-to-animate.gif)

## <a name="why-use-interactiontracker"></a>InteractionTracker を使用する理由

InteractionTracker は、SDK バージョン 10586 で Windows.UI.Composition.Interactions 名前空間に導入されました。 InteractionTracker では次のことを実行できます。

- **完全な柔軟性** – 操作エクスペリエンスのすべての側面をカスタマイズし調整することができます。具体的には、入力時または入力に反応して発生するモーションを正確にカスタマイズできます。 InteractionTracker を使用してカスタム操作エクスペリエンスを作成するとき、必要なすべての素材は自由に利用できます。
- **スムーズなパフォーマンス** – 操作エクスペリエンスの課題の 1 つは、そのパフォーマンスが UI スレッドに依存していることです。 このことは、UI がビジー状態の場合に、すべての操作エクスペリエンスに悪影響を及ぼす可能性があります。 InteractionTracker は、独立したスレッド上で 60 FPS で動作し、滑らかな動きを実現する新しいアニメーション エンジンを利用するために作成されました。

## <a name="overview-interactiontracker"></a>概要: InteractionTracker

カスタム操作エクスペリエンスを作成するとき、2 つの主要なコンポーネントを操作できます。 最初にこれらのコンポーネントについて説明します。

- [InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) – アクティブなユーザー入力、直接的な更新、および直接的なアニメーションによって動作するプロパティを持つステート マシンを管理するコア オブジェクトです。 このオブジェクトは、CompositionAnimation と関連付けて、カスタム操作のモーションを作成することを目的としています。
- [VisualInteractionSource](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.visualinteractionsource) – 入力が InteractionTracker に送信されるタイミングや条件を定義する補完オブジェクトです。 ヒット テストや他の入力構成プロパティで使用される CompositionVisual を定義します。

ステート マシンとして、InteractionTracker のプロパティは次のいずれかによって動作します。

- 直接的なユーザー操作 – エンド ユーザーは、VisualInteractionSource ヒット テスト領域内で直接操作を行います。
- 慣性 – プログラムに従った速度やユーザーのジェスチャによって、InteractionTracker のプロパティが慣性曲線に基づいてアニメーション化されます。
- CustomAnimation – InteractionTracker のプロパティを直接ターゲットとするカスタム アニメーションです。

### <a name="interactiontracker-state-machine"></a>InteractionTracker ステート マシン

前述のように、InteractionTracker は、その他の fourstates のいずれかに移行するそれぞれの 4 つの状態を持つステート マシンです。 (InteractionTracker でこれらの状態がどのように遷移するかについて詳しくは、[InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) クラスのドキュメントをご覧ください)。

| 状態 | 説明 |
|-------|-------------|
| アイドル | アクティブになっていません。モーションを発生させる入力やアニメーションがありません。 |
| 操作中 | アクティブなユーザー入力が検出されました。 |
| 慣性 | アクティブな入力やプログラムに従った速度によって、アクティブなモーションが発生しました。 |
| CustomAnimation | カスタム アニメーションによって、アクティブなモーションが発生しました。 |

InteractionTracker での状態遷移の各状況では、リッスンすることができイベント (またはコールバック) が生成されます。 これらのイベントをリッスンするには、[IInteractionTrackerOwner](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.iinteractiontrackerowner) インターフェイスを実装し、CreateWithOwner メソッドを使用して、InteractionTracker オブジェクトを作成する必要があります。 次の図は、さまざまなイベントがトリガーされるタイミングの概要を示しています。

![InteractionTracker ステート マシン](images/animation/interaction-tracker-diagram.png)

## <a name="using-the-visualinteractionsource"></a>VisualInteractionSource の使用

InteractionTracker を入力によって動作させるには、VisualInteractionSource (VIS) を InteractionTracker に関連付ける必要があります。 VIS は補完オブジェクトとして作成され、CompositionVisual を使用して次のことを定義します。

1. 入力が追跡され、座標空間のジェスチャが検出されるヒット テスト領域。
1. 検出されルーティングされる入力の構成。次のようなものがあります。
    - 検出可能なジェスチャー: 位置 X および Y (水平方向および垂直方向のパン)、拡大/縮小 (ピンチ)
    - 慣性
    - レールとチェーン
    - リダイレクト モード: InteractionTracker に自動的にリダイレクトされる入力データの種類

> [!NOTE]
> VisualInteractionSource は、ヒット テストの位置と Visual の座標空間に基づいて作成されるので、動作を表したり、位置を変更する Visual は使用しないことをお勧めします。

> [!NOTE]
> 複数のヒット テスト領域がある場合は、同じ InteractionTracker で複数の VisualInteractionSource インスタンスを使用できます。 ただし、VIS は 1 つだけ使用するのが最も一般的な方法です。

また、VisualInteractionSource では、さまざまな入力方式 (タッチ、PTP、ペン) からの入力データを InteractionTracker にルーティングするタイミングを管理することもできます。 この動作は、ManipulationRedirectionMode プロパティによって定義されます。 既定では、すべてのポインター入力は UI スレッドに送信され、高精度タッチパッドの入力は VisualInteractionSource と InteractionTracker に送信されます。

このため、タッチとペン (Creators Update) で VisualInteractionSource と InteractionTracker を利用して操作を実行する場合は、VisualInteractionSource.TryRedirectForManipulation メソッドを呼び出す必要があります。 以下の XAML アプリの短いスニペットでは、タッチ入力イベントが最上位の UIElement グリッドで発生したときに、メソッドが呼び出されます。

```csharp
private void root_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch)
    {
        _source.TryRedirectForManipulation(e.GetCurrentPoint(root));
    }
}
```

## <a name="tie-in-with-expressionanimations"></a>ExpressionAnimations との関連付け

InteractionTracker を利用して操作エクスペリエンスを実行するとき、主に Scale プロパティと Position プロパティとやり取ります。 他の CompositionObject プロパティと同様に、これらのプロパティは、CompositionAnimation (多くの場合は ExpressionAnimations) でターゲットにされたり、参照されたりする場合があります。

式で InteractionTracker を使用するには、次の例のように、トラッカーの Position (または Scale) プロパティを参照します。 InteractionTracker のプロパティは前に説明した状態に応じて変更されるため、式の出力も変わります。

```csharp
// With Strings
var opacityExp = _compositor.CreateExpressionAnimation("-tracker.Position");
opacityExp.SetReferenceParameter("tracker", _tracker);

// With ExpressionBuilder
var opacityExp = -_tracker.GetReference().Position;
```

> [!NOTE]
> 式で InteractionTracker の位置を参照する場合は、最終的に生成される式で適切な方向への移動を行うための値を無効にする必要があります。 その理由は、InteractionTracker ではグラフの原点から一方向への移動が行われるためです。また、ユーザーが "現実世界" の座標における InteractionTracker の一方向への移動 (原点からの距離など) を考慮することができるためです。

## <a name="get-started"></a>作業の開始

InteractionTracker を使用して、カスタム操作エクスペリエンスの作成を開始するには:

1. InteractionTracker.Create または InteractionTracker.CreateWithOwner を使用して、InteractionTracker オブジェクトを作成します。
    - (CreateWithOwner を使用する場合は、IInteractionTrackerOwner インターフェイスを必ず実装してください)
1. 新しく作成する InteractionTracker の最小位置と最大位置を設定します。
1. CompositionVisual を使用して VisualInteractionSource を作成します。
    - 渡す Visual のサイズが 0 ではないことを確認してください。 0 である場合、ヒット テストが正しく実行されません。
1. VisualInteractionSource のプロパティを設定します。
    - VisualInteractionSourceRedirectionMode
    - PositionXSourceMode、PositionYSourceMode、ScaleSourceMode
    - レールとチェーン
1. InteractionTracker.InteractionSources.Add を使用して、VisualInteractionSource を InteractionTracker に追加します。
1. タッチとペンによる入力が検出された場合に備えて、TryRedirectForManipulation をセットアップします。
    - 通常 XAML では、これは UIElement の PointerPressed イベントで行われます。
1. InteractionTracker の位置を参照し、CompositionObject のプロパティをターゲットにする ExpressionAnimation を作成します。

手順 1. ~ 5. の実行を表す短いコード スニペットを次に示します。

```csharp
private void InteractionTrackerSetup(Compositor compositor, Visual hitTestRoot)
{ 
    // #1 Create InteractionTracker object
    var tracker = InteractionTracker.Create(compositor);

    // #2 Set Min and Max positions
    tracker.MinPosition = new Vector3(-1000f);
    tracker.MaxPosition = new Vector3(1000f);

    // #3 Setup the VisualInteractionSourc
    var source = VisualInteractionSource.Create(hitTestRoot);

    // #4 Set the properties for the VisualInteractionSource
    source.ManipulationRedirectionMode =
        VisualInteractionSourceRedirectionMode.CapableTouchpadOnly;
    source.PositionXSourceMode = InteractionSourceMode.EnabledWithInertia;
    source.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;

    // #5 Add the VisualInteractionSource to InteractionTracker
    tracker.InteractionSources.Add(source);
}
```

InteractionTracker の高度な使用法について詳しくは、次の記事をご覧ください。

- [InertiaModifiers を使用したスナップ位置の作成](inertia-modifiers.md)
- [SourceModifiers を使用した引っ張って更新](source-modifiers.md)
