---
author: scottmill
ms.assetid: 386faf59-8f22-2e7c-abc9-d04216e78894
title: コンポジションのアニメーション
description: コンポジション オブジェクトと効果の多くのプロパティは、キー フレーム アニメーションや数式アニメーションを使って、時間の経過や計算に基づいて UI 要素のプロパティを変更することによりアニメーション化できます。
---
# コンポジションのアニメーション

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

コンポジション オブジェクトと効果の多くのプロパティは、キー フレーム アニメーションや数式アニメーションを使って、時間の経過や計算に基づいて UI 要素のプロパティを変更することによりアニメーション化できます。 アニメーションには、[**KeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706830) クラスによって表されるキー フレーム アニメーションと、[**ExpressionAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706817) クラスによって表される数式アニメーションの 2 種類があります。

-   [アニメーション化が可能なプロパティ](./composition-animation.md#animatable_properties)
-   [キー フレーム アニメーション](./composition-animation.md#keyframe-animations)
    -   [アニメーションとキー フレームの管理](./composition-animation.md#creating-your-animation-and-Keyframes)
    -   [キー フレームのプロパティ](./composition-animation.md#keyframe-properties)
    -   [イージング関数](./composition-animation.md#easing-functions)
    -   [キー フレーム アニメーションの開始と停止](./composition-animation.md#starting-and-stopping-keyframe-animations)
    -   [アニメーション完了イベント](./composition-animation.md#animation-completion-events)
-   [数式アニメーション](./composition-animation.md#expression-animations)
    -   [数式の作成](./composition-animation.md#creating-your-expression)
    -   [プロパティ セット](./composition-animation.md#property-sets)
    -   [数式キー フレーム](./composition-animation.md#expression_keyframes)

## アニメーション化が可能なプロパティ

次のプロパティは、キー フレーム アニメーションまたは数式アニメーションに関連付けることによってアニメーション化されます。

-   CompositionColorBrush.Color
-   InsetClip.BottomInset
-   InsetClip.LeftInset
-   InsetClip.RightInset
-   InsetClip.TopInset
-   Visual.AnchorPoint
-   Visual.CenterPoint
-   Visual.Offset
-   Visual.Opacity
-   Visual.Orientation
-   Visual.RotationAngle
-   Visual.RotationAxis
-   Visual.Size
-   Visual.TransformMatrix
-   CompositionPropertySet

## キー フレーム アニメーション

キー フレーム アニメーションは時間に基づくアニメーションで、1 つまたは複数のキー フレームを使って時間の経過と共にアニメーション化された値を変更する方法を指定します。 フレームはマーカーを表し、アニメーション化された値が特定の時点でどのようになるかを定義できます。

### アニメーションとキー フレームの管理

キー フレーム アニメーションを作成するには、アニメーション化するプロパティの構造体の種類に関連付けられたコンポジター クラスのコンストラクター メソッドのいずれかを使います。

-   [**CreateColorKeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt589424)
-   [**CreateQuaternionKeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt517858)
-   [**CreateScalarKeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706803)
-   [**CreateVector2KeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706806)
-   [**CreateVector3KeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706807)
-   [**CreateVector4KeyFrameAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706808)

たとえば、次のスニペットは、Vector3 キー フレーム アニメーションを作成します。

```cs
var animation = _compositor.CreateVector3KeyFrameAnimation();
```

各キー フレームは、KeyFrameAnimation の InsertKeyFrame メソッドを呼び出して、2 つのコンポーネントと、必要に応じて 3 つ目のコンポーネントを指定することにより作成されます。

-   時間: 正規化されたキー フレームの進行状況 (0.0 ～ 1.0)
-   値: 特定の時間状態でのアニメーション化する値の特定の値
-   (省略可能) イージング関数: 前のキー フレームと現在のキー フレームの間の補間を記述する関数 (後で説明します)。

たとえば、次のスニペットは、アニメーションの半分の時点でトリガーされるキー フレームを Vector3KeyFrameAnimation に挿入します。

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f));
```

### キー フレームのプロパティ

キー フレーム アニメーションと個々のキー フレームを定義すると、アニメーションの複数のプロパティを定義できます。

-   DelayTime: StartAnimation() が呼び出されてからアニメーションが開始されるまでの時間
-   Duration: アニメーションの継続時間
-   IterationBehavior: アニメーションの繰り返し動作の回数または無制限
-   IterationCount: キー フレーム アニメーションが繰り返される有限の回数
-   KeyFrame Count: 特定の KeyFrameAnimation のキー フレームの数
-   StopBehavior: StopAnimation が呼び出されたときのアニメーションのプロパティ値の動作を指定します。

たとえば、次のスニペットは、アニメーションの継続時間を 5 秒に設定します。

```cs
animation.Duration = TimeSpan.FromSeconds(5);
```

### イージング関数

キー フレーム イージング関数 CompositionEasingFunction は、前のキー フレーム値から現在のキー フレーム値への中間値の進行状況を指定します。 キーフレームのイージング関数を指定しない場合、既定の曲線が使用されます。

2 種類のイージング関数がサポートされています。

-   線形 ([**LinearEasingFunction**](https://msdn.microsoft.com/library/windows/apps/Dn706839))
-   3 次ベジエ ([**CubicBezierEasingFunction**](https://msdn.microsoft.com/library/windows/apps/Dn706812))

イージング関数を作成するには、[**Compositor**](https://msdn.microsoft.com/library/windows/apps/Dn706761) クラスの [**CreateLinearEasingFunction**](https://msdn.microsoft.com/library/windows/apps/Dn706801) メソッドまたは [**CreateCubicBezierEasingFunction**](https://msdn.microsoft.com/library/windows/apps/Dn706791) メソッドを使います。

```cs
var linear = _compositor.CreateLinearEasingFunction();
var easeIn = _compositor.CreateCubicBezierEasingFunction(new Vector2(0.5f, 0.0f), new Vector2(1.0f, 1.0f));
```

注: 3 次ベジエの点を生成するのに便利なツールはここにあります。

イージング関数をキー フレームに追加するには、アニメーションにキー フレームを挿入するときに、3 番目のパラメーターを追加するだけです。

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f), easeIn);
```

### キー フレーム アニメーションの開始と停止

アニメーション、キーフレーム、プロパティを定義したら、アニメーション化するプロパティにアニメーションを接続できます。 プロパティが属する [**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) オブジェクトの [**StartAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt590840) を呼び出して、アニメーション化するプロパティにアニメーションを接続します。

一般的な構文と例は次のとおりです。

```cs
targetVisual.StartAnimation("Offset", animation);
```

アニメーションを開始した後、アニメーションを停止して接続を切断することもできます。 この処理を実行するには、[**StopAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt590841) メソッドを使って、アニメーション化を停止するプロパティを指定します。

次に例を示します。

```cs
targetVisual.StopAnimation("Offset");
```

### アニメーション完了イベント

キー フレーム アニメーションには、条件付きである数式アニメーションとは異なり、定義済みの最後があります。 開発者は、バッチを使用して、グループまたは単一のキー フレーム アニメーションの完了時を決定できます。 バッチは、バッチ オブジェクトの種類に応じて作成または取得することができ、アニメーションの終了状態を集計するために使用されます。 コミット バッチが取得されている間、スコープ指定されたバッチが作成されます。これらのさまざまなバッチの使用については、後で説明します。

バッチ完了イベントは、バッチ内のすべてのアニメーションが完了したときに発生します。 バッチの完了イベントが発生するまでの時間は、バッチ内の最も長い、または最も遅延したアニメーションに依存します。 終了状態の集計は、他の作業をスケジュールするために、選択したアニメーションのグループが完了するタイミングを把握する必要がある場合に便利です。

### スコープ指定されたバッチ

特定のグループまたは 1 つのアニメーションを集計するには、最初に、[**CreateScopedBatch**](https://msdn.microsoft.com/library/windows/apps/Mt589425) を呼び出してスコープ指定されたバッチを作成する必要があります。

```cs
myScopedBatch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
```

スコープ指定されたバッチを作成した後、開始されたすべてのアニメーションは、[**Suspend**](https://msdn.microsoft.com/library/windows/apps/Mt590848) または [**End**](https://msdn.microsoft.com/library/windows/apps/Mt590844) を使って、明示的に中断または停止されるまで集計されます。

[
            **Suspend**](https://msdn.microsoft.com/library/windows/apps/Mt590848) を呼び出すと、[**Resume**](https://msdn.microsoft.com/library/windows/apps/Mt590847) が呼び出されるまで、アニメーションの終了状態の集計は停止します。 これにより、特定のバッチから明示的にコンテンツを除外することができます。

```cs
myScopedBatch.Suspend();
```

バッチを完了するには、[**End**](https://msdn.microsoft.com/library/windows/apps/Mt590844) を呼び出す必要があります。 End を呼び出さない場合、バッチは開いたまま、オブジェクトの収集を継続します。

```cs
myScopedBatch.End();
```

1 つのアニメーションが終了するタイミングを知る必要がある場合は、スコープ指定されたバッチを作成し、アニメーションを開始して、バッチを終了する必要があります。

次に例を示します。

```cs
myScopedBatch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
Visual.StartAnimation("Opacity", myAnimation);
myScopedBatch.End();
```

### コミット バッチ

コミット バッチとは、コミットのサイクル中に暗黙的に作成されるバッチです。 現在のコミット バッチは、コミット サイクル中にいつでも [**GetCommitBatch**](https://msdn.microsoft.com/library/windows/apps/Mt589430) を呼び出すことによって取得できます。 コミット サイクルは、コンポジターからの更新間の時間として定義されています。 更新は、システムが、変更を処理してビットを画面に描画する準備ができるまでキューに配置されます。 タイトルはコミットが発生するタイミングを制御しません。 コミット バッチは、GetCommitBatch が呼び出される前と後の、コミット サイクル内のすべてのオブジェクトを集計します。 コミット サイクルごとにコミット バッチは 1 つだけ存在し、コミット バッチで [**End**](https://msdn.microsoft.com/library/windows/apps/Mt590844) を明示的に呼び出す必要はありません。

```cs
myCommitBatch = _compositor.GetCommitBatch(CompositionBatchTypes.Animation);
```

### バッチの状態

バッチがアニメーションを集計できるかどうかを判断するには、**IsActive** プロパティを使います。 **IsEnded** プロパティが true を返す場合、その特定のバッチにアニメーションを追加することはできません。 スコープ指定されたバッチが "終了済み" になるのは、[**End**](https://msdn.microsoft.com/library/windows/apps/Mt590844) メソッドを呼び出して、バッチを明示的に終了した場合です。 現在のコミット サイクルが終了したときに、コミット バッチは終了します。

## 数式アニメーション

数式アニメーションでは、数式を使って、各フレームのアニメーション化された値を計算する方法を指定します。 式言語自体で、他のコンポジション オブジェクトからプロパティを参照できます。 キー フレーム アニメーションとは異なり、数式は時間ベースではなく、各フレームで処理されます (必要な場合)。 数式は、固定のヘッダーや視差など、合成エンジンによって処理できるをさらに複雑なユーザー エクスペリエンスを記述するのに便利です。

### 数式の作成

数式を作成するには、コンポジター オブジェクトで [**CreateExpressionAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt187002) を呼び出し、使用する数式を指定します。

```cs
var expression = _compositor.CreateExpressionAnimation("INSERT_EXPRESSION_STRING")
```

### 演算子、優先順位、結合性

式言語は次の演算子をサポートしており、演算子の優先順位と結合性は C# 言語の仕様での定義に準拠します。

-   単項 (-)
-   乗算 (\* /)
-   加算 (- +)

式言語では、コンポーネントごとの数学演算の概念もサポートしています。 これらのメンバー アクセス (x.y) 演算子は、"プリミティブ" 型 (ベクターやマトリックス) についてのみサポートされます。 次に例を示します。

```cs
Offset.x + 5.0
```

### プロパティのパラメーター

式言語の強力なコンポーネントの 1 つは、式内の変数としてパラメーターを使用できることです。 式文字列には、計算時に定数値に置き換えられるか、別のオブジェクトのプロパティ値を参照するパラメーターを含めることができます。 次に例を示します。

```cs
ChildVisual.Offset.X / ParentVisual.Offset.Y
```

この例では ChildOffset と ParentOffset は、2 つの視覚効果のオフセット プロパティを表すパラメーターです。 [
            **CompositionAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706708) クラスの **Set\*Parameter** メソッドを使ってパラメーターを定義します。

-   ベクター パラメーターを作成するには、[**SetVector2Parameter**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setvector2parameter.aspx)、[**SetVector3Parameter**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setvector3parameter.aspx)、または [**SetVector4Parameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setvector4parameter) を使います。
-   マトリックス パラメーターを作成するには、[**SetMatrix3x2Parameter**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setmatrix3x2parameter.aspx) または [**SetMatrix4x4Parameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setmatrix4x4parameter) を使います。
-   スカラー パラメーターを作成するには、[**SetScalarParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setscalarparameter) を使います。
-   カラー パラメーターを作成するには、[**SetColorParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setcolorparameter) を使います。
-   四元数パラメーターを作成するには、[**SetQuaternionParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setquaternionparameter) を使います。
-   参照パラメーターを作成するには、[**SetReferenceParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setreferenceparameter) を使います。

上記の式文字列では、2 つの視覚効果を定義する 2 つのパラメーターを作成する必要があります。

```cs
Expression.SetReferenceParameter("ChildVisual", childVisual);
Expression.SetReferenceParameter("ParentVisual", parentVisual);
```

### 式ヘルパー関数

演算子とプロパティ パラメーターにアクセスすることに加え、式言語のヘルパー関数ライブラリ全体にもアクセスできます。 ヘルパー関数の完全な一覧は、[**ExpressionAnimation**](https://msdn.microsoft.com/library/windows/apps/Dn706817) クラスの「注釈」セクションに記載されていますが、ここではいくつかを示します。

-   Max (Scalar value1, Scalar value2)
-   Scale (Vector3 value, Scalar factor)
-   Transform(Vector2 value, Matrix 3x2 matrix)

Clamp ヘルパー関数を使用するより複雑な式文字列の例を次に示します。

```cs
Clamp((scroller.Offset.y * -1.0) - container.Offset.y, 0, container.Size.y - header.Size.y)
```

### 数式アニメーションの開始と停止

数式アニメーションを開始および停止するには、キー フレーム アニメーションの場合と同じ関数 ([**StartAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt590840)、[**StopAnimation**](https://msdn.microsoft.com/library/windows/apps/Mt590841)) を使います。 注: 数式アニメーションは、キー フレーム アニメーションとは異なり、**StopAnimation** を使って停止するまで引き続き実行されます。数式アニメーションには限定された継続時間はありません。

### プロパティ セット

他のコンポジション オブジェクトのプロパティを参照できるだけでなく、複数のアニメーションで使うことができる独自のプロパティ値を作成して保存することもできます。 プロパティ セットは、[**CompositionPropertySet**](https://msdn.microsoft.com/library/windows/apps/Dn706772) クラスによって表されます。 プロパティ セットでは、値を持つプロパティを作成し、後で式で参照したり、キー フレーム アニメーションのターゲットとしてをフックすることもできます。

プロパティ セットを作成するには、コンポジター クラスの [**CreatePropertySet**](https://msdn.microsoft.com/library/windows/apps/Dn706802) メソッドを使います。 次に例を示します。

```cs
_sharedProperties = _compositor.CreatePropertySet();
```

プロパティ セットを作成したら、[**CompositionPropertySet**](https://msdn.microsoft.com/library/windows/apps/Dn706772) の **Insert\*** メソッドの 1 つを使ってプロパティと値を追加できます。 次に例を示します。

```cs
_sharedProperties.InsertVector3("NewOffset", offset);
```

数式アニメーションを作成した後、参照パラメーターを使って式文字列内のプロパティ セットからプロパティを参照できます。 次に例を示します。

```cs
var expression = _compositor.CreateExpressionAnimation("sharedProperties.NewOffset");
expression.SetReferenceParameter("sharedProperties", _sharedProperties);
```

### 数式キー フレーム

このドキュメントで、キー フレーム アニメーションとそれぞれのキーフレームを作成する方法について既に説明しました。 正規化された時間と値のコンポーネントによる従来のキー フレームを作成するだけでなく、数式キー フレームを定義することもできます。

キー フレーム内の特定の時点の明示的な値を定義する代わりに、式の構文を使って、キー フレームのタイムラインのこの特定の時点で、どのように値を計算するかを記述できます。 キー フレーム アニメーション内で数式キー フレームと基本的なキー フレームを混在および調和させることができます。

### 数式キー フレームの作成

従来のキー フレームと同様に、数式キー フレームは次の 2 つのコンポーネントを指定して作成します。

-   時間: 正規化されたキー フレームの時間の状態 (0.0 ～ 1.0)
-   値: 値の計算方法を記述するために使う式文字列

たとえば、次のスニペットは、通常のキー フレームと数式キー フレームの両方の組み合わせを使用します。

```cs
var animation = _compositor.CreateScalarKeyFrameAnimation();
animation.InsertExpressionKeyFrame(0.25, "VisualBOffset.X / VisualAOffset.Y");
animation.InsertKeyFrame(1.00f, 0.8f);
```

### 現在値と開始値の使用

式言語では、アニメーションの現在値と開始値の両方を参照できます。 式言語では、これらの値に "this" というプレフィックスが付けられます。

-   this.CurrentValue
-   this.StartingValue

数式キー フレームでこれらを使う例を次に示します。

```cs
animation.InsertExpressionKeyFrame(0.0f, "this.CurrentValue + delta");
```

### 条件式

基本的な数学式をサポートするだけでなく、3 項演算子を使って条件式を定義することもできます。

```cs
(condition ? first_expression : second_expression)
```

式自体では、条件ステートメントで次の条件演算子がサポートされています。

-   等しい (==)
-   等しくない (!=)
-   より小さい (<)
-   以下 (<=)
-   より大きい (>)
-   以上 (>=)

最後に、条件ステートメント内の演算子や関数として次の要素がサポートされています。

-   Not: ! / Not(bool1)
-   And: && / And(bool1, bool2)
-   Or: || / Or(bool1, bool2)

次のスニペットは、式の中で条件を使う例を示しています。

```cs
var expression = _compositor.CreateExpressionAnimation("target.Offset.x > 50 ? 0.0f +   (target.Offset.x / parent.Offset.x) : 1.0f");
```

 

 






<!--HONumber=May16_HO2-->


