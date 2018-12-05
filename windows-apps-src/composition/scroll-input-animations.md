---
title: 既存の ScrollViewer エクスペリエンスを強化する
description: XAML の ScrollViewer と ExpressionAnimations を使用して、動的な入力駆動型のモーション エクスペリエンスを作成する方法ついて説明します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10、UWP、アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 118b3f6e306e60d1d8d569f0d58f2d77ea30d9a8
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8736842"
---
# <a name="enhance-existing-scrollviewer-experiences"></a>既存の ScrollViewer エクスペリエンスを強化する

この記事では、XAML の ScrollViewer と ExpressionAnimations を使用して、動的な入力駆動型のモーション エクスペリエンスを作成する方法ついて説明します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [入力駆動型アニメーション](input-driven-animations.md)
- [関係ベース アニメーション](relation-animations.md)

## <a name="why-build-on-top-of-scrollviewer"></a>ScrollViewer の最上位に構築する理由

通常は既存の XAML ScrollViewer を使用して、スクロールとズームが可能なアプリ コンテンツのサーフェスを作成します。 Fluent Design 言語が導入されたことにより、現在では、サーフェスでのスクロールやズームの動作をどのように使用して、他のモーション エクスペリエンスを機能させるかといったことにも重点を置くことができます。 たとえば、スクロールを使用して、背景のぼかしアニメーションを動作させたり、"固定ヘッダー" の位置を動かしたりします。

こうしたシナリオでは、スクロールやズームなどの動作エクスペリエンスまたは操作エクスペリエンスを活用して、アプリの他の部分をより動的なものにすることができます。 これにより、アプリの統一感が向上し、ユーザーにとってより覚えやすいエクスペリエンスを実現することができます。 アプリの UI を覚えやすいものにすることで、エンド ユーザーがそのアプリを利用する頻度が高まり、長期にわたって使用するようになります。

## <a name="what-can-you-build-on-top-of-scrollviewer"></a>ScrollViewer の最上位に構築できるもの

ScrollViewer の位置を利用して、さまざまな動的エクスペリエンスを構築することができます。

- 視差 – ScrollViewer の位置を使用して、背景や前景のコンテンツをスクロール位置に対する相対速度で動かします。
- StickyHeaders – ScrollViewer の位置を使用して、ヘッダーをアニメーション化し、任意の位置に "固定" します。
- 入力駆動型効果 – Scrollviewer の位置を使用して、ぼかしなどのコンポジション効果をアニメーション化します。

一般に、ExpressionAnimation を使用して ScrollViewer の位置を参照することにより、相対的なスクロール量を動的に変化させるアニメーションを作成できます。

![視差を利用したリスト ビュー](images/animation/parallax.gif)

![シャイ ヘッダー](images/animation/shy-header.gif)

## <a name="using-scrollmanipulationpropertyset"></a>ScrollManipulationPropertySet の使用

XAML ScrollViewer を使用して、上記のような動的エクスペリエンスを作成するには、アニメーション内のスクロール位置を参照できるようにする必要があります。 そのためには、XAML ScrollViewer から CompositionPropertySet (ScrollManipulationPropertySet と呼ばれます) にアクセスします。
ScrollManipulationPropertySet には、Translation と呼ばれる 1 つの Vector3 プロパティが含まれています。このプロパティによって、ScrollViewer のスクロール位置にアクセスすることができます。 ScrollManipulationPropertySet にアクセスすると、ExpressionAnimation で他の CompositionPropertySet と同様に、このプロパティを参照することができます。

作業を始める際の一般的な手順:

1. ElementCompositionPreview を使用して ScrollManipulationPropertySet にアクセスします。
    - `ElementCompositionPreview.GetScrollManipulationPropertySet(ScrollViewer scroller)`
1. PropertySet の Translation プロパティを参照する ExpressionAnimation を作成します。
    - 参照パラメーターは必ず設定してください。
1. ExpressionAnimation を使用して CompositionObject のプロパティをターゲットにします。

> [!NOTE]
> GetScrollManipulationPropertySet メソッドから返された PropertySet をクラス変数に割り当てることをお勧めします。 これにより、プロパティ セットがガベージ コレクションによってクリーンアップされなくなります。そのため、参照されている ExpressionAnimation は影響を受けません。 ExpressionAnimations は、式で使用されているどのオブジェクトに対しても強参照を保持しません。

## <a name="example"></a>例

前に示した視差のサンプルがどのように構成されているかを見てみましょう。 アプリのすべてのソース コードについては、[Window UI Dev Labs repo on GitHub](https://github.com/Microsoft/WindowsUIDevLabs) (GitHub の Windows UI 開発ラボ リポジトリ) をご覧ください。

最初に、ScrollManipulationPropertySet への参照を取得します。

```csharp
_scrollProperties =
    ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScrollViewer);
```

次の手順では、ScrollViewer のスクロール位置を利用する式を定義する ExpressionAnimation を作成します。

```csharp
_parallaxExpression = compositor.CreateExpressionAnimation();
_parallaxExpression.SetScalarParameter("StartOffset", 0.0f);
_parallaxExpression.SetScalarParameter("ParallaxValue", 0.5f);
_parallaxExpression.SetScalarParameter("ItemHeight", 0.0f);
_parallaxExpression.SetReferenceParameter("ScrollManipulation", _scrollProperties);
_parallaxExpression.Expression = "(ScrollManipulation.Translation.Y + StartOffset - (0.5 * ItemHeight)) * ParallaxValue - (ScrollManipulation.Translation.Y + StartOffset - (0.5 * ItemHeight))";
```

> [!NOTE]
> ExpressionBuilder ヘルパー クラスを利用して、これと同じ Expression を作成することもできます。次の文字列は必要ありません。

> ```csharp
> var scrollPropSet = _scrollProperties.GetSpecializedReference<ManipulationPropertySetReferenceNode>();
> var parallaxValue = 0.5f;
> var parallax = (scrollPropSet.Translation.Y + startOffset);
> _parallaxExpression = parallax * parallaxValue - parallax;
> ```

最後に、この ExpressionAnimation を実行し、視差で必要となる Visual をターゲットにします。 この場合、リストに表示される各項目用の画像がターゲットになります。

```csharp
Visual visual = ElementCompositionPreview.GetElementVisual(image);
visual.StartAnimation("Offset.Y", _parallaxExpression);
```