---
author: jwmsft
title: 関係ベース アニメーション
description: 別のオブジェクトのプロパティに基づいくモーションを作成します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: cde3868d1a554396bfda7c13ea0c71bd037416bc
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5748355"
---
# <a name="relation-based-animations"></a>関係ベース アニメーション

この記事では、Composition の ExpressionAnimation を使用して関係ベース アニメーションを作成する方法の概要ついて説明します。

## <a name="dynamic-relation-based-experiences"></a>動的な関係ベースのエクスペリエンス

アプリのモーション エクスペリエンスを作成するとき、モーションが時間ベースではなく、他のオブジェクトのプロパティに影響される場合があります。 KeyFrameAnimations では、このような種類のモーション エクスペリエンスを簡単に表現することはできません。 こうした場合、モーションを独立したものとして作成したり、事前に定義したりする必要はありません。 代わりに、モーションと他のオブジェクトのプロパティとの関係に基づいて、モーションを動的に対応させることができます。 たとえば、水平方向の位置に基づいてオブジェクトの不透明度をアニメーション化することができます。 他の例としては、固定ヘッダーや視差などのモーション エクスペリエンスがあります。

これらの種類のモーション エクスペリエンスを使用すると、単一で独立して動作する UI ではなく、関連性の強い動作を示す UI を作成することができます。 ユーザーに対しては、動的な UI エクスペリエンスの印象を与えます。

![軌道を回る円](images/animation/orbit.gif)

![視差を利用したリスト ビュー](images/animation/parallax.gif)

## <a name="using-expressionanimations"></a>ExpressionAnimation の使用

関係ベースのモーション エクスペリエンスを作成するには、ExpressionAnimation という種類のアニメーションを使用します。 ExpressionAnimation (短く示す場合は Expression) は新しい種類のアニメーションで、数学的な関係を表すことができます。数学的な関係とは、各フレームでアニメーション化するプロパティの値を計算する際にシステムで使用される関係です。 言い換えれば、Expression は、各フレームでアニメーション化するプロパティの目的の値を定義する単純な方程式です。 Expression は用途の広いコンポーネントで、次のようなさまざまなシナリオで使用できます。

- 相対サイズ、オフセット アニメーション。
- ScrollViewer を使用した固定ヘッダーや視差  (「[既存の ScrollViewer エクスペリエンスを強化する](scroll-input-animations.md)」をご覧ください)。
- InertiaModifier と InteractionTracker を使用したスナップ位置  (「[慣性修飾子を使用したスナップ位置の作成](inertia-modifiers.md)」をご覧ください)。

ExpressionAnimation を使用するときは、以下の点について留意してください。

- 終了しない – KeyFrameAnimation とは異なり、Expression には限定された継続時間はありません。 Expression は数学的な関係であるため、継続して "実行されている" アニメーションとなります。 必要な場合は、こうしたアニメーションを停止するオプションを使用できます。
- 継続して実行されているが、常に評価されるわけではない – パフォーマンスは、継続して実行されているアニメーションと常に関連する懸念事項です。 ただし、心配する必要はありません。Expression はいずれかの入力またはパラメーターが変更された場合にのみ再評価されるということを、システムでは自動的に把握するためです。
- 適切なオブジェクトの種類への解決 – Expression は数学的な関係であるため、Expression ではアニメーションのターゲットとなるプロパティと同じ種類のプロパティへの解決が行われることを式で定義することが重要となります。 たとえば、オフセットをアニメーション化する場合、Expression では Vector3 の種類に解決する必要があります。

### <a name="components-of-an-expression"></a>Expression のコンポーネント

Expression の数学的な関係を構築する際に利用できる主なコンポーネントには、以下のものがあります。

- パラメーター – 定数値または他のコンポジション オブジェクトへの参照を表す値です。
- 数学演算子 – 式を構成するためにパラメーターを結合する一般的な数学演算子 (加算 (+)、減算 (-)、乗算 (*)、除算 (/)) です。 条件演算子 (より大きい (>)、等しい (==) など) や、三項演算子 (condition ?  ifTrue : ifFalse) なども含まれます。
- 数学関数 – System.Numerics に基づく数学関数/数学ショートカットです。 サポートされる関数の完全な一覧については、「[ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation)」をご覧ください。

Expression では一連のキーワードもサポートされています。キーワードとは、ExpressionAnimation システム内でのみ使われる独自の意味を持つ特別な語句です。 これらのキーワードの一覧 (および数学関数の完全な一覧) については、「[ExpressionAnimation](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.ExpressionAnimation)」の説明をご覧ください。

### <a name="creating-expressions-with-expressionbuilder"></a>ExpressionBuilder を使用して Expression を作成する

UWP アプリで Expression を作成するには、2 つの方法があります。

1. 公式のパブリック API を使用し、文字列として式を作成する。
1. オープンソースの ExpressionBuilder ツールを使用し、タイプ セーフなオブジェクト モデルで式を作成する。 [Github のソースとドキュメント](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/ExpressionBuilder)をご覧ください。

このドキュメントのために、ここでは ExpressionBuilder を使用して Expression を定義します。

### <a name="parameters"></a>パラメーター

パラメーターは、Expression の重要な部分を構成します。 パラメーターには次の 2 種類があります。

- 定数: 型指定された System.Numeric 変数を表すパラメーターです。 これらのパラメーターは、アニメーションが開始されたときに割り当てられる値を取得します。
- 参照: CompositionObject への参照を表すパラメーターです。これらのパラメーターは、アニメーションが開始された後で更新された値を継続的に取得します。

一般的に参照は、Expression の出力が動的に変更される方法に関連する主要な側面となります。 参照が変更されると、その結果に伴って Expression の出力も変更されます。 String を使用して Expression を作成する場合、またはテンプレートのシナリオで String を使用する場合 (複数の CompositionObject をターゲットとする Expression を使用)、パラメーターの名前を指定し、その値を設定する必要があります。 詳しくは、「例」セクションをご覧ください。

### <a name="working-with-keyframeanimations"></a>KeyFrameAnimation の操作

Expression は、KeyFrameAnimation と共にも使用することもできます。 このような場合、ある時点での KeyFrame の値を定義する Expression を使用する必要があります。このような種類の KeyFrame は、ExpressionKeyFrame と呼ばれます。

```csharp
KeyFrameAnimation.InsertExpressionKeyFrame(Single, String)
KeyFrameAnimation.InsertExpressionKeyFrame(Single, ExpressionNode)
```

ただし ExpressionAnimation とは異なり、ExpressionKeyFrame は KeyFrameAnimation の起動時に 1 回だけ評価されます。 ExpressionAnimation を KeyFrame の値として渡すのではなく、文字列 (または ExpressionBuilder を使用している場合は ExpressionNode) として渡すという点に注意してください。

## <a name="example"></a>例

Expression を使用した例を確認してみましょう。具体的には、Windows UI サンプル ギャラリーの PropertySet の例を紹介します。 ここでは、軌道を回る青い円のモーションの動作を管理する Expression について説明します。

![軌道を回る円](images/animation/orbit.gif)

エクスペリエンス全体では、3 つのコンポーネントが使用されています。

1. KeyFrameAnimation。赤い円の Y オフセットをアニメーション化しています。
1. 軌道の周回を駆動する際に利用される **Rotation** プロパティを含んでいる PropertySet。他の KeyFrameAnimation によってアニメーション化されます。
1. 青い円のオフセットを駆動する ExpressionAnimation。赤い円のオフセットと Rotation プロパティを参照して、完全な軌道の周回を維持します。

3. で定義されている ExpressionAnimation に注目します。 また、ExpressionBuilder クラスも使用した、この Expression の作成も行います。 String を使用してこのエクスペリエンスを作成するためのコードのコピーが、最後に記載されています。

この式では、PropertySet から参照する必要がある 2 つのプロパティが使用されています。1 つは中心点のオフセット、もう 1 つは回転です。

```
var propSetCenterPoint =
_propertySet.GetReference().GetVector3Property("CenterPointOffset");

// This rotation value will animate via KFA from 0 -> 360 degrees
var propSetRotation = _propertySet.GetReference().GetScalarProperty("Rotation");
```

次に、実際の起動の周回を構成する Vector3 コンポーネントを定義する必要があります。

```
var orbitRotation = EF.Vector3(
    EF.Cos(EF.ToRadians(propSetRotation)) * 150,
    EF.Sin(EF.ToRadians(propSetRotation)) * 75, 0);
```

> [!NOTE]
> `EF` は、ExpressionBuilder.ExpressionFunctions を定義する “using” 表記の短縮形です。

最後に、これらのコンポーネントを一緒に組み合わせ、赤い円の位置を参照して、数学的な関係を定義します。

```
var orbitExpression = redSprite.GetReference().Offset + propSetCenterPoint + orbitRotation;
blueSprite.StartAnimation("Offset", orbitExpression);
```

これと同じ Expression を使用するが、2 つの他の Visual (軌道を回る円の 2 つのセット) を使うと仮定した場合は、どうすればよいでしょうか。 CompositionAnimation を使用すると、アニメーションを再利用し、複数の CompositionObject をターゲットにすることができます。 この Expression を使用して軌道周回のケースを追加する場合、変更する必要があるのは、Visual への参照だけです。 これをテンプレート化と呼びます。

この場合、前に作成した Expression を変更します。 CompositionObject への参照を "取得" するのではなく、名前を指定して参照を作成し、異なる値を割り当てます。

```
var orbitExpression = ExpressionValues.Reference.CreateVisualReference("orbitRoundVisual");
orbitExpression.SetReferenceParameter("orbitRoundVisual", redSprite);
blueSprite.StartAnimation("Offset", orbitExpression);
// Later on … use same Expression to assign to another orbiting Visual
orbitExpression.SetReferenceParameter("orbitRoundVisual", yellowSprite);
greenSprite.StartAnimation("Offset", orbitExpression);
```

パブリック API 経由で String を使用して Expression を定義する場合のコードを次に示します。

```
ExpressionAnimation expressionAnimation =
compositor.CreateExpressionAnimation("visual.Offset + " +
"propertySet.CenterPointOffset + " +
"Vector3(cos(ToRadians(propertySet.Rotation)) * 150," + "sin(ToRadians(propertySet.Rotation)) * 75, 0)");
 var propSetCenterPoint = _propertySet.GetReference().GetVector3Property("CenterPointOffset");
 var propSetRotation = _propertySet.GetReference().GetScalarProperty("Rotation");
expressionAnimation.SetReferenceParameter("propertySet", _propertySet);
expressionAnimation.SetReferenceParameter("visual", redSprite);
```
